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
    public class ImageAttribute
    {
    
        private String imageIdField;

        private  List<LaunchPermission> launchPermissionField;

        private List<String> productCodeField;

        private String kernelIdField;

        private String ramdiskIdField;

        private  BlockDeviceMapping blockDeviceMappingField;

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
        public ImageAttribute WithImageId(String imageId)
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
        /// Gets and sets the LaunchPermission property.
        /// </summary>
        [XmlElementAttribute(ElementName = "LaunchPermission")]
        public List<LaunchPermission> LaunchPermission
        {
            get
            {
                if (this.launchPermissionField == null)
                {
                    this.launchPermissionField = new List<LaunchPermission>();
                }
                return this.launchPermissionField;
            }
            set { this.launchPermissionField =  value; }
        }



        /// <summary>
        /// Sets the LaunchPermission property
        /// </summary>
        /// <param name="list">LaunchPermission property</param>
        /// <returns>this instance</returns>
        public ImageAttribute WithLaunchPermission(params LaunchPermission[] list)
        {
            foreach (LaunchPermission item in list)
            {
                LaunchPermission.Add(item);
            }
            return this;
        }          
 


        /// <summary>
        /// Checks if LaunchPermission property is set
        /// </summary>
        /// <returns>true if LaunchPermission property is set</returns>
        public Boolean IsSetLaunchPermission()
        {
            return (LaunchPermission.Count > 0);
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
        public ImageAttribute WithProductCode(params String[] list)
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
        public ImageAttribute WithKernelId(String kernelId)
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
        public ImageAttribute WithRamdiskId(String ramdiskId)
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
        /// Gets and sets the BlockDeviceMapping property.
        /// </summary>
        [XmlElementAttribute(ElementName = "BlockDeviceMapping")]
        public BlockDeviceMapping BlockDeviceMapping
        {
            get { return this.blockDeviceMappingField ; }
            set { this.blockDeviceMappingField = value; }
        }



        /// <summary>
        /// Sets the BlockDeviceMapping property
        /// </summary>
        /// <param name="blockDeviceMapping">BlockDeviceMapping property</param>
        /// <returns>this instance</returns>
        public ImageAttribute WithBlockDeviceMapping(BlockDeviceMapping blockDeviceMapping)
        {
            this.blockDeviceMappingField = blockDeviceMapping;
            return this;
        }



        /// <summary>
        /// Checks if BlockDeviceMapping property is set
        /// </summary>
        /// <returns>true if BlockDeviceMapping property is set</returns>
        public Boolean IsSetBlockDeviceMapping()
        {
            return this.blockDeviceMappingField != null;
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
            List<LaunchPermission> launchPermissionList = this.LaunchPermission;
            foreach (LaunchPermission launchPermission in launchPermissionList) {
                xml.Append("<LaunchPermission>");
                xml.Append(launchPermission.ToXMLFragment());
                xml.Append("</LaunchPermission>");
            }
            List<String> productCodeList  =  this.ProductCode;
            foreach (String productCode in productCodeList) { 
                xml.Append("<ProductCode>");
                xml.Append(EscapeXML(productCode));
                xml.Append("</ProductCode>");
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
            if (IsSetBlockDeviceMapping()) {
                BlockDeviceMapping  blockDeviceMapping = this.BlockDeviceMapping;
                xml.Append("<BlockDeviceMapping>");
                xml.Append(blockDeviceMapping.ToXMLFragment());
                xml.Append("</BlockDeviceMapping>");
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