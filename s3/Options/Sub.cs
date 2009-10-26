using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

using com.amazon.s3;

namespace s3.Options
{
    class Sub : OptionWithParameter<string>
    {
        private const string deleteOption = "withdelete";

        public bool withDelete = false;

        protected override bool parameterIsCompulsory
        {
            get { return false; }
        }

        protected override void parameterIsSet()
        {
            if (parameter != null && !parameter.Equals(deleteOption, StringComparison.InvariantCultureIgnoreCase))
                throw new SyntaxException("The /sub option must be specified as /sub or /sub:withdelete");

            withDelete = parameter.Equals(deleteOption, StringComparison.InvariantCultureIgnoreCase);
        }

        public static IEnumerable<string> getFiles(string directory, string pattern, bool recurse)
        {
            FileDirectoryEnumerable fde = new FileDirectoryEnumerable();
            fde.SearchPath = directory;
            if (!string.IsNullOrEmpty(pattern))
                fde.SearchPattern = pattern;

            List<string> subdirectories = new List<string>();

            foreach (string f in fde)
            {
                string fullPath = Path.Combine(directory, f);

                FileInfo fi = new FileInfo(fullPath);
                if ((fi.Attributes & (FileAttributes.Hidden | FileAttributes.System)) != 0)
                    continue;

                bool isDirectory = Directory.Exists(fullPath);

                if (isDirectory && !fullPath.EndsWith("\\"))
                    fullPath = string.Concat(fullPath, "\\");

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
                        foreach (string fn in getFiles(fullPath, pattern, recurse))
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
                    foreach (string fn in getFiles(d, pattern, recurse))
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

                    Console.WriteLine(e.Key);
                    if (Yes.confirm("Delete this key? (yes/no)"))
                        svc.delete(bucket, e.Key, null).Connection.Close();
                }
            }
        }
    }
}
