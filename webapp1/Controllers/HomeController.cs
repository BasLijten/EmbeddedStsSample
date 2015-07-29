using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.IdentityModel.Services;

namespace webapp1.Controllers
{    
    public class HomeController : Controller
    {
        public ActionResult Index()
        {            
            return View();
        }

        [Authorize]
        public ActionResult Login()
        {            
            return RedirectToAction("Index");
        }

        public ActionResult Logout()
        {
            FederatedAuthentication.WSFederationAuthenticationModule.SignOut();

            return RedirectToAction("Index");
        }
    }
}