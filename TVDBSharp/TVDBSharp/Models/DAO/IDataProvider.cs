using System.Xml.Linq;

namespace TVDBSharp.Models.DAO {
    /// <summary>
    /// Defines a Dataprovider API.
    /// </summary>
    public interface IDataProvider {
        /// <summary>
        /// The API key provided by TVDB.
        /// </summary>
        string ApiKey { get; set; }

        /// <summary>
        /// Retrieves the show with the given id and returns the corresponding XML tree.
        /// </summary>
        /// <param name="showID">ID of the show you wish to lookup.</param>
        /// <returns>Returns an XML tree of the show object.</returns>
        XDocument GetShow(string showID);

        /// <summary>
        /// Returns an XML tree representing a search query for the given parameter.
        /// </summary>
        /// <param name="query">Query to perform the search with.</param>
        /// <returns>Returns an XML tree of a search result.</returns>
        XDocument Search(string query);
    }
}