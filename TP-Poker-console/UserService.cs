using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP_Poker_console
{
    public class UserService : IUserService
    {
        private IDeck _deck;

        public UserService(IDeck deck)
        {
            _deck = deck;
        }

        public User CreateUser(string name)
        {
            User user = new User();
            user.Name = name;
            return user;
        }

        public void DrawUserCards(User user)
        {
            if (user.Card1 == null)
            {
                user.Card1 = _deck.Draw();
            }

            if (user.Card2 == null)
            {
                user.Card2 = _deck.Draw();
            }
        }

        public IDeck Deck
        {
            get; set;
        }
    }
}