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
    public class Attachment
    {
    
        private String volumeIdField;

        private String instanceIdField;

        private String deviceField;

        private String statusField;

        private String attachTimeField;


        /// <summary>
        /// Gets and sets the VolumeId property.
        /// </summary>
        [XmlElementAttribute(ElementName = "VolumeId")]
        public String VolumeId
        {
            get { return this.volumeIdField ; }
            set { this.volumeIdField= value; }
        }



        /// <summary>
        /// Sets the VolumeId property
        /// </summary>
        /// <param name="volumeId">VolumeId property</param>
        /// <returns>this instance</returns>
        public Attachment WithVolumeId(String volumeId)
        {
            this.volumeIdField = volumeId;
            return this;
        }



        /// <summary>
        /// Checks if VolumeId property is set
        /// </summary>
        /// <returns>true if VolumeId property is set</returns>
        public Boolean IsSetVolumeId()
        {
            return  this.volumeIdField != null;

        }


        /// <summary>
        /// Gets and sets the InstanceId property.
        /// </summary>
        [XmlElementAttribute(ElementName = "InstanceId")]
        public String InstanceId
        {
            get { return this.instanceIdField ; }
            set { this.instanceIdField= value; }
        }



        /// <summary>
        /// Sets the InstanceId property
        /// </summary>
        /// <param name="instanceId">InstanceId property</param>
        /// <returns>this instance</returns>
        public Attachment WithInstanceId(String instanceId)
        {
            this.instanceIdField = instanceId;
            return this;
        }



        /// <summary>
        /// Checks if InstanceId property is set
        /// </summary>
        /// <returns>true if InstanceId property is set</returns>
        public Boolean IsSetInstanceId()
        {
            return  this.instanceIdField != null;

        }


        /// <summary>
        /// Gets and sets the Device property.
        /// </summary>
        [XmlElementAttribute(ElementName = "Device")]
        public String Device
        {
            get { return this.deviceField ; }
            set { this.deviceField= value; }
        }



        /// <summary>
        /// Sets the Device property
        /// </summary>
        /// <param name="device">Device property</param>
        /// <returns>this instance</returns>
        public Attachment WithDevice(String device)
        {
            this.deviceField = device;
            return this;
        }



        /// <summary>
        /// Checks if Device property is set
        /// </summary>
        /// <returns>true if Device property is set</returns>
        public Boolean IsSetDevice()
        {
            return  this.deviceField != null;

        }


        /// <summary>
        /// Gets and sets the Status property.
        /// </summary>
        [XmlElementAttribute(ElementName = "Status")]
        public String Status
        {
            get { return this.statusField ; }
            set { this.statusField= value; }
        }



        /// <summary>
        /// Sets the Status property
        /// </summary>
        /// <param name="status">Status property</param>
        /// <returns>this instance</returns>
        public Attachment WithStatus(String status)
        {
            this.statusField = status;
            return this;
        }



        /// <summary>
        /// Checks if Status property is set
        /// </summary>
        /// <returns>true if Status property is set</returns>
        public Boolean IsSetStatus()
        {
            return  this.statusField != null;

        }


        /// <summary>
        /// Gets and sets the AttachTime property.
        /// </summary>
        [XmlElementAttribute(ElementName = "AttachTime")]
        public String AttachTime
        {
            get { return this.attachTimeField ; }
            set { this.attachTimeField= value; }
        }



        /// <summary>
        /// Sets the AttachTime property
        /// </summary>
        /// <param name="attachTime">AttachTime property</param>
        /// <returns>this instance</returns>
        public Attachment WithAttachTime(String attachTime)
        {
            this.attachTimeField = attachTime;
            return this;
        }



        /// <summary>
        /// Checks if AttachTime property is set
        /// </summary>
        /// <returns>true if AttachTime property is set</returns>
        public Boolean IsSetAttachTime()
        {
            return  this.attachTimeField != null;

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
            if (IsSetVolumeId()) {
                xml.Append("<VolumeId>");
                xml.Append(EscapeXML(this.VolumeId));
                xml.Append("</VolumeId>");
            }
            if (IsSetInstanceId()) {
                xml.Append("<InstanceId>");
                xml.Append(EscapeXML(this.InstanceId));
                xml.Append("</InstanceId>");
            }
            if (IsSetDevice()) {
                xml.Append("<Device>");
                xml.Append(EscapeXML(this.Device));
                xml.Append("</Device>");
            }
            if (IsSetStatus()) {
                xml.Append("<Status>");
                xml.Append(EscapeXML(this.Status));
                xml.Append("</Status>");
            }
            if (IsSetAttachTime()) {
                xml.Append("<AttachTime>");
                xml.Append(EscapeXML(this.AttachTime));
                xml.Append("</AttachTime>");
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