using Pickaxe.MinecraftData.Reader.Tests.Helpers;
using Xunit;

namespace Pickaxe.MinecraftData.Reader.Tests
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
