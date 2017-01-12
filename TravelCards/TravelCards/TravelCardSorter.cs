using System;
using System.Collections.Generic;
using System.Linq;

namespace TravelCards
{
    /// <summary>
    /// Sorts unordered lists of Travel Cards.
    /// </summary>
    public class TravelCardSorter
    {
        /// <summary>
        /// Hashtable of Travel Cards.
        /// </summary>
        private Dictionary<string, LinkedList<TravelCard>> _travelCards;

        /// <summary>
        /// Sort given list of Travel Cards to make arrival and departure points match in consequent cards.
        /// </summary>
        /// <param name="unsortedCards">Unsorted list of Travel Cards.</param>
        /// <returns></returns>
        public IList<TravelCard> Sort(IEnumerable<TravelCard> unsortedCards)
        {
            if (unsortedCards == null) throw new ArgumentNullException(nameof(unsortedCards));
            var travelCards
                = unsortedCards as TravelCard[] ?? unsortedCards.ToArray();
            if (!travelCards.Any()) return new List<TravelCard>();

            //populate dictionary from the given list, where Departure is set to be the Key
            _travelCards = travelCards.ToDictionary(
                travelCard => travelCard.Departure,
                travelCard => new LinkedList<TravelCard>(new Node<TravelCard> { Next = null, Value = travelCard })
                );

           //a card is needed to initate the sorting procedure (any card would really fit)
            var initialCard = _travelCards.Values.First() //get the first list of travel cards from the dictionary
                .Tail.Value //get the last element of this list
                .Departure; //take is departure

            //link cards recursively
            LinkCards(initialCard);
            
            return _travelCards.First().Value.ToList();
        }

        /// <summary>
        /// Recursively links cards
        /// </summary>
        /// <param name="key">Key for an element to initialize procedure.</param>
        private void LinkCards(string key)
        {
            //if there is only one item remaining in the dictionary, the recursion should be terminated, since this is the result
            if (_travelCards.Count == 1) return;

            //acquire key for the next in sequence travel card 
            //this key is the arrival point from the final card of the current card list
            var nextKey = _travelCards[key].Tail.Value.Arrival;
            
            if (_travelCards.ContainsKey(nextKey))
            {
                //if next key is present in the dictionary
                //append cards from this key to the current card list
                _travelCards[key].Concat(_travelCards[nextKey]);
                //remove the next key from the dictionary
                _travelCards.Remove(nextKey);
                //next level of recursion
                LinkCards(key);
            }
            else
            {
                //if next key is not present in the dictionary
                //then we have stumbled upon the very last card of the resulting sequence
                //hence, any other key should be used 
                LinkCards(_travelCards.Keys.FirstOrDefault(s => s != key));
            }
        }
       
    }
}
