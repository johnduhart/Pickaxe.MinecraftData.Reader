using System.Collections.Generic;
using Newtonsoft.Json;

namespace Pickaxe.MinecraftData.Parser
{
    public class DataPaths
    {
        [JsonProperty("pc")]
        public IDictionary<MinecraftVersion, VersionFiles> PcVersions { get; set; }

        [JsonProperty("pe")]
        public IDictionary<MinecraftVersion, VersionFiles> PocketVersions { get; set; }
    }
}