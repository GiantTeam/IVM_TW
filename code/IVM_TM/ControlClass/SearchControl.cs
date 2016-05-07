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
        private static ProjectList projectListForAll = Initializate.mProjectList;//总项目列表
        private static ProjectList ChildProjectList = projectListForAll;//筛选出的项目的列表
        public enum TimeSort { LongToShort,ShortTo}        
        public  ProjectList Search(Condition c)
        {
            //当无上限时，Up应设为 无穷大；当无下限时，Down应为0
            return ChildProjectList;
        }
        public ProjectList Search(string Key)
        {
            return ChildProjectList;
        }

        //筛选部分的函数统一用SelectProjectList()
        //传入月份数来搜索。。月份大小。第一个参数是指月份的上限，第二个参数指月份的下限。第三个参数为起投金额的上限，第四个为起投金额的下限。如果是6个月以下金额大于10000元传入的
        //参数应该是（0，6,10000,null）自己手动选的话传入参数为（第一个框的数，第二个框的参数，第三个框的数，第四个框的数为）
        //，。。。
        public ProjectList SelectProjectListByMonthAndMoney(string lowMonth,string HighMonth,string lowMoney,string HighMoney )
        {
            if (lowMoney == null && (HighMoney == null) && (lowMonth == null) && (HighMonth == null))
            {
                return projectListForAll;
            }
            string url = ReturnUrl(lowMonth,HighMonth,lowMoney,HighMoney);
            string webContent = GetWebContent.LoadDataFromWeb(url);
            string projectStrLink = "https://list.lu.com";
            ChildProjectList = AddProjectList.addProject(ChildProjectList, webContent, projectStrLink);
            return ChildProjectList;
        }

        public string ReturnUrl(string lowMonth,string HighMonth,string lowMoney,string HighMoney)
        {
            string url = "";
           
            if (lowMoney == null && (HighMoney == null))
            {
                if (HighMonth == null)
                {
                    int dayFrist = (int.Parse(lowMonth)) * 30;
                    url = "https://list.lu.com/list/p2p?minMoney=&maxMoney=&minDays=" + dayFrist + "&maxDays=&minRate=&maxRate=&mode=&tradingMode=&isCx=&currentPage=1&orderCondition=&isShared=&canRealized=&productCategoryEnum=";
                }
                else
                {
                    int dayFrist = (int.Parse(lowMonth)) * 30;
                    int daySecond = (int.Parse(HighMonth)) * 30;
                    url = "https://list.lu.com/list/p2p?minMoney=&maxMoney=&minDays=" + dayFrist + "&maxDays=" + daySecond + "&minRate=&maxRate=&mode=&tradingMode=&isCx=&currentPage=1&orderCondition=&isShared=&canRealized=&productCategoryEnum=";
                }

            }
            else if (lowMonth == null && (HighMonth == null))
            {
                if (HighMoney == null)
                {
                    int moneyFrist = (int.Parse(lowMoney));
                    url = "https://list.lu.com/list/p2p?minMoney=" + moneyFrist + "&maxMoney=&minDays=&maxDays=&minRate=&maxRate=&mode=&tradingMode=&isCx=&currentPage=1&orderCondition=&isShared=&canRealized=&productCategoryEnum=";
                }
                else
                {
                    int moneyFrist = (int.Parse(lowMoney)) * 30;
                    int moneySecond = (int.Parse(HighMoney)) * 30;
                    url = "https://list.lu.com/list/p2p?minMoney=" + moneyFrist + "&maxMoney=" + moneySecond + "&minDays=&maxDays=&minRate=&maxRate=&mode=&tradingMode=&isCx=&currentPage=1&orderCondition=&isShared=&canRealized=&productCategoryEnum=";
                }

            }
            else if ((lowMonth != null) && (HighMonth != null) && (lowMoney != null) && (HighMoney != null))
            {
                int dayFrist = (int.Parse(lowMonth)) * 30;
                int daySecond = (int.Parse(HighMonth)) * 30;
                int moneyFrist = (int.Parse(lowMoney)) * 30;
                int moneySecond = (int.Parse(HighMoney)) * 30;
                url = "https://list.lu.com/list/p2p?minMoney=" + moneyFrist + "&maxMoney=" + moneySecond + "&minDays=" + dayFrist + "&maxDays=" + daySecond + "&minRate=&maxRate=&mode=&tradingMode=&isCx=&currentPage=1&orderCondition=&isShared=&canRealized=&productCategoryEnum=";
            }
            else if (HighMoney == null && (HighMonth == null) && (lowMonth != null) && (lowMoney != null))
            {
                int dayFrist = (int.Parse(lowMonth)) * 30;
                int moneyFrist = (int.Parse(lowMoney));
                url = url = "https://list.lu.com/list/p2p?minMoney=" + moneyFrist + "&maxMoney=&minDays=" + dayFrist + "&maxDays=&minRate=&maxRate=&mode=&tradingMode=&isCx=&currentPage=1&orderCondition=&isShared=&canRealized=&productCategoryEnum=";
            }
            else if (HighMoney == null && (HighMonth != null) && (lowMonth != null) && (lowMoney != null))
            {
                int dayFrist = (int.Parse(lowMonth)) * 30;
                int daySecond = (int.Parse(HighMonth)) * 30;
                int moneyFrist = (int.Parse(lowMoney));
                url = "https://list.lu.com/list/p2p?minMoney=" + moneyFrist + "&maxMoney=&minDays=" + dayFrist + "&maxDays=" + daySecond + "&minRate=&maxRate=&mode=&tradingMode=&isCx=&currentPage=1&orderCondition=&isShared=&canRealized=&productCategoryEnum=";
            }
            else if (HighMoney != null && (HighMonth == null) && (lowMonth != null) && (lowMoney != null))
            {
                int dayFrist = (int.Parse(lowMonth)) * 30;
                int moneyFrist = (int.Parse(lowMoney));
                int moneySecond = (int.Parse(HighMoney));
                url = url = "https://list.lu.com/list/p2p?minMoney=" + moneyFrist + "&maxMoney=" + moneySecond + "&minDays=" + dayFrist + "&maxDays=&minRate=&maxRate=&mode=&tradingMode=&isCx=&currentPage=1&orderCondition=&isShared=&canRealized=&productCategoryEnum=";
            }
            return url;
        }
    
        //
        private ProjectList SelectByRate(float Up,float Down)
        {
            //当无上限时，Up应设为 无穷大；当无下限时，Down应为0
            return ChildProjectList;
        }

        public ProjectList ProjectList
        {
            get { return ChildProjectList; }
            }
       
        public static ProjectList Sort(string Method,Enum UpOrDown)
        {
            
            return ChildProjectList; 
        }
        public ProjectList TimeLongToShort ()
        {
            return ChildProjectList;
        }
        public ProjectList TimeShortToLong()
        {
            return ChildProjectList;
        }
        public ProjectList MoneyMoreToLess()
        {
            return ChildProjectList;
        }
        public ProjectList MoneyLessToMore()
        {
            return ChildProjectList;
        }
        public ProjectList RateHighToLow()
        {
            return ChildProjectList;
        }
        public ProjectList RateLowToHigh()
        {
            return ChildProjectList;
        }

    }
}
