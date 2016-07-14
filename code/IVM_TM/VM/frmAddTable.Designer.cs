namespace VM
{
    partial class frmAddTable
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
            this.label1 = new System.Windows.Forms.Label();
            this.tBxNewTableName = new System.Windows.Forms.TextBox();
            this.btnAddNewTable = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(33, 30);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "新投资表";
            // 
            // tBxNewTableName
            // 
            this.tBxNewTableName.Location = new System.Drawing.Point(121, 27);
            this.tBxNewTableName.Name = "tBxNewTableName";
            this.tBxNewTableName.Size = new System.Drawing.Size(100, 21);
            this.tBxNewTableName.TabIndex = 1;
            // 
            // btnAddNewTable
            // 
            this.btnAddNewTable.Location = new System.Drawing.Point(35, 73);
            this.btnAddNewTable.Name = "btnAddNewTable";
            this.btnAddNewTable.Size = new System.Drawing.Size(75, 23);
            this.btnAddNewTable.TabIndex = 2;
            this.btnAddNewTable.Text = "确认添加";
            this.btnAddNewTable.UseVisualStyleBackColor = true;
            this.btnAddNewTable.Click += new System.EventHandler(this.btnAddNewTable_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(146, 73);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 3;
            this.btnCancel.Text = "取消";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // frmAddTable
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(324, 121);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnAddNewTable);
            this.Controls.Add(this.tBxNewTableName);
            this.Controls.Add(this.label1);
            this.Name = "frmAddTable";
            this.Text = "输入新增投资表的名字";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tBxNewTableName;
        private System.Windows.Forms.Button btnAddNewTable;
        private System.Windows.Forms.Button btnCancel;
    }
}