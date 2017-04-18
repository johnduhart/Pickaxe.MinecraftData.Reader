using System.Collections.Generic;

namespace Pickaxe.MinecraftData.Reader
{
    public class VersionDefinition
    {
        public IEnumerable<Block> Blocks { get; set; }

        public IEnumerable<Biome> Biomes { get; set; }

        public IEnumerable<Enchantment> Enchantments { get; set; }
        public IEnumerable<Effect> Effects { get; set; }
        public IEnumerable<Item> Items { get; set; }
        public IEnumerable<Instrument> Instruments { get; set; }

        public IEnumerable<Entity> Entities { get; set; }
        public VersionInfo VersionInfo { get; set; }
    }

    public class VersionInfo
    {
        // Should these be Minecraft versions?? :/

        public string MinecraftVersion { get; set; }
        public int Version { get; set; }
        public string MajorVersion { get; set; }
    }
}