using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;
namespace EntityClass
{
    public class ProjectRecord
    {
        string strName;
        double dblInvest;//投资金额
        double dblWithdrawals;//赎回金额
        double dblProfit;//收益
        double dblPresentValue;//当前价值
        ArrayList recordList = new ArrayList();//该项目的所有投资/赎回记录
        public double Profit
        {
            
                   
            get { dblProfit = 0;
                return dblProfit; }
        }
        public double Invest
        {
            get {
                dblInvest = 0;
                foreach (Record record in recordList)
                {
                    if (record.strType == "购买")
                        dblInvest += record.dblMoney;
                }
                return dblInvest; }
        }
       
        public double Withdrawals
        {
            get {
                foreach(Record record in recordList)
                {
                    if (record.strType == "赎回")
                        dblWithdrawals += record.dblMoney;
                }
                return dblWithdrawals;
            }
        }
        public double Value
        {
            get { return dblPresentValue; }
            
        }


    }
}
