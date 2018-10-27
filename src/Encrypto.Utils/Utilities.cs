using System;
using System.IO;
using System.Linq;
using Encrypto.AESLibrary;

namespace Encrypto.Utils
{
    public static class Utilities
    {
        public static string Base64Encode(byte[] input)
        {
            return System.Convert.ToBase64String(input);
        }

        public static byte[] Base64Decode(string plainText)
        {
            return System.Convert.FromBase64String(plainText);
        }

        public static string CreateSecurePassword()
        {
            string pass = "";

            do
            {
                ConsoleKeyInfo keyInfo = Console.ReadKey(true);
                // Backspace Should Not Work
                if (keyInfo.Key != ConsoleKey.Backspace && keyInfo.Key != ConsoleKey.Enter)
                {
                    pass += keyInfo.KeyChar;
                    Console.Write("*");
                }
                else
                {
                    if (keyInfo.Key == ConsoleKey.Backspace && pass.Length > 0)
                    {
                        pass = pass.Substring(0, (pass.Length - 1));
                        Console.Write("\b \b");
                    }
                    else if (keyInfo.Key == ConsoleKey.Enter)
                    {
                        break;
                    }
                }
            } while (true);

            return pass;
        }


        public static void EncryptSubFolders(string[] folder, string password)
        {
            foreach (string file in folder)
            {
                FileAttributes attr = File.GetAttributes(file);
                if (attr == FileAttributes.Directory)
                {
                    string[] filesAndSubDirectories = Directory.GetFileSystemEntries(file);
                    if (filesAndSubDirectories.Length > 0)
                        EncryptSubFolders(filesAndSubDirectories, password);
                }
                else
                {
                    Console.WriteLine(string.Format("{0} | Result:{1}", file, AES.EncryptFile(file, file, password)));
                }
            }
        }

        public static void DecryptSubFolders(string[] folder, string password)
        {
            foreach (string file in folder)
            {
                FileAttributes attr = File.GetAttributes(file);
                if (attr == FileAttributes.Directory)
                {
                    string[] filesAndSubDirectories = Directory.GetFileSystemEntries(file);
                    if (filesAndSubDirectories.Length > 0)
                        DecryptSubFolders(filesAndSubDirectories, password);
                }
                else
                {
                    Console.WriteLine(string.Format("{0} | Result:{1}", file, AES.DecryptFile(file, file, password)));
                }
            }
        }

        private static string ReadLines(string fileName, bool fromTop, int count)
        {
            var lines = File.ReadAllLines(fileName);
            if (fromTop)
            {
                return string.Join(Environment.NewLine, lines.Take(count));
            }

            return string.Join(Environment.NewLine, lines.Reverse().Take(count));
        }


        private static string ReadBytes(string fileName, bool fromTop, int count)
        {
            var bytes = File.ReadAllBytes(fileName);
            if (fromTop)
            {
                return System.Text.ASCIIEncoding.ASCII.GetString(bytes, 0, count);
            }

            return System.Text.ASCIIEncoding.Default.GetString(bytes, bytes.Length - count, count);
        }
        
        private static Tuple<string, string> MakeError()
        {
            return Tuple.Create("\0", "\0");
        }
    }
}