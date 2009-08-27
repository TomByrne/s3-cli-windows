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
    public class UserIdGroupPair
    {
    
        private String userIdField;

        private String groupNameField;


        /// <summary>
        /// Gets and sets the UserId property.
        /// </summary>
        [XmlElementAttribute(ElementName = "UserId")]
        public String UserId
        {
            get { return this.userIdField ; }
            set { this.userIdField= value; }
        }



        /// <summary>
        /// Sets the UserId property
        /// </summary>
        /// <param name="userId">UserId property</param>
        /// <returns>this instance</returns>
        public UserIdGroupPair WithUserId(String userId)
        {
            this.userIdField = userId;
            return this;
        }



        /// <summary>
        /// Checks if UserId property is set
        /// </summary>
        /// <returns>true if UserId property is set</returns>
        public Boolean IsSetUserId()
        {
            return  this.userIdField != null;

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
        public UserIdGroupPair WithGroupName(String groupName)
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
        /// XML fragment representation of this object
        /// </summary>
        /// <returns>XML fragment for this object.</returns>
        /// <remarks>
        /// Name for outer tag expected to be set by calling method. 
        /// This fragment returns inner properties representation only
        /// </remarks>


        protected internal String ToXMLFragment() {
            StringBuilder xml = new StringBuilder();
            if (IsSetUserId()) {
                xml.Append("<UserId>");
                xml.Append(EscapeXML(this.UserId));
                xml.Append("</UserId>");
            }
            if (IsSetGroupName()) {
                xml.Append("<GroupName>");
                xml.Append(EscapeXML(this.GroupName));
                xml.Append("</GroupName>");
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