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
    public class Snapshot
    {
    
        private String snapshotIdField;

        private String volumeIdField;

        private String statusField;

        private String startTimeField;

        private String progressField;


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
        public Snapshot WithSnapshotId(String snapshotId)
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
        public Snapshot WithVolumeId(String volumeId)
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
        public Snapshot WithStatus(String status)
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
        /// Gets and sets the StartTime property.
        /// </summary>
        [XmlElementAttribute(ElementName = "StartTime")]
        public String StartTime
        {
            get { return this.startTimeField ; }
            set { this.startTimeField= value; }
        }



        /// <summary>
        /// Sets the StartTime property
        /// </summary>
        /// <param name="startTime">StartTime property</param>
        /// <returns>this instance</returns>
        public Snapshot WithStartTime(String startTime)
        {
            this.startTimeField = startTime;
            return this;
        }



        /// <summary>
        /// Checks if StartTime property is set
        /// </summary>
        /// <returns>true if StartTime property is set</returns>
        public Boolean IsSetStartTime()
        {
            return  this.startTimeField != null;

        }


        /// <summary>
        /// Gets and sets the Progress property.
        /// </summary>
        [XmlElementAttribute(ElementName = "Progress")]
        public String Progress
        {
            get { return this.progressField ; }
            set { this.progressField= value; }
        }



        /// <summary>
        /// Sets the Progress property
        /// </summary>
        /// <param name="progress">Progress property</param>
        /// <returns>this instance</returns>
        public Snapshot WithProgress(String progress)
        {
            this.progressField = progress;
            return this;
        }



        /// <summary>
        /// Checks if Progress property is set
        /// </summary>
        /// <returns>true if Progress property is set</returns>
        public Boolean IsSetProgress()
        {
            return  this.progressField != null;

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
            if (IsSetSnapshotId()) {
                xml.Append("<SnapshotId>");
                xml.Append(EscapeXML(this.SnapshotId));
                xml.Append("</SnapshotId>");
            }
            if (IsSetVolumeId()) {
                xml.Append("<VolumeId>");
                xml.Append(EscapeXML(this.VolumeId));
                xml.Append("</VolumeId>");
            }
            if (IsSetStatus()) {
                xml.Append("<Status>");
                xml.Append(EscapeXML(this.Status));
                xml.Append("</Status>");
            }
            if (IsSetStartTime()) {
                xml.Append("<StartTime>");
                xml.Append(EscapeXML(this.StartTime));
                xml.Append("</StartTime>");
            }
            if (IsSetProgress()) {
                xml.Append("<Progress>");
                xml.Append(EscapeXML(this.Progress));
                xml.Append("</Progress>");
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