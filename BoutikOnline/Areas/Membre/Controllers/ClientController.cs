using AdopteUneDev.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BoutikOnline.Areas.Membre.Controllers
{
    public class ClientController : Controller
    {
        //
        // GET: /Membre/Client/
        public ActionResult Index()
        {
            List<Client> maListe = Client.ChargerTous();
            return View(maListe);
        }

        public ActionResult Fiche(int id)
        {
            Client c = Client.getInfo(1);
            return View(c);
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            Client c = Client.getInfo(id);
            return View(c);
        }

        [HttpPost]
        public ActionResult Edit(Client c)
        {
            c.saveMe();
            return View(c);
        }
	}
}