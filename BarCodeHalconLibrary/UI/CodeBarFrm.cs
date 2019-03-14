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
//using MachineVision.ShuJuJieGou;
using System.Diagnostics;
using MultTree;
using LogClassLibrary;



namespace BarCodeHalconLibrary.UI
{
    public partial class CodeBarFrm : Form
    {
        #region    全局变量

        #region 无用代码
        #region 记录第几张图片
        /// <summary>
        /// 记录第几张图片
        /// </summary>
        //  public UInt16 _number_Image = 0;
        #endregion
        #endregion

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
        ////  ReadImageHalcon.ReadImageShuJu.ReadShuJu _re;
        //ReadImageHalconLibrary.ReadShuJu _re;
        //#endregion

        //#region  取图工具
        ///// <summary>
        ///// 取图工具
        ///// </summary>
        //ReadImageHalconLibrary.IReadImage _IRead = new ReadImageHalconLibrary.ReadImage();

        //#endregion

        #region  委托
        delegate bool _run_delegate();

        /// <summary>
        ///运行的算法
        /// </summary>
        event _run_delegate _run;

        /// <summary>
        ///读取图片 
        /// </summary>
        event _run_delegate _read;

        #endregion

        #region  一维码
        /// <summary>
        /// 一维码数据
        /// </summary>
        BarCodeHalconLibrary.IBarCodeShuJu _ICode;
        /// <summary>
        /// 设置数据
        /// </summary>
        BarCodeHalconLibrary.Set_BarCodeShuJu _Set_CodeBar = new BarCodeHalconLibrary.Set_BarCodeShuJu();
        ///// <summary>
        ///// 分析数据
        ///// </summary>
        //BarCodeHalconLibrary.BarCode _co;        
        #endregion

        #region   结果
        /// <summary>
        /// 结果
        /// </summary>
        Dictionary<string, Object> _result = new Dictionary<string, object>();
        #endregion

        #region  计时器
        /// <summary>
        /// 计时器
        /// </summary>
        Stopwatch _stop_watch = new Stopwatch();
        #endregion

        #endregion

        #region   构造函数
        public CodeBarFrm()
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

            //_co = new BarCodeHalconLibrary.BarCode();

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
            //        _re = (ReadImageHalconLibrary.ReadShuJu)TreeStatic.Mult_Tree_Node_Picture.Obj;

            //        #region  把图片写入

            //        foreach (string file_name in _re.Path_Picture)
            //        {
            //            listBox_acquire_picture.Items.Add(file_name); //加载所有文件
            //        }
            //        #endregion
            //    }
            //    else
            //    {
            //        _re = new ReadImageHalconLibrary.ReadShuJu();
            //    }
            //}
            //else
            //{
            //    _re = new ReadImageHalconLibrary.ReadShuJu();
            //}
            //#endregion

#if DEBUG == true

            if (TreeStatic.Mult_Tree_Node.Obj == null)
            {
                //   BarCodeHalcon.BarCodeShuJu.IBarCodeShuJu su = new BarCodeHalcon.BarCodeShuJu.BarCodeShuJu();
                _ICode = new BarCodeHalconLibrary.BarCodeShuJu();
            }
            else
            {
                _ICode = (BarCodeHalconLibrary.BarCodeShuJu)TreeStatic.Mult_Tree_Node.Obj; ;
            }
#else
            BarCodeHalcon.BarCodeShuJu.IBarCodeShuJu su = new BarCodeHalcon.BarCodeShuJu.BarCodeShuJu();
            _ICode = su;
#endif
            _Set_CodeBar.Set_showParameterHalconWinControl(_ICode, this.Controls, halconWinControl_ROI1);

        }
        #endregion

        #region 无用代码
        #region  适应窗口
        //private void fit_window_strip_click(object sender, eventargs e)
        //{
        //    //  dispimagefit();
        //}
        #endregion


        #region  保存图片
        //private void save_Image_strip_Click(object sender, EventArgs e)
        //{

        //    HOperatorSet.GenEmptyObj(out _ho_Image);
        //        _ho_Image.Dispose();

        //    SaveWindowDumpDialog();
        //}

        ///// <summary>
        ///// 保存图片
        ///// </summary>
        //private void SaveWindowDumpDialog()
        //{
        //    try
        //    {
        //        SaveFileDialog sfd = new SaveFileDialog();
        //        //string imgFileName;

        //        sfd.Filter = "PNG图像|*.png|BMP图像|*.bmp|JPEG图像|*.jpg|所有文件|*.*";

        //        if (sfd.ShowDialog() == DialogResult.OK)
        //        {
        //            if (String.IsNullOrEmpty(sfd.FileName))
        //                return;
        //            HOperatorSet.WriteImage(_ho_Image, Path.GetExtension(sfd.FileName).Substring(1), 0, sfd.FileName);

        //            //  hv_image.WriteImage(Path.GetExtension(sfd.FileName).Substring(1), 0, sfd.FileName);
        //            //imgFileName = sfd.FileName;
        //            //SaveWindowDump(imgFileName, new Size(1280, 1024));
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        m_CtrlHStatusLabelCtrl.Text = ex.Message;
        //    }

        //}

        #endregion
        #endregion

        //#region  循环运行
        //private void tSB_circulation_run_Click(object sender, EventArgs e)
        //{
        //    string str = tSB_circulation_run.Text;
        //    if (str == "循环运行")
        //    {
        //        _xun_huan_yun_xing_biao_zhi = true;
        //        tSB_circulation_run.Text = "停止循环";
        //        //  timer_run.Enabled = true;
        //        trigger_read();
        //    }
        //    else
        //    {
        //        _xun_huan_yun_xing_biao_zhi = false;
        //        //timer_run.Enabled = false;
        //        tSB_circulation_run.Text = "循环运行";
        //    }
        //}
        //#endregion

        #region     运行
        private void tSB_run_one_Click(object sender, EventArgs e)
        {
            trigger_run();
        }

        #region  无用代码
        /// <summary>
        /// 运行成功后回调
        /// </summary>
        //void run_callBack(IAsyncResult re)
        //{
        //    if (_xun_huan_yun_xing_biao_zhi)
        //    {
        //        Invoke(new Action(delegate {
        //            if (_read != null)
        //            {
        //                _read();
        //            }
        //        }));
        //        // timer_run.Enabled = true;
        //    }
        //}
        #endregion

        bool run()
        {
            if (halconWinControl_ROI1.Exit_Image() == false)
            {
                return false;
            }
            _stop_watch.Restart();
            bool ok = false;
            //_co.Find_Bar_Code(halconWinControl_ROI1.Ho_Image, _ICode);
            //_co.ShowBarCode(_ICode, halconWinControl_ROI1.HalconWindow1);
            _result.Clear();
            this._ICode.analyze_show( halconWinControl_ROI1.HalconWindow1, "1", ref _result);

            _stop_watch.Stop();

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

        #region   读取一张图片  线程

        #region  无用代码
        /// <summary>
        /// 读取一张图片   线程
        /// </summary>
        /// <returns></returns>
        //public void read_one_image()
        //{
        //    while (_start_stop)
        //    {
        //        _read_event.WaitOne();
        //        this.BeginInvoke(new Action(delegate
        //        {
        //            try
        //            {
        //                int i = listBox_acquire_picture.Items.Count;
        //                if (i > 0)
        //                {
        //                    if (_number_Image >= i)
        //                    {
        //                        _number_Image = 0;
        //                    }

        //                    Mai.Tool.readImage read = new Mai.Tool.readImage();
        //                    listBox_acquire_picture.SelectedIndex = _number_Image;

        //                    string path = listBox_acquire_picture.SelectedItem.ToString();
        //                    _number_Image++;

        //                    read.read_Image(path, hWindowControl1.HalconWindow);
        //                    _ho_Image = read.ho_Image;

        //                    if (_xun_huan_yun_xing_biao_zhi)
        //                    {
        //                        _run(); 
        //                     //   _run_event.Set();
        //                    }
        //                }
        //            }
        //            catch (Exception ex)
        //            {
        //                Mai.Log.LogManager.WriteLog(Mai.Log.LogFile.Error, "取图片一张出错");
        //                MessageBox.Show(ex.Message + " " + "取图片一张出错");
        //            }
        //        }));
        //    }
        //}
        #endregion

        bool read_one_image()
        {
            bool ok = false;
            try
            {
                //halconWinControl_ROI1.Ho_Image.Dispose();
                //_IRead.read_Image(_re);
                if (!halconWinControl_ROI1.Exit_Image())
                {
                    halconWinControl_ROI1.Ho_Image.Dispose(); 
                }
                halconWinControl_ROI1.Ho_Image = this._ICode.ImageFather.Ho_image;

                //if (_xun_huan_yun_xing_biao_zhi == true)
                //{
                //    //trigger_run();
                //    Thread thr = new Thread(new ThreadStart(this.trigger_run));
                //    thr.Start();
                //}
                #region  无用代码
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

                //    read.read_Image(path, halconWinControl_Draw1.HalconWindow1);
                //    //_ho_Image = read.ho_Image;
                //    halconWinControl_Draw1.Ho_Image = read.ho_Image;

                //    ok = true;
                //    if (_xun_huan_yun_xing_biao_zhi)
                //    {
                //        if (_run != null)
                //        {
                //            _run.BeginInvoke(run_callBack, null);
                //        }
                //        //else
                //        //{
                //        //    timer_run.Enabled = true;
                //        //}
                //        ok = true;
                //        //   _run_event.Set();
                //    }
                //}
                #endregion
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
            #region   无用代码
            /*****防止没有图片无操作*********************/
            //int num = this.listBox_acquire_picture.Items.Count;
            //if (num == 0)
            //    return;

            //halconWinControl_ROI1.Ho_Image.Dispose();
            //_IRead.read_Image(_re);
            //halconWinControl_ROI1.Ho_Image = _re.Ho_image;


            //this.BeginInvoke(new Action(delegate {
            //    try
            //    {
            //        int i = listBox_acquire_picture.Items.Count;
            //        if (i > 0)
            //        {
            //            if (_number_Image >= i)
            //            {
            //                _number_Image = 0;
            //            }

            //            ReadImageHalcon.Tool.readImage read = new ReadImageHalcon.Tool.readImage();
            //            listBox_acquire_picture.SelectedIndex = _number_Image;

            //            string path = listBox_acquire_picture.SelectedItem.ToString();
            //            _number_Image++;

            //            read.read_Image(path, halconWinControl_Draw1.HalconWindow1);
            //            //_ho_Image = read.ho_Image;
            //            halconWinControl_Draw1.Ho_Image= read.ho_Image;

            //        }
            //    }
            //    catch (Exception ex)
            //    {
            //        SerializeTree.Log.LogManager.WriteLog(SerializeTree.Log.LogFile.Error, "取图片一张出错");
            //        MessageBox.Show(ex.Message + " " + "取图片一张出错");
            //    }
            //}));
            #endregion

            trigger_read();

        }
        #endregion

        #region 退出
        private void acquriefrm_FormClosing(object sender, FormClosingEventArgs e)
        {

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

        #region   刷新窗口事件
        /// <summary>
        /// 刷新窗口事件
        /// </summary>
        /// <param name="win">要刷新的窗体</param>
        void repaint(HWindow win)
        {
            this._ICode.show(halconWinControl_ROI1.HalconWindow1);
        }
        #endregion

        #region  触发事件

        #region  取图触发器
        /// <summary>
        /// 取图触发器
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

        #endregion

        #region 设置读码的方式
        private void hv_CodeType_SelectedIndexChanged(object sender, EventArgs e)
        {
            _Set_CodeBar.Set_CodeType(_ICode, hv_CodeType.Text);
        }
        #endregion

        //#region  设置最小对比度
        //private void bnt_contrast_min_Click(object sender, EventArgs e)
        //{
        //    _Set_CodeBar.Set_CodeBarParameter(_ICode, contrast_min.Text, null, null, null);
        //}
        //#endregion

        //#region 最小宽度的尺寸

        //private void bnt_element_size_min_Click(object sender, EventArgs e)
        //{
        //    _Set_CodeBar.Set_CodeBarParameter(_ICode, null, element_size_min.Text, null, null);
        //}

        //#endregion

        //#region  保存中间结果
        //private void Persistence_SelectedIndexChanged(object sender, EventArgs e)
        //{
        //    _Set_CodeBar.Set_CodeBarParameter(_ICode, null, null, Persistence.Text, null);
        //}
        //#endregion

        //#region    设置扫描线条数
        //private void bnt_Num_scanlines_Click(object sender, EventArgs e)
        //{
        //    _Set_CodeBar.Set_CodeBarParameter(_ICode, null, null, null, Num_scanlines.Text);
        //}
        //#endregion

        #region   设置最小等级
        private void bnt_min_Grade_Click(object sender, EventArgs e)
        {
            //this._Set_CodeBar.Set_MinGrade(this._ICode, _min_Grade.Text);
            QueDingCanShuJu();
        }
        #endregion

        #region   确定参数
        /// <summary>
        /// 确定参数
        /// </summary>
        void QueDingCanShuJu()
        {
            _Set_CodeBar.Set_CodeBarParameter(_ICode, numericUpDown_contrast_min.Text, numericUpDown_element_size_min.Text, numericUpDown_Persistence.Text, numericUpDown_Num_scanlines.Text);
            this._Set_CodeBar.Set_MinGrade(this._ICode, numericUpDown_min_Grade.Text);
        }
        #endregion
        
        #region  启动等级验证
        private void Quality_isoiec15416_CheckedChanged(object sender, EventArgs e)
        {
            this._Set_CodeBar.Set_Quality_isoiec15416(this._ICode, Quality_isoiec15416.Checked);
        }
        #endregion

        #region    启动训练
        private void _trained_CheckedChanged(object sender, EventArgs e)
        {
            string str = "";
            this._Set_CodeBar.Set_Trained(this._ICode, _trained.Checked, ref str);
            _BarCodeTrained.Text = str;

        }
        #endregion

        #region 重新刷新定位点
        private void tSB_shua_xin_ding_wei_dian_Click(object sender, EventArgs e)
        {
            this._Set_CodeBar.Set_shua_xin_ding_wei_dian(this._ICode);
        }
        #endregion

        #region 无用代码
        #region   halcon函数跟绘制
        //#region  绘制 
        //#region 在图像中绘制矩形区域
        ///// <summary>
        /////  在图像中绘制矩形区域
        ///// </summary>
        ///// <param name="rowBegin"></param>
        ///// <param name="colBegin"></param>
        ///// <param name="rowEnd"></param>
        ///// <param name="colEnd"></param>
        //public void DrawRectangle1(string color, out double rowBegin, out double colBegin, out double rowEnd, out double colEnd)
        //{
        //    try
        //    {
        //        Double _rowBegin, _colBegin, _rowEnd, _colEnd;

        //        ShieldMouseEvent();

        //        hWindowControl1.Focus();
        //        hWindowControl1.HalconWindow.SetColor(color);
        //        hWindowControl1.HalconWindow.DrawRectangle1(out _rowBegin, out _colBegin, out _rowEnd, out _colEnd);
        //        // hv_window.SetColor(color);
        //        //  hv_window.DrawRectangle1(out _rowBegin, out _colBegin, out _rowEnd, out _colEnd);

        //        HRegion rectangle = new HRegion();
        //        rectangle.GenRectangle1(_rowBegin, _colBegin, _rowEnd, _colEnd);

        //        rectangle.DispObj(hWindowControl1.HalconWindow);
        //        rectangle.Dispose();
        //        ReloadMouseEvent();

        //        rowBegin = _rowBegin;
        //        colBegin = _colBegin;
        //        rowEnd = _rowEnd;
        //        colEnd = _colEnd;
        //    }
        //    catch (System.Exception ex)
        //    {
        //        rowBegin = 0.0;
        //        colBegin = 0.0;
        //        rowEnd = 0.0;
        //        colEnd = 0.0;
        //        m_CtrlHStatusLabelCtrl.Text = ex.Message;
        //    }
        //}
        //#endregion

        //#region 在图像中绘制矩形区域
        ///// <summary>
        /////  在图像中绘制矩形区域
        ///// </summary>
        ///// <param name="row"></param>
        ///// <param name="column"></param>
        ///// <param name="phi"></param>
        ///// <param name="length1"></param>
        ///// <param name="length2"></param>
        //public void DrawRectangle2(string color, out double row, out double column, out double phi, out double length1, out double length2)
        //{
        //    try
        //    {
        //        Double _row, _column, _phi, _length1, _length2;
        //        ShieldMouseEvent();
        //        hWindowControl1.Focus();
        //        hWindowControl1.HalconWindow.SetColor(color);
        //        hWindowControl1.HalconWindow.DrawRectangle2(out _row, out _column, out _phi, out _length1, out _length2);
        //        HRegion rectangle = new HRegion();
        //        rectangle.GenRectangle2(_row, _column, _phi, _length1, _length2);
        //        rectangle.DispObj(hWindowControl1.HalconWindow);
        //        rectangle.Dispose();
        //        ReloadMouseEvent();
        //        row = _row;
        //        column = _column;
        //        phi = _phi;
        //        length1 = _length1;
        //        length2 = _length2;
        //    }
        //    catch (System.Exception ex)
        //    {
        //        row = 0.0;
        //        column = 0.0;
        //        phi = 0.0;
        //        length1 = 0.0;
        //        length2 = 0.0;
        //        m_CtrlHStatusLabelCtrl.Text = ex.Message;
        //    }
        //}
        //#endregion

        //#region   在图像中绘制圆形区域    
        ///// <summary>
        ///// 在图像中绘制圆形区域
        ///// </summary>
        ///// <param name="row"></param>
        ///// <param name="column"></param>
        ///// <param name="radius"></param>
        //public void DrawCircle(string color, out double row, out double column, out double radius)
        //{
        //    try
        //    {
        //        Double _row, _column, _radius;
        //        ShieldMouseEvent();

        //        hWindowControl1.Focus();
        //        hWindowControl1.HalconWindow.SetColor(color);
        //        hWindowControl1.HalconWindow.DrawCircle(out _row, out _column, out _radius);

        //        HRegion circle = new HRegion();
        //        circle.GenCircle(_row, _column, _radius);
        //        circle.DispObj(hWindowControl1.HalconWindow);
        //        circle.Dispose();
        //        ReloadMouseEvent();

        //        row = _row;
        //        column = _column;
        //        radius = _radius;

        //    }
        //    catch (Exception ex)
        //    {
        //        row = 0.0;
        //        column = 0.0;
        //        radius = 0.0;
        //        m_CtrlHStatusLabelCtrl.Text = ex.Message;
        //    }
        //}
        //#endregion

        //#region   在图像中绘制直线     
        ///// <summary>
        ///// 在图像中绘制直线
        ///// </summary>
        ///// <param name="color"></param>
        ///// <param name="beginRow"></param>
        ///// <param name="beginCol"></param>
        ///// <param name="endRow"></param>
        ///// <param name="endCol"></param>
        //public void DrawLine(string color, out double beginRow, out double beginCol, out double endRow, out double endCol)
        //{
        //    try
        //    {
        //        Double _beginRow, _beginCol, _endRow, _endCol;
        //        ShieldMouseEvent();

        //        hWindowControl1.Focus();
        //        hWindowControl1.HalconWindow.SetColor(color);
        //        hWindowControl1.HalconWindow.DrawLine(out _beginRow, out _beginCol, out _endRow, out _endCol);

        //        hWindowControl1.HalconWindow.DispLine(_beginRow, _beginCol, _endRow, _endCol);
        //        ReloadMouseEvent();

        //        beginRow = _beginRow;
        //        beginCol = _beginCol;
        //        endRow = _endRow;
        //        endCol = _endCol;

        //    }
        //    catch (Exception ex)
        //    {
        //        beginRow = 0.0;
        //        beginCol = 0.0;
        //        endRow = 0.0;
        //        endCol = 0.0;
        //        m_CtrlHStatusLabelCtrl.Text = ex.Message;
        //    }
        //}
        //#endregion

        //#region  在图像中绘制椭圆形区域      
        ///// <summary>
        ///// 在图像中绘制椭圆形区域
        ///// </summary>
        ///// <param name="row"></param>
        ///// <param name="column"></param>
        ///// <param name="radius"></param>
        //public void DrawEllipse(string color, out double row, out double column, out double phi, out double radius1, out double radius2)
        //{
        //    try
        //    {

        //        Double _row, _column, _phi, _radius1, _radius2;
        //        ShieldMouseEvent();


        //        hWindowControl1.Focus();
        //        hWindowControl1.HalconWindow.SetColor(color);
        //        hWindowControl1.HalconWindow.DrawEllipse(out _row, out _column, out _phi, out _radius1, out _radius2);

        //        HRegion ellipse = new HRegion();
        //        ellipse.GenEllipse(_row, _column, _phi, _radius1, _radius2);
        //        ellipse.DispObj(hWindowControl1.HalconWindow);
        //        ellipse.Dispose();
        //        ReloadMouseEvent();

        //        row = _row;
        //        column = _column;
        //        phi = _phi;
        //        radius1 = _radius1;
        //        radius2 = _radius2;

        //    }
        //    catch (Exception ex)
        //    {
        //        row = 0.0;
        //        column = 0.0;
        //        phi = 0.0;
        //        radius1 = 0.0;
        //        radius2 = 0.0;
        //        m_CtrlHStatusLabelCtrl.Text = ex.Message;
        //    }
        //}


        //#endregion

        //#endregion

        //#region halcon 控件函数

        //#region 鼠标移动时发生
        //private void hWindowControl1_HMouseMove(object sender, HMouseEventArgs e)
        //{
        //    if (_ho_Image.IsInitialized())
        //    {
        //        try
        //        {
        //            int button_state;
        //            double positionX, positionY;
        //            string str_value;
        //            string str_position;
        //            bool _isXOut = true, _isYOut = true;
        //            HTuple channel_count;//元素

        //            HOperatorSet.CountChannels(_ho_Image, out channel_count);//计算图片的通道


        //            hWindowControl1.HalconWindow.GetMpositionSubPix(out positionY, out positionX, out button_state);//得到亚像素组成 取得坐标，及鼠标的状态
        //            str_position = String.Format("X: {0:0000.0}, Y: {1:0000.0}", positionX, positionY);//把坐标转成字符格式

        //            HTuple width, height;
        //            HOperatorSet.GetImageSize(_ho_Image, out width, out height);
        //            _isXOut = (positionX < 0 || positionX >= (double)width);//判断是否超出范围，超出为1
        //            _isYOut = (positionY < 0 || positionY >= (double)height);//判断是否超出范围，超出为1

        //            if (!_isXOut && !_isYOut)
        //            {
        //                if ((int)channel_count == 1)
        //                {
        //                    HTuple grayval;
        //                    HOperatorSet.GetGrayval(_ho_Image, (HTuple)positionY, (HTuple)positionX, out grayval);
        //                    str_value = String.Format("灰度值: {0:000.0}", (double)grayval);//显示出去
        //                }
        //                else
        //                {
        //                    if ((int)channel_count == 3)
        //                    {
        //                        str_value = "";
        //                        HTuple grayValRed, grayValGreen, grayValBlue;
        //                        HObject _RedChannel, _GreenChannel, _BlueChannel;
        //                        HOperatorSet.GenEmptyObj(out _RedChannel);
        //                        HOperatorSet.GenEmptyObj(out _GreenChannel);
        //                        HOperatorSet.GenEmptyObj(out _BlueChannel);
        //                        HOperatorSet.AccessChannel(_ho_Image, out _RedChannel, 1);
        //                        HOperatorSet.AccessChannel(_ho_Image, out _GreenChannel, 2);
        //                        HOperatorSet.AccessChannel(_ho_Image, out _BlueChannel, 3);

        //                        HOperatorSet.GetGrayval(_RedChannel, (HTuple)positionY, (HTuple)positionX, out grayValRed);
        //                        HOperatorSet.GetGrayval(_GreenChannel, (HTuple)positionY, (HTuple)positionX, out grayValGreen);
        //                        HOperatorSet.GetGrayval(_BlueChannel, (HTuple)positionY, (HTuple)positionX, out grayValBlue);

        //                        _RedChannel.Dispose();
        //                        _GreenChannel.Dispose();
        //                        _BlueChannel.Dispose();

        //                        str_value = String.Format("Val: ({0:000.0}, {1:000.0}, {2:000.0})", (double)grayValRed, (double)grayValGreen, (double)grayValBlue);//显示3个通道的灰度值

        //                    }
        //                    else
        //                    {
        //                        str_value = "";
        //                    }
        //                }
        //                m_CtrlHStatusLabelCtrl.Text = str_position + "    " + str_value;
        //            }

        //            switch (button_state)
        //            {
        //                case 0:
        //                    this.Cursor = System.Windows.Forms.Cursors.Default;//显示鼠标类型为手型
        //                    break;
        //                case 1:
        //                    this.Cursor = System.Windows.Forms.Cursors.Hand;//显示鼠标类型为手型
        //                    hWindowControl1.HalconWindow.ClearWindow();//清空窗体类容
        //                    hWindowControl1.HalconWindow.SetPaint(new HTuple("default"));//设置显示默认
        //                                                                                 //              保持图像显示比例
        //                    zoom_beginRow -= (int)(positionY - _start_positionY);
        //                    zoom_beginCol -= (int)(positionX - _start_positionX);
        //                    zoom_endRow -= (int)(positionY - _start_positionY);
        //                    zoom_endCol -= (int)(positionX - _start_positionX);
        //                    hWindowControl1.HalconWindow.SetPart(zoom_beginRow, zoom_beginCol, zoom_endRow, zoom_endCol);
        //                    hWindowControl1.HalconWindow.DispObj(_ho_Image);//显示图片
        //                    break;
        //            }

        //        }
        //        catch (Exception ex)
        //        {
        //            m_CtrlHStatusLabelCtrl.Text = ex.Message;
        //        }
        //    }
        //}



        //#endregion

        //#region 鼠标释放时发生
        //private void hWindowControl1_HMouseUp(object sender, HMouseEventArgs e)
        //{
        //    try
        //    {
        //        switch (e.Button)
        //        {
        //            case MouseButtons.Left://左键
        //                this.Cursor = System.Windows.Forms.Cursors.Default;//变回默认
        //                _b_leftButton = false;//设置按钮状态
        //                break;
        //            case MouseButtons.Right://右键
        //                _b_rightButton = false;//设置按钮状态
        //                break;
        //            case MouseButtons.Middle:
        //                break;
        //            default:
        //                break;
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        m_CtrlHStatusLabelCtrl.Text = ex.Message;
        //    }
        //}

        //#endregion

        //#region 图片滚轮放大缩小
        //private void hWindowControl1_HMouseWheel(object sender, HMouseEventArgs e)
        //{
        //    if (_ho_Image.IsInitialized())
        //    {

        //        double mposition_row = 0, mposition_col = 0;
        //        int button_state;

        //        HWindow hv_window = hWindowControl1.HalconWindow;

        //        try
        //        {
        //            hv_window.GetMpositionSubPix(out mposition_row, out mposition_col, out button_state);
        //            hv_window.GetPart(out current_beginRow, out current_beginCol, out current_endRow, out current_endCol);
        //        }
        //        catch (Exception ex)
        //        {
        //            m_CtrlHStatusLabelCtrl.Text = ex.Message;
        //        }

        //        if (e.Delta > 0)                 // 放大图像
        //        {
        //            zoom_beginRow = (int)(current_beginRow + (mposition_row - current_beginRow) * 0.300d);
        //            zoom_beginCol = (int)(current_beginCol + (mposition_col - current_beginCol) * 0.300d);
        //            zoom_endRow = (int)(current_endRow - (current_endRow - mposition_row) * 0.300d);
        //            zoom_endCol = (int)(current_endCol - (current_endCol - mposition_col) * 0.300d);

        //        }
        //        else                // 缩小图像
        //        {
        //            zoom_beginRow = (int)(mposition_row - (mposition_row - current_beginRow) / 0.700d);
        //            zoom_beginCol = (int)(mposition_col - (mposition_col - current_beginCol) / 0.700d);
        //            zoom_endRow = (int)(mposition_row + (current_endRow - mposition_row) / 0.700d);
        //            zoom_endCol = (int)(mposition_col + (current_endCol - mposition_col) / 0.700d);
        //        }

        //        try
        //        {
        //            int hw_width, hw_height;
        //            hw_width = hWindowControl1.Size.Width;
        //            hw_height = hWindowControl1.Size.Height;

        //            HTuple width, height;
        //            HOperatorSet.GetImageSize(_ho_Image, out width, out height);

        //            bool _isOutOfArea = true;
        //            bool _isOutOfSize = true;
        //            bool _isOutOfPixel = true; //避免像素过大

        //            _isOutOfArea = zoom_beginRow >= (int)height || zoom_endRow <= 0 || zoom_beginCol >= (int)width || zoom_endCol < 0;
        //            _isOutOfSize = (zoom_endRow - zoom_beginRow) > (int)height * 20 || (zoom_endCol - zoom_beginCol) > (int)width * 20;
        //            _isOutOfPixel = hw_height / (zoom_endRow - zoom_beginRow) > 500 || hw_width / (zoom_endCol - zoom_beginCol) > 500;

        //            if (_isOutOfArea || _isOutOfSize)
        //            {
        //                HOperatorSet.SetPart(hWindowControl1.HalconWindow, 0, 0, height - 1, width - 1);
        //                hWindowControl1.HalconWindow.DispObj(_ho_Image);
        //            }
        //            else if (!_isOutOfPixel)
        //            {
        //                hWindowControl1.HalconWindow.ClearWindow();
        //                zoom_endCol = zoom_beginCol + (zoom_endRow - zoom_beginRow) * hw_width / hw_height;

        //                hv_window.SetPart(zoom_beginRow, zoom_beginCol, zoom_endRow, zoom_endCol);
        //                hv_window.DispObj(_ho_Image);

        //            }
        //        }
        //        catch (Exception ex)
        //        {
        //            DispImageFit();
        //            m_CtrlHStatusLabelCtrl.Text = ex.Message;
        //        }
        //    }
        //}
        //#endregion

        //#region 鼠标按下时发生
        //private void hWindowControl1_HMouseDown(object sender, HMouseEventArgs e)
        //{
        //    int temp_button_state;
        //    try
        //    {
        //        switch (e.Button)
        //        {
        //            case MouseButtons.Left://鼠标左键按下检测
        //                this.Cursor = System.Windows.Forms.Cursors.Hand;//把鼠标显示为手型
        //                hWindowControl1.HalconWindow.GetMpositionSubPix(out _start_positionY, out _start_positionX, out temp_button_state);//得到亚像素组成 取得坐标，及鼠标的状态
        //                _b_leftButton = true;//记录鼠标的状态
        //                break;
        //            case MouseButtons.Right:
        //                _b_rightButton = true;//记录鼠标的状态
        //                this.Cursor = System.Windows.Forms.Cursors.Default;//把鼠标显示为手型
        //                break;
        //            case MouseButtons.Middle://鼠标中间按钮按下
        //                break;
        //            default:
        //                break;
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        m_CtrlHStatusLabelCtrl.Text = ex.Message;//显示的运行错误
        //    }

        //}
        //#endregion

        //#region   刷新halcon控件
        ///// <summary>
        ///// 刷新控件
        ///// </summary>
        //public void refreshWindow()
        //{
        //    hWindowControl1.HalconWindow.ClearWindow();
        //    if (_ho_Image.IsInitialized())
        //    {
        //        hWindowControl1.HalconWindow.DispObj(_ho_Image);
        //    }
        //}
        //#endregion

        //#region   屏蔽halcon控件的鼠标事件
        ///// <summary>
        ///// 屏蔽鼠标事件
        ///// </summary>
        //public void ShieldMouseEvent()
        //{
        //    hWindowControl1.ContextMenuStrip = null;

        //    //this.hWindowControl1.HMouseDown -= new HalconDotNet.HMouseEventHandler(this.hWindowControl1_HMouseDown);
        //    //this.hWindowControl1.HMouseUp -= new HalconDotNet.HMouseEventHandler(this.hWindowControl1_HMouseUp);
        //    //hWindowControl1.HMouseMove -= hWindowControl1_HMouseMove;
        //    //hWindowControl1.HMouseWheel -= hWindowControl1_HMouseWheel;
        //    this.hWindowControl1.HMouseMove -= new HalconDotNet.HMouseEventHandler(this.hWindowControl1_HMouseMove);
        //    this.hWindowControl1.HMouseDown -= new HalconDotNet.HMouseEventHandler(this.hWindowControl1_HMouseDown);
        //    this.hWindowControl1.HMouseUp -= new HalconDotNet.HMouseEventHandler(this.hWindowControl1_HMouseUp);
        //    this.hWindowControl1.HMouseWheel -= new HalconDotNet.HMouseEventHandler(this.hWindowControl1_HMouseWheel);
        //}
        //#endregion

        //#region 重新加载halcon控件　鼠标事件
        ///// <summary>
        ///// 重新加载　鼠标事件
        ///// </summary>
        //public void ReloadMouseEvent()
        //{
        //    hWindowControl1.ContextMenuStrip = contextMenuStrip_halcon;
        //    //this.hWindowControl1.HMouseDown += new HalconDotNet.HMouseEventHandler(this.hWindowControl1_HMouseDown);
        //    //this.hWindowControl1.HMouseUp += new HalconDotNet.HMouseEventHandler(this.hWindowControl1_HMouseUp);
        //    //hWindowControl1.HMouseMove += hWindowControl1_HMouseMove;
        //    //hWindowControl1.HMouseWheel += hWindowControl1_HMouseWheel;
        //    this.hWindowControl1.HMouseMove += new HalconDotNet.HMouseEventHandler(this.hWindowControl1_HMouseMove);
        //    this.hWindowControl1.HMouseDown += new HalconDotNet.HMouseEventHandler(this.hWindowControl1_HMouseDown);
        //    this.hWindowControl1.HMouseUp += new HalconDotNet.HMouseEventHandler(this.hWindowControl1_HMouseUp);
        //    this.hWindowControl1.HMouseWheel += new HalconDotNet.HMouseEventHandler(this.hWindowControl1_HMouseWheel);
        //}
        //#endregion

        //#region    屏蔽halcon控件的鼠标事件,但不屏蔽滚轮事件
        ///// <summary>
        /////   屏蔽halcon控件的鼠标事件,但不屏蔽滚轮事件
        ///// </summary>
        //public void ti_qu_model_shi_ShieldMouseEvent()
        //{
        //    hWindowControl1.ContextMenuStrip = null;

        //    //this.hWindowControl1.HMouseDown -= new HalconDotNet.HMouseEventHandler(this.hWindowControl1_HMouseDown);
        //    //this.hWindowControl1.HMouseUp -= new HalconDotNet.HMouseEventHandler(this.hWindowControl1_HMouseUp);
        //    //hWindowControl1.HMouseMove -= hWindowControl1_HMouseMove;
        //    //hWindowControl1.HMouseWheel -= hWindowControl1_HMouseWheel;
        //    this.hWindowControl1.HMouseMove -= new HalconDotNet.HMouseEventHandler(this.hWindowControl1_HMouseMove);
        //    this.hWindowControl1.HMouseDown -= new HalconDotNet.HMouseEventHandler(this.hWindowControl1_HMouseDown);
        //    this.hWindowControl1.HMouseUp -= new HalconDotNet.HMouseEventHandler(this.hWindowControl1_HMouseUp);
        //}
        //#endregion

        //#region  重新加载halcon控件　鼠标事件但不加载滚轮事件
        ///// <summary>
        /////重新加载halcon控件　鼠标事件但不加载滚轮事件
        ///// </summary>
        //public void ti_qu_model_shi_ReloadMouseEvent()
        //{
        //    hWindowControl1.ContextMenuStrip = contextMenuStrip_halcon;
        //    //this.hWindowControl1.HMouseDown += new HalconDotNet.HMouseEventHandler(this.hWindowControl1_HMouseDown);
        //    //this.hWindowControl1.HMouseUp += new HalconDotNet.HMouseEventHandler(this.hWindowControl1_HMouseUp);
        //    //hWindowControl1.HMouseMove += hWindowControl1_HMouseMove;
        //    //hWindowControl1.HMouseWheel += hWindowControl1_HMouseWheel;
        //    this.hWindowControl1.HMouseMove += new HalconDotNet.HMouseEventHandler(this.hWindowControl1_HMouseMove);
        //    this.hWindowControl1.HMouseDown += new HalconDotNet.HMouseEventHandler(this.hWindowControl1_HMouseDown);
        //    this.hWindowControl1.HMouseUp += new HalconDotNet.HMouseEventHandler(this.hWindowControl1_HMouseUp);

        //}


        //#endregion


        //#region 适应窗口
        ///// <summary>
        ///// 让图片适应窗口显示
        ///// </summary>
        //void DispImageFit()
        //{
        //    try
        //    {
        //        if (_ho_Image.IsInitialized())
        //        {
        //            hWindowControl1.HalconWindow.ClearWindow();
        //            HTuple width, height;
        //            HOperatorSet.GetImageSize(_ho_Image, out width, out height);
        //            HOperatorSet.SetPart(hWindowControl1.HalconWindow, 0, 0, height - 1, width - 1);
        //            hWindowControl1.HalconWindow.DispObj(_ho_Image);

        //            //if (_xld!=null)
        //            //{
        //            //    hWindowControl1.HalconWindow.DispObj(_xld);
        //            //}

        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        m_CtrlHStatusLabelCtrl.Text = ex.Message;
        //    }
        //}
        //#endregion

        //#endregion

        #endregion
        #endregion
    }
}
