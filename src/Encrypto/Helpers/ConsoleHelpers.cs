using System;
using System.IO;
using Encrypto.AESLibrary;
using Encrypto.Utils;

namespace Encrypto
{
    public class Helpers
    {
        private EncryptOptions _encryptOptions;
        private DecryptOptions _decryptOptions;
        public Helpers(DecryptOptions options)
        {
            _decryptOptions = options;
        }

        public Helpers(EncryptOptions options)
        {
            _encryptOptions = options;
        }

        public void EncryptDirectories()
        {
            Console.WriteLine("Encryption Started...");
            string[] filesAndSubDirectories = Directory.GetFileSystemEntries(_encryptOptions.InputFile);
            Console.WriteLine("Password:");
            string pass = Utilities.CreateSecurePassword();
            Utilities.EncryptSubFolders(filesAndSubDirectories, pass);
            Console.WriteLine("Encryption Finished...");
        }

        public void EncryptFile()
        {
            Console.WriteLine("Encryption Started...");
            Console.WriteLine("Password:");
            string pass = Utilities.CreateSecurePassword();
            Console.WriteLine(string.Format("{0} | Result:{1}", _encryptOptions.InputFile,
                AES.EncryptFile(_encryptOptions.InputFile, _encryptOptions.InputFile, pass)));
            Console.WriteLine("Encryption Finished...");
        }

        public void EncryptText()
        {
            Console.WriteLine("Encryption Started...");
            Console.WriteLine("Password:");
            string pass = Utilities.CreateSecurePassword();
            Console.WriteLine(string.Format("{1}{0}-->{1}{2}", _encryptOptions.InputText, Environment.NewLine, Utilities.Base64Encode(AES.EncryptText(_encryptOptions.InputText, pass))));
            Console.WriteLine("Encryption Finished...");
        }

        public void DecryptDirectories()
        {
            Console.WriteLine("Decryption Started...");
            Console.WriteLine("Password:");
            string pass = Utilities.CreateSecurePassword();
            string[] filesAndSubDirectories = Directory.GetFileSystemEntries(_decryptOptions.InputFile);
            Utilities.DecryptSubFolders(filesAndSubDirectories, pass);
            Console.WriteLine("Decryption Finished...");
        }

        public void DecryptFile()
        {
            Console.WriteLine("Decryption Started...");
            Console.WriteLine("Password:");
            string pass = Utilities.CreateSecurePassword();
            Console.WriteLine(string.Format("{0} | Result:{1}", _decryptOptions.InputFile,
                AES.DecryptFile(_decryptOptions.InputFile, _decryptOptions.InputFile, pass)));
            Console.WriteLine("Decryption Finished...");
        }
        public void DecryptText()
        {
            Console.WriteLine("Decryption Started...");
            Console.WriteLine("Password:");
            string pass = Utilities.CreateSecurePassword();
            byte[] base64Decode = Utilities.Base64Decode(_decryptOptions.InputText);
            Console.WriteLine(string.Format("{0}-->{1}{2}", _decryptOptions.InputText, Environment.NewLine, AES.DecryptText(base64Decode, pass)));
            Console.WriteLine("Decryption Finished...");

        }
    }
}