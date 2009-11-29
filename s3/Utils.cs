using System;
using System.Collections.Generic;
using System.Text;

namespace s3
{
    static class Utils
    {
        public static bool IsMono
        {
            get
            {
                return Type.GetType("Mono.Runtime") != null;
            }
        }

        public static bool IsLinux
        {
            get
            {
                int p = (int)Environment.OSVersion.Platform;
                return ((p == 4) || (p == 128));
            }
        }

        private static readonly double kilobyte = 1024;
        private static readonly double megabyte = 1024 * kilobyte;
        private static readonly double gigabyte = 1024 * megabyte;
        private static readonly double terabyte = 1024 * gigabyte;

        public static string FormatFileSize(double bytes)
        {
            if (bytes > terabyte) return (bytes / terabyte).ToString("0.00 TB");
            else if (bytes > gigabyte) return (bytes / gigabyte).ToString("0.00 GB");
            else if (bytes > megabyte) return (bytes / megabyte).ToString("0.00 MB");
            else if (bytes > kilobyte) return (bytes / kilobyte).ToString("0.00 KB");
            else return bytes + " bytes";
        }

        public static string BytesToHex(byte[] bytes)
        {
            return String.Concat(Array.ConvertAll(bytes, delegate(byte x) { return x.ToString("X2"); }));
        }
    }
}
