using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CodeFirstApproach.Identity;
using CodeFirstApproach.ViewModels;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity;
using System.Web.Helpers;
using Microsoft.Owin.Security;
using System.Web.Security;

namespace CodeFirstApproach.Controllers
{
    [OverrideAuthentication]
    public class AccountController : Controller
    {
        // GET: Account
        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Register(RegisterViewModel Input)
        {
            if (ModelState.IsValid)
            {
                var appDbContext = new ApplicationDbContext();
                var appUserStore = new ApplicationUserStore(appDbContext);
                var userManager = new ApplicationUserManager(appUserStore);

                var passHash = Crypto.HashPassword(Input.Password);
                var user = new ApplicationUser()
                {
                    Email = Input.Email,
                    UserName = Input.UserName,
                    PasswordHash = passHash,
                };
                IdentityResult result = userManager.Create(user);

                if (result.Succeeded)
                {
                    userManager.AddToRole(user.Id, "User");

                    var authManager = HttpContext.GetOwinContext().Authentication;
                    var userIdentity = userManager.CreateIdentity(user, DefaultAuthenticationTypes.ApplicationCookie);
                    authManager.SignIn(new AuthenticationProperties(), userIdentity);

                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    ViewBag.error = result.Errors.First();
                    return View();
                }
            }
            else
            {
                ModelState.AddModelError("MyError", "Invalid Data");
                return View();
            }

        }

        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(LoginViewModel input)
        {
            if (ModelState.IsValid)
            {
                var appDbContext = new ApplicationDbContext();
                var appUserStore = new ApplicationUserStore(appDbContext);
                var userManager = new ApplicationUserManager(appUserStore);

                var user = userManager.Find(input.UserName, input.Password);
                if (user != null)
                {
                    var authManager = HttpContext.GetOwinContext().Authentication;
                    var userIdentity = userManager.CreateIdentity(user, DefaultAuthenticationTypes.ApplicationCookie);
                    authManager.SignIn(new AuthenticationProperties(), userIdentity);

                    var role = userManager.GetRoles(user.Id);
                    if (userManager.GetRoles(user.Id)[0].Equals("User"))
                    {
                        return RedirectToAction("Index", "Product");
                    }
                    else
                    {
                        return RedirectToAction("Index", "Home", new { area = "admin" });
                    }
                }
                else
                {
                    ViewBag.Error = "Username/password is wrong";
                    return View();
                }
            }
            return View();
        }

        public ActionResult Logout()
        {
            var authManager = HttpContext.GetOwinContext().Authentication;
            authManager.SignOut();
            return RedirectToAction("login", "account");
        }
    }
}