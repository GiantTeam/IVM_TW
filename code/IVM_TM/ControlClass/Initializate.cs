using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntityClass;
using ControlClass;

namespace ControlClass
{

    using System.Net;
    using System.Collections;
    public class Initializate
    {
        
        List<string> aLinkList = new List<string>() { "https://list.lu.com/list/transfer-p2p?minMoney=&maxMoney=&minDays=&maxDays=&minRate=&maxRate=&mode=&tradingMode=&isCx=&currentPage=1&orderCondition=&isShared=&canRealized=&productCategoryEnum=" };

        public static ProjectList mProjectList = new ProjectList();//项目列表
        //从若干网页中筛选出所有项目的信息，生成总项目列表项

        static void Main(string[] args)
        {
            Console.WriteLine("Program1");
            Console.ReadKey();
        }
        public Initializate()
        {
            SetProjectList();
        }
        //初始化ProjectList
        private void SetProjectList()
        {
            int intProjectListIndex = 0;
            for (int i = 0; i < aLinkList.Count; i++)
            {
                intProjectListIndex = i;
                string strTemp = GetWebContent.LoadDataFromWeb(aLinkList[i]);
                if (strTemp.Length != 0)
                {
                    SetProject(strTemp, intProjectListIndex);
                }

            }

        }

        //从网页内容中整理出项目信息，返回一条条的项目信息
        private void SetProject(string strWebContent, int intProjectListIndex)
        {
            if (intProjectListIndex == 0)
            {

                int intIndexOflink = 0;
                if (intIndexOflink == 0)
                {
                    string projectStrLink = "https://list.lu.com";
                    AddProjectList.addProject(mProjectList,strWebContent,projectStrLink);
                }
            }

        }



    }
}
