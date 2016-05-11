using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityClass
{

    public struct Record
    {
        public string strDate;
        public string strType;
        public string strName;
        public double dblMoney;
        public double dblID;
    }
    public class RecordCompareByDate : System.Collections.IComparer
    {
        public int Compare(object x, object y)
        {
            return (-(string.Compare(((Record)x).strDate, ((Record)y).strDate)));
        }
    }
    public class RecordCompareByID : System.Collections.IComparer
    {
        public int Compare(object x, object y)
        {
            return (int)(((Record)x).dblID - ((Record)y).dblID);
        }
    }
}