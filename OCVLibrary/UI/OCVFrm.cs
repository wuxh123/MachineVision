#define DEBUG
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
using System.Diagnostics;
using ReadImageHalconLibrary;
using MultTree;
using LogClassLibrary;



namespace OCVLibrary.UI
{
    public partial class OCVFrm : Form
    {
        #region    全局变量

        //#region    循环运行的标志
        ///// <summary>
        ///// 循环运行的标志
        ///// </summary>
        //public bool _xun_huan_yun_xing_biao_zhi = false;
        //#endregion

        //#region   读图的数据
        ///// <summary>
        ///// 读图的数据
        ///// </summary>
        //public IReadShuJu _re;
        //#endregion

        //#region   取图工具
        ///// <summary>
        ///// 取图工具
        ///// </summary>
        //IReadImage _IRead = new ReadImageHalconLibrary.ReadImage();
        //#endregion

        #region  委托,事件
        /// <summary>
        /// 委托
        /// </summary>
        /// <returns></returns>
        delegate bool _run_delegate();

        /// <summary>
        /// 读取图片事件 
        /// </summary>
        event _run_delegate _read;

        /// <summary>
        /// 运行事件
        /// </summary>
        event _run_delegate _run;

        #endregion

        #region   检测时间
        /// <summary>
        /// 检测时间
        /// </summary>
        Stopwatch _stopWatch = new Stopwatch();
        #endregion

        #region   设置取图工具
        SetReadShuJu Set_ReadShuJu = new SetReadShuJu();
        #endregion

        #region  ocv

        /// <summary>
        /// OCV数据接口
        /// </summary>
        IOCVShuJu _IOCV;

        ///// <summary>
        ///// ocv工具
        ///// </summary>
        //OCV _OCV;

        /// <summary>
        /// 设置ocv数据
        /// </summary>
        Set_OCVShuJu _Set_OCV = new Set_OCVShuJu();

        #region  无用代码
        ///// <summary>
        ///// ocv创建工具
        ///// </summary>
        //OCVCreateShuJu _OCV_Create = new OCVCreateShuJu();
        #endregion

        #endregion

        #region   结果
        /// <summary>
        /// 结果
        /// </summary>
        Dictionary<string, Object> _result = new Dictionary<string, object>();

        #endregion


        #endregion

        #region   构造函数
        public OCVFrm()
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
            halconWinControl_ROI1.Repaint += repaint;

            _read += read_one_image;
            _run += run;

            //_OCV = new OCV();

            #region  无用代码
            #region  逻辑控制
            //_read_event = new AutoResetEvent(false);

            //_run_event = new AutoResetEvent(false);

            #endregion

            #region   初始化线程

            //_read_th = new Thread(new ThreadStart(read_one_image));
            //_read_th.Name = "取图线程";
            //_run_th = new Thread(new ThreadStart(run));
            //_run_th.Name = "检测线程";
            //_read_th.Start();
            //_run_th.Start();

            #endregion
            #endregion

            //#region 初始化数据
            //if (TreeStatic.Mult_Tree_Node_Picture != null)
            //{
            //    if (TreeStatic.Mult_Tree_Node_Picture.SelfId.Contains("acquire"))
            //    {
            //        _re = (ReadShuJu)TreeStatic.Mult_Tree_Node_Picture.Obj;

            //        #region  把图片写入

            //        foreach (string file_name in _re.Path_Picture)
            //        {
            //            listBox_acquire_picture.Items.Add(file_name); //加载所有文件
            //        }
            //        #endregion
            //    }
            //    else
            //    {
            //        _re = new ReadShuJu();
            //    }
            //}
            //else
            //{
            //    _re = new ReadShuJu();
            //}
            //#endregion

#if DEBUG ==true
            if (TreeStatic.Mult_Tree_Node.Obj == null)
            {
                _IOCV = new OCVShuJu();
            }
            else
            {
                _IOCV = (OCVShuJu)TreeStatic.Mult_Tree_Node.Obj;
            }
#else
            _IOCV = new OCVHalcon.OCVShuJu.OCVShuJu();
#endif

            _Set_OCV.Set_showParameterHalconWinControl(_IOCV, this.Controls, this.halconWinControl_ROI1);

        }
        #endregion

        //#region  循环运行
        //private void tSB_circulation_run_Click(object sender, EventArgs e)
        //{
        //    string str = tSB_circulation_run.Text;
        //    if (str == "循环运行")
        //    {
        //        _xun_huan_yun_xing_biao_zhi = true;
        //        tSB_circulation_run.Text = "停止循环";

        //        trigger_read();

        //    }
        //    else
        //    {
        //        _xun_huan_yun_xing_biao_zhi = false;

        //        tSB_circulation_run.Text = "循环运行";
        //    }
        //}
        //#endregion

        #region     运行
        private void tSB_run_one_Click(object sender, EventArgs e)
        {
            trigger_run();
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

            //_OCV.OCV_Check(halconWinControl_ROI1.Ho_Image, _IOCV);
            //_OCV.OCV_Show(_IOCV, halconWinControl_ROI1.HalconWindow1);

            this._result.Clear();
            this._IOCV.analyze_show(halconWinControl_ROI1.HalconWindow1, "1", ref _result);

            _stopWatch.Stop();

            Invoke(new Action(delegate
            {
                m_CtrlHStatusLabelCtrl.Text = _stopWatch.ElapsedMilliseconds.ToString();
                //if (_xun_huan_yun_xing_biao_zhi)
                //{
                //    Thread th = new Thread(new ThreadStart(() =>
                //    {
                //        trigger_read();
                //    }));
                //    th.Start();
                //}
            }));

            ok = true;
            return ok;
        }
        #endregion

        #region   读取一张图片事件

        bool read_one_image()
        {
            bool ok = false;
            try
            {
                _stopWatch.Restart();

                if (!halconWinControl_ROI1.Exit_Image())
                {
                    halconWinControl_ROI1.Ho_Image.Dispose();
                    //_IRead.read_Image(_re);
                  
                }
                halconWinControl_ROI1.Ho_Image = this._IOCV.ImageFather.Ho_image;
                _stopWatch.Stop();

                Invoke(new Action(delegate
                {
                    m_CtrlHStatusLabelCtrl.Text = _stopWatch.ElapsedMilliseconds.ToString();
                }));

                //if (_xun_huan_yun_xing_biao_zhi == true)
                //{
                //    Thread thr = new Thread(new ThreadStart(this.trigger_run));
                //    thr.Start();
                //}

                #region   无用代码
                //int i = listBox_acquire_picture.Items.Count;
                //if (i > 0)
                //{
                //    if (_number_Image >= i)
                //    {
                //        _number_Image = 0;
                //    }

                //    ReadImageHalcon.Tool.readImage read = new ReadImageHalcon.Tool.readImage();
                //    listBox_acquire_picture.SelectedIndex = _number_Image;

                //    string path = listBox_acquire_picture.SelectedItem.ToString();
                //    _number_Image++;

                //    read.read_Image(path, halconWinControl_11.HalconWindow1);
                //    halconWinControl_11.Ho_Image = read.ho_Image;
                //    ok = true;

                //    if (_xun_huan_yun_xing_biao_zhi)
                //    {
                //        if (_read != null)
                //        {
                //            _read();
                //        }
                //    }
                //}
                #endregion
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

        #region  取一张图片
        private void tSB_read_image_Click(object sender, EventArgs e)
        {
            trigger_read();
        }
        #endregion

        #region 退出
        private void acquriefrm_FormClosing(object sender, FormClosingEventArgs e)
        {

            // MachineVision.ShuJuJieGou.TreeStatic.Mult_Tree_Node.Obj = _re;         

        }
        #endregion

        //#region    添加图片
        //private void bnt_add_picture_Click(object sender, EventArgs e)
        //{
        //    OpenFileDialog open_file = new OpenFileDialog();
        //    open_file.Filter = "All files (*.*)|*.*|TIFF files (*.tif)|*tif";
        //    open_file.FilterIndex = 2;
        //    open_file.RestoreDirectory = true;
        //    open_file.Multiselect = true;
        //    open_file.ShowDialog();//打开对话框           

        //    if (listBox_acquire_picture.Items.Count != 0)//判断有无图片
        //    {
        //        listBox_acquire_picture.Items.Clear();//清空图片
        //    }

        //    if (_re.Path_Picture.Count != 0)
        //    {
        //        _re.Path_Picture.Clear();
        //    }

        //    foreach (string file_name in open_file.FileNames)
        //    {
        //        listBox_acquire_picture.Items.Add(file_name); //加载所有文件

        //        _re.Path_Picture.Add(file_name);

        //    }
        //}
        //#endregion

        //#region     删除图片
        //private void btn_delete_picture_Click(object sender, EventArgs e)
        //{
        //    listBox_acquire_picture.Items.Clear();
        //}
        //#endregion

        //#region    移除图片
        //private void btn_remove_picture_Click(object sender, EventArgs e)
        //{

        //}

        //#endregion

        #region  无用代码
        #region 读取图片后的回调函数
        //void read_callBack(IAsyncResult re)
        //{
        //    if (_xun_huan_yun_xing_biao_zhi)
        //    {
        //        _read.BeginInvoke(read_callBack, null);
        //    }
        //}
        #endregion
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

        #region   出发运行
        /// <summary>
        /// 出发运行
        /// </summary>
        void trigger_run()
        {
            if (_run != null)
            {
                _run();
            }
        }
        #endregion

        #region  截取丝印检测的region
        private void bnt_cut_out_check_region_Click(object sender, EventArgs e)
        {
            #region  无用代码
            //double row1=0, column1=0, row2=0, column2=0;

            //halconWinControl_ROI1.DrawRectangle1("red", out row1, out column1, out row2, out column2);

            //_Set_OCV.Set_OCVRegionPonit(_IOCV, row1, column1, row2, column2);
            #endregion
            string str = hv_PatternNames.Text;
            _Set_OCV.Set_ChangeOCV(halconWinControl_ROI1.Ho_Image, halconWinControl_ROI1.HalconWindow1, _IOCV, ref str);
        }
        #endregion

        #region   刷新窗口事件
        /// <summary>
        /// 刷新窗口事件
        /// </summary>
        /// <param name="win">要刷新的窗体</param>
        void repaint(HWindow win)
        {
            //_OCV.OCV_Show(_IOCV, win);
            this._IOCV.show(halconWinControl_ROI1.HalconWindow1);
        }
        #endregion

        #region  确定丝印检测灰度的误差
        private void bnt_threshold_confrim_Click(object sender, EventArgs e)
        {
            string str = hv_Threshold.Text;

            _Set_OCV.Set_OCVParameter(_IOCV, null, null, null, null, str);

        }
        #endregion

        #region  检测丝印位置标志
        private void hv_AdaptPos_SelectedValueChanged(object sender, EventArgs e)
        {
            string str = hv_AdaptPos.Text;

            _Set_OCV.Set_OCVParameter(_IOCV, str, null, null, null, null);
        }
        #endregion

        #region  检测丝印大小标志
        private void hv_AdaptSize_SelectedValueChanged(object sender, EventArgs e)
        {
            string str = hv_AdaptSize.Text;

            _Set_OCV.Set_OCVParameter(_IOCV, null, str, null, null, null);
        }
        #endregion

        #region 检测丝印角度标志
        private void hv_AdaptAngle_SelectedValueChanged(object sender, EventArgs e)
        {
            string str = hv_AdaptAngle.Text;

            _Set_OCV.Set_OCVParameter(_IOCV, null, null, str, null, null);
        }
        #endregion

        #region  检测丝印灰度标志
        private void hv_AdaptGray_SelectedValueChanged(object sender, EventArgs e)
        {
            string str = hv_AdaptGray.Text;

            _Set_OCV.Set_OCVParameter(_IOCV, null, null, null, str, null);
        }
        #endregion

        #region  获取创建OCV的区域
        private void bnt_get_create_ocv_region_Click(object sender, EventArgs e)
        {

        }
        #endregion

        #region 无用代码
        //#region  修改当前ocv
        //private void bnt_change_ocv_Click(object sender, EventArgs e)
        //{
        //    string str = _IOCV.Hv_PatternNames;
        //    Invoke(new Action(delegate {
        //        txt_ocv_name.Text = str;            
        //    }));

        //    double row1, column1, row2, column2;
        //    halconWinControl_Draw1.DrawRectangle1("red", out row1, out column1, out row2, out column2);
        //    _Set_OCV.Set_OCVRegionPonit(_IOCV, row1, column1, row2, column2);            
        //    _OCV_Create.ChangeOcv(_IOCV);
        //    _OCV_Create.Training(halconWinControl_Draw1.Ho_Image, _IOCV, halconWinControl_Draw1.HalconWindow1);

        //    Show_gB_training_ocv();
        //}
        //#endregion

        //#region    把当前训练的ocv写入当前ocv工具
        //private void bnt_write_ocv_Click(object sender, EventArgs e)
        //{
        //    _OCV_Create.Save_current_ocv_tool(_IOCV);
        //    _Set_OCV.Set_showParameterHalconWinControl(_IOCV, this.Controls, null);
        //}
        //#endregion

        //#region   保存训练的ocv工具
        //private void bnt_save_ocv_Click(object sender, EventArgs e)
        //{
        //    _OCV_Create.WriteOCVCreate();
        //}
        //#endregion

        //#region   创建region
        ////private void bnt_get_create_ocv_region_Click_1(object sender, EventArgs e)
        ////{
        ////    double row1=0, column1=0, row2=0, column2=0;

        ////    //halconWinControl_ROI1.DrawRectangle1("red", out row1, out column1, out row2, out column2);

        ////    _OCV_Create.SetOCVCreateRegion(ref row1, ref column1, ref row2, ref column2);
        ////}
        //#endregion   

        //#region 测试当前训练的OCV
        //private void bnt_check_training_OCV_Click(object sender, EventArgs e)
        //{
        //    _OCV_Create.CheckTrainingOCV(_IOCV, halconWinControl_ROI1.Ho_Image, halconWinControl_ROI1.HalconWindow1);
        //}
        //#endregion

        //#region  使能训练组
        ///// <summary>
        ///// 使能训练组
        ///// </summary>
        //void Show_gB_training_ocv()
        //{
        //    Invoke(new Action(delegate
        //    {

        //        gB_training_ocv.Enabled = true;
        //    }));
        //}
        //#endregion
        #endregion

        #region      训练当前丝印质量
        private void _trained_CheckedChanged(object sender, EventArgs e)
        {
            //string str = "";
            this._Set_OCV.Set_OcvTrained_Class(this._IOCV, this._trained.Checked, _ocvTrainingQuality.Text);
            //_ocvTrainingQuality.Text = str;

        }
        #endregion

        #region  确定训练的对比质量
        private void _ocvTrainingQuality_sure_Click(object sender, EventArgs e)
        {
            this._Set_OCV.Set_OcvTrained_Class(this._IOCV, this._trained.Checked, _ocvTrainingQuality.Text);
        }
        #endregion

        #region  刷新定位点
        private void tSB_ShuaXinDingWeiDian_Click(object sender, EventArgs e)
        {
            this._Set_OCV.Set_ShuaXinDingWeiDian(this._IOCV);
        }
        #endregion

        #region  无用代码
        //#region  设置取图方式
        //private void Acquire_SelectedIndexChanged(object sender, EventArgs e)
        //{
        //    string str=Acquire.Text;
        //    Set_ReadShuJu.Set_Acquire(_IRead, str);

        //}
        //#endregion
        #endregion
    }
}
