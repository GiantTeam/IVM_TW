//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;


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
        public Int32 grpGetResult(GroupBox grp)
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
            tem = grpGetResult(grpSearchGUI);
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

            for (int i = 0; i < 9; i++)
            {
                grpSearch.Rows[i].Cells[0].Value = null;
                grpSearch.Rows[i].Cells[1].Value = null;
                grpSearch.Rows[i].Cells[2].Value = null;
                grpSearch.Rows[i].Cells[3].Value = null;
                grpSearch.Rows[i].Cells[4].Value = null;
                grpSearch.Rows[i].Cells[5].Value = null;
            }

            ProjectList proList = new ProjectList();
            proList = SearchControl.ChildProjectList;
            for (int i = 0; i < 9 && i < proList.Count(); i++)
            {
                grpSearch.Rows[i].Cells[0].Value = proList.getProject(i).name;
                grpSearch.Rows[i].Cells[1].Value = proList.getProject(i).intTime;
                grpSearch.Rows[i].Cells[2].Value = proList.getProject(i).dblMoney;
                grpSearch.Rows[i].Cells[3].Value = proList.getProject(i).dblRate;
                grpSearch.Rows[i].Cells[4].Value = "投资";
                grpSearch.Rows[i].Cells[5].Value = "陆金所";

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
            strShowPg = "当前页数：" + cdtS.currentPage;
            lblShowPg.Text = strShowPg;
        }

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
            if (proList.Count() < 1)
            {
                for (int i = 0; i < 9; i++)
                {
                    grpSearch.Rows[i].Cells[0].Value = "";
                    grpSearch.Rows[i].Cells[1].Value = "";
                    grpSearch.Rows[i].Cells[2].Value = "";
                    grpSearch.Rows[i].Cells[3].Value = "";
                    grpSearch.Rows[i].Cells[4].Value = "";
                    grpSearch.Rows[i].Cells[5].Value = "";
                }
            }
            else {
                for (int i = 0; i < 9 && i < proList.Count(); i++)
                {
                    grpSearch.Rows[i].Cells[0].Value = proList.getProject(i).name;
                    grpSearch.Rows[i].Cells[1].Value = proList.getProject(i).intTime;
                    grpSearch.Rows[i].Cells[2].Value = proList.getProject(i).dblMoney;
                    grpSearch.Rows[i].Cells[3].Value = proList.getProject(i).dblRate;
                    grpSearch.Rows[i].Cells[4].Value = "投资";
                    grpSearch.Rows[i].Cells[4].Value = "路金所";

                }
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
            SearchControl.SelectOrOrderProjectList("No", cdtS);
            grReFresh();
        }

        private void rdoSTime2_CheckedChanged(object sender, EventArgs e)
        {
            btnTimeConfirm.Enabled = false;
            rdo_checkedChange(rdoSTime2, txtSTimeLow, txtSTimeHigh);
            grpSetTime(grpSTime, cdtS, txtSTimeLow, txtSTimeHigh);
            SearchControl.SelectOrOrderProjectList("No", cdtS);
            grReFresh();
        }

        private void rdoSTime1_CheckedChanged(object sender, EventArgs e)
        {
            btnTimeConfirm.Enabled = false;
            rdo_checkedChange(rdoSTime1, txtSTimeLow, txtSTimeHigh);
            grpSetTime(grpSTime, cdtS, txtSTimeLow, txtSTimeHigh);
            SearchControl.SelectOrOrderProjectList("No", cdtS);
            grReFresh();
        }


        private void rdoTimeAll_CheckedChanged(object sender, EventArgs e)
        {
            btnTimeConfirm.Enabled = false;
            rdo_checkedChange(rdoTimeAll, txtSTimeLow, txtSTimeHigh);
            grpSetTime(grpSTime, cdtS, txtSTimeLow, txtSTimeHigh);
            SearchControl.SelectOrOrderProjectList("No", cdtS);
            grReFresh();
        }
        //第二组单选按钮框处理:处理起投金额
        private void rdoSMoney4_CheckedChanged(object sender, EventArgs e)
        {
            rdo_checkedChange(rdoSMoney4, txtSMoneyLow, txtSMoneyHigh);
            btnMoneyConfirm.Enabled = true;
        }
        private void rdoSMoney3_CheckedChanged(object sender, EventArgs e)
        {
            rdo_checkedChange(rdoSMoney3, txtSMoneyLow, txtSMoneyHigh);
            btnMoneyConfirm.Enabled = false;
            grpSetMoney(grpSMoney, cdtS, txtSMoneyLow, txtSMoneyHigh);
            SearchControl.SelectOrOrderProjectList("No", cdtS);
            grReFresh();
        }

        private void rdoSMoney2_CheckedChanged(object sender, EventArgs e)
        {
            rdo_checkedChange(rdoSMoney2, txtSMoneyLow, txtSMoneyHigh);
            btnMoneyConfirm.Enabled = false;
            grpSetMoney(grpSMoney, cdtS, txtSMoneyLow, txtSMoneyHigh);
            SearchControl.SelectOrOrderProjectList("No", cdtS);
            grReFresh();
        }

        private void rdoSMoney1_CheckedChanged(object sender, EventArgs e)
        {
            rdo_checkedChange(rdoSMoney1, txtSMoneyLow, txtSMoneyHigh);
            btnMoneyConfirm.Enabled = false;
            grpSetMoney(grpSMoney, cdtS, txtSMoneyLow, txtSMoneyHigh);
            SearchControl.SelectOrOrderProjectList("No", cdtS);
            grReFresh();
        }


        private void rdoMoneyAll_CheckedChanged(object sender, EventArgs e)
        {
            rdo_checkedChange(rdoMoneyAll, txtSMoneyLow, txtSMoneyHigh);
            btnMoneyConfirm.Enabled = false;
            grpSetMoney(grpSMoney, cdtS, txtSMoneyLow, txtSMoneyHigh);
            SearchControl.SelectOrOrderProjectList("No", cdtS);
            grReFresh();

        }
        //第三组单选按钮框处理:处理收益率
        private void rdoSRate4_CheckedChanged(object sender, EventArgs e)
        {
            rdo_checkedChange(rdoSRate4, txtSRateLow, txtSRateHigh);
            btnRateConfirm.Enabled = true;
        }

        private void rdoSRate3_CheckedChanged(object sender, EventArgs e)
        {
            rdo_checkedChange(rdoSRate3, txtSRateLow, txtSRateHigh);
            btnRateConfirm.Enabled = false;
            grpSetRate(grpSRate, cdtS, txtSRateLow, txtSRateHigh);
            SearchControl.SelectOrOrderProjectList("No", cdtS);
            grReFresh();
        }

        private void rdoSRate2_CheckedChanged(object sender, EventArgs e)
        {
            rdo_checkedChange(rdoSRate2, txtSRateLow, txtSRateHigh);
            btnRateConfirm.Enabled = false;
            grpSetRate(grpSRate, cdtS, txtSRateLow, txtSRateHigh);
            SearchControl.SelectOrOrderProjectList("No", cdtS);
            grReFresh();
        }

        private void rdoSRate1_CheckedChanged(object sender, EventArgs e)
        {
            rdo_checkedChange(rdoSRate1, txtSRateLow, txtSRateHigh);
            btnRateConfirm.Enabled = false;
            grpSetRate(grpSRate, cdtS, txtSRateLow, txtSRateHigh);
            SearchControl.SelectOrOrderProjectList("No", cdtS);
            grReFresh();
        }


        private void rdoRateAll_CheckedChanged(object sender, EventArgs e)
        {
            rdo_checkedChange(rdoRateAll, txtSRateLow, txtSRateHigh);
            btnTimeConfirm.Enabled = false;
            grpSetRate(grpSRate, cdtS, txtSRateLow, txtSRateHigh);
            SearchControl.SelectOrOrderProjectList("No", cdtS);
            grReFresh();
        }

        //btnConfirm处理！！
        private void btnTimeConfirm_Click(object sender, EventArgs e)
        {
            grpSetTime(grpSTime, cdtS, txtSTimeLow, txtSTimeHigh);
            //  grpSetTime(grpSTime, cdtS, txtSTimeLow, txtSTimeHigh);
            SearchControl.SelectOrOrderProjectList("No", cdtS);
            grReFresh();

        }

        private void btnMoneyConfirm_Click(object sender, EventArgs e)
        {
            grpSetMoney(grpSMoney, cdtS, txtSMoneyLow, txtSMoneyHigh);
            SearchControl.SelectOrOrderProjectList("No", cdtS);
            grReFresh();
        }

        private void btnRateConfirm_Click(object sender, EventArgs e)
        {
            grpSetRate(grpSRate, cdtS, txtSRateLow, txtSRateHigh);
            SearchControl.SelectOrOrderProjectList("No", cdtS);
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
            SearchControl.SelectOrOrderProjectList("No", cdtS);
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
            SearchControl.SelectOrOrderProjectList("No", cdtS);
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
            SearchControl.SelectOrOrderProjectList("No", cdtS);
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
            SearchControl.SelectOrOrderProjectList("No", cdtS);
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
            SearchControl.SelectOrOrderProjectList("No", cdtS);
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
            SearchControl.SelectOrOrderProjectList("No", cdtS);
            grReFresh();
        }

        //抢购按钮
        private void btnRush_Click(object sender, EventArgs e)
        {
            int tem;
            grpSetTime(grpSTime, cdtS, txtSTimeLow, txtSTimeHigh);
            grpSetMoney(grpSMoney, cdtS, txtSMoneyLow, txtSMoneyHigh);
            grpSetRate(grpSRate, cdtS, txtSRateLow, txtSRateHigh);

            //  cdtR.set(cdtS);

            grpSetgrp(grpSTime, grpRTime);
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


        //public event EventHandler GetValue;
        private void grpSearch_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                string buttonText = grpSearch.Rows[e.RowIndex].Cells[4].Value.ToString();
                if (buttonText.Equals("投资") && e.ColumnIndex == 4)
                {
                    //if (GetValue != null)
                    //{
                    //    List<String> s = tableNameList;//假如这个就是要传的值
                    //    GetValue(s, e);
                    //}
                    frmDialog dlgHint = new frmDialog();
                    dlgHint.ShowDialog();
                    double money = dlgHint.forResult();
                    if (money == -1)
                        return;
                    string name = "";
                    name += grpSearch.Rows[e.RowIndex].Cells[0].Value.ToString();
                    //   AddRecord(money,name);
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
            catch (System.NullReferenceException) { }
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
                SearchControl.SelectOrOrderProjectList("No", cdtS);
                grReFresh();
            }
            else
            {
                SearchControl.SelectOrOrderProjectList("No", cdtS);
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
    }
}
