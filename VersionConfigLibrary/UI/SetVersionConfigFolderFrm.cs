using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;



namespace VersionConfigLibrary.UI
{
    public partial class SetVersionConfigFolderFrm : Form
    {
        #region  全局变量

        #region  设置器
        /// <summary>
        /// 配置文件设置器
        /// </summary>
        Set_Get_VersionConfig _setGetVersionConfig;
        #endregion

        #region   数据接口
        /// <summary>
        /// 数据接口
        /// </summary>
        IVersionConfig _IVer = null;
        #endregion

        #region  配置文件路径
        /// <summary>
        /// 配置文件路径
        /// </summary>
        string _paht_VersionConfig = "";
        #endregion

        #endregion

        #region  属性
        /// <summary>
        /// 配置文件路径
        /// </summary>
        string Paht_VersionConfig
        {
            get { return _paht_VersionConfig; }
            set
            {
                this.Text = value;
                _paht_VersionConfig = value;
            }
        }
        #endregion

        #region   构造函数
        public SetVersionConfigFolderFrm()
        {
            InitializeComponent();
        }
        #endregion

        #region  初始化函数
        private void SetVersionConfigFolderFrm_Load(object sender, EventArgs e)
        {
            this._setGetVersionConfig = new Set_Get_VersionConfig();

        }
        #endregion

        #region    加载一个配置文件
        private void tSB_OpenVersionConfig_Click(object sender, EventArgs e)
        {
            OpenFileDialog open_file = new OpenFileDialog();
            open_file.Filter = "CONFIG files (*.config)|*config";
            open_file.FilterIndex = 2;
            open_file.RestoreDirectory = true;
            open_file.Multiselect = true;

            if (open_file.ShowDialog()/*打开对话框 */ == System.Windows.Forms.DialogResult.OK)
            {
                VersionConfig Ver_;
                this._setGetVersionConfig.fanXuLeiHua<VersionConfig>(out Ver_, open_file.FileName);
                this._IVer = Ver_;
                this._setGetVersionConfig.Set_ShowParameter(this._IVer, this.Controls);
            }
        }
        #endregion

        #region  保存
        private void tSB_SaveSet_Click(object sender, EventArgs e)
        {
            if (this._IVer == null)
            {
                MessageBox.Show("配置文件数据是空的，请创建或新建一个");
                return;
            }

            if (this._paht_VersionConfig == "")
            {
                SaveFileDialog savfile = new SaveFileDialog();
                savfile.Filter = "CONFIG files (*.config)|*config";
                savfile.FilterIndex = 1;
                if (savfile.ShowDialog() == DialogResult.OK)
                {
                    this.Paht_VersionConfig = savfile.FileName;
                    _setGetVersionConfig.XuLeiHua<VersionConfig>((VersionConfig)this._IVer, savfile.FileName+".config");
                }
            }
        }
        #endregion

        #region   新建一个配置文件
        private void tSB_NewVersionConfig_Click(object sender, EventArgs e)
        {
            this._IVer = new VersionConfig();
            this._setGetVersionConfig.Set_ShowParameter(_IVer, Controls);
        }
        #endregion

        #region    设置软件版本
        private void bnt_SetUseVersionConfig_Click(object sender, EventArgs e)
        {
            this._setGetVersionConfig.Set_use_VersionConfig(this._IVer, Use_VersionConfig.Text);
        }
        #endregion

        #region     客户 项目
        private void bnt_SetClientProjectVersionConfig_Click(object sender, EventArgs e)
        {
            this._setGetVersionConfig.Set_client_project(this._IVer, Client_VersionConfig.Text, Project_VersionConfig.Text);
        }
        #endregion

        #region 设置试用期
        private void bnt_SetTryOutVersionConfig_Click(object sender, EventArgs e)
        {
            this._setGetVersionConfig.Set_tryOut(this._IVer, ExitTryOut_VersionConfig.Checked, TryOutDateStart_VersionConfig.Text, TryOutDateStop_VersionConfig.Text);
        }
        #endregion

        #region  确定强制停止日期
        private void bnt_SetForceVersionConfig_Click(object sender, EventArgs e)
        {
            this._setGetVersionConfig.Set_Force(this._IVer, ExitForceStop.Checked, this.ForceStopDate_VersionConfig.Text);
        }
        #endregion

        #region  是否启动工具限权
        private void Exit_Tool_CheckedChanged(object sender, EventArgs e)
        {
            bool bo_ = this.Exit_Tool.Checked;
            this._setGetVersionConfig.Set_tool_bool(this._IVer, tool_enum.Exit_Tool, ref bo_);
        }
        #endregion

        #region   系统标志
        private void Detection_bool_CheckedChanged(object sender, EventArgs e)
        {
            bool bo_ = this.Detection_bool.Checked;
            this._setGetVersionConfig.Set_tool_bool(this._IVer, tool_enum.Detection_bool, ref bo_);
        }
        #endregion

        #region    取图标志
        private void Acquire_bool_CheckedChanged(object sender, EventArgs e)
        {
            bool bo_ = this.Acquire_bool.Checked;
            this._setGetVersionConfig.Set_tool_bool(this._IVer, tool_enum.Acquire_bool, ref bo_);

        }
        #endregion

        #region   模板标志
        private void Template_bool1_CheckedChanged(object sender, EventArgs e)
        {
            bool bo_ = this.Template_bool1.Checked;
            this._setGetVersionConfig.Set_tool_bool(this._IVer, tool_enum.Template_bool,ref bo_);
        }
        #endregion
         
        #region  放射定位     
        private void Rect_bool1_CheckedChanged(object sender, EventArgs e)
        {
            bool bo_=this.Rect_bool1.Checked;
            this._setGetVersionConfig.Set_tool_bool(this._IVer, tool_enum.Rect_bool,ref bo_);

        }
        #endregion

        #region  标定标志
        private void Calibration_bool1_CheckedChanged(object sender, EventArgs e)
        {
            bool bo_ = this.Calibration_bool1.Checked;
            this._setGetVersionConfig.Set_tool_bool(this._IVer, tool_enum.Calibration_bool, ref bo_);

        }
        #endregion

        #region  二维码标志
        private void DataCode_bool1_CheckedChanged(object sender, EventArgs e)
        {
            bool bo_ = this.DataCode_bool1.Checked;
            this._setGetVersionConfig.Set_tool_bool(this._IVer, tool_enum.DataCode_bool, ref bo_);
        }
        #endregion

        #region  拟合圆标志
        private void Circle_bool1_CheckedChanged(object sender, EventArgs e)
        {
            bool bo_ = this.Circle_bool1.Checked;
            this._setGetVersionConfig.Set_tool_bool(this._IVer, tool_enum.Circle_bool, ref bo_);
        }
        #endregion

        #region   拟合边标志
        private void Line_bool1_CheckedChanged(object sender, EventArgs e)
        {
            bool bo_ = this.Line_bool1.Checked;
            this._setGetVersionConfig.Set_tool_bool(this._IVer, tool_enum.Line_bool, ref bo_);

        }
        #endregion

        #region  ocr标志
        private void OCR_bool1_CheckedChanged(object sender, EventArgs e)
        {
            bool bo_ = this.OCR_bool1.Checked;
            this._setGetVersionConfig.Set_tool_bool(this._IVer, tool_enum.OCR_bool, ref bo_);
        }
        #endregion

        #region   ocv标定
        private void OCV_bool1_CheckedChanged(object sender, EventArgs e)
        {
            bool bo_ = this.OCV_bool1.Checked;
            this._setGetVersionConfig.Set_tool_bool(this._IVer, tool_enum.OCV_bool, ref bo_);
        }
        #endregion
    }
}
