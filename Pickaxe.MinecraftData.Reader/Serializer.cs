using System.IO;
using Newtonsoft.Json;

namespace Pickaxe.MinecraftData.Reader
{
    internal static class Serializer
    {
        private static readonly JsonSerializerSettings Settings;
        private static readonly JsonSerializer _serializer;

        static Serializer()
        {
            Settings = new JsonSerializerSettings
            {
                Converters =
                {
                    new MinecraftVersionConverter(),
                    new ItemReferenceJsonConverter()
                }
            };

            _serializer = JsonSerializer.CreateDefault(Settings);
        }

        internal static T Deserialize<T>(string input)
        {
            return JsonConvert.DeserializeObject<T>(input, Settings);
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