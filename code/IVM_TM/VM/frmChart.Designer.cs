﻿namespace VM
{
    partial class frmChart
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
            this.lblCMoney = new System.Windows.Forms.Label();
            this.lblCInterst = new System.Windows.Forms.Label();
            this.lblCMoney2 = new System.Windows.Forms.Label();
            this.lblCGet = new System.Windows.Forms.Label();
            this.txtC2 = new System.Windows.Forms.TextBox();
            this.txtC1 = new System.Windows.Forms.TextBox();
            this.txtC3 = new System.Windows.Forms.TextBox();
            this.txtC4 = new System.Windows.Forms.TextBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.btnCReturn = new System.Windows.Forms.Button();
            this.btnC1 = new System.Windows.Forms.Button();
            this.btnC2 = new System.Windows.Forms.Button();
            this.btnC3 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // lblCMoney
            // 
            this.lblCMoney.AutoSize = true;
            this.lblCMoney.Location = new System.Drawing.Point(56, 24);
            this.lblCMoney.Name = "lblCMoney";
            this.lblCMoney.Size = new System.Drawing.Size(77, 12);
            this.lblCMoney.TabIndex = 0;
            this.lblCMoney.Text = "投资总金额：";
            // 
            // lblCInterst
            // 
            this.lblCInterst.AutoSize = true;
            this.lblCInterst.Location = new System.Drawing.Point(64, 56);
            this.lblCInterst.Name = "lblCInterst";
            this.lblCInterst.Size = new System.Drawing.Size(41, 12);
            this.lblCInterst.TabIndex = 1;
            this.lblCInterst.Text = "本息：";
            // 
            // lblCMoney2
            // 
            this.lblCMoney2.AutoSize = true;
            this.lblCMoney2.Location = new System.Drawing.Point(312, 24);
            this.lblCMoney2.Name = "lblCMoney2";
            this.lblCMoney2.Size = new System.Drawing.Size(65, 12);
            this.lblCMoney2.TabIndex = 2;
            this.lblCMoney2.Text = "待收金额：";
            // 
            // lblCGet
            // 
            this.lblCGet.AutoSize = true;
            this.lblCGet.Location = new System.Drawing.Point(312, 56);
            this.lblCGet.Name = "lblCGet";
            this.lblCGet.Size = new System.Drawing.Size(77, 12);
            this.lblCGet.TabIndex = 3;
            this.lblCGet.Text = "已获总收益：";
            // 
            // txtC2
            // 
            this.txtC2.Enabled = false;
            this.txtC2.Location = new System.Drawing.Point(384, 16);
            this.txtC2.Name = "txtC2";
            this.txtC2.Size = new System.Drawing.Size(132, 21);
            this.txtC2.TabIndex = 4;
            // 
            // txtC1
            // 
            this.txtC1.Enabled = false;
            this.txtC1.Location = new System.Drawing.Point(136, 16);
            this.txtC1.Name = "txtC1";
            this.txtC1.Size = new System.Drawing.Size(132, 21);
            this.txtC1.TabIndex = 5;
            // 
            // txtC3
            // 
            this.txtC3.Enabled = false;
            this.txtC3.Location = new System.Drawing.Point(136, 56);
            this.txtC3.Name = "txtC3";
            this.txtC3.Size = new System.Drawing.Size(132, 21);
            this.txtC3.TabIndex = 6;
            // 
            // txtC4
            // 
            this.txtC4.Enabled = false;
            this.txtC4.Location = new System.Drawing.Point(384, 48);
            this.txtC4.Name = "txtC4";
            this.txtC4.Size = new System.Drawing.Size(132, 21);
            this.txtC4.TabIndex = 7;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(48, 96);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(800, 500);
            this.pictureBox1.TabIndex = 8;
            this.pictureBox1.TabStop = false;
            // 
            // btnCReturn
            // 
            this.btnCReturn.Location = new System.Drawing.Point(712, 56);
            this.btnCReturn.Name = "btnCReturn";
            this.btnCReturn.Size = new System.Drawing.Size(75, 23);
            this.btnCReturn.TabIndex = 14;
            this.btnCReturn.Text = "返回";
            this.btnCReturn.UseVisualStyleBackColor = true;
            this.btnCReturn.Click += new System.EventHandler(this.btnCReturn_Click);
            // 
            // btnC1
            // 
            this.btnC1.Location = new System.Drawing.Point(576, 16);
            this.btnC1.Name = "btnC1";
            this.btnC1.Size = new System.Drawing.Size(75, 23);
            this.btnC1.TabIndex = 15;
            this.btnC1.Text = "收益";
            this.btnC1.UseVisualStyleBackColor = true;
            this.btnC1.Click += new System.EventHandler(this.btnC1_Click);
            // 
            // btnC2
            // 
            this.btnC2.Location = new System.Drawing.Point(576, 56);
            this.btnC2.Name = "btnC2";
            this.btnC2.Size = new System.Drawing.Size(75, 23);
            this.btnC2.TabIndex = 16;
            this.btnC2.Text = "投资";
            this.btnC2.UseVisualStyleBackColor = true;
            this.btnC2.Click += new System.EventHandler(this.btnC2_Click);
            // 
            // btnC3
            // 
            this.btnC3.Location = new System.Drawing.Point(712, 16);
            this.btnC3.Name = "btnC3";
            this.btnC3.Size = new System.Drawing.Size(75, 23);
            this.btnC3.TabIndex = 17;
            this.btnC3.Text = "收益率";
            this.btnC3.UseVisualStyleBackColor = true;
            this.btnC3.Click += new System.EventHandler(this.btnC3_Click);
            // 
            // frmChart
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(901, 630);
            this.Controls.Add(this.btnC3);
            this.Controls.Add(this.btnC2);
            this.Controls.Add(this.btnC1);
            this.Controls.Add(this.btnCReturn);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.txtC4);
            this.Controls.Add(this.txtC3);
            this.Controls.Add(this.txtC1);
            this.Controls.Add(this.txtC2);
            this.Controls.Add(this.lblCGet);
            this.Controls.Add(this.lblCMoney2);
            this.Controls.Add(this.lblCInterst);
            this.Controls.Add(this.lblCMoney);
            this.Name = "frmChart";
            this.Text = "图表分析";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblCMoney;
        private System.Windows.Forms.Label lblCInterst;
        private System.Windows.Forms.Label lblCMoney2;
        private System.Windows.Forms.Label lblCGet;
        private System.Windows.Forms.TextBox txtC2;
        private System.Windows.Forms.TextBox txtC1;
        private System.Windows.Forms.TextBox txtC3;
        private System.Windows.Forms.TextBox txtC4;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button btnCReturn;
        private System.Windows.Forms.Button btnC1;
        private System.Windows.Forms.Button btnC2;
        private System.Windows.Forms.Button btnC3;
    }
}