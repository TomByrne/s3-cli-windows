using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace com.amazon.s3
{
    public partial class AWSAuthConnection
    {
        public static string OUR_ACCESS_KEY_ID, OUR_SECRET_ACCESS_KEY;
        public static bool verbose = false;

        public static SortedList getHeaders(string acl, string mime)
        {
            SortedList headers = new SortedList();
            if (acl != null)
                headers.Add("x-amz-acl", acl);
            if (mime != null)
                headers.Add("Content-Type", mime);
            return headers;
        }

        public IEnumerable<ListEntry> iterativeList(string bucket, string prefix)
        {
            string marker = "";

            while (true)
            {
                ListBucketResponse listResp = listBucket(bucket, prefix, marker, 250, null);
                listResp.Connection.Close();
                foreach (ListEntry e in listResp.Entries)
                    yield return e;

                if (listResp.IsTruncated)
                    marker = listResp.Entries[listResp.Entries.Count - 1].Key;
                else
                    yield break;
            }
        }
    }
}
