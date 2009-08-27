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
    public class ModifyImageAttributeRequest
    {
    
        private String imageIdField;

        private String attributeField;

        private String operationTypeField;

        private List<String> userIdField;

        private List<String> userGroupField;

        private List<String> productCodeField;


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
        public ModifyImageAttributeRequest WithImageId(String imageId)
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
        /// Gets and sets the Attribute property.
        /// </summary>
        [XmlElementAttribute(ElementName = "Attribute")]
        public String Attribute
        {
            get { return this.attributeField ; }
            set { this.attributeField= value; }
        }



        /// <summary>
        /// Sets the Attribute property
        /// </summary>
        /// <param name="attribute">Attribute property</param>
        /// <returns>this instance</returns>
        public ModifyImageAttributeRequest WithAttribute(String attribute)
        {
            this.attributeField = attribute;
            return this;
        }



        /// <summary>
        /// Checks if Attribute property is set
        /// </summary>
        /// <returns>true if Attribute property is set</returns>
        public Boolean IsSetAttribute()
        {
            return  this.attributeField != null;

        }


        /// <summary>
        /// Gets and sets the OperationType property.
        /// </summary>
        [XmlElementAttribute(ElementName = "OperationType")]
        public String OperationType
        {
            get { return this.operationTypeField ; }
            set { this.operationTypeField= value; }
        }



        /// <summary>
        /// Sets the OperationType property
        /// </summary>
        /// <param name="operationType">OperationType property</param>
        /// <returns>this instance</returns>
        public ModifyImageAttributeRequest WithOperationType(String operationType)
        {
            this.operationTypeField = operationType;
            return this;
        }



        /// <summary>
        /// Checks if OperationType property is set
        /// </summary>
        /// <returns>true if OperationType property is set</returns>
        public Boolean IsSetOperationType()
        {
            return  this.operationTypeField != null;

        }


        /// <summary>
        /// Gets and sets the UserId property.
        /// </summary>
        [XmlElementAttribute(ElementName = "UserId")]
        public List<String> UserId
        {
            get
            {
                if (this.userIdField == null)
                {
                    this.userIdField = new List<String>();
                }
                return this.userIdField;
            }
            set { this.userIdField =  value; }
        }



        /// <summary>
        /// Sets the UserId property
        /// </summary>
        /// <param name="list">UserId property</param>
        /// <returns>this instance</returns>
        public ModifyImageAttributeRequest WithUserId(params String[] list)
        {
            foreach (String item in list)
            {
                UserId.Add(item);
            }
            return this;
        }          
 


        /// <summary>
        /// Checks of UserId property is set
        /// </summary>
        /// <returns>true if UserId property is set</returns>
        public Boolean IsSetUserId()
        {
            return (UserId.Count > 0);
        }




        /// <summary>
        /// Gets and sets the UserGroup property.
        /// </summary>
        [XmlElementAttribute(ElementName = "UserGroup")]
        public List<String> UserGroup
        {
            get
            {
                if (this.userGroupField == null)
                {
                    this.userGroupField = new List<String>();
                }
                return this.userGroupField;
            }
            set { this.userGroupField =  value; }
        }



        /// <summary>
        /// Sets the UserGroup property
        /// </summary>
        /// <param name="list">UserGroup property</param>
        /// <returns>this instance</returns>
        public ModifyImageAttributeRequest WithUserGroup(params String[] list)
        {
            foreach (String item in list)
            {
                UserGroup.Add(item);
            }
            return this;
        }          
 


        /// <summary>
        /// Checks of UserGroup property is set
        /// </summary>
        /// <returns>true if UserGroup property is set</returns>
        public Boolean IsSetUserGroup()
        {
            return (UserGroup.Count > 0);
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
        public ModifyImageAttributeRequest WithProductCode(params String[] list)
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







    }

}