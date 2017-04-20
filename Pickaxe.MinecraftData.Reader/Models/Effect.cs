namespace Pickaxe.MinecraftData.Reader
{
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
}