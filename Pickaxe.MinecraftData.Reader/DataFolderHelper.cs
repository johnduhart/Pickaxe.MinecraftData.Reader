using System;
using System.IO;
using Pickaxe.MinecraftData.Reader.Exceptions;

namespace Pickaxe.MinecraftData.Reader
{
    internal static class PathConstants
    {
        public const string DataFolder = "data";

        public const string DataPaths = "dataPaths.json";

        public const string Biomes = "biomes.json";
        public const string Blocks = "blocks.json";
    }

    internal static class DataFolderHelper
    {
        // TODO: Caching
        internal static string GetDataFolder(string path)
        {
            if (path == null)
                throw new ArgumentNullException(nameof(path));

            string originalPath = path;

            if (!Path.IsPathRooted(path))
                path = Path.GetFullPath(path);

            // Case A: Provided a path to the data folder inside the repo
            if (File.Exists(Path.Combine(path, PathConstants.DataPaths)))
            {
                // Return as-is
                return path;
            }

            // Case B: Provided a path to the root of the repository
            string datasubFolder = Path.Combine(path, PathConstants.DataFolder);
            if (Directory.Exists(datasubFolder))
            {
                if (File.Exists(Path.Combine(datasubFolder, PathConstants.DataPaths)))
                {
                    return datasubFolder;
                }
            }

            throw new InvalidDataPathException($"The path provided ({originalPath}) does not point to a valid data folder");
        }
    }
}