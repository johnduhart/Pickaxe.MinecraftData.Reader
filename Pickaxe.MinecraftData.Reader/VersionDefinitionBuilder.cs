using System.Collections.Generic;
using System.IO;

namespace Pickaxe.MinecraftData.Reader
{
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