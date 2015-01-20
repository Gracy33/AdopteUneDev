using AdopteUneDev.DAL;
using BoutikOnline.Areas.Boutik.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BoutikOnline.Areas.Membre.Models
{
    public class PanierUser
    {
        /*Model utilisé dans la vue CheckOut pour récupérer le panier et le client courant*/
        private Panier _panier;
        private Client _client;
        public Panier Panier
        {
            get { return _panier = _panier ?? new Panier(); }
            set { _panier = value; }
        }

        public Client Client
        {
            get { return _client = _client ?? new Client(); }
            set { _client = value; }
        }
    }
}