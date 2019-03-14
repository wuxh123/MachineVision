using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using HalconDotNet;
using System.Diagnostics;
using LogClassLibrary;
using MultTree;


namespace OCRTextLibrary.UI
{
    public partial class OCRTextFrm : Form
    {
        #region  全局变量

        #region   ocr文本
        /// <summary>
        /// ocr文本
        /// </summary>
        IOCRTextShuJu _iOCRText;
        /// <summary>
        /// ocr文本设置器
        /// </summary>
        Set_OCRTextLibrary _Set_OCRText = new Set_OCRTextLibrary();
        #endregion

        #region  委托,事件
        /// <summary>
        /// 委托
        /// </summary>
        /// <returns></returns>
        delegate bool _run_delegate();

        /// <summary>
        ///运行的算法
        /// </summary>
        event _run_delegate _run;

        /// <summary>
        /// 事件 
        /// </summary>
        event _run_delegate _read;

        #endregion

        #region   检测时间
        /// <summary>
        /// 检测时间
        /// </summary>
        Stopwatch _stopWatch = new Stopwatch();
        #endregion

        #region 结果
        /// <summary>
        /// 结果
        /// </summary>
        Dictionary<string, Object> _result = new Dictionary<string, object>();
        #endregion

        #endregion

        #region    构造函数
        public OCRTextFrm()
        {
            InitializeComponent();
        }
        #endregion

        #region  初始化
        private void OCRTextFrm_Load(object sender, EventArgs e)
        {
            halconWinControl_ROI1.init();
            halconWinControl_ROI1.Repaint += repaint;
            _read += read_one_image;
            _run += run;


#if DEBUG == true
            if (TreeStatic.Mult_Tree_Node.Obj == null)
            {
                _iOCRText =new OCRTextShuJu();
            }
            else
            {
                _iOCRText = (OCRTextShuJu)TreeStatic.Mult_Tree_Node.Obj; ;
            }
#else
           _IOCR = new OCRHalcon.OCRShuJu.OCRShuJu();
#endif
            this._Set_OCRText.Set_showParameterHalconWinControl(this._iOCRText, this.Controls, this.halconWinControl_ROI1);
            Hv_FileName.SelectedValueChanged += chice_ocr_omc;


        }
        #endregion

        #region   读取一张图片事件
        bool read_one_image()
        {
            bool ok = false;
            try
            {
                if (!halconWinControl_ROI1.Exit_Image())
                {
                    halconWinControl_ROI1.Ho_Image.Dispose();
                }
                halconWinControl_ROI1.Ho_Image = this._iOCRText.ImageFather.Ho_image;                               
            }
            catch (Exception ex)
            {
                LogManager.WriteLog(LogFile.Error, "取图片一张出错");
                MessageBox.Show(ex.Message + " " + "取图片一张出错");
                ok = false;
            }
            return ok;
        }
        #endregion

        #region  运行
        bool run()
        {
            if (halconWinControl_ROI1.Exit_Image() == false)
            { return false; }

            _stopWatch.Restart();
            bool ok = false;
                        
            this._result.Clear();
            this._iOCRText.analyze_show(halconWinControl_ROI1.HalconWindow1, "1", ref _result);

            _stopWatch.Stop();

            Invoke(new Action(delegate
            {
                m_CtrlHStatusLabelCtrl.Text = _stopWatch.ElapsedMilliseconds.ToString();
             
            }));
            ok = true;
            return ok;
        }
        #endregion
        
        #region   刷新窗口事件
        /// <summary>
        /// 刷新窗口事件
        /// </summary>
        /// <param name="win">要刷新的窗体</param>
        void repaint(HWindow win)
        {
            this._iOCRText.show(halconWinControl_ROI1.HalconWindow1);
        }
        #endregion

        #region   单步运行
        private void tSB_run_one_Click(object sender, EventArgs e)
        {
            trigger_run();
        }

        #region 运行触发器
        /// <summary>
        /// 运行触发器
        /// </summary>
        void trigger_run()
        {
            if (_run != null)
            {
                _run();
            }
        }
        #endregion

        #endregion

        #region  取一张图片
        private void tSB_read_image_Click(object sender, EventArgs e)
        {
            trigger_read();
        }
        #endregion

        #region   触发取图
        /// <summary>
        /// 触发取图
        /// </summary>
        void trigger_read()
        {
            if (_read != null)
            {
                _read();
            }
        }
        #endregion

        #region  选择字库
        /// <summary>
        /// 选择字库
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void chice_ocr_omc(object sender, EventArgs e)
        {
            string str = Hv_FileName.Text;
            this._Set_OCRText.Set_GengHuanZiKu(this._iOCRText, str);
          
        }
        #endregion

        #region  刷新定位点
        private void tSB_shua_xin_ding_wei_dian_Click(object sender, EventArgs e)
        {
            this._Set_OCRText.Set_ShuaXinDingWeiDian(this._iOCRText);
        }
        #endregion
    }
}
