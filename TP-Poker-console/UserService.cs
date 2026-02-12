using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP_Poker_console
{
    public class UserService : IUserService
    {
        public User CreateUser(string name)
        {
            User user = new User();
            user.Name = name;
            return user;
        }

        public void DrawUserCard(User user)
        {
        }
    }
}