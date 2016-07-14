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
    public partial class frmAddTable : Form
    {
        // List<String> tableNameList;
        public frmAddTable()
        {
            InitializeComponent();
            //   this.tableNameList = tableNameList;
        }

        public event EventHandler GetValue;
        //窗口关闭事件

        private void form_Closed(object sender, EventArgs e) //参数类型不记得了，自己点出来
        {
            if (GetValue != null)
            {
                string s = tBxNewTableName.Text;//假如这个就是要传的值
                GetValue(s, e);
            }
        }

        private void btnAddNewTable_Click(object sender, EventArgs e)
        {
            if(tBxNewTableName.Text.Length != 0)
            {
                string s = tBxNewTableName.Text;//假如这个就是要传的值
                GetValue(s, e);
                this.Close();
            }
            else
            {
                MessageBox.Show("请输入完整数据", "提示信息", MessageBoxButtons.OK);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
