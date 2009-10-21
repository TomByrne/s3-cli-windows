﻿// s3.exe
// Command-line Amazon AWS utility for .NET
// http://s3.codeplex.com/

// This intentionally targets .NET 2.0 rather than 3.5, as Amazon EC2 instances only come with 2.0 as supplied(?) and
// the primary design goal is to have one .exe with no supporting DLLs that runs on a plain vanilla server without 
// having to install anything.

// Permission is hereby granted, free of charge, to any person obtaining a copy of this software and associated documentation files (the "Software"), 
// to deal in the Software without restriction, including without limitation the rights to use, copy, modify, merge, publish, distribute, sublicense, 
// and/or sell copies of the Software, and to permit persons to whom the Software is furnished to do so, subject to the following conditions:
//
// The above copyright notice and this permission notice shall be included in all copies or substantial portions of the Software.
//
// THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY, 
// FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER 
// LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS 
// IN THE SOFTWARE.

using System;
using System.Collections;
using System.Collections.Generic;
using System.Configuration;
using System.Diagnostics;
using System.IO;
using System.Xml;
using System.Xml.Serialization;

using com.amazon.s3;

using s3.Commands;
using s3.Options;
using s3.Properties;

namespace s3
{
    class Program
    {
        static int Main(string[] originalArgs)
        {
            bool debugOption = false;
            initialise();

            try
            {
                CommandLine cl = new CommandLine(originalArgs);

                if ((Settings.Default.AccessKeyId == "" || Settings.Default.AccessKeySecret == "") && !(cl.command is Auth))
                {
                    string key = null, secret = null;
                    Auth.getAuthInteractively(ref key, ref secret);
                    Auth.saveAuth(key, secret);
                }

                AWSAuthConnection.OUR_ACCESS_KEY_ID = Settings.Default.AccessKeyId;
                AWSAuthConnection.OUR_SECRET_ACCESS_KEY = Settings.Default.AccessKeySecret;

                
                debugOption = cl.options.ContainsKey(typeof(s3.Options.Verbose));
                cl.command.execute();
            }
            catch (SyntaxError ex)
            {
                Console.Error.WriteLine("Syntax error: {0}\nType 's3 help' for assistance.", ex.why);
                if (debugOption)
                    Console.Error.WriteLine(ex.StackTrace);
                return 3;
            }
            catch (NotFoundException ex)
            {
                Console.Error.WriteLine(string.Format("Not found: {0}", ex.what));
                if (debugOption)
                    Console.Error.WriteLine(ex.StackTrace);
                return 2;
            }
            catch (Amazon.EC2.AmazonEC2Exception ex)
            {
                Console.Error.WriteLine(ex.Message);
                if (debugOption)
                    Console.Error.WriteLine(ex.StackTrace);
            }
            catch (System.Net.WebException ex)
            {
                XmlSerializer ser = new XmlSerializer(typeof(S3Error));
                using (TextReader tr = new StringReader(ex.Message))
                {
                    try
                    {
                        S3Error error = ser.Deserialize(tr) as S3Error;
                        Console.Error.WriteLine(string.Format("{0}\t{1}", error.Code, error.Message));
                        if (debugOption)
                        {
                            Console.Error.WriteLine(ex.Message);
                            Console.Error.WriteLine(ex.StackTrace);
                        }
                    }
                    catch (InvalidOperationException)
                    {
                        // couldn't read XML so fall back to displaying the whole Message string from the original exception
                        Console.Error.WriteLine(ex.Message);
                        if (debugOption)
                            Console.Error.WriteLine(ex.StackTrace);
                    }
                }

                return 1;
            }
            catch (Exception ex)
            {
                Console.Error.WriteLine(ex.Message);
                if (debugOption)
                    Console.Error.WriteLine(ex.StackTrace);
                return 3;
            }

            return 0;
        }

        private static void initialise()
        {
            Version v = System.Reflection.Assembly.GetExecutingAssembly().GetName().Version;
            Console.Error.WriteLine("s3.exe version {0}.{1} - check for updates at http://s3.codeplex.com\n", v.Major, v.Minor);

            upgradeSettings();
        }

        private static void upgradeSettings()
        {
            System.Reflection.Assembly a = System.Reflection.Assembly.GetExecutingAssembly();
            Version appVersion = a.GetName().Version;
            string appVersionString = appVersion.ToString();

            if (Properties.Settings.Default.ApplicationVersion != appVersion.ToString())
            {
                Properties.Settings.Default.Upgrade();
                Properties.Settings.Default.ApplicationVersion = appVersionString;
                Properties.Settings.Default.Save();
            }
        }
    }
}

