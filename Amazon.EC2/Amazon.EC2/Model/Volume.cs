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
    public class Volume
    {
    
        private String volumeIdField;

        private String sizeField;

        private String snapshotIdField;

        private String availabilityZoneField;

        private String statusField;

        private String createTimeField;

        private  List<Attachment> attachmentField;


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
        public Volume WithVolumeId(String volumeId)
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
        /// Gets and sets the Size property.
        /// </summary>
        [XmlElementAttribute(ElementName = "Size")]
        public String Size
        {
            get { return this.sizeField ; }
            set { this.sizeField= value; }
        }



        /// <summary>
        /// Sets the Size property
        /// </summary>
        /// <param name="size">Size property</param>
        /// <returns>this instance</returns>
        public Volume WithSize(String size)
        {
            this.sizeField = size;
            return this;
        }



        /// <summary>
        /// Checks if Size property is set
        /// </summary>
        /// <returns>true if Size property is set</returns>
        public Boolean IsSetSize()
        {
            return  this.sizeField != null;

        }


        /// <summary>
        /// Gets and sets the SnapshotId property.
        /// </summary>
        [XmlElementAttribute(ElementName = "SnapshotId")]
        public String SnapshotId
        {
            get { return this.snapshotIdField ; }
            set { this.snapshotIdField= value; }
        }



        /// <summary>
        /// Sets the SnapshotId property
        /// </summary>
        /// <param name="snapshotId">SnapshotId property</param>
        /// <returns>this instance</returns>
        public Volume WithSnapshotId(String snapshotId)
        {
            this.snapshotIdField = snapshotId;
            return this;
        }



        /// <summary>
        /// Checks if SnapshotId property is set
        /// </summary>
        /// <returns>true if SnapshotId property is set</returns>
        public Boolean IsSetSnapshotId()
        {
            return  this.snapshotIdField != null;

        }


        /// <summary>
        /// Gets and sets the AvailabilityZone property.
        /// </summary>
        [XmlElementAttribute(ElementName = "AvailabilityZone")]
        public String AvailabilityZone
        {
            get { return this.availabilityZoneField ; }
            set { this.availabilityZoneField= value; }
        }



        /// <summary>
        /// Sets the AvailabilityZone property
        /// </summary>
        /// <param name="availabilityZone">AvailabilityZone property</param>
        /// <returns>this instance</returns>
        public Volume WithAvailabilityZone(String availabilityZone)
        {
            this.availabilityZoneField = availabilityZone;
            return this;
        }



        /// <summary>
        /// Checks if AvailabilityZone property is set
        /// </summary>
        /// <returns>true if AvailabilityZone property is set</returns>
        public Boolean IsSetAvailabilityZone()
        {
            return  this.availabilityZoneField != null;

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
        public Volume WithStatus(String status)
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
        /// Gets and sets the CreateTime property.
        /// </summary>
        [XmlElementAttribute(ElementName = "CreateTime")]
        public String CreateTime
        {
            get { return this.createTimeField ; }
            set { this.createTimeField= value; }
        }



        /// <summary>
        /// Sets the CreateTime property
        /// </summary>
        /// <param name="createTime">CreateTime property</param>
        /// <returns>this instance</returns>
        public Volume WithCreateTime(String createTime)
        {
            this.createTimeField = createTime;
            return this;
        }



        /// <summary>
        /// Checks if CreateTime property is set
        /// </summary>
        /// <returns>true if CreateTime property is set</returns>
        public Boolean IsSetCreateTime()
        {
            return  this.createTimeField != null;

        }


        /// <summary>
        /// Gets and sets the Attachment property.
        /// </summary>
        [XmlElementAttribute(ElementName = "Attachment")]
        public List<Attachment> Attachment
        {
            get
            {
                if (this.attachmentField == null)
                {
                    this.attachmentField = new List<Attachment>();
                }
                return this.attachmentField;
            }
            set { this.attachmentField =  value; }
        }



        /// <summary>
        /// Sets the Attachment property
        /// </summary>
        /// <param name="list">Attachment property</param>
        /// <returns>this instance</returns>
        public Volume WithAttachment(params Attachment[] list)
        {
            foreach (Attachment item in list)
            {
                Attachment.Add(item);
            }
            return this;
        }          
 


        /// <summary>
        /// Checks if Attachment property is set
        /// </summary>
        /// <returns>true if Attachment property is set</returns>
        public Boolean IsSetAttachment()
        {
            return (Attachment.Count > 0);
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
            if (IsSetSize()) {
                xml.Append("<Size>");
                xml.Append(EscapeXML(this.Size));
                xml.Append("</Size>");
            }
            if (IsSetSnapshotId()) {
                xml.Append("<SnapshotId>");
                xml.Append(EscapeXML(this.SnapshotId));
                xml.Append("</SnapshotId>");
            }
            if (IsSetAvailabilityZone()) {
                xml.Append("<AvailabilityZone>");
                xml.Append(EscapeXML(this.AvailabilityZone));
                xml.Append("</AvailabilityZone>");
            }
            if (IsSetStatus()) {
                xml.Append("<Status>");
                xml.Append(EscapeXML(this.Status));
                xml.Append("</Status>");
            }
            if (IsSetCreateTime()) {
                xml.Append("<CreateTime>");
                xml.Append(EscapeXML(this.CreateTime));
                xml.Append("</CreateTime>");
            }
            List<Attachment> attachmentList = this.Attachment;
            foreach (Attachment attachment in attachmentList) {
                xml.Append("<Attachment>");
                xml.Append(attachment.ToXMLFragment());
                xml.Append("</Attachment>");
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