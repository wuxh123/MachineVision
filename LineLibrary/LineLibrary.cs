using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HalconDotNet;
using System.Windows.Forms;
using RectLibrary;
using HalControl.ROI.Line;
using CalibrationLibrary;


namespace LineLibrary
{
    #region  拟合直线的数据
    /// <summary>
    /// 拟合直线的数据
    /// </summary>
    [Serializable]
    public class LineShuJu : MultTree.ToolDateFather, ILineShuJu
    {
        #region 全局变量

        #region   第一个点
        /// <summary>
        /// 第一个点
        /// </summary>
        IRectShuJuPianYi _irectShuJuPianYiOne = new RectShuJuPianYi();

        #endregion

        #region  第二个点
        /// <summary>
        /// 第二点
        /// </summary>
        IRectShuJuPianYi _irectShuJuPianYiTwo = new RectShuJuPianYi();
        #endregion

        #region    卡尺的数据
        /// <summary>
        /// 卡尺的个数
        /// </summary>
        [NonSerialized]
        HTuple hv_Elements = null;

        /// <summary>
        /// 卡尺的高
        /// </summary>
        [NonSerialized]
        HTuple hv_DetectHeight = null;

        /// <summary>
        /// 卡尺的宽
        /// </summary>
        [NonSerialized]
        HTuple hv_DetectWidth = null;
        #endregion

        //#region  防射变换
        /////// <summary>
        /////// 防射变换
        /////// </summary>
        ////[NonSerialized]
        ////HTuple hv_HomMat2D = null;

        ///// <summary>
        ///// 需要防射变化
        ///// </summary>
        //IRectShuJuHv_HomMat2D _ihv_HomMat2D = null;
        //#endregion

        //#region  标定数据
        ///// <summary>
        ///// 标定数据
        ///// </summary>
        //IHomMat2D _iCalibration = null;
        //#endregion

        #region   测量的数据
        /// <summary>
        /// 高斯滤波因子
        /// </summary>
        [NonSerialized]
        HTuple hv_Sigma = null;

        /// <summary>
        /// 边缘幅度阈值
        /// </summary>
        [NonSerialized]
        HTuple hv_Threshold = null;

        /// <summary>
        /// 极性：  positive表示由黑到白   negative表示由白到黑   all表示以上两种方向
        /// </summary>
        [NonSerialized]
        HTuple hv_Transition = null;

        /// <summary>
        /// >first表示选择第一点    last表示选择最后一点   max表示选择边缘强度最强点
        /// </summary>
        [NonSerialized]
        HTuple hv_Select = null;

        /// <summary>
        /// 最小有效点数
        /// </summary>
        [NonSerialized]
        HTuple hv_ActiveNum = null;
        #endregion

        #region   draw_rake输出的数据
        /// <summary>
        /// draw_rake输出的区域
        /// </summary>
        [NonSerialized]
        HObject ho_Regions_Draw;

        /// <summary>
        /// draw_rake输出线的开头点 y
        /// </summary>
        [NonSerialized]
        HTuple hv_Row1_Draw;

        /// <summary>
        /// draw_rake输出线的开头 x
        /// </summary>
        [NonSerialized]
        HTuple hv_Column1_Draw;

        /// <summary>
        /// draw_rake输出线的结束点 y
        /// </summary>
        [NonSerialized]
        HTuple hv_Row2_Draw;

        /// <summary>
        /// draw_rake输出线的结束点 x
        /// </summary>
        [NonSerialized]
        HTuple hv_Column2_Draw;
        #endregion

        #region   rake输出的数据
        /// <summary>
        /// rake输出的数据
        /// </summary>
        [NonSerialized]
        HObject ho_Regions_Rake = null;

        /// <summary>
        /// 检测到的边缘点的y坐标数组    拟合圆的边缘y数组
        /// </summary>
        [NonSerialized]
        HTuple hv_ResultRow = null;

        /// <summary>
        /// 检测到的边缘点的x坐标数组   拟合圆的边缘x数组
        /// </summary>
        [NonSerialized]
        HTuple hv_ResultColumn = null;
        #endregion

        #region   拟合的直线输出的数据
        /// <summary>
        /// 拟合的直线
        /// </summary>
        [NonSerialized]
        HObject ho_Line;

        ///// <summary>
        ///// 拟合的直线开头点 y
        ///// </summary>
        //[NonSerialized]
        //HTuple hv_Row11;

        ///// <summary>
        ///// 拟合的直线开头点 x
        ///// </summary>
        //[NonSerialized]
        //HTuple hv_Column11;


        ///// <summary>
        ///// 拟合的直线结束点 y
        ///// </summary>
        //[NonSerialized]
        //HTuple hv_Row21;

        ///// <summary>
        ///// 拟合的直线结束点 x
        ///// </summary>
        //[NonSerialized]
        //HTuple hv_Column21;

        /// <summary>
        /// 找到直线点，端点，中点
        /// </summary>
        [NonSerialized]
        HObject _ho_Cross;

        #endregion

        #region   外部接口
        /// <summary>
        /// 外部接口 
        /// </summary>
        IOutsideLineROI _iOutSide;

        #endregion

        #region   结果
        /// <summary>
        /// 结果
        /// </summary>
        [NonSerialized]
        Line_Result _result = new Line_Result();
        #endregion

        #endregion

        #region   构造函数
        /// <summary>
        /// 构造函数
        /// </summary>
        public LineShuJu()
        {

        }
        #endregion

        #region  属性

        #region 第一个点
        /// <summary>
        /// 第一个点
        /// </summary>
        public IRectShuJuPianYi IrectShuJuPianYiOne
        {
            get { return _irectShuJuPianYiOne; }
            set { _irectShuJuPianYiOne = value; }
        }
        #endregion

        #region  第二个点
        /// <summary>
        /// 第二点
        /// </summary>
        public IRectShuJuPianYi IrectShuJuPianYiTwo
        {
            get { return _irectShuJuPianYiTwo; }
            set { _irectShuJuPianYiTwo = value; }
        }
        #endregion

        #region    卡尺的数据
        /// <summary>
        /// 卡尺的个数
        /// </summary>
        public HTuple Hv_Elements
        {
            get
            {
                if (hv_Elements == null)
                {
                    hv_Elements = 30;
                }
                return hv_Elements;
            }

            set { hv_Elements = value; }
        }

        /// <summary>
        /// 卡尺的高
        /// </summary>
        public HTuple Hv_DetectHeight
        {
            get
            {
                if (hv_DetectHeight == null)
                {
                    hv_DetectHeight = 60;
                }
                return hv_DetectHeight;
            }

            set { hv_DetectHeight = value; }
        }

        /// <summary>
        /// 卡尺的宽
        /// </summary>
        public HTuple Hv_DetectWidth
        {
            get
            {
                if (hv_DetectWidth == null)
                {
                    hv_DetectWidth = 15;
                }
                return hv_DetectWidth;
            }

            set { hv_DetectWidth = value; }
        }
        #endregion

        //#region  防射变换
        /////// <summary>
        /////// 防射变换
        /////// </summary>
        ////public HTuple Hv_HomMat2D
        ////{
        ////    get { return hv_HomMat2D; }
        ////    set { hv_HomMat2D = value; }
        ////}

        /////// <summary>
        /////// 需要防射变化
        /////// </summary>
        ////public IRectShuJuHv_HomMat2D Ihv_HomMat2D
        ////{
        ////    get { return _ihv_HomMat2D; }
        ////    set { _ihv_HomMat2D = value; }
        ////}

        //#endregion

        #region   rake输出的数据
        /// <summary>
        /// rake输出的数据
        /// </summary>
        public HObject Ho_Regions_Rake
        {
            get
            {
                if (ho_Regions_Rake == null)
                {
                    HOperatorSet.GenEmptyObj(out ho_Regions_Rake);
                    ho_Regions_Rake.Dispose();
                }
                return ho_Regions_Rake;
            }
            set { ho_Regions_Rake = value; }
        }

        /// <summary>
        /// 检测到的边缘点的y坐标数组    拟合圆的边缘y数组
        /// </summary>
        public HTuple Hv_ResultRow
        {
            get { return hv_ResultRow; }
            set { hv_ResultRow = value; }
        }

        /// <summary>
        /// 检测到的边缘点的x坐标数组   拟合圆的边缘x数组
        /// </summary>
        public HTuple Hv_ResultColumn
        {
            get { return hv_ResultColumn; }
            set { hv_ResultColumn = value; }
        }

        #endregion

        #region   draw_rake输出的数据
        /// <summary>
        /// draw_rake输出的区域
        /// </summary>
        public HObject Ho_Regions_Draw
        {
            get
            {
                if (ho_Regions_Draw == null)
                {
                    HOperatorSet.GenEmptyObj(out ho_Regions_Draw);
                    ho_Regions_Draw.Dispose();
                }
                return ho_Regions_Draw;
            }
            set { ho_Regions_Draw = value; }
        }

        /// <summary>
        /// draw_rake输出线的开头点 y
        /// </summary>
        public HTuple Hv_Row1_Draw
        {
            get { return hv_Row1_Draw; }
            set { hv_Row1_Draw = value; }
        }

        /// <summary>
        /// draw_rake输出线的开头 x
        /// </summary>
        public HTuple Hv_Column1_Draw
        {
            get { return hv_Column1_Draw; }
            set { hv_Column1_Draw = value; }
        }

        /// <summary>
        /// draw_rake输出线的结束点 y
        /// </summary>
        public HTuple Hv_Row2_Draw
        {
            get { return hv_Row2_Draw; }
            set { hv_Row2_Draw = value; }
        }

        /// <summary>
        /// draw_rake输出线的结束点 x
        /// </summary>
        public HTuple Hv_Column2_Draw
        {
            get { return hv_Column2_Draw; }
            set { hv_Column2_Draw = value; }
        }

        #endregion

        #region  拟合的直线

        /// <summary>
        /// 拟合的直线
        /// </summary>
        public HObject Ho_Line
        {
            get
            {
                if (ho_Line == null)
                {
                    HOperatorSet.GenEmptyObj(out ho_Line);
                    ho_Line.Dispose();
                }
                return ho_Line;
            }
            set { ho_Line = value; }
        }

        ///// <summary>
        ///// 拟合的直线开头点 y
        ///// </summary>
        //public HTuple Hv_Row11
        //{
        //    get { return hv_Row11; }
        //    set { hv_Row11 = value; }
        //}

        ///// <summary>
        ///// 拟合的直线开头点 x
        ///// </summary>
        //public HTuple Hv_Column11
        //{
        //    get { return hv_Column11; }
        //    set { hv_Column11 = value; }
        //}

        ///// <summary>
        ///// 拟合的直线结束点 y
        ///// </summary>
        //public HTuple Hv_Row21
        //{
        //    get { return hv_Row21; }
        //    set { hv_Row21 = value; }
        //}

        ///// <summary>
        ///// 拟合的直线结束点 x
        ///// </summary>
        //public HTuple Hv_Column21
        //{
        //    get { return hv_Column21; }
        //    set { hv_Column21 = value; }
        //}

        #endregion

        #region  测量的数据
        /// <summary>
        /// 高斯滤波因子
        /// </summary>
        public HTuple Hv_Sigma
        {
            get
            {
                if (hv_Sigma == null)
                {
                    hv_Sigma = 4;
                }
                return hv_Sigma;
            }
            set { hv_Sigma = value; }
        }

        /// <summary>
        /// 边缘幅度阈值
        /// </summary>
        public HTuple Hv_Threshold
        {
            get
            {
                if (hv_Threshold == null)
                {
                    hv_Threshold = 20;
                }
                return hv_Threshold;
            }
            set { hv_Threshold = value; }
        }

        /// <summary>
        /// 极性：  positive表示由黑到白   negative表示由白到黑   all表示以上两种方向
        /// </summary>
        public HTuple Hv_Transition
        {
            get
            {
                if (hv_Transition == null)
                {
                    hv_Transition = "all";
                }
                return hv_Transition;
            }
            set { hv_Transition = value; }
        }

        /// <summary>
        /// >first表示选择第一点    last表示选择最后一点   max表示选择边缘强度最强点
        /// </summary>
        public HTuple Hv_Select
        {
            get
            {
                if (hv_Select == null)
                {
                    hv_Select = "max";
                }
                return hv_Select;
            }
            set { hv_Select = value; }
        }

        /// <summary>
        /// 最小有效点数
        /// </summary>
        public HTuple Hv_ActiveNum
        {
            get
            {
                if (hv_ActiveNum == null)
                {
                    hv_ActiveNum = 3;
                }
                return hv_ActiveNum;
            }
            set { hv_ActiveNum = value; }
        }
        #endregion

        #region  外部接口
        /// <summary>
        /// 外部接口 
        /// </summary>
        public IOutsideLineROI IOutSide
        {
            get
            {
                if (_iOutSide == null)
                {
                    _iOutSide = new OutsideLineROI();
                    _iOutSide.Row1 = 100;
                    _iOutSide.Cols1 = 100;
                    _iOutSide.Row2 = 100;
                    _iOutSide.Cols2 = 200;
                }
                return _iOutSide;
            }
            set { _iOutSide = value; }
        }
        #endregion

        #region 找到直线点，端点，中点
        /// <summary>
        /// 找到直线点，端点，中点
        /// </summary>
        public HObject Ho_Cross
        {
            get
            {
                if (_ho_Cross == null)
                {
                    HOperatorSet.GenEmptyObj(out _ho_Cross);
                    _ho_Cross.Dispose();
                }
                return _ho_Cross;
            }
            set { _ho_Cross = value; }
        }
        #endregion

        #endregion

        #region   序列化数据

        #region    卡尺的数据
        /// <summary>
        /// 卡尺的个数
        /// </summary>
        object hv_Elements_1;

        /// <summary>
        /// 卡尺的高
        /// </summary>
        object hv_DetectHeight_1;

        /// <summary>
        /// 卡尺的宽
        /// </summary>
        object hv_DetectWidth_1;
        #endregion

        #region   测量的数据
        /// <summary>
        /// 高斯滤波因子
        /// </summary>
        object hv_Sigma_1;

        /// <summary>
        /// 边缘幅度阈值
        /// </summary>
        object hv_Threshold_1;

        /// <summary>
        /// 极性：  positive表示由黑到白   negative表示由白到黑   all表示以上两种方向
        /// </summary>
        object hv_Transition_1;

        /// <summary>
        /// >first表示选择第一点    last表示选择最后一点   max表示选择边缘强度最强点
        /// </summary>
        object hv_Select_1;

        /// <summary>
        /// 最小有效点数
        /// </summary>
        object hv_ActiveNum_1;

        #endregion

        #region  外部接口
        Object row1_1;
        Object col1_1;
        Object row2_1;
        Object col2_1;
        #endregion

        #endregion

        #region  初始化数据
        /// <summary>
        /// 初始化数据
        /// </summary>
        public override void init()
        {
            base.init();

            #region    卡尺的数据
            hv_Elements = (HTuple)hv_Elements_1;

            hv_DetectHeight = (HTuple)hv_DetectHeight_1;

            hv_DetectWidth = (HTuple)hv_DetectWidth_1;
            #endregion

            #region   测量的数据
            hv_Sigma = (HTuple)hv_Sigma_1;

            hv_Threshold = (HTuple)hv_Threshold_1;

            hv_Transition = (HTuple)hv_Transition_1;

            hv_Select = (HTuple)hv_Select_1;

            hv_ActiveNum = (HTuple)hv_ActiveNum_1;
            #endregion

            #region  外部接口
            this.IOutSide.Row1 = (HTuple)row1_1;
            this.IOutSide.Cols1 = (HTuple)col1_1;
            this.IOutSide.Row2 = (HTuple)row2_1;
            this.IOutSide.Cols2 = (HTuple)col2_1;
            #endregion

            _result = new Line_Result();

            //#region   draw_rake输出的数据
            //HOperatorSet.GenEmptyObj(out ho_Regions_Draw);
            //ho_Regions_Draw.Dispose();
            //ho_Regions_Draw = (HObject)ho_Regions_Draw_1;
            //hv_Row1_Draw = (HTuple)hv_Row1_Draw_1;
            //hv_Column1_Draw = (HTuple)hv_Column1_Draw_1;
            //hv_Row2_Draw = (HTuple)hv_Row2_Draw_1;
            //hv_Column2_Draw = (HTuple)hv_Column2_Draw_1;
            //#endregion
        }
        #endregion

        #region   保存数据
        /// <summary>
        /// 保存数据
        /// </summary>
        public override void save()
        {
            base.save();

            #region    卡尺的数据
            hv_Elements_1 = hv_Elements;

            hv_DetectHeight_1 = hv_DetectHeight;

            hv_DetectWidth_1 = hv_DetectWidth;
            #endregion

            #region   测量的数据
            hv_Sigma_1 = hv_Sigma;

            hv_Threshold_1 = hv_Threshold;

            hv_Transition_1 = hv_Transition;

            hv_Select_1 = hv_Select;

            hv_ActiveNum_1 = hv_ActiveNum;
            #endregion

            #region  外部接口
            row1_1 = this.IOutSide.Row1;
            col1_1 = this.IOutSide.Cols1;
            row2_1 = this.IOutSide.Row2;
            col2_1 = this.IOutSide.Cols2;
            #endregion


            //#region   draw_rake输出的数据
            //ho_Regions_Draw_1 = ho_Regions_Draw;
            //hv_Row1_Draw_1 = hv_Row1_Draw;
            //hv_Column1_Draw_1 = hv_Column1_Draw;
            //hv_Row2_Draw_1 = hv_Row2_Draw;
            //hv_Column2_Draw_1 = hv_Column2_Draw;
            //#endregion
        }
        #endregion

        #region  检测
        public override bool analyze_show(HWindow hwin, string Key, ref Dictionary<string, object> _dictionary_resulte)
        {
            bool ok = false;
            /***************************************处理************************************************************/
            HObject ho_Regions_, ho_Line_;
            HOperatorSet.GenEmptyObj(out ho_Regions_);
            HTuple oneRow_, oneCol_, twoRow_, twoCol_;

            if (IrectShuJuPianYi != null)
            {
                HTuple hv_modMat2D_, crossRow_ = new HTuple(), crossCol_ = new HTuple(), Nr, Nc, Dist;
                HObject contour_;
                HOperatorSet.GenEmptyObj(out contour_);
                HOperatorSet.VectorAngleToRigid(GenSuiDian_Y_Row, GeuSuiDian_X_Col, GenSuiDian_A, IrectShuJuPianYi.Row, IrectShuJuPianYi.Column, IrectShuJuPianYi.Angle, out hv_modMat2D_);
                crossRow_[0] = IOutSide.Row1.D;
                crossRow_[1] = IOutSide.Row2.D;
                crossCol_[0] = IOutSide.Cols1.D;
                crossCol_[1] = IOutSide.Cols2.D;
                HOperatorSet.GenContourPolygonXld(out contour_, crossRow_, crossCol_);

                HOperatorSet.AffineTransContourXld(contour_, out contour_, hv_modMat2D_);

                HOperatorSet.FitLineContourXld(contour_, "tukey", -1, 0, 5, 2, out oneRow_, out oneCol_, out twoRow_, out twoCol_, out Nr, out Nc, out Dist);
                contour_.Dispose();
            }
            else
            {
                oneCol_ = IOutSide.Cols1;
                oneRow_ = IOutSide.Row1;
                twoCol_ = IOutSide.Cols2;
                twoRow_ = IOutSide.Row2;
            }

            #region  无用代码
            //HTuple[] Hv_Row_Draw = new HTuple[2], Hv_Column_Draw = new HTuple[2];           
            //if (ILine_.Ihv_HomMat2D != null)
            //{
            //    HObject coutour;
            //    HOperatorSet.GenEmptyObj(out coutour);
            //    Hv_Row_Draw[0] = ILine_.Hv_Row1_Draw;
            //    Hv_Row_Draw[1] = ILine_.Hv_Row2_Draw;
            //    Hv_Column_Draw[0] = ILine_.Hv_Column1_Draw;
            //    Hv_Column_Draw[1] = ILine_.Hv_Column2_Draw;

            //    HTuple Hv_ROIRows, Hv_ROICols;

            //    HOperatorSet.GenContourPolygonXld(out coutour, Hv_Row_Draw, Hv_Column_Draw);
            //    HOperatorSet.AffineTransContourXld(coutour, out coutour, ILine_.Ihv_HomMat2D.Hv_HomMat2D);
            //    HOperatorSet.GetContourXld(coutour, out Hv_ROIRows, out Hv_ROICols);

            //    if (Hv_ROIRows.Length == 2)
            //    {
            //        Hv_Row_Draw[0] = Hv_ROIRows[0];
            //        Hv_Row_Draw[1] = Hv_ROIRows[1];

            //    }
            //    if (Hv_ROICols.Length == 2)
            //    {

            //        Hv_Column_Draw[0] = Hv_ROICols[0];
            //        Hv_Column_Draw[1] = Hv_ROICols[1];
            //    }
            //}
            //else
            //{
            //    Hv_Row_Draw[0] = ILine_.Hv_Row1_Draw;
            //    Hv_Row_Draw[1] = ILine_.Hv_Row2_Draw;
            //    Hv_Column_Draw[0] = ILine_.Hv_Column1_Draw;
            //    Hv_Column_Draw[1] = ILine_.Hv_Column2_Draw;
            //}
            #endregion
            HTuple resultRow_, resultCol_, beginRow_, beginCol_, endRow_, endCol_, centerRow_, centerCol_;

            rake(this.ImageFather.Ho_image, out ho_Regions_, Hv_Elements, Hv_DetectHeight, Hv_DetectWidth, Hv_Sigma, Hv_Threshold
                , Hv_Transition, Hv_Select, oneRow_, oneCol_, twoRow_, twoCol_, out resultRow_, out resultCol_);

            Ho_Regions_Draw.Dispose();
            Ho_Regions_Draw = ho_Regions_;

            Hv_ResultRow = resultRow_;
            Hv_ResultColumn = resultCol_;

            HObject ho_Regions1;
            HOperatorSet.GenEmptyObj(out ho_Regions1);
            ho_Regions1.Dispose();
            HOperatorSet.GenCrossContourXld(out ho_Regions1, resultRow_, resultCol_, 6, 0.785398);

            Ho_Regions_Rake.Dispose();
            Ho_Regions_Rake = ho_Regions1;

            pts_to_best_line(out ho_Line_, Hv_ResultRow, Hv_ResultColumn, Hv_ActiveNum, out beginRow_, out beginCol_, out endRow_, out endCol_, out centerRow_, out centerCol_);

            this.IrectShuJuPianYiOne.Column = beginCol_;
            this.IrectShuJuPianYiOne.Row = beginRow_;

            this.IrectShuJuPianYiTwo.Row = endRow_;
            this.IrectShuJuPianYiTwo.Column = endCol_;

            HOperatorSet.LineOrientation(this.IrectShuJuPianYiOne.Row, this.IrectShuJuPianYiOne.Column, this.IrectShuJuPianYiTwo.Row, this.IrectShuJuPianYiTwo.Column, out angle);

            Row = centerRow_;
            Column = centerCol_;
            //Angle = 0;

            Ho_Line.Dispose();
            Ho_Line = ho_Line_;

            HTuple row_ = new HTuple(), col_ = new HTuple();

            row_[0] = beginRow_;
            row_[1] = endRow_;
            row_[2] = centerRow_;

            col_[0] = beginCol_;
            col_[1] = endCol_;
            col_[2] = centerCol_;

            HObject ho_cross;
            HOperatorSet.GenEmptyObj(out ho_cross);
            HOperatorSet.GenCrossContourXld(out ho_cross, row_, col_, 60, 0.785398);

            Ho_Cross.Dispose();
            Ho_Cross = ho_cross;

            /*************数据分析*************************/
            Key = "Line_" + Key;
            //Line_Result lineResult_ = new Line_Result();
            _result._tolatName = Key;

            if ((this.IrectShuJuPianYiOne.Column.D == 0) || (this.IrectShuJuPianYiTwo.Column.D == 0) || (this.IrectShuJuPianYiOne.Row.D == 0) || (this.IrectShuJuPianYiTwo.Row.D == 0))
            {
                _result._tolatResult = false;
            }
            else
            {
                _result._tolatResult = true;
                _result.HV_CenCol = Column;
                _result.Hv_CenRow = Row;
                _result.Hv_Column11 = this.IrectShuJuPianYiOne.Column;
                _result.Hv_Row11 = this.IrectShuJuPianYiOne.Row;
                _result.Hv_Row21 = this.IrectShuJuPianYiTwo.Row;
                _result.Hv_Column21 = this.IrectShuJuPianYiTwo.Column;
                _result.HV_Angle = Angle;

                if (_ICalibration != null)//判断有无标定
                {
                    this.Cal(_ICalibration.HomMat2D, ref _result.Hv_CenRow, ref _result.HV_CenCol);
                    this.Cal(_ICalibration.HomMat2D, ref _result.Hv_Row11, ref _result.Hv_Column11);
                    this.Cal(_ICalibration.HomMat2D, ref _result.Hv_Row21, ref _result.Hv_Column21);
                    //Column = _result.HV_CenCol;
                    //Row = _result.Hv_CenRow;
                    //this.IrectShuJuPianYiOne.Column = _result.Hv_Column11;
                    //this.IrectShuJuPianYiOne.Row = _result.Hv_Row11;
                    //this.IrectShuJuPianYiTwo.Column = _result.Hv_Column21;
                    //this.IrectShuJuPianYiTwo.Row = _result.Hv_Row21;
                }
                ok = true;
            }

            /*******保存数据**************/
            _dictionary_resulte.Add(Key, _result);

            show(hwin);

            return ok;
        }
        #endregion

        #region  显示

        public override bool show(HWindow hwin)
        {
            bool ok = false;

            hwin.DispObj(Ho_Regions_Draw);
            hwin.DispObj(Ho_Regions_Rake);
            hwin.DispObj(Ho_Cross);
            hwin.DispObj(Ho_Line);

            return ok;
        }
        #endregion

        #region  卡尺工具  拟合线
        void rake(HObject ho_Image, out HObject ho_Regions, HTuple hv_Elements,
   HTuple hv_DetectHeight, HTuple hv_DetectWidth, HTuple hv_Sigma, HTuple hv_Threshold,
   HTuple hv_Transition, HTuple hv_Select, HTuple hv_Row1, HTuple hv_Column1, HTuple hv_Row2,
   HTuple hv_Column2, out HTuple hv_ResultRow, out HTuple hv_ResultColumn)
        {
            // Stack for temporary objects 
            HObject[] OTemp = new HObject[20];
            // Local iconic variables 
            HObject ho_RegionLines, ho_Rectangle = null;
            HObject ho_Arrow1 = null;
            // Local control variables 
            HTuple hv_Width = null, hv_Height = null, hv_ATan = null;
            HTuple hv_i = null, hv_RowC = new HTuple(), hv_ColC = new HTuple();
            HTuple hv_Distance = new HTuple(), hv_RowL2 = new HTuple();
            HTuple hv_RowL1 = new HTuple(), hv_ColL2 = new HTuple();
            HTuple hv_ColL1 = new HTuple(), hv_MsrHandle_Measure = new HTuple();
            HTuple hv_RowEdge = new HTuple(), hv_ColEdge = new HTuple();
            HTuple hv_Amplitude = new HTuple(), hv_tRow = new HTuple();
            HTuple hv_tCol = new HTuple(), hv_t = new HTuple(), hv_Number = new HTuple();
            HTuple hv_j = new HTuple();
            HTuple hv_DetectWidth_COPY_INP_TMP = hv_DetectWidth.Clone();
            HTuple hv_Select_COPY_INP_TMP = hv_Select.Clone();
            HTuple hv_Transition_COPY_INP_TMP = hv_Transition.Clone();

            hv_ResultRow = new HTuple();
            hv_ResultColumn = new HTuple();
            // Initialize local and output iconic variables 
            HOperatorSet.GenEmptyObj(out ho_Regions);
            HOperatorSet.GenEmptyObj(out ho_RegionLines);
            HOperatorSet.GenEmptyObj(out ho_Rectangle);
            HOperatorSet.GenEmptyObj(out ho_Arrow1);
            try
            {

                hv_ResultColumn[0] = 0;
                hv_ResultColumn[0] = 0;

                //获取图像尺寸
                HOperatorSet.GetImageSize(ho_Image, out hv_Width, out hv_Height);
                //产生一个空显示对象，用于显示
                ho_Regions.Dispose();
                HOperatorSet.GenEmptyObj(out ho_Regions);
                //初始化边缘坐标数组
                hv_ResultRow = new HTuple();
                hv_ResultColumn = new HTuple();
                //产生直线xld
                ho_RegionLines.Dispose();
                HOperatorSet.GenContourPolygonXld(out ho_RegionLines, hv_Row1.TupleConcat(hv_Row2),
                    hv_Column1.TupleConcat(hv_Column2));
                //存储到显示对象
                {
                    HObject ExpTmpOutVar_0;
                    HOperatorSet.ConcatObj(ho_Regions, ho_RegionLines, out ExpTmpOutVar_0);
                    ho_Regions.Dispose();
                    ho_Regions = ExpTmpOutVar_0;
                }
                //计算直线与x轴的夹角，逆时针方向为正向。
                HOperatorSet.AngleLx(hv_Row1, hv_Column1, hv_Row2, hv_Column2, out hv_ATan);

                //边缘检测方向垂直于检测直线：直线方向正向旋转90°为边缘检测方向
                hv_ATan = hv_ATan + ((new HTuple(90)).TupleRad());

                //根据检测直线按顺序产生测量区域矩形，并存储到显示对象
                HTuple end_val18 = hv_Elements;
                HTuple step_val18 = 1;
                for (hv_i = 1; hv_i.Continue(end_val18, step_val18); hv_i = hv_i.TupleAdd(step_val18))
                {
                    //RowC := Row1+(((Row2-Row1)*i)/(Elements+1))
                    //ColC := Column1+(Column2-Column1)*i/(Elements+1)
                    //if (RowC>Height-1 or RowC<0 or ColC>Width-1 or ColC<0)
                    //continue
                    //endif
                    //如果只有一个测量矩形，作为卡尺工具，宽度为检测直线的长度
                    if ((int)(new HTuple(hv_Elements.TupleEqual(1))) != 0)
                    {
                        hv_RowC = (hv_Row1 + hv_Row2) * 0.5;
                        hv_ColC = (hv_Column1 + hv_Column2) * 0.5;
                        //判断是否超出图像,超出不检测边缘
                        if ((int)((new HTuple((new HTuple((new HTuple(hv_RowC.TupleGreater(hv_Height - 1))).TupleOr(
                            new HTuple(hv_RowC.TupleLess(0))))).TupleOr(new HTuple(hv_ColC.TupleGreater(
                            hv_Width - 1))))).TupleOr(new HTuple(hv_ColC.TupleLess(0)))) != 0)
                        {
                            continue;
                        }
                        HOperatorSet.DistancePp(hv_Row1, hv_Column1, hv_Row2, hv_Column2, out hv_Distance);
                        hv_DetectWidth_COPY_INP_TMP = hv_Distance.Clone();
                        ho_Rectangle.Dispose();
                        HOperatorSet.GenRectangle2ContourXld(out ho_Rectangle, hv_RowC, hv_ColC,
                            hv_ATan, hv_DetectHeight / 2, hv_Distance / 2);
                    }
                    else
                    {
                        //如果有多个测量矩形，产生该测量矩形xld
                        hv_RowC = hv_Row1 + (((hv_Row2 - hv_Row1) * (hv_i - 1)) / (hv_Elements - 1));
                        hv_ColC = hv_Column1 + (((hv_Column2 - hv_Column1) * (hv_i - 1)) / (hv_Elements - 1));
                        //判断是否超出图像,超出不检测边缘
                        if ((int)((new HTuple((new HTuple((new HTuple(hv_RowC.TupleGreater(hv_Height - 1))).TupleOr(
                            new HTuple(hv_RowC.TupleLess(0))))).TupleOr(new HTuple(hv_ColC.TupleGreater(
                            hv_Width - 1))))).TupleOr(new HTuple(hv_ColC.TupleLess(0)))) != 0)
                        {
                            continue;
                        }
                        ho_Rectangle.Dispose();
                        HOperatorSet.GenRectangle2ContourXld(out ho_Rectangle, hv_RowC, hv_ColC,
                            hv_ATan, hv_DetectHeight / 2, hv_DetectWidth_COPY_INP_TMP / 2);
                    }

                    //把测量矩形xld存储到显示对象
                    {
                        HObject ExpTmpOutVar_0;
                        HOperatorSet.ConcatObj(ho_Regions, ho_Rectangle, out ExpTmpOutVar_0);
                        ho_Regions.Dispose();
                        ho_Regions = ExpTmpOutVar_0;
                    }
                    if ((int)(new HTuple(hv_i.TupleEqual(1))) != 0)
                    {
                        //在第一个测量矩形绘制一个箭头xld，用于只是边缘检测方向
                        hv_RowL2 = hv_RowC + ((hv_DetectHeight / 2) * (((-hv_ATan)).TupleSin()));
                        hv_RowL1 = hv_RowC - ((hv_DetectHeight / 2) * (((-hv_ATan)).TupleSin()));
                        hv_ColL2 = hv_ColC + ((hv_DetectHeight / 2) * (((-hv_ATan)).TupleCos()));
                        hv_ColL1 = hv_ColC - ((hv_DetectHeight / 2) * (((-hv_ATan)).TupleCos()));
                        ho_Arrow1.Dispose();
                        gen_arrow_contour_xld(out ho_Arrow1, hv_RowL1, hv_ColL1, hv_RowL2, hv_ColL2,
                            25, 25);
                        //把xld存储到显示对象
                        {
                            HObject ExpTmpOutVar_0;
                            HOperatorSet.ConcatObj(ho_Regions, ho_Arrow1, out ExpTmpOutVar_0);
                            ho_Regions.Dispose();
                            ho_Regions = ExpTmpOutVar_0;
                        }
                    }
                    //产生测量对象句柄
                    HOperatorSet.GenMeasureRectangle2(hv_RowC, hv_ColC, hv_ATan, hv_DetectHeight / 2,
                        hv_DetectWidth_COPY_INP_TMP / 2, hv_Width, hv_Height, "nearest_neighbor",
                        out hv_MsrHandle_Measure);

                    //设置极性
                    if ((int)(new HTuple(hv_Transition_COPY_INP_TMP.TupleEqual("negative"))) != 0)
                    {
                        hv_Transition_COPY_INP_TMP = "negative";
                    }
                    else
                    {
                        if ((int)(new HTuple(hv_Transition_COPY_INP_TMP.TupleEqual("positive"))) != 0)
                        {

                            hv_Transition_COPY_INP_TMP = "positive";
                        }
                        else
                        {
                            hv_Transition_COPY_INP_TMP = "all";
                        }
                    }
                    //设置边缘位置。最强点是从所有边缘中选择幅度绝对值最大点，需要设置为'all'
                    if ((int)(new HTuple(hv_Select_COPY_INP_TMP.TupleEqual("first"))) != 0)
                    {
                        hv_Select_COPY_INP_TMP = "first";
                    }
                    else
                    {
                        if ((int)(new HTuple(hv_Select_COPY_INP_TMP.TupleEqual("last"))) != 0)
                        {

                            hv_Select_COPY_INP_TMP = "last";
                        }
                        else
                        {
                            hv_Select_COPY_INP_TMP = "all";
                        }
                    }
                    //检测边缘
                    HOperatorSet.MeasurePos(ho_Image, hv_MsrHandle_Measure, hv_Sigma, hv_Threshold,
                        hv_Transition_COPY_INP_TMP, hv_Select_COPY_INP_TMP, out hv_RowEdge, out hv_ColEdge,
                        out hv_Amplitude, out hv_Distance);
                    //清除测量对象句柄
                    HOperatorSet.CloseMeasure(hv_MsrHandle_Measure);

                    //临时变量初始化
                    //tRow，tCol保存找到指定边缘的坐标
                    hv_tRow = 0;
                    hv_tCol = 0;
                    //t保存边缘的幅度绝对值
                    hv_t = 0;
                    //找到的边缘必须至少为1个
                    HOperatorSet.TupleLength(hv_RowEdge, out hv_Number);
                    if ((int)(new HTuple(hv_Number.TupleLess(1))) != 0)
                    {
                        continue;
                    }
                    //有多个边缘时，选择幅度绝对值最大的边缘
                    HTuple end_val100 = hv_Number - 1;
                    HTuple step_val100 = 1;
                    for (hv_j = 0; hv_j.Continue(end_val100, step_val100); hv_j = hv_j.TupleAdd(step_val100))
                    {
                        if ((int)(new HTuple(((((hv_Amplitude.TupleSelect(hv_j))).TupleAbs())).TupleGreater(
                            hv_t))) != 0)
                        {

                            hv_tRow = hv_RowEdge.TupleSelect(hv_j);
                            hv_tCol = hv_ColEdge.TupleSelect(hv_j);
                            hv_t = ((hv_Amplitude.TupleSelect(hv_j))).TupleAbs();
                        }
                    }
                    //把找到的边缘保存在输出数组
                    if ((int)(new HTuple(hv_t.TupleGreater(0))) != 0)
                    {
                        hv_ResultRow = hv_ResultRow.TupleConcat(hv_tRow);
                        hv_ResultColumn = hv_ResultColumn.TupleConcat(hv_tCol);
                    }
                }

                ho_RegionLines.Dispose();
                ho_Rectangle.Dispose();
                ho_Arrow1.Dispose();

                return;
            }
            catch (HalconException HDevExpDefaultException)
            {
                ho_RegionLines.Dispose();
                ho_Rectangle.Dispose();
                ho_Arrow1.Dispose();

                throw HDevExpDefaultException;
            }
        }

        void gen_arrow_contour_xld(out HObject ho_Arrow, HTuple hv_Row1, HTuple hv_Column1,
    HTuple hv_Row2, HTuple hv_Column2, HTuple hv_HeadLength, HTuple hv_HeadWidth)
        {
            // Stack for temporary objects 
            HObject[] OTemp = new HObject[20];

            // Local iconic variables 

            HObject ho_TempArrow = null;

            // Local control variables 

            HTuple hv_Length = null, hv_ZeroLengthIndices = null;
            HTuple hv_DR = null, hv_DC = null, hv_HalfHeadWidth = null;
            HTuple hv_RowP1 = null, hv_ColP1 = null, hv_RowP2 = null;
            HTuple hv_ColP2 = null, hv_Index = null;
            // Initialize local and output iconic variables 
            HOperatorSet.GenEmptyObj(out ho_Arrow);
            HOperatorSet.GenEmptyObj(out ho_TempArrow);
            try
            {
                //This procedure generates arrow shaped XLD contours,
                //pointing from (Row1, Column1) to (Row2, Column2).
                //If starting and end point are identical, a contour consisting
                //of a single point is returned.
                //
                //input parameteres:
                //Row1, Column1: Coordinates of the arrows' starting points
                //Row2, Column2: Coordinates of the arrows' end points
                //HeadLength, HeadWidth: Size of the arrow heads in pixels
                //
                //output parameter:
                //Arrow: The resulting XLD contour
                //
                //The input tuples Row1, Column1, Row2, and Column2 have to be of
                //the same length.
                //HeadLength and HeadWidth either have to be of the same length as
                //Row1, Column1, Row2, and Column2 or have to be a single element.
                //If one of the above restrictions is violated, an error will occur.
                //
                //
                //Init
                ho_Arrow.Dispose();
                HOperatorSet.GenEmptyObj(out ho_Arrow);
                //
                //Calculate the arrow length
                HOperatorSet.DistancePp(hv_Row1, hv_Column1, hv_Row2, hv_Column2, out hv_Length);
                //
                //Mark arrows with identical start and end point
                //(set Length to -1 to avoid division-by-zero exception)
                hv_ZeroLengthIndices = hv_Length.TupleFind(0);
                if ((int)(new HTuple(hv_ZeroLengthIndices.TupleNotEqual(-1))) != 0)
                {
                    if (hv_Length == null)
                        hv_Length = new HTuple();
                    hv_Length[hv_ZeroLengthIndices] = -1;
                }
                //
                //Calculate auxiliary variables.
                hv_DR = (1.0 * (hv_Row2 - hv_Row1)) / hv_Length;
                hv_DC = (1.0 * (hv_Column2 - hv_Column1)) / hv_Length;
                hv_HalfHeadWidth = hv_HeadWidth / 2.0;
                //
                //Calculate end points of the arrow head.
                hv_RowP1 = (hv_Row1 + ((hv_Length - hv_HeadLength) * hv_DR)) + (hv_HalfHeadWidth * hv_DC);
                hv_ColP1 = (hv_Column1 + ((hv_Length - hv_HeadLength) * hv_DC)) - (hv_HalfHeadWidth * hv_DR);
                hv_RowP2 = (hv_Row1 + ((hv_Length - hv_HeadLength) * hv_DR)) - (hv_HalfHeadWidth * hv_DC);
                hv_ColP2 = (hv_Column1 + ((hv_Length - hv_HeadLength) * hv_DC)) + (hv_HalfHeadWidth * hv_DR);
                //
                //Finally create output XLD contour for each input point pair
                for (hv_Index = 0; (int)hv_Index <= (int)((new HTuple(hv_Length.TupleLength())) - 1); hv_Index = (int)hv_Index + 1)
                {
                    if ((int)(new HTuple(((hv_Length.TupleSelect(hv_Index))).TupleEqual(-1))) != 0)
                    {
                        //Create_ single points for arrows with identical start and end point
                        ho_TempArrow.Dispose();
                        HOperatorSet.GenContourPolygonXld(out ho_TempArrow, hv_Row1.TupleSelect(
                            hv_Index), hv_Column1.TupleSelect(hv_Index));
                    }
                    else
                    {
                        //Create arrow contour
                        ho_TempArrow.Dispose();
                        HOperatorSet.GenContourPolygonXld(out ho_TempArrow, ((((((((((hv_Row1.TupleSelect(
                            hv_Index))).TupleConcat(hv_Row2.TupleSelect(hv_Index)))).TupleConcat(
                            hv_RowP1.TupleSelect(hv_Index)))).TupleConcat(hv_Row2.TupleSelect(hv_Index)))).TupleConcat(
                            hv_RowP2.TupleSelect(hv_Index)))).TupleConcat(hv_Row2.TupleSelect(hv_Index)),
                            ((((((((((hv_Column1.TupleSelect(hv_Index))).TupleConcat(hv_Column2.TupleSelect(
                            hv_Index)))).TupleConcat(hv_ColP1.TupleSelect(hv_Index)))).TupleConcat(
                            hv_Column2.TupleSelect(hv_Index)))).TupleConcat(hv_ColP2.TupleSelect(
                            hv_Index)))).TupleConcat(hv_Column2.TupleSelect(hv_Index)));
                    }
                    {
                        HObject ExpTmpOutVar_0;
                        HOperatorSet.ConcatObj(ho_Arrow, ho_TempArrow, out ExpTmpOutVar_0);
                        ho_Arrow.Dispose();
                        ho_Arrow = ExpTmpOutVar_0;
                    }
                }
                ho_TempArrow.Dispose();

                return;
            }
            catch (HalconException HDevExpDefaultException)
            {
                ho_TempArrow.Dispose();

                throw HDevExpDefaultException;
            }
        }

        //   void disp_message(HTuple hv_WindowHandle, HTuple hv_String, HTuple hv_CoordSystem,
        //HTuple hv_Row, HTuple hv_Column, HTuple hv_Color, HTuple hv_Box)
        //   {
        //       // Local iconic variables 
        //       // Local control variables 
        //       HTuple hv_Red = null, hv_Green = null, hv_Blue = null;
        //       HTuple hv_Row1Part = null, hv_Column1Part = null, hv_Row2Part = null;
        //       HTuple hv_Column2Part = null, hv_RowWin = null, hv_ColumnWin = null;
        //       HTuple hv_WidthWin = null, hv_HeightWin = null, hv_MaxAscent = null;
        //       HTuple hv_MaxDescent = null, hv_MaxWidth = null, hv_MaxHeight = null;
        //       HTuple hv_R1 = new HTuple(), hv_C1 = new HTuple(), hv_FactorRow = new HTuple();
        //       HTuple hv_FactorColumn = new HTuple(), hv_UseShadow = null;
        //       HTuple hv_ShadowColor = null, hv_Exception = new HTuple();
        //       HTuple hv_Width = new HTuple(), hv_Index = new HTuple();
        //       HTuple hv_Ascent = new HTuple(), hv_Descent = new HTuple();
        //       HTuple hv_W = new HTuple(), hv_H = new HTuple(), hv_FrameHeight = new HTuple();
        //       HTuple hv_FrameWidth = new HTuple(), hv_R2 = new HTuple();
        //       HTuple hv_C2 = new HTuple(), hv_DrawMode = new HTuple();
        //       HTuple hv_CurrentColor = new HTuple();
        //       HTuple hv_Box_COPY_INP_TMP = hv_Box.Clone();
        //       HTuple hv_Color_COPY_INP_TMP = hv_Color.Clone();
        //       HTuple hv_Column_COPY_INP_TMP = hv_Column.Clone();
        //       HTuple hv_Row_COPY_INP_TMP = hv_Row.Clone();
        //       HTuple hv_String_COPY_INP_TMP = hv_String.Clone();

        //       // Initialize local and output iconic variables 
        //       //This procedure displays text in a graphics window.
        //       //
        //       //Input parameters:
        //       //WindowHandle: The WindowHandle of the graphics window, where
        //       //   the message should be displayed
        //       //String: A tuple of strings containing the text message to be displayed
        //       //CoordSystem: If set to 'window', the text position is given
        //       //   with respect to the window coordinate system.
        //       //   If set to 'image', image coordinates are used.
        //       //   (This may be useful in zoomed images.)
        //       //Row: The row coordinate of the desired text position
        //       //   If set to -1, a default value of 12 is used.
        //       //Column: The column coordinate of the desired text position
        //       //   If set to -1, a default value of 12 is used.
        //       //Color: defines the color of the text as string.
        //       //   If set to [], '' or 'auto' the currently set color is used.
        //       //   If a tuple of strings is passed, the colors are used cyclically
        //       //   for each new textline.
        //       //Box: If Box[0] is set to 'true', the text is written within an orange box.
        //       //     If set to' false', no box is displayed.
        //       //     If set to a color string (e.g. 'white', '#FF00CC', etc.),
        //       //       the text is written in a box of that color.
        //       //     An optional second value for Box (Box[1]) controls if a shadow is displayed:
        //       //       'true' -> display a shadow in a default color
        //       //       'false' -> display no shadow (same as if no second value is given)
        //       //       otherwise -> use given string as color string for the shadow color
        //       //
        //       //Prepare window
        //       HOperatorSet.GetRgb(hv_WindowHandle, out hv_Red, out hv_Green, out hv_Blue);
        //       HOperatorSet.GetPart(hv_WindowHandle, out hv_Row1Part, out hv_Column1Part, out hv_Row2Part,
        //           out hv_Column2Part);
        //       HOperatorSet.GetWindowExtents(hv_WindowHandle, out hv_RowWin, out hv_ColumnWin,
        //           out hv_WidthWin, out hv_HeightWin);
        //       HOperatorSet.SetPart(hv_WindowHandle, 0, 0, hv_HeightWin - 1, hv_WidthWin - 1);
        //       //
        //       //default settings
        //       if ((int)(new HTuple(hv_Row_COPY_INP_TMP.TupleEqual(-1))) != 0)
        //       {
        //           hv_Row_COPY_INP_TMP = 12;
        //       }
        //       if ((int)(new HTuple(hv_Column_COPY_INP_TMP.TupleEqual(-1))) != 0)
        //       {
        //           hv_Column_COPY_INP_TMP = 12;
        //       }
        //       if ((int)(new HTuple(hv_Color_COPY_INP_TMP.TupleEqual(new HTuple()))) != 0)
        //       {
        //           hv_Color_COPY_INP_TMP = "";
        //       }
        //       //
        //       hv_String_COPY_INP_TMP = ((("" + hv_String_COPY_INP_TMP) + "")).TupleSplit("\n");
        //       //
        //       //Estimate extentions of text depending on font size.
        //       HOperatorSet.GetFontExtents(hv_WindowHandle, out hv_MaxAscent, out hv_MaxDescent,
        //           out hv_MaxWidth, out hv_MaxHeight);
        //       if ((int)(new HTuple(hv_CoordSystem.TupleEqual("window"))) != 0)
        //       {
        //           hv_R1 = hv_Row_COPY_INP_TMP.Clone();
        //           hv_C1 = hv_Column_COPY_INP_TMP.Clone();
        //       }
        //       else
        //       {
        //           //Transform image to window coordinates
        //           hv_FactorRow = (1.0 * hv_HeightWin) / ((hv_Row2Part - hv_Row1Part) + 1);
        //           hv_FactorColumn = (1.0 * hv_WidthWin) / ((hv_Column2Part - hv_Column1Part) + 1);
        //           hv_R1 = ((hv_Row_COPY_INP_TMP - hv_Row1Part) + 0.5) * hv_FactorRow;
        //           hv_C1 = ((hv_Column_COPY_INP_TMP - hv_Column1Part) + 0.5) * hv_FactorColumn;
        //       }
        //       //
        //       //Display text box depending on text size
        //       hv_UseShadow = 1;
        //       hv_ShadowColor = "gray";
        //       if ((int)(new HTuple(((hv_Box_COPY_INP_TMP.TupleSelect(0))).TupleEqual("true"))) != 0)
        //       {
        //           if (hv_Box_COPY_INP_TMP == null)
        //               hv_Box_COPY_INP_TMP = new HTuple();
        //           hv_Box_COPY_INP_TMP[0] = "#fce9d4";
        //           hv_ShadowColor = "#f28d26";
        //       }
        //       if ((int)(new HTuple((new HTuple(hv_Box_COPY_INP_TMP.TupleLength())).TupleGreater(
        //           1))) != 0)
        //       {
        //           if ((int)(new HTuple(((hv_Box_COPY_INP_TMP.TupleSelect(1))).TupleEqual("true"))) != 0)
        //           {
        //               //Use default ShadowColor set above
        //           }
        //           else if ((int)(new HTuple(((hv_Box_COPY_INP_TMP.TupleSelect(1))).TupleEqual(
        //               "false"))) != 0)
        //           {
        //               hv_UseShadow = 0;
        //           }
        //           else
        //           {
        //               hv_ShadowColor = hv_Box_COPY_INP_TMP[1];
        //               //Valid color?
        //               try
        //               {
        //                   HOperatorSet.SetColor(hv_WindowHandle, hv_Box_COPY_INP_TMP.TupleSelect(
        //                       1));
        //               }
        //               // catch (Exception) 
        //               catch (HalconException HDevExpDefaultException1)
        //               {
        //                   HDevExpDefaultException1.ToHTuple(out hv_Exception);
        //                   hv_Exception = "Wrong value of control parameter Box[1] (must be a 'true', 'false', or a valid color string)";
        //                   throw new HalconException(hv_Exception);
        //               }
        //           }
        //       }
        //       if ((int)(new HTuple(((hv_Box_COPY_INP_TMP.TupleSelect(0))).TupleNotEqual("false"))) != 0)
        //       {
        //           //Valid color?
        //           try
        //           {
        //               HOperatorSet.SetColor(hv_WindowHandle, hv_Box_COPY_INP_TMP.TupleSelect(0));
        //           }
        //           // catch (Exception) 
        //           catch (HalconException HDevExpDefaultException1)
        //           {
        //               HDevExpDefaultException1.ToHTuple(out hv_Exception);
        //               hv_Exception = "Wrong value of control parameter Box[0] (must be a 'true', 'false', or a valid color string)";
        //               throw new HalconException(hv_Exception);
        //           }
        //           //Calculate box extents
        //           hv_String_COPY_INP_TMP = (" " + hv_String_COPY_INP_TMP) + " ";
        //           hv_Width = new HTuple();
        //           for (hv_Index = 0; (int)hv_Index <= (int)((new HTuple(hv_String_COPY_INP_TMP.TupleLength()
        //               )) - 1); hv_Index = (int)hv_Index + 1)
        //           {
        //               HOperatorSet.GetStringExtents(hv_WindowHandle, hv_String_COPY_INP_TMP.TupleSelect(
        //                   hv_Index), out hv_Ascent, out hv_Descent, out hv_W, out hv_H);
        //               hv_Width = hv_Width.TupleConcat(hv_W);
        //           }
        //           hv_FrameHeight = hv_MaxHeight * (new HTuple(hv_String_COPY_INP_TMP.TupleLength()
        //               ));
        //           hv_FrameWidth = (((new HTuple(0)).TupleConcat(hv_Width))).TupleMax();
        //           hv_R2 = hv_R1 + hv_FrameHeight;
        //           hv_C2 = hv_C1 + hv_FrameWidth;
        //           //Display rectangles
        //           HOperatorSet.GetDraw(hv_WindowHandle, out hv_DrawMode);
        //           HOperatorSet.SetDraw(hv_WindowHandle, "fill");
        //           //Set shadow color
        //           HOperatorSet.SetColor(hv_WindowHandle, hv_ShadowColor);
        //           if ((int)(hv_UseShadow) != 0)
        //           {
        //               HOperatorSet.DispRectangle1(hv_WindowHandle, hv_R1 + 1, hv_C1 + 1, hv_R2 + 1, hv_C2 + 1);
        //           }
        //           //Set box color
        //           HOperatorSet.SetColor(hv_WindowHandle, hv_Box_COPY_INP_TMP.TupleSelect(0));
        //           HOperatorSet.DispRectangle1(hv_WindowHandle, hv_R1, hv_C1, hv_R2, hv_C2);
        //           HOperatorSet.SetDraw(hv_WindowHandle, hv_DrawMode);
        //       }
        //       //Write text.
        //       for (hv_Index = 0; (int)hv_Index <= (int)((new HTuple(hv_String_COPY_INP_TMP.TupleLength()
        //           )) - 1); hv_Index = (int)hv_Index + 1)
        //       {
        //           hv_CurrentColor = hv_Color_COPY_INP_TMP.TupleSelect(hv_Index % (new HTuple(hv_Color_COPY_INP_TMP.TupleLength()
        //               )));
        //           if ((int)((new HTuple(hv_CurrentColor.TupleNotEqual(""))).TupleAnd(new HTuple(hv_CurrentColor.TupleNotEqual(
        //               "auto")))) != 0)
        //           {
        //               HOperatorSet.SetColor(hv_WindowHandle, hv_CurrentColor);
        //           }
        //           else
        //           {
        //               HOperatorSet.SetRgb(hv_WindowHandle, hv_Red, hv_Green, hv_Blue);
        //           }
        //           hv_Row_COPY_INP_TMP = hv_R1 + (hv_MaxHeight * hv_Index);
        //           HOperatorSet.SetTposition(hv_WindowHandle, hv_Row_COPY_INP_TMP, hv_C1);
        //           HOperatorSet.WriteString(hv_WindowHandle, hv_String_COPY_INP_TMP.TupleSelect(
        //               hv_Index));
        //       }
        //       //Reset changed window settings
        //       HOperatorSet.SetRgb(hv_WindowHandle, hv_Red, hv_Green, hv_Blue);
        //       HOperatorSet.SetPart(hv_WindowHandle, hv_Row1Part, hv_Column1Part, hv_Row2Part,
        //           hv_Column2Part);

        //       return;
        //   }

        void pts_to_best_line(out HObject ho_Line, HTuple hv_Rows, HTuple hv_Cols,
    HTuple hv_ActiveNum, out HTuple hv_Row1, out HTuple hv_Column1, out HTuple hv_Row2,
    out HTuple hv_Column2, out HTuple hv_centerRow, out HTuple hv_centerCol)
        {
            // Local iconic variables 
            HObject ho_Contour = null;
            // Local control variables 
            HTuple hv_Length = null, hv_Nr = new HTuple();
            HTuple hv_Nc = new HTuple(), hv_Dist = new HTuple(), hv_Length1 = new HTuple();
            // Initialize local and output iconic variables 
            HOperatorSet.GenEmptyObj(out ho_Line);
            HOperatorSet.GenEmptyObj(out ho_Contour);
            hv_centerRow = new HTuple();
            hv_centerCol = new HTuple();
            try
            {

                hv_centerRow = 0;
                hv_centerCol = 0;
                //初始化
                hv_Row1 = 0;
                hv_Column1 = 0;
                hv_Row2 = 0;
                hv_Column2 = 0;
                //产生一个空的直线对象，用于保存拟合后的直线
                ho_Line.Dispose();
                HOperatorSet.GenEmptyObj(out ho_Line);
                //计算边缘数量
                HOperatorSet.TupleLength(hv_Cols, out hv_Length);
                //当边缘数量不小于有效点数时进行拟合
                if ((int)((new HTuple(hv_Length.TupleGreaterEqual(hv_ActiveNum))).TupleAnd(
                    new HTuple(hv_ActiveNum.TupleGreater(1)))) != 0)
                {
                    //halcon的拟合是基于xld的，需要把边缘连接成xld
                    ho_Contour.Dispose();
                    HOperatorSet.GenContourPolygonXld(out ho_Contour, hv_Rows, hv_Cols);
                    //拟合直线。使用的算法是'tukey'，其他算法请参考fit_line_contour_xld的描述部分。
                    HOperatorSet.FitLineContourXld(ho_Contour, "tukey", -1, 0, 5, 2, out hv_Row1,
                        out hv_Column1, out hv_Row2, out hv_Column2, out hv_Nr, out hv_Nc, out hv_Dist);
                    //*************输出中点*****************
                    hv_centerRow = (hv_Row1 + hv_Row2) / 2;
                    hv_centerCol = (hv_Column1 + hv_Column2) / 2;
                    //判断拟合结果是否有效：如果拟合成功，数组中元素的数量大于0
                    HOperatorSet.TupleLength(hv_Dist, out hv_Length1);
                    if ((int)(new HTuple(hv_Length1.TupleLess(1))) != 0)
                    {
                        ho_Contour.Dispose();
                        return;
                    }
                    //根据拟合结果，产生直线xld
                    ho_Line.Dispose();
                    HOperatorSet.GenContourPolygonXld(out ho_Line, hv_Row1.TupleConcat(hv_Row2),
                        hv_Column1.TupleConcat(hv_Column2));
                }
                ho_Contour.Dispose();
                return;
            }
            catch (HalconException HDevExpDefaultException)
            {
                ho_Contour.Dispose();

                throw HDevExpDefaultException;
            }
        }
        #endregion

        #region  显示结果
        /// <summary>
        /// 显示结果
        /// </summary>
        /// <param name="toolResult_"></param>
        /// <returns></returns>
        public override bool outResult(out string[] toolResult_)
        {
            bool ok = false;
            this._result.showResult(out toolResult_);
            ok = true;
            return ok;
        }
        #endregion
    }
    #endregion

    #region  拟合直线数据接口
    /// <summary>
    /// 拟合直线数据接口
    /// </summary>
    public interface ILineShuJu : IOutsideLine, MultTree.IToolDateFather, ILineStruct
    {
        #region  属性

        #region    卡尺的数据
        /// <summary>
        /// 卡尺的个数
        /// </summary>
        HTuple Hv_Elements
        {
            get
           ;
            set;
        }

        /// <summary>
        /// 卡尺的高
        /// </summary>
        HTuple Hv_DetectHeight
        {
            get
           ;
            set;
        }


        /// <summary>
        /// 卡尺的宽
        /// </summary>
        HTuple Hv_DetectWidth
        {
            get
            ;

            set;
        }
        #endregion

        #region  防射变换
        ///// <summary>
        ///// 防射变换
        ///// </summary>
        //HTuple Hv_HomMat2D
        //{
        //    get;
        //    set;
        //}
        #endregion

        #region   rake输出的数据
        /// <summary>
        /// rake输出的数据,找到的点
        /// </summary>
        HObject Ho_Regions_Rake
        {
            get;
            set;
        }

        /// <summary>
        /// 检测到的边缘点的y坐标数组    拟合圆的边缘y数组
        /// </summary>
        HTuple Hv_ResultRow
        {
            get;
            set;
        }

        /// <summary>
        /// 检测到的边缘点的x坐标数组   拟合圆的边缘x数组
        /// </summary>
        HTuple Hv_ResultColumn
        {
            get;
            set;
        }

        #endregion

        #region   draw_rake输出的数据

        /// <summary>
        /// draw_rake输出的区域
        /// </summary>
        HObject Ho_Regions_Draw
        {
            get;
            set;
        }

        /// <summary>
        /// draw_rake输出线的开头点 y
        /// </summary>
        HTuple Hv_Row1_Draw
        {
            get;
            set;
        }

        /// <summary>
        /// draw_rake输出线的开头 x
        /// </summary>
        HTuple Hv_Column1_Draw
        {
            get;
            set;
        }

        /// <summary>
        /// draw_rake输出线的结束点 y
        /// </summary>
        HTuple Hv_Row2_Draw
        {
            get;
            set;
        }

        /// <summary>
        /// draw_rake输出线的结束点 x
        /// </summary>
        HTuple Hv_Column2_Draw
        {
            get;
            set;
        }

        #endregion

        #region  拟合的直线

        /// <summary>
        /// 拟合的直线
        /// </summary>
        HObject Ho_Line
        {
            get;
            set;
        }

        ///// <summary>
        ///// 拟合的直线开头点 y
        ///// </summary>
        //HTuple Hv_Row11
        //{
        //    get;
        //    set;
        //}

        ///// <summary>
        ///// 拟合的直线开头点 x
        ///// </summary>
        //HTuple Hv_Column11
        //{
        //    get;
        //    set;
        //}

        ///// <summary>
        ///// 拟合的直线结束点 y
        ///// </summary>
        //HTuple Hv_Row21
        //{
        //    get;
        //    set;
        //}

        ///// <summary>
        ///// 拟合的直线结束点 x
        ///// </summary>
        //HTuple Hv_Column21
        //{
        //    get;
        //    set;
        //}

        #endregion

        #region 找到直线点，端点，中点
        /// <summary>
        /// 找到直线点，端点，中点
        /// </summary>
        HObject Ho_Cross
        {
            get;
            set;
        }
        #endregion

        #region  测量的数据
        /// <summary>
        /// 高斯滤波因子
        /// </summary>
        HTuple Hv_Sigma
        {
            get;
            set;
        }

        /// <summary>
        /// 边缘幅度阈值
        /// </summary>
        HTuple Hv_Threshold
        {
            get;
            set;
        }

        /// <summary>
        /// 极性：  positive表示由黑到白   negative表示由白到黑   all表示以上两种方向
        /// </summary>
        HTuple Hv_Transition
        {
            get;
            set;
        }

        /// <summary>
        /// >first表示选择第一点    last表示选择最后一点   max表示选择边缘强度最强点
        /// </summary>
        HTuple Hv_Select
        {
            get;
            set;
        }

        /// <summary>
        /// 最小有效点数
        /// </summary>
        HTuple Hv_ActiveNum
        {
            get;
            set;
        }
        #endregion
        #endregion

        #region  保存
        /// <summary>
        /// 保存
        /// </summary>
        void save();
        #endregion

        #region  初始化
        /// <summary>
        /// 初始化
        /// </summary>
        void init();
        #endregion
    }
    #endregion

    #region   数据设置器
    /// <summary>
    /// 数据设置器
    /// </summary>
    public class SetLineShuJu:MultTree.SetFather
    {
        #region   设置测量的数据
        /// <summary>
        /// 设置测量的数据
        /// </summary>
        /// <param name="ILine_"></param>
        /// <param name="hv_Sigma"></param>
        /// <param name="hv_Threshold"></param>
        /// <param name="hv_Transition"></param>
        /// <param name="hv_Select"></param>
        /// <param name="hv_ActiveNum"></param>
        /// <returns></returns>
        public bool Set_Rake(ILineShuJu ILine_, string hv_Sigma, string hv_Threshold, string hv_Transition, string hv_Select, string hv_ActiveNum)
        {
            bool ok = false;

            if (hv_Sigma != null)
            {
                double num = Convert.ToDouble(hv_Sigma);
                ILine_.Hv_Sigma = num;
            }

            if (hv_Threshold != null)
            {
                double num = Convert.ToDouble(hv_Threshold);
                ILine_.Hv_Threshold = num;
            }

            if (hv_Select != null)
            {
                ILine_.Hv_Select = hv_Select;
            }

            if (hv_ActiveNum != null)
            {
                double num = Convert.ToDouble(hv_ActiveNum);
                ILine_.Hv_ActiveNum = num;
            }

            if (hv_Transition != null)
            {
                ILine_.Hv_Transition = hv_Transition;
            }
            ok = false;
            return ok;

        }
        #endregion

        #region   设置卡尺数据
        /// <summary>
        /// 设置卡尺数据
        /// </summary>
        /// <param name="ILine_"></param>
        /// <param name="hv_Elements"></param>
        /// <param name="hv_DetectHeight"></param>
        /// <param name="hv_DetectWidth"></param>
        /// <returns></returns>
        public bool Set_Draw_Rake(ILineShuJu ILine_, string hv_Elements, string hv_DetectHeight, string hv_DetectWidth)
        {
            bool ok = false;
            if (hv_Elements != null)
            {
                double num = Convert.ToDouble(hv_Elements);
                ILine_.Hv_Elements = num;
            }

            if (hv_DetectHeight != null)
            {
                double num = Convert.ToDouble(hv_DetectHeight);
                ILine_.Hv_DetectHeight = num;

            }

            if (hv_DetectWidth != null)
            {
                double num = Convert.ToDouble(hv_DetectWidth);
                ILine_.Hv_DetectWidth = num;
            }
            ok = true;
            return ok;

        }

        #endregion

        //#region 显示卡尺工具
        ///// <summary>
        ///// 显示卡尺工具
        ///// </summary>
        ///// <param name="ILine_"></param>
        ///// <param name="hwin"></param>
        ///// <returns></returns>
        //public bool Set_Show_Rake(ILineShuJu ILine_, HWindow hwin)
        //{
        //    bool ok = false;

        //    if (ILine_.Ho_Regions_Draw.IsInitialized())
        //    {

        //        hwin.DispObj(ILine_.Ho_Regions_Draw);

        //    }
        //    ok = true;
        //    return ok;
        //}
        //#endregion

        //#region  显示测量的点
        ///// <summary>
        ///// 显示测量的点
        ///// </summary>
        ///// <param name="ILine_"></param>
        ///// <param name="hwin"></param>
        ///// <returns></returns>
        //public bool Set_Show_Point(ILineShuJu ILine_, HWindow hwin)
        //{
        //    bool ok = false;
        //    if (ILine_.Hv_ResultRow != null)
        //    {
        //        int num = ILine_.Hv_ResultRow.Length;
        //        HObject cross;
        //        HOperatorSet.GenEmptyObj(out cross);

        //        for (int i = 0; i < num; i++)
        //        {

        //            cross.Dispose();
        //            HOperatorSet.GenCrossContourXld(out cross, ILine_.Hv_ResultRow[i], ILine_.Hv_ResultColumn[i], 10, 0);
        //            hwin.DispObj(cross);

        //        }

        //    }

        //    ok = true;
        //    return ok;
        //}
        //#endregion

        //#region   显示直线
        ///// <summary>
        ///// 显示直线
        ///// </summary>
        ///// <param name="ILine_"></param>
        ///// <param name="hwin"></param>
        ///// <returns></returns>
        //public bool Set_Show_Line(ILineShuJu ILine_, HWindow hwin)
        //{

        //    bool ok = false;

        //    if (ILine_.Ho_Line.IsInitialized())
        //    {
        //        hwin.DispObj(ILine_.Ho_Line);
        //    }

        //    ok = true;
        //    return ok;
        //}
        //#endregion

        #region  显示参数
        /// <summary>
        /// 显示参数
        /// </summary>
        /// <param name="ILine_"></param>
        /// <param name="control"></param>
        /// <param name="halconWinControlRoi_"></param>
        /// <returns></returns>
        public bool Set_Show_Parameter_HalconWindows(ILineShuJu ILine_, Control.ControlCollection control, HalControl.HalconWinControl_ROI halconWinControlRoi_, HalControl.HalconWinControl_ROI.repaint repaint_)
        {
            bool ok = false;

            this.ShuaXinDingWeiDian((MultTree.IToolDateFather)ILine_, ILine_.IOutSide);

            if (halconWinControlRoi_ != null)
            {
                halconWinControlRoi_.DrawLine(ILine_.IOutSide.Cols1, ILine_.IOutSide.Row1, ILine_.IOutSide.Cols2, ILine_.IOutSide.Row2, ILine_.IOutSide);
            }

            if (repaint_ != null)
            {
                halconWinControlRoi_.Repaint += repaint_;
            }

            Set_Show_Parameter(ILine_, control);
            ok = true;
            return ok;
        }


        /// <summary>
        /// 显示参数
        /// </summary>
        /// <param name="ILine_"></param>
        /// <param name="control"></param>
        /// <returns></returns>
        bool Set_Show_Parameter(ILineShuJu ILine_, Control.ControlCollection control)
        {
            bool ok = false;

            foreach (Control con in control)
            {
                string name = con.Name;
                if ((con is ComboBox) || (con is TextBox) || (con is RichTextBox) || (con is NumericUpDown))
                {
                    switch (name)
                    {
                        #region   设置卡尺工具
                        case "numericUpDown_Hv_Elements":
                            con.Text = ILine_.Hv_Elements.ToString().Replace("\"", "");
                            break;

                        case "numericUpDown_Hv_DetectHeight":
                            con.Text = ILine_.Hv_DetectHeight.ToString().Replace("\"", "");
                            break;

                        case "numericUpDown_Hv_DetectWidth":
                            con.Text = ILine_.Hv_DetectWidth.ToString().Replace("\"", "");
                            break;

                        #endregion

                        #region   测量数据

                        case "Hv_Sigma":
                            con.Text = ILine_.Hv_Sigma.ToString().Replace("\"", "");
                            break;

                        case "numericUpDown_Hv_Threshold":
                            con.Text = ILine_.Hv_Threshold.ToString().Replace("\"", "");
                            break;

                        case "Hv_Transition":
                            con.Text = ILine_.Hv_Transition.ToString().Replace("\"", "");
                            break;


                        case "numericUpDown_Hv_ActiveNum":
                            con.Text = ILine_.Hv_ActiveNum.ToString().Replace("\"", "");

                            break;
                        case "Hv_Select":
                            con.Text = ILine_.Hv_Select.ToString().Replace("\"", "");
                            break;
                        #endregion
                    }
                }
                if (con.Controls.Count > 0)
                {
                    Set_Show_Parameter(ILine_, con.Controls);
                }
            }
            ok = true;
            return ok;
        }
        #endregion

        #region   显示卡尺
        //    /// <summary>
        //    /// 设置卡尺路径
        //    /// </summary>
        //    /// <param name="ILine_"></param>
        //    /// <param name="hwin"></param>
        //    /// <returns></returns>
        //    public bool Set_Draw_Rake(ILineShuJu ILine_, HWindow hwin)
        //    {
        //        bool ok = false;

        //        HObject ho_Regions;

        //        HTuple row1, column1, row2, column2;

        //        draw_rake(out ho_Regions, hwin, ILine_.Hv_Elements, ILine_.Hv_DetectHeight, ILine_.Hv_DetectWidth, out row1, out column1, out row2, out column2);

        //        ILine_.Ho_Regions_Draw = ho_Regions;
        //        ILine_.Hv_Row1_Draw = row1;
        //        ILine_.Hv_Column1_Draw = column1;
        //        ILine_.Hv_Row2_Draw = row2;
        //        ILine_.Hv_Column2_Draw = column2;

        //        hwin.DispObj(ILine_.Ho_Regions_Draw);

        //        ok = true;
        //        return ok;
        //    }

        //    void draw_rake(out HObject ho_Regions, HWindow hv_WindowHandle, HTuple hv_Elements,
        //        HTuple hv_DetectHeight, HTuple hv_DetectWidth, out HTuple hv_Row1, out HTuple hv_Column1,
        //        out HTuple hv_Row2, out HTuple hv_Column2)
        //    {
        //        // Stack for temporary objects 
        //        HObject[] OTemp = new HObject[20];
        //        // Local iconic variables 
        //        HObject ho_RegionLines, ho_Rectangle = null;
        //        HObject ho_Arrow1 = null;
        //        // Local control variables 
        //        HTuple hv_ATan = null, hv_i = null, hv_RowC = new HTuple();
        //        HTuple hv_ColC = new HTuple(), hv_Distance = new HTuple();
        //        HTuple hv_RowL2 = new HTuple(), hv_RowL1 = new HTuple();
        //        HTuple hv_ColL2 = new HTuple(), hv_ColL1 = new HTuple();
        //        // Initialize local and output iconic variables 
        //        HOperatorSet.GenEmptyObj(out ho_Regions);
        //        HOperatorSet.GenEmptyObj(out ho_RegionLines);
        //        HOperatorSet.GenEmptyObj(out ho_Rectangle);
        //        HOperatorSet.GenEmptyObj(out ho_Arrow1);
        //        try
        //        {
        //            //提示
        //            disp_message(hv_WindowHandle, "点击鼠标左键画一条直线,点击右键确认", "window",
        //                12, 12, "red", "false");
        //            //产生一个空显示对象，用于显示
        //            ho_Regions.Dispose();
        //            HOperatorSet.GenEmptyObj(out ho_Regions);
        //            //画矢量检测直线
        //            HOperatorSet.DrawLine(hv_WindowHandle, out hv_Row1, out hv_Column1, out hv_Row2,
        //                out hv_Column2);
        //            //产生直线xld
        //            ho_RegionLines.Dispose();
        //            HOperatorSet.GenContourPolygonXld(out ho_RegionLines, hv_Row1.TupleConcat(hv_Row2),
        //                hv_Column1.TupleConcat(hv_Column2));
        //            //存储到显示对象
        //            {
        //                HObject ExpTmpOutVar_0;
        //                HOperatorSet.ConcatObj(ho_Regions, ho_RegionLines, out ExpTmpOutVar_0);
        //                ho_Regions.Dispose();
        //                ho_Regions = ExpTmpOutVar_0;
        //            }
        //            //计算直线与x轴的夹角，逆时针方向为正向。
        //            HOperatorSet.AngleLx(hv_Row1, hv_Column1, hv_Row2, hv_Column2, out hv_ATan);

        //            //边缘检测方向垂直于检测直线：直线方向正向旋转90°为边缘检测方向
        //            hv_ATan = hv_ATan + ((new HTuple(90)).TupleRad());

        //            //根据检测直线按顺序产生测量区域矩形，并存储到显示对象
        //            HTuple end_val17 = hv_Elements;
        //            HTuple step_val17 = 1;
        //            for (hv_i = 1; hv_i.Continue(end_val17, step_val17); hv_i = hv_i.TupleAdd(step_val17))
        //            {
        //                //如果只有一个测量矩形，作为卡尺工具，宽度为检测直线的长度
        //                if ((int)(new HTuple(hv_Elements.TupleEqual(1))) != 0)
        //                {
        //                    hv_RowC = (hv_Row1 + hv_Row2) * 0.5;
        //                    hv_ColC = (hv_Column1 + hv_Column2) * 0.5;
        //                    HOperatorSet.DistancePp(hv_Row1, hv_Column1, hv_Row2, hv_Column2, out hv_Distance);
        //                    ho_Rectangle.Dispose();
        //                    HOperatorSet.GenRectangle2ContourXld(out ho_Rectangle, hv_RowC, hv_ColC,
        //                        hv_ATan, hv_DetectHeight / 2, hv_Distance / 2);
        //                }
        //                else
        //                {
        //                    //如果有多个测量矩形，产生该测量矩形xld
        //                    hv_RowC = hv_Row1 + (((hv_Row2 - hv_Row1) * (hv_i - 1)) / (hv_Elements - 1));
        //                    hv_ColC = hv_Column1 + (((hv_Column2 - hv_Column1) * (hv_i - 1)) / (hv_Elements - 1));
        //                    ho_Rectangle.Dispose();
        //                    HOperatorSet.GenRectangle2ContourXld(out ho_Rectangle, hv_RowC, hv_ColC,
        //                        hv_ATan, hv_DetectHeight / 2, hv_DetectWidth / 2);
        //                }
        //                //把测量矩形xld存储到显示对象
        //                {
        //                    HObject ExpTmpOutVar_0;
        //                    HOperatorSet.ConcatObj(ho_Regions, ho_Rectangle, out ExpTmpOutVar_0);
        //                    ho_Regions.Dispose();
        //                    ho_Regions = ExpTmpOutVar_0;
        //                }
        //                if ((int)(new HTuple(hv_i.TupleEqual(1))) != 0)
        //                {
        //                    //在第一个测量矩形绘制一个箭头xld，用于只是边缘检测方向
        //                    hv_RowL2 = hv_RowC + ((hv_DetectHeight / 2) * (((-hv_ATan)).TupleSin()));
        //                    hv_RowL1 = hv_RowC - ((hv_DetectHeight / 2) * (((-hv_ATan)).TupleSin()));
        //                    hv_ColL2 = hv_ColC + ((hv_DetectHeight / 2) * (((-hv_ATan)).TupleCos()));
        //                    hv_ColL1 = hv_ColC - ((hv_DetectHeight / 2) * (((-hv_ATan)).TupleCos()));
        //                    ho_Arrow1.Dispose();
        //                    gen_arrow_contour_xld(out ho_Arrow1, hv_RowL1, hv_ColL1, hv_RowL2, hv_ColL2,
        //                        25, 25);
        //                    //把xld存储到显示对象
        //                    {
        //                        HObject ExpTmpOutVar_0;
        //                        HOperatorSet.ConcatObj(ho_Regions, ho_Arrow1, out ExpTmpOutVar_0);
        //                        ho_Regions.Dispose();
        //                        ho_Regions = ExpTmpOutVar_0;
        //                    }
        //                }
        //            }

        //            ho_RegionLines.Dispose();
        //            ho_Rectangle.Dispose();
        //            ho_Arrow1.Dispose();

        //            return;
        //        }
        //        catch (HalconException HDevExpDefaultException)
        //        {
        //            ho_RegionLines.Dispose();
        //            ho_Rectangle.Dispose();
        //            ho_Arrow1.Dispose();

        //            throw HDevExpDefaultException;
        //        }
        //    }

        //    void gen_arrow_contour_xld(out HObject ho_Arrow, HTuple hv_Row1, HTuple hv_Column1,
        //HTuple hv_Row2, HTuple hv_Column2, HTuple hv_HeadLength, HTuple hv_HeadWidth)
        //    {
        //        // Stack for temporary objects 
        //        HObject[] OTemp = new HObject[20];

        //        // Local iconic variables 

        //        HObject ho_TempArrow = null;

        //        // Local control variables 

        //        HTuple hv_Length = null, hv_ZeroLengthIndices = null;
        //        HTuple hv_DR = null, hv_DC = null, hv_HalfHeadWidth = null;
        //        HTuple hv_RowP1 = null, hv_ColP1 = null, hv_RowP2 = null;
        //        HTuple hv_ColP2 = null, hv_Index = null;
        //        // Initialize local and output iconic variables 
        //        HOperatorSet.GenEmptyObj(out ho_Arrow);
        //        HOperatorSet.GenEmptyObj(out ho_TempArrow);
        //        try
        //        {
        //            //This procedure generates arrow shaped XLD contours,
        //            //pointing from (Row1, Column1) to (Row2, Column2).
        //            //If starting and end point are identical, a contour consisting
        //            //of a single point is returned.
        //            //
        //            //input parameteres:
        //            //Row1, Column1: Coordinates of the arrows' starting points
        //            //Row2, Column2: Coordinates of the arrows' end points
        //            //HeadLength, HeadWidth: Size of the arrow heads in pixels
        //            //
        //            //output parameter:
        //            //Arrow: The resulting XLD contour
        //            //
        //            //The input tuples Row1, Column1, Row2, and Column2 have to be of
        //            //the same length.
        //            //HeadLength and HeadWidth either have to be of the same length as
        //            //Row1, Column1, Row2, and Column2 or have to be a single element.
        //            //If one of the above restrictions is violated, an error will occur.
        //            //
        //            //
        //            //Init
        //            ho_Arrow.Dispose();
        //            HOperatorSet.GenEmptyObj(out ho_Arrow);
        //            //
        //            //Calculate the arrow length
        //            HOperatorSet.DistancePp(hv_Row1, hv_Column1, hv_Row2, hv_Column2, out hv_Length);
        //            //
        //            //Mark arrows with identical start and end point
        //            //(set Length to -1 to avoid division-by-zero exception)
        //            hv_ZeroLengthIndices = hv_Length.TupleFind(0);
        //            if ((int)(new HTuple(hv_ZeroLengthIndices.TupleNotEqual(-1))) != 0)
        //            {
        //                if (hv_Length == null)
        //                    hv_Length = new HTuple();
        //                hv_Length[hv_ZeroLengthIndices] = -1;
        //            }
        //            //
        //            //Calculate auxiliary variables.
        //            hv_DR = (1.0 * (hv_Row2 - hv_Row1)) / hv_Length;
        //            hv_DC = (1.0 * (hv_Column2 - hv_Column1)) / hv_Length;
        //            hv_HalfHeadWidth = hv_HeadWidth / 2.0;
        //            //
        //            //Calculate end points of the arrow head.
        //            hv_RowP1 = (hv_Row1 + ((hv_Length - hv_HeadLength) * hv_DR)) + (hv_HalfHeadWidth * hv_DC);
        //            hv_ColP1 = (hv_Column1 + ((hv_Length - hv_HeadLength) * hv_DC)) - (hv_HalfHeadWidth * hv_DR);
        //            hv_RowP2 = (hv_Row1 + ((hv_Length - hv_HeadLength) * hv_DR)) - (hv_HalfHeadWidth * hv_DC);
        //            hv_ColP2 = (hv_Column1 + ((hv_Length - hv_HeadLength) * hv_DC)) + (hv_HalfHeadWidth * hv_DR);
        //            //
        //            //Finally create output XLD contour for each input point pair
        //            for (hv_Index = 0; (int)hv_Index <= (int)((new HTuple(hv_Length.TupleLength())) - 1); hv_Index = (int)hv_Index + 1)
        //            {
        //                if ((int)(new HTuple(((hv_Length.TupleSelect(hv_Index))).TupleEqual(-1))) != 0)
        //                {
        //                    //Create_ single points for arrows with identical start and end point
        //                    ho_TempArrow.Dispose();
        //                    HOperatorSet.GenContourPolygonXld(out ho_TempArrow, hv_Row1.TupleSelect(
        //                        hv_Index), hv_Column1.TupleSelect(hv_Index));
        //                }
        //                else
        //                {
        //                    //Create arrow contour
        //                    ho_TempArrow.Dispose();
        //                    HOperatorSet.GenContourPolygonXld(out ho_TempArrow, ((((((((((hv_Row1.TupleSelect(
        //                        hv_Index))).TupleConcat(hv_Row2.TupleSelect(hv_Index)))).TupleConcat(
        //                        hv_RowP1.TupleSelect(hv_Index)))).TupleConcat(hv_Row2.TupleSelect(hv_Index)))).TupleConcat(
        //                        hv_RowP2.TupleSelect(hv_Index)))).TupleConcat(hv_Row2.TupleSelect(hv_Index)),
        //                        ((((((((((hv_Column1.TupleSelect(hv_Index))).TupleConcat(hv_Column2.TupleSelect(
        //                        hv_Index)))).TupleConcat(hv_ColP1.TupleSelect(hv_Index)))).TupleConcat(
        //                        hv_Column2.TupleSelect(hv_Index)))).TupleConcat(hv_ColP2.TupleSelect(
        //                        hv_Index)))).TupleConcat(hv_Column2.TupleSelect(hv_Index)));
        //                }
        //                {
        //                    HObject ExpTmpOutVar_0;
        //                    HOperatorSet.ConcatObj(ho_Arrow, ho_TempArrow, out ExpTmpOutVar_0);
        //                    ho_Arrow.Dispose();
        //                    ho_Arrow = ExpTmpOutVar_0;
        //                }
        //            }
        //            ho_TempArrow.Dispose();

        //            return;
        //        }
        //        catch (HalconException HDevExpDefaultException)
        //        {
        //            ho_TempArrow.Dispose();

        //            throw HDevExpDefaultException;
        //        }
        //    }

        /// <summary>
        /// 显示卡尺
        /// </summary>
        /// <param name="ILine_"></param>
        /// <param name="hWinRoi_"></param>
        /// <returns></returns>
        public bool Set_ShowSpoke(ILineShuJu ILine_, HalControl.HalconWinControl_ROI hWinRoi_)
        {
            bool ok = false;
            HObject ho_Regions, ho_Lines, ho_cross;
            HOperatorSet.GenEmptyObj(out ho_Regions);
            HOperatorSet.GenEmptyObj(out ho_Lines);
            HOperatorSet.GenEmptyObj(out ho_cross);

            HTuple resultRow_, resultCol_, beginRow_, beginCol_, endRow_, endCol_, centerRow_, centerCol_;
            rake(hWinRoi_.Ho_Image, out ho_Regions, ILine_.Hv_Elements, ILine_.Hv_DetectHeight, ILine_.Hv_DetectWidth, ILine_.Hv_Sigma, ILine_.Hv_Threshold, ILine_.Hv_Transition, ILine_.Hv_Select, ILine_.IOutSide.Row1, ILine_.IOutSide.Cols1, ILine_.IOutSide.Row2, ILine_.IOutSide.Cols2, out resultRow_, out resultCol_);

            ILine_.Ho_Regions_Draw.Dispose();
            ILine_.Ho_Regions_Draw = ho_Regions;

            /******生成点*******/
            HOperatorSet.GenCrossContourXld(out ho_cross, resultRow_, resultCol_, 6, 0.785398);
            ILine_.Ho_Regions_Rake.Dispose();
            ILine_.Ho_Regions_Rake = ho_cross;

            pts_to_best_line(out ho_Lines, resultRow_, resultCol_, ILine_.Hv_ActiveNum, out beginRow_, out beginCol_, out endRow_, out endCol_, out centerRow_, out centerCol_);

            ILine_.Ho_Line.Dispose();
            ILine_.Ho_Line = ho_Lines;

            HTuple rowCross = new HTuple(), colCross = new HTuple();
            rowCross[0] = beginRow_.D;
            rowCross[1] = endRow_.D;
            rowCross[2] = centerRow_.D;

            colCross[0] = beginCol_.D;
            colCross[1] = endCol_.D;
            colCross[2] = centerCol_.D;

            HObject ho_cross1;
            HOperatorSet.GenEmptyObj(out ho_cross1);
            HOperatorSet.GenCrossContourXld(out ho_cross1, rowCross, colCross, 60, 0.785398);

            ILine_.Ho_Cross.Dispose();
            ILine_.Ho_Cross = ho_cross1;

            /***********显示数据**************/
            hWinRoi_.HWindowControl.HalconWindow.DispObj(ILine_.Ho_Regions_Draw);
            hWinRoi_.HWindowControl.HalconWindow.DispObj(ILine_.Ho_Regions_Rake);
            hWinRoi_.HWindowControl.HalconWindow.DispObj(ILine_.Ho_Cross);
            hWinRoi_.HWindowControl.HalconWindow.DispObj(ILine_.Ho_Line);

            ok = true;
            return ok;
        }

        void rake(HObject ho_Image, out HObject ho_Regions, HTuple hv_Elements,
   HTuple hv_DetectHeight, HTuple hv_DetectWidth, HTuple hv_Sigma, HTuple hv_Threshold,
   HTuple hv_Transition, HTuple hv_Select, HTuple hv_Row1, HTuple hv_Column1, HTuple hv_Row2,
   HTuple hv_Column2, out HTuple hv_ResultRow, out HTuple hv_ResultColumn)
        {
            // Stack for temporary objects 
            HObject[] OTemp = new HObject[20];
            // Local iconic variables 
            HObject ho_RegionLines, ho_Rectangle = null;
            HObject ho_Arrow1 = null;
            // Local control variables 
            HTuple hv_Width = null, hv_Height = null, hv_ATan = null;
            HTuple hv_i = null, hv_RowC = new HTuple(), hv_ColC = new HTuple();
            HTuple hv_Distance = new HTuple(), hv_RowL2 = new HTuple();
            HTuple hv_RowL1 = new HTuple(), hv_ColL2 = new HTuple();
            HTuple hv_ColL1 = new HTuple(), hv_MsrHandle_Measure = new HTuple();
            HTuple hv_RowEdge = new HTuple(), hv_ColEdge = new HTuple();
            HTuple hv_Amplitude = new HTuple(), hv_tRow = new HTuple();
            HTuple hv_tCol = new HTuple(), hv_t = new HTuple(), hv_Number = new HTuple();
            HTuple hv_j = new HTuple();
            HTuple hv_DetectWidth_COPY_INP_TMP = hv_DetectWidth.Clone();
            HTuple hv_Select_COPY_INP_TMP = hv_Select.Clone();
            HTuple hv_Transition_COPY_INP_TMP = hv_Transition.Clone();

            hv_ResultRow = new HTuple();
            hv_ResultColumn = new HTuple();
            // Initialize local and output iconic variables 
            HOperatorSet.GenEmptyObj(out ho_Regions);
            HOperatorSet.GenEmptyObj(out ho_RegionLines);
            HOperatorSet.GenEmptyObj(out ho_Rectangle);
            HOperatorSet.GenEmptyObj(out ho_Arrow1);
            try
            {

                hv_ResultColumn[0] = 0;
                hv_ResultColumn[0] = 0;

                //获取图像尺寸
                HOperatorSet.GetImageSize(ho_Image, out hv_Width, out hv_Height);
                //产生一个空显示对象，用于显示
                ho_Regions.Dispose();
                HOperatorSet.GenEmptyObj(out ho_Regions);
                //初始化边缘坐标数组
                hv_ResultRow = new HTuple();
                hv_ResultColumn = new HTuple();
                //产生直线xld
                ho_RegionLines.Dispose();
                HOperatorSet.GenContourPolygonXld(out ho_RegionLines, hv_Row1.TupleConcat(hv_Row2),
                    hv_Column1.TupleConcat(hv_Column2));
                //存储到显示对象
                {
                    HObject ExpTmpOutVar_0;
                    HOperatorSet.ConcatObj(ho_Regions, ho_RegionLines, out ExpTmpOutVar_0);
                    ho_Regions.Dispose();
                    ho_Regions = ExpTmpOutVar_0;
                }
                //计算直线与x轴的夹角，逆时针方向为正向。
                HOperatorSet.AngleLx(hv_Row1, hv_Column1, hv_Row2, hv_Column2, out hv_ATan);

                //边缘检测方向垂直于检测直线：直线方向正向旋转90°为边缘检测方向
                hv_ATan = hv_ATan + ((new HTuple(90)).TupleRad());

                //根据检测直线按顺序产生测量区域矩形，并存储到显示对象
                HTuple end_val18 = hv_Elements;
                HTuple step_val18 = 1;
                for (hv_i = 1; hv_i.Continue(end_val18, step_val18); hv_i = hv_i.TupleAdd(step_val18))
                {
                    //RowC := Row1+(((Row2-Row1)*i)/(Elements+1))
                    //ColC := Column1+(Column2-Column1)*i/(Elements+1)
                    //if (RowC>Height-1 or RowC<0 or ColC>Width-1 or ColC<0)
                    //continue
                    //endif
                    //如果只有一个测量矩形，作为卡尺工具，宽度为检测直线的长度
                    if ((int)(new HTuple(hv_Elements.TupleEqual(1))) != 0)
                    {
                        hv_RowC = (hv_Row1 + hv_Row2) * 0.5;
                        hv_ColC = (hv_Column1 + hv_Column2) * 0.5;
                        //判断是否超出图像,超出不检测边缘
                        if ((int)((new HTuple((new HTuple((new HTuple(hv_RowC.TupleGreater(hv_Height - 1))).TupleOr(
                            new HTuple(hv_RowC.TupleLess(0))))).TupleOr(new HTuple(hv_ColC.TupleGreater(
                            hv_Width - 1))))).TupleOr(new HTuple(hv_ColC.TupleLess(0)))) != 0)
                        {
                            continue;
                        }
                        HOperatorSet.DistancePp(hv_Row1, hv_Column1, hv_Row2, hv_Column2, out hv_Distance);
                        hv_DetectWidth_COPY_INP_TMP = hv_Distance.Clone();
                        ho_Rectangle.Dispose();
                        HOperatorSet.GenRectangle2ContourXld(out ho_Rectangle, hv_RowC, hv_ColC,
                            hv_ATan, hv_DetectHeight / 2, hv_Distance / 2);
                    }
                    else
                    {
                        //如果有多个测量矩形，产生该测量矩形xld
                        hv_RowC = hv_Row1 + (((hv_Row2 - hv_Row1) * (hv_i - 1)) / (hv_Elements - 1));
                        hv_ColC = hv_Column1 + (((hv_Column2 - hv_Column1) * (hv_i - 1)) / (hv_Elements - 1));
                        //判断是否超出图像,超出不检测边缘
                        if ((int)((new HTuple((new HTuple((new HTuple(hv_RowC.TupleGreater(hv_Height - 1))).TupleOr(
                            new HTuple(hv_RowC.TupleLess(0))))).TupleOr(new HTuple(hv_ColC.TupleGreater(
                            hv_Width - 1))))).TupleOr(new HTuple(hv_ColC.TupleLess(0)))) != 0)
                        {
                            continue;
                        }
                        ho_Rectangle.Dispose();
                        HOperatorSet.GenRectangle2ContourXld(out ho_Rectangle, hv_RowC, hv_ColC,
                            hv_ATan, hv_DetectHeight / 2, hv_DetectWidth_COPY_INP_TMP / 2);
                    }

                    //把测量矩形xld存储到显示对象
                    {
                        HObject ExpTmpOutVar_0;
                        HOperatorSet.ConcatObj(ho_Regions, ho_Rectangle, out ExpTmpOutVar_0);
                        ho_Regions.Dispose();
                        ho_Regions = ExpTmpOutVar_0;
                    }
                    if ((int)(new HTuple(hv_i.TupleEqual(1))) != 0)
                    {
                        //在第一个测量矩形绘制一个箭头xld，用于只是边缘检测方向
                        hv_RowL2 = hv_RowC + ((hv_DetectHeight / 2) * (((-hv_ATan)).TupleSin()));
                        hv_RowL1 = hv_RowC - ((hv_DetectHeight / 2) * (((-hv_ATan)).TupleSin()));
                        hv_ColL2 = hv_ColC + ((hv_DetectHeight / 2) * (((-hv_ATan)).TupleCos()));
                        hv_ColL1 = hv_ColC - ((hv_DetectHeight / 2) * (((-hv_ATan)).TupleCos()));
                        ho_Arrow1.Dispose();
                        gen_arrow_contour_xld(out ho_Arrow1, hv_RowL1, hv_ColL1, hv_RowL2, hv_ColL2,
                            25, 25);
                        //把xld存储到显示对象
                        {
                            HObject ExpTmpOutVar_0;
                            HOperatorSet.ConcatObj(ho_Regions, ho_Arrow1, out ExpTmpOutVar_0);
                            ho_Regions.Dispose();
                            ho_Regions = ExpTmpOutVar_0;
                        }
                    }
                    //产生测量对象句柄
                    HOperatorSet.GenMeasureRectangle2(hv_RowC, hv_ColC, hv_ATan, hv_DetectHeight / 2,
                        hv_DetectWidth_COPY_INP_TMP / 2, hv_Width, hv_Height, "nearest_neighbor",
                        out hv_MsrHandle_Measure);

                    //设置极性
                    if ((int)(new HTuple(hv_Transition_COPY_INP_TMP.TupleEqual("negative"))) != 0)
                    {
                        hv_Transition_COPY_INP_TMP = "negative";
                    }
                    else
                    {
                        if ((int)(new HTuple(hv_Transition_COPY_INP_TMP.TupleEqual("positive"))) != 0)
                        {

                            hv_Transition_COPY_INP_TMP = "positive";
                        }
                        else
                        {
                            hv_Transition_COPY_INP_TMP = "all";
                        }
                    }
                    //设置边缘位置。最强点是从所有边缘中选择幅度绝对值最大点，需要设置为'all'
                    if ((int)(new HTuple(hv_Select_COPY_INP_TMP.TupleEqual("first"))) != 0)
                    {
                        hv_Select_COPY_INP_TMP = "first";
                    }
                    else
                    {
                        if ((int)(new HTuple(hv_Select_COPY_INP_TMP.TupleEqual("last"))) != 0)
                        {

                            hv_Select_COPY_INP_TMP = "last";
                        }
                        else
                        {
                            hv_Select_COPY_INP_TMP = "all";
                        }
                    }
                    //检测边缘
                    HOperatorSet.MeasurePos(ho_Image, hv_MsrHandle_Measure, hv_Sigma, hv_Threshold,
                        hv_Transition_COPY_INP_TMP, hv_Select_COPY_INP_TMP, out hv_RowEdge, out hv_ColEdge,
                        out hv_Amplitude, out hv_Distance);
                    //清除测量对象句柄
                    HOperatorSet.CloseMeasure(hv_MsrHandle_Measure);

                    //临时变量初始化
                    //tRow，tCol保存找到指定边缘的坐标
                    hv_tRow = 0;
                    hv_tCol = 0;
                    //t保存边缘的幅度绝对值
                    hv_t = 0;
                    //找到的边缘必须至少为1个
                    HOperatorSet.TupleLength(hv_RowEdge, out hv_Number);
                    if ((int)(new HTuple(hv_Number.TupleLess(1))) != 0)
                    {
                        continue;
                    }
                    //有多个边缘时，选择幅度绝对值最大的边缘
                    HTuple end_val100 = hv_Number - 1;
                    HTuple step_val100 = 1;
                    for (hv_j = 0; hv_j.Continue(end_val100, step_val100); hv_j = hv_j.TupleAdd(step_val100))
                    {
                        if ((int)(new HTuple(((((hv_Amplitude.TupleSelect(hv_j))).TupleAbs())).TupleGreater(
                            hv_t))) != 0)
                        {

                            hv_tRow = hv_RowEdge.TupleSelect(hv_j);
                            hv_tCol = hv_ColEdge.TupleSelect(hv_j);
                            hv_t = ((hv_Amplitude.TupleSelect(hv_j))).TupleAbs();
                        }
                    }
                    //把找到的边缘保存在输出数组
                    if ((int)(new HTuple(hv_t.TupleGreater(0))) != 0)
                    {
                        hv_ResultRow = hv_ResultRow.TupleConcat(hv_tRow);
                        hv_ResultColumn = hv_ResultColumn.TupleConcat(hv_tCol);
                    }
                }

                ho_RegionLines.Dispose();
                ho_Rectangle.Dispose();
                ho_Arrow1.Dispose();

                return;
            }
            catch (HalconException HDevExpDefaultException)
            {
                ho_RegionLines.Dispose();
                ho_Rectangle.Dispose();
                ho_Arrow1.Dispose();

                throw HDevExpDefaultException;
            }
        }

        void gen_arrow_contour_xld(out HObject ho_Arrow, HTuple hv_Row1, HTuple hv_Column1,
    HTuple hv_Row2, HTuple hv_Column2, HTuple hv_HeadLength, HTuple hv_HeadWidth)
        {
            // Stack for temporary objects 
            HObject[] OTemp = new HObject[20];

            // Local iconic variables 

            HObject ho_TempArrow = null;

            // Local control variables 

            HTuple hv_Length = null, hv_ZeroLengthIndices = null;
            HTuple hv_DR = null, hv_DC = null, hv_HalfHeadWidth = null;
            HTuple hv_RowP1 = null, hv_ColP1 = null, hv_RowP2 = null;
            HTuple hv_ColP2 = null, hv_Index = null;
            // Initialize local and output iconic variables 
            HOperatorSet.GenEmptyObj(out ho_Arrow);
            HOperatorSet.GenEmptyObj(out ho_TempArrow);
            try
            {
                //This procedure generates arrow shaped XLD contours,
                //pointing from (Row1, Column1) to (Row2, Column2).
                //If starting and end point are identical, a contour consisting
                //of a single point is returned.
                //
                //input parameteres:
                //Row1, Column1: Coordinates of the arrows' starting points
                //Row2, Column2: Coordinates of the arrows' end points
                //HeadLength, HeadWidth: Size of the arrow heads in pixels
                //
                //output parameter:
                //Arrow: The resulting XLD contour
                //
                //The input tuples Row1, Column1, Row2, and Column2 have to be of
                //the same length.
                //HeadLength and HeadWidth either have to be of the same length as
                //Row1, Column1, Row2, and Column2 or have to be a single element.
                //If one of the above restrictions is violated, an error will occur.
                //
                //
                //Init
                ho_Arrow.Dispose();
                HOperatorSet.GenEmptyObj(out ho_Arrow);
                //
                //Calculate the arrow length
                HOperatorSet.DistancePp(hv_Row1, hv_Column1, hv_Row2, hv_Column2, out hv_Length);
                //
                //Mark arrows with identical start and end point
                //(set Length to -1 to avoid division-by-zero exception)
                hv_ZeroLengthIndices = hv_Length.TupleFind(0);
                if ((int)(new HTuple(hv_ZeroLengthIndices.TupleNotEqual(-1))) != 0)
                {
                    if (hv_Length == null)
                        hv_Length = new HTuple();
                    hv_Length[hv_ZeroLengthIndices] = -1;
                }
                //
                //Calculate auxiliary variables.
                hv_DR = (1.0 * (hv_Row2 - hv_Row1)) / hv_Length;
                hv_DC = (1.0 * (hv_Column2 - hv_Column1)) / hv_Length;
                hv_HalfHeadWidth = hv_HeadWidth / 2.0;
                //
                //Calculate end points of the arrow head.
                hv_RowP1 = (hv_Row1 + ((hv_Length - hv_HeadLength) * hv_DR)) + (hv_HalfHeadWidth * hv_DC);
                hv_ColP1 = (hv_Column1 + ((hv_Length - hv_HeadLength) * hv_DC)) - (hv_HalfHeadWidth * hv_DR);
                hv_RowP2 = (hv_Row1 + ((hv_Length - hv_HeadLength) * hv_DR)) - (hv_HalfHeadWidth * hv_DC);
                hv_ColP2 = (hv_Column1 + ((hv_Length - hv_HeadLength) * hv_DC)) + (hv_HalfHeadWidth * hv_DR);
                //
                //Finally create output XLD contour for each input point pair
                for (hv_Index = 0; (int)hv_Index <= (int)((new HTuple(hv_Length.TupleLength())) - 1); hv_Index = (int)hv_Index + 1)
                {
                    if ((int)(new HTuple(((hv_Length.TupleSelect(hv_Index))).TupleEqual(-1))) != 0)
                    {
                        //Create_ single points for arrows with identical start and end point
                        ho_TempArrow.Dispose();
                        HOperatorSet.GenContourPolygonXld(out ho_TempArrow, hv_Row1.TupleSelect(
                            hv_Index), hv_Column1.TupleSelect(hv_Index));
                    }
                    else
                    {
                        //Create arrow contour
                        ho_TempArrow.Dispose();
                        HOperatorSet.GenContourPolygonXld(out ho_TempArrow, ((((((((((hv_Row1.TupleSelect(
                            hv_Index))).TupleConcat(hv_Row2.TupleSelect(hv_Index)))).TupleConcat(
                            hv_RowP1.TupleSelect(hv_Index)))).TupleConcat(hv_Row2.TupleSelect(hv_Index)))).TupleConcat(
                            hv_RowP2.TupleSelect(hv_Index)))).TupleConcat(hv_Row2.TupleSelect(hv_Index)),
                            ((((((((((hv_Column1.TupleSelect(hv_Index))).TupleConcat(hv_Column2.TupleSelect(
                            hv_Index)))).TupleConcat(hv_ColP1.TupleSelect(hv_Index)))).TupleConcat(
                            hv_Column2.TupleSelect(hv_Index)))).TupleConcat(hv_ColP2.TupleSelect(
                            hv_Index)))).TupleConcat(hv_Column2.TupleSelect(hv_Index)));
                    }
                    {
                        HObject ExpTmpOutVar_0;
                        HOperatorSet.ConcatObj(ho_Arrow, ho_TempArrow, out ExpTmpOutVar_0);
                        ho_Arrow.Dispose();
                        ho_Arrow = ExpTmpOutVar_0;
                    }
                }
                ho_TempArrow.Dispose();

                return;
            }
            catch (HalconException HDevExpDefaultException)
            {
                ho_TempArrow.Dispose();

                throw HDevExpDefaultException;
            }
        }

        //   void disp_message(HTuple hv_WindowHandle, HTuple hv_String, HTuple hv_CoordSystem,
        //HTuple hv_Row, HTuple hv_Column, HTuple hv_Color, HTuple hv_Box)
        //   {
        //       // Local iconic variables 
        //       // Local control variables 
        //       HTuple hv_Red = null, hv_Green = null, hv_Blue = null;
        //       HTuple hv_Row1Part = null, hv_Column1Part = null, hv_Row2Part = null;
        //       HTuple hv_Column2Part = null, hv_RowWin = null, hv_ColumnWin = null;
        //       HTuple hv_WidthWin = null, hv_HeightWin = null, hv_MaxAscent = null;
        //       HTuple hv_MaxDescent = null, hv_MaxWidth = null, hv_MaxHeight = null;
        //       HTuple hv_R1 = new HTuple(), hv_C1 = new HTuple(), hv_FactorRow = new HTuple();
        //       HTuple hv_FactorColumn = new HTuple(), hv_UseShadow = null;
        //       HTuple hv_ShadowColor = null, hv_Exception = new HTuple();
        //       HTuple hv_Width = new HTuple(), hv_Index = new HTuple();
        //       HTuple hv_Ascent = new HTuple(), hv_Descent = new HTuple();
        //       HTuple hv_W = new HTuple(), hv_H = new HTuple(), hv_FrameHeight = new HTuple();
        //       HTuple hv_FrameWidth = new HTuple(), hv_R2 = new HTuple();
        //       HTuple hv_C2 = new HTuple(), hv_DrawMode = new HTuple();
        //       HTuple hv_CurrentColor = new HTuple();
        //       HTuple hv_Box_COPY_INP_TMP = hv_Box.Clone();
        //       HTuple hv_Color_COPY_INP_TMP = hv_Color.Clone();
        //       HTuple hv_Column_COPY_INP_TMP = hv_Column.Clone();
        //       HTuple hv_Row_COPY_INP_TMP = hv_Row.Clone();
        //       HTuple hv_String_COPY_INP_TMP = hv_String.Clone();

        //       // Initialize local and output iconic variables 
        //       //This procedure displays text in a graphics window.
        //       //
        //       //Input parameters:
        //       //WindowHandle: The WindowHandle of the graphics window, where
        //       //   the message should be displayed
        //       //String: A tuple of strings containing the text message to be displayed
        //       //CoordSystem: If set to 'window', the text position is given
        //       //   with respect to the window coordinate system.
        //       //   If set to 'image', image coordinates are used.
        //       //   (This may be useful in zoomed images.)
        //       //Row: The row coordinate of the desired text position
        //       //   If set to -1, a default value of 12 is used.
        //       //Column: The column coordinate of the desired text position
        //       //   If set to -1, a default value of 12 is used.
        //       //Color: defines the color of the text as string.
        //       //   If set to [], '' or 'auto' the currently set color is used.
        //       //   If a tuple of strings is passed, the colors are used cyclically
        //       //   for each new textline.
        //       //Box: If Box[0] is set to 'true', the text is written within an orange box.
        //       //     If set to' false', no box is displayed.
        //       //     If set to a color string (e.g. 'white', '#FF00CC', etc.),
        //       //       the text is written in a box of that color.
        //       //     An optional second value for Box (Box[1]) controls if a shadow is displayed:
        //       //       'true' -> display a shadow in a default color
        //       //       'false' -> display no shadow (same as if no second value is given)
        //       //       otherwise -> use given string as color string for the shadow color
        //       //
        //       //Prepare window
        //       HOperatorSet.GetRgb(hv_WindowHandle, out hv_Red, out hv_Green, out hv_Blue);
        //       HOperatorSet.GetPart(hv_WindowHandle, out hv_Row1Part, out hv_Column1Part, out hv_Row2Part,
        //           out hv_Column2Part);
        //       HOperatorSet.GetWindowExtents(hv_WindowHandle, out hv_RowWin, out hv_ColumnWin,
        //           out hv_WidthWin, out hv_HeightWin);
        //       HOperatorSet.SetPart(hv_WindowHandle, 0, 0, hv_HeightWin - 1, hv_WidthWin - 1);
        //       //
        //       //default settings
        //       if ((int)(new HTuple(hv_Row_COPY_INP_TMP.TupleEqual(-1))) != 0)
        //       {
        //           hv_Row_COPY_INP_TMP = 12;
        //       }
        //       if ((int)(new HTuple(hv_Column_COPY_INP_TMP.TupleEqual(-1))) != 0)
        //       {
        //           hv_Column_COPY_INP_TMP = 12;
        //       }
        //       if ((int)(new HTuple(hv_Color_COPY_INP_TMP.TupleEqual(new HTuple()))) != 0)
        //       {
        //           hv_Color_COPY_INP_TMP = "";
        //       }
        //       //
        //       hv_String_COPY_INP_TMP = ((("" + hv_String_COPY_INP_TMP) + "")).TupleSplit("\n");
        //       //
        //       //Estimate extentions of text depending on font size.
        //       HOperatorSet.GetFontExtents(hv_WindowHandle, out hv_MaxAscent, out hv_MaxDescent,
        //           out hv_MaxWidth, out hv_MaxHeight);
        //       if ((int)(new HTuple(hv_CoordSystem.TupleEqual("window"))) != 0)
        //       {
        //           hv_R1 = hv_Row_COPY_INP_TMP.Clone();
        //           hv_C1 = hv_Column_COPY_INP_TMP.Clone();
        //       }
        //       else
        //       {
        //           //Transform image to window coordinates
        //           hv_FactorRow = (1.0 * hv_HeightWin) / ((hv_Row2Part - hv_Row1Part) + 1);
        //           hv_FactorColumn = (1.0 * hv_WidthWin) / ((hv_Column2Part - hv_Column1Part) + 1);
        //           hv_R1 = ((hv_Row_COPY_INP_TMP - hv_Row1Part) + 0.5) * hv_FactorRow;
        //           hv_C1 = ((hv_Column_COPY_INP_TMP - hv_Column1Part) + 0.5) * hv_FactorColumn;
        //       }
        //       //
        //       //Display text box depending on text size
        //       hv_UseShadow = 1;
        //       hv_ShadowColor = "gray";
        //       if ((int)(new HTuple(((hv_Box_COPY_INP_TMP.TupleSelect(0))).TupleEqual("true"))) != 0)
        //       {
        //           if (hv_Box_COPY_INP_TMP == null)
        //               hv_Box_COPY_INP_TMP = new HTuple();
        //           hv_Box_COPY_INP_TMP[0] = "#fce9d4";
        //           hv_ShadowColor = "#f28d26";
        //       }
        //       if ((int)(new HTuple((new HTuple(hv_Box_COPY_INP_TMP.TupleLength())).TupleGreater(
        //           1))) != 0)
        //       {
        //           if ((int)(new HTuple(((hv_Box_COPY_INP_TMP.TupleSelect(1))).TupleEqual("true"))) != 0)
        //           {
        //               //Use default ShadowColor set above
        //           }
        //           else if ((int)(new HTuple(((hv_Box_COPY_INP_TMP.TupleSelect(1))).TupleEqual(
        //               "false"))) != 0)
        //           {
        //               hv_UseShadow = 0;
        //           }
        //           else
        //           {
        //               hv_ShadowColor = hv_Box_COPY_INP_TMP[1];
        //               //Valid color?
        //               try
        //               {
        //                   HOperatorSet.SetColor(hv_WindowHandle, hv_Box_COPY_INP_TMP.TupleSelect(
        //                       1));
        //               }
        //               // catch (Exception) 
        //               catch (HalconException HDevExpDefaultException1)
        //               {
        //                   HDevExpDefaultException1.ToHTuple(out hv_Exception);
        //                   hv_Exception = "Wrong value of control parameter Box[1] (must be a 'true', 'false', or a valid color string)";
        //                   throw new HalconException(hv_Exception);
        //               }
        //           }
        //       }
        //       if ((int)(new HTuple(((hv_Box_COPY_INP_TMP.TupleSelect(0))).TupleNotEqual("false"))) != 0)
        //       {
        //           //Valid color?
        //           try
        //           {
        //               HOperatorSet.SetColor(hv_WindowHandle, hv_Box_COPY_INP_TMP.TupleSelect(0));
        //           }
        //           // catch (Exception) 
        //           catch (HalconException HDevExpDefaultException1)
        //           {
        //               HDevExpDefaultException1.ToHTuple(out hv_Exception);
        //               hv_Exception = "Wrong value of control parameter Box[0] (must be a 'true', 'false', or a valid color string)";
        //               throw new HalconException(hv_Exception);
        //           }
        //           //Calculate box extents
        //           hv_String_COPY_INP_TMP = (" " + hv_String_COPY_INP_TMP) + " ";
        //           hv_Width = new HTuple();
        //           for (hv_Index = 0; (int)hv_Index <= (int)((new HTuple(hv_String_COPY_INP_TMP.TupleLength()
        //               )) - 1); hv_Index = (int)hv_Index + 1)
        //           {
        //               HOperatorSet.GetStringExtents(hv_WindowHandle, hv_String_COPY_INP_TMP.TupleSelect(
        //                   hv_Index), out hv_Ascent, out hv_Descent, out hv_W, out hv_H);
        //               hv_Width = hv_Width.TupleConcat(hv_W);
        //           }
        //           hv_FrameHeight = hv_MaxHeight * (new HTuple(hv_String_COPY_INP_TMP.TupleLength()
        //               ));
        //           hv_FrameWidth = (((new HTuple(0)).TupleConcat(hv_Width))).TupleMax();
        //           hv_R2 = hv_R1 + hv_FrameHeight;
        //           hv_C2 = hv_C1 + hv_FrameWidth;
        //           //Display rectangles
        //           HOperatorSet.GetDraw(hv_WindowHandle, out hv_DrawMode);
        //           HOperatorSet.SetDraw(hv_WindowHandle, "fill");
        //           //Set shadow color
        //           HOperatorSet.SetColor(hv_WindowHandle, hv_ShadowColor);
        //           if ((int)(hv_UseShadow) != 0)
        //           {
        //               HOperatorSet.DispRectangle1(hv_WindowHandle, hv_R1 + 1, hv_C1 + 1, hv_R2 + 1, hv_C2 + 1);
        //           }
        //           //Set box color
        //           HOperatorSet.SetColor(hv_WindowHandle, hv_Box_COPY_INP_TMP.TupleSelect(0));
        //           HOperatorSet.DispRectangle1(hv_WindowHandle, hv_R1, hv_C1, hv_R2, hv_C2);
        //           HOperatorSet.SetDraw(hv_WindowHandle, hv_DrawMode);
        //       }
        //       //Write text.
        //       for (hv_Index = 0; (int)hv_Index <= (int)((new HTuple(hv_String_COPY_INP_TMP.TupleLength()
        //           )) - 1); hv_Index = (int)hv_Index + 1)
        //       {
        //           hv_CurrentColor = hv_Color_COPY_INP_TMP.TupleSelect(hv_Index % (new HTuple(hv_Color_COPY_INP_TMP.TupleLength()
        //               )));
        //           if ((int)((new HTuple(hv_CurrentColor.TupleNotEqual(""))).TupleAnd(new HTuple(hv_CurrentColor.TupleNotEqual(
        //               "auto")))) != 0)
        //           {
        //               HOperatorSet.SetColor(hv_WindowHandle, hv_CurrentColor);
        //           }
        //           else
        //           {
        //               HOperatorSet.SetRgb(hv_WindowHandle, hv_Red, hv_Green, hv_Blue);
        //           }
        //           hv_Row_COPY_INP_TMP = hv_R1 + (hv_MaxHeight * hv_Index);
        //           HOperatorSet.SetTposition(hv_WindowHandle, hv_Row_COPY_INP_TMP, hv_C1);
        //           HOperatorSet.WriteString(hv_WindowHandle, hv_String_COPY_INP_TMP.TupleSelect(
        //               hv_Index));
        //       }
        //       //Reset changed window settings
        //       HOperatorSet.SetRgb(hv_WindowHandle, hv_Red, hv_Green, hv_Blue);
        //       HOperatorSet.SetPart(hv_WindowHandle, hv_Row1Part, hv_Column1Part, hv_Row2Part,
        //           hv_Column2Part);

        //       return;
        //   }

        void pts_to_best_line(out HObject ho_Line, HTuple hv_Rows, HTuple hv_Cols,
    HTuple hv_ActiveNum, out HTuple hv_Row1, out HTuple hv_Column1, out HTuple hv_Row2,
    out HTuple hv_Column2, out HTuple hv_centerRow, out HTuple hv_centerCol)
        {
            // Local iconic variables 
            HObject ho_Contour = null;
            // Local control variables 
            HTuple hv_Length = null, hv_Nr = new HTuple();
            HTuple hv_Nc = new HTuple(), hv_Dist = new HTuple(), hv_Length1 = new HTuple();
            // Initialize local and output iconic variables 
            HOperatorSet.GenEmptyObj(out ho_Line);
            HOperatorSet.GenEmptyObj(out ho_Contour);
            hv_centerRow = new HTuple();
            hv_centerCol = new HTuple();
            try
            {

                hv_centerRow = 0;
                hv_centerCol = 0;
                //初始化
                hv_Row1 = 0;
                hv_Column1 = 0;
                hv_Row2 = 0;
                hv_Column2 = 0;
                //产生一个空的直线对象，用于保存拟合后的直线
                ho_Line.Dispose();
                HOperatorSet.GenEmptyObj(out ho_Line);
                //计算边缘数量
                HOperatorSet.TupleLength(hv_Cols, out hv_Length);
                //当边缘数量不小于有效点数时进行拟合
                if ((int)((new HTuple(hv_Length.TupleGreaterEqual(hv_ActiveNum))).TupleAnd(
                    new HTuple(hv_ActiveNum.TupleGreater(1)))) != 0)
                {
                    //halcon的拟合是基于xld的，需要把边缘连接成xld
                    ho_Contour.Dispose();
                    HOperatorSet.GenContourPolygonXld(out ho_Contour, hv_Rows, hv_Cols);
                    //拟合直线。使用的算法是'tukey'，其他算法请参考fit_line_contour_xld的描述部分。
                    HOperatorSet.FitLineContourXld(ho_Contour, "tukey", -1, 0, 5, 2, out hv_Row1,
                        out hv_Column1, out hv_Row2, out hv_Column2, out hv_Nr, out hv_Nc, out hv_Dist);
                    //*************输出中点*****************
                    hv_centerRow = (hv_Row1 + hv_Row2) / 2;
                    hv_centerCol = (hv_Column1 + hv_Column2) / 2;
                    //判断拟合结果是否有效：如果拟合成功，数组中元素的数量大于0
                    HOperatorSet.TupleLength(hv_Dist, out hv_Length1);
                    if ((int)(new HTuple(hv_Length1.TupleLess(1))) != 0)
                    {
                        ho_Contour.Dispose();
                        return;
                    }
                    //根据拟合结果，产生直线xld
                    ho_Line.Dispose();
                    HOperatorSet.GenContourPolygonXld(out ho_Line, hv_Row1.TupleConcat(hv_Row2),
                        hv_Column1.TupleConcat(hv_Column2));
                }
                ho_Contour.Dispose();
                return;
            }
            catch (HalconException HDevExpDefaultException)
            {
                ho_Contour.Dispose();

                throw HDevExpDefaultException;
            }
        }

        #endregion

        #region  无用代码
        //#region   刷新标定点
        ///// <summary>
        ///// 刷新标定点
        ///// </summary>
        ///// <param name="ILine_"></param>
        ///// <returns></returns>
        //public bool Set_ShuaXinDingWeiDian(ILineShuJu ILine_)
        //{
        //    bool ok = false;
        //    if (ILine_.IrectShuJuPianYi != null)
        //    {
        //        ILine_.GenSuiDian_A = ILine_.IrectShuJuPianYi.Angle;
        //        ILine_.GenSuiDian_Y_Row = ILine_.IrectShuJuPianYi.Row;
        //        ILine_.GeuSuiDian_X_Col = ILine_.IrectShuJuPianYi.Column;
        //    }
        //    ok = true;
        //    return ok;
        //}
        //#endregion
        #endregion

    }
    #endregion

    // #region  数据分析器
    // /// <summary>
    // /// 数据分析器
    // /// </summary>
    // public class Line : MultTree.ToolFather
    // {
    //     #region   卡尺测量
    //     //    /// <summary>
    //     //    /// 设置卡尺路径
    //     //    /// </summary>
    //     //    /// <param name="ILine_"></param>
    //     //    /// <param name="hwin"></param>
    //     //    /// <returns></returns>
    //     //    public bool Set_Draw_Rake(ILineShuJu ILine_, HWindow hwin)
    //     //    {
    //     //        bool ok = false;

    //     //        HObject ho_Regions;

    //     //        HTuple row1, column1, row2, column2;

    //     //        draw_rake(out ho_Regions, hwin, ILine_.Hv_Elements, ILine_.Hv_DetectHeight, ILine_.Hv_DetectWidth, out row1, out column1, out row2, out column2);

    //     //        ILine_.Ho_Regions_Draw = ho_Regions;
    //     //        ILine_.Hv_Row1_Draw = row1;
    //     //        ILine_.Hv_Column1_Draw = column1;
    //     //        ILine_.Hv_Row2_Draw = row2;
    //     //        ILine_.Hv_Column2_Draw = column2;

    //     //        hwin.DispObj(ILine_.Ho_Regions_Draw);

    //     //        ok = true;
    //     //        return ok;
    //     //    }

    //     //    void draw_rake(out HObject ho_Regions, HWindow hv_WindowHandle, HTuple hv_Elements,
    //     //        HTuple hv_DetectHeight, HTuple hv_DetectWidth, out HTuple hv_Row1, out HTuple hv_Column1,
    //     //        out HTuple hv_Row2, out HTuple hv_Column2)
    //     //    {
    //     //        // Stack for temporary objects 
    //     //        HObject[] OTemp = new HObject[20];
    //     //        // Local iconic variables 
    //     //        HObject ho_RegionLines, ho_Rectangle = null;
    //     //        HObject ho_Arrow1 = null;
    //     //        // Local control variables 
    //     //        HTuple hv_ATan = null, hv_i = null, hv_RowC = new HTuple();
    //     //        HTuple hv_ColC = new HTuple(), hv_Distance = new HTuple();
    //     //        HTuple hv_RowL2 = new HTuple(), hv_RowL1 = new HTuple();
    //     //        HTuple hv_ColL2 = new HTuple(), hv_ColL1 = new HTuple();
    //     //        // Initialize local and output iconic variables 
    //     //        HOperatorSet.GenEmptyObj(out ho_Regions);
    //     //        HOperatorSet.GenEmptyObj(out ho_RegionLines);
    //     //        HOperatorSet.GenEmptyObj(out ho_Rectangle);
    //     //        HOperatorSet.GenEmptyObj(out ho_Arrow1);
    //     //        try
    //     //        {
    //     //            //提示
    //     //            disp_message(hv_WindowHandle, "点击鼠标左键画一条直线,点击右键确认", "window",
    //     //                12, 12, "red", "false");
    //     //            //产生一个空显示对象，用于显示
    //     //            ho_Regions.Dispose();
    //     //            HOperatorSet.GenEmptyObj(out ho_Regions);
    //     //            //画矢量检测直线
    //     //            HOperatorSet.DrawLine(hv_WindowHandle, out hv_Row1, out hv_Column1, out hv_Row2,
    //     //                out hv_Column2);
    //     //            //产生直线xld
    //     //            ho_RegionLines.Dispose();
    //     //            HOperatorSet.GenContourPolygonXld(out ho_RegionLines, hv_Row1.TupleConcat(hv_Row2),
    //     //                hv_Column1.TupleConcat(hv_Column2));
    //     //            //存储到显示对象
    //     //            {
    //     //                HObject ExpTmpOutVar_0;
    //     //                HOperatorSet.ConcatObj(ho_Regions, ho_RegionLines, out ExpTmpOutVar_0);
    //     //                ho_Regions.Dispose();
    //     //                ho_Regions = ExpTmpOutVar_0;
    //     //            }
    //     //            //计算直线与x轴的夹角，逆时针方向为正向。
    //     //            HOperatorSet.AngleLx(hv_Row1, hv_Column1, hv_Row2, hv_Column2, out hv_ATan);

    //     //            //边缘检测方向垂直于检测直线：直线方向正向旋转90°为边缘检测方向
    //     //            hv_ATan = hv_ATan + ((new HTuple(90)).TupleRad());

    //     //            //根据检测直线按顺序产生测量区域矩形，并存储到显示对象
    //     //            HTuple end_val17 = hv_Elements;
    //     //            HTuple step_val17 = 1;
    //     //            for (hv_i = 1; hv_i.Continue(end_val17, step_val17); hv_i = hv_i.TupleAdd(step_val17))
    //     //            {
    //     //                //如果只有一个测量矩形，作为卡尺工具，宽度为检测直线的长度
    //     //                if ((int)(new HTuple(hv_Elements.TupleEqual(1))) != 0)
    //     //                {
    //     //                    hv_RowC = (hv_Row1 + hv_Row2) * 0.5;
    //     //                    hv_ColC = (hv_Column1 + hv_Column2) * 0.5;
    //     //                    HOperatorSet.DistancePp(hv_Row1, hv_Column1, hv_Row2, hv_Column2, out hv_Distance);
    //     //                    ho_Rectangle.Dispose();
    //     //                    HOperatorSet.GenRectangle2ContourXld(out ho_Rectangle, hv_RowC, hv_ColC,
    //     //                        hv_ATan, hv_DetectHeight / 2, hv_Distance / 2);
    //     //                }
    //     //                else
    //     //                {
    //     //                    //如果有多个测量矩形，产生该测量矩形xld
    //     //                    hv_RowC = hv_Row1 + (((hv_Row2 - hv_Row1) * (hv_i - 1)) / (hv_Elements - 1));
    //     //                    hv_ColC = hv_Column1 + (((hv_Column2 - hv_Column1) * (hv_i - 1)) / (hv_Elements - 1));
    //     //                    ho_Rectangle.Dispose();
    //     //                    HOperatorSet.GenRectangle2ContourXld(out ho_Rectangle, hv_RowC, hv_ColC,
    //     //                        hv_ATan, hv_DetectHeight / 2, hv_DetectWidth / 2);
    //     //                }
    //     //                //把测量矩形xld存储到显示对象
    //     //                {
    //     //                    HObject ExpTmpOutVar_0;
    //     //                    HOperatorSet.ConcatObj(ho_Regions, ho_Rectangle, out ExpTmpOutVar_0);
    //     //                    ho_Regions.Dispose();
    //     //                    ho_Regions = ExpTmpOutVar_0;
    //     //                }
    //     //                if ((int)(new HTuple(hv_i.TupleEqual(1))) != 0)
    //     //                {
    //     //                    //在第一个测量矩形绘制一个箭头xld，用于只是边缘检测方向
    //     //                    hv_RowL2 = hv_RowC + ((hv_DetectHeight / 2) * (((-hv_ATan)).TupleSin()));
    //     //                    hv_RowL1 = hv_RowC - ((hv_DetectHeight / 2) * (((-hv_ATan)).TupleSin()));
    //     //                    hv_ColL2 = hv_ColC + ((hv_DetectHeight / 2) * (((-hv_ATan)).TupleCos()));
    //     //                    hv_ColL1 = hv_ColC - ((hv_DetectHeight / 2) * (((-hv_ATan)).TupleCos()));
    //     //                    ho_Arrow1.Dispose();
    //     //                    gen_arrow_contour_xld(out ho_Arrow1, hv_RowL1, hv_ColL1, hv_RowL2, hv_ColL2,
    //     //                        25, 25);
    //     //                    //把xld存储到显示对象
    //     //                    {
    //     //                        HObject ExpTmpOutVar_0;
    //     //                        HOperatorSet.ConcatObj(ho_Regions, ho_Arrow1, out ExpTmpOutVar_0);
    //     //                        ho_Regions.Dispose();
    //     //                        ho_Regions = ExpTmpOutVar_0;
    //     //                    }
    //     //                }
    //     //            }

    //     //            ho_RegionLines.Dispose();
    //     //            ho_Rectangle.Dispose();
    //     //            ho_Arrow1.Dispose();

    //     //            return;
    //     //        }
    //     //        catch (HalconException HDevExpDefaultException)
    //     //        {
    //     //            ho_RegionLines.Dispose();
    //     //            ho_Rectangle.Dispose();
    //     //            ho_Arrow1.Dispose();

    //     //            throw HDevExpDefaultException;
    //     //        }
    //     //    }

    //     //    void gen_arrow_contour_xld(out HObject ho_Arrow, HTuple hv_Row1, HTuple hv_Column1,
    //     //HTuple hv_Row2, HTuple hv_Column2, HTuple hv_HeadLength, HTuple hv_HeadWidth)
    //     //    {
    //     //        // Stack for temporary objects 
    //     //        HObject[] OTemp = new HObject[20];

    //     //        // Local iconic variables 

    //     //        HObject ho_TempArrow = null;

    //     //        // Local control variables 

    //     //        HTuple hv_Length = null, hv_ZeroLengthIndices = null;
    //     //        HTuple hv_DR = null, hv_DC = null, hv_HalfHeadWidth = null;
    //     //        HTuple hv_RowP1 = null, hv_ColP1 = null, hv_RowP2 = null;
    //     //        HTuple hv_ColP2 = null, hv_Index = null;
    //     //        // Initialize local and output iconic variables 
    //     //        HOperatorSet.GenEmptyObj(out ho_Arrow);
    //     //        HOperatorSet.GenEmptyObj(out ho_TempArrow);
    //     //        try
    //     //        {
    //     //            //This procedure generates arrow shaped XLD contours,
    //     //            //pointing from (Row1, Column1) to (Row2, Column2).
    //     //            //If starting and end point are identical, a contour consisting
    //     //            //of a single point is returned.
    //     //            //
    //     //            //input parameteres:
    //     //            //Row1, Column1: Coordinates of the arrows' starting points
    //     //            //Row2, Column2: Coordinates of the arrows' end points
    //     //            //HeadLength, HeadWidth: Size of the arrow heads in pixels
    //     //            //
    //     //            //output parameter:
    //     //            //Arrow: The resulting XLD contour
    //     //            //
    //     //            //The input tuples Row1, Column1, Row2, and Column2 have to be of
    //     //            //the same length.
    //     //            //HeadLength and HeadWidth either have to be of the same length as
    //     //            //Row1, Column1, Row2, and Column2 or have to be a single element.
    //     //            //If one of the above restrictions is violated, an error will occur.
    //     //            //
    //     //            //
    //     //            //Init
    //     //            ho_Arrow.Dispose();
    //     //            HOperatorSet.GenEmptyObj(out ho_Arrow);
    //     //            //
    //     //            //Calculate the arrow length
    //     //            HOperatorSet.DistancePp(hv_Row1, hv_Column1, hv_Row2, hv_Column2, out hv_Length);
    //     //            //
    //     //            //Mark arrows with identical start and end point
    //     //            //(set Length to -1 to avoid division-by-zero exception)
    //     //            hv_ZeroLengthIndices = hv_Length.TupleFind(0);
    //     //            if ((int)(new HTuple(hv_ZeroLengthIndices.TupleNotEqual(-1))) != 0)
    //     //            {
    //     //                if (hv_Length == null)
    //     //                    hv_Length = new HTuple();
    //     //                hv_Length[hv_ZeroLengthIndices] = -1;
    //     //            }
    //     //            //
    //     //            //Calculate auxiliary variables.
    //     //            hv_DR = (1.0 * (hv_Row2 - hv_Row1)) / hv_Length;
    //     //            hv_DC = (1.0 * (hv_Column2 - hv_Column1)) / hv_Length;
    //     //            hv_HalfHeadWidth = hv_HeadWidth / 2.0;
    //     //            //
    //     //            //Calculate end points of the arrow head.
    //     //            hv_RowP1 = (hv_Row1 + ((hv_Length - hv_HeadLength) * hv_DR)) + (hv_HalfHeadWidth * hv_DC);
    //     //            hv_ColP1 = (hv_Column1 + ((hv_Length - hv_HeadLength) * hv_DC)) - (hv_HalfHeadWidth * hv_DR);
    //     //            hv_RowP2 = (hv_Row1 + ((hv_Length - hv_HeadLength) * hv_DR)) - (hv_HalfHeadWidth * hv_DC);
    //     //            hv_ColP2 = (hv_Column1 + ((hv_Length - hv_HeadLength) * hv_DC)) + (hv_HalfHeadWidth * hv_DR);
    //     //            //
    //     //            //Finally create output XLD contour for each input point pair
    //     //            for (hv_Index = 0; (int)hv_Index <= (int)((new HTuple(hv_Length.TupleLength())) - 1); hv_Index = (int)hv_Index + 1)
    //     //            {
    //     //                if ((int)(new HTuple(((hv_Length.TupleSelect(hv_Index))).TupleEqual(-1))) != 0)
    //     //                {
    //     //                    //Create_ single points for arrows with identical start and end point
    //     //                    ho_TempArrow.Dispose();
    //     //                    HOperatorSet.GenContourPolygonXld(out ho_TempArrow, hv_Row1.TupleSelect(
    //     //                        hv_Index), hv_Column1.TupleSelect(hv_Index));
    //     //                }
    //     //                else
    //     //                {
    //     //                    //Create arrow contour
    //     //                    ho_TempArrow.Dispose();
    //     //                    HOperatorSet.GenContourPolygonXld(out ho_TempArrow, ((((((((((hv_Row1.TupleSelect(
    //     //                        hv_Index))).TupleConcat(hv_Row2.TupleSelect(hv_Index)))).TupleConcat(
    //     //                        hv_RowP1.TupleSelect(hv_Index)))).TupleConcat(hv_Row2.TupleSelect(hv_Index)))).TupleConcat(
    //     //                        hv_RowP2.TupleSelect(hv_Index)))).TupleConcat(hv_Row2.TupleSelect(hv_Index)),
    //     //                        ((((((((((hv_Column1.TupleSelect(hv_Index))).TupleConcat(hv_Column2.TupleSelect(
    //     //                        hv_Index)))).TupleConcat(hv_ColP1.TupleSelect(hv_Index)))).TupleConcat(
    //     //                        hv_Column2.TupleSelect(hv_Index)))).TupleConcat(hv_ColP2.TupleSelect(
    //     //                        hv_Index)))).TupleConcat(hv_Column2.TupleSelect(hv_Index)));
    //     //                }
    //     //                {
    //     //                    HObject ExpTmpOutVar_0;
    //     //                    HOperatorSet.ConcatObj(ho_Arrow, ho_TempArrow, out ExpTmpOutVar_0);
    //     //                    ho_Arrow.Dispose();
    //     //                    ho_Arrow = ExpTmpOutVar_0;
    //     //                }
    //     //            }
    //     //            ho_TempArrow.Dispose();

    //     //            return;
    //     //        }
    //     //        catch (HalconException HDevExpDefaultException)
    //     //        {
    //     //            ho_TempArrow.Dispose();

    //     //            throw HDevExpDefaultException;
    //     //        }
    //     //    }

    //     /// <summary>
    //     /// 显示卡尺
    //     /// </summary>
    //     /// <param name="ILine_"></param>
    //     /// <param name="hWinRoi_"></param>
    //     /// <returns></returns>
    //     public bool Spoke(ILineShuJu ILine_, HalControl.HalconWinControl_ROI hWinRoi_)
    //     {
    //         bool ok = false;
    //         HObject ho_Regions, ho_Lines, ho_cross;
    //         HOperatorSet.GenEmptyObj(out ho_Regions);
    //         HOperatorSet.GenEmptyObj(out ho_Lines);
    //         HOperatorSet.GenEmptyObj(out ho_cross);

    //         HTuple oneRow_, oneCol_, twoRow_, twoCol_;
    //         if (ILine_.IrectShuJuPianYi != null)
    //         {
    //             HTuple hv_modMat2D_, crossRow_ = new HTuple(), crossCol_ = new HTuple(), Nr, Nc, Dist;
    //             HObject contour_;
    //             HOperatorSet.GenEmptyObj(out contour_);
    //             HOperatorSet.VectorAngleToRigid(ILine_.GenSuiDian_Y_Row, ILine_.GeuSuiDian_X_Col, ILine_.GenSuiDian_A, ILine_.IrectShuJuPianYi.Row, ILine_.IrectShuJuPianYi.Column, ILine_.IrectShuJuPianYi.Angle, out hv_modMat2D_);
    //             crossRow_[0] = ILine_.IOutSide.Row1.D;
    //             crossRow_[1] = ILine_.IOutSide.Row2.D;
    //             crossCol_[0] = ILine_.IOutSide.Cols1.D;
    //             crossCol_[1] = ILine_.IOutSide.Cols2.D;
    //             HOperatorSet.GenContourPolygonXld(out contour_, crossRow_, crossCol_);
    //             HOperatorSet.FitLineContourXld(contour_, "tukey", -1, 0, 5, 2, out oneRow_, out oneCol_, out twoRow_, out twoCol_, out Nr, out Nc, out Dist);
    //             contour_.Dispose();
    //         }
    //         else
    //         {
    //             oneCol_ = ILine_.IOutSide.Cols1;
    //             oneRow_ = ILine_.IOutSide.Row1;
    //             twoCol_ = ILine_.IOutSide.Cols2;
    //             twoRow_ = ILine_.IOutSide.Row2;
    //         }


    //         HTuple resultRow_, resultCol_, beginRow_, beginCol_, endRow_, endCol_, centerRow_, centerCol_;

    //         rake(hWinRoi_.Ho_Image, out ho_Regions, ILine_.Hv_Elements, ILine_.Hv_DetectHeight, ILine_.Hv_DetectWidth, ILine_.Hv_Sigma, ILine_.Hv_Threshold, ILine_.Hv_Transition, ILine_.Hv_Select, ILine_.IOutSide.Row1, ILine_.IOutSide.Cols1, ILine_.IOutSide.Row2, ILine_.IOutSide.Cols2, out resultRow_, out resultCol_);

    //         ILine_.Ho_Regions_Draw.Dispose();
    //         ILine_.Ho_Regions_Draw = ho_Regions;

    //         /******生成点*******/
    //         HOperatorSet.GenCrossContourXld(out ho_cross, resultRow_, resultCol_, 6, 0.785398);
    //         ILine_.Ho_Regions_Rake.Dispose();
    //         ILine_.Ho_Regions_Rake = ho_cross;

    //         pts_to_best_line(out ho_Lines, resultRow_, resultCol_, ILine_.Hv_ActiveNum, out beginRow_, out beginCol_, out endRow_, out endCol_, out centerRow_, out centerCol_);

    //         ILine_.Ho_Line.Dispose();
    //         ILine_.Ho_Line = ho_Lines;

    //         HTuple rowCross = new HTuple(), colCross = new HTuple();
    //         rowCross[0] = beginRow_.D;
    //         rowCross[1] = endRow_.D;
    //         rowCross[2] = centerRow_.D;

    //         colCross[0] = beginCol_.D;
    //         colCross[1] = endCol_.D;
    //         colCross[2] = centerCol_.D;

    //         ILine_.Hv_Column11 = beginCol_;
    //         ILine_.Hv_Row11 = beginRow_;

    //         ILine_.Hv_Row21 = endRow_;
    //         ILine_.Hv_Column21 = endCol_;

    //         ILine_.Row = centerRow_;
    //         ILine_.Column = centerCol_;
    //         ILine_.Angle = 0;

    //         HObject ho_cross1;
    //         HOperatorSet.GenEmptyObj(out ho_cross1);
    //         HOperatorSet.GenCrossContourXld(out ho_cross1, rowCross, colCross, 60, 0.785398);

    //         ILine_.Ho_Cross.Dispose();
    //         ILine_.Ho_Cross = ho_cross1;

    //         ok = true;
    //         return ok;
    //     }

    //     void rake(HObject ho_Image, out HObject ho_Regions, HTuple hv_Elements,
    //HTuple hv_DetectHeight, HTuple hv_DetectWidth, HTuple hv_Sigma, HTuple hv_Threshold,
    //HTuple hv_Transition, HTuple hv_Select, HTuple hv_Row1, HTuple hv_Column1, HTuple hv_Row2,
    //HTuple hv_Column2, out HTuple hv_ResultRow, out HTuple hv_ResultColumn)
    //     {
    //         // Stack for temporary objects 
    //         HObject[] OTemp = new HObject[20];
    //         // Local iconic variables 
    //         HObject ho_RegionLines, ho_Rectangle = null;
    //         HObject ho_Arrow1 = null;
    //         // Local control variables 
    //         HTuple hv_Width = null, hv_Height = null, hv_ATan = null;
    //         HTuple hv_i = null, hv_RowC = new HTuple(), hv_ColC = new HTuple();
    //         HTuple hv_Distance = new HTuple(), hv_RowL2 = new HTuple();
    //         HTuple hv_RowL1 = new HTuple(), hv_ColL2 = new HTuple();
    //         HTuple hv_ColL1 = new HTuple(), hv_MsrHandle_Measure = new HTuple();
    //         HTuple hv_RowEdge = new HTuple(), hv_ColEdge = new HTuple();
    //         HTuple hv_Amplitude = new HTuple(), hv_tRow = new HTuple();
    //         HTuple hv_tCol = new HTuple(), hv_t = new HTuple(), hv_Number = new HTuple();
    //         HTuple hv_j = new HTuple();
    //         HTuple hv_DetectWidth_COPY_INP_TMP = hv_DetectWidth.Clone();
    //         HTuple hv_Select_COPY_INP_TMP = hv_Select.Clone();
    //         HTuple hv_Transition_COPY_INP_TMP = hv_Transition.Clone();

    //         hv_ResultRow = new HTuple();
    //         hv_ResultColumn = new HTuple();
    //         // Initialize local and output iconic variables 
    //         HOperatorSet.GenEmptyObj(out ho_Regions);
    //         HOperatorSet.GenEmptyObj(out ho_RegionLines);
    //         HOperatorSet.GenEmptyObj(out ho_Rectangle);
    //         HOperatorSet.GenEmptyObj(out ho_Arrow1);
    //         try
    //         {

    //             hv_ResultColumn[0] = 0;
    //             hv_ResultColumn[0] = 0;

    //             //获取图像尺寸
    //             HOperatorSet.GetImageSize(ho_Image, out hv_Width, out hv_Height);
    //             //产生一个空显示对象，用于显示
    //             ho_Regions.Dispose();
    //             HOperatorSet.GenEmptyObj(out ho_Regions);
    //             //初始化边缘坐标数组
    //             hv_ResultRow = new HTuple();
    //             hv_ResultColumn = new HTuple();
    //             //产生直线xld
    //             ho_RegionLines.Dispose();
    //             HOperatorSet.GenContourPolygonXld(out ho_RegionLines, hv_Row1.TupleConcat(hv_Row2),
    //                 hv_Column1.TupleConcat(hv_Column2));
    //             //存储到显示对象
    //             {
    //                 HObject ExpTmpOutVar_0;
    //                 HOperatorSet.ConcatObj(ho_Regions, ho_RegionLines, out ExpTmpOutVar_0);
    //                 ho_Regions.Dispose();
    //                 ho_Regions = ExpTmpOutVar_0;
    //             }
    //             //计算直线与x轴的夹角，逆时针方向为正向。
    //             HOperatorSet.AngleLx(hv_Row1, hv_Column1, hv_Row2, hv_Column2, out hv_ATan);

    //             //边缘检测方向垂直于检测直线：直线方向正向旋转90°为边缘检测方向
    //             hv_ATan = hv_ATan + ((new HTuple(90)).TupleRad());

    //             //根据检测直线按顺序产生测量区域矩形，并存储到显示对象
    //             HTuple end_val18 = hv_Elements;
    //             HTuple step_val18 = 1;
    //             for (hv_i = 1; hv_i.Continue(end_val18, step_val18); hv_i = hv_i.TupleAdd(step_val18))
    //             {
    //                 //RowC := Row1+(((Row2-Row1)*i)/(Elements+1))
    //                 //ColC := Column1+(Column2-Column1)*i/(Elements+1)
    //                 //if (RowC>Height-1 or RowC<0 or ColC>Width-1 or ColC<0)
    //                 //continue
    //                 //endif
    //                 //如果只有一个测量矩形，作为卡尺工具，宽度为检测直线的长度
    //                 if ((int)(new HTuple(hv_Elements.TupleEqual(1))) != 0)
    //                 {
    //                     hv_RowC = (hv_Row1 + hv_Row2) * 0.5;
    //                     hv_ColC = (hv_Column1 + hv_Column2) * 0.5;
    //                     //判断是否超出图像,超出不检测边缘
    //                     if ((int)((new HTuple((new HTuple((new HTuple(hv_RowC.TupleGreater(hv_Height - 1))).TupleOr(
    //                         new HTuple(hv_RowC.TupleLess(0))))).TupleOr(new HTuple(hv_ColC.TupleGreater(
    //                         hv_Width - 1))))).TupleOr(new HTuple(hv_ColC.TupleLess(0)))) != 0)
    //                     {
    //                         continue;
    //                     }
    //                     HOperatorSet.DistancePp(hv_Row1, hv_Column1, hv_Row2, hv_Column2, out hv_Distance);
    //                     hv_DetectWidth_COPY_INP_TMP = hv_Distance.Clone();
    //                     ho_Rectangle.Dispose();
    //                     HOperatorSet.GenRectangle2ContourXld(out ho_Rectangle, hv_RowC, hv_ColC,
    //                         hv_ATan, hv_DetectHeight / 2, hv_Distance / 2);
    //                 }
    //                 else
    //                 {
    //                     //如果有多个测量矩形，产生该测量矩形xld
    //                     hv_RowC = hv_Row1 + (((hv_Row2 - hv_Row1) * (hv_i - 1)) / (hv_Elements - 1));
    //                     hv_ColC = hv_Column1 + (((hv_Column2 - hv_Column1) * (hv_i - 1)) / (hv_Elements - 1));
    //                     //判断是否超出图像,超出不检测边缘
    //                     if ((int)((new HTuple((new HTuple((new HTuple(hv_RowC.TupleGreater(hv_Height - 1))).TupleOr(
    //                         new HTuple(hv_RowC.TupleLess(0))))).TupleOr(new HTuple(hv_ColC.TupleGreater(
    //                         hv_Width - 1))))).TupleOr(new HTuple(hv_ColC.TupleLess(0)))) != 0)
    //                     {
    //                         continue;
    //                     }
    //                     ho_Rectangle.Dispose();
    //                     HOperatorSet.GenRectangle2ContourXld(out ho_Rectangle, hv_RowC, hv_ColC,
    //                         hv_ATan, hv_DetectHeight / 2, hv_DetectWidth_COPY_INP_TMP / 2);
    //                 }

    //                 //把测量矩形xld存储到显示对象
    //                 {
    //                     HObject ExpTmpOutVar_0;
    //                     HOperatorSet.ConcatObj(ho_Regions, ho_Rectangle, out ExpTmpOutVar_0);
    //                     ho_Regions.Dispose();
    //                     ho_Regions = ExpTmpOutVar_0;
    //                 }
    //                 if ((int)(new HTuple(hv_i.TupleEqual(1))) != 0)
    //                 {
    //                     //在第一个测量矩形绘制一个箭头xld，用于只是边缘检测方向
    //                     hv_RowL2 = hv_RowC + ((hv_DetectHeight / 2) * (((-hv_ATan)).TupleSin()));
    //                     hv_RowL1 = hv_RowC - ((hv_DetectHeight / 2) * (((-hv_ATan)).TupleSin()));
    //                     hv_ColL2 = hv_ColC + ((hv_DetectHeight / 2) * (((-hv_ATan)).TupleCos()));
    //                     hv_ColL1 = hv_ColC - ((hv_DetectHeight / 2) * (((-hv_ATan)).TupleCos()));
    //                     ho_Arrow1.Dispose();
    //                     gen_arrow_contour_xld(out ho_Arrow1, hv_RowL1, hv_ColL1, hv_RowL2, hv_ColL2,
    //                         25, 25);
    //                     //把xld存储到显示对象
    //                     {
    //                         HObject ExpTmpOutVar_0;
    //                         HOperatorSet.ConcatObj(ho_Regions, ho_Arrow1, out ExpTmpOutVar_0);
    //                         ho_Regions.Dispose();
    //                         ho_Regions = ExpTmpOutVar_0;
    //                     }
    //                 }
    //                 //产生测量对象句柄
    //                 HOperatorSet.GenMeasureRectangle2(hv_RowC, hv_ColC, hv_ATan, hv_DetectHeight / 2,
    //                     hv_DetectWidth_COPY_INP_TMP / 2, hv_Width, hv_Height, "nearest_neighbor",
    //                     out hv_MsrHandle_Measure);

    //                 //设置极性
    //                 if ((int)(new HTuple(hv_Transition_COPY_INP_TMP.TupleEqual("negative"))) != 0)
    //                 {
    //                     hv_Transition_COPY_INP_TMP = "negative";
    //                 }
    //                 else
    //                 {
    //                     if ((int)(new HTuple(hv_Transition_COPY_INP_TMP.TupleEqual("positive"))) != 0)
    //                     {

    //                         hv_Transition_COPY_INP_TMP = "positive";
    //                     }
    //                     else
    //                     {
    //                         hv_Transition_COPY_INP_TMP = "all";
    //                     }
    //                 }
    //                 //设置边缘位置。最强点是从所有边缘中选择幅度绝对值最大点，需要设置为'all'
    //                 if ((int)(new HTuple(hv_Select_COPY_INP_TMP.TupleEqual("first"))) != 0)
    //                 {
    //                     hv_Select_COPY_INP_TMP = "first";
    //                 }
    //                 else
    //                 {
    //                     if ((int)(new HTuple(hv_Select_COPY_INP_TMP.TupleEqual("last"))) != 0)
    //                     {

    //                         hv_Select_COPY_INP_TMP = "last";
    //                     }
    //                     else
    //                     {
    //                         hv_Select_COPY_INP_TMP = "all";
    //                     }
    //                 }
    //                 //检测边缘
    //                 HOperatorSet.MeasurePos(ho_Image, hv_MsrHandle_Measure, hv_Sigma, hv_Threshold,
    //                     hv_Transition_COPY_INP_TMP, hv_Select_COPY_INP_TMP, out hv_RowEdge, out hv_ColEdge,
    //                     out hv_Amplitude, out hv_Distance);
    //                 //清除测量对象句柄
    //                 HOperatorSet.CloseMeasure(hv_MsrHandle_Measure);

    //                 //临时变量初始化
    //                 //tRow，tCol保存找到指定边缘的坐标
    //                 hv_tRow = 0;
    //                 hv_tCol = 0;
    //                 //t保存边缘的幅度绝对值
    //                 hv_t = 0;
    //                 //找到的边缘必须至少为1个
    //                 HOperatorSet.TupleLength(hv_RowEdge, out hv_Number);
    //                 if ((int)(new HTuple(hv_Number.TupleLess(1))) != 0)
    //                 {
    //                     continue;
    //                 }
    //                 //有多个边缘时，选择幅度绝对值最大的边缘
    //                 HTuple end_val100 = hv_Number - 1;
    //                 HTuple step_val100 = 1;
    //                 for (hv_j = 0; hv_j.Continue(end_val100, step_val100); hv_j = hv_j.TupleAdd(step_val100))
    //                 {
    //                     if ((int)(new HTuple(((((hv_Amplitude.TupleSelect(hv_j))).TupleAbs())).TupleGreater(
    //                         hv_t))) != 0)
    //                     {

    //                         hv_tRow = hv_RowEdge.TupleSelect(hv_j);
    //                         hv_tCol = hv_ColEdge.TupleSelect(hv_j);
    //                         hv_t = ((hv_Amplitude.TupleSelect(hv_j))).TupleAbs();
    //                     }
    //                 }
    //                 //把找到的边缘保存在输出数组
    //                 if ((int)(new HTuple(hv_t.TupleGreater(0))) != 0)
    //                 {
    //                     hv_ResultRow = hv_ResultRow.TupleConcat(hv_tRow);
    //                     hv_ResultColumn = hv_ResultColumn.TupleConcat(hv_tCol);
    //                 }
    //             }

    //             ho_RegionLines.Dispose();
    //             ho_Rectangle.Dispose();
    //             ho_Arrow1.Dispose();

    //             return;
    //         }
    //         catch (HalconException HDevExpDefaultException)
    //         {
    //             ho_RegionLines.Dispose();
    //             ho_Rectangle.Dispose();
    //             ho_Arrow1.Dispose();

    //             throw HDevExpDefaultException;
    //         }
    //     }

    //     void gen_arrow_contour_xld(out HObject ho_Arrow, HTuple hv_Row1, HTuple hv_Column1,
    // HTuple hv_Row2, HTuple hv_Column2, HTuple hv_HeadLength, HTuple hv_HeadWidth)
    //     {
    //         // Stack for temporary objects 
    //         HObject[] OTemp = new HObject[20];

    //         // Local iconic variables 

    //         HObject ho_TempArrow = null;

    //         // Local control variables 

    //         HTuple hv_Length = null, hv_ZeroLengthIndices = null;
    //         HTuple hv_DR = null, hv_DC = null, hv_HalfHeadWidth = null;
    //         HTuple hv_RowP1 = null, hv_ColP1 = null, hv_RowP2 = null;
    //         HTuple hv_ColP2 = null, hv_Index = null;
    //         // Initialize local and output iconic variables 
    //         HOperatorSet.GenEmptyObj(out ho_Arrow);
    //         HOperatorSet.GenEmptyObj(out ho_TempArrow);
    //         try
    //         {
    //             //This procedure generates arrow shaped XLD contours,
    //             //pointing from (Row1, Column1) to (Row2, Column2).
    //             //If starting and end point are identical, a contour consisting
    //             //of a single point is returned.
    //             //
    //             //input parameteres:
    //             //Row1, Column1: Coordinates of the arrows' starting points
    //             //Row2, Column2: Coordinates of the arrows' end points
    //             //HeadLength, HeadWidth: Size of the arrow heads in pixels
    //             //
    //             //output parameter:
    //             //Arrow: The resulting XLD contour
    //             //
    //             //The input tuples Row1, Column1, Row2, and Column2 have to be of
    //             //the same length.
    //             //HeadLength and HeadWidth either have to be of the same length as
    //             //Row1, Column1, Row2, and Column2 or have to be a single element.
    //             //If one of the above restrictions is violated, an error will occur.
    //             //
    //             //
    //             //Init
    //             ho_Arrow.Dispose();
    //             HOperatorSet.GenEmptyObj(out ho_Arrow);
    //             //
    //             //Calculate the arrow length
    //             HOperatorSet.DistancePp(hv_Row1, hv_Column1, hv_Row2, hv_Column2, out hv_Length);
    //             //
    //             //Mark arrows with identical start and end point
    //             //(set Length to -1 to avoid division-by-zero exception)
    //             hv_ZeroLengthIndices = hv_Length.TupleFind(0);
    //             if ((int)(new HTuple(hv_ZeroLengthIndices.TupleNotEqual(-1))) != 0)
    //             {
    //                 if (hv_Length == null)
    //                     hv_Length = new HTuple();
    //                 hv_Length[hv_ZeroLengthIndices] = -1;
    //             }
    //             //
    //             //Calculate auxiliary variables.
    //             hv_DR = (1.0 * (hv_Row2 - hv_Row1)) / hv_Length;
    //             hv_DC = (1.0 * (hv_Column2 - hv_Column1)) / hv_Length;
    //             hv_HalfHeadWidth = hv_HeadWidth / 2.0;
    //             //
    //             //Calculate end points of the arrow head.
    //             hv_RowP1 = (hv_Row1 + ((hv_Length - hv_HeadLength) * hv_DR)) + (hv_HalfHeadWidth * hv_DC);
    //             hv_ColP1 = (hv_Column1 + ((hv_Length - hv_HeadLength) * hv_DC)) - (hv_HalfHeadWidth * hv_DR);
    //             hv_RowP2 = (hv_Row1 + ((hv_Length - hv_HeadLength) * hv_DR)) - (hv_HalfHeadWidth * hv_DC);
    //             hv_ColP2 = (hv_Column1 + ((hv_Length - hv_HeadLength) * hv_DC)) + (hv_HalfHeadWidth * hv_DR);
    //             //
    //             //Finally create output XLD contour for each input point pair
    //             for (hv_Index = 0; (int)hv_Index <= (int)((new HTuple(hv_Length.TupleLength())) - 1); hv_Index = (int)hv_Index + 1)
    //             {
    //                 if ((int)(new HTuple(((hv_Length.TupleSelect(hv_Index))).TupleEqual(-1))) != 0)
    //                 {
    //                     //Create_ single points for arrows with identical start and end point
    //                     ho_TempArrow.Dispose();
    //                     HOperatorSet.GenContourPolygonXld(out ho_TempArrow, hv_Row1.TupleSelect(
    //                         hv_Index), hv_Column1.TupleSelect(hv_Index));
    //                 }
    //                 else
    //                 {
    //                     //Create arrow contour
    //                     ho_TempArrow.Dispose();
    //                     HOperatorSet.GenContourPolygonXld(out ho_TempArrow, ((((((((((hv_Row1.TupleSelect(
    //                         hv_Index))).TupleConcat(hv_Row2.TupleSelect(hv_Index)))).TupleConcat(
    //                         hv_RowP1.TupleSelect(hv_Index)))).TupleConcat(hv_Row2.TupleSelect(hv_Index)))).TupleConcat(
    //                         hv_RowP2.TupleSelect(hv_Index)))).TupleConcat(hv_Row2.TupleSelect(hv_Index)),
    //                         ((((((((((hv_Column1.TupleSelect(hv_Index))).TupleConcat(hv_Column2.TupleSelect(
    //                         hv_Index)))).TupleConcat(hv_ColP1.TupleSelect(hv_Index)))).TupleConcat(
    //                         hv_Column2.TupleSelect(hv_Index)))).TupleConcat(hv_ColP2.TupleSelect(
    //                         hv_Index)))).TupleConcat(hv_Column2.TupleSelect(hv_Index)));
    //                 }
    //                 {
    //                     HObject ExpTmpOutVar_0;
    //                     HOperatorSet.ConcatObj(ho_Arrow, ho_TempArrow, out ExpTmpOutVar_0);
    //                     ho_Arrow.Dispose();
    //                     ho_Arrow = ExpTmpOutVar_0;
    //                 }
    //             }
    //             ho_TempArrow.Dispose();

    //             return;
    //         }
    //         catch (HalconException HDevExpDefaultException)
    //         {
    //             ho_TempArrow.Dispose();

    //             throw HDevExpDefaultException;
    //         }
    //     }

    //     //   void disp_message(HTuple hv_WindowHandle, HTuple hv_String, HTuple hv_CoordSystem,
    //     //HTuple hv_Row, HTuple hv_Column, HTuple hv_Color, HTuple hv_Box)
    //     //   {
    //     //       // Local iconic variables 
    //     //       // Local control variables 
    //     //       HTuple hv_Red = null, hv_Green = null, hv_Blue = null;
    //     //       HTuple hv_Row1Part = null, hv_Column1Part = null, hv_Row2Part = null;
    //     //       HTuple hv_Column2Part = null, hv_RowWin = null, hv_ColumnWin = null;
    //     //       HTuple hv_WidthWin = null, hv_HeightWin = null, hv_MaxAscent = null;
    //     //       HTuple hv_MaxDescent = null, hv_MaxWidth = null, hv_MaxHeight = null;
    //     //       HTuple hv_R1 = new HTuple(), hv_C1 = new HTuple(), hv_FactorRow = new HTuple();
    //     //       HTuple hv_FactorColumn = new HTuple(), hv_UseShadow = null;
    //     //       HTuple hv_ShadowColor = null, hv_Exception = new HTuple();
    //     //       HTuple hv_Width = new HTuple(), hv_Index = new HTuple();
    //     //       HTuple hv_Ascent = new HTuple(), hv_Descent = new HTuple();
    //     //       HTuple hv_W = new HTuple(), hv_H = new HTuple(), hv_FrameHeight = new HTuple();
    //     //       HTuple hv_FrameWidth = new HTuple(), hv_R2 = new HTuple();
    //     //       HTuple hv_C2 = new HTuple(), hv_DrawMode = new HTuple();
    //     //       HTuple hv_CurrentColor = new HTuple();
    //     //       HTuple hv_Box_COPY_INP_TMP = hv_Box.Clone();
    //     //       HTuple hv_Color_COPY_INP_TMP = hv_Color.Clone();
    //     //       HTuple hv_Column_COPY_INP_TMP = hv_Column.Clone();
    //     //       HTuple hv_Row_COPY_INP_TMP = hv_Row.Clone();
    //     //       HTuple hv_String_COPY_INP_TMP = hv_String.Clone();

    //     //       // Initialize local and output iconic variables 
    //     //       //This procedure displays text in a graphics window.
    //     //       //
    //     //       //Input parameters:
    //     //       //WindowHandle: The WindowHandle of the graphics window, where
    //     //       //   the message should be displayed
    //     //       //String: A tuple of strings containing the text message to be displayed
    //     //       //CoordSystem: If set to 'window', the text position is given
    //     //       //   with respect to the window coordinate system.
    //     //       //   If set to 'image', image coordinates are used.
    //     //       //   (This may be useful in zoomed images.)
    //     //       //Row: The row coordinate of the desired text position
    //     //       //   If set to -1, a default value of 12 is used.
    //     //       //Column: The column coordinate of the desired text position
    //     //       //   If set to -1, a default value of 12 is used.
    //     //       //Color: defines the color of the text as string.
    //     //       //   If set to [], '' or 'auto' the currently set color is used.
    //     //       //   If a tuple of strings is passed, the colors are used cyclically
    //     //       //   for each new textline.
    //     //       //Box: If Box[0] is set to 'true', the text is written within an orange box.
    //     //       //     If set to' false', no box is displayed.
    //     //       //     If set to a color string (e.g. 'white', '#FF00CC', etc.),
    //     //       //       the text is written in a box of that color.
    //     //       //     An optional second value for Box (Box[1]) controls if a shadow is displayed:
    //     //       //       'true' -> display a shadow in a default color
    //     //       //       'false' -> display no shadow (same as if no second value is given)
    //     //       //       otherwise -> use given string as color string for the shadow color
    //     //       //
    //     //       //Prepare window
    //     //       HOperatorSet.GetRgb(hv_WindowHandle, out hv_Red, out hv_Green, out hv_Blue);
    //     //       HOperatorSet.GetPart(hv_WindowHandle, out hv_Row1Part, out hv_Column1Part, out hv_Row2Part,
    //     //           out hv_Column2Part);
    //     //       HOperatorSet.GetWindowExtents(hv_WindowHandle, out hv_RowWin, out hv_ColumnWin,
    //     //           out hv_WidthWin, out hv_HeightWin);
    //     //       HOperatorSet.SetPart(hv_WindowHandle, 0, 0, hv_HeightWin - 1, hv_WidthWin - 1);
    //     //       //
    //     //       //default settings
    //     //       if ((int)(new HTuple(hv_Row_COPY_INP_TMP.TupleEqual(-1))) != 0)
    //     //       {
    //     //           hv_Row_COPY_INP_TMP = 12;
    //     //       }
    //     //       if ((int)(new HTuple(hv_Column_COPY_INP_TMP.TupleEqual(-1))) != 0)
    //     //       {
    //     //           hv_Column_COPY_INP_TMP = 12;
    //     //       }
    //     //       if ((int)(new HTuple(hv_Color_COPY_INP_TMP.TupleEqual(new HTuple()))) != 0)
    //     //       {
    //     //           hv_Color_COPY_INP_TMP = "";
    //     //       }
    //     //       //
    //     //       hv_String_COPY_INP_TMP = ((("" + hv_String_COPY_INP_TMP) + "")).TupleSplit("\n");
    //     //       //
    //     //       //Estimate extentions of text depending on font size.
    //     //       HOperatorSet.GetFontExtents(hv_WindowHandle, out hv_MaxAscent, out hv_MaxDescent,
    //     //           out hv_MaxWidth, out hv_MaxHeight);
    //     //       if ((int)(new HTuple(hv_CoordSystem.TupleEqual("window"))) != 0)
    //     //       {
    //     //           hv_R1 = hv_Row_COPY_INP_TMP.Clone();
    //     //           hv_C1 = hv_Column_COPY_INP_TMP.Clone();
    //     //       }
    //     //       else
    //     //       {
    //     //           //Transform image to window coordinates
    //     //           hv_FactorRow = (1.0 * hv_HeightWin) / ((hv_Row2Part - hv_Row1Part) + 1);
    //     //           hv_FactorColumn = (1.0 * hv_WidthWin) / ((hv_Column2Part - hv_Column1Part) + 1);
    //     //           hv_R1 = ((hv_Row_COPY_INP_TMP - hv_Row1Part) + 0.5) * hv_FactorRow;
    //     //           hv_C1 = ((hv_Column_COPY_INP_TMP - hv_Column1Part) + 0.5) * hv_FactorColumn;
    //     //       }
    //     //       //
    //     //       //Display text box depending on text size
    //     //       hv_UseShadow = 1;
    //     //       hv_ShadowColor = "gray";
    //     //       if ((int)(new HTuple(((hv_Box_COPY_INP_TMP.TupleSelect(0))).TupleEqual("true"))) != 0)
    //     //       {
    //     //           if (hv_Box_COPY_INP_TMP == null)
    //     //               hv_Box_COPY_INP_TMP = new HTuple();
    //     //           hv_Box_COPY_INP_TMP[0] = "#fce9d4";
    //     //           hv_ShadowColor = "#f28d26";
    //     //       }
    //     //       if ((int)(new HTuple((new HTuple(hv_Box_COPY_INP_TMP.TupleLength())).TupleGreater(
    //     //           1))) != 0)
    //     //       {
    //     //           if ((int)(new HTuple(((hv_Box_COPY_INP_TMP.TupleSelect(1))).TupleEqual("true"))) != 0)
    //     //           {
    //     //               //Use default ShadowColor set above
    //     //           }
    //     //           else if ((int)(new HTuple(((hv_Box_COPY_INP_TMP.TupleSelect(1))).TupleEqual(
    //     //               "false"))) != 0)
    //     //           {
    //     //               hv_UseShadow = 0;
    //     //           }
    //     //           else
    //     //           {
    //     //               hv_ShadowColor = hv_Box_COPY_INP_TMP[1];
    //     //               //Valid color?
    //     //               try
    //     //               {
    //     //                   HOperatorSet.SetColor(hv_WindowHandle, hv_Box_COPY_INP_TMP.TupleSelect(
    //     //                       1));
    //     //               }
    //     //               // catch (Exception) 
    //     //               catch (HalconException HDevExpDefaultException1)
    //     //               {
    //     //                   HDevExpDefaultException1.ToHTuple(out hv_Exception);
    //     //                   hv_Exception = "Wrong value of control parameter Box[1] (must be a 'true', 'false', or a valid color string)";
    //     //                   throw new HalconException(hv_Exception);
    //     //               }
    //     //           }
    //     //       }
    //     //       if ((int)(new HTuple(((hv_Box_COPY_INP_TMP.TupleSelect(0))).TupleNotEqual("false"))) != 0)
    //     //       {
    //     //           //Valid color?
    //     //           try
    //     //           {
    //     //               HOperatorSet.SetColor(hv_WindowHandle, hv_Box_COPY_INP_TMP.TupleSelect(0));
    //     //           }
    //     //           // catch (Exception) 
    //     //           catch (HalconException HDevExpDefaultException1)
    //     //           {
    //     //               HDevExpDefaultException1.ToHTuple(out hv_Exception);
    //     //               hv_Exception = "Wrong value of control parameter Box[0] (must be a 'true', 'false', or a valid color string)";
    //     //               throw new HalconException(hv_Exception);
    //     //           }
    //     //           //Calculate box extents
    //     //           hv_String_COPY_INP_TMP = (" " + hv_String_COPY_INP_TMP) + " ";
    //     //           hv_Width = new HTuple();
    //     //           for (hv_Index = 0; (int)hv_Index <= (int)((new HTuple(hv_String_COPY_INP_TMP.TupleLength()
    //     //               )) - 1); hv_Index = (int)hv_Index + 1)
    //     //           {
    //     //               HOperatorSet.GetStringExtents(hv_WindowHandle, hv_String_COPY_INP_TMP.TupleSelect(
    //     //                   hv_Index), out hv_Ascent, out hv_Descent, out hv_W, out hv_H);
    //     //               hv_Width = hv_Width.TupleConcat(hv_W);
    //     //           }
    //     //           hv_FrameHeight = hv_MaxHeight * (new HTuple(hv_String_COPY_INP_TMP.TupleLength()
    //     //               ));
    //     //           hv_FrameWidth = (((new HTuple(0)).TupleConcat(hv_Width))).TupleMax();
    //     //           hv_R2 = hv_R1 + hv_FrameHeight;
    //     //           hv_C2 = hv_C1 + hv_FrameWidth;
    //     //           //Display rectangles
    //     //           HOperatorSet.GetDraw(hv_WindowHandle, out hv_DrawMode);
    //     //           HOperatorSet.SetDraw(hv_WindowHandle, "fill");
    //     //           //Set shadow color
    //     //           HOperatorSet.SetColor(hv_WindowHandle, hv_ShadowColor);
    //     //           if ((int)(hv_UseShadow) != 0)
    //     //           {
    //     //               HOperatorSet.DispRectangle1(hv_WindowHandle, hv_R1 + 1, hv_C1 + 1, hv_R2 + 1, hv_C2 + 1);
    //     //           }
    //     //           //Set box color
    //     //           HOperatorSet.SetColor(hv_WindowHandle, hv_Box_COPY_INP_TMP.TupleSelect(0));
    //     //           HOperatorSet.DispRectangle1(hv_WindowHandle, hv_R1, hv_C1, hv_R2, hv_C2);
    //     //           HOperatorSet.SetDraw(hv_WindowHandle, hv_DrawMode);
    //     //       }
    //     //       //Write text.
    //     //       for (hv_Index = 0; (int)hv_Index <= (int)((new HTuple(hv_String_COPY_INP_TMP.TupleLength()
    //     //           )) - 1); hv_Index = (int)hv_Index + 1)
    //     //       {
    //     //           hv_CurrentColor = hv_Color_COPY_INP_TMP.TupleSelect(hv_Index % (new HTuple(hv_Color_COPY_INP_TMP.TupleLength()
    //     //               )));
    //     //           if ((int)((new HTuple(hv_CurrentColor.TupleNotEqual(""))).TupleAnd(new HTuple(hv_CurrentColor.TupleNotEqual(
    //     //               "auto")))) != 0)
    //     //           {
    //     //               HOperatorSet.SetColor(hv_WindowHandle, hv_CurrentColor);
    //     //           }
    //     //           else
    //     //           {
    //     //               HOperatorSet.SetRgb(hv_WindowHandle, hv_Red, hv_Green, hv_Blue);
    //     //           }
    //     //           hv_Row_COPY_INP_TMP = hv_R1 + (hv_MaxHeight * hv_Index);
    //     //           HOperatorSet.SetTposition(hv_WindowHandle, hv_Row_COPY_INP_TMP, hv_C1);
    //     //           HOperatorSet.WriteString(hv_WindowHandle, hv_String_COPY_INP_TMP.TupleSelect(
    //     //               hv_Index));
    //     //       }
    //     //       //Reset changed window settings
    //     //       HOperatorSet.SetRgb(hv_WindowHandle, hv_Red, hv_Green, hv_Blue);
    //     //       HOperatorSet.SetPart(hv_WindowHandle, hv_Row1Part, hv_Column1Part, hv_Row2Part,
    //     //           hv_Column2Part);

    //     //       return;
    //     //   }

    //     void pts_to_best_line(out HObject ho_Line, HTuple hv_Rows, HTuple hv_Cols,
    // HTuple hv_ActiveNum, out HTuple hv_Row1, out HTuple hv_Column1, out HTuple hv_Row2,
    // out HTuple hv_Column2, out HTuple hv_centerRow, out HTuple hv_centerCol)
    //     {
    //         // Local iconic variables 
    //         HObject ho_Contour = null;
    //         // Local control variables 
    //         HTuple hv_Length = null, hv_Nr = new HTuple();
    //         HTuple hv_Nc = new HTuple(), hv_Dist = new HTuple(), hv_Length1 = new HTuple();
    //         // Initialize local and output iconic variables 
    //         HOperatorSet.GenEmptyObj(out ho_Line);
    //         HOperatorSet.GenEmptyObj(out ho_Contour);
    //         hv_centerRow = new HTuple();
    //         hv_centerCol = new HTuple();
    //         try
    //         {

    //             hv_centerRow = 0;
    //             hv_centerCol = 0;
    //             //初始化
    //             hv_Row1 = 0;
    //             hv_Column1 = 0;
    //             hv_Row2 = 0;
    //             hv_Column2 = 0;
    //             //产生一个空的直线对象，用于保存拟合后的直线
    //             ho_Line.Dispose();
    //             HOperatorSet.GenEmptyObj(out ho_Line);
    //             //计算边缘数量
    //             HOperatorSet.TupleLength(hv_Cols, out hv_Length);
    //             //当边缘数量不小于有效点数时进行拟合
    //             if ((int)((new HTuple(hv_Length.TupleGreaterEqual(hv_ActiveNum))).TupleAnd(
    //                 new HTuple(hv_ActiveNum.TupleGreater(1)))) != 0)
    //             {
    //                 //halcon的拟合是基于xld的，需要把边缘连接成xld
    //                 ho_Contour.Dispose();
    //                 HOperatorSet.GenContourPolygonXld(out ho_Contour, hv_Rows, hv_Cols);
    //                 //拟合直线。使用的算法是'tukey'，其他算法请参考fit_line_contour_xld的描述部分。
    //                 HOperatorSet.FitLineContourXld(ho_Contour, "tukey", -1, 0, 5, 2, out hv_Row1,
    //                     out hv_Column1, out hv_Row2, out hv_Column2, out hv_Nr, out hv_Nc, out hv_Dist);
    //                 //*************输出中点*****************
    //                 hv_centerRow = (hv_Row1 + hv_Row2) / 2;
    //                 hv_centerCol = (hv_Column1 + hv_Column2) / 2;
    //                 //判断拟合结果是否有效：如果拟合成功，数组中元素的数量大于0
    //                 HOperatorSet.TupleLength(hv_Dist, out hv_Length1);
    //                 if ((int)(new HTuple(hv_Length1.TupleLess(1))) != 0)
    //                 {
    //                     ho_Contour.Dispose();
    //                     return;
    //                 }
    //                 //根据拟合结果，产生直线xld
    //                 ho_Line.Dispose();
    //                 HOperatorSet.GenContourPolygonXld(out ho_Line, hv_Row1.TupleConcat(hv_Row2),
    //                     hv_Column1.TupleConcat(hv_Column2));
    //             }
    //             ho_Contour.Dispose();
    //             return;
    //         }
    //         catch (HalconException HDevExpDefaultException)
    //         {
    //             ho_Contour.Dispose();

    //             throw HDevExpDefaultException;
    //         }
    //     }
    //     #endregion

    //     //    #region  拟合线
    //     //    /// <summary>
    //     //    /// 拟合线
    //     //    /// </summary>
    //     //    /// <param name="ILine_"></param>
    //     //    /// <param name="ho_Image"></param>
    //     //    /// <returns></returns>
    //     //    public bool Spoke(ILineShuJu ILine_, HObject ho_Image)
    //     //    {
    //     //        bool ok = false;

    //     //        HObject ho_Regions, ho_Line;
    //     //        HOperatorSet.GenEmptyObj(out ho_Regions);

    //     //        HTuple hv_ResultRow, hv_ResultColumn;

    //     //        HTuple[] Hv_Row_Draw = new HTuple[2], Hv_Column_Draw = new HTuple[2];

    //     //        if (ILine_.Ihv_HomMat2D != null)
    //     //        {
    //     //            HObject coutour;
    //     //            HOperatorSet.GenEmptyObj(out coutour);
    //     //            Hv_Row_Draw[0] = ILine_.Hv_Row1_Draw;
    //     //            Hv_Row_Draw[1] = ILine_.Hv_Row2_Draw;
    //     //            Hv_Column_Draw[0] = ILine_.Hv_Column1_Draw;
    //     //            Hv_Column_Draw[1] = ILine_.Hv_Column2_Draw;

    //     //            HTuple Hv_ROIRows, Hv_ROICols;

    //     //            HOperatorSet.GenContourPolygonXld(out coutour, Hv_Row_Draw, Hv_Column_Draw);
    //     //            HOperatorSet.AffineTransContourXld(coutour, out coutour, ILine_.Ihv_HomMat2D.Hv_HomMat2D);
    //     //            HOperatorSet.GetContourXld(coutour, out Hv_ROIRows, out Hv_ROICols);

    //     //            if (Hv_ROIRows.Length == 2)
    //     //            {
    //     //                Hv_Row_Draw[0] = Hv_ROIRows[0];
    //     //                Hv_Row_Draw[1] = Hv_ROIRows[1];

    //     //            }

    //     //            if (Hv_ROICols.Length == 2)
    //     //            {

    //     //                Hv_Column_Draw[0] = Hv_ROICols[0];
    //     //                Hv_Column_Draw[1] = Hv_ROICols[1];
    //     //            }

    //     //        }
    //     //        else
    //     //        {
    //     //            Hv_Row_Draw[0] = ILine_.Hv_Row1_Draw;
    //     //            Hv_Row_Draw[1] = ILine_.Hv_Row2_Draw;
    //     //            Hv_Column_Draw[0] = ILine_.Hv_Column1_Draw;
    //     //            Hv_Column_Draw[1] = ILine_.Hv_Column2_Draw;
    //     //        }

    //     //        rake(ho_Image, out ho_Regions, ILine_.Hv_Elements, ILine_.Hv_DetectHeight, ILine_.Hv_DetectWidth, ILine_.Hv_Sigma, ILine_.Hv_Threshold
    //     //            , ILine_.Hv_Transition, ILine_.Hv_Select, Hv_Row_Draw[0], Hv_Column_Draw[0], Hv_Row_Draw[1], Hv_Column_Draw[1], out hv_ResultRow, out hv_ResultColumn);

    //     //        ILine_.Ho_Regions_Rake = ho_Regions;
    //     //        ILine_.Hv_ResultRow = hv_ResultRow;
    //     //        ILine_.Hv_ResultColumn = hv_ResultColumn;

    //     //        HTuple Hv_Row11, Hv_Column11, Hv_Row21, Hv_Column21;

    //     //        pts_to_best_line(out ho_Line, ILine_.Hv_ResultRow, ILine_.Hv_ResultColumn, ILine_.Hv_ActiveNum, out Hv_Row11, out Hv_Column11, out Hv_Row21, out Hv_Column21);

    //     //        ILine_.Hv_Row11 = Hv_Row11;
    //     //        ILine_.Hv_Column11 = Hv_Column11;
    //     //        ILine_.Hv_Row21 = Hv_Row21;
    //     //        ILine_.Hv_Column21 = Hv_Column21;
    //     //        ILine_.Ho_Line = ho_Line;

    //     //        ok = true;
    //     //        return ok;
    //     //    }

    //     //    void rake(HObject ho_Image, out HObject ho_Regions, HTuple hv_Elements,
    //     //HTuple hv_DetectHeight, HTuple hv_DetectWidth, HTuple hv_Sigma, HTuple hv_Threshold,
    //     //HTuple hv_Transition, HTuple hv_Select, HTuple hv_Row1, HTuple hv_Column1, HTuple hv_Row2,
    //     //HTuple hv_Column2, out HTuple hv_ResultRow, out HTuple hv_ResultColumn)
    //     //    {
    //     //        // Stack for temporary objects 
    //     //        HObject[] OTemp = new HObject[20];
    //     //        // Local iconic variables 
    //     //        HObject ho_RegionLines, ho_Rectangle = null;
    //     //        HObject ho_Arrow1 = null;
    //     //        // Local control variables 
    //     //        HTuple hv_Width = null, hv_Height = null, hv_ATan = null;
    //     //        HTuple hv_i = null, hv_RowC = new HTuple(), hv_ColC = new HTuple();
    //     //        HTuple hv_Distance = new HTuple(), hv_RowL2 = new HTuple();
    //     //        HTuple hv_RowL1 = new HTuple(), hv_ColL2 = new HTuple();
    //     //        HTuple hv_ColL1 = new HTuple(), hv_MsrHandle_Measure = new HTuple();
    //     //        HTuple hv_RowEdge = new HTuple(), hv_ColEdge = new HTuple();
    //     //        HTuple hv_Amplitude = new HTuple(), hv_tRow = new HTuple();
    //     //        HTuple hv_tCol = new HTuple(), hv_t = new HTuple(), hv_Number = new HTuple();
    //     //        HTuple hv_j = new HTuple();
    //     //        HTuple hv_DetectWidth_COPY_INP_TMP = hv_DetectWidth.Clone();
    //     //        HTuple hv_Select_COPY_INP_TMP = hv_Select.Clone();
    //     //        HTuple hv_Transition_COPY_INP_TMP = hv_Transition.Clone();

    //     //        // Initialize local and output iconic variables 
    //     //        HOperatorSet.GenEmptyObj(out ho_Regions);
    //     //        HOperatorSet.GenEmptyObj(out ho_RegionLines);
    //     //        HOperatorSet.GenEmptyObj(out ho_Rectangle);
    //     //        HOperatorSet.GenEmptyObj(out ho_Arrow1);
    //     //        try
    //     //        {
    //     //            //获取图像尺寸
    //     //            HOperatorSet.GetImageSize(ho_Image, out hv_Width, out hv_Height);
    //     //            //产生一个空显示对象，用于显示
    //     //            ho_Regions.Dispose();
    //     //            HOperatorSet.GenEmptyObj(out ho_Regions);
    //     //            //初始化边缘坐标数组
    //     //            hv_ResultRow = new HTuple();
    //     //            hv_ResultColumn = new HTuple();
    //     //            //产生直线xld
    //     //            ho_RegionLines.Dispose();
    //     //            HOperatorSet.GenContourPolygonXld(out ho_RegionLines, hv_Row1.TupleConcat(hv_Row2),
    //     //                hv_Column1.TupleConcat(hv_Column2));
    //     //            //存储到显示对象
    //     //            {
    //     //                HObject ExpTmpOutVar_0;
    //     //                HOperatorSet.ConcatObj(ho_Regions, ho_RegionLines, out ExpTmpOutVar_0);
    //     //                ho_Regions.Dispose();
    //     //                ho_Regions = ExpTmpOutVar_0;
    //     //            }
    //     //            //计算直线与x轴的夹角，逆时针方向为正向。
    //     //            HOperatorSet.AngleLx(hv_Row1, hv_Column1, hv_Row2, hv_Column2, out hv_ATan);

    //     //            //边缘检测方向垂直于检测直线：直线方向正向旋转90°为边缘检测方向
    //     //            hv_ATan = hv_ATan + ((new HTuple(90)).TupleRad());

    //     //            //根据检测直线按顺序产生测量区域矩形，并存储到显示对象
    //     //            HTuple end_val18 = hv_Elements;
    //     //            HTuple step_val18 = 1;
    //     //            for (hv_i = 1; hv_i.Continue(end_val18, step_val18); hv_i = hv_i.TupleAdd(step_val18))
    //     //            {
    //     //                //RowC := Row1+(((Row2-Row1)*i)/(Elements+1))
    //     //                //ColC := Column1+(Column2-Column1)*i/(Elements+1)
    //     //                //if (RowC>Height-1 or RowC<0 or ColC>Width-1 or ColC<0)
    //     //                //continue
    //     //                //endif
    //     //                //如果只有一个测量矩形，作为卡尺工具，宽度为检测直线的长度
    //     //                if ((int)(new HTuple(hv_Elements.TupleEqual(1))) != 0)
    //     //                {
    //     //                    hv_RowC = (hv_Row1 + hv_Row2) * 0.5;
    //     //                    hv_ColC = (hv_Column1 + hv_Column2) * 0.5;
    //     //                    //判断是否超出图像,超出不检测边缘
    //     //                    if ((int)((new HTuple((new HTuple((new HTuple(hv_RowC.TupleGreater(hv_Height - 1))).TupleOr(
    //     //                        new HTuple(hv_RowC.TupleLess(0))))).TupleOr(new HTuple(hv_ColC.TupleGreater(
    //     //                        hv_Width - 1))))).TupleOr(new HTuple(hv_ColC.TupleLess(0)))) != 0)
    //     //                    {
    //     //                        continue;
    //     //                    }
    //     //                    HOperatorSet.DistancePp(hv_Row1, hv_Column1, hv_Row2, hv_Column2, out hv_Distance);
    //     //                    hv_DetectWidth_COPY_INP_TMP = hv_Distance.Clone();
    //     //                    ho_Rectangle.Dispose();
    //     //                    HOperatorSet.GenRectangle2ContourXld(out ho_Rectangle, hv_RowC, hv_ColC,
    //     //                        hv_ATan, hv_DetectHeight / 2, hv_Distance / 2);
    //     //                }
    //     //                else
    //     //                {
    //     //                    //如果有多个测量矩形，产生该测量矩形xld
    //     //                    hv_RowC = hv_Row1 + (((hv_Row2 - hv_Row1) * (hv_i - 1)) / (hv_Elements - 1));
    //     //                    hv_ColC = hv_Column1 + (((hv_Column2 - hv_Column1) * (hv_i - 1)) / (hv_Elements - 1));
    //     //                    //判断是否超出图像,超出不检测边缘
    //     //                    if ((int)((new HTuple((new HTuple((new HTuple(hv_RowC.TupleGreater(hv_Height - 1))).TupleOr(
    //     //                        new HTuple(hv_RowC.TupleLess(0))))).TupleOr(new HTuple(hv_ColC.TupleGreater(
    //     //                        hv_Width - 1))))).TupleOr(new HTuple(hv_ColC.TupleLess(0)))) != 0)
    //     //                    {
    //     //                        continue;
    //     //                    }
    //     //                    ho_Rectangle.Dispose();
    //     //                    HOperatorSet.GenRectangle2ContourXld(out ho_Rectangle, hv_RowC, hv_ColC,
    //     //                        hv_ATan, hv_DetectHeight / 2, hv_DetectWidth_COPY_INP_TMP / 2);
    //     //                }

    //     //                //把测量矩形xld存储到显示对象
    //     //                {
    //     //                    HObject ExpTmpOutVar_0;
    //     //                    HOperatorSet.ConcatObj(ho_Regions, ho_Rectangle, out ExpTmpOutVar_0);
    //     //                    ho_Regions.Dispose();
    //     //                    ho_Regions = ExpTmpOutVar_0;
    //     //                }
    //     //                if ((int)(new HTuple(hv_i.TupleEqual(1))) != 0)
    //     //                {
    //     //                    //在第一个测量矩形绘制一个箭头xld，用于只是边缘检测方向
    //     //                    hv_RowL2 = hv_RowC + ((hv_DetectHeight / 2) * (((-hv_ATan)).TupleSin()));
    //     //                    hv_RowL1 = hv_RowC - ((hv_DetectHeight / 2) * (((-hv_ATan)).TupleSin()));
    //     //                    hv_ColL2 = hv_ColC + ((hv_DetectHeight / 2) * (((-hv_ATan)).TupleCos()));
    //     //                    hv_ColL1 = hv_ColC - ((hv_DetectHeight / 2) * (((-hv_ATan)).TupleCos()));
    //     //                    ho_Arrow1.Dispose();
    //     //                    gen_arrow_contour_xld(out ho_Arrow1, hv_RowL1, hv_ColL1, hv_RowL2, hv_ColL2,
    //     //                        25, 25);
    //     //                    //把xld存储到显示对象
    //     //                    {
    //     //                        HObject ExpTmpOutVar_0;
    //     //                        HOperatorSet.ConcatObj(ho_Regions, ho_Arrow1, out ExpTmpOutVar_0);
    //     //                        ho_Regions.Dispose();
    //     //                        ho_Regions = ExpTmpOutVar_0;
    //     //                    }
    //     //                }
    //     //                //产生测量对象句柄
    //     //                HOperatorSet.GenMeasureRectangle2(hv_RowC, hv_ColC, hv_ATan, hv_DetectHeight / 2,
    //     //                    hv_DetectWidth_COPY_INP_TMP / 2, hv_Width, hv_Height, "nearest_neighbor",
    //     //                    out hv_MsrHandle_Measure);

    //     //                //设置极性
    //     //                if ((int)(new HTuple(hv_Transition_COPY_INP_TMP.TupleEqual("negative"))) != 0)
    //     //                {
    //     //                    hv_Transition_COPY_INP_TMP = "negative";
    //     //                }
    //     //                else
    //     //                {
    //     //                    if ((int)(new HTuple(hv_Transition_COPY_INP_TMP.TupleEqual("positive"))) != 0)
    //     //                    {

    //     //                        hv_Transition_COPY_INP_TMP = "positive";
    //     //                    }
    //     //                    else
    //     //                    {
    //     //                        hv_Transition_COPY_INP_TMP = "all";
    //     //                    }
    //     //                }
    //     //                //设置边缘位置。最强点是从所有边缘中选择幅度绝对值最大点，需要设置为'all'
    //     //                if ((int)(new HTuple(hv_Select_COPY_INP_TMP.TupleEqual("first"))) != 0)
    //     //                {
    //     //                    hv_Select_COPY_INP_TMP = "first";
    //     //                }
    //     //                else
    //     //                {
    //     //                    if ((int)(new HTuple(hv_Select_COPY_INP_TMP.TupleEqual("last"))) != 0)
    //     //                    {

    //     //                        hv_Select_COPY_INP_TMP = "last";
    //     //                    }
    //     //                    else
    //     //                    {
    //     //                        hv_Select_COPY_INP_TMP = "all";
    //     //                    }
    //     //                }
    //     //                //检测边缘
    //     //                HOperatorSet.MeasurePos(ho_Image, hv_MsrHandle_Measure, hv_Sigma, hv_Threshold,
    //     //                    hv_Transition_COPY_INP_TMP, hv_Select_COPY_INP_TMP, out hv_RowEdge, out hv_ColEdge,
    //     //                    out hv_Amplitude, out hv_Distance);
    //     //                //清除测量对象句柄
    //     //                HOperatorSet.CloseMeasure(hv_MsrHandle_Measure);

    //     //                //临时变量初始化
    //     //                //tRow，tCol保存找到指定边缘的坐标
    //     //                hv_tRow = 0;
    //     //                hv_tCol = 0;
    //     //                //t保存边缘的幅度绝对值
    //     //                hv_t = 0;
    //     //                //找到的边缘必须至少为1个
    //     //                HOperatorSet.TupleLength(hv_RowEdge, out hv_Number);
    //     //                if ((int)(new HTuple(hv_Number.TupleLess(1))) != 0)
    //     //                {
    //     //                    continue;
    //     //                }
    //     //                //有多个边缘时，选择幅度绝对值最大的边缘
    //     //                HTuple end_val100 = hv_Number - 1;
    //     //                HTuple step_val100 = 1;
    //     //                for (hv_j = 0; hv_j.Continue(end_val100, step_val100); hv_j = hv_j.TupleAdd(step_val100))
    //     //                {
    //     //                    if ((int)(new HTuple(((((hv_Amplitude.TupleSelect(hv_j))).TupleAbs())).TupleGreater(
    //     //                        hv_t))) != 0)
    //     //                    {

    //     //                        hv_tRow = hv_RowEdge.TupleSelect(hv_j);
    //     //                        hv_tCol = hv_ColEdge.TupleSelect(hv_j);
    //     //                        hv_t = ((hv_Amplitude.TupleSelect(hv_j))).TupleAbs();
    //     //                    }
    //     //                }
    //     //                //把找到的边缘保存在输出数组
    //     //                if ((int)(new HTuple(hv_t.TupleGreater(0))) != 0)
    //     //                {
    //     //                    hv_ResultRow = hv_ResultRow.TupleConcat(hv_tRow);
    //     //                    hv_ResultColumn = hv_ResultColumn.TupleConcat(hv_tCol);
    //     //                }
    //     //            }

    //     //            ho_RegionLines.Dispose();
    //     //            ho_Rectangle.Dispose();
    //     //            ho_Arrow1.Dispose();

    //     //            return;
    //     //        }
    //     //        catch (Exception ex)
    //     //        {
    //     //            ho_RegionLines.Dispose();
    //     //            ho_Rectangle.Dispose();
    //     //            ho_Arrow1.Dispose();
    //     //            hv_ResultColumn = 0;
    //     //            hv_ResultRow = 0;
    //     //           // throw HDevExpDefaultException;
    //     //            return;
    //     //        }
    //     //    }

    //     //    void gen_arrow_contour_xld(out HObject ho_Arrow, HTuple hv_Row1, HTuple hv_Column1,
    //     //HTuple hv_Row2, HTuple hv_Column2, HTuple hv_HeadLength, HTuple hv_HeadWidth)
    //     //    {
    //     //        // Stack for temporary objects 
    //     //        HObject[] OTemp = new HObject[20];

    //     //        // Local iconic variables 

    //     //        HObject ho_TempArrow = null;

    //     //        // Local control variables 

    //     //        HTuple hv_Length = null, hv_ZeroLengthIndices = null;
    //     //        HTuple hv_DR = null, hv_DC = null, hv_HalfHeadWidth = null;
    //     //        HTuple hv_RowP1 = null, hv_ColP1 = null, hv_RowP2 = null;
    //     //        HTuple hv_ColP2 = null, hv_Index = null;
    //     //        // Initialize local and output iconic variables 
    //     //        HOperatorSet.GenEmptyObj(out ho_Arrow);
    //     //        HOperatorSet.GenEmptyObj(out ho_TempArrow);
    //     //        try
    //     //        {
    //     //            //This procedure generates arrow shaped XLD contours,
    //     //            //pointing from (Row1, Column1) to (Row2, Column2).
    //     //            //If starting and end point are identical, a contour consisting
    //     //            //of a single point is returned.
    //     //            //
    //     //            //input parameteres:
    //     //            //Row1, Column1: Coordinates of the arrows' starting points
    //     //            //Row2, Column2: Coordinates of the arrows' end points
    //     //            //HeadLength, HeadWidth: Size of the arrow heads in pixels
    //     //            //
    //     //            //output parameter:
    //     //            //Arrow: The resulting XLD contour
    //     //            //
    //     //            //The input tuples Row1, Column1, Row2, and Column2 have to be of
    //     //            //the same length.
    //     //            //HeadLength and HeadWidth either have to be of the same length as
    //     //            //Row1, Column1, Row2, and Column2 or have to be a single element.
    //     //            //If one of the above restrictions is violated, an error will occur.
    //     //            //
    //     //            //
    //     //            //Init
    //     //            ho_Arrow.Dispose();
    //     //            HOperatorSet.GenEmptyObj(out ho_Arrow);
    //     //            //
    //     //            //Calculate the arrow length
    //     //            HOperatorSet.DistancePp(hv_Row1, hv_Column1, hv_Row2, hv_Column2, out hv_Length);
    //     //            //
    //     //            //Mark arrows with identical start and end point
    //     //            //(set Length to -1 to avoid division-by-zero exception)
    //     //            hv_ZeroLengthIndices = hv_Length.TupleFind(0);
    //     //            if ((int)(new HTuple(hv_ZeroLengthIndices.TupleNotEqual(-1))) != 0)
    //     //            {
    //     //                if (hv_Length == null)
    //     //                    hv_Length = new HTuple();
    //     //                hv_Length[hv_ZeroLengthIndices] = -1;
    //     //            }
    //     //            //
    //     //            //Calculate auxiliary variables.
    //     //            hv_DR = (1.0 * (hv_Row2 - hv_Row1)) / hv_Length;
    //     //            hv_DC = (1.0 * (hv_Column2 - hv_Column1)) / hv_Length;
    //     //            hv_HalfHeadWidth = hv_HeadWidth / 2.0;
    //     //            //
    //     //            //Calculate end points of the arrow head.
    //     //            hv_RowP1 = (hv_Row1 + ((hv_Length - hv_HeadLength) * hv_DR)) + (hv_HalfHeadWidth * hv_DC);
    //     //            hv_ColP1 = (hv_Column1 + ((hv_Length - hv_HeadLength) * hv_DC)) - (hv_HalfHeadWidth * hv_DR);
    //     //            hv_RowP2 = (hv_Row1 + ((hv_Length - hv_HeadLength) * hv_DR)) - (hv_HalfHeadWidth * hv_DC);
    //     //            hv_ColP2 = (hv_Column1 + ((hv_Length - hv_HeadLength) * hv_DC)) + (hv_HalfHeadWidth * hv_DR);
    //     //            //
    //     //            //Finally create output XLD contour for each input point pair
    //     //            for (hv_Index = 0; (int)hv_Index <= (int)((new HTuple(hv_Length.TupleLength())) - 1); hv_Index = (int)hv_Index + 1)
    //     //            {
    //     //                if ((int)(new HTuple(((hv_Length.TupleSelect(hv_Index))).TupleEqual(-1))) != 0)
    //     //                {
    //     //                    //Create_ single points for arrows with identical start and end point
    //     //                    ho_TempArrow.Dispose();
    //     //                    HOperatorSet.GenContourPolygonXld(out ho_TempArrow, hv_Row1.TupleSelect(
    //     //                        hv_Index), hv_Column1.TupleSelect(hv_Index));
    //     //                }
    //     //                else
    //     //                {
    //     //                    //Create arrow contour
    //     //                    ho_TempArrow.Dispose();
    //     //                    HOperatorSet.GenContourPolygonXld(out ho_TempArrow, ((((((((((hv_Row1.TupleSelect(
    //     //                        hv_Index))).TupleConcat(hv_Row2.TupleSelect(hv_Index)))).TupleConcat(
    //     //                        hv_RowP1.TupleSelect(hv_Index)))).TupleConcat(hv_Row2.TupleSelect(hv_Index)))).TupleConcat(
    //     //                        hv_RowP2.TupleSelect(hv_Index)))).TupleConcat(hv_Row2.TupleSelect(hv_Index)),
    //     //                        ((((((((((hv_Column1.TupleSelect(hv_Index))).TupleConcat(hv_Column2.TupleSelect(
    //     //                        hv_Index)))).TupleConcat(hv_ColP1.TupleSelect(hv_Index)))).TupleConcat(
    //     //                        hv_Column2.TupleSelect(hv_Index)))).TupleConcat(hv_ColP2.TupleSelect(
    //     //                        hv_Index)))).TupleConcat(hv_Column2.TupleSelect(hv_Index)));
    //     //                }
    //     //                {
    //     //                    HObject ExpTmpOutVar_0;
    //     //                    HOperatorSet.ConcatObj(ho_Arrow, ho_TempArrow, out ExpTmpOutVar_0);
    //     //                    ho_Arrow.Dispose();
    //     //                    ho_Arrow = ExpTmpOutVar_0;
    //     //                }
    //     //            }
    //     //            ho_TempArrow.Dispose();

    //     //            return;
    //     //        }
    //     //        catch (HalconException HDevExpDefaultException)
    //     //        {
    //     //            ho_TempArrow.Dispose();

    //     //            throw HDevExpDefaultException;
    //     //        }
    //     //    }

    //     //    /// <summary>
    //     //    /// 拟合线
    //     //    /// </summary>
    //     //    /// <param name="ho_Line"></param>
    //     //    /// <param name="hv_Rows"></param>
    //     //    /// <param name="hv_Cols"></param>
    //     //    /// <param name="hv_ActiveNum"></param>
    //     //    /// <param name="hv_Row1"></param>
    //     //    /// <param name="hv_Column1"></param>
    //     //    /// <param name="hv_Row2"></param>
    //     //    /// <param name="hv_Column2"></param>
    //     //    void pts_to_best_line(out HObject ho_Line, HTuple hv_Rows, HTuple hv_Cols,
    //     //  HTuple hv_ActiveNum, out HTuple hv_Row1, out HTuple hv_Column1, out HTuple hv_Row2,
    //     //  out HTuple hv_Column2)
    //     //    {
    //     //        // Local iconic variables 
    //     //        HObject ho_Contour = null;
    //     //        // Local control variables 
    //     //        HTuple hv_Length = null, hv_Nr = new HTuple();
    //     //        HTuple hv_Nc = new HTuple(), hv_Dist = new HTuple(), hv_Length1 = new HTuple();
    //     //        // Initialize local and output iconic variables 
    //     //        HOperatorSet.GenEmptyObj(out ho_Line);
    //     //        HOperatorSet.GenEmptyObj(out ho_Contour);
    //     //        try
    //     //        {
    //     //            //初始化
    //     //            hv_Row1 = 0;
    //     //            hv_Column1 = 0;
    //     //            hv_Row2 = 0;
    //     //            hv_Column2 = 0;
    //     //            //产生一个空的直线对象，用于保存拟合后的直线
    //     //            ho_Line.Dispose();
    //     //            HOperatorSet.GenEmptyObj(out ho_Line);
    //     //            //计算边缘数量
    //     //            HOperatorSet.TupleLength(hv_Cols, out hv_Length);
    //     //            //当边缘数量不小于有效点数时进行拟合
    //     //            if ((int)((new HTuple(hv_Length.TupleGreaterEqual(hv_ActiveNum))).TupleAnd(
    //     //                new HTuple(hv_ActiveNum.TupleGreater(1)))) != 0)
    //     //            {
    //     //                //halcon的拟合是基于xld的，需要把边缘连接成xld
    //     //                ho_Contour.Dispose();
    //     //                HOperatorSet.GenContourPolygonXld(out ho_Contour, hv_Rows, hv_Cols);
    //     //                //拟合直线。使用的算法是'tukey'，其他算法请参考fit_line_contour_xld的描述部分。
    //     //                HOperatorSet.FitLineContourXld(ho_Contour, "tukey", -1, 0, 5, 2, out hv_Row1,
    //     //                    out hv_Column1, out hv_Row2, out hv_Column2, out hv_Nr, out hv_Nc, out hv_Dist);
    //     //                //判断拟合结果是否有效：如果拟合成功，数组中元素的数量大于0
    //     //                HOperatorSet.TupleLength(hv_Dist, out hv_Length1);
    //     //                if ((int)(new HTuple(hv_Length1.TupleLess(1))) != 0)
    //     //                {
    //     //                    ho_Contour.Dispose();

    //     //                    return;
    //     //                }
    //     //                //根据拟合结果，产生直线xld
    //     //                ho_Line.Dispose();
    //     //                HOperatorSet.GenContourPolygonXld(out ho_Line, hv_Row1.TupleConcat(hv_Row2),
    //     //                    hv_Column1.TupleConcat(hv_Column2));
    //     //            }

    //     //            ho_Contour.Dispose();

    //     //            return;
    //     //        }
    //     //        catch (HalconException HDevExpDefaultException)
    //     //        {
    //     //            ho_Contour.Dispose();
    //     //            throw HDevExpDefaultException;
    //     //        }
    //     //    }
    //     //    #endregion

    //     #region  显示
    //     /// <summary>
    //     /// 显示
    //     /// </summary>
    //     /// <param name="ILine_"></param>
    //     /// <param name="hwin"></param>
    //     /// <returns></returns>
    //     public bool Line_Show(ILineShuJu ILine_, HWindow hwin)
    //     {
    //         bool ok = false;

    //         //if (ILine_.Ho_Line.IsInitialized())
    //         //{
    //         //    hwin.DispObj(ILine_.Ho_Line);
    //         //}

    //         /***********显示数据**************/
    //         hwin.DispObj(ILine_.Ho_Regions_Draw);
    //         hwin.DispObj(ILine_.Ho_Regions_Rake);
    //         hwin.DispObj(ILine_.Ho_Cross);
    //         hwin.DispObj(ILine_.Ho_Line);

    //         ok = true;
    //         return ok;

    //     }
    //     #endregion

    //     #region  拟合线，显示，保存
    //     /// <summary>
    //     ///  拟合线，显示，保存
    //     /// </summary>
    //     /// <param name="ho_Image"></param>
    //     /// <param name="ILine_"></param>
    //     /// <param name="hwin"></param>
    //     /// <param name="Key"></param>
    //     /// <param name="_dictionary_resulte"></param>
    //     /// <returns></returns>
    //     public bool Spoke_Show_Out(HObject ho_Image, ILineShuJu ILine_, HWindow hwin, string Key, ref Dictionary<string, Object> _dictionary_resulte)
    //     {
    //         bool ok = false;
    //         /***************************************处理************************************************************/
    //         HObject ho_Regions, ho_Line;
    //         HOperatorSet.GenEmptyObj(out ho_Regions);
    //         HTuple oneRow_, oneCol_, twoRow_, twoCol_;

    //         if (ILine_.IrectShuJuPianYi != null)
    //         {
    //             HTuple hv_modMat2D_, crossRow_ = new HTuple(), crossCol_ = new HTuple(), Nr, Nc, Dist;
    //             HObject contour_;
    //             HOperatorSet.GenEmptyObj(out contour_);
    //             HOperatorSet.VectorAngleToRigid(ILine_.GenSuiDian_Y_Row, ILine_.GeuSuiDian_X_Col, ILine_.GenSuiDian_A, ILine_.IrectShuJuPianYi.Row, ILine_.IrectShuJuPianYi.Column, ILine_.IrectShuJuPianYi.Angle, out hv_modMat2D_);
    //             crossRow_[0] = ILine_.IOutSide.Row1.D;
    //             crossRow_[1] = ILine_.IOutSide.Row2.D;
    //             crossCol_[0] = ILine_.IOutSide.Cols1.D;
    //             crossCol_[1] = ILine_.IOutSide.Cols2.D;
    //             HOperatorSet.GenContourPolygonXld(out contour_, crossRow_, crossCol_);
    //             HOperatorSet.FitLineContourXld(contour_, "tukey", -1, 0, 5, 2, out oneRow_, out oneCol_, out twoRow_, out twoCol_, out Nr, out Nc, out Dist);
    //             contour_.Dispose();
    //         }
    //         else
    //         {
    //             oneCol_ = ILine_.IOutSide.Cols1;
    //             oneRow_ = ILine_.IOutSide.Row1;
    //             twoCol_ = ILine_.IOutSide.Cols2;
    //             twoRow_ = ILine_.IOutSide.Row2;
    //         }

    //         #region  无用代码
    //         //HTuple[] Hv_Row_Draw = new HTuple[2], Hv_Column_Draw = new HTuple[2];           
    //         //if (ILine_.Ihv_HomMat2D != null)
    //         //{
    //         //    HObject coutour;
    //         //    HOperatorSet.GenEmptyObj(out coutour);
    //         //    Hv_Row_Draw[0] = ILine_.Hv_Row1_Draw;
    //         //    Hv_Row_Draw[1] = ILine_.Hv_Row2_Draw;
    //         //    Hv_Column_Draw[0] = ILine_.Hv_Column1_Draw;
    //         //    Hv_Column_Draw[1] = ILine_.Hv_Column2_Draw;

    //         //    HTuple Hv_ROIRows, Hv_ROICols;

    //         //    HOperatorSet.GenContourPolygonXld(out coutour, Hv_Row_Draw, Hv_Column_Draw);
    //         //    HOperatorSet.AffineTransContourXld(coutour, out coutour, ILine_.Ihv_HomMat2D.Hv_HomMat2D);
    //         //    HOperatorSet.GetContourXld(coutour, out Hv_ROIRows, out Hv_ROICols);

    //         //    if (Hv_ROIRows.Length == 2)
    //         //    {
    //         //        Hv_Row_Draw[0] = Hv_ROIRows[0];
    //         //        Hv_Row_Draw[1] = Hv_ROIRows[1];

    //         //    }
    //         //    if (Hv_ROICols.Length == 2)
    //         //    {

    //         //        Hv_Column_Draw[0] = Hv_ROICols[0];
    //         //        Hv_Column_Draw[1] = Hv_ROICols[1];
    //         //    }
    //         //}
    //         //else
    //         //{
    //         //    Hv_Row_Draw[0] = ILine_.Hv_Row1_Draw;
    //         //    Hv_Row_Draw[1] = ILine_.Hv_Row2_Draw;
    //         //    Hv_Column_Draw[0] = ILine_.Hv_Column1_Draw;
    //         //    Hv_Column_Draw[1] = ILine_.Hv_Column2_Draw;
    //         //}
    //         #endregion
    //         HTuple resultRow_, resultCol_, beginRow_, beginCol_, endRow_, endCol_, centerRow_, centerCol_;

    //         rake(ho_Image, out ho_Regions, ILine_.Hv_Elements, ILine_.Hv_DetectHeight, ILine_.Hv_DetectWidth, ILine_.Hv_Sigma, ILine_.Hv_Threshold
    //             , ILine_.Hv_Transition, ILine_.Hv_Select, oneRow_, oneCol_, twoRow_, twoCol_, out resultRow_, out resultCol_);

    //         ILine_.Ho_Regions_Draw.Dispose();
    //         ILine_.Ho_Regions_Draw = ho_Regions;

    //         ILine_.Hv_ResultRow = resultRow_;
    //         ILine_.Hv_ResultColumn = resultCol_;

    //         HObject ho_Regions1;
    //         HOperatorSet.GenEmptyObj(out ho_Regions1);
    //         ho_Regions1.Dispose();
    //         HOperatorSet.GenCrossContourXld(out ho_Regions1, resultRow_, resultCol_, 6, 0.785398);

    //         ILine_.Ho_Regions_Rake.Dispose();
    //         ILine_.Ho_Regions_Rake = ho_Regions1;

    //         pts_to_best_line(out ho_Line, ILine_.Hv_ResultRow, ILine_.Hv_ResultColumn, ILine_.Hv_ActiveNum, out beginRow_, out beginCol_, out endRow_, out endCol_, out centerRow_, out centerCol_);

    //         ILine_.Hv_Column11 = beginCol_;
    //         ILine_.Hv_Row11 = beginRow_;

    //         ILine_.Hv_Row21 = endRow_;
    //         ILine_.Hv_Column21 = endCol_;

    //         ILine_.Row = centerRow_;
    //         ILine_.Column = centerCol_;
    //         ILine_.Angle = 0;

    //         ILine_.Ho_Line.Dispose();
    //         ILine_.Ho_Line = ho_Line;

    //         HTuple row_ = new HTuple(), col_ = new HTuple();

    //         row_[0] = beginRow_;
    //         row_[1] = endRow_;
    //         row_[2] = centerRow_;

    //         col_[0] = beginCol_;
    //         col_[1] = endCol_;
    //         col_[2] = centerCol_;

    //         HObject ho_cross;
    //         HOperatorSet.GenEmptyObj(out ho_cross);
    //         HOperatorSet.GenCrossContourXld(out ho_cross, row_, col_, 60, 0.785398);

    //         ILine_.Ho_Cross.Dispose();
    //         ILine_.Ho_Cross = ho_cross;

    //         /***************数据分析**********************/
    //         Key = "Line_" + Key;
    //         Line_Result lineResult_ = new Line_Result();
    //         lineResult_._tolatName = Key;

    //         Result_Analyisis(ILine_, ref lineResult_);

    //         /*******保存数据**************/
    //         _dictionary_resulte.Add(Key, lineResult_);

    //         /*********显示**********/
    //         if (lineResult_._tolatResult)//判断对错
    //         {
    //             hwin.DispObj(ILine_.Ho_Regions_Draw);
    //             ok = true;
    //         }
    //         else
    //         {
    //             hwin.SetColor("red");
    //             hwin.DispObj(ILine_.Ho_Regions_Draw);
    //             hwin.SetColor("green");
    //         }
    //         hwin.DispObj(ILine_.Ho_Regions_Rake);
    //         hwin.DispObj(ILine_.Ho_Cross);
    //         hwin.DispObj(ILine_.Ho_Line);

    //         return ok;
    //     }
    //     #endregion


    //     #region  数据分析
    //     /// <summary>
    //     /// 数据分析
    //     /// </summary>
    //     /// <param name="ILine_"></param>
    //     /// <param name="lineResult_"></param>
    //     /// <returns></returns>
    //     bool Result_Analyisis(ILineShuJu ILine_, ref Line_Result lineResult_)
    //     {
    //         bool ok = false;

    //         if ((ILine_.Hv_Column11.D == 0) || (ILine_.Hv_Row11.D == 0) || (ILine_.Hv_Column11.D == 0) || (ILine_.Hv_Column21.D == 0))
    //         {
    //             lineResult_._tolatResult = false;
    //         }
    //         else
    //         {
    //             lineResult_._tolatResult = true;
    //         }

    //         lineResult_.HV_CenCol = ILine_.Column;
    //         lineResult_.Hv_CenRow = ILine_.Row;
    //         lineResult_.Hv_Column11 = ILine_.Hv_Column11;
    //         lineResult_.Hv_Row11 = ILine_.Hv_Row11;
    //         lineResult_.Hv_Column11 = ILine_.Hv_Column11;
    //         lineResult_.Hv_Row21 = ILine_.Hv_Row21;
    //         lineResult_.Hv_Column21 = ILine_.Hv_Column21;

    //         if (ILine_._ICalibration != null)//判断有无标定
    //         {
    //             this.Cal(ILine_._ICalibration.HomMat2D, ref lineResult_.Hv_CenRow, ref lineResult_.HV_CenCol);
    //             this.Cal(ILine_._ICalibration.HomMat2D, ref lineResult_.Hv_Row11, ref lineResult_.Hv_Column11);
    //             this.Cal(ILine_._ICalibration.HomMat2D, ref lineResult_.Hv_Row21, ref lineResult_.Hv_Column21);
    //             ILine_.Column = lineResult_.HV_CenCol;
    //             ILine_.Row = lineResult_.Hv_CenRow;

    //             ILine_.Hv_Column11 = lineResult_.Hv_Column11;
    //             ILine_.Hv_Row11 = lineResult_.Hv_Row11;

    //             ILine_.Hv_Column21 = lineResult_.Hv_Column21;
    //             ILine_.Hv_Row21 = lineResult_.Hv_Row21;
    //         }

    //         ok = true;
    //         return ok;
    //     }
    //     #endregion



    // }
    // #endregion

    #region  结果
    /// <summary>
    /// 结果
    /// </summary>
    public class Line_Result : MultTree.ClassResultFather
    {
        /// <summary>
        /// 
        /// </summary>
        public HTuple Hv_Row11 = new HTuple();
        /// <summary>
        /// 
        /// </summary>
        public HTuple Hv_Column11 = new HTuple();
        /// <summary>
        /// 
        /// </summary>
        public HTuple Hv_Row21 = new HTuple();
        /// <summary>
        /// 
        /// </summary>
        public HTuple Hv_Column21 = new HTuple();
        /// <summary>
        /// 中心点x
        /// </summary>
        public HTuple Hv_CenRow = new HTuple();
        /// <summary>
        /// 中心点y
        /// </summary>
        public HTuple HV_CenCol = new HTuple();
        /// <summary>
        /// 直线的角度
        /// </summary>
        public HTuple HV_Angle = new HTuple();


        /// <summary>
        /// 输出数据
        /// </summary>
        /// <param name="str_array"></param>
        /// <returns></returns>
        public override bool showResult(out string[] str_array)
        {
            bool ok = false;
            str_array = new string[9];
            if (this._tolatResult)
            {
                str_array[0] = this._tolatName;
                str_array[1] = this._tolatResult.ToString();
                str_array[2] = "端点1x:" + this.Hv_Column11.D.ToString();
                str_array[3] = "端点1y:" + this.Hv_Row11.D.ToString();
                str_array[4] = "端点2x:" + this.Hv_Column21.D.ToString();
                str_array[5] = "端点2y:" + this.Hv_Row21.D.ToString();
                str_array[6] = "中点x:" + this.HV_CenCol.D.ToString();
                str_array[7] = "中点y:" + this.Hv_CenRow.D.ToString();
                str_array[8] = "角度a:" + this.HV_Angle.D.ToString();
            }
            else
            {
                str_array[0] = this._tolatName;
                str_array[1] = this._tolatResult.ToString();
                str_array[2] = "端点1x:0";
                str_array[3] = "端点1y:0";
                str_array[4] = "端点2x:0";
                str_array[5] = "端点2y:0";
                str_array[6] = "中点x:0";
                str_array[7] = "中点y:0";
                str_array[8] = "角度a:0";
            }
            ok = true;
            return ok;
        }
    }
    #endregion
}
