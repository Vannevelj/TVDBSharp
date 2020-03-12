using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TVDBSharp.Models.Enums;

namespace TVDBSharp.Models.DAO
{
    /// <summary>
    ///     Defines a Dataprovider API.
    /// </summary>
    public interface IDataProvider
    {
        /// <summary>
        ///     Retrieves the show with the given id
        /// </summary>
        /// <param name="showId">ID of the show you wish to lookup.</param>
        /// <returns>The deserialized <see cref="Show"/></returns>
        Task<Show> GetShow(int showId);

        /// <summary>
        ///     Retrieves the show with the given id
        /// </summary>
        /// <param name="showId">ID of the show you wish to lookup.</param>
        /// <returns>The deserialized <see cref="List{Show}<"/></returns>
        Task<List<Episode>> GetEpisodes(int showId, int page);

        /// <summary>
        ///     Retrieves updates on tvdb (Shows, Episodes and Banners)
        /// </summary>
        /// <param name="interval">The interval for the updates</param>
        Task<List<UpdateTimestamp>> GetUpdates(DateTime from, DateTime to);

        /// <summary>
        ///     Returns an XML tree representing a search query for the given parameter.
        /// </summary>
        /// <param name="query">Query to perform the search with.</param>
        Task<List<Show>> Search(string query);
    }
}