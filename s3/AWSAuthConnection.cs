using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace com.amazon.s3
{
    public partial class AWSAuthConnection
    {
        public static string OUR_ACCESS_KEY_ID, OUR_SECRET_ACCESS_KEY;
        public static bool verbose = false;

        public static SortedList GetHeaders(string acl, string filename, string storageClass)
        {
            SortedList headers = new SortedList();

            if (acl != null)
                headers.Add("x-amz-acl", acl);

            if (storageClass != null)
                headers.Add("x-amz-storage-class", storageClass);

            string mime = GetMimeType(filename);
            if (mime != null)
            {
                headers.Add("Content-Type", mime);
                if (verbose)
                    Console.WriteLine("Using MIME type " + mime);
            }

            return headers;
        }

        private static string GetMimeType(string fileName)
        {
            string mimeType = null;
            string ext = System.IO.Path.GetExtension(fileName).ToLower();
            Microsoft.Win32.RegistryKey regKey = Microsoft.Win32.Registry.ClassesRoot.OpenSubKey(ext);
            if (regKey != null && regKey.GetValue("Content Type") != null)
                mimeType = regKey.GetValue("Content Type").ToString();
            return mimeType;
        }
    }
}
