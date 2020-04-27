using Newtonsoft.Json;
using System;

namespace TVDBSharp.Models.Deserialization
{
    /// <summary>
    ///     Parses a string of format hh:mm tt to a <see cref="TimeSpan" /> object.
    /// </summary>
    /// <param name="value">String to be parsed.</param>
    /// <returns>Returns a <see cref="TimeSpan" /> representation.</returns>
    public class TimeConverter : JsonConverter
    {
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer) => throw new NotImplementedException();

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            var value = (string)reader.Value;

            if (!DateTime.TryParse(value, out var date))
            {
                return new TimeSpan();
            }
            return date.TimeOfDay;
        }

        public override bool CanConvert(Type objectType) => objectType == typeof(TimeSpan?);
    }
}
