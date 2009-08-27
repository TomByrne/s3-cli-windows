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
    public class KeyPair
    {
    
        private String keyNameField;

        private String keyFingerprintField;

        private String keyMaterialField;


        /// <summary>
        /// Gets and sets the KeyName property.
        /// </summary>
        [XmlElementAttribute(ElementName = "KeyName")]
        public String KeyName
        {
            get { return this.keyNameField ; }
            set { this.keyNameField= value; }
        }



        /// <summary>
        /// Sets the KeyName property
        /// </summary>
        /// <param name="keyName">KeyName property</param>
        /// <returns>this instance</returns>
        public KeyPair WithKeyName(String keyName)
        {
            this.keyNameField = keyName;
            return this;
        }



        /// <summary>
        /// Checks if KeyName property is set
        /// </summary>
        /// <returns>true if KeyName property is set</returns>
        public Boolean IsSetKeyName()
        {
            return  this.keyNameField != null;

        }


        /// <summary>
        /// Gets and sets the KeyFingerprint property.
        /// </summary>
        [XmlElementAttribute(ElementName = "KeyFingerprint")]
        public String KeyFingerprint
        {
            get { return this.keyFingerprintField ; }
            set { this.keyFingerprintField= value; }
        }



        /// <summary>
        /// Sets the KeyFingerprint property
        /// </summary>
        /// <param name="keyFingerprint">KeyFingerprint property</param>
        /// <returns>this instance</returns>
        public KeyPair WithKeyFingerprint(String keyFingerprint)
        {
            this.keyFingerprintField = keyFingerprint;
            return this;
        }



        /// <summary>
        /// Checks if KeyFingerprint property is set
        /// </summary>
        /// <returns>true if KeyFingerprint property is set</returns>
        public Boolean IsSetKeyFingerprint()
        {
            return  this.keyFingerprintField != null;

        }


        /// <summary>
        /// Gets and sets the KeyMaterial property.
        /// </summary>
        [XmlElementAttribute(ElementName = "KeyMaterial")]
        public String KeyMaterial
        {
            get { return this.keyMaterialField ; }
            set { this.keyMaterialField= value; }
        }



        /// <summary>
        /// Sets the KeyMaterial property
        /// </summary>
        /// <param name="keyMaterial">KeyMaterial property</param>
        /// <returns>this instance</returns>
        public KeyPair WithKeyMaterial(String keyMaterial)
        {
            this.keyMaterialField = keyMaterial;
            return this;
        }



        /// <summary>
        /// Checks if KeyMaterial property is set
        /// </summary>
        /// <returns>true if KeyMaterial property is set</returns>
        public Boolean IsSetKeyMaterial()
        {
            return  this.keyMaterialField != null;

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
            if (IsSetKeyName()) {
                xml.Append("<KeyName>");
                xml.Append(EscapeXML(this.KeyName));
                xml.Append("</KeyName>");
            }
            if (IsSetKeyFingerprint()) {
                xml.Append("<KeyFingerprint>");
                xml.Append(EscapeXML(this.KeyFingerprint));
                xml.Append("</KeyFingerprint>");
            }
            if (IsSetKeyMaterial()) {
                xml.Append("<KeyMaterial>");
                xml.Append(EscapeXML(this.KeyMaterial));
                xml.Append("</KeyMaterial>");
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