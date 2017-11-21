using System.IO;
using System.Security.Cryptography;
using System.Text;

namespace YmlTransform.Tests
{
    internal static class Utils
    {
        internal static string GetFileHash(string filename)
        {
            using (var hash = new SHA1Managed())
            {
                var clearBytes = File.ReadAllBytes(filename);
                var hashedBytes = hash.ComputeHash(clearBytes);

                return ConvertBytesToHex(hashedBytes);
            }
        }

        private static string ConvertBytesToHex(byte[] bytes)
        {
            var sb = new StringBuilder();

            for (var i = 0; i < bytes.Length; i++)
            {
                sb.Append(bytes[i].ToString("x"));
            }

            return sb.ToString();
        }
    }
}