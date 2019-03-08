using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HalconDotNet;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using System.Collections;

using HalControl;
using MultTree;
using MultTree.MultTreeNodeStruct;
using ReadImageHalconLibrary;
using RectLibrary;
using TemplateHalconLibrary;
using BarCodeHalconLibrary;
using OCRLibrary;
using OCVLibrary;
using CircleLibrary;
using LineLibrary;
using CalibrationLibrary;
using DataCodeLibrary;
using DistanceTwoPointLibrary;
using BackGroundCheckHalconLibrary;




namespace CheckStreamLibrary
{
    #region   检测类
    /// <summary>
    /// 检测流
    /// </summary>
    public class CheckStream : ICheckStream, IDisposable
    {
        #region   全局变量

        #region 检测的几点入口
        /// <summary>
        /// 检测的几点入口
        /// </summary>
        private IMultTreeNode _Check_Root = null;
        #endregion

        #region  工具
        ///// <summary>
        ///// ocv工具
        ///// </summary>
        //OCVLibrary.OCV _IOCV;
        ///// <summary>
        ///// OCR工具
        ///// </summary>
        //OCRLibrary.OCR _IOCR;
        ///// <summary>
        ///// 一维码
        ///// </summary>
        //BarCodeHalconLibrary.BarCode _IBarCode;
        ///// <summary>
        ///// 取图工具
        ///// </summary>
        //ReadImageHalconLibrary.ReadImage _IRead;
        ///// <summary>
        ///// 模板工具
        ///// </summary>
        //TemplateHalconLibrary.Template _ITemplate;
        ///// <summary>
        ///// 仿射变换
        ///// </summary>
        //RectLibrary.Rect_FangSheBianHuan _IRect;

        ///// <summary>
        ///// 拟合圆工具
        ///// </summary>
        //CircleLibrary.Circle _ICircle;

        ///// <summary>
        ///// 拟合线工具
        ///// </summary>
        //LineLibrary.Line _ILine;
        ///// <summary>
        ///// 标定
        ///// </summary>
        //CalibrationLibrary.Calibration _ICalibration;
        ///// <summary>
        ///// 二维码工具
        ///// </summary>
        //DataCodeLibrary.DataCode _IDataCode;
        ///// <summary>
        ///// 背景检测功能工具
        ///// </summary>
        //BackGroundCheckHalconLibrary.BackkGroundTool _IBackGround;
        ///// <summary>
        ///// 两点距离
        ///// </summary>
        //DistanceTwoPointLibrary.DistanceTwoPiont _IDistanceTwoPoint;
        #endregion

        #region 当前检测的图片
        /// <summary>
        /// 当前检测的图片
        /// </summary>
        HObject _ho_Image;
        #endregion

        #region   写入的窗口
        /// <summary>
        /// 写入的窗口
        /// </summary>
        HalControl.HalconWinControl_1 halconWinControl_11;
        #endregion

        #region 委托，事件

        #region  无用代码
        /// <summary>
        /// 检测完后的委托
        /// </summary>
        /// <param name="check_resulet"></param>
        // public delegate void resulte(Dictionary<string, Object> check_resulet);
        /// <summary>
        /// 检测完后触发这个事件
        /// </summary>
        // public event resulte _Resulte;
        #endregion

        /// <summary>
        /// 检测完后触发这个事件
        /// </summary>
        public event EventHandler<CheckStreamEventArgs> _Resulte1;

        #region  无用代码
        #region  无用代码
        ///// <summary>
        ///// 显示数据的委托
        ///// </summary>
        //delegate void repaint();
        ///// <summary>
        ///// 显示数据的事件
        ///// </summary>
        //event repaint RePaint;
        #endregion
        #region  无用代码
        /// <summary>
        /// 存贮数据
        /// </summary>
        // delegate void save_parameter();
        ///// <summary>
        ///// 存贮数据
        ///// </summary>
        // event save_parameter Set_Parameter;
        #endregion
        #endregion

        /// <summary>
        /// 触发处理委托
        /// </summary>
        /// <returns></returns>
        delegate bool trigger();
        /// <summary>
        /// 触发处理
        /// </summary>
        event trigger Trigger;
        #endregion

        #region  存放结果数据

        #region  无用代码
        /// <summary>
        /// 存放结果数据
        /// </summary>
        //Dictionary<string ,Object> _dictionary_resulte;
        #endregion

        /// <summary>
        /// 存放结果数据
        /// </summary>
        CheckStreamEventArgs _dictionary_resulte1;
        #endregion

        #region  当前检测的结果
        /// <summary>
        /// 当前检测的结果
        /// </summary>
        private bool _dang_qian_jian_ce_jie_guo = true;
        #endregion

        #region   检测流的时间控制器
        /// <summary>
        /// 检测控制流的时间
        /// </summary>
        Stopwatch _stopWatch = new Stopwatch();

        /// <summary>
        /// 检测的时间
        /// </summary>
        string milliseconds = "0.0";
        #endregion

        #region  记录递归的次数，用于保存数据的key
        /// <summary>
        /// 记录递归的次数，用于保存数据的key
        /// </summary>
        int _check_number = 0;
        #endregion

        #region   无用代码
        #region  注册表指针
        ///// <summary>
        // /// 注册表指针
        ///// </summary>
        // public static IntPtr Registry_Image;
        #endregion
        #endregion

        #endregion

        #region 属性
        /// <summary>
        /// 检测的几点入口
        /// </summary>
        public IMultTreeNode Check_Root
        {
            get { return _Check_Root; }
            set { _Check_Root = value; }
        }

        /// <summary>
        /// 实时更新的窗体
        /// </summary>
        public HalControl.HalconWinControl_1 HalconWinControl_11
        {
            get
            {
                return halconWinControl_11;
            }

            set
            {
                halconWinControl_11 = value;
            }
        }

        /// <summary>
        /// 设置流处理的图片
        /// </summary>
        public HObject Ho_Image
        {
            get
            {
                return _ho_Image;
            }

            set
            {
                _ho_Image = value;
            }
        }

        /// <summary>
        /// 检测时间
        /// </summary>
        public string Milliseconds
        {
            get
            {
                return milliseconds;
            }

            set
            {
                milliseconds = value;
            }
        }

        ///// <summary>
        ///// 取图工具
        ///// </summary>
        //public ReadImageHalconLibrary.ReadImage IRead
        //{
        //    get { return _IRead; }
        //    set { _IRead = value; }
        //}

        /// <summary>
        /// 存放结果数据
        /// </summary>
        public CheckStreamEventArgs Dictionary_resulte1
        {
            get { return _dictionary_resulte1; }
            set { _dictionary_resulte1 = value; }
        }

        /// <summary>
        /// 当前检测的结果
        /// </summary>
        public bool Dang_qian_jian_ce_jie_guo
        {
            get { return _dang_qian_jian_ce_jie_guo; }
            set { _dang_qian_jian_ce_jie_guo = value; }
        }

        #endregion

        #region 初始化
        /// <summary>
        /// 初始化
        /// </summary>
        /// <param name="Hwin">传入</param>
        public void CheckStream_Init(HalControl.HalconWinControl_1 Hwin)
        {
            halconWinControl_11 = Hwin;
            HOperatorSet.GenEmptyObj(out _ho_Image);
            Ho_Image.Dispose();
            //RePaint += create_show_Stream;
            Trigger = create_Stream;
            Hwin.Repaint += this.re_halconWin;
            //  _dictionary_resulte = new Dictionary<string, Object>();
            _dictionary_resulte1 = new CheckStreamEventArgs();
            //_IOCR = new OCR();
            //_IOCV = new OCV();
            //_IRead = new ReadImage();
            //_IRect = new Rect_FangSheBianHuan();
            //_ITemplate = new Template();
            //_IBarCode = new BarCode();
            ////_ICircle = new Circle();
            //_ILine = new Line();
            //_IDataCode = new DataCode();
            //_IBackGround = new BackkGroundTool();
            //_ICalibration = new Calibration();
            //_IDistanceTwoPoint = new DistanceTwoPiont();
        }
        #endregion

        #region 检测流

        #region   创建检测流
        /// <summary>
        /// 创建检测流
        /// </summary>
        bool create_Stream()
        {
            _stopWatch.Restart();
            delete_repaint();

            bool ok = false;

            #region  无用代码
            //  List<MultTreeNode> mu = MachineVision.ShuJuJieGou.TreeStatic.get_Root().getChildList();
            #endregion

            Dictionary_resulte1._dictionary_resulte.Clear();//初始化缓存
            this._dang_qian_jian_ce_jie_guo = true;//初始化当前检测结果的值
            _check_number = 0;//初始化递归次数

            List<MultTreeNode> mu = _Check_Root.getChildList();
            foreach (MultTreeNode trN in mu)
            {
                check_Stream(trN);
            }
            //create_save_parameter_stream();

            _dictionary_resulte1.AllResult = this._dang_qian_jian_ce_jie_guo;

            _stopWatch.Stop();

            TimeSpan timespan = _stopWatch.Elapsed;

            milliseconds = timespan.TotalMilliseconds.ToString(); ;

            #region  无用代码
            //if (RePaint != null)
            //{
            //    RePaint();
            //}
            #endregion

            if (_Resulte1 != null)
            {
                _Resulte1(null, _dictionary_resulte1);
            }

            load_repaint();
            ok = true;
            return ok;
        }
        #endregion

        #region  检测流
        /// <summary>
        /// 检测流程1
        /// </summary>
        /// <param name="tree"></param>
        /// <param name="Image"></param>
        void check_Stream(MultTreeNode tree)
        {
            /***********当前是对的才运行下取*****************/
            if (this._dang_qian_jian_ce_jie_guo == false)
            {
                return;
            }

            _check_number++;
            string Cname = tree.SelfId;

            Cname = Cname.Substring(0, Cname.IndexOf("_"));//当前节点的名称           

            switch (Cname)
            {
                #region System
                case "System":
                    foreach (MultTreeNode tr in tree.getChildList())//实现递归
                    {
                        check_Stream(tr);
                    }
                    break;
                #endregion

                #region detection
                case "detection":
                    foreach (MultTreeNode tr in tree.getChildList())//实现递归
                    {
                        check_Stream(tr);
                    }
                    break;
                #endregion

                #region  取图
                case "acquire":
                    #region   取出数据
                    MultTree.IToolDateFather te_ = (ToolDateFather)tree.Obj;
                    #endregion

                    #region   算法
                    this._dang_qian_jian_ce_jie_guo = te_.analyze_show(halconWinControl_11.HalconWindow1, _check_number.ToString(), ref Dictionary_resulte1._dictionary_resulte);
                    if (this._dang_qian_jian_ce_jie_guo)
                    {
                        this.halconWinControl_11.Ho_Image = te_.ImageFather.Ho_image;
                    }
                    #endregion

                    #region 判断是否有子节点
                    foreach (MultTreeNode tr in tree.getChildList())//实现递归
                    {
                        check_Stream(tr);
                    }
                    #endregion

                    break;
                #endregion

                #region 无用代码
                //#region 模板寻找
                //case "Template":

                //    #region   取出数据
                //    TemplateHalconLibrary.ITemplateShuJu teshuju = (TemplateHalconLibrary.TemplateShuJu)tree.Obj;
                //    #endregion

                //    #region   算法处理
                //    this._dang_qian_jian_ce_jie_guo = _ITemplate.Find_Show_Out(Image, teshuju, halconWinControl_11.HalconWindow1, _check_number.ToString(), ref  Dictionary_resulte1._dictionary_resulte);
                //    #endregion

                //    break;
                //#endregion

                //#region  拟合圆
                //case "Circle":
                //       #region 取出数据
                //    IToolDateFather Circle_ = (ToolDateFather)tree.Obj;
                //    #endregion

                //    #region   算法  
                //    this._dang_qian_jian_ce_jie_guo = Circle_.analyze_show(Image, halconWinControl_11.HalconWindow1, _check_number.ToString(), ref  Dictionary_resulte1._dictionary_resulte);
                //    #endregion

                //    break;

                //#endregion

                //#region   拟合线
                //case "Line":
                //    #region  取出数据
                //    ILineShuJu _ILineShuJu = (LineShuJu)tree.Obj;
                //    #endregion

                //    #region   算法
                //    this._dang_qian_jian_ce_jie_guo = _ILine.Spoke_Show_Out(Image, _ILineShuJu, halconWinControl_11.HalconWindow1, _check_number.ToString(), ref  Dictionary_resulte1._dictionary_resulte);
                //    #endregion
                //    break;

                //#endregion

                //#region  放射变换
                //case "Rect":
                //    #region   取出数据
                //    RectLibrary.IRectShuJu IRectShuJu_ = (RectLibrary.RectShuJu)tree.Obj;
                //    #endregion

                //    #region  算法
                //    this._dang_qian_jian_ce_jie_guo = _IRect.fang_bian_huan_ju_zhen(IRectShuJu_, _check_number.ToString(), ref  Dictionary_resulte1._dictionary_resulte);
                //    #endregion
                //    break;
                //#endregion

                //#region  颜色分析
                //case "colorAnalyst":
                //    #region 判断是否有子节点
                //    foreach (MultTreeNode tr in tree.getChildList())//实现递归
                //    {
                //        check_Stream(tr, null);
                //    }
                //    #endregion
                //    break;

                //#endregion

                //#region   一维码读取
                //case "BarCode":
                //    #region   取出数据
                //    #region 无用代码
                //    // BarCodeHalcon.BarCodeShuJu.IBarCodeShuJu bar = (BarCodeHalcon.BarCodeShuJu.BarCodeShuJu)tree.Obj;
                //    #endregion
                //    BarCodeHalconLibrary.IBarCodeShuJu bar = (BarCodeHalconLibrary.BarCodeShuJu)tree.Obj;
                //    #endregion

                //    #region   算法
                //    this._dang_qian_jian_ce_jie_guo = _IBarCode.Find_Show_out(Image, bar, halconWinControl_11.HalconWindow1, _check_number.ToString(), ref  Dictionary_resulte1._dictionary_resulte);
                //    #endregion
                //    break;
                //#endregion

                //#region  二维码
                //case "DataCode":

                //    #region  取出数据
                //    DataCodeLibrary.IDataCodeShuJu dat = (DataCodeLibrary.DataCodeShuJu)tree.Obj;
                //    #endregion

                //    #region   算法处理
                //    this._dang_qian_jian_ce_jie_guo = this._IDataCode.DateCodeFindShow(Image, dat, halconWinControl_11.HalconWindow1, _check_number.ToString(), ref  Dictionary_resulte1._dictionary_resulte);
                //    #endregion

                //    break;
                //#endregion

                //#region  标定
                //case "Calibration":

                //    #region  取出数据
                //    ICalibrationShuJu ICal_ = (CalibrationShuJu)tree.Obj;
                //    #endregion

                //    #region   算法
                //    this._dang_qian_jian_ce_jie_guo = _ICalibration.Cal_(_check_number.ToString(), ref  Dictionary_resulte1._dictionary_resulte);
                //    #endregion

                //    break;
                //#endregion

                //#region  ocr
                //case "OCR":
                //    #region  取出数据
                //    #region  无用代码
                //    //  OCRHalcon.OCRShuJu.IOCRShuJu IOCR = (OCRHalcon.OCRShuJu.OCRShuJu)tree.Obj;
                //    #endregion
                //    OCRLibrary.IOCRShuJu IOCR = (OCRLibrary.OCRShuJu)tree.Obj;
                //    #endregion

                //    #region  算法
                //    this._dang_qian_jian_ce_jie_guo = _IOCR.Read_Show_Out(Image, IOCR, halconWinControl_11.HalconWindow1, _check_number.ToString(), ref  Dictionary_resulte1._dictionary_resulte);
                //    #endregion
                //    break;
                //#endregion

                //#region   ocv
                //case "OCV":
                //    #region  取出数据
                //    OCVLibrary.IOCVShuJu IOCV_ = (OCVLibrary.OCVShuJu)tree.Obj;
                //    #endregion

                //    #region 算法
                //    //_IOCV.OCV_Check(Image, IOCV_);
                //    this._dang_qian_jian_ce_jie_guo = _IOCV.Check_Show_Out(Image, IOCV_, halconWinControl_11.HalconWindow1, _check_number.ToString(), ref  Dictionary_resulte1._dictionary_resulte);
                //    #endregion
                //    break;
                //#endregion

                //#region   背景检测
                //case "BackGround":
                //    #region   取出数据
                //    BackGroundCheckHalconLibrary.IBackGroundShuJu IBack_ = (BackGroundCheckHalconLibrary.BackGroundShuJu)tree.Obj;
                //    #endregion

                //    #region   算法
                //    this._dang_qian_jian_ce_jie_guo = _IBackGround.ImageArithmetic_ShowBackkGround(IBack_, Image, halconWinControl_11.HalconWindow1, _check_number.ToString(), ref  Dictionary_resulte1._dictionary_resulte);
                //    #endregion
                //    break;
                //#endregion

                //#region  两点距离
                //case "DistanceTwoPoint":
                //    #region  取出数据
                //    IToolDateFather IDistance_ = (ToolDateFather)tree.Obj;
                //    #endregion

                //    #region    算法
                //    //this._dang_qian_jian_ce_jie_guo = _IDistanceTwoPoint.show_analyze_save(Image, IDistance_, halconWinControl_11.HalconWindow1, _check_number.ToString(), ref  Dictionary_resulte1._dictionary_resulte);
                //    this._dang_qian_jian_ce_jie_guo = IDistance_.analyze_show(Image,halconWinControl_11.HalconWindow1, _check_number.ToString(), ref  Dictionary_resulte1._dictionary_resulte);
                //    #endregion

                //    break;
                //#endregion

                //#region    点到线的距离
                //case "DistancePointToLine":

                //    #region 取出数据
                //    IToolDateFather tool_ = (ToolDateFather)tree.Obj;
                //    #endregion

                //    #region   算法  
                //    this._dang_qian_jian_ce_jie_guo = tool_.analyze_show(Image, halconWinControl_11.HalconWindow1, _check_number.ToString(), ref  Dictionary_resulte1._dictionary_resulte);
                //    #endregion

                //    break;
                //#endregion
                #endregion

                #region 默认处理
                default:

                    #region   取出数据
                    MultTree.IToolDateFather teshuju = (ToolDateFather)tree.Obj;
                    #endregion

                    #region   算法
                    this._dang_qian_jian_ce_jie_guo = teshuju.analyze_show(halconWinControl_11.HalconWindow1, _check_number.ToString(), ref Dictionary_resulte1._dictionary_resulte);
                    #endregion

                    #region 判断是否有子节点
                    foreach (MultTreeNode tr in tree.getChildList())//实现递归
                    {
                        check_Stream(tr);
                    }
                    #endregion

                    break;
                #endregion
            }
        }

        #region  防射变换流  无用代码
        ///// <summary>
        ///// 防射变换流
        ///// </summary>
        ///// <param name="tree"></param>
        ///// <param name="Image"></param>
        ///// <param name="hv_HomMat2D"></param>
        //void check_Stream_hv_HomMat2D(MultTreeNode tree, HObject Image, HTuple hv_HomMat2D)
        //{
        //    string Cname = tree.SelfId;
        //    Cname = Cname.Substring(0, Cname.IndexOf("_"));//当前节点的名称
        //    switch (Cname)
        //    {
        //        #region  拟合圆
        //        case "Circle":
        //            #region  取出数据
        //            CircleLibrary.ICircleShuJu circleshuju_ = (CircleLibrary.CircleShuJu)tree.Obj;
        //            #endregion

        //            #region  算法处理
        //            //circleshuju_.Hv_HomMat2D = hv_HomMat2D;
        //            //_ICircle.Spoke(circleshuju_, Image);
        //            #endregion

        //            #region 判断是否有子节点
        //            //foreach (MultTreeNode tr in tree.getChildList())//实现递归
        //            //{
        //            //    check_Stream(tr, null);
        //            //}
        //            #endregion
        //            break;

        //        #endregion

        //        #region   拟合线
        //        case "Line":
        //            #region  取出数据
        //            ILineShuJu ILineShuJu_ = (LineShuJu)tree.Obj;
        //            #endregion

        //            #region   算法
        //            //ILineShuJu_.Hv_HomMat2D = hv_HomMat2D;
        //            //_ILine.Spoke(ILineShuJu_, Image);
        //            #endregion

        //            #region   判断下是否有子节点

        //            #endregion
        //            break;

        //        #endregion

        //        #region   一维码读取
        //        case "BarCode":
        //            #region   取出数据
        //            #region 无用代码
        //            // BarCodeShuJu.IBarCodeShuJu bar = (BarCodeShuJu.BarCodeShuJu)tree.Obj;
        //            #endregion
        //            BarCodeHalconLibrary.IBarCodeShuJu bar = (BarCodeHalconLibrary.BarCodeShuJu)tree.Obj;
        //            #endregion

        //            #region   算法
        //            #region  无用代码
        //            // ToolStatic.BarCodeStatic.get_Tool_CodeBar().Find_Bar_Code(Image, bar);
        //            #endregion
        //            //bar.Hv_HomMat2D = hv_HomMat2D;
        //            //_IBarCode.Find_Bar_Code(Image, bar);
        //            #endregion
        //            break;
        //        #endregion

        //        #region  ocr
        //        case "OCR":
        //            #region  取出数据
        //            OCRLibrary.IOCRShuJu IOCR = (OCRLibrary.OCRShuJu)tree.Obj;
        //            #endregion

        //            #region  算法
        //            #region 无用代码
        //            // ToolStatic.OCRStatic.get_Tool_Circle().OCR_Read(IOCR, Image);
        //            #endregion
        //            //IOCR.Hv_HomMat2D = hv_HomMat2D;
        //            //_IOCR.OCR_Read(IOCR, Image);
        //            #endregion
        //            break;
        //        #endregion

        //        #region   ocv
        //        case "OCV":
        //            #region  取出数据
        //            OCVLibrary.IOCVShuJu IOCV_ = (OCVLibrary.OCVShuJu)tree.Obj;
        //            #endregion

        //            #region 算法

        //            //IOCV_.Hv_HomMat2D = hv_HomMat2D;
        //            //_IOCV.OCV_Check(Image, IOCV_);
        //            #endregion
        //            break;
        //        #endregion

        //        #region 默认处理
        //        default:

        //            #region 判断是否有子节点
        //            foreach (MultTreeNode tr in tree.getChildList())//实现递归
        //            {
        //                check_Stream(tr, null);
        //            }
        //            #endregion

        //            break;
        //        #endregion
        //    }
        //}
        #endregion
        #endregion

        #endregion

        #region   显示检测数据
        #region  创建显示数据流
        /// <summary>
        /// 创建显示数据流
        /// </summary>
        /// <returns></returns>
        void create_show_Stream()
        {
            bool ok = false;
            #region  无用代码
            //  List<MultTreeNode> mu = MachineVision.ShuJuJieGou.TreeStatic.get_Root().getChildList();
            #endregion
            List<MultTreeNode> mu = _Check_Root.getChildList();
            foreach (MultTreeNode trN in mu)
            {
                show_Stream(trN);
            }

            ok = true;
            return;
        }
        #endregion

        #region   显示数据流
        /// <summary>
        /// 显示数据流
        /// </summary>
        /// <param name="tree"></param>
        void show_Stream(MultTreeNode tree)
        {
            string Cname = tree.SelfId;
            Cname = Cname.Substring(0, Cname.IndexOf("_"));//当前节点的名称

            switch (Cname)
            {
                #region  System
                case "System":
                    foreach (MultTreeNode tr in tree.getChildList())//实现递归
                    {
                        show_Stream(tr);
                    }
                    break;
                #endregion

                #region   detection
                case "detection":
                    foreach (MultTreeNode tr in tree.getChildList())//实现递归
                    {
                        show_Stream(tr);
                    }
                    break;

                #endregion

                #region   取图
                case "acquire":

                    #region  判断有没子节点
                    foreach (MultTreeNode tr in tree.getChildList())//实现递归
                    {
                        show_Stream(tr);
                    }
                    #endregion
                    break;
                #endregion

                #region 无用代码
                //#region 模板寻找
                //case "Template":
                //    #region   取出数据
                //    TemplateHalconLibrary.ITemplateShuJu teshuju = (TemplateHalconLibrary.TemplateShuJu)tree.Obj;
                //    #endregion

                //    #region   算法处理
                //    _ITemplate.show_template(teshuju, halconWinControl_11.HalconWindow1);
                //    #endregion

                //    #region 判断是否有子节点
                //    //foreach (MultTreeNode tr in tree.getChildList())//实现递归
                //    //{
                //    //    check_Stream(tr, Ho_Image);
                //    //}
                //    #endregion
                //    break;
                //#endregion

                //#region  拟合圆
                //case "Circle":

                //    #region  取出数据
                //    CircleLibrary.ICircleShuJu circleshuju_ = (CircleLibrary.CircleShuJu)tree.Obj;
                //    #endregion

                //    #region  算法处理
                //    //_ICircle.Circle_Show(circleshuju_, halconWinControl_11.HalconWindow1);
                //    circleshuju_.show(halconWinControl_11.HalconWindow1);
                //    #endregion

                //    break;
                //#endregion

                //#region   拟合线
                //case "Line":
                //    #region  取出数据
                //    ILineShuJu _ILineShuJu = (LineShuJu)tree.Obj;
                //    #endregion

                //    #region   算法
                //    _ILine.Line_Show(_ILineShuJu, halconWinControl_11.HalconWindow1);
                //    #endregion

                //    #region   判断下是否有子节点

                //    #endregion
                //    break;

                //#endregion

                //#region   一维码读取
                //case "BarCode":

                //    #region   取出数据
                //    #region  无用代码
                //    // BarCodeHalcon.BarCodeShuJu.IBarCodeShuJu bar = (BarCodeHalcon.BarCodeShuJu.BarCodeShuJu)tree.Obj;
                //    #endregion
                //    BarCodeHalconLibrary.IBarCodeShuJu bar = (BarCodeHalconLibrary.BarCodeShuJu)tree.Obj;
                //    #endregion

                //    #region   显示数据的算法
                //    #region 无用代码
                //    //ToolStatic.BarCodeStatic.get_Tool_CodeBar().ShowBarCode(bar, this.HalconWinControl_11.HalconWindow1);
                //    #endregion
                //    _IBarCode.ShowBarCode(bar, this.HalconWinControl_11.HalconWindow1);
                //    #endregion
                //    break;
                //#endregion

                //#region  二维码

                //case "DataCode":

                //    #region  取出数据
                //    DataCodeLibrary.IDataCodeShuJu dat = (DataCodeLibrary.DataCodeShuJu)tree.Obj;
                //    #endregion

                //    #region  算法
                //    this._IDataCode.DateCodeShow(dat, this.HalconWinControl_11.HalconWindow1);
                //    #endregion
                //    break;
                //#endregion

                //#region   ocr
                //case "OCR":
                //    #region 取出数据
                //    #region 无用代码
                //    // OCRHalcon.OCRShuJu.IOCRShuJu IO = (OCRHalcon.OCRShuJu.OCRShuJu)tree.Obj;
                //    #endregion
                //    OCRLibrary.IOCRShuJu IO = (OCRLibrary.OCRShuJu)tree.Obj;
                //    #endregion

                //    #region 显示数据的算法
                //    #region  无用代码
                //    // ToolStatic.OCRStatic.get_Tool_Circle().OCR_Show(IO, this.HalconWinControl_11.HalconWindow1);
                //    #endregion
                //    _IOCR.OCR_Show(IO, this.HalconWinControl_11.HalconWindow1);
                //    #endregion
                //    break;
                //#endregion

                //#region  ocv
                //case "OCV":

                //    #region  取出数据
                //    IOCVShuJu IOCV = (OCVShuJu)tree.Obj;
                //    #endregion

                //    #region  显示数据的算法
                //    _IOCV.OCV_Show(IOCV, this.HalconWinControl_11.HalconWindow1);
                //    #endregion

                //    break;
                //#endregion

                //#region   背景检测
                //case "BackGround":
                //    #region   取出数据
                //    BackGroundCheckHalconLibrary.IBackGroundShuJu IBack_ = (BackGroundCheckHalconLibrary.BackGroundShuJu)tree.Obj;
                //    #endregion

                //    #region   显示数据的算法
                //    _IBackGround.ShowBackkGround(IBack_, this.HalconWinControl_11.HalconWindow1);
                //    #endregion
                //    break;
                //#endregion
                #endregion

                #region  默认处理
                default:

                    #region   取出数据
                    MultTree.IToolDateFather teshuju = (ToolDateFather)tree.Obj;
                    #endregion

                    #region   算法
                    teshuju.show(halconWinControl_11.HalconWindow1);
                    #endregion

                    #region 判断是否有子节点
                    foreach (MultTreeNode tr in tree.getChildList())//实现递归
                    {
                        show_Stream(tr);
                    }
                    #endregion
                    break;

                #endregion
            }
        }
        #endregion
        #endregion

        //#region  存贮检测流数据
        /////// <summary>
        /////// 创建保存数据流
        /////// </summary>
        ////void create_save_parameter_stream()
        ////{
        ////    _dictionary_resulte1._dictionary_resulte.Clear();
        ////    #region  无用代码
        ////    //  List<MultTreeNode> mu = MachineVision.ShuJuJieGou.TreeStatic.get_Root().getChildList();
        ////    #endregion
        ////    List<MultTreeNode> mu = _Check_Root.getChildList();
        ////    foreach (MultTreeNode trN in mu)
        ////    {
        ////        save_parameter_stream(trN);
        ////    }
        ////}

        /////// <summary>
        /////// 保存数据流
        /////// </summary>
        /////// <param name="tree"></param>
        ////void save_parameter_stream(MultTreeNode tree)
        ////{
        ////    string Cname = tree.SelfId, name = tree.SelfId;
        ////    Cname = Cname.Substring(0, Cname.IndexOf("_"));//当前节点的名称

        ////    switch (Cname)
        ////    {
        ////        #region  System
        ////        case "System":
        ////            foreach (MultTreeNode tr in tree.getChildList())//实现递归
        ////            {
        ////                save_parameter_stream(tr);
        ////            }
        ////            break;
        ////        #endregion

        ////        #region   detection
        ////        case "detection":
        ////            foreach (MultTreeNode tr in tree.getChildList())//实现递归
        ////            {
        ////                save_parameter_stream(tr);
        ////            }
        ////            break;

        ////        #endregion

        ////        #region   取图
        ////        case "acquire":

        ////            #region   取出数据
        ////            #region  无用代码
        ////            // ReadImageHalcon.ReadImageShuJu.IReadShuJu reshuju = (ReadImageHalcon.ReadImageShuJu.ReadShuJu)tree.Obj;
        ////            #endregion
        ////            #endregion

        ////            #region  算法
        ////            #region  无用代码
        ////            // halconWinControl_11.Ho_Image = reshuju.Ho_image;
        ////            // ToolStatic.ReadImageStatic.get_Tool_ReadImage().show_Image(reshuju, halconWinControl_11.HalconWindow1);
        ////            #endregion
        ////            #endregion

        ////            #region  判断有没子节点
        ////            foreach (MultTreeNode tr in tree.getChildList())//实现递归
        ////            {
        ////                save_parameter_stream(tr);
        ////            }
        ////            #endregion
        ////            break;
        ////        #endregion

        ////        #region   一维码读取
        ////        case "BarCode":
        ////            #region   取出数据
        ////            BarCodeHalconLibrary.IBarCodeShuJu bar = (BarCodeHalconLibrary.BarCodeShuJu)tree.Obj;
        ////            #endregion

        ////            #region   显示数据的算法
        ////            _IBarCode.out_result(name, bar, ref _dictionary_resulte1._dictionary_resulte);
        ////            #endregion
        ////            break;
        ////        #endregion

        ////        #region  模板
        ////        #endregion

        ////        #region   ocv
        ////        #endregion

        ////        #region  拟合圆
        ////        #endregion

        ////        #region  拟合线
        ////        #endregion

        ////        #region   OCR
        ////        case "OCR":
        ////            #region  取出数据
        ////            OCRLibrary.IOCRShuJu io = (OCRLibrary.OCRShuJu)tree.Obj;
        ////            #endregion

        ////            #region  算法
        ////            _IOCR.out_result(name, io, ref _dictionary_resulte1._dictionary_resulte);
        ////            #endregion
        ////            break;
        ////        #endregion

        ////        #region  默认处理
        ////        default:
        ////            #region  判断有没子节点
        ////            foreach (MultTreeNode tr in tree.getChildList())//实现递归
        ////            {
        ////                save_parameter_stream(tr);
        ////            }
        ////            #endregion
        ////            break;
        ////        #endregion
        ////    }
        ////}
        //#endregion

        #region   检测触发器
        /// <summary>
        /// 触发检测
        /// </summary>
        public void trigger_check()
        {
            if (Trigger != null)
            {
                Trigger();
            }
        }
        #endregion

        #region   刷新窗口
        /// <summary>
        /// 刷新窗口
        /// </summary>
        /// <param name="win"></param>
        void re_halconWin(HWindow win)
        {
            create_show_Stream();
        }
        #endregion

        #region   去掉刷新窗口事件
        /// <summary>
        /// 去掉刷新窗口事件,及有关窗体控件事件
        /// </summary>
        void delete_repaint()
        {
            halconWinControl_11.Repaint -= this.re_halconWin;
            halconWinControl_11.ShieldMouseEvent();
            halconWinControl_11.PingBiZhuangTaiKongJian();
        }
        #endregion

        #region   添加刷新窗体事件
        /// <summary>
        /// 添加刷新窗体事件,及有关窗体控件事件
        /// </summary>
        void load_repaint()
        {
            halconWinControl_11.Repaint += this.re_halconWin;
            halconWinControl_11.ReloadMouseEvent();
            halconWinControl_11.KaiShiZhuangTaiKongJian();
        }
        #endregion

        #region  释放内存
        /// <summary>
        /// 释放内存
        /// </summary>
        public void Dispose()
        {
            _Check_Root = null;
            //_IOCV = null;
            //_IOCR = null;
            //_IBarCode = null;
            //_IRead = null;
            //_IRect = null;
            //_ITemplate = null;
            //_IBarCode = null;
            halconWinControl_11 = null;
            _ho_Image.Dispose();
        }
        #endregion

        #region  无用代码
        // #region 加载RePaint Set_Parameter事件
        ///// <summary>
        // /// 加载RePaint Set_Parameter事件
        ///// </summary>
        // void load_RePaint_Set_Parameter()
        // {
        //     RePaint += create_show_Stream;
        //     Set_Parameter += create_save_parameter_stream;
        // }

        // #endregion

        // #region  卸载RePaint Set_Parameter事件
        ///// <summary>
        ///// 卸载RePaint Set_Parameter事件
        ///// </summary>
        // void delete()
        // {
        //     RePaint -= create_show_Stream;
        //     Set_Parameter -= create_save_parameter_stream;
        // }
        // #endregion
        #endregion
    }
    #endregion

    #region  对外事件参数
    /// <summary>
    /// 检测流回调的参数
    /// </summary>
    public class CheckStreamEventArgs : EventArgs
    {
        /// <summary>
        /// 存放的结果
        /// </summary>
        public Dictionary<string, Object> _dictionary_resulte;

        /// <summary>
        /// 整个检测的结果
        /// </summary>
        public bool AllResult = false;

        /// <summary>
        /// 存放的结果
        /// </summary>
        public CheckStreamEventArgs()
        {
            _dictionary_resulte = new Dictionary<string, object>();
        }
    }
    #endregion

    #region  检测接口
    /// <summary>
    /// 检测接口
    /// </summary>
    public interface ICheckStream
    {
        #region 属性

        /// <summary>
        /// 检测的几点入口
        /// </summary>
        IMultTreeNode Check_Root
        {
            get;
            set;
        }

        /// <summary>
        /// 实时更新的窗体
        /// </summary>
        HalControl.HalconWinControl_1 HalconWinControl_11
        {
            get
           ;

            set
          ;
        }

        /// <summary>
        /// 设置流处理的图片
        /// </summary>
        HObject Ho_Image
        {
            get
           ;
            set
          ;
        }

        /// <summary>
        /// 检测时间
        /// </summary>
        string Milliseconds
        {
            get
            ;
            set
           ;
        }

        ///// <summary>
        ///// 取图工具
        ///// </summary>
        //ReadImageHalconLibrary.ReadImage IRead
        //{
        //    get;
        //    set;
        //}
        #endregion

        #region  事件
        /// <summary>
        /// 处理完后回调事件
        /// </summary>
        event EventHandler<CheckStreamEventArgs> _Resulte1;
        #endregion

        #region 方法
        /// <summary>
        /// 初始化
        /// </summary>
        /// <param name="Hwin"></param>
        void CheckStream_Init(HalControl.HalconWinControl_1 Hwin);


        /// <summary>
        /// 触发检测
        /// </summary>
        void trigger_check();
        #endregion
    }
    #endregion

    #region   检测流的静态保存数据工具
    /// <summary>
    /// 检测流的静态工具
    /// </summary>
    public static class MultTreeStaticSave
    {
        #region  保存TreeStatic数据
        /// <summary>
        /// 保存TreeStatic数据
        /// </summary>
        /// <param name="path1"></param>
        /// <returns></returns>
        public static bool SaveTreeStatic(ref string path1)
        {
            bool ok = false;
            di_gui_save();
            TreeStatic.save_MultTreeNode(path1);
            ok = true;
            return ok;
        }

        /// <summary>
        /// 递归保存数据
        /// </summary>
        private static void di_gui_save()
        {
            di_gui_save(TreeStatic.Root);
        }

        /// <summary>
        /// 递归保存数据
        /// </summary>
        /// <param name="tree">传入的树节点</param>
        private static void di_gui_save(IMultTreeNode tree)
        {
            string Cname = tree.SelfId;//取出树的名称
            Cname = Cname.Substring(0, Cname.IndexOf("_"));//当前节点的名称

            switch (Cname)
            {
                #region System
                case "System":
                    #region   判断是否有子节点
                    foreach (MultTreeNode trN in tree.getChildList())
                    {
                        di_gui_save(trN);
                    }
                    #endregion
                    break;
                #endregion

                #region detection
                case "detection":

                    #region   判断是否有子节点
                    foreach (MultTreeNode trN in tree.getChildList())
                    {
                        di_gui_save(trN);
                    }
                    #endregion


                    break;
                #endregion

                #region  取图
                case "acquire":

                    #region   判断是否有子节点
                    foreach (MultTreeNode trN in tree.getChildList())
                    {
                        di_gui_save(trN);
                    }
                    #endregion

                    break;
                #endregion

                #region  无用代码

                //#region 模板寻找
                //case "Template":
                //    #region   取出数据
                //    ITemplateShuJu teshuju = (TemplateShuJu)tree.Obj;
                //    #endregion

                //    #region   保存数据
                //    teshuju.save();
                //    //tree.setObj(teshuju);
                //    #endregion

                //    #region   判断是否有子节点
                //    //foreach (MultTreeNode trN in tree.getChildList())
                //    //{
                //    //    di_gui_save(trN);
                //    //}
                //    #endregion

                //    break;
                //#endregion

                //#region  拟合圆
                //case "Circle":
                //    #region  取出数据
                //    CircleShuJu circleshuju = (CircleShuJu)tree.Obj;
                //    #endregion

                //    #region 保存数据
                //    circleshuju.save();
                //    //tree.setObj(circleshuju);
                //    #endregion

                //    #region   判断是否有子节点
                //    //foreach (MultTreeNode trN in tree.getChildList())
                //    //{
                //    //    di_gui_save(trN);
                //    //}
                //    #endregion

                //    break;

                //#endregion

                //#region   拟合线
                //case "Line":
                //    #region  取出数据
                //    ILineShuJu _ILineShuJu = (LineShuJu)tree.Obj;
                //    #endregion

                //    #region   算法
                //    _ILineShuJu.save();
                //    #endregion

                //    #region   判断下是否有子节点

                //    #endregion

                //    break;
                //#endregion

                //#region  图片旋转 放射变换
                //case "Rect":
                //    #region   取出数据
                //    IRectShuJu shujurect = (IRectShuJu)tree.Obj;
                //    #endregion

                //    #region  保存数据
                //    shujurect.save();
                //    #endregion

                //    #region   判断是否有子节点
                //    foreach (MultTreeNode trN in tree.getChildList())
                //    {
                //        di_gui_save(trN);
                //    }
                //    #endregion
                //    break;
                //#endregion

                //#region  颜色分析
                //case "colorAnalyst":
                //    #region   判断是否有子节点
                //    //foreach (MultTreeNode trN in tree.getChildList())
                //    //{
                //    //    di_gui_save(trN);
                //    //}
                //    #endregion
                //    break;

                //#endregion

                //#region  一维码 BarCode
                //case "BarCode":
                //    #region   取出数据
                //    IBarCodeShuJu IBar = (BarCodeShuJu)tree.Obj;
                //    #endregion

                //    #region   保存数据
                //    IBar.save();
                //    #endregion

                //    #region   判断是否有子节点
                //    //foreach (MultTreeNode trN in tree.getChildList())
                //    //{
                //    //    di_gui_save(trN);
                //    //}
                //    #endregion
                //    break;
                //#endregion

                //#region   二维码
                //case "DataCode":
                //    #region  取出数据
                //    DataCodeLibrary.IDataCodeShuJu dat = (DataCodeLibrary.DataCodeShuJu)tree.Obj;
                //    #endregion

                //    #region   算法处理
                //    dat.save();
                //    #endregion
                //    break;
                //#endregion

                //#region OCR
                //case "OCR":
                //    #region  取出数据
                //    IOCRShuJu IOCR = (OCRShuJu)tree.Obj;
                //    #endregion

                //    #region  保存数据
                //    IOCR.save();
                //    #endregion
                //    break;
                //#endregion

                //#region 标定
                //case "Calibration":
                //    #region   取出数据
                //    ICalibrationShuJu ICal_ = (CalibrationShuJu)tree.Obj;
                //    #endregion

                //    #region  保存数据
                //    ICal_.save();
                //    #endregion
                //    break;
                //#endregion

                //#region   OCV
                //case "OCV":
                //    #region  取出数据
                //    IOCVShuJu IOCV = (OCVShuJu)tree.Obj;
                //    #endregion

                //    #region  保存数据
                //    IOCV.save();
                //    #endregion
                //    break;
                //#endregion

                //#region   背景检测
                //case "BackGround":
                //    #region   取出数据
                //    IBackGroundShuJu IBack_ = (BackGroundShuJu)tree.Obj;
                //    #endregion

                //    #region   保存数据
                //    IBack_.save();
                //    #endregion
                //    break;
                //#endregion
                #endregion

                #region 默认处理
                default:

                    #region   取出数据
                    var teshuju = tree.Obj as IToolDateFather;
                    #endregion

                    #region  算法处理
                    if (teshuju is IToolDateFather)
                    {
                        teshuju.save();
                    }
                    #endregion

                    #region   判断是否有子节点
                    foreach (MultTreeNode trN in tree.getChildList())
                    {
                        di_gui_save(trN);
                    }
                    #endregion

                    break;
                #endregion
            }

        }
        #endregion

        #region 加载TreeStatic数据
        /// <summary>
        /// 加载TreeStatic数据
        /// </summary>
        /// <param name="path1"></param>
        /// <returns></returns>
        public static bool LoadTreeStatic(ref string path1)
        {
            bool ok = false;
            TreeStatic.load_MultTreeNode(path1);
            di_gui_init();
            ok = true;
            return ok;
        }

        /// <summary>
        /// 递归初始化数据
        /// </summary>
        private static void di_gui_init()
        {
            di_gui_init(TreeStatic.Root);
        }

        /// <summary>
        /// 递归初始化数据
        /// </summary>
        /// <param name="tree">传入的树</param>
        private static void di_gui_init(IMultTreeNode tree)
        {
            string Cname = tree.SelfId;//取出树的名称
            Cname = Cname.Substring(0, Cname.IndexOf("_"));//当前节点的名称
            switch (Cname)
            {
                #region System
                case "System":


                    #region   判断是否有子节点
                    foreach (MultTreeNode trN in tree.getChildList())
                    {
                        di_gui_init(trN);
                    }
                    #endregion

                    break;
                #endregion

                #region detection
                case "detection":

                    #region   判断是否有子节点
                    foreach (MultTreeNode trN in tree.getChildList())
                    {
                        di_gui_init(trN);
                    }
                    #endregion

                    break;
                #endregion

                #region  取图
                case "acquire":
                    #region   取出数据
                    ////  MachineVision.ShuJu.ReadShuJu reshuju = (MachineVision.ShuJu.ReadShuJu)tree.Tag;
                    IReadShuJu reshuju = (ReadShuJu)tree.Obj;
                    #endregion

                    #region 初始化数据
                    reshuju.init();
                    #endregion

                    #region   判断是否有子节点
                    foreach (MultTreeNode trN in tree.getChildList())
                    {
                        di_gui_init(trN);
                    }
                    #endregion
                    break;
                #endregion

                #region  无用代码
                //#region 模板寻找
                //case "Template":
                //    #region   取出数据
                //    ITemplateShuJu teshuju = (TemplateShuJu)tree.Obj;
                //    #endregion

                //    #region 初始化数据
                //    teshuju.init();
                //    #endregion

                //    #region   判断是否有子节点
                //    //foreach (MultTreeNode trN in tree.getChildList())
                //    //{
                //    //    di_gui_init(trN);
                //    //}
                //    #endregion
                //    break;
                //#endregion

                //#region  拟合圆
                //case "Circle":
                //    #region  取出数据
                //    CircleShuJu circleshuju = (CircleShuJu)tree.Obj;
                //    #endregion

                //    #region 初始化数据
                //    circleshuju.init();
                //    //tree.setObj(circleshuju);
                //    #endregion

                //    #region   判断是否有子节点
                //    //foreach (MultTreeNode trN in tree.getChildList())
                //    //{
                //    //    di_gui_init(trN);
                //    //}
                //    #endregion
                //    break;
                //#endregion

                //#region   拟合线
                //case "Line":

                //    #region  取出数据
                //    ILineShuJu _ILineShuJu = (LineShuJu)tree.Obj;
                //    #endregion

                //    #region   算法
                //    _ILineShuJu.init();
                //    #endregion

                //    #region   判断下是否有子节点

                //    #endregion

                //    break;
                //#endregion

                //#region  图片旋转 放射变换
                //case "Rect":
                //    #region   取出数据
                //    IRectShuJu shujurect = (RectShuJu)tree.Obj;
                //    #endregion

                //    #region   初始化数据
                //    shujurect.init();

                //    #endregion

                //    #region   判断是否有子节点
                //    foreach (MultTreeNode trN in tree.getChildList())
                //    {
                //        di_gui_init(trN);
                //    }
                //    #endregion
                //    break;
                //#endregion

                //#region  颜色分析
                //case "colorAnalyst":
                //    #region   判断是否有子节点
                //    //foreach (MultTreeNode trN in tree.getChildList())
                //    //{
                //    //    di_gui_init(trN);
                //    //}
                //    #endregion
                //    break;

                //#endregion

                //#region  一维码 BarCode
                //case "BarCode":
                //    #region   取出数据
                //    IBarCodeShuJu IBar = (BarCodeShuJu)tree.Obj;
                //    #endregion

                //    #region   初始化数据
                //    IBar.init();
                //    #endregion

                //    #region   判断是否有子节点
                //    //foreach (MultTreeNode trN in tree.getChildList())
                //    //{
                //    //    di_gui_save(trN);
                //    //}
                //    #endregion
                //    break;
                //#endregion

                //#region   二维码
                //case "DataCode":
                //    #region  取出数据
                //    DataCodeLibrary.IDataCodeShuJu dat = (DataCodeLibrary.DataCodeShuJu)tree.Obj;
                //    #endregion

                //    #region   算法处理
                //    dat.init();
                //    #endregion
                //    break;
                //#endregion

                //#region OCR
                //case "OCR":
                //    #region  取出数据
                //    IOCRShuJu IOCR = (OCRShuJu)tree.Obj;
                //    #endregion

                //    #region  初始化数据
                //    IOCR.init();
                //    #endregion
                //    break;
                //#endregion

                //#region   标定
                //case "Calibration":
                //    #region   取出数据
                //    ICalibrationShuJu ICal_ = (CalibrationShuJu)tree.Obj;
                //    #endregion

                //    #region  保存数据
                //    ICal_.init();
                //    #endregion
                //    break;
                //#endregion

                //#region   OCV
                //case "OCV":

                //    #region  取出数据
                //    IOCVShuJu IOCV = (OCVShuJu)tree.Obj;
                //    #endregion

                //    #region  初始化数据
                //    IOCV.init();
                //    #endregion

                //    break;
                //#endregion

                //#region   背景检测
                //case "BackGround":
                //    #region   取出数据
                //    IBackGroundShuJu IBack_ = (BackGroundShuJu)tree.Obj;
                //    #endregion

                //    #region   保存数据
                //    IBack_.init();
                //    #endregion
                //    break;
                //#endregion
                #endregion

                #region 默认处理
                default:
                    #region   取出数据
                    var teshuju = tree.Obj as IToolDateFather;
                    #endregion

                    #region   算法
                    if (teshuju is IToolDateFather)
                    {
                        teshuju.init();
                    }
                    #endregion

                    #region   判断是否有子节点
                    foreach (MultTreeNode trN in tree.getChildList())
                    {
                        di_gui_init(trN);
                    }
                    #endregion
                    break;
                #endregion
            }
        }
        #endregion
    }
    #endregion

    #region  检测数据显示工具
    /// <summary>
    /// 检测数据显示工具
    /// </summary>
    public class CheckShuJuResultTool
    {
        #region 在listbox中显示数据
        /// <summary>
        /// 在listbox中显示数据
        /// </summary>
        /// <param name="li"></param>
        /// <param name="e"></param>
        /// <returns></returns>
        public bool ShowOnListBox(ListBox li, CheckStreamEventArgs e)
        {
            bool ok = false;

            Dictionary<string, object>.ValueCollection ValCol = e._dictionary_resulte.Values;
            foreach (object obj in ValCol)
            {
                string str;
                MultTree.ClassResultFather fa_ = obj as MultTree.ClassResultFather;
                fa_.showResult(out str);
                li.Items.Add(str);
            }
            ok = true;
            return ok;
        }
        #endregion

        #region    在listbox中显示数据
        /// <summary>
        /// 在listbox中显示数据
        /// </summary>
        /// <param name="li"></param>
        /// <param name="e"></param>
        /// <returns></returns>
        public bool ShowOnListBox1(ListBox li, CheckStreamEventArgs e)
        {
            bool ok = false;

            Dictionary<string, object>.ValueCollection ValCol = e._dictionary_resulte.Values;
            foreach (object obj in ValCol)
            {
                string[] str;
                MultTree.ClassResultFather fa_ = obj as MultTree.ClassResultFather;
                fa_.showResult(out str);
                foreach (string s in str)
                {
                    li.Items.Add(s);
                }
            }

            ok = true;
            return ok;
        }

        #endregion
    }
    #endregion
}
