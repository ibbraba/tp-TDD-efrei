using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TP_Poker_console;
using TP_Poker_console.Deck;
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
    }
}