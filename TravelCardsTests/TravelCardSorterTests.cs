using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TravelCards;

namespace TravelCardsTests
{
    [TestClass]
    public class TravelCardSorterTests
    {

        private static TravelCardSorter _travelCardSorter;

        [ClassInitialize]
        public static void ClassInitialize(TestContext context)
        {
            _travelCardSorter = new TravelCardSorter();
        }

        /// <summary>
        /// Тест с набором значений из спецификации
        /// </summary>
        [TestMethod]
        public void SpecificationSortTest()
        {
            //Arrange
            var cards = new[]
            {
                new TravelCard("Melbourne", "Koeln"),
                new TravelCard("Moscow", "Paris"),
                new TravelCard("Koeln", "Moscow")
            };

            //Act
            var sortedCards = _travelCardSorter.Sort(cards);

            //Assert
            for (var i = 0; i < sortedCards.Count - 1; i++)
            {
                Assert.AreEqual(sortedCards[i].Arrival, sortedCards[i + 1].Departure);
            }
        }

        /// <summary>
        /// Тест с пустым аргументом
        /// </summary>
        [ExpectedException(typeof (ArgumentNullException))]
        [TestMethod]
        public void NullSortTest()
        {
            //Arrange
            TravelCard[] cards = null;

            //Act
            var sortedCards = _travelCardSorter.Sort(cards);

            //Assert
            Assert.Fail();
        }

        /// <summary>
        /// Тест с пустой коллекцией
        /// </summary>
        [TestMethod]
        public void EmptySortTest()
        {
            //Arrange
            TravelCard[] cards = {};

            //Act
            var sortedCards = _travelCardSorter.Sort(cards);

            //Assert
            Assert.IsFalse(sortedCards.Any());
        }

        /// <summary>
        /// Тест с единственным значением в коллекции
        /// </summary>
        [TestMethod]
        public void SingleItemSortTest()
        {
            //Arrange
            var cards = new[]
            {
                new TravelCard("Melbourne", "Koeln")
            };

            //Act
            var sortedCards = _travelCardSorter.Sort(cards);

            //Assert
            Assert.AreEqual(sortedCards.First(), cards.First());
           Assert.AreEqual(sortedCards.Count, cards.Length);

        }

        /// <summary>
        /// Тест с заранее отсортированным списком
        /// </summary>
        [TestMethod]
        public void PresortedSortTest()
        {
            //Arrange
            var cards = new[]
            {
                new TravelCard("Melbourne", "Koeln"),
                new TravelCard("Koeln", "Moscow"),
                new TravelCard("Moscow", "Paris")
            };

            //Act
            var sortedCards = _travelCardSorter.Sort(cards);

            //Assert
            for (var i = 0; i < sortedCards.Count - 1; i++)
            {
                Assert.AreEqual(sortedCards[i].Arrival, sortedCards[i + 1].Departure);
            }
        }

        /// <summary>
        /// Тест с отсортированным в обратном порядке списком
        /// </summary>
        [TestMethod]
        public void InversePresortedSortTest()
        {
            //Arrange
            var cards = new[]
            {
                new TravelCard("Moscow", "Paris"),
                new TravelCard("Koeln", "Moscow"),
                new TravelCard("Melbourne", "Koeln")

            };

            //Act
            var sortedCards = _travelCardSorter.Sort(cards);

            //Assert
            for (var i = 0; i < sortedCards.Count - 1; i++)
            {
                Assert.AreEqual(sortedCards[i].Arrival, sortedCards[i + 1].Departure);
            }
        }


    }
}