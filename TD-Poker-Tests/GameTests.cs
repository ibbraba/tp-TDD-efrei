using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TP_Poker_console;

namespace TD_Poker_Tests
{
    [TestFixture]
    public class GameTests
    {
        /*
        [Test]
        public void RunGame_LauchesAnInstanceOfGame()
        {
            var userServiceMock = new Mock<IUserService>();
            var deckMock = new Mock<IDeck>();
            var sut = new GameService(userServiceMock.Object, deckMock.Object);

            // Assert.DoesNotThrow(() => { sut.RunGame(); });
        }
        */

        public void RunGame_ShouldDrawPlayerCards()
        {
            var userServiceMock = new Mock<IUserService>();
            var deckMock = new Mock<IDeck>();
            var sut = new GameService(userServiceMock.Object, deckMock.Object);
            sut.RunGame();

            userServiceMock.Verify(us => us.DrawUserCards(It.IsAny<User>()), Times.Once);
        }
    }
}