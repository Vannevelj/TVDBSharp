namespace Tests.Models
{
    /// <summary>
    ///     Used to create an original XML representation of an episode.
    /// </summary>
    public class TestEpisode
    {
#pragma warning disable 1591 // Disables XML warnings
        public string id { get; set; }
        public string Director { get; set; }
        public string EpisodeName { get; set; }
        public string EpisodeNumber { get; set; }
        public string FirstAired { get; set; }
        public string GuestStars { get; set; }
        public string IMDB_ID { get; set; }
        public string Language { get; set; }
        public string Overview { get; set; }
        public string Rating { get; set; }
        public string RatingCount { get; set; }
        public string SeasonNumber { get; set; }
        public string Writer { get; set; }
        public string filename { get; set; }
        public string lastupdated { get; set; }
        public string seasonid { get; set; }
        public string seriesid { get; set; }
        public string thumb_height { get; set; }
        public string thumb_width { get; set; }
        public string tms_export { get; set; }
#pragma warning restore 1591 // Enables XML warnings
    }
}