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
            string strFileWholePath = "C:\\Users\\campufix\\Desktop\\TestForGenerate.xls";
            Statistic sStatistic = new Statistic();
            ArrayList RecordList = sStatistic.LoadDataFromExcel(strFileWholePath);
            bool Actual = true;
            bool Result = true;
            Assert.AreEqual(Actual, Result);
        }
  

        [TestMethod()]
        public void WriteDateToExcelTestThree()
        {
            ArrayList RecordList = new ArrayList();
            for(int i = 2001; i<2004;i++)
            {
                Record record = new Record();
                record.strType = "购买";
                record.strName = "车押宝"+ i.ToString();
                record.dblMoney = i;
                record.dblID = i;
                record.dtmDate = DateTime.Parse("2013/01/01 00:12");
                RecordList.Add(record);
            }
            

            string strFileWholePath = "C:\\Users\\campufix\\Desktop\\TestForGenerate.xls";
            Statistic sStatistic = new Statistic();
            sStatistic.WriteDataToExcel(RecordList,strFileWholePath);

            bool Actual = true;
            bool Result = true;
            Assert.AreEqual(Actual, Result);

        }

        [TestMethod()]
        public void WriteDateToExcelTestTen()
        {
            ArrayList RecordList = new ArrayList();
            for (int i = 2020; i < 2030; i++)
            {
                Record record = new Record();
                record.strType = "购买";
                record.strName = "车押宝" + i.ToString();
                record.dblMoney = i;
                record.dblID = i;
                record.dtmDate = DateTime.Parse("2013/01/01 00:12");
                RecordList.Add(record);
            }


            string strFileWholePath = "C:\\Users\\campufix\\Desktop\\TestForGenerate.xls";
            Statistic sStatistic = new Statistic();
            sStatistic.WriteDataToExcel(RecordList, strFileWholePath);

            bool Actual = true;
            bool Result = true;
            Assert.AreEqual(Actual, Result);

        }
        [TestMethod()]
        public void WriteDateToExcelTestTwenty()
        {
            ArrayList RecordList = new ArrayList();
            for (int i = 2020; i < 2040; i++)
            {
                Record record = new Record();
                record.strType = "购买";
                record.strName = "车押宝" + i.ToString();
                record.dblMoney = i;
                record.dblID = i;
                record.dtmDate = DateTime.Parse("2013/01/01 00:12");
                RecordList.Add(record);
            }


            string strFileWholePath = "C:\\Users\\campufix\\Desktop\\TestForGenerate.xls";
            Statistic sStatistic = new Statistic();
            sStatistic.WriteDataToExcel(RecordList, strFileWholePath);

            bool Actual = true;
            bool Result = true;
            Assert.AreEqual(Actual, Result);

        }
    }
}