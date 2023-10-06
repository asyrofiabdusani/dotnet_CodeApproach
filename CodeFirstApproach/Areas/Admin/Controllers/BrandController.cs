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
    public class BrandController : Controller
    {
        public ActionResult Index(string search)
        {
            var db = new DbModel();

            List<Brand> brands;
            if (search != null)
            {
                brands = db.Brands.Where(tmp => tmp.BrandName.Contains(search)).ToList();
            }
            else
            {
                brands = db.Brands.ToList();

            }
            return View(brands);
        }

        public ActionResult Input()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Input(Brand brand)
        {
            var db = new DbModel();
            db.Brands.Add(brand);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult Edit(string id)
        {
            var db = new DbModel();
            if (id != null)
            {
                var brand = db.Brands.Where(tmp => tmp.BrandId.Equals(id)).FirstOrDefault();
                return View(brand);
            }
            else
            {
                return RedirectToAction("index");
            }
        }

        [HttpPost]
        public ActionResult Edit(Brand input)
        {
            var db = new DbModel();
            Brand existBrand = db.Brands.Where(tmp => tmp.BrandId.Equals(input.BrandId)).FirstOrDefault();
            existBrand.BrandName = input.BrandName;
            db.SaveChanges();

            return RedirectToAction("index");
        }

        public ActionResult Delete(string id)
        {
            var db = new DbModel();
            Brand existBrand = db.Brands.Where(tmp => tmp.BrandId.Equals(id)).FirstOrDefault();
            db.Brands.Remove(existBrand);
            db.SaveChanges();

            return RedirectToAction("index");
        }
    }
}