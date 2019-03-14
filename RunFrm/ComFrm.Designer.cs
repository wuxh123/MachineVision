namespace RunFrm
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
            this.components = new System.ComponentModel.Container();
            this.serialPort1 = new System.IO.Ports.SerialPort(this.components);
            this.label1 = new System.Windows.Forms.Label();
            this.richTextBox_jieShouShuJu = new System.Windows.Forms.RichTextBox();
            this.SuspendLayout();
            // 
            // serialPort1
            // 
            this.serialPort1.DataReceived += new System.IO.Ports.SerialDataReceivedEventHandler(this.serialPort1_DataReceived);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(77, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "接收的数据：";
            // 
            // richTextBox_jieShouShuJu
            // 
            this.richTextBox_jieShouShuJu.Location = new System.Drawing.Point(91, 12);
            this.richTextBox_jieShouShuJu.Name = "richTextBox_jieShouShuJu";
            this.richTextBox_jieShouShuJu.Size = new System.Drawing.Size(241, 174);
            this.richTextBox_jieShouShuJu.TabIndex = 1;
            this.richTextBox_jieShouShuJu.Text = "";
            // 
            // ComFrm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(344, 246);
            this.Controls.Add(this.richTextBox_jieShouShuJu);
            this.Controls.Add(this.label1);
            this.Name = "ComFrm";
            this.Text = "串口";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.IO.Ports.SerialPort serialPort1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.RichTextBox richTextBox_jieShouShuJu;
    }
}