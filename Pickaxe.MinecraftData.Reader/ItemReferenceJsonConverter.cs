using System;
using Newtonsoft.Json;

namespace Pickaxe.MinecraftData.Reader
{
    internal class ItemReferenceJsonConverter : JsonConverter
    {
        public override bool CanWrite => false;

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            if (reader.TokenType == JsonToken.Integer)
                return new ItemReference {Id = (int) ((long) reader.Value)};

            if (reader.TokenType == JsonToken.StartObject)
            {
                var reference = new ItemReference();
                serializer.Populate(reader, reference);

                return reference;
            }

            throw new NotImplementedException();
        }

        public override bool CanConvert(Type objectType)
        {
            return objectType == typeof(ItemReference);
        }
    }
}