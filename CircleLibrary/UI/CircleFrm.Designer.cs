namespace CircleLibrary.UI
{
    partial class CircleFrm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CircleFrm));
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
            this.comboBox_Hv_Direct = new System.Windows.Forms.ComboBox();
            this.label12 = new System.Windows.Forms.Label();
            this.numericUpDown_Hv_Threshold = new System.Windows.Forms.NumericUpDown();
            this.numericUpDown_Hv_ActiveNum = new System.Windows.Forms.NumericUpDown();
            this.numericUpDown_Hv_DetectWidth = new System.Windows.Forms.NumericUpDown();
            this.numericUpDown_Hv_DetectHeight = new System.Windows.Forms.NumericUpDown();
            this.numericUpDown_Hv_Elements = new System.Windows.Forms.NumericUpDown();
            this.button_queDingCanShu = new System.Windows.Forms.Button();
            this.numericUpDown_endAngle = new System.Windows.Forms.NumericUpDown();
            this.numericUpDown_startAngle = new System.Windows.Forms.NumericUpDown();
            this.label11 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.comboBox_Hv_Select = new System.Windows.Forms.ComboBox();
            this.comboBox_Hv_Transition = new System.Windows.Forms.ComboBox();
            this.comboBox_Hv_Sigma = new System.Windows.Forms.ComboBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.tabPage4 = new System.Windows.Forms.TabPage();
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
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_endAngle)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_startAngle)).BeginInit();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 3;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 48.13028F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 51.86972F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 112F));
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
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1028, 524);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // m_CtrlHStatusLabelCtrl
            // 
            this.m_CtrlHStatusLabelCtrl.AutoSize = true;
            this.m_CtrlHStatusLabelCtrl.Location = new System.Drawing.Point(2, 501);
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
            this.toolStrip1.Location = new System.Drawing.Point(915, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(113, 71);
            this.toolStrip1.TabIndex = 3;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // tSB_run_one
            // 
            this.tSB_run_one.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tSB_run_one.Image = ((System.Drawing.Image)(resources.GetObject("tSB_run_one.Image")));
            this.tSB_run_one.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tSB_run_one.Name = "tSB_run_one";
            this.tSB_run_one.Size = new System.Drawing.Size(111, 21);
            this.tSB_run_one.Text = "运行";
            this.tSB_run_one.Click += new System.EventHandler(this.tSB_run_one_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(111, 6);
            // 
            // tSB_read_image
            // 
            this.tSB_read_image.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tSB_read_image.Image = ((System.Drawing.Image)(resources.GetObject("tSB_read_image.Image")));
            this.tSB_read_image.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tSB_read_image.Name = "tSB_read_image";
            this.tSB_read_image.Size = new System.Drawing.Size(111, 21);
            this.tSB_read_image.Text = "取一张图片";
            this.tSB_read_image.Click += new System.EventHandler(this.tSB_read_image_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(111, 6);
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage4);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(442, 2);
            this.tabControl1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(471, 497);
            this.tabControl1.TabIndex = 2;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.groupBox2);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Size = new System.Drawing.Size(463, 471);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "卡尺参数";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.comboBox_Hv_Direct);
            this.groupBox2.Controls.Add(this.label12);
            this.groupBox2.Controls.Add(this.numericUpDown_Hv_Threshold);
            this.groupBox2.Controls.Add(this.numericUpDown_Hv_ActiveNum);
            this.groupBox2.Controls.Add(this.numericUpDown_Hv_DetectWidth);
            this.groupBox2.Controls.Add(this.numericUpDown_Hv_DetectHeight);
            this.groupBox2.Controls.Add(this.numericUpDown_Hv_Elements);
            this.groupBox2.Controls.Add(this.button_queDingCanShu);
            this.groupBox2.Controls.Add(this.numericUpDown_endAngle);
            this.groupBox2.Controls.Add(this.numericUpDown_startAngle);
            this.groupBox2.Controls.Add(this.label11);
            this.groupBox2.Controls.Add(this.label10);
            this.groupBox2.Controls.Add(this.comboBox_Hv_Select);
            this.groupBox2.Controls.Add(this.comboBox_Hv_Transition);
            this.groupBox2.Controls.Add(this.comboBox_Hv_Sigma);
            this.groupBox2.Controls.Add(this.label9);
            this.groupBox2.Controls.Add(this.label8);
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox2.Location = new System.Drawing.Point(0, 0);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.groupBox2.Size = new System.Drawing.Size(463, 405);
            this.groupBox2.TabIndex = 0;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "设置卡尺参数";
            // 
            // comboBox_Hv_Direct
            // 
            this.comboBox_Hv_Direct.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_Hv_Direct.FormattingEnabled = true;
            this.comboBox_Hv_Direct.Items.AddRange(new object[] {
            "inner",
            "outer"});
            this.comboBox_Hv_Direct.Location = new System.Drawing.Point(104, 116);
            this.comboBox_Hv_Direct.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.comboBox_Hv_Direct.Name = "comboBox_Hv_Direct";
            this.comboBox_Hv_Direct.Size = new System.Drawing.Size(158, 20);
            this.comboBox_Hv_Direct.TabIndex = 47;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(4, 118);
            this.label12.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(65, 12);
            this.label12.TabIndex = 46;
            this.label12.Text = "搜索方向：";
            // 
            // numericUpDown_Hv_Threshold
            // 
            this.numericUpDown_Hv_Threshold.Location = new System.Drawing.Point(104, 282);
            this.numericUpDown_Hv_Threshold.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.numericUpDown_Hv_Threshold.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.numericUpDown_Hv_Threshold.Name = "numericUpDown_Hv_Threshold";
            this.numericUpDown_Hv_Threshold.Size = new System.Drawing.Size(158, 21);
            this.numericUpDown_Hv_Threshold.TabIndex = 45;
            this.numericUpDown_Hv_Threshold.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // numericUpDown_Hv_ActiveNum
            // 
            this.numericUpDown_Hv_ActiveNum.Location = new System.Drawing.Point(102, 211);
            this.numericUpDown_Hv_ActiveNum.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.numericUpDown_Hv_ActiveNum.Maximum = new decimal(new int[] {
            1316134912,
            2328,
            0,
            0});
            this.numericUpDown_Hv_ActiveNum.Name = "numericUpDown_Hv_ActiveNum";
            this.numericUpDown_Hv_ActiveNum.Size = new System.Drawing.Size(158, 21);
            this.numericUpDown_Hv_ActiveNum.TabIndex = 44;
            this.numericUpDown_Hv_ActiveNum.Value = new decimal(new int[] {
            3,
            0,
            0,
            0});
            // 
            // numericUpDown_Hv_DetectWidth
            // 
            this.numericUpDown_Hv_DetectWidth.Location = new System.Drawing.Point(104, 84);
            this.numericUpDown_Hv_DetectWidth.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.numericUpDown_Hv_DetectWidth.Maximum = new decimal(new int[] {
            1569325056,
            23283064,
            0,
            0});
            this.numericUpDown_Hv_DetectWidth.Name = "numericUpDown_Hv_DetectWidth";
            this.numericUpDown_Hv_DetectWidth.Size = new System.Drawing.Size(158, 21);
            this.numericUpDown_Hv_DetectWidth.TabIndex = 43;
            this.numericUpDown_Hv_DetectWidth.Value = new decimal(new int[] {
            5,
            0,
            0,
            0});
            // 
            // numericUpDown_Hv_DetectHeight
            // 
            this.numericUpDown_Hv_DetectHeight.Location = new System.Drawing.Point(104, 49);
            this.numericUpDown_Hv_DetectHeight.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.numericUpDown_Hv_DetectHeight.Maximum = new decimal(new int[] {
            1215752192,
            23,
            0,
            0});
            this.numericUpDown_Hv_DetectHeight.Name = "numericUpDown_Hv_DetectHeight";
            this.numericUpDown_Hv_DetectHeight.Size = new System.Drawing.Size(158, 21);
            this.numericUpDown_Hv_DetectHeight.TabIndex = 42;
            this.numericUpDown_Hv_DetectHeight.Value = new decimal(new int[] {
            5,
            0,
            0,
            0});
            // 
            // numericUpDown_Hv_Elements
            // 
            this.numericUpDown_Hv_Elements.Location = new System.Drawing.Point(104, 15);
            this.numericUpDown_Hv_Elements.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.numericUpDown_Hv_Elements.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.numericUpDown_Hv_Elements.Name = "numericUpDown_Hv_Elements";
            this.numericUpDown_Hv_Elements.Size = new System.Drawing.Size(158, 21);
            this.numericUpDown_Hv_Elements.TabIndex = 41;
            this.numericUpDown_Hv_Elements.Value = new decimal(new int[] {
            6,
            0,
            0,
            0});
            // 
            // button_queDingCanShu
            // 
            this.button_queDingCanShu.Location = new System.Drawing.Point(303, 15);
            this.button_queDingCanShu.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.button_queDingCanShu.Name = "button_queDingCanShu";
            this.button_queDingCanShu.Size = new System.Drawing.Size(164, 150);
            this.button_queDingCanShu.TabIndex = 40;
            this.button_queDingCanShu.Text = "确定参数";
            this.button_queDingCanShu.UseVisualStyleBackColor = true;
            this.button_queDingCanShu.Click += new System.EventHandler(this.button_queDingCanShu_Click);
            // 
            // numericUpDown_endAngle
            // 
            this.numericUpDown_endAngle.Location = new System.Drawing.Point(104, 174);
            this.numericUpDown_endAngle.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.numericUpDown_endAngle.Maximum = new decimal(new int[] {
            360,
            0,
            0,
            0});
            this.numericUpDown_endAngle.Name = "numericUpDown_endAngle";
            this.numericUpDown_endAngle.Size = new System.Drawing.Size(158, 21);
            this.numericUpDown_endAngle.TabIndex = 39;
            this.numericUpDown_endAngle.Value = new decimal(new int[] {
            360,
            0,
            0,
            0});
            // 
            // numericUpDown_startAngle
            // 
            this.numericUpDown_startAngle.Location = new System.Drawing.Point(104, 145);
            this.numericUpDown_startAngle.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.numericUpDown_startAngle.Maximum = new decimal(new int[] {
            360,
            0,
            0,
            0});
            this.numericUpDown_startAngle.Name = "numericUpDown_startAngle";
            this.numericUpDown_startAngle.Size = new System.Drawing.Size(158, 21);
            this.numericUpDown_startAngle.TabIndex = 38;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(2, 182);
            this.label11.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(65, 12);
            this.label11.TabIndex = 37;
            this.label11.Text = "结束角度：";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(2, 153);
            this.label10.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(65, 12);
            this.label10.TabIndex = 36;
            this.label10.Text = "起启角度：";
            // 
            // comboBox_Hv_Select
            // 
            this.comboBox_Hv_Select.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_Hv_Select.FormattingEnabled = true;
            this.comboBox_Hv_Select.Items.AddRange(new object[] {
            "first",
            "last",
            "max"});
            this.comboBox_Hv_Select.Location = new System.Drawing.Point(102, 356);
            this.comboBox_Hv_Select.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.comboBox_Hv_Select.Name = "comboBox_Hv_Select";
            this.comboBox_Hv_Select.Size = new System.Drawing.Size(158, 20);
            this.comboBox_Hv_Select.TabIndex = 35;
            // 
            // comboBox_Hv_Transition
            // 
            this.comboBox_Hv_Transition.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_Hv_Transition.FormattingEnabled = true;
            this.comboBox_Hv_Transition.Items.AddRange(new object[] {
            "positive",
            "negative",
            "all"});
            this.comboBox_Hv_Transition.Location = new System.Drawing.Point(102, 323);
            this.comboBox_Hv_Transition.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.comboBox_Hv_Transition.Name = "comboBox_Hv_Transition";
            this.comboBox_Hv_Transition.Size = new System.Drawing.Size(158, 20);
            this.comboBox_Hv_Transition.TabIndex = 34;
            // 
            // comboBox_Hv_Sigma
            // 
            this.comboBox_Hv_Sigma.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_Hv_Sigma.FormattingEnabled = true;
            this.comboBox_Hv_Sigma.Items.AddRange(new object[] {
            "4",
            "5",
            "6"});
            this.comboBox_Hv_Sigma.Location = new System.Drawing.Point(102, 246);
            this.comboBox_Hv_Sigma.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.comboBox_Hv_Sigma.Name = "comboBox_Hv_Sigma";
            this.comboBox_Hv_Sigma.Size = new System.Drawing.Size(158, 20);
            this.comboBox_Hv_Sigma.TabIndex = 32;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(0, 356);
            this.label9.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(89, 12);
            this.label9.TabIndex = 30;
            this.label9.Text = "选择点的位置：";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(0, 323);
            this.label8.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(65, 12);
            this.label8.TabIndex = 29;
            this.label8.Text = "找点极性：";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(0, 283);
            this.label7.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(89, 12);
            this.label7.TabIndex = 28;
            this.label7.Text = "边缘幅度阈值：";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(0, 248);
            this.label6.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(89, 12);
            this.label6.TabIndex = 27;
            this.label6.Text = "高斯滤波因子：";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(0, 213);
            this.label5.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(77, 12);
            this.label5.TabIndex = 26;
            this.label5.Text = "最小有效点：";
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
            // tabPage4
            // 
            this.tabPage4.Location = new System.Drawing.Point(4, 22);
            this.tabPage4.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.tabPage4.Name = "tabPage4";
            this.tabPage4.Size = new System.Drawing.Size(468, 470);
            this.tabPage4.TabIndex = 3;
            this.tabPage4.Text = "结果";
            this.tabPage4.UseVisualStyleBackColor = true;
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
            this.halconWinControl_ROI1.Size = new System.Drawing.Size(436, 497);
            this.halconWinControl_ROI1.TabIndex = 5;
            // 
            // CircleFrm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1028, 524);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.MinimizeBox = false;
            this.Name = "CircleFrm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "拟合圆";
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
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_endAngle)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_startAngle)).EndInit();
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
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TabPage tabPage4;
        private HalControl.HalconWinControl_ROI halconWinControl_ROI1;
        private System.Windows.Forms.ComboBox comboBox_Hv_Select;
        private System.Windows.Forms.ComboBox comboBox_Hv_Transition;
        private System.Windows.Forms.ComboBox comboBox_Hv_Sigma;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.NumericUpDown numericUpDown_startAngle;
        private System.Windows.Forms.NumericUpDown numericUpDown_endAngle;
        private System.Windows.Forms.Button button_queDingCanShu;
        private System.Windows.Forms.NumericUpDown numericUpDown_Hv_DetectHeight;
        private System.Windows.Forms.NumericUpDown numericUpDown_Hv_Elements;
        private System.Windows.Forms.NumericUpDown numericUpDown_Hv_DetectWidth;
        private System.Windows.Forms.NumericUpDown numericUpDown_Hv_ActiveNum;
        private System.Windows.Forms.NumericUpDown numericUpDown_Hv_Threshold;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.ComboBox comboBox_Hv_Direct;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
    }
}