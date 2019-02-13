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
        public bool IsInRole(string role)
        {
            var httpContext = HttpContext.Current;
            if (httpContext == null)
            {
                return false;
            }

            if (httpContext.Session != null)
            {
                if (httpContext.Session["user"] is User user)
                {
                    //TODO: check if the user has the requested role
                }
            }

            return false;
        }

        public IIdentity Identity { get; }
    }
}