using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdopteUneDev.DAL
{
    public class Categories
    {
        #region Fields
        private int _idCategory;
        private string _categLabel;
        private List<ITLang> _itLangs;
        #endregion

        #region Properties
        public int IdCategory
        {
            get { return _idCategory; }
            set { _idCategory = value; }
        }

        public string CategLabel
        {
            get { return _categLabel; }
            set { _categLabel = value;}
        }

        public List<ITLang> ItLangs
        {
            get 
            {
                if (_itLangs == null) _itLangs = ChargerLesITLangs();

                return _itLangs; 
                // return _itLangs = _itLangs?? ChargerLesITLangs();
            }
        }
        #endregion

        #region Method Static

        private List<ITLang> ChargerLesITLangs()
        {
            string query = @"select i.idIT, i.ITLabel from ITLang i 
                             inner join LangCateg c 
                             on c.idIT = i.idIT 
                             where c.idCategory =" + this.IdCategory;

            List<ITLang> retour = new List<ITLang>();
            List<Dictionary<string, object>> MesLang = GestionConnexion.Instance.getData(query);         
            foreach (Dictionary<string, object> item in MesLang)
            {
                ITLang l = new ITLang();
                l.IdIT = (int)item["idIT"];
                l.ITLabel = item["ITLabel"].ToString();
                retour.Add(l);
            }

            return retour;
        }

        public static Categories ChargerUneCategorie(int idCateg)
        {
            List<Dictionary<string, object>> uneCateg = GestionConnexion.Instance.getData("select * from Categories where idCategory=" + idCateg);
            Categories categ = Associe(uneCateg[0]);
            return categ;    
        }

        public static List<Categories> ChargerToutesLesCategories()
        {
            List<Dictionary<string, object>> lstCateg = GestionConnexion.Instance.getData("select * from Categories");
            List<Categories> listCateg = new List<Categories>();
            foreach (Dictionary<string, object> item in lstCateg)
            {
                Categories categ = Associe(item);
                listCateg.Add(categ);
            }
            return listCateg;
        }

        private static Categories Associe(Dictionary<string, object> item)
        {
            Categories categ = new Categories()
            {
                IdCategory = int.Parse(item["idCategory"].ToString()),
                CategLabel = item["CategLabel"].ToString() 
            };
            return categ;
        }
        #endregion
    }
}
