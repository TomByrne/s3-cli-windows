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
    public class RunningInstance
    {
    
        private String instanceIdField;

        private String imageIdField;

        private  InstanceState instanceStateField;
        private String privateDnsNameField;

        private String publicDnsNameField;

        private String stateTransitionReasonField;

        private String keyNameField;

        private String amiLaunchIndexField;

        private List<String> productCodeField;

        private String instanceTypeField;

        private String launchTimeField;

        private  Placement placementField;
        private String kernelIdField;

        private String ramdiskIdField;

        private String platformField;


        /// <summary>
        /// Gets and sets the InstanceId property.
        /// </summary>
        [XmlElementAttribute(ElementName = "InstanceId")]
        public String InstanceId
        {
            get { return this.instanceIdField ; }
            set { this.instanceIdField= value; }
        }



        /// <summary>
        /// Sets the InstanceId property
        /// </summary>
        /// <param name="instanceId">InstanceId property</param>
        /// <returns>this instance</returns>
        public RunningInstance WithInstanceId(String instanceId)
        {
            this.instanceIdField = instanceId;
            return this;
        }



        /// <summary>
        /// Checks if InstanceId property is set
        /// </summary>
        /// <returns>true if InstanceId property is set</returns>
        public Boolean IsSetInstanceId()
        {
            return  this.instanceIdField != null;

        }


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
        public RunningInstance WithImageId(String imageId)
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
        /// Gets and sets the InstanceState property.
        /// </summary>
        [XmlElementAttribute(ElementName = "InstanceState")]
        public InstanceState InstanceState
        {
            get { return this.instanceStateField ; }
            set { this.instanceStateField = value; }
        }



        /// <summary>
        /// Sets the InstanceState property
        /// </summary>
        /// <param name="instanceState">InstanceState property</param>
        /// <returns>this instance</returns>
        public RunningInstance WithInstanceState(InstanceState instanceState)
        {
            this.instanceStateField = instanceState;
            return this;
        }



        /// <summary>
        /// Checks if InstanceState property is set
        /// </summary>
        /// <returns>true if InstanceState property is set</returns>
        public Boolean IsSetInstanceState()
        {
            return this.instanceStateField != null;
        }




        /// <summary>
        /// Gets and sets the PrivateDnsName property.
        /// </summary>
        [XmlElementAttribute(ElementName = "PrivateDnsName")]
        public String PrivateDnsName
        {
            get { return this.privateDnsNameField ; }
            set { this.privateDnsNameField= value; }
        }



        /// <summary>
        /// Sets the PrivateDnsName property
        /// </summary>
        /// <param name="privateDnsName">PrivateDnsName property</param>
        /// <returns>this instance</returns>
        public RunningInstance WithPrivateDnsName(String privateDnsName)
        {
            this.privateDnsNameField = privateDnsName;
            return this;
        }



        /// <summary>
        /// Checks if PrivateDnsName property is set
        /// </summary>
        /// <returns>true if PrivateDnsName property is set</returns>
        public Boolean IsSetPrivateDnsName()
        {
            return  this.privateDnsNameField != null;

        }


        /// <summary>
        /// Gets and sets the PublicDnsName property.
        /// </summary>
        [XmlElementAttribute(ElementName = "PublicDnsName")]
        public String PublicDnsName
        {
            get { return this.publicDnsNameField ; }
            set { this.publicDnsNameField= value; }
        }



        /// <summary>
        /// Sets the PublicDnsName property
        /// </summary>
        /// <param name="publicDnsName">PublicDnsName property</param>
        /// <returns>this instance</returns>
        public RunningInstance WithPublicDnsName(String publicDnsName)
        {
            this.publicDnsNameField = publicDnsName;
            return this;
        }



        /// <summary>
        /// Checks if PublicDnsName property is set
        /// </summary>
        /// <returns>true if PublicDnsName property is set</returns>
        public Boolean IsSetPublicDnsName()
        {
            return  this.publicDnsNameField != null;

        }


        /// <summary>
        /// Gets and sets the StateTransitionReason property.
        /// </summary>
        [XmlElementAttribute(ElementName = "StateTransitionReason")]
        public String StateTransitionReason
        {
            get { return this.stateTransitionReasonField ; }
            set { this.stateTransitionReasonField= value; }
        }



        /// <summary>
        /// Sets the StateTransitionReason property
        /// </summary>
        /// <param name="stateTransitionReason">StateTransitionReason property</param>
        /// <returns>this instance</returns>
        public RunningInstance WithStateTransitionReason(String stateTransitionReason)
        {
            this.stateTransitionReasonField = stateTransitionReason;
            return this;
        }



        /// <summary>
        /// Checks if StateTransitionReason property is set
        /// </summary>
        /// <returns>true if StateTransitionReason property is set</returns>
        public Boolean IsSetStateTransitionReason()
        {
            return  this.stateTransitionReasonField != null;

        }


        /// <summary>
        /// Gets and sets the KeyName property.
        /// </summary>
        [XmlElementAttribute(ElementName = "KeyName")]
        public String KeyName
        {
            get { return this.keyNameField ; }
            set { this.keyNameField= value; }
        }



        /// <summary>
        /// Sets the KeyName property
        /// </summary>
        /// <param name="keyName">KeyName property</param>
        /// <returns>this instance</returns>
        public RunningInstance WithKeyName(String keyName)
        {
            this.keyNameField = keyName;
            return this;
        }



        /// <summary>
        /// Checks if KeyName property is set
        /// </summary>
        /// <returns>true if KeyName property is set</returns>
        public Boolean IsSetKeyName()
        {
            return  this.keyNameField != null;

        }


        /// <summary>
        /// Gets and sets the AmiLaunchIndex property.
        /// </summary>
        [XmlElementAttribute(ElementName = "AmiLaunchIndex")]
        public String AmiLaunchIndex
        {
            get { return this.amiLaunchIndexField ; }
            set { this.amiLaunchIndexField= value; }
        }



        /// <summary>
        /// Sets the AmiLaunchIndex property
        /// </summary>
        /// <param name="amiLaunchIndex">AmiLaunchIndex property</param>
        /// <returns>this instance</returns>
        public RunningInstance WithAmiLaunchIndex(String amiLaunchIndex)
        {
            this.amiLaunchIndexField = amiLaunchIndex;
            return this;
        }



        /// <summary>
        /// Checks if AmiLaunchIndex property is set
        /// </summary>
        /// <returns>true if AmiLaunchIndex property is set</returns>
        public Boolean IsSetAmiLaunchIndex()
        {
            return  this.amiLaunchIndexField != null;

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
        public RunningInstance WithProductCode(params String[] list)
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
        /// Gets and sets the InstanceType property.
        /// </summary>
        [XmlElementAttribute(ElementName = "InstanceType")]
        public String InstanceType
        {
            get { return this.instanceTypeField ; }
            set { this.instanceTypeField= value; }
        }



        /// <summary>
        /// Sets the InstanceType property
        /// </summary>
        /// <param name="instanceType">InstanceType property</param>
        /// <returns>this instance</returns>
        public RunningInstance WithInstanceType(String instanceType)
        {
            this.instanceTypeField = instanceType;
            return this;
        }



        /// <summary>
        /// Checks if InstanceType property is set
        /// </summary>
        /// <returns>true if InstanceType property is set</returns>
        public Boolean IsSetInstanceType()
        {
            return  this.instanceTypeField != null;

        }


        /// <summary>
        /// Gets and sets the LaunchTime property.
        /// </summary>
        [XmlElementAttribute(ElementName = "LaunchTime")]
        public String LaunchTime
        {
            get { return this.launchTimeField ; }
            set { this.launchTimeField= value; }
        }



        /// <summary>
        /// Sets the LaunchTime property
        /// </summary>
        /// <param name="launchTime">LaunchTime property</param>
        /// <returns>this instance</returns>
        public RunningInstance WithLaunchTime(String launchTime)
        {
            this.launchTimeField = launchTime;
            return this;
        }



        /// <summary>
        /// Checks if LaunchTime property is set
        /// </summary>
        /// <returns>true if LaunchTime property is set</returns>
        public Boolean IsSetLaunchTime()
        {
            return  this.launchTimeField != null;

        }


        /// <summary>
        /// Gets and sets the Placement property.
        /// </summary>
        [XmlElementAttribute(ElementName = "Placement")]
        public Placement Placement
        {
            get { return this.placementField ; }
            set { this.placementField = value; }
        }



        /// <summary>
        /// Sets the Placement property
        /// </summary>
        /// <param name="placement">Placement property</param>
        /// <returns>this instance</returns>
        public RunningInstance WithPlacement(Placement placement)
        {
            this.placementField = placement;
            return this;
        }



        /// <summary>
        /// Checks if Placement property is set
        /// </summary>
        /// <returns>true if Placement property is set</returns>
        public Boolean IsSetPlacement()
        {
            return this.placementField != null;
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
        public RunningInstance WithKernelId(String kernelId)
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
        public RunningInstance WithRamdiskId(String ramdiskId)
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
        public RunningInstance WithPlatform(String platform)
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
            if (IsSetInstanceId()) {
                xml.Append("<InstanceId>");
                xml.Append(EscapeXML(this.InstanceId));
                xml.Append("</InstanceId>");
            }
            if (IsSetImageId()) {
                xml.Append("<ImageId>");
                xml.Append(EscapeXML(this.ImageId));
                xml.Append("</ImageId>");
            }
            if (IsSetInstanceState()) {
                InstanceState  instanceState = this.InstanceState;
                xml.Append("<InstanceState>");
                xml.Append(instanceState.ToXMLFragment());
                xml.Append("</InstanceState>");
            } 
            if (IsSetPrivateDnsName()) {
                xml.Append("<PrivateDnsName>");
                xml.Append(EscapeXML(this.PrivateDnsName));
                xml.Append("</PrivateDnsName>");
            }
            if (IsSetPublicDnsName()) {
                xml.Append("<PublicDnsName>");
                xml.Append(EscapeXML(this.PublicDnsName));
                xml.Append("</PublicDnsName>");
            }
            if (IsSetStateTransitionReason()) {
                xml.Append("<StateTransitionReason>");
                xml.Append(EscapeXML(this.StateTransitionReason));
                xml.Append("</StateTransitionReason>");
            }
            if (IsSetKeyName()) {
                xml.Append("<KeyName>");
                xml.Append(EscapeXML(this.KeyName));
                xml.Append("</KeyName>");
            }
            if (IsSetAmiLaunchIndex()) {
                xml.Append("<AmiLaunchIndex>");
                xml.Append(EscapeXML(this.AmiLaunchIndex));
                xml.Append("</AmiLaunchIndex>");
            }
            List<String> productCodeList  =  this.ProductCode;
            foreach (String productCode in productCodeList) { 
                xml.Append("<ProductCode>");
                xml.Append(EscapeXML(productCode));
                xml.Append("</ProductCode>");
            }	
            if (IsSetInstanceType()) {
                xml.Append("<InstanceType>");
                xml.Append(EscapeXML(this.InstanceType));
                xml.Append("</InstanceType>");
            }
            if (IsSetLaunchTime()) {
                xml.Append("<LaunchTime>");
                xml.Append(EscapeXML(this.LaunchTime));
                xml.Append("</LaunchTime>");
            }
            if (IsSetPlacement()) {
                Placement  placement = this.Placement;
                xml.Append("<Placement>");
                xml.Append(placement.ToXMLFragment());
                xml.Append("</Placement>");
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