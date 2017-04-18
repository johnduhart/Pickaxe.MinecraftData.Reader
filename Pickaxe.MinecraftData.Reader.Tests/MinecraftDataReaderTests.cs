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

        [Fact]
        public async Task GetDefinitionForVersionAsnyc_GivenVersion_ReturnsBiomes()
        {
            var sut = new MinecraftDataReader(TestDataLocator.GetMinecraftDataPath());

            var result = await sut.GetDefinitionForVersionAsnyc(MinecraftPlatform.Pc, new MinecraftVersion("1.9.2"));

            Assert.NotEmpty(result.Biomes);

            // Check one that its not empty
            Biome biome = result.Biomes.Skip(3).First();

            AssertEx.GreaterThan(0, biome.Id, "Biome ID should be greater than zero");
            AssertEx.GreaterThan(0, biome.Color, "Biome color should be greater than zero");
            AssertEx.NotNullOrEmpty(biome.Name);
        }
    }

    internal class AssertEx
    {
        public static void GreaterThan(int minimum, int actual)
        {
            Assert.True(actual > minimum);
        }
        public static void GreaterThan(int minimum, int actual, string message)
        {
            Assert.True(actual > minimum, message);
        }

        public static void NotNullOrEmpty(string input)
        {
            Assert.False(string.IsNullOrEmpty(input));
        }
    }
}