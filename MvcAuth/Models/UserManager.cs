using Microsoft.AspNet.Identity;
using Microsoft.Owin.Security;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Web;

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
            var loggedInUser = _users.FirstOrDefault(u => u.Username == username && u.Password == password);
            if (loggedInUser != null)
            {
                var claims = new List<Claim>(new[]
                {
                    // adding following 2 claim just for supporting default antiforgery provider
                    new Claim(ClaimTypes.NameIdentifier, username),
                    new Claim(
                        "http://schemas.microsoft.com/accesscontrolservice/2010/07/claims/identityprovider",
                        "ASP.NET Identity", "http://www.w3.org/2001/XMLSchema#string"),
                    new Claim(ClaimTypes.Name, username)
                });

                foreach (var role in loggedInUser.Roles)
                {
                    claims.Add(new Claim(ClaimTypes.Role, role));
                }

                var identity = new ClaimsIdentity(claims, DefaultAuthenticationTypes.ApplicationCookie);

                HttpContext.Current.GetOwinContext().Authentication.SignIn(
                    new AuthenticationProperties { IsPersistent = false }, identity);
            }

            return loggedInUser;
        }

        public bool UserExists(string username)
        {
            return _users.Any(u => u.Username == username);
        }
    }
}