// This software code is made available "AS IS" without warranties of any        
// kind.  You may copy, display, modify and redistribute the software            
// code either by itself or as incorporated into your code; provided that        
// you do not remove any proprietary notices.  Your use of this software         
// code is at your own risk and you waive any claim against Amazon               
// Digital Services, Inc. or its affiliates with respect to your use of          
// this software code. (c) 2006 Amazon Digital Services, Inc. or its             
// affiliates.          


using System;
using System.Collections;
using System.Collections.Generic;
using System.Net;
using System.Text;
using System.Xml;

namespace com.amazon.s3
{
    public class ListBucketResponse : Response
    {
        /// <summary>
        /// The name of the bucket being listed.  Null if the request fails.
        /// </summary>
        private string name;
        public string Name
        {
            get
            {
                return name;
            }
        }

        /// <summary>
        /// The prefix echoed back from the request.  Null if the request fails.
        /// </summary>
        private string prefix;
        public string Prefix
        {
            get
            {
                return prefix;
            }
        }

        /// <summary>
        /// The marker echoed back from the request.  Null if the request fails.
        /// </summary>
        private string marker;
        public string Marker
        {
            get
            {
                return marker;
            }
        }

        /// <summary>
        /// The delimiter echoed back from the request.  Null if not specified in
        /// the request or it fails.
        /// </summary>
        private string delimiter;
        public string Delimiter
        {
            get
            {
                return delimiter;
            }
        }

        /// <summary>
        /// The maxKeys echoed back from the request if specified.  0 if the request fails.
        /// </summary>
        private int maxKeys;
        public int MaxKeys
        {
            get
            {
                return maxKeys;
            }
        }

        /// <summary>
        /// Indicates if there are more results to the list.  True if the current
        /// list results have been truncated.  The value will be false if the request
        /// fails.
        /// </summary>
        private bool isTruncated;
        public bool IsTruncated
        {
            get
            {
                return isTruncated;
            }
        }

        /// <summary>
        /// Indicates what to use as a marker for subsequent list requests in the event
        /// that the results are truncated.  Present only when a delimiter is specified.
        /// Null if the requests fails.
        /// </summary>
        private string nextMarker;
        public string NextMarker
        {
            get
            {
                return nextMarker;
            }
        }

        /// <summary>
        /// A list of ListEntry objects representing the objects in the given bucket.
        /// Null if the request fails.
        /// </summary>
        private List<ListEntry> entries;
        public List<ListEntry> Entries
        {
            get
            {
                return entries;
            }
        }

        /// <summary>
        /// A list of CommonPrefixEntry objects representing the common prefixes of the
        /// keys that matched up to the delimiter.  Null if the request fails.
        /// </summary>
        private List<CommonPrefixEntry> commonPrefixEntries;
        public List<CommonPrefixEntry> CommonPrefixEntries
        {
            get
            {
                return commonPrefixEntries;
            }
        }

        public ListBucketResponse(WebRequest request) :
            base(request)
        {
            entries = new List<ListEntry>();
            commonPrefixEntries = new List<CommonPrefixEntry>();
            string rawBucketXML = Utils.slurpInputStream(response.GetResponseStream());

            XmlDocument doc = new XmlDocument();
            doc.LoadXml( rawBucketXML );
            foreach (XmlNode node in doc.ChildNodes)
            {
                if (node.Name.Equals("ListBucketResult"))
                {
                    foreach (XmlNode child in node.ChildNodes)
                    {
                        if (child.Name.Equals("Contents"))
                        {
                            entries.Add( new ListEntry(child) );
                        }
                        else if (child.Name.Equals("CommonPrefixes"))
                        {
                            commonPrefixEntries.Add(new CommonPrefixEntry(child));
                        }
                        else if (child.Name.Equals("Name"))
                        {
                            name = Utils.getXmlChildText( child );
                        }
                        else if (child.Name.Equals("Prefix"))
                        {
                            prefix = Utils.getXmlChildText(child);
                        }
                        else if (child.Name.Equals("Marker"))
                        {
                            marker = Utils.getXmlChildText(child);
                        }
                        else if (child.Name.Equals("Delimiter"))
                        {
                            delimiter = Utils.getXmlChildText(child);
                        }
                        else if (child.Name.Equals("MaxKeys"))
                        {
                            maxKeys = int.Parse(Utils.getXmlChildText(child));
                        }
                        else if (child.Name.Equals("IsTruncated"))
                        {
                            isTruncated = bool.Parse( Utils.getXmlChildText(child) );
                        }
                        else if (child.Name.Equals("NextMarker"))
                        {
                            nextMarker = Utils.getXmlChildText(child);
                        }
                    }
                }
            }
        }
    }
}
