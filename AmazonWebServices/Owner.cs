// This software code is made available "AS IS" without warranties of any        
// kind.  You may copy, display, modify and redistribute the software            
// code either by itself or as incorporated into your code; provided that        
// you do not remove any proprietary notices.  Your use of this software         
// code is at your own risk and you waive any claim against Amazon               
// Digital Services, Inc. or its affiliates with respect to your use of          
// this software code. (c) 2006 Amazon Digital Services, Inc. or its             
// affiliates.          



using System;
using System.Text;
using System.Xml;

namespace com.amazon.s3
{
    public class Owner
    {
        private string id;
        public String Id {
            get {
                return id;
            }
        }

        private string displayName;
        public string DisplayName {
            get {
                return displayName;
            }
        }

        public Owner( string id, string displayName )
        {
            this.id = id;
            this.displayName = displayName;
        }

        public Owner(XmlNode node)
        {
            foreach (XmlNode child in node.ChildNodes)
            {
                if (child.Name.Equals("ID"))
                {
                    id = Utils.getXmlChildText(child);
                }
                else if (child.Name.Equals("DisplayName"))
                {
                    displayName = Utils.getXmlChildText(child);
                }
            }
        }
    }
}
