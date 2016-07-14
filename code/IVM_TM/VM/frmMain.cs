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
using System.IO;

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
        //投资表列表
        List<String> tableNameList;

        // Project project;
        // ProjectList projectList; 


        //***************************************华丽的分割线**************************************************
        String strPath;
        public frmMain()
        {
            InitializeComponent();
            new Initializate();
            strPath = System.Environment.CurrentDirectory;
            tableNameList = new List<String>();
            UpdateTableNameList();
            //  RecordList =sStatistic.LoadDataFromExcel(strDefaultExcelFileWholePath);
            //   ShowContentOfRecordList();
        }

        private void UpdateTableNameList()
        {
            tableNameList.Clear();
            lBTableNameList.Items.Clear();
            cbBTableNameList.Items.Clear();

            DirectoryInfo dir = new DirectoryInfo(strPath);
            foreach (FileInfo fi in dir.GetFiles("*.xls"))
            {
                //if (fi.FullName.EndsWith(".xls")) 
                //{                     
                tableNameList.Add(fi.Name);
                //}
            }
            
            foreach (String str in tableNameList)
            {               
                lBTableNameList.Items.Add(str);              
                cbBTableNameList.Items.Add(str);
            }
            cbBTableNameList.SelectedIndex = 0;

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
        //******************search**************************

        
        //**********************************程序开始************************************************
        //加载框架
        


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
                cbBTableNameList.Enabled = false;
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
                cbBTableNameList.Enabled = true;
                t.AutoReset = false;
                t.Enabled = false;
                for (int i = 0; i < 9; i++)
                {
                    grpRush.Rows[i].Cells[0].Value = null;
                    grpRush.Rows[i].Cells[1].Value = null;
                    grpRush.Rows[i].Cells[2].Value = null;
                    grpRush.Rows[i].Cells[3].Value = null;
                    grpRush.Rows[i].Cells[4].Value = null;
                    grpRush.Rows[i].Cells[5].Value = null;

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
                grpRush.Rows[i].Cells[5].Value = null;
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
                grpRush.Rows[i].Cells[5].Value = "陆金所";
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
            
            try
            {
                string buttonText = grpSearch.Rows[e.RowIndex].Cells[4].Value.ToString();
                if (buttonText.Equals("投资") && e.ColumnIndex == 4)

                {
                    frmDialog dlgHint = new frmDialog();
                    dlgHint.ShowDialog();
                    double money = dlgHint.forResult();
                    if (money == -1)
                        return;
                    string name = "";
                    name += grpSearch.Rows[e.RowIndex].Cells[0].Value.ToString();
//                    AddRecord(money, name);
                }
            }
            catch (System.NullReferenceException) { MessageBox.Show("rechoose!"); }
        }

       

        private void grpRush_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (SearchControl.AuctionProjectList != null)
            {
                string link = SearchControl.AuctionProjectList.getProject(e.RowIndex).strLink;
                //调用系统默认的浏览器 
                System.Diagnostics.Process.Start(link);
            }
        }



        private void lblShowPg_Click(object sender, EventArgs e)
        {

        }

        //private void grpSearch_CellContentClick(object sender, DataGridViewCellEventArgs e)
        //{

        //}
    }
}
