using System;
using System.Collections.Generic;
using System.Linq;

namespace TravelCards
{
    /// <summary>
    /// Сортировщик карточек
    /// </summary>
    public class TravelCardSorter
    {
        /// <summary>
        /// Словарь карточек
        /// </summary>
        private Dictionary<string, LinkedList<TravelCard>> _travelCards;

        /// <summary>
        /// Отсортировать карточки
        /// </summary>
        /// <param name="unsortedCards">Неотсортированный набор карточек</param>
        /// <returns></returns>
        public IList<TravelCard> Sort(IEnumerable<TravelCard> unsortedCards)
        {
            if (unsortedCards == null) throw new ArgumentNullException(nameof(unsortedCards));
            var travelCards
                = unsortedCards as TravelCard[] ?? unsortedCards.ToArray();
            if (!travelCards.Any()) return new List<TravelCard>();

            //кладем все карточки в словарь, где ключом будет пункт отправления
            _travelCards = travelCards.ToDictionary(
                travelCard => travelCard.Departure,
                travelCard => new LinkedList<TravelCard>(new Node<TravelCard> { Next = null, Value = travelCard })
                );

            //рекурсивно связываем карточки
            var initialCard = _travelCards.Values.First() //первый список карточек из словаря
                .Tail.Value //последний элемент списка
                .Departure;//пункт прибытия

            LinkCards(initialCard);
            
            return _travelCards.First().Value.ToList();
        }

        /// <summary>
        /// Связываем карточки в словаре
        /// </summary>
        /// <param name="key">Ключ начального элемента (подойдет любой ключ из словаря)</param>
        private void LinkCards(string key)
        {
            //если в словаре остался только один элемент, то это результирующий список карточек
            if (_travelCards.Count == 1) return;

            //получаем ключ для следующей по очереди карточки (или списка карточек)
            //этот ключ - пункт назначения в последней карточке
            var nextKey = _travelCards[key].Tail.Value.Arrival;
            
            //если этот ключ есть в словаре
            if (_travelCards.ContainsKey(nextKey))
            {
                //добавляем карточки по этому ключу к предыдущему списку
                _travelCards[key].Concat(_travelCards[nextKey]);
                //убираем элемент по этому ключу из словаря
                _travelCards.Remove(nextKey);
                //повторяем для обновленного списка
                LinkCards(key);
            }
            else
            {
                //если ключа нет в словаре, то, значит, найден последний элемент в последовательности
                //берем любой другой ключ из оставшихся в словаре
                LinkCards(_travelCards.Keys.First(s => s != key));
            }
        }
       
    }
}
