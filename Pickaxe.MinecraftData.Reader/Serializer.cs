using System.IO;
using Newtonsoft.Json;

namespace Pickaxe.MinecraftData.Reader
{
    internal static class Serializer
    {
        private static readonly JsonSerializerSettings _settings;
        private static readonly JsonSerializer _serializer;

        static Serializer()
        {
            _settings = new JsonSerializerSettings
            {
                Converters =
                {
                    new MinecraftVersionConverter()
                }
            };

            _serializer = JsonSerializer.CreateDefault(_settings);
        }

        internal static T Deserialize<T>(string input)
        {
            return JsonConvert.DeserializeObject<T>(input, _settings);
        }

        public static T ReadFile<T>(string biomePath)
        {
            // TODO: Arg Check

            using (var reader = new StreamReader(File.OpenRead(biomePath)))
            using (var jsonTextReader = new JsonTextReader(reader))
            {
                return _serializer.Deserialize<T>(jsonTextReader);
            }
        }
    }
}