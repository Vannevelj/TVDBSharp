using System.Collections.Generic;
using System.Xml.Serialization;

namespace Tests.Models
{
    /// <summary>
    ///     Used to create an original XML representation of a show.
    /// </summary>
    public class TestShow
    {
#pragma warning disable 1591 // Disables XML warnings
        public string id { get; set; }
        public string Actors { get; set; }
        public string Airs_DayOfWeek { get; set; }
        public string Airs_Time { get; set; }
        public string ContentRating { get; set; }
        public string FirstAired { get; set; }
        public string Genre { get; set; }
        public string IMDB_ID { get; set; }
        public string Language { get; set; }
        public string Network { get; set; }
        public string Overview { get; set; }
        public string Rating { get; set; }
        public string RatingCount { get; set; }
        public string Runtime { get; set; }
        public string SeriesName { get; set; }
        public string Status { get; set; }
        public string banner { get; set; }
        public string fanart { get; set; }
        public string lastupdated { get; set; }
        public string poster { get; set; }
        public string zap2it_id { get; set; }

        [XmlElement("Episode")]
        public List<TestEpisode> Episodes { get; set; }
#pragma warning restore 1591 // Enables XML warnings
    }
}