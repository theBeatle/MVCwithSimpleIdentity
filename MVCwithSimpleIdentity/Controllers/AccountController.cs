using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security;
using MVCwithSimpleIdentity.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCwithSimpleIdentity.Controllers
{
    public class AccountController : Controller
    {
        private ApplicationUserManager UserManager
        {
            get => HttpContext.GetOwinContext().GetUserManager<ApplicationUserManager>();
        }

        private IAuthenticationManager AuthManager
        {
            get => HttpContext.GetOwinContext().Authentication;
        }

        [HttpPost]
        public ActionResult Register(RegisterModel model)
        {
           //TODO: add method body!!!
            return HttpNotFound();
        }

        [HttpPost]
        public ActionResult Login(LoginModel model, string returnUrl)
        {
            //TODO: add method body!!!
            return HttpNotFound();
        }







        // GET: Account
        public ActionResult Index()
        {
            return View();
        }
    }
}