namespace VM
{
    partial class frmDialog
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.lblDMoney = new System.Windows.Forms.Label();
            this.lblHint = new System.Windows.Forms.Label();
            this.btnYes = new System.Windows.Forms.Button();
            this.btnCannel = new System.Windows.Forms.Button();
            this.txtDMoney = new System.Windows.Forms.TextBox();
            this.cbBTableNameList = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lblDMoney
            // 
            this.lblDMoney.AutoSize = true;
            this.lblDMoney.Enabled = false;
            this.lblDMoney.Location = new System.Drawing.Point(8, 85);
            this.lblDMoney.Name = "lblDMoney";
            this.lblDMoney.Size = new System.Drawing.Size(97, 12);
            this.lblDMoney.TabIndex = 1;
            this.lblDMoney.Text = "投资金额(元)：";
            // 
            // lblHint
            // 
            this.lblHint.AutoSize = true;
            this.lblHint.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblHint.Location = new System.Drawing.Point(56, 8);
            this.lblHint.Name = "lblHint";
            this.lblHint.Size = new System.Drawing.Size(127, 14);
            this.lblHint.TabIndex = 2;
            this.lblHint.Text = "请补充项目信息！";
            // 
            // btnYes
            // 
            this.btnYes.Location = new System.Drawing.Point(24, 125);
            this.btnYes.Name = "btnYes";
            this.btnYes.Size = new System.Drawing.Size(75, 23);
            this.btnYes.TabIndex = 3;
            this.btnYes.Text = "确定";
            this.btnYes.UseVisualStyleBackColor = true;
            this.btnYes.Click += new System.EventHandler(this.btnYes_Click);
            // 
            // btnCannel
            // 
            this.btnCannel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCannel.Location = new System.Drawing.Point(136, 125);
            this.btnCannel.Name = "btnCannel";
            this.btnCannel.Size = new System.Drawing.Size(75, 23);
            this.btnCannel.TabIndex = 4;
            this.btnCannel.Text = "取消";
            this.btnCannel.UseVisualStyleBackColor = true;
            this.btnCannel.Click += new System.EventHandler(this.btnCannel_Click);
            // 
            // txtDMoney
            // 
            this.txtDMoney.Location = new System.Drawing.Point(112, 77);
            this.txtDMoney.Name = "txtDMoney";
            this.txtDMoney.Size = new System.Drawing.Size(120, 21);
            this.txtDMoney.TabIndex = 6;
            // 
            // cbBTableNameList
            // 
            this.cbBTableNameList.FormattingEnabled = true;
            this.cbBTableNameList.Location = new System.Drawing.Point(91, 38);
            this.cbBTableNameList.Name = "cbBTableNameList";
            this.cbBTableNameList.Size = new System.Drawing.Size(154, 20);
            this.cbBTableNameList.TabIndex = 24;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Enabled = false;
            this.label1.Location = new System.Drawing.Point(22, 46);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(44, 12);
            this.label1.TabIndex = 25;
            this.label1.Text = "投资表";
            // 
            // frmDialog
            // 
            this.AcceptButton = this.btnYes;
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(257, 197);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cbBTableNameList);
            this.Controls.Add(this.txtDMoney);
            this.Controls.Add(this.btnCannel);
            this.Controls.Add(this.btnYes);
            this.Controls.Add(this.lblHint);
            this.Controls.Add(this.lblDMoney);
            this.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.ImeMode = System.Windows.Forms.ImeMode.Disable;
            this.MaximizeBox = false;
            this.Name = "frmDialog";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "增加到记录";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblDMoney;
        private System.Windows.Forms.Label lblHint;
        private System.Windows.Forms.Button btnYes;
        private System.Windows.Forms.Button btnCannel;
        private System.Windows.Forms.TextBox txtDMoney;
        private System.Windows.Forms.ComboBox cbBTableNameList;
        private System.Windows.Forms.Label label1;
    }
}