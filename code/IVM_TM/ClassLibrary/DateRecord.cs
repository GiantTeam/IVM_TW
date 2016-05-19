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

        public DateTime dtmTime;
        public double dblInvest = 0;//投资金额
        public double dblProfit = 0;//收益
        public double dblValue = 0;//当前价值
        public double dblRate = 0;//收益率
        public ArrayList recordList = new ArrayList();
        public DateRecord(DateTime time)
        {
            this.dtmTime = time;

        }
        public void Add(Record record)
        {
            this.recordList.Add(record);
        }
        //public DateRecord (DateTime Date,ArrayList RecordList)
        //{
        //    this.dtmDate = Date;            
        //    int DateIndex = 0;
        //    Record record =(Record) RecordList[DateIndex];
        //    while (record.dtmDate>this.dtmDate)//将当天和那天之前的所有项目记录单独放
        //    {
        //        recordList.Add(record);
        //        DateIndex++;
        //        record = (Record)RecordList[DateIndex];
        //    }
        //    RecordCompareByID recordCompareByID = new RecordCompareByID();
        //    recordList.Sort(recordCompareByID);//按ID排序

        //}

        public double Profit
        {
            get
            {
                dblProfit = 0;

                for (int i = 0; i < recordList.Count; i++)
                {
                    Record record = (Record)recordList[i];
                    //if(i != recordList .Count-1 &&((Record)recordList[i]).dblID == ((Record)recordList[i+1]).dblID)
                    //{
                    //    dblProfit += ((Record)recordList[i+1]).dblMoney-((Record)recordList[i]).dblMoney;
                    //    i += 2;
                    //}
                    //else
                    //{
                    //    Record temp = (Record)recordList[i];
                    //    //设购买金额是x元，今天离购买日期y天)，其当前的价值value = x * (1 + 0.084) * y / 365；其今天为止的收益 = value - x;
                    //    double value = temp.dblMoney * (1 + 0.084) * (Math.Abs((this.dtmTime-temp.dtmDate).Days))/ 365;
                    //    dblProfit += value - temp.dblMoney;
                    //    i++;
                    //}
                    bool ShuhuiOrNot = false;
                    int ii = i;
                    if (record.strType == "购买")
                    {
                        if (i == recordList.Count - 1)
                        {
                            ShuhuiOrNot = false;
                        }
                        else
                        {
                            for (int index = i + 1; index < recordList.Count; index++)
                            {
                                if (((Record)recordList[index]).dblID == record.dblID)
                                {
                                    ii = index;
                                    ShuhuiOrNot = true;
                                    break;
                                }
                            }
                        }

                        if (ShuhuiOrNot == true)//该投资已经赎回
                            dblProfit += ((Record)recordList[ii]).dblMoney - ((Record)recordList[i]).dblMoney;
                        else
                        {
                            //该投资未赎回
                            DateTime start = record.dtmDate.Date;
                            DateTime end = this.dtmTime.Date;
                            TimeSpan ts = end - start;
                            int intDay = ts.Days;
                            double value = record.dblMoney * (1 + 0.084) * intDay / 365;
                            dblProfit += value;
                        }
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
                        dblInvest += temp.dblMoney;
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

                //dblRate = this.Profit / 100000 / dateDiff(((Record)recordList[0]).strDate, this.dtmDate)*365;
                DateTime start = ((Record)recordList[0]).dtmDate;
                DateTime end = this.dtmTime.Date;
                TimeSpan ts = end - start;
                int intDay = ts.Days;
                dblRate = this.Profit / this.Invest;
                // dblRate = this.Profit / 100000 / intDay* 365;

                return dblRate;
            }
        }



    }

}
