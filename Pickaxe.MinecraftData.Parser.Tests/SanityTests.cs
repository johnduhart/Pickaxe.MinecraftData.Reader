using Pickaxe.MinecraftData.Parser.Tests.Helpers;
using Xunit;

namespace Pickaxe.MinecraftData.Parser.Tests
{
    public class SanityTests
    {
        [Fact]
        public void MinecraftDataExists()
        {
            string path = TestDataLocator.GetMinecraftDataPath();

            Assert.NotNull(path);
        }
    }
}
