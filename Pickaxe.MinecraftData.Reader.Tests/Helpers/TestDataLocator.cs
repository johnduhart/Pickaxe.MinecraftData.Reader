using System;
using System.IO;

namespace Pickaxe.MinecraftData.Reader.Tests.Helpers
{
    internal static class TestDataLocator
    {
        private static string _minecraftDataPath;

        public static string GetMinecraftDataPath()
        {
            if (_minecraftDataPath != null)
                return _minecraftDataPath;

            string currentDirectory = Directory.GetCurrentDirectory();
            string root = Path.GetPathRoot(currentDirectory);

            while (currentDirectory != root)
            {
                // Check to see if minecraft-data is in this folder
                if (Directory.Exists(Path.Combine(currentDirectory, "minecraft-data")))
                {
                    _minecraftDataPath = Path.Combine(currentDirectory, "minecraft-data");
                    return _minecraftDataPath;
                }

                currentDirectory = Path.GetDirectoryName(currentDirectory);
            }

            throw new Exception("Could not find the minecraft-data folder.");
        }
    }
}