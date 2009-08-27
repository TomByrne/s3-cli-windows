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
    public class Reservation
    {
    
        private String reservationIdField;

        private String ownerIdField;

        private String requesterIdField;

        private List<String> groupNameField;

        private  List<RunningInstance> runningInstanceField;


        /// <summary>
        /// Gets and sets the ReservationId property.
        /// </summary>
        [XmlElementAttribute(ElementName = "ReservationId")]
        public String ReservationId
        {
            get { return this.reservationIdField ; }
            set { this.reservationIdField= value; }
        }



        /// <summary>
        /// Sets the ReservationId property
        /// </summary>
        /// <param name="reservationId">ReservationId property</param>
        /// <returns>this instance</returns>
        public Reservation WithReservationId(String reservationId)
        {
            this.reservationIdField = reservationId;
            return this;
        }



        /// <summary>
        /// Checks if ReservationId property is set
        /// </summary>
        /// <returns>true if ReservationId property is set</returns>
        public Boolean IsSetReservationId()
        {
            return  this.reservationIdField != null;

        }


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
        public Reservation WithOwnerId(String ownerId)
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
        /// Gets and sets the RequesterId property.
        /// </summary>
        [XmlElementAttribute(ElementName = "RequesterId")]
        public String RequesterId
        {
            get { return this.requesterIdField ; }
            set { this.requesterIdField= value; }
        }



        /// <summary>
        /// Sets the RequesterId property
        /// </summary>
        /// <param name="requesterId">RequesterId property</param>
        /// <returns>this instance</returns>
        public Reservation WithRequesterId(String requesterId)
        {
            this.requesterIdField = requesterId;
            return this;
        }



        /// <summary>
        /// Checks if RequesterId property is set
        /// </summary>
        /// <returns>true if RequesterId property is set</returns>
        public Boolean IsSetRequesterId()
        {
            return  this.requesterIdField != null;

        }


        /// <summary>
        /// Gets and sets the GroupName property.
        /// </summary>
        [XmlElementAttribute(ElementName = "GroupName")]
        public List<String> GroupName
        {
            get
            {
                if (this.groupNameField == null)
                {
                    this.groupNameField = new List<String>();
                }
                return this.groupNameField;
            }
            set { this.groupNameField =  value; }
        }



        /// <summary>
        /// Sets the GroupName property
        /// </summary>
        /// <param name="list">GroupName property</param>
        /// <returns>this instance</returns>
        public Reservation WithGroupName(params String[] list)
        {
            foreach (String item in list)
            {
                GroupName.Add(item);
            }
            return this;
        }          
 


        /// <summary>
        /// Checks of GroupName property is set
        /// </summary>
        /// <returns>true if GroupName property is set</returns>
        public Boolean IsSetGroupName()
        {
            return (GroupName.Count > 0);
        }




        /// <summary>
        /// Gets and sets the RunningInstance property.
        /// </summary>
        [XmlElementAttribute(ElementName = "RunningInstance")]
        public List<RunningInstance> RunningInstance
        {
            get
            {
                if (this.runningInstanceField == null)
                {
                    this.runningInstanceField = new List<RunningInstance>();
                }
                return this.runningInstanceField;
            }
            set { this.runningInstanceField =  value; }
        }



        /// <summary>
        /// Sets the RunningInstance property
        /// </summary>
        /// <param name="list">RunningInstance property</param>
        /// <returns>this instance</returns>
        public Reservation WithRunningInstance(params RunningInstance[] list)
        {
            foreach (RunningInstance item in list)
            {
                RunningInstance.Add(item);
            }
            return this;
        }          
 


        /// <summary>
        /// Checks if RunningInstance property is set
        /// </summary>
        /// <returns>true if RunningInstance property is set</returns>
        public Boolean IsSetRunningInstance()
        {
            return (RunningInstance.Count > 0);
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
            if (IsSetReservationId()) {
                xml.Append("<ReservationId>");
                xml.Append(EscapeXML(this.ReservationId));
                xml.Append("</ReservationId>");
            }
            if (IsSetOwnerId()) {
                xml.Append("<OwnerId>");
                xml.Append(EscapeXML(this.OwnerId));
                xml.Append("</OwnerId>");
            }
            if (IsSetRequesterId()) {
                xml.Append("<RequesterId>");
                xml.Append(EscapeXML(this.RequesterId));
                xml.Append("</RequesterId>");
            }
            List<String> groupNameList  =  this.GroupName;
            foreach (String groupName in groupNameList) { 
                xml.Append("<GroupName>");
                xml.Append(EscapeXML(groupName));
                xml.Append("</GroupName>");
            }	
            List<RunningInstance> runningInstanceList = this.RunningInstance;
            foreach (RunningInstance runningInstance in runningInstanceList) {
                xml.Append("<RunningInstance>");
                xml.Append(runningInstance.ToXMLFragment());
                xml.Append("</RunningInstance>");
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