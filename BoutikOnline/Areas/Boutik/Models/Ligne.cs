using AdopteUneDev.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BoutikOnline.Areas.Boutik.Models
{
    public class Ligne
    {
        private Developer _zeDave;
        private int _qte;
        private int _choix;

        public Developer ZeDave
        {
            get { return _zeDave; }
            set { _zeDave = value; }
        }

        public int Qte
        {
            get { return _qte; }
            set { _qte = value; }
        }

        public int Choix
        {
            get { return _choix; }
            set { _choix = value; }
        }

        public Double TotalLigne
        {
            get { return Total(); }
        }

        private Double Total()
        {
            return (Choix * Qte);
        }

    }
}