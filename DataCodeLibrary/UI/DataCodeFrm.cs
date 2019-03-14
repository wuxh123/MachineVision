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
using HalControl.ROI;





namespace DataCodeLibrary.UI
{
    public partial class DataCodeFrm : Form
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
        //ReadImageHalconLibrary.IReadShuJu _IRead;
        //#endregion

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

        //#region   取图数据
        ///// <summary>
        ///// 取图数据
        ///// </summary>
        //ReadImageHalconLibrary.SetReadShuJu Set_ReadShuJu = new ReadImageHalconLibrary.SetReadShuJu();
        //#endregion

        //#region  取图工具
        ///// <summary>
        ///// 取图工具
        ///// </summary>
        //ReadImageHalconLibrary.IReadImage ReadImage = new ReadImageHalconLibrary.ReadImage();
        //#endregion

        #region  数据设置器
        /// <summary>
        /// 数据设置器
        /// </summary>
        Set_DataCodeShuJu _set_DateCode;
        #endregion

        #region   二维码数据
        /// <summary>
        /// 二维码数据
        /// </summary>
        IDataCodeShuJu _iDataCodeShuJu;
        #endregion

        #region  结果
        /// <summary>
        /// 结果
        /// </summary>
        Dictionary<string, Object> _result=new Dictionary<string,object>();
        #endregion

        //#region  二维码数据处理器
        ///// <summary>
        ///// 二维码数据处理器
        ///// </summary>
        //DataCode _dateCode;
        //#endregion

        #endregion

        #region   构造函数
        public DataCodeFrm()
        {
            InitializeComponent();

            #region  无用代码
            //BeginInvoke(new Action(delegate
            //{
            //HOperatorSet.GenEmptyObj(out _ho_Image);
            //_ho_Image.Dispose();
            //}));
            #endregion
        }
        #endregion

        #region  初始化
        private void ParentFrm_Load(object sender, EventArgs e)
        {

            halconWinControl_ROI1.init();

            _read += read_one_image;
            _run += run;

            _set_DateCode = new Set_DataCodeShuJu();
            //_dateCode = new DataCode();

            //#region 初始化数据 图片数据
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

#if DEBUG == true
            if (TreeStatic.Mult_Tree_Node.Obj == null)
            {
                _iDataCodeShuJu = new DataCodeShuJu();
            }
            else
            {
                _iDataCodeShuJu = (DataCodeShuJu)TreeStatic.Mult_Tree_Node.Obj; ;
            }
#else
            _iDataCodeShuJu = new DataCodeShuJu();
#endif

            _set_DateCode.Set_showParameterHalconWinControl(_iDataCodeShuJu, this.Controls, this.halconWinControl_ROI1);

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

        bool run()
        {
            if (halconWinControl_ROI1.Exit_Image() == false)
                return false;

            bool ok = false;
            _stopWatch.Restart();
            //_dateCode.DateCodeFind(this._iDataCodeShuJu, this.halconWinControl_ROI1.Ho_Image);
            //_dateCode.DateCodeShow(this._iDataCodeShuJu, this.halconWinControl_ROI1.HWindowControl.HalconWindow);
            this._result.Clear();
            this._iDataCodeShuJu.analyze_show( halconWinControl_ROI1.HalconWindow1, "1",ref  this._result);
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
                if (!halconWinControl_ROI1.Exit_Image())
                {
                    halconWinControl_ROI1.Ho_Image.Dispose();
                    //ReadImage.read_Image(this._IRead);                   
                }
                halconWinControl_ROI1.Ho_Image = this._iDataCodeShuJu.ImageFather.Ho_image;
                //if (_xun_huan_yun_xing_biao_zhi)
                //{
                //    trigger_run();
                //}
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

        #region 确定创建参数
        private void bnt_sure_create_parameter_Click(object sender, EventArgs e)
        {
            _set_DateCode.Set_createCode2Paramter(_iDataCodeShuJu, Create_hv_SymbolType.Text, Create_hv_GenParamNames.Text, Create_hv_GenParamValues.Text);
        }
        #endregion

        #region  确定查找参数
        private void bnt_sure_find_parameter_Click(object sender, EventArgs e)
        {
            _set_DateCode.Set_findCode2Parameter(_iDataCodeShuJu, Find_hv_GenParamNames.Text, numericUpDown_Find_hv_GenParaValues.Text);
        }
        #endregion

        #region 刷新定位点
        private void tSB_ShuaXinDingWeiDian_Click(object sender, EventArgs e)
        {
            this._set_DateCode.Set_ShuaXinDingWeiDian(this._iDataCodeShuJu);
        }
        #endregion

    }
}
