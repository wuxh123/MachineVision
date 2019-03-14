namespace BarCodeHalconLibrary.UI
{
    partial class CodeBarFrm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CodeBarFrm));
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.m_CtrlHStatusLabelCtrl = new System.Windows.Forms.Label();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.tSB_run_one = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.tSB_read_image = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.tSB_shua_xin_ding_wei_dian = new System.Windows.Forms.ToolStripButton();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.numericUpDown_min_Grade = new System.Windows.Forms.NumericUpDown();
            this.numericUpDown_Num_scanlines = new System.Windows.Forms.NumericUpDown();
            this.numericUpDown_Persistence = new System.Windows.Forms.NumericUpDown();
            this.numericUpDown_element_size_min = new System.Windows.Forms.NumericUpDown();
            this.numericUpDown_contrast_min = new System.Windows.Forms.NumericUpDown();
            this.bnt_QueDingCanShu = new System.Windows.Forms.Button();
            this._BarCodeTrained = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this._trained = new System.Windows.Forms.CheckBox();
            this.Quality_isoiec15416 = new System.Windows.Forms.CheckBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.hv_CodeType = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.halconWinControl_ROI1 = new HalControl.HalconWinControl_ROI();
            this.tableLayoutPanel1.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_min_Grade)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_Num_scanlines)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_Persistence)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_element_size_min)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_contrast_min)).BeginInit();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 3;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 56.88172F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 43.11828F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 120F));
            this.tableLayoutPanel1.Controls.Add(this.m_CtrlHStatusLabelCtrl, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.toolStrip1, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this.tabControl1, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.halconWinControl_ROI1, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 95.63795F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 31F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1282, 544);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // m_CtrlHStatusLabelCtrl
            // 
            this.m_CtrlHStatusLabelCtrl.AutoSize = true;
            this.m_CtrlHStatusLabelCtrl.Location = new System.Drawing.Point(3, 513);
            this.m_CtrlHStatusLabelCtrl.Name = "m_CtrlHStatusLabelCtrl";
            this.m_CtrlHStatusLabelCtrl.Size = new System.Drawing.Size(63, 15);
            this.m_CtrlHStatusLabelCtrl.TabIndex = 5;
            this.m_CtrlHStatusLabelCtrl.Text = "message";
            // 
            // toolStrip1
            // 
            this.toolStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tSB_run_one,
            this.toolStripSeparator3,
            this.tSB_read_image,
            this.toolStripSeparator1,
            this.tSB_shua_xin_ding_wei_dian});
            this.toolStrip1.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.VerticalStackWithOverflow;
            this.toolStrip1.Location = new System.Drawing.Point(1161, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(121, 104);
            this.toolStrip1.TabIndex = 3;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // tSB_run_one
            // 
            this.tSB_run_one.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tSB_run_one.Image = ((System.Drawing.Image)(resources.GetObject("tSB_run_one.Image")));
            this.tSB_run_one.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tSB_run_one.Name = "tSB_run_one";
            this.tSB_run_one.Size = new System.Drawing.Size(119, 24);
            this.tSB_run_one.Text = "运行";
            this.tSB_run_one.Click += new System.EventHandler(this.tSB_run_one_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(119, 6);
            // 
            // tSB_read_image
            // 
            this.tSB_read_image.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tSB_read_image.Image = ((System.Drawing.Image)(resources.GetObject("tSB_read_image.Image")));
            this.tSB_read_image.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tSB_read_image.Name = "tSB_read_image";
            this.tSB_read_image.Size = new System.Drawing.Size(119, 24);
            this.tSB_read_image.Text = "取一张图片";
            this.tSB_read_image.Click += new System.EventHandler(this.tSB_read_image_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(119, 6);
            // 
            // tSB_shua_xin_ding_wei_dian
            // 
            this.tSB_shua_xin_ding_wei_dian.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tSB_shua_xin_ding_wei_dian.Image = ((System.Drawing.Image)(resources.GetObject("tSB_shua_xin_ding_wei_dian.Image")));
            this.tSB_shua_xin_ding_wei_dian.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tSB_shua_xin_ding_wei_dian.Name = "tSB_shua_xin_ding_wei_dian";
            this.tSB_shua_xin_ding_wei_dian.Size = new System.Drawing.Size(119, 24);
            this.tSB_shua_xin_ding_wei_dian.Text = "刷新定位点";
            this.tSB_shua_xin_ding_wei_dian.Click += new System.EventHandler(this.tSB_shua_xin_ding_wei_dian_Click);
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(663, 3);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(495, 507);
            this.tabControl1.TabIndex = 2;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.numericUpDown_min_Grade);
            this.tabPage2.Controls.Add(this.numericUpDown_Num_scanlines);
            this.tabPage2.Controls.Add(this.numericUpDown_Persistence);
            this.tabPage2.Controls.Add(this.numericUpDown_element_size_min);
            this.tabPage2.Controls.Add(this.numericUpDown_contrast_min);
            this.tabPage2.Controls.Add(this.bnt_QueDingCanShu);
            this.tabPage2.Controls.Add(this._BarCodeTrained);
            this.tabPage2.Controls.Add(this.label7);
            this.tabPage2.Controls.Add(this._trained);
            this.tabPage2.Controls.Add(this.Quality_isoiec15416);
            this.tabPage2.Controls.Add(this.label6);
            this.tabPage2.Controls.Add(this.label5);
            this.tabPage2.Controls.Add(this.label4);
            this.tabPage2.Controls.Add(this.label3);
            this.tabPage2.Controls.Add(this.hv_CodeType);
            this.tabPage2.Controls.Add(this.label2);
            this.tabPage2.Location = new System.Drawing.Point(4, 25);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Size = new System.Drawing.Size(487, 478);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "设置一维码";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // numericUpDown_min_Grade
            // 
            this.numericUpDown_min_Grade.Location = new System.Drawing.Point(163, 235);
            this.numericUpDown_min_Grade.Maximum = new decimal(new int[] {
            7,
            0,
            0,
            0});
            this.numericUpDown_min_Grade.Name = "numericUpDown_min_Grade";
            this.numericUpDown_min_Grade.Size = new System.Drawing.Size(151, 25);
            this.numericUpDown_min_Grade.TabIndex = 31;
            // 
            // numericUpDown_Num_scanlines
            // 
            this.numericUpDown_Num_scanlines.Location = new System.Drawing.Point(162, 183);
            this.numericUpDown_Num_scanlines.Name = "numericUpDown_Num_scanlines";
            this.numericUpDown_Num_scanlines.Size = new System.Drawing.Size(151, 25);
            this.numericUpDown_Num_scanlines.TabIndex = 30;
            // 
            // numericUpDown_Persistence
            // 
            this.numericUpDown_Persistence.Location = new System.Drawing.Point(163, 143);
            this.numericUpDown_Persistence.Maximum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUpDown_Persistence.Name = "numericUpDown_Persistence";
            this.numericUpDown_Persistence.Size = new System.Drawing.Size(151, 25);
            this.numericUpDown_Persistence.TabIndex = 29;
            // 
            // numericUpDown_element_size_min
            // 
            this.numericUpDown_element_size_min.Location = new System.Drawing.Point(163, 94);
            this.numericUpDown_element_size_min.Name = "numericUpDown_element_size_min";
            this.numericUpDown_element_size_min.Size = new System.Drawing.Size(151, 25);
            this.numericUpDown_element_size_min.TabIndex = 28;
            // 
            // numericUpDown_contrast_min
            // 
            this.numericUpDown_contrast_min.Location = new System.Drawing.Point(162, 57);
            this.numericUpDown_contrast_min.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.numericUpDown_contrast_min.Name = "numericUpDown_contrast_min";
            this.numericUpDown_contrast_min.Size = new System.Drawing.Size(151, 25);
            this.numericUpDown_contrast_min.TabIndex = 27;
            // 
            // bnt_QueDingCanShu
            // 
            this.bnt_QueDingCanShu.Location = new System.Drawing.Point(327, 59);
            this.bnt_QueDingCanShu.Name = "bnt_QueDingCanShu";
            this.bnt_QueDingCanShu.Size = new System.Drawing.Size(134, 201);
            this.bnt_QueDingCanShu.TabIndex = 26;
            this.bnt_QueDingCanShu.Text = "确定";
            this.bnt_QueDingCanShu.UseVisualStyleBackColor = true;
            this.bnt_QueDingCanShu.Click += new System.EventHandler(this.bnt_min_Grade_Click);
            // 
            // _BarCodeTrained
            // 
            this._BarCodeTrained.Location = new System.Drawing.Point(174, 328);
            this._BarCodeTrained.Name = "_BarCodeTrained";
            this._BarCodeTrained.Size = new System.Drawing.Size(287, 51);
            this._BarCodeTrained.TabIndex = 25;
            this._BarCodeTrained.Text = "训练的条码";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(3, 237);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(112, 15);
            this.label7.TabIndex = 23;
            this.label7.Text = "条码最小等级：";
            // 
            // _trained
            // 
            this._trained.Location = new System.Drawing.Point(6, 339);
            this._trained.Name = "_trained";
            this._trained.Size = new System.Drawing.Size(301, 19);
            this._trained.TabIndex = 22;
            this._trained.Text = "训练当前条码为模板";
            this._trained.UseVisualStyleBackColor = true;
            this._trained.CheckedChanged += new System.EventHandler(this._trained_CheckedChanged);
            // 
            // Quality_isoiec15416
            // 
            this.Quality_isoiec15416.AutoSize = true;
            this.Quality_isoiec15416.Location = new System.Drawing.Point(6, 294);
            this.Quality_isoiec15416.Name = "Quality_isoiec15416";
            this.Quality_isoiec15416.Size = new System.Drawing.Size(179, 19);
            this.Quality_isoiec15416.TabIndex = 21;
            this.Quality_isoiec15416.Text = "是否启动条码等级验证";
            this.Quality_isoiec15416.UseVisualStyleBackColor = true;
            this.Quality_isoiec15416.CheckedChanged += new System.EventHandler(this.Quality_isoiec15416_CheckedChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(3, 185);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(120, 15);
            this.label6.TabIndex = 10;
            this.label6.Text = "设置扫描线条数:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(3, 145);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(105, 15);
            this.label5.TabIndex = 9;
            this.label5.Text = "保存中间结果:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(3, 104);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(120, 15);
            this.label4.TabIndex = 8;
            this.label4.Text = "最小宽度的尺寸:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(3, 67);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(90, 15);
            this.label3.TabIndex = 7;
            this.label3.Text = "最小对比度:";
            // 
            // hv_CodeType
            // 
            this.hv_CodeType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.hv_CodeType.FormattingEnabled = true;
            this.hv_CodeType.Items.AddRange(new object[] {
            "auto",
            "Code 39",
            "Code 93",
            "Code 128"});
            this.hv_CodeType.Location = new System.Drawing.Point(162, 24);
            this.hv_CodeType.Name = "hv_CodeType";
            this.hv_CodeType.Size = new System.Drawing.Size(145, 23);
            this.hv_CodeType.TabIndex = 6;
            this.hv_CodeType.SelectedIndexChanged += new System.EventHandler(this.hv_CodeType_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(3, 24);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(112, 15);
            this.label2.TabIndex = 5;
            this.label2.Text = "读取条码格式：";
            // 
            // halconWinControl_ROI1
            // 
            this.halconWinControl_ROI1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.halconWinControl_ROI1.HalconWindow1 = null;
            this.halconWinControl_ROI1.Ho_Image = null;
            this.halconWinControl_ROI1.HWindowControl = null;
            this.halconWinControl_ROI1.Location = new System.Drawing.Point(3, 3);
            this.halconWinControl_ROI1.Name = "halconWinControl_ROI1";
            this.halconWinControl_ROI1.Size = new System.Drawing.Size(654, 507);
            this.halconWinControl_ROI1.TabIndex = 6;
            // 
            // CodeBarFrm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1282, 544);
            this.Controls.Add(this.tableLayoutPanel1);
            this.MinimizeBox = false;
            this.Name = "CodeBarFrm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "一维码";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.acquriefrm_FormClosing);
            this.Load += new System.EventHandler(this.ParentFrm_Load);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.tabControl1.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_min_Grade)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_Num_scanlines)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_Persistence)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_element_size_min)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_contrast_min)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton tSB_run_one;
        private System.Windows.Forms.ToolStripButton tSB_read_image;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox hv_CodeType;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.Label m_CtrlHStatusLabelCtrl;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.CheckBox Quality_isoiec15416;
        private System.Windows.Forms.CheckBox _trained;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label _BarCodeTrained;
        private System.Windows.Forms.Button bnt_QueDingCanShu;
        private HalControl.HalconWinControl_ROI halconWinControl_ROI1;
        private System.Windows.Forms.ToolStripButton tSB_shua_xin_ding_wei_dian;
        private System.Windows.Forms.NumericUpDown numericUpDown_contrast_min;
        private System.Windows.Forms.NumericUpDown numericUpDown_element_size_min;
        private System.Windows.Forms.NumericUpDown numericUpDown_Persistence;
        private System.Windows.Forms.NumericUpDown numericUpDown_Num_scanlines;
        private System.Windows.Forms.NumericUpDown numericUpDown_min_Grade;
    }
}