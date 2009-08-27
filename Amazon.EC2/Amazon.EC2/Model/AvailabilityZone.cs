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
    public class AvailabilityZone
    {
    
        private String zoneNameField;

        private String zoneStateField;

        private String regionNameField;


        /// <summary>
        /// Gets and sets the ZoneName property.
        /// </summary>
        [XmlElementAttribute(ElementName = "ZoneName")]
        public String ZoneName
        {
            get { return this.zoneNameField ; }
            set { this.zoneNameField= value; }
        }



        /// <summary>
        /// Sets the ZoneName property
        /// </summary>
        /// <param name="zoneName">ZoneName property</param>
        /// <returns>this instance</returns>
        public AvailabilityZone WithZoneName(String zoneName)
        {
            this.zoneNameField = zoneName;
            return this;
        }



        /// <summary>
        /// Checks if ZoneName property is set
        /// </summary>
        /// <returns>true if ZoneName property is set</returns>
        public Boolean IsSetZoneName()
        {
            return  this.zoneNameField != null;

        }


        /// <summary>
        /// Gets and sets the ZoneState property.
        /// </summary>
        [XmlElementAttribute(ElementName = "ZoneState")]
        public String ZoneState
        {
            get { return this.zoneStateField ; }
            set { this.zoneStateField= value; }
        }



        /// <summary>
        /// Sets the ZoneState property
        /// </summary>
        /// <param name="zoneState">ZoneState property</param>
        /// <returns>this instance</returns>
        public AvailabilityZone WithZoneState(String zoneState)
        {
            this.zoneStateField = zoneState;
            return this;
        }



        /// <summary>
        /// Checks if ZoneState property is set
        /// </summary>
        /// <returns>true if ZoneState property is set</returns>
        public Boolean IsSetZoneState()
        {
            return  this.zoneStateField != null;

        }


        /// <summary>
        /// Gets and sets the RegionName property.
        /// </summary>
        [XmlElementAttribute(ElementName = "RegionName")]
        public String RegionName
        {
            get { return this.regionNameField ; }
            set { this.regionNameField= value; }
        }



        /// <summary>
        /// Sets the RegionName property
        /// </summary>
        /// <param name="regionName">RegionName property</param>
        /// <returns>this instance</returns>
        public AvailabilityZone WithRegionName(String regionName)
        {
            this.regionNameField = regionName;
            return this;
        }



        /// <summary>
        /// Checks if RegionName property is set
        /// </summary>
        /// <returns>true if RegionName property is set</returns>
        public Boolean IsSetRegionName()
        {
            return  this.regionNameField != null;

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
            if (IsSetZoneName()) {
                xml.Append("<ZoneName>");
                xml.Append(EscapeXML(this.ZoneName));
                xml.Append("</ZoneName>");
            }
            if (IsSetZoneState()) {
                xml.Append("<ZoneState>");
                xml.Append(EscapeXML(this.ZoneState));
                xml.Append("</ZoneState>");
            }
            if (IsSetRegionName()) {
                xml.Append("<RegionName>");
                xml.Append(EscapeXML(this.RegionName));
                xml.Append("</RegionName>");
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