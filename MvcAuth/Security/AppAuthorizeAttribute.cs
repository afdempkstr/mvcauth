using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using MvcAuth.Models;

namespace MvcAuth.Security
{
    public class AppAuthorizeAttribute : AuthorizeAttribute
    {
        public override void OnAuthorization(AuthorizationContext filterContext)
        {
            var httpContext = HttpContext.Current;
            var username = string.Empty;

            if (httpContext?.Session != null)
            {
                if (httpContext.Session["user"] is User user)
                {
                    username = user.Username;
                }
            }

            if (string.IsNullOrWhiteSpace(username))
            {
                filterContext.Result = new RedirectToRouteResult(new
                    RouteValueDictionary(new
                    {
                        controller = "Login",
                        action = "Index"
                    }));
            }
            else
            {
                UserManager userManager = new UserManager();
                ApplicationPrincipal principal = new ApplicationPrincipal(userManager.Find(username));
                if (!principal.IsInRole(Roles))
                    filterContext.Result = new RedirectToRouteResult(new
                        RouteValueDictionary(new
                        {
                            controller = "Login",
                            action = "AccessDenied"
                        }));
            }
        }
    }
}