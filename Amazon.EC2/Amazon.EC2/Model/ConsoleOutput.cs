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
    public class ConsoleOutput
    {
    
        private String instanceIdField;

        private String timestampField;

        private String outputField;


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
        public ConsoleOutput WithInstanceId(String instanceId)
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
        /// Gets and sets the Timestamp property.
        /// </summary>
        [XmlElementAttribute(ElementName = "Timestamp")]
        public String Timestamp
        {
            get { return this.timestampField ; }
            set { this.timestampField= value; }
        }



        /// <summary>
        /// Sets the Timestamp property
        /// </summary>
        /// <param name="timestamp">Timestamp property</param>
        /// <returns>this instance</returns>
        public ConsoleOutput WithTimestamp(String timestamp)
        {
            this.timestampField = timestamp;
            return this;
        }



        /// <summary>
        /// Checks if Timestamp property is set
        /// </summary>
        /// <returns>true if Timestamp property is set</returns>
        public Boolean IsSetTimestamp()
        {
            return  this.timestampField != null;

        }


        /// <summary>
        /// Gets and sets the Output property.
        /// </summary>
        [XmlElementAttribute(ElementName = "Output")]
        public String Output
        {
            get { return this.outputField ; }
            set { this.outputField= value; }
        }



        /// <summary>
        /// Sets the Output property
        /// </summary>
        /// <param name="output">Output property</param>
        /// <returns>this instance</returns>
        public ConsoleOutput WithOutput(String output)
        {
            this.outputField = output;
            return this;
        }



        /// <summary>
        /// Checks if Output property is set
        /// </summary>
        /// <returns>true if Output property is set</returns>
        public Boolean IsSetOutput()
        {
            return  this.outputField != null;

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
            if (IsSetTimestamp()) {
                xml.Append("<Timestamp>");
                xml.Append(EscapeXML(this.Timestamp));
                xml.Append("</Timestamp>");
            }
            if (IsSetOutput()) {
                xml.Append("<Output>");
                xml.Append(EscapeXML(this.Output));
                xml.Append("</Output>");
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