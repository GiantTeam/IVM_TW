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
        public String     strSearchInfo=null;
        public static int s_pgNum=0;
        public static int s_maxItem;
        const int         c_ITEMNUM=8;
        public mData   g_SearchCondition;
        public RadioButton rdoTem;

        public class mData
        {
           public  String name;
           public  String money;
           public  String date;
           public  String rate;
            
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

        private void btnActionRush_Click(object sender, EventArgs e)
        {
            if (btnActionRush.Text.Equals("开始抢购"))
            {
                btnActionRush.Text = "停止抢购";
            }
            else
            {
                btnActionRush.Text = "开始抢购";
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            if (txtSearch.Text != null)
            {
                strSearchInfo = txtSearch.Text;
            }
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            mData record=new mData();
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

        private void btnPageUp_Click(object sender, EventArgs e)
        {
            s_pgNum = s_pgNum > 0 ? s_pgNum-- : 0;
        }

        private void btnPageDown_Click(object sender, EventArgs e)
        {
            s_pgNum = s_pgNum * c_ITEMNUM < s_maxItem ? s_pgNum++ : s_pgNum;
        }

        private void rdoSortDefault_CheckedChanged(object sender, EventArgs e)
        {
            grvSearch.Sort(grvSearch.Columns[0], ListSortDirection.Ascending);  
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

        //可考虑重构，Map方式托管
        private void rdoSTime4_CheckedChanged(object sender, EventArgs e)
        {
            txtSTimeLow.Enabled = true;
            txtSTimeHigh.Enabled = true;
        }

        private void rdoSTime3_CheckedChanged(object sender, EventArgs e)
        {
            txtSTimeLow.Enabled = false;
            txtSTimeHigh.Enabled = false;
        }


    }
}
