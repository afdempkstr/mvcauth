using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Web;
using MvcAuth.Models;

namespace MvcAuth.Security
{
    public class ApplicationPrincipal : IPrincipal
    {
        private User _user;

        public ApplicationPrincipal(User user)
        {
            _user = user;
        }

        public bool IsInRole(string role)
        {
            var roles = role.Split(new[] {','}, StringSplitOptions.RemoveEmptyEntries);

        }

        public IIdentity Identity { get; }
    }
}