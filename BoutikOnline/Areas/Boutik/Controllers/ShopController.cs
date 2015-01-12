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
           return View();
        }
	}
}