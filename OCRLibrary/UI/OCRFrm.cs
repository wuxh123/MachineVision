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
using HalControl;




namespace OCRLibrary.UI
{
    public partial class OCRFrm : Form
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
        //IReadShuJu _re;
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

        #region   ocr
        /// <summary>
        /// ocr数据
        /// </summary>
        IOCRShuJu _IOCR;
        /// <summary>
        /// OCR设置
        /// </summary>
        Set_OCRShuJu _Set_OCR = new Set_OCRShuJu();
        ///// <summary>
        ///// OCR数据分析器
        ///// </summary>
        //OCR _OCR;
        #endregion

        #region 结果
        /// <summary>
        /// 结果
        /// </summary>
        Dictionary<string, Object> _result = new Dictionary<string, object>();
        #endregion

        #region  无用代码
        //#region  创建字符库线程
        ///// <summary>
        ///// 创建字符库线程
        ///// </summary>
        //Thread _thr_create_training_ocr;
        ///// <summary>
        ///// 创建字符库线程
        ///// </summary>
        //AutoResetEvent _auto_thr_create_training_ocr_run;
        ///// <summary>
        ///// 创建字符库线程
        ///// </summary>
        //AutoResetEvent _auto_thr_create_training_ocr_train;
        //#endregion
        //#region  训练当前字符线程
        ///// <summary>
        ///// 训练当前ocr
        ///// </summary>
        //Thread _thr_current_training_ocr;

        ///// <summary>
        ///// 训练当前ocr
        ///// </summary>
        //AutoResetEvent _auto_thr_current_training_ocr_run;

        ///// <summary>
        ///// 训练当前ocr
        ///// </summary>
        //AutoResetEvent _auto_thr_current_training_ocr_train;
        //#endregion

        //#region  训练的字符
        ///// <summary>
        ///// 训练的字符
        ///// </summary>
        //StringBuilder _train_str = new StringBuilder();
        //#endregion
        #endregion

        #endregion

        #region   构造函数
        public OCRFrm()
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

            #region 无用代码
            //_OCR = new OCR();
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
            #endregion

#if DEBUG == true
            if (TreeStatic.Mult_Tree_Node.Obj == null)
            {
                _IOCR = new OCRShuJu();
            }
            else
            {
                _IOCR = (OCRShuJu)TreeStatic.Mult_Tree_Node.Obj; ;
            }
#else
           _IOCR = new OCRHalcon.OCRShuJu.OCRShuJu();
#endif
            _Set_OCR.Set_showParameterHalconWinControl(_IOCR, this.Controls, this.halconWinControl_ROI1);
            Hv_FileName.SelectedValueChanged += chice_ocr_omc;
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

        bool run()
        {
            if (halconWinControl_ROI1.Exit_Image() == false)
            { return false; }

            _stopWatch.Restart();
            bool ok = false;

            //_OCR.OCR_Read(_IOCR, halconWinControl_ROI1.Ho_Image);
            //_OCR.OCR_Show(_IOCR, halconWinControl_ROI1.HalconWindow1);
            this._result.Clear();
            this._IOCR.analyze_show(halconWinControl_ROI1.HalconWindow1, "1", ref _result);
            
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
                  
                }
                halconWinControl_ROI1.Ho_Image = this._IOCR.ImageFather.Ho_image;

                //if (_xun_huan_yun_xing_biao_zhi)
                //{
                //    trigger_run();
                //}
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

        #region  取一张图片
        private void tSB_read_image_Click(object sender, EventArgs e)
        {
            trigger_read();
        }
        #endregion

        #region 退出
        private void acquriefrm_FormClosing(object sender, FormClosingEventArgs e)
        {
            _Set_OCR = null;
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
      

        #region  截取ocr读取的region
        private void bnt_rectangle1_Click(object sender, EventArgs e)
        {
            //double row1, column1, row2, column2;

            //halconWinControl_ROI1.DrawRectangle1("red", out row1, out column1, out row2, out column2);

            //_Set_OCR.Set_OCRCheckRegion(_IOCR, row1, column1, row2, column2);


        }
        #endregion

        #region   刷新窗口事件
        /// <summary>
        /// 刷新窗口事件
        /// </summary>
        /// <param name="win">要刷新的窗体</param>
        void repaint(HWindow win)
        {
            this._IOCR.show(halconWinControl_ROI1.HalconWindow1);
        }
        #endregion

        #region  无用代码
        //#region  emphasize参数
        //private void bnt_sure_emphasize_Click(object sender, EventArgs e)
        //{
        //    _Set_OCR.Set_OCREmphasize(_IOCR, MaskWidth.Text, MaskHeight.Text, Factor.Text);
        //}
        //#endregion

        //#region  scale_image参数
        //private void bnt_scale_image_Click(object sender, EventArgs e)
        //{
        //    _Set_OCR.Set_OCRScaleImage(_IOCR, Mult.Text, Add.Text);
        //}
        //#endregion
        #endregion

        #region   threshold参数
        private void bnt_threshold_Click(object sender, EventArgs e)
        {
            if (halconWinControl_ROI1.Exit_Image() == false)
                return;
            _Set_OCR.Set_OCRThreshold(_IOCR, MinGray.Text, MaxGray.Text);
            halconWinControl_ROI1.HWindowControl.HalconWindow.SetDraw("fill");
            _Set_OCR.Set_OCRCutOffRegion(_IOCR, halconWinControl_ROI1.Ho_Image, halconWinControl_ROI1.HalconWindow1);
            halconWinControl_ROI1.HWindowControl.HalconWindow.SetDraw("margin");
        }
        #endregion

        #region  select_shape参数
        private void bnt_select_shape_Click(object sender, EventArgs e)
        {
            if (halconWinControl_ROI1.Exit_Image() == false)
                return;

            _Set_OCR.Set_OCRSelectShape(_IOCR, Features.Text, Operation.Text, Min.Text, Max.Text);

            halconWinControl_ROI1.HWindowControl.HalconWindow.SetDraw("fill");
            _Set_OCR.Set_OCRCutOffRegion(_IOCR, halconWinControl_ROI1.Ho_Image, halconWinControl_ROI1.HalconWindow1);
            halconWinControl_ROI1.HWindowControl.HalconWindow.SetDraw("margin");
        }
        #endregion

        #region  无用代码
        //#region  显示OCR分割的效果
        //private void bnt_OCR_Cut_Off_Region_Click(object sender, EventArgs e)
        //{
        //    if (halconWinControl_ROI1.Exit_Image() == false)
        //        return;

        //    halconWinControl_ROI1.HWindowControl.HalconWindow.SetDraw("fill");
        //    _Set_OCR.Set_OCRCutOffRegion(_IOCR, halconWinControl_ROI1.Ho_Image, halconWinControl_ROI1.HalconWindow1);
        //    halconWinControl_ROI1.HWindowControl.HalconWindow.SetDraw("margin");
        //}
        //#endregion
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
            _Set_OCR.Set_ReplaceOCRWork(_IOCR, null, str);
            Path1.Text = _IOCR.Path1;
        }
        #endregion

        #region 加载特殊字库
        private void bnt_Load_Speciial_Work_Click(object sender, EventArgs e)
        {
            OpenFileDialog open_file = new OpenFileDialog();
            open_file.Filter = "OMC files (*.omc)|*omc";
            open_file.FilterIndex = 1;
            open_file.RestoreDirectory = true;
            open_file.Multiselect = true;

            if (open_file.ShowDialog()/*打开对话框 */== System.Windows.Forms.DialogResult.OK)
            {
                _Set_OCR.Set_ReplaceOCRWork(_IOCR, open_file.FileName, null);

                Path1.Text = _IOCR.Path1;
            }
        }
        #endregion

        #region  无用代码
        //#region  查看emphasize
        //private void bnt_check_emphaisze_result_Click(object sender, EventArgs e)
        //{
        //    if (!halconWinControl_ROI1.Exit_Image())
        //        return;

        //    //_Set_OCR.Set_CheckEmphasize(_IOCR, halconWinControl_ROI1.Ho_Image, halconWinControl_ROI1.HalconWindow1);
        //}
        //#endregion

        //#region  查看scale
        //private void bnt_check_scale_result_Click(object sender, EventArgs e)
        //{
        //    if (!halconWinControl_ROI1.Exit_Image())
        //        return;

        //    //_Set_OCR.Set_CheckScale(_IOCR, halconWinControl_ROI1.Ho_Image, halconWinControl_ROI1.HalconWindow1);
        //}
        //#endregion

        //#region  提取训练的region
        //private void bnt_extract_train_ocr_region_Click(object sender, EventArgs e)
        //{
        //    //_Set_OCR.Set_OCRCutOffRegion(_IOCR, halconWinControl_Draw1.Ho_Image, halconWinControl_Draw1.HalconWindow1);

        //}
        //#endregion
        #endregion

        #region 加载一个字符类
        private void bnt_Load_Class_Click(object sender, EventArgs e)
        {

        }
        #endregion

        #region  无用代码
        //#region  创建字库
        ////private void bnt_create_train_file_Click(object sender, EventArgs e)
        ////{
        ////    string str = hv_Class.Text;
        ////    string[] train_file = str.Split(',');

        ////    for (int i = 0; i < train_file.Length; i++)
        ////    {
        ////        _OCRTrainShuJu.Hv_Characters[i] = train_file[i];
        ////    }
        ////    _OCRTrainShuJu.CreateOCRClassMlp(txt_Hv_FileName.Text);
        ////}
        //#endregion

        //#region   训练线程
        /////// <summary>
        /////// 训练线程
        /////// </summary>
        ////void TrainOCRRun()
        ////{
        ////    while (true)
        ////    {
        ////        _auto_thr_create_training_ocr_run.WaitOne();

        ////        MessageBox.Show("请把要训练的字符输入到，输入当前图片中分割出的字符的空间中，然后按确定");

        ////        #region   无用代码
        ////        #region   无用代码
        ////        //_auto_thr_train_ocr_train.WaitOne();
        ////        #endregion
        ////        #region  无用代码
        ////        //if (ss.Length != num)
        ////        //{
        ////        //    MessageBox.Show("输入训练的字符有误,检查是否位数不对");
        ////        //    Invoke(new Action(delegate
        ////        //    {
        ////        //        train_ocr.BackColor = Color.PaleVioletRed;
        ////        //        train_ocr.Text = "请输入要训练的字符";
        ////        //    }));
        ////        //    return;
        ////        //}

        ////        //  HObject ho_SelectedRegions;

        ////        //  HOperatorSet.GenEmptyObj(out ho_SelectedRegions);

        ////        //  HOperatorSet.SortRegion(_IOCR.Ho_SelectedRegions, out ho_SelectedRegions, "lower_left",
        ////        //"true", "row");
        ////        //Invoke(new Action(delegate{
        ////        #endregion
        ////        #endregion

        ////        int num = Convert.ToInt32(_OCRTrainShuJu.Hv_Number.ToString());
        ////        for (int i = 1; i <= num; i++)
        ////        {
        ////            HObject ho_ObjectSelected;
        ////            HOperatorSet.GenEmptyObj(out ho_ObjectSelected);
        ////            halconWinControl_ROI1.clear_Window();
        ////            _OCRTrainShuJu.SelectOCRRegion(halconWinControl_ROI1.Ho_Image, halconWinControl_ROI1.HalconWindow1, out ho_ObjectSelected, i);

        ////            Invoke(new Action(delegate
        ////            {
        ////                train_ocr.BackColor = Color.PaleVioletRed;
        ////                if (_OCRTrainShuJu.Hv_Class1 != null)
        ////                {
        ////                    train_ocr.Text = "训练字符:" + _OCRTrainShuJu.Hv_Class1.ToString() + "完成。" + "请输入要训练的字符";
        ////                }
        ////                else
        ////                {
        ////                    train_ocr.Text = "请输入要训练的字符";
        ////                }
        ////            }));

        ////            _auto_thr_create_training_ocr_train.WaitOne();

        ////            Invoke(new Action(delegate
        ////            {
        ////                train_ocr.Text = "正在训练。。。。。";
        ////            }));
        ////            string str = _train_str.ToString();
        ////            string[] ss = str.Split(',');
        ////            _OCRTrainShuJu.Hv_ocr = ss[0];
        ////            _OCRTrainShuJu.TrainOCR(ho_ObjectSelected, halconWinControl_ROI1.Ho_Image, halconWinControl_ROI1.HalconWindow1);
        ////            #region  无用代码
        ////            //Invoke(new Action(delegate
        ////            //{
        ////            //    train_ocr.Text = "训练字符:"+_OCRTrainShuJu.Hv_Class1.ToString()+"完成";
        ////            //}));
        ////            // _auto_thr_train_ocr_train.WaitOne(3000);
        ////            #endregion
        ////        }

        ////        Invoke(new Action(delegate
        ////        {
        ////            train_ocr.BackColor = Color.YellowGreen;
        ////            train_ocr.Text = "训练完成";

        ////            train_reset_control();

        ////        }));

        ////        //}));
        ////    }
        ////}
        //#endregion

        //#region  确定字符
        //private void bnt_confirm_charater_Click(object sender, EventArgs e)
        //{
        //    _train_str.Clear();
        //    _train_str.Append(train_ocr.Text);
        //    _auto_thr_create_training_ocr_train.Set();
        //}
        //#endregion

        //#region  训练字符时屏蔽工具
        ///// <summary>
        ///// 训练字符时屏蔽工具
        ///// </summary>
        //void train_shield_control()
        //{
        //    halconWinControl_ROI1.HWindowControl.HalconWindow.SetDraw("fill");

        //    groupBox_train_work.Enabled = true;

        //    halconWinControl_ROI1.Enabled = false;
        //    toolStrip1.Enabled = false;

        //    //  tabPage5.Parent = null;
        //    tabPage1.Parent = null;
        //    tabPage3.Parent = null;
        //    tabPage2.Parent = null;
        //    tabPage4.Parent = tabControl1;


        //    //  bnt_extract_train_ocr_region.Enabled = false;
        //    bnt_Load_Class.Enabled = false;
        //    //bnt_create_train_file.Enabled = false;
        //    //      bnt_TrainOCR.Enabled = false;
        //    bnt_write_work_to_ocr.Enabled = false;
        //    bnt_check_when_ocr.Enabled = false;
        //    bnt_cut_out_train_region.Enabled = false;
        //    //  bnt_current_change_work.Enabled = false;
        //    bnt_save_current_ocr.Enabled = false;

        //    bnt_confirm_charater.Enabled = true;

        //}
        //#endregion

        //#region  训练完成，重置控件
        ///// <summary>
        ///// 训练完成，重置控件
        ///// </summary>
        //void train_reset_control()
        //{
        //    halconWinControl_ROI1.HWindowControl.HalconWindow.SetDraw("margin");

        //    groupBox_train_work.Enabled = true;

        //    halconWinControl_ROI1.Enabled = true;
        //    toolStrip1.Enabled = true;

        //    tabPage4.Parent = null;

        //    tabPage1.Parent = tabControl1;
        //    tabPage2.Parent = tabControl1;
        //    tabPage3.Parent = tabControl1;
        //    tabPage4.Parent = tabControl1;
        //    //   tabPage5.Parent = tabControl1;

        //    //bnt_extract_train_ocr_region.Enabled = true;
        //    bnt_Load_Class.Enabled = true;
        //    //bnt_create_train_file.Enabled = true;
        //    //bnt_TrainOCR.Enabled = true;
        //    bnt_write_work_to_ocr.Enabled = true;
        //    bnt_check_when_ocr.Enabled = true;
        //    bnt_cut_out_train_region.Enabled = true;
        //    //  bnt_current_change_work.Enabled = true;
        //    bnt_save_current_ocr.Enabled = true;
        //    bnt_confirm_charater.Enabled = false;


        //}
        //#endregion

        //#region   测试当前训练的ocr
        //private void bnt_check_when_ocr_Click(object sender, EventArgs e)
        //{
        //    //_OCRTrainShuJu.train_when_ocr(_IOCR.Ho_SelectedRegions, halconWinControl_ROI1.Ho_Image, halconWinControl_ROI1.HalconWindow1);
        //}
        //#endregion


        //#region    把训练到的ocr写入当前ocr工具
        //private void bnt_write_work_to_ocr_Click(object sender, EventArgs e)
        //{
        //    //_OCRTrainShuJu.RollOutOCRHandle(_IOCR);
        //}
        //#endregion


        //#region   截取要训练的区域
        //private void bnt_cut_out_train_region_Click(object sender, EventArgs e)
        //{
        //    if (halconWinControl_ROI1.Exit_Image() == false)
        //        return;


        //    string str = hv_Class.Text;
        //    string[] train_file = str.Split(',');

        //    for (int i = 0; i < train_file.Length; i++)
        //    {
        //        _OCRTrainShuJu.Hv_Characters[i] = train_file[i];
        //    }
        //    _OCRTrainShuJu.CreateOCRClassMlp(txt_Hv_FileName.Text);

        //    #region  无用代码
        //    //_OCRTrainShuJu.Set_OCRTrainRegion(this._IOCR.IOutSide.Mid_row_y, this._IOCR.IOutSide.Mid_col_x, this._IOCR.IOutSide.Phi, this._IOCR.IOutSide.Len1, this._IOCR.IOutSide.Len2);

        //    //_OCRTrainShuJu.extract_train_ocr_region(_IOCR, halconWinControl_ROI1.Ho_Image, halconWinControl_ROI1.HalconWindow1);

        //    //if ((_OCRTrainShuJu.Hv_OCRHandle == null) || (_OCRTrainShuJu.Hv_Number == null))
        //    //{
        //    //    MessageBox.Show("字库是空的,或者没有提取到训练的ocr，不能训练");
        //    //    return;
        //    //}
        //    //_auto_thr_create_training_ocr_run.Set();
        //    //train_shield_control();
        //    #endregion
        //}
        //#endregion

        //#region  修改当前ocr字库
        //private void bnt_current_change_work_Click(object sender, EventArgs e)
        //{
        //    if ((_IOCR.Hv_TrainingFile == null) || (_IOCR.Hv_OCRHandle == null))
        //    {
        //        MessageBox.Show("当前ocr工具没有携带字库,或者没有ocr分析器");
        //    }
        //    else
        //    {
        //        _OCRTrainShuJu.Hv_TrainingFile = _IOCR.Hv_TrainingFile;
        //        _OCRTrainShuJu.Hv_OCRHandle = _IOCR.Hv_OCRHandle;

        //        //bnt_create_train_file.Enabled = false;
        //        groupBox_train_work.Enabled = true;
        //    }
        //}
        //#endregion


        //#region  保存当前ocr
        //private void bnt_save_current_ocr_Click(object sender, EventArgs e)
        //{
        //    //_OCRTrainShuJu.SaveOCRHandle();
        //}
        //#endregion



        //#region  训练当前ocr
        //private void bnt_training_current_Click(object sender, EventArgs e)
        //{
        //    if (!halconWinControl_ROI1.Exit_Image())
        //        return;

        //    if ((_IOCR.Hv_FileName != null) && (_Set_OCR.extract_current_train_ocr_region(_IOCR, halconWinControl_ROI1.Ho_Image, halconWinControl_ROI1.HalconWindow1)))
        //    {
        //        _auto_thr_current_training_ocr_run.Set();
        //        current_train_shield_control();
        //    }
        //    else
        //    {
        //        MessageBox.Show("当前ocr没有对应的训练字库或字符没有分割成功");
        //    }
        //}
        //#endregion

        //#region  确定当前ocv字符
        //private void bnt_confirm_current_charater_Click(object sender, EventArgs e)
        //{
        //    _train_str.Clear();
        //    _train_str.Append(train_current_ocr.Text);
        //    _auto_thr_current_training_ocr_train.Set();
        //}
        //#endregion

        //#region  训练当前字符
        ///// <summary>
        ///// 训练当前字符
        ///// </summary>
        //void TrainCurrentOCR()
        //{
        //    while (true)
        //    {
        //        _auto_thr_current_training_ocr_run.WaitOne();

        //        MessageBox.Show("请把要训练的字符输入到，输入当前图片中分割出的字符的空间中，然后按确定");

        //        Invoke(new Action(delegate
        //        {
        //            train_current_ocr.BackColor = Color.PaleVioletRed;
        //            if (_IOCR.Hv_Class2 != null)
        //            {
        //                train_current_ocr.Text = "训练字符:" + _IOCR.Hv_Class2.ToString() + "完成。" + "请输入要训练的字符";
        //            }
        //            else
        //            {
        //                train_current_ocr.Text = "请输入要训练的字符";
        //            }

        //        }));

        //        _auto_thr_current_training_ocr_train.WaitOne();

        //        Invoke(new Action(delegate
        //        {
        //            train_current_ocr.Text = "正在训练。。。。。";
        //        }));

        //        int num = _IOCR.Hv_Number;

        //        if (num > 0)
        //        {
        //            string str = _train_str.ToString();
        //            _IOCR.Hv_Class = str;
        //            _Set_OCR.TrainOCR(_IOCR, _IOCR.Ho_SelectedRegions, halconWinControl_ROI1.Ho_Image, halconWinControl_ROI1.HalconWindow1);
        //        }

        //        #region  无用代码
        //        //for (int i = 1; i <= num; i++)
        //        //{
        //        //    HObject ho_ObjectSelected;
        //        //    HOperatorSet.GenEmptyObj(out ho_ObjectSelected);
        //        //    halconWinControl_ROI1.clear_Window();
        //        //    _Set_OCR.SelectOCRRegion(_IOCR, halconWinControl_ROI1.Ho_Image, halconWinControl_ROI1.HalconWindow1, out ho_ObjectSelected, i);
        //        //    Invoke(new Action(delegate
        //        //    {
        //        //        train_current_ocr.BackColor = Color.PaleVioletRed;
        //        //        if (_IOCR.Hv_Class2 != null)
        //        //        {
        //        //            train_current_ocr.Text = "训练字符:" + _IOCR.Hv_Class2.ToString() + "完成。" + "请输入要训练的字符";
        //        //        }
        //        //        else
        //        //        {
        //        //            train_current_ocr.Text = "请输入要训练的字符";
        //        //        }
        //        //    }));
        //        //    _auto_thr_current_training_ocr_train.WaitOne();
        //        //    Invoke(new Action(delegate
        //        //    {
        //        //        train_current_ocr.Text = "正在训练。。。。。";
        //        //    }));
        //        //    string str = _train_str.ToString();
        //        //    string[] ss = str.Split(',');
        //        //    _IOCR.Hv_Class = ss[0];
        //        //    _Set_OCR.TrainOCR(_IOCR, ho_ObjectSelected, halconWinControl_ROI1.Ho_Image, halconWinControl_ROI1.HalconWindow1);
        //        //    #region  无用代码
        //        //    // _OCRTrainShuJu.Hv_ocr = ss[0];
        //        //    //_OCRTrainShuJu.TrainOCR(ho_ObjectSelected, halconWinControl_Draw1.Ho_Image, halconWinControl_Draw1.HalconWindow1);
        //        //    #endregion
        //        //}
        //        #endregion

        //        Invoke(new Action(delegate
        //        {
        //            train_current_ocr.BackColor = Color.YellowGreen;
        //            train_current_ocr.Text = "训练完成";
        //            current_train_reset_control();
        //        }));
        //    }
        //}
        //#endregion


        //#region  训练当前ocr要屏蔽的控件
        ///// <summary>
        ///// 训练当前ocr要屏蔽的控件
        ///// </summary>
        //void current_train_shield_control()
        //{
        //    halconWinControl_ROI1.HWindowControl.HalconWindow.SetDraw("fill");
        //    groupBox_current_train_work.Enabled = true;

        //    halconWinControl_ROI1.Enabled = false;

        //    this.toolStrip1.Enabled = false;

        //    Hv_FileName.Enabled = false;
        //    bnt_Load_Speciial_Work.Enabled = false;
        //    //bnt_rectangle1.Enabled = false;
        //    bnt_SaveCurrentOCR.Enabled = false;
        //    bnt_training_current.Enabled = false;


        //    tabPage1.Parent = null;
        //    tabPage2.Parent = tabControl1;
        //    tabPage3.Parent = null;
        //    tabPage4.Parent = null;
        //}
        //#endregion

        //#region    训练完成，重置控件
        ///// <summary>
        ///// 训练完成，重置控件  
        ///// </summary>
        //void current_train_reset_control()
        //{
        //    halconWinControl_ROI1.HWindowControl.HalconWindow.SetDraw("margin");
        //    groupBox_current_train_work.Enabled = false;

        //    halconWinControl_ROI1.Enabled = true;

        //    this.toolStrip1.Enabled = true;

        //    Hv_FileName.Enabled = true;
        //    bnt_Load_Speciial_Work.Enabled = true;
        //    //bnt_rectangle1.Enabled = true;
        //    bnt_SaveCurrentOCR.Enabled = true;
        //    bnt_training_current.Enabled = true;

        //    tabPage2.Parent = null;

        //    tabPage1.Parent = tabControl1;
        //    tabPage2.Parent = tabControl1;
        //    tabPage3.Parent = tabControl1;
        //    tabPage4.Parent = tabControl1;

        //}
        //#endregion
        #endregion

        #region  设置当前字符为对比模板
        private void _trained_CheckedChanged(object sender, EventArgs e)
        {
            string str = "";
            this._Set_OCR.Set_Trained_Class(this._IOCR, _trained.Checked, ref str);
            _ocrTrainingCharacteer.Text = str;
        }
        #endregion

        #region 确定要读取ocr的个数
        private void but_que_ding_yao_du_qu_ocr_de_ge_shu_Click(object sender, EventArgs e)
        {
            int num = (int)this.nUD_yao_du_qu_ocr_de_ge_shu.Value;

            if (num > 0)
            {
                _Set_OCR.Set_AddOcrRoi(this._IOCR, this.halconWinControl_ROI1, num);
            }
        }
        #endregion

        #region 删除当前选中的roi
        private void but_shan_chu_dang_qian_roi_Click(object sender, EventArgs e)
        {
            _Set_OCR.Set_DeleteOcrRegion(this._IOCR, this.halconWinControl_ROI1);
            this.nUD_yao_du_qu_ocr_de_ge_shu.Value = decimal.Parse(_IOCR.List_IOutSide.Count.ToString());
        }
        #endregion

        #region   刷新定位点
        private void tSB_shua_xin_ding_wei_dian_Click(object sender, EventArgs e)
        {
            this._Set_OCR.Set_ShuaXinDingWeiDian(this._IOCR);
        }
        #endregion

        #region  创建字符库
        private void bnt_cut_out_train_region_Click(object sender, EventArgs e)
        {
            if (this._Set_OCR.CreateOCRClassMlp(_IOCR, txt_Hv_FileName.Text, hv_Class.Text))
            {
                bnt_cut_out_train_region.Text = "字符库创建成功";
            }
        }
        #endregion

        #region  保存训练
        private void tSB_saveOCR_Click(object sender, EventArgs e)
        {
            this._Set_OCR.Set_SaveOCRHandle(this._IOCR);
        }
        #endregion

        #region  添加roi
        private void btn_tian_jia_roi_Click(object sender, EventArgs e)
        {
            this._Set_OCR.Set_AddOneOCRRegion(this._IOCR, this.halconWinControl_ROI1);
            this.nUD_yao_du_qu_ocr_de_ge_shu.Value = decimal.Parse(_IOCR.List_IOutSide.Count.ToString());
        }
        #endregion

        #region 当前训练字符的text
        private void train_current_ocr_TextChanged(object sender, EventArgs e)
        {
            string str = train_current_ocr.Text;
            if (str != "")
            {
                but_training.Enabled = true;
            }
            else
            {
                but_training.Enabled = false;
            }
        }
        #endregion

        #region  训练当前字符
        private void but_training_Click(object sender, EventArgs e)
        {
            if ((_IOCR.Hv_FileName != null) && (_Set_OCR.extract_current_train_ocr_region(_IOCR, halconWinControl_ROI1.Ho_Image, halconWinControl_ROI1.HalconWindow1)))
            {
                _IOCR.Hv_Class = train_current_ocr.Text.ToString();
                _Set_OCR.TrainOCR(_IOCR, _IOCR.Ho_SelectedRegions, halconWinControl_ROI1.Ho_Image, halconWinControl_ROI1.HalconWindow1);
                but_training.Text = "训练成功:" + train_current_ocr.Text.ToString();
                but_training.Enabled = false;
                _Set_OCR.Set_SaveOCRHandle(_IOCR);
                train_current_ocr.Text = "";
            }
            else
            {
                MessageBox.Show("当前ocr没有对应的训练字库或字符没有分割成功");
            }
        }
        #endregion

    }
}
