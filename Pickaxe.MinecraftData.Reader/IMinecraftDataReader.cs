using System.Collections.Generic;
using System.Threading.Tasks;

namespace Pickaxe.MinecraftData.Reader
{
    public interface IMinecraftDataReader
    {
        Task<IEnumerable<MinecraftVersion>> GetVersionsForPlatformAsync(MinecraftPlatform minecraftPlatform);

        Task<MinecraftVersion> GetLatestVersionForPlayformAsync(MinecraftPlatform minecraftPlatform);

        //Task<>
    }


}