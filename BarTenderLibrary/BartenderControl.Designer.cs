namespace BarTenderLibrary
{
    partial class BartenderControl
    {
        /// <summary> 
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region 组件设计器生成的代码

        /// <summary> 
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(BartenderControl));
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.label1 = new System.Windows.Forms.Label();
            this.PathFileName = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.lab_BantenderPrintNumber = new System.Windows.Forms.Label();
            this.trackBar_BartenderPrintNumber = new System.Windows.Forms.TrackBar();
            this.tSB_save = new System.Windows.Forms.ToolStripButton();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.tSB_SetPathFileName = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.tSB_TriggerPrintAgain = new System.Windows.Forms.ToolStripButton();
            this.tableLayoutPanel1.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar_BartenderPrintNumber)).BeginInit();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Inset;
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 28.26421F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 71.73579F));
            this.tableLayoutPanel1.Controls.Add(this.label1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.PathFileName, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.label2, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel2, 1, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 27);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 97F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(651, 176);
            this.tableLayoutPanel1.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label1.Location = new System.Drawing.Point(5, 2);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(176, 73);
            this.label1.TabIndex = 0;
            this.label1.Text = "bartender打印的文件";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // PathFileName
            // 
            this.PathFileName.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PathFileName.Location = new System.Drawing.Point(189, 2);
            this.PathFileName.Name = "PathFileName";
            this.PathFileName.Size = new System.Drawing.Size(457, 73);
            this.PathFileName.TabIndex = 1;
            this.PathFileName.Text = "filename";
            this.PathFileName.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label2
            // 
            this.label2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label2.Location = new System.Drawing.Point(5, 77);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(176, 97);
            this.label2.TabIndex = 2;
            this.label2.Text = "打印的份数";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 1;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.Controls.Add(this.lab_BantenderPrintNumber, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.trackBar_BartenderPrintNumber, 0, 1);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(189, 80);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 2;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(457, 91);
            this.tableLayoutPanel2.TabIndex = 3;
            // 
            // lab_BantenderPrintNumber
            // 
            this.lab_BantenderPrintNumber.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lab_BantenderPrintNumber.Location = new System.Drawing.Point(3, 0);
            this.lab_BantenderPrintNumber.Name = "lab_BantenderPrintNumber";
            this.lab_BantenderPrintNumber.Size = new System.Drawing.Size(451, 45);
            this.lab_BantenderPrintNumber.TabIndex = 0;
            this.lab_BantenderPrintNumber.Text = "0";
            this.lab_BantenderPrintNumber.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // trackBar_BartenderPrintNumber
            // 
            this.trackBar_BartenderPrintNumber.Dock = System.Windows.Forms.DockStyle.Fill;
            this.trackBar_BartenderPrintNumber.Location = new System.Drawing.Point(3, 48);
            this.trackBar_BartenderPrintNumber.Maximum = 100;
            this.trackBar_BartenderPrintNumber.Name = "trackBar_BartenderPrintNumber";
            this.trackBar_BartenderPrintNumber.Size = new System.Drawing.Size(451, 40);
            this.trackBar_BartenderPrintNumber.TabIndex = 1;
            this.trackBar_BartenderPrintNumber.ValueChanged += new System.EventHandler(this.trackBar1_ValueChanged);
            // 
            // tSB_save
            // 
            this.tSB_save.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tSB_save.Image = ((System.Drawing.Image)(resources.GetObject("tSB_save.Image")));
            this.tSB_save.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tSB_save.Name = "tSB_save";
            this.tSB_save.Size = new System.Drawing.Size(73, 24);
            this.tSB_save.Text = "保存数据";
            this.tSB_save.Click += new System.EventHandler(this.toolStripButton1_Click);
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tSB_save,
            this.toolStripSeparator1,
            this.tSB_SetPathFileName,
            this.toolStripSeparator2,
            this.tSB_TriggerPrintAgain});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(651, 27);
            this.toolStrip1.TabIndex = 1;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 27);
            // 
            // tSB_SetPathFileName
            // 
            this.tSB_SetPathFileName.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tSB_SetPathFileName.Image = ((System.Drawing.Image)(resources.GetObject("tSB_SetPathFileName.Image")));
            this.tSB_SetPathFileName.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tSB_SetPathFileName.Name = "tSB_SetPathFileName";
            this.tSB_SetPathFileName.Size = new System.Drawing.Size(118, 24);
            this.tSB_SetPathFileName.Text = "修改打印的文件";
            this.tSB_SetPathFileName.Click += new System.EventHandler(this.toolStripButton2_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 27);
            // 
            // tSB_TriggerPrintAgain
            // 
            this.tSB_TriggerPrintAgain.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tSB_TriggerPrintAgain.Image = ((System.Drawing.Image)(resources.GetObject("tSB_TriggerPrintAgain.Image")));
            this.tSB_TriggerPrintAgain.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tSB_TriggerPrintAgain.Name = "tSB_TriggerPrintAgain";
            this.tSB_TriggerPrintAgain.Size = new System.Drawing.Size(103, 24);
            this.tSB_TriggerPrintAgain.Text = "单步触发打印";
            this.tSB_TriggerPrintAgain.Click += new System.EventHandler(this.toolStripButton3_Click);
            // 
            // BartenderControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.toolStrip1);
            this.Name = "BartenderControl";
            this.Size = new System.Drawing.Size(651, 203);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar_BartenderPrintNumber)).EndInit();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.ToolStripButton tSB_save;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton tSB_SetPathFileName;
        private System.Windows.Forms.Label PathFileName;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripButton tSB_TriggerPrintAgain;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.Label lab_BantenderPrintNumber;
        private System.Windows.Forms.TrackBar trackBar_BartenderPrintNumber;
    }
}
