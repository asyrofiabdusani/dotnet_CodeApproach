using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CodeFirstApproach.Filters;
using CodeFirstApproach.Models;

namespace CodeFirstApproach.Areas.Admin.Controllers
{
    [AdminAuthorization]
    public class CategoryController : Controller
    {
        public ActionResult Index(string search)
        {
            var db = new DbModel();

            List<Category> cat;
            if (search != null)
            {
                cat = db.Categories.Where(tmp => tmp.CategoryName.Contains(search)).ToList();
            }
            else
            {
                cat = db.Categories.ToList();

            }
            return View(cat);
        }

        public ActionResult Input()
        {
            ViewBag.alert = null;
            return View();
        }

        [HttpPost]
        public ActionResult Input(Category category)
        {
            var db = new DbModel();
            db.Categories.Add(category);
            if (ModelState.IsValid)
            {
                db.SaveChanges();
            }
            else
            {
                ViewBag.alert = "There is something wrong";
                return View("input");
            }

            return RedirectToAction("Index");
        }

        public ActionResult Edit(string id)
        {
            var db = new DbModel();
            if (id != null)
            {
                var cat = db.Categories.Where(tmp => tmp.CategoryId.Equals(id)).FirstOrDefault();
                return View(cat);
            }
            else
            {
                return RedirectToAction("index");
            }
        }

        [HttpPost]
        public ActionResult Edit(Category input)
        {
            var db = new DbModel();
            Category existCat = db.Categories.Where(tmp => tmp.CategoryId.Equals(input.CategoryId)).FirstOrDefault();
            existCat.CategoryName = input.CategoryName;
            db.SaveChanges();

            return RedirectToAction("index");
        }

        public ActionResult Delete(string id)
        {
            var db = new DbModel();
            Category existCat = db.Categories.Where(tmp => tmp.CategoryId.Equals(id)).FirstOrDefault();
            db.Categories.Remove(existCat);
            db.SaveChanges();

            return RedirectToAction("index");
        }
    }
}