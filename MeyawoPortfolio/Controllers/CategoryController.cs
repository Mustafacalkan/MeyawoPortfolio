using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MeyawoPortfolio.Models;

namespace MeyawoPortfolio.Controllers
{
    public class CategoryController : Controller
    {
		DbMyPortfolioEntities2 db = new DbMyPortfolioEntities2();
		public ActionResult Index()
        {
            var values = db.TblCategory.ToList();
            return View(values);
        }
        public ActionResult CreateCategory()
        {
            return View();
        }
        [HttpPost]
        public ActionResult CreateCategory(TblCategory Category)
        {
            db.TblCategory.Add(Category);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult DeleteCategory(int id)
        {
            var value =db.TblCategory.Find(id);
            db.TblCategory.Remove(value);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult UpdateCategory(int id)
        {
            var value = db.TblCategory.Find(id);
            return View(value);
        }
        [HttpPost]
        public ActionResult UpdateCategory(TblCategory model)
        {
            var value = db.TblCategory.Find(model.CategoryID);
            value.CategoryName = model.CategoryName;
            db.SaveChanges();
            return RedirectToAction("Index");

        }
        public ActionResult Index2()
        { 
            return View(); 
        }
    }
}