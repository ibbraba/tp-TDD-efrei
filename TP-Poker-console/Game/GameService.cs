using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TP_Poker_console.Deck;
using TP_Poker_console.User;

namespace TP_Poker_console.Game
{
    public class GameService : IGameService
    {
        private IUserService _userService;
        private IDeck _deck;

        public GameService(IUserService userService, IDeck deck)
        {
            _userService = userService;
            _deck = deck;
        }

        public void RunGame()
        {
            Console.WriteLine("Welcome to the Poker Game!");
            Console.WriteLine("Enter your name...");

            var name = Console.ReadLine();

            var user = _userService.CreateUser(name);
            Console.WriteLine($"Hello, {user.Name}! Let's start the game.");

            _deck.ShuffleCards();
            _userService.DrawUserCards(user);
            Console.WriteLine($"Your cards are: {user.Card1} and {user.Card2}");

            var oppenent = _userService.CreateUser("Opponent");
            _userService.DrawUserCards(oppenent);
            Console.WriteLine($"Opponent's cards are: {oppenent.Card1} and {oppenent.Card2}");

            var communityCards = DrawCommunityCards(); Console.WriteLine("Community cards are:");
        }

        public List<Card> DrawCommunityCards()
        {
            List<Card> communityCards = new List<Card>(); for (int i = 0; i < 5; i++) { communityCards.Add(_deck.Draw()); }
            return communityCards;
        }

        public string CheckResult(User.User player, User.User opponent, List<Card> communityCards)
        {
            var playerResult = PokerHandEvaluator.EvaluateHand(new List<Card> { player.Card1, player.Card2 }, communityCards);
            var opponentResult = PokerHandEvaluator.EvaluateHand(new List<Card> { opponent.Card1, opponent.Card2 }, communityCards);

            int comparison = playerResult.CompareTo(opponentResult);

            if (comparison > 0) return "Player wins";
            if (comparison < 0) return "Opponent wins";
            return "Tie";
        }
    }
}