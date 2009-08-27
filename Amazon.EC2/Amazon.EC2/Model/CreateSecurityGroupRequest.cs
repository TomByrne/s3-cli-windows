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
    public class CreateSecurityGroupRequest
    {
    
        private String groupNameField;

        private String groupDescriptionField;


        /// <summary>
        /// Gets and sets the GroupName property.
        /// </summary>
        [XmlElementAttribute(ElementName = "GroupName")]
        public String GroupName
        {
            get { return this.groupNameField ; }
            set { this.groupNameField= value; }
        }



        /// <summary>
        /// Sets the GroupName property
        /// </summary>
        /// <param name="groupName">GroupName property</param>
        /// <returns>this instance</returns>
        public CreateSecurityGroupRequest WithGroupName(String groupName)
        {
            this.groupNameField = groupName;
            return this;
        }



        /// <summary>
        /// Checks if GroupName property is set
        /// </summary>
        /// <returns>true if GroupName property is set</returns>
        public Boolean IsSetGroupName()
        {
            return  this.groupNameField != null;

        }


        /// <summary>
        /// Gets and sets the GroupDescription property.
        /// </summary>
        [XmlElementAttribute(ElementName = "GroupDescription")]
        public String GroupDescription
        {
            get { return this.groupDescriptionField ; }
            set { this.groupDescriptionField= value; }
        }



        /// <summary>
        /// Sets the GroupDescription property
        /// </summary>
        /// <param name="groupDescription">GroupDescription property</param>
        /// <returns>this instance</returns>
        public CreateSecurityGroupRequest WithGroupDescription(String groupDescription)
        {
            this.groupDescriptionField = groupDescription;
            return this;
        }



        /// <summary>
        /// Checks if GroupDescription property is set
        /// </summary>
        /// <returns>true if GroupDescription property is set</returns>
        public Boolean IsSetGroupDescription()
        {
            return  this.groupDescriptionField != null;

        }





    }

}