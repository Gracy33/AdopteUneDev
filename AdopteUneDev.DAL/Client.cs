using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdopteUneDev.DAL
{
    public class Client
    {
        #region Fields
        private int _idClient;
        private string _name;
        private string _firstName;
        private string _mail;
        private string _company;
        #endregion

        #region Properties
        public int IdClient
        {
            get { return _idClient; }
            set { _idClient = value; }
        }

        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }

        public string FirstName
        {
            get { return _firstName; }
            set { _firstName = value; }
        }

        public string Mail
        {
            get { return _mail; }
            set { _mail = value; }
        }

        public string Company
        {
            get { return _company; }
            set { _company = value; }
        }
        #endregion

        #region Constructor
        public Client()
        {

        }

        public Client(int idClient, string name, string firstName, string mail, string company)
        {
            this.IdClient = idClient;
            this.Name = name;
            this.FirstName = firstName;
            this.Mail = mail;
            this.Company = company;
        }
        #endregion

        #region Method Static
        public static Client getInfo(int identifiant)
        {
            List<Dictionary<string, object>> unClient = GestionConnexion.Instance.getData("select * from Client where idClient=" + identifiant);
            Client c = Associe(unClient[0]);            
            return c;    
        }

        public static List<Client> ChargerTous()
        {
            List<Dictionary<string, object>> infoClient = GestionConnexion.Instance.getData("select * from Client");
            List<Client> listCli = new List<Client>();
            foreach (Dictionary<string, object> item in infoClient)
            {
                Client c = Associe(item);
                listCli.Add(c);
            }
            return listCli;
        }

        private static Client Associe(Dictionary<string, object> item)
        {
            Client c = new Client()
            {
                IdClient = (int)item["idClient"],
                Name = item["CliName"].ToString(),
                FirstName = item["CliFirstName"].ToString(),
                Mail = item["CliMail"].ToString(),
                Company = item["CliCompany"].ToString()
            };
            return c;
        }
        #endregion

        #region Function
        public virtual bool saveMe()
        {
            Client c = Client.getInfo(this.IdClient);
            string query = "";
            if (c == null)
            {

                query = @"INSERT INTO [AdopteUneDev].[dbo].[Client]
                                 VALUES (@idClient,@name,@firstName,@mail,@company";
            }
            else
            {
                query = @"UPDATE [dbo].[Client]
                             SET [CliName] = @name,
                                 [CliFirstName] = @firstName,
                                 [CliMail] = @mail,
                                 [CliCompany] = @company
                           WHERE [idClient] = @idClient";
            }

            //les données a insérer
            Dictionary<string, object> valeurs = new Dictionary<string, object>();
            valeurs.Add("idClient", this.IdClient);
            valeurs.Add("name", this.Name);
            valeurs.Add("firstName", this.FirstName);
            valeurs.Add("mail", this.Mail);
            valeurs.Add("company", this.Company);

            if (GestionConnexion.Instance.saveData(query, GenerateKey.APP, valeurs))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        #endregion
    }
}
