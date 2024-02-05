using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MeyawoPortfolio.Models;

namespace MeyawoPortfolio.Controllers
{
    public class DashboardController : Controller
    {
        DbMyPortfolioEntities2 db = new DbMyPortfolioEntities2 ();
		//[Authorize]
		public ActionResult Index()
        {
			ViewBag.serviceCount = db.TblService.Count();
			ViewBag.projectCount = db.TblProject.Count();
			ViewBag.messageCount = db.TblContact.Count();
			ViewBag.testimonialCount = db.TblTestimonial.Count();
			return View();
			
        }
    }
}