using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace EntityClass
{
     public class Project : IComparable
    {
        public int intId;  //理财产品编号
        public int intTime; //起投期限
        public double dblRate; //项目收益率
        public double dblMoney;  //项目起投金额
        public string strLink; //理财产品链接
       
        public Project(int intId)
        {
            this.intId = intId;
            this.intTime = 0;
            this.dblMoney = 0;
            this.dblMoney =0;
            this.strLink = ""; 
        }
        public int CompareTo(Object rhs)
        {
            Project r = (Project)rhs;
            return this.intId.CompareTo(r.intId);
        }

    }
}
