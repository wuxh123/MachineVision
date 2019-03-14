using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using HalconDotNet;
using System.IO;
using RectLibrary;
using HalControl.ROI.Rectangle2;






namespace BarCodeHalconLibrary
{
    #region  一维码工具的数据
    /// <summary>
    /// 一维码工具的数据
    /// </summary>
    [Serializable]
    public class BarCodeShuJu : MultTree.ToolDateFather, IBarCodeShuJu
    {
        #region   全局变量

        #region   条码的对错标志
        /// <summary>
        /// 条码的对错标志
        /// </summary>
        bool _tiaoMaDeDuiCuoBiaoZhi = false;
        #endregion

        #region  一维码的参数值

        /// <summary>
        /// 最小对比度250
        /// </summary>
        [NonSerialized]
        HTuple contrast_min = null;

        /// <summary>
        /// 设置最小宽度的尺寸
        /// </summary>
        [NonSerialized]
        HTuple element_size_min = null;

        /// <summary>
        /// 保存中间结果
        /// </summary>
        [NonSerialized]
        HTuple persistence = null;

        /// <summary>
        /// 设置扫描线条数8
        /// </summary>
        [NonSerialized]
        HTuple num_scanlines = null;

        #endregion

        #region roi信息
        /// <summary>
        ///  region的接口数据
        /// </summary>      
        IOutsideRectangle2ROI _iOutSide;
        #endregion

        #region 条码指针
        /// <summary>
        /// 条码指针
        /// </summary>
        [NonSerialized]
        HTuple hv_BarCodeHandle = null;
        #endregion

        #region  读取条码的格式
        /// <summary>
        /// 读取条码的格式
        /// </summary>
        [NonSerialized]
        HTuple hv_CodeType = "auto";
        #endregion

        #region  读取到的条码信息
        /// <summary>
        /// 读取到的条码信息
        /// </summary>
        [NonSerialized]
        HTuple hv_DecodedDataStrings = null;
        #endregion

        #region  条码读取后的region
        /// <summary>
        /// 条码读取后的region
        /// </summary>
        [NonSerialized]
        HObject ho_SymbolRegions;
        #endregion

        #region   输出的等级验证
        /// <summary>
        /// 输出的等级验证
        /// </summary>
        [NonSerialized]
        HTuple hv_BarCodeResults = null;
        #endregion

        #region   训练的结果类
        /// <summary>
        /// 训练的结果类
        /// </summary>
        Trained_Class _trainClass;
        #endregion

        #region   等级验证的结果类
        /// <summary>
        /// 等级验证的结果类
        /// </summary>
        Quality_Class _qualityClass;
        #endregion

        #region   结果
        /// <summary>
        /// 结果
        /// </summary>
        [NonSerialized]
        BarCode_Result _result;
        #endregion

        #endregion

        #region 属性

        //#region   需要防射变化
        /////// <summary>
        /////// 需要防射变化
        /////// </summary>
        ////public HTuple Hv_HomMat2D
        ////{
        ////    get { return hv_HomMat2D; }
        ////    set { hv_HomMat2D = value; }
        ////}

        ///// <summary>
        ///// 需要防射变化
        ///// </summary>
        //public IRectShuJuHv_HomMat2D Ihv_HomMat2D
        //{
        //    get { return _ihv_HomMat2D; }
        //    set { _ihv_HomMat2D = value; }
        //}
        //#endregion

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

        //#region  跟随点的放射变换矩阵
        ///// <summary>
        ///// 跟随点的放射变换矩阵
        ///// </summary>
        //public HTuple GenSuiDianWei_Hv_HomMat2D
        //{
        //    get { return genSuiDianWei_Hv_HomMat2D; }
        //    set
        //    {
        //        genSuiDianWei_Hv_HomMat2D = value;
        //    }
        //}
        //#endregion

        //#region  防射变换偏移的数据接口
        ///// <summary>
        ///// 防射变换偏移的数据接口
        ///// </summary>
        //public IRectShuJuPianYi IrectShuJuPianYi
        //{
        //    get { return irectShuJuPianYi; }
        //    set
        //    {
        //        #region  无用代码
        //        //if (value != null)//判断是不是跟随定位
        //        //{
        //        //    if (this.GenSuiDianYuDingWeiDianDeBianHuanRegion != null)
        //        //    {
        //        //        HTuple y_row, x_col, area, phi;
        //        //        HOperatorSet.AreaCenter(this.GenSuiDianYuDingWeiDianDeBianHuanRegion, out area, out y_row, out x_col);
        //        //        HOperatorSet.OrientationRegion(this.GenSuiDianYuDingWeiDianDeBianHuanRegion, out phi);
        //        //        this._iOutSide.Mid_col_x = x_col;
        //        //        this._iOutSide.Mid_row_y = y_row;
        //        //        this._iOutSide.Phi = phi;
        //        //    }
        //        //}
        //        #endregion

        //        irectShuJuPianYi = value;
        //    }
        //}
        //#endregion

        //#region  跟随点与定位点的变换region
        ///// <summary>
        ///// 跟随点与定位点的变换region
        ///// </summary>
        //public HObject GenSuiDianYuDingWeiDianDeBianHuanRegion
        //{
        //    get
        //    {
        //        if (genSuiDianYuDingWeiDianDeBianHuanRegion == null)
        //        {

        //            HOperatorSet.GenEmptyObj(out genSuiDianYuDingWeiDianDeBianHuanRegion);
        //        }
        //        return genSuiDianYuDingWeiDianDeBianHuanRegion;
        //    }
        //    set
        //    {
        //        ;
        //    }
        //}
        //#endregion

        //#endregion

        #region   条码读取后的region
        /// <summary>
        /// 条码读取后的region
        /// </summary>
        public HObject Ho_SymbolRegions
        {
            get
            {
                return ho_SymbolRegions;
            }

            set
            {
                ho_SymbolRegions = value;
            }
        }
        #endregion

        #region   读取到的条码信息
        /// <summary>
        /// 读取到的条码信息
        /// </summary>
        public HTuple Hv_DecodedDataStrings
        {
            get
            {
                return hv_DecodedDataStrings;
            }

            set
            {
                hv_DecodedDataStrings = value;
            }
        }
        #endregion

        #region 条码指针
        /// <summary>
        /// 条码指针
        /// </summary>
        public HTuple Hv_BarCodeHandle
        {
            get
            {
                return hv_BarCodeHandle;
            }

            set
            {
                hv_BarCodeHandle = value;
            }
        }
        #endregion

        #region   读取条码的格式
        /// <summary>
        /// 读取条码的格式
        /// </summary>
        public HTuple Hv_CodeType
        {
            get
            {
                return hv_CodeType;
            }

            set
            {
                hv_CodeType = value;
            }
        }
        #endregion

        #region  最小对比度250
        /// <summary>
        /// 最小对比度250
        /// </summary>
        public HTuple Contrast_min
        {
            get
            {
                if (contrast_min == null)
                {
                    contrast_min = 30;
                }
                return contrast_min;
            }
            set { contrast_min = value; }
        }
        #endregion

        #region   设置最小宽度的尺寸
        /// <summary>
        /// 设置最小宽度的尺寸
        /// </summary>
        public HTuple Element_size_min
        {
            get
            {
                if (element_size_min == null)
                {
                    element_size_min = 2;
                }
                return element_size_min;
            }
            set { element_size_min = value; }
        }
        #endregion

        #region  保存中间结果
        /// <summary>
        /// 保存中间结果
        /// </summary>
        public HTuple Persistence
        {
            get
            {
                if (persistence == null)
                {
                    persistence = 1;
                }
                return persistence;
            }
            set { persistence = value; }
        }
        #endregion

        #region   设置扫描线条数8
        /// <summary>
        /// 设置扫描线条数8
        /// </summary>
        public HTuple Num_scanlines
        {
            get
            {
                if (num_scanlines == null)
                {
                    num_scanlines = 8;
                }
                return num_scanlines;
            }
            set { num_scanlines = value; }
        }
        #endregion

        #region   训练的结果类
        /// <summary>
        /// 训练的结果类
        /// </summary>
        public Trained_Class TrainClass
        {
            get
            {
                if (_trainClass == null)
                {
                    _trainClass = new Trained_Class();
                }
                return _trainClass;
            }
            set
            {
                if (_trainClass == null)
                {
                    _trainClass = new Trained_Class();
                }
                _trainClass = value;
            }
        }
        #endregion

        #region  等级验证的结果类
        /// <summary>
        /// 等级验证的结果类
        /// </summary>
        public Quality_Class QualityClass
        {
            get
            {
                if (_qualityClass == null)
                {
                    _qualityClass = new Quality_Class();
                }
                return _qualityClass;
            }
            set
            {
                if (_qualityClass == null)
                {
                    _qualityClass = new Quality_Class();
                }
                _qualityClass = value;
            }
        }
        #endregion

        #region   输出的等级验证
        /// <summary>
        /// 输出的等级验证
        /// </summary>
        public HTuple Hv_BarCodeResults
        {
            get { return hv_BarCodeResults; }
            set { hv_BarCodeResults = value; }
        }
        #endregion

        #region   region的接口数据
        /// <summary>
        ///  region的接口数据
        /// </summary>
        public IOutsideRectangle2ROI IOutSide
        {
            get
            {
                if (_iOutSide == null)
                {
                    _iOutSide = new OutsideRectangle2ROI();
                    _iOutSide.Mid_col_x = 100;
                    _iOutSide.Mid_row_y = 100;
                    _iOutSide.Phi = 0;
                    _iOutSide.Len1 = 100;
                    _iOutSide.Len2 = 100;
                }
                return _iOutSide;
            }
            set
            {
                if (_iOutSide == null)
                {
                    _iOutSide = new OutsideRectangle2ROI();
                    _iOutSide.Mid_col_x = 100;
                    _iOutSide.Mid_row_y = 100;
                    _iOutSide.Phi = 0;
                    _iOutSide.Len1 = 100;
                    _iOutSide.Len2 = 100;
                }

                _iOutSide = value;
            }
        }
        #endregion

        #endregion

        #region   初始化
        /// <summary>
        /// 初始化
        /// </summary>
        public BarCodeShuJu()
        {
            _result = new BarCode_Result();
            HOperatorSet.GenEmptyObj(out ho_SymbolRegions);
            HOperatorSet.CreateBarCodeModel(new HTuple(), new HTuple(), out hv_BarCodeHandle);
        }
        #endregion

        #region  序列化保存数据

        #region roi信息
        /// <summary>
        /// 截取roi的中心坐标， 行 y
        /// </summary>
        Object hv_Row1;
        /// <summary>
        /// 截取roi的中心坐标， 列 x
        /// </summary>
        Object hv_Column1;
        /// <summary>
        /// 截取roi的角度
        /// </summary>
        Object hv_Phi1;
        /// <summary>
        /// 截取roi的width
        /// </summary>
        Object hv_Length11;
        /// <summary>
        /// 截取roi的high
        /// </summary>
        Object hv_Length21;
        #endregion

        #region  一维码的参数值
        /// <summary>
        /// 最小对比度250
        /// </summary>
        Object contrast_min_1;

        /// <summary>
        /// 设置最小宽度的尺寸
        /// </summary>
        Object element_size_min_1;

        /// <summary>
        /// 保存中间结果
        /// </summary>
        Object persistence_1;

        /// <summary>
        /// 设置扫描线条数8
        /// </summary>
        Object num_scanlines_1;
        #endregion

        #region  读取条码的格式
        /// <summary>
        /// 读取条码的格式
        /// </summary>   
        Object hv_CodeType1;
        #endregion

        #region   一维码指针
        /// <summary>
        ///  一维码指针
        /// </summary>
        Object Hv_BarCodeHandle1;
        #endregion

        #endregion

        #region   保存数据
        /// <summary>
        /// 保存数据
        /// </summary>
        public override void save()
        {
            base.save();

            #region roi信息
            hv_Row1 = IOutSide.Mid_row_y;

            hv_Column1 = IOutSide.Mid_col_x;

            hv_Phi1 = IOutSide.Phi;

            hv_Length11 = IOutSide.Len1;

            hv_Length21 = IOutSide.Len2;
            #endregion

            #region  一维码的参数值
            contrast_min_1 = contrast_min;

            element_size_min_1 = element_size_min;

            persistence_1 = persistence;

            num_scanlines_1 = num_scanlines;
            #endregion

            #region 读取条码的格式
            hv_CodeType1 = hv_CodeType;
            #endregion

            #region   保存一维码读取模板
            Hv_BarCodeHandle1 = hv_BarCodeHandle;
            //  HOperatorSet.WriteBarCodeModel(hv_BarCodeHandle, Bar_code_Path);
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

            #region roi信息
            IOutSide.Mid_row_y = (HTuple)hv_Row1;

            IOutSide.Mid_col_x = (HTuple)hv_Column1;

            IOutSide.Phi = (HTuple)hv_Phi1;

            IOutSide.Len1 = (HTuple)hv_Length11;

            IOutSide.Len2 = (HTuple)hv_Length21;
            #endregion

            #region  一维码的参数值
            contrast_min = (HTuple)contrast_min_1;
            element_size_min = (HTuple)element_size_min_1;
            persistence = (HTuple)persistence_1;
            num_scanlines = (HTuple)num_scanlines_1;
            #endregion

            #region 读取条码的格式
            hv_CodeType = (HTuple)hv_CodeType1;
            #endregion

            #region 初始化一维码读码模板

            hv_BarCodeHandle = (HTuple)Hv_BarCodeHandle1;

            //HOperatorSet.ReadBarCodeModel(Bar_code_Path,out hv_BarCodeHandle);
            #endregion

            _result = new BarCode_Result();

            HOperatorSet.GenEmptyObj(out ho_SymbolRegions);
            HOperatorSet.CreateBarCodeModel(new HTuple(), new HTuple(), out hv_BarCodeHandle);

        }
        #endregion

        #region   检测
        public override bool analyze_show(HWindow hwin, string Key, ref Dictionary<string, object> _dictionary_resulte)
        {
            bool ok = false;
            /********************************************************处理**********************************************/
            HObject ho_Rectangle;
            HObject ho_ImageReduced;
            HObject ho_SymbolRegions;
            HTuple hv_DecodedDataStrings;
            HTuple hv_HomMat2D;

            HOperatorSet.GenEmptyObj(out ho_Rectangle);
            HOperatorSet.GenEmptyObj(out ho_ImageReduced);
            HOperatorSet.GenEmptyObj(out ho_SymbolRegions);

            ho_Rectangle.Dispose();
            HOperatorSet.GenRectangle2(out ho_Rectangle, IOutSide.Mid_row_y, IOutSide.Mid_col_x, -IOutSide.Phi, IOutSide.Len1,
               IOutSide.Len2);

            if (IrectShuJuPianYi != null)
            {
                HOperatorSet.VectorAngleToRigid(GenSuiDian_Y_Row, GeuSuiDian_X_Col, GenSuiDian_A, IrectShuJuPianYi.Row, IrectShuJuPianYi.Column, IrectShuJuPianYi.Angle, out hv_HomMat2D);
                HOperatorSet.AffineTransRegion(ho_Rectangle, out ho_Rectangle, hv_HomMat2D, "nearest_neighbor");
            }

            ho_ImageReduced.Dispose();
            HOperatorSet.ReduceDomain(this.ImageFather.Ho_image, ho_Rectangle, out ho_ImageReduced);

            ho_SymbolRegions.Dispose();
            HOperatorSet.FindBarCode(ho_ImageReduced, out ho_SymbolRegions, Hv_BarCodeHandle,
               Hv_CodeType, out hv_DecodedDataStrings);

            Ho_SymbolRegions.Dispose();
            Ho_SymbolRegions = ho_SymbolRegions;
            Hv_DecodedDataStrings = hv_DecodedDataStrings;

            /**********************数据分析********************************/
            //BarCode_Result bar_ = new BarCode_Result();
            Key = "BarCode_" + Key;
            _result._tolatName = Key;

            if (Hv_DecodedDataStrings.Length > 0)
            {
                string str = Hv_DecodedDataStrings.ToString();

                _result.Hv_DecodedDataStrings = Hv_DecodedDataStrings;

                _result._Result = true;
                _result._tolatResult = true;

                #region   检测是否训练
                if (TrainClass._trained)
                {
                    _result.Trained = true;
                    if (TrainClass._BarCodeTrained == str)
                    {
                        TrainClass._result = true;
                        //bar_.Trained_Result = true;
                    }
                    else
                    {
                        TrainClass._result = false;
                        //bar_.Trained_Result = false;
                        _result._Result = false;
                        _result._tolatResult = false;
                    }
                }
                else
                {
                    _result.Trained = false;
                    //bar_.Trained_Result = false;
                }
                #endregion

                #region   等级验证
                if (QualityClass._quality_isoiec15416)
                {
                    _result.Quality_Isoiec15416 = true;
                    int num = Hv_BarCodeResults[0].I;
                    if (QualityClass._min_Grade < num)
                    {
                        QualityClass._result = true;
                        //bar_.Quality_Result = true;
                    }
                    else
                    {
                        QualityClass._result = false;
                        //bar_.Quality_Result = false;
                        _result._Result = false;
                        _result._tolatResult = false;
                    }
                }
                else
                {
                    _result.Quality_Isoiec15416 = false;
                    //bar_.Quality_Result = false;
                }
                #endregion
            }
            else
            {
                _result._Result = false;
                _result._tolatResult = false;
            }
            _dictionary_resulte.Add(Key, _result);

            this._tiaoMaDeDuiCuoBiaoZhi = _result._Result;
            if (this._tiaoMaDeDuiCuoBiaoZhi)
            {
                ok = true;
            }
            //ho_Rectangle.Dispose();
            ho_ImageReduced.Dispose();
            GenSuiDianYuDingWeiDianDeBianHuanRegion.Dispose();
            GenSuiDianYuDingWeiDianDeBianHuanRegion = ho_Rectangle;
            //hwin.DispObj(GenSuiDianYuDingWeiDianDeBianHuanRegion);
            show(hwin);

            return ok;
        }
        #endregion

        #region   显示
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

        #region   显示
        public override bool show(HWindow hwin)
        {
            bool ok = false;

            /**********************************************显示结果数据********************************************/
            if (this._tiaoMaDeDuiCuoBiaoZhi)
            {
                // ShowCodeBar(ICode.Ho_SymbolRegions, hwin, ICode.Hv_DecodedDataStrings);
                HObject ho_Contours;
                HOperatorSet.GenEmptyObj(out ho_Contours);
                ho_Contours.Dispose();
                HOperatorSet.GenContourRegionXld(Ho_SymbolRegions, out ho_Contours, "border");
                hwin.DispObj(ho_Contours);

                disp_message(hwin, Hv_DecodedDataStrings, "image", IOutSide.Mid_row_y,
              IOutSide.Mid_col_x, "green", "false");

                if (QualityClass._quality_isoiec15416)
                {
                    HTuple barCodeResults_;
                    HOperatorSet.GetBarCodeResult(Hv_BarCodeHandle, 0, "quality_isoiec15416", out barCodeResults_);
                    Hv_BarCodeResults = barCodeResults_;
                    disp_message(hwin, Hv_BarCodeResults, "image", IOutSide.Mid_row_y,
              IOutSide.Mid_col_x, "green", "false");
                }

                /**********清空缓存************/
                ho_Contours.Dispose();
            }

            /***********************************************显示 提示正确还是错误******************************************/
            //HObject ho_Rectangle_;
            //HOperatorSet.GenEmptyObj(out ho_Rectangle_);
            //ho_Rectangle_.Dispose();
            //HOperatorSet.GenContourRegionXld(GenSuiDianYuDingWeiDianDeBianHuanRegion, out ho_Rectangle_, "border");
            if (this._tiaoMaDeDuiCuoBiaoZhi)
            {
                //HOperatorSet.GenContourRegionXld(ho_Rectangle, out ho_Rectangle, "border");
                hwin.DispObj(GenSuiDianYuDingWeiDianDeBianHuanRegion);
                ok = true;
            }
            else
            {
                hwin.SetColor("red");
                if (GenSuiDianYuDingWeiDianDeBianHuanRegion.IsInitialized())
                {
                    hwin.DispObj(GenSuiDianYuDingWeiDianDeBianHuanRegion);
                }
                hwin.SetColor("green");
            }
            ///********清空缓存**************/
            //ho_Rectangle_.Dispose();

            ok = true;
            return ok;
        }
        #endregion

    }
    #endregion

    #region  训练的结果类
    /// <summary>
    /// 训练的结果体
    /// </summary>
    [Serializable]
    public class Trained_Class
    {
        /// <summary>
        /// 是否启动训练
        /// </summary>
        public bool _trained = false;

        /// <summary>
        /// 训练的一维码数据
        /// </summary>
        public string _BarCodeTrained = "";

        /// <summary>
        /// 条码训练后，对比的结果
        /// </summary>
        public bool _result = false;
    }
    #endregion

    #region  等级验证的结果类
    /// <summary>
    /// 等级验证的结果体
    /// </summary>
    [Serializable]
    public class Quality_Class
    {
        /// <summary>
        /// 是否启动等级验证
        /// </summary>
        public bool _quality_isoiec15416 = false;

        /// <summary>
        /// 条码的最小等级
        /// </summary>
        public int _min_Grade = 0;

        /// <summary>
        /// 等级验证的结果
        /// </summary>
        public bool _result = false;
    }
    #endregion

    #region  一维码数据的接口
    /// <summary>
    /// 一维码数据的接口
    /// </summary>
    public interface IBarCodeShuJu : IOutsideRectangle2, MultTree.IToolDateFather
    {
        #region 全局变量
        //#region  roi信息
        ///// <summary>
        ///// 截取roi的中心坐标， 行 y
        ///// </summary>
        //HTuple Hv_Row
        //{
        //    get
        //   ;

        //    set
        //    ;
        //}

        ///// <summary>
        /////  截取roi的中心坐标， 列 x
        ///// </summary>
        //HTuple Hv_Column
        //{
        //    get
        //    ;

        //    set
        //   ;
        //}

        ///// <summary>
        ///// 截取roi的角度
        ///// </summary>
        //HTuple Hv_Phi
        //{
        //    get
        // ;
        //    set
        //   ;
        //}

        ///// <summary>
        ///// 截取roi的width
        ///// </summary>
        //HTuple Hv_Length1
        //{
        //    get
        //  ;
        //    set
        //   ;
        //}

        ///// <summary>
        ///// 截取roi的high
        ///// </summary>
        //HTuple Hv_Length2
        //{
        //    get
        //   ;

        //    set
        //  ;
        //}
        //#endregion

        #region   条码读取后的region

        /// <summary>
        /// 条码读取后的region
        /// </summary>
        HObject Ho_SymbolRegions
        {
            get
          ;

            set
           ;
        }
        #endregion

        #region   读取到的条码信息
        /// <summary>
        /// 读取到的条码信息
        /// </summary>
        HTuple Hv_DecodedDataStrings
        {
            get
           ;
            set
          ;
        }
        #endregion

        #region 条码指针
        /// <summary>
        /// 条码指针
        /// </summary>
        HTuple Hv_BarCodeHandle
        {
            get
           ;
            set
           ;
        }

        #endregion

        #region   读取条码的格式
        /// <summary>
        /// 读取条码的格式
        /// </summary>
        HTuple Hv_CodeType
        {
            get
         ;
            set
          ;
        }
        #endregion

        #region   训练的结果类
        /// <summary>
        /// 训练的结果类
        /// </summary>
        Trained_Class TrainClass
        {
            get
          ;
            set
          ;
        }
        #endregion

        #region  等级验证的结果类
        /// <summary>
        /// 等级验证的结果类
        /// </summary>
        Quality_Class QualityClass
        {
            get
          ;
            set
           ;
        }
        #endregion

        #region   输出的等级验证
        /// <summary>
        /// 输出的等级验证
        /// </summary>
        HTuple Hv_BarCodeResults
        {
            get;
            set;
        }
        #endregion

        //#region  是否启动等级验证标志
        ///// <summary>
        ///// 是否启动等级验证标志
        ///// </summary>
        //bool Quality_isoiec15416
        //{
        //    get;
        //    set;
        //}
        //#endregion

        //#region   是否启动训练
        ///// <summary>
        ///// 是否启动训练
        ///// </summary>
        //bool Trained
        //{
        //    get;
        //    set;
        //}
        //#endregion

        #region 无用代码
        #region  一维码名称
        /// <summary>
        /// 一维码名称
        /// </summary>
        //string Bar_code_name
        //{
        //    get
        //   ;
        //    set
        //   ;
        //}

        ///// <summary>
        ///// 一维码路径
        ///// </summary>
        // string Bar_code_Path
        //{
        //    get
        //    ;
        //}


        #endregion
        #endregion

        //#region   需要防射变化
        /////// <summary>
        /////// 需要防射变化
        /////// </summary>
        ////HTuple Hv_HomMat2D
        ////{
        ////    get;
        ////    set;
        ////}

        ///// <summary>
        ///// 需要防射变化
        ///// </summary>
        //IRectShuJuHv_HomMat2D Ihv_HomMat2D
        //{
        //    get;
        //    set;
        //}
        //#endregion

        //#region   条码的最小等级
        ///// <summary>
        ///// 条码的最小等级
        ///// </summary>
        //int Min_Grade
        //{
        //    get;
        //    set;
        //}
        //#endregion

        #endregion

        #region  保存数据
        /// <summary>
        /// 保存数据
        /// </summary>
        void save();
        #endregion

        #region   初始化数据
        /// <summary>
        /// 初始化数据
        /// </summary>
        void init();
        #endregion

        #region  最小对比度250
        /// <summary>
        /// 最小对比度250
        /// </summary>
        HTuple Contrast_min
        {
            get
           ;
            set;
        }
        #endregion

        #region   设置最小宽度的尺寸
        /// <summary>
        /// 设置最小宽度的尺寸
        /// </summary>
        HTuple Element_size_min
        {
            get
              ;
            set;
        }
        #endregion

        #region  保存中间结果
        /// <summary>
        /// 保存中间结果
        /// </summary>
        HTuple Persistence
        {
            get
          ;
            set;
        }
        #endregion

        #region   设置扫描线条数8
        /// <summary>
        /// 设置扫描线条数8
        /// </summary>
        HTuple Num_scanlines
        {
            get
          ;
            set;
        }
        #endregion
    }
    #endregion

    #region   设置数据一维码数据接口
    /// <summary>
    /// 设置数据一维码数据接口
    /// </summary>
    public class Set_BarCodeShuJu
    {
        #region  设置roi的数据
        /// <summary>
        /// 设置roi的数据
        /// </summary>
        /// <param name="ICode"></param>
        /// <param name="hv_Row"></param>
        /// <param name="hv_Column"></param>
        /// <param name="hv_Phi"></param>
        /// <param name="hv_Length1"></param>
        /// <param name="hv_Length2"></param>
        /// <returns></returns>
        public bool Set_Code_ROI(IBarCodeShuJu ICode, HTuple hv_Row, HTuple hv_Column, HTuple hv_Phi
            , HTuple hv_Length1, HTuple hv_Length2)
        {
            bool ok = false;

            //ICode.Hv_Row = hv_Row;
            //ICode.Hv_Column = hv_Column;
            //ICode.Hv_Phi = hv_Phi;
            //ICode.Hv_Length1 = hv_Length1;
            //ICode.Hv_Length2 = hv_Length2;

            ok = true;
            return ok;
        }
        #endregion

        #region   创建读码ID
        /// <summary>
        /// 创建读码ID
        /// </summary>
        /// <param name="ICode"></param>
        /// <returns></returns>
        public bool Create_Code_Id(IBarCodeShuJu ICode)
        {
            bool ok = false;

            HTuple hv_BarCodeHandle;
            //创建一维码模型
            // HOperatorSet.CreateBarCodeModel(new HTuple(), new HTuple(), out hv_BarCodeHandle);
            Create_Code(out hv_BarCodeHandle);
            ICode.Hv_BarCodeHandle = hv_BarCodeHandle;
            ok = true;
            return ok;
        }

        /// <summary>
        /// 创建读码ID
        /// </summary>
        /// <param name="hv_BarCodeHandle"></param>
        void Create_Code(out HTuple hv_BarCodeHandle)
        {
            // Initialize local and output iconic variables 
            //创建一维码模型
            HOperatorSet.CreateBarCodeModel(new HTuple(), new HTuple(), out hv_BarCodeHandle);
            return;
        }
        #endregion

        #region 保存一维码模板
        /// <summary>
        /// 保存一维码模板
        /// </summary>
        /// <param name="ICode">数据接口</param>
        /// <returns></returns>
        public bool write_bar_code(IBarCodeShuJu ICode)
        {
            bool ok = false;
            //   HOperatorSet.WriteBarCodeModel(ICode.Hv_BarCodeHandle, ICode.Bar_code_Path);
            ok = true;
            return ok;
        }
        #endregion

        #region  读取一维码模板
        /// <summary>
        /// 读取一维码模板
        /// </summary>
        /// <param name="ICode">数据接口</param>
        /// <returns></returns>
        public bool read_bar_code(IBarCodeShuJu ICode)
        {
            bool ok = false;
            HTuple barcode;
            // HOperatorSet.ReadBarCodeModel(ICode.Bar_code_Path,out barcode);
            // ICode.Hv_BarCodeHandle = barcode;
            ok = true;
            return ok;
        }
        #endregion

        #region   设置一维码参数
        /// <summary>
        ///  设置一维码参数
        /// </summary>
        /// <param name="ICode"></param>
        /// <param name="contrast_min"></param>
        /// <param name="element_size_min"></param>
        /// <param name="persistence"></param>
        /// <param name="num_scanlines"></param>
        /// <returns></returns>
        public bool Set_CodeBarParameter(IBarCodeShuJu ICode, string contrast_min, string element_size_min, string persistence, string num_scanlines)
        {
            bool ok = false;

            if (contrast_min != null)
            {
                double num = Convert.ToDouble(contrast_min);

                HTuple hv_GenParamValues = num;
                HOperatorSet.SetBarCodeParam(ICode.Hv_BarCodeHandle, "contrast_min", hv_GenParamValues);
                ICode.Contrast_min = hv_GenParamValues;
            }

            if (element_size_min != null)
            {
                double num = Convert.ToDouble(element_size_min);
                HTuple hv_GenParamValues = num;
                HOperatorSet.SetBarCodeParam(ICode.Hv_BarCodeHandle, "element_size_min", hv_GenParamValues);
                ICode.Element_size_min = hv_GenParamValues;
            }

            if (persistence != null)
            {

                double num = Convert.ToDouble(persistence);
                HTuple hv_GenParamValues = num;
                HOperatorSet.SetBarCodeParam(ICode.Hv_BarCodeHandle, "persistence", hv_GenParamValues);
                ICode.Persistence = hv_GenParamValues;
            }

            if (num_scanlines != null)
            {
                double num = Convert.ToDouble(num_scanlines);
                HTuple hv_GenParamValues = num;
                HOperatorSet.SetBarCodeParam(ICode.Hv_BarCodeHandle, "num_scanlines", hv_GenParamValues);
                ICode.Num_scanlines = hv_GenParamValues;
            }

            ok = true;
            return ok;
        }

        #endregion

        #region  显示参数数据
        /// <summary>
        /// 显示输出参数，初始化halcon窗口region
        /// </summary>
        /// <param name="ICode_"></param>
        /// <param name="control"></param>
        /// <param name="halconWinControl_"></param>
        public void Set_showParameterHalconWinControl(IBarCodeShuJu ICode_, Control.ControlCollection control, HalControl.HalconWinControl_ROI halconWinControl_)
        {
            if (halconWinControl_ != null)
            {
                halconWinControl_.DrawRectangle2(ICode_.IOutSide.Mid_col_x, ICode_.IOutSide.Mid_row_y, ICode_.IOutSide.Phi, ICode_.IOutSide.Len1, ICode_.IOutSide.Len2, ICode_.IOutSide);
            }

            Show_CodeBarParamter(ICode_, control);

        }

        /// <summary>
        /// 显示参数数据
        /// </summary>
        /// <param name="ICode"></param>
        /// <param name="control"></param>
        /// <returns></returns>
        bool Show_CodeBarParamter(IBarCodeShuJu ICode, Control.ControlCollection control)
        {
            bool ok = false;
            foreach (Control con in control)
            {
                string name = con.Name;
                if ((con is ComboBox) || (con is TextBox) || (con is CheckBox)||(con is NumericUpDown))
                {
                    switch (name)
                    {
                        #region   条码查找参数
                        case "numericUpDown_contrast_min":
                            con.Text = ICode.Contrast_min.ToString().Replace("\"", "");
                            break;

                        case "numericUpDown_element_size_min":
                            con.Text = ICode.Element_size_min.ToString().Replace("\"", "");
                            break;

                        case "numericUpDown_Persistence":
                            con.Text = ICode.Persistence.ToString().Replace("\"", "");
                            break;

                        case "numericUpDown_Num_scanlines":
                            con.Text = ICode.Num_scanlines.ToString().Replace("\"", "");
                            break;

                        case "hv_CodeType":
                            con.Text = ICode.Hv_CodeType.ToString().Replace("\"", "");
                            break;
                        #endregion

                        #region   等级验证
                        case "Quality_isoiec15416":
                            ((CheckBox)con).Checked = ICode.QualityClass._quality_isoiec15416;
                            break;

                        case "_min_Grade":
                            con.Text = ICode.QualityClass._min_Grade.ToString();
                            break;
                        #endregion

                        #region  训练
                        case "_trained":
                            ((CheckBox)con).Checked = ICode.TrainClass._trained;
                            break;

                        case "_BarCodeTrained":
                            con.Text = ICode.TrainClass._BarCodeTrained;
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
                    Show_CodeBarParamter(ICode, con.Controls);
                }
            }



            ok = true;
            return ok;
        }
        #endregion

        #region  设置读码的格式
        /// <summary>
        /// 设置读码的格式
        /// </summary>
        /// <param name="ICode"></param>
        /// <param name="CodeType"></param>
        /// <returns></returns>
        public bool Set_CodeType(IBarCodeShuJu ICode, string CodeType)
        {
            bool ok = false;
            ICode.Hv_CodeType = CodeType;

            ok = true;
            return ok;
        }
        #endregion

        #region  设置是否启动条码等级验证
        /// <summary>
        /// 设置是否启动等级验证
        /// </summary>
        /// <param name="ICode"></param>
        /// <param name="start_stop"></param>
        /// <returns></returns>
        public bool Set_Quality_isoiec15416(IBarCodeShuJu ICode, bool start_stop)
        {
            bool ok = false;
            ICode.QualityClass._quality_isoiec15416 = start_stop;
            ok = true;
            return ok;
        }

        #endregion

        #region  设置条码的最小等级
        /// <summary>
        /// 设置条码的最小等级
        /// </summary>
        /// <param name="ICode"></param>
        /// <param name="MinGrade"></param>
        /// <returns></returns>
        public bool Set_MinGrade(IBarCodeShuJu ICode, string MinGrade)
        {
            bool ok = false;
            ICode.QualityClass._min_Grade = Convert.ToInt32(MinGrade);
            ok = true;
            return ok;
        }
        #endregion

        #region   设置是否启动训练
        /// <summary>
        /// 设置是否启动训练
        /// </summary>
        /// <param name="ICode"></param>
        /// <param name="trained_"></param>
        /// <returns></returns>
        public bool Set_Trained(IBarCodeShuJu ICode, bool trained_, ref string BarCodeTrained_)
        {
            bool ok = false;

            ICode.TrainClass._trained = trained_;
            if (ICode.Hv_DecodedDataStrings != null)
            {
                ICode.TrainClass._BarCodeTrained = ICode.Hv_DecodedDataStrings.ToString();
            }
            BarCodeTrained_ = ICode.TrainClass._BarCodeTrained;

            ok = true;
            return ok;
        }
        #endregion

        #region   刷新定位点
        /// <summary>
        /// 刷新定位点
        /// </summary>
        /// <param name="ICode"></param>
        /// <returns></returns>
        public bool Set_shua_xin_ding_wei_dian(IBarCodeShuJu ICode)
        {
            bool ok = false;
            if (ICode.GenSuiDian_A != null)
            {
                ICode.GeuSuiDian_X_Col = ICode.IrectShuJuPianYi.Column;
                ICode.GenSuiDian_Y_Row = ICode.IrectShuJuPianYi.Row;
                ICode.GenSuiDian_A = ICode.IrectShuJuPianYi.Angle;
            }
            ok = true;
            return ok;
        }
        #endregion

    }
    #endregion

    //#region  一维码的数据分析器
    ///// <summary>
    ///// 一维码的数据分析器
    ///// </summary>
    //public class BarCode
    //{
    //    #region  读取条码
    //    /// <summary>
    //    /// 读取条码
    //    /// </summary>
    //    /// <param name="ho_Image"></param>
    //    /// <param name="ICode"></param>
    //    /// <returns></returns>
    //    public bool Find_Bar_Code(HObject ho_Image, IBarCodeShuJu ICode)
    //    {
    //        bool ok = false;
    //        HObject ho_Rectangle;
    //        HObject ho_ImageReduced;
    //        HObject ho_SymbolRegions;
    //        HTuple hv_DecodedDataStrings;
    //        HTuple hv_HomMat2D;

    //        HOperatorSet.GenEmptyObj(out ho_Rectangle);
    //        HOperatorSet.GenEmptyObj(out ho_ImageReduced);
    //        HOperatorSet.GenEmptyObj(out ho_SymbolRegions);

    //        ho_Rectangle.Dispose();
    //        HOperatorSet.GenRectangle2(out ho_Rectangle, ICode.IOutSide.Mid_row_y, ICode.IOutSide.Mid_col_x, -ICode.IOutSide.Phi, ICode.IOutSide.Len1,
    //            ICode.IOutSide.Len2);

    //        #region 无用
    //        //         FindBarCode(ho_Image, out ho_Rectangle, out ho_ImageReduced,
    //        //out ho_SymbolRegions, ICode.Hv_Row, ICode.Hv_Column, ICode.Hv_Phi,
    //        //ICode.Hv_Length1, ICode.Hv_Length2, ICode.Hv_BarCodeHandle, ICode.Hv_CodeType,
    //        //out hv_DecodedDataStrings);
    //        #endregion

    //        if (ICode.GeuSuiDian_X_Col != null)
    //        {
    //            HOperatorSet.VectorAngleToRigid(ICode.GenSuiDian_Y_Row, ICode.GeuSuiDian_X_Col, ICode.GenSuiDian_A, ICode.IrectShuJuPianYi.Row, ICode.IrectShuJuPianYi.Column, ICode.IrectShuJuPianYi.Angle, out hv_HomMat2D);
    //            HOperatorSet.AffineTransRegion(ho_Rectangle, out ho_Rectangle, hv_HomMat2D, "nearest_neighbor");
    //        }

    //        ho_ImageReduced.Dispose();
    //        HOperatorSet.ReduceDomain(ho_Image, ho_Rectangle, out ho_ImageReduced);

    //        ho_SymbolRegions.Dispose();
    //        HOperatorSet.FindBarCode(ho_ImageReduced, out ho_SymbolRegions, ICode.Hv_BarCodeHandle,
    //            ICode.Hv_CodeType, out hv_DecodedDataStrings);

    //        ICode.Ho_SymbolRegions.Dispose();
    //        ICode.Ho_SymbolRegions = ho_SymbolRegions;
    //        ICode.Hv_DecodedDataStrings = hv_DecodedDataStrings;

    //        /********手动清空局部缓存************/
    //        ho_ImageReduced.Dispose();

    //        ICode.GenSuiDianYuDingWeiDianDeBianHuanRegion.Dispose();
    //        ICode.GenSuiDianYuDingWeiDianDeBianHuanRegion = ho_Rectangle;

    //        ok = true;
    //        return ok;
    //    }
    //    #endregion

    //    #region   显示数据信息
    //    /// <summary>
    //    /// 显示数据信息
    //    /// </summary>
    //    /// <param name="ICode">数据接口</param>
    //    /// <param name="hwin">显示窗口</param>
    //    /// <returns></returns>
    //    public bool ShowBarCode(IBarCodeShuJu ICode, HWindow hwin)
    //    {
    //        bool ok = false;

    //        bool result_ = true;

    //        if (ICode.Hv_DecodedDataStrings.Length > 0)
    //        {
    //            // ShowCodeBar(ICode.Ho_SymbolRegions, hwin, ICode.Hv_DecodedDataStrings);
    //            HObject ho_Contours;
    //            HOperatorSet.GenEmptyObj(out ho_Contours);
    //            HOperatorSet.GenContourRegionXld(ICode.Ho_SymbolRegions, out ho_Contours, "border");
    //            hwin.DispObj(ho_Contours);
    //            ho_Contours.Dispose();

    //            disp_message(hwin, ICode.Hv_DecodedDataStrings, "image", ICode.IOutSide.Mid_row_y,
    //            ICode.IOutSide.Mid_col_x, "green", "false");

    //            if (ICode.QualityClass._quality_isoiec15416)
    //            {
    //                HTuple barCodeResults_;
    //                HOperatorSet.GetBarCodeResult(ICode.Hv_BarCodeHandle, 0, "quality_isoiec15416", out barCodeResults_);
    //                ICode.Hv_BarCodeResults = barCodeResults_;
    //                disp_message(hwin, ICode.Hv_BarCodeResults, "image", ICode.IOutSide.Mid_row_y,
    //           ICode.IOutSide.Mid_col_x, "green", "false");
    //            }

    //            string str = ICode.Hv_DecodedDataStrings.ToString();

    //            #region   检测是否训练
    //            if (ICode.TrainClass._trained)
    //            {
    //                if (ICode.TrainClass._BarCodeTrained == str)
    //                {
    //                    ICode.TrainClass._result = true;
    //                    //bar_.Trained_Result = true;
    //                }
    //                else
    //                {
    //                    ICode.TrainClass._result = false;
    //                    //bar_.Trained_Result = false;
    //                    result_ = false;
    //                }
    //            }

    //            #endregion

    //            #region   等级验证
    //            if (ICode.QualityClass._quality_isoiec15416)
    //            {
    //                int num = ICode.Hv_BarCodeResults[0].I;
    //                if (ICode.QualityClass._min_Grade < num)
    //                {
    //                    ICode.QualityClass._result = true;
    //                    //bar_.Quality_Result = true;
    //                }
    //                else
    //                {
    //                    ICode.QualityClass._result = false;
    //                    //bar_.Quality_Result = false;
    //                    result_ = false;
    //                }
    //            }
    //            #endregion
    //        }
    //        else
    //        {
    //            result_ = false;
    //        }

    //        if (ICode.IOutSide.Mid_row_y != null)
    //        {
    //            HObject ho_Rectangle;
    //            HOperatorSet.GenEmptyObj(out ho_Rectangle);

    //            HOperatorSet.GenRectangle2(out ho_Rectangle, ICode.IOutSide.Mid_row_y, ICode.IOutSide.Mid_col_x, -ICode.IOutSide.Phi, ICode.IOutSide.Len1, ICode.IOutSide.Len2);
    //            //if (ICode.Ihv_HomMat2D != null)
    //            //{
    //            //    HOperatorSet.AffineTransRegion(ho_Rectangle, out ho_Rectangle, ICode.Ihv_HomMat2D.Hv_HomMat2D, "nearest_neighbor");
    //            //    HOperatorSet.GenContourRegionXld(ho_Rectangle, out ho_Rectangle, "border");
    //            //    //if (result_)
    //            //    //{
    //            //    //    hwin.DispObj(ho_Rectangle);
    //            //    //}
    //            //    //else
    //            //    //{
    //            //    //    hwin.SetColor("red");
    //            //    //    hwin.DispObj(ho_Rectangle);
    //            //    //}
    //            //}
    //            //else
    //            //{

    //            //    //HOperatorSet.GenContourRegionXld(ho_Rectangle, out ho_Rectangle, "border");


    //            //    //hwin.DispObj(ho_Rectangle);
    //            //}
    //            HOperatorSet.GenContourRegionXld(ho_Rectangle, out ho_Rectangle, "border");

    //            if (result_)
    //            {
    //                hwin.DispObj(ho_Rectangle);
    //            }
    //            else
    //            {
    //                hwin.SetColor("red");
    //                hwin.DispObj(ho_Rectangle);
    //                hwin.SetColor("green");
    //            }

    //            ho_Rectangle.Dispose();

    //        }



    //        ok = true;
    //        return ok;
    //    }

    //    #region 无用代码ShowCodeBar
    //    //void ShowCodeBar(HObject ho_SymbolRegions, HWindow hv_WindowHandle, HTuple hv_DecodedDataStrings)
    //    //{
    //    //    // Local iconic variables 

    //    //    HObject ho_Contours;

    //    //    // Local control variables 

    //    //    HTuple hv_Area = null, hv_Row1 = null, hv_Column1 = null;
    //    //    // Initialize local and output iconic variables 
    //    //    HOperatorSet.GenEmptyObj(out ho_Contours);
    //    //    try
    //    //    {
    //    //        ho_Contours.Dispose();
    //    //        HOperatorSet.GenContourRegionXld(ho_SymbolRegions, out ho_Contours, "border");
    //    //        //HOperatorSet.AreaCenter(ho_SymbolRegions, out hv_Area, out hv_Row1, out hv_Column1);
    //    //        //disp_message(hv_WindowHandle, hv_DecodedDataStrings, "image", hv_Row1 + 200,
    //    //        //    hv_Column1 - 700, "black", "true");

    //    //        hv_WindowHandle.DispObj(ho_Contours);

    //    //        return;
    //    //    }
    //    //    catch (HalconException HDevExpDefaultException)
    //    //    {
    //    //        ho_Contours.Dispose();

    //    //        throw HDevExpDefaultException;
    //    //    }
    //    //}
    //    #endregion

    //    void disp_message(HTuple hv_WindowHandle, HTuple hv_String, HTuple hv_CoordSystem,
    // HTuple hv_Row, HTuple hv_Column, HTuple hv_Color, HTuple hv_Box)
    //    {
    //        // Local iconic variables 

    //        // Local control variables 

    //        HTuple hv_Red = null, hv_Green = null, hv_Blue = null;
    //        HTuple hv_Row1Part = null, hv_Column1Part = null, hv_Row2Part = null;
    //        HTuple hv_Column2Part = null, hv_RowWin = null, hv_ColumnWin = null;
    //        HTuple hv_WidthWin = null, hv_HeightWin = null, hv_MaxAscent = null;
    //        HTuple hv_MaxDescent = null, hv_MaxWidth = null, hv_MaxHeight = null;
    //        HTuple hv_R1 = new HTuple(), hv_C1 = new HTuple(), hv_FactorRow = new HTuple();
    //        HTuple hv_FactorColumn = new HTuple(), hv_UseShadow = null;
    //        HTuple hv_ShadowColor = null, hv_Exception = new HTuple();
    //        HTuple hv_Width = new HTuple(), hv_Index = new HTuple();
    //        HTuple hv_Ascent = new HTuple(), hv_Descent = new HTuple();
    //        HTuple hv_W = new HTuple(), hv_H = new HTuple(), hv_FrameHeight = new HTuple();
    //        HTuple hv_FrameWidth = new HTuple(), hv_R2 = new HTuple();
    //        HTuple hv_C2 = new HTuple(), hv_DrawMode = new HTuple();
    //        HTuple hv_CurrentColor = new HTuple();
    //        HTuple hv_Box_COPY_INP_TMP = hv_Box.Clone();
    //        HTuple hv_Color_COPY_INP_TMP = hv_Color.Clone();
    //        HTuple hv_Column_COPY_INP_TMP = hv_Column.Clone();
    //        HTuple hv_Row_COPY_INP_TMP = hv_Row.Clone();
    //        HTuple hv_String_COPY_INP_TMP = hv_String.Clone();

    //        // Initialize local and output iconic variables 
    //        //This procedure displays text in a graphics window.
    //        //
    //        //Input parameters:
    //        //WindowHandle: The WindowHandle of the graphics window, where
    //        //   the message should be displayed
    //        //String: A tuple of strings containing the text message to be displayed
    //        //CoordSystem: If set to 'window', the text position is given
    //        //   with respect to the window coordinate system.
    //        //   If set to 'image', image coordinates are used.
    //        //   (This may be useful in zoomed images.)
    //        //Row: The row coordinate of the desired text position
    //        //   If set to -1, a default value of 12 is used.
    //        //Column: The column coordinate of the desired text position
    //        //   If set to -1, a default value of 12 is used.
    //        //Color: defines the color of the text as string.
    //        //   If set to [], '' or 'auto' the currently set color is used.
    //        //   If a tuple of strings is passed, the colors are used cyclically
    //        //   for each new textline.
    //        //Box: If Box[0] is set to 'true', the text is written within an orange box.
    //        //     If set to' false', no box is displayed.
    //        //     If set to a color string (e.g. 'white', '#FF00CC', etc.),
    //        //       the text is written in a box of that color.
    //        //     An optional second value for Box (Box[1]) controls if a shadow is displayed:
    //        //       'true' -> display a shadow in a default color
    //        //       'false' -> display no shadow (same as if no second value is given)
    //        //       otherwise -> use given string as color string for the shadow color
    //        //
    //        //Prepare window
    //        HOperatorSet.GetRgb(hv_WindowHandle, out hv_Red, out hv_Green, out hv_Blue);
    //        HOperatorSet.GetPart(hv_WindowHandle, out hv_Row1Part, out hv_Column1Part, out hv_Row2Part,
    //            out hv_Column2Part);
    //        HOperatorSet.GetWindowExtents(hv_WindowHandle, out hv_RowWin, out hv_ColumnWin,
    //            out hv_WidthWin, out hv_HeightWin);
    //        HOperatorSet.SetPart(hv_WindowHandle, 0, 0, hv_HeightWin - 1, hv_WidthWin - 1);
    //        //
    //        //default settings
    //        if ((int)(new HTuple(hv_Row_COPY_INP_TMP.TupleEqual(-1))) != 0)
    //        {
    //            hv_Row_COPY_INP_TMP = 12;
    //        }
    //        if ((int)(new HTuple(hv_Column_COPY_INP_TMP.TupleEqual(-1))) != 0)
    //        {
    //            hv_Column_COPY_INP_TMP = 12;
    //        }
    //        if ((int)(new HTuple(hv_Color_COPY_INP_TMP.TupleEqual(new HTuple()))) != 0)
    //        {
    //            hv_Color_COPY_INP_TMP = "";
    //        }
    //        //
    //        hv_String_COPY_INP_TMP = ((("" + hv_String_COPY_INP_TMP) + "")).TupleSplit("\n");
    //        //
    //        //Estimate extentions of text depending on font size.
    //        HOperatorSet.GetFontExtents(hv_WindowHandle, out hv_MaxAscent, out hv_MaxDescent,
    //            out hv_MaxWidth, out hv_MaxHeight);
    //        if ((int)(new HTuple(hv_CoordSystem.TupleEqual("window"))) != 0)
    //        {
    //            hv_R1 = hv_Row_COPY_INP_TMP.Clone();
    //            hv_C1 = hv_Column_COPY_INP_TMP.Clone();
    //        }
    //        else
    //        {
    //            //Transform image to window coordinates
    //            hv_FactorRow = (1.0 * hv_HeightWin) / ((hv_Row2Part - hv_Row1Part) + 1);
    //            hv_FactorColumn = (1.0 * hv_WidthWin) / ((hv_Column2Part - hv_Column1Part) + 1);
    //            hv_R1 = ((hv_Row_COPY_INP_TMP - hv_Row1Part) + 0.5) * hv_FactorRow;
    //            hv_C1 = ((hv_Column_COPY_INP_TMP - hv_Column1Part) + 0.5) * hv_FactorColumn;
    //        }
    //        //
    //        //Display text box depending on text size
    //        hv_UseShadow = 1;
    //        hv_ShadowColor = "gray";
    //        if ((int)(new HTuple(((hv_Box_COPY_INP_TMP.TupleSelect(0))).TupleEqual("true"))) != 0)
    //        {
    //            if (hv_Box_COPY_INP_TMP == null)
    //                hv_Box_COPY_INP_TMP = new HTuple();
    //            hv_Box_COPY_INP_TMP[0] = "#fce9d4";
    //            hv_ShadowColor = "#f28d26";
    //        }
    //        if ((int)(new HTuple((new HTuple(hv_Box_COPY_INP_TMP.TupleLength())).TupleGreater(
    //            1))) != 0)
    //        {
    //            if ((int)(new HTuple(((hv_Box_COPY_INP_TMP.TupleSelect(1))).TupleEqual("true"))) != 0)
    //            {
    //                //Use default ShadowColor set above
    //            }
    //            else if ((int)(new HTuple(((hv_Box_COPY_INP_TMP.TupleSelect(1))).TupleEqual(
    //                "false"))) != 0)
    //            {
    //                hv_UseShadow = 0;
    //            }
    //            else
    //            {
    //                hv_ShadowColor = hv_Box_COPY_INP_TMP[1];
    //                //Valid color?
    //                try
    //                {
    //                    HOperatorSet.SetColor(hv_WindowHandle, hv_Box_COPY_INP_TMP.TupleSelect(
    //                        1));
    //                }
    //                // catch (Exception) 
    //                catch (HalconException HDevExpDefaultException1)
    //                {
    //                    HDevExpDefaultException1.ToHTuple(out hv_Exception);
    //                    hv_Exception = "Wrong value of control parameter Box[1] (must be a 'true', 'false', or a valid color string)";
    //                    throw new HalconException(hv_Exception);
    //                }
    //            }
    //        }
    //        if ((int)(new HTuple(((hv_Box_COPY_INP_TMP.TupleSelect(0))).TupleNotEqual("false"))) != 0)
    //        {
    //            //Valid color?
    //            try
    //            {
    //                HOperatorSet.SetColor(hv_WindowHandle, hv_Box_COPY_INP_TMP.TupleSelect(0));
    //            }
    //            // catch (Exception) 
    //            catch (HalconException HDevExpDefaultException1)
    //            {
    //                HDevExpDefaultException1.ToHTuple(out hv_Exception);
    //                hv_Exception = "Wrong value of control parameter Box[0] (must be a 'true', 'false', or a valid color string)";
    //                throw new HalconException(hv_Exception);
    //            }
    //            //Calculate box extents
    //            hv_String_COPY_INP_TMP = (" " + hv_String_COPY_INP_TMP) + " ";
    //            hv_Width = new HTuple();
    //            for (hv_Index = 0; (int)hv_Index <= (int)((new HTuple(hv_String_COPY_INP_TMP.TupleLength()
    //                )) - 1); hv_Index = (int)hv_Index + 1)
    //            {
    //                HOperatorSet.GetStringExtents(hv_WindowHandle, hv_String_COPY_INP_TMP.TupleSelect(
    //                    hv_Index), out hv_Ascent, out hv_Descent, out hv_W, out hv_H);
    //                hv_Width = hv_Width.TupleConcat(hv_W);
    //            }
    //            hv_FrameHeight = hv_MaxHeight * (new HTuple(hv_String_COPY_INP_TMP.TupleLength()
    //                ));
    //            hv_FrameWidth = (((new HTuple(0)).TupleConcat(hv_Width))).TupleMax();
    //            hv_R2 = hv_R1 + hv_FrameHeight;
    //            hv_C2 = hv_C1 + hv_FrameWidth;
    //            //Display rectangles
    //            HOperatorSet.GetDraw(hv_WindowHandle, out hv_DrawMode);
    //            HOperatorSet.SetDraw(hv_WindowHandle, "fill");
    //            //Set shadow color
    //            HOperatorSet.SetColor(hv_WindowHandle, hv_ShadowColor);
    //            if ((int)(hv_UseShadow) != 0)
    //            {
    //                HOperatorSet.DispRectangle1(hv_WindowHandle, hv_R1 + 1, hv_C1 + 1, hv_R2 + 1, hv_C2 + 1);
    //            }
    //            //Set box color
    //            HOperatorSet.SetColor(hv_WindowHandle, hv_Box_COPY_INP_TMP.TupleSelect(0));
    //            HOperatorSet.DispRectangle1(hv_WindowHandle, hv_R1, hv_C1, hv_R2, hv_C2);
    //            HOperatorSet.SetDraw(hv_WindowHandle, hv_DrawMode);
    //        }
    //        //Write text.
    //        for (hv_Index = 0; (int)hv_Index <= (int)((new HTuple(hv_String_COPY_INP_TMP.TupleLength()
    //            )) - 1); hv_Index = (int)hv_Index + 1)
    //        {
    //            hv_CurrentColor = hv_Color_COPY_INP_TMP.TupleSelect(hv_Index % (new HTuple(hv_Color_COPY_INP_TMP.TupleLength()
    //                )));
    //            if ((int)((new HTuple(hv_CurrentColor.TupleNotEqual(""))).TupleAnd(new HTuple(hv_CurrentColor.TupleNotEqual(
    //                "auto")))) != 0)
    //            {
    //                HOperatorSet.SetColor(hv_WindowHandle, hv_CurrentColor);
    //            }
    //            else
    //            {
    //                HOperatorSet.SetRgb(hv_WindowHandle, hv_Red, hv_Green, hv_Blue);
    //            }
    //            hv_Row_COPY_INP_TMP = hv_R1 + (hv_MaxHeight * hv_Index);
    //            HOperatorSet.SetTposition(hv_WindowHandle, hv_Row_COPY_INP_TMP, hv_C1);
    //            HOperatorSet.WriteString(hv_WindowHandle, hv_String_COPY_INP_TMP.TupleSelect(
    //                hv_Index));
    //        }
    //        //Reset changed window settings
    //        HOperatorSet.SetRgb(hv_WindowHandle, hv_Red, hv_Green, hv_Blue);
    //        HOperatorSet.SetPart(hv_WindowHandle, hv_Row1Part, hv_Column1Part, hv_Row2Part,
    //            hv_Column2Part);

    //        return;
    //    }
    //    #endregion

    //    #region  查找，显示，保存 读码数据
    //    /// <summary>
    //    /// 查找，显示，保存 读码数据
    //    /// </summary>
    //    /// <param name="ho_Image"></param>
    //    /// <param name="ICode"></param>
    //    /// <param name="hwin"></param>
    //    /// <param name="Key"></param>
    //    /// <param name="_dictionary_resulte"></param>
    //    /// <returns></returns>
    //    public bool Find_Show_out(HObject ho_Image, IBarCodeShuJu ICode, HWindow hwin, string Key, ref Dictionary<string, Object> _dictionary_resulte)
    //    {
    //        bool ok = false;
    //        /********************************************************处理**********************************************/
    //        HObject ho_Rectangle;
    //        HObject ho_ImageReduced;
    //        HObject ho_SymbolRegions;
    //        HTuple hv_DecodedDataStrings;
    //        HTuple hv_HomMat2D;

    //        HOperatorSet.GenEmptyObj(out ho_Rectangle);
    //        HOperatorSet.GenEmptyObj(out ho_ImageReduced);
    //        HOperatorSet.GenEmptyObj(out ho_SymbolRegions);

    //        ho_Rectangle.Dispose();
    //        HOperatorSet.GenRectangle2(out ho_Rectangle, ICode.IOutSide.Mid_row_y, ICode.IOutSide.Mid_col_x, -ICode.IOutSide.Phi, ICode.IOutSide.Len1,
    //            ICode.IOutSide.Len2);

    //        if (ICode.GeuSuiDian_X_Col != null)
    //        {
    //            HOperatorSet.VectorAngleToRigid(ICode.GenSuiDian_Y_Row, ICode.GeuSuiDian_X_Col, ICode.GenSuiDian_A, ICode.IrectShuJuPianYi.Row, ICode.IrectShuJuPianYi.Column, ICode.IrectShuJuPianYi.Angle, out hv_HomMat2D);
    //            HOperatorSet.AffineTransRegion(ho_Rectangle, out ho_Rectangle, hv_HomMat2D, "nearest_neighbor");
    //        }

    //        ho_ImageReduced.Dispose();
    //        HOperatorSet.ReduceDomain(ho_Image, ho_Rectangle, out ho_ImageReduced);

    //        ho_SymbolRegions.Dispose();
    //        HOperatorSet.FindBarCode(ho_ImageReduced, out ho_SymbolRegions, ICode.Hv_BarCodeHandle,
    //            ICode.Hv_CodeType, out hv_DecodedDataStrings);

    //        ICode.Ho_SymbolRegions.Dispose();
    //        ICode.Ho_SymbolRegions = ho_SymbolRegions;
    //        ICode.Hv_DecodedDataStrings = hv_DecodedDataStrings;

    //        //bool isSaveResult = false;

    //        /**********************数据分析********************************/
    //        BarCode_Result bar_ = new BarCode_Result();
    //        Key = "BarCode_" + Key;
    //        bar_._tolatName = Key;

    //        Result_Analyisis(ICode, ref bar_);
    //        _dictionary_resulte.Add(Key, bar_);

    //        /**********************************************显示结果数据********************************************/
    //        if (bar_._Result)
    //        {
    //            // ShowCodeBar(ICode.Ho_SymbolRegions, hwin, ICode.Hv_DecodedDataStrings);
    //            HObject ho_Contours;
    //            HOperatorSet.GenEmptyObj(out ho_Contours);
    //            ho_Contours.Dispose();
    //            HOperatorSet.GenContourRegionXld(ICode.Ho_SymbolRegions, out ho_Contours, "border");
    //            hwin.DispObj(ho_Contours);

    //            disp_message(hwin, ICode.Hv_DecodedDataStrings, "image", ICode.IOutSide.Mid_row_y,
    //            ICode.IOutSide.Mid_col_x, "green", "false");

    //            if (ICode.QualityClass._quality_isoiec15416)
    //            {
    //                HTuple barCodeResults_;
    //                HOperatorSet.GetBarCodeResult(ICode.Hv_BarCodeHandle, 0, "quality_isoiec15416", out barCodeResults_);
    //                ICode.Hv_BarCodeResults = barCodeResults_;
    //                disp_message(hwin, ICode.Hv_BarCodeResults, "image", ICode.IOutSide.Mid_row_y,
    //           ICode.IOutSide.Mid_col_x, "green", "false");
    //            }
    //        }

    //        #region  无用代码
    //        /*********************************保存数据************************************************************/
    //        //BarCode_Result bar_ = new BarCode_Result();
    //        //Key = Key + "BarCode";
    //        //if (isSaveResult)
    //        //{
    //        //    string str = ICode.Hv_DecodedDataStrings.ToString();

    //        //    bar_.Hv_DecodedDataStrings = ICode.Hv_DecodedDataStrings;

    //        //    #region   检测是否训练
    //        //    if (ICode.TrainClass._trained)
    //        //    {
    //        //        bar_.Trained = true;
    //        //        if (ICode.TrainClass._BarCodeTrained == str)
    //        //        {
    //        //            ICode.TrainClass._result = true;
    //        //            //bar_.Trained_Result = true;
    //        //        }
    //        //        else
    //        //        {
    //        //            ICode.TrainClass._result = false;
    //        //            //bar_.Trained_Result = false;
    //        //            bar_._Result = false;
    //        //        }
    //        //    }
    //        //    else
    //        //    {
    //        //        bar_.Trained = false;
    //        //        //bar_.Trained_Result = false;
    //        //    }
    //        //    #endregion

    //        //    #region   等级验证
    //        //    if (ICode.QualityClass._quality_isoiec15416)
    //        //    {
    //        //        bar_.Quality_Isoiec15416 = true;
    //        //        int num = ICode.Hv_BarCodeResults[0].I;
    //        //        if (ICode.QualityClass._min_Grade < num)
    //        //        {
    //        //            ICode.QualityClass._result = true;
    //        //            //bar_.Quality_Result = true;
    //        //        }
    //        //        else
    //        //        {
    //        //            ICode.QualityClass._result = false;
    //        //            //bar_.Quality_Result = false;
    //        //            bar_._Result = false;
    //        //        }
    //        //    }
    //        //    else
    //        //    {
    //        //        bar_.Quality_Isoiec15416 = false;
    //        //        //bar_.Quality_Result = false;
    //        //    }
    //        //    #endregion

    //        //    _dictionary_resulte.Add(Key, bar_);

    //        //}
    //        //else
    //        //{
    //        //    bar_._Result = false;
    //        //    _dictionary_resulte.Add(Key, null);
    //        //}
    //        #endregion

    //        /***********************************************显示 提示正确还是错误******************************************/
    //        HOperatorSet.GenContourRegionXld(ho_Rectangle, out ho_Rectangle, "border");

    //        if (bar_._Result)
    //        {
    //            //HOperatorSet.GenContourRegionXld(ho_Rectangle, out ho_Rectangle, "border");
    //            hwin.DispObj(ho_Rectangle);
    //            ok = true;
    //        }
    //        else
    //        {
    //            hwin.SetColor("red");
    //            hwin.DispObj(ho_Rectangle);
    //            hwin.SetColor("green");
    //        }

    //        //ho_Rectangle.Dispose();
    //        ho_ImageReduced.Dispose();

    //        ICode.GenSuiDianYuDingWeiDianDeBianHuanRegion.Dispose();
    //        ICode.GenSuiDianYuDingWeiDianDeBianHuanRegion = ho_Rectangle;

    //        return ok;
    //    }
    //    #endregion

    //    #region   结果分析
    //    /// <summary>
    //    /// 结果分析
    //    /// </summary>
    //    /// <param name="ICode"></param>
    //    /// <param name="bar_"></param>
    //    void Result_Analyisis(IBarCodeShuJu ICode, ref BarCode_Result bar_)
    //    {
    //        if (ICode.Hv_DecodedDataStrings.Length > 0)
    //        {
    //            string str = ICode.Hv_DecodedDataStrings.ToString();

    //            bar_.Hv_DecodedDataStrings = ICode.Hv_DecodedDataStrings;

    //            bar_._Result = true;
    //            bar_._tolatResult = true;

    //            #region   检测是否训练
    //            if (ICode.TrainClass._trained)
    //            {
    //                bar_.Trained = true;
    //                if (ICode.TrainClass._BarCodeTrained == str)
    //                {
    //                    ICode.TrainClass._result = true;
    //                    //bar_.Trained_Result = true;
    //                }
    //                else
    //                {
    //                    ICode.TrainClass._result = false;
    //                    //bar_.Trained_Result = false;
    //                    bar_._Result = false;
    //                    bar_._tolatResult = false;
    //                }
    //            }
    //            else
    //            {
    //                bar_.Trained = false;
    //                //bar_.Trained_Result = false;
    //            }
    //            #endregion

    //            #region   等级验证
    //            if (ICode.QualityClass._quality_isoiec15416)
    //            {
    //                bar_.Quality_Isoiec15416 = true;
    //                int num = ICode.Hv_BarCodeResults[0].I;
    //                if (ICode.QualityClass._min_Grade < num)
    //                {
    //                    ICode.QualityClass._result = true;
    //                    //bar_.Quality_Result = true;
    //                }
    //                else
    //                {
    //                    ICode.QualityClass._result = false;
    //                    //bar_.Quality_Result = false;
    //                    bar_._Result = false;
    //                    bar_._tolatResult = false;
    //                }
    //            }
    //            else
    //            {
    //                bar_.Quality_Isoiec15416 = false;
    //                //bar_.Quality_Result = false;
    //            }
    //            #endregion
    //        }
    //        else
    //        {
    //            bar_._Result = false;
    //            bar_._tolatResult = false;
    //        }

    //    }
    //    #endregion
    //}
    //#endregion

    #region  一维码的结果
    /// <summary>
    /// 一维码的结果
    /// </summary>
    public class BarCode_Result : MultTree.ClassResultFather
    {
        #region  无用代码
        ///// <summary>
        ///// 条码的质量
        ///// </summary>
        //public HTuple Hv_Quality;
        #endregion

        /// <summary>
        /// 条码的结果
        /// </summary>
        public HTuple Hv_DecodedDataStrings;

        /// <summary>
        ///是否有训练 
        /// </summary>
        public bool Trained = false;

        ///// <summary>
        ///// 训练后对比的结果
        ///// </summary>
        //public bool Trained_Result = true;

        /// <summary>
        /// 是否有启动等级验证
        /// </summary>
        public bool Quality_Isoiec15416 = false;

        ///// <summary>
        ///// 等级验证的结果
        ///// </summary>
        //public bool Quality_Result = true;

        /// <summary>
        /// 整个数据的结果
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

            if (this._tolatResult)
            {
                str = this._tolatName + ":检测成功--" + Hv_DecodedDataStrings.ToString();
            }
            else
            {
                str = this._tolatName + ":检测失败--";
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
            str_array[0] = this._tolatName;
            if (this._tolatResult)
            {
                str_array[1] = this.Hv_DecodedDataStrings.ToString();
            }
            else
            {
                str_array[1] = "检测失败。";
            }
            ok = true;
            return ok;
        }

    }
    #endregion
}
