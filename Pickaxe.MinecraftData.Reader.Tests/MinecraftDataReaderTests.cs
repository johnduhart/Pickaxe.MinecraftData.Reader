using System;
using System.Linq;
using System.Threading.Tasks;
using Pickaxe.MinecraftData.Reader.Tests.Helpers;
using Xunit;

namespace Pickaxe.MinecraftData.Reader.Tests
{
    public class MinecraftDataReaderTests
    {
        [Fact]
        public void Ctor_GivenNullPath_ThrowsException()
        {
            Assert.Throws<ArgumentNullException>(() => new MinecraftDataReader(null));
        }

        [Fact]
        public async Task GetVersionsForPlatformAsync_GivenPcPlatform_ReturnsVersions()
        {
            var sut = new MinecraftDataReader(TestDataLocator.GetMinecraftDataPath());

            var result = (await sut.GetVersionsForPlatformAsync(MinecraftPlatform.Pc)).ToList();

            Assert.NotEmpty(result);
            Assert.Contains(new MinecraftVersion("1.11.2"), result);
        }
    }
}