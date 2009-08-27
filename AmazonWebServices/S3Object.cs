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
using System.Text;
using System.IO;

namespace com.amazon.s3
{
    public class S3Object
    {
        private string data;
        public string Data {
            get {
                return data;
            }
        }

        private Stream stream;
        public Stream Stream
        {
            get
            {
                return stream;
            }
        }

        private SortedList metadata;
        public SortedList Metadata {
            get {
                return metadata;
            }
        }

        public S3Object( string data, SortedList metadata ) 
        {
            this.data = data;
            this.metadata = metadata;
        }

        public S3Object(Stream stream, SortedList metadata)
        {
            this.stream = stream;
            this.metadata = metadata;
        }
    }
}
