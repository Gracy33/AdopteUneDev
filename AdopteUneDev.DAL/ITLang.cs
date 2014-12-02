using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdopteUneDev.DAL
{
    public class ITLang
    {
        #region Fields
        private int _idIT;
        private string _itLabel;
        private List<Categories> _categories;
        private List<Developer> _developers;
        #endregion

        #region Properties
        public int IdIT
        {
            get { return _idIT; }
            set { _idIT = value; }
        }

        public string ITLabel
        {
            get { return _itLabel; }
            set { _itLabel = value; }
        }

        public List<Categories> Categories
        {
            get { return _categories = _categories ?? ChargerLesCategories(); }
        }

        public List<Developer> Developers
        {
            get { return _developers = _developers ?? ChargerLesDev(); }
        }
        #endregion

        #region Method Static

        private List<Categories> ChargerLesCategories()
        {
            string query = @"select * from Categories c 
                             inner join LangCateg l 
                             on l.idCategory = c.idCategory 
                             where l.idIT =" + this.IdIT;

            List<Categories> retour = new List<Categories>();
            List<Dictionary<string, object>> MesCat = GestionConnexion.Instance.getData(query);
            foreach (Dictionary<string, object> item in MesCat)
            {
                Categories cat = new Categories();
                cat.IdCategory = (int)item["idCategory"];
                cat.CategLabel = item["CategLabel"].ToString();
                retour.Add(cat);
            }

            return retour;
        }

        private List<Developer> ChargerLesDev()
        {
            string query = @"select dev.idDev, dev.DevName, dev.DevFirstName, dev.DevBirthDate, dev.DevPicture, dev.DevHourCost, dev.DevDayCost, dev.DevMonthCost, dev.DevMail from Developer dev 
                             inner join DevLang d 
                             on d.idDev = dev.idDev 
                             where d.idIT =" + this.IdIT;

            List<Developer> retour = new List<Developer>();
            List<Dictionary<string, object>> MesDev = GestionConnexion.Instance.getData(query);
            foreach (Dictionary<string, object> item in MesDev)
            {
                Developer dev = new Developer();
                dev.IdDev = (int)item["idDev"];
                dev.DevName = item["DevName"].ToString();
                dev.DevFirstName = item["DevFirstName"].ToString();
                dev.DevBirthDate = DateTime.Parse(item["DevBirthDate"].ToString());
                dev.DevPicture = item["DevPicture"] == null ? "" : item["DevPicture"].ToString();
                dev.DevHourCost = float.Parse(item["DevHourCost"].ToString());
                dev.DevDayCost = float.Parse(item["DevDayCost"].ToString());
                dev.DevMonthCost = float.Parse(item["DevMonthCost"].ToString());
                dev.DevMail = item["DevMail"].ToString();

                retour.Add(dev);
            }

            return retour;
        }


        public static ITLang ChargerUneLangue(int idLang)
        {
            List<Dictionary<string, object>> uneLangue = GestionConnexion.Instance.getData("select * from ITLang where idIT=" + idLang);
            return Associe(uneLangue[0]);
        }

        public static List<ITLang> ChargerLangues()
        {
            List<Dictionary<string, object>> lstLang = GestionConnexion.Instance.getData("select * from ITLang");
            List<ITLang> lang = new List<ITLang>();
            foreach (Dictionary<string, object> item in lstLang)
            {
                lang.Add(Associe(item));
            }
            return lang;
        }

        private static ITLang Associe(Dictionary<string, object> item)
        {
            ITLang lang = new ITLang()
            {
                IdIT = int.Parse(item["idIT"].ToString()),
                ITLabel = item["ITLabel"].ToString()
            };
            return lang;
        }
        #endregion
    }
}
