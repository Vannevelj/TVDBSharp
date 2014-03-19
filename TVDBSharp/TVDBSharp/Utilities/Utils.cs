using System;
using System.Globalization;
using TVDBSharp.Models.Enums;

namespace TVDBSharp.Utilities {
    /// <summary>
    /// Provides static utility methods.
    /// </summary>
    public static class Utils {
        /// <summary>
        /// Parses a string of format yyyy-MM-dd to a <see cref="DateTime"/> object.
        /// </summary>
        /// <param name="value">String to be parsed.</param>
        /// <returns>Returns a <see cref="DateTime"/> representation.</returns>
        public static DateTime ParseDate(string value)
        {
            DateTime date;
            DateTime.TryParseExact(value, "yyyy-MM-dd", CultureInfo.CurrentCulture, DateTimeStyles.AssumeLocal, out date);
            return date;
        }

        /// <summary>
        /// Parses a string of format hh:mm tt to a <see cref="TimeSpan"/> object.
        /// </summary>
        /// <param name="value">String to be parsed.</param>
        /// <returns>Returns a <see cref="TimeSpan"/> representation.</returns>
        public static TimeSpan ParseTime(string value) {
            var hour = Convert.ToInt32(value.Substring(0, value.IndexOf(':')));
            var minute = Convert.ToInt32(value.Substring(value.IndexOf(':') + 1, 2));
            var daypart = value.Substring(value.Length - 2);
            if (daypart == "PM") {
                hour += 12;
            }

            return new TimeSpan(hour, minute, 0);
        }

        /// <summary>
        /// Translates the incoming string to a <see cref="ContentRating"/> enum, if applicable.
        /// </summary>
        /// <param name="rating">The rating in string format.</param>
        /// <returns>Returns the appropriate <see cref="ContentRating"/> value.</returns>
        /// <exception cref="ArgumentException">Throws an exception if no conversion could be applied.</exception>
        public static ContentRating GetContentRating(string rating) {
            switch (rating) {
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
    }
}