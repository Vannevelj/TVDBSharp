using Newtonsoft.Json;
using System;

namespace TVDBSharp.Models.Deserialization
{
    public class BannerConverter : JsonConverter
    {
        private const string UriPrefix = "http://thetvdb.com/banners/";

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer) => throw new NotImplementedException();
       
        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            var value = (string) reader.Value;
            return new Uri(UriPrefix + value, UriKind.Absolute);
        }

        public override bool CanConvert(Type objectType) => objectType == typeof(string);
    }
}
