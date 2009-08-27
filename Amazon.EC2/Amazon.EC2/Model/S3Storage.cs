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
    public class S3Storage
    {
    
        private String bucketField;

        private String prefixField;

        private String AWSAccessKeyIdField;

        private String uploadPolicyField;

        private String uploadPolicySignatureField;


        /// <summary>
        /// Gets and sets the Bucket property.
        /// </summary>
        [XmlElementAttribute(ElementName = "Bucket")]
        public String Bucket
        {
            get { return this.bucketField ; }
            set { this.bucketField= value; }
        }



        /// <summary>
        /// Sets the Bucket property
        /// </summary>
        /// <param name="bucket">Bucket property</param>
        /// <returns>this instance</returns>
        public S3Storage WithBucket(String bucket)
        {
            this.bucketField = bucket;
            return this;
        }



        /// <summary>
        /// Checks if Bucket property is set
        /// </summary>
        /// <returns>true if Bucket property is set</returns>
        public Boolean IsSetBucket()
        {
            return  this.bucketField != null;

        }


        /// <summary>
        /// Gets and sets the Prefix property.
        /// </summary>
        [XmlElementAttribute(ElementName = "Prefix")]
        public String Prefix
        {
            get { return this.prefixField ; }
            set { this.prefixField= value; }
        }



        /// <summary>
        /// Sets the Prefix property
        /// </summary>
        /// <param name="prefix">Prefix property</param>
        /// <returns>this instance</returns>
        public S3Storage WithPrefix(String prefix)
        {
            this.prefixField = prefix;
            return this;
        }



        /// <summary>
        /// Checks if Prefix property is set
        /// </summary>
        /// <returns>true if Prefix property is set</returns>
        public Boolean IsSetPrefix()
        {
            return  this.prefixField != null;

        }


        /// <summary>
        /// Gets and sets the AWSAccessKeyId property.
        /// </summary>
        [XmlElementAttribute(ElementName = "AWSAccessKeyId")]
        public String AWSAccessKeyId
        {
            get { return this.AWSAccessKeyIdField ; }
            set { this.AWSAccessKeyIdField= value; }
        }



        /// <summary>
        /// Sets the AWSAccessKeyId property
        /// </summary>
        /// <param name="AWSAccessKeyId">AWSAccessKeyId property</param>
        /// <returns>this instance</returns>
        public S3Storage WithAWSAccessKeyId(String AWSAccessKeyId)
        {
            this.AWSAccessKeyIdField = AWSAccessKeyId;
            return this;
        }



        /// <summary>
        /// Checks if AWSAccessKeyId property is set
        /// </summary>
        /// <returns>true if AWSAccessKeyId property is set</returns>
        public Boolean IsSetAWSAccessKeyId()
        {
            return  this.AWSAccessKeyIdField != null;

        }


        /// <summary>
        /// Gets and sets the UploadPolicy property.
        /// </summary>
        [XmlElementAttribute(ElementName = "UploadPolicy")]
        public String UploadPolicy
        {
            get { return this.uploadPolicyField ; }
            set { this.uploadPolicyField= value; }
        }



        /// <summary>
        /// Sets the UploadPolicy property
        /// </summary>
        /// <param name="uploadPolicy">UploadPolicy property</param>
        /// <returns>this instance</returns>
        public S3Storage WithUploadPolicy(String uploadPolicy)
        {
            this.uploadPolicyField = uploadPolicy;
            return this;
        }



        /// <summary>
        /// Checks if UploadPolicy property is set
        /// </summary>
        /// <returns>true if UploadPolicy property is set</returns>
        public Boolean IsSetUploadPolicy()
        {
            return  this.uploadPolicyField != null;

        }


        /// <summary>
        /// Gets and sets the UploadPolicySignature property.
        /// </summary>
        [XmlElementAttribute(ElementName = "UploadPolicySignature")]
        public String UploadPolicySignature
        {
            get { return this.uploadPolicySignatureField ; }
            set { this.uploadPolicySignatureField= value; }
        }



        /// <summary>
        /// Sets the UploadPolicySignature property
        /// </summary>
        /// <param name="uploadPolicySignature">UploadPolicySignature property</param>
        /// <returns>this instance</returns>
        public S3Storage WithUploadPolicySignature(String uploadPolicySignature)
        {
            this.uploadPolicySignatureField = uploadPolicySignature;
            return this;
        }



        /// <summary>
        /// Checks if UploadPolicySignature property is set
        /// </summary>
        /// <returns>true if UploadPolicySignature property is set</returns>
        public Boolean IsSetUploadPolicySignature()
        {
            return  this.uploadPolicySignatureField != null;

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
            if (IsSetBucket()) {
                xml.Append("<Bucket>");
                xml.Append(EscapeXML(this.Bucket));
                xml.Append("</Bucket>");
            }
            if (IsSetPrefix()) {
                xml.Append("<Prefix>");
                xml.Append(EscapeXML(this.Prefix));
                xml.Append("</Prefix>");
            }
            if (IsSetAWSAccessKeyId()) {
                xml.Append("<AWSAccessKeyId>");
                xml.Append(EscapeXML(this.AWSAccessKeyId));
                xml.Append("</AWSAccessKeyId>");
            }
            if (IsSetUploadPolicy()) {
                xml.Append("<UploadPolicy>");
                xml.Append(EscapeXML(this.UploadPolicy));
                xml.Append("</UploadPolicy>");
            }
            if (IsSetUploadPolicySignature()) {
                xml.Append("<UploadPolicySignature>");
                xml.Append(EscapeXML(this.UploadPolicySignature));
                xml.Append("</UploadPolicySignature>");
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