using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using EntityClass;
using System.Reflection;
using Microsoft.Office.Core;
using Excel= Microsoft.Office.Interop.Excel;
using Microsoft.Office.Interop.Excel;


namespace ControlClass
{
    using System.Collections;
    public class Statistic
    {
        public ArrayList LogList;
        public static string strTablePath = "Document";//项目记录文件路径
        public static string strTableFileName = "投资项目统计表.excel";//项目记录文件名
        public static string strWholePath = strTablePath +@"\"+strTableFileName;
        public static ArrayList RecordList = LoadDataFromExcel(strWholePath);
        
      
        public ArrayList GetDateRecordList ()
        {
            //将所有的项目记录按时间进行分开整理计算，可以获取该数组
            //利用该数组画出每天的收益，投资，收益率，作出曲线。
            ArrayList DateRecordList = new ArrayList();
            List<string> DateList = new List<string>();
            for(int i = 0;i<RecordList.Count;)
            {
                Record temp = (Record)RecordList[i];
                if(!DateList.Contains(temp.strDate))
                {
                    DateList.Add(temp.strDate);
                    DateRecord dateRecord = new DateRecord(temp.strDate,RecordList);
                    DateRecordList.Add(dateRecord);
                }
            }
            return DateRecordList;
        }
        public static  void GenerateXMLDoc()
        {
            try
            {
                XmlDocument StatisticTable = new XmlDocument();
                XmlElement rootElement = StatisticTable.CreateElement("Recerds");
                StatisticTable.AppendChild(rootElement);

                XmlElement Record = StatisticTable.CreateElement("Record");
                Record.SetAttribute("Date","20150308");
                Record.SetAttribute("Type", "购买");
                Record.SetAttribute("Name","车押宝");
                Record.SetAttribute("Money", "1000000");
                Record.SetAttribute("ID", "1000000001");                 
                rootElement.AppendChild(Record);
            }
            catch
            {


            }
        }
        public ArrayList LoadDataFromXml(string WholePath )
        {
            try
            {
                ArrayList RecordList = new ArrayList();
                if(!File.Exists(WholePath ))
                {
                    XmlDocument StatisticTable = new XmlDocument();
                    //创建根节点
                    XmlElement rootElement = StatisticTable.CreateElement("Records");
                    StatisticTable.AppendChild(rootElement);
                    StatisticTable.Save(strWholePath );
                    return RecordList;
                }
                XmlDocument Table = new XmlDocument();
                Table.Load(strWholePath );
                XmlNode rootNode = Table.SelectSingleNode("Records");
                XmlNodeList NodeList = rootNode.ChildNodes;
                foreach (XmlNode XmlRecord in NodeList)
                {
                    //获取每一条项目记录
                    XmlAttributeCollection xmlSingleRecord = XmlRecord.Attributes;
                    Record record = new Record();
   
                    record.strDate = xmlSingleRecord["Date"].Value;
                    record.dblMoney = double.Parse(xmlSingleRecord["Money"].Value);
                    record.strName = xmlSingleRecord["Name"].Value;
                    record.strType = xmlSingleRecord["Type"].Value;
                    record.dblID= double.Parse(xmlSingleRecord["ID"].Value);
                    RecordList.Add(record);
                }
                return RecordList;
            }
            catch
            {
                return null;
            }

        }
        public static ArrayList LoadDataFromExcel(string WholePath)
        {
            ArrayList RecordList = new ArrayList();

            Application app = new Application();
            _Workbook _wbk;
            Workbooks wbks = app.Workbooks;
            if (!File.Exists(WholePath ))
            {
                _wbk = wbks.Add(true);
                Sheets sh = _wbk.Sheets;
                _Worksheet _ws = (_Worksheet)sh.get_Item(0);
                _ws.Cells[0, 0] = "时间";
                _ws.Cells[0, 1] = "类型";
                _ws.Cells[0,2] = "金额";
                _ws.Cells[0.3] = "项目";
                ((Range)_ws.Rows[11, Missing.Value]).Insert(Missing.Value, XlInsertFormatOrigin.xlFormatFromLeftOrAbove);
                _wbk.SaveAs(WholePath );
            }
             _wbk = wbks.Add(WholePath);
            Sheets shs = _wbk.Sheets;
            _Worksheet _wsh = (_Worksheet)shs.get_Item(0);
            int rowsCount = _wsh.UsedRange.Rows.Count;                       
            for (int i = 1;i<= rowsCount;i++)
            {
                Record record = new Record();
                record.strDate = DateTime.Parse(_wsh.Cells[i-1,0]);
                record.strType = _wsh.Cells[i-1, 1];
                record.dblMoney = double.Parse(_wsh.Cells[i-1, 2]);
                record.strName = _wsh.Cells[i-1, 3];
                record.dblID = _wsh.Cells[i-1,4];          
            }
            RecordCompareByDate recordCompare = new RecordCompareByDate();
            RecordList.Sort(recordCompare);//所有的项目记录表按时间排序

            return RecordList;
        }

        public void WriteDateToExcel(ArrayList RecordList,String WholePath)//保存修改
        {
            Application app = new Application();
            Workbooks wbks = app.Workbooks;
            _Workbook _wbk = wbks.Add(WholePath);
            Sheets shs = _wbk.Sheets;
            _Worksheet _wsh = (_Worksheet)shs.get_Item(0);
            int RecordNum = RecordList.Count;
            for(int i = 0; i< RecordNum;i++)
            {
                Record record = (Record)RecordList[i];
                _wsh.Cells[i + 1, 0] = record.strDate;
                _wsh.Cells[i + 1, 1] = record.strType;
                _wsh.Cells[i + 1, 2] = record.dblMoney;
                _wsh.Cells[i + 1, 3] = record.strName;
                _wsh.Cells[i + 1, 4] = record.strName;
            }
            

        }
      
        
        public void DrawLineGragh()
        {

        }
    }
}
