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
    public class AuthorizeSecurityGroupIngressRequest
    {
    
        private String groupNameField;

        private String sourceSecurityGroupNameField;

        private String sourceSecurityGroupOwnerIdField;

        private String ipProtocolField;

        private Decimal? fromPortField;

        private Decimal? toPortField;

        private String cidrIpField;


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
        public AuthorizeSecurityGroupIngressRequest WithGroupName(String groupName)
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
        /// Gets and sets the SourceSecurityGroupName property.
        /// </summary>
        [XmlElementAttribute(ElementName = "SourceSecurityGroupName")]
        public String SourceSecurityGroupName
        {
            get { return this.sourceSecurityGroupNameField ; }
            set { this.sourceSecurityGroupNameField= value; }
        }



        /// <summary>
        /// Sets the SourceSecurityGroupName property
        /// </summary>
        /// <param name="sourceSecurityGroupName">SourceSecurityGroupName property</param>
        /// <returns>this instance</returns>
        public AuthorizeSecurityGroupIngressRequest WithSourceSecurityGroupName(String sourceSecurityGroupName)
        {
            this.sourceSecurityGroupNameField = sourceSecurityGroupName;
            return this;
        }



        /// <summary>
        /// Checks if SourceSecurityGroupName property is set
        /// </summary>
        /// <returns>true if SourceSecurityGroupName property is set</returns>
        public Boolean IsSetSourceSecurityGroupName()
        {
            return  this.sourceSecurityGroupNameField != null;

        }


        /// <summary>
        /// Gets and sets the SourceSecurityGroupOwnerId property.
        /// </summary>
        [XmlElementAttribute(ElementName = "SourceSecurityGroupOwnerId")]
        public String SourceSecurityGroupOwnerId
        {
            get { return this.sourceSecurityGroupOwnerIdField ; }
            set { this.sourceSecurityGroupOwnerIdField= value; }
        }



        /// <summary>
        /// Sets the SourceSecurityGroupOwnerId property
        /// </summary>
        /// <param name="sourceSecurityGroupOwnerId">SourceSecurityGroupOwnerId property</param>
        /// <returns>this instance</returns>
        public AuthorizeSecurityGroupIngressRequest WithSourceSecurityGroupOwnerId(String sourceSecurityGroupOwnerId)
        {
            this.sourceSecurityGroupOwnerIdField = sourceSecurityGroupOwnerId;
            return this;
        }



        /// <summary>
        /// Checks if SourceSecurityGroupOwnerId property is set
        /// </summary>
        /// <returns>true if SourceSecurityGroupOwnerId property is set</returns>
        public Boolean IsSetSourceSecurityGroupOwnerId()
        {
            return  this.sourceSecurityGroupOwnerIdField != null;

        }


        /// <summary>
        /// Gets and sets the IpProtocol property.
        /// </summary>
        [XmlElementAttribute(ElementName = "IpProtocol")]
        public String IpProtocol
        {
            get { return this.ipProtocolField ; }
            set { this.ipProtocolField= value; }
        }



        /// <summary>
        /// Sets the IpProtocol property
        /// </summary>
        /// <param name="ipProtocol">IpProtocol property</param>
        /// <returns>this instance</returns>
        public AuthorizeSecurityGroupIngressRequest WithIpProtocol(String ipProtocol)
        {
            this.ipProtocolField = ipProtocol;
            return this;
        }



        /// <summary>
        /// Checks if IpProtocol property is set
        /// </summary>
        /// <returns>true if IpProtocol property is set</returns>
        public Boolean IsSetIpProtocol()
        {
            return  this.ipProtocolField != null;

        }


        /// <summary>
        /// Gets and sets the FromPort property.
        /// </summary>
        [XmlElementAttribute(ElementName = "FromPort")]
        public Decimal FromPort
        {
            get { return this.fromPortField.GetValueOrDefault() ; }
            set { this.fromPortField= value; }
        }



        /// <summary>
        /// Sets the FromPort property
        /// </summary>
        /// <param name="fromPort">FromPort property</param>
        /// <returns>this instance</returns>
        public AuthorizeSecurityGroupIngressRequest WithFromPort(Decimal fromPort)
        {
            this.fromPortField = fromPort;
            return this;
        }



        /// <summary>
        /// Checks if FromPort property is set
        /// </summary>
        /// <returns>true if FromPort property is set</returns>
        public Boolean IsSetFromPort()
        {
            return  this.fromPortField.HasValue;

        }


        /// <summary>
        /// Gets and sets the ToPort property.
        /// </summary>
        [XmlElementAttribute(ElementName = "ToPort")]
        public Decimal ToPort
        {
            get { return this.toPortField.GetValueOrDefault() ; }
            set { this.toPortField= value; }
        }



        /// <summary>
        /// Sets the ToPort property
        /// </summary>
        /// <param name="toPort">ToPort property</param>
        /// <returns>this instance</returns>
        public AuthorizeSecurityGroupIngressRequest WithToPort(Decimal toPort)
        {
            this.toPortField = toPort;
            return this;
        }



        /// <summary>
        /// Checks if ToPort property is set
        /// </summary>
        /// <returns>true if ToPort property is set</returns>
        public Boolean IsSetToPort()
        {
            return  this.toPortField.HasValue;

        }


        /// <summary>
        /// Gets and sets the CidrIp property.
        /// </summary>
        [XmlElementAttribute(ElementName = "CidrIp")]
        public String CidrIp
        {
            get { return this.cidrIpField ; }
            set { this.cidrIpField= value; }
        }



        /// <summary>
        /// Sets the CidrIp property
        /// </summary>
        /// <param name="cidrIp">CidrIp property</param>
        /// <returns>this instance</returns>
        public AuthorizeSecurityGroupIngressRequest WithCidrIp(String cidrIp)
        {
            this.cidrIpField = cidrIp;
            return this;
        }



        /// <summary>
        /// Checks if CidrIp property is set
        /// </summary>
        /// <returns>true if CidrIp property is set</returns>
        public Boolean IsSetCidrIp()
        {
            return  this.cidrIpField != null;

        }





    }

}