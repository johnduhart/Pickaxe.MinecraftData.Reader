using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Linq.Expressions;
using System.Net.Http.Headers;
using System.Reflection;
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
            var dataPaths = await ReadDataPaths();
            var versions = dataPaths.GetVersionsForPlatform(minecraftPlatform);

            return versions.Keys.ToList();
        }

        public Task<MinecraftVersion> GetLatestVersionForPlatformAsync(MinecraftPlatform minecraftPlatform)
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

        /// <inheritdoc />
        public async Task<VersionDefinition> GetDefinitionForVersionAsnyc(MinecraftPlatform minecraftPlatform, MinecraftVersion version)
        {
            // Read in information from the paths file.
            // Load version definition

            var dataPaths = await ReadDataPaths();
            var versions = dataPaths.GetVersionsForPlatform(minecraftPlatform);

            VersionFiles files;
            if (!versions.TryGetValue(version, out files))
            {
                // TODO: What should we do here?
                throw new ArgumentException("Given version does not exist");
            }

            var versionDefinition = VersionDefinitionBuilder.Build(_dataPath, files);

            return versionDefinition;
        }

        private async Task<DataPaths> ReadDataPaths()
        {
            string dataJsonPath = Path.Combine(_dataPath, PathConstants.DataPaths);
            string jsonContents;
            using (var stream = new StreamReader(File.OpenRead(dataJsonPath)))
            {
                jsonContents = await stream.ReadToEndAsync().ConfigureAwait(false);
            }

            var dataPaths = Serializer.Deserialize<DataPaths>(jsonContents);
            return dataPaths;
        }
    }

    internal class VersionDefinitionBuilder
    {
        private readonly VersionDefinition _definition = new VersionDefinition();
        private readonly string _dataPath;
        private readonly VersionFiles _files;

        private VersionDefinitionBuilder(string dataPath, VersionFiles files)
        {
            _dataPath = dataPath;
            _files = files;
        }

        internal static VersionDefinition Build(string dataPath, VersionFiles files)
        {
            var builder = new VersionDefinitionBuilder(dataPath, files);
            return builder.Build();
        }

        private VersionDefinition Build()
        {
            ReadSimpleDefinitions();

            return _definition;
        }

        private void ReadSimpleDefinitions()
        {
            // TODO: Make this more generic..

            string biomePath = Path.Combine(_dataPath, _files.Biomes, PathConstants.Biomes);
            if (File.Exists(biomePath))
            {
                _definition.Biomes = Serializer.ReadFile<IEnumerable<Biome>>(biomePath);
            }

            string blocksPath = Path.Combine(_dataPath, _files.Blocks, PathConstants.Blocks);
            if (File.Exists(blocksPath))
            {
                _definition.Blocks = Serializer.ReadFile<IEnumerable<Block>>(blocksPath);
            }

            string effectsPath = Path.Combine(_dataPath, _files.Effects, PathConstants.Effects);
            if (File.Exists(effectsPath))
            {
                _definition.Effects = Serializer.ReadFile<IEnumerable<Effect>>(effectsPath);
            }

            string enchanmentsPath = Path.Combine(_dataPath, _files.Enchantments, PathConstants.Enchantments);
            if (File.Exists(enchanmentsPath))
            {
                _definition.Enchantments = Serializer.ReadFile<IEnumerable<Enchantment>>(enchanmentsPath);
            }

            string entityPath = Path.Combine(_dataPath, _files.Entities, PathConstants.Entities);
            if (File.Exists(entityPath))
            {
                _definition.Entities = Serializer.ReadFile<IEnumerable<Entity>>(entityPath);
            }

            string instrumentPath = Path.Combine(_dataPath, _files.Instruments, PathConstants.Instruments);
            if (File.Exists(instrumentPath))
            {
                _definition.Instruments = Serializer.ReadFile<IEnumerable<Instrument>>(instrumentPath);
            }

            string itemsPath = Path.Combine(_dataPath, _files.Items, PathConstants.Items);
            if (File.Exists(itemsPath))
            {
                _definition.Items = Serializer.ReadFile<IEnumerable<Item>>(itemsPath);
            }

            string versionPath = Path.Combine(_dataPath, _files.Version, PathConstants.Version);
            if (File.Exists(versionPath))
            {
                _definition.VersionInfo = Serializer.ReadFile<VersionInfo>(versionPath);
            }
        }
    }
}