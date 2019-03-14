namespace DaHuaLibrary.UI
{
    partial class DaHuaCamerFrm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DaHuaCamerFrm));
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.m_CtrlHStatusLabelCtrl = new System.Windows.Forms.Label();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.tSB_run_one = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.tSB_circulation_run = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.tSB_read_image = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.tSB_trigger = new System.Windows.Forms.ToolStripButton();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btn_remove_picture = new System.Windows.Forms.Button();
            this.btn_delete_picture = new System.Windows.Forms.Button();
            this.bnt_add_picture = new System.Windows.Forms.Button();
            this.listBox_acquire_picture = new System.Windows.Forms.ListBox();
            this.label1 = new System.Windows.Forms.Label();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.Device_Number = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.bnt_que_ding_xiangji_bao_guang = new System.Windows.Forms.Button();
            this.TriggerSourceenum = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.Gainraw = new System.Windows.Forms.TextBox();
            this.Exposuretime = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.CamerIndx1 = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.halconWinControl_11 = new HalControl.HalconWinControl_1();
            this.tableLayoutPanel1.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 3;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 48.13028F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 51.86972F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 114F));
            this.tableLayoutPanel1.Controls.Add(this.m_CtrlHStatusLabelCtrl, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.toolStrip1, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this.tabControl1, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.halconWinControl_11, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 95.63795F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 4.36205F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1460, 617);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // m_CtrlHStatusLabelCtrl
            // 
            this.m_CtrlHStatusLabelCtrl.AutoSize = true;
            this.m_CtrlHStatusLabelCtrl.Location = new System.Drawing.Point(3, 590);
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
            this.toolStripSeparator2,
            this.tSB_circulation_run,
            this.toolStripSeparator1,
            this.tSB_read_image,
            this.toolStripSeparator3,
            this.tSB_trigger});
            this.toolStrip1.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.VerticalStackWithOverflow;
            this.toolStrip1.Location = new System.Drawing.Point(1345, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(115, 137);
            this.toolStrip1.TabIndex = 3;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // tSB_run_one
            // 
            this.tSB_run_one.Image = ((System.Drawing.Image)(resources.GetObject("tSB_run_one.Image")));
            this.tSB_run_one.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tSB_run_one.Name = "tSB_run_one";
            this.tSB_run_one.Size = new System.Drawing.Size(113, 24);
            this.tSB_run_one.Text = "运行";
            this.tSB_run_one.Click += new System.EventHandler(this.tSB_run_one_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(183, 6);
            // 
            // tSB_circulation_run
            // 
            this.tSB_circulation_run.Image = ((System.Drawing.Image)(resources.GetObject("tSB_circulation_run.Image")));
            this.tSB_circulation_run.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tSB_circulation_run.Name = "tSB_circulation_run";
            this.tSB_circulation_run.Size = new System.Drawing.Size(183, 24);
            this.tSB_circulation_run.Text = "循环运行";
            this.tSB_circulation_run.Click += new System.EventHandler(this.tSB_circulation_run_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(183, 6);
            // 
            // tSB_read_image
            // 
            this.tSB_read_image.Image = ((System.Drawing.Image)(resources.GetObject("tSB_read_image.Image")));
            this.tSB_read_image.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tSB_read_image.Name = "tSB_read_image";
            this.tSB_read_image.Size = new System.Drawing.Size(183, 24);
            this.tSB_read_image.Text = "取一张图片";
            this.tSB_read_image.Click += new System.EventHandler(this.tSB_read_image_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(183, 6);
            // 
            // tSB_trigger
            // 
            this.tSB_trigger.Image = ((System.Drawing.Image)(resources.GetObject("tSB_trigger.Image")));
            this.tSB_trigger.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tSB_trigger.Name = "tSB_trigger";
            this.tSB_trigger.Size = new System.Drawing.Size(183, 24);
            this.tSB_trigger.Text = "软触发相机";
            this.tSB_trigger.Click += new System.EventHandler(this.tSB_trigger_Click);
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(650, 3);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(692, 584);
            this.tabControl1.TabIndex = 2;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.groupBox1);
            this.tabPage1.Location = new System.Drawing.Point(4, 25);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(684, 555);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "取图";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.comboBox1);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.btn_remove_picture);
            this.groupBox1.Controls.Add(this.btn_delete_picture);
            this.groupBox1.Controls.Add(this.bnt_add_picture);
            this.groupBox1.Controls.Add(this.listBox_acquire_picture);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox1.Location = new System.Drawing.Point(3, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(678, 672);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "取图";
            // 
            // comboBox1
            // 
            this.comboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Items.AddRange(new object[] {
            "大华相机取图",
            "文件夹取图"});
            this.comboBox1.Location = new System.Drawing.Point(113, 38);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(527, 23);
            this.comboBox1.TabIndex = 6;
            this.comboBox1.Visible = false;
            // 
            // label2
            // 
            this.label2.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.label2.Location = new System.Drawing.Point(6, 36);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(101, 25);
            this.label2.TabIndex = 5;
            this.label2.Text = "取图方式：";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.label2.Visible = false;
            // 
            // btn_remove_picture
            // 
            this.btn_remove_picture.Location = new System.Drawing.Point(493, 319);
            this.btn_remove_picture.Name = "btn_remove_picture";
            this.btn_remove_picture.Size = new System.Drawing.Size(158, 51);
            this.btn_remove_picture.TabIndex = 4;
            this.btn_remove_picture.Text = "移除图片";
            this.btn_remove_picture.UseVisualStyleBackColor = true;
            this.btn_remove_picture.Click += new System.EventHandler(this.btn_remove_picture_Click);
            // 
            // btn_delete_picture
            // 
            this.btn_delete_picture.Location = new System.Drawing.Point(259, 318);
            this.btn_delete_picture.Name = "btn_delete_picture";
            this.btn_delete_picture.Size = new System.Drawing.Size(185, 52);
            this.btn_delete_picture.TabIndex = 3;
            this.btn_delete_picture.Text = "删除图片";
            this.btn_delete_picture.UseVisualStyleBackColor = true;
            this.btn_delete_picture.Click += new System.EventHandler(this.btn_delete_picture_Click);
            // 
            // bnt_add_picture
            // 
            this.bnt_add_picture.Location = new System.Drawing.Point(6, 319);
            this.bnt_add_picture.Name = "bnt_add_picture";
            this.bnt_add_picture.Size = new System.Drawing.Size(191, 53);
            this.bnt_add_picture.TabIndex = 2;
            this.bnt_add_picture.Text = "添加图片";
            this.bnt_add_picture.UseVisualStyleBackColor = true;
            this.bnt_add_picture.Click += new System.EventHandler(this.bnt_add_picture_Click);
            // 
            // listBox_acquire_picture
            // 
            this.listBox_acquire_picture.FormattingEnabled = true;
            this.listBox_acquire_picture.ItemHeight = 15;
            this.listBox_acquire_picture.Location = new System.Drawing.Point(113, 67);
            this.listBox_acquire_picture.Name = "listBox_acquire_picture";
            this.listBox_acquire_picture.Size = new System.Drawing.Size(527, 214);
            this.listBox_acquire_picture.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.label1.Location = new System.Drawing.Point(3, 60);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(104, 57);
            this.label1.TabIndex = 0;
            this.label1.Text = "图片列表：";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.Device_Number);
            this.tabPage2.Controls.Add(this.button1);
            this.tabPage2.Controls.Add(this.label7);
            this.tabPage2.Controls.Add(this.bnt_que_ding_xiangji_bao_guang);
            this.tabPage2.Controls.Add(this.TriggerSourceenum);
            this.tabPage2.Controls.Add(this.label6);
            this.tabPage2.Controls.Add(this.Gainraw);
            this.tabPage2.Controls.Add(this.Exposuretime);
            this.tabPage2.Controls.Add(this.label5);
            this.tabPage2.Controls.Add(this.label4);
            this.tabPage2.Controls.Add(this.CamerIndx1);
            this.tabPage2.Controls.Add(this.label3);
            this.tabPage2.Location = new System.Drawing.Point(4, 25);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Size = new System.Drawing.Size(883, 841);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "相机参数";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // Device_Number
            // 
            this.Device_Number.Location = new System.Drawing.Point(136, 47);
            this.Device_Number.Name = "Device_Number";
            this.Device_Number.Size = new System.Drawing.Size(251, 23);
            this.Device_Number.TabIndex = 12;
            this.Device_Number.Text = "Device_Number";
            this.Device_Number.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(407, 47);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(204, 23);
            this.button1.TabIndex = 11;
            this.button1.Text = "获取相机驱动个数";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(3, 50);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(82, 15);
            this.label7.TabIndex = 9;
            this.label7.Text = "相机个数：";
            // 
            // bnt_que_ding_xiangji_bao_guang
            // 
            this.bnt_que_ding_xiangji_bao_guang.Location = new System.Drawing.Point(407, 190);
            this.bnt_que_ding_xiangji_bao_guang.Name = "bnt_que_ding_xiangji_bao_guang";
            this.bnt_que_ding_xiangji_bao_guang.Size = new System.Drawing.Size(204, 75);
            this.bnt_que_ding_xiangji_bao_guang.TabIndex = 8;
            this.bnt_que_ding_xiangji_bao_guang.Text = "确定相机曝光增益";
            this.bnt_que_ding_xiangji_bao_guang.UseVisualStyleBackColor = true;
            this.bnt_que_ding_xiangji_bao_guang.Click += new System.EventHandler(this.bnt_que_ding_xiangji_bao_guang_Click);
            // 
            // TriggerSourceenum
            // 
            this.TriggerSourceenum.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.TriggerSourceenum.FormattingEnabled = true;
            this.TriggerSourceenum.Items.AddRange(new object[] {
            "Software",
            "Line1",
            "Line2"});
            this.TriggerSourceenum.Location = new System.Drawing.Point(136, 138);
            this.TriggerSourceenum.Name = "TriggerSourceenum";
            this.TriggerSourceenum.Size = new System.Drawing.Size(251, 23);
            this.TriggerSourceenum.TabIndex = 7;
            this.TriggerSourceenum.SelectedIndexChanged += new System.EventHandler(this.TriggerSourceenum_SelectedIndexChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(3, 143);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(112, 15);
            this.label6.TabIndex = 6;
            this.label6.Text = "相机触发模式：";
            // 
            // Gainraw
            // 
            this.Gainraw.Location = new System.Drawing.Point(136, 234);
            this.Gainraw.Name = "Gainraw";
            this.Gainraw.Size = new System.Drawing.Size(251, 25);
            this.Gainraw.TabIndex = 5;
            // 
            // Exposuretime
            // 
            this.Exposuretime.Location = new System.Drawing.Point(136, 190);
            this.Exposuretime.Name = "Exposuretime";
            this.Exposuretime.Size = new System.Drawing.Size(251, 25);
            this.Exposuretime.TabIndex = 4;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(3, 237);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(82, 15);
            this.label5.TabIndex = 3;
            this.label5.Text = "相机增益：";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(3, 193);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(82, 15);
            this.label4.TabIndex = 2;
            this.label4.Text = "相机曝光：";
            // 
            // CamerIndx1
            // 
            this.CamerIndx1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CamerIndx1.FormattingEnabled = true;
            this.CamerIndx1.Items.AddRange(new object[] {
            "0",
            "1",
            "2",
            "3",
            "4",
            "5",
            "6",
            "7",
            "8",
            "9"});
            this.CamerIndx1.Location = new System.Drawing.Point(136, 90);
            this.CamerIndx1.Name = "CamerIndx1";
            this.CamerIndx1.Size = new System.Drawing.Size(251, 23);
            this.CamerIndx1.TabIndex = 1;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(3, 93);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(127, 15);
            this.label3.TabIndex = 0;
            this.label3.Text = "绑定第几个相机：";
            // 
            // halconWinControl_11
            // 
            this.halconWinControl_11.Dock = System.Windows.Forms.DockStyle.Fill;
         //   this.halconWinControl_11.Exit_Image = false;
            this.halconWinControl_11.HalconWindow1 = null;
            this.halconWinControl_11.Ho_Image = null;
            this.halconWinControl_11.Location = new System.Drawing.Point(3, 3);
            this.halconWinControl_11.Name = "halconWinControl_11";
            this.halconWinControl_11.Size = new System.Drawing.Size(641, 584);
            this.halconWinControl_11.TabIndex = 5;
            // 
            // DaHuaCamerFrm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1460, 617);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "DaHuaCamerFrm";
            this.Text = "大华相机";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.acquriefrm_FormClosing);
            this.Load += new System.EventHandler(this.ParentFrm_Load);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label m_CtrlHStatusLabelCtrl;
        private System.Windows.Forms.ToolStripButton tSB_circulation_run;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.Button btn_remove_picture;
        private System.Windows.Forms.Button btn_delete_picture;
        private System.Windows.Forms.Button bnt_add_picture;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton tSB_run_one;
        private System.Windows.Forms.ToolStripButton tSB_read_image;
        private System.Windows.Forms.ListBox listBox_acquire_picture;
        private HalControl.HalconWinControl_1 halconWinControl_11;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox CamerIndx1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox Gainraw;
        private System.Windows.Forms.TextBox Exposuretime;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox TriggerSourceenum;
        private System.Windows.Forms.Button bnt_que_ding_xiangji_bao_guang;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripButton tSB_trigger;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label Device_Number;
    }
}