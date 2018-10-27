using System;
using System.IO;
using System.Linq;
using CommandLine;
using Encrypto.AESLibrary;
using Encrypto.Utils;

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
                        string pass =  Utilities.CreateSecurePassword();
                        Utilities.EncryptSubFolders(filesAndSubDirectories, pass);
                        Console.WriteLine("Encryption Finished...");
                    }
                    else if (File.Exists(options.InputFile)) //File Only
                    {
                        Console.WriteLine("Encryption Started...");
                        Console.WriteLine("Password:");
                        string pass =  Utilities.CreateSecurePassword();
                        Console.WriteLine(string.Format("{0} | Result:{1}", options.InputFile,
                            AES.EncryptFile(options.InputFile, options.InputFile, pass)));
                        Console.WriteLine("Encryption Finished...");
                    }
                    else if (!string.IsNullOrEmpty(options.InputText))
                    {
                        Console.WriteLine("Encryption Started...");
                        Console.WriteLine("Password:");
                        string pass =  Utilities.CreateSecurePassword();                        
                        Console.WriteLine(string.Format("{1}{0}-->{1}{2}", options.InputText, Environment.NewLine, Utilities.Base64Encode(AES.EncryptText(options.InputText, pass))));
                        Console.WriteLine("Encryption Finished...");
                    }
                    else
                    {
                        if (string.IsNullOrEmpty(options.InputFile) || string.IsNullOrEmpty(options.InputText))
                        {
                            Console.WriteLine("ERROR(S):");
                            Console.WriteLine("-i\tInput File(s) or Folder(s) to encrypt.");
                            Console.WriteLine("-t\tInsert the text to encrypt.");
                        }
                    }

                    return 0;
                },
                (DecryptOptions options) =>
                {
                    if (Directory.Exists(options.InputFile)) // Directory
                    {
                        Console.WriteLine("Decryption Started...");
                        Console.WriteLine("Password:");
                        string pass =  Utilities.CreateSecurePassword();
                        string[] filesAndSubDirectories = Directory.GetFileSystemEntries(options.InputFile);
                        Utilities.DecryptSubFolders(filesAndSubDirectories, pass);
                        Console.WriteLine("Decryption Finished...");
                    }
                    else if (File.Exists(options.InputFile)) //File Only
                    {
                        Console.WriteLine("Decryption Started...");
                        Console.WriteLine("Password:");
                        string pass =  Utilities.CreateSecurePassword();
                        Console.WriteLine(string.Format("{0} | Result:{1}", options.InputFile,
                            AES.DecryptFile(options.InputFile, options.InputFile, pass)));
                        Console.WriteLine("Decryption Finished...");
                    }
                    else if (!string.IsNullOrEmpty(options.InputText))
                    {
                        Console.WriteLine("Decryption Started...");
                        Console.WriteLine("Password:");
                        string pass =  Utilities.CreateSecurePassword();
                        byte[] base64Decode = Utilities.Base64Decode(options.InputText);
                        Console.WriteLine(string.Format("{0}-->{1}{2}", options.InputText, Environment.NewLine, AES.DecryptText(base64Decode, pass)));
                        Console.WriteLine("Decryption Finished...");
                    }
                    else
                    {
                        if (string.IsNullOrEmpty(options.InputFile) || string.IsNullOrEmpty(options.InputText))
                        {
                            Console.WriteLine("-i\tInput File(s) or Folder(s) to decrypt.");
                            Console.WriteLine("-t\tInsert the text to decrypt.");
                        }
                    }

                    return 0;
                },
                errors =>
                {
                    var invalidTokens = errors.Where(x => x is TokenError).ToList();
                    invalidTokens.ForEach(token => Console.WriteLine(((TokenError)token).Token));

                    return 1;
                });
        }

        

      

        
    }
}
