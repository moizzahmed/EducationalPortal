using System.Security.Cryptography;
using System.Text;

namespace EducationalPortal.Helper
{
    public class Hash
    {
        public static string CreateSHA256(string password)
        {
            using (SHA256 sha256 = SHA256.Create())
            {
                // Convert the input string to a byte array and compute the hash
                byte[] bytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(password));

                // Loop through each byte of the hashed data and format each one as a hexadecimal string
                StringBuilder builder = new StringBuilder();
                for (int i = 0; i < bytes.Length; i++)
                {
                    builder.Append(bytes[i].ToString("x2"));
                }

                // Return the hexadecimal string
                return builder.ToString();
            }
        }
    }
}
