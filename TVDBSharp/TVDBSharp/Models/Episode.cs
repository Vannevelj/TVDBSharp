using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using TVDBSharp.Models.Deserialization;

namespace TVDBSharp.Models
{
    /// <summary>
    ///     Entity describing an episode of a <see cref="Show" />show.
    /// </summary>
    public class Episode
    {
        /// <summary>
        ///     Unique identifier for an episode.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        ///     Directors for the episode.
        /// </summary>
        public List<string> Directors { get; set; }

        /// <summary>
        ///     This episode's title.
        /// </summary>
        public string EpisodeName { get; set; }

        /// <summary>
        ///     This episode's number in the appropriate season.
        /// </summary>
        public int AiredEpisodeNumber { get; set; }

        /// <summary>
        ///     This episode's season.
        /// </summary>
        public int AiredSeason { get; set; }

        /// <summary>
        ///     The date of the first time this episode has aired.
        /// </summary>
        public DateTime? FirstAired { get; set; }

        /// <summary>
        ///     A list of guest stars.
        /// </summary>
        public List<string> GuestStars { get; set; }

        /// <summary>
        ///     Unique identifier on IMDb.
        /// </summary>
        public string ImdbId { get; set; }

        /// <summary>
        ///     A short description of the episode.
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
        ///     Writers(s) of the episode.
        /// </summary>
        public List<string> Writers { get; set; }

        /// <summary>
        ///     Let me know if you find out what this is.
        /// </summary>
        [JsonProperty("filename")]
        [JsonConverter(typeof(BannerConverter))]
        public Uri EpisodeImage { get; set; }

        /// <summary>
        ///     Timestamp of the last update to this episode.
        /// </summary>
        public long? LastUpdated { get; set; }

        /// <summary>
        ///     Unique identifier of the season.
        /// </summary>
        public int AiredSeasonId { get; set; }

        /// <summary>
        ///     Unique identifier of the show.
        /// </summary>
        public int SeriesId { get; set; }

        /// <summary>
        ///     Height dimension of the thumbnail in pixels.
        /// </summary>
        public int? ThumbHeight { get; set; }

        /// <summary>
        ///     Width dimension of the thumbnail in pixels;
        /// </summary>
        public int? ThumbWidth { get; set; }

        /// <summary>
        /// Absolute episode number
        /// </summary>
        public int? AbsoluteNumber { get; set; }
    }
}