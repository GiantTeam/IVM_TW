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
   
    public partial class frmDialog : Form
    {

        public String strAddInfo = null;
//***************************************************************************************
        public frmDialog()
        {
            InitializeComponent();
        }

        private void btnYes_Click(object sender, EventArgs e)
        {
            if (txtDTime.Text != "" && txtDMoney.Text != "")
            {
              strAddInfo = "time=" + txtDTime.Text + "\nMoney=" + txtDMoney.Text;
              this.Close();
            }
           else
           {
               MessageBox.Show("请将项目信息补充完整");
           }
         }

        private void btnCannel_Click(object sender, EventArgs e)
        {
            strAddInfo = null;
            this.Close();
        }

        public String forResult()
        {
            return strAddInfo;
        }
    }
}
