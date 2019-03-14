using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HalconDotNet;
using System.Windows.Forms;
using RectLibrary;
using HalControl.ROI.Rectangle2;
using HalControl;





namespace DataCodeLibrary
{
    #region  二维码数据
    /// <summary>
    /// 二维码数据
    /// </summary>
    [Serializable]
    public class DataCodeShuJu : MultTree.ToolDateFather, IDataCodeShuJu
    {
        #region  全局变量

        #region  region的接口数据

        /// <summary>
        /// region的接口数据
        /// </summary>
        IOutsideRectangle2ROI _iOutSide;
        #endregion

        #region  创建code2时的参数
        /// <summary>
        /// 创建时二维码读取的格式
        /// </summary>
        [NonSerialized]
        HTuple _create_hv_SymbolType = null;

        /// <summary>
        /// 创建时二维码要设置的参数名称
        /// </summary>
        [NonSerialized]
        HTuple _create_hv_GenParamNames1 = null;

        /// <summary>
        /// 创建时二维码要设置的参数名称，对应的参数名
        /// </summary>
        [NonSerialized]
        HTuple _create_hv_GenParamValues1 = null;

        #endregion

        #region  查找时的数据
        /// <summary>
        /// 查找时的数据
        /// </summary>
        [NonSerialized]
        HTuple _find_hv_GenParamNames = null;

        /// <summary>
        /// 查找时的数据
        /// </summary>
        [NonSerialized]
        HTuple _find_hv_GenParaValues = null;
        #endregion

        #region   二维码查找的句柄
        /// <summary>
        /// 二维码查找的句柄
        /// </summary>
        [NonSerialized]
        HTuple _hv_DataCodeHandle = null;
        #endregion

        #region  查找输出的数据

        /// <summary>
        /// 查找输出的条码
        /// </summary>
        [NonSerialized]
        HTuple _hv_DecodedDataStrings = null;

        /// <summary>
        /// 查找输出的条码
        /// </summary>
        [NonSerialized]
        HObject ho_SymbolXLDs = null;
        #endregion

        //#region  放射变换矩阵
        ///// <summary>
        ///// 需要防射变化
        ///// </summary>
        //IRectShuJuHv_HomMat2D _ihv_HomMat2D = null;
        //#endregion

        #endregion

        #region   属性

        #region   创建时二维码读取的格式
        /// <summary>
        /// 创建时二维码读取的格式
        /// </summary>
        public HTuple Create_hv_SymbolType
        {
            get
            {
                if (_create_hv_SymbolType == null)
                {
                    this._create_hv_SymbolType = "Data Matrix ECC 200";
                }
                return _create_hv_SymbolType;
            }
            set { _create_hv_SymbolType = value; }
        }

        /// <summary>
        /// 创建时二维码要设置的参数名称
        /// </summary>
        public HTuple Create_hv_GenParamNames1
        {
            get
            {
                if (_create_hv_GenParamNames1 == null)
                {
                    this._create_hv_GenParamNames1 = "default_parameters";
                }
                return _create_hv_GenParamNames1;
            }
            set { _create_hv_GenParamNames1 = value; }
        }

        /// <summary>
        /// 创建时二维码要设置的参数名称，对应的参数名
        /// </summary>
        public HTuple Create_hv_GenParamValues1
        {
            get
            {
                if (_create_hv_GenParamValues1 == null)
                {
                    this._create_hv_GenParamValues1 = "maximum_recognition";
                }
                return _create_hv_GenParamValues1;
            }
            set { _create_hv_GenParamValues1 = value; }
        }
        #endregion

        #region     查找时的数据
        /// <summary>
        /// 查找时的数据
        /// </summary>
        public HTuple Find_hv_GenParamNames1
        {
            get
            {
                if (_find_hv_GenParamNames == null)
                {
                    this._find_hv_GenParamNames = "stop_after_result_num";
                }
                return _find_hv_GenParamNames;
            }
            set { _find_hv_GenParamNames = value; }
        }

        /// <summary>
        /// 查找时的数据
        /// </summary>
        public HTuple Find_hv_GenParaValues1
        {
            get
            {
                if (_find_hv_GenParaValues == null)
                {
                    _find_hv_GenParaValues = 1;
                }
                return _find_hv_GenParaValues;
            }
            set { _find_hv_GenParaValues = value; }
        }
        #endregion

        #region    查找输出的条码
        /// <summary>
        /// 查找输出的条码
        /// </summary>
        public HTuple Hv_DecodedDataStrings
        {
            get { return _hv_DecodedDataStrings; }
            set { _hv_DecodedDataStrings = value; }
        }

        /// <summary>
        /// 查找输出的条码
        /// </summary>
        public HObject Ho_SymbolXLDs
        {
            get
            {
                if (ho_SymbolXLDs == null)
                {
                    HOperatorSet.GenEmptyObj(out ho_SymbolXLDs);
                    ho_SymbolXLDs.Dispose();
                }
                return ho_SymbolXLDs;
            }
            set
            {

                if (ho_SymbolXLDs == null)
                    HOperatorSet.GenEmptyObj(out ho_SymbolXLDs);

                ho_SymbolXLDs.Dispose();

                ho_SymbolXLDs = value;
            }
        }
        #endregion

        #region   二维码查找的句柄
        /// <summary>
        /// 二维码查找的句柄
        /// </summary>
        public HTuple Hv_DataCodeHandle
        {
            get
            {
                if (_hv_DataCodeHandle == null)
                {
                    /*********创建二维码句柄*********/
                    HOperatorSet.CreateDataCode2dModel(this.Create_hv_SymbolType, new HTuple(), new HTuple(),
                        out this._hv_DataCodeHandle);
                    HOperatorSet.SetDataCode2dParam(this._hv_DataCodeHandle, this.Create_hv_GenParamNames1, this.Create_hv_GenParamValues1);
                    //HOperatorSet.SetDataCode2dParam(this._hv_DataCodeHandle, "polarity", "dark_on_light");
                }
                return _hv_DataCodeHandle;
            }
            set { _hv_DataCodeHandle = value; }
        }
        #endregion

        //#region    需要防射变化
        ///// <summary>
        ///// 需要防射变化
        ///// </summary>
        //public IRectShuJuHv_HomMat2D Ihv_HomMat2D
        //{
        //    get { return _ihv_HomMat2D; }
        //    set { _ihv_HomMat2D = value; }
        //}
        //#endregion

        #region   region的接口数据
        /// <summary>
        /// region的接口数据
        /// </summary>
        public IOutsideRectangle2ROI IOutSide
        {
            get
            {
                if (_iOutSide == null)
                {
                    _iOutSide = new HalControl.ROI.Rectangle2.OutsideRectangle2ROI();
                    _iOutSide.Len1 = 100;
                    _iOutSide.Len2 = 100;
                    _iOutSide.Mid_col_x = 100;
                    _iOutSide.Mid_row_y = 100;
                    _iOutSide.Phi = 0;
                }
                return _iOutSide;
            }
            set
            {
                if (_iOutSide == null)
                {
                    _iOutSide = new OutsideRectangle2ROI();
                    _iOutSide.Len1 = 100;
                    _iOutSide.Len2 = 100;
                    _iOutSide.Mid_col_x = 100;
                    _iOutSide.Mid_row_y = 100;
                    _iOutSide.Phi = 0;
                }
                _iOutSide = value;
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

        #endregion

        #region  序列化数据

        #region  截取region的数据
        ///// <summary>
        ///// 截取roi的端点
        ///// </summary>
        //Object _hv_Row1_1;

        ///// <summary>
        ///// 截取roi的端点
        ///// </summary>
        //Object _hv_Column1_1;

        ///// <summary>
        ///// 截取roi的端点
        ///// </summary>
        //Object _hv_Row2_1;

        ///// <summary>
        ///// 截取roi的端点
        ///// </summary>
        //Object _hv_Column2_1;

        Object mid_row_y_1;

        Object mid_col_x_1;

        Object len1_1;

        Object len2_1;

        Object angle_1;

        #endregion

        #region  创建code2时的参数
        /// <summary>
        /// 创建时二维码读取的格式
        /// </summary>
        Object _create_hv_SymbolType_1;

        /// <summary>
        /// 创建时二维码要设置的参数名称
        /// </summary>
        Object _create_hv_GenParamNames_1;

        /// <summary>
        /// 创建时二维码要设置的参数名称，对应的参数名
        /// </summary>
        Object _create_hv_GenParamValues_1;

        #endregion

        #region  查找时的数据
        /// <summary>
        /// 查找时的数据
        /// </summary>
        Object _find_hv_GenParamNames_1;

        /// <summary>
        /// 查找时的数据
        /// </summary>
        Object _find_hv_GenParaValues_1;
        #endregion

        #region   二维码查找的句柄
        /// <summary>
        /// 二维码查找的句柄
        /// </summary>
        Object hv_DataCodeHandle_1;
        #endregion

        #endregion

        #region  构造函数
        /// <summary>
        /// 构造函数
        /// </summary>
        public DataCodeShuJu()
        {
            HOperatorSet.GenEmptyObj(out ho_SymbolXLDs);
            ho_SymbolXLDs.Dispose();
        }
        #endregion

        #region  保存数据
        /// <summary>
        /// 保存数据
        /// </summary>
        public override void save()
        {
            base.save();

            #region   截取region的数据
            mid_row_y_1 = this.IOutSide.Mid_row_y;

            mid_col_x_1 = this.IOutSide.Mid_col_x;

            len1_1 = this.IOutSide.Len1;

            len2_1 = this.IOutSide.Len2;

            angle_1 = this.IOutSide.Phi;

            #endregion

            #region  创建code2时的参数
            _create_hv_SymbolType_1 = _create_hv_SymbolType;

            _create_hv_GenParamNames_1 = _create_hv_GenParamNames1;

            _create_hv_GenParamValues_1 = _create_hv_GenParamValues1;

            #endregion

            #region  查找时的数据
            _find_hv_GenParamNames_1 = _find_hv_GenParamNames;

            _find_hv_GenParaValues_1 = _find_hv_GenParaValues;
            #endregion

            #region   二维码查找的句柄
            hv_DataCodeHandle_1 = Hv_DataCodeHandle;
            #endregion

        }
        #endregion

        #region  初始化数据
        /// <summary>
        /// 初始化数据
        /// </summary>
        public override void init()
        {
            base.init();

            #region  截取region的数据

            this.IOutSide.Mid_row_y = (HTuple)mid_row_y_1;

            this.IOutSide.Mid_col_x = (HTuple)mid_col_x_1;

            this.IOutSide.Len1 = (HTuple)len1_1;

            this.IOutSide.Len2 = (HTuple)len2_1;

            this.IOutSide.Phi = (HTuple)angle_1;

            #endregion

            #region  创建code2时的参数
            _create_hv_SymbolType = (HTuple)_create_hv_SymbolType_1;

            _create_hv_GenParamNames1 = (HTuple)_create_hv_GenParamNames_1;

            _create_hv_GenParamValues1 = (HTuple)_create_hv_GenParamValues_1;

            #endregion

            #region  查找时的数据
            _find_hv_GenParamNames = (HTuple)_find_hv_GenParamNames_1;

            _find_hv_GenParaValues = (HTuple)_find_hv_GenParaValues_1;
            #endregion

            #region   二维码查找的句柄
            _hv_DataCodeHandle = (HTuple)hv_DataCodeHandle_1;
            #endregion

        }
        #endregion

        #region   检测
        public override bool analyze_show(HWindow hwin, string Key, ref Dictionary<string, object> _dictionary_resulte)
        {
            bool ok = false;

            /****************************处理********************************/
            HObject ho_ROI_0, ho_SymbolXLDs, ho_ImageReduced;
            HOperatorSet.GenEmptyObj(out ho_SymbolXLDs);
            HTuple hv_ResultHandles;
            HTuple hv_DecodedDataStrings, hv_modMat2D;

            HOperatorSet.GenRectangle2(out ho_ROI_0, IOutSide.Mid_row_y, IOutSide.Mid_col_x, -IOutSide.Phi, IOutSide.Len1, IOutSide.Len2);

            if (IrectShuJuPianYi != null)
            {
                HOperatorSet.VectorAngleToRigid(GenSuiDian_Y_Row, GeuSuiDian_X_Col, GenSuiDian_A, IrectShuJuPianYi.Row, IrectShuJuPianYi.Column, IrectShuJuPianYi.Angle, out hv_modMat2D);
                HOperatorSet.AffineTransRegion(ho_ROI_0, out ho_ROI_0, hv_modMat2D, "nearest_neighbor");
            }
            HOperatorSet.ReduceDomain(this.ImageFather.Ho_image, ho_ROI_0, out ho_ImageReduced);



            HOperatorSet.FindDataCode2d(ho_ImageReduced, out ho_SymbolXLDs, Hv_DataCodeHandle,
            Find_hv_GenParamNames1, Find_hv_GenParaValues1, out hv_ResultHandles, out hv_DecodedDataStrings);

            Ho_SymbolXLDs = ho_SymbolXLDs;
            Hv_DecodedDataStrings = hv_DecodedDataStrings;

            /***********************分析结果****************************/
            DateCode_Result DateCodeResult_ = new DateCode_Result();
            HTuple hv_Area, hv_Row, hv_Column, hv_PointOrder, hv_Number;

            HOperatorSet.AreaCenterXld(Ho_SymbolXLDs, out hv_Area, out hv_Row, out hv_Column, out hv_PointOrder);
            if (hv_Area.Length > 0)
            {
                DateCodeResult_.AllResult = true;
                DateCodeResult_._tolatResult = true;
                DateCodeResult_.Hv_DecodedDataStrings = this.Hv_DecodedDataStrings;
            }
            else
            {
                DateCodeResult_.AllResult = false;
                DateCodeResult_._tolatResult = false;
            }

            /*********************保存结果***************************/
            Key = "DataCode_" + Key;
            DateCodeResult_._tolatName = Key;

            _dictionary_resulte.Add(Key, DateCodeResult_);
            /***************************显示对错***********************************/
            show(hwin);

            if (DateCodeResult_._tolatResult)
            {
                ok = true;
            }

            return ok;
        }
        #endregion

        #region  显示
        public override bool show(HWindow hwin)
        {
            bool ok = false;

            HTuple hv_modMat2D;
            HObject ho_ROI_0;
            //HOperatorSet.GenRectangle1(out ho_ROI_0, iDateCode_.IOutSide.Row_y1, iDateCode_.IOutSide.Col_x1, iDateCode_.IOutSide.Row_y2, iDateCode_.IOutSide.Col_x2);

            HOperatorSet.GenRectangle2(out ho_ROI_0, IOutSide.Mid_row_y, IOutSide.Mid_col_x, IOutSide.Phi, IOutSide.Len1, IOutSide.Len2);

            /***************************显示查找的区域***************************************/

            if (IrectShuJuPianYi != null)
            {
                HOperatorSet.VectorAngleToRigid(GenSuiDian_Y_Row, GeuSuiDian_X_Col, GenSuiDian_A, IrectShuJuPianYi.Row, IrectShuJuPianYi.Column, IrectShuJuPianYi.Angle, out hv_modMat2D);
                HOperatorSet.AffineTransRegion(ho_ROI_0, out ho_ROI_0, hv_modMat2D, "nearest_neighbor");
            }


            /***********显示结果***********/



            if (Ho_SymbolXLDs.IsInitialized())
            {
                HTuple hv_Area, hv_Row, hv_Column, hv_PointOrder, hv_Number;
                HOperatorSet.AreaCenterXld(Ho_SymbolXLDs, out hv_Area, out hv_Row, out hv_Column, out hv_PointOrder);

                if (hv_Area.Length > 0)
                {
                    HOperatorSet.GenContourRegionXld(ho_ROI_0, out ho_ROI_0, "border");
                    hwin.DispObj(ho_ROI_0);

                    HOperatorSet.CountObj(Ho_SymbolXLDs, out hv_Number);

                    HTuple end_val47 = hv_Number - 1;
                    HTuple step_val47 = 1;
                    HObject ho_ObjectSelected;
                    HOperatorSet.GenEmptyObj(out ho_ObjectSelected);

                    for (HTuple hv_Index = 0; hv_Index.Continue(end_val47, step_val47); hv_Index = hv_Index.TupleAdd(step_val47))
                    {
                        if (HDevWindowStack.IsOpen())
                        {
                            HOperatorSet.SetLineWidth(HDevWindowStack.GetActive(), 100);
                        }
                        disp_message(hwin, Hv_DecodedDataStrings.TupleSelect(hv_Index),
                            "image", hv_Row.TupleSelect(hv_Index), hv_Column.TupleSelect(hv_Index),
                            "green", "false");

                        ho_ObjectSelected.Dispose();
                        HOperatorSet.SelectObj(Ho_SymbolXLDs, out ho_ObjectSelected, hv_Index + 1);
                        hwin.DispObj(ho_ObjectSelected);
                    }
                }
                else
                {
                    hwin.SetColor("red");
                    HOperatorSet.GenContourRegionXld(ho_ROI_0, out ho_ROI_0, "border");
                    hwin.DispObj(ho_ROI_0);
                    hwin.SetColor("green");
                }
            }
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
    }
    #endregion

    #region  数据的接口
    /// <summary>
    /// 二维码数据接口
    /// </summary>
    public interface IDataCodeShuJu : IOutsideRectangle2, MultTree.IToolDateFather
    {
        #region   属性

        #region   创建时二维码读取的格式
        /// <summary>
        /// 创建时二维码读取的格式
        /// </summary>
        HTuple Create_hv_SymbolType
        {
            get;
            set;
        }

        /// <summary>
        /// 创建时二维码要设置的参数名称
        /// </summary>
        HTuple Create_hv_GenParamNames1
        {
            get;
            set;
        }

        /// <summary>
        /// 创建时二维码要设置的参数名称，对应的参数名
        /// </summary>
        HTuple Create_hv_GenParamValues1
        {
            get;
            set;
        }
        #endregion

        #region     查找时的数据
        /// <summary>
        /// 查找时的数据
        /// </summary>
        HTuple Find_hv_GenParamNames1
        {
            get;
            set;
        }

        /// <summary>
        /// 查找时的数据
        /// </summary>
        HTuple Find_hv_GenParaValues1
        {
            get;
            set;
        }
        #endregion

        #region    查找输出的条码
        /// <summary>
        /// 查找输出的条码
        /// </summary>
        HTuple Hv_DecodedDataStrings
        {
            get;
            set;
        }

        /// <summary>
        /// 查找输出的条码
        /// </summary>
        HObject Ho_SymbolXLDs
        {
            get
          ;
            set
          ;
        }
        #endregion

        #region   二维码查找的句柄
        /// <summary>
        /// 二维码查找的句柄
        /// </summary>
        HTuple Hv_DataCodeHandle
        {
            get;
            set;
        }
        #endregion

        #endregion

        #region 数据保存
        /// <summary>
        /// 数据保存
        /// </summary>
        void save();
        #endregion

        #region  初始化数据
        /// <summary>
        /// 初始化数据
        /// </summary>
        void init();
        #endregion

    }
    #endregion

    #region  数据设置器
    /// <summary>
    /// 数据设置器
    /// </summary>
    internal class Set_DataCodeShuJu
    {
        #region    设置创建code2时的参数
        /// <summary>
        ///  设置创建code2时的参数
        /// </summary>
        internal void Set_createCode2Paramter(IDataCodeShuJu iDateCode2_, string _create_hv_SymbolType, string _create_hv_GenParamNames, string _create_hv_GenParamValues)
        {
            if (_create_hv_SymbolType != null)
            {
                iDateCode2_.Create_hv_SymbolType = _create_hv_SymbolType;
            }
            if (_create_hv_GenParamNames != null)
            {
                iDateCode2_.Create_hv_GenParamNames1 = _create_hv_GenParamNames;
            }
            if (_create_hv_GenParamValues != null)
            {
                iDateCode2_.Create_hv_GenParamValues1 = _create_hv_GenParamValues;
            }

        }
        #endregion

        #region 设置查找时的数据
        /// <summary>
        /// 设置查找时的数据
        /// </summary>
        /// <param name="iDateCode2_"></param>
        /// <param name="_find_hv_GenParamNames"></param>
        /// <param name="_find_hv_GenParaValues"></param>
        internal void Set_findCode2Parameter(IDataCodeShuJu iDateCode2_, string _find_hv_GenParamNames, string _find_hv_GenParaValues)
        {
            if (_find_hv_GenParamNames != null)
            {
                iDateCode2_.Find_hv_GenParamNames1 = _find_hv_GenParamNames;
            }

            if (_find_hv_GenParaValues != null)
            {
                iDateCode2_.Find_hv_GenParaValues1 = Convert.ToDouble(_find_hv_GenParaValues);
            }
        }
        #endregion

        #region  创建code2句柄
        /// <summary>
        /// 创建code2句柄
        /// </summary>
        /// <param name="iDateCode2_"></param>
        internal void Set_createCode2(IDataCodeShuJu iDateCode2_)
        {
            HTuple hv_DataCodeHandle;
            HOperatorSet.CreateDataCode2dModel(iDateCode2_.Create_hv_SymbolType, iDateCode2_.Create_hv_GenParamNames1, iDateCode2_.Create_hv_GenParamValues1,
      out hv_DataCodeHandle);

            iDateCode2_.Hv_DataCodeHandle = hv_DataCodeHandle;

        }
        #endregion

        #region  输出参数到窗体
        /// <summary>
        /// 显示输出参数，初始化halcon窗口region
        /// </summary>
        /// <param name="iDateCode2_"></param>
        /// <param name="control"></param>
        /// <param name="halconWinControl_"></param>
        internal void Set_showParameterHalconWinControl(IDataCodeShuJu iDateCode2_, Control.ControlCollection control, HalControl.HalconWinControl_ROI halconWinControl_)
        {
            if (halconWinControl_ != null)
            {
                halconWinControl_.DrawRectangle2(iDateCode2_.IOutSide.Mid_col_x, iDateCode2_.IOutSide.Mid_row_y, iDateCode2_.IOutSide.Phi, iDateCode2_.IOutSide.Len1, iDateCode2_.IOutSide.Len2, iDateCode2_.IOutSide);
            }
            Set_showParameter(iDateCode2_, control);
        }


        /// <summary>
        /// 输出参数到窗体
        /// </summary>
        /// <param name="iDateCode2_"></param>
        /// <param name="control"></param>
        void Set_showParameter(IDataCodeShuJu iDateCode2_, Control.ControlCollection control)
        {
            foreach (Control con in control)
            {
                string name = con.Name;
                if ((con is ComboBox) || (con is TextBox) || (con is RichTextBox) || (con is NumericUpDown))
                {
                    switch (name)
                    {

                        #region 显示创建时的参数
                        case "Create_hv_SymbolType":
                            con.Text = iDateCode2_.Create_hv_SymbolType.ToString().Replace("\"", "");
                            break;

                        case "Create_hv_GenParamNames":
                            con.Text = iDateCode2_.Create_hv_GenParamNames1.ToString().Replace("\"", "");
                            break;

                        case "Create_hv_GenParamValues":
                            con.Text = iDateCode2_.Create_hv_GenParamValues1.ToString().Replace("\"", "");
                            break;
                        #endregion

                        #region  显示查找时测参数

                        case "Find_hv_GenParamNames":
                            con.Text = iDateCode2_.Find_hv_GenParamNames1.ToString().Replace("\"", "");
                            break;

                        case "numericUpDown_Find_hv_GenParaValues":
                            con.Text = iDateCode2_.Find_hv_GenParaValues1.ToString().Replace("\"", "");
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
                    Set_showParameter(iDateCode2_, con.Controls);
                }
            }
        }
        #endregion

        #region  刷新定位点
        /// <summary>
        /// 刷新定位点
        /// </summary>
        /// <returns></returns>
        public bool Set_ShuaXinDingWeiDian(IDataCodeShuJu iDateCode2_)
        {
            bool ok = false;
            if (iDateCode2_.IrectShuJuPianYi != null)
            {
                iDateCode2_.GenSuiDian_A = iDateCode2_.IrectShuJuPianYi.Angle;
                iDateCode2_.GeuSuiDian_X_Col = iDateCode2_.IrectShuJuPianYi.Column;
                iDateCode2_.GenSuiDian_Y_Row = iDateCode2_.IrectShuJuPianYi.Row;
            }
            ok = true;
            return ok;
        }
        #endregion
    }
    #endregion

    //#region  数据分析器
    ///// <summary>
    ///// 数据分析器
    ///// </summary>
    //public class DataCode
    //{
    //    #region  查找条码
    //    /// <summary>
    //    /// 查找条码
    //    /// </summary>
    //    /// <param name="iDateCode_"></param>
    //    /// <param name="ho_Image"></param>
    //    /// <returns></returns>
    //    public bool DateCodeFind(IDataCodeShuJu iDateCode_, HObject ho_Image)
    //    {
    //        bool ok = false;
    //        HObject ho_ROI_0, ho_SymbolXLDs, ho_ImageReduced;
    //        HOperatorSet.GenEmptyObj(out ho_SymbolXLDs);
    //        HTuple hv_ResultHandles;
    //        HTuple hv_DecodedDataStrings;
    //        HTuple hv_modMat2D;

    //        HOperatorSet.GenRectangle2(out ho_ROI_0, iDateCode_.IOutSide.Mid_row_y, iDateCode_.IOutSide.Mid_col_x, iDateCode_.IOutSide.Phi, iDateCode_.IOutSide.Len1, iDateCode_.IOutSide.Len2);

    //        if (iDateCode_.GenSuiDian_A != null)
    //        {
    //            HOperatorSet.VectorAngleToRigid(iDateCode_.GenSuiDian_Y_Row, iDateCode_.GeuSuiDian_X_Col, iDateCode_.GenSuiDian_A, iDateCode_.IrectShuJuPianYi.Row, iDateCode_.IrectShuJuPianYi.Column, iDateCode_.IrectShuJuPianYi.Angle, out hv_modMat2D);
    //            HOperatorSet.AffineTransRegion(ho_ROI_0, out ho_ROI_0, hv_modMat2D, "nearest_neighbor");
    //        }
    //        HOperatorSet.ReduceDomain(ho_Image, ho_ROI_0, out ho_ImageReduced);

    //        #region  无用代码
    //        //if (iDateCode_.Ihv_HomMat2D != null)
    //        //{
    //        //    HOperatorSet.GenRectangle1(out ho_ROI_0, iDateCode_.IOutSide.Row_y1, iDateCode_.IOutSide.Col_x1, iDateCode_.IOutSide.Row_y2, iDateCode_.IOutSide.Col_x2);
    //        //    HOperatorSet.AffineTransRegion(ho_ROI_0, out ho_ROI_0, iDateCode_.Ihv_HomMat2D.Hv_HomMat2D, "nearest_neighbor");
    //        //    HOperatorSet.ReduceDomain(ho_Image, ho_ROI_0, out ho_ImageReduced);
    //        //}
    //        //else
    //        //{
    //        //    HOperatorSet.GenRectangle1(out ho_ROI_0, iDateCode_.IOutSide.Row_y1, iDateCode_.IOutSide.Col_x1, iDateCode_.IOutSide.Row_y2, iDateCode_.IOutSide.Col_x2);
    //        //    HOperatorSet.ReduceDomain(ho_Image, ho_ROI_0, out ho_ImageReduced);
    //        //}
    //        #endregion

    //        HOperatorSet.FindDataCode2d(ho_ImageReduced, out ho_SymbolXLDs, iDateCode_.Hv_DataCodeHandle,
    //       iDateCode_.Find_hv_GenParamNames1, iDateCode_.Find_hv_GenParaValues1, out hv_ResultHandles, out hv_DecodedDataStrings);

    //        //hwin.ClearWindow();
    //        //hwin.DispObj(ho_ImageReduced);

    //        iDateCode_.Ho_SymbolXLDs = ho_SymbolXLDs;
    //        iDateCode_.Hv_DecodedDataStrings = hv_DecodedDataStrings;

    //        ok = true;
    //        return ok;
    //    }
    //    #endregion

    //    #region  显示结果
    //    /// <summary>
    //    /// 显示结果
    //    /// </summary>
    //    /// <param name="iDateCode_"></param>
    //    /// <param name="hwin"></param>
    //    /// <returns></returns>
    //    public bool DateCodeShow(IDataCodeShuJu iDateCode_, HWindow hwin)
    //    {
    //        bool ok = false;

    //        HTuple hv_modMat2D;
    //        HObject ho_ROI_0;
    //        //HOperatorSet.GenRectangle1(out ho_ROI_0, iDateCode_.IOutSide.Row_y1, iDateCode_.IOutSide.Col_x1, iDateCode_.IOutSide.Row_y2, iDateCode_.IOutSide.Col_x2);

    //        HOperatorSet.GenRectangle2(out ho_ROI_0, iDateCode_.IOutSide.Mid_row_y, iDateCode_.IOutSide.Mid_col_x, iDateCode_.IOutSide.Phi, iDateCode_.IOutSide.Len1, iDateCode_.IOutSide.Len2);

    //        /***************************显示查找的区域***************************************/

    //        if (iDateCode_.GenSuiDian_A != null)
    //        {
    //            HOperatorSet.VectorAngleToRigid(iDateCode_.GenSuiDian_Y_Row, iDateCode_.GeuSuiDian_X_Col, iDateCode_.GenSuiDian_A, iDateCode_.IrectShuJuPianYi.Row, iDateCode_.IrectShuJuPianYi.Column, iDateCode_.IrectShuJuPianYi.Angle, out hv_modMat2D);
    //            HOperatorSet.AffineTransRegion(ho_ROI_0, out ho_ROI_0, hv_modMat2D, "nearest_neighbor");
    //        }


    //        /***********显示结果***********/

    //        HTuple hv_Area, hv_Row, hv_Column, hv_PointOrder, hv_Number;

    //        HOperatorSet.AreaCenterXld(iDateCode_.Ho_SymbolXLDs, out hv_Area, out hv_Row, out hv_Column, out hv_PointOrder);

    //        if (hv_Area.Length > 0)
    //        {
    //            HOperatorSet.GenContourRegionXld(ho_ROI_0, out ho_ROI_0, "border");
    //            hwin.DispObj(ho_ROI_0);

    //            HOperatorSet.CountObj(iDateCode_.Ho_SymbolXLDs, out hv_Number);

    //            HTuple end_val47 = hv_Number - 1;
    //            HTuple step_val47 = 1;
    //            HObject ho_ObjectSelected;
    //            HOperatorSet.GenEmptyObj(out ho_ObjectSelected);

    //            for (HTuple hv_Index = 0; hv_Index.Continue(end_val47, step_val47); hv_Index = hv_Index.TupleAdd(step_val47))
    //            {
    //                if (HDevWindowStack.IsOpen())
    //                {
    //                    HOperatorSet.SetLineWidth(HDevWindowStack.GetActive(), 100);
    //                }
    //                disp_message(hwin, iDateCode_.Hv_DecodedDataStrings.TupleSelect(hv_Index),
    //                    "image", hv_Row.TupleSelect(hv_Index), hv_Column.TupleSelect(hv_Index),
    //                    "green", "false");

    //                ho_ObjectSelected.Dispose();
    //                HOperatorSet.SelectObj(iDateCode_.Ho_SymbolXLDs, out ho_ObjectSelected, hv_Index + 1);
    //                hwin.DispObj(ho_ObjectSelected);
    //            }
    //        }
    //        else
    //        {
    //            hwin.SetColor("red");
    //            HOperatorSet.GenContourRegionXld(ho_ROI_0, out ho_ROI_0, "border");
    //            hwin.DispObj(ho_ROI_0);
    //            hwin.SetColor("green");
    //        }
    //        ok = true;
    //        return ok;
    //    }
    //    #endregion

    //    #region   查找 显示结果
    //    /// <summary>
    //    ///   查找 显示结果
    //    /// </summary>
    //    /// <param name="ho_Image"></param>
    //    /// <param name="iDateCode_"></param>
    //    /// <param name="hwin"></param>
    //    /// <param name="Key"></param>
    //    /// <param name="_dictionary_resulte"></param>
    //    /// <returns></returns>
    //    public bool DateCodeFindShow(HObject ho_Image, IDataCodeShuJu iDateCode_, HWindow hwin, string Key, ref Dictionary<string, Object> _dictionary_resulte)
    //    {
    //        bool ok = false;

    //        /****************************处理********************************/
    //        HObject ho_ROI_0, ho_SymbolXLDs, ho_ImageReduced;
    //        HOperatorSet.GenEmptyObj(out ho_SymbolXLDs);
    //        HTuple hv_ResultHandles;
    //        HTuple hv_DecodedDataStrings, hv_modMat2D;

    //        HOperatorSet.GenRectangle2(out ho_ROI_0, iDateCode_.IOutSide.Mid_row_y, iDateCode_.IOutSide.Mid_col_x, iDateCode_.IOutSide.Phi, iDateCode_.IOutSide.Len1, iDateCode_.IOutSide.Len2);

    //        if (iDateCode_.GenSuiDian_A != null)
    //        {
    //            HOperatorSet.VectorAngleToRigid(iDateCode_.GenSuiDian_Y_Row, iDateCode_.GeuSuiDian_X_Col, iDateCode_.GenSuiDian_A, iDateCode_.IrectShuJuPianYi.Row, iDateCode_.IrectShuJuPianYi.Column, iDateCode_.IrectShuJuPianYi.Angle, out hv_modMat2D);
    //            HOperatorSet.AffineTransRegion(ho_ROI_0, out ho_ROI_0, hv_modMat2D, "nearest_neighbor");
    //        }
    //        HOperatorSet.ReduceDomain(ho_Image, ho_ROI_0, out ho_ImageReduced);

    //        #region  无用代码
    //        //if (iDateCode_.Ihv_HomMat2D != null)
    //        //{
    //        //    HOperatorSet.GenRectangle1(out ho_ROI_0, iDateCode_.IOutSide.Row_y1, iDateCode_.IOutSide.Col_x1, iDateCode_.IOutSide.Row_y2, iDateCode_.IOutSide.Col_x2);
    //        //    HOperatorSet.AffineTransRegion(ho_ROI_0, out ho_ROI_0, iDateCode_.Ihv_HomMat2D.Hv_HomMat2D, "nearest_neighbor");
    //        //    HOperatorSet.ReduceDomain(ho_Image, ho_ROI_0, out ho_ImageReduced);
    //        //}
    //        //else
    //        //{
    //        //    HOperatorSet.GenRectangle1(out ho_ROI_0, iDateCode_.IOutSide.Row_y1, iDateCode_.IOutSide.Col_x1, iDateCode_.IOutSide.Row_y2, iDateCode_.IOutSide.Col_x2);
    //        //    HOperatorSet.ReduceDomain(ho_Image, ho_ROI_0, out ho_ImageReduced);
    //        //}
    //        #endregion

    //        HOperatorSet.FindDataCode2d(ho_ImageReduced, out ho_SymbolXLDs, iDateCode_.Hv_DataCodeHandle,
    //        iDateCode_.Find_hv_GenParamNames1, iDateCode_.Find_hv_GenParaValues1, out hv_ResultHandles, out hv_DecodedDataStrings);

    //        iDateCode_.Ho_SymbolXLDs = ho_SymbolXLDs;
    //        iDateCode_.Hv_DecodedDataStrings = hv_DecodedDataStrings;

    //        /***********************分心结果****************************/
    //        DateCode_Result DateCodeResult_ = new DateCode_Result();

    //        Result_Analyisis(iDateCode_, ref DateCodeResult_);


    //        /*********************保存结果***************************/
    //        Key = "DataCode_" + Key;
    //        DateCodeResult_._tolatName = Key;

    //        _dictionary_resulte.Add(Key, DateCodeResult_);


    //        /***************************显示对错***********************************/
    //        if (DateCodeResult_.AllResult)
    //        {
    //            HOperatorSet.GenContourRegionXld(ho_ROI_0, out ho_ROI_0, "border");
    //            hwin.DispObj(ho_ROI_0);
    //            HTuple hv_Area, hv_Row, hv_Column, hv_PointOrder, hv_Number;
    //            HOperatorSet.AreaCenterXld(iDateCode_.Ho_SymbolXLDs, out hv_Area, out hv_Row, out hv_Column, out hv_PointOrder);
    //            HOperatorSet.CountObj(iDateCode_.Ho_SymbolXLDs, out hv_Number);
    //            HObject ho_ObjectSelected;
    //            HOperatorSet.GenEmptyObj(out ho_ObjectSelected);

    //            HTuple end_val47 = hv_Number - 1;
    //            HTuple step_val47 = 1;
    //            for (HTuple hv_Index = 0; hv_Index.Continue(end_val47, step_val47); hv_Index = hv_Index.TupleAdd(step_val47))
    //            {
    //                if (HDevWindowStack.IsOpen())
    //                {
    //                    HOperatorSet.SetLineWidth(HDevWindowStack.GetActive(), 100);
    //                }
    //                disp_message(hwin, iDateCode_.Hv_DecodedDataStrings.TupleSelect(hv_Index),
    //                    "image", hv_Row.TupleSelect(hv_Index), hv_Column.TupleSelect(hv_Index),
    //                    "green", "false");
    //                //gen_cross_contour_xld (Cross, Row[Index], Column[Index], 60, 0.785398)
    //                ho_ObjectSelected.Dispose();
    //                HOperatorSet.SelectObj(iDateCode_.Ho_SymbolXLDs, out ho_ObjectSelected, hv_Index + 1);
    //                hwin.DispObj(ho_ObjectSelected);
    //            }

    //            ok = true;
    //        }
    //        else
    //        {
    //            hwin.SetColor("red");
    //            HOperatorSet.GenContourRegionXld(ho_ROI_0, out ho_ROI_0, "border");
    //            hwin.DispObj(ho_ROI_0);
    //            hwin.SetColor("green");
    //        }


    //        #region  无用代码
    //        /****************************显示*************************************/
    //        //HOperatorSet.AffineTransRegion(ho_ROI_0, out ho_ROI_0, iDateCode_.Ihv_HomMat2D.Hv_HomMat2D, "nearest_neighbor");
    //        //HOperatorSet.GenContourRegionXld(ho_ROI_0, out ho_ROI_0, "border");
    //        //hwin.DispObj(ho_ROI_0);
    //        //HTuple hv_Area, hv_Row, hv_Column, hv_PointOrder, hv_Number;
    //        //HOperatorSet.AreaCenterXld(iDateCode_.Ho_SymbolXLDs, out hv_Area, out hv_Row, out hv_Column, out hv_PointOrder);
    //        //HOperatorSet.CountObj(iDateCode_.Ho_SymbolXLDs, out hv_Number);
    //        //HObject ho_ObjectSelected;
    //        //HOperatorSet.GenEmptyObj(out ho_ObjectSelected);

    //        //HTuple end_val47 = hv_Number - 1;
    //        //HTuple step_val47 = 1;
    //        //for (HTuple hv_Index = 0; hv_Index.Continue(end_val47, step_val47); hv_Index = hv_Index.TupleAdd(step_val47))
    //        //{
    //        //    if (HDevWindowStack.IsOpen())
    //        //    {
    //        //        HOperatorSet.SetLineWidth(HDevWindowStack.GetActive(), 100);
    //        //    }
    //        //    disp_message(hwin, iDateCode_.Hv_DecodedDataStrings.TupleSelect(hv_Index),
    //        //        "image", hv_Row.TupleSelect(hv_Index), hv_Column.TupleSelect(hv_Index),
    //        //        "green", "false");
    //        //    //gen_cross_contour_xld (Cross, Row[Index], Column[Index], 60, 0.785398)

    //        //    ho_ObjectSelected.Dispose();
    //        //    HOperatorSet.SelectObj(iDateCode_.Ho_SymbolXLDs, out ho_ObjectSelected, hv_Index + 1);
    //        //    hwin.DispObj(ho_ObjectSelected);
    //        //}

    //        /*********************保存数据*********************************/

    //        //if (hv_Number.D > 0)
    //        //{
    //        //    result_.Hv_DecodedDataStrings = iDateCode_.Hv_DecodedDataStrings;
    //        //    _dictionary_resulte.Add(Key, result_);
    //        //}
    //        //else
    //        //{
    //        //    _dictionary_resulte.Add(Key, null);
    //        //}
    //        #endregion


    //        return ok;
    //    }
    //    #endregion

    //    #region  显示数据
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

    //    #region   结果分析
    //    /// <summary>
    //    /// 结果分析
    //    /// </summary>
    //    /// <param name="iDateCode_"></param>
    //    /// <param name="DateCodeResult"></param>
    //    void Result_Analyisis(IDataCodeShuJu iDateCode_, ref DateCode_Result DateCodeResult_)
    //    {
    //        HTuple hv_Area, hv_Row, hv_Column, hv_PointOrder, hv_Number;
    //        HOperatorSet.AreaCenterXld(iDateCode_.Ho_SymbolXLDs, out hv_Area, out hv_Row, out hv_Column, out hv_PointOrder);
    //        if (hv_Area.Length > 0)
    //        {
    //            DateCodeResult_.AllResult = true;
    //            DateCodeResult_._tolatResult = true;
    //        }
    //        else
    //        {
    //            DateCodeResult_.AllResult = false;
    //            DateCodeResult_._tolatResult = false;
    //        }
    //    }
    //    #endregion

    //}
    //#endregion

    #region  二维码结果的结构体
    /// <summary>
    /// 二维码结果的结构体
    /// </summary>
    public class DateCode_Result : MultTree.ClassResultFather
    {
        /// <summary>
        /// 二维码结果
        /// </summary>
        public HTuple Hv_DecodedDataStrings = new HTuple();

        /// <summary>
        /// 条码的整体结果
        /// </summary>
        public bool AllResult = false;

        /// <summary>
        ///显示数据
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public override bool showResult(out string str)
        {
            bool ok = false;

            if (this._tolatResult)
            {
                str = this._tolatName + ":" + this.Hv_DecodedDataStrings.ToString();
            }
            else
            {
                str = this._tolatName + ":检测失败。";
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
