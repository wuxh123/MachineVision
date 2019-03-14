namespace TcpIpLibrary
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
            this.textBox_IP = new System.Windows.Forms.TextBox();
            this.textBox_DuanKou = new System.Windows.Forms.TextBox();
            this.button_QueDingIpDiGenShuJu = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.richTextBox_FaSongDeShuJu = new System.Windows.Forms.RichTextBox();
            this.button_FaSong = new System.Windows.Forms.Button();
            this.button_QingKong = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.button_QingKongJieShouDeShuJu = new System.Windows.Forms.Button();
            this.richTextBox_JieShouDeShuJu = new System.Windows.Forms.RichTextBox();
            this.label_keHuDuanZhuanTai = new System.Windows.Forms.Label();
            this.label_fuWuDuanZhuanTai = new System.Windows.Forms.Label();
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
            this.label2.Location = new System.Drawing.Point(12, 40);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 12);
            this.label2.TabIndex = 1;
            this.label2.Text = "端口号：";
            // 
            // textBox_IP
            // 
            this.textBox_IP.Location = new System.Drawing.Point(82, 6);
            this.textBox_IP.Name = "textBox_IP";
            this.textBox_IP.Size = new System.Drawing.Size(120, 21);
            this.textBox_IP.TabIndex = 2;
            // 
            // textBox_DuanKou
            // 
            this.textBox_DuanKou.Location = new System.Drawing.Point(82, 37);
            this.textBox_DuanKou.Name = "textBox_DuanKou";
            this.textBox_DuanKou.Size = new System.Drawing.Size(120, 21);
            this.textBox_DuanKou.TabIndex = 3;
            // 
            // button_QueDingIpDiGenShuJu
            // 
            this.button_QueDingIpDiGenShuJu.Location = new System.Drawing.Point(208, 6);
            this.button_QueDingIpDiGenShuJu.Name = "button_QueDingIpDiGenShuJu";
            this.button_QueDingIpDiGenShuJu.Size = new System.Drawing.Size(88, 52);
            this.button_QueDingIpDiGenShuJu.TabIndex = 4;
            this.button_QueDingIpDiGenShuJu.Text = "确定数据";
            this.button_QueDingIpDiGenShuJu.UseVisualStyleBackColor = true;
            this.button_QueDingIpDiGenShuJu.Click += new System.EventHandler(this.button_QueDingIpDiGenShuJu_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 133);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(65, 12);
            this.label3.TabIndex = 5;
            this.label3.Text = "发送数据：";
            // 
            // richTextBox_FaSongDeShuJu
            // 
            this.richTextBox_FaSongDeShuJu.Location = new System.Drawing.Point(82, 113);
            this.richTextBox_FaSongDeShuJu.Name = "richTextBox_FaSongDeShuJu";
            this.richTextBox_FaSongDeShuJu.Size = new System.Drawing.Size(214, 58);
            this.richTextBox_FaSongDeShuJu.TabIndex = 6;
            this.richTextBox_FaSongDeShuJu.Text = "000000";
            // 
            // button_FaSong
            // 
            this.button_FaSong.Location = new System.Drawing.Point(82, 185);
            this.button_FaSong.Name = "button_FaSong";
            this.button_FaSong.Size = new System.Drawing.Size(91, 36);
            this.button_FaSong.TabIndex = 7;
            this.button_FaSong.Text = "发送";
            this.button_FaSong.UseVisualStyleBackColor = true;
            this.button_FaSong.Click += new System.EventHandler(this.button_FaSong_Click);
            // 
            // button_QingKong
            // 
            this.button_QingKong.Location = new System.Drawing.Point(205, 185);
            this.button_QingKong.Name = "button_QingKong";
            this.button_QingKong.Size = new System.Drawing.Size(91, 36);
            this.button_QingKong.TabIndex = 8;
            this.button_QingKong.Text = "清空";
            this.button_QingKong.UseVisualStyleBackColor = true;
            this.button_QingKong.Click += new System.EventHandler(this.button_QingKong_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 261);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(65, 12);
            this.label4.TabIndex = 9;
            this.label4.Text = "接收的数据";
            // 
            // button_QingKongJieShouDeShuJu
            // 
            this.button_QingKongJieShouDeShuJu.Location = new System.Drawing.Point(82, 316);
            this.button_QingKongJieShouDeShuJu.Name = "button_QingKongJieShouDeShuJu";
            this.button_QingKongJieShouDeShuJu.Size = new System.Drawing.Size(214, 36);
            this.button_QingKongJieShouDeShuJu.TabIndex = 12;
            this.button_QingKongJieShouDeShuJu.Text = "清空接受的数据";
            this.button_QingKongJieShouDeShuJu.UseVisualStyleBackColor = true;
            this.button_QingKongJieShouDeShuJu.Click += new System.EventHandler(this.button_QingKongJieShouDeShuJu_Click);
            // 
            // richTextBox_JieShouDeShuJu
            // 
            this.richTextBox_JieShouDeShuJu.Location = new System.Drawing.Point(82, 244);
            this.richTextBox_JieShouDeShuJu.Name = "richTextBox_JieShouDeShuJu";
            this.richTextBox_JieShouDeShuJu.Size = new System.Drawing.Size(214, 58);
            this.richTextBox_JieShouDeShuJu.TabIndex = 10;
            this.richTextBox_JieShouDeShuJu.Text = "";
            // 
            // label_keHuDuanZhuanTai
            // 
            this.label_keHuDuanZhuanTai.AutoSize = true;
            this.label_keHuDuanZhuanTai.Location = new System.Drawing.Point(45, 77);
            this.label_keHuDuanZhuanTai.Name = "label_keHuDuanZhuanTai";
            this.label_keHuDuanZhuanTai.Size = new System.Drawing.Size(65, 12);
            this.label_keHuDuanZhuanTai.TabIndex = 13;
            this.label_keHuDuanZhuanTai.Text = "客户端连接";
            // 
            // label_fuWuDuanZhuanTai
            // 
            this.label_fuWuDuanZhuanTai.AutoSize = true;
            this.label_fuWuDuanZhuanTai.Location = new System.Drawing.Point(203, 77);
            this.label_fuWuDuanZhuanTai.Name = "label_fuWuDuanZhuanTai";
            this.label_fuWuDuanZhuanTai.Size = new System.Drawing.Size(65, 12);
            this.label_fuWuDuanZhuanTai.TabIndex = 14;
            this.label_fuWuDuanZhuanTai.Text = "服务端链接";
            // 
            // TCPIPFrm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(324, 373);
            this.Controls.Add(this.label_fuWuDuanZhuanTai);
            this.Controls.Add(this.label_keHuDuanZhuanTai);
            this.Controls.Add(this.button_QingKongJieShouDeShuJu);
            this.Controls.Add(this.richTextBox_JieShouDeShuJu);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.button_QingKong);
            this.Controls.Add(this.button_FaSong);
            this.Controls.Add(this.richTextBox_FaSongDeShuJu);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.button_QueDingIpDiGenShuJu);
            this.Controls.Add(this.textBox_DuanKou);
            this.Controls.Add(this.textBox_IP);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "TCPIPFrm";
            this.Text = "TCPIP";
            this.Load += new System.EventHandler(this.TCPIPFrm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBox_IP;
        private System.Windows.Forms.TextBox textBox_DuanKou;
        private System.Windows.Forms.Button button_QueDingIpDiGenShuJu;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.RichTextBox richTextBox_FaSongDeShuJu;
        private System.Windows.Forms.Button button_FaSong;
        private System.Windows.Forms.Button button_QingKong;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button button_QingKongJieShouDeShuJu;
        private System.Windows.Forms.RichTextBox richTextBox_JieShouDeShuJu;
        private System.Windows.Forms.Label label_keHuDuanZhuanTai;
        private System.Windows.Forms.Label label_fuWuDuanZhuanTai;
    }
}