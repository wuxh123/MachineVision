namespace OCRTextLibrary.UI
{
    partial class OCRTextFrm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(OCRTextFrm));
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.tSB_run_one = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.tSB_read_image = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.tSB_shua_xin_ding_wei_dian = new System.Windows.Forms.ToolStripButton();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.halconWinControl_ROI1 = new HalControl.HalconWinControl_ROI();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.numericUpDown_char_height = new System.Windows.Forms.NumericUpDown();
            this.label3 = new System.Windows.Forms.Label();
            this.numericUpDown_char_width = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.Hv_FileName = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.m_CtrlHStatusLabelCtrl = new System.Windows.Forms.Label();
            this.toolStrip1.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_char_height)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_char_width)).BeginInit();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.Dock = System.Windows.Forms.DockStyle.Right;
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tSB_run_one,
            this.toolStripSeparator1,
            this.tSB_read_image,
            this.toolStripSeparator2,
            this.tSB_shua_xin_ding_wei_dian});
            this.toolStrip1.Location = new System.Drawing.Point(943, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(85, 599);
            this.toolStrip1.TabIndex = 1;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // tSB_run_one
            // 
            this.tSB_run_one.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tSB_run_one.Image = ((System.Drawing.Image)(resources.GetObject("tSB_run_one.Image")));
            this.tSB_run_one.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tSB_run_one.Name = "tSB_run_one";
            this.tSB_run_one.Size = new System.Drawing.Size(82, 21);
            this.tSB_run_one.Text = "运行";
            this.tSB_run_one.Click += new System.EventHandler(this.tSB_run_one_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(82, 6);
            // 
            // tSB_read_image
            // 
            this.tSB_read_image.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tSB_read_image.Image = ((System.Drawing.Image)(resources.GetObject("tSB_read_image.Image")));
            this.tSB_read_image.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tSB_read_image.Name = "tSB_read_image";
            this.tSB_read_image.Size = new System.Drawing.Size(82, 21);
            this.tSB_read_image.Text = "取图一张图片";
            this.tSB_read_image.Click += new System.EventHandler(this.tSB_read_image_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(82, 6);
            // 
            // tSB_shua_xin_ding_wei_dian
            // 
            this.tSB_shua_xin_ding_wei_dian.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tSB_shua_xin_ding_wei_dian.Image = ((System.Drawing.Image)(resources.GetObject("tSB_shua_xin_ding_wei_dian.Image")));
            this.tSB_shua_xin_ding_wei_dian.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tSB_shua_xin_ding_wei_dian.Name = "tSB_shua_xin_ding_wei_dian";
            this.tSB_shua_xin_ding_wei_dian.Size = new System.Drawing.Size(82, 21);
            this.tSB_shua_xin_ding_wei_dian.Text = "刷新定位点";
            this.tSB_shua_xin_ding_wei_dian.Click += new System.EventHandler(this.tSB_shua_xin_ding_wei_dian_Click);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.m_CtrlHStatusLabelCtrl, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel2, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(2);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 35F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(943, 599);
            this.tableLayoutPanel1.TabIndex = 2;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 2;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.Controls.Add(this.halconWinControl_ROI1, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.tabControl1, 1, 0);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(2, 2);
            this.tableLayoutPanel2.Margin = new System.Windows.Forms.Padding(2);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 1;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(939, 560);
            this.tableLayoutPanel2.TabIndex = 0;
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
            this.halconWinControl_ROI1.Size = new System.Drawing.Size(465, 556);
            this.halconWinControl_ROI1.TabIndex = 0;
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(471, 2);
            this.tabControl1.Margin = new System.Windows.Forms.Padding(2);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(466, 556);
            this.tabControl1.TabIndex = 1;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.numericUpDown_char_height);
            this.tabPage1.Controls.Add(this.label3);
            this.tabPage1.Controls.Add(this.numericUpDown_char_width);
            this.tabPage1.Controls.Add(this.label2);
            this.tabPage1.Controls.Add(this.Hv_FileName);
            this.tabPage1.Controls.Add(this.label1);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Margin = new System.Windows.Forms.Padding(2);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(2);
            this.tabPage1.Size = new System.Drawing.Size(458, 530);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "参数";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // numericUpDown_char_height
            // 
            this.numericUpDown_char_height.Location = new System.Drawing.Point(57, 113);
            this.numericUpDown_char_height.Margin = new System.Windows.Forms.Padding(2);
            this.numericUpDown_char_height.Name = "numericUpDown_char_height";
            this.numericUpDown_char_height.Size = new System.Drawing.Size(218, 21);
            this.numericUpDown_char_height.TabIndex = 8;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(4, 114);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(47, 12);
            this.label3.TabIndex = 7;
            this.label3.Text = "字符宽:";
            // 
            // numericUpDown_char_width
            // 
            this.numericUpDown_char_width.Location = new System.Drawing.Point(57, 62);
            this.numericUpDown_char_width.Margin = new System.Windows.Forms.Padding(2);
            this.numericUpDown_char_width.Name = "numericUpDown_char_width";
            this.numericUpDown_char_width.Size = new System.Drawing.Size(218, 21);
            this.numericUpDown_char_width.TabIndex = 6;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(4, 70);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(47, 12);
            this.label2.TabIndex = 5;
            this.label2.Text = "字符高:";
            // 
            // Hv_FileName
            // 
            this.Hv_FileName.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.Hv_FileName.FormattingEnabled = true;
            this.Hv_FileName.Location = new System.Drawing.Point(57, 13);
            this.Hv_FileName.Margin = new System.Windows.Forms.Padding(2);
            this.Hv_FileName.Name = "Hv_FileName";
            this.Hv_FileName.Size = new System.Drawing.Size(219, 20);
            this.Hv_FileName.TabIndex = 4;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(4, 15);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "字库:";
            // 
            // m_CtrlHStatusLabelCtrl
            // 
            this.m_CtrlHStatusLabelCtrl.AutoSize = true;
            this.m_CtrlHStatusLabelCtrl.Location = new System.Drawing.Point(2, 564);
            this.m_CtrlHStatusLabelCtrl.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.m_CtrlHStatusLabelCtrl.Name = "m_CtrlHStatusLabelCtrl";
            this.m_CtrlHStatusLabelCtrl.Size = new System.Drawing.Size(47, 12);
            this.m_CtrlHStatusLabelCtrl.TabIndex = 5;
            this.m_CtrlHStatusLabelCtrl.Text = "message";
            // 
            // OCRTextFrm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1028, 599);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.toolStrip1);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "OCRTextFrm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "OCR文本读取工具";
            this.Load += new System.EventHandler(this.OCRTextFrm_Load);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_char_height)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_char_width)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private HalControl.HalconWinControl_ROI halconWinControl_ROI1;
        private System.Windows.Forms.ToolStripButton tSB_run_one;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton tSB_read_image;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripButton tSB_shua_xin_ding_wei_dian;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox Hv_FileName;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.NumericUpDown numericUpDown_char_width;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.NumericUpDown numericUpDown_char_height;
        private System.Windows.Forms.Label m_CtrlHStatusLabelCtrl;
    }
}