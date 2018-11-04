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
                    Helpers helpers = new Helpers(options);
                    if (Directory.Exists(options.InputFile)) // Directory
                    {
                        helpers.EncryptDirectories();
                    }
                    else if (File.Exists(options.InputFile)) //File Only
                    {
                        helpers.EncryptFile();
                    }
                    else if (!string.IsNullOrEmpty(options.InputText))
                    {
                        helpers.EncryptText();
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
                    Helpers helpers = new Helpers(options);
                    if (Directory.Exists(options.InputFile)) // Directory
                    {
                        helpers.DecryptDirectories();
                    }
                    else if (File.Exists(options.InputFile)) //File Only
                    {
                        helpers.DecryptFile();
                    }
                    else if (!string.IsNullOrEmpty(options.InputText))
                    {
                        helpers.DecryptText();
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
