using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MeyawoPortfolio.Models;

namespace MeyawoPortfolio.Controllers
{
    public class FutureController : Controller
    {
        DbMyPortfolioEntities2 db = new DbMyPortfolioEntities2();
		public ActionResult Index()
		{
			var values = db.TblFuture.ToList();
			return View(values);
		}
		[HttpGet]
		public ActionResult CreateFuture()
		{
			return View();
		}
		[HttpPost]
		public ActionResult CreateFuture(TblFuture p)
		{
			db.TblFuture.Add(p);
			db.SaveChanges();
			return RedirectToAction("Index");
		}
		public ActionResult DeleteFuture(int id)
		{
			var value = db.TblFuture.Find(id);
			db.TblFuture.Remove(value);
			db.SaveChanges();
			return RedirectToAction("Index");
		}
		[HttpGet]
		public ActionResult UpdateFuture(int id)
		{
			var value1 = db.TblFuture.Find(id);
			return View(value1);
		}
		[HttpPost]
		public ActionResult UpdateFuture(TblFuture p)
		{
			var value1 = db.TblFuture.Find(p.FutureID);
			value1.Header = p.Header;
			value1.NameSurname = p.NameSurname;
			value1.Title = p.Title;
			db.SaveChanges();
			return RedirectToAction("Index");
		}


	}
}