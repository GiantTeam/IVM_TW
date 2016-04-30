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
        public String strSearchInfo=null;

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

    }
}
