using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

using com.amazon.s3;
using System.Collections;

namespace s3.Options
{
    class Sub : OptionWithParameter<string>
    {
        private const string deleteOption = "withdelete";

        public bool withDelete = false;

        protected override bool ParameterIsCompulsory
        {
            get { return false; }
        }

        protected override void ParameterIsSet()
        {
            if (Parameter != null && !Parameter.Equals(deleteOption, StringComparison.InvariantCultureIgnoreCase))
                throw new SyntaxException("The /sub option must be specified as /sub or /sub:withdelete");

            withDelete = Parameter.Equals(deleteOption, StringComparison.InvariantCultureIgnoreCase);
        }

        public static IEnumerable<string> GetFiles(string directory, string pattern, bool recurse)
        {
            IEnumerable files = null;

            if (Utils.IsMono)
            {
                // if we're running on Mono, don't use the FileDirectoryEnumerable as it relies on win api's
                List<string> fileList = new List<string>();
                foreach (var file in Directory.GetFiles(directory, pattern))
                    fileList.Add(file);
                foreach (var dir in Directory.GetDirectories(directory))
                    fileList.Add(dir);
                files = fileList;
            }
            else
            {
                FileDirectoryEnumerable fde = new FileDirectoryEnumerable();
                fde.SearchPath = directory;
                if (!string.IsNullOrEmpty(pattern))
                    fde.SearchPattern = pattern;
                files = fde;
            }

            List<string> subdirectories = new List<string>();

            foreach (string f in files)
            {
                string fullPath = Path.Combine(directory, f);

                FileInfo fi = new FileInfo(fullPath);
                if ((fi.Attributes & (FileAttributes.Hidden | FileAttributes.System)) != 0)
                    continue;

                bool isDirectory = Directory.Exists(fullPath);

                if (isDirectory && !fullPath.EndsWith(Path.DirectorySeparatorChar.ToString()))
                    fullPath = string.Concat(fullPath, Path.DirectorySeparatorChar.ToString());

                if (recurse && isDirectory)
                {
                    // it's neater to keep the recursion until we've finished with the files in this directory, but
                    // we don't want to build up a long list of subdirectories in memory, so let's give up on that
                    // if there are a lot of subdirectories:
                    if (subdirectories.Count < 100)
                        subdirectories.Add(fullPath);
                    else
                    {
                        yield return fullPath;
                        foreach (string fn in GetFiles(fullPath, pattern, recurse))
                            yield return fn;
                    }
                }

                if (!isDirectory)
                    yield return fullPath;
            }

            if (recurse)
                foreach (string d in subdirectories)
                {
                    yield return d;
                    foreach (string fn in GetFiles(d, pattern, recurse))
                        yield return fn;
                }
        }

        /// <summary>
        /// Deletes keys from S3 that don't correspond with any file in the specified directory
        /// </summary>
        /// <param name="directory">The directory base where to look for matching files</param>
        /// <param name="bucket">The bucket from which keys will be deleted</param>
        /// <param name="baseKey">The base key</param>
        internal static void deleteKeys(string directory, string bucket, string baseKey)
        {
            AWSAuthConnection svc = new AWSAuthConnection();

            foreach (ListEntry e in new IterativeList(bucket, baseKey))
            {
                string filename = Path.Combine(directory, e.Key.Substring(baseKey.Length));
                if (!File.Exists(filename) && !Directory.Exists(filename))
                {
                    Console.Write(e.Key + "... ");
                    if (Yes.Confirm("Delete this key? [y/N]"))
                    {
                        svc.delete(bucket, e.Key, null).Connection.Close();
                        Console.WriteLine(" deleted.");
                    }
                    else
                        Console.WriteLine(" ignored.");

                }
            }
        }
    }
}
