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
    public class SecurityGroup
    {
    
        private String ownerIdField;

        private String groupNameField;

        private String groupDescriptionField;

        private  List<IpPermission> ipPermissionField;


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
        public SecurityGroup WithOwnerId(String ownerId)
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
        public SecurityGroup WithGroupName(String groupName)
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
        public SecurityGroup WithGroupDescription(String groupDescription)
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


        /// <summary>
        /// Gets and sets the IpPermission property.
        /// </summary>
        [XmlElementAttribute(ElementName = "IpPermission")]
        public List<IpPermission> IpPermission
        {
            get
            {
                if (this.ipPermissionField == null)
                {
                    this.ipPermissionField = new List<IpPermission>();
                }
                return this.ipPermissionField;
            }
            set { this.ipPermissionField =  value; }
        }



        /// <summary>
        /// Sets the IpPermission property
        /// </summary>
        /// <param name="list">IpPermission property</param>
        /// <returns>this instance</returns>
        public SecurityGroup WithIpPermission(params IpPermission[] list)
        {
            foreach (IpPermission item in list)
            {
                IpPermission.Add(item);
            }
            return this;
        }          
 


        /// <summary>
        /// Checks if IpPermission property is set
        /// </summary>
        /// <returns>true if IpPermission property is set</returns>
        public Boolean IsSetIpPermission()
        {
            return (IpPermission.Count > 0);
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
            if (IsSetOwnerId()) {
                xml.Append("<OwnerId>");
                xml.Append(EscapeXML(this.OwnerId));
                xml.Append("</OwnerId>");
            }
            if (IsSetGroupName()) {
                xml.Append("<GroupName>");
                xml.Append(EscapeXML(this.GroupName));
                xml.Append("</GroupName>");
            }
            if (IsSetGroupDescription()) {
                xml.Append("<GroupDescription>");
                xml.Append(EscapeXML(this.GroupDescription));
                xml.Append("</GroupDescription>");
            }
            List<IpPermission> ipPermissionList = this.IpPermission;
            foreach (IpPermission ipPermission in ipPermissionList) {
                xml.Append("<IpPermission>");
                xml.Append(ipPermission.ToXMLFragment());
                xml.Append("</IpPermission>");
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