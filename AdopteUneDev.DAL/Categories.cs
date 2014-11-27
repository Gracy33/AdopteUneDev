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
        private int _idCateg;
        private string _categLabel;

        #endregion

        #region Properties
        public int IdCateg
        {
            get { return _idCateg; }
            set { _idCateg = value; }
        }

        public string CategLabel
        {
            get { return _categLabel; }
            set { _categLabel = value;}
        }
        #endregion

        #region Method Static
        public static Categories getCateg(int idCateg)
        {
            List<Dictionary<string, object>> uneCateg = GestionConnexion.Instance.getData("select * from Client where idClient=" + idCateg);
            Categories categ = Associe(uneCateg[0]);
            return categ;    
        }

        public static List<Categories> getAllCateg()
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
                IdCateg = int.Parse(item["idCateg"].ToString()),
                CategLabel = item["categLabel"].ToString()
            };
            return categ;
        }
        #endregion
    }
}
