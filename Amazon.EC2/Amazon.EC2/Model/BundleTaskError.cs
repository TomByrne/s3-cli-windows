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
    public class BundleTaskError
    {
    
        private String codeField;

        private String messageField;


        /// <summary>
        /// Gets and sets the Code property.
        /// </summary>
        [XmlElementAttribute(ElementName = "Code")]
        public String Code
        {
            get { return this.codeField ; }
            set { this.codeField= value; }
        }



        /// <summary>
        /// Sets the Code property
        /// </summary>
        /// <param name="code">Code property</param>
        /// <returns>this instance</returns>
        public BundleTaskError WithCode(String code)
        {
            this.codeField = code;
            return this;
        }



        /// <summary>
        /// Checks if Code property is set
        /// </summary>
        /// <returns>true if Code property is set</returns>
        public Boolean IsSetCode()
        {
            return  this.codeField != null;

        }


        /// <summary>
        /// Gets and sets the Message property.
        /// </summary>
        [XmlElementAttribute(ElementName = "Message")]
        public String Message
        {
            get { return this.messageField ; }
            set { this.messageField= value; }
        }



        /// <summary>
        /// Sets the Message property
        /// </summary>
        /// <param name="message">Message property</param>
        /// <returns>this instance</returns>
        public BundleTaskError WithMessage(String message)
        {
            this.messageField = message;
            return this;
        }



        /// <summary>
        /// Checks if Message property is set
        /// </summary>
        /// <returns>true if Message property is set</returns>
        public Boolean IsSetMessage()
        {
            return  this.messageField != null;

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
            if (IsSetCode()) {
                xml.Append("<Code>");
                xml.Append(EscapeXML(this.Code));
                xml.Append("</Code>");
            }
            if (IsSetMessage()) {
                xml.Append("<Message>");
                xml.Append(EscapeXML(this.Message));
                xml.Append("</Message>");
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