using AdopteUneDev.DAL;
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
            Developer dev = Developer.getInfo(id);
            return View(dev);
        }
	}
}