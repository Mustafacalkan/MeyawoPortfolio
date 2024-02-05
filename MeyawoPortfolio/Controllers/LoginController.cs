using MeyawoPortfolio.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;


namespace MeyawoPortfolio.Controllers
{
	public class LoginController : Controller
	{
		DbMyPortfolioEntities2 db = new DbMyPortfolioEntities2();
		[HttpGet]
		public ActionResult Login()
		{
			return View();
		}
		[HttpPost]
		public ActionResult Login(TblAdminPanel p)
		{
			var bilgiler = db.TblAdminPanel.FirstOrDefault(x => x.Kullanici == p.Kullanici &&
			x.Sifre == p.Sifre);
			if (bilgiler == null)
			{
				FormsAuthentication.SetAuthCookie(bilgiler.Kullanici, false);
				Session["Kullanici"] = bilgiler.Kullanici;
				return RedirectToAction("Dashboard","Index");
			}
			else
			{
				return RedirectToAction("Dashboard", "Index");
			}
			//return View();

		}
	}
}