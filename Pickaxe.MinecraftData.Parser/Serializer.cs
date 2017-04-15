using Newtonsoft.Json;

namespace Pickaxe.MinecraftData.Parser
{
    internal static class Serializer
    {
        private static readonly JsonSerializerSettings _settings;

        static Serializer()
        {
            _settings = new JsonSerializerSettings
            {
                Converters =
                {
                    new MinecraftVersionConverter()
                }
            };
        }

        internal static T Deserialize<T>(string input)
        {
            return JsonConvert.DeserializeObject<T>(input, _settings);
        }
    }
}