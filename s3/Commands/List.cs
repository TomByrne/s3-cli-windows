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
    class List : Command
    {
        bool listBuckets = false;
        bool showStorageClass = false;
        string bucket, prefix;

        protected override void Initialise(CommandLine cl)
        {
            if (cl.args.Count == 0)
                listBuckets = true;
            else if (cl.args.Count == 1)
            {
                int slashIdx = cl.args[0].IndexOf("/");
                if (slashIdx == -1)
                {
                    bucket = cl.args[0];
                    prefix = "";
                }
                else
                {
                    bucket = cl.args[0].Substring(0, slashIdx);
                    prefix = cl.args[0].Substring(slashIdx + 1);
                }

                showStorageClass = cl.options.ContainsKey(typeof(StorageClass));
            }
            else
                throw new SyntaxException("The list command requires either zero or one parameters");
        }

        public override void Execute()
        {
            AWSAuthConnection svc = new AWSAuthConnection();

            if (listBuckets)
            {
                ListAllMyBucketsResponse allResp = svc.listAllMyBuckets(null);
                allResp.Connection.Close();
                foreach (Bucket b in allResp.Buckets)
                    Console.WriteLine(b.Name);
                Console.WriteLine(string.Format("{0} files listed", allResp.Buckets.Count));
            }
            else
            {
                if (prefix.EndsWith("*"))
                    prefix = prefix.Substring(0, prefix.Length - 1);

                int fileCount = 0;
                foreach (ListEntry e in new IterativeList(bucket, prefix))
                {
                    string storageDescription = (showStorageClass && e.StorageClass.Length > 0) ? e.StorageClass[0] + " " : string.Empty;
                    Console.WriteLine(string.Format("{2}\t{1:0.0}M\t{3}{0}", e.Key, e.Size / (1024 * 1024), e.LastModified, storageDescription));
                    fileCount++;
                }

                Console.WriteLine(string.Format("{0} files listed", fileCount));
            }
        }
    }
}
