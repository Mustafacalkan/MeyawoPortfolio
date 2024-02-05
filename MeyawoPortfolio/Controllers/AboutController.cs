using System;
using System.Collections.Generic;
using System.Data.Entity.Core.Objects;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MeyawoPortfolio.Models;

namespace MeyawoPortfolio.Controllers
{
	public class AboutController : Controller
	{
		DbMyPortfolioEntities2 db = new DbMyPortfolioEntities2();
		
		public ActionResult Index()
		{
			var values = db.TblAbout.ToList();
			return View(values);
		}
		[HttpGet]
		public ActionResult CreateAbout()
		{
			return View();
		}
		[HttpPost]
		public ActionResult CreateAbout(TblAbout Create)
		{
			db.TblAbout.Add(Create);
			db.SaveChanges();
			return RedirectToAction("Index");
		}
		public ActionResult DeleteAbout(int id)
		{
			var value = db.TblAbout.Find(id);
			db.TblAbout.Remove(value);
			db.SaveChanges();
			return RedirectToAction("Index");
		}
		public ActionResult UpdateAbout(int id)
		{
			var value = db.TblAbout.Find(id);
			return View(value);
		}
		[HttpPost]
		public ActionResult UpdateAbout(TblAbout model)
		{
			var value = db.TblAbout.Find(model.AboutID);
			value.Title = model.Title;
			value.Header = model.Header;
			value.Description = model.Description;
			value.ImageUrl = model.ImageUrl;
			db.SaveChanges();
			return RedirectToAction("Index");
		}

	}
}