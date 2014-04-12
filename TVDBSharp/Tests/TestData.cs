using System;
using System.Collections.Generic;
using System.Globalization;
using System.Threading;
using Tests.Models;
using TVDBSharp.Models.Enums;

namespace Tests
{
    /// <summary>
    ///     Provides mocking data to construct the XML tree and validate the parsed objects.
    /// </summary>
    public class TestData
    {
        private readonly Dictionary<Conversion, Conversion> _showData = new Dictionary<Conversion, Conversion>();

        private readonly List<Dictionary<Conversion, Conversion>> _episodeData =
            new List<Dictionary<Conversion, Conversion>>();

        // Using en-US culture to prevent errors when comparing doubles (comma vs dot).
        static TestData()
        {
            Thread.CurrentThread.CurrentCulture = new CultureInfo("en-US");
        }

        /// <summary>
        ///     Used to create an XML tree where the XML element names are represented
        ///     by the key-XML value and the XML values are represented by the value-XML value.
        ///     After using the TVDB builders: check if the resulting object's properties
        ///     (key-Object value) has the same values as the value-Object value.
        ///     Key-Object value and value-Object value refer to
        ///     respectively the dictionary's key and the corresponding value.
        /// </summary>
        public TestData()
        {
            AddShowData();
            AddEpisodeData();
        }

        private void AddShowData()
        {
            #region ShowData

            _showData.Add(new Conversion("id", "ID"), new Conversion("76290", "76290"));
            _showData.Add(new Conversion("IMDB_ID", "ImdbID"), new Conversion("tt0285331", "tt0285331"));
            _showData.Add(new Conversion("Language", "Language"), new Conversion("en", "en"));
            _showData.Add(new Conversion("Actors", "Actors"),
                new Conversion("|Kiefer Sutherland|Carlos Bernard|Mary Lynn Rajskub|",
                    new List<String>(new[] {"Kiefer Sutherland", "Carlos Bernard", "Mary Lynn Rajskub"}).ToString()));
            _showData.Add(new Conversion("Airs_DayOfWeek", "AirDay"), new Conversion("Monday", "Monday"));
            _showData.Add(new Conversion("Airs_Time", "AirTime"),
                new Conversion("9:00 PM", new TimeSpan(21, 0, 0).ToString()));
            _showData.Add(new Conversion("ContentRating", "ContentRating"),
                new Conversion("TV-14", ContentRating.TV14.ToString()));
            _showData.Add(new Conversion("FirstAired", "FirstAired"),
                new Conversion("2001-11-06", new DateTime(2001, 11, 06).ToString()));
            _showData.Add(new Conversion("Genre", "Genres"),
                new Conversion("|Action|Adventure|Drama|",
                    new List<String>(new[] {"Action", "Adventure", "Drama"}).ToString()));
            _showData.Add(new Conversion("Network", "Network"), new Conversion("FOX", "FOX"));
            _showData.Add(new Conversion("Overview", "Description"),
                new Conversion("24 is a TV thriller presented in real time.",
                    "24 is a TV thriller presented in real time."));
            _showData.Add(new Conversion("Rating", "Rating"), new Conversion("8.9", "8.9"));
            _showData.Add(new Conversion("RatingCount", "RatingCount"), new Conversion("371", "371"));
            _showData.Add(new Conversion("Runtime", "Runtime"), new Conversion("60", "60"));
            _showData.Add(new Conversion("SeriesName", "Name"), new Conversion("24", "24"));
            _showData.Add(new Conversion("Status", "Status"), new Conversion("Ended", Status.Ended.ToString()));
            _showData.Add(new Conversion("banner", "Banner"),
                new Conversion("graphical/76290-g14.jpg", "graphical/76290-g14.jpg"));
            _showData.Add(new Conversion("fanart", "Fanart"),
                new Conversion("fanart/original/76290-23.jpg", "fanart/original/76290-23.jpg"));
            _showData.Add(new Conversion("lastupdated", "LastUpdated"), new Conversion("1378608881", "1378608881"));
            _showData.Add(new Conversion("poster", "Poster"),
                new Conversion("posters/76290-4.jpg", "posters/76290-4.jpg"));
            _showData.Add(new Conversion("zap2it_id", "Zap2ItID"), new Conversion("SH00446604", "SH00446604"));

            #endregion ShowData
        }

        private void AddEpisodeData()
        {
            #region FirstEpisode

            var newEpisode = new Dictionary<Conversion, Conversion>();
            newEpisode.Add(new Conversion("id", "ID"), new Conversion("189258", "189258"));
            newEpisode.Add(new Conversion("Director", "Director"), new Conversion("Winrich Kolbe", "Winrich Kolbe"));
            newEpisode.Add(new Conversion("EpisodeName", "Title"),
                new Conversion("3:00 A.M.-4:00 A.M.", "3:00 A.M.-4:00 A.M."));
            newEpisode.Add(new Conversion("EpisodeNumber", "EpisodeNumber"), new Conversion("4", "4"));
            newEpisode.Add(new Conversion("FirstAired", "FirstAired"),
                new Conversion("2001-11-27", new DateTime(2001, 11, 27).ToString()));
            newEpisode.Add(new Conversion("GuestStars", "GuestStars"),
                new Conversion("|Johnny Vasquez| Mike Siegal| Kathy Byron|",
                    new List<String>(new[] {"Johnny Vasquez", "Mike Siegal", "Kathy Byron"}).ToString()));
            newEpisode.Add(new Conversion("IMDB_ID", "ImdbID"), new Conversion("tt1091252", "tt1091252"));
            newEpisode.Add(new Conversion("Language", "Language"), new Conversion("en", "en"));
            newEpisode.Add(new Conversion("Overview", "Description"),
                new Conversion("With Tony in custody, Jack leads his interrogation",
                    "With Tony in custody, Jack leads his interrogation"));
            newEpisode.Add(new Conversion("Rating", "Rating"), new Conversion("7.6", "7.6"));
            newEpisode.Add(new Conversion("RatingCount", "RatingCount"), new Conversion("57", "57"));
            newEpisode.Add(new Conversion("SeasonNumber", "SeasonNumber"), new Conversion("7", "7"));
            newEpisode.Add(new Conversion("Writer", "Writers"),
                new Conversion("Manny Coto | Brannon Braga",
                    new List<string>(new[] {"Manny Coto", "Brannon Braga"}).ToString()));
            newEpisode.Add(new Conversion("filename", "FileName"),
                new Conversion("episodes/76290/409267.jpg", "episodes/76290/409267.jpg"));
            newEpisode.Add(new Conversion("lastupdated", "LastUpdated"), new Conversion("1360269400", "1360269400"));
            newEpisode.Add(new Conversion("seasonid", "SeasonID"), new Conversion("35831", "35831"));
            newEpisode.Add(new Conversion("seriesid", "SeriesID"), new Conversion("76290", "76290"));
            newEpisode.Add(new Conversion("thumb_height", "ThumbHeight"), new Conversion("225", "225"));
            newEpisode.Add(new Conversion("thumb_width", "ThumbWidth"), new Conversion("400", "400"));
            newEpisode.Add(new Conversion("tms_export", "TmsExport"), new Conversion("1374789754", "1374789754"));
            _episodeData.Add(newEpisode);

            #endregion FirstEpisode

            #region SecondEpisode

            newEpisode = new Dictionary<Conversion, Conversion>();
            newEpisode.Add(new Conversion("id", "ID"), new Conversion("1482791", "1482791"));
            newEpisode.Add(new Conversion("Director", "Director"),
                new Conversion("Nelson McCormick", "Nelson McCormick"));
            newEpisode.Add(new Conversion("EpisodeName", "Title"),
                new Conversion("Day 8: 3:00 A.M. - 4:00 A.M.", "Day 8: 3:00 A.M. - 4:00 A.M."));
            newEpisode.Add(new Conversion("EpisodeNumber", "EpisodeNumber"), new Conversion("12", "12"));
            newEpisode.Add(new Conversion("FirstAired", "FirstAired"),
                new Conversion("2010-03-14", new DateTime(2010, 03, 14).ToString()));
            newEpisode.Add(new Conversion("GuestStars", "GuestStars"),
                new Conversion("|Kiefer Sutherland|Annie Wersching|Mary Lynn Rajskub|",
                    new List<String>(new[] {"Kiefer Sutherland", "Annie Wersching", "Mary Lynn Rajskub"}).ToString()));
            newEpisode.Add(new Conversion("IMDB_ID", "ImdbID"), new Conversion("tt1463812", "tt1463812"));
            newEpisode.Add(new Conversion("Language", "Language"), new Conversion("en", "en"));
            newEpisode.Add(new Conversion("Overview", "Description"),
                new Conversion(
                    "While Jack and Cole team up in the field to shield New York from the calamitous threat",
                    "While Jack and Cole team up in the field to shield New York from the calamitous threat"));
            newEpisode.Add(new Conversion("Rating", "Rating"), new Conversion("8.0", "8"));
            newEpisode.Add(new Conversion("RatingCount", "RatingCount"), new Conversion("106", "106"));
            newEpisode.Add(new Conversion("SeasonNumber", "SeasonNumber"), new Conversion("8", "8"));
            newEpisode.Add(new Conversion("Writer", "Writers"),
                new Conversion("Chip Johannessen|Patrick Harbinson",
                    new List<string>(new[] {"Chip Johannessen", "Patrick Harbinson"}).ToString()));
            newEpisode.Add(new Conversion("filename", "FileName"),
                new Conversion("episodes/76290/1482791.jpg", "episodes/76290/1482791.jpg"));
            newEpisode.Add(new Conversion("lastupdated", "LastUpdated"), new Conversion("1360269825", "1360269825"));
            newEpisode.Add(new Conversion("seasonid", "SeasonID"), new Conversion("83471", "83471"));
            newEpisode.Add(new Conversion("seriesid", "SeriesID"), new Conversion("76290", "76290"));
            newEpisode.Add(new Conversion("thumb_height", "ThumbHeight"), new Conversion("225", "225"));
            newEpisode.Add(new Conversion("thumb_width", "ThumbWidth"), new Conversion("400", "400"));
            newEpisode.Add(new Conversion("tms_export", "TmsExport"), new Conversion("1374789754", "1374789754"));
            _episodeData.Add(newEpisode);

            #endregion SecondEpisode
        }

        /// <summary>
        ///     Returns the dictionary with show data.
        /// </summary>
        /// <returns>Show data.</returns>
        public Dictionary<Conversion, Conversion> GetShowData()
        {
            return _showData;
        }

        /// <summary>
        ///     Returns the dictionary with episode data.
        /// </summary>
        /// <returns>Episode data.</returns>
        public List<Dictionary<Conversion, Conversion>> GetEpisodeData()
        {
            return _episodeData;
        }
    }
}