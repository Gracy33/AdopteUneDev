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
        private string _idLabel;
        private int _idCategory; 
        #endregion

        #region Properties
        public int IdIT
        {
            get { return _idIT; }
            set { _idIT = value; }
        }

        public string IdLabel
        {
            get { return _idLabel; }
            set { _idLabel = value; }
        }
        public int IdCategory
        {
            get { return _idCategory; }
            set { _idCategory = value; }
        } 
        #endregion
    }
}
