using System;
using System.Security.Cryptography;

namespace ConfigSaver
{
    public interface IEncoder
    {
        String Encode(string input);
        string Decode(string input);
    }

    public class Base64Encoder : IEncoder
    {
        public string Decode(string input)
        {
            var base64EncodedBytes = System.Convert.FromBase64String(input);
            return System.Text.Encoding.UTF8.GetString(base64EncodedBytes);
        }

        public string Encode(string input)
        {
            var plainTextBytes = System.Text.Encoding.UTF8.GetBytes(input);
            return System.Convert.ToBase64String(plainTextBytes);
        }
    }


}