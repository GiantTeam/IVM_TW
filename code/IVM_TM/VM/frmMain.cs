using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace VM
{
    public partial class frmMain : Form
    {
        public String strSearchInfo = null;
        public static int s_pgNum = 0;
        public static int s_maxItem;
        const int c_ITEMNUM = 8;
        public mData g_SearchCondition;
        public RadioButton rdoTem;
        public static ListSortDirection s_lsdSUpDown = ListSortDirection.Ascending;

        public class mData
        {
            public String name;
            public String money;
            public String date;
            public String rate;

            public void setData()
            {
                name = "lin";
                money = "200";
                date = "2016/4/30";
                rate = "5%";
            }
        }


        //***************************华丽的分割线***********************************************

        public frmMain()
        {
            InitializeComponent();
        }

        private void btnTimeConfirm_Click(object sender, EventArgs e)
        {
            /* foreach (Control ct in grpSTime.Controls) 
             { 
                 RadioButton rb = ct as RadioButton; 
                 if (rb.Checked) 
                 {
                     rdoTem = rb;
                 }
             }
             if (rdoTem.Equals(rdoSTime4))
             {
                 return txtSTimeLow.Txt+txtSTimeHigh;
             }
             else
             {
                 return rdoTem.toText();

             }*/
        }


//**************************************Search界面处理***********************************************
        //加载框架
        private void frmMain_Load(object sender, EventArgs e)
        {
            mData record = new mData();
            record.setData();
            for (int i = 0; i < 8; i++)
            {
                DataGridViewRow Row = new DataGridViewRow();
                grvSearch.RowHeadersWidth = 45;

                int index = grvSearch.Rows.Add(Row);
                grvSearch.Rows[index].Cells[0].Value = record.name;
                grvSearch.Rows[index].Cells[1].Value = record.date;
                grvSearch.Rows[index].Cells[2].Value = record.money;
                grvSearch.Rows[index].Cells[3].Value = record.rate;
                grvSearch.Rows[index].Cells[4].Value = "投资";
            }
            this.grvSearch.AutoGenerateColumns = false;
        }

        //页面上部：搜索功能
        //点击搜索按钮
        private void btnSearch_Click(object sender, EventArgs e)
        {
            if (txtSearch.Text != null)
            {
                strSearchInfo = txtSearch.Text;
                //SearchFromWeb(strSearchInfo);
            }
        }


        //页面上部：选择搜索条件
        //重构函数：点击单选按钮组，自有在“其它”的情况下，输入框可编辑,确定按钮值Tag为“1”
        //第一个参数为传入的选中单选按钮，第二三为对应的编辑框，第四位其后的确定按钮
        private void rdoSSearch_checkedChange(RadioButton rdo, TextBox txtLow, TextBox txtHigh, Button btnConfirm)
        {
            if (1 == Convert.ToInt32(rdo.Tag))
            {
                txtLow.Enabled = true;
                txtHigh.Enabled = true;
                btnConfirm.Tag = 1;
            }
            else
            {
                txtLow.Enabled = false;
                txtHigh.Enabled = false;
                btnConfirm.Tag = 0;
            }
        }

        //Search界面第一组单选按钮组处理：
        private void rdoSTime4_CheckedChanged(object sender, EventArgs e)
        {
            rdoSSearch_checkedChange(rdoSTime4, txtSTimeLow, txtSTimeHigh, btnTimeConfirm);
        }

        private void rdoSTime3_CheckedChanged(object sender, EventArgs e)
        {
            rdoSSearch_checkedChange(rdoSTime3, txtSTimeLow, txtSTimeHigh, btnTimeConfirm);
        }

        private void rdoSTime2_CheckedChanged(object sender, EventArgs e)
        {
            rdoSSearch_checkedChange(rdoSTime2, txtSTimeLow, txtSTimeHigh, btnTimeConfirm);
        }

        private void rdoSTime1_CheckedChanged(object sender, EventArgs e)
        {
            rdoSSearch_checkedChange(rdoSTime1, txtSTimeLow, txtSTimeHigh, btnTimeConfirm);
        }

        //第二组单选按钮框处理:处理起投金额
        private void rdoSMoney4_CheckedChanged(object sender, EventArgs e)
        {
            rdoSSearch_checkedChange(rdoSMoney4, txtSMoneyLow, txtSMoneyHigh, btnMoneyConfirm);
        }

        private void rdoSMoney3_CheckedChanged(object sender, EventArgs e)
        {
            rdoSSearch_checkedChange(rdoSMoney3, txtSMoneyLow, txtSMoneyHigh, btnMoneyConfirm);
        }

        private void rdoSMoney2_CheckedChanged(object sender, EventArgs e)
        {
            rdoSSearch_checkedChange(rdoSMoney2, txtSMoneyLow, txtSMoneyHigh, btnMoneyConfirm);
        }

        private void rdoSMoney1_CheckedChanged(object sender, EventArgs e)
        {
            rdoSSearch_checkedChange(rdoSMoney1, txtSMoneyLow, txtSMoneyHigh, btnMoneyConfirm);
        }

        //第三组单选按钮框处理:处理收益率
        private void rdoSRate4_CheckedChanged(object sender, EventArgs e)
        {
            rdoSSearch_checkedChange(rdoSRate4, txtSRateLow, txtSRateHigh, btnRateConfirm);
        }

        private void rdoSRate3_CheckedChanged(object sender, EventArgs e)
        {
            rdoSSearch_checkedChange(rdoSRate3, txtSRateLow, txtSRateHigh, btnRateConfirm);
        }

        private void rdoSRate2_CheckedChanged(object sender, EventArgs e)
        {
            rdoSSearch_checkedChange(rdoSRate2, txtSRateLow, txtSRateHigh, btnRateConfirm);
        }

        private void rdoSRate1_CheckedChanged(object sender, EventArgs e)
        {
            rdoSSearch_checkedChange(rdoSRate1, txtSRateLow, txtSRateHigh, btnRateConfirm);
        }


        //页面中部：设置排序方式
        //重构排序方式：参数：选中的单选按钮
        private void rdoSort_checkedChange(RadioButton rdo)
        {
           Int32 tIndex= Convert.ToInt32(rdo.Tag);
            grvSearch.Sort(grvSearch.Columns[tIndex], s_lsdSUpDown);
        }
        //重构排序方式：参数：按钮所在的组合框，找到选中的按钮，再调用rdoSort_checkedChange
        private void rdoSort_checkedChange(GroupBox grpSort)
        {
            foreach (Control ct in grpSort.Controls)
            {
                RadioButton rb = ct as RadioButton;
                if (rb.Checked)
                {
                    rdoTem = rb;
                }
            }
            rdoSort_checkedChange(rdoTem);
        }

        //默认排序
        private void rdoSortDefault_CheckedChanged(object sender, EventArgs e)
        {
            rdoSort_checkedChange(rdoSortDefault);
        }

        //按投资期限排序
        private void rdoSortTime_CheckedChanged(object sender, EventArgs e)
        {
            rdoSort_checkedChange(rdoSortTime);
        }

        //按起投金额排序
        private void rdoSortMoney_CheckedChanged(object sender, EventArgs e)
        {
            rdoSort_checkedChange(rdoSortMoney);
        }

        //按收益率排序
        private void rdoSortRate_CheckedChanged(object sender, EventArgs e)
        {
            rdoSort_checkedChange(rdoSortRate);
        }

        private void rdoSortUp_CheckedChanged(object sender, EventArgs e)
        {
            s_lsdSUpDown = ListSortDirection.Ascending;
            rdoSort_checkedChange(grpSort);
        }

        private void rdoSortDown_CheckedChanged(object sender, EventArgs e)
        {
            s_lsdSUpDown = ListSortDirection.Descending;
            rdoSort_checkedChange(grpSort);
        }

        //抢购按钮
        private void btnRush_Click(object sender, EventArgs e)
        {

        }


        //页面下部：表格及翻页按钮
        //点击表格“投资”按钮跳到对应网页
        //注：LinkGet()未实现，应该修改为点击“投资”响应，点击其他选项不相应。
        private void grvSearch_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            //LinkGet();
            //  System.Diagnostics.Process.Start("http://baidu.com");
         }

        private void grvSearch_CellClick(object sender, DataGridViewCellEventArgs e)
        {
           // System.Diagnostics.Process.Start("http://baidu.com");
        }

        //翻页设置：上一页
        private void btnPageUp_Click(object sender, EventArgs e)
        {
            s_pgNum = s_pgNum > 0 ? s_pgNum-- : 0;
        }

        //翻页设置：下一页
        private void btnPageDown_Click(object sender, EventArgs e)
        {
            s_pgNum = s_pgNum * c_ITEMNUM < s_maxItem ? s_pgNum++ : s_pgNum;
        }


//******************************************Analyse界面**********************************************
        private void mmuNew_Click(object sender, EventArgs e)
        {

        }

        private void mmuSave_Click(object sender, EventArgs e)
        {

        }

        private void mmuEmpty_Click(object sender, EventArgs e)
        {

        }

        private void mmuImport_Click(object sender, EventArgs e)
        {
            OpenFileDialog fileDialog = new OpenFileDialog();
            fileDialog.Multiselect = true;
            fileDialog.Title = "请选择文件";
            fileDialog.Filter = "所有文件(*.*)|*.*";
            if (fileDialog.ShowDialog() == DialogResult.OK)
            {
                string file = fileDialog.FileName;
                MessageBox.Show("已选择文件:" + file, "选择文件提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void mmuExport_Click(object sender, EventArgs e)
        {

        }

        private void mmuDiagram_Click(object sender, EventArgs e)
        {

        }

        private void btnAdd_Click(object sender, EventArgs e)
        {

        }

        private void btnDelete_Click(object sender, EventArgs e)
        {

        }





    }
}
