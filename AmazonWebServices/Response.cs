// This software code is made available "AS IS" without warranties of any        
// kind.  You may copy, display, modify and redistribute the software            
// code either by itself or as incorporated into your code; provided that        
// you do not remove any proprietary notices.  Your use of this software         
// code is at your own risk and you waive any claim against Amazon               
// Digital Services, Inc. or its affiliates with respect to your use of          
// this software code. (c) 2006 Amazon Digital Services, Inc. or its             
// affiliates.          



using System;
using System.Diagnostics;
using System.Net;
using System.Text;

namespace com.amazon.s3
{
    public class Response
    {
        protected WebResponse response;
        public WebResponse Connection
        {
            get
            {
                return response;
            }
        }

        public HttpStatusCode Status
        {
            get
            {
                HttpWebResponse wr = response as HttpWebResponse;
                return wr.StatusCode;
            }
        }

        public string XAmzId
        {
            get
            {
                return response.Headers.Get("x-amz-id-2");
            }
        }

        public string XAmzRequestId
        {
            get
            {
                return response.Headers.Get("x-amz-request-id");
            }
        }

        public Response(WebRequest request)
        {
            int retries = 0;
            const int maxRetries = 3;
            WebException lastEx = null;

            do
            {
                try
                {
                    if (this.response != null)
                    {
                        try
                        {
                            this.response.Close();
                        }
                        catch { }
                    }

                    request.Timeout = 30000;
                    this.response = request.GetResponse();
                    lastEx = null;
                }
                catch (WebException ex)
                {
                    Debug.WriteLine("Response(request) failed with " + ex.Message);
                    long contentLength = request.ContentLength;

                    try
                    {
                        this.response.Close();
                    }
                    catch { }

                    try
                    {
                        request.Abort();
                    }
                    catch { }

                    lastEx = ex;
                    retries += 1;

                    int? statusCode;
                    HttpWebResponse response = ex.Response as HttpWebResponse;
                    if (response == null)
                    {
                        statusCode = null;
                        if (AWSAuthConnection.verbose)
                            Console.WriteLine("WebException ({0}) but couldn't determine status code", ex.Message);
                    }
                    else
                    {
                        statusCode = (int)response.StatusCode;
                        if (AWSAuthConnection.verbose)
                            Console.WriteLine("WebException ({0}) with status code {1}", ex.Message, statusCode);
                    }

                    if (contentLength == -1 && (statusCode == null || (statusCode >= 500 && statusCode < 600)))
                    {
                        if (AWSAuthConnection.verbose)
                            Console.WriteLine("Rebuilding request automatically");

                        // we can rebuild the request here and retry it (sadly there's no request.Reset())
                        WebRequest newRequest = WebRequest.Create(request.RequestUri);
                        foreach (string key in request.Headers.AllKeys)
                            if (key != "Host" && key != "Connection") // can't set either of these directly
                                newRequest.Headers.Add(key, request.Headers[key]);
                        newRequest.Method = request.Method;
                        if (newRequest is HttpWebRequest)
                        {
                            HttpWebRequest httpReq = newRequest as HttpWebRequest;
                            httpReq.AllowWriteStreamBuffering = false;
                        }
                        request = newRequest;

                        System.Threading.Thread.Sleep(250 * (int)Math.Pow(2, retries - 1));
                    }
                    else
                    {
                        request = null;
                        throw;
                    }
                }
            } while (retries < maxRetries && lastEx != null);

            if (lastEx != null)
            {
                Debug.WriteLine("lastEx not null");

                string msg = lastEx.Response != null ? Utils.slurpInputStream(lastEx.Response.GetResponseStream()) : lastEx.Message;
                try
                {
                    lastEx.Response.Close();
                }
                catch
                {
                    // ignore
                }
                throw new WebException(msg, lastEx, lastEx.Status, lastEx.Response);
            }
        }

        public string getResponseMessage()
        {
            string data = Utils.slurpInputStream(response.GetResponseStream());
            response.GetResponseStream().Close();
            return data;
        }
    }
}
