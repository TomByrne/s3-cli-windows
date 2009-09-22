// This software code is made available "AS IS" without warranties of any        
// kind.  You may copy, display, modify and redistribute the software            
// code either by itself or as incorporated into your code; provided that        
// you do not remove any proprietary notices.  Your use of this software         
// code is at your own risk and you waive any claim against Amazon               
// Digital Services, Inc. or its affiliates with respect to your use of          
// this software code. (c) 2006 Amazon Digital Services, Inc. or its             
// affiliates.          


using System;
using System.Collections;
using System.IO;
using System.Net;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
using System.Web;
using System.Xml;

namespace com.amazon.s3
{
    class Utils
    {
        public static readonly string METADATA_PREFIX = "x-amz-meta-";
        public static readonly string AMAZON_HEADER_PREFIX = "x-amz-";
        public static readonly string ALTERNATIVE_DATE_HEADER = "x-amz-date";
        public static readonly string DEFAULT_SERVER = "s3.amazonaws.com";

        public static string Host(string bucket)
        {
            if (bucket == "")
                return DEFAULT_SERVER;
            else
                return bucket + "." + DEFAULT_SERVER;
        }

        private static int securePort = 443;
        public static int SecurePort
        {
            get
            {
                return securePort;
            }
            set
            {
                securePort = value;
            }
        }

        private static int insecurePort = 80;
        public static int InsecurePort
        {
            get
            {
                return insecurePort;
            }
            set
            {
                insecurePort = value;
            }
        }

        public static string makeCanonicalString(string resource, WebRequest request)
        {
            SortedList headers = new SortedList();
            foreach (string key in request.Headers)
            {
                headers.Add(key, request.Headers[key]);
            }
            if (headers["Content-Type"] == null)
            {
                headers.Add("Content-Type", request.ContentType);
            }
            return makeCanonicalString(request.Method, resource, headers, null);
        }

        public static string makeCanonicalString(string verb, string resource,
                                                  SortedList headers, string expires)
        {
            StringBuilder buf = new StringBuilder();
            buf.Append(verb);
            buf.Append("\n");

            SortedList interestingHeaders = new SortedList();
            if (headers != null)
            {
                foreach (string key in headers.Keys)
                {
                    string lk = key.ToLower();
                    if (lk.Equals("content-type") ||
                         lk.Equals("content-md5") ||
                         lk.Equals("date") ||
                         lk.StartsWith(AMAZON_HEADER_PREFIX))
                    {
                        interestingHeaders.Add(lk, headers[key]);
                    }
                }
            }
            if (interestingHeaders[ALTERNATIVE_DATE_HEADER] != null)
            {
                interestingHeaders.Add("date", "");
            }

            // if the expires is non-null, use that for the date field.  this
            // trumps the x-amz-date behavior.
            if (expires != null)
            {
                interestingHeaders.Add("date", expires);
            }

            // these headers require that we still put a new line after them,
            // even if they don't exist.
            {
                string[] newlineHeaders = { "content-type", "content-md5" };
                foreach (string header in newlineHeaders)
                {
                    if (interestingHeaders.IndexOfKey(header) == -1)
                    {
                        interestingHeaders.Add(header, "");
                    }
                }
            }

            // Finally, add all the interesting headers (i.e.: all that startwith x-amz- ;-))
            foreach (string key in interestingHeaders.Keys)
            {
                if (key.StartsWith(AMAZON_HEADER_PREFIX))
                {
                    buf.Append(key).Append(":").Append((interestingHeaders[key] as string).Trim());
                }
                else
                {
                    buf.Append(interestingHeaders[key]);
                }
                buf.Append("\n");
            }

            // Do not include the query string parameters
            int queryIndex = resource.IndexOf('?');
            if (queryIndex == -1)
            {
                buf.Append("/" + resource);
            }
            else
            {
                buf.Append("/" + resource.Substring(0, queryIndex));
            }

            Regex aclQueryStringRegEx = new Regex(".*[&?]acl($|=|&).*");
            Regex torrentQueryStringRegEx = new Regex(".*[&?]torrent($|=|&).*");
            Regex loggingQueryStringRegEx = new Regex(".*[&?]logging($|=|&).*");
            if (aclQueryStringRegEx.IsMatch(resource))
            {
                buf.Append("?acl");
            }
            else if (torrentQueryStringRegEx.IsMatch(resource))
            {
                buf.Append("?torrent");
            }
            else if (loggingQueryStringRegEx.IsMatch(resource))
            {
                buf.Append("?logging");
            }

            return buf.ToString();
        }

        public static string encode(string awsSecretAccessKey, string canonicalString, bool urlEncode)
        {
            Encoding ae = new UTF8Encoding();
            HMACSHA1 signature = new HMACSHA1(ae.GetBytes(awsSecretAccessKey));
            string b64 = Convert.ToBase64String(
                                        signature.ComputeHash(ae.GetBytes(
                                                        canonicalString.ToCharArray()))
                                               );

            if (urlEncode)
            {
                return HttpUtility.UrlEncode(b64);
            }
            else
            {
                return b64;
            }
        }

        public static string slurpInputStream(Stream stream)
        {
            StringBuilder data = new StringBuilder();

            try
            {
                System.Text.Encoding encode =
                    System.Text.Encoding.GetEncoding("utf-8");
                StreamReader readStream = new StreamReader(stream, encode);
                const int stride = 4096;
                Char[] read = new Char[stride];

                int count = readStream.Read(read, 0, stride);
                while (count > 0)
                {
                    string str = new string(read, 0, count);
                    data.Append(str);
                    count = readStream.Read(read, 0, stride);
                }
            }
            finally
            {
                stream.Close();
            }

            return data.ToString();
        }

        public static string getXmlChildText(XmlNode data)
        {
            StringBuilder builder = new StringBuilder();
            foreach (XmlNode node in data.ChildNodes)
            {
                if (node.NodeType == XmlNodeType.Text ||
                    node.NodeType == XmlNodeType.CDATA)
                {
                    builder.Append(node.Value);
                }
            }
            return builder.ToString();
        }

        public static DateTime parseDate(string dateStr)
        {
            return DateTime.Parse(dateStr);
        }

        public static string getHttpDate()
        {
            // Setting the Culture will ensure we get a proper HTTP Date.
            string date = System.DateTime.UtcNow.ToString("ddd, dd MMM yyyy HH:mm:ss ", System.Globalization.CultureInfo.InvariantCulture) + "GMT";
            return date;
        }

        public static long currentTimeMillis()
        {
            return (long)(DateTime.UtcNow - new DateTime(1970, 1, 1)).TotalMilliseconds;
        }
    }
}
