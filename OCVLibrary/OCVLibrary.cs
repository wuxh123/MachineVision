using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Windows.Forms;
using HalconDotNet;
using RectLibrary;
using HalControl.ROI.Rectangle1;
using HalControl.ROI.Rectangle2;



namespace OCVLibrary
{
    #region  数据
    /// <summary>
    /// 数据
    /// </summary>
    [Serializable]
    public class OCVShuJu : MultTree.ToolDateFather, IOCVShuJu
    {
        #region 全局变量

        #region   提取ocv检测的region
        /// <summary>
        ///  提取ocv检测的region
        /// </summary>
        [NonSerialized]
        HObject ho_Rectangle = null;
        #endregion

        #region  提取ocv检测的region 点位
        /// <summary>
        /// 外部接口
        /// </summary>
        [NonSerialized]
        HalControl.ROI.Rectangle2.IOutsideRectangle2ROI _iOutSide = null;
        #endregion

        #region  丝印的名称
        /// <summary>
        /// 丝印的名称
        /// </summary>
        [NonSerialized]
        HTuple hv_PatternNames = null;
        #endregion

        #region   ocv指针路径
        /// <summary>
        /// ocv指针路径
        /// </summary>
        string hv_path = null;
        #endregion

        #region   ocv指针
        /// <summary>
        /// ocv指针
        /// </summary>
        [NonSerialized]
        HTuple hv_OCVHandle = null;
        #endregion

        #region   检测ocv参数
        /// <summary>
        /// 适合位置
        /// </summary>
        [NonSerialized]
        HTuple hv_AdaptPos = "true";

        /// <summary>
        /// 适合大小
        /// </summary>
        [NonSerialized]
        HTuple hv_AdaptSize = "true";

        /// <summary>
        /// 适合角度
        /// </summary>
        [NonSerialized]
        HTuple hv_AdaptAngle = "false";

        /// <summary>
        /// 适合灰度
        /// </summary>
        [NonSerialized]
        HTuple hv_AdaptGray = "true";

        /// <summary>
        /// 灰度误差
        /// </summary>
        [NonSerialized]
        HTuple hv_Threshold = 10;
        #endregion

        #region   ocv检测的质量
        /// <summary>
        /// ocv检测的质量
        /// </summary>
        [NonSerialized]
        HTuple hv_Quality = null;
        #endregion

        #region  放射变换的矩阵
        ///// <summary>
        ///// 放射变换的矩阵
        ///// </summary>
        //[NonSerialized]
        //public HTuple hv_HomMat2D = null;

        /// <summary>
        /// 放射变换的矩阵
        /// </summary>
        IRectShuJuHv_HomMat2D ihv_HomMat2D = null;

        #endregion

        #region   ocv质量对比类
        /// <summary>
        /// ocv质量对比类
        /// </summary>
        OcvTrained_Class _ocvTrainedClass = null;
        #endregion

        #endregion

        #region  属性

        #region  提取ocv检测的region
        /// <summary>
        ///  提取ocv检测的region
        /// </summary>
        public HObject Ho_Rectangle
        {
            get
            {
                if (ho_Rectangle == null)
                {
                    HOperatorSet.GenEmptyObj(out ho_Rectangle);
                }
                return ho_Rectangle;
            }
            set { ho_Rectangle = value; }
        }
        #endregion

        #region  提取ocv检测的region 点位
        ///// <summary>
        ///// 提取ocv检测的region 点位 y1
        ///// </summary>
        //public HTuple Hv_Row1
        //{
        //    get { return hv_Row1; }
        //    set { hv_Row1 = value; }
        //}

        ///// <summary>
        ///// 提取ocv检测的region 点位 x1
        ///// </summary>
        //public HTuple Hv_Column1
        //{
        //    get { return hv_Column1; }
        //    set { hv_Column1 = value; }
        //}

        ///// <summary>
        ///// 提取ocv检测的region 点位 y2
        ///// </summary>
        //public HTuple Hv_Row2
        //{
        //    get { return hv_Row2; }
        //    set { hv_Row2 = value; }
        //}

        ///// <summary>
        ///// 提取ocv检测的region 点位 x2
        ///// </summary>
        //public HTuple Hv_Column2
        //{
        //    get { return hv_Column2; }
        //    set { hv_Column2 = value; }
        //}


        /// <summary>
        /// 外部接口
        /// </summary>
        public HalControl.ROI.Rectangle2.IOutsideRectangle2ROI IOutSide
        {
            get
            {
                if (_iOutSide == null)
                {
                    this._iOutSide = new HalControl.ROI.Rectangle2.OutsideRectangle2ROI();
                    this._iOutSide.Len1 = 100;
                    this._iOutSide.Len2 = 100;
                    this._iOutSide.Phi = 0;
                    this._iOutSide.Mid_col_x = 100;
                    this._iOutSide.Mid_row_y = 100;
                }
                return _iOutSide;
            }
            set
            {
                if (_iOutSide == null)
                {
                    this._iOutSide = new HalControl.ROI.Rectangle2.OutsideRectangle2ROI();
                }

                _iOutSide = value;
            }
        }
        #endregion

        #region   丝印的名称
        /// <summary>
        /// 丝印的名称
        /// </summary>
        public HTuple Hv_PatternNames
        {
            get
            {
                if (hv_PatternNames == null)
                {
                    hv_PatternNames = "test";
                }
                return hv_PatternNames;
            }
            set { hv_PatternNames = value; }
        }
        #endregion

        #region  ocv指针路径
        /// <summary>
        /// ocv指针路径
        /// </summary>
        public string Hv_path
        {
            get
            {
                if (hv_path == null)
                {
                    if (!Directory.Exists(AppDomain.CurrentDomain.BaseDirectory + @"Ocv\"))
                    {
                        Directory.CreateDirectory(AppDomain.CurrentDomain.BaseDirectory + @"Ocv\");
                    }
                    string str = Hv_PatternNames.ToString().Replace("\"", "") + ".ocv";
                    return (AppDomain.CurrentDomain.BaseDirectory + @"Ocv\" + str);

                }
                return hv_path;
            }
            set { hv_path = value; }
        }
        #endregion

        #region  OCV指针
        /// <summary>
        /// ocv指针
        /// </summary>
        public HTuple Hv_OCVHandle
        {
            get
            {
                if (hv_OCVHandle == null)
                {
                    HOperatorSet.ReadOcv(Hv_path, out hv_OCVHandle);
                }
                return hv_OCVHandle;
            }
            set { hv_OCVHandle = value; }
        }
        #endregion

        #region  检测ocv参数
        /// <summary>
        /// 适合位置
        /// </summary>
        public HTuple Hv_AdaptPos
        {
            get { return hv_AdaptPos; }
            set { hv_AdaptPos = value; }
        }

        /// <summary>
        /// 适合大小
        /// </summary>
        public HTuple Hv_AdaptSize
        {
            get { return hv_AdaptSize; }
            set { hv_AdaptSize = value; }
        }

        /// <summary>
        /// 适合角度
        /// </summary>
        public HTuple Hv_AdaptAngle
        {
            get { return hv_AdaptAngle; }
            set { hv_AdaptAngle = value; }
        }

        /// <summary>
        /// 适合灰度
        /// </summary>
        public HTuple Hv_AdaptGray
        {
            get { return hv_AdaptGray; }
            set { hv_AdaptGray = value; }
        }

        /// <summary>
        /// 灰度误差
        /// </summary>
        public HTuple Hv_Threshold
        {
            get { return hv_Threshold; }
            set { hv_Threshold = value; }
        }
        #endregion

        #region ocv检测的质量
        /// <summary>
        /// ocv检测的质量
        /// </summary>
        public HTuple Hv_Quality
        {
            get
            {
                if (hv_Quality == null)
                {
                    hv_Quality = new HTuple();
                }
                return hv_Quality;
            }
            set { hv_Quality = value; }
        }
        #endregion

        #region  防射变换
        ///// <summary>
        ///// 放射变换的矩阵
        ///// </summary>
        //public HTuple Hv_HomMat2D
        //{
        //    get { return hv_HomMat2D; }
        //    set { hv_HomMat2D = value; }
        //}

        /// <summary>
        /// 放射变换的矩阵
        /// </summary>
        public IRectShuJuHv_HomMat2D Ihv_HomMat2D
        {
            get { return ihv_HomMat2D; }
            set { ihv_HomMat2D = value; }
        }

        #endregion

        #region   ocv质量对比类
        /// <summary>
        /// ocv质量对比类
        /// </summary>
        public OcvTrained_Class OcvTrainedClass
        {
            get
            {
                if (_ocvTrainedClass == null)
                {
                    _ocvTrainedClass = new OcvTrained_Class();
                }
                return _ocvTrainedClass;
            }
            set { _ocvTrainedClass = value; }
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

        #endregion

        #region  序列化保存数据

        #region  提取ocv检测的region 点位
        ///// <summary>
        ///// 提取ocv检测的region 点位 y1
        ///// </summary>
        //object hv_Row1_1;

        ///// <summary>
        ///// 提取ocv检测的region 点位 x1
        ///// </summary>
        //object hv_Column1_1;

        ///// <summary>
        ///// 提取ocv检测的region 点位 y2
        ///// </summary>
        //object hv_Row2_1;

        ///// <summary>
        ///// 提取ocv检测的region 点位 x2
        ///// </summary>
        //object hv_Column2_1;
        /// <summary>
        /// 
        /// </summary>
        Object mid_row_y_1;
        /// <summary>
        /// 
        /// </summary>
        Object mid_col_x_1;
        /// <summary>
        /// 
        /// </summary>
        Object len1_1;
        /// <summary>
        /// 
        /// </summary>
        Object len2_1;
        /// <summary>
        /// 
        /// </summary>
        Object angle_1;
        #endregion

        #region  丝印的名称
        /// <summary>
        /// 丝印的名称
        /// </summary>
        object hv_PatternNames_1;
        #endregion

        #region   检测ocv参数
        /// <summary>
        /// 适合位置
        /// </summary>
        object hv_AdaptPos_1;

        /// <summary>
        /// 适合大小
        /// </summary>
        object hv_AdaptSize_1;

        /// <summary>
        /// 适合角度
        /// </summary>
        object hv_AdaptAngle_1;

        /// <summary>
        /// 适合灰度
        /// </summary>
        object hv_AdaptGray_1;

        /// <summary>
        /// 灰度误差
        /// </summary>
        object hv_Threshold_1;
        #endregion

        #endregion

        #region  保存数据
        /// <summary>
        /// 保存数据
        /// </summary>
        public override void save()
        {
            base.save();

            #region  提取ocv检测的region 点位
            //hv_Row1_1 = this.IOutSide.Row_y1;

            //hv_Column1_1 = this.IOutSide.Col_x1;

            //hv_Row2_1 = this.IOutSide.Row_y2;

            //hv_Column2_1 = this.IOutSide.Col_x2;

            this.mid_col_x_1 = this.IOutSide.Mid_col_x;
            this.mid_row_y_1 = this.IOutSide.Mid_row_y;
            this.len1_1 = this.IOutSide.Len1;
            this.len2_1 = this.IOutSide.Len2;
            this.angle_1 = this.IOutSide.Phi;

            #endregion

            #region  丝印的名称
            hv_PatternNames_1 = hv_PatternNames;
            #endregion

            #region   检测ocv参数
            hv_AdaptPos_1 = hv_AdaptPos;

            hv_AdaptSize_1 = hv_AdaptPos;

            hv_AdaptAngle_1 = hv_AdaptAngle;

            hv_AdaptGray_1 = hv_AdaptGray;

            hv_Threshold_1 = hv_Threshold;

            #endregion
        }
        #endregion

        #region   初始化
        /// <summary>
        /// 初始化
        /// </summary>
        public override void init()
        {
            base.init();

            #region  提取ocv检测的region 点位
            //this.IOutSide.Row_y1 = (HTuple)hv_Row1_1;
            //this.IOutSide.Col_x1 = (HTuple)hv_Column1_1;
            //this.IOutSide.Row_y2 = (HTuple)hv_Row2_1;
            //this.IOutSide.Col_x2 = (HTuple)hv_Column2_1;

            this.IOutSide.Mid_col_x = (HTuple)this.mid_col_x_1;
            this.IOutSide.Mid_row_y = (HTuple)this.mid_row_y_1;
            this.IOutSide.Len1 = (HTuple)this.len1_1;
            this.IOutSide.Len2 = (HTuple)this.len2_1;
            this.IOutSide.Phi = (HTuple)this.angle_1;
            #endregion

            #region  丝印的名称
            hv_PatternNames = (HTuple)hv_PatternNames_1;
            #endregion

            #region   检测ocv参数
            hv_AdaptPos = (HTuple)hv_AdaptPos_1;

            hv_AdaptSize = (HTuple)hv_AdaptSize_1;

            hv_AdaptAngle = (HTuple)hv_AdaptAngle_1;

            hv_AdaptGray = (HTuple)hv_AdaptGray_1;

            hv_Threshold = (HTuple)hv_Threshold_1;
            #endregion

            #region 初始化句柄
            HOperatorSet.ReadOcv(Hv_path, out hv_OCVHandle);
            #endregion
        }
        #endregion

        #region  检测
        public override bool analyze_show(HWindow hwin, string Key, ref Dictionary<string, object> _dictionary_resulte)
        {
            bool ok = false;
            /****************************************处理***************************************************************/
            HObject ho_ImageReduced_;
            HOperatorSet.GenEmptyObj(out ho_ImageReduced_);

            HTuple hv_ModMat2D_;

            HObject ho_Rectangle_;
            HOperatorSet.GenEmptyObj(out ho_Rectangle_);
            ho_Rectangle_.Dispose();
            //HOperatorSet.GenRectangle1(out ho_Rectangle, IOCV.IOutSide.Row_y1, IOCV.IOutSide.Col_x1, IOCV.IOutSide.Row_y2, IOCV.IOutSide.Col_x2);
            HOperatorSet.GenRectangle2(out ho_Rectangle_, IOutSide.Mid_row_y, IOutSide.Mid_col_x, -IOutSide.Phi, IOutSide.Len1, IOutSide.Len2);

            if (IrectShuJuPianYi != null)
            {
                HOperatorSet.VectorAngleToRigid(GenSuiDian_Y_Row, GeuSuiDian_X_Col, GenSuiDian_A, IrectShuJuPianYi.Row, IrectShuJuPianYi.Column, IrectShuJuPianYi.Angle, out hv_ModMat2D_);
                HOperatorSet.AffineTransRegion(ho_Rectangle_, out ho_Rectangle_, hv_ModMat2D_, "nearest_neighbor");
            }

            //if (IOCV.Ihv_HomMat2D != null)
            //{
            //    HOperatorSet.AffineTransRegion(ho_Rectangle, out ho_Rectangle, IOCV.Ihv_HomMat2D.Hv_HomMat2D, "nearest_neighbor");            
            //}

            HOperatorSet.ReduceDomain(this.ImageFather.Ho_image, ho_Rectangle_, out ho_ImageReduced_);
            HTuple hv_Quality = null;
            HOperatorSet.DoOcvSimple(ho_ImageReduced_, Hv_OCVHandle, Hv_PatternNames, Hv_AdaptPos,
         Hv_AdaptSize, Hv_AdaptAngle, Hv_AdaptGray, Hv_Threshold, out hv_Quality);
            Hv_Quality = hv_Quality;

            ho_ImageReduced_.Dispose();

            Ho_Rectangle.Dispose();
            Ho_Rectangle = ho_Rectangle_;

            /********************************结果分析跟数据保存********************************************/
            Key = "OCV_" + Key;
            OCV_Result ocvResult_ = new OCV_Result();
            ocvResult_._tolatName = Key;
            if (Hv_Quality == null)
            {
                OcvTrainedClass._allResult = false;
                ocvResult_.Hv_Quality = null;
                ocvResult_._Result = false;
                ocvResult_._tolatResult = false;
            }

            if (OcvTrainedClass._trained)//判断有无训练
            {
                double quality_ = Convert.ToDouble(Hv_Quality.ToString());
                if (quality_ < OcvTrainedClass._ocvTrainingQuality)//质量对比
                {
                    OcvTrainedClass._allResult = false;
                    //IOCV.OcvTrainedClass._result = false;
                    ocvResult_.Hv_Quality = Hv_Quality;
                    ocvResult_._Result = false;
                    ocvResult_._tolatResult = false;
                }
                else
                {
                    OcvTrainedClass._allResult = true;
                    //IOCV.OcvTrainedClass._result = true;
                    ocvResult_.Hv_Quality = Hv_Quality;
                    ocvResult_._Result = true;
                    ocvResult_._tolatResult = true;
                }
            }
            else
            {
                OcvTrainedClass._allResult = true;
                ocvResult_.Hv_Quality = Hv_Quality;
                ocvResult_._Result = true;
                ocvResult_._tolatResult = true;
            }
            _dictionary_resulte.Add(Key, ocvResult_);

            if (OcvTrainedClass._allResult)
            {
                ok = true;
            }
            show(hwin);
            return ok;
        }

        #endregion

        #region  显示
        public override bool show(HWindow hwin)
        {
            bool ok = false;

            HObject ho_Rectangle_;
            HOperatorSet.GenEmptyObj(out ho_Rectangle_);

            HOperatorSet.GenContourRegionXld(Ho_Rectangle, out ho_Rectangle_, "border");
            if (OcvTrainedClass._allResult)
            {
                disp_message(hwin, "质量:" + Hv_Quality, "image", IOutSide.Mid_row_y, IOutSide.Mid_col_x, "black", "false");
                hwin.DispObj(ho_Rectangle_);
                ok = true;
            }
            else
            {
                hwin.SetColor("red");
                hwin.DispObj(ho_Rectangle_);
                hwin.SetColor("green");
            }
            ho_Rectangle_.Dispose();
            return ok;
        }
        #endregion

        #region 显示
        public void disp_message(HTuple hv_WindowHandle, HTuple hv_String, HTuple hv_CoordSystem,
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

    #region   ocv质量对比类
    /// <summary>
    /// ocv质量对比类
    /// </summary>
    [Serializable]
    public class OcvTrained_Class
    {
        /// <summary>
        /// 是否启动训练
        /// </summary>
        public bool _trained = false;

        /// <summary>
        /// ocv训练的质量
        /// </summary>
        public double _ocvTrainingQuality = 0;

        /// <summary>
        /// 质量对比的结果
        /// </summary>
        public bool _result = true;

        /// <summary>
        /// ocv整体的结果
        /// </summary>
        public bool _allResult = true;

    }
    #endregion

    #region   数据接口
    /// <summary>
    /// 数据接口
    /// </summary>
    public interface IOCVShuJu : HalControl.ROI.Rectangle2.IOutsideRectangle2, MultTree.IToolDateFather
    {
        #region  属性

        #region  提取ocv检测的region
        /// <summary>
        ///  提取ocv检测的region
        /// </summary>
        HObject Ho_Rectangle
        {
            get;
            set;
        }
        #endregion

        #region  提取ocv检测的region 点位
        ///// <summary>
        ///// 提取ocv检测的region 点位 y1
        ///// </summary>
        //HTuple Hv_Row1
        //{
        //    get;
        //    set;
        //}

        ///// <summary>
        ///// 提取ocv检测的region 点位 x1
        ///// </summary>
        //HTuple Hv_Column1
        //{
        //    get;
        //    set;
        //}

        ///// <summary>
        ///// 提取ocv检测的region 点位 y2
        ///// </summary>
        //HTuple Hv_Row2
        //{
        //    get;
        //    set;
        //}

        ///// <summary>
        ///// 提取ocv检测的region 点位 x2
        ///// </summary>
        //HTuple Hv_Column2
        //{
        //    get;
        //    set;
        //}
        #endregion

        #region   丝印的名称
        /// <summary>
        /// 丝印的名称
        /// </summary>
        HTuple Hv_PatternNames
        {
            get;
            set;
        }
        #endregion

        #region  ocv指针路径
        /// <summary>
        /// ocv指针路径
        /// </summary>
        string Hv_path
        {
            get;
            set;
        }
        #endregion

        #region  OCV指针
        /// <summary>
        /// ocv指针
        /// </summary>
        HTuple Hv_OCVHandle
        {
            get;
            set;
        }
        #endregion

        #region  检测ocv参数
        /// <summary>
        /// 适合位置
        /// </summary>
        HTuple Hv_AdaptPos
        {
            get;
            set;
        }

        /// <summary>
        /// 适合大小
        /// </summary>
        HTuple Hv_AdaptSize
        {
            get;
            set;
        }

        /// <summary>
        /// 适合角度
        /// </summary>
        HTuple Hv_AdaptAngle
        {
            get;
            set;
        }

        /// <summary>
        /// 适合灰度
        /// </summary>
        HTuple Hv_AdaptGray
        {
            get;
            set;
        }

        /// <summary>
        /// 灰度误差
        /// </summary>
        HTuple Hv_Threshold
        {
            get;
            set;
        }
        #endregion

        #region ocv检测的质量
        /// <summary>
        /// ocv检测的质量
        /// </summary>
        HTuple Hv_Quality
        {
            get;
            set;
        }
        #endregion

        #region  防射变换
        ///// <summary>
        ///// 放射变换的矩阵
        ///// </summary>
        //HTuple Hv_HomMat2D
        //{
        //    get;
        //    set;
        //}
        #endregion

        #region   ocv质量对比类
        /// <summary>
        /// ocv质量对比类
        /// </summary>
        OcvTrained_Class OcvTrainedClass
        {
            get;
            set;
        }
        #endregion

        #endregion

        #region  初始化
        void init();
        #endregion

        #region  保存
        void save();
        #endregion
    }
    #endregion

    #region   数据设置器
    /// <summary>
    /// 数据设置器
    /// </summary>
    public class Set_OCVShuJu
    {
        #region  提取ocv检测的region 点位
        ///// <summary>
        /////  设置 提取ocv检测的region 点位
        ///// </summary>
        ///// <param name="IOCV"></param>
        ///// <param name="hv_Row1"></param>
        ///// <param name="hv_Column1"></param>
        ///// <param name="hv_Row2"></param>
        ///// <param name="hv_Column2"></param>
        ///// <returns></returns>
        //public bool Set_OCVRegionPonit(IOCVShuJu IOCV, HTuple hv_Row1, HTuple hv_Column1, HTuple hv_Row2,
        //    HTuple hv_Column2)
        //{
        //    bool ok = false;
        //    IOCV.IOutSide.Row_y1 = hv_Row1;
        //    IOCV.IOutSide.Col_x1 = hv_Column1;
        //    IOCV.IOutSide.Row_y2 = hv_Row2;
        //    IOCV.IOutSide.Col_x2 = hv_Column2;
        //    ok = true;
        //    return ok;
        //}

        #endregion

        #region   设置丝印的名称
        /// <summary>
        /// 设置丝印的名称
        /// </summary>
        /// <param name="IOCV"></param>
        /// <param name="name"></param>
        /// <returns></returns>
        public bool Set_OCVPatternNames(IOCVShuJu IOCV, string name)
        {
            bool ok = false;
            IOCV.Hv_PatternNames = name;
            ok = true;
            return ok;
        }

        #endregion

        //#region  设置OCV路径
        ///// <summary>
        ///// 设置OCV路径
        ///// </summary>
        ///// <param name="IOCV"></param>
        ///// <param name="path"></param>
        ///// <returns></returns>
        //public bool Set_Path(IOCVShuJu IOCV, string path)
        //{
        //    bool ok = false;
        //    IOCV.Hv_path = path;
        //    ok = true;
        //    return ok;
        //}
        //#endregion

        //#region  清除OCV指针
        ///// <summary>
        ///// 清楚OCV指针
        ///// </summary>
        ///// <param name="IOCV"></param>
        ///// <returns></returns>
        //public bool Set_OCVClearHandle(IOCVShuJu IOCV)
        //{
        //    bool ok = false;
        //    HOperatorSet.CloseOcv(IOCV.Hv_OCVHandle);
        //    IOCV.Hv_OCVHandle = null;
        //    ok = true;
        //    return ok;
        //}
        //#endregion

        #region   设置ocv参数
        /// <summary>
        /// 设置ocv参数
        /// </summary>
        /// <param name="IOCV">ocv数据接口</param>
        /// <param name="hv_AdaptPos">是否判断丝印的位置。赋值是字符串"true"或"false"</param>
        /// <param name="hv_AdaptSize">是否判断丝印的大小，赋值是字符串"true"或"false"</param>
        /// <param name="hv_AdaptAngle">是否判断丝印的角度大小，赋值是字符串"true"或"false"</param>
        /// <param name="hv_AdaptGray">是否判断丝印的灰度值，赋值是字符串"true"或"false"</param>
        /// <param name="hv_Threshold">丝印灰度值误差</param>
        /// <returns></returns>
        public bool Set_OCVParameter(IOCVShuJu IOCV, string hv_AdaptPos, string hv_AdaptSize, string hv_AdaptAngle
            , string hv_AdaptGray, string hv_Threshold)
        {
            bool ok = false;

            if (hv_AdaptPos != null)
            {
                IOCV.Hv_AdaptPos = hv_AdaptPos;
            }
            if (hv_AdaptSize != null)
            {
                IOCV.Hv_AdaptSize = hv_AdaptSize;
            }
            if (hv_AdaptAngle != null)
            {
                IOCV.Hv_AdaptAngle = hv_AdaptAngle;
            }
            if (hv_AdaptGray != null)
            {
                IOCV.Hv_AdaptGray = hv_AdaptGray;
            }

            if (hv_Threshold != null)
            {
                double num = Convert.ToDouble(hv_Threshold);
                IOCV.Hv_Threshold = num;
            }

            ok = true;
            return ok;
        }
        #endregion

        //#region 创建ocv指针
        ///// <summary>
        ///// 创建ocv指针
        ///// </summary>
        ///// <param name="IOCV"></param>
        ///// <returns></returns>
        //public bool Set_OCVCreateHandle(IOCVShuJu IOCV)
        //{
        //    bool ok = false;
        //    Set_OCVClearHandle(IOCV);
        //    HTuple Handle = null;
        //    HOperatorSet.CreateOcvProj(IOCV.Hv_PatternNames, out Handle);
        //    IOCV.Hv_OCVHandle = Handle;
        //    ok = true;
        //    return ok;
        //}
        //#endregion

        //#region   读取ocv指针
        //public bool Set_OCVReadHandle(IOCVShuJu IOCV, string path)
        //{
        //    bool ok = false;
        //    IOCV.Hv_path = path;
        //    HTuple Handle = null;
        //    HOperatorSet.ReadOcv(IOCV.Hv_path, out Handle);
        //    IOCV.Hv_OCVHandle = Handle;
        //    ok = true;
        //    return ok;
        //}


        //#endregion

        #region  显示参数
        /// <summary>
        /// 显示参数
        /// </summary>
        /// <param name="IOCV_"></param>
        /// <param name="control"></param>
        /// <param name="halconWinControl_"></param>
        public void Set_showParameterHalconWinControl(IOCVShuJu IOCV_, Control.ControlCollection control, HalControl.HalconWinControl_ROI halconWinControl_)
        {
            if (halconWinControl_ != null)
            {
                halconWinControl_.DrawRectangle2(IOCV_.IOutSide.Mid_col_x, IOCV_.IOutSide.Mid_row_y, IOCV_.IOutSide.Phi, IOCV_.IOutSide.Len1, IOCV_.IOutSide.Len2, IOCV_.IOutSide);
                //  halconWinControl_.DrawRectangle1(IOCV_.IOutSide.Col_x1, IOCV_.IOutSide.Row_y1, IOCV_.IOutSide.Col_x2, IOCV_.IOutSide.Row_y2, IOCV_.IOutSide);
            }
            Set_ShowOCVParameter(IOCV_, control);
        }

        /// <summary>
        /// 显示参数
        /// </summary>
        /// <param name="IOCV"></param>
        /// <param name="control"></param>
        /// <returns></returns>
        bool Set_ShowOCVParameter(IOCVShuJu IOCV, Control.ControlCollection control)
        {
            bool ok = false;
            foreach (Control con in control)
            {
                string name = con.Name;
                if ((con is ComboBox) || (con is TextBox) || (con is RichTextBox) || (con is Label))
                {
                    switch (name)
                    {
                        #region  ocv检测参数
                        case "hv_AdaptPos":
                            con.Text = IOCV.Hv_AdaptPos.ToString().Replace("\"", "");
                            break;

                        case "hv_AdaptSize":
                            con.Text = IOCV.Hv_AdaptSize.ToString().Replace("\"", "");
                            break;

                        case "hv_AdaptAngle":
                            con.Text = IOCV.Hv_AdaptAngle.ToString().Replace("\"", "");
                            break;

                        case "hv_Threshold":
                            con.Text = IOCV.Hv_Threshold.ToString().Replace("\"", "");
                            break;

                        case "hv_AdaptGray":
                            con.Text = IOCV.Hv_AdaptGray.ToString().Replace("\"", "");
                            break;

                        #endregion

                        #region  检测丝印的名称
                        case "hv_PatternNames":
                            con.Text = IOCV.Hv_PatternNames.ToString().Replace("\"", "");
                            break;
                        #endregion

                        #region   ocv训练
                        case "_trained":
                            ((CheckBox)con).Checked = IOCV.OcvTrainedClass._trained;
                            break;
                        #endregion

                        #region   丝印的质量
                        case "_ocvTrainingQuality":
                            con.Text = IOCV.OcvTrainedClass._ocvTrainingQuality.ToString();
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
                    Set_ShowOCVParameter(IOCV, con.Controls);
                }
            }

            ok = true;
            return ok;
        }
        #endregion

        #region  修改ocv
        /// <summary>
        /// 修改ocv
        /// </summary>
        /// <param name="Ho_Image"></param>
        /// <param name="hwin"></param>
        /// <param name="IOCV"></param>
        /// <returns></returns>
        public bool Set_ChangeOCV(HObject Ho_Image, HWindow hwin, IOCVShuJu IOCV, ref string Hv_PatternNames)
        {
            bool ok = false;

            if (Hv_PatternNames != "")//判断名称不等于空
            {
                if (IOCV.Hv_OCVHandle != null)
                {
                    HOperatorSet.CloseOcv(IOCV.Hv_OCVHandle);
                }

                HTuple ocvhandle = null;
                HOperatorSet.CreateOcvProj(Hv_PatternNames, out ocvhandle);
                HObject Hreg;
                HOperatorSet.GenEmptyObj(out Hreg);

                //HOperatorSet.GenRectangle1(out Hreg, IOCV.IOutSide.Row_y1, IOCV.IOutSide.Col_x1, IOCV.IOutSide.Row_y2, IOCV.IOutSide.Col_x2);
                HOperatorSet.GenRectangle2(out Hreg, IOCV.IOutSide.Mid_row_y, IOCV.IOutSide.Mid_col_x, IOCV.IOutSide.Phi, IOCV.IOutSide.Len1, IOCV.IOutSide.Len2);
                HOperatorSet.ReduceDomain(Ho_Image, Hreg, out Hreg);
                HOperatorSet.TraindOcvProj(Hreg, ocvhandle, IOCV.Hv_PatternNames, "single");

                HTuple Quality;
                HOperatorSet.DoOcvSimple(Hreg, ocvhandle, IOCV.Hv_PatternNames, IOCV.Hv_AdaptPos, IOCV.Hv_AdaptSize, IOCV.Hv_AdaptAngle, IOCV.Hv_AdaptGray, IOCV.Hv_Threshold, out Quality);
                disp_message(hwin, "质量:" + Quality, "image", IOCV.IOutSide.Mid_row_y, IOCV.IOutSide.Mid_col_x,
          "black", "false");

                IOCV.Hv_OCVHandle = ocvhandle;
                IOCV.Hv_PatternNames = Hv_PatternNames;

                HOperatorSet.WriteOcv(IOCV.Hv_OCVHandle, IOCV.Hv_path);

                ok = true;
            }

            return ok;
        }
        #endregion

        #region 显示
        public void disp_message(HTuple hv_WindowHandle, HTuple hv_String, HTuple hv_CoordSystem,
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

        #region   设置训练值
        /// <summary>
        /// 设置训练值
        /// </summary>
        /// <param name="IOCV"></param>
        /// <param name="trained_"></param>
        /// <param name="ocvTrainingQuality_"></param>
        public void Set_OcvTrained_Class(IOCVShuJu IOCV, bool trained_, string ocvTrainingQuality_)
        {
            IOCV.OcvTrainedClass._trained = trained_;
            if (ocvTrainingQuality_ != null)
            {
                IOCV.OcvTrainedClass._ocvTrainingQuality = Convert.ToDouble(ocvTrainingQuality_);
            }
        }
        #endregion

        #region  重新刷新定位点
        /// <summary>
        /// 重新刷新定位点
        /// </summary>
        /// <param name="IOCV"></param>
        /// <returns></returns>
        public bool Set_ShuaXinDingWeiDian(IOCVShuJu IOCV)
        {
            bool ok = false;

            if (IOCV.IrectShuJuPianYi != null)
            {
                IOCV.GeuSuiDian_X_Col = IOCV.IrectShuJuPianYi.Column;
                IOCV.GenSuiDian_Y_Row = IOCV.IrectShuJuPianYi.Row;
                IOCV.GenSuiDian_A = IOCV.IrectShuJuPianYi.Angle;
            }
            ok = true;
            return ok;
        }
        #endregion

        //#region 创建ocv
        ///// <summary>
        ///// 创建ocv
        ///// </summary>
        ///// <param name="PatternNames"></param>
        ///// <param name="Ho_Image"></param>
        ///// <param name="hwin"></param>
        ///// <param name="IOCV"></param>
        ///// <returns></returns>
        //public bool Set_CreateTraining(ref string PatternNames, HObject Ho_Image, HWindow hwin, IOCVShuJu IOCV)
        //{
        //    bool ok = false;

        //    #region  无用代码
        //    //double row1, column1, row2, column2;
        //    //hwin.DrawRectangle1(out row1, out column1, out row2, out column2);
        //    //HRegion Hreg = new HRegion(row1, column1, row2, column2);
        //    #endregion

        //    HTuple OCVHandle;
        //    HObject Hreg;
        //    HOperatorSet.GenEmptyObj(out Hreg);
        //    HOperatorSet.GenRectangle2(out Hreg, IOCV.IOutSide.Mid_row_y, IOCV.IOutSide.Mid_col_x, IOCV.IOutSide.Phi, IOCV.IOutSide.Len1, IOCV.IOutSide.Len2);
        //    HOperatorSet.ReduceDomain(Ho_Image, Hreg, out Hreg);

        //    #region  无用代码
        //    //if (OCVHandle1 != null)
        //    //{
        //    //    HOperatorSet.CloseOcv(OCVHandle1);
        //    //}
        //    //Hv_PatternNames = PatternNames;
        //    #endregion

        //    /***********创建ocv**************/
        //    HOperatorSet.CreateOcvProj(PatternNames, out OCVHandle);

        //    /************训练ocv*****************/
        //    HOperatorSet.TraindOcvProj(Hreg, OCVHandle, PatternNames, "single");

        //    /*************检测ocv******************/
        //    HTuple hv_Quality = null;
        //    HOperatorSet.DoOcvSimple(Hreg, OCVHandle, PatternNames, IOCV.Hv_AdaptPos, IOCV.Hv_AdaptSize, IOCV.Hv_AdaptAngle, IOCV.Hv_AdaptGray, IOCV.Hv_Threshold, out hv_Quality);

        //    /*************显示质量*********************/
        //    disp_message(hwin, "质量:" + hv_Quality, "image", IOCV.IOutSide.Mid_row_y, IOCV.IOutSide.Mid_col_x, "black", "false");

        //    /***************写入到当前ocv*********************/
        //    IOCV.Hv_OCVHandle = OCVHandle;
        //    IOCV.Hv_PatternNames = PatternNames;

        //    /*****************保存*******************/
        //    HOperatorSet.WriteOcv(IOCV.Hv_OCVHandle, IOCV.Hv_path);

        //    ok = true;
        //    return ok;
        //}
        //#endregion
    }
    #endregion

    //#region   数据分析器
    ///// <summary>
    ///// 数据分析器
    ///// </summary>
    //public class OCV
    //{
    //    #region OCV检测
    //    /// <summary>
    //    /// ocv检测
    //    /// </summary>
    //    /// <param name="ho_Image"></param>
    //    /// <param name="IOCV"></param>
    //    /// <returns></returns>
    //    public bool OCV_Check(HObject ho_Image, IOCVShuJu IOCV)
    //    {
    //        bool ok = false;
    //        HTuple hv_modMat2D;
    //        HObject ho_ImageReduced;
    //        HOperatorSet.GenEmptyObj(out ho_ImageReduced);

    //        HObject ho_Rectangle;
    //        HOperatorSet.GenEmptyObj(out ho_Rectangle);
    //        ho_Rectangle.Dispose();
    //        //HOperatorSet.GenRectangle1(out ho_Rectangle, IOCV.IOutSide.Row_y1, IOCV.IOutSide.Col_x1, IOCV.IOutSide.Row_y2, IOCV.IOutSide.Col_x2);
    //        HOperatorSet.GenRectangle2(out ho_Rectangle, IOCV.IOutSide.Mid_row_y, IOCV.IOutSide.Mid_col_x, IOCV.IOutSide.Phi, IOCV.IOutSide.Len1, IOCV.IOutSide.Len2);

    //        if (IOCV.GenSuiDian_A != null)
    //        {
    //            HOperatorSet.VectorAngleToRigid(IOCV.GenSuiDian_Y_Row, IOCV.GeuSuiDian_X_Col, IOCV.GenSuiDian_A, IOCV.IrectShuJuPianYi.Row, IOCV.IrectShuJuPianYi.Column, IOCV.IrectShuJuPianYi.Angle, out hv_modMat2D);
    //            HOperatorSet.AffineTransRegion(ho_Rectangle, out ho_Rectangle, hv_modMat2D, "nearest_neighbor");
    //        }

    //        //if (IOCV.Ihv_HomMat2D != null)
    //        //{
    //        //    HOperatorSet.AffineTransRegion(ho_Rectangle, out ho_Rectangle, IOCV.Ihv_HomMat2D.Hv_HomMat2D, "nearest_neighbor");
    //        //}

    //        HOperatorSet.ReduceDomain(ho_Image, ho_Rectangle, out ho_ImageReduced);
    //        HTuple hv_Quality = null;
    //        HOperatorSet.DoOcvSimple(ho_ImageReduced, IOCV.Hv_OCVHandle, IOCV.Hv_PatternNames, IOCV.Hv_AdaptPos,
    //        IOCV.Hv_AdaptSize, IOCV.Hv_AdaptAngle, IOCV.Hv_AdaptGray, IOCV.Hv_Threshold, out hv_Quality);
    //        IOCV.Hv_Quality = hv_Quality;

    //        ho_ImageReduced.Dispose();

    //        IOCV.Ho_Rectangle.Dispose();
    //        IOCV.Ho_Rectangle = ho_Rectangle;

    //        OCV_Result result_ = new OCV_Result();

    //        this.Result_Analyisis(IOCV, ref result_);
    //        ok = true;
    //        return ok;
    //    }
    //    #endregion

    //    #region    显示ocv检测数据
    //    /// <summary>
    //    /// 显示ocv检测数据
    //    /// </summary>
    //    /// <param name="IOCV"></param>
    //    /// <param name="win"></param>
    //    /// <returns></returns>
    //    public bool OCV_Show(IOCVShuJu IOCV, HWindow hwin)
    //    {
    //        bool ok = false;

    //        HTuple hv_modMat2D;

    //        HObject ho_Rectangle;
    //        HOperatorSet.GenEmptyObj(out ho_Rectangle);

    //        ho_Rectangle.Dispose();

    //        //HOperatorSet.GenRectangle1(out ho_Rectangle, IOCV.IOutSide.Row_y1, IOCV.IOutSide.Col_x1, IOCV.IOutSide.Row_y2, IOCV.IOutSide.Col_x2);

    //        HOperatorSet.GenRectangle2(out ho_Rectangle, IOCV.IOutSide.Mid_row_y, IOCV.IOutSide.Mid_col_x, IOCV.IOutSide.Phi, IOCV.IOutSide.Len1, IOCV.IOutSide.Len2);

    //        if (IOCV.GenSuiDian_A != null)
    //        {
    //            HOperatorSet.VectorAngleToRigid(IOCV.GenSuiDian_Y_Row, IOCV.GeuSuiDian_X_Col, IOCV.GenSuiDian_A, IOCV.IrectShuJuPianYi.Row, IOCV.IrectShuJuPianYi.Column, IOCV.IrectShuJuPianYi.Angle, out hv_modMat2D);
    //            HOperatorSet.AffineTransRegion(ho_Rectangle, out ho_Rectangle, hv_modMat2D, "nearest_neighbor");
    //        }

    //        //if (IOCV.Ihv_HomMat2D != null)
    //        //{
    //        //    HOperatorSet.AffineTransRegion(ho_Rectangle, out ho_Rectangle, IOCV.Ihv_HomMat2D.Hv_HomMat2D, "nearest_neighbor");
    //        //}

    //        HOperatorSet.GenContourRegionXld(ho_Rectangle, out ho_Rectangle, "border");

    //        if (IOCV.OcvTrainedClass._allResult)
    //        {
    //            if (IOCV.Hv_Quality != null)
    //            {
    //                disp_message(hwin, "质量:" + IOCV.Hv_Quality, "image", IOCV.IOutSide.Mid_row_y, IOCV.IOutSide.Mid_col_x, "black", "false");
    //            }
    //            hwin.DispObj(ho_Rectangle);
    //        }
    //        else
    //        {
    //            hwin.SetColor("red");
    //            hwin.DispObj(ho_Rectangle);
    //            hwin.SetColor("green");
    //        }

    //        ho_Rectangle.Dispose();

    //        #region  无用代码
    //        //if (IOCV.Ho_Rectangle != null)
    //        //{
    //        //    HObject ho_Contours;
    //        //    HOperatorSet.GenEmptyObj(out ho_Contours);
    //        //    ho_Contours.Dispose();
    //        //    HOperatorSet.GenContourRegionXld(IOCV.Ho_Rectangle, out ho_Contours, "border");
    //        //    hwin.DispObj(ho_Contours);

    //        //    disp_message(hwin, "质量:" + IOCV.Hv_Quality, "image", IOCV.Hv_Row1, IOCV.Hv_Column1 - 200,
    //        //        "black", "false");
    //        //}
    //        #endregion

    //        ok = true;
    //        return ok;
    //    }
    //    #endregion

    //    #region 显示
    //    public void disp_message(HTuple hv_WindowHandle, HTuple hv_String, HTuple hv_CoordSystem,
    //  HTuple hv_Row, HTuple hv_Column, HTuple hv_Color, HTuple hv_Box)
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

    //    //#region   输出数据
    //    ///// <summary>
    //    ///// 输出数据
    //    ///// </summary>
    //    ///// <param name="IOCR"></param>
    //    ///// <param name="_dictionary_resulte"></param>
    //    /////  <param name="Key"></param>
    //    //public void out_result(string Key, IOCVShuJu IOCV, ref Dictionary<string, Object> _dictionary_resulte)
    //    //{
    //    //    _dictionary_resulte.Add(Key, IOCV.Hv_Quality);
    //    //}
    //    // #endregion

    //    #region  检测，显示，保存
    //    /// <summary>
    //    /// 检测，显示，保存
    //    /// </summary>
    //    /// <param name="ho_Image"></param>
    //    /// <param name="IOCV"></param>
    //    /// <param name="hwin"></param>
    //    /// <param name="Key"></param>
    //    /// <param name="_dictionary_resulte"></param>
    //    /// <returns></returns>
    //    public bool Check_Show_Out(HObject ho_Image, IOCVShuJu IOCV, HWindow hwin, string Key, ref Dictionary<string, Object> _dictionary_resulte)
    //    {
    //        bool ok = false;
    //        /****************************************处理***************************************************************/
    //        HObject ho_ImageReduced;
    //        HOperatorSet.GenEmptyObj(out ho_ImageReduced);

    //        HTuple hv_ModMat2D;

    //        HObject ho_Rectangle;
    //        HOperatorSet.GenEmptyObj(out ho_Rectangle);
    //        ho_Rectangle.Dispose();
    //        //HOperatorSet.GenRectangle1(out ho_Rectangle, IOCV.IOutSide.Row_y1, IOCV.IOutSide.Col_x1, IOCV.IOutSide.Row_y2, IOCV.IOutSide.Col_x2);
    //        HOperatorSet.GenRectangle2(out ho_Rectangle, IOCV.IOutSide.Mid_row_y, IOCV.IOutSide.Mid_col_x, IOCV.IOutSide.Phi, IOCV.IOutSide.Len1, IOCV.IOutSide.Len2);

    //        if (IOCV.GenSuiDian_A != null)
    //        {
    //            HOperatorSet.VectorAngleToRigid(IOCV.GenSuiDian_Y_Row, IOCV.GeuSuiDian_X_Col, IOCV.GenSuiDian_A, IOCV.IrectShuJuPianYi.Row, IOCV.IrectShuJuPianYi.Column, IOCV.IrectShuJuPianYi.Angle, out hv_ModMat2D);
    //            HOperatorSet.AffineTransRegion(ho_Rectangle, out ho_Rectangle, hv_ModMat2D, "nearest_neighbor");
    //        }

    //        //if (IOCV.Ihv_HomMat2D != null)
    //        //{
    //        //    HOperatorSet.AffineTransRegion(ho_Rectangle, out ho_Rectangle, IOCV.Ihv_HomMat2D.Hv_HomMat2D, "nearest_neighbor");            
    //        //}

    //        HOperatorSet.ReduceDomain(ho_Image, ho_Rectangle, out ho_ImageReduced);
    //        HTuple hv_Quality = null;
    //        HOperatorSet.DoOcvSimple(ho_ImageReduced, IOCV.Hv_OCVHandle, IOCV.Hv_PatternNames, IOCV.Hv_AdaptPos,
    //        IOCV.Hv_AdaptSize, IOCV.Hv_AdaptAngle, IOCV.Hv_AdaptGray, IOCV.Hv_Threshold, out hv_Quality);
    //        IOCV.Hv_Quality = hv_Quality;

    //        ho_ImageReduced.Dispose();

    //        IOCV.Ho_Rectangle.Dispose();
    //        IOCV.Ho_Rectangle = ho_Rectangle;

    //        #region  无用代码
    //        //disp_message(hwin, "质量:" + IOCV.Hv_Quality, "image", IOCV.Hv_Row1, IOCV.Hv_Column1 - 200,
    //        //     "black", "false");
    //        #endregion

    //        /********************************结果分析跟数据保存********************************************/
    //        Key = "OCV_" + Key;
    //        OCV_Result _result = new OCV_Result();
    //        _result._tolatName = Key;
    //        this.Result_Analyisis(IOCV, ref  _result);
    //        _dictionary_resulte.Add(Key, _result);

    //        //if (IOCV.OcvTrainedClass._allResult)
    //        //{
    //        //}
    //        //else
    //        //{
    //        //    _dictionary_resulte.Add(Key, _result);
    //        //}

    //        /**********************************显示质量，跟对错*********************************************************/
    //        HOperatorSet.GenContourRegionXld(ho_Rectangle, out ho_Rectangle, "border");
    //        if (IOCV.OcvTrainedClass._allResult)
    //        {
    //            disp_message(hwin, "质量:" + IOCV.Hv_Quality, "image", IOCV.IOutSide.Mid_row_y, IOCV.IOutSide.Mid_col_x, "black", "false");
    //            hwin.DispObj(ho_Rectangle);
    //            ok = true;
    //        }
    //        else
    //        {
    //            hwin.SetColor("red");
    //            hwin.DispObj(ho_Rectangle);
    //            hwin.SetColor("green");
    //        }
    //        ho_Rectangle.Dispose();


    //        return ok;
    //    }
    //    #endregion

    //    #region   ocv结果分析器
    //    /// <summary>
    //    /// ocv结果分析器
    //    /// </summary>
    //    /// <param name="IOCV"></param>
    //    /// <param name="ocvResult_"></param>
    //    void Result_Analyisis(IOCVShuJu IOCV, ref OCV_Result ocvResult_)
    //    {
    //        if (IOCV.Hv_Quality == null)
    //        {
    //            IOCV.OcvTrainedClass._allResult = false;
    //            ocvResult_.Hv_Quality = null;
    //            ocvResult_._Result = false;
    //            ocvResult_._tolatResult = false;
    //            return;
    //        }

    //        if (IOCV.OcvTrainedClass._trained)//判断有无训练
    //        {
    //            double quality_ = Convert.ToDouble(IOCV.Hv_Quality.ToString());
    //            if (quality_ < IOCV.OcvTrainedClass._ocvTrainingQuality)//质量对比
    //            {
    //                IOCV.OcvTrainedClass._allResult = false;
    //                //IOCV.OcvTrainedClass._result = false;
    //                ocvResult_.Hv_Quality = IOCV.Hv_Quality;

    //                ocvResult_._Result = false;
    //                ocvResult_._tolatResult = false;
    //            }
    //            else
    //            {
    //                IOCV.OcvTrainedClass._allResult = true;
    //                //IOCV.OcvTrainedClass._result = true;
    //                ocvResult_.Hv_Quality = IOCV.Hv_Quality;

    //                ocvResult_._Result = true;
    //                ocvResult_._tolatResult = true;
    //            }
    //        }
    //        else
    //        {
    //            IOCV.OcvTrainedClass._allResult = true;
    //            ocvResult_.Hv_Quality = IOCV.Hv_Quality;

    //            ocvResult_._Result = true;
    //            ocvResult_._tolatResult = true;
    //        }
    //    }
    //    #endregion
    //}
    //#endregion

    #region   无用代码
    //#region  ocv工具的创建器
    ///// <summary>
    ///// ocv工具的创建器
    ///// </summary>
    //public class OCVCreateShuJu
    //{
    //    #region  全局变量

    //    #region  当前训练的ocv是否有保存标志
    //    /// <summary>
    //    /// 当前训练的ocv是否有保存标志
    //    /// </summary>
    //    bool Save = false;

    //    #endregion

    //    #region  提取ocv检测的region 点位
    //    /// <summary>
    //    /// 提取ocv检测的region 点位 y1
    //    /// </summary>
    //    [NonSerialized]
    //    HTuple hv_Row1 = 1081.66;

    //    /// <summary>
    //    /// 提取ocv检测的region 点位 x1
    //    /// </summary>
    //    [NonSerialized]
    //    HTuple hv_Column1 = 469.3;

    //    /// <summary>
    //    /// 提取ocv检测的region 点位 y2
    //    /// </summary>
    //    [NonSerialized]
    //    HTuple hv_Row2 = 1263.1;

    //    /// <summary>
    //    /// 提取ocv检测的region 点位 x2
    //    /// </summary>
    //    [NonSerialized]
    //    HTuple hv_Column2 = 2034.22;
    //    #endregion

    //    #region  ocv的句柄
    //    /// <summary>
    //    /// ocv的句柄
    //    /// </summary>
    //    HTuple OCVHandle = null;
    //    #endregion

    //    #region 检测丝印的名称
    //    /// <summary>
    //    /// 检测丝印的名称
    //    /// </summary>
    //    HTuple hv_PatternNames = null;
    //    #endregion

    //    #region   ocv保存的路径
    //    /// <summary>
    //    /// ocv保存的路径
    //    /// </summary>
    //    string path = null;
    //    #endregion

    //    #region 当前ocv检测是输出的质量
    //    /// <summary>
    //    /// 当前ocv检测是输出的质量
    //    /// </summary>
    //    HTuple hv_Quality = null;
    //    #endregion
    //    #endregion

    //    #region  属性

    //    #region  当前ocv检测是输出的质量
    //    /// <summary>
    //    /// 当前ocv检测是输出的质量
    //    /// </summary>
    //    public HTuple Hv_Quality
    //    {
    //        get { return hv_Quality; }
    //        set { hv_Quality = value; }
    //    }
    //    #endregion

    //    #region  提取ocv检测的region 点位
    //    /// <summary>
    //    /// 提取ocv检测的region 点位 y1
    //    /// </summary>
    //    public HTuple Hv_Row1
    //    {
    //        get { return hv_Row1; }
    //        set { hv_Row1 = value; }
    //    }

    //    /// <summary>
    //    /// 提取ocv检测的region 点位 x1
    //    /// </summary>
    //    public HTuple Hv_Column1
    //    {
    //        get { return hv_Column1; }
    //        set { hv_Column1 = value; }
    //    }

    //    /// <summary>
    //    /// 提取ocv检测的region 点位 y2
    //    /// </summary>
    //    public HTuple Hv_Row2
    //    {
    //        get { return hv_Row2; }
    //        set { hv_Row2 = value; }
    //    }

    //    /// <summary>
    //    /// 提取ocv检测的region 点位 x2
    //    /// </summary>
    //    public HTuple Hv_Column2
    //    {
    //        get { return hv_Column2; }
    //        set { hv_Column2 = value; }
    //    }
    //    #endregion

    //    #region  ocv句柄
    //    /// <summary>
    //    /// ocv的句柄
    //    /// </summary>
    //    public HTuple OCVHandle1
    //    {
    //        get { return OCVHandle; }
    //        set { OCVHandle = value; }
    //    }
    //    #endregion

    //    #region 检测丝印的名称
    //    /// <summary>
    //    /// 检测丝印的名称
    //    /// </summary>
    //    public HTuple Hv_PatternNames
    //    {
    //        get
    //        {
    //            if (hv_PatternNames == null)
    //            {
    //                hv_PatternNames = "test";
    //            }
    //            return hv_PatternNames;
    //        }
    //        set { hv_PatternNames = value; }
    //    }
    //    #endregion

    //    #region ocv保存的路径
    //    /// <summary>
    //    /// ocv保存的路径
    //    /// </summary>
    //    public string Path
    //    {
    //        get
    //        {
    //            if (path == null)
    //            {
    //                if (Directory.Exists(AppDomain.CurrentDomain.BaseDirectory + @"Ocv\"))
    //                {
    //                    Directory.CreateDirectory(AppDomain.CurrentDomain.BaseDirectory + @"Ocv\");
    //                }

    //                string str = Hv_PatternNames.ToString().Replace("\"", "") + ".ocv";
    //                path = AppDomain.CurrentDomain.BaseDirectory + @"Ocv\" + str;

    //            }
    //            return path;
    //        }
    //        set { path = value; }
    //    }
    //    #endregion

    //    #endregion

    //    #region  创建ocv
    //    /// <summary>
    //    /// 创建ocv
    //    /// </summary>
    //    /// <param name="PatternNames"></param>
    //    /// <returns></returns>
    //    public bool CreateOCV(ref string PatternNames)
    //    {
    //        bool ok = false;
    //        if (OCVHandle1 != null)
    //        {
    //            HOperatorSet.CloseOcv(OCVHandle1);
    //        }
    //        HOperatorSet.CreateOcvProj(PatternNames, out OCVHandle);
    //        Hv_PatternNames = PatternNames;
    //        ok = true;
    //        return ok;
    //    }
    //    #endregion

    //    //#region   修改的丝印检测
    //    ///// <summary>
    //    ///// 修改的丝印检测
    //    ///// </summary>
    //    ///// <param name="IOCV"></param>
    //    ///// <returns></returns>
    //    //public bool ChangeOcv(IOCVShuJu IOCV)
    //    //{
    //    //    bool ok = false;
    //    //    if (OCVHandle != null)
    //    //    {
    //    //        HOperatorSet.CloseOcv(OCVHandle);
    //    //    }
    //    //    OCVHandle1 = IOCV.Hv_OCVHandle;
    //    //    Hv_PatternNames = IOCV.Hv_PatternNames;
    //    //    Hv_Row1 = IOCV.Hv_Row1;
    //    //    Hv_Column1 = IOCV.Hv_Column1;
    //    //    Hv_Row2 = IOCV.Hv_Row2;
    //    //    Hv_Column2 = IOCV.Hv_Column2;

    //    //    ok = true;
    //    //    return ok;
    //    //}
    //    //#endregion

    //    #region  设置训练的ocv区域点位
    //    /// <summary>
    //    /// 设置训练的ocv区域点位
    //    /// </summary>
    //    /// <param name="row1"></param>
    //    /// <param name="column1"></param>
    //    /// <param name="row2"></param>
    //    /// <param name="column2"></param>
    //    /// <returns></returns>
    //    public bool SetOCVCreateRegion(ref  double row1, ref double column1, ref double row2, ref double column2)
    //    {
    //        bool ok = false;

    //        Hv_Row1 = row1;
    //        Hv_Column1 = column1;
    //        Hv_Row2 = row2;
    //        Hv_Column2 = column2;

    //        ok = true;
    //        return ok;
    //    }
    //    #endregion

    //    //#region  训练ocv
    //    ///// <summary>
    //    ///// 训练ocv
    //    ///// </summary>
    //    ///// <param name="Ho_Image"></param>
    //    ///// <returns></returns>
    //    //public bool Training(HObject Ho_Image, IOCVShuJu IOCV,HWindow hwin)
    //    //{
    //    //    bool ok = false;

    //    //    if (OCVHandle == null)
    //    //    {
    //    //        MessageBox.Show("没有ocv训练指针");
    //    //        return false;
    //    //    }

    //    //    HObject Hreg;
    //    //    HOperatorSet.GenEmptyObj(out Hreg);
    //    //    HOperatorSet.GenRectangle1(out Hreg, Hv_Row1, Hv_Column1, Hv_Row2, Hv_Column2);
    //    //    HOperatorSet.ReduceDomain(Ho_Image, Hreg, out Hreg);

    //    //    HOperatorSet.TraindOcvProj(Hreg, OCVHandle1, Hv_PatternNames, "single");

    //    //    HTuple hv_Quality = null;
    //    //    HOperatorSet.DoOcvSimple(Hreg, OCVHandle1, Hv_PatternNames, IOCV.Hv_AdaptPos, IOCV.Hv_AdaptSize, IOCV.Hv_AdaptAngle, IOCV.Hv_AdaptGray, IOCV.Hv_Threshold, out hv_Quality);
    //    //    disp_message(hwin, "质量:" + hv_Quality, "image", Hv_Row1, Hv_Column1 - 200,
    //    //          "black", "false");

    //    //    ok = true;
    //    //    return ok;
    //    //}
    //    //#endregion

    //    #region   把当前训练的ocv写入当前ocv工具
    //    /// <summary>
    //    ///  把当前训练的ocv写入当前ocv工具
    //    /// </summary>
    //    /// <param name="IOCV"></param>
    //    /// <returns></returns>
    //    public bool Save_current_ocv_tool(IOCVShuJu IOCV)
    //    {
    //        bool ok = false;
    //        if (Save == false)
    //        {
    //            MessageBox.Show("当前训练的ocv还没保存,不能写入当前ocv工具");
    //            return ok;
    //        }
    //        IOCV.Hv_OCVHandle = OCVHandle1;
    //        IOCV.Hv_PatternNames = Hv_PatternNames;
    //        //IOCV.Hv_Row1 = Hv_Row1;
    //        //IOCV.Hv_Column1 = Hv_Column1;
    //        //IOCV.Hv_Row2 = Hv_Row2;
    //        //IOCV.Hv_Column2 = Hv_Column2;

    //        ok = true;
    //        return ok;
    //    }
    //    #endregion

    //    #region  保存训练的ocv
    //    /// <summary>
    //    /// 保存训练的ocv
    //    /// </summary>
    //    /// <returns></returns>
    //    public bool WriteOCVCreate()
    //    {
    //        bool ok = false;
    //        HOperatorSet.WriteOcv(OCVHandle, Path);
    //        Save = true;
    //        ok = true;
    //        return ok;
    //    }

    //    #endregion

    //    #region   测试当前ocv
    //    /// <summary>
    //    /// 测试当前ocv
    //    /// </summary>
    //    /// <param name="IOCV"></param>
    //    /// <param name="Ho_Image"></param>
    //    /// <returns></returns>
    //    public bool CheckTrainingOCV(IOCVShuJu IOCV, HObject Ho_Image, HWindow hwin)
    //    {
    //        bool ok = false;
    //        if (OCVHandle1 == null)
    //        {
    //            MessageBox.Show("没有训练");
    //        }

    //        HObject ho_ImageReduced;
    //        HOperatorSet.GenEmptyObj(out ho_ImageReduced);

    //        HObject ho_Rectangle;
    //        HOperatorSet.GenEmptyObj(out ho_Rectangle);
    //        ho_Rectangle.Dispose();
    //        HOperatorSet.GenRectangle1(out ho_Rectangle, Hv_Row1, Hv_Column1, Hv_Row2, Hv_Column2);
    //        //if (IOCV.Hv_HomMat2D != null)
    //        //{
    //        //    HOperatorSet.AffineTransRegion(ho_Rectangle, out ho_Rectangle, IOCV.Hv_HomMat2D, "nearest_neighbor");
    //        //}
    //        HObject contour;
    //        HOperatorSet.GenEmptyObj(out contour);
    //        HOperatorSet.GenContourRegionXld(ho_Rectangle, out contour, "border");
    //        contour.DispObj(hwin);

    //        HOperatorSet.ReduceDomain(Ho_Image, ho_Rectangle, out ho_ImageReduced);
    //        HTuple hv_Quality = null;
    //        HOperatorSet.DoOcvSimple(ho_ImageReduced, OCVHandle1, Hv_PatternNames, IOCV.Hv_AdaptPos, IOCV.Hv_AdaptSize, IOCV.Hv_AdaptAngle, IOCV.Hv_AdaptGray, IOCV.Hv_Threshold, out hv_Quality);

    //        disp_message(hwin, "质量:" + hv_Quality, "image", Hv_Row1, Hv_Column1 - 200,
    //              "black", "false");

    //        ok = true;
    //        return ok;
    //    }

    //    #region 显示
    //    public void disp_message(HTuple hv_WindowHandle, HTuple hv_String, HTuple hv_CoordSystem,
    //  HTuple hv_Row, HTuple hv_Column, HTuple hv_Color, HTuple hv_Box)
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

    //    #endregion

    //    #region 创建ocv
    //    /// <summary>
    //    /// 
    //    /// </summary>
    //    /// <param name="PatternNames"></param>
    //    /// <param name="Ho_Image"></param>
    //    /// <param name="hwin"></param>
    //    /// <param name="IOCV"></param>
    //    /// <returns></returns>
    //    public bool Training(ref string PatternNames, HObject Ho_Image, HWindow hwin, IOCVShuJu IOCV)
    //    {
    //        bool ok = false;
    //        //   double row1, column1, row2, column2;
    //        //hwin.DrawRectangle1(out row1, out column1, out row2, out column2);
    //        //HRegion Hreg = new HRegion(row1, column1, row2, column2);
    //        HObject Hreg;
    //        HOperatorSet.GenEmptyObj(out Hreg);
    //        HOperatorSet.GenRectangle1(out Hreg, Hv_Row1, Hv_Column1, Hv_Row2, Hv_Column2);
    //        HOperatorSet.ReduceDomain(Ho_Image, Hreg, out Hreg);

    //        if (OCVHandle1 != null)
    //        {
    //            HOperatorSet.CloseOcv(OCVHandle1);
    //        }
    //        HOperatorSet.CreateOcvProj(PatternNames, out OCVHandle);
    //        Hv_PatternNames = PatternNames;

    //        HOperatorSet.TraindOcvProj(Hreg, OCVHandle1, Hv_PatternNames, "single");
    //        HTuple hv_Quality = null;
    //        HOperatorSet.DoOcvSimple(Hreg, OCVHandle1, Hv_PatternNames, IOCV.Hv_AdaptPos, IOCV.Hv_AdaptSize, IOCV.Hv_AdaptAngle, IOCV.Hv_AdaptGray, IOCV.Hv_Threshold, out hv_Quality);
    //        disp_message(hwin, "质量:" + hv_Quality, "image", Hv_Row1, Hv_Column1 - 200,
    //              "black", "false");
    //        ok = true;
    //        return ok;
    //    }
    //    #endregion
    //}
    //#endregion
    #endregion

    #region   ocv结果
    /// <summary>
    ///  ocv结果
    /// </summary>
    public class OCV_Result : MultTree.ClassResultFather
    {
        /// <summary>
        /// 当前的质量
        /// </summary>
        public HTuple Hv_Quality = new HTuple();

        /// <summary>
        /// ocv总体结果
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
                str = this._tolatName + ":" + Hv_Quality.ToString();
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
                str_array[1] = this.Hv_Quality.ToString();
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
}
