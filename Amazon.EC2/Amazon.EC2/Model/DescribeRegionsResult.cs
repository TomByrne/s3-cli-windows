/******************************************************************************* 
 *  Copyright 2008 Amazon Technologies, Inc.
 *  Licensed under the Apache License, Version 2.0 (the "License"); 
 *  
 *  You may not use this file except in compliance with the License. 
 *  You may obtain a copy of the License at: http://aws.amazon.com/apache2.0
 *  This file is distributed on an "AS IS" BASIS, WITHOUT WARRANTIES OR 
 *  CONDITIONS OF ANY KIND, either express or implied. See the License for the 
 *  specific language governing permissions and limitations under the License.
 * ***************************************************************************** 
 *    __  _    _  ___ 
 *   (  )( \/\/ )/ __)
 *   /__\ \    / \__ \
 *  (_)(_) \/\/  (___/
 * 
 *  Amazon EC2 CSharp Library
 *  API Version: 2008-12-01
 *  Generated: Fri Dec 26 23:53:41 PST 2008 
 * 
 */

using System;
using System.Xml.Serialization;
using System.Collections.Generic;
using System.Text;


namespace Amazon.EC2.Model
{
    [XmlTypeAttribute(Namespace = "http://ec2.amazonaws.com/doc/2008-12-01/")]
    [XmlRootAttribute(Namespace = "http://ec2.amazonaws.com/doc/2008-12-01/", IsNullable = false)]
    public class DescribeRegionsResult
    {
    
        private  List<Region> regionField;


        /// <summary>
        /// Gets and sets the Region property.
        /// </summary>
        [XmlElementAttribute(ElementName = "Region")]
        public List<Region> Region
        {
            get
            {
                if (this.regionField == null)
                {
                    this.regionField = new List<Region>();
                }
                return this.regionField;
            }
            set { this.regionField =  value; }
        }



        /// <summary>
        /// Sets the Region property
        /// </summary>
        /// <param name="list">Region property</param>
        /// <returns>this instance</returns>
        public DescribeRegionsResult WithRegion(params Region[] list)
        {
            foreach (Region item in list)
            {
                Region.Add(item);
            }
            return this;
        }          
 


        /// <summary>
        /// Checks if Region property is set
        /// </summary>
        /// <returns>true if Region property is set</returns>
        public Boolean IsSetRegion()
        {
            return (Region.Count > 0);
        }




        /// <summary>
        /// XML fragment representation of this object
        /// </summary>
        /// <returns>XML fragment for this object.</returns>
        /// <remarks>
        /// Name for outer tag expected to be set by calling method. 
        /// This fragment returns inner properties representation only
        /// </remarks>


        protected internal String ToXMLFragment() {
            StringBuilder xml = new StringBuilder();
            List<Region> regionList = this.Region;
            foreach (Region region in regionList) {
                xml.Append("<Region>");
                xml.Append(region.ToXMLFragment());
                xml.Append("</Region>");
            }
            return xml.ToString();
        }

        /**
         * 
         * Escape XML special characters
         */
        private String EscapeXML(String str) {
            StringBuilder sb = new StringBuilder();
            foreach (Char c in str)
            {
                switch (c) {
                case '&':
                    sb.Append("&amp;");
                    break;
                case '<':
                    sb.Append("&lt;");
                    break;
                case '>':
                    sb.Append("&gt;");
                    break;
                case '\'':
                    sb.Append("&#039;");
                    break;
                case '"':
                    sb.Append("&quot;");
                    break;
                default:
                    sb.Append(c);
                    break;
                }
            }
            return sb.ToString();
        }



    }

}