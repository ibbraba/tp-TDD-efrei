using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TP_Poker_console.Deck;
using TP_Poker_console.Deck.Utils;
using TP_Poker_console.Game;
using TP_Poker_console.User;

namespace TD_Poker_Tests
{
    [TestFixture]
    public class GameServiceHandEvaluationTests
    {
        private GameService _gameService;

        [SetUp]
        public void Setup()
        {
            _gameService = new GameService(null, null);
        }

        // Straight Flush
        [Test]
        public void CheckResult_PlayerHasStraightFlush_Wins()
        {
            var player = new User
            {
                Card1 = new Card(Suit.Spades, Rank.Ten),
                Card2 = new Card(Suit.Spades, Rank.Jack)
            };
            var opponent = new User
            {
                Card1 = new Card(Suit.Clubs, Rank.Ace),
                Card2 = new Card(Suit.Diamonds, Rank.King)
            };
            var community = new List<Card>
        {
            new Card(Suit.Spades, Rank.Queen),
            new Card(Suit.Spades, Rank.King),
            new Card(Suit.Spades, Rank.Nine),
            new Card(Suit.Diamonds, Rank.Two),
            new Card(Suit.Clubs, Rank.Three)
        };

            var result = _gameService.CheckResult(player, opponent, community);
            Assert.That(result, Is.EqualTo("Player wins"));
        }

        // Four of a Kind
        [Test]
        public void CheckResult_PlayerHasFourOfAKind_Wins()
        {
            var player = new User
            {
                Card1 = new Card(Suit.Spades, Rank.Ace),
                Card2 = new Card(Suit.Hearts, Rank.Ace)
            };
            var opponent = new User
            {
                Card1 = new Card(Suit.Diamonds, Rank.King),
                Card2 = new Card(Suit.Clubs, Rank.King)
            };
            var community = new List<Card>
        {
            new Card(Suit.Clubs, Rank.Ace),
            new Card(Suit.Diamonds, Rank.Ace),
            new Card(Suit.Spades, Rank.Queen),
            new Card(Suit.Hearts, Rank.Three),
            new Card(Suit.Diamonds, Rank.Four)
        };

            var result = _gameService.CheckResult(player, opponent, community);
            Assert.That(result, Is.EqualTo("Player wins"));
        }

        // Full House
        [Test]
        public void CheckResult_PlayerHasFullHouse_Wins()
        {
            var player = new User
            {
                Card1 = new Card(Suit.Spades, Rank.Ace),
                Card2 = new Card(Suit.Hearts, Rank.Ace)
            };
            var opponent = new User
            {
                Card1 = new Card(Suit.Diamonds, Rank.King),
                Card2 = new Card(Suit.Clubs, Rank.King)
            };
            var community = new List<Card>
        {
            new Card(Suit.Clubs, Rank.Ace),
            new Card(Suit.Diamonds, Rank.King),
            new Card(Suit.Spades, Rank.Queen),
            new Card(Suit.Hearts, Rank.Two),
            new Card(Suit.Clubs, Rank.Three)
        };

            var result = _gameService.CheckResult(player, opponent, community);
            Assert.That(result, Is.EqualTo("Player wins"));
        }

        // Flush
        [Test]
        public void CheckResult_PlayerHasFlush_Wins()
        {
            var player = new User
            {
                Card1 = new Card(Suit.Hearts, Rank.Two),
                Card2 = new Card(Suit.Hearts, Rank.Five)
            };
            var opponent = new User
            {
                Card1 = new Card(Suit.Clubs, Rank.Ace),
                Card2 = new Card(Suit.Diamonds, Rank.King)
            };
            var community = new List<Card>
        {
            new Card(Suit.Hearts, Rank.Seven),
            new Card(Suit.Hearts, Rank.Nine),
            new Card(Suit.Hearts, Rank.Jack),
            new Card(Suit.Spades, Rank.Three),
            new Card(Suit.Diamonds, Rank.Four)
        };

            var result = _gameService.CheckResult(player, opponent, community);
            Assert.That(result, Is.EqualTo("Player wins"));
        }

        // Straight
        [Test]
        public void CheckResult_PlayerHasStraight_Wins()
        {
            var player = new User
            {
                Card1 = new Card(Suit.Spades, Rank.Ten),
                Card2 = new Card(Suit.Hearts, Rank.Jack)
            };
            var opponent = new User
            {
                Card1 = new Card(Suit.Diamonds, Rank.Ace),
                Card2 = new Card(Suit.Clubs, Rank.King)
            };
            var community = new List<Card>
        {
            new Card(Suit.Spades, Rank.Queen),
            new Card(Suit.Hearts, Rank.King),
            new Card(Suit.Diamonds, Rank.Nine),
            new Card(Suit.Spades, Rank.Two),
            new Card(Suit.Clubs, Rank.Three)
        };

            var result = _gameService.CheckResult(player, opponent, community);
            Assert.That(result, Is.EqualTo("Player wins"));
        }

        // Three of a Kind
        [Test]
        public void CheckResult_PlayerHasThreeOfAKind_Wins()
        {
            var player = new User
            {
                Card1 = new Card(Suit.Spades, Rank.Ace),
                Card2 = new Card(Suit.Hearts, Rank.Ace)
            };

            var opponent = new User
            {
                Card1 = new Card(Suit.Diamonds, Rank.King),
                Card2 = new Card(Suit.Clubs, Rank.Queen)
            };

            var community = new List<Card>
    {
        new Card(Suit.Clubs, Rank.Ace),
        new Card(Suit.Spades, Rank.Jack),
        new Card(Suit.Diamonds, Rank.Two),
        new Card(Suit.Hearts, Rank.Four),
        new Card(Suit.Clubs, Rank.Seven)
    };

            var result = _gameService.CheckResult(player, opponent, community);
            Assert.That(result, Is.EqualTo("Player wins"));
        }

        // Two Pair
        [Test]
        public void CheckResult_PlayerHasTwoPair_Wins()
        {
            var player = new User
            {
                Card1 = new Card(Suit.Spades, Rank.Ace),
                Card2 = new Card(Suit.Hearts, Rank.Ace)
            };
            var opponent = new User
            {
                Card1 = new Card(Suit.Diamonds, Rank.King),
                Card2 = new Card(Suit.Clubs, Rank.King)
            };
            var community = new List<Card>
        {
            new Card(Suit.Clubs, Rank.Queen),
            new Card(Suit.Spades, Rank.Queen),
            new Card(Suit.Diamonds, Rank.Ten),
            new Card(Suit.Hearts, Rank.Two),
            new Card(Suit.Clubs, Rank.Three)
        };

            var result = _gameService.CheckResult(player, opponent, community);
            Assert.That(result, Is.EqualTo("Player wins"));
        }

        // One Pair
        [Test]
        public void CheckResult_PlayerHasOnePair_Wins()
        {
            var player = new User
            {
                Card1 = new Card(Suit.Spades, Rank.Ace),
                Card2 = new Card(Suit.Hearts, Rank.King)
            };
            var opponent = new User
            {
                Card1 = new Card(Suit.Diamonds, Rank.Queen),
                Card2 = new Card(Suit.Clubs, Rank.Jack)
            };
            var community = new List<Card>
        {
            new Card(Suit.Clubs, Rank.Two),
            new Card(Suit.Spades, Rank.Three),
            new Card(Suit.Diamonds, Rank.Four),
            new Card(Suit.Hearts, Rank.Five),
            new Card(Suit.Clubs, Rank.Seven)
        };

            var result = _gameService.CheckResult(player, opponent, community);
            Assert.That(result, Is.EqualTo("Player wins"));
        }

        // High Card
        [Test]
        public void CheckResult_PlayerHasHighCard_Wins()
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
            var community = new List<Card>
        {
            new Card(Suit.Clubs, Rank.Two),
            new Card(Suit.Spades, Rank.Three),
            new Card(Suit.Diamonds, Rank.Four),
            new Card(Suit.Hearts, Rank.Five),
            new Card(Suit.Clubs, Rank.Seven)
        };

            var result = _gameService.CheckResult(player, opponent, community);
            Assert.That(result, Is.EqualTo("Player wins"));
        }
    }
}