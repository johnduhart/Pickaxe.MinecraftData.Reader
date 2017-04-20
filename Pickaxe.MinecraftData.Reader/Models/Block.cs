using System.Collections.Generic;

namespace Pickaxe.MinecraftData.Reader
{
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
}