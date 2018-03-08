using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;
using System.Threading;
using Xunit;
using YmlTransform.Exceptions;

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

            var originalHash = Utils.GetFileHash(originalFile);
            var expectedHash = Utils.GetFileHash(expectedFile);

            Assert.Equal(expectedHash, originalHash);
        }

        [Fact]
        public void TestUnversionedTransformation()
        {
            const string originalFile = @"Data\\Unversioned.yml";
            const string expectedFile = @"Data\\Unversioned.ymlexpected";

            YmlTransformer.TransformFile(originalFile, "Data\\Unversioned.ymltransform");

            var originalHash = Utils.GetFileHash(originalFile);
            var expectedHash = Utils.GetFileHash(expectedFile);

            Console.WriteLine(originalHash, expectedHash);

            Assert.Equal(expectedHash, originalHash);
        }

        [Fact]
        public void TestExceptionThrownOnIncompleteTransform()
        {
            const string originalFile = @"Data\\MissingTransformation.yml";

            Assert.Throws<IncompleteTransformationException>(() => YmlTransformer.TransformFile(originalFile, "Data\\MissingTransformation.ymltransform"));
        }
    }
}
