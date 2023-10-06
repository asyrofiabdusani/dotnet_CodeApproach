using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CodeFirstApproach.Filters;

namespace CodeFirstApproach.Controllers
{
    [CustomerAuthorization]
    public class ProductController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }
    }
}