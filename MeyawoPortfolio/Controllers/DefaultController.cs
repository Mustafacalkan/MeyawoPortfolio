using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MeyawoPortfolio.Models;

namespace MeyawoPortfolio.Controllers
{
    public class DefaultController : Controller
    {
        DbMyPortfolioEntities2 db = new DbMyPortfolioEntities2();
        public ActionResult Index()
        {
            return View();
        }
        public PartialViewResult HeadPartial()
        {
            return PartialView();
        }
        public PartialViewResult NavbarPartial()
        {
            return NavbarPartial();
        }
        public PartialViewResult FeaturePartial()
        {
            var values = db.TblFuture.ToList();
            return PartialView(values);
        }
        public PartialViewResult AboutPartial()
        {
            var values = db.TblAbout.ToList();
            return PartialView(values);
        }
        public PartialViewResult ServicePartial()
        {
            var values = db.TblService.ToList();
            return PartialView(values);
        }
        public PartialViewResult PortfolioPartial()
        {
            return PortfolioPartial();
        }
        public PartialViewResult TestimonialPartial()
        {
            var values = db.TblTestimonial.ToList();
            return PartialView(values);
        }
        public PartialViewResult ContactPartial()
        {
            //buraya veri göndermene gerek yok ki neyi listeliyosun burada ? 
            var values = db.TblContact.ToList();
            return PartialView(values);
        }
        public PartialViewResult ContainerPartial()
        {
            return ContainerPartial();
        }
        public PartialViewResult CorePartial()
        {
            return CorePartial();
        }
        [HttpPost]
        public ActionResult SendMessage(TblContact model)
        {
            model.SendDate = DateTime.Now;
            model.IsRead = false;
            db.TblContact.Add(model);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

	}
}