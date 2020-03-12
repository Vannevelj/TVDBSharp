using Newtonsoft.Json;
using System;

namespace TVDBSharp.Models.Deserialization
{
    public class EpochConverter : JsonConverter
    {
        private static readonly DateTime Epoch = new DateTime(1970, 1, 1);

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer) => throw new NotImplementedException();

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            var value = (long)reader.Value;
            return Epoch.AddSeconds(value);
        }

        public override bool CanConvert(Type objectType) => objectType == typeof(string);
    }
}
