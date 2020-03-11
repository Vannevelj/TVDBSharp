using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;
using TVDBSharp.Models.DAO;
using TVDBSharp.Models.Enums;
using TVDBSharp.Utilities;

namespace TVDBSharp.Models
{
    /// <summary>
    ///     Provides builder classes for complex entities.
    /// </summary>
    public class Builder
    {
        
        private readonly IDataProvider _dataProvider;

        /// <summary>
        ///     Initializes a new Builder object with the given <see cref="IDataProvider" />.
        /// </summary>
        /// <param name="dataProvider">The DataProvider used to retrieve XML responses.</param>
        public Builder(IDataProvider dataProvider)
        {
            _dataProvider = dataProvider;
        }

        public Episode BuildEpisode(int episodeId, string lang)
        {
            //var builder = new EpisodeBuilder(_dataProvider.GetEpisode(episodeId, lang).Descendants("Episode").First());
            //return builder.GetResult();
            return null;
        }

        public Updates BuildUpdates(Interval interval)
        {
            var builder = new UpdatesBuilder(_dataProvider.GetUpdates(interval));
            return builder.GetResult();
        }

        /// <summary>
        ///     Returns a list of <see cref="Show" /> objects that match the given query.
        /// </summary>
        /// <param name="query">Query the search is performed with.</param>
        /// <param name="results">Maximal amount of shows the resultset should return.</param>
        /// <returns>Returns a list of show objects.</returns>
        public List<Show> Search(string query, int results)
        {
            var shows = new List<Show>(results);
            var doc = _dataProvider.Search(query);

            //foreach (var element in doc.Descendants("Series").Take(results))
            //{
            //    var id = int.Parse(element.GetXmlData("seriesid"));
            //    var response = _dataProvider.GetShow(id);
            //    shows.Add(new ShowBuilder(response).GetResult());
            //}

            return shows;
        }

        public class EpisodeBuilder
        {
            private readonly Episode _episode;

            public EpisodeBuilder(XElement episodeNode)
            {
                _episode = new Episode
                {
                    Id = int.Parse(episodeNode.GetXmlData("id")),
                    EpisodeName = episodeNode.GetXmlData("EpisodeName"),
                    Overview = episodeNode.GetXmlData("Overview"),
                    AiredEpisodeNumber = int.Parse(episodeNode.GetXmlData("EpisodeNumber")),
                    Directors = episodeNode.GetXmlData("Director"),
                    //EpisodeImage = GetBannerUri(episodeNode.GetXmlData("filename")),
                    //FirstAired =
                    //    string.IsNullOrWhiteSpace(episodeNode.GetXmlData("FirstAired"))
                    //        ? (DateTime?) null
                    //        : Utils.ParseDate(episodeNode.GetXmlData("FirstAired")),
                    GuestStars =
                        new List<string>(episodeNode.GetXmlData("GuestStars")
                            .Split(new[] {'|'}, StringSplitOptions.RemoveEmptyEntries)),
                    ImdbId = episodeNode.GetXmlData("IMDB_ID"),
                    LastUpdated =
                        string.IsNullOrWhiteSpace(episodeNode.GetXmlData("lastupdated"))
                            ? 0L
                            : Convert.ToInt64(episodeNode.GetXmlData("lastupdated")),
                    SiteRating =
                        string.IsNullOrWhiteSpace(episodeNode.GetXmlData("Rating"))
                            ? (double?) null
                            : Convert.ToDouble(episodeNode.GetXmlData("Rating"),
                                System.Globalization.CultureInfo.InvariantCulture),
                    SiteRatingCount =
                        string.IsNullOrWhiteSpace(episodeNode.GetXmlData("RatingCount"))
                            ? 0
                            : Convert.ToInt32(episodeNode.GetXmlData("RatingCount")),
                    AiredSeasonId = int.Parse(episodeNode.GetXmlData("seasonid")),
                    AiredSeason = int.Parse(episodeNode.GetXmlData("SeasonNumber")),
                    SeriesId = int.Parse(episodeNode.GetXmlData("seriesid")),
                    ThumbHeight =
                        string.IsNullOrWhiteSpace(episodeNode.GetXmlData("thumb_height"))
                            ? (int?) null
                            : Convert.ToInt32(episodeNode.GetXmlData("thumb_height")),
                    ThumbWidth =
                        string.IsNullOrWhiteSpace(episodeNode.GetXmlData("thumb_width"))
                            ? (int?) null
                            : Convert.ToInt32(episodeNode.GetXmlData("thumb_width")),
                    Writers =
                        new List<string>(episodeNode.GetXmlData("Writer")
                            .Split(new[] {'|'}, StringSplitOptions.RemoveEmptyEntries))
                };
            }

            public Episode GetResult()
            {
                return _episode;
            }
        }

        private class EpisodesBuilder
        {
            private readonly XDocument _doc;

            public EpisodesBuilder(XDocument doc)
            {
                _doc = doc;
            }

            public List<Episode> BuildEpisodes()
            {
                var result = new List<Episode>();

                foreach (var episodeNode in _doc.Descendants("Episode"))
                {
                    var episode = new EpisodeBuilder(episodeNode).GetResult();
                    result.Add(episode);
                }

                return result;
            }
        }

        public class UpdatesBuilder
        {
            private readonly Updates _updates;

            public UpdatesBuilder(Updates doc)
            {
                //if (doc.Root != null)
                //{
                //    _updates = new Updates
                //    {
                //        Time = int.Parse(doc.Root.Attribute("time").Value),
                //        UpdatedSeries = doc.Root.Elements("Series")
                //            .Select(elt => new UpdatedSerie
                //            {
                //                Id = int.Parse(elt.Element("id").Value),
                //                Time = int.Parse(elt.Element("time").Value)
                //            })
                //            .ToList(),
                //        UpdatedEpisodes = doc.Root.Elements("Episode")
                //            .Select(elt => new UpdatedEpisode
                //            {
                //                Id = int.Parse(elt.Element("id").Value),
                //                SerieId = int.Parse(elt.Element("Series").Value),
                //                Time = int.Parse(elt.Element("time").Value)
                //            })
                //            .ToList(),
                //        UpdatedBanners = doc.Root.Elements("Banner")
                //            .Select(elt => new UpdatedBanner
                //            {
                //                SerieId = int.Parse(elt.Element("Series").Value),
                //                Format = elt.Element("format").Value,
                //                Language =
                //                    elt.Elements("language").Select(n => n.Value).FirstOrDefault() ?? string.Empty,
                //                Path = elt.Element("path").Value,
                //                Type = elt.Element("type").Value,
                //                SeasonNumber = elt.Elements("SeasonNumber").Any()
                //                    ? int.Parse(elt.Element("SeasonNumber").Value)
                //                    : (int?) null,
                //                Time = int.Parse(elt.Element("time").Value)
                //            })
                //            .ToList()
                //    };
                //}
            }

            public Updates GetResult()
            {
                return _updates;
            }
        }
    }
}