using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MvcAuth.Models
{
    public class UserManager
    {
        private List<User> _users = new List<User>();

        public UserManager()
        {
            // add users: bill / gates / admin,owner
            // steve / ballmer / developers
            // satya / nadella / ceo,admin
            // share / point / developers
        }

        public User Login(string username, string password)
        {
            throw new NotImplementedException();
        }

        public bool UserExists(string username)
        {
            return false;
        }
    }
}