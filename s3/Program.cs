// s3.exe
// Command-line Amazon AWS utility for .NET
// http://s3.codeplex.com/

// This intentionally targets .NET 2.0 rather than 3.5, as Amazon EC2 instances only come with 2.0 as supplied(?) and
// the primary design goal is to have one .exe with no supporting DLLs that runs on a plain vanilla server without 
// having to install anything.

// Permission is hereby granted, free of charge, to any person obtaining a copy of this software and associated documentation files (the "Software"), 
// to deal in the Software without restriction, including without limitation the rights to use, copy, modify, merge, publish, distribute, sublicense, 
// and/or sell copies of the Software, and to permit persons to whom the Software is furnished to do so, subject to the following conditions:
//
// The above copyright notice and this permission notice shall be included in all copies or substantial portions of the Software.
//
// THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY, 
// FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER 
// LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS 
// IN THE SOFTWARE.

using System;
using System.Collections.Generic;
using System.Configuration;
using System.Diagnostics;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;

using com.amazon.s3;
using s3.Properties; 

namespace s3
{
    class SyntaxError : Exception
    { }

    class NotFoundException : Exception
    {
        public string what;

        public NotFoundException(string what)
        {
            this.what = what;
        }
    }

    class Program
    {
        static void Main(string[] originalArgs)
        {
            string command;

            List<string> args = new List<string>();
            List<string> options = new List<string>();

            foreach (string a in originalArgs)
                if (a.StartsWith("/"))
                    options.Add(a.ToLower());
                else
                    args.Add(a);

            if (args.Count > 0)
                command = args[0].ToLower();
            else
                command = "";

            if (command == "auth" && args.Count == 3)
            {
                Settings.Default.AccessKeyId = args[1].Trim();
                Settings.Default.AccessKeySecret = args[2].Trim();
                Settings.Default.Save();
            }

            if (Settings.Default.AccessKeyId == "" || Settings.Default.AccessKeySecret == "" || (command == "auth" && args.Count == 1))
            {
                Console.Write("Enter your Access Key Id: ");
                Settings.Default.AccessKeyId = Console.ReadLine().Trim();
                Console.Write("Enter your Access Key Secret: ");
                Settings.Default.AccessKeySecret = Console.ReadLine().Trim();
                Settings.Default.Save();
            }

            AWSAuthConnection.OUR_ACCESS_KEY_ID = Settings.Default.AccessKeyId;
            AWSAuthConnection.OUR_SECRET_ACCESS_KEY = Settings.Default.AccessKeySecret;

            bool bigOption = options.Contains("/big");
            bool backupOption = options.Contains("/backup");
            bool newOption = options.Contains("/new");

            try
            {
                switch (command)
                {
                    case "get":
                        get(args, bigOption);
                        break;

                    case "put":
                        put(args, bigOption, backupOption, newOption);
                        break;

                    case "list":
                        list(args);
                        break;

                    case "auth":
                        // handled above
                        break;

                    case "snapshot":
                        snapshot(args);
                        break;

                    case "help":
                        Console.WriteLine(@"
s3 auth
    Prompts you for your S3 credentials for use in future invocations.

s3 auth <key> <secret>
    Sets authentication details non-interactively.

s3 put <bucket>[/<keyprefix>] <filename> [/big] [/backup] [/new]
    Puts the specified filename to S3. The filename excluding path is 
    suffixed to the end of the supplied key prefix.

    Adding the /big option splits files into 10MB chunks suffixed with .000, .001 etc.
    This is done without creating any temporary files on disk.

    Adding the /backup option causes only files with the archive attribute
    to be copied, and the archive attribute is reset after copying.

    Adding the /new option causes only files that don't already exist on S3
    to be copied

s3 get <bucket>/<key> [<filename>] [/big]
    Gets the specified object from S3. If no filename is supplied then 
    the suffix of the key after the final slash is used as the filename.

    Adding the /big option fetches a file or files split using the /big
    option with the put command.

s3 list [<bucket>[/<keyprefix>]]
    Lists the keys in the bucket beginning with the keyprefix, if 
    supplied.  With no paramters, gets the list of buckets.

s3 snapshot <volumeID>
    Starts an EBS snapshot.  Returns as soon as job begins.

");
                        break;

                    default:
                        throw new SyntaxError();
                }
            }
            catch (SyntaxError)
            {
                Console.WriteLine("Wrong syntax. Try s3 help");
            }
            catch (NotFoundException ex)
            {
                Console.WriteLine(string.Format("Not found: {0}", ex.what));
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private static void snapshot(List<string> args)
        {
            if (args.Count == 2)
            {
                string volumeId = args[1].Trim();
                Amazon.EC2.AmazonEC2Client client = new Amazon.EC2.AmazonEC2Client(AWSAuthConnection.OUR_ACCESS_KEY_ID, AWSAuthConnection.OUR_SECRET_ACCESS_KEY);
                Amazon.EC2.Model.CreateSnapshotRequest request = new Amazon.EC2.Model.CreateSnapshotRequest();
                request.VolumeId = volumeId;
                Amazon.EC2.Model.CreateSnapshotResponse response = client.CreateSnapshot(request);
                string snapshotId = response.CreateSnapshotResult.Snapshot.SnapshotId;
                Console.WriteLine("Started snapshot of volume {0} with snapshot ID {1}", volumeId, snapshotId);
            }
            else
                throw new SyntaxError();
        }

        static void streamToStream(Stream sIn, Stream sOut)
        {
            int Length = 256;
            Byte[] buffer = new Byte[Length];
            int bytesRead = sIn.Read(buffer, 0, Length);
            // write the required bytes
            while (bytesRead > 0)
            {
                sOut.Write(buffer, 0, bytesRead);
                bytesRead = sIn.Read(buffer, 0, Length);
            }
        }

        static void put(List<string> args, bool big, bool backup, bool newOnly)
        {
            AWSAuthConnection svc = new AWSAuthConnection();

            if (args.Count != 3)
                throw new SyntaxError();

            int slashIdx = args[1].IndexOf("/");
            string bucket, baseKey;
            if (slashIdx == -1)
            {
                baseKey = "";
                bucket = args[1];
            }
            else
            {
                baseKey = args[1].Substring(slashIdx + 1);
                bucket = args[1].Substring(0, slashIdx);
            }

            string directory = Path.GetDirectoryName(args[2]);
            string filename;

            if (directory == "")
            {
                directory = ".";
                filename = args[2];
            }
            else
            {
                Debug.Assert(args[2].StartsWith(directory));
                Debug.Assert(args[2][directory.Length] == '\\' || directory == "\\");

                filename = args[2].Substring(directory.Length);
                while (filename.StartsWith("\\"))
                    filename = filename.Substring(1);
            }

            List<string> files = new List<string>(Directory.GetFiles(directory, filename));

            if (files.Count == 0)
                throw new NotFoundException(filename);

            List<string> filesOnS3 = new List<string>();

            if (newOnly)
            {
                ListBucketResponse listResp = svc.listBucket(bucket, baseKey, "", 0, null);
                listResp.Connection.Close();

                foreach (ListEntry e in listResp.Entries)
                    filesOnS3.Add(e.Key);
            }

            foreach (string file in files)
            {
                if (backup && (File.GetAttributes(file) & FileAttributes.Archive) != FileAttributes.Archive)
                    continue;

                string key = baseKey + Path.GetFileName(file);

                if (newOnly && filesOnS3.Contains(key))
                    continue;

                const long maxFileBytes = 5L * 1024L * 1024L * 1024L;

                using (FileStream fs = new FileStream(file, FileMode.Open, FileAccess.Read))
                {
                    if (!big)
                    {
                        if (fs.Length > maxFileBytes)
                            Console.WriteLine(string.Format("{0} is too big; maximum file size on S3 is {1}GB. Type s3 help and see the /big option.",
                                Path.GetFileName(file), maxFileBytes / 1024 / 1024 / 1024));
                        else
                        {
                            Console.WriteLine(string.Format("Writing to key {0}", key));
                            svc.put(bucket, key, fs, null).Connection.Close();
                        }
                    }
                    else
                    {
                        const long perChunkBytes = 10L * 1024L * 1024L;

                        int sequence = 0;
                        while (fs.Position < fs.Length)
                        {
                            long putBytes = Math.Min(perChunkBytes, fs.Length - fs.Position);
                            string thisKey = string.Format("{0}.{1:000}", key, sequence);
                            Console.WriteLine(string.Format("Writing to key {0}", thisKey));
                            svc.put(bucket, thisKey, fs, null, fs.Position, putBytes).Connection.Close();
                            sequence++;
                        }
                    }
                }

                if (backup)
                    File.SetAttributes(file, File.GetAttributes(file) & ~FileAttributes.Archive);
            }
        }

        static void get(List<string> args, bool big)
        {
            AWSAuthConnection svc = new AWSAuthConnection();

            string resource, filename;
            if (args.Count == 2)
            {
                resource = args[1];
                int lastSlash = resource.LastIndexOf("/");
                if (lastSlash == -1)
                    throw new SyntaxError();
                filename = resource.Substring(lastSlash + 1);
            }
            else if (args.Count == 3)
            {
                resource = args[1];
                filename = args[2];
            }
            else
                throw new SyntaxError();

            int firstSlash = resource.IndexOf("/");
            if (firstSlash == -1)
                throw new SyntaxError();

            string bucket = resource.Substring(0, firstSlash);
            string key = resource.Substring(firstSlash + 1);
            List<string> keys = new List<string>();

            if (!big)
            {
                if (key.EndsWith("*"))
                {
                    ListBucketResponse list = svc.listBucket(bucket, key.Substring(0, key.Length - 1), "", 0, null);
                    list.Connection.Close();

                    foreach (ListEntry e in list.Entries)
                        keys.Add(e.Key);
                }
                else
                    keys.Add(key);
            }
            else
            {
                if (key.EndsWith("*"))
                    throw new SyntaxError();

                ListBucketResponse list = svc.listBucket(bucket, key + ".", "", 0, null);
                list.Connection.Close();
                foreach (ListEntry e in list.Entries)
                    if (Regex.IsMatch(e.Key, string.Format(@"^{0}\.\d\d\d$", key)))
                        keys.Add(e.Key);
            }

            if (keys.Count == 0)
                throw new NotFoundException(key);
            else
            {
                FileStream fs = null;

                if (big)
                    fs = new FileStream(filename, FileMode.Create, FileAccess.ReadWrite);

                keys.Sort();
                int sequence = 0;

                foreach (string thisKey in keys)
                {
                    GetResponse getResp = svc.get(bucket, thisKey, null, true);
                    Console.WriteLine(string.Format("Reading from {0}/{1}", bucket, thisKey));

                    if (!big)
                    {
                        string thisFilename = thisKey.Substring(thisKey.LastIndexOf("/") + 1);
                        fs = new FileStream(thisFilename, FileMode.Create, FileAccess.ReadWrite);
                    }
                    else if (!thisKey.EndsWith(string.Format(".{0:000}", sequence)))
                    {
                        throw new NotFoundException(string.Format("Object with sequence number {0}", sequence));
                    }

                    streamToStream(getResp.Object.Stream, fs);
                    getResp.Object.Stream.Close();

                    if (!big)
                        fs.Close();

                    getResp.Connection.Close();
                    sequence++;
                }

                if (big)
                    fs.Close();
            }
        }

        static void list(List<string> args)
        {
            AWSAuthConnection svc = new AWSAuthConnection();

            if (args.Count == 1)
            {
                ListAllMyBucketsResponse allResp = svc.listAllMyBuckets(null);
                allResp.Connection.Close();
                foreach (Bucket b in allResp.Buckets)
                    Console.WriteLine(b.Name);
                Console.WriteLine(string.Format("{0} files listed", allResp.Buckets.Count));
            }
            else if (args.Count == 2)
            {
                int slashIdx = args[1].IndexOf("/");
                string bucket, prefix;
                if (slashIdx == -1)
                {
                    bucket = args[1];
                    prefix = "";
                }
                else
                {
                    bucket = args[1].Substring(0, slashIdx);
                    prefix = args[1].Substring(slashIdx + 1);
                }

                ListBucketResponse listResp = svc.listBucket(bucket, prefix, "", 0, null);
                listResp.Connection.Close();
                foreach (ListEntry e in listResp.Entries)
                    Console.WriteLine(string.Format("{0} {1:0.0}M", e.Key, e.Size / (1024 * 1024)));
                Console.WriteLine(string.Format("{0} files listed", listResp.Entries.Count));
            }
            else
                throw new SyntaxError();
        }
    }
}

namespace com.amazon.s3
{
    public partial class AWSAuthConnection
    {
        public static string OUR_ACCESS_KEY_ID, OUR_SECRET_ACCESS_KEY;
    }
}
