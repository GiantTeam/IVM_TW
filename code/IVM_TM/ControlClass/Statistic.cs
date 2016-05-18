using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using EntityClass;
using System.Reflection;
//using Excel= Microsoft.Office.Interop.Excel;
//using Excel;
using Cells = Aspose.Cells;
using Microsoft.Office.Interop.Excel;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Data.OleDb;
using System.Runtime.InteropServices;
using System.Collections;
using System.Configuration;
using System.Data;

namespace ControlClass
{
    using System.Collections;
    public class Statistic
    {
        public ArrayList LogList;
        public static string strTablePath = "Document";//项目记录文件路径
        public static string strTableFileName = "投资项目统计表.excel";//项目记录文件名
        public static string strWholePath = strTablePath + @"\" + strTableFileName;//记录文件的路径/文件全名
        public ArrayList RecordList;//从记录文件中获取记录列表


        public ArrayList GetDateRecordList(Comparer cmpCompare)
        {
            //打开excel选择框
           
            //将所有的项目记录按不同的时间精度（年、月、日）进行分开整理计算，可以获取该数组
            //利用该数组画出每个时间点收益，投资，收益率，作出曲线。
            ArrayList DateRecordList = new ArrayList();
            DateRecord tempDateRecord ;
            List<DateTime> DateList = new List<DateTime>();
            for (int i = 0; i < RecordList.Count;i++)//
            {
                //对项目投资记录表进行遍历，根据要求的整理方法对记录进行归类
                //生成DateRecord列表，每个DateRecord中含有该时间(每年/每月/每日)的收益情况、投资情况等
                Record temp = (Record)RecordList[i];//
                DateTime tempTime = temp.dtmDate;
                DateTime dtmTime;//存储该条记录的年/年月/年月日
               
                if (cmpCompare.GetType() == typeof(RecordCompareByDate))                                
                    dtmTime = new DateTime(tempTime.Year,tempTime.Month,tempTime.Day);//按日归类                            
                else if (cmpCompare.GetType() == typeof(RecordCompareByMonth))
                    dtmTime = new DateTime(tempTime.Year,tempTime.Month,1); //按月归类                 
                else
                    dtmTime = new DateTime(tempTime.Year,1,1);//按年归类

                if (!DateList.Contains(dtmTime))
                {
                    //出现新的时间点
                    DateList.Add(dtmTime);
                    DateRecord dateRecord = new DateRecord(dtmTime);
                    dateRecord.recordList.Add(temp);
                    tempDateRecord = dateRecord;                    
                    DateRecordList.Add(dateRecord);
                }
                    else
                {
                   //该时间已经记录在DateRecord表中，将该记录记录到对应时间点的记录表中
                    int intIndex = new int();
                    foreach (DateRecord  a in DateRecordList)
                    {
                        if (a.dtmTime == dtmTime)
                        {
                            intIndex = DateRecordList.IndexOf(a);
                            break;
                        }
                    }
                   ((DateRecord)(DateRecordList[intIndex])).Add(temp);
                }
            }
            return DateRecordList;
        }
        public static void GenerateXMLDoc()
        {
            try
            {
                XmlDocument StatisticTable = new XmlDocument();
                XmlElement rootElement = StatisticTable.CreateElement("Recerds");
                StatisticTable.AppendChild(rootElement);

                XmlElement Record = StatisticTable.CreateElement("Record");
                Record.SetAttribute("Date", "20150308");
                Record.SetAttribute("Type", "购买");
                Record.SetAttribute("Name", "车押宝");
                Record.SetAttribute("Money", "1000000");
                Record.SetAttribute("ID", "1000000001");
                rootElement.AppendChild(Record);
            }
            catch
            {


            }
        }
        public ArrayList LoadDataFromXml(string WholePath)
        {
            try
            {
                ArrayList RecordList = new ArrayList();
                if (!File.Exists(WholePath))
                {
                    XmlDocument StatisticTable = new XmlDocument();
                    //创建根节点
                    XmlElement rootElement = StatisticTable.CreateElement("Records");
                    StatisticTable.AppendChild(rootElement);
                    StatisticTable.Save(strWholePath);
                    return RecordList;
                }
                XmlDocument Table = new XmlDocument();
                Table.Load(strWholePath);
                XmlNode rootNode = Table.SelectSingleNode("Records");
                XmlNodeList NodeList = rootNode.ChildNodes;
                foreach (XmlNode XmlRecord in NodeList)
                {
                    //获取每一条项目记录
                    XmlAttributeCollection xmlSingleRecord = XmlRecord.Attributes;
                    Record record = new Record();

                    record.dtmDate = DateTime.Parse(xmlSingleRecord["Date"].Value);
                    record.dblMoney = double.Parse(xmlSingleRecord["Money"].Value);
                    record.strName = xmlSingleRecord["Name"].Value;
                    record.strType = xmlSingleRecord["Type"].Value;
                    record.dblID = double.Parse(xmlSingleRecord["ID"].Value);
                    RecordList.Add(record);
                }
                return RecordList;
            }
            catch
            {
                return null;
            }

        }
        public  ArrayList LoadDataFromExcel(string WholePath)
        {
            ArrayList RecordList = new ArrayList();           
            Application app = new Application();



            Workbooks wbks = app.Workbooks;
            if (!File.Exists(WholePath))
            {
                Cells.Workbook _wbkTemp = new Cells.Workbook();
                //  _wbk = wbks.Add(true);
                //Sheets sh = _wbk.Sheets;
                Cells.Worksheet _ws = _wbkTemp.Worksheets[0];
                //   Cells.Cells _ws = sh.Cells; 
                //   _Worksheet _ws = (_Worksheet)sh.get_Item(1);
                _ws.Cells[0, 0].PutValue("时间");
                _ws.Cells[0, 1].PutValue("类型");
                _ws.Cells[0, 2].PutValue("金额");
                _ws.Cells[0, 3].PutValue("项目");
                _ws.Cells[0, 4].PutValue("编号");
                _wbkTemp.Save(WholePath);

            }
            Cells.Workbook _wbk = new Cells.Workbook(WholePath);
            Cells.Worksheet _wsh = _wbk.Worksheets[0];
            Cells.Cells cells = _wsh.Cells;
            int rowCount = cells.MaxRow;
         //   int columncount = cells.MaxColumn;
                    
            for (int i = 1; i < rowCount; i++)
            {
                Record record = new Record();
                // System._ComObject 
                record.dtmDate = DateTime.Parse(_wsh.Cells[i, 0].StringValue.Trim());                          
                record.strType =_wsh.Cells[i, 1].StringValue;
                record.dblMoney = Double.Parse(_wsh.Cells[i, 2].StringValue.Trim());
                record.strName = _wsh.Cells[i, 3].StringValue.Trim(); ;
                record.dblID = Double.Parse( _wsh.Cells[i, 4].StringValue.Trim());
                RecordList.Add(record);
              //  __ComObject
            }




            RecordCompareByTime cmpCompareByTime = new RecordCompareByTime();
            RecordList.Sort(cmpCompareByTime);//所有的项目记录表按时间排序
         //   _wbk.Close();
            return RecordList;
        }

        public void WriteDataToExcel(ArrayList RecordList, String WholePath)//保存修改
        {                  
            if (!File.Exists(WholePath))
            {
                Cells.Workbook _wbkTemp = new Cells.Workbook();          
                Cells.Worksheet _ws = _wbkTemp.Worksheets[0];  
                _ws.Cells[0, 0].PutValue("时间");
                _ws.Cells[0, 1].PutValue("类型");
                _ws.Cells[0, 2].PutValue("金额");
                _ws.Cells[0, 3].PutValue("项目");
                _ws.Cells[0, 4].PutValue("编号");
                _wbkTemp.Save(WholePath);

            }
            Application app = new Application();
            Workbooks wbks = app.Workbooks;
           // _Workbook _wbk = wbks.Add(WholePath);


            Cells.Workbook _wbk = new Cells.Workbook(WholePath);
            Cells.Worksheet _wsh = _wbk.Worksheets[0];

            //清空原始数据
            int rowCount = _wsh.Cells.MaxRow;



            _wsh.Cells.DeleteRows(1, rowCount-1);
          

            //  Sheets shs = _wbk.Sheets;
            //_Worksheet _wsh = (_Worksheet)shs.get_Item(1);
            int RecordNum = RecordList.Count;
            for (int i = 1; i <= RecordNum; i++)
            {
                Record record = (Record)RecordList[i-1];
                _wsh.Cells[i, 0].PutValue( record.dtmDate.ToString());
                _wsh.Cells[i, 1] .PutValue( record.strType);
                _wsh.Cells[i, 2] .PutValue(record.dblMoney);
                _wsh.Cells[i, 3] .PutValue( record.strName);
                _wsh.Cells[i, 4] .PutValue( record.dblID);
            }
            _wbk.Save(WholePath);
            //    ((Range)_wsh.Rows[11, Missing.Value]).Insert(Missing.Value, XlInsertFormatOrigin.xlFormatFromLeftOrAbove);
            // _wbk.Save();
            // _wbk.Close();
        }
      
    
        
    }
}
