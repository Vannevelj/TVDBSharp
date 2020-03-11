using Newtonsoft.Json;
using System;
using TVDBSharp.Models.Enums;

namespace TVDBSharp.Models.Deserialization
{
    /// <summary>
    ///     Translates the incoming string to a <see cref="ContentRating" /> enum, if applicable.
    /// </summary>
    /// <param name="rating">The rating in string format.</param>
    /// <returns>Returns the appropriate <see cref="ContentRating" /> value.</returns>
    public class ContentRatingConverter : JsonConverter
    {
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer) => throw new NotImplementedException();

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            var value = (string)reader.Value;

            switch (value)
            {
                case "TV-14":
                    return ContentRating.TV14;

                case "TV-PG":
                    return ContentRating.TVPG;

                case "TV-Y":
                    return ContentRating.TVY;

                case "TV-Y7":
                    return ContentRating.TVY7;

                case "TV-G":
                    return ContentRating.TVG;

                case "TV-MA":
                    return ContentRating.TVMA;

                default:
                    return ContentRating.Unknown;
            }
        }

        public override bool CanConvert(Type objectType) => objectType == typeof(ContentRating);
    }
}
