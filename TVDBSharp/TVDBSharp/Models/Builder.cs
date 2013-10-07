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
                _show = new Show();
                _show.ID = doc.GetSeriesData("id");
                _show.ImdbID = doc.GetSeriesData("IMDB_ID");
                _show.Name = doc.GetSeriesData("SeriesName");
                _show.Language = doc.GetSeriesData("Language");
                _show.Network = doc.GetSeriesData("Network");
                _show.Description = doc.GetSeriesData("Overview");
                _show.Rating = string.IsNullOrWhiteSpace(doc.GetSeriesData("Rating"))
                                   ? (double?) null
                                   : Convert.ToDouble(doc.GetSeriesData("Rating"),
                                                      System.Globalization.CultureInfo.InvariantCulture);
                _show.RatingCount = string.IsNullOrWhiteSpace(doc.GetSeriesData("RatingCount"))
                                        ? 0
                                        : Convert.ToInt32(doc.GetSeriesData("RatingCount"));
                _show.Runtime = string.IsNullOrWhiteSpace(doc.GetSeriesData("Runtime"))
                                    ? (int?) null
                                    : Convert.ToInt32(doc.GetSeriesData("Runtime"));
                _show.Banner = doc.GetSeriesData("banner");
                _show.Fanart = doc.GetSeriesData("fanart");
                _show.LastUpdated = string.IsNullOrWhiteSpace(doc.GetSeriesData("lastupdated"))
                                        ? (long?) null
                                        : Convert.ToInt64(doc.GetSeriesData("lastupdated"));
                _show.Poster = doc.GetSeriesData("poster");
                _show.Zap2ItID = doc.GetSeriesData("zap2it_id");
                _show.FirstAired = Utils.ParseDate(doc.GetSeriesData("FirstAired"));
                _show.AirTime = string.IsNullOrWhiteSpace(doc.GetSeriesData("Airs_Time"))
                                    ? (TimeSpan?) null
                                    : Utils.ParseTime(doc.GetSeriesData("Airs_Time"));
                _show.AirDay = string.IsNullOrWhiteSpace(doc.GetSeriesData("Airs_DayOfWeek"))
                                   ? (DayOfWeek?) null
                                   : (DayOfWeek) Enum.Parse(typeof(DayOfWeek), doc.GetSeriesData("Airs_DayOfWeek"));
                _show.Status = string.IsNullOrWhiteSpace(doc.GetSeriesData("Status"))
                                   ? Status.Unknown
                                   : (Status) Enum.Parse(typeof(Status), doc.GetSeriesData("Status"));
                _show.ContentRating = Utils.GetContentRating(doc.GetSeriesData("ContentRating"));
                _show.Genres = new List<string>(doc.GetSeriesData("Genre").Split(new[] { '|' }, StringSplitOptions.RemoveEmptyEntries));
                _show.Actors = new List<string>(doc.GetSeriesData("Actors").Split(new[] { '|' }, StringSplitOptions.RemoveEmptyEntries));
                _show.Episodes = new EpisodeBuilder(doc).BuildEpisodes();
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
                        GuestStars = new List<string>(episode.GetXmlData("GuestStars").Split(new[] { '|' }, StringSplitOptions.RemoveEmptyEntries)),
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
                                ? 0
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
                        Writers = new List<string>(episode.GetXmlData("Writer").Split(new[] { '|' }, StringSplitOptions.RemoveEmptyEntries))
                    };

                    result.Add(ep);
                }

                return result;
            }
        }
    }
}