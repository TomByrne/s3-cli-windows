using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Security;
using System.Security.Cryptography;
using System.Text;

using com.amazon.s3;

using s3.Properties;
using s3.Options;

namespace s3.Commands
{
    class Auth : Command
    {
        string key, secret, password;

        protected override void Initialise(CommandLine cl)
        {

            if (cl.args.Count == 0)
                GetAuthInteractively(ref key, ref secret, ref password);
            else if (cl.args.Count == 2)
            {
                key = cl.args[0];
                secret = cl.args[1];
            }
            else
                throw new SyntaxException("The auth command requires zero or two parameters");
        }

        public override void Execute()
        {
            SaveAuth(key, secret, password);
        }

        public static void GetAuthInteractively(ref string key, ref string secret, ref string password)
        {
            Console.WriteLine("Do you want to encrypt your Secret Access Key with a password? (yes/no)");
            if (Console.ReadLine().StartsWith("y", StringComparison.InvariantCultureIgnoreCase))
            {
                Console.Write("Please choose an encryption password: ");
                password = ReadPassword();
                Console.Write("Please enter your chosen password again: ");
                string p2 = ReadPassword();
                if (!password.Equals(p2))
                    throw new Exception("Passwords don't match");
            }
            else
                password = null;

            Console.Write("Enter your Access Key Id: ");
            key = Console.ReadLine().Trim();
            Console.Write("Enter your Secret Access Key: ");
            secret = ReadPassword();
        }

        public static string ReadPassword()
        {
            string password = "";

            ConsoleKeyInfo info = Console.ReadKey(true);
            while (info.Key != ConsoleKey.Enter)
            {
                if (!char.IsControl(info.KeyChar))
                {
                    password += info.KeyChar;
                    Console.Write(".");
                }
                else if (info.Key == ConsoleKey.Backspace)
                {
                    if (!string.IsNullOrEmpty(password))
                    {
                        password = password.Substring
                        (0, password.Length - 1);
                        Console.Write("\b \b");
                    }
                }
                info = Console.ReadKey(true);
            }

            Console.WriteLine();
            return password.Trim();
        }

        public static void SaveAuth(string key, string secret, string password)
        {
            Settings.Default.AccessKeyId = key;

            if (password == null)
            {
                Settings.Default.AccessKeySecret = secret;
                Settings.Default.Encrypted = false;
            }
            else
            {
                MD5CryptoServiceProvider HashProvider = new MD5CryptoServiceProvider();
                byte[] TDESKey = HashProvider.ComputeHash(Encoding.UTF8.GetBytes(password));

                TripleDESCryptoServiceProvider TDESAlgorithm = new TripleDESCryptoServiceProvider();
                TDESAlgorithm.Key = TDESKey;
                TDESAlgorithm.Mode = CipherMode.ECB;
                TDESAlgorithm.Padding = PaddingMode.PKCS7;

                byte[] results;

                try
                {
                    ICryptoTransform Encryptor = TDESAlgorithm.CreateEncryptor();
                    byte[] data = Encoding.UTF8.GetBytes(secret);
                    results = Encryptor.TransformFinalBlock(data, 0, data.Length);
                }
                finally
                {
                    TDESAlgorithm.Clear();
                    HashProvider.Clear();
                }

                Settings.Default.AccessKeySecret = Convert.ToBase64String(results);
                Settings.Default.Encrypted = true;
            }

            Settings.Default.Save();
        }

        internal static void LoadAuth(ref string id, ref string secret)
        {
            id = Settings.Default.AccessKeyId;

            if (Settings.Default.Encrypted)
            {
                Console.Write("Please enter your encryption password: ");
                string password = ReadPassword();

                MD5CryptoServiceProvider HashProvider = new MD5CryptoServiceProvider();
                byte[] TDESKey = HashProvider.ComputeHash(Encoding.UTF8.GetBytes(password));

                TripleDESCryptoServiceProvider TDESAlgorithm = new TripleDESCryptoServiceProvider();
                TDESAlgorithm.Key = TDESKey;
                TDESAlgorithm.Mode = CipherMode.ECB;
                TDESAlgorithm.Padding = PaddingMode.PKCS7;

                byte[] results;

                try
                {
                    ICryptoTransform Decryptor = TDESAlgorithm.CreateDecryptor();
                    byte[] data = Convert.FromBase64String(Settings.Default.AccessKeySecret);
                    results = Decryptor.TransformFinalBlock(data, 0, data.Length);
                }
                catch (CryptographicException ex)
                {
                    throw new Exception("Wrong password, or other cryptographic error", ex);
                }
                finally
                {
                    TDESAlgorithm.Clear();
                    HashProvider.Clear();
                }

                secret = Encoding.UTF8.GetString(results);
            }
            else
                secret = Settings.Default.AccessKeySecret;
        }
    }
}
