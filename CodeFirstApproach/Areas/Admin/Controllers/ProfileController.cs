using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CodeFirstApproach.Filters;
using CodeFirstApproach.Identity;
using Microsoft.AspNet.Identity;

namespace CodeFirstApproach.Areas.Admin.Controllers
{
    [AdminAuthorization]
    public class ProfileController : Controller
    {

        public ActionResult Index()
        {
            var appDbContext = new ApplicationDbContext();
            var appUserStore = new ApplicationUserStore(appDbContext);
            var userManager = new ApplicationUserManager(appUserStore);

            ApplicationUser appUser = userManager.FindById(User.Identity.GetUserId());
            return View(appUser);
        }
    }
}