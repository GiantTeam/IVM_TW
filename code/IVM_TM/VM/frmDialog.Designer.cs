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
            this.lblDTime = new System.Windows.Forms.Label();
            this.lblDMoney = new System.Windows.Forms.Label();
            this.lblHint = new System.Windows.Forms.Label();
            this.btnYes = new System.Windows.Forms.Button();
            this.btnCannel = new System.Windows.Forms.Button();
            this.txtDTime = new System.Windows.Forms.TextBox();
            this.txtDMoney = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // lblDTime
            // 
            this.lblDTime.AutoSize = true;
            this.lblDTime.Enabled = false;
            this.lblDTime.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblDTime.Location = new System.Drawing.Point(8, 40);
            this.lblDTime.Name = "lblDTime";
            this.lblDTime.Size = new System.Drawing.Size(109, 12);
            this.lblDTime.TabIndex = 0;
            this.lblDTime.Text = "投资期限（月）：";
            // 
            // lblDMoney
            // 
            this.lblDMoney.AutoSize = true;
            this.lblDMoney.Enabled = false;
            this.lblDMoney.Location = new System.Drawing.Point(8, 72);
            this.lblDMoney.Name = "lblDMoney";
            this.lblDMoney.Size = new System.Drawing.Size(109, 12);
            this.lblDMoney.TabIndex = 1;
            this.lblDMoney.Text = "投资金额（万）：";
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
            this.btnYes.Location = new System.Drawing.Point(32, 96);
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
            this.btnCannel.Location = new System.Drawing.Point(136, 96);
            this.btnCannel.Name = "btnCannel";
            this.btnCannel.Size = new System.Drawing.Size(75, 23);
            this.btnCannel.TabIndex = 4;
            this.btnCannel.Text = "取消";
            this.btnCannel.UseVisualStyleBackColor = true;
            this.btnCannel.Click += new System.EventHandler(this.btnCannel_Click);
            // 
            // txtDTime
            // 
            this.txtDTime.Location = new System.Drawing.Point(112, 32);
            this.txtDTime.Name = "txtDTime";
            this.txtDTime.Size = new System.Drawing.Size(120, 21);
            this.txtDTime.TabIndex = 5;
            // 
            // txtDMoney
            // 
            this.txtDMoney.Location = new System.Drawing.Point(112, 64);
            this.txtDMoney.Name = "txtDMoney";
            this.txtDMoney.Size = new System.Drawing.Size(120, 21);
            this.txtDMoney.TabIndex = 6;
            // 
            // frmDialog
            // 
            this.AcceptButton = this.btnYes;
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(242, 127);
            this.Controls.Add(this.txtDMoney);
            this.Controls.Add(this.txtDTime);
            this.Controls.Add(this.btnCannel);
            this.Controls.Add(this.btnYes);
            this.Controls.Add(this.lblHint);
            this.Controls.Add(this.lblDMoney);
            this.Controls.Add(this.lblDTime);
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

        private System.Windows.Forms.Label lblDTime;
        private System.Windows.Forms.Label lblDMoney;
        private System.Windows.Forms.Label lblHint;
        private System.Windows.Forms.Button btnYes;
        private System.Windows.Forms.Button btnCannel;
        private System.Windows.Forms.TextBox txtDTime;
        private System.Windows.Forms.TextBox txtDMoney;
    }
}