namespace HalControl
{
    partial class HalconWinControl
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
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(HalconWinControl));
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.bnt_fit_window = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.bnt_save_image = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripLabel1 = new System.Windows.Forms.ToolStripLabel();
            this.com_show_color = new System.Windows.Forms.ToolStripComboBox();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.status_message = new System.Windows.Forms.StatusStrip();
            this.StatusMessage = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStrip1.SuspendLayout();
            this.status_message.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.bnt_fit_window,
            this.toolStripSeparator1,
            this.bnt_save_image,
            this.toolStripSeparator2,
            this.toolStripLabel1,
            this.com_show_color,
            this.toolStripSeparator3});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(534, 28);
            this.toolStrip1.TabIndex = 2;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // bnt_fit_window
            // 
            this.bnt_fit_window.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.bnt_fit_window.Image = ((System.Drawing.Image)(resources.GetObject("bnt_fit_window.Image")));
            this.bnt_fit_window.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.bnt_fit_window.Name = "bnt_fit_window";
            this.bnt_fit_window.Size = new System.Drawing.Size(73, 25);
            this.bnt_fit_window.Text = "适应窗口";
            this.bnt_fit_window.Click += new System.EventHandler(this.bnt_fit_window_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 28);
            // 
            // bnt_save_image
            // 
            this.bnt_save_image.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.bnt_save_image.Image = ((System.Drawing.Image)(resources.GetObject("bnt_save_image.Image")));
            this.bnt_save_image.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.bnt_save_image.Name = "bnt_save_image";
            this.bnt_save_image.Size = new System.Drawing.Size(73, 25);
            this.bnt_save_image.Text = "保存图片";
            this.bnt_save_image.Click += new System.EventHandler(this.bnt_save_image_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 28);
            // 
            // toolStripLabel1
            // 
            this.toolStripLabel1.Name = "toolStripLabel1";
            this.toolStripLabel1.Size = new System.Drawing.Size(103, 25);
            this.toolStripLabel1.Text = "设置窗口颜色:";
            // 
            // com_show_color
            // 
            this.com_show_color.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.com_show_color.Items.AddRange(new object[] {
            "red",
            "green"});
            this.com_show_color.Name = "com_show_color";
            this.com_show_color.Size = new System.Drawing.Size(121, 28);
            this.com_show_color.SelectedIndexChanged += new System.EventHandler(this.toolStripComboBox1_SelectedIndexChanged);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(6, 28);
            // 
            // status_message
            // 
            this.status_message.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.status_message.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.StatusMessage});
            this.status_message.Location = new System.Drawing.Point(0, 440);
            this.status_message.Name = "status_message";
            this.status_message.Size = new System.Drawing.Size(534, 25);
            this.status_message.TabIndex = 3;
            this.status_message.Text = "statusStrip1";
            // 
            // StatusMessage
            // 
            this.StatusMessage.Name = "StatusMessage";
            this.StatusMessage.Size = new System.Drawing.Size(73, 20);
            this.StatusMessage.Text = "message";
            // 
            // HalconWinControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.status_message);
            this.Controls.Add(this.toolStrip1);
            this.Name = "HalconWinControl";
            this.Size = new System.Drawing.Size(534, 465);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.status_message.ResumeLayout(false);
            this.status_message.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton bnt_fit_window;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton bnt_save_image;
        private System.Windows.Forms.StatusStrip status_message;
        private System.Windows.Forms.ToolStripStatusLabel StatusMessage;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripComboBox com_show_color;
        private System.Windows.Forms.ToolStripLabel toolStripLabel1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
    }
}
