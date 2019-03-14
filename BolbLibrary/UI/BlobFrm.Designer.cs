namespace BlobLibrary.UI
{
    partial class BlobFrm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(BlobFrm));
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.m_CtrlHStatusLabelCtrl = new System.Windows.Forms.Label();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.tSB_run_one = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.tSB_read_image = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.tSB_ShuaXinDingWeiDian = new System.Windows.Forms.ToolStripButton();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.bnt_QueDingCanShuJu = new System.Windows.Forms.Button();
            this.numericUpDown_Max = new System.Windows.Forms.NumericUpDown();
            this.numericUpDown_Min = new System.Windows.Forms.NumericUpDown();
            this.comboBox_Features = new System.Windows.Forms.ComboBox();
            this.numericUpDown_MaxGray = new System.Windows.Forms.NumericUpDown();
            this.numericUpDown_MinGray = new System.Windows.Forms.NumericUpDown();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.halconWinControl_ROI1 = new HalControl.HalconWinControl_ROI();
            this.tableLayoutPanel1.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_Max)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_Min)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_MaxGray)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_MinGray)).BeginInit();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 3;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 48.13028F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 51.86972F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 143F));
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
            this.toolStripSeparator2,
            this.tSB_ShuaXinDingWeiDian});
            this.toolStrip1.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.VerticalStackWithOverflow;
            this.toolStrip1.Location = new System.Drawing.Point(1307, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(144, 104);
            this.toolStrip1.TabIndex = 3;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // tSB_run_one
            // 
            this.tSB_run_one.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tSB_run_one.Image = ((System.Drawing.Image)(resources.GetObject("tSB_run_one.Image")));
            this.tSB_run_one.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tSB_run_one.Name = "tSB_run_one";
            this.tSB_run_one.Size = new System.Drawing.Size(142, 24);
            this.tSB_run_one.Text = "运行";
            this.tSB_run_one.Click += new System.EventHandler(this.tSB_run_one_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(142, 6);
            // 
            // tSB_read_image
            // 
            this.tSB_read_image.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tSB_read_image.Image = ((System.Drawing.Image)(resources.GetObject("tSB_read_image.Image")));
            this.tSB_read_image.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tSB_read_image.Name = "tSB_read_image";
            this.tSB_read_image.Size = new System.Drawing.Size(142, 24);
            this.tSB_read_image.Text = "取一张图片";
            this.tSB_read_image.Click += new System.EventHandler(this.tSB_read_image_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(142, 6);
            // 
            // tSB_ShuaXinDingWeiDian
            // 
            this.tSB_ShuaXinDingWeiDian.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tSB_ShuaXinDingWeiDian.Image = ((System.Drawing.Image)(resources.GetObject("tSB_ShuaXinDingWeiDian.Image")));
            this.tSB_ShuaXinDingWeiDian.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tSB_ShuaXinDingWeiDian.Name = "tSB_ShuaXinDingWeiDian";
            this.tSB_ShuaXinDingWeiDian.Size = new System.Drawing.Size(142, 24);
            this.tSB_ShuaXinDingWeiDian.Text = "刷新定位点";
            this.tSB_ShuaXinDingWeiDian.Click += new System.EventHandler(this.tSB_ShuaXinDingWeiDian_Click);
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(632, 3);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(672, 609);
            this.tabControl1.TabIndex = 2;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.bnt_QueDingCanShuJu);
            this.tabPage2.Controls.Add(this.numericUpDown_Max);
            this.tabPage2.Controls.Add(this.numericUpDown_Min);
            this.tabPage2.Controls.Add(this.comboBox_Features);
            this.tabPage2.Controls.Add(this.numericUpDown_MaxGray);
            this.tabPage2.Controls.Add(this.numericUpDown_MinGray);
            this.tabPage2.Controls.Add(this.label5);
            this.tabPage2.Controls.Add(this.label4);
            this.tabPage2.Controls.Add(this.label3);
            this.tabPage2.Controls.Add(this.label2);
            this.tabPage2.Controls.Add(this.label1);
            this.tabPage2.Location = new System.Drawing.Point(4, 25);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Size = new System.Drawing.Size(664, 580);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "参数设置";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // bnt_QueDingCanShuJu
            // 
            this.bnt_QueDingCanShuJu.Location = new System.Drawing.Point(359, 13);
            this.bnt_QueDingCanShuJu.Name = "bnt_QueDingCanShuJu";
            this.bnt_QueDingCanShuJu.Size = new System.Drawing.Size(188, 189);
            this.bnt_QueDingCanShuJu.TabIndex = 10;
            this.bnt_QueDingCanShuJu.Text = "确定参数";
            this.bnt_QueDingCanShuJu.UseVisualStyleBackColor = true;
            this.bnt_QueDingCanShuJu.Click += new System.EventHandler(this.bnt_QueDingCanShuJu_Click);
            // 
            // numericUpDown_Max
            // 
            this.numericUpDown_Max.DecimalPlaces = 3;
            this.numericUpDown_Max.Location = new System.Drawing.Point(152, 184);
            this.numericUpDown_Max.Maximum = new decimal(new int[] {
            -1486618624,
            232830643,
            0,
            0});
            this.numericUpDown_Max.Name = "numericUpDown_Max";
            this.numericUpDown_Max.Size = new System.Drawing.Size(155, 25);
            this.numericUpDown_Max.TabIndex = 9;
            // 
            // numericUpDown_Min
            // 
            this.numericUpDown_Min.DecimalPlaces = 3;
            this.numericUpDown_Min.Location = new System.Drawing.Point(152, 142);
            this.numericUpDown_Min.Maximum = new decimal(new int[] {
            1569325056,
            23283064,
            0,
            0});
            this.numericUpDown_Min.Name = "numericUpDown_Min";
            this.numericUpDown_Min.Size = new System.Drawing.Size(155, 25);
            this.numericUpDown_Min.TabIndex = 8;
            // 
            // comboBox_Features
            // 
            this.comboBox_Features.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_Features.FormattingEnabled = true;
            this.comboBox_Features.Items.AddRange(new object[] {
            "area"});
            this.comboBox_Features.Location = new System.Drawing.Point(150, 97);
            this.comboBox_Features.Name = "comboBox_Features";
            this.comboBox_Features.Size = new System.Drawing.Size(157, 23);
            this.comboBox_Features.TabIndex = 7;
            // 
            // numericUpDown_MaxGray
            // 
            this.numericUpDown_MaxGray.Location = new System.Drawing.Point(152, 59);
            this.numericUpDown_MaxGray.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.numericUpDown_MaxGray.Name = "numericUpDown_MaxGray";
            this.numericUpDown_MaxGray.Size = new System.Drawing.Size(155, 25);
            this.numericUpDown_MaxGray.TabIndex = 6;
            // 
            // numericUpDown_MinGray
            // 
            this.numericUpDown_MinGray.Location = new System.Drawing.Point(152, 21);
            this.numericUpDown_MinGray.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.numericUpDown_MinGray.Name = "numericUpDown_MinGray";
            this.numericUpDown_MinGray.Size = new System.Drawing.Size(155, 25);
            this.numericUpDown_MinGray.TabIndex = 5;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(3, 186);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(127, 15);
            this.label5.TabIndex = 4;
            this.label5.Text = "斑点特征最大值：";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(3, 144);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(127, 15);
            this.label4.TabIndex = 3;
            this.label4.Text = "斑点特征最小值：";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(3, 100);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(82, 15);
            this.label3.TabIndex = 2;
            this.label3.Text = "斑点特征：";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(3, 61);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(127, 15);
            this.label2.TabIndex = 1;
            this.label2.Text = "斑点最大的灰度：";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 23);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(127, 15);
            this.label1.TabIndex = 0;
            this.label1.Text = "斑点最小的灰度：";
            // 
            // halconWinControl_ROI1
            // 
            this.halconWinControl_ROI1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.halconWinControl_ROI1.HalconWindow1 = null;
            this.halconWinControl_ROI1.Ho_Image = null;
            this.halconWinControl_ROI1.HWindowControl = null;
            this.halconWinControl_ROI1.Location = new System.Drawing.Point(3, 3);
            this.halconWinControl_ROI1.Name = "halconWinControl_ROI1";
            this.halconWinControl_ROI1.Size = new System.Drawing.Size(623, 609);
            this.halconWinControl_ROI1.TabIndex = 5;
            // 
            // BlobFrm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1451, 644);
            this.Controls.Add(this.tableLayoutPanel1);
            this.MinimizeBox = false;
            this.Name = "BlobFrm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "blob";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.acquriefrm_FormClosing);
            this.Load += new System.EventHandler(this.ParentFrm_Load);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.tabControl1.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_Max)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_Min)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_MaxGray)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_MinGray)).EndInit();
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
        private HalControl.HalconWinControl_ROI halconWinControl_ROI1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripButton tSB_ShuaXinDingWeiDian;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.NumericUpDown numericUpDown_MinGray;
        private System.Windows.Forms.NumericUpDown numericUpDown_MaxGray;
        private System.Windows.Forms.ComboBox comboBox_Features;
        private System.Windows.Forms.NumericUpDown numericUpDown_Max;
        private System.Windows.Forms.NumericUpDown numericUpDown_Min;
        private System.Windows.Forms.Button bnt_QueDingCanShuJu;
    }
}