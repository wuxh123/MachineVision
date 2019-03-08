namespace MultTreeControlLibrary
{
    partial class MultTreeControl
    {
        /// <summary> 
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region 组件设计器生成的代码

        /// <summary> 
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MultTreeControl));
            this.toolStrip_main = new System.Windows.Forms.ToolStrip();
            this.but_add_detection = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.but_load_detection = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.tSB_run_again_check_stream = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.tSB_run_circulation_check_stream = new System.Windows.Forms.ToolStripButton();
            this.toolStrip_second = new System.Windows.Forms.ToolStrip();
            this.bnt_save_detection = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.bnt_anthor_save = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator6 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStrip_third = new System.Windows.Forms.ToolStrip();
            this.toolStripLabel1 = new System.Windows.Forms.ToolStripLabel();
            this.tSB_delection_box = new System.Windows.Forms.ToolStripComboBox();
            this.toolStripButton_Add_Detection = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton_delete_detection = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
            this.tSB_read_one_image = new System.Windows.Forms.ToolStripButton();
            this.statusStrip_main = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.tSB_time = new System.Windows.Forms.ToolStripStatusLabel();
            this.contextMenuStrip_treeview = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.跟前添加工具 = new System.Windows.Forms.ToolStripMenuItem();
            this.跟后添加工具 = new System.Windows.Forms.ToolStripMenuItem();
            this.插入工具 = new System.Windows.Forms.ToolStripMenuItem();
            this.删除工具 = new System.Windows.Forms.ToolStripMenuItem();
            this.treeVeiwImage = new System.Windows.Forms.ImageList(this.components);
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.tool_treeView = new System.Windows.Forms.TreeView();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.listBox2 = new System.Windows.Forms.ListBox();
            this.toolStrip_main.SuspendLayout();
            this.toolStrip_second.SuspendLayout();
            this.toolStrip_third.SuspendLayout();
            this.statusStrip_main.SuspendLayout();
            this.contextMenuStrip_treeview.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolStrip_main
            // 
            this.toolStrip_main.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.but_add_detection,
            this.toolStripSeparator1,
            this.but_load_detection,
            this.toolStripSeparator2,
            this.tSB_run_again_check_stream,
            this.toolStripSeparator3,
            this.tSB_run_circulation_check_stream});
            this.toolStrip_main.Location = new System.Drawing.Point(0, 0);
            this.toolStrip_main.Name = "toolStrip_main";
            this.toolStrip_main.Size = new System.Drawing.Size(406, 25);
            this.toolStrip_main.TabIndex = 0;
            this.toolStrip_main.Text = "toolStrip1";
            // 
            // but_add_detection
            // 
            this.but_add_detection.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.but_add_detection.Image = ((System.Drawing.Image)(resources.GetObject("but_add_detection.Image")));
            this.but_add_detection.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.but_add_detection.Name = "but_add_detection";
            this.but_add_detection.Size = new System.Drawing.Size(59, 22);
            this.but_add_detection.Text = "new检测";
            this.but_add_detection.Click += new System.EventHandler(this.but_add_detection_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // but_load_detection
            // 
            this.but_load_detection.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.but_load_detection.Image = ((System.Drawing.Image)(resources.GetObject("but_load_detection.Image")));
            this.but_load_detection.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.but_load_detection.Name = "but_load_detection";
            this.but_load_detection.Size = new System.Drawing.Size(66, 22);
            this.but_load_detection.Text = "open检测";
            this.but_load_detection.Click += new System.EventHandler(this.but_load_detection_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 25);
            // 
            // tSB_run_again_check_stream
            // 
            this.tSB_run_again_check_stream.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tSB_run_again_check_stream.Image = ((System.Drawing.Image)(resources.GetObject("tSB_run_again_check_stream.Image")));
            this.tSB_run_again_check_stream.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tSB_run_again_check_stream.Name = "tSB_run_again_check_stream";
            this.tSB_run_again_check_stream.Size = new System.Drawing.Size(60, 22);
            this.tSB_run_again_check_stream.Text = "单步运行";
            this.tSB_run_again_check_stream.Click += new System.EventHandler(this.tSB_run_again_check_stream_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(6, 25);
            // 
            // tSB_run_circulation_check_stream
            // 
            this.tSB_run_circulation_check_stream.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tSB_run_circulation_check_stream.Image = ((System.Drawing.Image)(resources.GetObject("tSB_run_circulation_check_stream.Image")));
            this.tSB_run_circulation_check_stream.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tSB_run_circulation_check_stream.Name = "tSB_run_circulation_check_stream";
            this.tSB_run_circulation_check_stream.Size = new System.Drawing.Size(60, 22);
            this.tSB_run_circulation_check_stream.Text = "循环运行";
            this.tSB_run_circulation_check_stream.Click += new System.EventHandler(this.tSB_run_circulation_check_stream_Click);
            // 
            // toolStrip_second
            // 
            this.toolStrip_second.Dock = System.Windows.Forms.DockStyle.Right;
            this.toolStrip_second.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.bnt_save_detection,
            this.toolStripSeparator4,
            this.bnt_anthor_save,
            this.toolStripSeparator6});
            this.toolStrip_second.Location = new System.Drawing.Point(357, 25);
            this.toolStrip_second.Name = "toolStrip_second";
            this.toolStrip_second.Size = new System.Drawing.Size(49, 485);
            this.toolStrip_second.TabIndex = 1;
            this.toolStrip_second.Text = "toolStrip2";
            // 
            // bnt_save_detection
            // 
            this.bnt_save_detection.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.bnt_save_detection.Image = ((System.Drawing.Image)(resources.GetObject("bnt_save_detection.Image")));
            this.bnt_save_detection.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.bnt_save_detection.Name = "bnt_save_detection";
            this.bnt_save_detection.Size = new System.Drawing.Size(46, 21);
            this.bnt_save_detection.Text = "保存";
            this.bnt_save_detection.Click += new System.EventHandler(this.bnt_save_detection_Click);
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(46, 6);
            // 
            // bnt_anthor_save
            // 
            this.bnt_anthor_save.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.bnt_anthor_save.Image = ((System.Drawing.Image)(resources.GetObject("bnt_anthor_save.Image")));
            this.bnt_anthor_save.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.bnt_anthor_save.Name = "bnt_anthor_save";
            this.bnt_anthor_save.Size = new System.Drawing.Size(46, 21);
            this.bnt_anthor_save.Text = "另存为";
            this.bnt_anthor_save.Click += new System.EventHandler(this.bnt_anthor_save_detection_Click);
            // 
            // toolStripSeparator6
            // 
            this.toolStripSeparator6.Name = "toolStripSeparator6";
            this.toolStripSeparator6.Size = new System.Drawing.Size(46, 6);
            // 
            // toolStrip_third
            // 
            this.toolStrip_third.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripLabel1,
            this.tSB_delection_box,
            this.toolStripButton_Add_Detection,
            this.toolStripButton_delete_detection,
            this.toolStripSeparator5,
            this.tSB_read_one_image});
            this.toolStrip_third.Location = new System.Drawing.Point(0, 25);
            this.toolStrip_third.Name = "toolStrip_third";
            this.toolStrip_third.Size = new System.Drawing.Size(357, 25);
            this.toolStrip_third.TabIndex = 2;
            this.toolStrip_third.Text = "toolStrip3";
            // 
            // toolStripLabel1
            // 
            this.toolStripLabel1.Name = "toolStripLabel1";
            this.toolStripLabel1.Size = new System.Drawing.Size(35, 22);
            this.toolStripLabel1.Text = "检测:";
            // 
            // tSB_delection_box
            // 
            this.tSB_delection_box.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.tSB_delection_box.Name = "tSB_delection_box";
            this.tSB_delection_box.Size = new System.Drawing.Size(92, 25);
            this.tSB_delection_box.SelectedIndexChanged += new System.EventHandler(this.tSB_delection_box_SelectedIndexChanged);
            // 
            // toolStripButton_Add_Detection
            // 
            this.toolStripButton_Add_Detection.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripButton_Add_Detection.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton_Add_Detection.Image")));
            this.toolStripButton_Add_Detection.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton_Add_Detection.Name = "toolStripButton_Add_Detection";
            this.toolStripButton_Add_Detection.Size = new System.Drawing.Size(84, 22);
            this.toolStripButton_Add_Detection.Text = "添加一个检测";
            this.toolStripButton_Add_Detection.Click += new System.EventHandler(this.toolStripButton_Add_Detection_Click);
            // 
            // toolStripButton_delete_detection
            // 
            this.toolStripButton_delete_detection.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripButton_delete_detection.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton_delete_detection.Image")));
            this.toolStripButton_delete_detection.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton_delete_detection.Name = "toolStripButton_delete_detection";
            this.toolStripButton_delete_detection.Size = new System.Drawing.Size(84, 22);
            this.toolStripButton_delete_detection.Text = "删除一个检测";
            this.toolStripButton_delete_detection.Click += new System.EventHandler(this.toolStripButton_delete_detection_Click);
            // 
            // toolStripSeparator5
            // 
            this.toolStripSeparator5.Name = "toolStripSeparator5";
            this.toolStripSeparator5.Size = new System.Drawing.Size(6, 25);
            // 
            // tSB_read_one_image
            // 
            this.tSB_read_one_image.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tSB_read_one_image.Image = ((System.Drawing.Image)(resources.GetObject("tSB_read_one_image.Image")));
            this.tSB_read_one_image.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tSB_read_one_image.Name = "tSB_read_one_image";
            this.tSB_read_one_image.Size = new System.Drawing.Size(60, 21);
            this.tSB_read_one_image.Text = "取图一张";
            this.tSB_read_one_image.Click += new System.EventHandler(this.tSB_read_one_image_Click);
            // 
            // statusStrip_main
            // 
            this.statusStrip_main.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1,
            this.tSB_time});
            this.statusStrip_main.Location = new System.Drawing.Point(0, 488);
            this.statusStrip_main.Name = "statusStrip_main";
            this.statusStrip_main.Padding = new System.Windows.Forms.Padding(1, 0, 10, 0);
            this.statusStrip_main.Size = new System.Drawing.Size(357, 22);
            this.statusStrip_main.TabIndex = 3;
            this.statusStrip_main.Text = "statusStrip1";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(71, 17);
            this.toolStripStatusLabel1.Text = "运行的时间:";
            // 
            // tSB_time
            // 
            this.tSB_time.Name = "tSB_time";
            this.tSB_time.Size = new System.Drawing.Size(60, 17);
            this.tSB_time.Text = "message";
            // 
            // contextMenuStrip_treeview
            // 
            this.contextMenuStrip_treeview.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.contextMenuStrip_treeview.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.跟前添加工具,
            this.跟后添加工具,
            this.插入工具,
            this.删除工具});
            this.contextMenuStrip_treeview.Name = "contextMenuStrip1";
            this.contextMenuStrip_treeview.Size = new System.Drawing.Size(149, 92);
            // 
            // 跟前添加工具
            // 
            this.跟前添加工具.Name = "跟前添加工具";
            this.跟前添加工具.Size = new System.Drawing.Size(148, 22);
            this.跟前添加工具.Text = "跟前添加工具";
            this.跟前添加工具.Click += new System.EventHandler(this.跟前添加工具_Click);
            // 
            // 跟后添加工具
            // 
            this.跟后添加工具.Name = "跟后添加工具";
            this.跟后添加工具.Size = new System.Drawing.Size(148, 22);
            this.跟后添加工具.Text = "跟后添加工具";
            this.跟后添加工具.Click += new System.EventHandler(this.跟后添加工具_Click);
            // 
            // 插入工具
            // 
            this.插入工具.Name = "插入工具";
            this.插入工具.Size = new System.Drawing.Size(148, 22);
            this.插入工具.Text = "插入工具";
            this.插入工具.Click += new System.EventHandler(this.插入工具_Click);
            // 
            // 删除工具
            // 
            this.删除工具.Name = "删除工具";
            this.删除工具.Size = new System.Drawing.Size(148, 22);
            this.删除工具.Text = "删除工具";
            this.删除工具.Click += new System.EventHandler(this.删除工具_Click);
            // 
            // treeVeiwImage
            // 
            this.treeVeiwImage.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("treeVeiwImage.ImageStream")));
            this.treeVeiwImage.TransparentColor = System.Drawing.Color.Transparent;
            this.treeVeiwImage.Images.SetKeyName(0, "appbackground.png");
            this.treeVeiwImage.Images.SetKeyName(1, "ok.png");
            this.treeVeiwImage.Images.SetKeyName(2, "fail.png");
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.tool_treeView, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel2, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 50);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(2);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(357, 438);
            this.tableLayoutPanel1.TabIndex = 5;
            // 
            // tool_treeView
            // 
            this.tool_treeView.ContextMenuStrip = this.contextMenuStrip_treeview;
            this.tool_treeView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tool_treeView.ImageIndex = 0;
            this.tool_treeView.ImageList = this.treeVeiwImage;
            this.tool_treeView.Location = new System.Drawing.Point(180, 2);
            this.tool_treeView.Margin = new System.Windows.Forms.Padding(2);
            this.tool_treeView.Name = "tool_treeView";
            this.tool_treeView.SelectedImageIndex = 0;
            this.tool_treeView.Size = new System.Drawing.Size(175, 434);
            this.tool_treeView.TabIndex = 0;
            this.tool_treeView.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.tool_treeView_AfterSelect);
            this.tool_treeView.DoubleClick += new System.EventHandler(this.tool_treeView_DoubleClick);
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 1;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Controls.Add(this.listBox1, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.listBox2, 0, 1);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 2;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 67.36111F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 32.63889F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(172, 432);
            this.tableLayoutPanel2.TabIndex = 1;
            // 
            // listBox1
            // 
            this.listBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listBox1.FormattingEnabled = true;
            this.listBox1.ItemHeight = 12;
            this.listBox1.Location = new System.Drawing.Point(3, 3);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(166, 284);
            this.listBox1.TabIndex = 0;
            // 
            // listBox2
            // 
            this.listBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listBox2.FormattingEnabled = true;
            this.listBox2.ItemHeight = 12;
            this.listBox2.Location = new System.Drawing.Point(3, 293);
            this.listBox2.Name = "listBox2";
            this.listBox2.Size = new System.Drawing.Size(166, 136);
            this.listBox2.TabIndex = 1;
            // 
            // MultTreeControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.statusStrip_main);
            this.Controls.Add(this.toolStrip_third);
            this.Controls.Add(this.toolStrip_second);
            this.Controls.Add(this.toolStrip_main);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "MultTreeControl";
            this.Size = new System.Drawing.Size(406, 510);
            this.toolStrip_main.ResumeLayout(false);
            this.toolStrip_main.PerformLayout();
            this.toolStrip_second.ResumeLayout(false);
            this.toolStrip_second.PerformLayout();
            this.toolStrip_third.ResumeLayout(false);
            this.toolStrip_third.PerformLayout();
            this.statusStrip_main.ResumeLayout(false);
            this.statusStrip_main.PerformLayout();
            this.contextMenuStrip_treeview.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip_main;
        private System.Windows.Forms.ToolStripButton but_add_detection;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton but_load_detection;
        private System.Windows.Forms.ToolStrip toolStrip_second;
        private System.Windows.Forms.ToolStrip toolStrip_third;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripButton tSB_run_again_check_stream;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripButton tSB_run_circulation_check_stream;
        private System.Windows.Forms.ToolStripButton bnt_save_detection;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.ToolStripButton bnt_anthor_save;
        private System.Windows.Forms.ToolStripLabel toolStripLabel1;
        private System.Windows.Forms.ToolStripComboBox tSB_delection_box;
        private System.Windows.Forms.StatusStrip statusStrip_main;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator5;
        private System.Windows.Forms.ToolStripButton tSB_read_one_image;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip_treeview;
        private System.Windows.Forms.ToolStripMenuItem 跟前添加工具;
        private System.Windows.Forms.ToolStripMenuItem 跟后添加工具;
        private System.Windows.Forms.ToolStripMenuItem 插入工具;
        private System.Windows.Forms.ToolStripMenuItem 删除工具;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator6;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.ToolStripStatusLabel tSB_time;
        private System.Windows.Forms.ImageList treeVeiwImage;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.TreeView tool_treeView;
        private System.Windows.Forms.ToolStripButton toolStripButton_Add_Detection;
        private System.Windows.Forms.ToolStripButton toolStripButton_delete_detection;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.ListBox listBox2;
    }
}
