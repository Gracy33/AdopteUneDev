using AdopteUneDev.DAL;
using BoutikOnline.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BoutikOnline.Areas.Boutik.Controllers
{
    public class ShopController : Controller
    {
        //
        // GET: /Boutik/Shop/
        public ActionResult Index()
        {
            List<Developer> maListe = Developer.ChargerTous();
            return View(maListe);
        }

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
	}
}