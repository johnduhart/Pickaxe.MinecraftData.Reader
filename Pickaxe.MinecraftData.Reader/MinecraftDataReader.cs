using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

namespace Pickaxe.MinecraftData.Reader
{
    public class MinecraftDataReader : IMinecraftDataReader
    {
        private readonly string _dataPath;

        public MinecraftDataReader(string dataPath)
        {
            if (dataPath == null) throw new ArgumentNullException(nameof(dataPath));

            _dataPath = DataFolderHelper.GetDataFolder(dataPath);
        }

        public async Task<IEnumerable<MinecraftVersion>> GetVersionsForPlatformAsync(MinecraftPlatform minecraftPlatform)
        {
            string dataJsonPath = Path.Combine(_dataPath, PathConstants.DataPaths);
            string jsonContents;
            using (var stream = new StreamReader(File.OpenRead(dataJsonPath)))
            {
                jsonContents = await stream.ReadToEndAsync().ConfigureAwait(false);
            }

            var dataPaths = Serializer.Deserialize<DataPaths>(jsonContents);

            // Returning straight .Keys here may not be completely safe...
            switch (minecraftPlatform)
            {
                case MinecraftPlatform.Pc:
                    return dataPaths.PcVersions.Keys;
                case MinecraftPlatform.PocketEdition:
                    return dataPaths.PocketVersions.Keys;
                default:
                    throw new ArgumentOutOfRangeException(nameof(minecraftPlatform), minecraftPlatform, null);
            }
        }

        public Task<MinecraftVersion> GetLatestVersionForPlayformAsync(MinecraftPlatform minecraftPlatform)
        {
            switch (minecraftPlatform)
            {
                case MinecraftPlatform.Pc:
                    return Task.FromResult(new MinecraftVersion("1.11.2"));
                case MinecraftPlatform.PocketEdition:
                    return Task.FromResult(new MinecraftVersion("1.0"));
                default:
                    throw new ArgumentOutOfRangeException(nameof(minecraftPlatform), minecraftPlatform, null);
            }
        }
    }
}