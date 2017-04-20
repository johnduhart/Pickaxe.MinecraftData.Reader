namespace Pickaxe.MinecraftData.Reader
{
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
}