using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdopteUneDev.DAL
{
    public class Developer
    {
        #region Fields
        private int _idDev;
        private string _devName;
        private string _devFirstName;
        private DateTime _devBirthDate;
        private string _devPicture;
        private double _devHourCost;
        private double _devDayCost;
        private double _devMonthCost;
        private string _devMail;
        private string _nomCategPrincipale;
        private int _devCategPrincipale;
        public List<ITLang> _itLangs;
        public List<Review> _reviews;
        #endregion

        #region Properties
        public int IdDev
        {
            get { return _idDev; }
            set { _idDev = value; }
        }

        public string DevName
        {
            get { return _devName; }
            set { _devName = value; }
        }

        public string DevFirstName
        {
            get { return _devFirstName; }
            set { _devFirstName = value; }
        }

        public DateTime DevBirthDate
        {
            get { return _devBirthDate; }
            set { _devBirthDate = value; }
        }

        public string DevPicture
        {
            get { return _devPicture; }
            set { _devPicture = value; }
        }

        public double DevHourCost
        {
            get { return _devHourCost; }
            set { _devHourCost = value; }
        }

        public double DevDayCost
        {
            get { return _devDayCost; }
            set { _devDayCost = value; }
        }

        public double DevMonthCost
        {
            get { return _devMonthCost; }
            set { _devMonthCost = value; }
        }

        public string DevMail
        {
            get { return _devMail; }
            set { _devMail = value; }
        }

        public int DevCategPrincipale
        {
            get { return _devCategPrincipale; }
            set { _devCategPrincipale = value; }
        }

        public string NomCategPrincipale
        {
            get { return _nomCategPrincipale = _nomCategPrincipale ?? chargerNomCateg(); }
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

        public List<Review> Reviews
        {
            get
            {
                if (_reviews == null) _reviews = ChargerReviews();

                return _reviews;
                // return _itLangs = _itLangs?? ChargerLesITLangs();
            }
        }
        #endregion

        #region Constructor
        public Developer()
        {

        }

        public Developer(int idDev, string devName, string devFirstName, DateTime devBirthDate, float devHourCost, float devDayCost, float devMonthCost, string devMail, string devPicture = default(string))
        {
            this.IdDev = idDev;
            this.DevName = devName;
            this.DevFirstName = devFirstName;
            this.DevBirthDate = devBirthDate;
            this.DevPicture = devPicture;
            this.DevHourCost = devHourCost;
            this.DevDayCost = devDayCost;
            this.DevMonthCost = devMonthCost;
            this.DevMail = devMail;
        }
        #endregion

        private string chargerNomCateg()
        {
            List<Dictionary<string, object>> maCateg = GestionConnexion.Instance.getData("select CategLabel from Categories where idCategory=" + this.DevCategPrincipale);
            string categName = "";
            if (maCateg[0]["CategLabel"] != null) categName = maCateg[0]["CategLabel"].ToString();
            return categName;
        }

        private List<ITLang> ChargerLesITLangs()
        {
            string query = @"select i.idIT, i.ITLabel from ITLang i 
                             inner join DevLang d 
                             on d.idIT = i.idIT 
                             where d.idDev =" + this.IdDev;

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

        private List<Review> ChargerReviews()
        {
            return Review.getReviewsFromDev(this.IdDev);
        }

        #region Method Static
        public static Developer getInfo(int id)
        {
            List<Dictionary<string, object>> unDev = GestionConnexion.Instance.getData("select * from Developer where idDev=" + id);
            Developer dev = new Developer();
            dev.IdDev = int.Parse(unDev[0]["idDev"].ToString());
            dev.DevName = unDev[0]["DevName"].ToString();
            dev.DevFirstName = unDev[0]["DevFirstName"].ToString();
            dev.DevBirthDate = DateTime.Parse(unDev[0]["DevBirthDate"].ToString());
            dev.DevPicture = unDev[0]["DevPicture"] == null ? "" : unDev[0]["DevPicture"].ToString();
            dev.DevHourCost = float.Parse(unDev[0]["DevHourCost"].ToString());
            dev.DevDayCost = float.Parse(unDev[0]["DevDayCost"].ToString());
            dev.DevMonthCost = float.Parse(unDev[0]["DevMonthCost"].ToString());
            dev.DevMail = unDev[0]["DevMail"].ToString();
            dev.DevCategPrincipale = int.Parse(unDev[0]["DevCategPrincipale"].ToString());
            return dev;
        }

        public static List<Developer> ChargerTous()
        {
            List<Dictionary<string, object>> lstDevs = GestionConnexion.Instance.getData("select * from Developer");
            List<Developer> listDev = new List<Developer>();
            foreach (Dictionary<string, object> item in lstDevs)
            {
                Developer dev = new Developer();
                dev.IdDev = int.Parse(item["idDev"].ToString());
                dev.DevName = item["DevName"].ToString();
                dev.DevFirstName = item["DevFirstName"].ToString();
                dev.DevBirthDate = DateTime.Parse(item["DevBirthDate"].ToString());
                dev.DevPicture = item["DevPicture"] == null ? "" : item["DevPicture"].ToString();
                dev.DevHourCost = float.Parse(item["DevHourCost"].ToString());
                dev.DevDayCost = float.Parse(item["DevDayCost"].ToString());
                dev.DevMonthCost = float.Parse(item["DevMonthCost"].ToString());
                dev.DevMail = item["DevMail"].ToString();
                dev.DevCategPrincipale = int.Parse(item["DevCategPrincipale"].ToString());
                listDev.Add(dev);
            }
            return listDev;
        }
        #endregion

        public virtual bool saveMe()
        {
            Developer dev = Developer.getInfo(this.IdDev);
            string query = "";
            if (dev == null)
            {

                query = @"INSERT INTO [AdopteUneDev].[dbo].[Developer]
                                 VALUES(@idDev,@devName,@devFirstName,@devBirthDate,@devPicture,@devHourCost,@devDayCost,@devMonthCost,@devMail";
            }
            else
            {
                query = @"UPDATE [dbo].[Developer]
                             SET [DevName] = @devName,
                                 [DevFirstName] = @devFirstName,
                                 [DevBirthDate] = @devBirthDate,
                                 [DevPicture] = @devPicture,
                                 [DevHourCost] = @devHourCost,
                                 [DevDayCost] = @devDayCost,
                                 [DevMonthCost] = @devMonthCost,
                                 [DevMail] = @devMail,
                           Where [idDev] = @idDev";
            }

            //les données a insérer
            Dictionary<string, object> valeurs = new Dictionary<string, object>();
            valeurs.Add("idDev", this.IdDev);
            valeurs.Add("devName", this.DevName);
            valeurs.Add("devFirstName", this.DevFirstName);
            valeurs.Add("devBirthDate", this.DevBirthDate);
            valeurs.Add("devPicture", this.DevPicture == default(string) ? DBNull.Value : (object)this.DevPicture);
            valeurs.Add("devHourCost", this.DevHourCost);
            valeurs.Add("devDayCost", this.DevDayCost);
            valeurs.Add("devMonthCost", this.DevMonthCost);
            valeurs.Add("devMail", this.DevMail);

            if (GestionConnexion.Instance.saveData(query, GenerateKey.APP, valeurs))
            {
                return true;
            }
            else
            {
                return false;
            }
        }


    }
}
