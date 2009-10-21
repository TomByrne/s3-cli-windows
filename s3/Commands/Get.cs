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
        bool big;
        string resource, filename;
        bool explicitFilename;

        const string slashRequiredError = "The first parameter to the get command must have a slash (/) between the bucket name and the key";

        protected override void initialise(CommandLine cl)
        {
            if (cl.args.Count == 1)
            {
                resource = cl.args[0];
                int lastSlash = resource.LastIndexOf("/");
                if (lastSlash == -1)
                    throw new SyntaxError(slashRequiredError);
                filename = resource.Substring(lastSlash + 1);
                explicitFilename = false;
            }
            else if (cl.args.Count == 2)
            {
                resource = cl.args[0];
                filename = cl.args[1];
                explicitFilename = true;
            }
            else
                throw new SyntaxError("The get command requires one or two arguments");

            big = cl.options.ContainsKey(typeof(Big));
        }

        public override void execute()
        {
            AWSAuthConnection svc = new AWSAuthConnection();

            int firstSlash = resource.IndexOf("/");
            if (firstSlash == -1)
                throw new SyntaxError(slashRequiredError);

            string bucket = resource.Substring(0, firstSlash);
            string key = resource.Substring(firstSlash + 1);
            List<string> keys = new List<string>();

            if (!big)
            {
                if (key.EndsWith("*"))
                {
                    foreach (ListEntry e in svc.iterativeList(bucket, key.Substring(0, key.Length - 1)))
                        keys.Add(e.Key);
                    if (keys.Count > 1 && explicitFilename)
                        throw new SyntaxError("You specified a destination filename but there is more than one key; can't copy multiple keys to one file");
                }
                else
                    keys.Add(key);
            }
            else
            {
                if (key.EndsWith("*"))
                    throw new SyntaxError("Can't use wildcard (*) with the /big option");

                foreach (ListEntry e in svc.iterativeList(bucket, key + "."))
                    if (Regex.IsMatch(e.Key, "^" + key + @"\.\d{3,5}$"))
                        keys.Add(e.Key);
            }

            if (keys.Count == 0)
                throw new NotFoundException(key);
            else
            {
                FileStream fs = null;

                if (big)
                {
                    fs = new FileStream(filename, FileMode.Create, FileAccess.ReadWrite);
                    keys.Sort(numericSuffixCompare);
                }
                else
                    keys.Sort();

                int sequence = 0;

                foreach (string thisKey in keys)
                {
                    GetResponse getResp = svc.get(bucket, thisKey, null, true);
                    Console.WriteLine(string.Format("Reading from {0}/{1}", bucket, thisKey));

                    if (!big)
                    {
                        string thisFilename;
                        if (explicitFilename)
                            thisFilename = filename;
                        else
                            thisFilename = thisKey.Substring(thisKey.LastIndexOf("/") + 1);
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

        private static int numericSuffixCompare(string x, string y)
        {
            int x1 = int.Parse(x.Substring(x.LastIndexOf(".") + 1));
            int y1 = int.Parse(y.Substring(y.LastIndexOf(".") + 1));
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
    }
}
