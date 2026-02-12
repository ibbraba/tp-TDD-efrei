using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TP_Poker_console;

namespace TD_Poker_Tests
{
    [TestFixture]
    public class GameTest
    {
        [Test]
        public void RunGame_LauchesAnInstanceOfGame()
        {
            var sut = new GameService();

            Assert.DoesNotThrow(() => { sut.RunGame(); });
        }
    }
}