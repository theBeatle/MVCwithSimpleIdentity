using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security;
using MVCwithSimpleIdentity.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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

        [HttpGet]
        public ActionResult Register()
        {
            return View();
        }


        [HttpPost]
        public async Task<ActionResult> Register(RegisterModel model)
        {
            if (ModelState.IsValid)
            {
                ApplicationUser user = new ApplicationUser
                {
                    BirthDay = model.BirthDay,
                    UserName = model.Email,
                    Name = model.Name,
                    Surname = model.Surname,
                    Email = model.Email
                };
                var result = await UserManager.CreateAsync(user, model.Password);
                if (result.Succeeded)
                {
                    return RedirectToAction("Login", "Account");
                }
                else
                {
                    foreach (var item in result.Errors)
                    {
                        ModelState.AddModelError("", item);
                    }
                }
            }
            return View(model);
        }

        [HttpGet]
        public ActionResult Login(string returnUrl)
        {
            ViewBag.returnUrl = returnUrl;
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Login(LoginModel model, string returnUrl)
        {
            if (ModelState.IsValid)
            {
                var user = await UserManager.FindAsync(model.Email, model.Password);
                if (user == null)
                {
                    ModelState.AddModelError("", "Login or Password is invalid!");
                }
                else
                {
                    var identityUser = await UserManager.CreateIdentityAsync(user, DefaultAuthenticationTypes.ApplicationCookie);
                    AuthManager.SignOut();
                    AuthManager.SignIn(new AuthenticationProperties { IsPersistent = true }, identityUser);
                    if (String.IsNullOrEmpty(returnUrl))
                    {
                        RedirectToAction("Index", "Home");
                    }
                    return Redirect(returnUrl);
                }
            }

            ViewBag.returnUrl = returnUrl;
            return View(model);
        }

        [HttpGet]
        public ActionResult Logout()
        {
            AuthManager.SignOut();
            return RedirectToAction("Index", "Home");
        }


        public ActionResult LoadUser()
        {
            //var userToFind = await UserManager.FindByEmailAsync(User.Identity.Name);

            var userToFind =
                Task.Run(async ()
                    => { await UserManager.FindByEmailAsync(User.Identity.Name); });
            var user = userToFind.Wait();

            if (userToFind == null)
                return PartialView("_PartialLoginView", null);
            else
                return PartialView("_PartialLoginView",
                    new SmallUserModel { Name = userToFind.Name, Surname = userToFind.Surname });
        }


    }
}