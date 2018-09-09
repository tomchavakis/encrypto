using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;
using System.Threading;

namespace Encrypto.AESLibrary
{
    public class AES
    {
          public static byte[] GetEncryptedByteArray(byte[] bytesencrypted, byte[] password)
        {
            byte[] encyptedbytes = null;

            //the salt bytes must be at least 8 bytes
            byte[] saltBytes = new byte[] { 1, 2, 3, 4, 5, 6, 7, 8 };
            using (MemoryStream ms = new MemoryStream())
            {
                using (RijndaelManaged AES = new RijndaelManaged())
                {
                    AES.KeySize = 256;
                    AES.BlockSize = 128;
                    var key = new Rfc2898DeriveBytes(password, saltBytes, 1000);
                    AES.Key = key.GetBytes(AES.KeySize / 8);
                    AES.IV = key.GetBytes(AES.BlockSize / 8);

                    AES.Mode = CipherMode.CBC;
                    using (var cs = new CryptoStream(ms, AES.CreateEncryptor(), CryptoStreamMode.Write))
                    {
                        cs.Write(bytesencrypted, 0, bytesencrypted.Length);
                        cs.Close();
                    }
                    encyptedbytes = ms.ToArray();
                }
                return encyptedbytes;
            }
        }
        
        public static byte[] GetDecryptedByteArray(byte[] bytesDecrypted, byte[] password)
        {
            byte[] decryptedbytes = null;


            byte[] saltBytes = new byte[] { 1, 2, 3, 4, 5, 6, 7, 8 };
            using (MemoryStream ms = new MemoryStream())
            {
                using (RijndaelManaged AES = new RijndaelManaged())
                {
                    AES.KeySize = 256;
                    AES.BlockSize = 128;
                    var key = new Rfc2898DeriveBytes(password, saltBytes, 1000);
                    AES.Key = key.GetBytes(AES.KeySize / 8);
                    AES.IV = key.GetBytes(AES.BlockSize / 8);

                    AES.Mode = CipherMode.CBC;
                    using (var cs = new CryptoStream(ms, AES.CreateDecryptor(), CryptoStreamMode.Write))
                    {
                        cs.Write(bytesDecrypted, 0, bytesDecrypted.Length);
                        cs.Close();

                    }
                    decryptedbytes = ms.ToArray();
                }

            }
            return decryptedbytes;
        }

        public static string EncryptFile(string inputFile, string outputFile, string password)
        {
            ReaderWriterLockSlim locker = new ReaderWriterLockSlim();

            try
            {
                locker.EnterReadLock();

                byte[] bytestoencrypted = File.ReadAllBytes(inputFile);
                byte[] passwordToByteArray = Encoding.UTF8.GetBytes(password);

                //hash the password with sha256
                passwordToByteArray = SHA256.Create().ComputeHash(passwordToByteArray);

                byte[] encryptedByteArray = AES.GetEncryptedByteArray(bytestoencrypted, passwordToByteArray);

                File.WriteAllBytes(outputFile, encryptedByteArray);
                return "encryption succeeded";

            }
            catch (Exception ex)
            {
                return "encryption failed";
            }
            finally
            {
                locker.ExitReadLock();
            }
        }

        public static string DecryptFile(string inputFile, string outputFile, string password)
        {
            ReaderWriterLockSlim locker = new ReaderWriterLockSlim();

            try
            {
                locker.EnterReadLock();

                byte[] bytesToBeDecrypted = File.ReadAllBytes(outputFile);
                byte[] passwordBytes = Encoding.UTF8.GetBytes(password);
                passwordBytes = SHA256.Create().ComputeHash(passwordBytes);

                byte[] bytesDecrypted = AES.GetDecryptedByteArray(bytesToBeDecrypted, passwordBytes);

                File.WriteAllBytes(outputFile, bytesDecrypted);
                return "Decryption succeeded";
            }
            catch (Exception e)
            {
                return "Decryption failed";
            }
            finally
            {
                locker.ExitReadLock();
            }
        }
    }
}
