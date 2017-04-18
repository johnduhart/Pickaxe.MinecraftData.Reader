using System.Collections.Generic;
using System.Threading.Tasks;

namespace Pickaxe.MinecraftData.Reader
{
    public interface IMinecraftDataReader
    {
        Task<IEnumerable<MinecraftVersion>> GetVersionsForPlatformAsync(MinecraftPlatform minecraftPlatform);

        Task<MinecraftVersion> GetLatestVersionForPlatformAsync(MinecraftPlatform minecraftPlatform);

        /// <summary>
        /// Returns information about the minecraft version and patform specified
        /// </summary>
        /// <param name="minecraftPlatform">The Minecraft platform.</param>
        /// <param name="version">The desired version.</param>
        /// <returns>Definitions for the request version/platform</returns>
        Task<VersionDefinition> GetDefinitionForVersionAsnyc(MinecraftPlatform minecraftPlatform,
            MinecraftVersion version);
    }


}