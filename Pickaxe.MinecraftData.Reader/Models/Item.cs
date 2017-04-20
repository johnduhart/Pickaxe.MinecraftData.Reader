using System.Collections.Generic;

namespace Pickaxe.MinecraftData.Reader
{
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
}