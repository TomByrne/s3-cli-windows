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
using System.Collections.Generic;
using System.Diagnostics;
using System.Net;
using System.Net.Sockets;
using System.Security.Cryptography;
using System.Text;
using System.Threading;
using System.Web;
using System.IO;

namespace com.amazon.s3
{
    public delegate void progressHandler(string description, long bytesDone, long bytesTotal);

    /// An interface into the S3 system.  It is initially configured with
    /// authentication and connection parameters and exposes methods to access and
    /// manipulate S3 data.
    public partial class AWSAuthConnection
    {
        private string awsAccessKeyId;
        private string awsSecretAccessKey;
        private bool isSecure;
        private int port;

        public static event progressHandler progress;

        public AWSAuthConnection()
            : this(OUR_ACCESS_KEY_ID, OUR_SECRET_ACCESS_KEY)
        {
        }

        public AWSAuthConnection(string awsAccessKeyId, string awsSecretAccessKey)
            :
            this(awsAccessKeyId, awsSecretAccessKey, false)
        {
        }

        public AWSAuthConnection(string awsAccessKeyId, string awsSecretAccessKey, bool isSecure)
            :
            this(awsAccessKeyId, awsSecretAccessKey, isSecure, isSecure ? Utils.SecurePort : Utils.InsecurePort)
        {
        }

        public AWSAuthConnection(string awsAccessKeyId, string awsSecretAccessKey, bool isSecure, int port)
        {
            this.awsAccessKeyId = awsAccessKeyId;
            this.awsSecretAccessKey = awsSecretAccessKey;
            this.isSecure = isSecure;
            this.port = port;
            ServicePointManager.DefaultConnectionLimit = 50;
        }

        /// <summary>
        /// Creates a new bucket.
        /// </summary>
        /// <param name="bucket">The name of the bucket to create</param>
        /// <param name="headers">A Map of string to string representing the headers to pass (can be null)</param>
        public Response createBucket(string bucket, SortedList headers)
        {
            S3Object obj = new S3Object("", null);
            WebRequest request = makeRequest("PUT", bucket, headers, obj, "");
            request.ContentLength = 0;
            request.GetRequestStream().Close();
            return new Response(request);
        }

        /// <summary>
        /// Lists the contents of a bucket.
        /// </summary>
        /// <param name="bucket">The name of the bucket to list</param>
        /// <param name="prefix">All returned keys will start with this string (can be null)</param>
        /// <param name="marker">All returned keys will be lexographically greater than this string (can be null)</param>
        /// <param name="maxKeys">The maximum number of keys to return (can be 0)</param>
        /// <param name="headers">A Map of string to string representing HTTP headers to pass.</param>
        public ListBucketResponse listBucket(string bucket, string prefix, string marker,
                                              int maxKeys, SortedList headers)
        {
            return listBucket(bucket, prefix, marker, maxKeys, null, headers);
        }

        /// <summary>
        /// Lists the contents of a bucket.
        /// </summary>
        /// <param name="bucket">The name of the bucket to list</param>
        /// <param name="prefix">All returned keys will start with this string (can be null)</param>
        /// <param name="marker">All returned keys will be lexographically greater than this string (can be null)</param>
        /// <param name="maxKeys">The maximum number of keys to return (can be 0)</param>
        /// <param name="headers">A Map of string to string representing HTTP headers to pass.</param>
        /// <param name="delimiter">Keys that contain a string between the prefix and the first
        /// occurrence of the delimiter will be rolled up into a single element.</param>
        public ListBucketResponse listBucket(string bucket, string prefix, string marker,
                                              int maxKeys, string delimiter, SortedList headers)
        {
            StringBuilder path = new StringBuilder("?");
            if (prefix != null) path.Append("prefix=").Append(HttpUtility.UrlEncode(prefix)).Append("&");
            if (marker != null) path.Append("marker=").Append(HttpUtility.UrlEncode(marker)).Append("&");
            if (maxKeys != 0) path.Append("max-keys=").Append(maxKeys).Append("&");
            if (delimiter != null) path.Append("delimiter=").Append(HttpUtility.UrlEncode(delimiter)).Append("&");
            // we've always added exactly one too many chars.
            path.Remove(path.Length - 1, 1);

            return new ListBucketResponse(makeRequest("GET", path.ToString(), headers, bucket));
        }

        /// <summary>
        /// Deletes an empty Bucket.
        /// </summary>
        /// <param name="bucket">The name of the bucket to delete</param>
        /// <param name="headers">A map of string to string representing the HTTP headers to pass (can be null)</param>
        /// <returns></returns>
        public Response deleteBucket(string bucket, SortedList headers)
        {
            return new Response(makeRequest("DELETE", bucket, headers, ""));
        }

        /// <summary>
        /// Writes an object to S3.
        /// </summary>
        /// <param name="bucket">The name of the bucket to which the object will be added.</param>
        /// <param name="key">The name of the key to use</param>
        /// <param name="obj">An S3Object containing the data to write.</param>
        /// <param name="headers">A map of string to string representing the HTTP headers to pass (can be null)</param>
        public Response put(string bucket, string key, S3Object obj, SortedList headers)
        {
            WebRequest request = makeRequest("PUT", encodeKeyForSignature(key), headers, obj, bucket);
            request.ContentLength = obj.Data.Length;

            ASCIIEncoding encoding = new ASCIIEncoding();
            byte[] bytes = encoding.GetBytes(obj.Data);
            request.GetRequestStream().Write(bytes, 0, bytes.Length);
            request.GetRequestStream().Close();

            return new Response(request);
        }

        public Response put(string bucket, string key, Stream str, SortedList headers)
        {
            return put(bucket, key, str, headers, 0, -1);
        }

        public Response put(string bucket, string key, Stream str, SortedList headers, long startByte, long bytes)
        {
            const int maxRetries = 5;
            const int bufferSize = 100 * 1024;

            headers["Content-MD5"] = Convert.ToBase64String(calculateMD5(str, startByte, bytes));
            int retries = 0;
            byte[] buffer = new byte[bufferSize];

            while (true)
            {
                WebRequest request = null;
                Exception failEx = null;

                try
                {
                    request = makeRequest("PUT", encodeKeyForSignature(key), headers, bucket);

                    long bytesToPut = bytes;
                    if (bytesToPut == -1)
                        request.ContentLength = str.Length;
                    else
                        request.ContentLength = bytesToPut;

                    str.Seek(startByte, SeekOrigin.Begin);
                    request.Timeout = Timeout.Infinite;
                    (request as HttpWebRequest).ReadWriteTimeout = 3 * 60 * 1000;  // 3 minutes

                    Stream sreq = null;

                    try
                    {
                        sreq = request.GetRequestStream();

                        long bytesWritten = 0;

                        while (bytesToPut != 0)
                        {
                            int bytesToRead;
                            if (bytesToPut == -1 || bytesToPut > buffer.Length)
                                bytesToRead = buffer.Length;
                            else
                                bytesToRead = (int)bytesToPut;
                            int nread = str.Read(buffer, 0, bytesToRead);
                            if (nread == 0) break;
                            sreq.Write(buffer, 0, nread);
                            bytesWritten += nread;
                            if (progress != null) progress(key, bytesWritten, request.ContentLength);

                            if (bytesToPut != -1)
                                bytesToPut -= nread;
                        }
                    }
                    finally
                    {
                        if (sreq != null)
                        {
                            sreq.Flush();
                            sreq.Close();
                            sreq.Dispose();
                        }
                    }

                    Response ret = new Response(request);
                    return ret;
                }
                catch (WebException ex)
                {
                    HttpWebResponse response = ex.Response as HttpWebResponse;
                    if (response != null && (int)response.StatusCode >= 400 && (int)response.StatusCode < 500)
                        throw;
                    failEx = ex;
                }
                catch (IOException ex)
                {
                    failEx = ex;
                }
                catch (SocketException ex)
                {
                    failEx = ex;
                }

                if (failEx != null)
                {
                    try
                    {
                        request.Abort();
                    }
                    catch { }
                    retries += 1;
                    if (verbose)
                        Console.WriteLine(string.Format("Put failed on attempt {0}: {1}", retries.ToString(), failEx.Message));
                    if (retries >= maxRetries)
                        throw failEx;
                    else
                        System.Threading.Thread.Sleep(250 * (int)Math.Pow(2, retries - 1));
                }
            }
        }

        internal static byte[] calculateMD5(Stream str, long startByte, long bytes)
        {
            const int bufferSize = 100 * 1024;

            byte[] buffer = new byte[bufferSize];
            MD5 md5Hasher = MD5.Create();
            str.Seek(startByte, SeekOrigin.Begin);
            long bytesToHash = bytes;

            while (bytesToHash != 0)
            {
                int bytesToRead;
                if (bytesToHash == -1 || bytesToHash > buffer.Length)
                    bytesToRead = buffer.Length;
                else
                    bytesToRead = (int)bytesToHash;
                int nread = str.Read(buffer, 0, bytesToRead);
                if (nread == 0) break;
                md5Hasher.TransformBlock(buffer, 0, nread, buffer, 0);

                if (bytesToHash != -1)
                    bytesToHash -= nread;
            }

            md5Hasher.TransformFinalBlock(new byte[0], 0, 0);
            return md5Hasher.Hash;
        }

        // NOTE: The Syste.Net.Uri class does modifications to the URL.
        // For example, if you have two consecutive slashes, it will
        // convert these to a single slash.  This could lead to invalid
        // signatures as best and at worst keys with names you do not
        // care for.
        private static string encodeKeyForSignature(string key)
        {
            if (key.IndexOf("\\") != -1)
                throw new Exception("Backslashes in key names cause problems");

            return HttpUtility.UrlEncode(key).Replace("%2f", "/");
        }

        /// <summary>
        /// Reads an object from S3
        /// </summary>
        /// <param name="bucket">The name of the bucket where the object lives</param>
        /// <param name="key">The name of the key to use</param>
        /// <param name="headers">A Map of string to string representing the HTTP headers to pass (can be null)</param>
        public GetResponse get(string bucket, string key, SortedList headers, bool asStream)
        {
            return new GetResponse(makeRequest("GET", encodeKeyForSignature(key), headers, bucket), asStream);
        }

        /// <summary>
        /// Reads the headers for an object from S3
        /// </summary>
        /// <param name="bucket">The name of the bucket where the object lives</param>
        /// <param name="key">The name of the key to use</param>
        /// <param name="headers">A Map of string to string representing the HTTP headers to pass (can be null)</param>
        public GetResponse head(string bucket, string key, SortedList headers)
        {
            return new GetResponse(makeRequest("HEAD", encodeKeyForSignature(key), headers, bucket), false);
        }

        /// <summary>
        /// Gets the last modified date for a key on S3 without downloading it
        /// </summary>
        /// <param name="bucket">The name of the bucket where the object lives</param>
        /// <param name="key">The name of the key to use</param>
        /// <returns>Returns time in UTC, or null if the object does not exist</returns>
        public DateTime? getLastModified(string bucket, string key)
        {
            WebResponse resp;

            try
            {
                resp = head(bucket, key, null).Connection;
            }
            catch (WebException ex)
            {
                if (((HttpWebResponse)ex.Response).StatusCode == HttpStatusCode.NotFound)
                    return null;
                else
                    throw;
            }

            resp.Close();
            return DateTime.Parse(resp.Headers["Last-Modified"]).ToUniversalTime();
        }

        /// <summary>
        /// Gets the MD5 checksum for a key on S3 without downloading it
        /// </summary>
        /// <param name="bucket">The name of the bucket where the object lives</param>
        /// <param name="key">The name of the key to use</param>
        /// <returns>Returns MD5 checksum as hex with no quotes (not base64)</returns>
        public string getChecksum(string bucket, string key)
        {
            WebResponse resp;

            try
            {
                resp = head(bucket, key, null).Connection;
            }
            catch (WebException ex)
            {
                if (((HttpWebResponse)ex.Response).StatusCode == HttpStatusCode.NotFound)
                    return null;
                else
                    throw;
            }

            resp.Close();
            string quotedHash = resp.Headers["ETag"];
            Debug.Assert(quotedHash[0] == '"');
            Debug.Assert(quotedHash[quotedHash.Length - 1] == '"');
            return quotedHash.Substring(1, quotedHash.Length - 2);
        }

        /// <summary>
        /// Delete an object from S3.
        /// </summary>
        /// <param name="bucket">The name of the bucket where the object lives.</param>
        /// <param name="key">The name of the key to use.</param>
        /// <param name="headers">A map of string to string representing the HTTP headers to pass (can be null)</param>
        /// <returns></returns>
        public Response delete(string bucket, string key, SortedList headers)
        {
            return new Response(makeRequest("DELETE", encodeKeyForSignature(key), headers, bucket));
        }

        /// <summary>
        /// Get the logging xml document for a given bucket
        /// </summary>
        /// <param name="bucket">The name of the bucket</param>
        /// <param name="headers">A map of string to string representing the HTTP headers to pass (can be null)</param>
        public GetResponse getBucketLogging(string bucket, SortedList headers)
        {
            return new GetResponse(makeRequest("GET", "?logging", headers, bucket), false);
        }

        /// <summary>
        /// Write a new logging xml document for a given bucket
        /// </summary>
        /// <param name="bucket">The name of the bucket to enable/disable logging on</param>
        /// <param name="loggingXMLDoc">The xml representation of the logging configuration as a String.</param>
        /// <param name="headers">A map of string to string representing the HTTP headers to pass (can be null)</param>
        public Response putBucketLogging(string bucket, string loggingXMLDoc, SortedList headers)
        {
            S3Object obj = new S3Object(loggingXMLDoc, null);

            WebRequest request = makeRequest("PUT", "?logging", headers, obj, bucket);
            request.ContentLength = loggingXMLDoc.Length;

            ASCIIEncoding encoding = new ASCIIEncoding();
            byte[] bytes = encoding.GetBytes(obj.Data);
            request.GetRequestStream().Write(bytes, 0, bytes.Length);
            request.GetRequestStream().Close();

            return new Response(request);
        }

        /// <summary>
        /// Get the ACL for a given bucket.
        /// </summary>
        /// <param name="bucket">The the bucket to get the ACL from.</param>
        /// <param name="headers">A map of string to string representing the HTTP headers to pass (can be null)</param>
        public GetResponse getBucketACL(string bucket, SortedList headers)
        {
            return getACL(bucket, null, headers);
        }

        /// <summary>
        /// Get the ACL for a given object
        /// </summary>
        /// <param name="bucket">The name of the bucket where the object lives</param>
        /// <param name="key">The name of the key to use.</param>
        /// <param name="headers">A map of string to string representing the HTTP headers to pass (can be null)</param>
        public GetResponse getACL(string bucket, string key, SortedList headers)
        {
            if (key == null) key = "";
            return new GetResponse(makeRequest("GET", encodeKeyForSignature(key) + "?acl", headers, bucket), false);
        }

        /// <summary>
        /// Write a new ACL for a given bucket
        /// </summary>
        /// <param name="bucket">The name of the bucket to change the ACL.</param>
        /// <param name="aclXMLDoc">An XML representation of the ACL as a string.</param>
        /// <param name="headers">A map of string to string representing the HTTP headers to pass (can be null)</param>
        public Response putBucketACL(string bucket, string aclXMLDoc, SortedList headers)
        {
            return putACL(bucket, null, aclXMLDoc, headers);
        }

        /// <summary>
        /// Write a new ACL for a given object
        /// </summary>
        /// <param name="bucket">The name of the bucket where the object lives or the
        /// name of the bucket to change the ACL if key is null.</param>
        /// <param name="key">The name of the key to use; can be null.</param>
        /// <param name="aclXMLDoc">An XML representation of the ACL as a string.</param>
        /// <param name="headers">A map of string to string representing the HTTP headers to pass (can be null)</param>
        public Response putACL(string bucket, string key, string aclXMLDoc, SortedList headers)
        {
            S3Object obj = new S3Object(aclXMLDoc, null);
            if (key == null) key = "";

            WebRequest request = makeRequest("PUT", encodeKeyForSignature(key) + "?acl", headers, obj, bucket);
            request.ContentLength = aclXMLDoc.Length;

            ASCIIEncoding encoding = new ASCIIEncoding();
            byte[] bytes = encoding.GetBytes(obj.Data);
            request.GetRequestStream().Write(bytes, 0, bytes.Length);
            request.GetRequestStream().Close();

            return new Response(request);
        }

        /// <summary>
        /// List all the buckets created by this account.
        /// </summary>
        /// <param name="headers">A map of string to string representing the HTTP headers to pass (can be null)</param>
        public ListAllMyBucketsResponse listAllMyBuckets(SortedList headers)
        {
            return new ListAllMyBucketsResponse(makeRequest("GET", "", headers, ""));
        }

        /// <summary>
        /// Make a new WebRequest without an S3Object.
        /// </summary>
        /// <param name="resourceWithoutBucket">The key WITHOUT BUCKET</param>
        private WebRequest makeRequest(string method, string resourceWithoutBucket, SortedList headers, string bucket)
        {
            return makeRequest(method, resourceWithoutBucket, headers, null, bucket);
        }

        /// <summary>
        /// Make a new WebRequest
        /// </summary>
        /// <param name="method">The HTTP method to use (GET, PUT, DELETE)</param>
        /// <param name="resource">The resource name WITHOUT BUCKET</param>
        /// <param name="headers">A map of string to string representing the HTTP headers to pass (can be null)</param>
        /// <param name="obj">S3Object that is to be written (can be null).</param>
        private WebRequest makeRequest(string method, string resourceWithoutBucket, SortedList headers, S3Object obj, string bucket)
        {
            string keyForUrl, keyForEncryption;
            string server = Utils.Host(bucket);

            if (bucket == "" && resourceWithoutBucket == "")
            {
                keyForUrl = "";
                keyForEncryption = "";
            }
            else
            {
                if (server == Utils.DEFAULT_SERVER)
                    keyForUrl = bucket + "/" + resourceWithoutBucket;
                else
                    keyForUrl = resourceWithoutBucket;

                keyForEncryption = bucket + "/" + resourceWithoutBucket;
            }

            string url = makeURL(server, keyForUrl);
            WebRequest req = WebRequest.Create(url);
            if (req is HttpWebRequest)
            {
                HttpWebRequest httpReq = req as HttpWebRequest;
                httpReq.AllowWriteStreamBuffering = false;
                httpReq.Proxy.Credentials = CredentialCache.DefaultCredentials;
            }
            req.Method = method;

            addHeaders(req, headers);
            if (obj != null) addMetadataHeaders(req, obj.Metadata);
            addAuthHeader(req, keyForEncryption);

            return req;
        }

        /// <summary>
        /// Add the given headers to the WebRequest
        /// </summary>
        /// <param name="req">Web request to add the headers to.</param>
        /// <param name="headers">A map of string to string representing the HTTP headers to pass (can be null)</param>
        private void addHeaders(WebRequest req, SortedList headers)
        {
            addHeaders(req, headers, "");
        }

        /// <summary>
        /// Add the given metadata fields to the WebRequest.
        /// </summary>
        /// <param name="req">Web request to add the headers to.</param>
        /// <param name="metadata">A map of string to string representing the S3 metadata for this resource.</param>
        private void addMetadataHeaders(WebRequest req, SortedList metadata)
        {
            addHeaders(req, metadata, Utils.METADATA_PREFIX);
        }

        /// <summary>
        /// Add the given headers to the WebRequest with a prefix before the keys.
        /// </summary>
        /// <param name="req">WebRequest to add the headers to.</param>
        /// <param name="headers">Headers to add.</param>
        /// <param name="prefix">String to prepend to each before ebfore adding it to the WebRequest</param>
        private void addHeaders(WebRequest req, SortedList headers, string prefix)
        {
            if (headers != null)
            {
                foreach (string key in headers.Keys)
                {
                    if (prefix.Length == 0 && key.Equals("Content-Type"))
                    {
                        req.ContentType = headers[key] as string;
                    }
                    else
                    {
                        req.Headers.Add(prefix + key, headers[key] as string);
                    }
                }
            }
        }

        /// <summary>
        /// Add the appropriate Authorization header to the WebRequest
        /// </summary>
        /// <param name="request">Request to add the header to</param>
        /// <param name="resource">The resource name (bucketName + "/" + key)</param>
        private void addAuthHeader(WebRequest request, string resource)
        {
            if (request.Headers[Utils.ALTERNATIVE_DATE_HEADER] == null)
            {
                request.Headers.Add(Utils.ALTERNATIVE_DATE_HEADER, Utils.getHttpDate());
            }

            string canonicalString = Utils.makeCanonicalString(resource, request);
            string encodedCanonical = Utils.encode(awsSecretAccessKey, canonicalString, false);
            request.Headers.Add("Authorization", "AWS " + awsAccessKeyId + ":" + encodedCanonical);
        }

        /// <summary>
        /// Create a new URL object for the given resource.
        /// </summary>
        /// <param name="resource">The resource name (bucketName + "/" + key)</param>
        private string makeURL(string server, string resource)
        {
            if (server == null)
                server = Utils.DEFAULT_SERVER;

            StringBuilder url = new StringBuilder();
            url.Append(isSecure ? "https" : "http").Append("://");
            url.Append(server).Append(":").Append(port).Append("/");
            url.Append(resource);
            return url.ToString();
        }
    }
}
