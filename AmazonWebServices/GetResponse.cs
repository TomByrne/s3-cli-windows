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
using System.Net;
using System.IO;
using System.Text;

namespace com.amazon.s3
{
    public class GetResponse : Response
    {
        private S3Object obj;
        public S3Object Object {
            get {
                return obj;
            }
        }

        public GetResponse( WebRequest request, bool asStream ) :
            base(request)
        {
            SortedList metadata = extractMetadata( response );
            if (asStream)
            {
                this.obj = new S3Object(response.GetResponseStream(), metadata);
            }
            else
            {
                string body = Utils.slurpInputStream(response.GetResponseStream());
                this.obj = new S3Object(body, metadata);
            }
        }

        private static SortedList extractMetadata( WebResponse response )
        {
            SortedList metadata = new SortedList();
            foreach ( string key in response.Headers.Keys ) {
                if ( key == null ) continue;
                if ( key.StartsWith( Utils.METADATA_PREFIX ) ) {
                    metadata.Add( key.Substring( Utils.METADATA_PREFIX.Length ), response.Headers[ key ] );
                }
            }
            return metadata;
        }
    }
}
