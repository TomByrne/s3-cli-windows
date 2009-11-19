using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

using com.amazon.s3;

namespace s3
{
    /// <summary>
    /// Makes S3 list requests, ensuring we get the first result as quickly as possible AND also
    /// that we fetch all the results as quickly as possible in the background so that we get a
    /// consistent list of keys at a single point in time even if the caller takes hours to iterate
    /// through the entries, as may be the case with the 'get' command.
    /// </summary>
    class IterativeList : IEnumerable<ListEntry>
    {
        readonly string bucket, prefix;
        readonly Regex regex;
        readonly IEnumerable<ListEntry> iterator;

        AWSAuthConnection svc = new AWSAuthConnection();
        string marker = "";
        ListBucketResponse resp;

        public enum EntryCount
        {
            zero,
            one,
            some
        }

        public EntryCount Count
        {
            get;
            private set;
        }

        public IterativeList(string bucket, string prefix)
        {
            this.bucket = bucket;
            this.prefix = prefix;
            this.regex = null;
            iterator = iterativeList();
            resp = FetchBatch();

            if (resp.Entries.Count == 0)
                Count = EntryCount.zero;
            else if (resp.Entries.Count == 1)
                Count = EntryCount.one;
            else
                Count = EntryCount.some;
        }

        public IterativeList(string bucket, string prefix, Regex regex)
            : this(bucket, prefix)
        {
            this.regex = regex;
        }

        private IEnumerable<ListEntry> iterativeList()
        {
            while (true)
            {
                foreach (ListEntry e in resp.Entries)
                    if (regex == null || regex.IsMatch(e.Key))
                        yield return e;

                if (resp.IsTruncated)
                {
                    marker = resp.Entries[resp.Entries.Count - 1].Key;
                    resp = FetchBatch();
                }
                else
                    yield break;
            }
        }

        bool first = true;

        private ListBucketResponse FetchBatch()
        {
            ListBucketResponse listResp = svc.listBucket(bucket, prefix, marker, first ? 10 : 250, null);
            listResp.Connection.Close();
            first = false;
            return listResp;
        }

        public IEnumerator<ListEntry> GetEnumerator()
        {
            return new IterativeListEnumerator(iterator.GetEnumerator());
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return new IterativeListEnumerator(iterator.GetEnumerator());
        }

        private class IterativeListEnumerator : IEnumerator<ListEntry>
        {
            private readonly IEnumerator<ListEntry> original;

            public IterativeListEnumerator(IEnumerator<ListEntry> original)
            {
                this.original = original;
            }

            public ListEntry Current
            {
                get { return original.Current; }
            }

            public void Dispose()
            {
                original.Dispose();
            }

            object IEnumerator.Current
            {
                get { return original.Current; }
            }

            public bool MoveNext()
            {
                return original.MoveNext();
            }

            public void Reset()
            {
                original.Reset();
            }
        }
    }
}
