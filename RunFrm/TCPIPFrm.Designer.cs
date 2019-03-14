namespace RunFrm
{
    partial class TCPIPFrm
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.textBox_ipDiZhi = new System.Windows.Forms.TextBox();
            this.textBox_duanKouHao = new System.Windows.Forms.TextBox();
            this.button_chuangJianFuWuDuan = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.richTextBox_FaSongShuJu = new System.Windows.Forms.RichTextBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "ip地址：";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 36);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 12);
            this.label2.TabIndex = 1;
            this.label2.Text = "端口号：";
            // 
            // textBox_ipDiZhi
            // 
            this.textBox_ipDiZhi.Location = new System.Drawing.Point(71, 6);
            this.textBox_ipDiZhi.Name = "textBox_ipDiZhi";
            this.textBox_ipDiZhi.Size = new System.Drawing.Size(207, 21);
            this.textBox_ipDiZhi.TabIndex = 2;
            this.textBox_ipDiZhi.Text = "192.168.1.200";
            // 
            // textBox_duanKouHao
            // 
            this.textBox_duanKouHao.Location = new System.Drawing.Point(71, 33);
            this.textBox_duanKouHao.Name = "textBox_duanKouHao";
            this.textBox_duanKouHao.Size = new System.Drawing.Size(207, 21);
            this.textBox_duanKouHao.TabIndex = 3;
            this.textBox_duanKouHao.Text = "5000";
            // 
            // button_chuangJianFuWuDuan
            // 
            this.button_chuangJianFuWuDuan.Location = new System.Drawing.Point(71, 60);
            this.button_chuangJianFuWuDuan.Name = "button_chuangJianFuWuDuan";
            this.button_chuangJianFuWuDuan.Size = new System.Drawing.Size(207, 32);
            this.button_chuangJianFuWuDuan.TabIndex = 5;
            this.button_chuangJianFuWuDuan.Text = "创建服务端";
            this.button_chuangJianFuWuDuan.UseVisualStyleBackColor = true;
            this.button_chuangJianFuWuDuan.Click += new System.EventHandler(this.button_chuangJianFuWuDuan_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 109);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(101, 12);
            this.label3.TabIndex = 6;
            this.label3.Text = "服务端接收数据：";
            // 
            // richTextBox_FaSongShuJu
            // 
            this.richTextBox_FaSongShuJu.Location = new System.Drawing.Point(71, 133);
            this.richTextBox_FaSongShuJu.Name = "richTextBox_FaSongShuJu";
            this.richTextBox_FaSongShuJu.Size = new System.Drawing.Size(207, 61);
            this.richTextBox_FaSongShuJu.TabIndex = 7;
            this.richTextBox_FaSongShuJu.Text = "";
            // 
            // TCPIPFrm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(343, 267);
            this.Controls.Add(this.richTextBox_FaSongShuJu);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.button_chuangJianFuWuDuan);
            this.Controls.Add(this.textBox_duanKouHao);
            this.Controls.Add(this.textBox_ipDiZhi);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "TCPIPFrm";
            this.Text = "TCPIP";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBox_ipDiZhi;
        private System.Windows.Forms.TextBox textBox_duanKouHao;
        private System.Windows.Forms.Button button_chuangJianFuWuDuan;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.RichTextBox richTextBox_FaSongShuJu;
    }
}