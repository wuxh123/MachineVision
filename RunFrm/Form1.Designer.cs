namespace RunFrm
{
    partial class Form1
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

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripButton_loadJob = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripButton_startTest = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripButton_danBuChuFaDiYiGeXiangJi = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripButton_danBuChuFaDiErGeXiangJi = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripButton_TcpIp = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripButton1 = new System.Windows.Forms.ToolStripButton();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.halconWinControl_11 = new HalControl.HalconWinControl_1();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.listBox2 = new System.Windows.Forms.ListBox();
            this.halconWinControl_12 = new HalControl.HalconWinControl_1();
            this.toolStrip1.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.tableLayoutPanel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripButton_loadJob,
            this.toolStripSeparator1,
            this.toolStripButton_startTest,
            this.toolStripSeparator2,
            this.toolStripButton_danBuChuFaDiYiGeXiangJi,
            this.toolStripSeparator3,
            this.toolStripButton_danBuChuFaDiErGeXiangJi,
            this.toolStripSeparator4,
            this.toolStripButton_TcpIp,
            this.toolStripSeparator5,
            this.toolStripButton1});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(1270, 25);
            this.toolStrip1.TabIndex = 0;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // toolStripButton_loadJob
            // 
            this.toolStripButton_loadJob.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripButton_loadJob.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton_loadJob.Image")));
            this.toolStripButton_loadJob.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton_loadJob.Name = "toolStripButton_loadJob";
            this.toolStripButton_loadJob.Size = new System.Drawing.Size(55, 22);
            this.toolStripButton_loadJob.Text = "加载job";
            this.toolStripButton_loadJob.Click += new System.EventHandler(this.toolStripButton_loadJob_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // toolStripButton_startTest
            // 
            this.toolStripButton_startTest.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripButton_startTest.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton_startTest.Image")));
            this.toolStripButton_startTest.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton_startTest.Name = "toolStripButton_startTest";
            this.toolStripButton_startTest.Size = new System.Drawing.Size(60, 22);
            this.toolStripButton_startTest.Text = "开始检测";
            this.toolStripButton_startTest.Click += new System.EventHandler(this.toolStripButton_startTest_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 25);
            // 
            // toolStripButton_danBuChuFaDiYiGeXiangJi
            // 
            this.toolStripButton_danBuChuFaDiYiGeXiangJi.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripButton_danBuChuFaDiYiGeXiangJi.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton_danBuChuFaDiYiGeXiangJi.Image")));
            this.toolStripButton_danBuChuFaDiYiGeXiangJi.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton_danBuChuFaDiYiGeXiangJi.Name = "toolStripButton_danBuChuFaDiYiGeXiangJi";
            this.toolStripButton_danBuChuFaDiYiGeXiangJi.Size = new System.Drawing.Size(144, 22);
            this.toolStripButton_danBuChuFaDiYiGeXiangJi.Text = "手动单步触发第一个相机";
            this.toolStripButton_danBuChuFaDiYiGeXiangJi.Click += new System.EventHandler(this.toolStripButton_shouDongDanBuChuFa_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(6, 25);
            // 
            // toolStripButton_danBuChuFaDiErGeXiangJi
            // 
            this.toolStripButton_danBuChuFaDiErGeXiangJi.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripButton_danBuChuFaDiErGeXiangJi.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton_danBuChuFaDiErGeXiangJi.Image")));
            this.toolStripButton_danBuChuFaDiErGeXiangJi.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton_danBuChuFaDiErGeXiangJi.Name = "toolStripButton_danBuChuFaDiErGeXiangJi";
            this.toolStripButton_danBuChuFaDiErGeXiangJi.Size = new System.Drawing.Size(144, 22);
            this.toolStripButton_danBuChuFaDiErGeXiangJi.Text = "手动单步触发第二个相机";
            this.toolStripButton_danBuChuFaDiErGeXiangJi.Click += new System.EventHandler(this.toolStripButton_danBuChuFaDiErGeXiangJi_Click);
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(6, 25);
            // 
            // toolStripButton_TcpIp
            // 
            this.toolStripButton_TcpIp.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripButton_TcpIp.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton_TcpIp.Image")));
            this.toolStripButton_TcpIp.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton_TcpIp.Name = "toolStripButton_TcpIp";
            this.toolStripButton_TcpIp.Size = new System.Drawing.Size(69, 22);
            this.toolStripButton_TcpIp.Text = "使用TCPIP";
            this.toolStripButton_TcpIp.Click += new System.EventHandler(this.toolStripButton_TcpIp_Click);
            // 
            // toolStripSeparator5
            // 
            this.toolStripSeparator5.Name = "toolStripSeparator5";
            this.toolStripSeparator5.Size = new System.Drawing.Size(6, 25);
            // 
            // toolStripButton1
            // 
            this.toolStripButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripButton1.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton1.Image")));
            this.toolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton1.Name = "toolStripButton1";
            this.toolStripButton1.Size = new System.Drawing.Size(60, 22);
            this.toolStripButton1.Text = "使用串口";
            this.toolStripButton1.Click += new System.EventHandler(this.toolStripButton1_Click);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel2, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel3, 1, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 25);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1270, 666);
            this.tableLayoutPanel1.TabIndex = 1;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 1;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Controls.Add(this.listBox1, 0, 1);
            this.tableLayoutPanel2.Controls.Add(this.halconWinControl_11, 0, 0);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 2;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 80F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(629, 660);
            this.tableLayoutPanel2.TabIndex = 0;
            // 
            // listBox1
            // 
            this.listBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listBox1.FormattingEnabled = true;
            this.listBox1.ItemHeight = 12;
            this.listBox1.Location = new System.Drawing.Point(3, 531);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(623, 126);
            this.listBox1.TabIndex = 0;
            // 
            // halconWinControl_11
            // 
            this.halconWinControl_11.Dock = System.Windows.Forms.DockStyle.Fill;
            this.halconWinControl_11.HalconWindow1 = null;
            this.halconWinControl_11.Ho_Image = null;
            this.halconWinControl_11.HWindowControl = null;
            this.halconWinControl_11.Location = new System.Drawing.Point(2, 2);
            this.halconWinControl_11.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.halconWinControl_11.Name = "halconWinControl_11";
            this.halconWinControl_11.Size = new System.Drawing.Size(625, 524);
            this.halconWinControl_11.TabIndex = 1;
            // 
            // tableLayoutPanel3
            // 
            this.tableLayoutPanel3.ColumnCount = 1;
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel3.Controls.Add(this.listBox2, 0, 1);
            this.tableLayoutPanel3.Controls.Add(this.halconWinControl_12, 0, 0);
            this.tableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel3.Location = new System.Drawing.Point(638, 3);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RowCount = 2;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 80F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel3.Size = new System.Drawing.Size(629, 660);
            this.tableLayoutPanel3.TabIndex = 1;
            // 
            // listBox2
            // 
            this.listBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listBox2.FormattingEnabled = true;
            this.listBox2.ItemHeight = 12;
            this.listBox2.Location = new System.Drawing.Point(3, 531);
            this.listBox2.Name = "listBox2";
            this.listBox2.Size = new System.Drawing.Size(623, 126);
            this.listBox2.TabIndex = 0;
            // 
            // halconWinControl_12
            // 
            this.halconWinControl_12.Dock = System.Windows.Forms.DockStyle.Fill;
            this.halconWinControl_12.HalconWindow1 = null;
            this.halconWinControl_12.Ho_Image = null;
            this.halconWinControl_12.HWindowControl = null;
            this.halconWinControl_12.Location = new System.Drawing.Point(2, 2);
            this.halconWinControl_12.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.halconWinControl_12.Name = "halconWinControl_12";
            this.halconWinControl_12.Size = new System.Drawing.Size(625, 524);
            this.halconWinControl_12.TabIndex = 1;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1270, 691);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.toolStrip1);
            this.Name = "Form1";
            this.Text = "运行的窗体";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel3.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton toolStripButton_loadJob;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton toolStripButton_startTest;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripButton toolStripButton_danBuChuFaDiYiGeXiangJi;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
        private System.Windows.Forms.ListBox listBox1;
        private HalControl.HalconWinControl_1 halconWinControl_11;
        private System.Windows.Forms.ListBox listBox2;
        private HalControl.HalconWinControl_1 halconWinControl_12;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripButton toolStripButton_danBuChuFaDiErGeXiangJi;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.ToolStripButton toolStripButton_TcpIp;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator5;
        private System.Windows.Forms.ToolStripButton toolStripButton1;
    }
}

