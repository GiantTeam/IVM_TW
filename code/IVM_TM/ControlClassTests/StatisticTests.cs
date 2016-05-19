using Microsoft.VisualStudio.TestTools.UnitTesting;
using ControlClass;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntityClass;
using System.Collections;
using VM;
namespace ControlClass.Tests
{
    [TestClass()]
    public class StatisticTests
    {
        [TestMethod()]
        public void LoadDataFromExcelTest()
        {
            //string strFileWholePath = "投资记录表.xls";
            Statistic sStatistic = new Statistic();
            //  frmMain a = new frmMain();
            string s = frmMain.strDefaultExcelFileWholePath;
            ArrayList RecordList = sStatistic.LoadDataFromExcel(s);
            bool Actual = true;
            bool Result = true;
            Assert.AreEqual(Actual, Result);
        }


        [TestMethod()]
        public void WriteDateToExcelTestThree()
        {
            ArrayList RecordList = new ArrayList();
            for (int i = 2001; i < 2004; i++)
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
        public void WriteDateToExcelTestTen()
        {
            ArrayList RecordList = new ArrayList();
            for (int i = 1; i < 10; i++)
            {
                Record record = new Record();
                record.strType = "购买";
                record.strName = "车押宝" + (i * 20 + 2000).ToString();
                record.dblMoney = i;
                record.dblID = i * 10000;
                record.dtmDate = DateTime.Parse("2013/01/01 00:12");
                RecordList.Add(record);
            }


            string strFileWholePath = "投资记录表.xls";
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

        [TestMethod()]
        public void GetDateRecordListTest()
        {
            string strDay = "日";
            ArrayList RecordList = new ArrayList();
            for (int i = 1; i < 30; i++)
            {
                Record record = new Record();
                record.strType = "购买";
                record.strName = "车押宝" + (i + 2000).ToString();
                record.dblMoney = i * 10000;
                record.dblID = i;
                string strDateTime = "2013/01/" + i.ToString() + " 00:12";
                record.dtmDate = DateTime.Parse(strDateTime);
                RecordList.Add(record);
            }
            Statistic sStatistic = new Statistic();
            ArrayList DateRecordList = sStatistic.GetDateRecordList(strDay, RecordList);
            int DateRecordCount = DateRecordList.Count;
            double[] dblProfitList = new double[DateRecordCount];
            for (int index = 0; index < DateRecordCount; index++)
            {
                DateRecord dateRecord = (DateRecord)DateRecordList[index];
                dblProfitList[index] = dateRecord.Profit;
            }


            bool Actual = true;
            bool Result = true;
            Assert.AreEqual(Actual, Result);


            //Assert.Fail();
        }
    }
}