using AdopteUneDev.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BoutikOnline.Controllers
{
    public class HomeController : Controller
    {
        //
        // GET: /Home/
        public ActionResult Index()
        {
            //List<Categories> lesCategories = Categories.ChargerToutesLesCategories();
            List<ITLang> leslangs = ITLang.ChargerLangues();
            return View(leslangs);
        }
	}
}