using System.Collections.Generic;
using System.Linq;

namespace MvcAuth.Models
{
    public class UserManager
    {
        private List<User> _users = new List<User>();

        public UserManager()
        {
            _users.Add(new User()
            {
                Username = "bill",
                Password = "gates",
                Roles = new[] {"admin", "owner"}
            });

            _users.Add(new User()
            {
                Username = "steve",
                Password = "ballmer",
                Roles = new[] { "developers" }
            });

            _users.Add(new User()
            {
                Username = "satya",
                Password = "nadella",
                Roles = new[] { "ceo", "admin" }
            });

            _users.Add(new User()
            {
                Username = "share",
                Password = "point",
                Roles = new[] { "developers" }
            });
        }

        public User Login(string username, string password)
        {
            return _users.FirstOrDefault(u => u.Username == username && u.Password == password);
        }

        public bool UserExists(string username)
        {
            return _users.Any(u => u.Username == username);
        }
    }
}