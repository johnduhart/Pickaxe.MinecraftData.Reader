namespace Pickaxe.MinecraftData.Reader
{
    /// <summary>
    /// Used by <see cref="BlockDrop"/> to reference a specific variation for a block
    /// </summary>
    public class ItemReference
    {
        public int Id { get; set; }
        public int? Metadata { get; set; }
    }
}