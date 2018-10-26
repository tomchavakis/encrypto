using System;

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

    }
}
