namespace LineLibrary.UI
{
    partial class LineFrm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LineFrm));
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.m_CtrlHStatusLabelCtrl = new System.Windows.Forms.Label();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.tSB_run_one = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.tSB_read_image = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.numericUpDown_Hv_Threshold = new System.Windows.Forms.NumericUpDown();
            this.numericUpDown_Hv_ActiveNum = new System.Windows.Forms.NumericUpDown();
            this.numericUpDown_Hv_DetectWidth = new System.Windows.Forms.NumericUpDown();
            this.numericUpDown_Hv_DetectHeight = new System.Windows.Forms.NumericUpDown();
            this.numericUpDown_Hv_Elements = new System.Windows.Forms.NumericUpDown();
            this.Hv_Select = new System.Windows.Forms.ComboBox();
            this.Hv_Transition = new System.Windows.Forms.ComboBox();
            this.Hv_Sigma = new System.Windows.Forms.ComboBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.btn_que_ding_draw_spoke_can_shu = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.halconWinControl_ROI1 = new HalControl.HalconWinControl_ROI();
            this.tableLayoutPanel1.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_Hv_Threshold)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_Hv_ActiveNum)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_Hv_DetectWidth)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_Hv_DetectHeight)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_Hv_Elements)).BeginInit();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 3;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 48.13028F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 51.86972F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 106F));
            this.tableLayoutPanel1.Controls.Add(this.m_CtrlHStatusLabelCtrl, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.toolStrip1, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this.tabControl1, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.halconWinControl_ROI1, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 95.63795F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 4.36205F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1028, 599);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // m_CtrlHStatusLabelCtrl
            // 
            this.m_CtrlHStatusLabelCtrl.AutoSize = true;
            this.m_CtrlHStatusLabelCtrl.Location = new System.Drawing.Point(2, 572);
            this.m_CtrlHStatusLabelCtrl.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.m_CtrlHStatusLabelCtrl.Name = "m_CtrlHStatusLabelCtrl";
            this.m_CtrlHStatusLabelCtrl.Size = new System.Drawing.Size(47, 12);
            this.m_CtrlHStatusLabelCtrl.TabIndex = 4;
            this.m_CtrlHStatusLabelCtrl.Text = "message";
            // 
            // toolStrip1
            // 
            this.toolStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tSB_run_one,
            this.toolStripSeparator1,
            this.tSB_read_image,
            this.toolStripSeparator3});
            this.toolStrip1.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.VerticalStackWithOverflow;
            this.toolStrip1.Location = new System.Drawing.Point(921, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(107, 90);
            this.toolStrip1.TabIndex = 3;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // tSB_run_one
            // 
            this.tSB_run_one.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tSB_run_one.Image = ((System.Drawing.Image)(resources.GetObject("tSB_run_one.Image")));
            this.tSB_run_one.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tSB_run_one.Name = "tSB_run_one";
            this.tSB_run_one.Size = new System.Drawing.Size(105, 21);
            this.tSB_run_one.Text = "运行";
            this.tSB_run_one.Click += new System.EventHandler(this.tSB_run_one_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(105, 6);
            // 
            // tSB_read_image
            // 
            this.tSB_read_image.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tSB_read_image.Image = ((System.Drawing.Image)(resources.GetObject("tSB_read_image.Image")));
            this.tSB_read_image.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tSB_read_image.Name = "tSB_read_image";
            this.tSB_read_image.Size = new System.Drawing.Size(105, 21);
            this.tSB_read_image.Text = "取一张图片";
            this.tSB_read_image.Click += new System.EventHandler(this.tSB_read_image_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(105, 6);
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(445, 2);
            this.tabControl1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(474, 568);
            this.tabControl1.TabIndex = 2;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.groupBox2);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Size = new System.Drawing.Size(466, 542);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "卡尺参数";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.numericUpDown_Hv_Threshold);
            this.groupBox2.Controls.Add(this.numericUpDown_Hv_ActiveNum);
            this.groupBox2.Controls.Add(this.numericUpDown_Hv_DetectWidth);
            this.groupBox2.Controls.Add(this.numericUpDown_Hv_DetectHeight);
            this.groupBox2.Controls.Add(this.numericUpDown_Hv_Elements);
            this.groupBox2.Controls.Add(this.Hv_Select);
            this.groupBox2.Controls.Add(this.Hv_Transition);
            this.groupBox2.Controls.Add(this.Hv_Sigma);
            this.groupBox2.Controls.Add(this.label9);
            this.groupBox2.Controls.Add(this.label8);
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.btn_que_ding_draw_spoke_can_shu);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox2.Location = new System.Drawing.Point(0, 0);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.groupBox2.Size = new System.Drawing.Size(466, 474);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "设置卡尺参数";
            // 
            // numericUpDown_Hv_Threshold
            // 
            this.numericUpDown_Hv_Threshold.Location = new System.Drawing.Point(106, 197);
            this.numericUpDown_Hv_Threshold.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.numericUpDown_Hv_Threshold.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.numericUpDown_Hv_Threshold.Name = "numericUpDown_Hv_Threshold";
            this.numericUpDown_Hv_Threshold.Size = new System.Drawing.Size(151, 21);
            this.numericUpDown_Hv_Threshold.TabIndex = 40;
            // 
            // numericUpDown_Hv_ActiveNum
            // 
            this.numericUpDown_Hv_ActiveNum.Location = new System.Drawing.Point(106, 126);
            this.numericUpDown_Hv_ActiveNum.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.numericUpDown_Hv_ActiveNum.Maximum = new decimal(new int[] {
            10000000,
            0,
            0,
            0});
            this.numericUpDown_Hv_ActiveNum.Name = "numericUpDown_Hv_ActiveNum";
            this.numericUpDown_Hv_ActiveNum.Size = new System.Drawing.Size(147, 21);
            this.numericUpDown_Hv_ActiveNum.TabIndex = 39;
            this.numericUpDown_Hv_ActiveNum.Value = new decimal(new int[] {
            2,
            0,
            0,
            0});
            // 
            // numericUpDown_Hv_DetectWidth
            // 
            this.numericUpDown_Hv_DetectWidth.Location = new System.Drawing.Point(106, 83);
            this.numericUpDown_Hv_DetectWidth.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.numericUpDown_Hv_DetectWidth.Maximum = new decimal(new int[] {
            10000000,
            0,
            0,
            0});
            this.numericUpDown_Hv_DetectWidth.Name = "numericUpDown_Hv_DetectWidth";
            this.numericUpDown_Hv_DetectWidth.Size = new System.Drawing.Size(147, 21);
            this.numericUpDown_Hv_DetectWidth.TabIndex = 38;
            // 
            // numericUpDown_Hv_DetectHeight
            // 
            this.numericUpDown_Hv_DetectHeight.Location = new System.Drawing.Point(106, 49);
            this.numericUpDown_Hv_DetectHeight.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.numericUpDown_Hv_DetectHeight.Maximum = new decimal(new int[] {
            10000000,
            0,
            0,
            0});
            this.numericUpDown_Hv_DetectHeight.Name = "numericUpDown_Hv_DetectHeight";
            this.numericUpDown_Hv_DetectHeight.Size = new System.Drawing.Size(147, 21);
            this.numericUpDown_Hv_DetectHeight.TabIndex = 37;
            this.numericUpDown_Hv_DetectHeight.Value = new decimal(new int[] {
            2,
            0,
            0,
            0});
            // 
            // numericUpDown_Hv_Elements
            // 
            this.numericUpDown_Hv_Elements.Location = new System.Drawing.Point(106, 15);
            this.numericUpDown_Hv_Elements.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.numericUpDown_Hv_Elements.Maximum = new decimal(new int[] {
            100000000,
            0,
            0,
            0});
            this.numericUpDown_Hv_Elements.Name = "numericUpDown_Hv_Elements";
            this.numericUpDown_Hv_Elements.Size = new System.Drawing.Size(147, 21);
            this.numericUpDown_Hv_Elements.TabIndex = 36;
            this.numericUpDown_Hv_Elements.Value = new decimal(new int[] {
            2,
            0,
            0,
            0});
            // 
            // Hv_Select
            // 
            this.Hv_Select.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.Hv_Select.FormattingEnabled = true;
            this.Hv_Select.Items.AddRange(new object[] {
            "first",
            "last",
            "max"});
            this.Hv_Select.Location = new System.Drawing.Point(106, 271);
            this.Hv_Select.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Hv_Select.Name = "Hv_Select";
            this.Hv_Select.Size = new System.Drawing.Size(152, 20);
            this.Hv_Select.TabIndex = 35;
            // 
            // Hv_Transition
            // 
            this.Hv_Transition.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.Hv_Transition.FormattingEnabled = true;
            this.Hv_Transition.Items.AddRange(new object[] {
            "positive",
            "negative",
            "all"});
            this.Hv_Transition.Location = new System.Drawing.Point(106, 238);
            this.Hv_Transition.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Hv_Transition.Name = "Hv_Transition";
            this.Hv_Transition.Size = new System.Drawing.Size(152, 20);
            this.Hv_Transition.TabIndex = 34;
            // 
            // Hv_Sigma
            // 
            this.Hv_Sigma.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.Hv_Sigma.FormattingEnabled = true;
            this.Hv_Sigma.Items.AddRange(new object[] {
            "4",
            "5",
            "6"});
            this.Hv_Sigma.Location = new System.Drawing.Point(106, 161);
            this.Hv_Sigma.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Hv_Sigma.Name = "Hv_Sigma";
            this.Hv_Sigma.Size = new System.Drawing.Size(152, 20);
            this.Hv_Sigma.TabIndex = 32;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(4, 271);
            this.label9.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(89, 12);
            this.label9.TabIndex = 30;
            this.label9.Text = "选择点的位置：";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(4, 238);
            this.label8.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(65, 12);
            this.label8.TabIndex = 29;
            this.label8.Text = "找点极性：";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(4, 198);
            this.label7.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(89, 12);
            this.label7.TabIndex = 28;
            this.label7.Text = "边缘幅度阈值：";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(4, 163);
            this.label6.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(89, 12);
            this.label6.TabIndex = 27;
            this.label6.Text = "高斯滤波因子：";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(4, 128);
            this.label5.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(77, 12);
            this.label5.TabIndex = 26;
            this.label5.Text = "最小有效点：";
            // 
            // btn_que_ding_draw_spoke_can_shu
            // 
            this.btn_que_ding_draw_spoke_can_shu.Location = new System.Drawing.Point(308, 18);
            this.btn_que_ding_draw_spoke_can_shu.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btn_que_ding_draw_spoke_can_shu.Name = "btn_que_ding_draw_spoke_can_shu";
            this.btn_que_ding_draw_spoke_can_shu.Size = new System.Drawing.Size(190, 86);
            this.btn_que_ding_draw_spoke_can_shu.TabIndex = 17;
            this.btn_que_ding_draw_spoke_can_shu.Text = "确定参数";
            this.btn_que_ding_draw_spoke_can_shu.UseVisualStyleBackColor = true;
            this.btn_que_ding_draw_spoke_can_shu.Click += new System.EventHandler(this.btn_que_ding_draw_spoke_can_shu_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(4, 86);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(59, 12);
            this.label4.TabIndex = 13;
            this.label4.Text = "卡尺的宽:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(4, 50);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(59, 12);
            this.label3.TabIndex = 12;
            this.label3.Text = "卡尺的高:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(4, 17);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(71, 12);
            this.label2.TabIndex = 11;
            this.label2.Text = "卡尺的个数:";
            // 
            // tabPage3
            // 
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Size = new System.Drawing.Size(510, 547);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "结果";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // halconWinControl_ROI1
            // 
            this.halconWinControl_ROI1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.halconWinControl_ROI1.HalconWindow1 = null;
            this.halconWinControl_ROI1.Ho_Image = null;
            this.halconWinControl_ROI1.HWindowControl = null;
            this.halconWinControl_ROI1.Location = new System.Drawing.Point(2, 2);
            this.halconWinControl_ROI1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.halconWinControl_ROI1.Name = "halconWinControl_ROI1";
            this.halconWinControl_ROI1.Size = new System.Drawing.Size(439, 568);
            this.halconWinControl_ROI1.TabIndex = 5;
            // 
            // LineFrm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1028, 599);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.MinimizeBox = false;
            this.Name = "LineFrm";
            this.Text = "拟合线";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.acquriefrm_FormClosing);
            this.Load += new System.EventHandler(this.ParentFrm_Load);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.tabControl1.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_Hv_Threshold)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_Hv_ActiveNum)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_Hv_DetectWidth)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_Hv_DetectHeight)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_Hv_Elements)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label m_CtrlHStatusLabelCtrl;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton tSB_run_one;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton tSB_read_image;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button btn_que_ding_draw_spoke_can_shu;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private HalControl.HalconWinControl_ROI halconWinControl_ROI1;
        private System.Windows.Forms.ComboBox Hv_Select;
        private System.Windows.Forms.ComboBox Hv_Transition;
        private System.Windows.Forms.ComboBox Hv_Sigma;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.NumericUpDown numericUpDown_Hv_Elements;
        private System.Windows.Forms.NumericUpDown numericUpDown_Hv_DetectHeight;
        private System.Windows.Forms.NumericUpDown numericUpDown_Hv_DetectWidth;
        private System.Windows.Forms.NumericUpDown numericUpDown_Hv_ActiveNum;
        private System.Windows.Forms.NumericUpDown numericUpDown_Hv_Threshold;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
    }
}