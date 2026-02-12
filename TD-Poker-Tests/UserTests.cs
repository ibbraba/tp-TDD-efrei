using Moq;
using TP_Poker_console;

namespace TD_Poker_Tests
{
    [TestFixture]
    public class UserTests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Test_CreateUserSuccesfullyReturnsUser()
        {
            var deckMock = new Mock<IDeck>();
            var sut = new UserService(deckMock.Object);
            var user = sut.CreateUser("John Doe");
            Assert.That(user, Is.Not.Null);
            Assert.That(user.Name, Is.EqualTo("John Doe"));
        }

        /*
         * CREER MOCK DE LA CONSOLE POUR LANCER CE TEST SINON TEST INFINI
         *
        [Test]
        public void Test_UserIsCreatedOnGameStart()
        {
            var sut = new Mock<IUserService>();
            var deckMock = new Mock<IDeck>();
            var gameService = new GameService(sut.Object, deckMock.Object);

            // Act
            gameService.RunGame();

            // Assert
            sut.Verify(service => service.CreateUser("John Doe"), Moq.Times.Once);
        }
        */

        [Test]
        public void Test_DrawUserCard_DrawsCardSuccessfully()
        {
            var sut = new Mock<IUserService>();
            var deck = new Mock<IDeck>();
            User user = new User { Name = "John" };

            Assert.DoesNotThrow(() => { sut.Object.DrawUserCards(user); });
        }
    }
}