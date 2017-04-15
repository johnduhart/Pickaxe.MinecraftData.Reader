using System;
using Newtonsoft.Json;

namespace Pickaxe.MinecraftData.Parser
{
    internal class MinecraftVersionConverter : JsonConverter
    {
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            throw new NotImplementedException();
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            if (reader.TokenType == JsonToken.Null)
                return MinecraftVersion.Default;

            if (reader.TokenType != JsonToken.String)
                throw new JsonSerializationException($"Unexpected token or value when parsing minecraft version. Token: {reader.TokenType}, Value: {reader.Value}");

            return new MinecraftVersion((string) reader.Value);
        }

        public override bool CanConvert(Type objectType)
        {
            return objectType == typeof(MinecraftVersion);
        }
    }
}