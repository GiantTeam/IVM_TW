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
                //页面上部，菜单栏：
        //重构函数：选择文件夹
        private string  selectFile()
    {
            string strFileWholePath  = "";
        OpenFileDialog fileDialog = new OpenFileDialog();
        fileDialog.Multiselect = true;
        fileDialog.Title = "请选择文件";
        fileDialog.Filter = "所有文件(*.*)|*.*";
         
        if (fileDialog.ShowDialog() == DialogResult.OK)
        {
          strFileWholePath = fileDialog.FileName;
            MessageBox.Show("已选择文件:" + strFileWholePath, "选择文件提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

            return strFileWholePath;
    }

    //重构函数：选择路径
    private void selectPath()
    {
        FolderBrowserDialog dialog = new FolderBrowserDialog();
        dialog.Description = "请选择文件路径";
        if (dialog.ShowDialog() == DialogResult.OK)
        {
            string foldPath = dialog.SelectedPath;
            MessageBox.Show("已选择文件夹:" + foldPath, "选择文件夹提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        
    }

    //重构函数：清空表格内容
    private void deleteAll()
    {
        int index;
        for (index = 0; index < grpAnalyse.Rows.Count;)
        {
            grpAnalyse.Rows.Remove(grpAnalyse.Rows[index]);
        }
    }

    //创建新的文件
    private void mmuNew_Click(object sender, EventArgs e)
    {
        
        deleteAll();
    }

    //清空文件内容
    private void mmuEmpty_Click(object sender, EventArgs e)
    {
        deleteAll();
        //将结果写入文件
    }

    //保存
    private void mmuSave_Click(object sender, EventArgs e)
    {
        //if(文件存在）
        //保存文件
        //else
        // selectPath();
        //保存文件

    }

    //导入
    private void mmuImport_Click(object sender, EventArgs e)
    {
     //       strFileWholePath = "C:\\Users\\campufix\\Desktop\\投资记录表.xlsx";
        string strFileWholePath = selectFile();
            Statistic sStatistic = new Statistic();
         ArrayList RecordList =  sStatistic.LoadDataFromExcel(strFileWholePath);

           
        //读取文件并显示
    }

    //导出
    private void mmuExport_Click(object sender, EventArgs e)
    {
        selectPath();
        //转化文件格式写出
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
        for (index = 0; index < grpAnalyse.Rows.Count; index++)
        {
            grpAnalyse.Rows[index].Selected = false;
        }
        index = addgrpRow(grpAnalyse);
        grpAnalyse.Rows[index].Selected = true;
        grpAnalyse.Rows[index].Cells[0].Value = index;
    }

    //删除按钮
    private void btnDelete_Click(object sender, EventArgs e)
    {
        for (int i = this.grpAnalyse.SelectedRows.Count; i > 0; i--)
        {
            int ID = Convert.ToInt32(grpAnalyse.SelectedRows[i - 1].Cells[0].Value);
            grpAnalyse.Rows.RemoveAt(grpAnalyse.SelectedRows[i - 1].Index);
            /* 使用获得的ID删除数据库的数据
             string SQL = "delete  from UserInfo where UserId='"+ID.ToString()+"'";
             int s =Convert.ToInt32(cl.Execute(SQL));  //cl是操作类的一个对像，Execute()是类中的一个方法
             if (s!=0)
             {
                 MessageBox.Show("成功删除选中行数据！");
             }
             */
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

    }
}
