using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;

using com.amazon.s3;

using s3.Options;

namespace s3.Commands
{
    class Get : Command
    {
        bool big, sub;
        string resource, filename;
        string bucket, key;
        bool explicitFilename;

        const string slashRequiredError = "The first parameter to the get command must have a slash (/) between the bucket name and the key";

        protected override void initialise(CommandLine cl)
        {
            if (cl.args.Count < 1 || cl.args.Count > 2)
                throw new SyntaxException("The get command requires one or two parameters");

            big = cl.options.ContainsKey(typeof(Big));
            sub = cl.options.ContainsKey(typeof(Sub));

            if (big && sub)
                throw new SyntaxException("The /big option is not currently compatible with the /sub option");

            resource = cl.args[0];
            int firstSlash = resource.IndexOf("/");
            if (firstSlash == -1)
            {
                if (!sub)
                    throw new SyntaxException(slashRequiredError);
                bucket = resource;
                key = "";
            }
            else
            {
                bucket = resource.Substring(0, firstSlash);
                key = resource.Substring(firstSlash + 1);
                if (sub && !key.EndsWith("/"))
                    throw new SyntaxException("With the /sub option, the first parameter must be just a bucket name or must end with a slash (/)");
            }

            if (!sub)
            {
                if (cl.args.Count == 1)
                {
                    int lastSlash = resource.LastIndexOf("/");
                    if (lastSlash == -1)
                        throw new SyntaxException(slashRequiredError);
                    filename = resource.Substring(lastSlash + 1);
                    explicitFilename = false;
                }
                else
                {
                    filename = cl.args[1];
                    explicitFilename = true;
                }
            }
            else
            {
                if (cl.args.Count == 1)
                    filename = ".";
                else
                {
                    filename = cl.args[1];
                    if (!Directory.Exists(filename))
                        throw new SyntaxException("With the /sub option, the second parameter must be an existing directory");
                }
            }
        }

        public override void execute()
        {
            AWSAuthConnection svc = new AWSAuthConnection();
            IEnumerable<ListEntry> keys;

            if (!big)
            {
                if (key.EndsWith("*") || sub)
                {
                    while (key.EndsWith("*"))
                        key = key.Substring(0, key.Length - 1);
                    IterativeList list = new IterativeList(bucket, key);
                    if (list.Count == IterativeList.EntryCount.some && explicitFilename)
                        throw new SyntaxException("You specified a destination filename but there is more than one key; can't copy multiple keys to one file");
                    keys = list;
                }
                else
                {
                    List<ListEntry> singleton = new List<ListEntry>();
                    singleton.Add(new ListEntry(key, DateTime.UtcNow, null, 0, null, null));
                    keys = singleton;
                }
            }
            else
            {
                if (key.EndsWith("*"))
                    throw new SyntaxException("Can't use wildcard (*) with the /big option");
                else
                {
                    List<ListEntry> sorted = new List<ListEntry>();
                    foreach (ListEntry e in new IterativeList(bucket, key + ".", new Regex("^" + key + @"\.\d{3,5}$")))
                        sorted.Add(e);
                    sorted.Sort(numericSuffixCompare);
                    keys = sorted;
                }
            }

            if (keys is IterativeList && (keys as IterativeList).Count == IterativeList.EntryCount.zero)
                throw new FileNotFoundException("No keys found: " + key);
            else
            {
                FileStream fs = null;

                ConsoleCancelEventHandler deletePartialFileHandler = delegate
                {
                    if (fs != null)
                    {
                        try { fs.Close(); }
                        catch { }
                        File.Delete(fs.Name);
                        Console.WriteLine("Deleted partial file: " + fs.Name);
                    }
                };

                Console.CancelKeyPress += deletePartialFileHandler;

                try
                {
                    if (big)
                        fs = new FileStream(filename, FileMode.Create, FileAccess.ReadWrite);

                    int sequence = 0;

                    foreach (ListEntry entry in keys)
                    {
                        GetResponse getResp = svc.get(bucket, entry.Key, null, true);
                        Console.WriteLine(string.Format("{0}/{1}", bucket, entry.Key));

                        if (!big)
                        {
                            string thisFilename;
                            if (sub)
                            {
                                thisFilename = Path.Combine(filename, keyToFilename(entry.Key.Substring(key.Length)));
                                string directoryName = Path.GetDirectoryName(thisFilename);
                                if (!Directory.Exists(directoryName))
                                    Directory.CreateDirectory(directoryName);
                            }
                            else if (explicitFilename)
                                thisFilename = filename;
                            else
                                thisFilename = entry.Key.Substring(entry.Key.LastIndexOf("/") + 1);
                            fs = new FileStream(thisFilename, FileMode.Create, FileAccess.ReadWrite);
                        }
                        else if (!entry.Key.EndsWith(string.Format(".{0:000}", sequence)))
                            throw new FileNotFoundException(string.Format("Object with sequence number {0} not found", sequence));

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
                catch
                {
                    deletePartialFileHandler(null, null);
                    throw;
                }
                finally
                {
                    Console.CancelKeyPress -= deletePartialFileHandler;
                }
            }
        }

        private string keyToFilename(string key)
        {
            string ret = key.Replace("/", Path.DirectorySeparatorChar.ToString());
            while (ret.StartsWith(Path.DirectorySeparatorChar.ToString()))
                ret = ret.Substring(1);
            return ret;
        }

        private static int numericSuffixCompare(ListEntry x, ListEntry y)
        {
            int x1 = int.Parse(x.Key.Substring(x.Key.LastIndexOf(".") + 1));
            int y1 = int.Parse(y.Key.Substring(y.Key.LastIndexOf(".") + 1));
            return x1.CompareTo(y1);
        }

        private static void streamToStream(Stream sIn, Stream sOut)
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

        public override string[] getHelpText()
        {
            return new string[] {
@"s3 get <bucket>/<keyprefix> [<path>] [/big] [/sub]
Examples:
s3 get mybucket/pic*
s3 get mybucket/pictures/ /sub
    
    Gets the specified object(s) from S3. If no filename is supplied then the
    suffix of the key after the final slash is used as the filename, except
    with the /sub option (see below).

    A trailing * on the end of the key is treated as a wildcard, except when 
    the /big option or a full <filename> is specified.

    /big fetches a file or files split using /big with the put command.

    /sub causes all keys beginning with the specified keyprefix to be fetched
    and forward slashes (/) in the key names used to create directories as
    needed.  This enables a whole directory hierarchy uploaded with 'put /sub' 
    to be downloaded.
"};
        }
    }
}
