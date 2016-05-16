using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Data.OleDb;
using Excel = Microsoft.Office.Interop.Excel;
using Microsoft.Office.Interop.Excel;

using System.Reflection;
using System.Runtime.InteropServices;// For COMException 

public partial class readandwrite_excel : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        ReadExcel();
        Response.Write("下面是写入XLS文件");
        WriteXls();


        WriteAndAutoSaveXls();
    }
    /// <summary> 
    /// 读取一个XLSW文件并显示出来 
    /// </summary> 
    public void ReadExcel()
    {
        string oleconn = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=e:\\WebCHat\\excel\\test.xls;Extended Properties='Excel 8.0;HDR=NO'";
        //  HDR=NO　即无字段 
        //   HDR=yes　即有字段，一般默认excel表中第1行的列标题为字段名，如姓名、年龄等 
        //如果您在连接字符串中指定 HDR=NO，Jet OLE DB 提供程序将自动为您命名字段（F1 表示第一个字段，F2 表示第二个字段，依此类推）； 
        // IMEX　表示是否强制转换为文本 
        //   Excel 驱动程序读取指定源中一定数量的行（默认情况下为 8 行）以推测每列的数据类型。 
        //如果推测出列可能包含混合数据类型（尤其是混合了文本数据的数值数据时）， 
        //驱动程序将决定采用占多数的数据类型，并对包含其他类型数据的单元返回空值。 
        //（如果各种数据类型的数量相当，则采用数值类型。） 
        //Excel 工作表中大部分单元格格式设置选项不会影响此数据类型判断。 
        //可以通过指定导入模式来修改 Excel 驱动程序的此行为。 
        //若要指定导入模式，请在“属性”窗口中将 IMEX=1 添加到 Excel 
        //连接管理器的连接字符串内的扩展属性值中。 
        OleDbConnection conn = new OleDbConnection(oleconn);
        conn.Open();
        string str_sql = "select * from [Sheet1$]";
        OleDbDataAdapter oda = new OleDbDataAdapter(str_sql, conn);
        DataSet ds = new DataSet();
        oda.Fill(ds);

        conn.Close();
      //  GridView1.DataSource = ds;
    //    GridView1.DataBind();
    }



    /// <summary> 
    /// 将一些数据写入到一个XLS文件中 
    /// </summary> 

    public void WriteXls()
    {
        Excel.Application excel = new Excel.Application();
        excel.Workbooks.Add(true);
        excel.Cells[1, 1] = "1,1";
        excel.Cells[1, 2] = "1,2";
        excel.Cells[1, 3] = "1,3";
        excel.Cells[2, 1] = "2,1";
        excel.Cells[2, 2] = "2,2";
        excel.Cells[2, 3] = "2,3";
        excel.Visible = true;
        
    }

    /// <summary> 
    /// 实现自动保存 
    /// </summary> 
    /// ///参考 http://hi.baidu.com/happybadbaby/blog/item/c396ae231ef5f4549822ed58.html 
    public void WriteAndAutoSaveXls()
    {
        Excel.Application excel = new Excel.Application();
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
                Response.Write("不能创建excle文件");
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
            sheet.SaveAs("e:\\WebChat\\excel\\demo.xls", Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value);
            excel.ActiveWorkbook.Close(false, null, null); // 关闭 Excel 文件且不保存 
        }
        catch (Exception ex)
        {
            Response.Write(ex.Message);
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
}

