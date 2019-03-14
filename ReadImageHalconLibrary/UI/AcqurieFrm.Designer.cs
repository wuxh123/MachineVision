namespace ReadImageHalconLibrary.UI
{
    partial class AcqurieFrm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AcqurieFrm));
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.m_CtrlHStatusLabelCtrl = new System.Windows.Forms.Label();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.tSB_run_one = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.tSB_circulation_run = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.tSB_read_image = new System.Windows.Forms.ToolStripButton();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.bnt_write_registry = new System.Windows.Forms.Button();
            this.Registry_height = new System.Windows.Forms.TextBox();
            this.Registry_width = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.Acquire = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btn_remove_picture = new System.Windows.Forms.Button();
            this.btn_delete_picture = new System.Windows.Forms.Button();
            this.bnt_add_picture = new System.Windows.Forms.Button();
            this.listBox_acquire_picture = new System.Windows.Forms.ListBox();
            this.label1 = new System.Windows.Forms.Label();
            this.halconWinControl_11 = new HalControl.HalconWinControl_1();
            this.tableLayoutPanel1.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 3;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 48.13028F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 51.86972F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 105F));
            this.tableLayoutPanel1.Controls.Add(this.m_CtrlHStatusLabelCtrl, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.toolStrip1, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this.tabControl1, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.halconWinControl_11, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(2);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 95.63795F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 4.36205F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1028, 515);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // m_CtrlHStatusLabelCtrl
            // 
            this.m_CtrlHStatusLabelCtrl.AutoSize = true;
            this.m_CtrlHStatusLabelCtrl.Location = new System.Drawing.Point(2, 492);
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
            this.tSB_circulation_run,
            this.toolStripSeparator2,
            this.tSB_read_image});
            this.toolStrip1.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.VerticalStackWithOverflow;
            this.toolStrip1.Location = new System.Drawing.Point(922, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(106, 95);
            this.toolStrip1.TabIndex = 3;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // tSB_run_one
            // 
            this.tSB_run_one.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tSB_run_one.Image = ((System.Drawing.Image)(resources.GetObject("tSB_run_one.Image")));
            this.tSB_run_one.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tSB_run_one.Name = "tSB_run_one";
            this.tSB_run_one.Size = new System.Drawing.Size(104, 21);
            this.tSB_run_one.Text = "运行";
            this.tSB_run_one.Click += new System.EventHandler(this.tSB_run_one_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(104, 6);
            // 
            // tSB_circulation_run
            // 
            this.tSB_circulation_run.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tSB_circulation_run.Image = ((System.Drawing.Image)(resources.GetObject("tSB_circulation_run.Image")));
            this.tSB_circulation_run.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tSB_circulation_run.Name = "tSB_circulation_run";
            this.tSB_circulation_run.Size = new System.Drawing.Size(104, 21);
            this.tSB_circulation_run.Text = "循环运行";
            this.tSB_circulation_run.Click += new System.EventHandler(this.tSB_circulation_run_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(104, 6);
            // 
            // tSB_read_image
            // 
            this.tSB_read_image.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tSB_read_image.Image = ((System.Drawing.Image)(resources.GetObject("tSB_read_image.Image")));
            this.tSB_read_image.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tSB_read_image.Name = "tSB_read_image";
            this.tSB_read_image.Size = new System.Drawing.Size(104, 21);
            this.tSB_read_image.Text = "取一张图片";
            this.tSB_read_image.Click += new System.EventHandler(this.tSB_read_image_Click);
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(446, 2);
            this.tabControl1.Margin = new System.Windows.Forms.Padding(2);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(474, 488);
            this.tabControl1.TabIndex = 2;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.groupBox1);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Margin = new System.Windows.Forms.Padding(2);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(2);
            this.tabPage1.Size = new System.Drawing.Size(466, 462);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "取图";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.groupBox2);
            this.groupBox1.Controls.Add(this.Acquire);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.btn_remove_picture);
            this.groupBox1.Controls.Add(this.btn_delete_picture);
            this.groupBox1.Controls.Add(this.bnt_add_picture);
            this.groupBox1.Controls.Add(this.listBox_acquire_picture);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox1.Location = new System.Drawing.Point(2, 2);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(2);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(2);
            this.groupBox1.Size = new System.Drawing.Size(462, 538);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "取图";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.bnt_write_registry);
            this.groupBox2.Controls.Add(this.Registry_height);
            this.groupBox2.Controls.Add(this.Registry_width);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Location = new System.Drawing.Point(20, 72);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(2);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(2);
            this.groupBox2.Size = new System.Drawing.Size(344, 58);
            this.groupBox2.TabIndex = 7;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "注册表大小";
            // 
            // bnt_write_registry
            // 
            this.bnt_write_registry.Location = new System.Drawing.Point(274, 19);
            this.bnt_write_registry.Margin = new System.Windows.Forms.Padding(2);
            this.bnt_write_registry.Name = "bnt_write_registry";
            this.bnt_write_registry.Size = new System.Drawing.Size(65, 23);
            this.bnt_write_registry.TabIndex = 4;
            this.bnt_write_registry.Text = "确定";
            this.bnt_write_registry.UseVisualStyleBackColor = true;
            this.bnt_write_registry.Click += new System.EventHandler(this.bnt_write_registry_Click);
            // 
            // Registry_height
            // 
            this.Registry_height.Location = new System.Drawing.Point(194, 22);
            this.Registry_height.Margin = new System.Windows.Forms.Padding(2);
            this.Registry_height.Name = "Registry_height";
            this.Registry_height.Size = new System.Drawing.Size(77, 21);
            this.Registry_height.TabIndex = 3;
            // 
            // Registry_width
            // 
            this.Registry_width.Location = new System.Drawing.Point(59, 22);
            this.Registry_width.Margin = new System.Windows.Forms.Padding(2);
            this.Registry_width.Name = "Registry_width";
            this.Registry_width.Size = new System.Drawing.Size(77, 21);
            this.Registry_width.TabIndex = 2;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(142, 25);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(47, 12);
            this.label4.TabIndex = 1;
            this.label4.Text = "height:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(14, 25);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(41, 12);
            this.label3.TabIndex = 0;
            this.label3.Text = "width:";
            // 
            // Acquire
            // 
            this.Acquire.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.Acquire.FormattingEnabled = true;
            this.Acquire.Items.AddRange(new object[] {
            "Registry_Image_One",
            "Registry_Image_Two",
            "Folder_Image"});
            this.Acquire.Location = new System.Drawing.Point(85, 30);
            this.Acquire.Margin = new System.Windows.Forms.Padding(2);
            this.Acquire.Name = "Acquire";
            this.Acquire.Size = new System.Drawing.Size(280, 20);
            this.Acquire.TabIndex = 6;
            this.Acquire.SelectedIndexChanged += new System.EventHandler(this.Acquire_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.label2.Location = new System.Drawing.Point(4, 29);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(76, 20);
            this.label2.TabIndex = 5;
            this.label2.Text = "取图方式：";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btn_remove_picture
            // 
            this.btn_remove_picture.Location = new System.Drawing.Point(372, 355);
            this.btn_remove_picture.Margin = new System.Windows.Forms.Padding(2);
            this.btn_remove_picture.Name = "btn_remove_picture";
            this.btn_remove_picture.Size = new System.Drawing.Size(118, 41);
            this.btn_remove_picture.TabIndex = 4;
            this.btn_remove_picture.Text = "移除图片";
            this.btn_remove_picture.UseVisualStyleBackColor = true;
            this.btn_remove_picture.Click += new System.EventHandler(this.btn_remove_picture_Click);
            // 
            // btn_delete_picture
            // 
            this.btn_delete_picture.Location = new System.Drawing.Point(196, 354);
            this.btn_delete_picture.Margin = new System.Windows.Forms.Padding(2);
            this.btn_delete_picture.Name = "btn_delete_picture";
            this.btn_delete_picture.Size = new System.Drawing.Size(139, 42);
            this.btn_delete_picture.TabIndex = 3;
            this.btn_delete_picture.Text = "删除图片";
            this.btn_delete_picture.UseVisualStyleBackColor = true;
            this.btn_delete_picture.Click += new System.EventHandler(this.btn_delete_picture_Click);
            // 
            // bnt_add_picture
            // 
            this.bnt_add_picture.Location = new System.Drawing.Point(7, 355);
            this.bnt_add_picture.Margin = new System.Windows.Forms.Padding(2);
            this.bnt_add_picture.Name = "bnt_add_picture";
            this.bnt_add_picture.Size = new System.Drawing.Size(143, 42);
            this.bnt_add_picture.TabIndex = 2;
            this.bnt_add_picture.Text = "添加图片";
            this.bnt_add_picture.UseVisualStyleBackColor = true;
            this.bnt_add_picture.Click += new System.EventHandler(this.bnt_add_picture_Click);
            // 
            // listBox_acquire_picture
            // 
            this.listBox_acquire_picture.FormattingEnabled = true;
            this.listBox_acquire_picture.ItemHeight = 12;
            this.listBox_acquire_picture.Location = new System.Drawing.Point(87, 154);
            this.listBox_acquire_picture.Margin = new System.Windows.Forms.Padding(2);
            this.listBox_acquire_picture.Name = "listBox_acquire_picture";
            this.listBox_acquire_picture.Size = new System.Drawing.Size(280, 172);
            this.listBox_acquire_picture.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.label1.Location = new System.Drawing.Point(4, 148);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(78, 46);
            this.label1.TabIndex = 0;
            this.label1.Text = "图片列表：";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
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
            this.halconWinControl_11.Size = new System.Drawing.Size(440, 488);
            this.halconWinControl_11.TabIndex = 5;
            // 
            // AcqurieFrm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1028, 515);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.MinimizeBox = false;
            this.Name = "AcqurieFrm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "取图";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.acquriefrm_FormClosing);
            this.Load += new System.EventHandler(this.ParentFrm_Load);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label m_CtrlHStatusLabelCtrl;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.Button btn_remove_picture;
        private System.Windows.Forms.Button btn_delete_picture;
        private System.Windows.Forms.Button bnt_add_picture;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton tSB_run_one;
        private System.Windows.Forms.ListBox listBox_acquire_picture;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox Acquire;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton tSB_circulation_run;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripButton tSB_read_image;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox Registry_width;
        private System.Windows.Forms.TextBox Registry_height;
        private System.Windows.Forms.Button bnt_write_registry;
        private HalControl.HalconWinControl_1 halconWinControl_11;
    }
}