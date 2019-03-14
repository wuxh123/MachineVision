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
using MultTree;
using LogClassLibrary;
using ReadImageHalconLibrary;




namespace BackGroundCheckHalconLibrary.UI
{
    public partial class BackGroundFrm : Form
    {
        #region    全局变量

        //#region    循环运行的标志
        ///// <summary>
        ///// 循环运行的标志
        ///// </summary>
        //bool _xun_huan_yun_xing_biao_zhi = false;
        //#endregion

        //#region   读图的数据
        ///// <summary>
        ///// 读图的数据
        ///// </summary>
        //ReadImageHalconLibrary.IReadShuJu _IRead;
        //#endregion

        #region  委托,事件
        /// <summary>
        /// 委托
        /// </summary>
        /// <returns></returns>
        delegate bool _run_delegate();

        /// <summary>
        /// 取图事件 
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
        Stopwatch _stop_watch = new Stopwatch();
        #endregion

        //#region   取图数据
        //// ReadImageHalcon.ReadImageShuJu.SetReadShuJu Set_ReadShuJu = new ReadImageHalcon.ReadImageShuJu.SetReadShuJu();
        //ReadImageHalconLibrary.SetReadShuJu Set_ReadShuJu = new ReadImageHalconLibrary.SetReadShuJu();
        //#endregion

        //#region  取图工具
        ///// <summary>
        ///// 取图工具
        ///// </summary>
        //ReadImageHalconLibrary.IReadImage ReadImage = new ReadImageHalconLibrary.ReadImage();
        //#endregion

        #region   背景检测数据
        /// <summary>
        /// 背景检测数据
        /// </summary>
        IBackGroundShuJu _IBackShuJu = null;
        #endregion

        #region   背景检测数据设置器
        /// <summary>
        /// 背景检测数据设置器
        /// </summary>
        Set_BackGroundShuJu _SetIBack = new Set_BackGroundShuJu();
        #endregion

        //#region   背景检测工具
        ///// <summary>
        ///// 背景检测工具
        ///// </summary>
        //BackkGroundTool _BackGroundTool = new BackkGroundTool();
        //#endregion

        #region   结果
        /// <summary>
        /// 结果
        /// </summary>
        Dictionary<string, Object> _result = new Dictionary<string, object>();
        #endregion

        #endregion

        #region   构造函数
        public BackGroundFrm()
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
            _read += read_one_image;
            _run += run;

            #region  无用代码
            //#region 初始化数据
            //if (TreeStatic.Mult_Tree_Node_Picture != null)
            //{
            //    if (TreeStatic.Mult_Tree_Node_Picture.SelfId.Contains("acquire"))
            //    {
            //        _IRead = (ReadImageHalconLibrary.ReadShuJu)TreeStatic.Mult_Tree_Node_Picture.Obj;
            //        #region  把图片写入

            //        foreach (string file_name in _IRead.Path_Picture)
            //        {
            //            listBox_acquire_picture.Items.Add(file_name); //加载所有文件
            //        }
            //        #endregion
            //    }
            //    else
            //    {
            //        _IRead = new ReadImageHalconLibrary.ReadShuJu();
            //    }
            //}
            //else
            //{
            //    _IRead = new ReadImageHalconLibrary.ReadShuJu();
            //}
            //#endregion
            #endregion

#if DEBUG ==true
            if (TreeStatic.Mult_Tree_Node.Obj == null)
            {
                _IBackShuJu = new BackGroundShuJu();
            }
            else
            {
                _IBackShuJu = (BackGroundShuJu)TreeStatic.Mult_Tree_Node.Obj;
            }
#else
              _IBackShuJu = new BackGroundShuJu();
#endif
            this._SetIBack.Set_showBackGroundHalconWinControl(this._IBackShuJu, this.Controls, this.halconWinControl_ROI1);

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
            this.trigger_run();
        }

        #region  无用代码
        /// <summary>
        /// 运行成功后回调
        /// </summary>
        //void run_callBack(IAsyncResult re)
        //{
        //    if (_xun_huan_yun_xing_biao_zhi)
        //    {
        //        timer_run.Enabled = true;
        //    }
        //}
        #endregion

        #region  运行
        /// <summary>
        /// 运行检测
        /// </summary>
        bool run()
        {
            if (halconWinControl_ROI1.Exit_Image() == false)
            {
                return false;
            }
            _stop_watch.Restart();
            bool ok = false;

            //this._BackGroundTool.ImageArithmetic(this._IBackShuJu, halconWinControl_ROI1.Ho_Image);
            //this._BackGroundTool.ShowBackkGround(this._IBackShuJu, halconWinControl_ROI1.HWindowControl.HalconWindow);
            this._result.Clear();
            this._IBackShuJu.analyze_show(halconWinControl_ROI1.HalconWindow1, "1", ref this._result);

            Invoke(new Action(delegate
            {
                m_CtrlHStatusLabelCtrl.Text = _stop_watch.ElapsedMilliseconds.ToString();
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
        #endregion

        #region   读取一张图片事件
        /// <summary>
        /// 读取一张图片事件
        /// </summary>
        /// <returns></returns>
        bool read_one_image()
        {
            bool ok = false;
            try
            {
                if (!halconWinControl_ROI1.Exit_Image())//防止图片出错
                {
                    halconWinControl_ROI1.Ho_Image.Dispose();
                }

                halconWinControl_ROI1.Ho_Image = this._IBackShuJu.ImageFather.Ho_image;

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

        //    if (_IRead.Path_Picture.Count != 0)
        //    {
        //        _IRead.Path_Picture.Clear();
        //    }

        //    foreach (string file_name in open_file.FileNames)
        //    {
        //        listBox_acquire_picture.Items.Add(file_name); //加载所有文件

        //        _IRead.Path_Picture.Add(file_name);

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

        #region   触发运行
        /// <summary>
        /// 触发运行
        /// </summary>
        void trigger_run()
        {
            if (_run != null)
            {
                _run();
            }
        }
        #endregion

        #region   重建掩盖区域
        private void bnt_CoverUpRegion_Click(object sender, EventArgs e)
        {
            if (!halconWinControl_ROI1.Exit_Image())
            {
                return;
            }

            this._SetIBack.grindQuYu(this._IBackShuJu, this.halconWinControl_ROI1.Ho_Image, halconWinControl_ROI1.HWindowControl.HalconWindow);
            this._SetIBack.Set_modelImage(this._IBackShuJu, this.halconWinControl_ROI1.Ho_Image);

            bnt_CoverUpRegion.Text = "重建掩盖区域成功";

        }
        #endregion

        #region     确定掩盖参数
        private void bnt_coverUpParameter_Click(object sender, EventArgs e)
        {
            this._SetIBack.Set_CoverUp(this._IBackShuJu, numericUpDown_MinGray.Text, numericUpDown_MaxGray.Text, numericUpDown_DilationRadius.Text);
        }
        #endregion

        #region  无用代码
        //#region  确定图片对比的参数的对比灰度值
        //private void bnt_OffsetSure_Click(object sender, EventArgs e)
        //{
        //    this._SetIBack.Set_dynParameter(this._IBackShuJu, Offset.Text, null, null, null, null, null);
        //}
        //#endregion
        //#region  确定图片对比的参数的查找极性
        //private void bnt_LightDarkSure_Click(object sender, EventArgs e)
        //{
        //    this._SetIBack.Set_dynParameter(this._IBackShuJu, null, LightDark.Text, null, null, null, null);
        //}
        //#endregion
        //#region    设置模板图片
        //private void bnt_setModelImage_Click(object sender, EventArgs e)
        //{
        //    if (!halconWinControl_ROI1.Exit_Image())
        //    {
        //        return;
        //    }
        //    this._SetIBack.Set_modelImage(this._IBackShuJu, this.halconWinControl_ROI1.Ho_Image);
        //}
        //#endregion
        //#region   Max
        //private void but_Max_Click(object sender, EventArgs e)
        //{
        //    this._SetIBack.Set_dynParameter(this._IBackShuJu, null, null, null, null, null, txt_Max.Text);
        //}
        //#endregion
        #endregion

        #region 刷新定位点
        private void tSB_ChongXinShuaXinDingWeiDian_Click(object sender, EventArgs e)
        {
            this._SetIBack.Set_ChongXinShuaXinDingWeiDian(this._IBackShuJu);
        }
        #endregion

        #region  确定参数
        private void but_Min_Click(object sender, EventArgs e)
        {
            this._SetIBack.Set_dynParameter(this._IBackShuJu, numericUpDown_Offset.Text, LightDark.Text, null, null, numericUpDown_txt_Min.Text, numericUpDown_txt_Max.Text);
        }
        #endregion
    }
}
