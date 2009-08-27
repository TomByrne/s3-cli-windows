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
    public class DescribeInstancesResult
    {
    
        private  List<Reservation> reservationField;


        /// <summary>
        /// Gets and sets the Reservation property.
        /// </summary>
        [XmlElementAttribute(ElementName = "Reservation")]
        public List<Reservation> Reservation
        {
            get
            {
                if (this.reservationField == null)
                {
                    this.reservationField = new List<Reservation>();
                }
                return this.reservationField;
            }
            set { this.reservationField =  value; }
        }



        /// <summary>
        /// Sets the Reservation property
        /// </summary>
        /// <param name="list">Reservation property</param>
        /// <returns>this instance</returns>
        public DescribeInstancesResult WithReservation(params Reservation[] list)
        {
            foreach (Reservation item in list)
            {
                Reservation.Add(item);
            }
            return this;
        }          
 


        /// <summary>
        /// Checks if Reservation property is set
        /// </summary>
        /// <returns>true if Reservation property is set</returns>
        public Boolean IsSetReservation()
        {
            return (Reservation.Count > 0);
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
            List<Reservation> reservationList = this.Reservation;
            foreach (Reservation reservation in reservationList) {
                xml.Append("<Reservation>");
                xml.Append(reservation.ToXMLFragment());
                xml.Append("</Reservation>");
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