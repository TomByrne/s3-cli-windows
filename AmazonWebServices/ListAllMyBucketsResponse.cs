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
    public class ListAllMyBucketsResponse : Response
    {
        private Owner owner;
        public Owner Owner {
            get {
                return owner;
            }
        }

        private List<Bucket> buckets;
        public List<Bucket> Buckets {
            get {
                return buckets;
            }
        }

        public ListAllMyBucketsResponse( WebRequest request ) :
            base(request)
        {
            buckets = new List<Bucket>();
            string rawBucketXML = Utils.slurpInputStream( response.GetResponseStream() );

            XmlDocument doc = new XmlDocument();
            doc.LoadXml( rawBucketXML );
            foreach (XmlNode node in doc.ChildNodes)
            {
                if (node.Name.Equals("ListAllMyBucketsResult"))
                {
                    foreach (XmlNode child in node.ChildNodes)
                    {
                        if (child.Name.Equals("Owner"))
                        {
                            owner = new Owner(child);
                        }
                        else if (child.Name.Equals("Buckets"))
                        {
                            foreach (XmlNode bucket in child.ChildNodes)
                            {
                                if (bucket.Name.Equals("Bucket"))
                                {
                                    buckets.Add(new Bucket(bucket));
                                }
                            }
                        }
                    }
                }
            }
        }
    }
}
