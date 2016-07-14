namespace VM
{
    partial class frmTable
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            this.label1 = new System.Windows.Forms.Label();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnAdd = new System.Windows.Forms.Button();
            this.grpStatisticTable = new System.Windows.Forms.DataGridView();
            this.ColumnTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnType = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnMoney = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Num = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Other = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.mmuStatistic = new System.Windows.Forms.MenuStrip();
            this.mmuSave = new System.Windows.Forms.ToolStripMenuItem();
            this.mmuEmpty = new System.Windows.Forms.ToolStripMenuItem();
            this.mmuExport = new System.Windows.Forms.ToolStripMenuItem();
            this.mmuChart = new System.Windows.Forms.ToolStripMenuItem();
            this.label4 = new System.Windows.Forms.Label();
            this.txtC3 = new System.Windows.Forms.TextBox();
            this.lblCInterst = new System.Windows.Forms.Label();
            this.btnC3 = new System.Windows.Forms.Button();
            this.btnC2 = new System.Windows.Forms.Button();
            this.btnC1 = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.txtRe = new System.Windows.Forms.TextBox();
            this.lblCMoney2 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtWholeInvest = new System.Windows.Forms.TextBox();
            this.lblCMoney = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label5 = new System.Windows.Forms.Label();
            this.lblRemain = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grpStatisticTable)).BeginInit();
            this.mmuStatistic.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(-6, 338);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(11, 12);
            this.label1.TabIndex = 19;
            this.label1.Text = "h";
            // 
            // splitContainer1
            // 
            this.splitContainer1.Location = new System.Drawing.Point(1, 1);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.btnDelete);
            this.splitContainer1.Panel1.Controls.Add(this.btnAdd);
            this.splitContainer1.Panel1.Controls.Add(this.grpStatisticTable);
            this.splitContainer1.Panel1.Controls.Add(this.mmuStatistic);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.label6);
            this.splitContainer1.Panel2.Controls.Add(this.lblRemain);
            this.splitContainer1.Panel2.Controls.Add(this.label5);
            this.splitContainer1.Panel2.Controls.Add(this.label4);
            this.splitContainer1.Panel2.Controls.Add(this.txtC3);
            this.splitContainer1.Panel2.Controls.Add(this.lblCInterst);
            this.splitContainer1.Panel2.Controls.Add(this.pictureBox1);
            this.splitContainer1.Panel2.Controls.Add(this.btnC3);
            this.splitContainer1.Panel2.Controls.Add(this.btnC2);
            this.splitContainer1.Panel2.Controls.Add(this.btnC1);
            this.splitContainer1.Panel2.Controls.Add(this.label3);
            this.splitContainer1.Panel2.Controls.Add(this.txtRe);
            this.splitContainer1.Panel2.Controls.Add(this.lblCMoney2);
            this.splitContainer1.Panel2.Controls.Add(this.label2);
            this.splitContainer1.Panel2.Controls.Add(this.txtWholeInvest);
            this.splitContainer1.Panel2.Controls.Add(this.lblCMoney);
            this.splitContainer1.Size = new System.Drawing.Size(1166, 681);
            this.splitContainer1.SplitterDistance = 601;
            this.splitContainer1.TabIndex = 20;
            // 
            // btnDelete
            // 
            this.btnDelete.Location = new System.Drawing.Point(484, 523);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(85, 46);
            this.btnDelete.TabIndex = 23;
            this.btnDelete.Text = "删除";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(371, 523);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(73, 46);
            this.btnAdd.TabIndex = 22;
            this.btnAdd.Text = "添加";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // grpStatisticTable
            // 
            this.grpStatisticTable.AllowUserToAddRows = false;
            this.grpStatisticTable.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.BottomCenter;
            this.grpStatisticTable.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.grpStatisticTable.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.grpStatisticTable.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.grpStatisticTable.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.grpStatisticTable.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.RaisedVertical;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.grpStatisticTable.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.grpStatisticTable.ColumnHeadersHeight = 30;
            this.grpStatisticTable.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ColumnTime,
            this.ColumnType,
            this.ColumnMoney,
            this.ColumnName,
            this.Num,
            this.Other});
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.grpStatisticTable.DefaultCellStyle = dataGridViewCellStyle3;
            this.grpStatisticTable.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter;
            this.grpStatisticTable.Location = new System.Drawing.Point(0, 32);
            this.grpStatisticTable.Name = "grpStatisticTable";
            this.grpStatisticTable.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Sunken;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.grpStatisticTable.RowHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.grpStatisticTable.RowHeadersVisible = false;
            this.grpStatisticTable.RowHeadersWidth = 100;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.grpStatisticTable.RowsDefaultCellStyle = dataGridViewCellStyle5;
            this.grpStatisticTable.RowTemplate.Height = 23;
            this.grpStatisticTable.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.grpStatisticTable.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.grpStatisticTable.Size = new System.Drawing.Size(592, 464);
            this.grpStatisticTable.TabIndex = 21;
            this.grpStatisticTable.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.grpStatisticTable_CellContentClick);
            // 
            // ColumnTime
            // 
            this.ColumnTime.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.ColumnTime.FillWeight = 101.5228F;
            this.ColumnTime.Frozen = true;
            this.ColumnTime.HeaderText = "时间";
            this.ColumnTime.Name = "ColumnTime";
            this.ColumnTime.ReadOnly = true;
            // 
            // ColumnType
            // 
            this.ColumnType.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.ColumnType.FillWeight = 86.8386F;
            this.ColumnType.Frozen = true;
            this.ColumnType.HeaderText = "类型";
            this.ColumnType.Name = "ColumnType";
            this.ColumnType.ReadOnly = true;
            this.ColumnType.Width = 50;
            // 
            // ColumnMoney
            // 
            this.ColumnMoney.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.ColumnMoney.FillWeight = 86.8386F;
            this.ColumnMoney.Frozen = true;
            this.ColumnMoney.HeaderText = "金额";
            this.ColumnMoney.Name = "ColumnMoney";
            // 
            // ColumnName
            // 
            this.ColumnName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.ColumnName.FillWeight = 86.8386F;
            this.ColumnName.Frozen = true;
            this.ColumnName.HeaderText = "项目";
            this.ColumnName.Name = "ColumnName";
            this.ColumnName.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.ColumnName.Width = 170;
            // 
            // Num
            // 
            this.Num.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.Num.Frozen = true;
            this.Num.HeaderText = "编号";
            this.Num.Name = "Num";
            this.Num.ReadOnly = true;
            // 
            // Other
            // 
            this.Other.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Other.FillWeight = 137.9613F;
            this.Other.HeaderText = "其他";
            this.Other.Name = "Other";
            this.Other.ReadOnly = true;
            // 
            // mmuStatistic
            // 
            this.mmuStatistic.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.mmuStatistic.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mmuSave,
            this.mmuEmpty,
            this.mmuExport,
            this.mmuChart});
            this.mmuStatistic.Location = new System.Drawing.Point(0, 0);
            this.mmuStatistic.Name = "mmuStatistic";
            this.mmuStatistic.Size = new System.Drawing.Size(601, 29);
            this.mmuStatistic.TabIndex = 20;
            this.mmuStatistic.Text = "menuStrip1";
            // 
            // mmuSave
            // 
            this.mmuSave.Name = "mmuSave";
            this.mmuSave.Size = new System.Drawing.Size(54, 25);
            this.mmuSave.Text = "保存";
            this.mmuSave.Click += new System.EventHandler(this.mmuSave_Click);
            // 
            // mmuEmpty
            // 
            this.mmuEmpty.Name = "mmuEmpty";
            this.mmuEmpty.Size = new System.Drawing.Size(54, 25);
            this.mmuEmpty.Text = "清空";
            this.mmuEmpty.Click += new System.EventHandler(this.mmuEmpty_Click);
            // 
            // mmuExport
            // 
            this.mmuExport.Name = "mmuExport";
            this.mmuExport.Size = new System.Drawing.Size(54, 25);
            this.mmuExport.Text = "导出";
            this.mmuExport.Click += new System.EventHandler(this.mmuExport_Click);
            // 
            // mmuChart
            // 
            this.mmuChart.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.mmuChart.Name = "mmuChart";
            this.mmuChart.Size = new System.Drawing.Size(86, 25);
            this.mmuChart.Text = "图表分析";
            this.mmuChart.Click += new System.EventHandler(this.mmuChart_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label4.Location = new System.Drawing.Point(264, 94);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(17, 16);
            this.label4.TabIndex = 32;
            this.label4.Text = "%";
            // 
            // txtC3
            // 
            this.txtC3.Enabled = false;
            this.txtC3.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtC3.Location = new System.Drawing.Point(125, 84);
            this.txtC3.Name = "txtC3";
            this.txtC3.Size = new System.Drawing.Size(132, 26);
            this.txtC3.TabIndex = 31;
            // 
            // lblCInterst
            // 
            this.lblCInterst.AutoSize = true;
            this.lblCInterst.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblCInterst.Location = new System.Drawing.Point(54, 92);
            this.lblCInterst.Name = "lblCInterst";
            this.lblCInterst.Size = new System.Drawing.Size(76, 16);
            this.lblCInterst.TabIndex = 30;
            this.lblCInterst.Text = "总利率：";
            // 
            // btnC3
            // 
            this.btnC3.Location = new System.Drawing.Point(326, 48);
            this.btnC3.Name = "btnC3";
            this.btnC3.Size = new System.Drawing.Size(75, 23);
            this.btnC3.TabIndex = 28;
            this.btnC3.Text = "收益率";
            this.btnC3.UseVisualStyleBackColor = true;
            this.btnC3.Click += new System.EventHandler(this.btnC3_Click);
            // 
            // btnC2
            // 
            this.btnC2.Location = new System.Drawing.Point(326, 8);
            this.btnC2.Name = "btnC2";
            this.btnC2.Size = new System.Drawing.Size(75, 23);
            this.btnC2.TabIndex = 22;
            this.btnC2.Text = "投资";
            this.btnC2.UseVisualStyleBackColor = true;
            this.btnC2.Click += new System.EventHandler(this.btnC2_Click);
            // 
            // btnC1
            // 
            this.btnC1.Location = new System.Drawing.Point(326, 92);
            this.btnC1.Name = "btnC1";
            this.btnC1.Size = new System.Drawing.Size(75, 23);
            this.btnC1.TabIndex = 21;
            this.btnC1.Text = "收益";
            this.btnC1.UseVisualStyleBackColor = true;
            this.btnC1.Click += new System.EventHandler(this.btnC1_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label3.Location = new System.Drawing.Point(262, 55);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(25, 16);
            this.label3.TabIndex = 24;
            this.label3.Text = "元";
            // 
            // txtRe
            // 
            this.txtRe.Enabled = false;
            this.txtRe.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtRe.Location = new System.Drawing.Point(124, 45);
            this.txtRe.Name = "txtRe";
            this.txtRe.Size = new System.Drawing.Size(132, 26);
            this.txtRe.TabIndex = 23;
            // 
            // lblCMoney2
            // 
            this.lblCMoney2.AutoSize = true;
            this.lblCMoney2.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblCMoney2.Location = new System.Drawing.Point(57, 50);
            this.lblCMoney2.Name = "lblCMoney2";
            this.lblCMoney2.Size = new System.Drawing.Size(76, 16);
            this.lblCMoney2.TabIndex = 22;
            this.lblCMoney2.Text = "总收益：";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.Location = new System.Drawing.Point(262, 15);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(25, 16);
            this.label2.TabIndex = 21;
            this.label2.Text = "元";
            // 
            // txtWholeInvest
            // 
            this.txtWholeInvest.Enabled = false;
            this.txtWholeInvest.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtWholeInvest.Location = new System.Drawing.Point(124, 7);
            this.txtWholeInvest.Name = "txtWholeInvest";
            this.txtWholeInvest.Size = new System.Drawing.Size(132, 26);
            this.txtWholeInvest.TabIndex = 20;
            // 
            // lblCMoney
            // 
            this.lblCMoney.AutoSize = true;
            this.lblCMoney.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblCMoney.Location = new System.Drawing.Point(23, 13);
            this.lblCMoney.Name = "lblCMoney";
            this.lblCMoney.Size = new System.Drawing.Size(110, 16);
            this.lblCMoney.TabIndex = 19;
            this.lblCMoney.Text = "投资总金额：";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(3, 150);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(555, 443);
            this.pictureBox1.TabIndex = 29;
            this.pictureBox1.TabStop = false;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label5.Location = new System.Drawing.Point(36, 131);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(85, 16);
            this.label5.TabIndex = 33;
            this.label5.Text = "账户余额:";
            // 
            // lblRemain
            // 
            this.lblRemain.AutoSize = true;
            this.lblRemain.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblRemain.Location = new System.Drawing.Point(127, 131);
            this.lblRemain.Name = "lblRemain";
            this.lblRemain.Size = new System.Drawing.Size(42, 16);
            this.lblRemain.TabIndex = 34;
            this.lblRemain.Text = "余额";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label6.Location = new System.Drawing.Point(306, 131);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(145, 16);
            this.label6.TabIndex = 35;
            this.label6.Text = "初始金额：10万元";
            // 
            // frmTable
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1163, 601);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.label1);
            this.Name = "frmTable";
            this.Text = "Table";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmTable_FormClosing);
            this.Load += new System.EventHandler(this.frmTable_Load);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grpStatisticTable)).EndInit();
            this.mmuStatistic.ResumeLayout(false);
            this.mmuStatistic.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ToolStripMenuItem mmuChart;
        private System.Windows.Forms.ToolStripMenuItem mmuExport;
        private System.Windows.Forms.ToolStripMenuItem mmuEmpty;
        private System.Windows.Forms.ToolStripMenuItem mmuSave;
        private System.Windows.Forms.MenuStrip mmuStatistic;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtWholeInvest;
        private System.Windows.Forms.Label lblCMoney;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtRe;
        private System.Windows.Forms.Label lblCMoney2;
        private System.Windows.Forms.Button btnC2;
        private System.Windows.Forms.Button btnC1;
        private System.Windows.Forms.Button btnC3;
        private System.Windows.Forms.DataGridView grpStatisticTable;
        private System.Windows.Forms.DataGridViewTextBoxColumn Other;
        private System.Windows.Forms.DataGridViewTextBoxColumn Num;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnName;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnMoney;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnType;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnTime;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.TextBox txtC3;
        private System.Windows.Forms.Label lblCInterst;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label lblRemain;
        private System.Windows.Forms.Label label5;
    }
}