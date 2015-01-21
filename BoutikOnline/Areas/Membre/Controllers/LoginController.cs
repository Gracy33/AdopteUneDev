using AdopteUneDev.DAL;
using BoutikOnline.Areas.Boutik.Models;
using BoutikOnline.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BoutikOnline.Areas.Membre.Controllers
{
    public class LoginController : Controller
    {
        //
        // GET: /Membre/Login/
        [HttpGet]
        public ActionResult LoginForm()
        {
            return View();
        }

        [HttpPost]
        public ActionResult LoginForm(string txtLogin, string txtPassword)
        {
            Client cli = Client.AuthentifieMoi(txtLogin, txtPassword);
            if (cli == null)
            {
                ViewBag.ErrorLogin = "Erreur Login/Password";
                return View();
            }
            else
            {
                SessionTools.Login = cli.CliUsername;
                SessionTools.Client = cli;
                return RedirectToRoute(new { controller = "Home", action = "Index" });
            }
        }

        public ActionResult LogOut()
        {
            SessionTools.Login = null;
            Session.Abandon();

            return RedirectToRoute(new { controller = "Home", action = "Index" });
        }

        [HttpPost]
        public ActionResult Inscription(string txtName, string txtFirstName, string txtEmail )
        {
            Newuser u = new Newuser()
            {
                cliName = txtName,
                cliFirstName = txtFirstName,
                cliMail = txtEmail
            };
                                
            return View(u);
        }

        [HttpPost]
        public ActionResult InscriptionPlus(string txtName, string txtFirstName, string txtEmail, string txtCompany, string txtLogin, string txtPassword)
        {
            Client c = new Client();
            c.saveMe(txtName, txtFirstName, txtEmail, txtCompany, txtLogin, txtPassword);
            //ViewBag.Message = "Vous pouvez vous connecter";
            return RedirectToRoute(new {area= "Membre", controller = "Login", action = "LoginForm" });
        }
    }
}