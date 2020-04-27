using Newtonsoft.Json;
using System;

namespace TVDBSharp.Models.Deserialization
{
    public class WeekdayConverter : JsonConverter
    {
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer) => throw new NotImplementedException();

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            var value = (string)reader.Value;

            if (Enum.TryParse<Enums.DayOfWeek>(value, out var dayOfWeek))
            {
                return dayOfWeek;
            }

            return null;
        }

        public override bool CanConvert(Type objectType) => objectType == typeof(Enums.DayOfWeek?);
    }
}
