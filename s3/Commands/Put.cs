using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Text;

using com.amazon.s3;

using s3.Options;

namespace s3.Commands
{
    class Put : Command
    {
        const double defaultChunkMegabytes = 10;

        long perChunkBytes;
        string acl;
        bool backup, sync, big;
        string keyArgument, fileArgument;

        protected override void initialise(CommandLine cl)
        {
            if (cl.args.Count != 2)
                throw new SyntaxError("The put command requires two arguments");

            keyArgument = cl.args[0];
            fileArgument = cl.args[1];

            acl = Acl.getOptionParameter(cl, typeof(Acl), false);
            backup = cl.options.ContainsKey(typeof(Backup));
            sync = cl.options.ContainsKey(typeof(Sync));
            big = cl.options.ContainsKey(typeof(Big));

            if (big)
            {
                Big bigOption = (Big)cl.options[typeof(Big)];

                double chunkMegabytes;
                if (bigOption.parameterIsPresent)
                    chunkMegabytes = bigOption.parameter;
                else
                    chunkMegabytes = defaultChunkMegabytes;

                perChunkBytes = (long)(chunkMegabytes * 1024.0 * 1024.0);
            }
        }

        public override void execute()
        {
            AWSAuthConnection svc = new AWSAuthConnection();

            SortedList headers = AWSAuthConnection.getHeaders(acl, null);

            int slashIdx = keyArgument.IndexOf("/");
            string bucket, baseKey;
            if (slashIdx == -1)
            {
                baseKey = "";
                bucket = keyArgument;
            }
            else
            {
                baseKey = keyArgument.Substring(slashIdx + 1);
                bucket = keyArgument.Substring(0, slashIdx);
            }

            string directory = Path.GetDirectoryName(fileArgument);
            string filename;

            if (directory == "")
            {
                directory = ".";
                filename = fileArgument;
            }
            else
            {
                Debug.Assert(fileArgument.StartsWith(directory));
                Debug.Assert(fileArgument[directory.Length] == '\\' || directory == "\\");

                filename = fileArgument.Substring(directory.Length);
                while (filename.StartsWith("\\"))
                    filename = filename.Substring(1);
            }

            List<string> files = new List<string>(Directory.GetFiles(directory, filename));

            if (files.Count == 0)
                throw new NotFoundException(filename);

            foreach (string file in files)
            {
                if (backup && (File.GetAttributes(file) & FileAttributes.Archive) != FileAttributes.Archive)
                    continue;

                string key = baseKey + Path.GetFileName(file);

                if (sync)
                {
                    DateTime? lastModified = svc.getLastModified(bucket, key);
                    if (lastModified.HasValue && lastModified.Value > File.GetLastWriteTimeUtc(file))
                        continue;
                }

                const long maxFileBytes = 5L * 1024L * 1024L * 1024L;

                using (FileStream fs = new FileStream(file, FileMode.Open, FileAccess.Read))
                {
                    if (!big)
                    {
                        if (fs.Length > maxFileBytes)
                            throw new ArgumentOutOfRangeException(string.Format("{0} is too big; maximum file size on S3 is {1}GB. Type s3 help and see the /big option.",
                                Path.GetFileName(file), maxFileBytes / 1024 / 1024 / 1024));
                        else
                        {
                            Console.WriteLine(string.Format("Writing to key {0}", key));
                            svc.put(bucket, key, fs, headers).Connection.Close();
                        }
                    }
                    else
                    {
                        int sequence = 0;
                        while (fs.Position < fs.Length)
                        {
                            long putBytes = Math.Min(perChunkBytes, fs.Length - fs.Position);
                            string thisKey = string.Format("{0}.{1:000}", key, sequence);
                            Console.WriteLine(string.Format("Writing to key {0}", thisKey));
                            svc.put(bucket, thisKey, fs, headers, fs.Position, putBytes).Connection.Close();
                            sequence++;
                        }
                    }
                }

                if (backup)
                    File.SetAttributes(file, File.GetAttributes(file) & ~FileAttributes.Archive);
            }
        }
    }
}
