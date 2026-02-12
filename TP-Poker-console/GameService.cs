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

        public GameService(IUserService userService)
        {
            _userService = userService;
        }

        public void RunGame()
        {
            Console.WriteLine("Welcome to the Poker Game!");
            Console.WriteLine("Enter your name...");

            var name = Console.ReadLine();
            var deck = Deck.CreateDeck();

            var user = _userService.CreateUser(name);

            Console.WriteLine($"Hello, {user.Name}! Let's start the game.");
        }
    }
}