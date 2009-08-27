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
    public class IpPermission
    {
    
        private String ipProtocolField;

        private Decimal? fromPortField;

        private Decimal? toPortField;

        private  List<UserIdGroupPair> userIdGroupPairField;

        private List<String> ipRangeField;


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
        public IpPermission WithIpProtocol(String ipProtocol)
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
        public IpPermission WithFromPort(Decimal fromPort)
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
        public IpPermission WithToPort(Decimal toPort)
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
        /// Gets and sets the UserIdGroupPair property.
        /// </summary>
        [XmlElementAttribute(ElementName = "UserIdGroupPair")]
        public List<UserIdGroupPair> UserIdGroupPair
        {
            get
            {
                if (this.userIdGroupPairField == null)
                {
                    this.userIdGroupPairField = new List<UserIdGroupPair>();
                }
                return this.userIdGroupPairField;
            }
            set { this.userIdGroupPairField =  value; }
        }



        /// <summary>
        /// Sets the UserIdGroupPair property
        /// </summary>
        /// <param name="list">UserIdGroupPair property</param>
        /// <returns>this instance</returns>
        public IpPermission WithUserIdGroupPair(params UserIdGroupPair[] list)
        {
            foreach (UserIdGroupPair item in list)
            {
                UserIdGroupPair.Add(item);
            }
            return this;
        }          
 


        /// <summary>
        /// Checks if UserIdGroupPair property is set
        /// </summary>
        /// <returns>true if UserIdGroupPair property is set</returns>
        public Boolean IsSetUserIdGroupPair()
        {
            return (UserIdGroupPair.Count > 0);
        }


        /// <summary>
        /// Gets and sets the IpRange property.
        /// </summary>
        [XmlElementAttribute(ElementName = "IpRange")]
        public List<String> IpRange
        {
            get
            {
                if (this.ipRangeField == null)
                {
                    this.ipRangeField = new List<String>();
                }
                return this.ipRangeField;
            }
            set { this.ipRangeField =  value; }
        }



        /// <summary>
        /// Sets the IpRange property
        /// </summary>
        /// <param name="list">IpRange property</param>
        /// <returns>this instance</returns>
        public IpPermission WithIpRange(params String[] list)
        {
            foreach (String item in list)
            {
                IpRange.Add(item);
            }
            return this;
        }          
 


        /// <summary>
        /// Checks of IpRange property is set
        /// </summary>
        /// <returns>true if IpRange property is set</returns>
        public Boolean IsSetIpRange()
        {
            return (IpRange.Count > 0);
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
            if (IsSetIpProtocol()) {
                xml.Append("<IpProtocol>");
                xml.Append(EscapeXML(this.IpProtocol));
                xml.Append("</IpProtocol>");
            }
            if (IsSetFromPort()) {
                xml.Append("<FromPort>");
                xml.Append(this.FromPort);
                xml.Append("</FromPort>");
            }
            if (IsSetToPort()) {
                xml.Append("<ToPort>");
                xml.Append(this.ToPort);
                xml.Append("</ToPort>");
            }
            List<UserIdGroupPair> userIdGroupPairList = this.UserIdGroupPair;
            foreach (UserIdGroupPair userIdGroupPair in userIdGroupPairList) {
                xml.Append("<UserIdGroupPair>");
                xml.Append(userIdGroupPair.ToXMLFragment());
                xml.Append("</UserIdGroupPair>");
            }
            List<String> ipRangeList  =  this.IpRange;
            foreach (String ipRange in ipRangeList) { 
                xml.Append("<IpRange>");
                xml.Append(EscapeXML(ipRange));
                xml.Append("</IpRange>");
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