using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Security.Cryptography;
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

        protected override void Initialise(CommandLine cl)
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

        public override void Execute()
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
                    foreach (ListEntry e in new IterativeList(bucket, key + ".", new Regex("^" + Regex.Escape(key) + @"\.\d{3,5}$")))
                        sorted.Add(e);
                    if (sorted.Count == 0)
                        throw new FileNotFoundException("Not found: " + key + ".000");
                    sorted.Sort(NumericSuffixCompare);
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

                        if (!big)
                        {
                            string thisFilename;
                            if (sub)
                            {
                                thisFilename = Path.Combine(filename, KeyToFilename(entry.Key.Substring(key.Length)));
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
                        else
                        {
                            if (!entry.Key.EndsWith(string.Format(".{0:000}", sequence)))
                            {
                                Console.Error.WriteLine(string.Format("Warning: The download has completed because there is no chunk number {0}, but there are chunks on S3 with higher numbers.  These chunks were probably uploaded to S3 when the file was larger than it is now, but it could indicate a missing chunk.  To surpress this message, delete the later chunks.", sequence));
                                break;
                            }
                        }

                        Console.WriteLine(string.Format("{0}/{1}", bucket, entry.Key));
                        StreamToStream(getResp.Object.Stream, fs, getResp.Connection.Headers["ETag"], entry.Key, entry.Size);
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

        private string KeyToFilename(string key)
        {
            string ret = key.Replace("/", Path.DirectorySeparatorChar.ToString());
            while (ret.StartsWith(Path.DirectorySeparatorChar.ToString()))
                ret = ret.Substring(1);
            return ret;
        }

        private static int NumericSuffixCompare(ListEntry x, ListEntry y)
        {
            int x1 = int.Parse(x.Key.Substring(x.Key.LastIndexOf(".") + 1));
            int y1 = int.Parse(y.Key.Substring(y.Key.LastIndexOf(".") + 1));
            return x1.CompareTo(y1);
        }

        private static void StreamToStream(Stream sIn, Stream sOut, string md5Expected, string key, long totalBytes)
        {
            MD5 md5Hasher = MD5.Create();
            int Length = 256;
            Byte[] buffer = new Byte[Length];
            long bytesSoFar = 0;
            long ct = 0;

            while (true)
            {
                int bytesRead = sIn.Read(buffer, 0, Length);
                if (bytesRead == 0) break;
                md5Hasher.TransformBlock(buffer, 0, bytesRead, buffer, 0);
                sOut.Write(buffer, 0, bytesRead);
                bytesSoFar += bytesRead;
                ct++;

                if (ct % 100 == 0 || bytesSoFar == totalBytes)
                    Progress.reportProgress(key, bytesSoFar, totalBytes);
            }

            md5Hasher.TransformFinalBlock(new byte[0], 0, 0);
            string md5Calculated = "\"" + Utils.BytesToHex(md5Hasher.Hash) + "\"";
            if (!md5Calculated.Equals(md5Expected, StringComparison.InvariantCultureIgnoreCase))
                throw new Exception("MD5 mismatch on download.  Possible data corruption!");
        }
    }
}
