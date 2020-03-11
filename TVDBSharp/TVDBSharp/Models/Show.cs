using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using TVDBSharp.Models.Deserialization;
using TVDBSharp.Models.Enums;

namespace TVDBSharp.Models
{
    /// <summary>
    ///     Entity describing a show.
    /// </summary>
    public class Show
    {
        /// <summary>
        ///     Unique identifier used by IMDb.
        /// </summary>
        public string ImdbId { get; set; }

        /// <summary>
        ///     Unique identifier used by TVDB and TVDBSharp.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        ///     Day of the week when the show airs.
        /// </summary>
        public DayOfWeek? AirsDayOfWeek { get; set; }

        /// <summary>
        ///     Time of the day when the show airs.
        /// </summary>
        [JsonConverter(typeof(TimeConverter))]
        public TimeSpan? AirsTime { get; set; }

        /// <summary>
        ///     Rating of the content provided by an official organ.
        /// </summary>
        [JsonConverter(typeof(ContentRatingConverter))]
        public ContentRating Rating { get; set; }

        /// <summary>
        ///     The date the show aired for the first time.
        /// </summary>
        public DateTime? FirstAired { get; set; }

        /// <summary>
        ///     A list of genres the show is associated with.
        /// </summary>
        public List<string> Genre { get; set; }

        /// <summary>
        ///     Main language of the show.
        /// </summary>
        public string Language { get; set; }

        /// <summary>
        ///     Network that broadcasts the show.
        /// </summary>
        public string Network { get; set; }

        /// <summary>
        ///     A short overview of the show.
        /// </summary>
        public string Overview { get; set; }

        /// <summary>
        ///     Average rating as shown on IMDb.
        /// </summary>
        public double? SiteRating { get; set; }

        /// <summary>
        ///     Amount of votes cast.
        /// </summary>
        public int SiteRatingCount { get; set; }

        /// <summary>
        ///     Let me know if you find out what this is.
        /// </summary>
        public int? Runtime { get; set; }

        /// <summary>
        ///     Name of the show.
        /// </summary>
        public string SeriesName { get; set; }

        /// <summary>
        ///     Current status of the show.
        /// </summary>
        public Status Status { get; set; }

        /// <summary>
        ///     Link to the banner image.
        /// </summary>
        [JsonConverter(typeof(BannerConverter))]
        public Uri Banner { get; set; }

        /// <summary>
        ///     Link to a fanart image.
        /// </summary>
        [JsonConverter(typeof(BannerConverter))]
        public Uri Fanart { get; set; }

        /// <summary>
        ///     Timestamp of the latest update.
        /// </summary>
        public long? LastUpdated { get; set; }

        /// <summary>
        ///     Let me know if you find out what this is.
        /// </summary>
        [JsonConverter(typeof(BannerConverter))]
        public Uri Poster { get; set; }

        /// <summary>
        ///     No clue
        /// </summary>
        public string Zap2ItID { get; set; }
    }
}