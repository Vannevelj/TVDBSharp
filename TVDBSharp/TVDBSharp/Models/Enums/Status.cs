namespace TVDBSharp.Models.Enums
{
    /// <summary>
    ///     Describes the current status of a show.
    /// </summary>
    public enum Status
    {
        /// <summary>
        ///     Default value if no status is specified.
        /// </summary>
        Unknown = 0,

        /// <summary>
        ///     No more episodes are being released.
        /// </summary>
        Ended = 1,

        /// <summary>
        ///     The show is ongoing.
        /// </summary>
        Continuing = 2,

        /// <summary>
        /// The show has yet to start.
        /// </summary>
        Upcoming = 3
    }
}