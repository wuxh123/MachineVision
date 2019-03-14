namespace DataCodeLibrary.UI
{
    partial class DataCodeFrm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DataCodeFrm));
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.bnt_sure_create_parameter = new System.Windows.Forms.Button();
            this.Create_hv_GenParamValues = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.Create_hv_GenParamNames = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.Create_hv_SymbolType = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.numericUpDown_Find_hv_GenParaValues = new System.Windows.Forms.NumericUpDown();
            this.bnt_sure_find_parameter = new System.Windows.Forms.Button();
            this.Find_hv_GenParamNames = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.tSB_run_one = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.tSB_read_image = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.tSB_ShuaXinDingWeiDian = new System.Windows.Forms.ToolStripButton();
            this.m_CtrlHStatusLabelCtrl = new System.Windows.Forms.Label();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.halconWinControl_ROI1 = new HalControl.HalconWinControl_ROI();
            this.tabControl1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.tabPage3.SuspendLayout();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_Find_hv_GenParaValues)).BeginInit();
            this.toolStrip1.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(628, 3);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(668, 609);
            this.tabControl1.TabIndex = 2;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.groupBox2);
            this.tabPage2.Location = new System.Drawing.Point(4, 25);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Size = new System.Drawing.Size(660, 580);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "读码参数";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.bnt_sure_create_parameter);
            this.groupBox2.Controls.Add(this.Create_hv_GenParamValues);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.Create_hv_GenParamNames);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.Create_hv_SymbolType);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox2.Location = new System.Drawing.Point(0, 0);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(660, 257);
            this.groupBox2.TabIndex = 0;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "读码的参数";
            // 
            // bnt_sure_create_parameter
            // 
            this.bnt_sure_create_parameter.Location = new System.Drawing.Point(202, 181);
            this.bnt_sure_create_parameter.Name = "bnt_sure_create_parameter";
            this.bnt_sure_create_parameter.Size = new System.Drawing.Size(247, 44);
            this.bnt_sure_create_parameter.TabIndex = 6;
            this.bnt_sure_create_parameter.Text = "确定参数";
            this.bnt_sure_create_parameter.UseVisualStyleBackColor = true;
            this.bnt_sure_create_parameter.Click += new System.EventHandler(this.bnt_sure_create_parameter_Click);
            // 
            // Create_hv_GenParamValues
            // 
            this.Create_hv_GenParamValues.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.Create_hv_GenParamValues.FormattingEnabled = true;
            this.Create_hv_GenParamValues.Items.AddRange(new object[] {
            "maximum_recognition"});
            this.Create_hv_GenParamValues.Location = new System.Drawing.Point(202, 133);
            this.Create_hv_GenParamValues.Name = "Create_hv_GenParamValues";
            this.Create_hv_GenParamValues.Size = new System.Drawing.Size(248, 23);
            this.Create_hv_GenParamValues.TabIndex = 5;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(4, 136);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(195, 15);
            this.label4.TabIndex = 4;
            this.label4.Text = "读取条码的参数特征1的值：";
            // 
            // Create_hv_GenParamNames
            // 
            this.Create_hv_GenParamNames.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.Create_hv_GenParamNames.FormattingEnabled = true;
            this.Create_hv_GenParamNames.Items.AddRange(new object[] {
            "default_parameters"});
            this.Create_hv_GenParamNames.Location = new System.Drawing.Point(202, 80);
            this.Create_hv_GenParamNames.Name = "Create_hv_GenParamNames";
            this.Create_hv_GenParamNames.Size = new System.Drawing.Size(248, 23);
            this.Create_hv_GenParamNames.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(4, 83);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(165, 15);
            this.label3.TabIndex = 2;
            this.label3.Text = "读取条码的参数特征1：";
            // 
            // Create_hv_SymbolType
            // 
            this.Create_hv_SymbolType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.Create_hv_SymbolType.FormattingEnabled = true;
            this.Create_hv_SymbolType.Items.AddRange(new object[] {
            "Data Matrix ECC 200",
            "QR Code",
            "Micro QR Code",
            "PDF417",
            "Aztec Code"});
            this.Create_hv_SymbolType.Location = new System.Drawing.Point(202, 24);
            this.Create_hv_SymbolType.Name = "Create_hv_SymbolType";
            this.Create_hv_SymbolType.Size = new System.Drawing.Size(248, 23);
            this.Create_hv_SymbolType.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(4, 27);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(127, 15);
            this.label2.TabIndex = 0;
            this.label2.Text = "读取条码的类型：";
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.groupBox3);
            this.tabPage3.Location = new System.Drawing.Point(4, 25);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Size = new System.Drawing.Size(660, 580);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "查找的参数";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.numericUpDown_Find_hv_GenParaValues);
            this.groupBox3.Controls.Add(this.bnt_sure_find_parameter);
            this.groupBox3.Controls.Add(this.Find_hv_GenParamNames);
            this.groupBox3.Controls.Add(this.label6);
            this.groupBox3.Controls.Add(this.label5);
            this.groupBox3.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox3.Location = new System.Drawing.Point(0, 0);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(660, 194);
            this.groupBox3.TabIndex = 0;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "查找的参数";
            // 
            // numericUpDown_Find_hv_GenParaValues
            // 
            this.numericUpDown_Find_hv_GenParaValues.Location = new System.Drawing.Point(201, 78);
            this.numericUpDown_Find_hv_GenParaValues.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUpDown_Find_hv_GenParaValues.Name = "numericUpDown_Find_hv_GenParaValues";
            this.numericUpDown_Find_hv_GenParaValues.Size = new System.Drawing.Size(189, 25);
            this.numericUpDown_Find_hv_GenParaValues.TabIndex = 6;
            this.numericUpDown_Find_hv_GenParaValues.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // bnt_sure_find_parameter
            // 
            this.bnt_sure_find_parameter.Location = new System.Drawing.Point(201, 130);
            this.bnt_sure_find_parameter.Name = "bnt_sure_find_parameter";
            this.bnt_sure_find_parameter.Size = new System.Drawing.Size(188, 41);
            this.bnt_sure_find_parameter.TabIndex = 4;
            this.bnt_sure_find_parameter.Text = "确定参数";
            this.bnt_sure_find_parameter.UseVisualStyleBackColor = true;
            this.bnt_sure_find_parameter.Click += new System.EventHandler(this.bnt_sure_find_parameter_Click);
            // 
            // Find_hv_GenParamNames
            // 
            this.Find_hv_GenParamNames.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.Find_hv_GenParamNames.FormattingEnabled = true;
            this.Find_hv_GenParamNames.Items.AddRange(new object[] {
            "stop_after_result_num"});
            this.Find_hv_GenParamNames.Location = new System.Drawing.Point(201, 30);
            this.Find_hv_GenParamNames.Name = "Find_hv_GenParamNames";
            this.Find_hv_GenParamNames.Size = new System.Drawing.Size(189, 23);
            this.Find_hv_GenParamNames.TabIndex = 2;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(3, 80);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(157, 15);
            this.label6.TabIndex = 1;
            this.label6.Text = "查找的参数特征的值：";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(3, 33);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(127, 15);
            this.label5.TabIndex = 0;
            this.label5.Text = "查找的参数特征：";
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
            this.toolStrip1.Location = new System.Drawing.Point(1299, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(152, 104);
            this.toolStrip1.TabIndex = 3;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // tSB_run_one
            // 
            this.tSB_run_one.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tSB_run_one.Image = ((System.Drawing.Image)(resources.GetObject("tSB_run_one.Image")));
            this.tSB_run_one.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tSB_run_one.Name = "tSB_run_one";
            this.tSB_run_one.Size = new System.Drawing.Size(150, 24);
            this.tSB_run_one.Text = "运行";
            this.tSB_run_one.Click += new System.EventHandler(this.tSB_run_one_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(150, 6);
            // 
            // tSB_read_image
            // 
            this.tSB_read_image.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tSB_read_image.Image = ((System.Drawing.Image)(resources.GetObject("tSB_read_image.Image")));
            this.tSB_read_image.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tSB_read_image.Name = "tSB_read_image";
            this.tSB_read_image.Size = new System.Drawing.Size(150, 24);
            this.tSB_read_image.Text = "取一张图片";
            this.tSB_read_image.Click += new System.EventHandler(this.tSB_read_image_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(150, 6);
            // 
            // tSB_ShuaXinDingWeiDian
            // 
            this.tSB_ShuaXinDingWeiDian.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tSB_ShuaXinDingWeiDian.Image = ((System.Drawing.Image)(resources.GetObject("tSB_ShuaXinDingWeiDian.Image")));
            this.tSB_ShuaXinDingWeiDian.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tSB_ShuaXinDingWeiDian.Name = "tSB_ShuaXinDingWeiDian";
            this.tSB_ShuaXinDingWeiDian.Size = new System.Drawing.Size(150, 24);
            this.tSB_ShuaXinDingWeiDian.Text = "刷新定位点";
            this.tSB_ShuaXinDingWeiDian.Click += new System.EventHandler(this.tSB_ShuaXinDingWeiDian_Click);
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
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 3;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 48.13028F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 51.86972F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 151F));
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
            // halconWinControl_ROI1
            // 
            this.halconWinControl_ROI1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.halconWinControl_ROI1.HalconWindow1 = null;
            this.halconWinControl_ROI1.Ho_Image = null;
            this.halconWinControl_ROI1.HWindowControl = null;
            this.halconWinControl_ROI1.Location = new System.Drawing.Point(3, 3);
            this.halconWinControl_ROI1.Name = "halconWinControl_ROI1";
            this.halconWinControl_ROI1.Size = new System.Drawing.Size(619, 609);
            this.halconWinControl_ROI1.TabIndex = 5;
            // 
            // DataCodeFrm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1451, 644);
            this.Controls.Add(this.tableLayoutPanel1);
            this.MinimizeBox = false;
            this.Name = "DataCodeFrm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "二维码";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.acquriefrm_FormClosing);
            this.Load += new System.EventHandler(this.ParentFrm_Load);
            this.tabControl1.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.tabPage3.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_Find_hv_GenParaValues)).EndInit();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button bnt_sure_create_parameter;
        private System.Windows.Forms.ComboBox Create_hv_GenParamValues;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox Create_hv_GenParamNames;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox Create_hv_SymbolType;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Button bnt_sure_find_parameter;
        private System.Windows.Forms.ComboBox Find_hv_GenParamNames;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton tSB_run_one;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton tSB_read_image;
        private System.Windows.Forms.Label m_CtrlHStatusLabelCtrl;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private HalControl.HalconWinControl_ROI halconWinControl_ROI1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripButton tSB_ShuaXinDingWeiDian;
        private System.Windows.Forms.NumericUpDown numericUpDown_Find_hv_GenParaValues;

    }
}