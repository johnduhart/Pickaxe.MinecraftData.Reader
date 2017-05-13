using System;
using System.Linq;
using System.Threading.Tasks;
using FluentAssertions;
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
            VersionDefinition result = await GetDefinitionsForVersion();

            Assert.NotEmpty(result.Biomes);

            // Test against the Jungle Biome
            Biome biome = result.Biomes.First(b => b.Id == 21);

            Assert.Equal(21, biome.Id);
            Assert.Equal(5470985, biome.Color);
            Assert.Equal("Jungle", biome.Name);
            Assert.Equal(0.9m, biome.Rainfall);
            Assert.Equal(1.2m, biome.Temperature);
        }

        [Fact]
        public async Task GetDefinitionForVersionAsnyc_GivenVersion_ReturnsBlocks()
        {
            VersionDefinition result = await GetDefinitionsForVersion();

            Assert.NotEmpty(result.Blocks);

            // Test against the Wood Planks
            Block block = result.Blocks.First(b => b.Id == 5);

            Assert.Equal(5, block.Id);
            Assert.Equal("Wood Planks", block.DisplayName);
            Assert.Equal("planks", block.Name);
            Assert.Equal(2, block.Hardness);
            Assert.Equal(64, block.StackSize);
            Assert.True(block.Diggable);
            Assert.Equal(BoundingBox.Block, block.BoundingBox);
            Assert.Equal("wood", block.Material);
            Assert.False(block.Transparent);
            Assert.Equal(0, block.EmitLight);
            Assert.Equal(15, block.FilterLight);

            block.Variations.Should().HaveCount(c => c >= 6);
            BlockVariation variation = block.Variations.First();

            Assert.Equal(0, variation.Metadata);
            Assert.Equal("Oak Wood Planks", variation.DisplayName);
        }

        [Fact]
        public async Task GetDefinitionForVersionAsnyc_GivenVersion_ReturnsBlocksWithComplexProperties()
        {
            VersionDefinition result = await GetDefinitionsForVersion();

            Assert.NotEmpty(result.Blocks);

            // Test against the Lapis Lazuli Ore
            Block block = result.Blocks.First(b => b.Id == 21);

            Assert.Equal(21, block.Id);
            Assert.NotEmpty(block.HarvestTools);

            BlockDrop drop = block.Drops.First();

            Assert.Equal(4, drop.MinCount);
            Assert.Equal(8, drop.MaxCount);
            Assert.Equal(351, drop.Drop.Id);
            Assert.Equal(4, drop.Drop.Metadata);
        }

        [Fact]
        public async Task GetDefinitionForVersionAsnyc_GivenVersion_ReturnsBlocksWithSimpleItemReference()
        {
            VersionDefinition result = await GetDefinitionsForVersion();

            Assert.NotEmpty(result.Blocks);

            // Test against the Lapis Lazuli Block
            Block block = result.Blocks.First(b => b.Id == 22);

            Assert.Equal(22, block.Id);
            Assert.NotEmpty(block.Drops);

            BlockDrop drop = block.Drops.First();

            Assert.Equal(22, drop.Drop.Id);
        }

        [Fact]
        public async Task GetDefinitionForVersionAsnyc_GivenVersion_ReturnsEnchantments()
        {
            VersionDefinition result = await GetDefinitionsForVersion();

            Assert.NotEmpty(result.Enchantments);

            // Test against Feather Falling
            Enchantment enchantment = result.Enchantments.First(e => e.Id == 2);

            Assert.Equal(2, enchantment.Id);
            Assert.Equal("feather_falling", enchantment.Name);
            Assert.Equal("Feather Falling", enchantment.DisplayName);
        }

        [Fact]
        public async Task GetDefinitionForVersionAsnyc_GivenVersion_ReturnsEffects()
        {
            VersionDefinition result = await GetDefinitionsForVersion();

            Assert.NotEmpty(result.Effects);

            // Test against Mining Fatigue
            Effect effect = result.Effects.First(e => e.Id == 4);

            Assert.Equal(4, effect.Id);
            Assert.Equal("MiningFatigue", effect.Name);
            Assert.Equal("Mining Fatigue", effect.DisplayName);
            Assert.Equal(EffectType.Bad, effect.Type);
        }

        [Fact]
        public async Task GetDefinitionForVersionAsnyc_GivenVersion_ReturnsItems()
        {
            VersionDefinition result = await GetDefinitionsForVersion();

            Assert.NotEmpty(result.Items);

            // Test against Coal
            Item item = result.Items.First(i => i.Id == 263);

            Assert.Equal(263, item.Id);
            Assert.Equal("Coal", item.DisplayName);
            Assert.Equal(64, item.StackSize);
            Assert.Equal("coal", item.Name);
            Assert.NotEmpty(item.Variations);

            ItemVariation variation = item.Variations.First();

            Assert.Equal(0, variation.Metadata);
            Assert.Equal("Coal", variation.DisplayName);
        }

        [Fact]
        public async Task GetDefinitionForVersionAsnyc_GivenVersion_ReturnsInstruments()
        {
            VersionDefinition result = await GetDefinitionsForVersion();

            Assert.NotEmpty(result.Instruments);

            // Test against snareDrum
            Instrument instrument = result.Instruments.First(i => i.Id == 2);

            Assert.Equal(2, instrument.Id);
            Assert.Equal("snareDrum", instrument.Name);
        }

        [Fact]
        public async Task GetDefinitionForVersionAsnyc_GivenVersion_ReturnsEntities()
        {
            VersionDefinition result = await GetDefinitionsForVersion();

            Assert.NotEmpty(result.Entities);

            // Test against Skeleton
            Entity entity = result.Entities.First(e => e.Id == 51);

            Assert.Equal(51, entity.Id);
            Assert.Equal(51, entity.InternalId);
            Assert.Equal("Skeleton", entity.Name);
            Assert.Equal("Skeleton", entity.DisplayName);
            Assert.Equal("mob", entity.Type);
            Assert.Equal((float?) 0.6, entity.Width);
            Assert.Equal((float?) 1.95, entity.Height);
            Assert.Equal("Hostile mobs", entity.Category);

        }

        [Fact]
        public async Task GetDefinitionForVersionAsnyc_GivenVersion_ReturnsVersionInfo()
        {
            VersionDefinition result = await GetDefinitionsForVersion();

            Assert.NotNull(result.VersionInfo);

            VersionInfo version = result.VersionInfo;

            Assert.Equal(109, version.Version);
            Assert.Equal("1.9.2", version.MinecraftVersion);
            Assert.Equal("1.9", version.MajorVersion);
        }

        private static async Task<VersionDefinition> GetDefinitionsForVersion()
        {
            var sut = new MinecraftDataReader(TestDataLocator.GetMinecraftDataPath());

            return await sut.GetDefinitionForVersionAsnyc(MinecraftPlatform.Pc, new MinecraftVersion("1.9.2"));
        }
    }
}