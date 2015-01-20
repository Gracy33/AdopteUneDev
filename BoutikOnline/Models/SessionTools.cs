using AdopteUneDev.DAL;
using BoutikOnline.Areas.Boutik.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BoutikOnline.Models
{
    public static class SessionTools
    {
        public static Panier Panier
        {
            get 
            {
                if (HttpContext.Current.Session["Panier"] == null)
                {
                    HttpContext.Current.Session["Panier"] = new Panier();
                }

                //HttpContext = Contexte dans lequel s'execute l'application. Dialogue entre serveur et client
                return (Panier)HttpContext.Current.Session["Panier"]; 
            }
            set 
            {
                HttpContext.Current.Session["Panier"] = value;
            }
        }

        public static string Login
        {
            get
            {
                try{
                    return HttpContext.Current.Session["login"].ToString();
                }
                catch
                {
                    return null;
                }
            }

            set 
            {
                HttpContext.Current.Session["login"] = value;
            }
        }

        public static Client Client
        {
            get { return (Client)HttpContext.Current.Session["user"]; }
            set { HttpContext.Current.Session["user"] = value; }
        }
    }
}