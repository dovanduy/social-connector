namespace App.Common.Helpers
{
    using System;
    using System.Collections.Generic;
    using System.Security.Cryptography;
    using System.Text;

    public class EncodeHelper
    {
        public static string EncodePassword(string password)
        {
            if (string.IsNullOrWhiteSpace(password))
            {
                return string.Empty;
            }

            return EncodeHelper.Md5Encode(password);
        }

        public static string Md5Encode(string input)
        {
            MD5 md5 = System.Security.Cryptography.MD5.Create();
            byte[] inputBytes = System.Text.Encoding.ASCII.GetBytes(input);
            byte[] hashBytes = md5.ComputeHash(inputBytes);

            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < hashBytes.Length; i++)
            {
                sb.Append(hashBytes[i].ToString("X2"));
            }

            return sb.ToString();
        }

        public static string GenerateRandomString(int length)
        {
            Random random = new Random();
            Dictionary<int, StringBuilder> stringBuilders = new Dictionary<int, StringBuilder>();
            string seedCharacters = "0123456789ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz";

            StringBuilder result;
            if (!stringBuilders.TryGetValue(length, out result))
            {
                result = new StringBuilder();
                stringBuilders[length] = result;
            }

            result.Clear();

            for (int i = 0; i < length; i++)
            {
                result.Append(seedCharacters[random.Next(seedCharacters.Length)]);
            }

            return result.ToString();
        }
    }
}