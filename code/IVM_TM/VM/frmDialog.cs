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

        public double money;
//***************************************************************************************
        public frmDialog()
        {
            InitializeComponent();
        }

        private void btnYes_Click(object sender, EventArgs e)
        {
            if ( txtDMoney.Text != "")
            {
                try
                {
                    money = Convert.ToDouble(txtDMoney.Text);
                    this.Close();
                }
                catch 
                {
                    MessageBox.Show("输入有误，请重新输入");
                }
            }
           else
           {
               MessageBox.Show("请将项目信息补充完整");
           }
         }

        private void btnCannel_Click(object sender, EventArgs e)
        {
            money = -1;
            this.Close();
        }

        public double forResult()
        {
            return money;
        }
    }
}
