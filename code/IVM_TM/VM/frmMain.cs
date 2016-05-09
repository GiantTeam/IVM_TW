using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Collections;
//using ControlClass;
//using EntityClass;

namespace VM
{
    public partial class frmMain : Form
    {
        public String strSearchInfo = null;
        public String strShowPg;
        public static String strAddInfo = null;
        public String strExpression;
        public static int s_pgNum = 0;
        public static int s_allPg;
        public static int s_maxItem=22;

        const int c_ITEMNUM = 8;
        const int c_iMAX = 999999;
        const int c_iMIN = -99999;
        const double c_dMAX = 999999;
        const double c_dMIN = -99999;

        public Condition cdtS,cdtR;
        public RadioButton rdoTem;
        public static ListSortDirection s_lsdSUpDown = ListSortDirection.Ascending;

       // Project project;
       // ProjectList projectList; 
        public class Condition
        {
            public int TimeUp;
            public int TimeDown;
            public double RateUp;
            public double RateDown;
            public double MoneyDown;
            public double MoneyUp;
            public void set(Condition cdt)
            {
                this.TimeDown = cdt.TimeDown;
                this.TimeUp = cdt.TimeUp;
                this.MoneyDown = cdt.MoneyDown;
                this.MoneyUp = cdt.MoneyUp;
                this.RateUp = cdt.RateUp;
                this.RateDown = cdt.RateDown;
            }
        }

//***************************************华丽的分割线**************************************************

        public frmMain()
        {
            InitializeComponent();
        }

        //将单选按钮组转化为对应表达式：投资期限
        public void grpSetTime(GroupBox grp,Condition cdt,TextBox txtl,TextBox txth)
        {
            int tem;
            tem = grpGetResult(grp);
            switch (tem)
            {
                case 0:
                    {
                        if (txtl.Text != "" && txth.Text != "")
                        {
                            cdt.TimeDown = Convert.ToInt32(txtl.Text);
                            cdt.TimeUp = Convert.ToInt32(txth.Text);
                        }
                        else
                        {
                            MessageBox.Show("请将搜索信息补充完整！");
                        }
                        break;
                    }
                case 1:
                    {
                        cdtS.TimeDown = 12;
                        cdtS.TimeUp = c_iMAX;
                        break;
                    }
                case 2:
                    {
                        cdt.TimeDown = 6;
                        cdt.TimeUp = 12;
                        break;
                    }
                case 3:
                    {
                        cdt.TimeDown = c_iMIN;
                        cdt.TimeUp = 6;
                        break;
                    }
                case 4:
                    {
                        cdt.TimeDown = c_iMIN;
                        cdt.TimeUp = c_iMAX;
                        break;
                    }
                default:
                    break;
            }
        }

        //将单选按钮组转化为对应表达式：投资金额
        public void grpSetMoney(GroupBox grp, Condition cdt, TextBox txtl, TextBox txth)
        {
            int tem;
            tem = grpGetResult(grp);
            switch (tem)
            {
                case 0:
                    {
                        if (txtl.Text != "" && txth.Text != "")
                        {
                            cdt.MoneyDown = Convert.ToDouble(txtl.Text);
                            cdt.MoneyUp = Convert.ToDouble(txth.Text);
                        }
                        else
                        {
                            MessageBox.Show("请将搜索信息补充完整！");
                        }
                        break;
                    }
                case 1:
                    {
                        cdt.MoneyDown = 5;
                        cdt.MoneyUp = 10;
                        break;
                    }
                case 2:
                    {
                        cdt.MoneyDown = 1;
                        cdt.MoneyUp = 5;
                        break;
                    }
                case 3:
                    {
                        cdt.MoneyDown = c_dMIN;
                        cdt.MoneyUp = 1;
                        break;
                    }
                case 4:
                    {
                        cdt.MoneyDown = c_dMIN;
                        cdt.MoneyUp = c_dMAX;
                        break;
                    }
                default:
                    break;
            }
        }

        //将单选按钮组转化为对应表达式：收益率
        public void grpSetRate(GroupBox grp, Condition cdt, TextBox txtl, TextBox txth)
        {
            int tem;
            tem = grpGetResult(grp);
            switch (tem)
            {
                case 0:
                    {
                        if (txtl.Text != "" && txth.Text != "")
                        {
                            cdt.RateDown = Convert.ToDouble(txtl.Text);
                            cdt.RateUp = Convert.ToDouble(txth.Text);
                        }
                        else
                        {
                            MessageBox.Show("请将搜索信息补充完整！");
                        }
                        break;
                    }
                case 1:
                    {
                        cdt.RateDown = 10;
                        cdt.RateUp = c_dMAX;
                        break;
                    }
                case 2:
                    {
                        cdt.RateDown = 5;
                        cdt.RateUp = 10;
                        break;
                    }
                case 3:
                    {
                        cdt.RateDown = c_dMIN;
                        cdt.RateUp = 5;
                        break;
                    }
                case 4:
                    {
                        cdt.RateDown = c_dMIN;
                        cdt.RateUp = c_dMAX;
                        break;
                    }
                default:
                    break;
            }
        }
      
//**************************************Search界面处理***********************************************
       //重构函数：判断单选按钮组选中情况
        public Int32  grpGetResult(GroupBox grp)
        {
             foreach (Control ct in grp.Controls) 
             {
                 if (ct is RadioButton)
                 {
                     RadioButton rb = ct as RadioButton;
                     if (rb.Checked == true)
                     {
                         return Convert.ToInt32(rb.Tag);
                     }
                 }
             }
             return -1;
        }

        public void grpSetgrp(GroupBox grp1, GroupBox grp2)
        {
            int tem;
            tem=grpGetResult(grp1);
            if (-1 != tem)
            {
                foreach (Control ct in grp2.Controls)
                {
                    if (ct is RadioButton)
                    {
                        RadioButton rb = ct as RadioButton;
                        if (Convert.ToInt32(rb.Tag) == tem)
                        {
                            rb.Checked = true;
                        }
                        else
                        {
                            rb.Checked = false;
                        }
                    }
                }
            }
        }

        //重构函数：根据当前页面和表格行数刷新显示表格
        private void grReFresh()
        {
           // s_pgNum;当前页数
           // c_ITEMNUM;
           //s_allPg;总页数
            int itemNum = s_pgNum * c_ITEMNUM;
            int i = 0;
            for (; i < c_ITEMNUM && itemNum+i<s_maxItem; i++)
            {
                //Project project;
               // ProjectList projectList=new ProjectList(); 
               // grpSearch.Rows[i].Cells[0].Value = projectList.proArray[i + s_pgNum * c_ITEMNUM].intId;
                grpSearch.Rows[i].Cells[0].Value = i + s_pgNum * c_ITEMNUM;
                grpSearch.Rows[i].Cells[1].Value = s_pgNum * c_ITEMNUM;
                grpSearch.Rows[i].Cells[2].Value = (s_pgNum + 1) * c_ITEMNUM;
                grpSearch.Rows[i].Cells[3].Value = 100 - i;
            }

            if (i != c_ITEMNUM)
            {
                
                for (; i < c_ITEMNUM; i++)
                {
                    grpSearch.Rows[i].Visible = false;
                }
            }
            else
            {
                for (i=0; i < c_ITEMNUM; i++)
                {
                    grpSearch.Rows[i].Visible = true;
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

        //显示页面数
        public void showPage()
        {
            s_allPg = (int)s_maxItem % c_ITEMNUM == 0 ? s_maxItem / c_ITEMNUM : s_maxItem / c_ITEMNUM + 1;
            strShowPg = "当前页数：" + (s_pgNum+1) + "      总页数：" + s_allPg;
            lblShowPg.Text = strShowPg;
        }
 //**********************************程序开始************************************************
        //加载框架
        private void frmMain_Load(object sender, EventArgs e)
        {
            showPage();
            cdtS = new Condition();
            cdtR = new Condition();
            for (int i = 0; i < 8; i++)
            {
                int index = addgrpRow(grpSearch);
                grpSearch.Rows[index].Cells[4].Value = "投资";
            }
            grReFresh();
            this.grpSearch.AutoGenerateColumns = false;

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
        private void rdo_checkedChange(RadioButton rdo, TextBox txtLow, TextBox txtHigh)
        {
            if (0 == Convert.ToInt32(rdo.Tag))
            {
                txtLow.Enabled = true;
                txtHigh.Enabled = true;
            }
            else
            {
                txtLow.Text = null;
                txtHigh.Text = null;
                txtLow.Enabled = false;
                txtHigh.Enabled = false;
            }
        }

        //Search界面第一组单选按钮组处理：
        private void rdoSTime4_CheckedChanged(object sender, EventArgs e)
        {
            rdo_checkedChange(rdoSTime4, txtSTimeLow, txtSTimeHigh);
        }

        private void rdoSTime3_CheckedChanged(object sender, EventArgs e)
        {
            rdo_checkedChange(rdoSTime3, txtSTimeLow, txtSTimeHigh);
        }

        private void rdoSTime2_CheckedChanged(object sender, EventArgs e)
        {
            rdo_checkedChange(rdoSTime2, txtSTimeLow, txtSTimeHigh);
        }

        private void rdoSTime1_CheckedChanged(object sender, EventArgs e)
        {
            rdo_checkedChange(rdoSTime1, txtSTimeLow, txtSTimeHigh );
        }


        private void rdoTimeAll_CheckedChanged(object sender, EventArgs e)
        {
            rdo_checkedChange(rdoTimeAll, txtSTimeLow, txtSTimeHigh );
        }
        //第二组单选按钮框处理:处理起投金额
        private void rdoSMoney4_CheckedChanged(object sender, EventArgs e)
        {
            rdo_checkedChange(rdoSMoney4, txtSMoneyLow, txtSMoneyHigh );
        }
        private void rdoSMoney3_CheckedChanged(object sender, EventArgs e)
        {
            rdo_checkedChange(rdoSMoney3, txtSMoneyLow, txtSMoneyHigh );
        }

        private void rdoSMoney2_CheckedChanged(object sender, EventArgs e)
        {
            rdo_checkedChange(rdoSMoney2, txtSMoneyLow, txtSMoneyHigh );
        }

        private void rdoSMoney1_CheckedChanged(object sender, EventArgs e)
        {
            rdo_checkedChange(rdoSMoney1, txtSMoneyLow, txtSMoneyHigh );
        }


        private void rdoMoneyAll_CheckedChanged(object sender, EventArgs e)
        {
            rdo_checkedChange(rdoMoneyAll, txtSMoneyLow, txtSMoneyHigh );
        }
        //第三组单选按钮框处理:处理收益率
        private void rdoSRate4_CheckedChanged(object sender, EventArgs e)
        {
            rdo_checkedChange(rdoSRate4, txtSRateLow, txtSRateHigh );
        }

        private void rdoSRate3_CheckedChanged(object sender, EventArgs e)
        {
            rdo_checkedChange(rdoSRate3, txtSRateLow, txtSRateHigh );
        }

        private void rdoSRate2_CheckedChanged(object sender, EventArgs e)
        {
            rdo_checkedChange(rdoSRate2, txtSRateLow, txtSRateHigh );
        }

        private void rdoSRate1_CheckedChanged(object sender, EventArgs e)
        {
            rdo_checkedChange(rdoSRate1, txtSRateLow, txtSRateHigh );
        }


        private void rdoRateAll_CheckedChanged(object sender, EventArgs e)
        {
            rdo_checkedChange(rdoRateAll, txtSRateLow, txtSRateHigh );
        }

//btnConfirm处理！！
        private void btnTimeConfirm_Click(object sender, EventArgs e)
        {
            grpSetTime(grpSTime, cdtS, txtSTimeLow, txtSTimeHigh);
        }

        private void btnMoneyConfirm_Click(object sender, EventArgs e)
        {
            grpSetMoney(grpSMoney,cdtS,txtSMoneyLow,txtSMoneyHigh);
        }

        private void btnRateConfirm_Click(object sender, EventArgs e)
        {
            grpSetRate(grpSRate,cdtS,txtSRateLow,txtSRateHigh);
        }

//排序！！
        //页面中部：设置排序方式
        //重构排序方式：参数：选中的单选按钮
        private void rdoSort_checkedChange(RadioButton rdo)
        {
          /*  if (rdo.Checked == true)
            {   
                  projectList = SearchControl.Sort(rdo.Text,s_lsdSUpDown );    
            }*/
             //    object a = rdo.Tag;  
            Int32 tIndex = Convert.ToInt32(rdo.Tag);
            //sortType tIndex = (sortType)rdo.Tag;
            //Int32 tem = Convert.ToInt32(tIndex);
            grpSearch.Sort(grpSearch.Columns[tIndex], s_lsdSUpDown);
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
            int tem;
            grpSetTime(grpSTime,cdtS,txtSTimeLow,txtSTimeHigh);
            grpSetMoney(grpSMoney, cdtS, txtSMoneyLow, txtSMoneyHigh);
            grpSetRate(grpSRate, cdtS, txtSRateLow, txtSRateHigh);

            cdtR.set(cdtS);

            grpSetgrp(grpSTime,grpRTime);
            grpSetgrp(grpSMoney, grpRMoney);
            grpSetgrp(grpSRate, grpRRate);

            tem = grpGetResult(grpRTime);
            if (tem == 0)
            {
                txtRTimeLow.Text = cdtR.TimeDown.ToString();
                txtRTimeHigh.Text = cdtR.TimeUp.ToString();
            }

            tem = grpGetResult(grpRMoney);
            if (tem == 0)
            {
                txtRMoneyLow.Text = cdtR.MoneyDown.ToString();
                txtRMoneyHigh.Text = cdtR.MoneyUp.ToString();
            }

            tem = grpGetResult(grpRRate);
            if (tem == 0)
            {
                txtRRateLow.Text = cdtR.RateDown.ToString();
                txtRRateHigh.Text = cdtR.RateUp.ToString();
            }
            
        }


        //页面下部：表格及增加记录按钮、翻页按钮
        //点击表格“投资”按钮跳到对应网页
        //注：LinkGet()未实现，应该修改为点击“投资”响应，点击其他选项不相应。

        private void grpSearch_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            //  System.Diagnostics.Process.Start("http://baidu.com");
        }
     
        //增加记录
        private void btnToRecord_Click(object sender, EventArgs e)
        {
            //弹出对话框
            frmDialog dlgHint = new frmDialog();
             dlgHint.ShowDialog();
             strAddInfo=dlgHint.forResult();
             if (strAddInfo != null)
             {
                 MessageBox.Show(strAddInfo);
             }
            //新增一行
            int index = addgrpRow(grpAnalyse);
            //赋值
            grpAnalyse.Rows[index].Cells[0].Value = 0;
        }

        //翻页设置：上一页
        private void btnPageUp_Click(object sender, EventArgs e)
        {
           // s_pgNum = s_pgNum > 0 ? s_pgNum-- : 0;
            if (s_pgNum > 0)
            {
                s_pgNum--;
            }
            grReFresh();
            showPage();
        }

        //翻页设置：下一页
        private void btnPageDown_Click(object sender, EventArgs e)
        {
            //s_pgNum = s_pgNum * c_ITEMNUM < s_maxItem ? s_pgNum++ : s_pgNum;
            if (s_pgNum+1 < s_allPg)
            {
                s_pgNum++;
            }
            grReFresh();
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
            for (index = 0; index < grpAnalyse.Rows.Count; )
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
            index=addgrpRow(grpAnalyse);
            grpAnalyse.Rows[index].Selected = true;
            grpAnalyse.Rows[index].Cells[0].Value= index;
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
                tmrRushReflash.Enabled = false;
                btnActionRush.Text = "开始抢购";       
            }

        }

        //刷新调用
        private void tmrRushReflash_Tick(object sender, EventArgs e)
        {
             //String strTem=null;
            //tmrRushReflash.Run();
            //if(return!=null)
            //strTem+="项目名称"+"起投金额\n"+"投资期限"+"收益率";
           // MessageBox.Show(strTem);
        }

        //条件按钮组设置
        //对第一组按钮组进行设置：投资期限
        private void rdoRTime4_CheckedChanged(object sender, EventArgs e)
        {
            rdo_checkedChange(rdoRTime4, txtRTimeLow, txtRTimeHigh);
        }

        private void rdoRTime3_CheckedChanged(object sender, EventArgs e)
        {
            rdo_checkedChange(rdoRTime3, txtRTimeLow, txtRTimeHigh);
        }

        private void rdoRTime2_CheckedChanged(object sender, EventArgs e)
        {
            rdo_checkedChange(rdoRTime2, txtRTimeLow, txtRTimeHigh);
        }

        private void rdoRTime1_CheckedChanged(object sender, EventArgs e)
        {
            rdo_checkedChange(rdoRTime1, txtRTimeLow, txtRTimeHigh);
        }

        //对第二组按钮组进行设置：投资金额
        private void rdoRMoney4_CheckedChanged(object sender, EventArgs e)
        {
            rdo_checkedChange(rdoRMoney4, txtRMoneyLow, txtRMoneyHigh);
        }

        private void rdoRMoney3_CheckedChanged(object sender, EventArgs e)
        {
            rdo_checkedChange(rdoRMoney3, txtRMoneyLow, txtRMoneyHigh);
        }

        private void rdoRMoney2_CheckedChanged(object sender, EventArgs e)
        {
            rdo_checkedChange(rdoRMoney2, txtRMoneyLow, txtRMoneyHigh);
        }

        private void rdoRMoney1_CheckedChanged(object sender, EventArgs e)
        {
            rdo_checkedChange(rdoRMoney1, txtRMoneyLow, txtRMoneyHigh);
        }

        //对第三组按钮组进行设置：收益率
        private void rdoRRate4_CheckedChanged(object sender, EventArgs e)
        {
            rdo_checkedChange(rdoRRate4, txtRRateLow, txtRRateHigh);
        }

        private void rdoRRate3_CheckedChanged(object sender, EventArgs e)
        {
            rdo_checkedChange(rdoRRate3, txtRRateLow, txtRRateHigh);
        }

        private void rdoRRate2_CheckedChanged(object sender, EventArgs e)
        {
            rdo_checkedChange(rdoRRate2, txtRRateLow, txtRRateHigh);
        }

        private void rdoRRate1_CheckedChanged(object sender, EventArgs e)
        {
            rdo_checkedChange(rdoRRate1, txtRRateLow, txtRRateHigh);
        }

        private void btnRConfirm_Click(object sender, EventArgs e)
        {
            grpSetTime(grpRTime, cdtS, txtSTimeLow, txtSTimeHigh);
            grpSetMoney(grpRMoney, cdtS, txtSMoneyLow, txtSMoneyHigh);
            grpSetRate(grpRRate, cdtS, txtSRateLow, txtSRateHigh);
        }


















    }
}
