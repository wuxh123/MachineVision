using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using HalconDotNet;
using RectLibrary;
using HalControl;
using HalControl.ROI;
using HalControl.ROI.Rectangle2;





namespace OCRLibrary
{
    #region  数据
    /// <summary>
    /// 数据
    /// </summary>
    [Serializable]
    public class OCRShuJu : MultTree.ToolDateFather, IOCRShuJu
    {
        #region  全局变量

        #region   创建一个OCR MLP分类器参数
        /// <summary>
        ///  创建一个OCR分类器参数
        /// </summary>
        [NonSerialized]
        private HTuple hv_WidthCharacter = 8;

        /// <summary>
        ///  创建一个OCR分类器参数
        /// </summary>
        [NonSerialized]
        private HTuple hv_HeightCharacter = 10;

        /// <summary>
        ///  创建一个OCR分类器参数
        /// </summary>
        [NonSerialized]
        private HTuple hv_Interpolation = "constant";

        /// <summary>
        ///  创建一个OCR分类器参数
        /// </summary>
        [NonSerialized]
        private HTuple hv_Features = "default";

        /// <summary>
        ///  创建一个OCR分类器参数
        /// </summary>
        [NonSerialized]
        private HTuple hv_Characters = new HTuple();

        /// <summary>
        /// 创建一个OCR分类器参数
        /// </summary>
        [NonSerialized]
        private HTuple hv_NumHidden = 80;

        /// <summary>
        /// 创建一个OCR分类器参数
        /// </summary>
        [NonSerialized]
        private HTuple hv_Preprocessing = "none";

        /// <summary>
        /// 创建一个OCR分类器参数
        /// </summary>
        [NonSerialized]
        private HTuple hv_NumComponents = 10;

        /// <summary>
        /// 创建一个OCR分类器参数
        /// </summary>
        [NonSerialized]
        private HTuple hv_RandSeed = 42;

        #endregion

        #region   训练的输出数据
        /// <summary>
        /// 训练的输出数据
        /// </summary>
        [NonSerialized]
        private HTuple hv_Error;

        /// <summary>
        /// 训练的输出数据
        /// </summary>
        [NonSerialized]
        private HTuple hv_ErrorLog;

        /// <summary>
        /// 训练的输出数据
        /// </summary>
        [NonSerialized]
        private HTuple hv_Class2;

        /// <summary>
        /// 训练的输出数据
        /// </summary>
        [NonSerialized]
        private HTuple hv_Confidence1;

        #endregion

        #region    要训练的文件路径
        /// <summary>
        /// 要训练的文件路径
        /// </summary>
        [NonSerialized]
        HTuple hv_TrainingFile = null;
        #endregion

        #region   字库名称
        /// <summary>
        /// 字库名称
        /// </summary>
        private string hv_FileName = null;
        #endregion

        //  #region  截取ocr的检测区域 的点位
        ///// <summary>
        ///// 截取ocr的检测区域 的点位 Y1
        ///// </summary>
        //[NonSerialized]
        //HTuple hv_Row1 = 1081.66;

        ///// <summary>
        ///// 截取ocr的检测区域 的点位 X1
        ///// </summary>
        //[NonSerialized]
        //HTuple hv_Column1 = 469.3;

        ///// <summary>
        ///// 截取ocr的检测区域 的点位 Y2
        ///// </summary>
        //[NonSerialized]
        //HTuple hv_Row2 = 1263.1;


        ///// <summary>
        ///// 截取ocr的检测区域 的点位 X2
        ///// </summary>
        //[NonSerialized]
        //HTuple hv_Column2 = 2034.22;

        ///// <summary>
        ///// 外接的矩形点
        ///// </summary>
        //[NonSerialized]
        //HalControl.ROI.Rectangle2.IOutsideRectangle2ROI _iOutSide = null;
        //   #endregion

        #region  emphasize参数
        /// <summary>
        /// emphasize参数
        /// </summary>
        [NonSerialized]
        HTuple MaskWidth = 17;

        /// <summary>
        /// emphasize参数
        /// </summary>
        [NonSerialized]
        HTuple MaskHeight = 17;

        /// <summary>
        /// emphasize参数
        /// </summary>
        [NonSerialized]
        HTuple Factor = 1;

        #endregion

        #region scale_image参数
        /// <summary>
        /// scale_image参数
        /// </summary>
        [NonSerialized]
        HTuple Mult = 1;

        /// <summary>
        /// scale_image参数
        /// </summary>
        [NonSerialized]
        HTuple Add = 1;

        #endregion

        #region *threshold参数
        /// <summary>
        /// threshold参数
        /// </summary>
        [NonSerialized]
        HTuple MinGray = 80;

        /// <summary>
        /// threshold参数
        /// </summary>
        [NonSerialized]
        HTuple MaxGray = 255;

        #endregion

        #region  *select_shape参数
        /// <summary>
        /// select_shape参数
        /// </summary>
        [NonSerialized]
        HTuple Features = "area";

        /// <summary>
        /// select_shape参数
        /// </summary>
        [NonSerialized]
        HTuple Operation = "and";

        /// <summary>
        /// select_shape参数
        /// </summary>
        [NonSerialized]
        HTuple Min = 1513.32;

        /// <summary>
        /// select_shape参数
        /// </summary>
        [NonSerialized]
        HTuple Max = 5000;

        #endregion

        #region  ocr指针路径
        /// <summary>
        /// ocr指针路径 
        /// </summary>
        private string path1 = null;
        #endregion

        #region  无用代码
        //#region  创建测试ocr
        ///// <summary>
        ///// 创建测试ocr
        ///// </summary>
        //[NonSerialized]
        //HTuple hv_WidthCharacter = 8;

        ///// <summary>
        ///// 创建测试ocr
        ///// </summary>
        //[NonSerialized]
        //HTuple hv_HeightCharacter = 10;

        ///// <summary>
        ///// 创建测试ocr
        ///// </summary>
        //[NonSerialized]
        //HTuple hv_Interpolation = "constant";

        ///// <summary>
        ///// 创建测试ocr
        ///// </summary>
        //[NonSerialized]
        //HTuple hv_Features = "default";

        ///// <summary>
        ///// 创建测试ocr
        ///// </summary>
        //[NonSerialized]
        //HTuple[] hv_Characters = new HTuple[36];

        ///// <summary>
        ///// 创建测试ocr
        ///// </summary>
        //[NonSerialized]
        //HTuple hv_NumHidden = 80;

        ///// <summary>
        ///// 创建测试ocr
        ///// </summary>
        //[NonSerialized]
        //HTuple hv_Preprocessing = "none";

        ///// <summary>
        ///// 创建测试ocr
        ///// </summary>
        //[NonSerialized]
        //HTuple hv_NumComponents = 10;

        ///// <summary>
        ///// 创建测试ocr
        ///// </summary>
        //[NonSerialized]
        //HTuple hv_RandSeed = 42;

        //#endregion
        #endregion

        #region   ***添加训练ocr
        /// <summary>
        /// 添加训练ocr
        /// </summary>
        [NonSerialized]
        HTuple hv_Class = "a";

        ///// <summary>
        ///// 添加训练ocr
        ///// </summary>
        //[NonSerialized]
        //HTuple hv_TrainningFile = "train_ocr";

        /// <summary>
        /// 添加训练ocr
        /// </summary>
        [NonSerialized]
        HTuple hv_MaxIteration = 200;

        /// <summary>
        /// 添加训练ocr
        /// </summary>
        [NonSerialized]
        HTuple hv_WeightTolerance = 3;

        /// <summary>
        /// 添加训练ocr
        /// </summary>
        [NonSerialized]
        HTuple hv_ErrorTolerance = 0.01;
        #endregion

        #region   无用代码
        #region  保存ocr句柄
        /// <summary>
        ///  保存ocr句柄  
        /// </summary>
        // string hv_FileName = "I:/光宝ocr/ocr/ziji.omc";
        #endregion
        #endregion

        #region   分割到的region数
        /// <summary>
        /// 分割到的region数
        /// </summary>
        [NonSerialized]
        HTuple hv_Number = null;
        #endregion

        #region 分割到的region
        /// <summary>
        /// 分割到的region
        /// </summary>
        [NonSerialized]
        HObject ho_SelectedRegions;
        #endregion

        #region  读取ocr的到的分数
        /// <summary>
        /// 读取ocr的到的分数
        /// </summary>
        [NonSerialized]
        HTuple hv_Confidence;
        #endregion

        #region   ocr指针
        /// <summary>
        /// ocr指针
        /// </summary>
        [NonSerialized]
        HTuple hv_OCRHandle = null;
        #endregion

        #region 读取到的类
        /// <summary>
        /// 读取 到的类
        /// </summary>
        [NonSerialized]
        HTuple hv_Class1 = null;

        #endregion

        // #region  放射变换的矩阵
        ///// <summary>
        ///// 放射变换的矩阵
        ///// </summary>
        //[NonSerialized]
        // HTuple hv_HomMat2D = null;

        ///// <summary>
        ///// 需要防射变化
        ///// </summary>
        //IRectShuJuHv_HomMat2D _ihv_HomMat2D = null;
        // #endregion

        #region   建立字符的对比模板类
        /// <summary>
        /// 建立字符的对比模板类
        /// </summary>
        OcrTrained_Class _ocrTrainedClass = null;
        #endregion

        //#region   跟随定位的数据

        //#region   跟随点
        ///// <summary>
        ///// 跟随点x
        ///// </summary>
        //HTuple geuSuiDian_X_Col = null;

        ///// <summary>
        ///// 跟随点y
        ///// </summary>
        //HTuple genSuiDian_Y_Row = null;

        ///// <summary>
        ///// 跟随点角度a
        ///// </summary>
        //HTuple genSuiDian_A = null;
        //#endregion

        //#region   放射变换矩阵
        ///// <summary>
        ///// 跟随点的放射变换矩阵
        ///// </summary>
        //HTuple genSuiDianWei_Hv_HomMat2D = null;
        //#endregion

        //#region 防射变换偏移的数据接口
        ///// <summary>
        ///// 防射变换偏移的数据接口
        ///// </summary>
        //IRectShuJuPianYi irectShuJuPianYi = null;
        //#endregion

        //#region  跟随点与定位点的变换region
        ///// <summary>
        ///// 跟随点与定位点的变换region
        ///// </summary>
        //HObject genSuiDianYuDingWeiDianDeBianHuanRegion = null;
        //#endregion

        //#endregion

        #region  要读取ocr的个数
        /// <summary>
        /// 要读取ocr的个数
        /// </summary>
        uint _yaoDuQuOcrDeGeShu = 1;
        #endregion

        #region  要读取ocr的region数据点的集合
        /// <summary>
        /// 要读取ocr的region数据点的集合
        /// </summary>       
        List<IOutsideRectangle2ROI> _list_IOutSide = null;
        #endregion

        #region   当前roi的引索
        /// <summary>
        /// 当前roi的引索
        /// </summary>
        HalControl.ROI.IDiJiGeROIBeiXuanZhong _iXuanZhongDeRoi = null;
        #endregion

        #endregion

        #region  属性

        #region   创建一个OCR MLP分类器参数
        /// <summary>
        ///  创建一个OCR分类器参数
        /// </summary>
        public HTuple Hv_WidthCharacter
        {
            get { return hv_WidthCharacter; }
            set { hv_WidthCharacter = value; }
        }

        /// <summary>
        ///  创建一个OCR分类器参数
        /// </summary>
        public HTuple Hv_HeightCharacter
        {
            get { return hv_HeightCharacter; }
            set { hv_HeightCharacter = value; }
        }

        /// <summary>
        ///  创建一个OCR分类器参数
        /// </summary>
        public HTuple Hv_Interpolation
        {
            get { return hv_Interpolation; }
            set { hv_Interpolation = value; }
        }


        /// <summary>
        ///  创建一个OCR分类器参数
        /// </summary>
        public HTuple Hv_Features
        {
            get { return hv_Features; }
            set { hv_Features = value; }
        }

        /// <summary>
        ///  创建一个OCR分类器参数
        /// </summary>
        public HTuple Hv_Characters
        {
            get { return hv_Characters; }
            set { hv_Characters = value; }
        }

        /// <summary>
        /// 创建一个OCR分类器参数
        /// </summary>
        public HTuple Hv_NumHidden
        {
            get { return hv_NumHidden; }
            set { hv_NumHidden = value; }
        }

        /// <summary>
        /// 创建一个OCR分类器参数
        /// </summary>
        public HTuple Hv_Preprocessing
        {
            get { return hv_Preprocessing; }
            set { hv_Preprocessing = value; }
        }

        /// <summary>
        /// 创建一个OCR分类器参数
        /// </summary>
        public HTuple Hv_NumComponents
        {
            get { return hv_NumComponents; }
            set { hv_NumComponents = value; }
        }

        /// <summary>
        /// 创建一个OCR分类器参数
        /// </summary>
        public HTuple Hv_RandSeed
        {
            get { return hv_RandSeed; }
            set { hv_RandSeed = value; }
        }
        #endregion

        #region  字库名称
        /// <summary>
        /// 字库名称
        /// </summary>
        public string Hv_FileName
        {
            get
            {
                if (hv_FileName == null)
                {
                    // hv_FileName = "Document_0-9A-Z_Rej.omc";
                    hv_FileName = "test";
                }
                return hv_FileName;
            }
            set { hv_FileName = value; }
        }
        #endregion

        //#region  截取ocr的检测区域
        ///// <summary>
        ///// 外接的矩形点
        ///// </summary>
        //public HalControl.ROI.Rectangle2.IOutsideRectangle2ROI IOutSide
        //{
        //    get
        //    {
        //        if (_iOutSide == null)
        //        {
        //            //_iOutSide = new HalControl.ROI.Rectangle1.OutSideRectangle1ROI();
        //            //_iOutSide.Col_x1 = 100;
        //            //_iOutSide.Row_y1 = 100;
        //            //_iOutSide.Col_x2 = 200;
        //            //_iOutSide.Row_y2 = 200;
        //            _iOutSide = new OutsideRectangle2ROI();
        //            _iOutSide.Mid_col_x = 100;
        //            _iOutSide.Mid_row_y = 100;
        //            _iOutSide.Phi = 0;
        //            _iOutSide.Len1 = 100;
        //            _iOutSide.Len2 = 100;

        //        }
        //        return _iOutSide;
        //    }
        //    set
        //    {
        //        if (_iOutSide == null)
        //        {
        //            //_iOutSide = new HalControl.ROI.Rectangle1.OutSideRectangle1ROI();
        //            //_iOutSide.Col_x1 = 100;
        //            //_iOutSide.Row_y1 = 100;
        //            //_iOutSide.Col_x2 = 200;
        //            //_iOutSide.Row_y2 = 200;

        //            _iOutSide = new OutsideRectangle2ROI();
        //            _iOutSide.Mid_col_x = 100;
        //            _iOutSide.Mid_row_y = 100;
        //            _iOutSide.Phi = 0;
        //            _iOutSide.Len1 = 100;
        //            _iOutSide.Len2 = 100;
        //        }

        //        _iOutSide = value;
        //    }
        //}
        //#endregion

        #region  emphasize参数
        /// <summary>
        /// 
        /// </summary>
        public HTuple MaskWidth1
        {
            get { return MaskWidth; }
            set { MaskWidth = value; }
        }

        /// <summary>
        /// 
        /// </summary>
        public HTuple MaskHeight1
        {
            get { return MaskHeight; }
            set { MaskHeight = value; }
        }

        /// <summary>
        /// 
        /// </summary>
        public HTuple Factor1
        {
            get { return Factor; }
            set { Factor = value; }
        }
        #endregion

        #region  scale_image参数
        /// <summary>
        /// 
        /// </summary>
        public HTuple Mult1
        {
            get { return Mult; }
            set { Mult = value; }
        }

        /// <summary>
        /// 
        /// </summary>
        public HTuple Add1
        {
            get { return Add; }
            set { Add = value; }
        }
        #endregion

        #region  *threshold参数
        /// <summary>
        /// 
        /// </summary>
        public HTuple MinGray1
        {
            get { return MinGray; }
            set { MinGray = value; }
        }

        /// <summary>
        /// 
        /// </summary>
        public HTuple MaxGray1
        {
            get { return MaxGray; }
            set { MaxGray = value; }
        }
        #endregion

        #region   *select_shape参数
        /// <summary>
        /// 
        /// </summary>
        public HTuple Features1
        {
            get { return Features; }
            set { Features = value; }
        }
        /// <summary>
        /// 
        /// </summary>
        public HTuple Operation1
        {
            get { return Operation; }
            set { Operation = value; }
        }


        /// <summary>
        /// 
        /// </summary>
        public HTuple Min1
        {
            get { return Min; }
            set { Min = value; }
        }

        /// <summary>
        /// 
        /// </summary>
        public HTuple Max1
        {
            get { return Max; }
            set { Max = value; }
        }
        #endregion

        #region   ocr指针路径
        /// <summary>
        /// ocr指针路径 
        /// </summary>
        public string Path1
        {
            get
            {
                if (path1 == null)
                {
                    // path1 = AppDomain.CurrentDomain.BaseDirectory + @"Ocr\" + Hv_FileName + ".omc";
                    string str = AppDomain.CurrentDomain.BaseDirectory + @"Ocr\" + Hv_FileName + ".omc";
                    return str;
                }
                return path1;
            }
            set { path1 = value; }
        }
        #endregion

        #region  添加训练ocr
        /// <summary>
        /// 要训练的字符类
        /// </summary>
        public HTuple Hv_Class
        {
            get
            {
                if (hv_Class == null)
                {
                    hv_Class = "a";
                }
                return hv_Class;
            }
            set { hv_Class = value; }
        }

        /// <summary>
        /// 要训练的文件路径
        /// </summary>
        public HTuple Hv_TrainingFile
        {
            get
            {
                if (hv_TrainingFile == null)
                {
                    //    hv_TrainingFile = AppDomain.CurrentDomain.BaseDirectory + @"TrainingOCR\" + Hv_FileName + ".trf";
                    string str = AppDomain.CurrentDomain.BaseDirectory + @"TrainingOCR\" + Hv_FileName + ".trf";
                    return str;
                }
                return hv_TrainingFile;
            }
            set { hv_TrainingFile = value; }
        }

        /// <summary>
        /// 训练时迭代的次数
        /// </summary>
        public HTuple Hv_MaxIteration
        {
            get
            {
                if (hv_MaxIteration == null)
                {
                    hv_MaxIteration = 200;
                }
                return hv_MaxIteration;
            }
            set { hv_MaxIteration = value; }
        }

        /// <summary>
        /// 要训练时初始化的权重
        /// </summary>
        public HTuple Hv_WeightTolerance
        {
            get
            {
                if (hv_WeightTolerance == null)
                {
                    hv_WeightTolerance = 3;
                }
                return hv_WeightTolerance;
            }
            set { hv_WeightTolerance = value; }
        }

        /// <summary>
        /// 要训练的最小误差
        /// </summary>
        public HTuple Hv_ErrorTolerance
        {
            get
            {

                if (hv_ErrorTolerance == null)
                {
                    hv_ErrorTolerance = 0.01;
                }
                return hv_ErrorTolerance;
            }
            set { hv_ErrorTolerance = value; }
        }

        #endregion

        #region  训练的输出数据
        /// <summary>
        /// 训练的输出数据
        /// </summary>
        public HTuple Hv_Error
        {
            get { return hv_Error; }
            set { hv_Error = value; }
        }

        /// <summary>
        /// 训练的输出数据
        /// </summary>
        public HTuple Hv_ErrorLog
        {
            get { return hv_ErrorLog; }
            set { hv_ErrorLog = value; }
        }

        /// <summary>
        /// 训练的输出数据
        /// </summary>
        public HTuple Hv_Class2
        {
            get { return hv_Class2; }
            set { hv_Class2 = value; }
        }

        /// <summary>
        /// 训练的输出数据
        /// </summary>
        public HTuple Hv_Confidence1
        {
            get { return hv_Confidence1; }
            set { hv_Confidence1 = value; }
        }
        #endregion

        #region   无用代码

        #region  无用代码
        #region  无用代码
        //         #region   ***创建测试ocr
        //         /// <summary>
        //         /// 
        //         /// </summary>
        //         public HTuple Hv_WidthCharacter
        //         {
        //             get { return hv_WidthCharacter; }
        //             set { hv_WidthCharacter = value; }
        //         }

        //         /// <summary>
        //         /// 
        //         /// </summary>
        //         public HTuple Hv_HeightCharacter
        //         {
        //             get { return hv_HeightCharacter; }
        //             set { hv_HeightCharacter = value; }
        //         }

        //         /// <summary>
        //         /// 
        //         /// </summary>
        //         public HTuple Hv_Interpolation
        //         {
        //             get { return hv_Interpolation; }
        //             set { hv_Interpolation = value; }
        //         }

        //         /// <summary>
        //         /// 
        //         /// </summary>
        //         public HTuple Hv_Features
        //         {
        //             get { return hv_Features; }
        //             set { hv_Features = value; }
        //         }

        //         /// <summary>
        //         /// 
        //         /// </summary>
        //         public HTuple[] Hv_Characters
        //         {
        //             get { return hv_Characters; }
        //             set { hv_Characters = value; }
        //         }

        //         /// <summary>
        //         /// 
        //         /// </summary>
        //         public HTuple Hv_NumHidden
        //         {
        //             get { return hv_NumHidden; }
        //             set { hv_NumHidden = value; }
        //         }

        //         /// <summary>
        //         /// 
        //         /// </summary>
        //         public HTuple Hv_Preprocessing
        //         {
        //             get { return hv_Preprocessing; }
        //             set { hv_Preprocessing = value; }
        //         }

        //         /// <summary>
        //         /// 
        //         /// </summary>
        //         public HTuple Hv_NumComponents
        //         {
        //             get { return hv_NumComponents; }
        //             set { hv_NumComponents = value; }
        //         }

        //         /// <summary>
        //         /// 
        //         /// </summary>
        //         public HTuple Hv_RandSeed
        //         {
        //             get { return hv_RandSeed; }
        //             set { hv_RandSeed = value; }
        //         }
        //#endregion

        #endregion

        #region 无用代码
        #region    保存ocr句柄
        /// <summary>
        /// 
        /// </summary>
        //public string Hv_FileName
        //{
        //    get { return hv_FileName; }
        //    set { hv_FileName = value; }
        //}
        #endregion

        #endregion
        #endregion

        #endregion

        #region  分割到的region数
        /// <summary>
        /// 分割到的region数
        /// </summary>
        public HTuple Hv_Number
        {
            get { return hv_Number; }
            set { hv_Number = value; }
        }
        #endregion

        #region  分割到的region
        /// <summary>
        /// 分割到的region
        /// </summary>
        public HObject Ho_SelectedRegions
        {
            get
            {
                if (ho_SelectedRegions == null)
                {
                    HOperatorSet.GenEmptyObj(out ho_SelectedRegions);
                }
                return ho_SelectedRegions;
            }
            set { ho_SelectedRegions = value; }
        }
        #endregion

        #region  读取ocr的到的分数
        /// <summary>
        /// 读取ocr的到的分数
        /// </summary>
        public HTuple Hv_Confidence
        {
            get { return hv_Confidence; }
            set { hv_Confidence = value; }
        }
        #endregion

        #region   ocr指针
        /// <summary>
        /// ocr指针
        /// </summary>
        public HTuple Hv_OCRHandle
        {
            get
            {
                if (hv_OCRHandle == null)
                {
                    HOperatorSet.ReadOcrClassMlp(Path1, out hv_OCRHandle);
                }
                return hv_OCRHandle;
            }

            set { hv_OCRHandle = value; }
        }
        #endregion

        #region    读取 到的类
        /// <summary>
        /// 读取 到的类
        /// </summary>
        public HTuple Hv_Class1
        {
            get { return hv_Class1; }
            set { hv_Class1 = value; }
        }
        #endregion

        // #region  防射变化矩阵
        ///// <summary>
        ///// 防射变换矩阵
        ///// </summary>
        //public HTuple Hv_HomMat2D
        //{
        //    get { return hv_HomMat2D; }
        //    set { hv_HomMat2D = value; }
        //}

        ///// <summary>
        ///// 需要防射变化
        ///// </summary>
        //public IRectShuJuHv_HomMat2D Ihv_HomMat2D
        //{
        //    get { return _ihv_HomMat2D; }
        //    set { _ihv_HomMat2D = value; }
        //}
        //  #endregion

        #region   建立字符的对比模板类
        /// <summary>
        /// 建立字符的对比模板类
        /// </summary>
        public OcrTrained_Class OcrTrainedClass
        {
            get
            {
                if (_ocrTrainedClass == null)
                {
                    _ocrTrainedClass = new OcrTrained_Class();
                }
                return _ocrTrainedClass;
            }
            set
            {
                if (_ocrTrainedClass == null)
                {
                    _ocrTrainedClass = new OcrTrained_Class();
                }

                _ocrTrainedClass = value;
            }
        }
        #endregion

        //#region   跟随定位的数据

        //#region  跟随点
        ///// <summary>
        ///// 跟随点x
        ///// </summary>
        //public HTuple GeuSuiDian_X_Col
        //{
        //    get { return geuSuiDian_X_Col; }
        //    set { geuSuiDian_X_Col = value; }
        //}

        ///// <summary>
        ///// 跟随点y
        ///// </summary>
        //public HTuple GenSuiDian_Y_Row
        //{
        //    get { return genSuiDian_Y_Row; }
        //    set { genSuiDian_Y_Row = value; }
        //}

        ///// <summary>
        ///// 跟随点角度a
        ///// </summary>
        //public HTuple GenSuiDian_A
        //{
        //    get { return genSuiDian_A; }
        //    set { genSuiDian_A = value; }
        //}
        //#endregion

        //#region  放射变换矩阵
        ///// <summary>
        ///// 跟随点的放射变换矩阵
        ///// </summary>
        //public HTuple GenSuiDianWei_Hv_HomMat2D
        //{
        //    get { return genSuiDianWei_Hv_HomMat2D; }
        //    set { genSuiDianWei_Hv_HomMat2D = value; }
        //}
        //#endregion

        //#region  放射变化偏移的数据接口
        ///// <summary>
        ///// 防射变换偏移的数据接口
        ///// </summary>
        //public IRectShuJuPianYi IrectShuJuPianYi
        //{
        //    get { return irectShuJuPianYi; }
        //    set { irectShuJuPianYi = value; }
        //}
        //#endregion

        //#region  跟随点与定位点的变换region
        ///// <summary>
        ///// 跟随点与定位点的变换region
        ///// </summary>
        //public HObject GenSuiDianYuDingWeiDianDeBianHuanRegion
        //{
        //    get { return genSuiDianYuDingWeiDianDeBianHuanRegion; }
        //    set { genSuiDianYuDingWeiDianDeBianHuanRegion = value; }
        //}
        //#endregion

        //#endregion

        #region   要读取ocr的个数
        /// <summary>
        /// 要读取ocr的个数
        /// </summary>
        public uint YaoDuQuOcrDeGeShu
        {
            get { return _yaoDuQuOcrDeGeShu; }
            set { _yaoDuQuOcrDeGeShu = value; }
        }
        #endregion

        #region 要读取ocr的region数据点的集合
        /// <summary>
        /// 要读取ocr的region数据点的集合
        /// </summary>
        public List<IOutsideRectangle2ROI> List_IOutSide
        {
            get
            {
                if (_list_IOutSide == null)
                {
                    _list_IOutSide = new List<IOutsideRectangle2ROI>();
                    IOutsideRectangle2ROI roi_ = new OutsideRectangle2ROI();
                    roi_.Mid_row_y = 100;
                    roi_.Mid_col_x = 100;
                    roi_.Phi = 0;
                    roi_.Len1 = 100;
                    roi_.Len2 = 100;
                    _list_IOutSide.Add(roi_);
                }
                return _list_IOutSide;
            }
            set { _list_IOutSide = value; }
        }
        #endregion

        #region  当前roi的引索
        /// <summary>
        /// 当前roi的引索
        /// </summary>
        public HalControl.ROI.IDiJiGeROIBeiXuanZhong IXuanZhongDeRoi
        {
            get
            {
                if (_iXuanZhongDeRoi == null)
                {
                    _iXuanZhongDeRoi = new DiJiGeROIBeiXuanZhong();
                    _iXuanZhongDeRoi.IXuanZhongRoiDeIndex = 0;
                }
                return _iXuanZhongDeRoi;
            }
            set { _iXuanZhongDeRoi = value; }
        }
        #endregion

        #endregion

        #region  序列化保存数据

        #region   创建一个OCR MLP分类器参数
        /// <summary>
        ///  创建一个OCR分类器参数
        /// </summary>     
        object hv_WidthCharacter1;

        /// <summary>
        ///  创建一个OCR分类器参数
        /// </summary>
        object hv_HeightCharacter1;

        /// <summary>
        ///  创建一个OCR分类器参数
        /// </summary>
        object hv_Interpolation1;

        /// <summary>
        ///  创建一个OCR分类器参数
        /// </summary>
        object hv_Features1;

        /// <summary>
        ///  创建一个OCR分类器参数
        /// </summary>
        object hv_Characters1;

        /// <summary>
        /// 创建一个OCR分类器参数
        /// </summary>
        object hv_NumHidden1;

        /// <summary>
        /// 创建一个OCR分类器参数
        /// </summary>
        object hv_Preprocessing1;

        /// <summary>
        /// 创建一个OCR分类器参数
        /// </summary>
        object hv_NumComponents1;

        /// <summary>
        /// 创建一个OCR分类器参数
        /// </summary>
        object hv_RandSeed1;

        #endregion

        #region  截取ocr的检测区域
        ///// <summary>
        ///// 
        ///// </summary>
        //object hv_Row1_1;

        ///// <summary>
        ///// 
        ///// </summary>
        //object hv_Column1_1;

        ///// <summary>
        ///// 
        ///// </summary>
        //object hv_Row2_1;

        ///// <summary>
        ///// 
        ///// </summary>
        //object hv_Column2_1;
        #endregion

        #region  emphasize参数
        /// <summary>
        /// 
        /// </summary>
        object MaskWidth_1;

        /// <summary>
        /// 
        /// </summary>
        object MaskHeight_1;

        /// <summary>
        /// 
        /// </summary>
        object Factor_1;

        #endregion

        #region scale_image参数
        /// <summary>
        /// 
        /// </summary>
        object Mult_1;

        /// <summary>
        /// 
        /// </summary>
        object Add_1;

        #endregion

        #region  *threshold参数
        /// <summary>
        /// 
        /// </summary>
        object MinGray_1;

        /// <summary>
        /// 
        /// </summary>
        object MaxGray_1;

        #endregion

        #region  *select_shape参数
        /// <summary>
        /// 
        /// </summary>
        object Features_1;

        /// <summary>
        /// 
        /// </summary>
        object Operation_1;

        /// <summary>
        /// 
        /// </summary>
        object Min_1;

        /// <summary>
        /// 
        /// </summary>
        object Max_1;

        #endregion

        #region  无用代码
        // #region  ***创建测试ocr
        // /// <summary>
        // /// 
        // /// </summary>
        //     object hv_WidthCharacter_1;

        // /// <summary>
        // /// 
        // /// </summary>
        //     object hv_HeightCharacter_1;

        // /// <summary>
        // /// 
        // /// </summary>
        //     object hv_Interpolation_1;

        // /// <summary>
        // /// 
        // /// </summary>
        //     object hv_Features_1;

        // /// <summary>
        // /// 
        // /// </summary>
        //     object[] hv_Characters_1;

        // /// <summary>
        // /// 
        // /// </summary>
        // /// 
        //     object hv_NumHidden_1;

        // /// <summary>
        // /// 
        // /// </summary>
        //     object hv_Preprocessing_1;

        // /// <summary>
        // /// 
        // /// </summary>
        //     object hv_NumComponents_1;

        // /// <summary>
        // /// 
        // /// </summary>
        //     object hv_RandSeed_1;

        // #endregion

        //#region   ***添加训练ocr
        ///// <summary>
        ///// 
        ///// </summary>
        //     object hv_Class_1;

        ///// <summary>
        ///// 
        ///// </summary>
        //     object hv_TrainningFile_1 ;

        ///// <summary>
        ///// 
        ///// </summary>
        //     object hv_MaxIteration_1;

        ///// <summary>
        ///// 
        ///// </summary>
        //     object hv_WeightTolerance_1 ;

        ///// <summary>
        ///// 
        ///// </summary>
        //     object hv_ErrorTolerance_1 ;

        //#endregion
        #endregion

        #region  要训练的文件路径
        /// <summary>
        /// 要训练的文件路径
        /// </summary>
        object hv_TrainingFile_1;
        #endregion

        #region   外部接口数据
        /// <summary>
        /// 外部接口数据
        /// </summary>
        List<waiBuJieKouBaoCunShuJu> _waiBuJieKouBaoCunShuJu = new List<waiBuJieKouBaoCunShuJu>();
        #endregion

        #endregion

        #region  保存数据
        /// <summary>
        /// 保存数据
        /// </summary>
        public override void save()
        {
            base.save();

            #region   要训练的文件路径
            hv_TrainingFile_1 = hv_TrainingFile;
            #endregion

            #region  截取ocr的检测区域
            //hv_Row1_1 = this.IOutSide.Row_y1;
            //hv_Column1_1 = this.IOutSide.Col_x1;
            //hv_Row2_1 = this.IOutSide.Row_y2;
            //hv_Column2_1 = this.IOutSide.Col_x2;
            #endregion

            #region  emphasize参数
            MaskWidth_1 = MaskWidth;

            MaskHeight_1 = MaskHeight;

            Factor_1 = Factor;

            #endregion

            #region scale_image参数
            Mult_1 = Mult;

            Add_1 = Add;

            #endregion

            #region  *threshold参数
            MinGray_1 = MinGray;

            MaxGray_1 = MaxGray;

            #endregion

            #region  *select_shape参数
            Features_1 = Features;

            Operation_1 = Operation;

            Min_1 = Min;

            Max_1 = Max;

            #endregion

            #region   保存外部接口
            this._waiBuJieKouBaoCunShuJu.Clear();
            foreach (IOutsideRectangle2ROI io_ in List_IOutSide)
            {
                waiBuJieKouBaoCunShuJu wai_ = new waiBuJieKouBaoCunShuJu();
                wai_._mid_col_x = io_.Mid_col_x;
                wai_._mid_row_y = io_.Mid_row_y;
                wai_._len1 = io_.Len1;
                wai_._len2 = io_.Len2;
                wai_._angle = io_.Phi;
                this._waiBuJieKouBaoCunShuJu.Add(wai_);
            }
            #endregion

        }
        #endregion

        #region   初始化数据
        /// <summary>
        /// 初始化数据
        /// </summary>
        public override void init()
        {
            base.init();

            #region   要训练的文件路径
            hv_TrainingFile = (HTuple)hv_TrainingFile_1;
            #endregion

            #region  emphasize参数
            MaskWidth = (HTuple)MaskWidth_1;

            MaskHeight = (HTuple)MaskHeight_1;

            Factor = (HTuple)Factor_1;

            #endregion

            #region scale_image参数
            Mult = (HTuple)Mult_1;

            Add = (HTuple)Add_1;

            #endregion

            #region  *threshold参数
            MinGray = (HTuple)MinGray_1;

            MaxGray = (HTuple)MaxGray_1;

            #endregion

            #region  *select_shape参数
            Features = (HTuple)Features_1;

            Operation = (HTuple)Operation_1;

            Min = (HTuple)Min_1;

            Max = (HTuple)Max_1;

            #endregion

            #region  读取字符库
            HOperatorSet.ReadOcrClassMlp(Path1, out hv_OCRHandle);
            #endregion

            #region 保存外部接口
            List_IOutSide.Clear();
            foreach (waiBuJieKouBaoCunShuJu wai_ in this._waiBuJieKouBaoCunShuJu)
            {
                IOutsideRectangle2ROI roi_ = new OutsideRectangle2ROI();
                roi_.Len1 = (HTuple)wai_._len1;
                roi_.Len2 = (HTuple)wai_._len2;
                roi_.Mid_col_x = (HTuple)wai_._mid_col_x;
                roi_.Mid_row_y = (HTuple)wai_._mid_row_y;
                roi_.Phi = (HTuple)wai_._angle;
                List_IOutSide.Add(roi_);
            }
            #endregion
        }
        #endregion

        #region   构造函数
        /// <summary>
        /// 构造函数
        /// </summary>
        public OCRShuJu()
        {
            HOperatorSet.GenEmptyObj(out ho_SelectedRegions);
        }
        #endregion

        #region   检测
        public override bool analyze_show(HWindow hwin, string Key, ref Dictionary<string, object> _dictionary_resulte)
        {
            bool ok = false;
            /*********************************************处理***********************************************/
            HObject ho_ImageReduced_;
            HObject ho_SelectedRegions_;
            HObject ho_ROI_0_;
            HTuple hv_Number_;
            HTuple hv_Class_;
            HTuple hv_Confidence_;
            HTuple hv_modMat2D_;

            int num_region_ = 0;

            HOperatorSet.GenEmptyObj(out ho_ImageReduced_);
            HOperatorSet.GenEmptyObj(out ho_SelectedRegions_);
            HOperatorSet.GenEmptyObj(out ho_ROI_0_);

            HObject ho_Roi_;
            HOperatorSet.GenEmptyObj(out ho_Roi_);

            HObject ho_SelectedRegions_list_;
            HOperatorSet.GenEmptyObj(out ho_SelectedRegions_list_);

            foreach (HalControl.ROI.Rectangle2.IOutsideRectangle2ROI io_ in List_IOutSide)
            {
                HOperatorSet.GenRectangle2(out ho_Roi_, io_.Mid_row_y, io_.Mid_col_x, -io_.Phi, io_.Len1, io_.Len2);

                if (IrectShuJuPianYi != null)
                {
                    HOperatorSet.VectorAngleToRigid(GenSuiDian_Y_Row, GeuSuiDian_X_Col, GenSuiDian_A, IrectShuJuPianYi.Row, IrectShuJuPianYi.Column, IrectShuJuPianYi.Angle, out hv_modMat2D_);
                    HOperatorSet.AffineTransRegion(ho_Roi_, out ho_Roi_, hv_modMat2D_, "nearest_neighbor");
                }

                HOperatorSet.ReduceDomain(this.ImageFather.Ho_image, ho_Roi_, out ho_ImageReduced_);
                extract(ho_ImageReduced_, out ho_SelectedRegions_, MaskWidth1, MaskHeight1, Factor1, Mult1, Add1
               , MinGray1, MaxGray1, Features1, Operation1, Min1, Max1, out hv_Number_);

                if (hv_Number_.I != 0)
                {
                    if (hv_Number_ > 1)
                    {
                        HOperatorSet.Union1(ho_SelectedRegions_, out ho_SelectedRegions_);
                    }
                    HOperatorSet.ConcatObj(ho_SelectedRegions_, ho_SelectedRegions_list_, out ho_SelectedRegions_list_);
                    num_region_ += 1;
                }
            }

            #region  无用代码
            //if (IOCR.Ihv_HomMat2D != null)
            //{
            //    //HOperatorSet.GenRectangle1(out ho_ROI_0, IOCR.IOutSide.Row_y1, IOCR.IOutSide.Col_x1, IOCR.IOutSide.Row_y2, IOCR.IOutSide.Col_x2);
            //    HOperatorSet.GenRectangle2(out ho_ROI_0, IOCR.IOutSide.Mid_row_y, IOCR.IOutSide.Mid_col_x, IOCR.IOutSide.Phi, IOCR.IOutSide.Len1, IOCR.IOutSide.Len2);
            //    HOperatorSet.AffineTransRegion(ho_ROI_0, out ho_ROI_0, IOCR.Ihv_HomMat2D.Hv_HomMat2D, "nearest_neighbor");
            //    HOperatorSet.ReduceDomain(ho_Image, ho_ROI_0, out ho_ImageReduced);
            //    //ho_ROI_0.Dispose();
            //}
            //else
            //{
            //    //HOperatorSet.GenRectangle1(out ho_ROI_0, IOCR.IOutSide.Row_y1, IOCR.IOutSide.Col_x1, IOCR.IOutSide.Row_y2, IOCR.IOutSide.Col_x2);
            //    HOperatorSet.GenRectangle2(out ho_ROI_0, IOCR.IOutSide.Mid_row_y, IOCR.IOutSide.Mid_col_x, IOCR.IOutSide.Phi, IOCR.IOutSide.Len1, IOCR.IOutSide.Len2);
            //    HOperatorSet.ReduceDomain(ho_Image, ho_ROI_0, out ho_ImageReduced);
            //}
            //extract(ho_ImageReduced, out ho_SelectedRegions, IOCR.MaskWidth1, IOCR.MaskHeight1, IOCR.Factor1, IOCR.Mult1, IOCR.Add1
            //    , IOCR.MinGray1, IOCR.MaxGray1, IOCR.Features1, IOCR.Operation1, IOCR.Min1, IOCR.Max1, out hv_Number);
            #endregion

            Ho_SelectedRegions.Dispose();
            Ho_SelectedRegions = ho_SelectedRegions_list_;
            ReadOCR(Ho_SelectedRegions, this.ImageFather.Ho_image, Hv_OCRHandle, out hv_Class_, out hv_Confidence_);
            Hv_Class1 = hv_Class_;
            Hv_Confidence = hv_Confidence_;
            Hv_Number = (HTuple)num_region_;
            
            /*******************************************保存数据及数据分析*********************************************************/
            OCR_Result ocr_result_ = new OCR_Result();
            Key = "OCR_" + Key;
            ocr_result_.TolatName = Key;

            if (Hv_Number > (HTuple)0)
            {
                ocr_result_.Hv_Class1 = Hv_Class1;
                ocr_result_.Hv_Confidence = Hv_Confidence;
                ocr_result_.Number = Hv_Number;

                if (OcrTrainedClass._trained)//检测有没有训练对比字符
                {
                    string str_result = Hv_Class1.ToString();
                    if (str_result != OcrTrainedClass._ocrTrainingCharacteer)//ocr读取的字符与训练的字符做对比
                    {
                        OcrTrainedClass._result = false;
                        ocr_result_._Result = false;
                        ocr_result_.TolatResult = false;
                        OcrTrainedClass._allResult = false;
                    }
                    else
                    {
                        OcrTrainedClass._allResult = true;
                        ocr_result_._Result = true;
                        ocr_result_.TolatResult = true;
                        OcrTrainedClass._result = true;
                    }
                }
                else
                {
                    OcrTrainedClass._allResult = true;
                    ocr_result_._Result = true;
                    ocr_result_.TolatResult = true;
                    OcrTrainedClass._result = true;
                }
                //_dictionary_resulte.Add(Key, _result);
            }
            else
            {
                OcrTrainedClass._result = false;
                ocr_result_._Result = false;
                ocr_result_.TolatResult = false;
                OcrTrainedClass._allResult = false;

                //_dictionary_resulte.Add(Key, null);
            }

            _dictionary_resulte.Add(Key, ocr_result_);

            if (OcrTrainedClass._allResult)
            {
                ok = true;
            }

            show(hwin);


            return ok;
        }
        #endregion

        #region   显示
        public override bool show(HWindow hwin)
        {
            bool ok = false;
            foreach (IOutsideRectangle2ROI io_ in List_IOutSide)
            {
                HTuple hv_modMat2D;
                HObject hr_;
                HOperatorSet.GenEmptyRegion(out hr_);
                HOperatorSet.GenRectangle2(out hr_, io_.Mid_row_y, io_.Mid_col_x, io_.Phi, io_.Len1, io_.Len2);

                if (IrectShuJuPianYi != null)
                {
                    HOperatorSet.VectorAngleToRigid(GenSuiDian_Y_Row, GeuSuiDian_X_Col, GenSuiDian_A, IrectShuJuPianYi.Row, IrectShuJuPianYi.Column, IrectShuJuPianYi.Angle, out hv_modMat2D);
                    HOperatorSet.AffineTransRegion(hr_, out hr_, hv_modMat2D, "nearest_neighbor");
                }

                HOperatorSet.GenContourRegionXld(hr_, out hr_, "border");

                if (OcrTrainedClass._allResult)
                {
                    hwin.DispObj(hr_);
                }
                else
                {
                    hwin.SetColor("red");
                    hwin.DispObj(hr_);
                    hwin.SetColor("green");
                }
                hr_.Dispose();
            }

            ShowOCR(Ho_SelectedRegions, hwin, Hv_Class1);


            return ok;
        }
        #endregion

        #region  显示数据
        void disp_message(HTuple hv_WindowHandle, HTuple hv_String, HTuple hv_CoordSystem,
      HTuple hv_Row, HTuple hv_Column, HTuple hv_Color, HTuple hv_Box)
        {
            // Local iconic variables 

            // Local control variables 

            HTuple hv_Red = null, hv_Green = null, hv_Blue = null;
            HTuple hv_Row1Part = null, hv_Column1Part = null, hv_Row2Part = null;
            HTuple hv_Column2Part = null, hv_RowWin = null, hv_ColumnWin = null;
            HTuple hv_WidthWin = null, hv_HeightWin = null, hv_MaxAscent = null;
            HTuple hv_MaxDescent = null, hv_MaxWidth = null, hv_MaxHeight = null;
            HTuple hv_R1 = new HTuple(), hv_C1 = new HTuple(), hv_FactorRow = new HTuple();
            HTuple hv_FactorColumn = new HTuple(), hv_UseShadow = null;
            HTuple hv_ShadowColor = null, hv_Exception = new HTuple();
            HTuple hv_Width = new HTuple(), hv_Index = new HTuple();
            HTuple hv_Ascent = new HTuple(), hv_Descent = new HTuple();
            HTuple hv_W = new HTuple(), hv_H = new HTuple(), hv_FrameHeight = new HTuple();
            HTuple hv_FrameWidth = new HTuple(), hv_R2 = new HTuple();
            HTuple hv_C2 = new HTuple(), hv_DrawMode = new HTuple();
            HTuple hv_CurrentColor = new HTuple();
            HTuple hv_Box_COPY_INP_TMP = hv_Box.Clone();
            HTuple hv_Color_COPY_INP_TMP = hv_Color.Clone();
            HTuple hv_Column_COPY_INP_TMP = hv_Column.Clone();
            HTuple hv_Row_COPY_INP_TMP = hv_Row.Clone();
            HTuple hv_String_COPY_INP_TMP = hv_String.Clone();

            // Initialize local and output iconic variables 
            //This procedure displays text in a graphics window.
            //
            //Input parameters:
            //WindowHandle: The WindowHandle of the graphics window, where
            //   the message should be displayed
            //String: A tuple of strings containing the text message to be displayed
            //CoordSystem: If set to 'window', the text position is given
            //   with respect to the window coordinate system.
            //   If set to 'image', image coordinates are used.
            //   (This may be useful in zoomed images.)
            //Row: The row coordinate of the desired text position
            //   If set to -1, a default value of 12 is used.
            //Column: The column coordinate of the desired text position
            //   If set to -1, a default value of 12 is used.
            //Color: defines the color of the text as string.
            //   If set to [], '' or 'auto' the currently set color is used.
            //   If a tuple of strings is passed, the colors are used cyclically
            //   for each new textline.
            //Box: If Box[0] is set to 'true', the text is written within an orange box.
            //     If set to' false', no box is displayed.
            //     If set to a color string (e.g. 'white', '#FF00CC', etc.),
            //       the text is written in a box of that color.
            //     An optional second value for Box (Box[1]) controls if a shadow is displayed:
            //       'true' -> display a shadow in a default color
            //       'false' -> display no shadow (same as if no second value is given)
            //       otherwise -> use given string as color string for the shadow color
            //
            //Prepare window
            HOperatorSet.GetRgb(hv_WindowHandle, out hv_Red, out hv_Green, out hv_Blue);
            HOperatorSet.GetPart(hv_WindowHandle, out hv_Row1Part, out hv_Column1Part, out hv_Row2Part,
                out hv_Column2Part);
            HOperatorSet.GetWindowExtents(hv_WindowHandle, out hv_RowWin, out hv_ColumnWin,
                out hv_WidthWin, out hv_HeightWin);
            HOperatorSet.SetPart(hv_WindowHandle, 0, 0, hv_HeightWin - 1, hv_WidthWin - 1);
            //
            //default settings
            if ((int)(new HTuple(hv_Row_COPY_INP_TMP.TupleEqual(-1))) != 0)
            {
                hv_Row_COPY_INP_TMP = 12;
            }
            if ((int)(new HTuple(hv_Column_COPY_INP_TMP.TupleEqual(-1))) != 0)
            {
                hv_Column_COPY_INP_TMP = 12;
            }
            if ((int)(new HTuple(hv_Color_COPY_INP_TMP.TupleEqual(new HTuple()))) != 0)
            {
                hv_Color_COPY_INP_TMP = "";
            }
            //
            hv_String_COPY_INP_TMP = ((("" + hv_String_COPY_INP_TMP) + "")).TupleSplit("\n");
            //
            //Estimate extentions of text depending on font size.
            HOperatorSet.GetFontExtents(hv_WindowHandle, out hv_MaxAscent, out hv_MaxDescent,
                out hv_MaxWidth, out hv_MaxHeight);
            if ((int)(new HTuple(hv_CoordSystem.TupleEqual("window"))) != 0)
            {
                hv_R1 = hv_Row_COPY_INP_TMP.Clone();
                hv_C1 = hv_Column_COPY_INP_TMP.Clone();
            }
            else
            {
                //Transform image to window coordinates
                hv_FactorRow = (1.0 * hv_HeightWin) / ((hv_Row2Part - hv_Row1Part) + 1);
                hv_FactorColumn = (1.0 * hv_WidthWin) / ((hv_Column2Part - hv_Column1Part) + 1);
                hv_R1 = ((hv_Row_COPY_INP_TMP - hv_Row1Part) + 0.5) * hv_FactorRow;
                hv_C1 = ((hv_Column_COPY_INP_TMP - hv_Column1Part) + 0.5) * hv_FactorColumn;
            }
            //
            //Display text box depending on text size
            hv_UseShadow = 1;
            hv_ShadowColor = "gray";
            if ((int)(new HTuple(((hv_Box_COPY_INP_TMP.TupleSelect(0))).TupleEqual("true"))) != 0)
            {
                if (hv_Box_COPY_INP_TMP == null)
                    hv_Box_COPY_INP_TMP = new HTuple();
                hv_Box_COPY_INP_TMP[0] = "#fce9d4";
                hv_ShadowColor = "#f28d26";
            }
            if ((int)(new HTuple((new HTuple(hv_Box_COPY_INP_TMP.TupleLength())).TupleGreater(
                1))) != 0)
            {
                if ((int)(new HTuple(((hv_Box_COPY_INP_TMP.TupleSelect(1))).TupleEqual("true"))) != 0)
                {
                    //Use default ShadowColor set above
                }
                else if ((int)(new HTuple(((hv_Box_COPY_INP_TMP.TupleSelect(1))).TupleEqual(
                    "false"))) != 0)
                {
                    hv_UseShadow = 0;
                }
                else
                {
                    hv_ShadowColor = hv_Box_COPY_INP_TMP[1];
                    //Valid color?
                    try
                    {
                        HOperatorSet.SetColor(hv_WindowHandle, hv_Box_COPY_INP_TMP.TupleSelect(
                            1));
                    }
                    // catch (Exception) 
                    catch (HalconException HDevExpDefaultException1)
                    {
                        HDevExpDefaultException1.ToHTuple(out hv_Exception);
                        hv_Exception = "Wrong value of control parameter Box[1] (must be a 'true', 'false', or a valid color string)";
                        throw new HalconException(hv_Exception);
                    }
                }
            }
            if ((int)(new HTuple(((hv_Box_COPY_INP_TMP.TupleSelect(0))).TupleNotEqual("false"))) != 0)
            {
                //Valid color?
                try
                {
                    HOperatorSet.SetColor(hv_WindowHandle, hv_Box_COPY_INP_TMP.TupleSelect(0));
                }
                // catch (Exception) 
                catch (HalconException HDevExpDefaultException1)
                {
                    HDevExpDefaultException1.ToHTuple(out hv_Exception);
                    hv_Exception = "Wrong value of control parameter Box[0] (must be a 'true', 'false', or a valid color string)";
                    throw new HalconException(hv_Exception);
                }
                //Calculate box extents
                hv_String_COPY_INP_TMP = (" " + hv_String_COPY_INP_TMP) + " ";
                hv_Width = new HTuple();
                for (hv_Index = 0; (int)hv_Index <= (int)((new HTuple(hv_String_COPY_INP_TMP.TupleLength()
                    )) - 1); hv_Index = (int)hv_Index + 1)
                {
                    HOperatorSet.GetStringExtents(hv_WindowHandle, hv_String_COPY_INP_TMP.TupleSelect(
                        hv_Index), out hv_Ascent, out hv_Descent, out hv_W, out hv_H);
                    hv_Width = hv_Width.TupleConcat(hv_W);
                }
                hv_FrameHeight = hv_MaxHeight * (new HTuple(hv_String_COPY_INP_TMP.TupleLength()
                    ));
                hv_FrameWidth = (((new HTuple(0)).TupleConcat(hv_Width))).TupleMax();
                hv_R2 = hv_R1 + hv_FrameHeight;
                hv_C2 = hv_C1 + hv_FrameWidth;
                //Display rectangles
                HOperatorSet.GetDraw(hv_WindowHandle, out hv_DrawMode);
                HOperatorSet.SetDraw(hv_WindowHandle, "fill");
                //Set shadow color
                HOperatorSet.SetColor(hv_WindowHandle, hv_ShadowColor);
                if ((int)(hv_UseShadow) != 0)
                {
                    HOperatorSet.DispRectangle1(hv_WindowHandle, hv_R1 + 1, hv_C1 + 1, hv_R2 + 1, hv_C2 + 1);
                }
                //Set box color
                HOperatorSet.SetColor(hv_WindowHandle, hv_Box_COPY_INP_TMP.TupleSelect(0));
                HOperatorSet.DispRectangle1(hv_WindowHandle, hv_R1, hv_C1, hv_R2, hv_C2);
                HOperatorSet.SetDraw(hv_WindowHandle, hv_DrawMode);
            }
            //Write text.
            for (hv_Index = 0; (int)hv_Index <= (int)((new HTuple(hv_String_COPY_INP_TMP.TupleLength()
                )) - 1); hv_Index = (int)hv_Index + 1)
            {
                hv_CurrentColor = hv_Color_COPY_INP_TMP.TupleSelect(hv_Index % (new HTuple(hv_Color_COPY_INP_TMP.TupleLength()
                    )));
                if ((int)((new HTuple(hv_CurrentColor.TupleNotEqual(""))).TupleAnd(new HTuple(hv_CurrentColor.TupleNotEqual(
                    "auto")))) != 0)
                {
                    HOperatorSet.SetColor(hv_WindowHandle, hv_CurrentColor);
                }
                else
                {
                    HOperatorSet.SetRgb(hv_WindowHandle, hv_Red, hv_Green, hv_Blue);
                }
                hv_Row_COPY_INP_TMP = hv_R1 + (hv_MaxHeight * hv_Index);
                HOperatorSet.SetTposition(hv_WindowHandle, hv_Row_COPY_INP_TMP, hv_C1);
                HOperatorSet.WriteString(hv_WindowHandle, hv_String_COPY_INP_TMP.TupleSelect(
                    hv_Index));
            }
            //Reset changed window settings
            HOperatorSet.SetRgb(hv_WindowHandle, hv_Red, hv_Green, hv_Blue);
            HOperatorSet.SetPart(hv_WindowHandle, hv_Row1Part, hv_Column1Part, hv_Row2Part,
                hv_Column2Part);

            return;
        }
        #endregion

        #region  提取ocr读取的region
        void extract(HObject ho_ImageReduced, out HObject ho_SelectedRegions, HTuple hv_MaskWidth,
      HTuple hv_MaskHeight, HTuple hv_Factor, HTuple hv_Mult, HTuple hv_Add, HTuple hv_MinGray,
      HTuple hv_MaxGray, HTuple hv_Features, HTuple hv_Operation, HTuple hv_Min, HTuple hv_Max,
      out HTuple hv_Number)
        {
            // Local iconic variables 
            HTuple area, col_x, row_y;
            HObject ho_ImageEmphasize, ho_ImageScaled;
            HObject ho_Region, ho_ConnectedRegions;
            // Initialize local and output iconic variables 
            HOperatorSet.GenEmptyObj(out ho_SelectedRegions);
            HOperatorSet.GenEmptyObj(out ho_ImageEmphasize);
            HOperatorSet.GenEmptyObj(out ho_ImageScaled);
            HOperatorSet.GenEmptyObj(out ho_Region);
            HOperatorSet.GenEmptyObj(out ho_ConnectedRegions);
            try
            {

                ho_ImageEmphasize.Dispose();
                HOperatorSet.Emphasize(ho_ImageReduced, out ho_ImageEmphasize, hv_MaskWidth,
                    hv_MaskHeight, hv_Factor);
                //invert_image (ImageEmphasize, ImageInvert)
                ho_ImageScaled.Dispose();
                HOperatorSet.ScaleImage(ho_ImageEmphasize, out ho_ImageScaled, hv_Mult, hv_Add);
                ho_Region.Dispose();
                HOperatorSet.Threshold(ho_ImageScaled, out ho_Region, hv_MinGray, hv_MaxGray);
                ho_ConnectedRegions.Dispose();
                HOperatorSet.Connection(ho_Region, out ho_ConnectedRegions);
                ho_SelectedRegions.Dispose();
                HOperatorSet.SelectShape(ho_ConnectedRegions, out ho_SelectedRegions, hv_Features,
                    hv_Operation, hv_Min, hv_Max);

                //HOperatorSet.CountObj(ho_SelectedRegions, out hv_Number);
                // HOperatorSet.EulerNumber(ho_SelectedRegions, out hv_Number);

                HOperatorSet.AreaCenter(ho_SelectedRegions, out area, out row_y, out col_x);

                if (area.Length > 0)
                {
                    hv_Number = area.I;
                }
                else
                {
                    hv_Number = area.Length;
                }
                ho_ImageEmphasize.Dispose();
                ho_ImageScaled.Dispose();
                ho_Region.Dispose();
                ho_ConnectedRegions.Dispose();

                return;
            }
            catch (HalconException HDevExpDefaultException)
            {
                ho_ImageEmphasize.Dispose();
                ho_ImageScaled.Dispose();
                ho_Region.Dispose();
                ho_ConnectedRegions.Dispose();
                throw HDevExpDefaultException;
            }
        }
        #endregion

        #region  读取ocr
        void ReadOCR(HObject ho_SelectedRegions, HObject ho_Image, HTuple hv_OCRHandle,
          out HTuple hv_Class, out HTuple hv_Confidence)
        {
            // Initialize local and output iconic variables 
            HOperatorSet.DoOcrMultiClassMlp(ho_SelectedRegions, ho_Image, hv_OCRHandle, out hv_Class,
                out hv_Confidence);
            return;
        }
        #endregion

        #region   显示数据OCR
        void ShowOCR(HObject ho_SelectedRegions, HWindow hv_WindowHandle, HTuple hv_Class)
        {
            if (hv_Class == null)
            { return; }
            // Local control variables 

            HTuple hv_Number1 = null, hv_Area = null, hv_Row1 = null;
            HTuple hv_Column1 = null, hv_Index = null;
            // Initialize local and output iconic variables 

            HOperatorSet.CountObj(ho_SelectedRegions, out hv_Number1);
            HOperatorSet.AreaCenter(ho_SelectedRegions, out hv_Area, out hv_Row1, out hv_Column1);
            HTuple end_val3 = hv_Number1 - 1;
            HTuple step_val3 = 1;

            hv_WindowHandle.DispObj(ho_SelectedRegions);

            for (hv_Index = 0; hv_Index.Continue(end_val3, step_val3); hv_Index = hv_Index.TupleAdd(step_val3))
            {
                disp_message(hv_WindowHandle, hv_Class.TupleSelect(hv_Index), "image", (hv_Row1.TupleSelect(
                    hv_Index)), hv_Column1.TupleSelect(hv_Index), "black", "true");
            }
            return;
        }
        #endregion

    }
    #endregion

    #region  建立字符的对比模板类
    /// <summary>
    /// 建立字符的对比模板类
    /// </summary>
    [Serializable]
    public class OcrTrained_Class
    {
        /// <summary>
        /// 是否启动训练
        /// </summary>
        public bool _trained = false;

        /// <summary>
        /// 字符的对比模板
        /// </summary>
        public string _ocrTrainingCharacteer = "";

        /// <summary>
        /// 条码训练后，对比的结果
        /// </summary>
        public bool _result = true;

        /// <summary>
        /// ocr整体结果
        /// </summary>
        public bool _allResult = true;

    }
    #endregion

    #region  接口
    /// <summary>
    /// 接口
    /// </summary>
    public interface IOCRShuJu : HalControl.ROI.IRoiIndex, MultTree.IToolDateFather
    {
        #region  属性

        #region  emphasize参数
        /// <summary>
        /// 
        /// </summary>
        HTuple MaskWidth1
        {
            get;
            set;
        }

        /// <summary>
        /// 
        /// </summary>
        HTuple MaskHeight1
        {
            get;
            set;
        }

        /// <summary>
        /// 
        /// </summary>
        HTuple Factor1
        {
            get;
            set;
        }
        #endregion

        #region  scale_image参数
        /// <summary>
        /// 
        /// </summary>
        HTuple Mult1
        {
            get;
            set;
        }

        /// <summary>
        /// 
        /// </summary>
        HTuple Add1
        {
            get;
            set;
        }
        #endregion

        #region  *threshold参数
        /// <summary>
        /// 
        /// </summary>
        HTuple MinGray1
        {
            get;
            set;
        }

        /// <summary>
        /// 
        /// </summary>
        HTuple MaxGray1
        {
            get;
            set;
        }
        #endregion

        #region   *select_shape参数
        /// <summary>
        /// 
        /// </summary>
        HTuple Features1
        {
            get;
            set;
        }
        /// <summary>
        /// 
        /// </summary>
        HTuple Operation1
        {
            get;
            set;
        }

        /// <summary>
        /// 
        /// </summary>
        HTuple Min1
        {
            get;
            set;
        }

        /// <summary>
        /// 
        /// </summary>
        HTuple Max1
        {
            get;
            set;
        }
        #endregion

        #region   ocr指针路径
        /// <summary>
        /// ocr指针路径 
        /// </summary>
        string Path1
        {
            get;
            set;
        }
        #endregion
            
        #region  要训练的字库名称
        /// <summary>
        ///  要训练的字库名称
        /// </summary>
        string Hv_FileName
        {
            get;
            set;
        }
        #endregion

        #region   分割到的region数
        /// <summary>
        /// 分割到的region数
        /// </summary>
        HTuple Hv_Number
        {
            get;
            set;
        }
        #endregion

        #region  分割到的region
        /// <summary>
        /// 分割到的region
        /// </summary>
        HObject Ho_SelectedRegions
        {
            get;
            set;
        }
        #endregion

        #region  读取ocr的到的分数
        /// <summary>
        /// 读取ocr的到的分数
        /// </summary>
        HTuple Hv_Confidence
        {
            get;
            set;
        }
        #endregion

        #region   ocr指针
        /// <summary>
        /// ocr指针
        /// </summary>
        HTuple Hv_OCRHandle
        {
            get;
            set;
        }
        #endregion

        #region    读取 到的类
        /// <summary>
        /// 读取 到的类
        /// </summary>
        HTuple Hv_Class1
        {
            get;
            set;
        }
        #endregion

        #region 添加训练ocr
        /// <summary>
        /// 要训练的字符类
        /// </summary>
        HTuple Hv_Class
        {
            get;
            set;
        }

        /// <summary>
        /// 要训练的文件路径
        /// </summary>
        HTuple Hv_TrainingFile
        {
            get;
            set;
        }

        /// <summary>
        ///要训练的迭代次数
        /// </summary>
        HTuple Hv_MaxIteration
        {
            get;
            set;
        }

        /// <summary>
        /// 要训练的权重
        /// </summary>
        HTuple Hv_WeightTolerance
        {
            get;
            set;
        }

        /// <summary>
        /// 要训练的误差
        /// </summary>
        HTuple Hv_ErrorTolerance
        {
            get;
            set;
        }
        #endregion

        #region  训练的输出数据
        /// <summary>
        /// 训练的输出数据
        /// </summary>
        HTuple Hv_Error
        {
            get;
            set;
        }

        /// <summary>
        /// 训练的输出数据
        /// </summary>
        HTuple Hv_ErrorLog
        {
            get;
            set;
        }

        /// <summary>
        /// 训练的输出数据
        /// </summary>
        HTuple Hv_Class2
        {
            get;
            set;
        }

        /// <summary>
        /// 训练的输出数据
        /// </summary>
        HTuple Hv_Confidence1
        {
            get;
            set;
        }
        #endregion

        #region   建立字符的对比模板类
        /// <summary>
        /// 建立字符的对比模板类
        /// </summary>
        OcrTrained_Class OcrTrainedClass
        {
            get
          ;
            set
           ;
        }
        #endregion

        #region   要读取ocr的个数
        /// <summary>
        /// 要读取ocr的个数
        /// </summary>
        uint YaoDuQuOcrDeGeShu
        {
            get;
            set;
        }
        #endregion

        #region 要读取ocr的region数据点的集合
        /// <summary>
        /// 要读取ocr的region数据点的集合
        /// </summary>
        List<IOutsideRectangle2ROI> List_IOutSide
        {
            get;
            set;
        }
        #endregion

        #region   创建一个OCR MLP分类器参数
        /// <summary>
        ///  创建一个OCR分类器参数
        /// </summary>
        HTuple Hv_WidthCharacter
        {
            get;
            set;
        }

        /// <summary>
        ///  创建一个OCR分类器参数
        /// </summary>
        HTuple Hv_HeightCharacter
        {
            get;
            set;
        }

        /// <summary>
        ///  创建一个OCR分类器参数
        /// </summary>
        HTuple Hv_Interpolation
        {
            get;
            set;
        }

        /// <summary>
        ///  创建一个OCR分类器参数
        /// </summary>
        HTuple Hv_Features
        {
            get;
            set;
        }

        /// <summary>
        ///  创建一个OCR分类器参数
        /// </summary>
        HTuple Hv_Characters
        {
            get;
            set;
        }

        /// <summary>
        /// 创建一个OCR分类器参数
        /// </summary>
        HTuple Hv_NumHidden
        {
            get;
            set;
        }

        /// <summary>
        /// 创建一个OCR分类器参数
        /// </summary>
        HTuple Hv_Preprocessing
        {
            get;
            set;
        }

        /// <summary>
        /// 创建一个OCR分类器参数
        /// </summary>
        HTuple Hv_NumComponents
        {
            get;
            set;
        }

        /// <summary>
        /// 创建一个OCR分类器参数
        /// </summary>
        HTuple Hv_RandSeed
        {
            get;
            set;
        }
        #endregion

        #endregion

        #region  init
        void init();
        #endregion

        #region  save
        void save();
        #endregion
    }
    #endregion

    #region  设置器
    /// <summary>
    /// 设置数据ocr数据接口
    /// </summary>
    public class Set_OCRShuJu
    {
     

        #region  Emphasize参数
        /// <summary>
        ///  设置Emphasize参数
        /// </summary>
        /// <param name="IOCR"></param>
        /// <param name="MaskWidth"></param>
        /// <param name="MaskHeight"></param>
        /// <param name="Factor"></param>
        /// <returns></returns>
        public bool Set_OCREmphasize(IOCRShuJu IOCR, string MaskWidth, string MaskHeight, string Factor)
        {
            bool ok = false;
            if (MaskWidth != null)
            {
                double num = Convert.ToDouble(MaskWidth);
                IOCR.MaskWidth1 = num;
            }

            if (MaskHeight != null)
            {
                double num = Convert.ToDouble(MaskHeight);
                IOCR.MaskHeight1 = num;
            }

            if (Factor != null)
            {
                double num = Convert.ToDouble(Factor);
                IOCR.Factor1 = num;
            }

            ok = true;
            return ok;
        }

        #endregion

        #region  scale_image参数
        /// <summary>
        ///设置 scale_image参数
        /// </summary>
        /// <param name="IOCR"></param>
        /// <param name="Mult"></param>
        /// <param name="Add"></param>
        /// <returns></returns>
        public bool Set_OCRScaleImage(IOCRShuJu IOCR, string Mult, string Add)
        {
            bool ok = false;
            if (Mult != null)
            {
                double num = Convert.ToDouble(Mult);
                IOCR.Mult1 = num;
            }

            if (Add != null)
            {
                double num = Convert.ToDouble(Add);
                IOCR.Add1 = num;
            }


            ok = true;
            return ok;
        }

        #endregion

        #region  threshold
        /// <summary>
        ///  threshold
        /// </summary>
        /// <param name="IOCR"></param>
        /// <param name="MinGray"></param>
        /// <param name="MaxGray"></param>
        /// <returns></returns>
        public bool Set_OCRThreshold(IOCRShuJu IOCR, string MinGray, string MaxGray)
        {
            bool ok = false;

            if (MinGray != null)
            {
                double num = Convert.ToDouble(MinGray);
                IOCR.MinGray1 = num;
            }

            if (MaxGray != null)
            {
                double num = Convert.ToDouble(MaxGray);
                IOCR.MaxGray1 = num;
            }

            ok = true;
            return ok;
        }
        #endregion

        #region   *select_shape参数
        /// <summary>
        ///  *select_shape参数
        /// </summary>
        /// <param name="IOCR"></param>
        /// <param name="Features"></param>
        /// <param name="Operation"></param>
        /// <param name="Min"></param>
        /// <param name="Max"></param>
        /// <returns></returns>
        public bool Set_OCRSelectShape(IOCRShuJu IOCR, string Features, string Operation, string Min, string Max)
        {
            bool ok = false;
            if (Features != null)
            {
                IOCR.Features1 = Features;
            }

            if (Operation != null)
            {
                IOCR.Operation1 = Operation;
            }

            if (Min != null)
            {
                double num = Convert.ToDouble(Min);
                IOCR.Min1 = num;
            }

            if (Max != null)
            {
                double num = Convert.ToDouble(Max);
                IOCR.Max1 = num;
            }

            ok = true;
            return ok;
        }
        #endregion

        #region   设置OCR指针的路径
        /// <summary>
        ///  设置OCR指针的路径
        /// </summary>
        /// <param name="IOCR"></param>
        /// <param name="path"></param>
        /// <returns></returns>
        public bool Set_OCRZhiZhenLuJing(IOCRShuJu IOCR, string path)
        {
            bool ok = false;
            if (path != null)
            {
                IOCR.Path1 = path;
            }
            ok = true;
            return ok;
        }
        #endregion

        #region  更换字库
        /// <summary>
        /// 更换字库,及更换指针handleOCR
        /// </summary>
        /// <param name="IOCR">更换字库</param>
        /// <param name="path">传入特殊字符路径</param>
        /// <param name="filename">传入默认字符库的名称</param>
        /// <returns></returns>
        public bool Set_ReplaceOCRWork(IOCRShuJu IOCR, string path, string filename)
        {
            bool ok = false;
            if (path != null)
            {
                IOCR.Path1 = path;
                HTuple OCRHandle;
                HOperatorSet.ClearOcrClassMlp(IOCR.Hv_OCRHandle);
                HOperatorSet.ReadOcrClassMlp(path, out OCRHandle);
                IOCR.Hv_OCRHandle = OCRHandle;
                IOCR.Hv_FileName = null;
            }
            else
            {
                if (filename != null)
                {
                    IOCR.Hv_FileName = filename;
                    HTuple OCRHandle;
                    HOperatorSet.ClearOcrClassMlp(IOCR.Hv_OCRHandle);
                    HOperatorSet.ReadOcrClassMlp(IOCR.Path1, out OCRHandle);
                    IOCR.Hv_OCRHandle = OCRHandle;
                }
            }
            ok = true;
            return ok;
        }
        #endregion

        #region 清空ocr指针
        /// <summary>
        /// 清空ocr指针
        /// </summary>
        /// <param name="IOCR"></param>
        /// <returns></returns>
        public bool Set_OCRClear(IOCRShuJu IOCR)
        {
            bool ok = false;
            HOperatorSet.ClearOcrClassMlp(IOCR.Hv_OCRHandle);
            ok = true;
            return ok;
        }
        #endregion

        #region  读取ocr指针
        /// <summary>
        /// 读取ocr指针
        /// </summary>
        /// <param name="IOCR"></param>
        /// <param name="path"></param>
        /// <returns></returns>
        public bool Set_OCRZhiZhenDuQu(IOCRShuJu IOCR, string path)
        {
            bool ok = false;
            HTuple Hv_OCRHandle;
            HOperatorSet.ReadOcrClassMlp(path, out Hv_OCRHandle);
            IOCR.Hv_OCRHandle = Hv_OCRHandle;
            ok = true;
            return ok;
        }
        #endregion

        #region  显示参数
        /// <summary>
        /// 显示输出参数，初始化halcon窗口region
        /// </summary>
        /// <param name="IOCR_"></param>
        /// <param name="control"></param>
        /// <param name="halconWinControl_"></param>
        public void Set_showParameterHalconWinControl(IOCRShuJu IOCR_, Control.ControlCollection control, HalControl.HalconWinControl_ROI halconWinControl_)
        {
            if (halconWinControl_ != null)
            {

                //halconWinControl_.DrawRectangle2(IOCR_.IOutSide.Mid_col_x, IOCR_.IOutSide.Mid_row_y, IOCR_.IOutSide.Phi, IOCR_.IOutSide.Len1, IOCR_.IOutSide.Len2, IOCR_.IOutSide);
                // halconWinControl_.DrawRectangle1(IOCR_.IOutSide.Col_x1, IOCR_.IOutSide.Row_y1, IOCR_.IOutSide.Col_x2, IOCR_.IOutSide.Row_y2, IOCR_.IOutSide);

                foreach (IOutsideRectangle2ROI io_ in IOCR_.List_IOutSide)
                {
                    halconWinControl_.DrawRectangle2(io_.Mid_col_x, io_.Mid_row_y, io_.Phi, io_.Len1, io_.Len2, io_);
                }
                halconWinControl_.roiYinSuoWaiBuJieKou(IOCR_.IXuanZhongDeRoi);
            }
            Set_ShowParameter(IOCR_, control);
        }

        /// <summary>
        /// 显示参数
        /// </summary>
        /// <param name="IOCR"></param>
        /// <param name="control"></param>
        /// <returns></returns>
        public bool Set_ShowParameter(IOCRShuJu IOCR, Control.ControlCollection control)
        {
            bool ok = false;
            foreach (Control con in control)
            {
                string name = con.Name;
                if ((con is ComboBox) || (con is TextBox) || (con is RichTextBox) || (con is CheckBox) || (con is NumericUpDown))
                {
                    switch (name)
                    {

                        #region  无用代码
                        //#region  emphasize
                        //case "MaskWidth":
                        //    con.Text = IOCR.MaskWidth1.ToString().Replace("\"", "");
                        //    break;

                        //case "MaskHeight":
                        //    con.Text = IOCR.MaskHeight1.ToString().Replace("\"", "");
                        //    break;

                        //case "Factor":
                        //    con.Text = IOCR.Factor1.ToString().Replace("\"", "");
                        //    break;
                        //#endregion

                        //#region  scale_image参数
                        //case "Mult":
                        //    con.Text = IOCR.Mult1.ToString().Replace("\"", "");
                        //    break;

                        //case "Add":
                        //    con.Text = IOCR.Add1.ToString().Replace("\"", "");
                        //    break;
                        //#endregion
                        #endregion

                        #region threshold参数
                        case "MinGray":
                            con.Text = IOCR.MinGray1.ToString().Replace("\"", "");

                            break;

                        case "MaxGray":
                            con.Text = IOCR.MaxGray1.ToString().Replace("\"", "");
                            break;
                        #endregion

                        #region select_shape参数
                        case "Features":
                            con.Text = IOCR.Features1.ToString().Replace("\"", "");
                            break;

                        case "Operation":
                            con.Text = IOCR.Operation1.ToString().Replace("\"", "");
                            break;

                        case "Min":
                            con.Text = IOCR.Min1.ToString().Replace("\"", "");
                            break;

                        case "Max":
                            con.Text = IOCR.Max1.ToString().Replace("\"", "");
                            break;
                        #endregion

                        #region  无用代码
                        //#region 创建ocr
                        //case "hv_WidthCharacter":
                        //    con.Text = IOCR.Hv_WidthCharacter.ToString().Replace("\"", "");
                        //    break;

                        //case "hv_HeightCharacter":
                        //    con.Text = IOCR.Hv_HeightCharacter.ToString().Replace("\"", "");
                        //    break;

                        //case "hv_Interpolation":
                        //    con.Text = IOCR.Hv_Interpolation.ToString().Replace("\"", "");
                        //    break;

                        //case "hv_Features":
                        //    con.Text = IOCR.Hv_Features.ToString().Replace("\"", "");
                        //    break;

                        //case "hv_Characters":
                        //    con.Text = IOCR.Hv_Characters.ToString().Replace("\"", "");
                        //    break;

                        //case "hv_NumHidden":
                        //    con.Text = IOCR.Hv_NumHidden.ToString().Replace("\"", "");
                        //    break;

                        //case "hv_Preprocessing":
                        //    con.Text = IOCR.Hv_Preprocessing.ToString().Replace("\"", "");
                        //    break;

                        //case "hv_NumComponents":
                        //    con.Text = IOCR.Hv_NumComponents.ToString().Replace("\"", "");
                        //    break;

                        //case "hv_RandSeed":
                        //    con.Text = IOCR.Hv_RandSeed.ToString().Replace("\"", "");
                        //    break;
                        //#endregion

                        //#region  添加训练的ocr
                        //case "hv_Class":
                        // //   con.Text = IOCR.Hv_Class.ToString().Replace("\"", "");
                        //    break;

                        //case "hv_TrainningFile":
                        //    con.Text = IOCR.Hv_TrainningFile.ToString().Replace("\"", "");
                        //    break;

                        //case "hv_MaxIteration":
                        //    con.Text = IOCR.Hv_MaxIteration.ToString().Replace("\"", "");
                        //    break;

                        //case "hv_WeightTolerance":
                        //    con.Text = IOCR.Hv_WeightTolerance.ToString().Replace("\"", "");
                        //    break;

                        //case "hv_ErrorTolerance":
                        //    con.Text = IOCR.Hv_ErrorTolerance.ToString().Replace("\"", "");
                        //    break;

                        //#endregion
                        #endregion

                        #region  hv_fileName
                        case "Hv_FileName":
                            List<string> str_name;
                            find_all_omc(out str_name);
                            ComboBox com = con as ComboBox;
                            if (com != null)
                            {
                                foreach (string filename in str_name)
                                {
                                    com.Items.Add(filename.Replace(".omc", ""));
                                }
                            }
                            con.Text = IOCR.Hv_FileName;
                            break;
                        #endregion

                        #region  path1
                        case "Path1":
                            con.Text = IOCR.Path1;
                            break;
                        #endregion

                        #region   字库名称
                        case "txt_Hv_FileName":
                            con.Text = IOCR.Hv_FileName;
                            break;
                        #endregion

                        #region   训练
                        case "_trained":
                            ((CheckBox)con).Checked = IOCR.OcrTrainedClass._trained;
                            break;
                        #endregion

                        #region   训练的字符
                        case "_ocrTrainingCharacteer":
                            con.Text = IOCR.OcrTrainedClass._ocrTrainingCharacteer;
                            break;
                        #endregion

                        #region  ocr的region数据
                        case "nUD_yao_du_qu_ocr_de_ge_shu":
                            NumericUpDown nu = con as NumericUpDown;
                            nu.Value = (decimal)IOCR.List_IOutSide.Count;
                            break;
                        #endregion

                        #region 默认处理
                        default:

                            break;
                        #endregion
                    }
                }

                if (con.Controls.Count > 0)
                {
                    Set_ShowParameter(IOCR, con.Controls);
                }
            }
            ok = true;
            return ok;
        }
        #endregion

        #region  查找默认路径下的字库文件
        /// <summary>
        /// 查找默认路径下的字库文件
        /// </summary>
        /// <param name="str_name">集合</param>
        public void find_all_omc(out List<string> str_name)
        {
            str_name = new List<string>();

            #region 确保目录存在
            DirectoryInfo dirInfo = new DirectoryInfo(Path.GetDirectoryName(AppDomain.CurrentDomain.BaseDirectory + @"Ocr\"));
            var dir = dirInfo;
            Stack<DirectoryInfo> needCreatedDirs = new Stack<DirectoryInfo>();
            while (!dir.Exists)
            {
                needCreatedDirs.Push(dir);
                dir = dir.Parent;
            }
            while (needCreatedDirs.Count > 0)
            {
                needCreatedDirs.Pop().Create();
            }
            #endregion

            foreach (FileInfo file in dirInfo.GetFiles("*.omc"))
            {
                str_name.Add(file.Name);
            }

        }
        #endregion

        #region  显示OCR分割效果
        /// <summary>
        /// 显示OCR分割效果
        /// </summary>
        /// <param name="IOCR"></param>
        /// <param name="ho_Image"></param>
        /// <param name="hwin"></param>
        /// <returns></returns>
        public bool Set_OCRCutOffRegion(IOCRShuJu IOCR, HObject ho_Image, HWindow hwin)
        {
            bool ok = false;
            HObject ho_ImageReduced;
            HObject ho_SelectedRegions;
            HObject ho_ROI_0;
            HTuple hv_Number, hv_modMat2D;

            HOperatorSet.GenEmptyObj(out ho_ImageReduced);
            HOperatorSet.GenEmptyObj(out ho_SelectedRegions);
            HOperatorSet.GenEmptyObj(out ho_ROI_0);

            foreach (IOutsideRectangle2ROI io_ in IOCR.List_IOutSide)
            {
                HOperatorSet.GenRectangle2(out ho_ROI_0, io_.Mid_row_y, io_.Mid_col_x, io_.Phi, io_.Len1, io_.Len2);

                if (IOCR.IrectShuJuPianYi != null)
                {
                    HOperatorSet.VectorAngleToRigid(IOCR.GenSuiDian_Y_Row, IOCR.GeuSuiDian_X_Col, IOCR.GenSuiDian_A, IOCR.IrectShuJuPianYi.Row, IOCR.IrectShuJuPianYi.Column, IOCR.IrectShuJuPianYi.Angle, out hv_modMat2D);
                    HOperatorSet.AffineTransRegion(ho_ROI_0, out ho_ROI_0, hv_modMat2D, "nearest_neighbor");
                }

                HOperatorSet.ReduceDomain(ho_Image, ho_ROI_0, out ho_ImageReduced);

                extract(ho_ImageReduced, out ho_SelectedRegions, IOCR.MaskWidth1, IOCR.MaskHeight1, IOCR.Factor1, IOCR.Mult1, IOCR.Add1
                 , IOCR.MinGray1, IOCR.MaxGray1, IOCR.Features1, IOCR.Operation1, IOCR.Min1, IOCR.Max1, out hv_Number);

                HOperatorSet.GenContourRegionXld(ho_ROI_0, out ho_ROI_0, "border");

                hwin.DispObj(ho_SelectedRegions);


            }

            /**********清空缓存*************/
            ho_ImageReduced.Dispose();
            ho_SelectedRegions.Dispose();
            ho_ROI_0.Dispose();

            #region  无用代码
            //if (IOCR.Ihv_HomMat2D != null)
            //{
            //    //HOperatorSet.GenRectangle1(out ho_ROI_0, IOCR.IOutSide.Row_y1, IOCR.IOutSide.Col_x1, IOCR.IOutSide.Row_y2, IOCR.IOutSide.Col_x2);
            //    HOperatorSet.GenRectangle2(out ho_ROI_0, IOCR.IOutSide.Mid_row_y, IOCR.IOutSide.Mid_col_x, IOCR.IOutSide.Phi, IOCR.IOutSide.Len1, IOCR.IOutSide.Len2);

            //    HOperatorSet.AffineTransRegion(ho_ROI_0, out ho_ROI_0, IOCR.Ihv_HomMat2D.Hv_HomMat2D, "nearest_neighbor");
            //    HOperatorSet.ReduceDomain(ho_Image, ho_ROI_0, out ho_ImageReduced);
            //    ho_ROI_0.Dispose();
            //}
            //else
            //{
            //    //HOperatorSet.GenRectangle1(out ho_ROI_0, IOCR.IOutSide.Row_y1, IOCR.IOutSide.Col_x1, IOCR.IOutSide.Row_y2, IOCR.IOutSide.Col_x2);
            //    HOperatorSet.GenRectangle2(out ho_ROI_0, IOCR.IOutSide.Mid_row_y, IOCR.IOutSide.Mid_col_x, IOCR.IOutSide.Phi, IOCR.IOutSide.Len1, IOCR.IOutSide.Len2);

            //    HOperatorSet.ReduceDomain(ho_Image, ho_ROI_0, out ho_ImageReduced);
            //}           
            //base.extract(ho_ImageReduced, out ho_SelectedRegions, IOCR.MaskWidth1, IOCR.MaskHeight1, IOCR.Factor1, IOCR.Mult1, IOCR.Add1
            //     , IOCR.MinGray1, IOCR.MaxGray1, IOCR.Features1, IOCR.Operation1, IOCR.Min1, IOCR.Max1, out hv_Number);

            ////IOCR.Ho_SelectedRegions = ho_SelectedRegions;
            ////string num = hv_Number.ToString();
            //// IOCR.Hv_Number = hv_Number;
            //hwin.DispObj(ho_SelectedRegions);
            #endregion

            ok = true;
            return ok;
        }

        //#region  提取ocr读取的region
        ////void extract(HObject ho_ImageReduced, out HObject ho_SelectedRegions, HTuple hv_MaskWidth,
        ////HTuple hv_MaskHeight, HTuple hv_Factor, HTuple hv_Mult, HTuple hv_Add, HTuple hv_MinGray,
        ////HTuple hv_MaxGray, HTuple hv_Features, HTuple hv_Operation, HTuple hv_Min, HTuple hv_Max,
        ////out HTuple hv_Number)
        ////{
        ////    // Local iconic variables 

        ////    HObject ho_ImageEmphasize, ho_ImageScaled;
        ////    HObject ho_Region, ho_ConnectedRegions;
        ////    // Initialize local and output iconic variables 
        ////    HOperatorSet.GenEmptyObj(out ho_SelectedRegions);
        ////    HOperatorSet.GenEmptyObj(out ho_ImageEmphasize);
        ////    HOperatorSet.GenEmptyObj(out ho_ImageScaled);
        ////    HOperatorSet.GenEmptyObj(out ho_Region);
        ////    HOperatorSet.GenEmptyObj(out ho_ConnectedRegions);
        ////    try
        ////    {

        ////        ho_ImageEmphasize.Dispose();
        ////        HOperatorSet.Emphasize(ho_ImageReduced, out ho_ImageEmphasize, hv_MaskWidth,
        ////            hv_MaskHeight, hv_Factor);
        ////        //invert_image (ImageEmphasize, ImageInvert)
        ////        ho_ImageScaled.Dispose();
        ////        HOperatorSet.ScaleImage(ho_ImageEmphasize, out ho_ImageScaled, hv_Mult, hv_Add);
        ////        ho_Region.Dispose();
        ////        HOperatorSet.Threshold(ho_ImageScaled, out ho_Region, hv_MinGray, hv_MaxGray);
        ////        ho_ConnectedRegions.Dispose();
        ////        HOperatorSet.Connection(ho_Region, out ho_ConnectedRegions);
        ////        ho_SelectedRegions.Dispose();
        ////        HOperatorSet.SelectShape(ho_ConnectedRegions, out ho_SelectedRegions, hv_Features,
        ////            hv_Operation, hv_Min, hv_Max);
        ////        HOperatorSet.CountObj(ho_SelectedRegions, out hv_Number);
        ////        ho_ImageEmphasize.Dispose();
        ////        ho_ImageScaled.Dispose();
        ////        ho_Region.Dispose();
        ////        ho_ConnectedRegions.Dispose();

        ////        return;
        ////    }
        ////    catch (HalconException HDevExpDefaultException)
        ////    {
        ////        ho_ImageEmphasize.Dispose();
        ////        ho_ImageScaled.Dispose();
        ////        ho_Region.Dispose();
        ////        ho_ConnectedRegions.Dispose();

        ////        throw HDevExpDefaultException;
        ////    }
        ////}
        //#endregion

        #endregion

        //#region  查看emphasize
        /////// <summary>
        /////// 查看emphasize效果
        /////// </summary>
        ////public void Set_CheckEmphasize(IOCRShuJu IOCR, HObject ho_Image, HWindow hwin)
        ////{

        ////    HObject ho_ImageReduced;
        ////    //  HObject ho_SelectedRegions;
        ////    HObject ho_ROI_0;
        ////    //  HTuple hv_Number;

        ////    HOperatorSet.GenEmptyObj(out ho_ImageReduced);
        ////    //   HOperatorSet.GenEmptyObj(out ho_SelectedRegions);
        ////    HOperatorSet.GenEmptyObj(out ho_ROI_0);

        ////    if (IOCR.Ihv_HomMat2D != null)
        ////    {
        ////        //HOperatorSet.GenRectangle1(out ho_ROI_0, IOCR.IOutSide.Row_y1, IOCR.IOutSide.Col_x1, IOCR.IOutSide.Row_y2, IOCR.IOutSide.Col_x2);
        ////        HOperatorSet.GenRectangle2(out ho_ROI_0, IOCR.IOutSide.Mid_row_y, IOCR.IOutSide.Mid_col_x, IOCR.IOutSide.Phi, IOCR.IOutSide.Len1, IOCR.IOutSide.Len2);

        ////        HOperatorSet.AffineTransRegion(ho_ROI_0, out ho_ROI_0, IOCR.Ihv_HomMat2D.Hv_HomMat2D, "nearest_neighbor");
        ////        HOperatorSet.ReduceDomain(ho_Image, ho_ROI_0, out ho_ImageReduced);
        ////        ho_ROI_0.Dispose();
        ////    }
        ////    else
        ////    {
        ////        //HOperatorSet.GenRectangle1(out ho_ROI_0, IOCR.IOutSide.Row_y1, IOCR.IOutSide.Col_x1, IOCR.IOutSide.Row_y2, IOCR.IOutSide.Col_x2);

        ////        HOperatorSet.GenRectangle2(out ho_ROI_0, IOCR.IOutSide.Mid_row_y, IOCR.IOutSide.Mid_col_x, IOCR.IOutSide.Phi, IOCR.IOutSide.Len1, IOCR.IOutSide.Len2);
        ////        HOperatorSet.ReduceDomain(ho_Image, ho_ROI_0, out ho_ImageReduced);
        ////    }

        ////    HObject ho_ImageEmphasize;
        ////    HOperatorSet.GenEmptyObj(out ho_ImageEmphasize);
        ////    ho_ImageEmphasize.Dispose();
        ////    HOperatorSet.Emphasize(ho_ImageReduced, out ho_ImageEmphasize, IOCR.MaskWidth1,
        ////        IOCR.MaskHeight1, IOCR.Factor1);

        ////    hwin.DispObj(ho_ImageEmphasize);

        ////}
        //#endregion

        //#region  查看scale
        /////// <summary>
        /////// 查看scale
        /////// </summary>
        /////// <param name="IOCR"></param>
        /////// <param name="ho_Image"></param>
        /////// <param name="hwin"></param>
        ////public void Set_CheckScale(IOCRShuJu IOCR, HObject ho_Image, HWindow hwin)
        ////{
        ////    HObject ho_ImageReduced, ho_ImageScaled; ;

        ////    HObject ho_ROI_0;
        ////    //HTuple hv_Number;

        ////    HOperatorSet.GenEmptyObj(out ho_ImageReduced);
        ////    HOperatorSet.GenEmptyObj(out ho_ImageScaled);
        ////    HOperatorSet.GenEmptyObj(out ho_ROI_0);

        ////    if (IOCR.Ihv_HomMat2D != null)
        ////    {
        ////        //HOperatorSet.GenRectangle1(out ho_ROI_0, IOCR.IOutSide.Row_y1, IOCR.IOutSide.Col_x1, IOCR.IOutSide.Row_y2, IOCR.IOutSide.Col_x2);

        ////        HOperatorSet.GenRectangle2(out ho_ROI_0, IOCR.IOutSide.Mid_row_y, IOCR.IOutSide.Mid_col_x, IOCR.IOutSide.Phi, IOCR.IOutSide.Len1, IOCR.IOutSide.Len2);
        ////        HOperatorSet.AffineTransRegion(ho_ROI_0, out ho_ROI_0, IOCR.Ihv_HomMat2D.Hv_HomMat2D, "nearest_neighbor");
        ////        HOperatorSet.ReduceDomain(ho_Image, ho_ROI_0, out ho_ImageReduced);
        ////        ho_ROI_0.Dispose();
        ////    }
        ////    else
        ////    {
        ////        //HOperatorSet.GenRectangle1(out ho_ROI_0, IOCR.IOutSide.Row_y1, IOCR.IOutSide.Col_x1, IOCR.IOutSide.Row_y2, IOCR.IOutSide.Col_x2);
        ////        HOperatorSet.GenRectangle2(out ho_ROI_0, IOCR.IOutSide.Mid_row_y, IOCR.IOutSide.Mid_col_x, IOCR.IOutSide.Phi, IOCR.IOutSide.Len1, IOCR.IOutSide.Len2);
        ////        HOperatorSet.ReduceDomain(ho_Image, ho_ROI_0, out ho_ImageReduced);
        ////    }

        ////    HObject ho_ImageEmphasize;
        ////    HOperatorSet.GenEmptyObj(out ho_ImageEmphasize);
        ////    ho_ImageEmphasize.Dispose();
        ////    HOperatorSet.Emphasize(ho_ImageReduced, out ho_ImageEmphasize, IOCR.MaskWidth1,
        ////        IOCR.MaskHeight1, IOCR.Factor1);

        ////    ho_ImageScaled.Dispose();
        ////    HOperatorSet.ScaleImage(ho_ImageEmphasize, out ho_ImageScaled, IOCR.Mult1, IOCR.Add1);

        ////    hwin.DispObj(ho_ImageScaled);

        ////}
        //#endregion

        //#region   晒算region
        /////// <summary>
        ///////  晒算region
        /////// </summary>
        /////// <param name="IOCR"></param>
        /////// <param name="ho_Image"></param>
        /////// <param name="hwin"></param>
        /////// <param name="ho_ObjectSelected"></param>
        /////// <param name="hv_Index2"></param>
        /////// <returns></returns>
        ////public bool SelectOCRRegion(IOCRShuJu IOCR, HObject ho_Image, HWindow hwin, out HObject ho_ObjectSelected,
        ////    HTuple hv_Index2)
        ////{
        ////    bool ok = false;
        ////    HOperatorSet.GenEmptyObj(out ho_ObjectSelected);
        ////    hwin.DispObj(ho_Image);
        ////    ho_ObjectSelected.Dispose();
        ////    base.SelectOCRRegion(IOCR.Ho_SelectedRegions, out ho_ObjectSelected, hv_Index2);
        ////    hwin.DispObj(ho_ObjectSelected);

        ////    ok = true;
        ////    return ok;
        ////}
        //#endregion

        #region   训练OCR
        /// <summary>
        ///  训练OCR
        /// </summary>
        /// <param name="IOCR"></param>
        /// <param name="ho_ObjectSelected"></param>
        /// <param name="ho_Image"></param>
        /// <param name="hv_WindowHandle"></param>
        /// <returns></returns>
        public bool TrainOCR(IOCRShuJu IOCR, HObject ho_ObjectSelected, HObject ho_Image, HWindow hv_WindowHandle)
        {
            bool ok = false;
            HTuple Hv_Error, Hv_ErrorLog, Hv_Class2, Hv_Confidence1;
            TrainOCRAndCreateTrainingFile(ho_ObjectSelected, ho_Image,
          IOCR.Hv_Class, IOCR.Hv_TrainingFile, IOCR.Hv_OCRHandle, IOCR.Hv_MaxIteration,
           IOCR.Hv_WeightTolerance, IOCR.Hv_ErrorTolerance, hv_WindowHandle,
          out Hv_Error, out Hv_ErrorLog, out Hv_Class2, out  Hv_Confidence1);

            IOCR.Hv_Class2 = Hv_Class2;
            IOCR.Hv_Error = Hv_Error;
            IOCR.Hv_ErrorLog = Hv_ErrorLog;
            IOCR.Hv_Confidence1 = Hv_Confidence1;

            ok = true;
            return ok;

        }
        #endregion

        #region  提取ocr读取的region
        /// <summary>
        /// 提取ocr读取的region
        /// </summary>
        /// <param name="IOCR"></param>
        /// <returns></returns>
        public bool extract_current_train_ocr_region(IOCRShuJu IOCR, HObject Ho_Image, HWindow Hwin)
        {
            Hwin.ClearWindow();
            Hwin.DispObj(Ho_Image);
            bool ok = false;
            HObject ho_ImageReduced;
            HObject ho_SelectedRegions;
            HObject ho_ROI_0;
            HTuple hv_Number = 0;

            HOperatorSet.GenEmptyObj(out ho_ImageReduced);
            HOperatorSet.GenEmptyObj(out ho_SelectedRegions);
            HOperatorSet.GenEmptyObj(out ho_ROI_0);

            #region  无用代码
            //if (IOCR.Hv_HomMat2D != null)
            //{
            //    HOperatorSet.GenRectangle1(out ho_ROI_0, IOCR.Hv_Row1, IOCR.Hv_Column1, IOCR.Hv_Row2, IOCR.Hv_Column2);
            //    HOperatorSet.AffineTransRegion(ho_ROI_0, out ho_ROI_0, IOCR.Hv_HomMat2D, "nearest_neighbor");
            //    HOperatorSet.ReduceDomain(Ho_Image, ho_ROI_0, out ho_ImageReduced);
            //    ho_ROI_0.Dispose();
            //}
            //else
            //{

            //}

            #endregion

            IOutsideRectangle2ROI io_ = IOCR.List_IOutSide[IOCR.IXuanZhongDeRoi.IXuanZhongRoiDeIndex];

            HOperatorSet.GenRectangle2(out ho_ROI_0, io_.Mid_row_y, io_.Mid_col_x, io_.Phi, io_.Len1, io_.Len2);
            HOperatorSet.ReduceDomain(Ho_Image, ho_ROI_0, out ho_ImageReduced);

            extract(ho_ImageReduced, out ho_SelectedRegions, IOCR.MaskWidth1, IOCR.MaskHeight1, IOCR.Factor1, IOCR.Mult1, IOCR.Add1
             , IOCR.MinGray1, IOCR.MaxGray1, IOCR.Features1, IOCR.Operation1, IOCR.Min1, IOCR.Max1, out hv_Number);

            if (hv_Number > 1)
            {
                HOperatorSet.Union1(ho_SelectedRegions, out ho_SelectedRegions);
            }

            IOCR.Ho_SelectedRegions.Dispose();
            IOCR.Ho_SelectedRegions = ho_SelectedRegions;
            IOCR.Hv_Number = hv_Number;
            Hwin.DispObj(ho_SelectedRegions);

            if (hv_Number > 0)
            {
                ok = true;
            }

            return ok;
        }

        #region  无用代码
        //void extract(HObject ho_ImageReduced, out HObject ho_SelectedRegions, HTuple hv_MaskWidth,
        //HTuple hv_MaskHeight, HTuple hv_Factor, HTuple hv_Mult, HTuple hv_Add, HTuple hv_MinGray,
        //HTuple hv_MaxGray, HTuple hv_Features, HTuple hv_Operation, HTuple hv_Min, HTuple hv_Max,
        //out HTuple hv_Number)
        //{
        //    // Local iconic variables 

        //    HObject ho_ImageEmphasize, ho_ImageScaled;
        //    HObject ho_Region, ho_ConnectedRegions;
        //    // Initialize local and output iconic variables 
        //    HOperatorSet.GenEmptyObj(out ho_SelectedRegions);
        //    HOperatorSet.GenEmptyObj(out ho_ImageEmphasize);
        //    HOperatorSet.GenEmptyObj(out ho_ImageScaled);
        //    HOperatorSet.GenEmptyObj(out ho_Region);
        //    HOperatorSet.GenEmptyObj(out ho_ConnectedRegions);
        //    try
        //    {
        //        ho_ImageEmphasize.Dispose();
        //        HOperatorSet.Emphasize(ho_ImageReduced, out ho_ImageEmphasize, hv_MaskWidth,
        //            hv_MaskHeight, hv_Factor);
        //        //invert_image (ImageEmphasize, ImageInvert)
        //        ho_ImageScaled.Dispose();
        //        HOperatorSet.ScaleImage(ho_ImageEmphasize, out ho_ImageScaled, hv_Mult, hv_Add);
        //        ho_Region.Dispose();
        //        HOperatorSet.Threshold(ho_ImageScaled, out ho_Region, hv_MinGray, hv_MaxGray);
        //        ho_ConnectedRegions.Dispose();
        //        HOperatorSet.Connection(ho_Region, out ho_ConnectedRegions);
        //        ho_SelectedRegions.Dispose();
        //        HOperatorSet.SelectShape(ho_ConnectedRegions, out ho_SelectedRegions, hv_Features,
        //            hv_Operation, hv_Min, hv_Max);
        //        HOperatorSet.CountObj(ho_SelectedRegions, out hv_Number);
        //        ho_ImageEmphasize.Dispose();
        //        ho_ImageScaled.Dispose();
        //        ho_Region.Dispose();
        //        ho_ConnectedRegions.Dispose();

        //        return;
        //    }
        //    catch (HalconException HDevExpDefaultException)
        //    {
        //        ho_ImageEmphasize.Dispose();
        //        ho_ImageScaled.Dispose();
        //        ho_Region.Dispose();
        //        ho_ConnectedRegions.Dispose();

        //        throw HDevExpDefaultException;
        //    }
        //}
        #endregion
        #endregion

        #region 提取ocr的region
        /// <summary>
        /// 提取ocr的region
        /// </summary>
        /// <param name="ho_ImageReduced"></param>
        /// <param name="ho_SelectedRegions"></param>
        /// <param name="hv_MaskWidth"></param>
        /// <param name="hv_MaskHeight"></param>
        /// <param name="hv_Factor"></param>
        /// <param name="hv_Mult"></param>
        /// <param name="hv_Add"></param>
        /// <param name="hv_MinGray"></param>
        /// <param name="hv_MaxGray"></param>
        /// <param name="hv_Features"></param>
        /// <param name="hv_Operation"></param>
        /// <param name="hv_Min"></param>
        /// <param name="hv_Max"></param>
        /// <param name="hv_Number"></param>
        void extract(HObject ho_ImageReduced, out HObject ho_SelectedRegions, HTuple hv_MaskWidth,
          HTuple hv_MaskHeight, HTuple hv_Factor, HTuple hv_Mult, HTuple hv_Add, HTuple hv_MinGray,
          HTuple hv_MaxGray, HTuple hv_Features, HTuple hv_Operation, HTuple hv_Min, HTuple hv_Max,
          out HTuple hv_Number)
        {
            // Local iconic variables 
            HTuple area, col_x, row_y;

            HObject ho_ImageEmphasize, ho_ImageScaled;
            HObject ho_Region, ho_ConnectedRegions;
            // Initialize local and output iconic variables 
            HOperatorSet.GenEmptyObj(out ho_SelectedRegions);
            HOperatorSet.GenEmptyObj(out ho_ImageEmphasize);
            HOperatorSet.GenEmptyObj(out ho_ImageScaled);
            HOperatorSet.GenEmptyObj(out ho_Region);
            HOperatorSet.GenEmptyObj(out ho_ConnectedRegions);
            try
            {
                ho_ImageEmphasize.Dispose();
                HOperatorSet.Emphasize(ho_ImageReduced, out ho_ImageEmphasize, hv_MaskWidth,
                    hv_MaskHeight, hv_Factor);
                //invert_image (ImageEmphasize, ImageInvert)
                ho_ImageScaled.Dispose();
                HOperatorSet.ScaleImage(ho_ImageEmphasize, out ho_ImageScaled, hv_Mult, hv_Add);
                ho_Region.Dispose();
                HOperatorSet.Threshold(ho_ImageScaled, out ho_Region, hv_MinGray, hv_MaxGray);
                ho_ConnectedRegions.Dispose();
                HOperatorSet.Connection(ho_Region, out ho_ConnectedRegions);
                ho_SelectedRegions.Dispose();
                HOperatorSet.SelectShape(ho_ConnectedRegions, out ho_SelectedRegions, hv_Features,
                    hv_Operation, hv_Min, hv_Max);
                //HOperatorSet.CountObj(ho_SelectedRegions, out hv_Number);
                HOperatorSet.AreaCenter(ho_ConnectedRegions, out area, out row_y, out col_x);


                if (area.Length > 0)
                {
                    hv_Number = area.I;
                }
                else
                {
                    hv_Number = area.Length;
                }
                //HOperatorSet.EulerNumber(ho_SelectedRegions, out hv_Number);
                ho_ImageEmphasize.Dispose();
                ho_ImageScaled.Dispose();
                ho_Region.Dispose();
                ho_ConnectedRegions.Dispose();
                return;
            }
            catch (HalconException HDevExpDefaultException)
            {
                ho_ImageEmphasize.Dispose();
                ho_ImageScaled.Dispose();
                ho_Region.Dispose();
                ho_ConnectedRegions.Dispose();

                throw HDevExpDefaultException;
            }
        }
        #endregion

        #region 训练跟创建训练文件
        void TrainOCRAndCreateTrainingFile(HObject ho_ObjectSelected, HObject ho_Image,
            HTuple hv_ocr, HTuple hv_TrainingFile, HTuple hv_OCRHandle, HTuple hv_MaxIterations,
            HTuple hv_WeightTolerance, HTuple hv_ErrorTolerance, HWindow hv_WindowHandle,
            out HTuple hv_Error, out HTuple hv_ErrorLog, out HTuple hv_Class1, out HTuple hv_Confidence1)
        {
            // Initialize local and output iconic variables
            HTuple area, row, column;
            HOperatorSet.AreaCenter(ho_ObjectSelected, out area, out row, out column);
            HOperatorSet.AppendOcrTrainf(ho_ObjectSelected, ho_Image, hv_ocr, hv_TrainingFile);
            HOperatorSet.TrainfOcrClassMlp(hv_OCRHandle, hv_TrainingFile, hv_MaxIterations,
                hv_WeightTolerance, hv_ErrorTolerance, out hv_Error, out hv_ErrorLog);
            HOperatorSet.DoOcrMultiClassMlp(ho_ObjectSelected, ho_Image, hv_OCRHandle, out hv_Class1,
                out hv_Confidence1);
            disp_message(hv_WindowHandle, hv_Class1.ToString(), "window", 200, 400, "black", "true");
            return;
        }
        #endregion

        #region  显示数据
        void disp_message(HTuple hv_WindowHandle, HTuple hv_String, HTuple hv_CoordSystem,
   HTuple hv_Row, HTuple hv_Column, HTuple hv_Color, HTuple hv_Box)
        {
            // Local iconic variables 

            // Local control variables 

            HTuple hv_Red = null, hv_Green = null, hv_Blue = null;
            HTuple hv_Row1Part = null, hv_Column1Part = null, hv_Row2Part = null;
            HTuple hv_Column2Part = null, hv_RowWin = null, hv_ColumnWin = null;
            HTuple hv_WidthWin = null, hv_HeightWin = null, hv_MaxAscent = null;
            HTuple hv_MaxDescent = null, hv_MaxWidth = null, hv_MaxHeight = null;
            HTuple hv_R1 = new HTuple(), hv_C1 = new HTuple(), hv_FactorRow = new HTuple();
            HTuple hv_FactorColumn = new HTuple(), hv_UseShadow = null;
            HTuple hv_ShadowColor = null, hv_Exception = new HTuple();
            HTuple hv_Width = new HTuple(), hv_Index = new HTuple();
            HTuple hv_Ascent = new HTuple(), hv_Descent = new HTuple();
            HTuple hv_W = new HTuple(), hv_H = new HTuple(), hv_FrameHeight = new HTuple();
            HTuple hv_FrameWidth = new HTuple(), hv_R2 = new HTuple();
            HTuple hv_C2 = new HTuple(), hv_DrawMode = new HTuple();
            HTuple hv_CurrentColor = new HTuple();
            HTuple hv_Box_COPY_INP_TMP = hv_Box.Clone();
            HTuple hv_Color_COPY_INP_TMP = hv_Color.Clone();
            HTuple hv_Column_COPY_INP_TMP = hv_Column.Clone();
            HTuple hv_Row_COPY_INP_TMP = hv_Row.Clone();
            HTuple hv_String_COPY_INP_TMP = hv_String.Clone();

            // Initialize local and output iconic variables 
            //This procedure displays text in a graphics window.
            //
            //Input parameters:
            //WindowHandle: The WindowHandle of the graphics window, where
            //   the message should be displayed
            //String: A tuple of strings containing the text message to be displayed
            //CoordSystem: If set to 'window', the text position is given
            //   with respect to the window coordinate system.
            //   If set to 'image', image coordinates are used.
            //   (This may be useful in zoomed images.)
            //Row: The row coordinate of the desired text position
            //   If set to -1, a default value of 12 is used.
            //Column: The column coordinate of the desired text position
            //   If set to -1, a default value of 12 is used.
            //Color: defines the color of the text as string.
            //   If set to [], '' or 'auto' the currently set color is used.
            //   If a tuple of strings is passed, the colors are used cyclically
            //   for each new textline.
            //Box: If Box[0] is set to 'true', the text is written within an orange box.
            //     If set to' false', no box is displayed.
            //     If set to a color string (e.g. 'white', '#FF00CC', etc.),
            //       the text is written in a box of that color.
            //     An optional second value for Box (Box[1]) controls if a shadow is displayed:
            //       'true' -> display a shadow in a default color
            //       'false' -> display no shadow (same as if no second value is given)
            //       otherwise -> use given string as color string for the shadow color
            //
            //Prepare window
            HOperatorSet.GetRgb(hv_WindowHandle, out hv_Red, out hv_Green, out hv_Blue);
            HOperatorSet.GetPart(hv_WindowHandle, out hv_Row1Part, out hv_Column1Part, out hv_Row2Part,
                out hv_Column2Part);
            HOperatorSet.GetWindowExtents(hv_WindowHandle, out hv_RowWin, out hv_ColumnWin,
                out hv_WidthWin, out hv_HeightWin);
            HOperatorSet.SetPart(hv_WindowHandle, 0, 0, hv_HeightWin - 1, hv_WidthWin - 1);
            //
            //default settings
            if ((int)(new HTuple(hv_Row_COPY_INP_TMP.TupleEqual(-1))) != 0)
            {
                hv_Row_COPY_INP_TMP = 12;
            }
            if ((int)(new HTuple(hv_Column_COPY_INP_TMP.TupleEqual(-1))) != 0)
            {
                hv_Column_COPY_INP_TMP = 12;
            }
            if ((int)(new HTuple(hv_Color_COPY_INP_TMP.TupleEqual(new HTuple()))) != 0)
            {
                hv_Color_COPY_INP_TMP = "";
            }
            //
            hv_String_COPY_INP_TMP = ((("" + hv_String_COPY_INP_TMP) + "")).TupleSplit("\n");
            //
            //Estimate extentions of text depending on font size.
            HOperatorSet.GetFontExtents(hv_WindowHandle, out hv_MaxAscent, out hv_MaxDescent,
                out hv_MaxWidth, out hv_MaxHeight);
            if ((int)(new HTuple(hv_CoordSystem.TupleEqual("window"))) != 0)
            {
                hv_R1 = hv_Row_COPY_INP_TMP.Clone();
                hv_C1 = hv_Column_COPY_INP_TMP.Clone();
            }
            else
            {
                //Transform image to window coordinates
                hv_FactorRow = (1.0 * hv_HeightWin) / ((hv_Row2Part - hv_Row1Part) + 1);
                hv_FactorColumn = (1.0 * hv_WidthWin) / ((hv_Column2Part - hv_Column1Part) + 1);
                hv_R1 = ((hv_Row_COPY_INP_TMP - hv_Row1Part) + 0.5) * hv_FactorRow;
                hv_C1 = ((hv_Column_COPY_INP_TMP - hv_Column1Part) + 0.5) * hv_FactorColumn;
            }
            //
            //Display text box depending on text size
            hv_UseShadow = 1;
            hv_ShadowColor = "gray";
            if ((int)(new HTuple(((hv_Box_COPY_INP_TMP.TupleSelect(0))).TupleEqual("true"))) != 0)
            {
                if (hv_Box_COPY_INP_TMP == null)
                    hv_Box_COPY_INP_TMP = new HTuple();
                hv_Box_COPY_INP_TMP[0] = "#fce9d4";
                hv_ShadowColor = "#f28d26";
            }
            if ((int)(new HTuple((new HTuple(hv_Box_COPY_INP_TMP.TupleLength())).TupleGreater(
                1))) != 0)
            {
                if ((int)(new HTuple(((hv_Box_COPY_INP_TMP.TupleSelect(1))).TupleEqual("true"))) != 0)
                {
                    //Use default ShadowColor set above
                }
                else if ((int)(new HTuple(((hv_Box_COPY_INP_TMP.TupleSelect(1))).TupleEqual(
                    "false"))) != 0)
                {
                    hv_UseShadow = 0;
                }
                else
                {
                    hv_ShadowColor = hv_Box_COPY_INP_TMP[1];
                    //Valid color?
                    try
                    {
                        HOperatorSet.SetColor(hv_WindowHandle, hv_Box_COPY_INP_TMP.TupleSelect(
                            1));
                    }
                    // catch (Exception) 
                    catch (HalconException HDevExpDefaultException1)
                    {
                        HDevExpDefaultException1.ToHTuple(out hv_Exception);
                        hv_Exception = "Wrong value of control parameter Box[1] (must be a 'true', 'false', or a valid color string)";
                        throw new HalconException(hv_Exception);
                    }
                }
            }
            if ((int)(new HTuple(((hv_Box_COPY_INP_TMP.TupleSelect(0))).TupleNotEqual("false"))) != 0)
            {
                //Valid color?
                try
                {
                    HOperatorSet.SetColor(hv_WindowHandle, hv_Box_COPY_INP_TMP.TupleSelect(0));
                }
                // catch (Exception) 
                catch (HalconException HDevExpDefaultException1)
                {
                    HDevExpDefaultException1.ToHTuple(out hv_Exception);
                    hv_Exception = "Wrong value of control parameter Box[0] (must be a 'true', 'false', or a valid color string)";
                    throw new HalconException(hv_Exception);
                }
                //Calculate box extents
                hv_String_COPY_INP_TMP = (" " + hv_String_COPY_INP_TMP) + " ";
                hv_Width = new HTuple();
                for (hv_Index = 0; (int)hv_Index <= (int)((new HTuple(hv_String_COPY_INP_TMP.TupleLength()
                    )) - 1); hv_Index = (int)hv_Index + 1)
                {
                    HOperatorSet.GetStringExtents(hv_WindowHandle, hv_String_COPY_INP_TMP.TupleSelect(
                        hv_Index), out hv_Ascent, out hv_Descent, out hv_W, out hv_H);
                    hv_Width = hv_Width.TupleConcat(hv_W);
                }
                hv_FrameHeight = hv_MaxHeight * (new HTuple(hv_String_COPY_INP_TMP.TupleLength()
                    ));
                hv_FrameWidth = (((new HTuple(0)).TupleConcat(hv_Width))).TupleMax();
                hv_R2 = hv_R1 + hv_FrameHeight;
                hv_C2 = hv_C1 + hv_FrameWidth;
                //Display rectangles
                HOperatorSet.GetDraw(hv_WindowHandle, out hv_DrawMode);
                HOperatorSet.SetDraw(hv_WindowHandle, "fill");
                //Set shadow color
                HOperatorSet.SetColor(hv_WindowHandle, hv_ShadowColor);
                if ((int)(hv_UseShadow) != 0)
                {
                    HOperatorSet.DispRectangle1(hv_WindowHandle, hv_R1 + 1, hv_C1 + 1, hv_R2 + 1, hv_C2 + 1);
                }
                //Set box color
                HOperatorSet.SetColor(hv_WindowHandle, hv_Box_COPY_INP_TMP.TupleSelect(0));
                HOperatorSet.DispRectangle1(hv_WindowHandle, hv_R1, hv_C1, hv_R2, hv_C2);
                HOperatorSet.SetDraw(hv_WindowHandle, hv_DrawMode);
            }
            //Write text.
            for (hv_Index = 0; (int)hv_Index <= (int)((new HTuple(hv_String_COPY_INP_TMP.TupleLength()
                )) - 1); hv_Index = (int)hv_Index + 1)
            {
                hv_CurrentColor = hv_Color_COPY_INP_TMP.TupleSelect(hv_Index % (new HTuple(hv_Color_COPY_INP_TMP.TupleLength()
                    )));
                if ((int)((new HTuple(hv_CurrentColor.TupleNotEqual(""))).TupleAnd(new HTuple(hv_CurrentColor.TupleNotEqual(
                    "auto")))) != 0)
                {
                    HOperatorSet.SetColor(hv_WindowHandle, hv_CurrentColor);
                }
                else
                {
                    HOperatorSet.SetRgb(hv_WindowHandle, hv_Red, hv_Green, hv_Blue);
                }
                hv_Row_COPY_INP_TMP = hv_R1 + (hv_MaxHeight * hv_Index);
                HOperatorSet.SetTposition(hv_WindowHandle, hv_Row_COPY_INP_TMP, hv_C1);
                HOperatorSet.WriteString(hv_WindowHandle, hv_String_COPY_INP_TMP.TupleSelect(
                    hv_Index));
            }
            //Reset changed window settings
            HOperatorSet.SetRgb(hv_WindowHandle, hv_Red, hv_Green, hv_Blue);
            HOperatorSet.SetPart(hv_WindowHandle, hv_Row1Part, hv_Column1Part, hv_Row2Part,
                hv_Column2Part);

            return;
        }
        #endregion

        //#region  设置要训练的ocr区域的点位
        ///// <summary>
        ///// 设置要训练的ocr区域的点位
        ///// </summary>
        ///// <param name="row1"></param>
        ///// <param name="column1"></param>
        ///// <param name="row2"></param>
        ///// <param name="column2"></param>
        ///// <returns></returns>
        //public bool Set_CurrentOCRTrainRegion(HTuple row_y_, HTuple column_x_, HTuple phi, HTuple len1, HTuple len2)
        //{
        //    bool ok = false;

        //    this.IOutSide.Mid_row_y = row_y_;
        //    this.IOutSide.Mid_col_x = column_x_;
        //    this.IOutSide.Phi = phi;
        //    this.IOutSide.Len1 = len1;
        //    this.IOutSide.Len2 = len2;

        //    //hv_Row1 = row1;
        //    //hv_Column1 = column1;
        //    //hv_Row2 = row2;
        //    //hv_Column2 = column2;

        //    ok = true;
        //    return ok;
        //}

        //#endregion

        #region  保存当前ocr
        ///// <summary>
        ///// 保存当前ocr
        ///// </summary>
        ///// <param name="IOCR"></param>
        ///// <returns></returns>
        //public bool Set_SaveOCRHandle(IOCRShuJu IOCR)
        //{
        //    bool ok = false;

        //    if (IOCR.Hv_OCRHandle == null)
        //    {
        //        MessageBox.Show("指针数据是空的，不能保存，检测是否有训练");
        //        return false;
        //    }
        //    //   HOperatorSet.WriteOcrClassMlp(Hv_OCRHandle, Path1);
        //    base.SaveHandleOCR(IOCR.Hv_OCRHandle, IOCR.Path1);

        //    ok = true;
        //    return ok;
        //}
        #endregion

        #region    建立字符对比模板
        /// <summary>
        /// 建立字符对比模板
        /// </summary>
        /// <param name="IOCR"></param>
        /// <param name="trained_"></param>
        /// <param name="character_"></param>
        /// <returns></returns>
        public bool Set_Trained_Class(IOCRShuJu IOCR, bool trained_, ref string character_)
        {
            bool ok = false;

            IOCR.OcrTrainedClass._trained = trained_;
            if (IOCR.Hv_Class1 != null)
            {
                IOCR.OcrTrainedClass._ocrTrainingCharacteer = IOCR.Hv_Class1.ToString();
            }
            character_ = IOCR.OcrTrainedClass._ocrTrainingCharacteer;

            ok = true;
            return ok;
        }
        #endregion

        #region  添加ocr的region
        /// <summary>
        /// 添加ocr的region
        /// </summary>
        /// <param name="halconWinControl_"></param>
        /// <param name="number"></param>
        /// <returns></returns>
        public bool Set_AddOcrRoi(IOCRShuJu IOCR, HalControl.HalconWinControl_ROI halconWinControl_, int number)
        {
            bool ok = false;

            if (number < 1)
            {
                return ok;
            }

            /*******删除当前的ocr的region*********/
            IOCR.List_IOutSide.Clear();
            halconWinControl_.clearAllROIControlRoi();

            for (int i = 0; i < number; i++)
            {
                IOutsideRectangle2ROI rectangle2Roi_ = new OutsideRectangle2ROI();
                rectangle2Roi_.Mid_col_x = 100;
                rectangle2Roi_.Mid_row_y = 100;
                rectangle2Roi_.Phi = 0;
                rectangle2Roi_.Len1 = 100;
                rectangle2Roi_.Len2 = 100;
                IOCR.List_IOutSide.Add(rectangle2Roi_);
            }

            foreach (IOutsideRectangle2ROI io_ in IOCR.List_IOutSide)
            {
                halconWinControl_.DrawRectangle2(io_.Mid_col_x, io_.Mid_row_y, io_.Phi, io_.Len1, io_.Len2, io_);
            }
            ok = true;
            return ok;
        }
        #endregion

        #region 当前添加一个ocr的region
        /// <summary>
        /// 当前添加一个ocr的region
        /// </summary>
        /// <param name="IOCR"></param>
        /// <param name="halconWinControl_"></param>
        /// <returns></returns>
        public bool Set_AddOneOCRRegion(IOCRShuJu IOCR, HalControl.HalconWinControl_ROI halconWinControl_)
        {
            bool ok = false;

            IOutsideRectangle2ROI rectangle2Roi_ = new OutsideRectangle2ROI();
            rectangle2Roi_.Mid_col_x = 100;
            rectangle2Roi_.Mid_row_y = 100;
            rectangle2Roi_.Phi = 0;
            rectangle2Roi_.Len1 = 100;
            rectangle2Roi_.Len2 = 100;
            IOCR.List_IOutSide.Add(rectangle2Roi_);

            halconWinControl_.DrawRectangle2(IOCR.List_IOutSide[IOCR.List_IOutSide.Count - 1].Mid_col_x, IOCR.List_IOutSide[IOCR.List_IOutSide.Count - 1].Mid_row_y, IOCR.List_IOutSide[IOCR.List_IOutSide.Count - 1].Phi, IOCR.List_IOutSide[IOCR.List_IOutSide.Count - 1].Len1, IOCR.List_IOutSide[IOCR.List_IOutSide.Count - 1].Len2, IOCR.List_IOutSide[IOCR.List_IOutSide.Count - 1]);

            ok = true;
            return ok;
        }
        #endregion
        
        #region    删除ocr的region
        /// <summary>
        /// 删除ocr的region
        /// </summary>
        /// <param name="IOCR"></param>
        /// <param name="halconWinControl_"></param>
        /// <returns></returns>
        public bool Set_DeleteOcrRegion(IOCRShuJu IOCR, HalControl.HalconWinControl_ROI halconWinControl_)
        {
            bool ok = false;

            if (IOCR.List_IOutSide.Count == 1)
            {
                return ok = false;
            }

            //if (IOCR.List_IOutSide.Count == IOCR.IXuanZhongDeRoi.IXuanZhongRoiDeIndex)
            //{
            //   
            //}

            if (IOCR.IXuanZhongDeRoi.IXuanZhongRoiDeIndex != -1)
            {
                IOCR.List_IOutSide.RemoveAt(IOCR.IXuanZhongDeRoi.IXuanZhongRoiDeIndex);


            }

            halconWinControl_.deleteDangQianXuanZhongDeRoi();
            halconWinControl_.refreshWindow();
            ok = true;
            return ok;
        }
        #endregion

        #region   创建训练
        /// <summary>
        /// 创建训练
        /// </summary>
        /// <param name="IOCR"></param>
        /// <param name="hv_FileName"></param>
        /// <param name="Characters_Text"></param>
        /// <returns></returns>
        public bool CreateOCRClassMlp(IOCRShuJu IOCR, string hv_FileName, string Characters_Text)
        {
            bool ok = false;

            if (hv_FileName == "")
            {
                MessageBox.Show("字符库名位空");
                return ok;
            }

            if (Characters_Text == "")
            {
                MessageBox.Show("要训练的字符名称为空");
                return ok;
            }

            string[] train_file = Characters_Text.Split(',');

            for (int i = 0; i < train_file.Length; i++)
            {
                IOCR.Hv_Characters[i] = train_file[i];
            }

            HTuple OCRHandle;

            if (IOCR.Hv_OCRHandle == null)
            {
                IOCR.Hv_OCRHandle = new HTuple();
            }
            else
            {
                HOperatorSet.ClearOcrClassMlp(IOCR.Hv_OCRHandle);
            }

            CreateOCRClassMlp(IOCR.Hv_WidthCharacter, IOCR.Hv_HeightCharacter, IOCR.Hv_Interpolation, IOCR.Hv_Features, IOCR.Hv_Characters, IOCR.Hv_NumHidden, IOCR.Hv_Preprocessing, IOCR.Hv_NumComponents, IOCR.Hv_RandSeed, out OCRHandle);
            IOCR.Hv_OCRHandle = OCRHandle;
            IOCR.Hv_FileName = hv_FileName;

            ok = true;
            return ok;
        }
        
        /// <summary>
        /// 
        /// </summary>
        /// <param name="hv_WidthCharacter"></param>
        /// <param name="hv_HeightCharacter"></param>
        /// <param name="hv_Interpolation"></param>
        /// <param name="hv_Features"></param>
        /// <param name="hv_Characters"></param>
        /// <param name="hv_NumHidden"></param>
        /// <param name="hv_Preprocessing"></param>
        /// <param name="hv_NumComponents"></param>
        /// <param name="hv_RandSeed"></param>
        /// <param name="hv_OCRHandle"></param>
        void CreateOCRClassMlp(HTuple hv_WidthCharacter, HTuple hv_HeightCharacter,
   HTuple hv_Interpolation, HTuple hv_Features, HTuple hv_Characters, HTuple hv_NumHidden,
   HTuple hv_Preprocessing, HTuple hv_NumComponents, HTuple hv_RandSeed, out HTuple hv_OCRHandle)
        {
            // Initialize local and output iconic variables 
            HOperatorSet.CreateOcrClassMlp(hv_WidthCharacter, hv_HeightCharacter, hv_Interpolation,
                hv_Features, hv_Characters, hv_NumHidden, hv_Preprocessing, hv_NumComponents,
                hv_RandSeed, out hv_OCRHandle);
            return;
        }

        #endregion

        #region  刷新定位点
        /// <summary>
        /// 刷新定位点
        /// </summary>
        /// <param name="IOCR"></param>
        /// <returns></returns>
        public bool Set_ShuaXinDingWeiDian(IOCRShuJu IOCR)
        {
            bool ok = false;

            if (IOCR.IrectShuJuPianYi != null)
            {
                IOCR.GeuSuiDian_X_Col = IOCR.IrectShuJuPianYi.Column;
                IOCR.GenSuiDian_Y_Row = IOCR.IrectShuJuPianYi.Row;
                IOCR.GenSuiDian_A = IOCR.IrectShuJuPianYi.Angle;
            }

            ok = true;
            return ok;

        }
        #endregion

        #region   保存当前训练的ocr
        /// <summary>
        /// 保存当前训练的ocr
        /// </summary>
        /// <param name="IOCR"></param>
        /// <returns></returns>
        public bool Set_SaveOCRHandle(IOCRShuJu IOCR)
        {
            bool ok = false;
            HOperatorSet.WriteOcrClassMlp(IOCR.Hv_OCRHandle, IOCR.Path1);
            ok = true;
            return ok;
        }
        #endregion
    }
    #endregion
      
    #region  OCR结果的结构体
    /// <summary>
    /// OCR结果的结构体
    /// </summary>
    public class OCR_Result : MultTree.ClassResultFather
    {
        /// <summary>
        /// 
        /// </summary>
        public HTuple Number = new HTuple();
        /// <summary>
        /// 
        /// </summary>
        public HTuple Hv_Class1 = new HTuple();
        /// <summary>
        /// 
        /// </summary>
        public HTuple Hv_Confidence = new HTuple();
        /// <summary>
        /// 训练对比的结果
        /// </summary>
        public bool _Result = true;

        /// <summary>
        /// 显示数据
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public override bool showResult(out string str)
        {
            bool ok = false;

            if (this.TolatResult)
            {
                str = this.TolatName + ":" + this.Hv_Class1.ToString();
            }
            else
            {
                str = this.TolatName + ":检测失败。";
            }

            ok = true;
            return ok;
        }

        /// <summary>
        /// 显示数据
        /// </summary>
        /// <param name="str_array"></param>
        /// <returns></returns>
        public override bool showResult(out string[] str_array)
        {
            bool ok = false;

            str_array = new string[2];
            str_array[0] = this.TolatName;

            if (this.TolatResult)
            {
                str_array[1] = this.Hv_Class1.ToString();
            }
            else
            {
                str_array[1] = "检测失败";
            }

            ok = true;
            return ok;
        }
    }
    #endregion

    #region  外部接口保存
    /// <summary>
    /// 外部接口保存
    /// </summary>
    [Serializable]
    public class waiBuJieKouBaoCunShuJu
    {
        /// <summary>
        /// 
        /// </summary>
        public Object _mid_row_y;

        /// <summary>
        /// 
        /// </summary>
        public Object _mid_col_x;

        /// <summary>
        /// 
        /// </summary>
        public Object _len1;

        /// <summary>
        /// 
        /// </summary>
        public Object _len2;

        /// <summary>
        /// 
        /// </summary>
        public Object _angle;
    }
    #endregion


}