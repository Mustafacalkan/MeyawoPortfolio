using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.Xml;
using System.Web;
using System.Web.Mvc;
using MeyawoPortfolio.Models;

namespace MeyawoPortfolio.Controllers
{
	public class ProjectController : Controller
	{
		DbMyPortfolioEntities2 db = new DbMyPortfolioEntities2();
		public ActionResult Index()
		{
			var values = db.TblProject.ToList();
			return View(values);
		}
		[HttpGet]
		public ActionResult CreateProject()
		{
			List<SelectListItem> values = (from x in db.TblCategory.ToList()
				                           select new SelectListItem
										   {
											   Text= x.CategoryName,
											   Value=x.CategoryID.ToString()
										   }).ToList();
			ViewBag.v=values;
			return View();
		}
		[HttpPost]
		public ActionResult CreateProject(TblProject Create)
		{
			db.TblProject.Add(Create);
			db.SaveChanges();
			return RedirectToAction("Index");
		}

		public ActionResult DeleteProject(int id)
		{
			var value = db.TblProject.Find(id);
			db.TblProject.Remove(value);
			db.SaveChanges();
			return RedirectToAction("Index");
		}
		[HttpGet]
		public ActionResult UpdateProject(int id)
		{
			List<SelectListItem> values = (from x in db.TblCategory.ToList()
										   select new SelectListItem
										   {
											   Text = x.CategoryName,
											   Value = x.CategoryID.ToString()
										   }).ToList();
			ViewBag.v = values;
			var value = db.TblProject.Find(id);
			return View(value);
		}

		[HttpPost]
		public ActionResult UpdateProject(TblProject p)
		{
			var value = db.TblProject.Find(p.ProjectID);
			value.Title = p.Title;
			value.Description = p.Description;
			value.ImageUrl = p.ImageUrl;
			value.ProjectUrl = p.ProjectUrl;
			value.ProjectCategory = p.ProjectCategory;
			db.SaveChanges();
			return RedirectToAction("Index");
		}
		public ActionResult Explanation(int id)
		{ 
			var value =db.TblProject.Find(id);
			return View(value);
		}

	}
}