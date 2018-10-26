using NUnit.Framework;
using Encrypto.Utils;
using System.Text;
namespace Tests
{
    public class UtilitiesTest
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Base64Encoding()
        {
            string result = "dGVzdA==";

            string text = "test";
            byte[] textToByteArray = ASCIIEncoding.ASCII.GetBytes(text);
            string base64 = Utilities.Base64Encode(textToByteArray);

            Assert.AreEqual(result,base64);
        }
    }
}