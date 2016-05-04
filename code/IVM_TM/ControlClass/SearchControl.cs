using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntityClass;
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
        private  ProjectList SelectByTime(int Up,int Down)
        {
            //当无上限时，Up应设为 无穷大；当无下限时，Down应为0
            return ChildProjectList;
        }
        private ProjectList SelectByRate(float Up,float Down)
        {
            //当无上限时，Up应设为 无穷大；当无下限时，Down应为0
            return ChildProjectList;
        }
        private ProjectList SelectByMoney(double Up,double Down)
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
