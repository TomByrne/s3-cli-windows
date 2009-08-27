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
    public class RunInstancesRequest
    {
    
        private String imageIdField;

        private Decimal? minCountField;

        private Decimal? maxCountField;

        private String keyNameField;

        private List<String> securityGroupField;

        private String userDataField;

        private String instanceTypeField;

        private  Placement placementField;
        private String kernelIdField;

        private String ramdiskIdField;

        private  List<BlockDeviceMapping> blockDeviceMappingField;


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
        public RunInstancesRequest WithImageId(String imageId)
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
        /// Gets and sets the MinCount property.
        /// </summary>
        [XmlElementAttribute(ElementName = "MinCount")]
        public Decimal MinCount
        {
            get { return this.minCountField.GetValueOrDefault() ; }
            set { this.minCountField= value; }
        }



        /// <summary>
        /// Sets the MinCount property
        /// </summary>
        /// <param name="minCount">MinCount property</param>
        /// <returns>this instance</returns>
        public RunInstancesRequest WithMinCount(Decimal minCount)
        {
            this.minCountField = minCount;
            return this;
        }



        /// <summary>
        /// Checks if MinCount property is set
        /// </summary>
        /// <returns>true if MinCount property is set</returns>
        public Boolean IsSetMinCount()
        {
            return  this.minCountField.HasValue;

        }


        /// <summary>
        /// Gets and sets the MaxCount property.
        /// </summary>
        [XmlElementAttribute(ElementName = "MaxCount")]
        public Decimal MaxCount
        {
            get { return this.maxCountField.GetValueOrDefault() ; }
            set { this.maxCountField= value; }
        }



        /// <summary>
        /// Sets the MaxCount property
        /// </summary>
        /// <param name="maxCount">MaxCount property</param>
        /// <returns>this instance</returns>
        public RunInstancesRequest WithMaxCount(Decimal maxCount)
        {
            this.maxCountField = maxCount;
            return this;
        }



        /// <summary>
        /// Checks if MaxCount property is set
        /// </summary>
        /// <returns>true if MaxCount property is set</returns>
        public Boolean IsSetMaxCount()
        {
            return  this.maxCountField.HasValue;

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
        public RunInstancesRequest WithKeyName(String keyName)
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
        /// Gets and sets the SecurityGroup property.
        /// </summary>
        [XmlElementAttribute(ElementName = "SecurityGroup")]
        public List<String> SecurityGroup
        {
            get
            {
                if (this.securityGroupField == null)
                {
                    this.securityGroupField = new List<String>();
                }
                return this.securityGroupField;
            }
            set { this.securityGroupField =  value; }
        }



        /// <summary>
        /// Sets the SecurityGroup property
        /// </summary>
        /// <param name="list">SecurityGroup property</param>
        /// <returns>this instance</returns>
        public RunInstancesRequest WithSecurityGroup(params String[] list)
        {
            foreach (String item in list)
            {
                SecurityGroup.Add(item);
            }
            return this;
        }          
 


        /// <summary>
        /// Checks of SecurityGroup property is set
        /// </summary>
        /// <returns>true if SecurityGroup property is set</returns>
        public Boolean IsSetSecurityGroup()
        {
            return (SecurityGroup.Count > 0);
        }




        /// <summary>
        /// Gets and sets the UserData property.
        /// </summary>
        [XmlElementAttribute(ElementName = "UserData")]
        public String UserData
        {
            get { return this.userDataField ; }
            set { this.userDataField= value; }
        }



        /// <summary>
        /// Sets the UserData property
        /// </summary>
        /// <param name="userData">UserData property</param>
        /// <returns>this instance</returns>
        public RunInstancesRequest WithUserData(String userData)
        {
            this.userDataField = userData;
            return this;
        }



        /// <summary>
        /// Checks if UserData property is set
        /// </summary>
        /// <returns>true if UserData property is set</returns>
        public Boolean IsSetUserData()
        {
            return  this.userDataField != null;

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
        public RunInstancesRequest WithInstanceType(String instanceType)
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
        public RunInstancesRequest WithPlacement(Placement placement)
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
        public RunInstancesRequest WithKernelId(String kernelId)
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
        public RunInstancesRequest WithRamdiskId(String ramdiskId)
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
        public List<BlockDeviceMapping> BlockDeviceMapping
        {
            get
            {
                if (this.blockDeviceMappingField == null)
                {
                    this.blockDeviceMappingField = new List<BlockDeviceMapping>();
                }
                return this.blockDeviceMappingField;
            }
            set { this.blockDeviceMappingField =  value; }
        }



        /// <summary>
        /// Sets the BlockDeviceMapping property
        /// </summary>
        /// <param name="list">BlockDeviceMapping property</param>
        /// <returns>this instance</returns>
        public RunInstancesRequest WithBlockDeviceMapping(params BlockDeviceMapping[] list)
        {
            foreach (BlockDeviceMapping item in list)
            {
                BlockDeviceMapping.Add(item);
            }
            return this;
        }          
 


        /// <summary>
        /// Checks if BlockDeviceMapping property is set
        /// </summary>
        /// <returns>true if BlockDeviceMapping property is set</returns>
        public Boolean IsSetBlockDeviceMapping()
        {
            return (BlockDeviceMapping.Count > 0);
        }





    }

}