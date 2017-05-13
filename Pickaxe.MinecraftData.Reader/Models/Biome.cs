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
        public decimal Rainfall { get; set; }

        /// <summary>
        /// An indicator for the temperature in a biome
        /// </summary>
        public decimal Temperature { get; set; }
    }
}