using System;
using System.IO;
using System.Linq;
using System.Text;
using CommandLine;
using Encrypto.AESLibrary;

namespace Encrypto
{
    class Program
    {
        static void Main(string[] args)
        {
              var result = CommandLine.Parser.Default.ParseArguments<EncryptOptions, DecryptOptions>(args);

            result.MapResult(
                (EncryptOptions options) =>
                {
                    if (Directory.Exists(options.InputFile)) // Directory
                    {
                        Console.WriteLine("Encryption Started...");
                        string[] filesAndSubDirectories = Directory.GetFileSystemEntries(options.InputFile);
                        Console.WriteLine("Password:");
                        string pass = Console.ReadLine();
                        Console.WriteLine(string.Format("Password:{0}",pass));
                        EncryptSubFolders(filesAndSubDirectories, pass);
                        Console.WriteLine("Encryption Finished...");
                    }
                    else if (File.Exists(options.InputFile)) //File Only
                    {
                        Console.WriteLine("Encryption Started...");
                        Console.WriteLine("Password:");
                        string pass = Console.ReadLine();
                        Console.WriteLine(string.Format("Password:{0}",pass));
                        Console.WriteLine(string.Format("{0} | Result:{1}", options.InputFile,
                            AES.EncryptFile(options.InputFile, options.InputFile, pass)));
                        Console.WriteLine("Encryption Finished...");
                    }
                    else
                    {
                        Console.WriteLine("Invalid Path");
                    }

                    return 0;
                },
                (DecryptOptions options) =>
                {
                    if (Directory.Exists(options.InputFile)) // Directory
                    {
                        Console.WriteLine("Decryption Started...");
                        Console.WriteLine("Password:");
                        string pass = Console.ReadLine();
                        Console.WriteLine(string.Format("Password:{0}",pass));
                        string[] filesAndSubDirectories = Directory.GetFileSystemEntries(options.InputFile);
                        DecryptSubFolders(filesAndSubDirectories, pass);
                        Console.WriteLine("Decryption Finished...");
                    }
                    else if (File.Exists(options.InputFile)) //File Only
                    {
                        Console.WriteLine("Encryption Started...");
                        Console.WriteLine("Password:");
                        string pass = Console.ReadLine();
                        Console.WriteLine(string.Format("Password:{0}",pass));
                        Console.WriteLine(string.Format("{0} | Result:{1}", options.InputFile,
                            AES.DecryptFile(options.InputFile, options.InputFile, pass)));
                        Console.WriteLine("Encryption Finished...");
                    }
                    else
                    {
                        Console.WriteLine("Invalid Path");
                    }

                    return 0;
                },
                errors =>
                {
                    var invalidTokens = errors.Where(x => x is TokenError).ToList();
                    if (invalidTokens != null)
                    {
                        invalidTokens.ForEach(token => Console.WriteLine(((TokenError) token).Token));
                    }

                    return 1;
                });

            Console.WriteLine("Application Finished...");
            Console.WriteLine("Press any key to exit...");
            Console.ReadKey();
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
                return Encoding.UTF8.GetString(bytes, 0, count);
            }

            return Encoding.UTF8.GetString(bytes, bytes.Length - count, count);
        }

        private static Tuple<string, string> MakeError()
        {
            return Tuple.Create("\0", "\0");
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
    }
}
