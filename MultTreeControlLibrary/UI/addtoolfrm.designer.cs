namespace MultTreeControlLibrary
{
    partial class AddToolFrm
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
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.Detection = new System.Windows.Forms.TabPage();
            this.lab_detection = new System.Windows.Forms.Label();
            this.Aquire = new System.Windows.Forms.TabPage();
            this.lab_acquire = new System.Windows.Forms.Label();
            this.Analyst = new System.Windows.Forms.TabPage();
            this.lab_Blob = new System.Windows.Forms.Label();
            this.lab_DistanceTwoLine = new System.Windows.Forms.Label();
            this.lab_DistancePointToLine = new System.Windows.Forms.Label();
            this.lab_distanceTwoPoint = new System.Windows.Forms.Label();
            this.lab_BackGround = new System.Windows.Forms.Label();
            this.lab_dataCode = new System.Windows.Forms.Label();
            this.lab_calibration = new System.Windows.Forms.Label();
            this.lab_line = new System.Windows.Forms.Label();
            this.lab_OCV = new System.Windows.Forms.Label();
            this.lab_OCR = new System.Windows.Forms.Label();
            this.lab_BarCode = new System.Windows.Forms.Label();
            this.lab_rect_location = new System.Windows.Forms.Label();
            this.lab_circle = new System.Windows.Forms.Label();
            this.lab_rotateImage = new System.Windows.Forms.Label();
            this.lab_colorAnalyst = new System.Windows.Forms.Label();
            this.lab_seekTemplate = new System.Windows.Forms.Label();
            this.Preprocessing = new System.Windows.Forms.TabPage();
            this.lab_OCRWenBen = new System.Windows.Forms.Label();
            this.tabControl1.SuspendLayout();
            this.Detection.SuspendLayout();
            this.Aquire.SuspendLayout();
            this.Analyst.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.Detection);
            this.tabControl1.Controls.Add(this.Aquire);
            this.tabControl1.Controls.Add(this.Analyst);
            this.tabControl1.Controls.Add(this.Preprocessing);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(468, 193);
            this.tabControl1.TabIndex = 0;
            // 
            // Detection
            // 
            this.Detection.Controls.Add(this.lab_detection);
            this.Detection.Location = new System.Drawing.Point(4, 22);
            this.Detection.Name = "Detection";
            this.Detection.Padding = new System.Windows.Forms.Padding(3, 3, 3, 3);
            this.Detection.Size = new System.Drawing.Size(460, 167);
            this.Detection.TabIndex = 0;
            this.Detection.Text = "图像检测控制";
            this.Detection.UseVisualStyleBackColor = true;
            // 
            // lab_detection
            // 
            this.lab_detection.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lab_detection.Location = new System.Drawing.Point(8, 19);
            this.lab_detection.Name = "lab_detection";
            this.lab_detection.Size = new System.Drawing.Size(72, 23);
            this.lab_detection.TabIndex = 0;
            this.lab_detection.Text = "图片检测";
            this.lab_detection.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lab_detection.Click += new System.EventHandler(this.lab_detection_Click);
            // 
            // Aquire
            // 
            this.Aquire.Controls.Add(this.lab_acquire);
            this.Aquire.Location = new System.Drawing.Point(4, 22);
            this.Aquire.Name = "Aquire";
            this.Aquire.Size = new System.Drawing.Size(460, 167);
            this.Aquire.TabIndex = 3;
            this.Aquire.Text = "取图工具";
            this.Aquire.UseVisualStyleBackColor = true;
            // 
            // lab_acquire
            // 
            this.lab_acquire.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lab_acquire.Location = new System.Drawing.Point(8, 12);
            this.lab_acquire.Name = "lab_acquire";
            this.lab_acquire.Size = new System.Drawing.Size(99, 27);
            this.lab_acquire.TabIndex = 4;
            this.lab_acquire.Text = "取图工具";
            this.lab_acquire.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lab_acquire.Click += new System.EventHandler(this.lab_acquire_Click);
            // 
            // Analyst
            // 
            this.Analyst.Controls.Add(this.lab_OCRWenBen);
            this.Analyst.Controls.Add(this.lab_Blob);
            this.Analyst.Controls.Add(this.lab_DistanceTwoLine);
            this.Analyst.Controls.Add(this.lab_DistancePointToLine);
            this.Analyst.Controls.Add(this.lab_distanceTwoPoint);
            this.Analyst.Controls.Add(this.lab_BackGround);
            this.Analyst.Controls.Add(this.lab_dataCode);
            this.Analyst.Controls.Add(this.lab_calibration);
            this.Analyst.Controls.Add(this.lab_line);
            this.Analyst.Controls.Add(this.lab_OCV);
            this.Analyst.Controls.Add(this.lab_OCR);
            this.Analyst.Controls.Add(this.lab_BarCode);
            this.Analyst.Controls.Add(this.lab_rect_location);
            this.Analyst.Controls.Add(this.lab_circle);
            this.Analyst.Controls.Add(this.lab_rotateImage);
            this.Analyst.Controls.Add(this.lab_colorAnalyst);
            this.Analyst.Controls.Add(this.lab_seekTemplate);
            this.Analyst.Location = new System.Drawing.Point(4, 22);
            this.Analyst.Name = "Analyst";
            this.Analyst.Padding = new System.Windows.Forms.Padding(3, 3, 3, 3);
            this.Analyst.Size = new System.Drawing.Size(460, 167);
            this.Analyst.TabIndex = 1;
            this.Analyst.Text = "通用工具";
            this.Analyst.UseVisualStyleBackColor = true;
            // 
            // lab_Blob
            // 
            this.lab_Blob.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lab_Blob.Location = new System.Drawing.Point(8, 127);
            this.lab_Blob.Name = "lab_Blob";
            this.lab_Blob.Size = new System.Drawing.Size(72, 23);
            this.lab_Blob.TabIndex = 16;
            this.lab_Blob.Text = "斑点";
            this.lab_Blob.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lab_Blob.Click += new System.EventHandler(this.lab_Blob_Click);
            // 
            // lab_DistanceTwoLine
            // 
            this.lab_DistanceTwoLine.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lab_DistanceTwoLine.Location = new System.Drawing.Point(319, 90);
            this.lab_DistanceTwoLine.Name = "lab_DistanceTwoLine";
            this.lab_DistanceTwoLine.Size = new System.Drawing.Size(72, 23);
            this.lab_DistanceTwoLine.TabIndex = 15;
            this.lab_DistanceTwoLine.Text = "两线交点";
            this.lab_DistanceTwoLine.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lab_DistanceTwoLine.Click += new System.EventHandler(this.lab_DistanceTwoLine_Click);
            // 
            // lab_DistancePointToLine
            // 
            this.lab_DistancePointToLine.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lab_DistancePointToLine.Location = new System.Drawing.Point(242, 90);
            this.lab_DistancePointToLine.Name = "lab_DistancePointToLine";
            this.lab_DistancePointToLine.Size = new System.Drawing.Size(72, 23);
            this.lab_DistancePointToLine.TabIndex = 14;
            this.lab_DistancePointToLine.Text = "点到线距离";
            this.lab_DistancePointToLine.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lab_DistancePointToLine.Click += new System.EventHandler(this.lab_DistancePointToLine_Click);
            // 
            // lab_distanceTwoPoint
            // 
            this.lab_distanceTwoPoint.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lab_distanceTwoPoint.Location = new System.Drawing.Point(164, 90);
            this.lab_distanceTwoPoint.Name = "lab_distanceTwoPoint";
            this.lab_distanceTwoPoint.Size = new System.Drawing.Size(72, 23);
            this.lab_distanceTwoPoint.TabIndex = 13;
            this.lab_distanceTwoPoint.Text = "两点的距离";
            this.lab_distanceTwoPoint.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lab_distanceTwoPoint.Click += new System.EventHandler(this.lab_distanceTwoPoint_Click);
            // 
            // lab_BackGround
            // 
            this.lab_BackGround.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lab_BackGround.Location = new System.Drawing.Point(86, 90);
            this.lab_BackGround.Name = "lab_BackGround";
            this.lab_BackGround.Size = new System.Drawing.Size(72, 23);
            this.lab_BackGround.TabIndex = 12;
            this.lab_BackGround.Text = "背景检测";
            this.lab_BackGround.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lab_BackGround.Click += new System.EventHandler(this.lab_BackGround_Click);
            // 
            // lab_dataCode
            // 
            this.lab_dataCode.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lab_dataCode.Location = new System.Drawing.Point(8, 90);
            this.lab_dataCode.Name = "lab_dataCode";
            this.lab_dataCode.Size = new System.Drawing.Size(72, 23);
            this.lab_dataCode.TabIndex = 11;
            this.lab_dataCode.Text = "二维码识别";
            this.lab_dataCode.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lab_dataCode.Click += new System.EventHandler(this.lab_dataCode_Click);
            // 
            // lab_calibration
            // 
            this.lab_calibration.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lab_calibration.Location = new System.Drawing.Point(319, 53);
            this.lab_calibration.Name = "lab_calibration";
            this.lab_calibration.Size = new System.Drawing.Size(72, 23);
            this.lab_calibration.TabIndex = 10;
            this.lab_calibration.Text = "标定";
            this.lab_calibration.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lab_calibration.Click += new System.EventHandler(this.lab_calibration_Click);
            // 
            // lab_line
            // 
            this.lab_line.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lab_line.Location = new System.Drawing.Point(319, 14);
            this.lab_line.Name = "lab_line";
            this.lab_line.Size = new System.Drawing.Size(72, 23);
            this.lab_line.TabIndex = 9;
            this.lab_line.Text = "拟合直线";
            this.lab_line.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lab_line.Click += new System.EventHandler(this.lab_line_Click);
            // 
            // lab_OCV
            // 
            this.lab_OCV.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lab_OCV.Location = new System.Drawing.Point(242, 53);
            this.lab_OCV.Name = "lab_OCV";
            this.lab_OCV.Size = new System.Drawing.Size(72, 23);
            this.lab_OCV.TabIndex = 8;
            this.lab_OCV.Text = "OCV";
            this.lab_OCV.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lab_OCV.Click += new System.EventHandler(this.lab_OCV_Click);
            // 
            // lab_OCR
            // 
            this.lab_OCR.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lab_OCR.Location = new System.Drawing.Point(242, 14);
            this.lab_OCR.Name = "lab_OCR";
            this.lab_OCR.Size = new System.Drawing.Size(72, 23);
            this.lab_OCR.TabIndex = 7;
            this.lab_OCR.Text = "OCR";
            this.lab_OCR.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lab_OCR.Click += new System.EventHandler(this.lab_OCR_Click);
            // 
            // lab_BarCode
            // 
            this.lab_BarCode.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lab_BarCode.Location = new System.Drawing.Point(164, 53);
            this.lab_BarCode.Name = "lab_BarCode";
            this.lab_BarCode.Size = new System.Drawing.Size(72, 23);
            this.lab_BarCode.TabIndex = 6;
            this.lab_BarCode.Text = "读取一维码";
            this.lab_BarCode.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lab_BarCode.Click += new System.EventHandler(this.lab_BarCode_Click);
            // 
            // lab_rect_location
            // 
            this.lab_rect_location.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lab_rect_location.Location = new System.Drawing.Point(86, 53);
            this.lab_rect_location.Name = "lab_rect_location";
            this.lab_rect_location.Size = new System.Drawing.Size(72, 23);
            this.lab_rect_location.TabIndex = 5;
            this.lab_rect_location.Text = "定位";
            this.lab_rect_location.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lab_rect_location.Click += new System.EventHandler(this.lab_rect_location_Click);
            // 
            // lab_circle
            // 
            this.lab_circle.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lab_circle.Location = new System.Drawing.Point(8, 53);
            this.lab_circle.Name = "lab_circle";
            this.lab_circle.Size = new System.Drawing.Size(72, 23);
            this.lab_circle.TabIndex = 4;
            this.lab_circle.Text = "拟合圆";
            this.lab_circle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lab_circle.Click += new System.EventHandler(this.lab_circle_Click);
            // 
            // lab_rotateImage
            // 
            this.lab_rotateImage.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lab_rotateImage.Location = new System.Drawing.Point(86, 14);
            this.lab_rotateImage.Name = "lab_rotateImage";
            this.lab_rotateImage.Size = new System.Drawing.Size(72, 23);
            this.lab_rotateImage.TabIndex = 3;
            this.lab_rotateImage.Text = "图片旋转";
            this.lab_rotateImage.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lab_rotateImage.Visible = false;
            this.lab_rotateImage.Click += new System.EventHandler(this.lab_rotateImage_Click);
            // 
            // lab_colorAnalyst
            // 
            this.lab_colorAnalyst.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lab_colorAnalyst.Location = new System.Drawing.Point(164, 14);
            this.lab_colorAnalyst.Name = "lab_colorAnalyst";
            this.lab_colorAnalyst.Size = new System.Drawing.Size(72, 23);
            this.lab_colorAnalyst.TabIndex = 2;
            this.lab_colorAnalyst.Text = "颜色分析";
            this.lab_colorAnalyst.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lab_colorAnalyst.Visible = false;
            this.lab_colorAnalyst.Click += new System.EventHandler(this.lab_colorAnalyst_Click);
            // 
            // lab_seekTemplate
            // 
            this.lab_seekTemplate.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lab_seekTemplate.Location = new System.Drawing.Point(8, 14);
            this.lab_seekTemplate.Name = "lab_seekTemplate";
            this.lab_seekTemplate.Size = new System.Drawing.Size(72, 23);
            this.lab_seekTemplate.TabIndex = 1;
            this.lab_seekTemplate.Text = "模板工具";
            this.lab_seekTemplate.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lab_seekTemplate.Click += new System.EventHandler(this.lab_seekTemplate_Click);
            // 
            // Preprocessing
            // 
            this.Preprocessing.Location = new System.Drawing.Point(4, 22);
            this.Preprocessing.Name = "Preprocessing";
            this.Preprocessing.Size = new System.Drawing.Size(460, 167);
            this.Preprocessing.TabIndex = 2;
            this.Preprocessing.Text = "图像处理工具";
            this.Preprocessing.UseVisualStyleBackColor = true;
            // 
            // lab_OCRWenBen
            // 
            this.lab_OCRWenBen.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lab_OCRWenBen.Location = new System.Drawing.Point(86, 127);
            this.lab_OCRWenBen.Name = "lab_OCRWenBen";
            this.lab_OCRWenBen.Size = new System.Drawing.Size(72, 23);
            this.lab_OCRWenBen.TabIndex = 17;
            this.lab_OCRWenBen.Text = "OCR文本";
            this.lab_OCRWenBen.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lab_OCRWenBen.Click += new System.EventHandler(this.lab_OCRWenBen_Click);
            // 
            // AddToolFrm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(468, 193);
            this.Controls.Add(this.tabControl1);
            this.Name = "AddToolFrm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "添加工具选择";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.add_toolfrm_FormClosing);
            this.Load += new System.EventHandler(this.add_toolfrm_Load);
            this.tabControl1.ResumeLayout(false);
            this.Detection.ResumeLayout(false);
            this.Aquire.ResumeLayout(false);
            this.Analyst.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage Detection;
        private System.Windows.Forms.TabPage Analyst;
        private System.Windows.Forms.TabPage Preprocessing;
        private System.Windows.Forms.TabPage Aquire;
        private System.Windows.Forms.Label lab_acquire;
        private System.Windows.Forms.Label lab_detection;
        private System.Windows.Forms.Label lab_seekTemplate;
        private System.Windows.Forms.Label lab_colorAnalyst;
        private System.Windows.Forms.Label lab_rotateImage;
        private System.Windows.Forms.Label lab_circle;
        private System.Windows.Forms.Label lab_rect_location;
        private System.Windows.Forms.Label lab_BarCode;
        private System.Windows.Forms.Label lab_OCR;
        private System.Windows.Forms.Label lab_OCV;
        private System.Windows.Forms.Label lab_line;
        private System.Windows.Forms.Label lab_calibration;
        private System.Windows.Forms.Label lab_dataCode;
        private System.Windows.Forms.Label lab_BackGround;
        private System.Windows.Forms.Label lab_distanceTwoPoint;
        private System.Windows.Forms.Label lab_DistancePointToLine;
        private System.Windows.Forms.Label lab_DistanceTwoLine;
        private System.Windows.Forms.Label lab_Blob;
        private System.Windows.Forms.Label lab_OCRWenBen;
    }
}