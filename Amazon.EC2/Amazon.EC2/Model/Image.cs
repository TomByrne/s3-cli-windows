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
    public class Image
    {
    
        private String imageIdField;

        private String imageLocationField;

        private String imageStateField;

        private String ownerIdField;

        private String visibilityField;

        private List<String> productCodeField;

        private String architectureField;

        private String imageTypeField;

        private String kernelIdField;

        private String ramdiskIdField;

        private String platformField;


        /// <summary>
        /// Gets and sets the ImageId property.
        /// </summary>
        [XmlElementAttribute(ElementName = "ImageId")]
        public String ImageId
        {
            get { return this.imageIdField ; }
            set { this.imageIdField= value; }
        }



        /// <summary>
        /// Sets the ImageId property
        /// </summary>
        /// <param name="imageId">ImageId property</param>
        /// <returns>this instance</returns>
        public Image WithImageId(String imageId)
        {
            this.imageIdField = imageId;
            return this;
        }



        /// <summary>
        /// Checks if ImageId property is set
        /// </summary>
        /// <returns>true if ImageId property is set</returns>
        public Boolean IsSetImageId()
        {
            return  this.imageIdField != null;

        }


        /// <summary>
        /// Gets and sets the ImageLocation property.
        /// </summary>
        [XmlElementAttribute(ElementName = "ImageLocation")]
        public String ImageLocation
        {
            get { return this.imageLocationField ; }
            set { this.imageLocationField= value; }
        }



        /// <summary>
        /// Sets the ImageLocation property
        /// </summary>
        /// <param name="imageLocation">ImageLocation property</param>
        /// <returns>this instance</returns>
        public Image WithImageLocation(String imageLocation)
        {
            this.imageLocationField = imageLocation;
            return this;
        }



        /// <summary>
        /// Checks if ImageLocation property is set
        /// </summary>
        /// <returns>true if ImageLocation property is set</returns>
        public Boolean IsSetImageLocation()
        {
            return  this.imageLocationField != null;

        }


        /// <summary>
        /// Gets and sets the ImageState property.
        /// </summary>
        [XmlElementAttribute(ElementName = "ImageState")]
        public String ImageState
        {
            get { return this.imageStateField ; }
            set { this.imageStateField= value; }
        }



        /// <summary>
        /// Sets the ImageState property
        /// </summary>
        /// <param name="imageState">ImageState property</param>
        /// <returns>this instance</returns>
        public Image WithImageState(String imageState)
        {
            this.imageStateField = imageState;
            return this;
        }



        /// <summary>
        /// Checks if ImageState property is set
        /// </summary>
        /// <returns>true if ImageState property is set</returns>
        public Boolean IsSetImageState()
        {
            return  this.imageStateField != null;

        }


        /// <summary>
        /// Gets and sets the OwnerId property.
        /// </summary>
        [XmlElementAttribute(ElementName = "OwnerId")]
        public String OwnerId
        {
            get { return this.ownerIdField ; }
            set { this.ownerIdField= value; }
        }



        /// <summary>
        /// Sets the OwnerId property
        /// </summary>
        /// <param name="ownerId">OwnerId property</param>
        /// <returns>this instance</returns>
        public Image WithOwnerId(String ownerId)
        {
            this.ownerIdField = ownerId;
            return this;
        }



        /// <summary>
        /// Checks if OwnerId property is set
        /// </summary>
        /// <returns>true if OwnerId property is set</returns>
        public Boolean IsSetOwnerId()
        {
            return  this.ownerIdField != null;

        }


        /// <summary>
        /// Gets and sets the Visibility property.
        /// </summary>
        [XmlElementAttribute(ElementName = "Visibility")]
        public String Visibility
        {
            get { return this.visibilityField ; }
            set { this.visibilityField= value; }
        }



        /// <summary>
        /// Sets the Visibility property
        /// </summary>
        /// <param name="visibility">Visibility property</param>
        /// <returns>this instance</returns>
        public Image WithVisibility(String visibility)
        {
            this.visibilityField = visibility;
            return this;
        }



        /// <summary>
        /// Checks if Visibility property is set
        /// </summary>
        /// <returns>true if Visibility property is set</returns>
        public Boolean IsSetVisibility()
        {
            return  this.visibilityField != null;

        }


        /// <summary>
        /// Gets and sets the ProductCode property.
        /// </summary>
        [XmlElementAttribute(ElementName = "ProductCode")]
        public List<String> ProductCode
        {
            get
            {
                if (this.productCodeField == null)
                {
                    this.productCodeField = new List<String>();
                }
                return this.productCodeField;
            }
            set { this.productCodeField =  value; }
        }



        /// <summary>
        /// Sets the ProductCode property
        /// </summary>
        /// <param name="list">ProductCode property</param>
        /// <returns>this instance</returns>
        public Image WithProductCode(params String[] list)
        {
            foreach (String item in list)
            {
                ProductCode.Add(item);
            }
            return this;
        }          
 


        /// <summary>
        /// Checks of ProductCode property is set
        /// </summary>
        /// <returns>true if ProductCode property is set</returns>
        public Boolean IsSetProductCode()
        {
            return (ProductCode.Count > 0);
        }




        /// <summary>
        /// Gets and sets the Architecture property.
        /// </summary>
        [XmlElementAttribute(ElementName = "Architecture")]
        public String Architecture
        {
            get { return this.architectureField ; }
            set { this.architectureField= value; }
        }



        /// <summary>
        /// Sets the Architecture property
        /// </summary>
        /// <param name="architecture">Architecture property</param>
        /// <returns>this instance</returns>
        public Image WithArchitecture(String architecture)
        {
            this.architectureField = architecture;
            return this;
        }



        /// <summary>
        /// Checks if Architecture property is set
        /// </summary>
        /// <returns>true if Architecture property is set</returns>
        public Boolean IsSetArchitecture()
        {
            return  this.architectureField != null;

        }


        /// <summary>
        /// Gets and sets the ImageType property.
        /// </summary>
        [XmlElementAttribute(ElementName = "ImageType")]
        public String ImageType
        {
            get { return this.imageTypeField ; }
            set { this.imageTypeField= value; }
        }



        /// <summary>
        /// Sets the ImageType property
        /// </summary>
        /// <param name="imageType">ImageType property</param>
        /// <returns>this instance</returns>
        public Image WithImageType(String imageType)
        {
            this.imageTypeField = imageType;
            return this;
        }



        /// <summary>
        /// Checks if ImageType property is set
        /// </summary>
        /// <returns>true if ImageType property is set</returns>
        public Boolean IsSetImageType()
        {
            return  this.imageTypeField != null;

        }


        /// <summary>
        /// Gets and sets the KernelId property.
        /// </summary>
        [XmlElementAttribute(ElementName = "KernelId")]
        public String KernelId
        {
            get { return this.kernelIdField ; }
            set { this.kernelIdField= value; }
        }



        /// <summary>
        /// Sets the KernelId property
        /// </summary>
        /// <param name="kernelId">KernelId property</param>
        /// <returns>this instance</returns>
        public Image WithKernelId(String kernelId)
        {
            this.kernelIdField = kernelId;
            return this;
        }



        /// <summary>
        /// Checks if KernelId property is set
        /// </summary>
        /// <returns>true if KernelId property is set</returns>
        public Boolean IsSetKernelId()
        {
            return  this.kernelIdField != null;

        }


        /// <summary>
        /// Gets and sets the RamdiskId property.
        /// </summary>
        [XmlElementAttribute(ElementName = "RamdiskId")]
        public String RamdiskId
        {
            get { return this.ramdiskIdField ; }
            set { this.ramdiskIdField= value; }
        }



        /// <summary>
        /// Sets the RamdiskId property
        /// </summary>
        /// <param name="ramdiskId">RamdiskId property</param>
        /// <returns>this instance</returns>
        public Image WithRamdiskId(String ramdiskId)
        {
            this.ramdiskIdField = ramdiskId;
            return this;
        }



        /// <summary>
        /// Checks if RamdiskId property is set
        /// </summary>
        /// <returns>true if RamdiskId property is set</returns>
        public Boolean IsSetRamdiskId()
        {
            return  this.ramdiskIdField != null;

        }


        /// <summary>
        /// Gets and sets the Platform property.
        /// </summary>
        [XmlElementAttribute(ElementName = "Platform")]
        public String Platform
        {
            get { return this.platformField ; }
            set { this.platformField= value; }
        }



        /// <summary>
        /// Sets the Platform property
        /// </summary>
        /// <param name="platform">Platform property</param>
        /// <returns>this instance</returns>
        public Image WithPlatform(String platform)
        {
            this.platformField = platform;
            return this;
        }



        /// <summary>
        /// Checks if Platform property is set
        /// </summary>
        /// <returns>true if Platform property is set</returns>
        public Boolean IsSetPlatform()
        {
            return  this.platformField != null;

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
            if (IsSetImageId()) {
                xml.Append("<ImageId>");
                xml.Append(EscapeXML(this.ImageId));
                xml.Append("</ImageId>");
            }
            if (IsSetImageLocation()) {
                xml.Append("<ImageLocation>");
                xml.Append(EscapeXML(this.ImageLocation));
                xml.Append("</ImageLocation>");
            }
            if (IsSetImageState()) {
                xml.Append("<ImageState>");
                xml.Append(EscapeXML(this.ImageState));
                xml.Append("</ImageState>");
            }
            if (IsSetOwnerId()) {
                xml.Append("<OwnerId>");
                xml.Append(EscapeXML(this.OwnerId));
                xml.Append("</OwnerId>");
            }
            if (IsSetVisibility()) {
                xml.Append("<Visibility>");
                xml.Append(EscapeXML(this.Visibility));
                xml.Append("</Visibility>");
            }
            List<String> productCodeList  =  this.ProductCode;
            foreach (String productCode in productCodeList) { 
                xml.Append("<ProductCode>");
                xml.Append(EscapeXML(productCode));
                xml.Append("</ProductCode>");
            }	
            if (IsSetArchitecture()) {
                xml.Append("<Architecture>");
                xml.Append(EscapeXML(this.Architecture));
                xml.Append("</Architecture>");
            }
            if (IsSetImageType()) {
                xml.Append("<ImageType>");
                xml.Append(EscapeXML(this.ImageType));
                xml.Append("</ImageType>");
            }
            if (IsSetKernelId()) {
                xml.Append("<KernelId>");
                xml.Append(EscapeXML(this.KernelId));
                xml.Append("</KernelId>");
            }
            if (IsSetRamdiskId()) {
                xml.Append("<RamdiskId>");
                xml.Append(EscapeXML(this.RamdiskId));
                xml.Append("</RamdiskId>");
            }
            if (IsSetPlatform()) {
                xml.Append("<Platform>");
                xml.Append(EscapeXML(this.Platform));
                xml.Append("</Platform>");
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