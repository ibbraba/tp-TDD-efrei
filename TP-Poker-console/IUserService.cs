using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP_Poker_console
{
    public interface IUserService
    {
        public User CreateUser(string name);

        public void DrawUserCards(User user);
    }
}