using System;
using System.Security.Cryptography;
using System.Text;

namespace DVTManagementSystem.Services
{
    public class PasswordHashing
    {

        private string salt = "ThisisMyDefaultSaltWithSomeSpicesAndHerbs";
        public string HashInput(string input)
        {

            byte[] hash;
            using (var sha1CryptoServiceProvider = new SHA1CryptoServiceProvider())
            {
                hash = sha1CryptoServiceProvider.ComputeHash(Encoding.Unicode.GetBytes(input + salt));
            }
            var stringBuilder = new StringBuilder();

            foreach (byte b in hash) stringBuilder.AppendFormat("{0:x2}", b);
            {
                return stringBuilder.ToString();
            }
        }

        internal string HashInput(object passwordHash)
        {
            throw new NotImplementedException();
        }
    }
}