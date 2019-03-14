namespace ZhuCeRuanJianLibrary.UI
{
    partial class ZhuCeRuanJianFrm
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
            this.textBox_JiQiMa = new System.Windows.Forms.TextBox();
            this.textBox_ZhuCeMa = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.button_ZhuCeRuanJian = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(31, 56);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(67, 15);
            this.label1.TabIndex = 0;
            this.label1.Text = "机器码：";
            // 
            // textBox_JiQiMa
            // 
            this.textBox_JiQiMa.Location = new System.Drawing.Point(104, 53);
            this.textBox_JiQiMa.Name = "textBox_JiQiMa";
            this.textBox_JiQiMa.Size = new System.Drawing.Size(577, 25);
            this.textBox_JiQiMa.TabIndex = 1;
            // 
            // textBox_ZhuCeMa
            // 
            this.textBox_ZhuCeMa.Location = new System.Drawing.Point(104, 108);
            this.textBox_ZhuCeMa.Name = "textBox_ZhuCeMa";
            this.textBox_ZhuCeMa.Size = new System.Drawing.Size(577, 25);
            this.textBox_ZhuCeMa.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(31, 111);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(67, 15);
            this.label2.TabIndex = 2;
            this.label2.Text = "注册码：";
            // 
            // button_ZhuCeRuanJian
            // 
            this.button_ZhuCeRuanJian.Location = new System.Drawing.Point(34, 176);
            this.button_ZhuCeRuanJian.Name = "button_ZhuCeRuanJian";
            this.button_ZhuCeRuanJian.Size = new System.Drawing.Size(646, 39);
            this.button_ZhuCeRuanJian.TabIndex = 4;
            this.button_ZhuCeRuanJian.Text = "注册软件";
            this.button_ZhuCeRuanJian.UseVisualStyleBackColor = true;
            this.button_ZhuCeRuanJian.Click += new System.EventHandler(this.button_ZhuCeRuanJian_Click);
            // 
            // ZhuCeRuanJianFrm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(707, 254);
            this.Controls.Add(this.button_ZhuCeRuanJian);
            this.Controls.Add(this.textBox_ZhuCeMa);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.textBox_JiQiMa);
            this.Controls.Add(this.label1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ZhuCeRuanJianFrm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "软件注册界面";
            this.Load += new System.EventHandler(this.ZhuCeRuanJianFrm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBox_JiQiMa;
        private System.Windows.Forms.TextBox textBox_ZhuCeMa;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button button_ZhuCeRuanJian;
    }
}