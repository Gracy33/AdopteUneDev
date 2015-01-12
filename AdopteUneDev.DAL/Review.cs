using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdopteUneDev.DAL
{
    public class Review
    {
        #region Fields
        private int _idReview;
        private string _name;
        private string _email;
        private int _idDev;
        private string _com;
        private DateTime _reviewDate;
        private List<Developer> _developer;
        #endregion

        #region Properties
        public int IdReview
        {
            get { return _idReview; }
            set { _idReview = value; }
        }

        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }

        public string Email
        {
            get { return _email; }
            set { _email = value; }
        }

        public int IdDev
        {
            get { return _idDev; }
            set { _idDev = value; }
        }

        public string Com
        {
            get { return _com; }
            set { _com = value; }
        }

        public DateTime ReviewDate
        {
            get { return _reviewDate; }
            set { _reviewDate = value; }
        }
        #endregion

        public static List<Review> getReviewsFromDev(int idD)
        {
            List<Review> retour = new List<Review>();
            List<Dictionary<string, object>> DesReviews = GestionConnexion.Instance.getData("select * from ReviewsTab where idDev =" + idD);
            foreach (Dictionary<string, object> item in DesReviews)
            {
                Review rev = new Review();
                rev.Name = item["Name"].ToString();
                rev.Email = item["Email"].ToString();
                rev.IdDev = (int)item["idDev"];
                rev.Com = item["Review"].ToString();
                rev.ReviewDate = DateTime.Parse(item["ReviewDate"].ToString());
                retour.Add(rev);
            }
            return retour;
        }        
    }
}
