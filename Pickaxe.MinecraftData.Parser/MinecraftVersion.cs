using System;
using System.ComponentModel;
using Newtonsoft.Json;

namespace Pickaxe.MinecraftData.Parser
{
    [TypeConverter(typeof(MinecraftVersionTypeConverter))]
    public struct MinecraftVersion : IEquatable<MinecraftVersion>
    {
        public static readonly MinecraftVersion Default = new MinecraftVersion();

        public string VersionString { get; }

        [JsonConstructor]
        public MinecraftVersion(string versionString)
        {
            if (string.IsNullOrWhiteSpace(versionString))
                throw new ArgumentException("Value cannot be null or whitespace.", nameof(versionString));

            VersionString = versionString;
        }

        public override int GetHashCode()
        {
            return VersionString != null ? VersionString.GetHashCode() : 0;
        }

        public bool Equals(MinecraftVersion other)
        {
            return string.Equals((string) VersionString, (string) other.VersionString);
        }

        public override bool Equals(object obj)
        {
            if (Object.ReferenceEquals(null, obj)) return false;
            return obj is MinecraftVersion && Equals((MinecraftVersion) obj);
        }

        public static bool operator ==(MinecraftVersion left, MinecraftVersion right)
        {
            return left.Equals(right);
        }

        public static bool operator !=(MinecraftVersion left, MinecraftVersion right)
        {
            return !left.Equals(right);
        }

        //public static explicit String 
    }
}