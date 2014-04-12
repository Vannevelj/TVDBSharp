using System;
using System.Collections.Generic;
using System.IO;
using System.Xml.Linq;
using System.Xml.Serialization;
using Tests.Models;
using TVDBSharp.Models.DAO;
using TVDBSharp.Models.Enums;

namespace Tests
{
    /// <summary>
    ///     Dataprovider used for testing. This class generates XML trees to be used for parsing tests.
    /// </summary>
    public class TestDataProvider : IDataProvider
    {
        private readonly TestData _data;

        public string ApiKey { get; set; }

        /// <summary>
        ///     Initializes a new instance with the provided testing data.
        /// </summary>
        /// <param name="data">Mocking data of type <see cref="TestData" />.</param>
        public TestDataProvider(TestData data)
        {
            _data = data;
        }

        public XDocument GetShow(int showID)
        {
            var showData = _data.GetShowData();
            var episodeData = _data.GetEpisodeData();
            var show = new Data {TestShow = new TestShow()};

            // Dynamically create the show object
            foreach (var key in showData.Keys)
            {
                var prop = show.TestShow.GetType().GetProperty(key.XmlValue);
                prop.SetValue(show.TestShow, showData[key].XmlValue, null);
            }

            // Add episodes to the show object
            show.TestShow.Episodes = new List<TestEpisode>();
            foreach (var ep in episodeData)
            {
                var newEpisode = new TestEpisode();

                foreach (var key in ep.Keys)
                {
                    var prop = newEpisode.GetType().GetProperty(key.XmlValue);
                    prop.SetValue(newEpisode, ep[key].XmlValue, null);
                }

                show.TestShow.Episodes.Add(newEpisode);
            }

            // Pull the created object trough an XML serializer
            var serializer = new XmlSerializer(show.GetType());
            string xml;

            using (var writer = new StringWriter())
            {
                serializer.Serialize(writer, show);
                xml = writer.ToString();
            }

            return XDocument.Parse(xml);
        }

        public XDocument GetEpisode(int episodeId, string lang)
        {
            throw new NotImplementedException();
        }

        public XDocument GetUpdates(Interval interval)
        {
            throw new NotImplementedException();
        }

        public XDocument Search(string query)
        {
            throw new NotImplementedException();
        }
    }
}