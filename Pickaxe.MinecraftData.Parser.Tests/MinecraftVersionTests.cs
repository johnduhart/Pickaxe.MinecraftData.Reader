using System;
using Newtonsoft.Json;
using Xunit;

namespace Pickaxe.MinecraftData.Parser.Tests
{
    public class MinecraftVersionTests
    {
        [Theory]
        [InlineData(null)]
        [InlineData("")]
        [InlineData("   ")]
        public void Ctor_GivenInvalidVersion_ThrowsException(string version)
        {
            Assert.Throws<ArgumentException>(() => new MinecraftVersion(version));
        }

        [Fact]
        public void JsonNet_DeserializesProperly()
        {
            var result = Serializer.Deserialize<MinecraftVersion>("\"1.2.3\"");

            Assert.Equal("1.2.3", result.VersionString);
        }

        [Fact]
        public void Equals_ReturnsTrueForEqualVersions()
        {
            var versionA = new Version("1.2.3");
            var versionB = new Version("1.2.3");

            Assert.StrictEqual(versionA, versionB);
        }

        [Fact]
        public void Equals_ReturnsFalseForUnequalVersions()
        {
            var versionA = new Version("1.2.3");
            var versionB = new Version("1.2.4");

            Assert.NotStrictEqual(versionA, versionB);
        }
    }
}