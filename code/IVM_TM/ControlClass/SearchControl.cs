using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntityClass;
using ClassLibrary;

namespace ControlClass
{
    public class SearchControl
    {
        public static ProjectList projectListForAll = new ProjectList();
       //总项目列表
        public static ProjectList ChildProjectList = Initializate.mProjectList;
       
        //筛选出的项目的列表       
        
        //筛选和排序部分的函数统一用SelectProjectList()
        //传入月份数来搜索。。月份大小。第一个参数是指月份的上限，第二个参数指月份的下限。第三个参数为起投金额的上限，第四个为起投金额的下限。如果是6个月以下金额大于10000元传入的
        //参数应该是（0，6,10000,null）自己手动选的话传入参数为（第一个框的数，第二个框的参数，第三个框的数，第四个框的数为）
        //，。。。
        //排序传入的参数sort，值为0代表默认排序，1代表按照价格升高排序，2代表降序，3代表期限升序排序，4代表降序排序，5代表利益率升序排序，5代表降序排序/
        public static void SelectOrOrderProjectList(string lowMonth,string HighMonth,string lowMoney,string HighMoney,string RateLow,string RateHigh,string projectName,string IsAuction,int currentPage,int sort)
        {
                string url = ReturnUrl(lowMonth, HighMonth, lowMoney, HighMoney, RateLow, RateHigh, projectName, IsAuction, currentPage, sort);
                string webContent = GetWebContent.LoadDataFromWeb(url);
                string projectStrLink = "https://list.lu.com";
                if(ChildProjectList.Count() != 0)
                ChildProjectList = AddProjectList.addProject(new ProjectList(), webContent, projectStrLink);
            
        }

        public static string ReturnUrl(string lowMonth,string HighMonth,string lowMoney,string HighMoney,string RateLow,string RateHigh,string projectName,string IsAuction,int currentPage,int sort)
        {
            string url = "";

            if (lowMonth != null)
            {
                lowMonth = ((int.Parse(lowMonth)) * 30).ToString();
            }
            if (HighMonth != null)
            {
                HighMonth = ((int.Parse(HighMonth)) * 30).ToString();
            }
            if (RateLow != null)
            {
                RateLow = (double.Parse(RateLow.Substring(0, (RateLow.Length - 2))) * 0.01).ToString();
            }
            if (RateHigh != null)
            {
                RateHigh = (double.Parse(RateHigh.Substring(0, (RateHigh.Length - 2))) * 0.01).ToString();
            }
            string sortString = null;
            if (sort == 1)
            {
                sortString = "TRANSFER_PRICE_ASC";
            }
            if (sort == 2)
            {
                sortString = "TRANSFER_PRICE_DESC";
            }
            if (sort == 3)
            {
                sortString = "INVEST_PERIOD_ASC";
            }
            if (sort == 4)
            {
                sortString = "INVEST_PERIOD_DESC";
            }
            if (sort == 5)
            {
                sortString = "INVEST_RATE_ASC";
            }
            if (sort == 6)
            {
                sortString = "INVEST_RATE_DESC";
            }
            url = "https://list.lu.com/list/transfer-p2p?minMoney=" + lowMoney + "&maxMoney=" + HighMoney + "&minDays=" + lowMonth + "&maxDays=" + HighMonth + "&minRate=" + RateLow + "&maxRate=" + RateHigh + "&mode=&tradingMode=" + IsAuction + "&isCx=&currentPage=" + currentPage + "&orderCondition=" + sortString + "&isShared=&canRealized=&productCategoryEnum=";
            return url;
        }
   
       

    }
}
