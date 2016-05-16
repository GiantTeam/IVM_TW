using Microsoft.VisualStudio.TestTools.UnitTesting;
using ControlClass;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntityClass;
using System.Collections;

namespace ControlClass.Tests
{
    [TestClass()]
    public class StatisticTests
    {
        [TestMethod()]
        public void LoadDataFromExcelTest()
        {
            string strFileWholePath = "C:\\Users\\campufix\\Desktop\\hhh.xls";
            Statistic sStatistic = new Statistic();
            ArrayList RecordList = sStatistic.LoadDataFromExcel(strFileWholePath);

            Assert.Fail();
        }

        [TestMethod()]
        public void WriteAndAutoSaveXlsTest()
        {
            Statistic sStatistic = new Statistic();
            sStatistic.WriteAndAutoSaveXls();
            bool Actual = true;
            bool Result = true;
            Assert.AreEqual(Actual,Result);
        }
        //[TestMethod()]
        //public void FindTimeInTheListOfNotTest()
        //{
        //    DateTime a = new DateTime(2013, 01, 02, 12, 12, 12);
        //    DateTime b = new DateTime(2013, 02, 02, 12, 12, 12);
        //    DateTime c = new DateTime(2013, 03, 02, 12, 12, 12);
        //    Record Ra = new Record();
        //    Ra.dtmDate = a;                
        //    Record Rb = new Record();
        //    Ra.dtmDate = b;           
        //    Record Rc = new Record();
        //    Ra.dtmDate = c;
        //    ArrayList recordList = new ArrayList();
        //    recordList.Add(Ra);
        //    recordList.Add(Rb);
        //    recordList.Add(Rc);
        //    Statistic statistic = new Statistic();

        //    DateTime goal = a;
        //    bool Actual = statistic.FindTimeInTheListOfNot(goal ,recordList);
        //    bool Expect = true;
        //    Assert.AreEqual(Actual,Expect);
        //}
    }
}