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
        [Test]
        public void RunGame_LauchesAnInstanceOfGame()
        {
            var userServiceMock = new Mock<IUserService>();
            var sut = new GameService(userServiceMock.Object);

            Assert.DoesNotThrow(() => { sut.RunGame(); });
        }
    }
}