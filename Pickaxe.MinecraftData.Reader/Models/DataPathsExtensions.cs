using System;
using System.Collections.Generic;

namespace Pickaxe.MinecraftData.Reader
{
    public static class DataPathsExtensions
    {
        public static IDictionary<MinecraftVersion, VersionFiles> GetVersionsForPlatform(this DataPaths dataPaths,
            MinecraftPlatform platform)
        {
            if (dataPaths ==  null)
                throw new ArgumentNullException(nameof(dataPaths));

            switch (platform)
            {
                case MinecraftPlatform.Pc:
                    return dataPaths.PcVersions;
                case MinecraftPlatform.PocketEdition:
                    return dataPaths.PocketVersions;
                default:
                    throw new ArgumentOutOfRangeException(nameof(platform), platform, null);
            }
        }
    }
}