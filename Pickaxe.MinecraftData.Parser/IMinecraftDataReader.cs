using System.Collections.Generic;
using System.Threading.Tasks;

namespace Pickaxe.MinecraftData.Parser
{
    public interface IMinecraftDataReader
    {
        Task<IEnumerable<MinecraftVersion>> GetVersionsForPlatformAsync(MinecraftPlatform minecraftPlatform);
    }
}