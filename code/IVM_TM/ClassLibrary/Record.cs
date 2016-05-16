using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityClass
{

    public struct Record
    {
        public DateTime dtmDate;
        public string strType;
        public string strName;
        public double dblMoney;
        public double dblID;
    }
   
    public class RecordCompareByTime : System.Collections.IComparer
    {
        public int Compare(object x, object y)
        {
            DateTime Dx = ((Record)x).dtmDate;
            DateTime Dy = ((Record)y).dtmDate;
            if (Dx > Dy)
                return 1;
            else if (Dx == Dy)
                return 0;
            else
                return -1;
        }
    }
    public class RecordCompareByDate : System.Collections.IComparer
    {
        public int Compare(object x, object y)
        {
            DateTime Dx = ((Record)x).dtmDate;
            DateTime Dy = ((Record)y).dtmDate;
            if (Dx.Date> Dy.Date)
                return 1;
            else if (Dx.Date == Dy.Date)
                return 0;
            else
                return -1;
        }
    }
    public class RecordCompareByMonth : System.Collections.IComparer
    {
        public int Compare(object x, object y)
        {
            DateTime Dx = ((Record)x).dtmDate;
            DateTime Dy = ((Record)y).dtmDate;
            if (Dx.Year> Dy.Year || (Dx.Year == Dy.Year &&Dx.Month > Dy.Month))
                return 1;
            else if (Dx.Year == Dy.Year && Dx.Month == Dy.Month)
                return 0;
            else
                return -1;
        }
    }
    public class RecordCompareByYear : System.Collections.IComparer
    {
        public int Compare(object x, object y)
        {
            DateTime Dx = ((Record)x).dtmDate;
            DateTime Dy = ((Record)y).dtmDate;
            if (Dx.Year > Dy.Year)
                return 1;
            else if (Dx.Year == Dy.Year)
                return 0;
            else
                return -1;
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