namespace TravelCards
{
    /// <summary>
    /// Contains information about city or airport of departure and arrival.
    /// </summary>
    public struct TravelCard
    {
        #region Props

        /// <summary>
        /// City or airport of departure.
        /// </summary>
        public string Departure { get; private set; }

        /// <summary>
        /// City or airport of arrival.
        /// Пункт прибытия
        /// </summary>
        public string Arrival { get; private set; }

        #endregion

        #region Ctor

        public TravelCard(string departure, string arrival)
        {
            Departure = departure;
            Arrival = arrival;
        }

        #endregion

    }
}
