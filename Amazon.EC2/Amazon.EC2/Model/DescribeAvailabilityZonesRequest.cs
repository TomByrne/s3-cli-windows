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
    public class DescribeAvailabilityZonesRequest
    {
    
        private List<String> zoneNameField;


        /// <summary>
        /// Gets and sets the ZoneName property.
        /// </summary>
        [XmlElementAttribute(ElementName = "ZoneName")]
        public List<String> ZoneName
        {
            get
            {
                if (this.zoneNameField == null)
                {
                    this.zoneNameField = new List<String>();
                }
                return this.zoneNameField;
            }
            set { this.zoneNameField =  value; }
        }



        /// <summary>
        /// Sets the ZoneName property
        /// </summary>
        /// <param name="list">ZoneName property</param>
        /// <returns>this instance</returns>
        public DescribeAvailabilityZonesRequest WithZoneName(params String[] list)
        {
            foreach (String item in list)
            {
                ZoneName.Add(item);
            }
            return this;
        }          
 


        /// <summary>
        /// Checks of ZoneName property is set
        /// </summary>
        /// <returns>true if ZoneName property is set</returns>
        public Boolean IsSetZoneName()
        {
            return (ZoneName.Count > 0);
        }







    }

}