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
        public string intTime; //投资期限
        public string dblRate; //项目收益率
        public string dblMoney;  //项目转让金额
        public string strLink; //理财产品链接
        public string name;//投资项目名称

        public Project(int intId)
        {
            this.intId = intId;
            this.intTime = "";
            this.dblMoney = "";
            this.dblMoney ="";
            this.strLink = "";
            this.name = "";
        }
        public int CompareTo(Object rhs)
        {
            Project r = (Project)rhs;
            return this.intId.CompareTo(r.intId);
        }

    }
}
