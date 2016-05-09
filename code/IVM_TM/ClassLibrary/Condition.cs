using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary
{
    public class Condition
    {
        public string TimeUp;
        public string TimeDown;
        public string RateUp;
        public string RateDown;
        public string MoneyDown;
        public string MoneyUp;
        public string projectName;
        public int currentPage;
        public string IsAuction;
        public int sort;
        public Condition()
        {
            this.TimeDown = null;
            this.TimeUp = null;
            this.RateDown = null;
            this.RateUp = null;
            this.MoneyDown = null;
            this.MoneyUp = null;
            this.projectName = "";
            this.IsAuction = null;
            this.currentPage = 1;
            this.sort = 0;
        }
    }
    
}
