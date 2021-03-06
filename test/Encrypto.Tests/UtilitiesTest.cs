using System.Text;
using Encrypto.AESLibrary;
using Encrypto.Utils;
using NUnit.Framework;

namespace Encrypto.Test
{
    public class UtilitiesTest
    {
        [Test]
        public void Base64Encoding()
        {
            string result = "dGVzdA==";
            string text = "test";
            byte[] textToByteArray = ASCIIEncoding.ASCII.GetBytes(text);
            string base64 = Utilities.Base64Encode(textToByteArray);
            Assert.AreEqual(result, base64);
        }
        [Test]
        public void Base64Decoding()
        {
            string result = "dGVzdA==";
            string text = "test";
            byte[] textToByteArray = Utilities.Base64Decode(result);
            string decodedString = ASCIIEncoding.ASCII.GetString(textToByteArray);
            Assert.AreEqual(text, decodedString);
        }

        [Test]
        public void IsBase64_Valid()
        {
            string base64 = "dGVzdA==";
            bool result = AES.isValidBase64(base64);
            Assert.IsTrue(result);
        }
    }
}