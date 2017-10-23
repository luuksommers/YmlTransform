using System.IO;
using System.Security.Cryptography;
using System.Text;
using Xunit;

namespace YmlTransform.Tests
{
    public class YmlTransformerTests
    {
        [Fact]
        public void TestMultiLanguageTranformation()
        {
            const string originalFile = @"Data\\Multi-Language.yml";
            const string expectedFile = @"Data\\Multi-Language.ymlexpected";


            YmlTransformer.TransformFile(originalFile, "Data\\Multi-Language.ymltransform");

            var originalHash = GetFileHash(originalFile);
            var expectedHash = GetFileHash(expectedFile);

            Assert.Equal(expectedHash, originalHash);
        }

        public string GetFileHash(string filename)
        {
            var hash = new SHA1Managed();
            var clearBytes = File.ReadAllBytes(filename);
            var hashedBytes = hash.ComputeHash(clearBytes);
            return ConvertBytesToHex(hashedBytes);
        }

        public string ConvertBytesToHex(byte[] bytes)
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
