using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MeyawoPortfolio.Models;

namespace MeyawoPortfolio.Controllers
{
 	public class StatisticController : Controller
    {    
        DbMyPortfolioEntities2 db = new DbMyPortfolioEntities2();
        public ActionResult Index()
        {
			ViewBag.categoryCount = db.TblCategory.Count();
			ViewBag.projectCount = db.TblProject.Count();
			ViewBag.messageCount = db.TblContact.Count();
			ViewBag.fluteterProjectCount = db.TblProject.Where(x => x.ProjectCategory == 1).Count();
			ViewBag.ısnotReadMessageCount = db.TblContact.Where(x => x.IsRead == false).Count();
            ViewBag.lastProjectName = db.LastProjectName().FirstOrDefault();

			ViewBag.serviceCount = db.TblService.Count();
			ViewBag.socialMedias = db.TblSocialMedia.Count();
			ViewBag.testimonials = db.TblTestimonial.Count();
			ViewBag.csharpProcectCount = db.TblProject.Where(x => x.ProjectCategory == 1).Count();
			return View();
        }
    }
}