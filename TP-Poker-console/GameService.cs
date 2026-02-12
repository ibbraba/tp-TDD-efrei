using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP_Poker_console
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
        }
    }
}