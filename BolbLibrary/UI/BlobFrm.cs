using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using HalconDotNet;
using System.IO;
using System.Threading;
//using MachineVision.ShuJuJieGou;
using System.Diagnostics;
using MultTree;
using LogClassLibrary;




namespace BlobLibrary.UI
{
    public partial class BlobFrm : Form
    {
        #region    全局变量

        #region   检测时间
        /// <summary>
        /// 检测时间
        /// </summary>
        Stopwatch _stopWatch = new Stopwatch();
        #endregion

        #region   blob数据
        /// <summary>
        /// blob数据
        /// </summary>
        IBlobShuJu _blob;
        #endregion

        #region   数据设置器
        /// <summary>
        /// 数据设置器
        /// </summary>
        Set_BlobShuJu _setBlob;
        #endregion

        #region   结果
        /// <summary>
        /// 结果
        /// </summary>
        Dictionary<string, Object> _result = new Dictionary<string, object>();
        #endregion

        #endregion

        #region   构造函数
        public BlobFrm()
        {
            InitializeComponent();

            //BeginInvoke(new Action(delegate
            //{
            //HOperatorSet.GenEmptyObj(out _ho_Image);
            //_ho_Image.Dispose();
            //}));
        }
        #endregion

        #region  初始化
        private void ParentFrm_Load(object sender, EventArgs e)
        {
            halconWinControl_ROI1.init();

            _setBlob = new Set_BlobShuJu();
            
            if (TreeStatic.Mult_Tree_Node.Obj == null)
            {
                this._blob = new BlobShuJu();
            }
            else
            {
                this._blob = (BlobShuJu)TreeStatic.Mult_Tree_Node.Obj;
            }

            _setBlob.Set_ShowParameterHalconWinControl(this._blob, this.Controls, this.halconWinControl_ROI1);

        }
        #endregion

        #region     运行
        private void tSB_run_one_Click(object sender, EventArgs e)
        {
            run();
        }

        /// <summary>
        /// 运行
        /// </summary>
        /// <returns></returns>
        bool run()
        {
            if (halconWinControl_ROI1.Exit_Image() == false)
            {
                return false;
            }
            _stopWatch.Restart();
            bool ok = false;

            this._result.Clear();
            this._blob.analyze_show(halconWinControl_ROI1.HalconWindow1, "1", ref _result);

            _stopWatch.Stop();
            Invoke(new Action(delegate
            {
                m_CtrlHStatusLabelCtrl.Text = _stopWatch.ElapsedMilliseconds.ToString();               
            }));

            ok = true;
            return ok;
        }
        #endregion

        #region  取一张图片
        private void tSB_read_image_Click(object sender, EventArgs e)
        {
            read_one_image();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        bool read_one_image()
        {
            bool ok = false;
            try
            {
                _stopWatch.Restart();
                if (!halconWinControl_ROI1.Exit_Image())
                {
                    halconWinControl_ROI1.Ho_Image.Dispose();
                }
                halconWinControl_ROI1.Ho_Image = this._blob.ImageFather.Ho_image;
                _stopWatch.Stop();

                Invoke(new Action(delegate
                {
                    m_CtrlHStatusLabelCtrl.Text = _stopWatch.ElapsedMilliseconds.ToString();
                }));
                ok = true;

            }
            catch (Exception ex)
            {
                LogManager.WriteLog(LogFile.Error, "取图片一张出错");
                MessageBox.Show("取图片一张出错:" + ex.Message);
                ok = false;
            }
            return ok;
        }
        #endregion

        #region 退出
        private void acquriefrm_FormClosing(object sender, FormClosingEventArgs e)
        {

            // MachineVision.ShuJuJieGou.TreeStatic.Mult_Tree_Node.Obj = _re;         

        }
        #endregion

        #region  刷新定位点
        private void tSB_ShuaXinDingWeiDian_Click(object sender, EventArgs e)
        {
            _setBlob.Set_ShuaXinDingWeiDian(this._blob);
        }
        #endregion

        #region 确定参数  
        private void bnt_QueDingCanShuJu_Click(object sender, EventArgs e)
        {
            this._setBlob.Set_SheZhiCanShu(this._blob, numericUpDown_MinGray.Value.ToString(), numericUpDown_MaxGray.Value.ToString(), comboBox_Features.Text, numericUpDown_Min.Value.ToString(), numericUpDown_Max.Value.ToString());
            run();
        }
        #endregion
    }
}
