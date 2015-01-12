using AdopteUneDev.DAL;
using BoutikOnline.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BoutikOnline.Controllers
{
    public class DevController : Controller
    {
        //
        // GET: /Dev/
        public ActionResult Details(int id)
        {
            Session["CurrentController"] = this;

            BoiteLangCateg langCateg = new BoiteLangCateg();
            langCateg.LstCateg = Categories.ChargerToutesLesCategories();
            langCateg.LstLang = ITLang.ChargerLangues();
            langCateg.LstDev = Developer.ChargerTous();
            langCateg.SelectedDev = Developer.getInfo(id);
            return View(langCateg);
        }

        [HttpPost]
        public ActionResult postReview(int id, string txtName, string txtMail, string txtText)
        {
            Review.AddReview(id, txtName, txtMail, txtText);
            return new RedirectResult("/Dev/Details/" + id);
        }
	}
}