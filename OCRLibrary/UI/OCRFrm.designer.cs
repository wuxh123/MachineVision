namespace OCRLibrary.UI
{
    partial class OCRFrm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(OCRFrm));
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.m_CtrlHStatusLabelCtrl = new System.Windows.Forms.Label();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.tSB_run_one = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.tSB_read_image = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.tSB_shua_xin_ding_wei_dian = new System.Windows.Forms.ToolStripButton();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.btn_tian_jia_roi = new System.Windows.Forms.Button();
            this.but_shan_chu_dang_qian_roi = new System.Windows.Forms.Button();
            this.nUD_yao_du_qu_ocr_de_ge_shu = new System.Windows.Forms.NumericUpDown();
            this.but_que_ding_yao_du_qu_ocr_de_ge_shu = new System.Windows.Forms.Button();
            this.label19 = new System.Windows.Forms.Label();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.Max = new System.Windows.Forms.NumericUpDown();
            this.Min = new System.Windows.Forms.NumericUpDown();
            this.Operation = new System.Windows.Forms.ComboBox();
            this.Features = new System.Windows.Forms.ComboBox();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.bnt_select_shape = new System.Windows.Forms.Button();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.MaxGray = new System.Windows.Forms.NumericUpDown();
            this.MinGray = new System.Windows.Forms.NumericUpDown();
            this.bnt_threshold = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this._ocrTrainingCharacteer = new System.Windows.Forms.RichTextBox();
            this._trained = new System.Windows.Forms.CheckBox();
            this.groupBox_current_train_work = new System.Windows.Forms.GroupBox();
            this.but_training = new System.Windows.Forms.Button();
            this.train_current_ocr = new System.Windows.Forms.RichTextBox();
            this.label17 = new System.Windows.Forms.Label();
            this.bnt_Load_Speciial_Work = new System.Windows.Forms.Button();
            this.Path1 = new System.Windows.Forms.RichTextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.Hv_FileName = new System.Windows.Forms.ComboBox();
            this.label13 = new System.Windows.Forms.Label();
            this.tabPage4 = new System.Windows.Forms.TabPage();
            this.txt_Hv_FileName = new System.Windows.Forms.TextBox();
            this.label18 = new System.Windows.Forms.Label();
            this.bnt_cut_out_train_region = new System.Windows.Forms.Button();
            this.hv_Class = new System.Windows.Forms.RichTextBox();
            this.bnt_Load_Class = new System.Windows.Forms.Button();
            this.label15 = new System.Windows.Forms.Label();
            this.halconWinControl_ROI1 = new HalControl.HalconWinControl_ROI();
            this.tableLayoutPanel1.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nUD_yao_du_qu_ocr_de_ge_shu)).BeginInit();
            this.groupBox5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Max)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Min)).BeginInit();
            this.groupBox4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.MaxGray)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.MinGray)).BeginInit();
            this.tabPage2.SuspendLayout();
            this.groupBox6.SuspendLayout();
            this.groupBox_current_train_work.SuspendLayout();
            this.tabPage4.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 3;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 48.13028F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 51.86972F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 103F));
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
            this.toolStripSeparator2,
            this.tSB_read_image,
            this.toolStripSeparator3,
            this.tSB_shua_xin_ding_wei_dian});
            this.toolStrip1.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.VerticalStackWithOverflow;
            this.toolStrip1.Location = new System.Drawing.Point(924, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(104, 95);
            this.toolStrip1.TabIndex = 3;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // tSB_run_one
            // 
            this.tSB_run_one.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tSB_run_one.Image = ((System.Drawing.Image)(resources.GetObject("tSB_run_one.Image")));
            this.tSB_run_one.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tSB_run_one.Name = "tSB_run_one";
            this.tSB_run_one.Size = new System.Drawing.Size(102, 21);
            this.tSB_run_one.Text = "运行";
            this.tSB_run_one.Click += new System.EventHandler(this.tSB_run_one_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(102, 6);
            // 
            // tSB_read_image
            // 
            this.tSB_read_image.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tSB_read_image.Image = ((System.Drawing.Image)(resources.GetObject("tSB_read_image.Image")));
            this.tSB_read_image.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tSB_read_image.Name = "tSB_read_image";
            this.tSB_read_image.Size = new System.Drawing.Size(102, 21);
            this.tSB_read_image.Text = "取一张图片";
            this.tSB_read_image.Click += new System.EventHandler(this.tSB_read_image_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(102, 6);
            // 
            // tSB_shua_xin_ding_wei_dian
            // 
            this.tSB_shua_xin_ding_wei_dian.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tSB_shua_xin_ding_wei_dian.Image = ((System.Drawing.Image)(resources.GetObject("tSB_shua_xin_ding_wei_dian.Image")));
            this.tSB_shua_xin_ding_wei_dian.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tSB_shua_xin_ding_wei_dian.Name = "tSB_shua_xin_ding_wei_dian";
            this.tSB_shua_xin_ding_wei_dian.Size = new System.Drawing.Size(102, 21);
            this.tSB_shua_xin_ding_wei_dian.Text = "刷新定位点";
            this.tSB_shua_xin_ding_wei_dian.Click += new System.EventHandler(this.tSB_shua_xin_ding_wei_dian_Click);
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage4);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(447, 2);
            this.tabControl1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(475, 568);
            this.tabControl1.TabIndex = 2;
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.btn_tian_jia_roi);
            this.tabPage3.Controls.Add(this.but_shan_chu_dang_qian_roi);
            this.tabPage3.Controls.Add(this.nUD_yao_du_qu_ocr_de_ge_shu);
            this.tabPage3.Controls.Add(this.but_que_ding_yao_du_qu_ocr_de_ge_shu);
            this.tabPage3.Controls.Add(this.label19);
            this.tabPage3.Controls.Add(this.groupBox5);
            this.tabPage3.Controls.Add(this.groupBox4);
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Size = new System.Drawing.Size(467, 542);
            this.tabPage3.TabIndex = 1;
            this.tabPage3.Text = "设置OCR分割";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // btn_tian_jia_roi
            // 
            this.btn_tian_jia_roi.Location = new System.Drawing.Point(199, 54);
            this.btn_tian_jia_roi.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btn_tian_jia_roi.Name = "btn_tian_jia_roi";
            this.btn_tian_jia_roi.Size = new System.Drawing.Size(112, 22);
            this.btn_tian_jia_roi.TabIndex = 16;
            this.btn_tian_jia_roi.Text = "添加roi";
            this.btn_tian_jia_roi.UseVisualStyleBackColor = true;
            this.btn_tian_jia_roi.Click += new System.EventHandler(this.btn_tian_jia_roi_Click);
            // 
            // but_shan_chu_dang_qian_roi
            // 
            this.but_shan_chu_dang_qian_roi.Location = new System.Drawing.Point(16, 54);
            this.but_shan_chu_dang_qian_roi.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.but_shan_chu_dang_qian_roi.Name = "but_shan_chu_dang_qian_roi";
            this.but_shan_chu_dang_qian_roi.Size = new System.Drawing.Size(112, 22);
            this.but_shan_chu_dang_qian_roi.TabIndex = 15;
            this.but_shan_chu_dang_qian_roi.Text = "删除当前选中的roi";
            this.but_shan_chu_dang_qian_roi.UseVisualStyleBackColor = true;
            this.but_shan_chu_dang_qian_roi.Click += new System.EventHandler(this.but_shan_chu_dang_qian_roi_Click);
            // 
            // nUD_yao_du_qu_ocr_de_ge_shu
            // 
            this.nUD_yao_du_qu_ocr_de_ge_shu.Location = new System.Drawing.Point(120, 13);
            this.nUD_yao_du_qu_ocr_de_ge_shu.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.nUD_yao_du_qu_ocr_de_ge_shu.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nUD_yao_du_qu_ocr_de_ge_shu.Name = "nUD_yao_du_qu_ocr_de_ge_shu";
            this.nUD_yao_du_qu_ocr_de_ge_shu.Size = new System.Drawing.Size(112, 21);
            this.nUD_yao_du_qu_ocr_de_ge_shu.TabIndex = 14;
            this.nUD_yao_du_qu_ocr_de_ge_shu.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // but_que_ding_yao_du_qu_ocr_de_ge_shu
            // 
            this.but_que_ding_yao_du_qu_ocr_de_ge_shu.Location = new System.Drawing.Point(268, 14);
            this.but_que_ding_yao_du_qu_ocr_de_ge_shu.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.but_que_ding_yao_du_qu_ocr_de_ge_shu.Name = "but_que_ding_yao_du_qu_ocr_de_ge_shu";
            this.but_que_ding_yao_du_qu_ocr_de_ge_shu.Size = new System.Drawing.Size(63, 18);
            this.but_que_ding_yao_du_qu_ocr_de_ge_shu.TabIndex = 13;
            this.but_que_ding_yao_du_qu_ocr_de_ge_shu.Text = "确定";
            this.but_que_ding_yao_du_qu_ocr_de_ge_shu.UseVisualStyleBackColor = true;
            this.but_que_ding_yao_du_qu_ocr_de_ge_shu.Click += new System.EventHandler(this.but_que_ding_yao_du_qu_ocr_de_ge_shu_Click);
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Location = new System.Drawing.Point(14, 14);
            this.label19.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(107, 12);
            this.label19.TabIndex = 11;
            this.label19.Text = "要读取ocr的个数：";
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.Max);
            this.groupBox5.Controls.Add(this.Min);
            this.groupBox5.Controls.Add(this.Operation);
            this.groupBox5.Controls.Add(this.Features);
            this.groupBox5.Controls.Add(this.label11);
            this.groupBox5.Controls.Add(this.label12);
            this.groupBox5.Controls.Add(this.bnt_select_shape);
            this.groupBox5.Controls.Add(this.label9);
            this.groupBox5.Controls.Add(this.label10);
            this.groupBox5.Location = new System.Drawing.Point(248, 119);
            this.groupBox5.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Padding = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.groupBox5.Size = new System.Drawing.Size(223, 239);
            this.groupBox5.TabIndex = 9;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "筛选字符的大小";
            // 
            // Max
            // 
            this.Max.Location = new System.Drawing.Point(80, 138);
            this.Max.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Max.Maximum = new decimal(new int[] {
            1569325056,
            23283064,
            0,
            0});
            this.Max.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.Max.Name = "Max";
            this.Max.Size = new System.Drawing.Size(128, 21);
            this.Max.TabIndex = 20;
            this.Max.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // Min
            // 
            this.Min.Location = new System.Drawing.Point(81, 105);
            this.Min.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Min.Maximum = new decimal(new int[] {
            1569325056,
            23283064,
            0,
            0});
            this.Min.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.Min.Name = "Min";
            this.Min.Size = new System.Drawing.Size(128, 21);
            this.Min.TabIndex = 19;
            this.Min.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // Operation
            // 
            this.Operation.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.Operation.FormattingEnabled = true;
            this.Operation.Items.AddRange(new object[] {
            "and"});
            this.Operation.Location = new System.Drawing.Point(80, 63);
            this.Operation.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Operation.Name = "Operation";
            this.Operation.Size = new System.Drawing.Size(129, 20);
            this.Operation.TabIndex = 12;
            // 
            // Features
            // 
            this.Features.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.Features.FormattingEnabled = true;
            this.Features.Items.AddRange(new object[] {
            "area"});
            this.Features.Location = new System.Drawing.Point(80, 24);
            this.Features.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Features.Name = "Features";
            this.Features.Size = new System.Drawing.Size(129, 20);
            this.Features.TabIndex = 11;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(4, 139);
            this.label11.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(29, 12);
            this.label11.TabIndex = 8;
            this.label11.Text = "Max:";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(4, 106);
            this.label12.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(29, 12);
            this.label12.TabIndex = 7;
            this.label12.Text = "Min:";
            // 
            // bnt_select_shape
            // 
            this.bnt_select_shape.Location = new System.Drawing.Point(7, 183);
            this.bnt_select_shape.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.bnt_select_shape.Name = "bnt_select_shape";
            this.bnt_select_shape.Size = new System.Drawing.Size(202, 30);
            this.bnt_select_shape.TabIndex = 6;
            this.bnt_select_shape.Text = "确定参数";
            this.bnt_select_shape.UseVisualStyleBackColor = true;
            this.bnt_select_shape.Click += new System.EventHandler(this.bnt_select_shape_Click);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(4, 66);
            this.label9.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(65, 12);
            this.label9.TabIndex = 1;
            this.label9.Text = "Operation:";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(4, 26);
            this.label10.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(59, 12);
            this.label10.TabIndex = 0;
            this.label10.Text = "Features:";
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.MaxGray);
            this.groupBox4.Controls.Add(this.MinGray);
            this.groupBox4.Controls.Add(this.bnt_threshold);
            this.groupBox4.Controls.Add(this.label5);
            this.groupBox4.Controls.Add(this.label8);
            this.groupBox4.Location = new System.Drawing.Point(16, 119);
            this.groupBox4.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Padding = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.groupBox4.Size = new System.Drawing.Size(223, 189);
            this.groupBox4.TabIndex = 8;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "设置字符的灰度值范围";
            // 
            // MaxGray
            // 
            this.MaxGray.Location = new System.Drawing.Point(81, 66);
            this.MaxGray.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.MaxGray.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.MaxGray.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.MaxGray.Name = "MaxGray";
            this.MaxGray.Size = new System.Drawing.Size(112, 21);
            this.MaxGray.TabIndex = 18;
            this.MaxGray.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // MinGray
            // 
            this.MinGray.Location = new System.Drawing.Point(81, 25);
            this.MinGray.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.MinGray.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.MinGray.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.MinGray.Name = "MinGray";
            this.MinGray.Size = new System.Drawing.Size(112, 21);
            this.MinGray.TabIndex = 17;
            this.MinGray.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // bnt_threshold
            // 
            this.bnt_threshold.Location = new System.Drawing.Point(7, 146);
            this.bnt_threshold.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.bnt_threshold.Name = "bnt_threshold";
            this.bnt_threshold.Size = new System.Drawing.Size(202, 30);
            this.bnt_threshold.TabIndex = 6;
            this.bnt_threshold.Text = "确定参数";
            this.bnt_threshold.UseVisualStyleBackColor = true;
            this.bnt_threshold.Click += new System.EventHandler(this.bnt_threshold_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(4, 66);
            this.label5.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(53, 12);
            this.label5.TabIndex = 1;
            this.label5.Text = "MaxGray:";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(4, 26);
            this.label8.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(53, 12);
            this.label8.TabIndex = 0;
            this.label8.Text = "MinGray:";
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.groupBox6);
            this.tabPage2.Controls.Add(this.groupBox_current_train_work);
            this.tabPage2.Controls.Add(this.bnt_Load_Speciial_Work);
            this.tabPage2.Controls.Add(this.Path1);
            this.tabPage2.Controls.Add(this.label14);
            this.tabPage2.Controls.Add(this.Hv_FileName);
            this.tabPage2.Controls.Add(this.label13);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Size = new System.Drawing.Size(467, 542);
            this.tabPage2.TabIndex = 2;
            this.tabPage2.Text = "设置OCR区域";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // groupBox6
            // 
            this.groupBox6.Controls.Add(this._ocrTrainingCharacteer);
            this.groupBox6.Controls.Add(this._trained);
            this.groupBox6.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.groupBox6.Location = new System.Drawing.Point(0, 325);
            this.groupBox6.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Padding = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.groupBox6.Size = new System.Drawing.Size(467, 217);
            this.groupBox6.TabIndex = 12;
            this.groupBox6.TabStop = false;
            this.groupBox6.Text = "建立字符的对比模板";
            // 
            // _ocrTrainingCharacteer
            // 
            this._ocrTrainingCharacteer.Location = new System.Drawing.Point(152, 27);
            this._ocrTrainingCharacteer.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this._ocrTrainingCharacteer.Name = "_ocrTrainingCharacteer";
            this._ocrTrainingCharacteer.ReadOnly = true;
            this._ocrTrainingCharacteer.Size = new System.Drawing.Size(188, 84);
            this._ocrTrainingCharacteer.TabIndex = 1;
            this._ocrTrainingCharacteer.Text = "要对比的字符";
            // 
            // _trained
            // 
            this._trained.Location = new System.Drawing.Point(2, 19);
            this._trained.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this._trained.Name = "_trained";
            this._trained.Size = new System.Drawing.Size(146, 34);
            this._trained.TabIndex = 0;
            this._trained.Text = "设置当前字符为对比模板";
            this._trained.UseVisualStyleBackColor = true;
            this._trained.CheckedChanged += new System.EventHandler(this._trained_CheckedChanged);
            // 
            // groupBox_current_train_work
            // 
            this.groupBox_current_train_work.Controls.Add(this.but_training);
            this.groupBox_current_train_work.Controls.Add(this.train_current_ocr);
            this.groupBox_current_train_work.Controls.Add(this.label17);
            this.groupBox_current_train_work.Location = new System.Drawing.Point(4, 138);
            this.groupBox_current_train_work.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.groupBox_current_train_work.Name = "groupBox_current_train_work";
            this.groupBox_current_train_work.Padding = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.groupBox_current_train_work.Size = new System.Drawing.Size(535, 84);
            this.groupBox_current_train_work.TabIndex = 10;
            this.groupBox_current_train_work.TabStop = false;
            this.groupBox_current_train_work.Text = "训练字符";
            // 
            // but_training
            // 
            this.but_training.Location = new System.Drawing.Point(363, 18);
            this.but_training.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.but_training.Name = "but_training";
            this.but_training.Size = new System.Drawing.Size(134, 38);
            this.but_training.TabIndex = 20;
            this.but_training.Text = "训练";
            this.but_training.UseVisualStyleBackColor = true;
            this.but_training.Click += new System.EventHandler(this.but_training_Click);
            // 
            // train_current_ocr
            // 
            this.train_current_ocr.Location = new System.Drawing.Point(98, 18);
            this.train_current_ocr.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.train_current_ocr.Name = "train_current_ocr";
            this.train_current_ocr.Size = new System.Drawing.Size(234, 38);
            this.train_current_ocr.TabIndex = 19;
            this.train_current_ocr.Text = "";
            this.train_current_ocr.TextChanged += new System.EventHandler(this.train_current_ocr_TextChanged);
            // 
            // label17
            // 
            this.label17.Location = new System.Drawing.Point(4, 18);
            this.label17.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(88, 38);
            this.label17.TabIndex = 16;
            this.label17.Text = "输入当前图片中分割出的字符：";
            this.label17.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // bnt_Load_Speciial_Work
            // 
            this.bnt_Load_Speciial_Work.Location = new System.Drawing.Point(368, 59);
            this.bnt_Load_Speciial_Work.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.bnt_Load_Speciial_Work.Name = "bnt_Load_Speciial_Work";
            this.bnt_Load_Speciial_Work.Size = new System.Drawing.Size(134, 54);
            this.bnt_Load_Speciial_Work.TabIndex = 6;
            this.bnt_Load_Speciial_Work.Text = "加载特殊字库";
            this.bnt_Load_Speciial_Work.UseVisualStyleBackColor = true;
            this.bnt_Load_Speciial_Work.Click += new System.EventHandler(this.bnt_Load_Speciial_Work_Click);
            // 
            // Path1
            // 
            this.Path1.Location = new System.Drawing.Point(102, 54);
            this.Path1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Path1.Name = "Path1";
            this.Path1.ReadOnly = true;
            this.Path1.Size = new System.Drawing.Size(237, 60);
            this.Path1.TabIndex = 5;
            this.Path1.Text = "";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(2, 57);
            this.label14.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(101, 12);
            this.label14.TabIndex = 4;
            this.label14.Text = "使用特殊字符库：";
            // 
            // Hv_FileName
            // 
            this.Hv_FileName.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.Hv_FileName.FormattingEnabled = true;
            this.Hv_FileName.Location = new System.Drawing.Point(102, 13);
            this.Hv_FileName.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Hv_FileName.Name = "Hv_FileName";
            this.Hv_FileName.Size = new System.Drawing.Size(234, 20);
            this.Hv_FileName.TabIndex = 3;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(2, 19);
            this.label13.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(83, 12);
            this.label13.TabIndex = 2;
            this.label13.Text = "选择OCR字库：";
            // 
            // tabPage4
            // 
            this.tabPage4.Controls.Add(this.txt_Hv_FileName);
            this.tabPage4.Controls.Add(this.label18);
            this.tabPage4.Controls.Add(this.bnt_cut_out_train_region);
            this.tabPage4.Controls.Add(this.hv_Class);
            this.tabPage4.Controls.Add(this.bnt_Load_Class);
            this.tabPage4.Controls.Add(this.label15);
            this.tabPage4.Location = new System.Drawing.Point(4, 22);
            this.tabPage4.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.tabPage4.Name = "tabPage4";
            this.tabPage4.Size = new System.Drawing.Size(537, 615);
            this.tabPage4.TabIndex = 3;
            this.tabPage4.Text = "创建OCR字符";
            this.tabPage4.UseVisualStyleBackColor = true;
            // 
            // txt_Hv_FileName
            // 
            this.txt_Hv_FileName.Location = new System.Drawing.Point(113, 11);
            this.txt_Hv_FileName.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.txt_Hv_FileName.Name = "txt_Hv_FileName";
            this.txt_Hv_FileName.Size = new System.Drawing.Size(221, 21);
            this.txt_Hv_FileName.TabIndex = 13;
            // 
            // label18
            // 
            this.label18.Location = new System.Drawing.Point(2, 11);
            this.label18.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(106, 54);
            this.label18.TabIndex = 12;
            this.label18.Text = "字库名称,名称为空表示采用默认：";
            // 
            // bnt_cut_out_train_region
            // 
            this.bnt_cut_out_train_region.Location = new System.Drawing.Point(113, 200);
            this.bnt_cut_out_train_region.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.bnt_cut_out_train_region.Name = "bnt_cut_out_train_region";
            this.bnt_cut_out_train_region.Size = new System.Drawing.Size(220, 76);
            this.bnt_cut_out_train_region.TabIndex = 10;
            this.bnt_cut_out_train_region.Text = "创建一个字库";
            this.bnt_cut_out_train_region.UseVisualStyleBackColor = true;
            this.bnt_cut_out_train_region.Click += new System.EventHandler(this.bnt_cut_out_train_region_Click);
            // 
            // hv_Class
            // 
            this.hv_Class.Location = new System.Drawing.Point(113, 66);
            this.hv_Class.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.hv_Class.Name = "hv_Class";
            this.hv_Class.Size = new System.Drawing.Size(221, 115);
            this.hv_Class.TabIndex = 6;
            this.hv_Class.Text = "1,2,3,4,5,6,7,8,9,0,a,s,d,f,g,h,j,k,l,q,w,e,r,t,y,u,i,o,p,z,x,c,v,b,n,m,A,S,D,F,G" +
    ",H,J,K,L,Q,W,E,R,T,Y,U,I,O,P,Z,X,C,V,B,N,M";
            // 
            // bnt_Load_Class
            // 
            this.bnt_Load_Class.Location = new System.Drawing.Point(352, 66);
            this.bnt_Load_Class.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.bnt_Load_Class.Name = "bnt_Load_Class";
            this.bnt_Load_Class.Size = new System.Drawing.Size(122, 114);
            this.bnt_Load_Class.TabIndex = 5;
            this.bnt_Load_Class.Text = "加载一个字符类";
            this.bnt_Load_Class.UseVisualStyleBackColor = true;
            this.bnt_Load_Class.Click += new System.EventHandler(this.bnt_Load_Class_Click);
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(2, 74);
            this.label15.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(113, 12);
            this.label15.TabIndex = 1;
            this.label15.Text = "要训练的字符名称：";
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
            this.halconWinControl_ROI1.Size = new System.Drawing.Size(441, 568);
            this.halconWinControl_ROI1.TabIndex = 5;
            // 
            // OCRFrm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1028, 599);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.MinimizeBox = false;
            this.Name = "OCRFrm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "OCR";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.acquriefrm_FormClosing);
            this.Load += new System.EventHandler(this.ParentFrm_Load);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.tabControl1.ResumeLayout(false);
            this.tabPage3.ResumeLayout(false);
            this.tabPage3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nUD_yao_du_qu_ocr_de_ge_shu)).EndInit();
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Max)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Min)).EndInit();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.MaxGray)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.MinGray)).EndInit();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.groupBox6.ResumeLayout(false);
            this.groupBox_current_train_work.ResumeLayout(false);
            this.tabPage4.ResumeLayout(false);
            this.tabPage4.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label m_CtrlHStatusLabelCtrl;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton tSB_run_one;
        private System.Windows.Forms.ToolStripButton tSB_read_image;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Button bnt_threshold;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.Button bnt_select_shape;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.ComboBox Features;
        private System.Windows.Forms.ComboBox Operation;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.ComboBox Hv_FileName;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.RichTextBox Path1;
        private System.Windows.Forms.Button bnt_Load_Speciial_Work;
        private System.Windows.Forms.TabPage tabPage4;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Button bnt_Load_Class;
        private System.Windows.Forms.RichTextBox hv_Class;
        private System.Windows.Forms.Button bnt_cut_out_train_region;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.TextBox txt_Hv_FileName;
        private System.Windows.Forms.GroupBox groupBox_current_train_work;
        private System.Windows.Forms.RichTextBox train_current_ocr;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.GroupBox groupBox6;
        private System.Windows.Forms.CheckBox _trained;
        private System.Windows.Forms.RichTextBox _ocrTrainingCharacteer;
        private HalControl.HalconWinControl_ROI halconWinControl_ROI1;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.Button but_que_ding_yao_du_qu_ocr_de_ge_shu;
        private System.Windows.Forms.NumericUpDown nUD_yao_du_qu_ocr_de_ge_shu;
        private System.Windows.Forms.Button but_shan_chu_dang_qian_roi;
        private System.Windows.Forms.ToolStripButton tSB_shua_xin_ding_wei_dian;
        private System.Windows.Forms.Button btn_tian_jia_roi;
        private System.Windows.Forms.Button but_training;
        private System.Windows.Forms.NumericUpDown MinGray;
        private System.Windows.Forms.NumericUpDown MaxGray;
        private System.Windows.Forms.NumericUpDown Min;
        private System.Windows.Forms.NumericUpDown Max;
    }
}