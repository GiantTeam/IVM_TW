using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
namespace VM
{
   
    public partial class frmDialog : Form
    {

        List<String> tableNameList = new List<String>();
        public double money;
        string strPath = System.Environment.CurrentDirectory;
        //***************************************************************************************
        public frmDialog()
        {
            InitializeComponent();

            tableNameList.Clear();
            DirectoryInfo dir = new DirectoryInfo(strPath);
            foreach (FileInfo fi in dir.GetFiles("*.xls"))
            {
                //if (fi.FullName.EndsWith(".xls")) 
                //{                     
                tableNameList.Add(fi.Name);
                //}
            }

            cbBTableNameList.Items.Clear();
            foreach (String str in tableNameList)
            {                
                cbBTableNameList.Items.Add(str);
            }
            cbBTableNameList.SelectedIndex = 0;
            // frmMain f =(frmMain) this.ParentForm;
            //f.GetValue += new EventHandler(SendValue);
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

        
       // private void SendValue(object sender, EventArgs e)
       // {
       //     tableNameList = sender as List<string>;
       ////     strNewTableName = sender as string;

       // }
    }

}
