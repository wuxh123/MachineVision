namespace BackGroundCheckHalconLibrary.UI
{
    partial class BackGroundFrm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(BackGroundFrm));
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.m_CtrlHStatusLabelCtrl = new System.Windows.Forms.Label();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.tSB_run_one = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.tSB_read_image = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.tSB_ChongXinShuaXinDingWeiDian = new System.Windows.Forms.ToolStripButton();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.numericUpDown_DilationRadius = new System.Windows.Forms.NumericUpDown();
            this.numericUpDown_MaxGray = new System.Windows.Forms.NumericUpDown();
            this.numericUpDown_MinGray = new System.Windows.Forms.NumericUpDown();
            this.bnt_CoverUpRegion = new System.Windows.Forms.Button();
            this.bnt_coverUpParameter = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.numericUpDown_txt_Min = new System.Windows.Forms.NumericUpDown();
            this.numericUpDown_txt_Max = new System.Windows.Forms.NumericUpDown();
            this.numericUpDown_Offset = new System.Windows.Forms.NumericUpDown();
            this.but_QueDingCanShu = new System.Windows.Forms.Button();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.com_Features = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.LightDark = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.halconWinControl_ROI1 = new HalControl.HalconWinControl_ROI();
            this.tableLayoutPanel1.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_DilationRadius)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_MaxGray)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_MinGray)).BeginInit();
            this.tabPage3.SuspendLayout();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_txt_Min)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_txt_Max)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_Offset)).BeginInit();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 3;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 48.13028F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 51.86972F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 145F));
            this.tableLayoutPanel1.Controls.Add(this.m_CtrlHStatusLabelCtrl, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.toolStrip1, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this.tabControl1, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.halconWinControl_ROI1, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 95.63795F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 4.36205F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1451, 644);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // m_CtrlHStatusLabelCtrl
            // 
            this.m_CtrlHStatusLabelCtrl.AutoSize = true;
            this.m_CtrlHStatusLabelCtrl.Location = new System.Drawing.Point(3, 615);
            this.m_CtrlHStatusLabelCtrl.Name = "m_CtrlHStatusLabelCtrl";
            this.m_CtrlHStatusLabelCtrl.Size = new System.Drawing.Size(63, 15);
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
            this.toolStripSeparator3,
            this.tSB_ChongXinShuaXinDingWeiDian});
            this.toolStrip1.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.VerticalStackWithOverflow;
            this.toolStrip1.Location = new System.Drawing.Point(1305, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(146, 104);
            this.toolStrip1.TabIndex = 3;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // tSB_run_one
            // 
            this.tSB_run_one.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tSB_run_one.Image = ((System.Drawing.Image)(resources.GetObject("tSB_run_one.Image")));
            this.tSB_run_one.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tSB_run_one.Name = "tSB_run_one";
            this.tSB_run_one.Size = new System.Drawing.Size(144, 24);
            this.tSB_run_one.Text = "运行";
            this.tSB_run_one.Click += new System.EventHandler(this.tSB_run_one_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(144, 6);
            // 
            // tSB_read_image
            // 
            this.tSB_read_image.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tSB_read_image.Image = ((System.Drawing.Image)(resources.GetObject("tSB_read_image.Image")));
            this.tSB_read_image.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tSB_read_image.Name = "tSB_read_image";
            this.tSB_read_image.Size = new System.Drawing.Size(144, 24);
            this.tSB_read_image.Text = "取一张图片";
            this.tSB_read_image.Click += new System.EventHandler(this.tSB_read_image_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(144, 6);
            // 
            // tSB_ChongXinShuaXinDingWeiDian
            // 
            this.tSB_ChongXinShuaXinDingWeiDian.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tSB_ChongXinShuaXinDingWeiDian.Image = ((System.Drawing.Image)(resources.GetObject("tSB_ChongXinShuaXinDingWeiDian.Image")));
            this.tSB_ChongXinShuaXinDingWeiDian.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tSB_ChongXinShuaXinDingWeiDian.Name = "tSB_ChongXinShuaXinDingWeiDian";
            this.tSB_ChongXinShuaXinDingWeiDian.Size = new System.Drawing.Size(144, 24);
            this.tSB_ChongXinShuaXinDingWeiDian.Text = "重新刷新定位点";
            this.tSB_ChongXinShuaXinDingWeiDian.Click += new System.EventHandler(this.tSB_ChongXinShuaXinDingWeiDian_Click);
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(631, 3);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(671, 609);
            this.tabControl1.TabIndex = 2;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.groupBox2);
            this.tabPage2.Location = new System.Drawing.Point(4, 25);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Size = new System.Drawing.Size(663, 580);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "掩盖参数";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.numericUpDown_DilationRadius);
            this.groupBox2.Controls.Add(this.numericUpDown_MaxGray);
            this.groupBox2.Controls.Add(this.numericUpDown_MinGray);
            this.groupBox2.Controls.Add(this.bnt_CoverUpRegion);
            this.groupBox2.Controls.Add(this.bnt_coverUpParameter);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox2.Location = new System.Drawing.Point(0, 0);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(663, 379);
            this.groupBox2.TabIndex = 0;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "掩盖参数";
            // 
            // numericUpDown_DilationRadius
            // 
            this.numericUpDown_DilationRadius.Location = new System.Drawing.Point(151, 111);
            this.numericUpDown_DilationRadius.Name = "numericUpDown_DilationRadius";
            this.numericUpDown_DilationRadius.Size = new System.Drawing.Size(164, 25);
            this.numericUpDown_DilationRadius.TabIndex = 10;
            // 
            // numericUpDown_MaxGray
            // 
            this.numericUpDown_MaxGray.Location = new System.Drawing.Point(151, 67);
            this.numericUpDown_MaxGray.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.numericUpDown_MaxGray.Name = "numericUpDown_MaxGray";
            this.numericUpDown_MaxGray.Size = new System.Drawing.Size(164, 25);
            this.numericUpDown_MaxGray.TabIndex = 9;
            // 
            // numericUpDown_MinGray
            // 
            this.numericUpDown_MinGray.Location = new System.Drawing.Point(151, 18);
            this.numericUpDown_MinGray.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.numericUpDown_MinGray.Name = "numericUpDown_MinGray";
            this.numericUpDown_MinGray.Size = new System.Drawing.Size(164, 25);
            this.numericUpDown_MinGray.TabIndex = 8;
            // 
            // bnt_CoverUpRegion
            // 
            this.bnt_CoverUpRegion.Location = new System.Drawing.Point(151, 171);
            this.bnt_CoverUpRegion.Name = "bnt_CoverUpRegion";
            this.bnt_CoverUpRegion.Size = new System.Drawing.Size(164, 47);
            this.bnt_CoverUpRegion.TabIndex = 7;
            this.bnt_CoverUpRegion.Text = "重建遮掩区域";
            this.bnt_CoverUpRegion.UseVisualStyleBackColor = true;
            this.bnt_CoverUpRegion.Click += new System.EventHandler(this.bnt_CoverUpRegion_Click);
            // 
            // bnt_coverUpParameter
            // 
            this.bnt_coverUpParameter.Location = new System.Drawing.Point(370, 18);
            this.bnt_coverUpParameter.Name = "bnt_coverUpParameter";
            this.bnt_coverUpParameter.Size = new System.Drawing.Size(132, 125);
            this.bnt_coverUpParameter.TabIndex = 6;
            this.bnt_coverUpParameter.Text = "确定";
            this.bnt_coverUpParameter.UseVisualStyleBackColor = true;
            this.bnt_coverUpParameter.Click += new System.EventHandler(this.bnt_coverUpParameter_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(3, 121);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(105, 15);
            this.label4.TabIndex = 4;
            this.label4.Text = "膨胀掩盖因子:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(3, 69);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(97, 15);
            this.label3.TabIndex = 2;
            this.label3.Text = "最大灰度值：";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(3, 21);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(97, 15);
            this.label2.TabIndex = 0;
            this.label2.Text = "最小灰度值：";
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.groupBox3);
            this.tabPage3.Location = new System.Drawing.Point(4, 25);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Size = new System.Drawing.Size(663, 580);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "图片对比参数";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.numericUpDown_txt_Min);
            this.groupBox3.Controls.Add(this.numericUpDown_txt_Max);
            this.groupBox3.Controls.Add(this.numericUpDown_Offset);
            this.groupBox3.Controls.Add(this.but_QueDingCanShu);
            this.groupBox3.Controls.Add(this.label9);
            this.groupBox3.Controls.Add(this.label8);
            this.groupBox3.Controls.Add(this.com_Features);
            this.groupBox3.Controls.Add(this.label7);
            this.groupBox3.Controls.Add(this.LightDark);
            this.groupBox3.Controls.Add(this.label6);
            this.groupBox3.Controls.Add(this.label5);
            this.groupBox3.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox3.Location = new System.Drawing.Point(0, 0);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(663, 408);
            this.groupBox3.TabIndex = 0;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "图片对比参数";
            // 
            // numericUpDown_txt_Min
            // 
            this.numericUpDown_txt_Min.Location = new System.Drawing.Point(179, 221);
            this.numericUpDown_txt_Min.Maximum = new decimal(new int[] {
            -1486618624,
            232830643,
            0,
            0});
            this.numericUpDown_txt_Min.Name = "numericUpDown_txt_Min";
            this.numericUpDown_txt_Min.Size = new System.Drawing.Size(152, 25);
            this.numericUpDown_txt_Min.TabIndex = 17;
            // 
            // numericUpDown_txt_Max
            // 
            this.numericUpDown_txt_Max.Location = new System.Drawing.Point(179, 175);
            this.numericUpDown_txt_Max.Maximum = new decimal(new int[] {
            1316134912,
            2328,
            0,
            0});
            this.numericUpDown_txt_Max.Name = "numericUpDown_txt_Max";
            this.numericUpDown_txt_Max.Size = new System.Drawing.Size(152, 25);
            this.numericUpDown_txt_Max.TabIndex = 16;
            // 
            // numericUpDown_Offset
            // 
            this.numericUpDown_Offset.Location = new System.Drawing.Point(179, 43);
            this.numericUpDown_Offset.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.numericUpDown_Offset.Name = "numericUpDown_Offset";
            this.numericUpDown_Offset.Size = new System.Drawing.Size(152, 25);
            this.numericUpDown_Offset.TabIndex = 15;
            // 
            // but_QueDingCanShu
            // 
            this.but_QueDingCanShu.Location = new System.Drawing.Point(376, 43);
            this.but_QueDingCanShu.Name = "but_QueDingCanShu";
            this.but_QueDingCanShu.Size = new System.Drawing.Size(171, 202);
            this.but_QueDingCanShu.TabIndex = 14;
            this.but_QueDingCanShu.Text = "确定";
            this.but_QueDingCanShu.UseVisualStyleBackColor = true;
            this.but_QueDingCanShu.Click += new System.EventHandler(this.but_Min_Click);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(6, 223);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(142, 15);
            this.label9.TabIndex = 10;
            this.label9.Text = "污点特征的最小值：";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(6, 177);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(142, 15);
            this.label8.TabIndex = 9;
            this.label8.Text = "污点特征的最大值：";
            // 
            // com_Features
            // 
            this.com_Features.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.com_Features.FormattingEnabled = true;
            this.com_Features.Items.AddRange(new object[] {
            "area"});
            this.com_Features.Location = new System.Drawing.Point(178, 124);
            this.com_Features.Name = "com_Features";
            this.com_Features.Size = new System.Drawing.Size(152, 23);
            this.com_Features.TabIndex = 7;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(6, 127);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(97, 15);
            this.label7.TabIndex = 6;
            this.label7.Text = "污点的特征：";
            // 
            // LightDark
            // 
            this.LightDark.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.LightDark.FormattingEnabled = true;
            this.LightDark.Items.AddRange(new object[] {
            "light",
            "dark",
            "equal",
            "not_equal"});
            this.LightDark.Location = new System.Drawing.Point(179, 84);
            this.LightDark.Name = "LightDark";
            this.LightDark.Size = new System.Drawing.Size(152, 23);
            this.LightDark.TabIndex = 4;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(6, 87);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(97, 15);
            this.label6.TabIndex = 1;
            this.label6.Text = "查找的极性：";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(6, 46);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(90, 15);
            this.label5.TabIndex = 0;
            this.label5.Text = "对比灰度值:";
            // 
            // halconWinControl_ROI1
            // 
            this.halconWinControl_ROI1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.halconWinControl_ROI1.HalconWindow1 = null;
            this.halconWinControl_ROI1.Ho_Image = null;
            this.halconWinControl_ROI1.HWindowControl = null;
            this.halconWinControl_ROI1.Location = new System.Drawing.Point(3, 3);
            this.halconWinControl_ROI1.Name = "halconWinControl_ROI1";
            this.halconWinControl_ROI1.Size = new System.Drawing.Size(622, 609);
            this.halconWinControl_ROI1.TabIndex = 5;
            // 
            // BackGroundFrm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1451, 644);
            this.Controls.Add(this.tableLayoutPanel1);
            this.MinimizeBox = false;
            this.Name = "BackGroundFrm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "背景检测";
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
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_DilationRadius)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_MaxGray)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_MinGray)).EndInit();
            this.tabPage3.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_txt_Min)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_txt_Max)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_Offset)).EndInit();
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
        private HalControl.HalconWinControl_ROI halconWinControl_ROI1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button bnt_coverUpParameter;
        private System.Windows.Forms.Button bnt_CoverUpRegion;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox LightDark;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripButton tSB_ChongXinShuaXinDingWeiDian;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox com_Features;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Button but_QueDingCanShu;
        private System.Windows.Forms.NumericUpDown numericUpDown_Offset;
        private System.Windows.Forms.NumericUpDown numericUpDown_txt_Max;
        private System.Windows.Forms.NumericUpDown numericUpDown_txt_Min;
        private System.Windows.Forms.NumericUpDown numericUpDown_MinGray;
        private System.Windows.Forms.NumericUpDown numericUpDown_MaxGray;
        private System.Windows.Forms.NumericUpDown numericUpDown_DilationRadius;
    }
}