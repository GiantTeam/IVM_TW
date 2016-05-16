using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using EntityClass;
using System.Reflection;
using Excel= Microsoft.Office.Interop.Excel;
//using Excel;
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
            _Workbook _wbk;
            Workbooks wbks = app.Workbooks;
            if (!File.Exists(WholePath))
            {
                _wbk = wbks.Add(true);
                Sheets sh = _wbk.Sheets;
                _Worksheet _ws = (_Worksheet)sh.get_Item(1);
                _ws.Cells[0, 0] = "Time";
                 _ws.Cells[0, 1] = "类型";
                _ws.Cells[0, 2] = "金额";
                _ws.Cells[0.3] = "项目";
                ((Range)_ws.Rows[11, Missing.Value]).Insert(Missing.Value, XlInsertFormatOrigin.xlFormatFromLeftOrAbove);
                _wbk.SaveAs(WholePath);
            }

            _wbk = wbks.Add(WholePath);
            Sheets shs = _wbk.Sheets;
            _Worksheet _wsh = (_Worksheet)shs.get_Item(1);
            int rowsCount = _wsh.UsedRange.Rows.Count;
            for (int i = 1; i <= rowsCount; i++)
            {
                Record record = new Record();
                record.strType = _wsh.Cells[i - 1, 1];
                record.dtmDate = DateTime.Parse(_wsh.Cells[i - 1, 0]);
               
                record.dblMoney = double.Parse(_wsh.Cells[i - 1, 2]);
                record.strName = _wsh.Cells[i - 1, 3];
                record.dblID = _wsh.Cells[i - 1, 4];
            }
            RecordCompareByTime cmpCompareByTime = new RecordCompareByTime();
            RecordList.Sort(cmpCompareByTime);//所有的项目记录表按时间排序

            return RecordList;
        }

        public void WriteDateToExcel(ArrayList RecordList, String WholePath)//保存修改
        {
            Application app = new Application();
            Workbooks wbks = app.Workbooks;
            _Workbook _wbk = wbks.Add(WholePath);
            Sheets shs = _wbk.Sheets;
            _Worksheet _wsh = (_Worksheet)shs.get_Item(0);
            int RecordNum = RecordList.Count;
            for (int i = 0; i < RecordNum; i++)
            {
                Record record = (Record)RecordList[i];
                _wsh.Cells[i + 1, 0] = record.dtmDate;
                _wsh.Cells[i + 1, 1] = record.strType;
                _wsh.Cells[i + 1, 2] = record.dblMoney;
                _wsh.Cells[i + 1, 3] = record.strName;
                _wsh.Cells[i + 1, 4] = record.strName;
            }


        }

        public void WriteAndAutoSaveXls()
        {
            Excel.Application excel = new Excel.Application();
            //Range range = null;// 创建一个空的单元格对象 
            //Worksheet sheet = null;
            Range range = null;// 创建一个空的单元格对象 
            Worksheet sheet = null;
            try
            {
                // 注释掉的语句是:从磁盘指定位置打开一个 Excel 文件 
                //excel.Workbooks.Open("demo.xls", Missing.Value, Missing.Value,  
                //Missing.Value,Missing.Value, Missing.Value, Missing.Value,  
                //Missing.Value, Missing.Value, Missing.Value, Missing.Value,  
                //Missing.Value, Missing.Value, Missing.Value, Missing.Value); 
                if (excel == null)
                {
                    //Response.Write("不能创建excle文件");
                }
                excel.Visible = false;// 不显示 Excel 文件,如果为 true 则显示 Excel 文件 
                excel.Workbooks.Add(Missing.Value);// 添加工作簿 
                                                   //使用 Missing 类的此实例来表示缺少的值，例如，当您调用具有默认参数值的方法时。 
                sheet = (Worksheet)excel.ActiveSheet;// 获取当前工作表 


                sheet.get_Range(sheet.Cells[29, 2], sheet.Cells[29, 2]).Orientation = Excel.XlOrientation.xlVertical;//字体竖直居中在单元格内 


                range = sheet.get_Range("A1", Missing.Value);// 获取单个单元格 
                range.RowHeight = 20;           // 设置行高 
                range.ColumnWidth = 20;         // 设置列宽 
                range.Borders.LineStyle = 1;    // 设置单元格边框 
                range.Font.Bold = true;         // 加粗字体 
                range.Font.Size = 20;           // 设置字体大小 
                range.Font.ColorIndex = 5;      // 设置字体颜色 
                range.Interior.ColorIndex = 6;  // 设置单元格背景色 
                range.HorizontalAlignment = XlHAlign.xlHAlignCenter;// 设置单元格水平居中 
                range.VerticalAlignment = XlVAlign.xlVAlignCenter;// 设置单元格垂直居中 
                range.Value2 = "设置行高和列宽";// 设置单元格的值 

                range = sheet.get_Range("B2", "D4");// 获取多个单元格 
                range.Merge(Missing.Value);         // 合并单元格 
                range.Columns.AutoFit();            // 设置列宽为自动适应 
                range.NumberFormatLocal = "#,##0.00";// 设置单元格格式为货币格式 
                                                     // 设置单元格左边框加粗 
                range.Borders[XlBordersIndex.xlEdgeLeft].Weight = XlBorderWeight.xlThick;
                // 设置单元格右边框加粗 
                range.Borders[XlBordersIndex.xlEdgeRight].Weight = XlBorderWeight.xlThick;
                range.Value2 = "合并单元格";

                // 页面设置 
                sheet.PageSetup.PaperSize = XlPaperSize.xlPaperA4;          // 设置页面大小为A4 
                sheet.PageSetup.Orientation = XlPageOrientation.xlPortrait; // 设置垂直版面 
                sheet.PageSetup.HeaderMargin = 0.0;                         // 设置页眉边距 
                sheet.PageSetup.FooterMargin = 0.0;                         // 设置页脚边距 
                sheet.PageSetup.LeftMargin = excel.InchesToPoints(0.354330708661417); // 设置左边距 
                sheet.PageSetup.RightMargin = excel.InchesToPoints(0.354330708661417);// 设置右边距 
                sheet.PageSetup.TopMargin = excel.InchesToPoints(0.393700787401575);  // 设置上边距 
                sheet.PageSetup.BottomMargin = excel.InchesToPoints(0.393700787401575);// 设置下边距 
                sheet.PageSetup.CenterHorizontally = true;                  // 设置水平居中 

                // 打印文件 
                sheet.PrintOut(Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value);

                // 保存文件到程序运行目录下 
                sheet.SaveAs("C:\\Users\\campufix\\Desktop\\hhh.xls", Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value);
                excel.ActiveWorkbook.Close(false, null, null); // 关闭 Excel 文件且不保存 
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                //  Response.Write(ex.Message);
            }
            finally
            {
                excel.Quit(); // 退出 Excel 
                System.Runtime.InteropServices.Marshal.ReleaseComObject(range);
                System.Runtime.InteropServices.Marshal.ReleaseComObject(sheet);
                System.Runtime.InteropServices.Marshal.ReleaseComObject(excel);
                GC.Collect();



            }
        }
        public void DrawLineGragh()
        {

        }
    }
}
