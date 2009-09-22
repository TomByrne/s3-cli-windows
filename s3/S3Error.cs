using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace s3
{
    [XmlType("Error")]
    public class S3Error
    {
        [XmlElement]
        public string Code;

        [XmlElement]
        public string Message;
    }
}
