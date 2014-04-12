using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Tests.Models;
using TVDBSharp.Models;
using TVDBSharp.Models.DAO;

namespace Tests
{
    /// <summary>
    ///     A collection of the most important tests which test the complete workflow excluding connecting to the web service.
    /// </summary>
    [TestClass]
    public class MainTests
    {
        private TestData _data;
        private IDataProvider _dataProvider;

        /// <summary>
        ///     Initializes the test with mock data. See <see cref="TestData" /> for more information.
        /// </summary>
        [TestInitialize]
        public void Initialize()
        {
            _data = new TestData();
            _dataProvider = new TestDataProvider(_data);
        }

        /// <summary>
        ///     Test the retrieval of a show. A <see cref="TestShow" /> object is created
        ///     to accurately represent the XML tree of a show.
        ///     Afterwards the <see cref="TVDBSharp.Models.Builder" /> is called
        ///     to parse this into a <see cref="TVDBSharp.Models.Show" /> object.
        ///     This process includes creating <see cref="TVDBSharp.Models.Episode" /> objects.
        ///     Finally every property is being tested to have the expected outcome a
        ///     as detailed in <see cref="TestData" />.
        /// </summary>
        [TestMethod]
        public void GetShow()
        {
            // Pull XML tree trough the show builder
            var builder = new Builder(_dataProvider);

            var showId = int.Parse(_data.GetShowData().Keys.First(x => x.XmlValue == "id").XmlValue);
            var result = builder.BuildShow(showId);

            var showData = _data.GetShowData();
            var episodeData = _data.GetEpisodeData();

            // Assert equality between value conversions for show data
            foreach (var key in showData.Keys)
            {
                var prop = result.GetType().GetProperty(key.ObjValue);
                Assert.IsTrue(prop.GetValue(result).ToString() == showData[key].ObjValue,
                    "!Show object! Property: " + prop.Name + " ;Actual object value: " + prop.GetValue(result) +
                    " ;Expected value: " + showData[key].ObjValue);
            }

            // Assert equality between value conversion for episode data
            for (var i = 0; i < result.Episodes.Count; i++)
            {
                var currentEpisode = result.Episodes[i];
                var dic = episodeData[i];

                foreach (var key in dic.Keys)
                {
                    var prop = currentEpisode.GetType().GetProperty(key.ObjValue);

                    // Checks whether or not we're dealing with a list
                    // ToString() method on lists will not show the values and are therefore not suited for comparison
                    // That's why we manually check the entries
                    if (new List<string> {"Actors", "Genres", "GuestStars", "Writers"}.Contains(key.ObjValue))
                    {
                        foreach (var entry in dic[key].XmlValue.Split('|'))
                        {
                            Assert.IsTrue(((List<string>) prop.GetValue(currentEpisode)).Contains(entry),
                                "!List object! Property: " + prop.Name + " ;Actual object value: " +
                                string.Join(", ", (List<string>) prop.GetValue(currentEpisode)) + ";Expected value: " +
                                dic[key].XmlValue);
                        }
                    }

                    var value = prop.GetValue(currentEpisode).ToString();
                    var expected = dic[key].ObjValue;
                    Assert.IsTrue(value == expected,
                        "!Episode object! Property: " + prop.Name + " ;Actual object value: " +
                        prop.GetValue(currentEpisode) + " ;Expected value: " + dic[key].ObjValue);
                }
            }
        }
    }
}