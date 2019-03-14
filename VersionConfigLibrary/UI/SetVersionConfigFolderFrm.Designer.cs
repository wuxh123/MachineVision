namespace VersionConfigLibrary.UI
{
    partial class SetVersionConfigFolderFrm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SetVersionConfigFolderFrm));
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.tSB_OpenVersionConfig = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.tSB_NewVersionConfig = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.tSB_SaveSet = new System.Windows.Forms.ToolStripButton();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.bnt_SetUseVersionConfig = new System.Windows.Forms.Button();
            this.Use_VersionConfig = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.bnt_SetClientProjectVersionConfig = new System.Windows.Forms.Button();
            this.Project_VersionConfig = new System.Windows.Forms.TextBox();
            this.Client_VersionConfig = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.bnt_SetTryOutVersionConfig = new System.Windows.Forms.Button();
            this.TryOutDateStop_VersionConfig = new System.Windows.Forms.TextBox();
            this.TryOutDateCurrendt_VersionConfig = new System.Windows.Forms.TextBox();
            this.TryOutDateStart_VersionConfig = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.ExitTryOut_VersionConfig = new System.Windows.Forms.CheckBox();
            this.label4 = new System.Windows.Forms.Label();
            this.tabPage4 = new System.Windows.Forms.TabPage();
            this.bnt_SetForceVersionConfig = new System.Windows.Forms.Button();
            this.ForceStopDate_VersionConfig = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.ExitForceStop = new System.Windows.Forms.CheckBox();
            this.tabPage5 = new System.Windows.Forms.TabPage();
            this.OCV_bool1 = new System.Windows.Forms.CheckBox();
            this.OCR_bool1 = new System.Windows.Forms.CheckBox();
            this.Line_bool1 = new System.Windows.Forms.CheckBox();
            this.Circle_bool1 = new System.Windows.Forms.CheckBox();
            this.DataCode_bool1 = new System.Windows.Forms.CheckBox();
            this.Calibration_bool1 = new System.Windows.Forms.CheckBox();
            this.Rect_bool1 = new System.Windows.Forms.CheckBox();
            this.Template_bool1 = new System.Windows.Forms.CheckBox();
            this.Acquire_bool = new System.Windows.Forms.CheckBox();
            this.Detection_bool = new System.Windows.Forms.CheckBox();
            this.Exit_Tool = new System.Windows.Forms.CheckBox();
            this.toolStrip1.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.tabPage3.SuspendLayout();
            this.tabPage4.SuspendLayout();
            this.tabPage5.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tSB_OpenVersionConfig,
            this.toolStripSeparator1,
            this.tSB_NewVersionConfig,
            this.toolStripSeparator2,
            this.tSB_SaveSet});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(1027, 27);
            this.toolStrip1.TabIndex = 0;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // tSB_OpenVersionConfig
            // 
            this.tSB_OpenVersionConfig.Image = ((System.Drawing.Image)(resources.GetObject("tSB_OpenVersionConfig.Image")));
            this.tSB_OpenVersionConfig.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tSB_OpenVersionConfig.Name = "tSB_OpenVersionConfig";
            this.tSB_OpenVersionConfig.Size = new System.Drawing.Size(149, 24);
            this.tSB_OpenVersionConfig.Text = "打开一个配置文件";
            this.tSB_OpenVersionConfig.Click += new System.EventHandler(this.tSB_OpenVersionConfig_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 27);
            // 
            // tSB_NewVersionConfig
            // 
            this.tSB_NewVersionConfig.Image = ((System.Drawing.Image)(resources.GetObject("tSB_NewVersionConfig.Image")));
            this.tSB_NewVersionConfig.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tSB_NewVersionConfig.Name = "tSB_NewVersionConfig";
            this.tSB_NewVersionConfig.Size = new System.Drawing.Size(149, 24);
            this.tSB_NewVersionConfig.Text = "新建一个配置文件";
            this.tSB_NewVersionConfig.Click += new System.EventHandler(this.tSB_NewVersionConfig_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 27);
            // 
            // tSB_SaveSet
            // 
            this.tSB_SaveSet.Image = ((System.Drawing.Image)(resources.GetObject("tSB_SaveSet.Image")));
            this.tSB_SaveSet.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tSB_SaveSet.Name = "tSB_SaveSet";
            this.tSB_SaveSet.Size = new System.Drawing.Size(89, 24);
            this.tSB_SaveSet.Text = "保存设置";
            this.tSB_SaveSet.Click += new System.EventHandler(this.tSB_SaveSet_Click);
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Controls.Add(this.tabPage4);
            this.tabControl1.Controls.Add(this.tabPage5);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 27);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1027, 445);
            this.tabControl1.TabIndex = 1;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.bnt_SetUseVersionConfig);
            this.tabPage1.Controls.Add(this.Use_VersionConfig);
            this.tabPage1.Controls.Add(this.label1);
            this.tabPage1.Location = new System.Drawing.Point(4, 25);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(1019, 416);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "软件的使用版本";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // bnt_SetUseVersionConfig
            // 
            this.bnt_SetUseVersionConfig.Location = new System.Drawing.Point(329, 247);
            this.bnt_SetUseVersionConfig.Name = "bnt_SetUseVersionConfig";
            this.bnt_SetUseVersionConfig.Size = new System.Drawing.Size(378, 54);
            this.bnt_SetUseVersionConfig.TabIndex = 2;
            this.bnt_SetUseVersionConfig.Text = "设置版本";
            this.bnt_SetUseVersionConfig.UseVisualStyleBackColor = true;
            this.bnt_SetUseVersionConfig.Click += new System.EventHandler(this.bnt_SetUseVersionConfig_Click);
            // 
            // Use_VersionConfig
            // 
            this.Use_VersionConfig.Location = new System.Drawing.Point(329, 185);
            this.Use_VersionConfig.Name = "Use_VersionConfig";
            this.Use_VersionConfig.Size = new System.Drawing.Size(378, 25);
            this.Use_VersionConfig.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(159, 172);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(164, 47);
            this.label1.TabIndex = 0;
            this.label1.Text = "软件的使用版本：";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.bnt_SetClientProjectVersionConfig);
            this.tabPage2.Controls.Add(this.Project_VersionConfig);
            this.tabPage2.Controls.Add(this.Client_VersionConfig);
            this.tabPage2.Controls.Add(this.label3);
            this.tabPage2.Controls.Add(this.label2);
            this.tabPage2.Location = new System.Drawing.Point(4, 25);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(1019, 416);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "项目客户";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // bnt_SetClientProjectVersionConfig
            // 
            this.bnt_SetClientProjectVersionConfig.Location = new System.Drawing.Point(255, 293);
            this.bnt_SetClientProjectVersionConfig.Name = "bnt_SetClientProjectVersionConfig";
            this.bnt_SetClientProjectVersionConfig.Size = new System.Drawing.Size(512, 52);
            this.bnt_SetClientProjectVersionConfig.TabIndex = 5;
            this.bnt_SetClientProjectVersionConfig.Text = "设置客户和项目";
            this.bnt_SetClientProjectVersionConfig.UseVisualStyleBackColor = true;
            this.bnt_SetClientProjectVersionConfig.Click += new System.EventHandler(this.bnt_SetClientProjectVersionConfig_Click);
            // 
            // Project_VersionConfig
            // 
            this.Project_VersionConfig.Location = new System.Drawing.Point(255, 234);
            this.Project_VersionConfig.Name = "Project_VersionConfig";
            this.Project_VersionConfig.Size = new System.Drawing.Size(512, 25);
            this.Project_VersionConfig.TabIndex = 4;
            // 
            // Client_VersionConfig
            // 
            this.Client_VersionConfig.Location = new System.Drawing.Point(255, 170);
            this.Client_VersionConfig.Name = "Client_VersionConfig";
            this.Client_VersionConfig.Size = new System.Drawing.Size(512, 25);
            this.Client_VersionConfig.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(122, 221);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(164, 47);
            this.label3.TabIndex = 2;
            this.label3.Text = "项目：";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(122, 157);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(164, 47);
            this.label2.TabIndex = 1;
            this.label2.Text = "客户：";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.bnt_SetTryOutVersionConfig);
            this.tabPage3.Controls.Add(this.TryOutDateStop_VersionConfig);
            this.tabPage3.Controls.Add(this.TryOutDateCurrendt_VersionConfig);
            this.tabPage3.Controls.Add(this.TryOutDateStart_VersionConfig);
            this.tabPage3.Controls.Add(this.label6);
            this.tabPage3.Controls.Add(this.label5);
            this.tabPage3.Controls.Add(this.ExitTryOut_VersionConfig);
            this.tabPage3.Controls.Add(this.label4);
            this.tabPage3.Location = new System.Drawing.Point(4, 25);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Size = new System.Drawing.Size(1019, 416);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "试用期";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // bnt_SetTryOutVersionConfig
            // 
            this.bnt_SetTryOutVersionConfig.Location = new System.Drawing.Point(481, 64);
            this.bnt_SetTryOutVersionConfig.Name = "bnt_SetTryOutVersionConfig";
            this.bnt_SetTryOutVersionConfig.Size = new System.Drawing.Size(204, 117);
            this.bnt_SetTryOutVersionConfig.TabIndex = 9;
            this.bnt_SetTryOutVersionConfig.Text = "设置试用期日期";
            this.bnt_SetTryOutVersionConfig.UseVisualStyleBackColor = true;
            this.bnt_SetTryOutVersionConfig.Click += new System.EventHandler(this.bnt_SetTryOutVersionConfig_Click);
            // 
            // TryOutDateStop_VersionConfig
            // 
            this.TryOutDateStop_VersionConfig.Location = new System.Drawing.Point(160, 157);
            this.TryOutDateStop_VersionConfig.Name = "TryOutDateStop_VersionConfig";
            this.TryOutDateStop_VersionConfig.Size = new System.Drawing.Size(238, 25);
            this.TryOutDateStop_VersionConfig.TabIndex = 8;
            // 
            // TryOutDateCurrendt_VersionConfig
            // 
            this.TryOutDateCurrendt_VersionConfig.Location = new System.Drawing.Point(160, 111);
            this.TryOutDateCurrendt_VersionConfig.Name = "TryOutDateCurrendt_VersionConfig";
            this.TryOutDateCurrendt_VersionConfig.Size = new System.Drawing.Size(238, 25);
            this.TryOutDateCurrendt_VersionConfig.TabIndex = 7;
            // 
            // TryOutDateStart_VersionConfig
            // 
            this.TryOutDateStart_VersionConfig.Location = new System.Drawing.Point(160, 68);
            this.TryOutDateStart_VersionConfig.Name = "TryOutDateStart_VersionConfig";
            this.TryOutDateStart_VersionConfig.Size = new System.Drawing.Size(238, 25);
            this.TryOutDateStart_VersionConfig.TabIndex = 6;
            // 
            // label6
            // 
            this.label6.Location = new System.Drawing.Point(19, 153);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(169, 28);
            this.label6.TabIndex = 5;
            this.label6.Text = "截止日期：";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label5
            // 
            this.label5.Location = new System.Drawing.Point(19, 107);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(169, 28);
            this.label5.TabIndex = 4;
            this.label5.Text = "当前日期：";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // ExitTryOut_VersionConfig
            // 
            this.ExitTryOut_VersionConfig.AutoSize = true;
            this.ExitTryOut_VersionConfig.Location = new System.Drawing.Point(22, 22);
            this.ExitTryOut_VersionConfig.Name = "ExitTryOut_VersionConfig";
            this.ExitTryOut_VersionConfig.Size = new System.Drawing.Size(134, 19);
            this.ExitTryOut_VersionConfig.TabIndex = 3;
            this.ExitTryOut_VersionConfig.Text = "是否启用试用期";
            this.ExitTryOut_VersionConfig.UseVisualStyleBackColor = true;
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(19, 64);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(169, 28);
            this.label4.TabIndex = 2;
            this.label4.Text = "开始日期：";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tabPage4
            // 
            this.tabPage4.Controls.Add(this.bnt_SetForceVersionConfig);
            this.tabPage4.Controls.Add(this.ForceStopDate_VersionConfig);
            this.tabPage4.Controls.Add(this.label7);
            this.tabPage4.Controls.Add(this.ExitForceStop);
            this.tabPage4.Location = new System.Drawing.Point(4, 25);
            this.tabPage4.Name = "tabPage4";
            this.tabPage4.Size = new System.Drawing.Size(1019, 416);
            this.tabPage4.TabIndex = 3;
            this.tabPage4.Text = "强制停止";
            this.tabPage4.UseVisualStyleBackColor = true;
            // 
            // bnt_SetForceVersionConfig
            // 
            this.bnt_SetForceVersionConfig.Location = new System.Drawing.Point(158, 145);
            this.bnt_SetForceVersionConfig.Name = "bnt_SetForceVersionConfig";
            this.bnt_SetForceVersionConfig.Size = new System.Drawing.Size(280, 64);
            this.bnt_SetForceVersionConfig.TabIndex = 5;
            this.bnt_SetForceVersionConfig.Text = "确定强制停止日期";
            this.bnt_SetForceVersionConfig.UseVisualStyleBackColor = true;
            this.bnt_SetForceVersionConfig.Click += new System.EventHandler(this.bnt_SetForceVersionConfig_Click);
            // 
            // ForceStopDate_VersionConfig
            // 
            this.ForceStopDate_VersionConfig.Location = new System.Drawing.Point(158, 76);
            this.ForceStopDate_VersionConfig.Name = "ForceStopDate_VersionConfig";
            this.ForceStopDate_VersionConfig.Size = new System.Drawing.Size(280, 25);
            this.ForceStopDate_VersionConfig.TabIndex = 4;
            // 
            // label7
            // 
            this.label7.Location = new System.Drawing.Point(8, 72);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(169, 28);
            this.label7.TabIndex = 3;
            this.label7.Text = "强制停止日期：";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // ExitForceStop
            // 
            this.ExitForceStop.AutoSize = true;
            this.ExitForceStop.Location = new System.Drawing.Point(8, 26);
            this.ExitForceStop.Name = "ExitForceStop";
            this.ExitForceStop.Size = new System.Drawing.Size(149, 19);
            this.ExitForceStop.TabIndex = 0;
            this.ExitForceStop.Text = "是否启用强制停止";
            this.ExitForceStop.UseVisualStyleBackColor = true;
            // 
            // tabPage5
            // 
            this.tabPage5.Controls.Add(this.OCV_bool1);
            this.tabPage5.Controls.Add(this.OCR_bool1);
            this.tabPage5.Controls.Add(this.Line_bool1);
            this.tabPage5.Controls.Add(this.Circle_bool1);
            this.tabPage5.Controls.Add(this.DataCode_bool1);
            this.tabPage5.Controls.Add(this.Calibration_bool1);
            this.tabPage5.Controls.Add(this.Rect_bool1);
            this.tabPage5.Controls.Add(this.Template_bool1);
            this.tabPage5.Controls.Add(this.Acquire_bool);
            this.tabPage5.Controls.Add(this.Detection_bool);
            this.tabPage5.Controls.Add(this.Exit_Tool);
            this.tabPage5.Location = new System.Drawing.Point(4, 25);
            this.tabPage5.Name = "tabPage5";
            this.tabPage5.Size = new System.Drawing.Size(1019, 416);
            this.tabPage5.TabIndex = 4;
            this.tabPage5.Text = "工具启动设置";
            this.tabPage5.UseVisualStyleBackColor = true;
            // 
            // OCV_bool1
            // 
            this.OCV_bool1.AutoSize = true;
            this.OCV_bool1.Location = new System.Drawing.Point(460, 142);
            this.OCV_bool1.Name = "OCV_bool1";
            this.OCV_bool1.Size = new System.Drawing.Size(83, 19);
            this.OCV_bool1.TabIndex = 11;
            this.OCV_bool1.Text = "ocv标志";
            this.OCV_bool1.UseVisualStyleBackColor = true;
            this.OCV_bool1.CheckedChanged += new System.EventHandler(this.OCV_bool1_CheckedChanged);
            // 
            // OCR_bool1
            // 
            this.OCR_bool1.AutoSize = true;
            this.OCR_bool1.Location = new System.Drawing.Point(310, 142);
            this.OCR_bool1.Name = "OCR_bool1";
            this.OCR_bool1.Size = new System.Drawing.Size(83, 19);
            this.OCR_bool1.TabIndex = 10;
            this.OCR_bool1.Text = "ocr标志";
            this.OCR_bool1.UseVisualStyleBackColor = true;
            this.OCR_bool1.CheckedChanged += new System.EventHandler(this.OCR_bool1_CheckedChanged);
            // 
            // Line_bool1
            // 
            this.Line_bool1.AutoSize = true;
            this.Line_bool1.Location = new System.Drawing.Point(170, 142);
            this.Line_bool1.Name = "Line_bool1";
            this.Line_bool1.Size = new System.Drawing.Size(104, 19);
            this.Line_bool1.TabIndex = 9;
            this.Line_bool1.Text = "拟合边标志";
            this.Line_bool1.UseVisualStyleBackColor = true;
            this.Line_bool1.CheckedChanged += new System.EventHandler(this.Line_bool1_CheckedChanged);
            // 
            // Circle_bool1
            // 
            this.Circle_bool1.AutoSize = true;
            this.Circle_bool1.Location = new System.Drawing.Point(8, 142);
            this.Circle_bool1.Name = "Circle_bool1";
            this.Circle_bool1.Size = new System.Drawing.Size(104, 19);
            this.Circle_bool1.TabIndex = 8;
            this.Circle_bool1.Text = "拟合圆标志";
            this.Circle_bool1.UseVisualStyleBackColor = true;
            this.Circle_bool1.CheckedChanged += new System.EventHandler(this.Circle_bool1_CheckedChanged);
            // 
            // DataCode_bool1
            // 
            this.DataCode_bool1.AutoSize = true;
            this.DataCode_bool1.Location = new System.Drawing.Point(752, 83);
            this.DataCode_bool1.Name = "DataCode_bool1";
            this.DataCode_bool1.Size = new System.Drawing.Size(104, 19);
            this.DataCode_bool1.TabIndex = 7;
            this.DataCode_bool1.Text = "二维码标志";
            this.DataCode_bool1.UseVisualStyleBackColor = true;
            this.DataCode_bool1.CheckedChanged += new System.EventHandler(this.DataCode_bool1_CheckedChanged);
            // 
            // Calibration_bool1
            // 
            this.Calibration_bool1.AutoSize = true;
            this.Calibration_bool1.Location = new System.Drawing.Point(619, 83);
            this.Calibration_bool1.Name = "Calibration_bool1";
            this.Calibration_bool1.Size = new System.Drawing.Size(89, 19);
            this.Calibration_bool1.TabIndex = 6;
            this.Calibration_bool1.Text = "标定标志";
            this.Calibration_bool1.UseVisualStyleBackColor = true;
            this.Calibration_bool1.CheckedChanged += new System.EventHandler(this.Calibration_bool1_CheckedChanged);
            // 
            // Rect_bool1
            // 
            this.Rect_bool1.AutoSize = true;
            this.Rect_bool1.Location = new System.Drawing.Point(460, 83);
            this.Rect_bool1.Name = "Rect_bool1";
            this.Rect_bool1.Size = new System.Drawing.Size(119, 19);
            this.Rect_bool1.TabIndex = 5;
            this.Rect_bool1.Text = "放射定位标志";
            this.Rect_bool1.UseVisualStyleBackColor = true;
            this.Rect_bool1.CheckedChanged += new System.EventHandler(this.Rect_bool1_CheckedChanged);
            // 
            // Template_bool1
            // 
            this.Template_bool1.AutoSize = true;
            this.Template_bool1.Location = new System.Drawing.Point(310, 83);
            this.Template_bool1.Name = "Template_bool1";
            this.Template_bool1.Size = new System.Drawing.Size(119, 19);
            this.Template_bool1.TabIndex = 4;
            this.Template_bool1.Text = "模板匹配标志";
            this.Template_bool1.UseVisualStyleBackColor = true;
            this.Template_bool1.CheckedChanged += new System.EventHandler(this.Template_bool1_CheckedChanged);
            // 
            // Acquire_bool
            // 
            this.Acquire_bool.AutoSize = true;
            this.Acquire_bool.Location = new System.Drawing.Point(170, 83);
            this.Acquire_bool.Name = "Acquire_bool";
            this.Acquire_bool.Size = new System.Drawing.Size(89, 19);
            this.Acquire_bool.TabIndex = 3;
            this.Acquire_bool.Text = "取图标志";
            this.Acquire_bool.UseVisualStyleBackColor = true;
            this.Acquire_bool.CheckedChanged += new System.EventHandler(this.Acquire_bool_CheckedChanged);
            // 
            // Detection_bool
            // 
            this.Detection_bool.AutoSize = true;
            this.Detection_bool.Location = new System.Drawing.Point(8, 83);
            this.Detection_bool.Name = "Detection_bool";
            this.Detection_bool.Size = new System.Drawing.Size(119, 19);
            this.Detection_bool.TabIndex = 2;
            this.Detection_bool.Text = "系统检测标志";
            this.Detection_bool.UseVisualStyleBackColor = true;
            this.Detection_bool.CheckedChanged += new System.EventHandler(this.Detection_bool_CheckedChanged);
            // 
            // Exit_Tool
            // 
            this.Exit_Tool.AutoSize = true;
            this.Exit_Tool.Location = new System.Drawing.Point(8, 27);
            this.Exit_Tool.Name = "Exit_Tool";
            this.Exit_Tool.Size = new System.Drawing.Size(149, 19);
            this.Exit_Tool.TabIndex = 1;
            this.Exit_Tool.Text = "是否启动工具限权";
            this.Exit_Tool.UseVisualStyleBackColor = true;
            this.Exit_Tool.CheckedChanged += new System.EventHandler(this.Exit_Tool_CheckedChanged);
            // 
            // SetVersionConfigFolderFrm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1027, 472);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.toolStrip1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "SetVersionConfigFolderFrm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "设置配置文件窗口";
            this.Load += new System.EventHandler(this.SetVersionConfigFolderFrm_Load);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.tabPage3.ResumeLayout(false);
            this.tabPage3.PerformLayout();
            this.tabPage4.ResumeLayout(false);
            this.tabPage4.PerformLayout();
            this.tabPage5.ResumeLayout(false);
            this.tabPage5.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton tSB_OpenVersionConfig;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox Use_VersionConfig;
        private System.Windows.Forms.Button bnt_SetUseVersionConfig;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox Project_VersionConfig;
        private System.Windows.Forms.TextBox Client_VersionConfig;
        private System.Windows.Forms.Button bnt_SetClientProjectVersionConfig;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.CheckBox ExitTryOut_VersionConfig;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox TryOutDateStart_VersionConfig;
        private System.Windows.Forms.TextBox TryOutDateCurrendt_VersionConfig;
        private System.Windows.Forms.TextBox TryOutDateStop_VersionConfig;
        private System.Windows.Forms.Button bnt_SetTryOutVersionConfig;
        private System.Windows.Forms.TabPage tabPage4;
        private System.Windows.Forms.CheckBox ExitForceStop;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox ForceStopDate_VersionConfig;
        private System.Windows.Forms.Button bnt_SetForceVersionConfig;
        private System.Windows.Forms.TabPage tabPage5;
        private System.Windows.Forms.CheckBox Exit_Tool;
        private System.Windows.Forms.CheckBox Detection_bool;
        private System.Windows.Forms.CheckBox Acquire_bool;
        private System.Windows.Forms.CheckBox Template_bool1;
        private System.Windows.Forms.CheckBox Rect_bool1;
        private System.Windows.Forms.CheckBox Calibration_bool1;
        private System.Windows.Forms.CheckBox DataCode_bool1;
        private System.Windows.Forms.CheckBox Circle_bool1;
        private System.Windows.Forms.CheckBox Line_bool1;
        private System.Windows.Forms.CheckBox OCR_bool1;
        private System.Windows.Forms.CheckBox OCV_bool1;
        private System.Windows.Forms.ToolStripButton tSB_NewVersionConfig;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripButton tSB_SaveSet;

    }
}