using AdopteUneDev.DAL;
using BoutikOnline.Areas.Boutik.Models;
using BoutikOnline.Areas.Membre.Models;
using BoutikOnline.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BoutikOnline.Areas.Boutik.Controllers
{
    public class PanierController : Controller
    {
        //
        // GET: /Boutik/Panier/
        public ActionResult Index()
        {
            return View("AddToBasket", SessionTools.Panier);
        }

        [HttpPost]
        public ActionResult AddToBasket(int id, int qte, int choix)
        {
            Developer dave = Developer.getInfo(id);
            if (SessionTools.Panier.Lignes.Where(li => li.ZeDave.IdDev == id).Count() > 0)
            {
                SessionTools.Panier.Lignes.Where(li => li.ZeDave.IdDev == id).FirstOrDefault().Qte += qte;
            }
            else
            {
                Ligne l = new Ligne() { ZeDave = dave, Qte = qte, Choix = choix };
                SessionTools.Panier.Lignes.Add(l);
            }
            return View("AddToBasket", SessionTools.Panier);
        }


        [HttpGet]
        public ActionResult AddToBasket(int id, int qte, bool op)
        {
            if (SessionTools.Panier.Lignes.Where(li => li.ZeDave.IdDev == id).Count() > 0)
            {
                if (op)
                {
                    SessionTools.Panier.Lignes.Where(li => li.ZeDave.IdDev == id).FirstOrDefault().Qte += qte;
                }
                else
                {
                    SessionTools.Panier.Lignes.Where(li => li.ZeDave.IdDev == id).FirstOrDefault().Qte -= qte;
                }

                if (SessionTools.Panier.Lignes.Where(li => li.ZeDave.IdDev == id).FirstOrDefault().Qte < 1) SessionTools.Panier.Lignes.Remove(SessionTools.Panier.Lignes.Where(li => li.ZeDave.IdDev == id).FirstOrDefault());
            }
            return View("AddToBasket", SessionTools.Panier);
        }

        [HttpPost]
        public ActionResult Supprimer(int id)
        {
            //Ligne ligne = null;

            //foreach (Ligne l in SessionTools.Panier.Lignes)
            //{
            //    if (l.ZeDave.IdDev == id)
            //    {
            //        ligne = l;
            //    }
            //}
            //SessionTools.Panier.Lignes.Remove(ligne);

            /*Version LINQ*/
            SessionTools.Panier.Lignes.RemoveAll(li => li.ZeDave.IdDev == id);

            return View("AddToBasket", SessionTools.Panier);
        }
        [HttpGet]
        public ActionResult CheckOut()
        {
            if (SessionTools.Login == null)
            {
                return RedirectToRoute(new { area = "Membre", controller = "Login", action = "LoginForm" }); //Renvoie à la page de login
            }
            else
            {
                /*Enregistrement du Panier et du Client dans le model PanierUser*/
                PanierUser checkOut = new PanierUser()
                {
                    Panier = SessionTools.Panier,
                     Client = SessionTools.Client
                };

                return View("CheckOut", checkOut); //Renvoie à la vue CheckOut
            }

        }
    }
}