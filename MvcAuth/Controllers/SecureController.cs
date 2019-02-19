using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcAuth.Controllers
{
    public class SecureController : Controller
    {
        // GET: Secure
        [Authorize(Roles="users,admin,developers,owner")]
        public ActionResult Index()
        {
            return View();
        }

        [Authorize(Roles="developers")]
        public ActionResult DevelopersOnly()
        {
            return View();
        }
    }
}