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
        /// Test with collection from task specification.
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
        /// Test for null argument.
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
        /// Test with empty collection.
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
        /// Test with a sole element in the collection.
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
        /// Test with presorted collection.
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
        /// Test with inversely presorted collection.
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