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
        public String strShowPg;
        public static int s_pgNum = 0;
        public static int s_allPg;
        public static int s_maxItem=900;
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
        //重构函数：根据当前页面和表格行数刷新显示表格
        private void grvReFresh()
        {
           // s_pgNum;当前页数
           // c_ITEMNUM;
           //s_allPg;总页数
            for (int tem = 0 ; tem < c_ITEMNUM; tem++)
            {
                grvSearch.Rows[tem].Cells[0].Value = tem+s_pgNum*c_ITEMNUM;
                grvSearch.Rows[tem].Cells[1].Value = s_pgNum * c_ITEMNUM;
                grvSearch.Rows[tem].Cells[2].Value = (s_pgNum + 1) * c_ITEMNUM;
                grvSearch.Rows[tem].Cells[3].Value = 100 - tem;
            }      
        }

        //重构函数：为表格添加行
        private int addgrvRow(DataGridView grv)
        {
            DataGridViewRow Row = new DataGridViewRow();
            grv.RowHeadersWidth = 45;
            int index = grv.Rows.Add(Row);
            return index;
        }

        public void showPage()
        {
            strShowPg = "当前页数：" + s_pgNum + "      总页数：" + (int)s_maxItem/c_ITEMNUM;
            lblShowPg.Text = strShowPg;
        }
        //**************程序开始**************
        //加载框架
        private void frmMain_Load(object sender, EventArgs e)
        {
            mData record = new mData();
            record.setData();

            for (int i = 0; i < 8; i++)
            {
                int index = addgrvRow(grvSearch);
                grvSearch.Rows[index].Cells[0].Value = record.name;
                grvSearch.Rows[index].Cells[1].Value = record.date;
                grvSearch.Rows[index].Cells[2].Value = record.money;
                grvSearch.Rows[index].Cells[3].Value = record.rate;
                grvSearch.Rows[index].Cells[4].Value = "投资";
            }
            this.grvSearch.AutoGenerateColumns = false;
            showPage();
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
        private void rdo_checkedChange(RadioButton rdo, TextBox txtLow, TextBox txtHigh, Button btnConfirm)
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
            rdo_checkedChange(rdoSTime4, txtSTimeLow, txtSTimeHigh, btnTimeConfirm);
        }

        private void rdoSTime3_CheckedChanged(object sender, EventArgs e)
        {
            rdo_checkedChange(rdoSTime3, txtSTimeLow, txtSTimeHigh, btnTimeConfirm);
        }

        private void rdoSTime2_CheckedChanged(object sender, EventArgs e)
        {
            rdo_checkedChange(rdoSTime2, txtSTimeLow, txtSTimeHigh, btnTimeConfirm);
        }

        private void rdoSTime1_CheckedChanged(object sender, EventArgs e)
        {
            rdo_checkedChange(rdoSTime1, txtSTimeLow, txtSTimeHigh, btnTimeConfirm);
        }

        //第二组单选按钮框处理:处理起投金额
        private void rdoSMoney4_CheckedChanged(object sender, EventArgs e)
        {
            rdo_checkedChange(rdoSMoney4, txtSMoneyLow, txtSMoneyHigh, btnMoneyConfirm);
        }

        private void rdoSMoney3_CheckedChanged(object sender, EventArgs e)
        {
            rdo_checkedChange(rdoSMoney3, txtSMoneyLow, txtSMoneyHigh, btnMoneyConfirm);
        }

        private void rdoSMoney2_CheckedChanged(object sender, EventArgs e)
        {
            rdo_checkedChange(rdoSMoney2, txtSMoneyLow, txtSMoneyHigh, btnMoneyConfirm);
        }

        private void rdoSMoney1_CheckedChanged(object sender, EventArgs e)
        {
            rdo_checkedChange(rdoSMoney1, txtSMoneyLow, txtSMoneyHigh, btnMoneyConfirm);
        }

        //第三组单选按钮框处理:处理收益率
        private void rdoSRate4_CheckedChanged(object sender, EventArgs e)
        {
            rdo_checkedChange(rdoSRate4, txtSRateLow, txtSRateHigh, btnRateConfirm);
        }

        private void rdoSRate3_CheckedChanged(object sender, EventArgs e)
        {
            rdo_checkedChange(rdoSRate3, txtSRateLow, txtSRateHigh, btnRateConfirm);
        }

        private void rdoSRate2_CheckedChanged(object sender, EventArgs e)
        {
            rdo_checkedChange(rdoSRate2, txtSRateLow, txtSRateHigh, btnRateConfirm);
        }

        private void rdoSRate1_CheckedChanged(object sender, EventArgs e)
        {
            rdo_checkedChange(rdoSRate1, txtSRateLow, txtSRateHigh, btnRateConfirm);
        }


        //页面中部：设置排序方式
        //重构排序方式：参数：选中的单选按钮
        private void rdoSort_checkedChange(RadioButton rdo)
        {
            Int32 tIndex = Convert.ToInt32(rdo.Tag);
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
            //此处仅对表格排序，当总项目少于表格行数时有效
            //应改为调用外部接口对整个列表排序后刷新输出
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


        //页面下部：表格及增加记录按钮、翻页按钮
        //点击表格“投资”按钮跳到对应网页
        //注：LinkGet()未实现，应该修改为点击“投资”响应，点击其他选项不相应。

        private void grvSearch_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            //  System.Diagnostics.Process.Start("http://baidu.com");
        }
     
        //增加记录
        private void btnToRecord_Click(object sender, EventArgs e)
        {
            //弹出对话框
            frmDialog dlgHint = new frmDialog();
            dlgHint.ShowDialog();
            dlgHint.Visible = true;
            //新增一行
            int index = addgrvRow(grvAnalyse);
            //赋值
            grvAnalyse.Rows[index].Cells[0].Value = 0;
        }

        //翻页设置：上一页
        private void btnPageUp_Click(object sender, EventArgs e)
        {
           // s_pgNum = s_pgNum > 0 ? s_pgNum-- : 0;
            if (s_pgNum > 0)
            {
                s_pgNum--;
            }
            grvReFresh();
            showPage();
        }

        //翻页设置：下一页
        private void btnPageDown_Click(object sender, EventArgs e)
        {
            //s_pgNum = s_pgNum * c_ITEMNUM < s_maxItem ? s_pgNum++ : s_pgNum;
            if (s_pgNum < s_maxItem)
            {
                s_pgNum++;
            }
            grvReFresh();
            showPage();
        }


        //******************************************Analyse界面**********************************************
        //页面上部，菜单栏：
        //重构函数：选择文件夹
        private void selectFile()
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
            for (index = 0; index < grvAnalyse.Rows.Count; )
            {
                grvAnalyse.Rows.Remove(grvAnalyse.Rows[index]);
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
            selectFile();
            //读取文件并显示
        }

        //导出
        private void mmuExport_Click(object sender, EventArgs e)
        {
            selectPath();
            //转化文件格式写出
        }

        //页面中部：表格处理
        private void mmuDiagram_Click(object sender, EventArgs e)
        {

        }

        //页面下部
        //增加按钮
        private void btnAdd_Click(object sender, EventArgs e)
        {
            int index;
            for (index = 0; index < grvAnalyse.Rows.Count; index++)
            {
                grvAnalyse.Rows[index].Selected = false;
            }
            index=addgrvRow(grvAnalyse);
            grvAnalyse.Rows[index].Selected = true;
            grvAnalyse.Rows[index].Cells[0].Value= index;
        }

        //删除按钮
        private void btnDelete_Click(object sender, EventArgs e)
        {
            for (int i = this.grvAnalyse.SelectedRows.Count; i > 0; i--)
            {
                int ID = Convert.ToInt32(grvAnalyse.SelectedRows[i - 1].Cells[0].Value);
                grvAnalyse.Rows.RemoveAt(grvAnalyse.SelectedRows[i - 1].Index);
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


//******************************************Rush界面**************************************

        //页面上端
        //抢购按钮
        private void btnActionRush_Click(object sender, EventArgs e)
        {
            if (btnActionRush.Text.Equals("开始抢购"))
            {
                tmrRushReflash.Enabled = true;
                btnActionRush.Text = "停止抢购";
            }
            else
            {
                btnActionRush.Enabled = false;
                btnActionRush.Text = "开始抢购";       
            }

        }

        //刷新调用
        private void tmrRushReflash_Tick(object sender, EventArgs e)
        {
            //tmrRushReflash();

        }

        //条件按钮组设置
        //对第一组按钮组进行设置：投资期限
        private void rdoRTime4_CheckedChanged(object sender, EventArgs e)
        {
            rdo_checkedChange(rdoRTime4, txtRTimeLow, txtRTimeHigh, btnRConfirm);
        }

        private void rdoRTime3_CheckedChanged(object sender, EventArgs e)
        {
            rdo_checkedChange(rdoRTime3, txtRTimeLow, txtRTimeHigh, btnRConfirm);
        }

        private void rdoRTime2_CheckedChanged(object sender, EventArgs e)
        {
            rdo_checkedChange(rdoRTime2, txtRTimeLow, txtRTimeHigh, btnRConfirm);
        }

        private void rdoRTime1_CheckedChanged(object sender, EventArgs e)
        {
            rdo_checkedChange(rdoRTime1, txtRTimeLow, txtRTimeHigh, btnRConfirm);
        }

        //对第二组按钮组进行设置：投资金额
        private void rdoRMoney4_CheckedChanged(object sender, EventArgs e)
        {
            rdo_checkedChange(rdoRMoney4, txtRMoneyLow, txtRMoneyHigh, btnRConfirm);
        }

        private void rdoRMoney3_CheckedChanged(object sender, EventArgs e)
        {
            rdo_checkedChange(rdoRMoney3, txtRMoneyLow, txtRMoneyHigh, btnRConfirm);
        }

        private void rdoRMoney2_CheckedChanged(object sender, EventArgs e)
        {
            rdo_checkedChange(rdoRMoney2, txtRMoneyLow, txtRMoneyHigh, btnRConfirm);
        }

        private void rdoRMoney1_CheckedChanged(object sender, EventArgs e)
        {
            rdo_checkedChange(rdoRMoney1, txtRMoneyLow, txtRMoneyHigh, btnRConfirm);
        }

        //对第三组按钮组进行设置：收益率
        private void rdoRRate4_CheckedChanged(object sender, EventArgs e)
        {
            rdo_checkedChange(rdoRRate4, txtRRateLow, txtRRateHigh, btnRConfirm);
        }

        private void rdoRRate3_CheckedChanged(object sender, EventArgs e)
        {
            rdo_checkedChange(rdoRRate3, txtRRateLow, txtRRateHigh, btnRConfirm);
        }

        private void rdoRRate2_CheckedChanged(object sender, EventArgs e)
        {
            rdo_checkedChange(rdoRRate2, txtRRateLow, txtRRateHigh, btnRConfirm);
        }

        private void rdoRRate1_CheckedChanged(object sender, EventArgs e)
        {
            rdo_checkedChange(rdoRRate1, txtRRateLow, txtRRateHigh, btnRConfirm);
        }







    }
}
