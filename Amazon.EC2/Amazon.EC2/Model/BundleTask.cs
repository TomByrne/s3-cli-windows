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
    public class BundleTask
    {
    
        private String instanceIdField;

        private String bundleIdField;

        private String bundleStateField;

        private String startTimeField;

        private String updateTimeField;

        private  Storage storageField;
        private String progressField;

        private  BundleTaskError bundleTaskErrorField;

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
        public BundleTask WithInstanceId(String instanceId)
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
        /// Gets and sets the BundleId property.
        /// </summary>
        [XmlElementAttribute(ElementName = "BundleId")]
        public String BundleId
        {
            get { return this.bundleIdField ; }
            set { this.bundleIdField= value; }
        }



        /// <summary>
        /// Sets the BundleId property
        /// </summary>
        /// <param name="bundleId">BundleId property</param>
        /// <returns>this instance</returns>
        public BundleTask WithBundleId(String bundleId)
        {
            this.bundleIdField = bundleId;
            return this;
        }



        /// <summary>
        /// Checks if BundleId property is set
        /// </summary>
        /// <returns>true if BundleId property is set</returns>
        public Boolean IsSetBundleId()
        {
            return  this.bundleIdField != null;

        }


        /// <summary>
        /// Gets and sets the BundleState property.
        /// </summary>
        [XmlElementAttribute(ElementName = "BundleState")]
        public String BundleState
        {
            get { return this.bundleStateField ; }
            set { this.bundleStateField= value; }
        }



        /// <summary>
        /// Sets the BundleState property
        /// </summary>
        /// <param name="bundleState">BundleState property</param>
        /// <returns>this instance</returns>
        public BundleTask WithBundleState(String bundleState)
        {
            this.bundleStateField = bundleState;
            return this;
        }



        /// <summary>
        /// Checks if BundleState property is set
        /// </summary>
        /// <returns>true if BundleState property is set</returns>
        public Boolean IsSetBundleState()
        {
            return  this.bundleStateField != null;

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
        public BundleTask WithStartTime(String startTime)
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
        /// Gets and sets the UpdateTime property.
        /// </summary>
        [XmlElementAttribute(ElementName = "UpdateTime")]
        public String UpdateTime
        {
            get { return this.updateTimeField ; }
            set { this.updateTimeField= value; }
        }



        /// <summary>
        /// Sets the UpdateTime property
        /// </summary>
        /// <param name="updateTime">UpdateTime property</param>
        /// <returns>this instance</returns>
        public BundleTask WithUpdateTime(String updateTime)
        {
            this.updateTimeField = updateTime;
            return this;
        }



        /// <summary>
        /// Checks if UpdateTime property is set
        /// </summary>
        /// <returns>true if UpdateTime property is set</returns>
        public Boolean IsSetUpdateTime()
        {
            return  this.updateTimeField != null;

        }


        /// <summary>
        /// Gets and sets the Storage property.
        /// </summary>
        [XmlElementAttribute(ElementName = "Storage")]
        public Storage Storage
        {
            get { return this.storageField ; }
            set { this.storageField = value; }
        }



        /// <summary>
        /// Sets the Storage property
        /// </summary>
        /// <param name="storage">Storage property</param>
        /// <returns>this instance</returns>
        public BundleTask WithStorage(Storage storage)
        {
            this.storageField = storage;
            return this;
        }



        /// <summary>
        /// Checks if Storage property is set
        /// </summary>
        /// <returns>true if Storage property is set</returns>
        public Boolean IsSetStorage()
        {
            return this.storageField != null;
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
        public BundleTask WithProgress(String progress)
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
        /// Gets and sets the BundleTaskError property.
        /// </summary>
        [XmlElementAttribute(ElementName = "BundleTaskError")]
        public BundleTaskError BundleTaskError
        {
            get { return this.bundleTaskErrorField ; }
            set { this.bundleTaskErrorField = value; }
        }



        /// <summary>
        /// Sets the BundleTaskError property
        /// </summary>
        /// <param name="bundleTaskError">BundleTaskError property</param>
        /// <returns>this instance</returns>
        public BundleTask WithBundleTaskError(BundleTaskError bundleTaskError)
        {
            this.bundleTaskErrorField = bundleTaskError;
            return this;
        }



        /// <summary>
        /// Checks if BundleTaskError property is set
        /// </summary>
        /// <returns>true if BundleTaskError property is set</returns>
        public Boolean IsSetBundleTaskError()
        {
            return this.bundleTaskErrorField != null;
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
            if (IsSetInstanceId()) {
                xml.Append("<InstanceId>");
                xml.Append(EscapeXML(this.InstanceId));
                xml.Append("</InstanceId>");
            }
            if (IsSetBundleId()) {
                xml.Append("<BundleId>");
                xml.Append(EscapeXML(this.BundleId));
                xml.Append("</BundleId>");
            }
            if (IsSetBundleState()) {
                xml.Append("<BundleState>");
                xml.Append(EscapeXML(this.BundleState));
                xml.Append("</BundleState>");
            }
            if (IsSetStartTime()) {
                xml.Append("<StartTime>");
                xml.Append(EscapeXML(this.StartTime));
                xml.Append("</StartTime>");
            }
            if (IsSetUpdateTime()) {
                xml.Append("<UpdateTime>");
                xml.Append(EscapeXML(this.UpdateTime));
                xml.Append("</UpdateTime>");
            }
            if (IsSetStorage()) {
                Storage  storage = this.Storage;
                xml.Append("<Storage>");
                xml.Append(storage.ToXMLFragment());
                xml.Append("</Storage>");
            } 
            if (IsSetProgress()) {
                xml.Append("<Progress>");
                xml.Append(EscapeXML(this.Progress));
                xml.Append("</Progress>");
            }
            if (IsSetBundleTaskError()) {
                BundleTaskError  bundleTaskError = this.BundleTaskError;
                xml.Append("<BundleTaskError>");
                xml.Append(bundleTaskError.ToXMLFragment());
                xml.Append("</BundleTaskError>");
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