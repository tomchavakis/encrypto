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

        public string GetEncryptedPassword()
        {
            if (!_encryptOptions.AskPass && string.IsNullOrEmpty(_encryptOptions.Password))
            {
                Console.WriteLine("ERROR(S):");
                Console.WriteLine("-p\t Password is Required");
                return string.Empty;
            }

            string pass = string.Empty;

            if (_encryptOptions.AskPass)
            {
                Console.WriteLine("Password:");
                pass = Utilities.CreateSecurePassword();
                System.Console.WriteLine("\n");
            }
            else
            {
                pass = _encryptOptions.Password;
            }
            return pass;
        }

        public string GetDecryptedPassword()
        {
            if (!_decryptOptions.AskPass && string.IsNullOrEmpty(_decryptOptions.Password))
            {
                Console.WriteLine("ERROR(S):");
                Console.WriteLine("-p\t Password is Required");
                return string.Empty;
            }

            string pass = string.Empty;

            if (_decryptOptions.AskPass)
            {
                Console.WriteLine("Password:");
                pass = Utilities.CreateSecurePassword();
                System.Console.WriteLine("\n");
            }
            else
            {
                pass = _decryptOptions.Password;
            }
            return pass;
        }

        public void EncryptDirectories()
        {
            string[] filesAndSubDirectories = Directory.GetFileSystemEntries(_encryptOptions.InputFile);
            string pass = GetEncryptedPassword();
            if (!string.IsNullOrEmpty(pass))
                Utilities.EncryptSubFolders(filesAndSubDirectories, pass);
        }

        public void EncryptFile()
        {
            string pass = GetEncryptedPassword();
            if (!string.IsNullOrEmpty(pass))
                Console.WriteLine(string.Format("{0} | Result:{1}", _encryptOptions.InputFile, AES.EncryptFile(_encryptOptions.InputFile, _encryptOptions.OutputFile, pass, _encryptOptions.Base64Output, _encryptOptions.LocalOutput)));
        }

        public void EncryptText()
        {
            string pass = GetEncryptedPassword();
            if (!string.IsNullOrEmpty(pass))
                Console.WriteLine(Utilities.Base64Encode(AES.EncryptText(_encryptOptions.InputText, pass)));
        }

        public void DecryptDirectories()
        {
            string pass = GetDecryptedPassword();
            if (!string.IsNullOrEmpty(pass))
            {
                string[] filesAndSubDirectories = Directory.GetFileSystemEntries(_decryptOptions.InputFile);
                Utilities.DecryptSubFolders(filesAndSubDirectories, pass);
            }
        }

        public void DecryptFile()
        {
            string pass = GetDecryptedPassword();
            if (!string.IsNullOrEmpty(pass))
            {
                Console.WriteLine(string.Format("{0} | Result:{1}", _decryptOptions.InputFile, AES.DecryptFile(_decryptOptions.InputFile, _decryptOptions.OutputFile, pass, _decryptOptions.Base64Output)));
            }
        }

        public void DecryptText()
        {
            if (!AES.isValidBase64(_decryptOptions.InputText))
            {
                System.Console.WriteLine("Error: Invalid base64");
            }
            else
            {
                string pass = GetDecryptedPassword();
                if (!string.IsNullOrEmpty(pass))
                {
                    byte[] base64Decode = Utilities.Base64Decode(_decryptOptions.InputText);
                    Console.WriteLine(AES.DecryptText(base64Decode, pass));
                }
            }


        }
    }
}