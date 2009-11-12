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
        long perChunkBytes;
        string acl;
        bool backup, sync, big, sub, subWithDelete;
        string keyArgument, fileArgument;
        string bucket, baseKey;

        protected override void Initialise(CommandLine cl)
        {
            if (cl.args.Count != 2)
            {
                // TODO We should probably allow multiple file names on the command line
                if (ExecutionEnvironment.IsLinux)
                    throw new SyntaxException("The put command requires two parameters. Did you remember to escape wildcard parameters?");
                else
                    throw new SyntaxException("The put command requires two parameters");
            }

            keyArgument = cl.args[0];
            fileArgument = cl.args[1];

            acl = Acl.GetOptionParameter(cl, typeof(Acl), false);
            backup = cl.options.ContainsKey(typeof(Backup));
            sync = cl.options.ContainsKey(typeof(Sync));
            big = cl.options.ContainsKey(typeof(Big));
            sub = cl.options.ContainsKey(typeof(Sub));
            if (sub)
                subWithDelete = (cl.options[typeof(Sub)] as Sub).withDelete;

            if (big && sub)
                throw new SyntaxException("The /big option is not currently compatible with the /sub option");

            if (big)
            {
                Big bigOption = (Big)cl.options[typeof(Big)];
                perChunkBytes = (long)(bigOption.chunkMegabytes * 1024.0 * 1024.0);
            }

            int slashIdx = keyArgument.IndexOf("/");
            if (slashIdx == -1)
            {
                baseKey = "";
                bucket = keyArgument;
            }
            else
            {
                baseKey = keyArgument.Substring(slashIdx + 1);
                bucket = keyArgument.Substring(0, slashIdx);

                if (sub && !baseKey.EndsWith("/"))
                    throw new SyntaxException("With the /sub option, either specify a bucket name only or a key that ends with a slash (/)");
            }
        }

        public override void Execute()
        {
            AWSAuthConnection svc = new AWSAuthConnection();
            SortedList headers = AWSAuthConnection.GetHeaders(acl, null);

            string directory, filename;

            if (fileArgument == "") // nothing specified; assume current directory
            {
                directory = Path.GetFullPath(".");
                filename = "*";
            }
            else if (Directory.Exists(fileArgument)) // only a directory specified
            {
                directory = Path.GetFullPath(fileArgument);
                filename = "*";
            }
            else if (fileArgument.IndexOf(Path.DirectorySeparatorChar) != -1) // directory and filename specified
            {
                directory = Path.GetFullPath(Path.GetDirectoryName(fileArgument));
                filename = Path.GetFileName(fileArgument);
            }
            else // only a filename specified
            {
                directory = Path.GetFullPath(".");
                filename = fileArgument;
            }

            if (!directory.EndsWith(Path.DirectorySeparatorChar.ToString()))
                directory = string.Concat(directory, Path.DirectorySeparatorChar.ToString());

            bool foundAnything = false;

            foreach (string file in Sub.GetFiles(directory, filename, sub))
            {
                foundAnything = true;

                if (backup && (File.GetAttributes(file) & FileAttributes.Archive) != FileAttributes.Archive)
                    continue;

                string key;
                if (sub)
                    key = baseKey + file.Substring(directory.Length).Replace("\\", "/");
                else
                    key = baseKey + Path.GetFileName(file);

                if (sync)
                {
                    DateTime? lastModified = svc.getLastModified(bucket, key);
                    if (lastModified.HasValue && lastModified.Value > File.GetLastWriteTimeUtc(file))
                        continue;
                }

                const long maxFileBytes = 5L * 1024L * 1024L * 1024L;

                if (sub && Directory.Exists(file))
                {
                    // Unlike S3Fox, we don't create dummy folder keys ending with _$folder$.  That's a bit of
                    // a hack, and would require special handling with the get and list commands resulting
                    // in us attempting to simulate a filesystem, which is not KISS enough for this project.
                    // And the only downside appears to be that there is no way to represent empty folders.
                }
                else
                {
                    using (FileStream fs = new FileStream(file, FileMode.Open, FileAccess.Read))
                    {
                        if (!big)
                        {
                            if (fs.Length > maxFileBytes)
                                throw new ArgumentOutOfRangeException(string.Format("{0} is too big; maximum file size on S3 is {1}GB. Type s3 help and see the /big option.",
                                    Path.GetFileName(file), maxFileBytes / 1024 / 1024 / 1024));
                            else
                            {
                                Console.WriteLine(key);
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
                                Console.WriteLine(thisKey);
                                svc.put(bucket, thisKey, fs, headers, fs.Position, putBytes).Connection.Close();
                                sequence++;
                            }
                        }
                    }
                }

                if (backup)
                    File.SetAttributes(file, File.GetAttributes(file) & ~FileAttributes.Archive);
            }

            if (!foundAnything)
                throw new FileNotFoundException(string.Format("No files found at {0}{1}", directory, filename));

            if (sub && subWithDelete)
                Sub.deleteKeys(directory, bucket, baseKey);
        }
      
    }
}
