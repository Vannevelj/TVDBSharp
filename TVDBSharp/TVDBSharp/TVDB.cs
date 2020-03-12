using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TVDBSharp.Models;
using TVDBSharp.Models.DAO;
using TVDBSharp.Models.Enums;

namespace TVDBSharp
{
    /// <summary>
    ///     The main class which will handle all user interaction.
    /// </summary>
    public class TVDB
    {
        private readonly IDataProvider _dataProvider;

        /// <summary>
        ///     Creates a new instance with the provided API key and standard <see cref="IDataProvider" />.
        /// </summary>
        /// <param name="apiKey">The API key provided by TVDB.</param>
        public TVDB(string apiKey)
        {
            _dataProvider = new DataProvider(apiKey);
        }

        /// <summary>
        ///     Search for a show in the database.
        /// </summary>
        /// <param name="query">Query that identifies the show.</param>
        /// <param name="results">Maximal amount of results in the returning set. Default is 5.</param>
        /// <returns>Returns a list of shows.</returns>
        public Task<List<Show>> Search(string query) => _dataProvider.Search(query);

        /// <summary>
        ///     Get a specific show based on its ID.
        /// </summary>
        /// <param name="showId">ID of the show.</param>
        /// <returns>Returns the corresponding show.</returns>
        public Task<Show> GetShow(int showId) => _dataProvider.GetShow(showId);

        /// <summary>
        /// Get all episodes for a given show, paginated in batches of 100 episodes.
        /// </summary>
        /// <param name="showId">ID of the show.</param>
        /// <param name="page">The index of the batch</param>
        /// <returns>A list of episodes</returns>
        public Task<List<Episode>> GetEpisodes(int showId, int page = 1) => _dataProvider.GetEpisodes(showId, page);

        /// <summary>
        /// Get all shows that have been updated since a provided timestamp.
        /// You may optionally pass in an end time as well but any time difference beyond 7 days will be automatically reduced to a week.
        /// </summary>
        /// <param name="from">Timestamp from which to retrieve updates</param>
        /// <param name="to">Optional end timestamp</param>
        /// <returns>A list of <see cref="UpdateTimestamp"/></returns>
        public Task<List<UpdateTimestamp>> GetUpdates(DateTime from, DateTime? to = null) => _dataProvider.GetUpdates(from, to ?? from.AddDays(7));
    }
}