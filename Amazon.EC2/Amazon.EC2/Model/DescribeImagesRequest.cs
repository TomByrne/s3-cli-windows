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
    public class DescribeImagesRequest
    {
    
        private List<String> imageIdField;

        private List<String> ownerField;

        private List<String> executableByField;


        /// <summary>
        /// Gets and sets the ImageId property.
        /// </summary>
        [XmlElementAttribute(ElementName = "ImageId")]
        public List<String> ImageId
        {
            get
            {
                if (this.imageIdField == null)
                {
                    this.imageIdField = new List<String>();
                }
                return this.imageIdField;
            }
            set { this.imageIdField =  value; }
        }



        /// <summary>
        /// Sets the ImageId property
        /// </summary>
        /// <param name="list">ImageId property</param>
        /// <returns>this instance</returns>
        public DescribeImagesRequest WithImageId(params String[] list)
        {
            foreach (String item in list)
            {
                ImageId.Add(item);
            }
            return this;
        }          
 


        /// <summary>
        /// Checks of ImageId property is set
        /// </summary>
        /// <returns>true if ImageId property is set</returns>
        public Boolean IsSetImageId()
        {
            return (ImageId.Count > 0);
        }




        /// <summary>
        /// Gets and sets the Owner property.
        /// </summary>
        [XmlElementAttribute(ElementName = "Owner")]
        public List<String> Owner
        {
            get
            {
                if (this.ownerField == null)
                {
                    this.ownerField = new List<String>();
                }
                return this.ownerField;
            }
            set { this.ownerField =  value; }
        }



        /// <summary>
        /// Sets the Owner property
        /// </summary>
        /// <param name="list">Owner property</param>
        /// <returns>this instance</returns>
        public DescribeImagesRequest WithOwner(params String[] list)
        {
            foreach (String item in list)
            {
                Owner.Add(item);
            }
            return this;
        }          
 


        /// <summary>
        /// Checks of Owner property is set
        /// </summary>
        /// <returns>true if Owner property is set</returns>
        public Boolean IsSetOwner()
        {
            return (Owner.Count > 0);
        }




        /// <summary>
        /// Gets and sets the ExecutableBy property.
        /// </summary>
        [XmlElementAttribute(ElementName = "ExecutableBy")]
        public List<String> ExecutableBy
        {
            get
            {
                if (this.executableByField == null)
                {
                    this.executableByField = new List<String>();
                }
                return this.executableByField;
            }
            set { this.executableByField =  value; }
        }



        /// <summary>
        /// Sets the ExecutableBy property
        /// </summary>
        /// <param name="list">ExecutableBy property</param>
        /// <returns>this instance</returns>
        public DescribeImagesRequest WithExecutableBy(params String[] list)
        {
            foreach (String item in list)
            {
                ExecutableBy.Add(item);
            }
            return this;
        }          
 


        /// <summary>
        /// Checks of ExecutableBy property is set
        /// </summary>
        /// <returns>true if ExecutableBy property is set</returns>
        public Boolean IsSetExecutableBy()
        {
            return (ExecutableBy.Count > 0);
        }







    }

}