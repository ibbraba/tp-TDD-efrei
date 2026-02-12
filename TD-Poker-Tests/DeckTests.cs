using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TP_Poker_console;

namespace TD_Poker_Tests
{
    [TestFixture]
    public class DeckTests
    {
        [Test]
        public void CreateDeck_Should_Return_52_Cards()
        {
            var deck = new Deck();

            Assert.That(deck, Is.Not.Null);
            Assert.AreEqual(52, deck.Count);
        }

        [Test]
        public void Draw_Should_Return_Card_And_Remove_It_From_Deck()
        { // Arrange
            var deck = new Deck();
            int initialCount = deck.Count;

            var card = deck.Draw();
            // Assert
            Assert.That(card, Is.Not.Null);
            Assert.AreEqual(initialCount - 1, deck.Count);
        }
    }
}