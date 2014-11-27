using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdopteUneDev.DAL
{
    public class DevLang
    {
        #region Fields
        private int _idDev;
        private int _idIT;
        private DateTime _since; 
        #endregion

        #region Properties
        public Developer IdDev
        {
            get;
            set;
        }

        public ITLang IdIT
        {
            get;
            set;
        }

        public DateTime Since
        {
            get { return _since; }
            set { _since = value; }
        } 
        #endregion
    }
}
