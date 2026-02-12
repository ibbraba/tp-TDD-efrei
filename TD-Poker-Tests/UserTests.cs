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
            var sut = new UserService();
            var user = sut.CreateUser("John Doe");
            Assert.That(user, Is.Not.Null);
            Assert.That(user.Name, Is.EqualTo("John Doe"));
        }

        [Test]
        public void Test_UserIsCreatedOnGameStart()
        {
            var sut = new Mock<IUserService>();
            var gameService = new GameService(sut.Object);

            // Act
            gameService.RunGame();

            // Assert
            sut.Verify(service => service.CreateUser("John Doe"), Moq.Times.Once);
        }

        [Test]
        public void Test_DrawUserCard_DrawsCardSuccessfully()
        {
            var sut = new Mock<IUserService>();
            User user = new User { Name = "John" };

            Assert.DoesNotThrow(() => { sut.Object.DrawUserCard(user); });
        }
    }
}