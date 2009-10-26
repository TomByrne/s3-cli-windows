using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Text;

using com.amazon.s3;

using s3.Properties;
using s3.Options;

namespace s3.Commands
{
    class Auth : Command
    {
        string key, secret;

        protected override void initialise(CommandLine cl)
        {
            if (cl.args.Count == 0)
            {
                getAuthInteractively(ref key, ref secret);
            }
            else if (cl.args.Count == 2)
            {
                key = cl.args[0];
                secret = cl.args[1];
            }
            else
                throw new SyntaxException("The auth command requires zero or two parameters");
        }

        public override void execute()
        {
            saveAuth(key, secret);
        }

        public static void getAuthInteractively(ref string key, ref string secret)
        {
            Console.Write("Enter your Access Key Id: ");
            key = Console.ReadLine().Trim();
            Console.Write("Enter your Access Key Secret: ");
            secret = Console.ReadLine().Trim();
        }

        public static void saveAuth(string key, string secret)
        {
            Settings.Default.AccessKeyId = key;
            Settings.Default.AccessKeySecret = secret;
            Settings.Default.Save();
        }

        public override void displayHelp()
        {
            Console.Error.WriteLine(@"
s3 auth [<key> <secret>]
    Prompts for authentication details or reads from command line if key and
    secret are specified.");
        }
    }
}
