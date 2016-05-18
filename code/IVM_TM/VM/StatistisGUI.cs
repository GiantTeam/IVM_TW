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
        static string strDefaultExcelFileWholePath = "投资记录表.xls";
        string strExcelFileWholePath = strDefaultExcelFileWholePath;
        ArrayList RecordList = new ArrayList();
        public  Statistic sStatistic = new Statistic();

        //页面上部，菜单栏：
        //重构函数：选择文件夹
        //private string selectFile()
        //{
        //    string strFileWholePath = "";
        //    OpenFileDialog fileDialog = new OpenFileDialog();
        //    fileDialog.Multiselect = true;
        //    fileDialog.Title = "请选择文件";
        //    fileDialog.Filter = "所有文件(*.*)|*.*";

        //    if (fileDialog.ShowDialog() == DialogResult.OK)
        //    {
        //        strFileWholePath = fileDialog.FileName;
        //        MessageBox.Show("已选择文件:" + strFileWholePath, "选择文件提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
        //    }

        //    return strFileWholePath;
        //}

        //重构函数：选择路径
        //private void selectPath()
        //{
        //    FolderBrowserDialog dialog = new FolderBrowserDialog();
        //    dialog.Description = "请选择文件路径";
        //    if (dialog.ShowDialog() == DialogResult.OK)
        //    {
        //        string foldPath = dialog.SelectedPath;
        //        MessageBox.Show("已选择文件夹:" + foldPath, "选择文件夹提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
        //    }

        //}

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
        //    sStatistic.WriteDataToExcel(RecordList, strExcelFileWholePath);
        }

        //刷新函数
        public void reflush()
        {
            RecordList.Clear();
            for (int index = 0; index < grpStatisticTable.Rows.Count; )
            {
                 saveAddRecord(index);
            }
            saveToExcel();
        }

        //绑定刷新与保存
        public void save()
        {
           // reflush();
            saveToExcel();
        }

        //保存
        private void mmuSave_Click(object sender, EventArgs e)
        {
            save();
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
              //  int count = grpStatisticTable.RowCount;
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
            int index;
            for (index = 0; index < grpStatisticTable.Rows.Count; index++)
            {
                grpStatisticTable.Rows[index].Selected = false;
            }
            index = addgrpRow(grpStatisticTable);
            grpStatisticTable.Rows[index].Selected = true;
            grpStatisticTable.Rows[index].Cells[0].Value = index;

           // saveToExcel();
        }

        private void saveAddRecord(int index)
        {
            Record record = new Record();
            record.dtmDate = (System.DateTime)grpStatisticTable.Rows[index].Cells[0].Value;
            record.strType = (string)grpStatisticTable.Rows[index].Cells[1].Value;
            record.dblMoney = (double)grpStatisticTable.Rows[index].Cells[2].Value;
            record.strName = (string)grpStatisticTable.Rows[index].Cells[3].Value;
        }

        //删除按钮
        private void btnDelete_Click(object sender, EventArgs e)
        {
            int ID=-1;
            for (int i = this.grpStatisticTable.SelectedRows.Count; i > 0; i--)
            {
                ID = Convert.ToInt32(grpStatisticTable.SelectedRows[i - 1].Cells[4].Value);
                grpStatisticTable.Rows.RemoveAt(grpStatisticTable.SelectedRows[i - 1].Index);
            }
            MessageBox.Show("ID=" + ID);
                int indexOfRecord = -1;
            foreach (Record record in RecordList)
            {
                if(record.dblID == ID)
                {
                    indexOfRecord= RecordList.IndexOf(record);
                    break;
                }
            }
                RecordList.RemoveAt(indexOfRecord);
                MessageBox.Show("delete from list!");
                save();
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
                // int count = grpStatisticTable.RowCount;
               // int index = grpStatisticTable.Rows.Add();
                int index = addgrpRow(grpStatisticTable);
                grpStatisticTable.Rows[index].Cells[0].Value = record.dtmDate;
                grpStatisticTable.Rows[index].Cells[1].Value = record.strType;
                grpStatisticTable.Rows[index].Cells[2].Value = record.dblMoney;
                grpStatisticTable.Rows[index].Cells[3].Value = record.strName;
                grpStatisticTable.Rows[index].Cells[4].Value =( ShuhuiOrNot == false) ? "赎回" : "";
                    // grpSearch.Rows[i].Cells[5].Value = record.dblID;             
            }
        }

    }
}
