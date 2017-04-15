using System;
using System.IO;
using System.Linq;
using Pickaxe.MinecraftData.Parser.Exceptions;
using Pickaxe.MinecraftData.Parser.Tests.Helpers;
using Xunit;

namespace Pickaxe.MinecraftData.Parser.Tests
{
    public class DataFolderHelperTests
    {
        [Fact]
        public void GetDataFolder_WhenGivenNullPath_ThrowsException()
        {
            Assert.Throws<ArgumentNullException>(() => DataFolderHelper.GetDataFolder(null));
        }

        [Fact]
        public void GetDataFolder_WhenGivenInvalidPath_ThrowsException()
        {
            string path = Path.GetDirectoryName(TestDataLocator.GetMinecraftDataPath());

            Assert.Throws<InvalidDataPathException>(() => DataFolderHelper.GetDataFolder(path));
        }

        [Fact]
        public void GetDataFolder_WhenGivenRepoPath_ReturnsDataFolderPath()
        {
            string path = TestDataLocator.GetMinecraftDataPath();

            string resultPath = DataFolderHelper.GetDataFolder(path);

            Assert.Equal("data", resultPath.Split(Path.DirectorySeparatorChar).Last());
        }

        [Fact]
        public void GetDataFolder_WhenGivenDataFolderPath_ReturnsDataFolderPath()
        {
            string path = Path.Combine(TestDataLocator.GetMinecraftDataPath(), "data");

            string resultPath = DataFolderHelper.GetDataFolder(path);

            Assert.Equal(path, resultPath);
        }
    }
}