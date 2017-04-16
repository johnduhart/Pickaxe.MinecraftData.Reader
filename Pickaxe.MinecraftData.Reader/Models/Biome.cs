using System.Collections.Generic;
using System.Reflection;

namespace Pickaxe.MinecraftData.Reader
{
    public class Biome
    {
        /// <summary>
        /// The unique identifier for a biome
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// The color in a biome
        /// </summary>
        public int Color { get; set; }

        /// <summary>
        /// The name of a biome
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// How much rain there is in a biome
        /// </summary>
        public float Rainfall { get; set; }

        /// <summary>
        /// An indicator for the temperature in a biome
        /// </summary>
        public float Temperature { get; set; }
    }

    public class Block
    {
        /// <summary>
        /// The unique identifier for a block
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// The display name of a block
        /// </summary>
        public string DisplayName { get; set; }

        /// <summary>
        /// The name of a block
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Hardness of a block
        /// </summary>
        public float? Hardness { get; set; }

        /// <summary>
        /// Stack size for a block
        /// </summary>
        public int StackSize { get; set; }

        /// <summary>
        /// <c>true</c> if a block is diggable
        /// </summary>
        public bool Diggable { get; set; }

        /// <summary>
        /// BoundingBox of a block
        /// </summary>
        public BoundingBox BoundingBox { get; set; }

        /// <summary>
        /// Material of a block
        /// </summary>
        public string Material { get; set; }

        /// <summary>
        /// Using one of these tools is required to harvest a block, without that you get a 3.33x time penalty.
        /// </summary>
        public IDictionary<int, bool> HarvestTools { get; set; }

        
        public ICollection<BlockVariation> Variations { get; set; }
        public ICollection<BlockDrop> Drops { get; set; }

        /// <summary>
        /// <c>true</c> if a block is transparent
        /// </summary>
        public bool Transparent { get; set; }

        /// <summary>
        /// Amount of light emitted by this block
        /// </summary>
        public int EmitLight { get; set; }

        /// <summary>
        /// Amount of light filtered by this block
        /// </summary>
        public int FilterLight { get; set; }
    }

    public class BlockDrop
    {
        public float? MinCount { get; set; }
        public float? MaxCount { get; set; }
        public ItemReference Drop { get; set; }
    }

    // TODO: TypeConverter?
    public class BlockVariation
    {
        public int Metadata { get; set; }
        public string DisplayName { get; set; }
    }

    /// <summary>
    /// Used by <see cref="BlockDrop"/> to reference a specific variation for a block
    /// </summary>
    public class ItemReference
    {
        public int Id { get; set; }
        public int? Metadata { get; set; } 
    }

    public enum BoundingBox
    {
        Block,
        Empty
    }

    public class Effect
    {
        /// <summary>
        /// The unique identifier for an effect
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// The display name of an effect
        /// </summary>
        public string DisplayName { get; set; }

        /// <summary>
        /// The name of an effect
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Whether an effect is positive or negative
        /// </summary>
        public EffectType Type { get; set; }
    }

    public enum EffectType
    {
        Good,
        Bad
    }

    public class Enchantment
    {
        /// <summary>
        /// The unique identifier for an enchantment
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// The display name of an enchantment
        /// </summary>
        public string DisplayName { get; set; }

        /// <summary>
        /// The name of an enchantment
        /// </summary>
        public string Name { get; set; }
    }

    public class Entity
    {
        /// <summary>
        /// The unique identifier for an entity
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// The internal id of an entity : used in eggs metadata for example
        /// </summary>
        public int InternalId { get; set; }

        /// <summary>
        /// The display name of an entity
        /// </summary>
        public string DisplayName { get; set; }

        /// <summary>
        /// The name of an entity
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// The type of an entity
        /// </summary>
        public string Type { get; set; }

        /// <summary>
        /// The width of the entity
        /// </summary>
        public float? Width { get; set; }

        /// <summary>
        /// The height of the entity
        /// </summary>
        public float? Height { get; set; }

        /// <summary>
        /// The category of an entity : a semantic category
        /// </summary>
        public string Category { get; set; }
    }

    public class Instrument
    {
        /// <summary>
        /// The unique identifier for an instrument
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// The name of an instrument
        /// </summary>
        public string Name { get; set; }
    }

    public class Item
    {
        /// <summary>
        /// The unique identifier for an item
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// The display name of an item
        /// </summary>
        public string DisplayName { get; set; }

        /// <summary>
        /// Stack size for an item
        /// </summary>
        public int StackSize { get; set; }

        /// <summary>
        /// The name of an item
        /// </summary>
        public string Name { get; set; }

        public ICollection<ItemVariation> Variations { get; set; }
    }

    public class ItemVariation
    {
        public int Metadata { get; set; }
        public string DisplayName { get; set; }
    }
}