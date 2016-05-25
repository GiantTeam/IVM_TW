using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Collections;
using ControlClass;
using EntityClass;
using ClassLibrary;
namespace VM
{
    // StatistisGUI
    public partial class frmMain : Form
    {
        public static string strDefaultExcelFileWholePath = "投资记录表.xls";
        string strExcelFileWholePath = strDefaultExcelFileWholePath;
        static public ArrayList RecordList = new ArrayList();
        static public Statistic sStatistic = new Statistic();
        //页面上部，菜单栏：
      
        //重构函数：清空表格内容
        private void ClearWholeTable()
        {
            int index;
            for (index = 0; index < grpStatisticTable.Rows.Count;)
            {
                grpStatisticTable.Rows.RemoveAt(index);
            }
        }

        //创建新的文件
        private void mmuNew_Click(object sender, EventArgs e)
        {
            ClearWholeTable();//清空表的内容
            strExcelFileWholePath = "";
            RecordList.Clear();
            MessageBox.Show("新建成功，请点击“添加”添加数据！");
        }

        //清空文件内容
        private void mmuEmpty_Click(object sender, EventArgs e)
        {
            ClearWholeTable();
            RecordList.Clear();
            //将结果写入文件
            sStatistic.WriteDataToExcel(RecordList, strExcelFileWholePath);
        }

        //保存
        private void mmuSave_Click(object sender, EventArgs e)
        {
            saveToExcel();
        }

        private void saveToExcel()
        {
            //生成RecordList中的内容      
            if (strExcelFileWholePath == "")
            {
                SaveFileDialog frm = new SaveFileDialog();
                frm.Filter = "Excel文件(*.xls,xlsx)|*.xls;*.xlsx";
                frm.FileName = "投资记录表.xlsx";
                if (frm.ShowDialog() == DialogResult.OK)
                {
                    strExcelFileWholePath = frm.FileName;
                }
            }
            sStatistic.WriteDataToExcel(RecordList, strExcelFileWholePath);
        }

        //导入
        public  void mmuImport_Click(object sender, EventArgs e)
        {
            OpenFileDialog frm = new OpenFileDialog();
            frm.Filter = "Excel文件(*.xls,xlsx)|*.xls;*.xlsx";
            if (frm.ShowDialog() == DialogResult.OK)
            {
                strExcelFileWholePath = frm.FileName;              
                RecordList = sStatistic.LoadDataFromExcel(strExcelFileWholePath);
                //显示RecorlList的中的内容                     
                ShowContentOfRecordList();
            }                               
  
        }

        //导出
        private void mmuExport_Click(object sender, EventArgs e)
        {
            SaveFileDialog frm = new SaveFileDialog();
            frm.Filter = "Excel文件(*.xls,xlsx)|*.xls;*.xlsx";
            frm.FileName = "投资记录表.xlsx";
            if (frm.ShowDialog() == DialogResult.OK)
            {
                strExcelFileWholePath = frm.FileName;
            }
            sStatistic.WriteDataToExcel(RecordList, strExcelFileWholePath);
        }

        //页面中部：表格处理
        private void mmuChart_Click(object sender, EventArgs e)
        {
            frmChart chart;
            chart = new frmChart();
            chart.Show();
        }

        //页面下部
        //增加按钮
        private void btnAdd_Click(object sender, EventArgs e)
        {
            AddRecord();
        }

        private void AddRecord(double money=0,string name="",double id=-1,string type="投资")
        {
            int index;
            for (index = 0; index < grpStatisticTable.Rows.Count; index++)
            {
                grpStatisticTable.Rows[index].Selected = false;
            }
            index = addgrpRow(grpStatisticTable);
            grpStatisticTable.Rows[index].Selected = true;
            Record record = new Record();
           if(id==-1)
                id=index;
            record.dtmDate = System.DateTime.Now;
            record.dblID = id;
            record.dblMoney = money;
            record.strType = type;
            record.strName = name;
            RecordList.Add(record);
            MessageBox.Show("已成功添加一条记录！");
            ShowContentOfRecordList();
        }

        //删除按钮
        private void btnDelete_Click(object sender, EventArgs e)
        {
            for (int index = 0; index < grpStatisticTable.Rows.Count; index++)
            {
                if (grpStatisticTable.Rows[index].Selected == true)
                {
                    grpStatisticTable.Rows.RemoveAt(index);
                    RecordList.RemoveAt(index);                 
                    sStatistic.WriteDataToExcel(RecordList, strExcelFileWholePath);
                    break;
                }
            }
        }

        //重构函数：为表格添加行
        private int addgrpRow(DataGridView grp)
        {
            DataGridViewRow Row = new DataGridViewRow();
            grp.RowHeadersWidth = 45;
            int index = grp.Rows.Add(Row);
            return index;
        }

        private void  ShowContentOfRecordList()
        {
            ClearWholeTable();
            int RecordCount = RecordList.Count;
            for (int i = 0; i < RecordCount; i++)
            {
                Record record = (Record)RecordList[i];
                double TempRecordID = record.dblID;
                bool ShuhuiOrNot = false;//默认没有赎回
                for(int recordIndex = i+1;recordIndex < RecordCount; recordIndex++)
                {
                    if (TempRecordID == ((Record)RecordList[recordIndex]).dblID)
                    {
                        ShuhuiOrNot = true;
                        break;
                    }
                }
                int index = addgrpRow(grpStatisticTable);
                grpStatisticTable.Rows[index].Cells[0].Value = record.dtmDate;
                grpStatisticTable.Rows[index].Cells[1].Value = record.strType;
                grpStatisticTable.Rows[index].Cells[2].Value = record.dblMoney;
                grpStatisticTable.Rows[index].Cells[3].Value = record.strName;
                grpStatisticTable.Rows[index].Cells[4].Value = record.dblID;
                if (record.strType.Equals("赎回"))
                {
                    grpStatisticTable.Rows[index].Cells[5].Value = "";
                }
                else
                grpStatisticTable.Rows[index].Cells[5].Value =( ShuhuiOrNot == false) ? "赎回" : "";           
            }
        }

    }
}
