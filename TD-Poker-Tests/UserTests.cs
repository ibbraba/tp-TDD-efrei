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
    }
}