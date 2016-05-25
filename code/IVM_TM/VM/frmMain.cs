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
using ControlClass;
using EntityClass;
using ClassLibrary;

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

        public static Condition cdtS = new Condition();
        public static Condition cdtR = new Condition(); 
        public RadioButton rdoTem;
        public static ListSortDirection s_lsdSUpDown = ListSortDirection.Ascending;

       // Project project;
       // ProjectList projectList; 
    

//***************************************华丽的分割线**************************************************

        public frmMain()
        {
            InitializeComponent();
            new Initializate();
            RecordList =sStatistic.LoadDataFromExcel(strDefaultExcelFileWholePath);
            ShowContentOfRecordList();
        }

        //将单选按钮组转化为对应表达式：投资期限
        public void grpSetTime(GroupBox grpTime,Condition cdt,TextBox txtl,TextBox txth)
        {
            int tem;
            tem = grpGetResult(grpTime);
            switch (tem)
            {
                case 0:
                    {
                        if (txtl.Text == "")
                        {
                            cdt.TimeDown = null;
                        }
                        else
                        {
                            cdt.TimeDown = (txtl.Text).Trim();
                        }
                        if (txth.Text == "")
                        {
                            cdt.TimeUp = null;
                        }
                        else
                        {
                            cdt.TimeUp = (txth.Text).Trim();
                        }
                        break;
                    }
                case 1:
                    {
                        cdt.TimeDown = "12";
                        cdt.TimeUp = null;
                        break;
                    }
                case 2:
                    {
                        cdt.TimeDown = "6";
                        cdt.TimeUp = "12";
                        break;
                    }
                case 3:
                    {
                        cdt.TimeDown = null;
                        cdt.TimeUp = "6";
                        break;
                    }
                case 4:
                    {
                        cdt.TimeDown = null;
                        cdt.TimeUp = null;
                        break;
                    }
                default:
                    break;
            }
        }

        //将单选按钮组转化为对应表达式：投资金额
        public void grpSetMoney(GroupBox grpMoney, Condition cdt, TextBox txtDown, TextBox txtUp)
        {
            int tem;
            tem = grpGetResult(grpMoney);
            switch (tem)
            {
                case 0:
                    {
                        if (txtDown.Text == "")
                        {
                            cdt.MoneyDown = null;
                        }
                        else
                        {
                            cdt.MoneyDown = (txtDown.Text).Trim();
                        }
                        if (txtUp.Text == "")
                        {
                            cdt.MoneyUp = null;
                        }
                        else
                        {
                            cdt.MoneyUp = (txtUp.Text).Trim();
                        }
                        break;
                       
                    }
                case 1:
                    {
                        cdt.MoneyDown = "5";
                        cdt.MoneyUp = "1";
                        break;
                    }
                case 2:
                    {
                        cdt.MoneyDown = "1";
                        cdt.MoneyUp = "5";
                        break;
                    }
                case 3:
                    {
                        cdt.MoneyDown = null;
                        cdt.MoneyUp = "1";
                        break;
                    }
                case 4:
                    {
                        cdt.MoneyDown = null;
                        cdt.MoneyUp = null;
                        break;
                    }
                default:
                    break;
            }
        }

        //将单选按钮组转化为对应表达式：收益率
        public void grpSetRate(GroupBox grpRate, Condition selectCondition, TextBox txtDown, TextBox txtUp)
        {
            int tem;
            tem = grpGetResult(grpRate);
            switch (tem)
            {
                case 0:
                    {
                        if (txtDown.Text == "")
                        {
                            selectCondition.RateDown = null;
                        }
                        else
                        {
                            selectCondition.RateDown = (txtDown.Text).Trim();
                        }
                        if (txtUp.Text == "")
                        {
                            selectCondition.RateUp = null;
                        }
                        else
                        {
                            selectCondition.RateUp = (txtUp.Text).Trim();
                        }
                        break;
                    }
                case 1:
                    {
                        selectCondition.RateDown = "10";
                        selectCondition.RateUp = null;
                        break;
                    }
                case 2:
                    {
                        selectCondition.RateDown = "5";
                        selectCondition.RateUp = "10";
                        break;
                    }
                case 3:
                    {
                        selectCondition.RateDown = null;
                        selectCondition.RateUp = "5";
                        break;
                    }
                case 4:
                    {
                        selectCondition.RateDown = null;
                        selectCondition.RateUp = null;
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

        public void grpSetgrp(GroupBox grpSearchGUI, GroupBox grpRushGUI)
        {
            int tem;
            tem=grpGetResult(grpSearchGUI);
            if (-1 != tem)
            {
                foreach (Control ct in grpRushGUI.Controls)
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

            for (int i = 0; i < 9 ; i++)
            {             
                grpSearch.Rows[i].Cells[0].Value = null;
                grpSearch.Rows[i].Cells[1].Value =null ;
                grpSearch.Rows[i].Cells[2].Value = null;
                grpSearch.Rows[i].Cells[3].Value = null;
                grpSearch.Rows[i].Cells[4].Value = null;          
            }

            ProjectList proList = new ProjectList();
            proList = SearchControl.ChildProjectList;
            for (int i = 0; i < 9 && i < proList.Count() ; i++)
            {
                grpSearch.Rows[i].Cells[0].Value = proList.getProject(i).name;
                grpSearch.Rows[i].Cells[1].Value = proList.getProject(i).intTime;
                grpSearch.Rows[i].Cells[2].Value = proList.getProject(i).dblMoney;
                grpSearch.Rows[i].Cells[3].Value = proList.getProject(i).dblRate;
                grpSearch.Rows[i].Cells[4].Value = "投资";
               
            }

            if (proList.Count() == 0)
            {
                grpSearch.DataSource = null;
                grpSearch.Rows[0].Selected = false;
                grpSearch.Rows[0].SetValues("没有搜索到结果");
                // grpSearch.Rows[i].Cells[0].Value = "没有搜索到结果";

            }

        }

        
        //显示页面数
        public void showPage()
        {
            s_allPg = (int)s_maxItem % 9 == 0 ? s_maxItem / 9 : s_maxItem / 9 + 1;
            strShowPg = "当前页数：" + cdtS.currentPage ;
            lblShowPg.Text = strShowPg;
        }
 //**********************************程序开始************************************************
        //加载框架
        private void frmMain_Load(object sender, EventArgs e)
        {
           
            
            for (int i = 0; i < 9; i++)
            {
               // int index = addgrpRow(grpSearch);
                int index = grpSearch.Rows.Add();
                grpRush.Rows.Add();
                grpSearch.Rows[index].Cells[4].Value = "投资";
            }
            ProjectList proList = new ProjectList();
            proList = SearchControl.projectListForAll;
            for (int i = 0; i < 9 && i < proList.Count(); i++)
            {
                grpSearch.Rows[i].Cells[0].Value = proList.getProject(i).name;
                grpSearch.Rows[i].Cells[1].Value = proList.getProject(i).intTime;
                grpSearch.Rows[i].Cells[2].Value = proList.getProject(i).dblMoney;
                grpSearch.Rows[i].Cells[3].Value = proList.getProject(i).dblRate;
                grpSearch.Rows[i].Cells[4].Value = "投资";
            }

            this.grpSearch.AutoGenerateColumns = false;
            showPage();

        }


        //页面上部：搜索功能
        //点击搜索按钮
        private void btnSearch_Click(object sender, EventArgs e)
        {
            if (txtSearch.Text != null)
            {
                strSearchInfo = txtSearch.Text;
                cdtS.projectName = strSearchInfo;
                SearchControl.SelectOrOrderProjectList("No", cdtS);
                grReFresh();
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
            btnTimeConfirm.Enabled = true;
        }

        private void rdoSTime3_CheckedChanged(object sender, EventArgs e)
        {
            btnTimeConfirm.Enabled = false;
            rdo_checkedChange(rdoSTime3, txtSTimeLow, txtSTimeHigh);
            grpSetTime(grpSTime, cdtS, txtSTimeLow, txtSTimeHigh);
            SearchControl.SelectOrOrderProjectList("No",cdtS);
            grReFresh();
        }

        private void rdoSTime2_CheckedChanged(object sender, EventArgs e)
        {
            btnTimeConfirm.Enabled = false;
            rdo_checkedChange(rdoSTime2, txtSTimeLow, txtSTimeHigh);
            grpSetTime(grpSTime, cdtS, txtSTimeLow, txtSTimeHigh);
            SearchControl.SelectOrOrderProjectList("No",cdtS);
            grReFresh();
        }

        private void rdoSTime1_CheckedChanged(object sender, EventArgs e)
        {
            btnTimeConfirm.Enabled = false;
            rdo_checkedChange(rdoSTime1, txtSTimeLow, txtSTimeHigh );
            grpSetTime(grpSTime, cdtS, txtSTimeLow, txtSTimeHigh);
            SearchControl.SelectOrOrderProjectList("No",cdtS);
            grReFresh();
        }


        private void rdoTimeAll_CheckedChanged(object sender, EventArgs e)
        {
            btnTimeConfirm.Enabled = false;
            rdo_checkedChange(rdoTimeAll, txtSTimeLow, txtSTimeHigh );            
            grpSetTime(grpSTime, cdtS, txtSTimeLow, txtSTimeHigh);
            SearchControl.SelectOrOrderProjectList("No",cdtS);
            grReFresh();
        }
        //第二组单选按钮框处理:处理起投金额
        private void rdoSMoney4_CheckedChanged(object sender, EventArgs e)
        {
            rdo_checkedChange(rdoSMoney4, txtSMoneyLow, txtSMoneyHigh );
            btnMoneyConfirm.Enabled = true;
        }
        private void rdoSMoney3_CheckedChanged(object sender, EventArgs e)
        {
            rdo_checkedChange(rdoSMoney3, txtSMoneyLow, txtSMoneyHigh );
            btnMoneyConfirm.Enabled = false;
            grpSetMoney(grpSMoney, cdtS, txtSMoneyLow, txtSMoneyHigh);
            SearchControl.SelectOrOrderProjectList("No",cdtS);
            grReFresh();
        }

        private void rdoSMoney2_CheckedChanged(object sender, EventArgs e)
        {
            rdo_checkedChange(rdoSMoney2, txtSMoneyLow, txtSMoneyHigh );
            btnMoneyConfirm.Enabled = false;
            grpSetMoney(grpSMoney, cdtS, txtSMoneyLow, txtSMoneyHigh);
            SearchControl.SelectOrOrderProjectList("No",cdtS);
            grReFresh();
        }

        private void rdoSMoney1_CheckedChanged(object sender, EventArgs e)
        {
            rdo_checkedChange(rdoSMoney1, txtSMoneyLow, txtSMoneyHigh );
            btnMoneyConfirm.Enabled = false;
            grpSetMoney(grpSMoney, cdtS, txtSMoneyLow, txtSMoneyHigh);
            SearchControl.SelectOrOrderProjectList("No",cdtS);
            grReFresh();
        }


        private void rdoMoneyAll_CheckedChanged(object sender, EventArgs e)
        {
            rdo_checkedChange(rdoMoneyAll, txtSMoneyLow, txtSMoneyHigh );
            btnMoneyConfirm.Enabled = false;
            grpSetMoney(grpSMoney,cdtS,txtSMoneyLow,txtSMoneyHigh);
            SearchControl.SelectOrOrderProjectList("No",cdtS);
            grReFresh();

        }
        //第三组单选按钮框处理:处理收益率
        private void rdoSRate4_CheckedChanged(object sender, EventArgs e)
        {
            rdo_checkedChange(rdoSRate4, txtSRateLow, txtSRateHigh );
            btnRateConfirm.Enabled = true;
        }

        private void rdoSRate3_CheckedChanged(object sender, EventArgs e)
        {
            rdo_checkedChange(rdoSRate3, txtSRateLow, txtSRateHigh );
            btnRateConfirm.Enabled = false;
            grpSetRate(grpSRate,cdtS,txtSRateLow,txtSRateHigh);
            SearchControl.SelectOrOrderProjectList("No",cdtS);
            grReFresh();
        }

        private void rdoSRate2_CheckedChanged(object sender, EventArgs e)
        {
            rdo_checkedChange(rdoSRate2, txtSRateLow, txtSRateHigh );
            btnRateConfirm.Enabled = false;
            grpSetRate(grpSRate, cdtS, txtSRateLow, txtSRateHigh);
            SearchControl.SelectOrOrderProjectList("No",cdtS);
            grReFresh();
        }

        private void rdoSRate1_CheckedChanged(object sender, EventArgs e)
        {
            rdo_checkedChange(rdoSRate1, txtSRateLow, txtSRateHigh );
            btnRateConfirm.Enabled = false;
            grpSetRate(grpSRate, cdtS, txtSRateLow, txtSRateHigh);
            SearchControl.SelectOrOrderProjectList("No",cdtS);
            grReFresh();
        }


        private void rdoRateAll_CheckedChanged(object sender, EventArgs e)
        {
            rdo_checkedChange(rdoRateAll, txtSRateLow, txtSRateHigh );
            btnTimeConfirm.Enabled = false;
            grpSetRate(grpSRate, cdtS, txtSRateLow, txtSRateHigh);
            SearchControl.SelectOrOrderProjectList("No",cdtS);
            grReFresh();
        }

//btnConfirm处理！！
        private void btnTimeConfirm_Click(object sender, EventArgs e)
        {
            grpSetTime(grpSTime, cdtS, txtSTimeLow, txtSTimeHigh);
          //  grpSetTime(grpSTime, cdtS, txtSTimeLow, txtSTimeHigh);
            SearchControl.SelectOrOrderProjectList("No",cdtS);
            grReFresh();
            
        }

        private void btnMoneyConfirm_Click(object sender, EventArgs e)
        {
            grpSetMoney(grpSMoney,cdtS,txtSMoneyLow,txtSMoneyHigh);
            SearchControl.SelectOrOrderProjectList("No",cdtS);
            grReFresh();
        }

        private void btnRateConfirm_Click(object sender, EventArgs e)
        {
            grpSetRate(grpSRate, cdtS, txtSRateLow, txtSRateHigh);
            SearchControl.SelectOrOrderProjectList("No",cdtS);
            grReFresh();
        }

//排序！！
        //页面中部：设置排序方式
        //重构排序方式：参数：选中的单选按钮
        private Int32 rdoSort_checkedChange(RadioButton rdo)
        {
           /* if (rdo.Checked == true)
            {
                return true; //projectList = SearchControl.Sort(rdo.Text,s_lsdSUpDown );    
            }
            return false;
            */
             //    object a = rdo.Tag;  
            Int32 tIndex = Convert.ToInt32(rdo.Tag);
            return tIndex;
            //sortType tIndex = (sortType)rdo.Tag;
            //Int32 tem = Convert.ToInt32(tIndex);
            //  grpSearch.Sort(grpSearch.Columns[tIndex], s_lsdSUpDown);
        }

        //重构排序方式：参数：按钮所在的组合框，找到选中的按钮，再调用rdoSort_checkedChange
        private Int32 rdoSort_checkedChange(GroupBox grpSort)
        {
            foreach (Control ct in grpSort.Controls)
            {
                RadioButton rb = ct as RadioButton;
                if (rb.Checked)
                {
                    rdoTem = rb;
                }
            }
            return rdoSort_checkedChange(rdoTem);
        }

        //默认排序
        private void rdoSortDefault_CheckedChanged(object sender, EventArgs e)
        {

            rdoSort_checkedChange(rdoSortDefault);
            rdoSortDown.Visible = false;
            rdoSortUp.Visible = false;
            //此处仅对表格排序，当总项目少于表格行数时有效
            //应改为调用外部接口对整个列表排序后刷新输出
            cdtS.sort = 0;
            SearchControl.SelectOrOrderProjectList("No",cdtS);
            grReFresh();

        }

        //按投资期限排序
        private void rdoSortTime_CheckedChanged(object sender, EventArgs e)
        {
            rdoSortDown.Visible = true;
            rdoSortUp.Visible = true;
            rdoSort_checkedChange(rdoSortTime);
            if (s_lsdSUpDown == ListSortDirection.Ascending)
            {
                cdtS.sort = 3;
            }
            else
            {
                cdtS.sort = 4;
            }
            SearchControl.SelectOrOrderProjectList("No",cdtS);
            grReFresh();
        }

        //按起投金额排序
        private void rdoSortMoney_CheckedChanged(object sender, EventArgs e)
        {
            rdoSortDown.Visible = true;
            rdoSortUp.Visible = true;
            rdoSort_checkedChange(rdoSortMoney);
            if (s_lsdSUpDown == ListSortDirection.Ascending)
            {
                cdtS.sort = 1;
            }
            else
            {
                cdtS.sort = 2;
            }
            SearchControl.SelectOrOrderProjectList("No",cdtS);
            grReFresh();
        }

        //按收益率排序
        private void rdoSortRate_CheckedChanged(object sender, EventArgs e)
        {
            rdoSortDown.Visible = true;
            rdoSortUp.Visible = true;
            rdoSort_checkedChange(rdoSortRate);
            if (s_lsdSUpDown == ListSortDirection.Ascending)
            {
                cdtS.sort = 5;
            }
            else
            {
                cdtS.sort = 6;
            }
            SearchControl.SelectOrOrderProjectList("No",cdtS);
            grReFresh();
        }

        private void rdoSortUp_CheckedChanged(object sender, EventArgs e)
        {
            s_lsdSUpDown = ListSortDirection.Ascending;
            Int32 item = 0;
            item = rdoSort_checkedChange(grpSort);
            if (item == 1)
                cdtS.sort = 3;
            if (item == 2)
                cdtS.sort = 1;
            if (item == 3)
                cdtS.sort = 5;
            SearchControl.SelectOrOrderProjectList("No",cdtS);
            grReFresh();
        }

        private void rdoSortDown_CheckedChanged(object sender, EventArgs e)
        {
            s_lsdSUpDown = ListSortDirection.Descending;
            Int32 item = 0;
            item = rdoSort_checkedChange(grpSort);
            if (item == 1)
                cdtS.sort = 4;
            if (item == 2)
                cdtS.sort = 2;
            if (item == 3)
                cdtS.sort = 6;
            SearchControl.SelectOrOrderProjectList("No",cdtS);
            grReFresh();
        }

        //抢购按钮
        private void btnRush_Click(object sender, EventArgs e)
        {
            int tem;
            grpSetTime(grpSTime,cdtS,txtSTimeLow,txtSTimeHigh);
            grpSetMoney(grpSMoney, cdtS, txtSMoneyLow, txtSMoneyHigh);
            grpSetRate(grpSRate, cdtS, txtSRateLow, txtSRateHigh);

          //  cdtR.set(cdtS);

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
            tabSelectModule.SelectedIndex = 2;

        }


        //页面下部：表格及增加记录按钮、翻页按钮
        //点击表格“投资”按钮跳到对应网页
        //注：LinkGet()未实现，应该修改为点击“投资”响应，点击其他选项不相应。

        private void grpSearch_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                string buttonText = grpSearch.Rows[e.RowIndex].Cells[4].Value.ToString();
                if (buttonText.Equals("投资"))
                {
                    frmDialog dlgHint = new frmDialog();
                    dlgHint.ShowDialog();
                    double money = dlgHint.forResult();
                    string name = "";
                    name+=grpSearch.Rows[e.RowIndex].Cells[0].Value.ToString();
                    AddRecord(money,name);
                }
            }
            catch (System.NullReferenceException) { MessageBox.Show("rechoose!"); }
        }   

        private void grpSearch_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            //int currentItem = e.RowIndex;
            try
            {
                string link = SearchControl.ChildProjectList.getProject(e.RowIndex).strLink;
                //调用系统默认的浏览器 
                System.Diagnostics.Process.Start(link);
            }
            catch (System.NullReferenceException) {  }
        }

        //增加记录
        private void btnToRecord_Click(object sender, EventArgs e)
        {
            //弹出对话框
             
        }

        //翻页设置：上一页
        private void btnPageUp_Click(object sender, EventArgs e)
        {
            // s_pgNum = s_pgNum > 0 ? s_pgNum-- : 0;
            if (cdtS.currentPage > 1)
            {
                cdtS.currentPage--;
                SearchControl.SelectOrOrderProjectList("No",cdtS);
                grReFresh();
            }
            else
            {
                SearchControl.SelectOrOrderProjectList("No",cdtS);
                grReFresh();
            }
        
            showPage();
        }

        //翻页设置：下一页
        private void btnPageDown_Click(object sender, EventArgs e)
        {
            //s_pgNum = s_pgNum * c_ITEMNUM < s_maxItem ? s_pgNum++ : s_pgNum;
         
                btnPageDown.Enabled = true;
                cdtS.currentPage++;
                SearchControl.SelectOrOrderProjectList("No", cdtS);
                grReFresh();
                showPage();
        }


        //******************************************Analyse界面**********************************************


        //******************************************Rush界面**************************************

        //页面上端
        System.Timers.Timer t = new System.Timers.Timer(10000);   //实例化Timer类，设置间隔时间为10000毫秒；
        //抢购按钮
        private void btnActionRush_Click(object sender, EventArgs e)
        {
            grpSetTime(grpRTime, cdtR, txtSTimeLow, txtSTimeHigh);
            grpSetMoney(grpRMoney, cdtR, txtSMoneyLow, txtSMoneyHigh);
            grpSetRate(grpRRate, cdtR, txtSRateLow, txtSRateHigh);

            if (btnActionRush.Text.Equals("开始抢购"))
            {
                tmrRushReflash.Enabled = true;
                btnActionRush.Text = "停止抢购";
                   
                t.Elapsed += new System.Timers.ElapsedEventHandler(theout); //到达时间的时候执行事件； 
                   //设置是执行一次（false）还是一直执行(true)；  
                if (GetWebContent.mark)
                    t.AutoReset = true; 
                else t.AutoReset = false;
                t.Enabled = true;;     //是否执行System.Timers.Timer.Elapsed事件；   
            }
            else
            {
                tmrRushReflash.Enabled = false;
                btnActionRush.Text = "开始抢购";
                t.AutoReset = false;
                t.Enabled = false;
                for (int i = 0; i < 9; i++)
                {
                    grpRush.Rows[i].Cells[0].Value = null;
                    grpRush.Rows[i].Cells[1].Value = null;
                    grpRush.Rows[i].Cells[2].Value = null;
                    grpRush.Rows[i].Cells[3].Value = null;
                    grpRush.Rows[i].Cells[4].Value = null;
                }
            }

        }

        public void theout(object source, System.Timers.ElapsedEventArgs e)
        {
            SearchControl.SelectOrOrderProjectList("yes",cdtR);
            for (int i = 0; i < 9; i++)
            {
                grpRush.Rows[i].Cells[0].Value = null;
                grpRush.Rows[i].Cells[1].Value = null;
                grpRush.Rows[i].Cells[2].Value = null;
                grpRush.Rows[i].Cells[3].Value = null;
                grpRush.Rows[i].Cells[4].Value = null;
            }

            ProjectList proList = new ProjectList();
            proList = SearchControl.AuctionProjectList;
            for (int i = 0; i < 9 && i < proList.Count(); i++)
            {
                grpRush.Rows[i].Cells[0].Value = proList.getProject(i).name;
                grpRush.Rows[i].Cells[1].Value = proList.getProject(i).intTime;
                grpRush.Rows[i].Cells[2].Value = proList.getProject(i).dblMoney;
                grpRush.Rows[i].Cells[3].Value = proList.getProject(i).dblRate;
                grpRush.Rows[i].Cells[4].Value = "点击抢购";
            }

            if (proList.Count() == 0)
            {
                grpSearch.DataSource = null;
                grpSearch.Rows[0].Selected = false;
                grpSearch.Rows[0].SetValues("没有搜索到结果");
                // grpSearch.Rows[i].Cells[0].Value = "没有搜索到结果";

            }
        }
        //刷新调用
        private void tmrRushReflash_Tick(object sender, EventArgs e)
        {
            
        }

        //条件按钮组设置
        //对第一组按钮组进行设置：投资期限
        private void rdoRTime4_CheckedChanged(object sender, EventArgs e)
        {
            rdo_checkedChange(rdoRTime4, txtRTimeLow, txtRTimeHigh);
            grpSetTime(grpRTime, cdtR, txtRTimeLow, txtRTimeHigh);

        }

        private void rdoRTime3_CheckedChanged(object sender, EventArgs e)
        {
            rdo_checkedChange(rdoRTime3, txtRTimeLow, txtRTimeHigh);
            grpSetTime(grpRTime, cdtR, txtRTimeLow, txtRTimeHigh);
        }

        private void rdoRTime2_CheckedChanged(object sender, EventArgs e)
        {
            rdo_checkedChange(rdoRTime2, txtRTimeLow, txtRTimeHigh);
            grpSetTime(grpRTime, cdtR, txtRTimeLow, txtRTimeHigh);
        }

        private void rdoRTime1_CheckedChanged(object sender, EventArgs e)
        {
            rdo_checkedChange(rdoRTime1, txtRTimeLow, txtRTimeHigh);
            grpSetTime(grpRTime, cdtR, txtRTimeLow, txtRTimeHigh);
        }

        //对第二组按钮组进行设置：投资金额
        private void rdoRMoney4_CheckedChanged(object sender, EventArgs e)
        {
            rdo_checkedChange(rdoRMoney4, txtRMoneyLow, txtRMoneyHigh);
            grpSetMoney(grpRMoney, cdtR, txtRMoneyLow, txtRMoneyHigh);
        }

        private void rdoRMoney3_CheckedChanged(object sender, EventArgs e)
        {
            rdo_checkedChange(rdoRMoney3, txtRMoneyLow, txtRMoneyHigh);
            grpSetMoney(grpRMoney, cdtR, txtRMoneyLow, txtRMoneyHigh);
        }

        private void rdoRMoney2_CheckedChanged(object sender, EventArgs e)
        {
            rdo_checkedChange(rdoRMoney2, txtRMoneyLow, txtRMoneyHigh);
            grpSetMoney(grpRMoney, cdtR, txtRMoneyLow, txtRMoneyHigh);
        }

        private void rdoRMoney1_CheckedChanged(object sender, EventArgs e)
        {
            rdo_checkedChange(rdoRMoney1, txtRMoneyLow, txtRMoneyHigh);
            grpSetMoney(grpRMoney, cdtR, txtRMoneyLow, txtRMoneyHigh);
        }

        //对第三组按钮组进行设置：收益率
        private void rdoRRate4_CheckedChanged(object sender, EventArgs e)
        {
            rdo_checkedChange(rdoRRate4, txtRRateLow, txtRRateHigh);
            grpSetRate(grpRRate, cdtR, txtRRateLow, txtRRateHigh);
        }

        private void rdoRRate3_CheckedChanged(object sender, EventArgs e)
        {
            rdo_checkedChange(rdoRRate3, txtRRateLow, txtRRateHigh);
            grpSetRate(grpRRate, cdtR, txtRRateLow, txtRRateHigh);
        }

        private void rdoRRate2_CheckedChanged(object sender, EventArgs e)
        {
            rdo_checkedChange(rdoRRate2, txtRRateLow, txtRRateHigh);
            grpSetRate(grpRRate, cdtR, txtRRateLow, txtRRateHigh);
        }

        private void rdoRRate1_CheckedChanged(object sender, EventArgs e)
        {
            rdo_checkedChange(rdoRRate1, txtRRateLow, txtRRateHigh);
            grpSetRate(grpRRate, cdtR, txtRRateLow, txtRRateHigh);

        }

        private void btnRConfirm_Click(object sender, EventArgs e)
        {
            grpSetTime(grpRTime, cdtR, txtSTimeLow, txtSTimeHigh);
            grpSetMoney(grpRMoney, cdtR, txtSMoneyLow, txtSMoneyHigh);
            grpSetRate(grpRRate, cdtR, txtSRateLow, txtSRateHigh);
           // btnActionRush.Enabled = true;
        }

        private void grpRush_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (SearchControl.AuctionProjectList != null)
            {
                string link = SearchControl.AuctionProjectList.getProject(e.RowIndex).strLink;
                //调用系统默认的浏览器 
                System.Diagnostics.Process.Start(link);
            }
        }

        private void grpStatisticTable_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                string buttonText = grpStatisticTable.Rows[e.RowIndex].Cells[5].Value.ToString();
                if (buttonText.Equals("赎回"))
                {
                    grpStatisticTable.Rows[e.RowIndex].Cells[5].Value = "";
                    double money =Convert.ToDouble(grpStatisticTable.Rows[e.RowIndex].Cells[2].Value);
                    string name = grpStatisticTable.Rows[e.RowIndex].Cells[3].Value.ToString();
                    int id = Convert.ToInt32(grpStatisticTable.Rows[e.RowIndex].Cells[4].Value);
                    AddRecord(money, name, id,"赎回");
                }
            }
            catch (System.NullReferenceException) { }
        }

        private void grpStatisticTable_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            /*Record record = (Record)RecordList[e.RowIndex];
            record.dblMoney = Convert.ToDouble(grpStatisticTable.Rows[e.RowIndex].Cells[2].Value);
            record.strName = grpStatisticTable.Rows[e.RowIndex].Cells[3].Value.ToString();
            RecordList.RemoveAt(e.RowIndex);
            RecordList.Insert(e.RowIndex, record);
            sStatistic.WriteDataToExcel(RecordList, strExcelFileWholePath);*/
        }


    }
}
