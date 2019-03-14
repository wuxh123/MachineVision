namespace OCVLibrary.UI
{
    partial class OCVFrm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(OCVFrm));
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.m_CtrlHStatusLabelCtrl = new System.Windows.Forms.Label();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.tSB_run_one = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.tSB_read_image = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.tSB_ShuaXinDingWeiDian = new System.Windows.Forms.ToolStripButton();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.hv_PatternNames = new System.Windows.Forms.TextBox();
            this._ocvTrainingQuality_sure = new System.Windows.Forms.Button();
            this.label8 = new System.Windows.Forms.Label();
            this._ocvTrainingQuality = new System.Windows.Forms.TextBox();
            this._trained = new System.Windows.Forms.CheckBox();
            this.bnt_cut_out_check_region = new System.Windows.Forms.Button();
            this.bnt_threshold_confrim = new System.Windows.Forms.Button();
            this.hv_Threshold = new System.Windows.Forms.TextBox();
            this.hv_AdaptGray = new System.Windows.Forms.ComboBox();
            this.hv_AdaptAngle = new System.Windows.Forms.ComboBox();
            this.hv_AdaptSize = new System.Windows.Forms.ComboBox();
            this.hv_AdaptPos = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.halconWinControl_ROI1 = new HalControl.HalconWinControl_ROI();
            this.tableLayoutPanel1.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 3;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 48.13028F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 51.86972F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 144F));
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
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1551, 744);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // m_CtrlHStatusLabelCtrl
            // 
            this.m_CtrlHStatusLabelCtrl.AutoSize = true;
            this.m_CtrlHStatusLabelCtrl.Location = new System.Drawing.Point(3, 711);
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
            this.tSB_ShuaXinDingWeiDian});
            this.toolStrip1.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.VerticalStackWithOverflow;
            this.toolStrip1.Location = new System.Drawing.Point(1406, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(145, 123);
            this.toolStrip1.TabIndex = 3;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // tSB_run_one
            // 
            this.tSB_run_one.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tSB_run_one.Image = ((System.Drawing.Image)(resources.GetObject("tSB_run_one.Image")));
            this.tSB_run_one.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tSB_run_one.Name = "tSB_run_one";
            this.tSB_run_one.Size = new System.Drawing.Size(143, 24);
            this.tSB_run_one.Text = "运行";
            this.tSB_run_one.Click += new System.EventHandler(this.tSB_run_one_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(143, 6);
            // 
            // tSB_read_image
            // 
            this.tSB_read_image.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tSB_read_image.Image = ((System.Drawing.Image)(resources.GetObject("tSB_read_image.Image")));
            this.tSB_read_image.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tSB_read_image.Name = "tSB_read_image";
            this.tSB_read_image.Size = new System.Drawing.Size(143, 24);
            this.tSB_read_image.Text = "取一张图片";
            this.tSB_read_image.Click += new System.EventHandler(this.tSB_read_image_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(143, 6);
            // 
            // tSB_ShuaXinDingWeiDian
            // 
            this.tSB_ShuaXinDingWeiDian.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tSB_ShuaXinDingWeiDian.Image = ((System.Drawing.Image)(resources.GetObject("tSB_ShuaXinDingWeiDian.Image")));
            this.tSB_ShuaXinDingWeiDian.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tSB_ShuaXinDingWeiDian.Name = "tSB_ShuaXinDingWeiDian";
            this.tSB_ShuaXinDingWeiDian.Size = new System.Drawing.Size(143, 24);
            this.tSB_ShuaXinDingWeiDian.Text = "刷新定位点";
            this.tSB_ShuaXinDingWeiDian.Click += new System.EventHandler(this.tSB_ShuaXinDingWeiDian_Click);
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(680, 3);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(723, 705);
            this.tabControl1.TabIndex = 2;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.hv_PatternNames);
            this.tabPage2.Controls.Add(this._ocvTrainingQuality_sure);
            this.tabPage2.Controls.Add(this.label8);
            this.tabPage2.Controls.Add(this._ocvTrainingQuality);
            this.tabPage2.Controls.Add(this._trained);
            this.tabPage2.Controls.Add(this.bnt_cut_out_check_region);
            this.tabPage2.Controls.Add(this.bnt_threshold_confrim);
            this.tabPage2.Controls.Add(this.hv_Threshold);
            this.tabPage2.Controls.Add(this.hv_AdaptGray);
            this.tabPage2.Controls.Add(this.hv_AdaptAngle);
            this.tabPage2.Controls.Add(this.hv_AdaptSize);
            this.tabPage2.Controls.Add(this.hv_AdaptPos);
            this.tabPage2.Controls.Add(this.label7);
            this.tabPage2.Controls.Add(this.label6);
            this.tabPage2.Controls.Add(this.label5);
            this.tabPage2.Controls.Add(this.label3);
            this.tabPage2.Controls.Add(this.label4);
            this.tabPage2.Controls.Add(this.label2);
            this.tabPage2.Location = new System.Drawing.Point(4, 25);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Size = new System.Drawing.Size(715, 676);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "OCV检测参数";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // hv_PatternNames
            // 
            this.hv_PatternNames.Location = new System.Drawing.Point(243, 41);
            this.hv_PatternNames.Name = "hv_PatternNames";
            this.hv_PatternNames.Size = new System.Drawing.Size(238, 25);
            this.hv_PatternNames.TabIndex = 18;
            this.hv_PatternNames.Text = "丝印检测的名称";
            this.hv_PatternNames.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // _ocvTrainingQuality_sure
            // 
            this._ocvTrainingQuality_sure.Location = new System.Drawing.Point(504, 573);
            this._ocvTrainingQuality_sure.Name = "_ocvTrainingQuality_sure";
            this._ocvTrainingQuality_sure.Size = new System.Drawing.Size(159, 66);
            this._ocvTrainingQuality_sure.TabIndex = 17;
            this._ocvTrainingQuality_sure.Text = "确定";
            this._ocvTrainingQuality_sure.UseVisualStyleBackColor = true;
            this._ocvTrainingQuality_sure.Click += new System.EventHandler(this._ocvTrainingQuality_sure_Click);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(48, 598);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(82, 15);
            this.label8.TabIndex = 16;
            this.label8.Text = "最小质量：";
            // 
            // _ocvTrainingQuality
            // 
            this._ocvTrainingQuality.Location = new System.Drawing.Point(237, 595);
            this._ocvTrainingQuality.Name = "_ocvTrainingQuality";
            this._ocvTrainingQuality.Size = new System.Drawing.Size(239, 25);
            this._ocvTrainingQuality.TabIndex = 15;
            this._ocvTrainingQuality.Text = "0";
            this._ocvTrainingQuality.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // _trained
            // 
            this._trained.AutoSize = true;
            this._trained.Location = new System.Drawing.Point(9, 542);
            this._trained.Name = "_trained";
            this._trained.Size = new System.Drawing.Size(149, 19);
            this._trained.TabIndex = 14;
            this._trained.Text = "训练当前丝印质量";
            this._trained.UseVisualStyleBackColor = true;
            this._trained.CheckedChanged += new System.EventHandler(this._trained_CheckedChanged);
            // 
            // bnt_cut_out_check_region
            // 
            this.bnt_cut_out_check_region.Location = new System.Drawing.Point(522, 26);
            this.bnt_cut_out_check_region.Name = "bnt_cut_out_check_region";
            this.bnt_cut_out_check_region.Size = new System.Drawing.Size(159, 51);
            this.bnt_cut_out_check_region.TabIndex = 13;
            this.bnt_cut_out_check_region.Text = "训练当前ocv";
            this.bnt_cut_out_check_region.UseVisualStyleBackColor = true;
            this.bnt_cut_out_check_region.Click += new System.EventHandler(this.bnt_cut_out_check_region_Click);
            // 
            // bnt_threshold_confrim
            // 
            this.bnt_threshold_confrim.Location = new System.Drawing.Point(509, 327);
            this.bnt_threshold_confrim.Name = "bnt_threshold_confrim";
            this.bnt_threshold_confrim.Size = new System.Drawing.Size(159, 26);
            this.bnt_threshold_confrim.TabIndex = 12;
            this.bnt_threshold_confrim.Text = "确定";
            this.bnt_threshold_confrim.UseVisualStyleBackColor = true;
            this.bnt_threshold_confrim.Click += new System.EventHandler(this.bnt_threshold_confrim_Click);
            // 
            // hv_Threshold
            // 
            this.hv_Threshold.Location = new System.Drawing.Point(242, 329);
            this.hv_Threshold.Name = "hv_Threshold";
            this.hv_Threshold.Size = new System.Drawing.Size(238, 25);
            this.hv_Threshold.TabIndex = 11;
            // 
            // hv_AdaptGray
            // 
            this.hv_AdaptGray.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.hv_AdaptGray.FormattingEnabled = true;
            this.hv_AdaptGray.Items.AddRange(new object[] {
            "true",
            "false"});
            this.hv_AdaptGray.Location = new System.Drawing.Point(240, 222);
            this.hv_AdaptGray.Name = "hv_AdaptGray";
            this.hv_AdaptGray.Size = new System.Drawing.Size(241, 23);
            this.hv_AdaptGray.TabIndex = 10;
            this.hv_AdaptGray.SelectedValueChanged += new System.EventHandler(this.hv_AdaptGray_SelectedValueChanged);
            // 
            // hv_AdaptAngle
            // 
            this.hv_AdaptAngle.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.hv_AdaptAngle.FormattingEnabled = true;
            this.hv_AdaptAngle.Items.AddRange(new object[] {
            "true",
            "false"});
            this.hv_AdaptAngle.Location = new System.Drawing.Point(240, 186);
            this.hv_AdaptAngle.Name = "hv_AdaptAngle";
            this.hv_AdaptAngle.Size = new System.Drawing.Size(241, 23);
            this.hv_AdaptAngle.TabIndex = 9;
            this.hv_AdaptAngle.SelectedValueChanged += new System.EventHandler(this.hv_AdaptAngle_SelectedValueChanged);
            // 
            // hv_AdaptSize
            // 
            this.hv_AdaptSize.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.hv_AdaptSize.FormattingEnabled = true;
            this.hv_AdaptSize.Items.AddRange(new object[] {
            "true",
            "false"});
            this.hv_AdaptSize.Location = new System.Drawing.Point(240, 147);
            this.hv_AdaptSize.Name = "hv_AdaptSize";
            this.hv_AdaptSize.Size = new System.Drawing.Size(241, 23);
            this.hv_AdaptSize.TabIndex = 8;
            this.hv_AdaptSize.SelectedValueChanged += new System.EventHandler(this.hv_AdaptSize_SelectedValueChanged);
            // 
            // hv_AdaptPos
            // 
            this.hv_AdaptPos.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.hv_AdaptPos.FormattingEnabled = true;
            this.hv_AdaptPos.Items.AddRange(new object[] {
            "true",
            "false"});
            this.hv_AdaptPos.Location = new System.Drawing.Point(240, 107);
            this.hv_AdaptPos.Name = "hv_AdaptPos";
            this.hv_AdaptPos.Size = new System.Drawing.Size(241, 23);
            this.hv_AdaptPos.TabIndex = 7;
            this.hv_AdaptPos.SelectedValueChanged += new System.EventHandler(this.hv_AdaptPos_SelectedValueChanged);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(6, 332);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(187, 15);
            this.label7.TabIndex = 6;
            this.label7.Text = "检测丝印允许的灰度误差：";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(28, 225);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(135, 15);
            this.label6.TabIndex = 5;
            this.label6.Text = "检测丝印灰度标志:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(28, 189);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(135, 15);
            this.label5.TabIndex = 4;
            this.label5.Text = "检测丝印角度标志:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(28, 150);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(135, 15);
            this.label3.TabIndex = 3;
            this.label3.Text = "检测丝印大小标志:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(21, 109);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(142, 15);
            this.label4.TabIndex = 2;
            this.label4.Text = "检测丝印位置标志：";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(31, 44);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(127, 15);
            this.label2.TabIndex = 0;
            this.label2.Text = "检测丝印的名称：";
            // 
            // halconWinControl_ROI1
            // 
            this.halconWinControl_ROI1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.halconWinControl_ROI1.HalconWindow1 = null;
            this.halconWinControl_ROI1.Ho_Image = null;
            this.halconWinControl_ROI1.HWindowControl = null;
            this.halconWinControl_ROI1.Location = new System.Drawing.Point(3, 3);
            this.halconWinControl_ROI1.Name = "halconWinControl_ROI1";
            this.halconWinControl_ROI1.Size = new System.Drawing.Size(671, 705);
            this.halconWinControl_ROI1.TabIndex = 5;
            // 
            // OCVFrm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1551, 744);
            this.Controls.Add(this.tableLayoutPanel1);
            this.MinimizeBox = false;
            this.Name = "OCVFrm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "OCV";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.acquriefrm_FormClosing);
            this.Load += new System.EventHandler(this.ParentFrm_Load);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.tabControl1.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
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
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox hv_AdaptGray;
        private System.Windows.Forms.ComboBox hv_AdaptAngle;
        private System.Windows.Forms.ComboBox hv_AdaptSize;
        private System.Windows.Forms.ComboBox hv_AdaptPos;
        private System.Windows.Forms.TextBox hv_Threshold;
        private System.Windows.Forms.Button bnt_threshold_confrim;
        private System.Windows.Forms.Button bnt_cut_out_check_region;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.CheckBox _trained;
        private HalControl.HalconWinControl_ROI halconWinControl_ROI1;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox _ocvTrainingQuality;
        private System.Windows.Forms.Button _ocvTrainingQuality_sure;
        private System.Windows.Forms.ToolStripButton tSB_ShuaXinDingWeiDian;
        private System.Windows.Forms.TextBox hv_PatternNames;
    }
}