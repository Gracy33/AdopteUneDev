﻿using AdopteUneDev.DAL;
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
                
	}
}