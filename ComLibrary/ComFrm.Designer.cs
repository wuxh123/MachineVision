namespace ComLibrary
{
    partial class ComFrm
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
            this.comboBox_chuanKouMingCheng = new System.Windows.Forms.ComboBox();
            this.comboBox_boTeLv = new System.Windows.Forms.ComboBox();
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(14, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "串口名称：";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(14, 52);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 12);
            this.label2.TabIndex = 1;
            this.label2.Text = "波特率：";
            // 
            // comboBox_chuanKouMingCheng
            // 
            this.comboBox_chuanKouMingCheng.FormattingEnabled = true;
            this.comboBox_chuanKouMingCheng.Location = new System.Drawing.Point(85, 17);
            this.comboBox_chuanKouMingCheng.Name = "comboBox_chuanKouMingCheng";
            this.comboBox_chuanKouMingCheng.Size = new System.Drawing.Size(138, 20);
            this.comboBox_chuanKouMingCheng.TabIndex = 2;
            // 
            // comboBox_boTeLv
            // 
            this.comboBox_boTeLv.FormattingEnabled = true;
            this.comboBox_boTeLv.Location = new System.Drawing.Point(85, 49);
            this.comboBox_boTeLv.Name = "comboBox_boTeLv";
            this.comboBox_boTeLv.Size = new System.Drawing.Size(138, 20);
            this.comboBox_boTeLv.TabIndex = 3;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(257, 22);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(89, 46);
            this.button1.TabIndex = 4;
            this.button1.Text = "确定数据";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // ComFrm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(391, 102);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.comboBox_boTeLv);
            this.Controls.Add(this.comboBox_chuanKouMingCheng);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ComFrm";
            this.Text = "串口";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox comboBox_chuanKouMingCheng;
        private System.Windows.Forms.ComboBox comboBox_boTeLv;
        private System.Windows.Forms.Button button1;
    }
}