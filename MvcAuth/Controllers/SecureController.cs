using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcAuth.Security;

namespace MvcAuth.Controllers
{
    public class SecureController : Controller
    {
        // GET: Secure
        [AppAuthorize(Roles="users,admin,developers,owner")]
        public ActionResult Index()
        {
            return View();
        }
    }
}