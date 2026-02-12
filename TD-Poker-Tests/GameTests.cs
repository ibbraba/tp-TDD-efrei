using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TP_Poker_console;
using TP_Poker_console.Deck;
using TP_Poker_console.Deck.Utils;
using TP_Poker_console.Game;
using TP_Poker_console.User;

namespace TD_Poker_Tests
{
    [TestFixture]
    public class GameTests
    {
        /*
         * TESTS INFINS, CLASS CONSOLE A MOCKER
         *
        [Test]
        public void RunGame_LauchesAnInstanceOfGame()
        {
            var userServiceMock = new Mock<IUserService>();
            var deckMock = new Mock<IDeck>();
            var sut = new GameService(userServiceMock.Object, deckMock.Object);

            // Assert.DoesNotThrow(() => { sut.RunGame(); });
        }

        [Test]
        public void RunGame_ShouldDrawPlayerCards()
        {
            var userServiceMock = new Mock<IUserService>();
            var deckMock = new Mock<IDeck>();
            var sut = new GameService(userServiceMock.Object, deckMock.Object);
            sut.RunGame();

            userServiceMock.Verify(us => us.DrawUserCards(It.IsAny<User>()), Times.Once);
        }

        */

        [Test]
        public void DrawCommunityCards_ShouldReturn5Cards()
        {
            var userServiceMock = new Mock<IUserService>();
            var deckMock = new Mock<IDeck>();
            var sut = new GameService(userServiceMock.Object, deckMock.Object);
            var communityCards = sut.DrawCommunityCards();
            Assert.That(communityCards, Is.Not.Null);
            Assert.That(communityCards.Count, Is.EqualTo(5));
        }

        [Test]
        public void CheckResult_PlayerHasHigherCard_Wins()
        {
            var player = new User
            {
                Card1 = new Card(Suit.Spades, Rank.Ace),
                Card2 = new Card(Suit.Hearts, Rank.Ten)
            };

            var opponent = new User
            {
                Card1 = new Card(Suit.Diamonds, Rank.King),
                Card2 = new Card(Suit.Clubs, Rank.Nine)
            };

            var communityCards = new List<Card>
    {
        new Card(Suit.Spades, Rank.Three),
        new Card(Suit.Hearts, Rank.Five),
        new Card(Suit.Diamonds, Rank.Seven),
        new Card(Suit.Clubs, Rank.Two),
        new Card(Suit.Spades, Rank.Four)
    };

            var gameService = new GameService(null, null);

            var result = gameService.CheckResult(player, opponent, communityCards);

            Assert.That(result, Is.EqualTo("Player wins"));
        }

        [Test]
        public void CheckResult_OpponentHasHigherCard_Wins()
        {
            // Arrange
            var player = new User
            {
                Card1 = new Card(Suit.Spades, Rank.Ten),
                Card2 = new Card(Suit.Hearts, Rank.Nine)
            };

            var opponent = new User
            {
                Card1 = new Card(Suit.Diamonds, Rank.King),
                Card2 = new Card(Suit.Clubs, Rank.Queen)
            };

            var communityCards = new List<Card>
        {
            new Card(Suit.Spades, Rank.Two),
            new Card(Suit.Hearts, Rank.Three),
            new Card(Suit.Diamonds, Rank.Four)
        };

            var gameService = new GameService(null, null);

            // Act
            var result = gameService.CheckResult(player, opponent, communityCards);

            // Assert
            Assert.That(result, Is.EqualTo("Opponent wins"));
        }

        [Test]
        public void CheckResult_Tie_ReturnsTie()
        {
            // Arrange
            var player = new User
            {
                Card1 = new Card(Suit.Spades, Rank.Ace),
                Card2 = new Card(Suit.Hearts, Rank.King)
            };

            var opponent = new User
            {
                Card1 = new Card(Suit.Diamonds, Rank.Ace),
                Card2 = new Card(Suit.Clubs, Rank.King)
            };

            var communityCards = new List<Card>
        {
            new Card(Suit.Spades, Rank.Two),
            new Card(Suit.Hearts, Rank.Three),
            new Card(Suit.Diamonds, Rank.Four)
        };

            var gameService = new GameService(null, null);

            // Act
            var result = gameService.CheckResult(player, opponent, communityCards);

            // Assert
            Assert.That(result, Is.EqualTo("Tie"));
        }
    }
}