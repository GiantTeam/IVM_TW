using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

namespace EntityClass
{

  
    public class DateRecord
    {
        
        string strDate;
        double dblInvest;//投资金额
        double dblProfit;//收益
        double dblValue;//当前价值
        double dblRate;//收益率
        ArrayList recordList;
        public DateRecord (string Date,ArrayList RecordList)
        {
            this.strDate = Date;            
            int DateIndex = 0;
            Record record =(Record) RecordList[DateIndex];
            while (!(string.Compare(record.strDate,this.strDate) >0))//将当天和那天之前的所有项目记录单独放
            {
                recordList.Add(record);
                DateIndex++;
                record = (Record)RecordList[DateIndex];
            }
            RecordCompareByID recordCompareByID = new RecordCompareByID();
            recordList.Sort(recordCompareByID);//按ID排序

        }
             
        public double Profit
        {
            get {
                dblProfit = 0;             
                for(int i =0; i< recordList.Count;)
                {
                    if(i != recordList .Count-1 &&((Record)recordList[i]).dblID == ((Record)recordList[i+1]).dblID)
                    {
                        dblProfit += ((Record)recordList[i+1]).dblMoney-((Record)recordList[i]).dblMoney;
                        i += 2;
                    }
                    else
                    {
                        Record temp = (Record)recordList[i];
                        //设购买金额是x元，今天离购买日期y天)，其当前的价值value = x * (1 + 0.084) * y / 365；其今天为止的收益 = value - x;
                        double value = temp.dblMoney * (1 + 0.084) * (dateDiff(this.strDate, temp.strDate)) / 365;
                        dblProfit += value - temp.dblMoney;
                        i++;
                    }
                
                 }
                return dblProfit;
            }
        }
        public double Invest
        {
            get
            {
                dblInvest = 0;
                for (int i = 0; i < recordList.Count;)
                {
                    if (i != recordList.Count - 1 && ((Record)recordList[i]).dblID == ((Record)recordList[i + 1]).dblID)
                    {                      
                        i += 2;
                    }
                    else
                    {
                        Record temp = (Record)recordList[i];                    
                        dblInvest +=temp.dblMoney;
                        i++;
                    }

                }
                return dblInvest;
            }

        }
        public double Rate
        {
            get
            {
                //今天为止的收益率=今天为止的所有项目的收益/初始现金/（当前日期-初始投资日期）*365*100%

                dblRate = this.Profit / 100000 / dateDiff(((Record)recordList[0]).strDate, this.strDate)*365;
                return dblRate;
            }
        }


        private int dateDiff(string date1, string date2)
        {
            DateTime dt = DateTime.Now;
            dt = DateTime.Now.AddDays(1);
            string sdate = dt.ToShortDateString().ToString();
            DateTime dt1 = Convert.ToDateTime(date1);
            DateTime dt2 = Convert.ToDateTime(date2);
            TimeSpan span = dt2.Subtract(dt1);
            int dayDiff = span.Days + 1;
            return dayDiff;
        }
    }

}
