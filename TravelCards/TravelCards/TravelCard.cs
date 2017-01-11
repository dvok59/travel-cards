namespace TravelCards
{
    /// <summary>
    /// Карточка путешествия
    /// </summary>
    public struct TravelCard
    {
        #region Props

        /// <summary>
        /// Пункт отправления
        /// </summary>
        public string Departure { get; private set; }

        /// <summary>
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
