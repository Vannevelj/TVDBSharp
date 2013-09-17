using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;
using TVDBSharp.Models.DAO;
using TVDBSharp.Models.Enums;
using TVDBSharp.Utilities;

namespace TVDBSharp.Models {
    /// <summary>
    /// Provides builder classes for complex entities.
    /// </summary>
    public class Builder {
        private readonly IDataProvider _dataProvider;

        /// <summary>
        /// Initializes a new Builder object with the given <see cref="IDataProvider"/>.
        /// </summary>
        /// <param name="dataProvider">The DataProvider used to retrieve XML responses.</param>
        public Builder(IDataProvider dataProvider) {
            _dataProvider = dataProvider;
        }

        /// <summary>
        /// Builds a show object from the given show ID.
        /// </summary>
        /// <param name="showID">ID of the show to serialize into a <see cref="Show"/> object.</param>
        /// <returns>Returns the Show object.</returns>
        public Show BuildShow(string showID) {
            var builder = new ShowBuilder(_dataProvider.GetShow(showID));
            return builder.GetResult();
        }

        /// <summary>
        /// Returns a list of <see cref="Show"/> objects that match the given query.
        /// </summary>
        /// <param name="query">Query the search is performed with.</param>
        /// <param name="results">Maximal amount of shows the resultset should return.</param>
        /// <returns>Returns a list of show objects.</returns>
        public List<Show> Search(string query, int results) {
            var shows = new List<Show>(results);
            var doc = _dataProvider.Search(query);

            foreach (var element in doc.Descendants("Series").Take(results)) {
                var id = element.GetXmlData("seriesid");
                var response = _dataProvider.GetShow(id);
                shows.Add(new ShowBuilder(response).GetResult());
            }

            return shows;
        }

        private class ShowBuilder {
            private Show _show;

            public ShowBuilder(XDocument doc) {
                _show = new Show {
                    ID = doc.GetSeriesData("SeriesID"),
                    ImdbID = doc.GetSeriesData("IMDB_ID"),
                    Name = doc.GetSeriesData("SeriesName"),
                    Language = doc.GetSeriesData("Language"),
                    Network = doc.GetSeriesData("Network"),
                    Description = doc.GetSeriesData("Overview"),
                    Rating = string.IsNullOrWhiteSpace(doc.GetSeriesData("Rating"))
                                 ? (double?) null
                                 : Convert.ToDouble(doc.GetSeriesData("Rating"),
                                                    System.Globalization.CultureInfo.InvariantCulture),
                    RatingCount = string.IsNullOrWhiteSpace(doc.GetSeriesData("RatingCount"))
                                      ? (int?) null
                                      : Convert.ToInt32(doc.GetSeriesData("RatingCount")),
                    Runtime = string.IsNullOrWhiteSpace(doc.GetSeriesData("Runtime"))
                                  ? (int?) null
                                  : Convert.ToInt32(doc.GetSeriesData("Runtime")),
                    Banner = doc.GetSeriesData("banner"),
                    Fanart = doc.GetSeriesData("fanart"),
                    LastUpdated = string.IsNullOrWhiteSpace(doc.GetSeriesData("lastupdated"))
                                      ? 0L
                                      : Convert.ToInt64(doc.GetSeriesData("lastupdated")),
                    Poster = doc.GetSeriesData("poster"),
                    Zap2ItID = doc.GetSeriesData("zap2it_id"),
                    FirstAired = Utils.ParseDate(doc.GetSeriesData("FirstAired")),
                    AirTime = string.IsNullOrWhiteSpace(doc.GetSeriesData("Airs_Time"))
                                  ? (TimeSpan?) null
                                  : Utils.ParseTime(doc.GetSeriesData("Airs_Time")),
                    AirDay = string.IsNullOrWhiteSpace(doc.GetSeriesData("Airs_DayOfWeek"))
                                 ? (DayOfWeek?) null
                                 : (DayOfWeek) Enum.Parse(typeof(DayOfWeek), doc.GetSeriesData("Airs_DayOfWeek")),
                    Status = string.IsNullOrWhiteSpace(doc.GetSeriesData("Status"))
                                 ? (Status?) null
                                 : (Status) Enum.Parse(typeof(Status), doc.GetSeriesData("Status")),
                    ContentRating = Utils.GetContentRating(doc.GetSeriesData("ContentRating")),
                    Genres = new List<string>(doc.GetSeriesData("Genre").Split('|')),
                    Actors = new List<string>(doc.GetSeriesData("Actors").Split('|')),
                    Episodes = new EpisodeBuilder(doc).BuildEpisodes()
                };
            }

            public Show GetResult() {
                return _show;
            }
        }

        private class EpisodeBuilder {
            private XDocument _doc;

            public EpisodeBuilder(XDocument doc) {
                _doc = doc;
            }

            public List<Episode> BuildEpisodes() {
                var result = new List<Episode>();

                foreach (var episode in _doc.Descendants("Episode")) {
                    var ep = new Episode {
                        ID = episode.GetXmlData("id"),
                        Title = episode.GetXmlData("EpisodeName"),
                        Description = episode.GetXmlData("Overview"),
                        EpisodeNumber =
                            string.IsNullOrWhiteSpace(episode.GetXmlData("EpisodeNumber"))
                                ? (int?) null
                                : Convert.ToInt32(episode.GetXmlData("EpisodeNumber")),
                        Director = episode.GetXmlData("Director"),
                        FileName = episode.GetXmlData("filename"),
                        FirstAired =
                            string.IsNullOrWhiteSpace(episode.GetXmlData("FirstAired"))
                                ? (DateTime?) null
                                : Utils.ParseDate(episode.GetXmlData("FirstAired")),
                        GuestStars = new List<string>(episode.GetXmlData("GuestStars").Split('|')),
                        ImdbID = episode.GetXmlData("IMDB_ID"),
                        Language = episode.GetXmlData("Language"),
                        LastUpdated =
                            string.IsNullOrWhiteSpace(episode.GetXmlData("lastupdated"))
                                ? 0L
                                : Convert.ToInt64(episode.GetXmlData("lastupdated")),
                        Rating =
                            string.IsNullOrWhiteSpace(episode.GetXmlData("Rating"))
                                ? (double?) null
                                : Convert.ToDouble(episode.GetXmlData("Rating"),
                                                   System.Globalization.CultureInfo.InvariantCulture),
                        RatingCount =
                            string.IsNullOrWhiteSpace(episode.GetXmlData("RatingCount"))
                                ? (int?) null
                                : Convert.ToInt32(episode.GetXmlData("RatingCount")),
                        SeasonID = episode.GetXmlData("seasonid"),
                        SeasonNumber =
                            string.IsNullOrWhiteSpace(episode.GetXmlData("SeasonNumber"))
                                ? (int?) null
                                : Convert.ToInt32(episode.GetXmlData("SeasonNumber")),
                        SeriesID = episode.GetXmlData("seriesid"),
                        ThumbHeight =
                            string.IsNullOrWhiteSpace(episode.GetXmlData("thumb_height"))
                                ? (int?) null
                                : Convert.ToInt32(episode.GetXmlData("thumb_height")),
                        ThumbWidth =
                            string.IsNullOrWhiteSpace(episode.GetXmlData("thumb_width"))
                                ? (int?) null
                                : Convert.ToInt32(episode.GetXmlData("thumb_width")),
                        TmsExport = episode.GetXmlData("tms_export"),
                        Writers = new List<string>(episode.GetXmlData("Writer").Split('|'))
                    };

                    result.Add(ep);
                }

                return result;
            }
        }
    }
}