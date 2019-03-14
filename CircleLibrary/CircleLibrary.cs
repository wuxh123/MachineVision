using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using HalconDotNet;
using RectLibrary;
using CalibrationLibrary;
using HalControl;
using HalControl.ROI.Cricle;





namespace CircleLibrary
{
    #region 拟合圆数据
    /// <summary>
    /// 拟合圆的数据
    /// </summary>
    [Serializable]
    public class CircleShuJu : MultTree.ToolDateFather, ICircleShuJu /*, IRectShuJuPianYi*/
    {
        #region  图片数据
        /// <summary>
        /// 差找到点
        /// </summary>
        [NonSerialized]
        HObject ho_Regions = null;

        /// <summary>
        ///输出边缘点检测区域及方向 
        /// </summary>
        [NonSerialized]
        HObject ho_Regions_0 = null;

        /// <summary>
        /// 拟合出来的圆
        /// </summary>
        [NonSerialized]
        HObject ho_Circle = null;
        #endregion

        //#region  防射变换
        /////// <summary>
        /////// 防射变换
        /////// </summary>
        ////HTuple hv_HomMat2D = null;

        ///// <summary>
        ///// 需要防射变化
        ///// </summary>
        //IRectShuJuHv_HomMat2D _ihv_HomMat2D = null;
        //#endregion

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

        #region   测量的数据
        /// <summary>
        /// spoke工具ROI的y数组   检测区域起点的y值
        /// </summary>
        [NonSerialized]
        HTuple hv_ROIRows = null;

        /// <summary>
        /// spoke工具ROI的x数组    检测区域起点的x值
        /// </summary>
        [NonSerialized]
        HTuple hv_ROICols = null;

        /// <summary>
        /// 圆弧起点角度(单位：弧度)
        /// </summary>
        [NonSerialized]
        HTuple hv_StartPhi = null;

        /// <summary>
        /// 圆弧终点角度(单位：弧度)
        /// </summary>
        [NonSerialized]
        HTuple hv_EndPhi = null;

        /// <summary>
        /// 'inner'表示检测方向由边缘点指向圆心；'outer'表示检测方向由圆心指向边缘点
        /// </summary>
        [NonSerialized]
        HTuple hv_Direct = null;

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
        /// 检测到的边缘点的y坐标数组    拟合圆的边缘y数组
        /// </summary>
        [NonSerialized]
        HTuple hv_ResultRow = null;

        /// <summary>
        /// 检测到的边缘点的x坐标数组   拟合圆的边缘x数组
        /// </summary>
        [NonSerialized]
        HTuple hv_ResultColumn = null;

        /// <summary>
        /// 拟合圆弧类型：'arc'圆弧；'circle'圆
        /// </summary>
        [NonSerialized]
        HTuple hv_ArcType = null;

        /// <summary>
        /// 最小有效点数
        /// </summary>
        [NonSerialized]
        HTuple hv_ActiveNum = null;
        #endregion

        #region  输出的数据
        /// <summary>
        /// 拟合的圆中心y
        /// </summary>
        [NonSerialized]
        HTuple hv_RowCenter;

        /// <summary>
        /// 拟合的圆中心x
        /// </summary>
        [NonSerialized]
        HTuple hv_ColCenter;

        /// <summary>
        /// 拟合的圆半径
        /// </summary>
        [NonSerialized]
        HTuple hv_Radius;

        /// <summary>
        /// 轮廓点方向
        /// </summary>
        [NonSerialized]
        HTuple hv_PointOrder;

        /// <summary>
        /// 
        /// </summary>
        [NonSerialized]
        HTuple hv_ArcAngle;
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

        //#region  标定数据
        ///// <summary>
        ///// 标定数据
        ///// </summary>
        //IHomMat2D _iCalibration = null;
        //#endregion

        #region  外部圆接口
        /// <summary>
        /// 对外接口
        /// </summary>
        IOutsideCricleROI iOutSide;
        #endregion

        #region   结果
        /// <summary>
        /// 结果
        /// </summary>
        [NonSerialized]
        Cricle_Result _result = new Cricle_Result();
        #endregion
        
        #region  构造函数
        public CircleShuJu()
        {
            HOperatorSet.GenEmptyObj(out ho_Regions);
            ho_Regions.Dispose();

            HOperatorSet.GenEmptyObj(out ho_Regions_0);
            ho_Regions_0.Dispose();

            HOperatorSet.GenEmptyObj(out ho_Circle);
            ho_Circle.Dispose();

        }
        #endregion

        #region 属性

        #region  图片数据
        /// <summary>
        /// 差找到的点
        /// </summary>
        public HObject Ho_Regions
        {
            get
            {
                if (ho_Regions == null)
                {
                    HOperatorSet.GenEmptyObj(out ho_Regions);
                    ho_Regions.Dispose();
                }
                return ho_Regions;
            }
            set { ho_Regions = value; }
        }

        /// <summary>
        ///输出边缘点检测区域及方向 
        /// </summary>
        public HObject Ho_Regions_0
        {
            get
            {
                if (ho_Regions_0 == null)
                {
                    HOperatorSet.GenEmptyObj(out ho_Regions_0);
                    ho_Regions_0.Dispose();
                }
                return ho_Regions_0;
            }
            set { ho_Regions_0 = value; }
        }

        /// <summary>
        /// 拟合出来的圆
        /// </summary>
        public HObject Ho_Circle
        {
            get
            {
                if (ho_Circle == null)
                {
                    HOperatorSet.GenEmptyObj(out ho_Circle);
                    ho_Circle.Dispose();
                }
                return ho_Circle;
            }

            set { ho_Circle = value; }
        }
        #endregion

        #region  对外接口
        /// <summary>
        /// 对外接口
        /// </summary>
        public IOutsideCricleROI IOutSide
        {
            get
            {
                if (iOutSide == null)
                {
                    iOutSide = new OutsideCricleROI();
                    iOutSide.Center_column_x = 100.0;
                    iOutSide.Center_row_y = 100.0;
                    iOutSide.Radius = 50.0;
                }
                return iOutSide;
            }
            set { iOutSide = value; }
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

        /// <summary>
        /// 圆弧起点角度(单位：弧度)
        /// </summary>
        public HTuple Hv_StartPhi
        {
            get
            {
                if (hv_StartPhi == null)
                {
                    hv_StartPhi = 0;
                }
                return hv_StartPhi;
            }
            set { hv_StartPhi = value; }
        }

        /// <summary>
        /// 圆弧终点角度(单位：弧度)
        /// </summary>
        public HTuple Hv_EndPh
        {
            get
            {
                if (hv_EndPhi == null)
                {
                    hv_EndPhi = 6;
                }
                return hv_EndPhi;
            }
            set { hv_EndPhi = value; }
        }

        #endregion

        #region  测量数据
        /// <summary>
        /// spoke工具ROI的y数组   检测区域起点的y值
        /// </summary>
        public HTuple Hv_ROIRows
        {
            get { return hv_ROIRows; }
            set { hv_ROIRows = value; }
        }

        /// <summary>
        /// spoke工具ROI的x数组    检测区域起点的x值
        /// </summary>
        public HTuple Hv_ROICols
        {
            get
            {
                return hv_ROICols;
            }

            set { hv_ROICols = value; }
        }

        /// <summary>
        /// 'inner'表示检测方向由边缘点指向圆心；'outer'表示检测方向由圆心指向边缘点
        /// </summary>
        public HTuple Hv_Direct
        {
            get
            {
                if (hv_Direct == null)
                {
                    hv_Direct = "inner";
                }
                return hv_Direct;
            }

            set { hv_Direct = value; }
        }

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
            set { hv_Select = value; }

            get
            {
                if (hv_Select == null)
                {
                    hv_Select = "max";
                }
                return hv_Select;
            }
        }

        /// <summary>
        /// 检测到的边缘点的y坐标数组    拟合圆的边缘y数组
        /// </summary>
        public HTuple Hv_ResultRow
        {
            set { hv_ResultRow = value; }
            get { return hv_ResultRow; }
        }

        /// <summary>
        /// 检测到的边缘点的x坐标数组   拟合圆的边缘x数组
        /// </summary>
        public HTuple Hv_ResultColumn
        {
            get { return hv_ResultColumn; }
            set { hv_ResultColumn = value; }
        }

        /// <summary>
        /// 拟合圆弧类型：'arc'圆弧；'circle'圆
        /// </summary>
        public HTuple Hv_ArcType
        {
            get
            {
                if (hv_ArcType == null)
                {
                    hv_ArcType = "circle";
                }
                return hv_ArcType;
            }

            set { hv_ArcType = value; }
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

        #region  输出的数据
        /// <summary>
        /// 拟合的圆中心y
        /// </summary>
        public HTuple Row
        {
            get { return hv_RowCenter; }
            set { hv_RowCenter = value; }
        }

        /// <summary>
        /// 拟合的圆中心x
        /// </summary>
        public HTuple Column
        {
            get { return hv_ColCenter; }
            set { hv_ColCenter = value; }
        }

        /// <summary>
        /// 拟合的圆半径
        /// </summary>
        public HTuple Hv_Radius
        {
            get { return hv_Radius; }
            set { hv_Radius = value; }
        }

        /// <summary>
        /// 轮廓点方向
        /// </summary>
        public HTuple Hv_PointOrder
        {
            get { return hv_PointOrder; }
            set { hv_PointOrder = value; }
        }

        /// <summary>
        /// 圆的角度
        /// </summary>
        public HTuple Angle
        {
            get { return hv_ArcAngle; }
            set { hv_ArcAngle = value; }
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

        ///// <summary>
        ///// 需要防射变化
        ///// </summary>
        //public IRectShuJuHv_HomMat2D Ihv_HomMat2D
        //{
        //    get { return _ihv_HomMat2D; }
        //    set { _ihv_HomMat2D = value; }
        //}
        //#endregion

        //#region 标定数据
        ///// <summary>
        ///// 标定数据
        ///// </summary>
        //public IHomMat2D _ICalibration
        //{
        //    get { return _iCalibration; }
        //    set { _iCalibration = value; }
        //}
        //#endregion

        #endregion

        #region   序列化保存数据

        #region  图片数据
        /// <summary>
        /// 画圆输出的region
        /// </summary>
        Object ho_Regions_;
        #endregion

        #region    卡尺的数据
        /// <summary>
        /// 卡尺的个数
        /// </summary>

        Object hv_Elements_1;

        /// <summary>
        /// 卡尺的高
        /// </summary>
        Object hv_DetectHeight_1;

        /// <summary>
        /// 卡尺的宽
        /// </summary>
        Object hv_DetectWidth_1;

        ///// <summary>
        ///// spoke工具ROI的y数组   检测区域起点的y值
        ///// </summary>

        //Object hv_ROIRows_;

        ///// <summary>
        ///// spoke工具ROI的x数组    检测区域起点的x值
        ///// </summary>

        //Object hv_ROICols_;

        /// <summary>
        /// 'inner'表示检测方向由边缘点指向圆心；'outer'表示检测方向由圆心指向边缘点
        /// </summary>
        Object hv_Direct_1;

        /// <summary>
        /// 高斯滤波因子
        /// </summary>
        Object hv_Sigma_1;

        /// <summary>
        /// 边缘幅度阈值
        /// </summary>
        Object hv_Threshold_1;

        /// <summary>
        /// 极性：  positive表示由黑到白   negative表示由白到黑   all表示以上两种方向
        /// </summary>
        Object hv_Transition_1;

        /// <summary>
        /// >first表示选择第一点    last表示选择最后一点   max表示选择边缘强度最强点
        /// </summary>
        Object hv_Select_1;

        #region  无用代码
        ///// <summary>
        ///// 检测到的边缘点的y坐标数组    拟合圆的边缘y数组
        ///// </summary>

        //Object hv_ResultRow_;

        ///// <summary>
        ///// 检测到的边缘点的x坐标数组   拟合圆的边缘x数组
        ///// </summary>

        //Object hv_ResultColumn_;
        #endregion

        /// <summary>
        /// 拟合圆弧类型：'arc'圆弧；'circle'圆
        /// </summary>
        Object hv_ArcType_1;

        /// <summary>
        /// 最小有效点数
        /// </summary>
        Object hv_ActiveNum_1;

        /// <summary>
        /// 开始角度
        /// </summary>
        Object startAngle_1;

        /// <summary>
        /// 结束角度
        /// </summary>
        Object endAngle_1;

        #endregion

        #region   外部接口

        Object mid_row_y_1;

        Object mid_col_x_1;

        Object radios_1;

        #endregion

        #endregion

        #region   保存数据
        /// <summary>
        /// 保存数据
        /// </summary>
        public override void save()
        {
            base.save();

            #region   外部接口

            mid_row_y_1 = this.IOutSide.Center_row_y;

            mid_col_x_1 = this.IOutSide.Center_column_x;

            radios_1 = this.IOutSide.Radius;

            #endregion

            //#region  图片数据
            //ho_Regions_ = ho_Regions;
            //#endregion

            #region    卡尺的数据

            hv_Elements_1 = hv_Elements;

            hv_DetectHeight_1 = hv_DetectHeight;

            hv_DetectWidth_1 = hv_DetectWidth;

            //hv_ROIRows_ = hv_ROIRows;

            //hv_ROICols_ = hv_ROICols;

            hv_Direct_1 = hv_Direct;

            hv_Sigma_1 = hv_Sigma;

            hv_Threshold_1 = hv_Threshold;

            hv_Transition_1 = hv_Transition;

            hv_Select_1 = hv_Select;

            #region  无用代码
            //hv_ResultRow_ = hv_ResultRow;
            //hv_ResultColumn_ = hv_ResultColumn;
            #endregion

            hv_ArcType_1 = hv_ArcType;

            hv_ActiveNum_1 = hv_ActiveNum;

            startAngle_1 = this.Hv_StartPhi;

            endAngle_1 = this.Hv_EndPh;

            #endregion

        }
        #endregion

        #region 初始化数据
        /// <summary>
        /// 初始化数据
        /// </summary>
        public override void init()
        {
            base.init();

            #region   外部接口

            this.IOutSide.Center_row_y = (HTuple)mid_row_y_1;

            this.IOutSide.Center_column_x = (HTuple)mid_col_x_1;

            this.IOutSide.Radius = (HTuple)radios_1;

            #endregion

            //#region  图片数据
            //ho_Regions = (HObject)ho_Regions_;
            //#endregion

            #region    卡尺的数据
            hv_Elements = (HTuple)hv_Elements_1;

            hv_DetectHeight = (HTuple)hv_DetectHeight_1;

            hv_DetectWidth = (HTuple)hv_DetectWidth_1;

            //hv_ROIRows = (HTuple)hv_ROIRows_;

            //hv_ROICols = (HTuple)hv_ROICols_;

            hv_Direct = (HTuple)hv_Direct_1;

            hv_Sigma = (HTuple)hv_Sigma_1;

            hv_Threshold = (HTuple)hv_Threshold_1;

            hv_Transition = (HTuple)hv_Transition_1;

            hv_Select = (HTuple)hv_Select_1;

            #region  无用代码
            //hv_ResultRow = (HTuple)hv_ResultRow_;

            //hv_ResultColumn = (HTuple)hv_ResultColumn_;
            #endregion

            hv_ArcType = (HTuple)hv_ArcType_1;
            hv_ActiveNum = (HTuple)hv_ActiveNum_1;
            this.Hv_StartPhi = (HTuple)startAngle_1;
            this.Hv_EndPh = (HTuple)endAngle_1;


            #endregion

            _result = new Cricle_Result();
        }
        #endregion

        #region  检测
        public override bool analyze_show(HWindow hwin, string Key, ref Dictionary<string, object> _dictionary_resulte)
        {
            bool ok = false;

            /*******************************************处理***********************************************/

            HTuple hv_modMat2D;
            HTuple hv_Center_X, hv_Center_Y;
            if (IrectShuJuPianYi != null)
            {
                HObject hv_Cirle;
                HTuple Area_, Column_, Row_;
                HOperatorSet.GenEmptyObj(out hv_Cirle);
                HOperatorSet.VectorAngleToRigid(GenSuiDian_Y_Row, GeuSuiDian_X_Col, GenSuiDian_A, IrectShuJuPianYi.Row, IrectShuJuPianYi.Column, IrectShuJuPianYi.Angle, out hv_modMat2D);
            
                //   HOperatorSet.GenCircle(out hv_Cirle, IOutSide.Center_row_y, IOutSide.Center_column_x, IOutSide.Radius);

                
                HOperatorSet.GenCircleContourXld(out hv_Cirle, iOutSide.Center_row_y, iOutSide.Center_column_x, iOutSide.Radius, 0, 6.28318, "positive", 1);

                HOperatorSet.AffineTransContourXld(hv_Cirle, out hv_Cirle, hv_modMat2D);

                //HOperatorSet.AffineTransRegion(hv_Cirle, out hv_Cirle, hv_modMat2D, "nearest_neighbor");
               // HOperatorSet.AreaCenter(hv_Cirle, out Area_, out Row_, out Column_);

                HTuple pointOrder;
                HOperatorSet.AreaCenterXld(hv_Cirle, out Area_, out Row_, out Column_, out pointOrder);
                
                hv_Cirle.Dispose();
                hv_Center_X = Column_;
                hv_Center_Y = Row_;
            }
            else
            {
                hv_Center_X = IOutSide.Center_column_x;
                hv_Center_Y = IOutSide.Center_row_y;
            }

            HObject ho_Regions;
            HOperatorSet.GenEmptyObj(out ho_Regions);
            HTuple Resultrow, Resultcolumn, ResultArcType;
            //spoke(ho_Image, out ho_Regions, hv_Center_Y, hv_Center_X, ICircle_.IOutSide.Radius, ICircle_.Hv_Elements, ICircle_.Hv_Direct, ICircle_.Hv_DetectHeight, ICircle_.Hv_DetectWidth, ICircle_.Hv_Transition, ICircle_.Hv_Select, ICircle_.Hv_Sigma, ICircle_.Hv_Threshold, out Resultrow, out Resultcolumn, out ResultArcType);
            spoke2(this.ImageFather.Ho_image, out ho_Regions, hv_Center_Y, hv_Center_X, IOutSide.Radius, Hv_StartPhi, Hv_EndPh, Hv_Elements, Hv_Direct, Hv_DetectHeight, Hv_DetectWidth, Hv_Transition, Hv_Select, Hv_Sigma, Hv_Threshold, out Resultrow, out Resultcolumn, out ResultArcType);

            HObject hv_cross1;
            HOperatorSet.GenEmptyObj(out hv_cross1);

            HOperatorSet.GenCrossContourXld(out hv_cross1, Resultrow, Resultcolumn, 6, 0.78639);
            Ho_Regions.Dispose();
            Ho_Regions = hv_cross1;

            Hv_ResultColumn = Resultcolumn;
            Hv_ResultRow = Resultrow;
            Hv_ArcType = ResultArcType;
            Ho_Regions_0 = ho_Regions;

            HObject ho_Circle;
            HOperatorSet.GenEmptyObj(out ho_Circle);
            ho_Circle.Dispose();

            HTuple hv_RowCenter, hv_ColCenter, hv_Radius, hv_StartPhi, hv_EndPhi, hv_PointOrder, hv_ArcAngle;
            pts_to_best_circle(out ho_Circle, Hv_ResultRow, Hv_ResultColumn, Hv_ActiveNum, Hv_ArcType, out hv_RowCenter, out hv_ColCenter, out hv_Radius, out hv_StartPhi, out hv_EndPhi, out hv_PointOrder, out hv_ArcAngle);

            Ho_Circle.Dispose();
            Ho_Circle = ho_Circle;
            Row = hv_RowCenter;
            Column = hv_ColCenter;
            Hv_PointOrder = hv_PointOrder;
            Angle = hv_ArcAngle;

            /****************************************保存数据************************************/
            Key = "Circle_" + Key;
            //Cricle_Result cricleResult = new Cricle_Result();
            _result._tolatName = Key;
            if (Row > 0)
            {
                _result._tolatResult = true;
                _result.Hv_StartPhi = Hv_StartPhi;
                _result.Hv_EndPh = Hv_EndPh;
                _result.Hv_PointOrder = Hv_PointOrder;
                _result.Angle = Angle;
                _result.Row = Row;
                _result.Column = Column;

                if (_ICalibration != null)//确定是否有标定
                {
                    //HTuple row_, col_;
                    //row_ = Row;
                    //col_ = Column;
                    this.Cal(_ICalibration.HomMat2D, ref  _result.Row, ref  _result.Column);
                    //Row = row_;
                    //Column = col_;
                    //cricleResult.Row = row_;
                    //cricleResult.Column = col_;
                }
            }
            else
            {
                _result._tolatResult = false;
                _result.Row = 0;
                _result.Column = 0;
            }
            _dictionary_resulte.Add(Key, _result);

            if (_result._tolatResult)
            {
                ok = true;
            }

            /********************************显示**********************************************/
            show(hwin);
            return ok;
        }
        #endregion

        #region  显示
        public override bool show(HWindow hwin)
        {
            bool ok = false;

            /****显示圆的圆心***/
            if (Column > 0)
            {
                HObject hv_cross;
                HOperatorSet.GenEmptyObj(out hv_cross);
                HOperatorSet.GenCrossContourXld(out hv_cross, Row, Column, 60, Angle);

                hwin.DispObj(hv_cross);
                /***********显示找到的点************/
                hwin.DispObj(Ho_Regions);
                /***显示卡尺工具****/
                hwin.DispObj(Ho_Regions_0);
                /***显示拟合的圆****/
                hwin.DispObj(Ho_Circle);
            }
            else
            {
                hwin.SetColor("red");
                /***显示卡尺工具****/
                hwin.DispObj(Ho_Regions_0);
                hwin.SetColor("green");
            }
            return ok;
        }

        #endregion

        #region  圆的卡尺工具
        void spoke2(HObject ho_Image, out HObject ho_Regions, HTuple hv_yuanDian_y,
 HTuple hv_yuanDian_x, HTuple hv_r, HTuple hv_startJiao, HTuple hv_endJiao, HTuple hv_Elements,
 HTuple hv_Direct, HTuple hv_DetectHeight, HTuple hv_DetectWidth, HTuple hv_Transition,
 HTuple hv_Select, HTuple hv_Sigma, HTuple hv_Threshold, out HTuple hv_ResultRow,
 out HTuple hv_ResultColumn, out HTuple hv_ArcType)
        {
            // Stack for temporary objects 
            HObject[] OTemp = new HObject[20];

            // Local iconic variables 

            HObject ho_ContCircle, ho_Rectangle1 = null;
            HObject ho_Arrow1 = null;

            // Local control variables 

            HTuple hv_SelectOut = null, hv_TransitionOut = null;
            HTuple hv_Width = null, hv_Height = null, hv_RowXLD = null;
            HTuple hv_ColXLD = null, hv_Length2 = null, hv_i = null;
            HTuple hv_j = new HTuple(), hv_RowE = new HTuple(), hv_ColE = new HTuple();
            HTuple hv_ATan = new HTuple(), hv_RowL2 = new HTuple();
            HTuple hv_RowL1 = new HTuple(), hv_ColL2 = new HTuple();
            HTuple hv_ColL1 = new HTuple(), hv_MsrHandle_Measure = new HTuple();
            HTuple hv_RowEdge = new HTuple(), hv_ColEdge = new HTuple();
            HTuple hv_Amplitude = new HTuple(), hv_Distance = new HTuple();
            HTuple hv_tRow = new HTuple(), hv_tCol = new HTuple();
            HTuple hv_t = new HTuple(), hv_Number = new HTuple(), hv_k = new HTuple();
            // Initialize local and output iconic variables 
            HOperatorSet.GenEmptyObj(out ho_Regions);
            HOperatorSet.GenEmptyObj(out ho_ContCircle);
            HOperatorSet.GenEmptyObj(out ho_Rectangle1);
            HOperatorSet.GenEmptyObj(out ho_Arrow1);
            hv_ArcType = new HTuple();
            try
            {
                hv_SelectOut = hv_Select.Clone();
                hv_TransitionOut = hv_Transition.Clone();
                //获取图像尺寸
                HOperatorSet.GetImageSize(ho_Image, out hv_Width, out hv_Height);

                //产生一个空显示对象，用于显示
                ho_Regions.Dispose();
                HOperatorSet.GenEmptyObj(out ho_Regions);

                //初始化边缘坐标数组
                hv_ResultRow = new HTuple();
                hv_ResultColumn = new HTuple();

                ho_ContCircle.Dispose();
                HOperatorSet.GenCircleContourXld(out ho_ContCircle, hv_yuanDian_y, hv_yuanDian_x,
                    hv_r, hv_startJiao, hv_endJiao, "positive", 1);

                //获取圆或圆弧xld上的点坐标
                HOperatorSet.GetContourXld(ho_ContCircle, out hv_RowXLD, out hv_ColXLD);

                //求圆或圆弧xld上的点的数量
                HOperatorSet.TupleLength(hv_ColXLD, out hv_Length2);

                HTuple end_val20 = hv_Elements - 1;
                HTuple step_val20 = 1;
                for (hv_i = 0; hv_i.Continue(end_val20, step_val20); hv_i = hv_i.TupleAdd(step_val20))
                {

                    //xld的起点和终点坐标相对，为圆
                    HOperatorSet.TupleInt(((1.0 * hv_Length2) / hv_Elements) * hv_i, out hv_j);
                    hv_ArcType = "circle";

                    //索引越界，强制赋值为最后一个索引
                    if ((int)(new HTuple(hv_j.TupleGreaterEqual(hv_Length2))) != 0)
                    {
                        hv_j = hv_Length2 - 1;
                        //continue
                    }

                    //获取卡尺工具中心
                    hv_RowE = hv_RowXLD.TupleSelect(hv_j);
                    hv_ColE = hv_ColXLD.TupleSelect(hv_j);

                    //超出图像区域，不检测，否则容易报异常
                    if ((int)((new HTuple((new HTuple((new HTuple(hv_RowE.TupleGreater(hv_Height - 1))).TupleOr(
                        new HTuple(hv_RowE.TupleLess(0))))).TupleOr(new HTuple(hv_ColE.TupleGreater(
                        hv_Width - 1))))).TupleOr(new HTuple(hv_ColE.TupleLess(0)))) != 0)
                    {
                        continue;
                    }

                    //边缘搜索方向类型：'inner'搜索方向由圆外指向圆心；'outer'搜索方向由圆心指向圆外
                    if ((int)(new HTuple(hv_Direct.TupleEqual("inner"))) != 0)
                    {
                        //求卡尺工具的边缘搜索方向
                        //求圆心指向边缘的矢量的角度
                        HOperatorSet.TupleAtan2((-hv_RowE) + hv_yuanDian_y, hv_ColE - hv_yuanDian_x,
                            out hv_ATan);
                        //角度反向
                        hv_ATan = ((new HTuple(180)).TupleRad()) + hv_ATan;
                    }
                    else
                    {
                        //求卡尺工具的边缘搜索方向
                        //求圆心指向边缘的矢量的角度
                        HOperatorSet.TupleAtan2((-hv_RowE) + hv_yuanDian_y, hv_ColE - hv_yuanDian_x,
                            out hv_ATan);
                    }


                    //产生卡尺xld，并保持到显示对象
                    ho_Rectangle1.Dispose();
                    HOperatorSet.GenRectangle2ContourXld(out ho_Rectangle1, hv_RowE, hv_ColE,
                        hv_ATan, hv_DetectHeight / 2, hv_DetectWidth / 2);
                    {
                        HObject ExpTmpOutVar_0;
                        HOperatorSet.ConcatObj(ho_Regions, ho_Rectangle1, out ExpTmpOutVar_0);
                        ho_Regions.Dispose();
                        ho_Regions = ExpTmpOutVar_0;
                    }
                    //用箭头xld指示边缘搜索方向，并保持到显示对象
                    if ((int)(new HTuple(hv_i.TupleEqual(0))) != 0)
                    {
                        hv_RowL2 = hv_RowE + ((hv_DetectHeight / 2) * (((-hv_ATan)).TupleSin()));
                        hv_RowL1 = hv_RowE - ((hv_DetectHeight / 2) * (((-hv_ATan)).TupleSin()));
                        hv_ColL2 = hv_ColE + ((hv_DetectHeight / 2) * (((-hv_ATan)).TupleCos()));
                        hv_ColL1 = hv_ColE - ((hv_DetectHeight / 2) * (((-hv_ATan)).TupleCos()));
                        ho_Arrow1.Dispose();

                        gen_arrow_contour_xld(out ho_Arrow1, hv_RowL1, hv_ColL1, hv_RowL2, hv_ColL2,
                            25, 25);
                        {
                            HObject ExpTmpOutVar_0;
                            HOperatorSet.ConcatObj(ho_Regions, ho_Arrow1, out ExpTmpOutVar_0);
                            ho_Regions.Dispose();
                            ho_Regions = ExpTmpOutVar_0;
                        }
                    }

                    //产生测量对象句柄
                    HOperatorSet.GenMeasureRectangle2(hv_RowE, hv_ColE, hv_ATan, hv_DetectHeight / 2,
                        hv_DetectWidth / 2, hv_Width, hv_Height, "nearest_neighbor", out hv_MsrHandle_Measure);


                    //设置极性
                    if ((int)(new HTuple(hv_TransitionOut.TupleEqual("negative"))) != 0)
                    {
                        hv_TransitionOut = "negative";
                    }
                    else
                    {
                        if ((int)(new HTuple(hv_TransitionOut.TupleEqual("positive"))) != 0)
                        {

                            hv_TransitionOut = "positive";
                        }
                        else
                        {
                            hv_TransitionOut = "all";
                        }
                    }
                    //设置边缘位置。最强点是从所有边缘中选择幅度绝对值最大点，需要设置为'all'
                    if ((int)(new HTuple(hv_SelectOut.TupleEqual("first"))) != 0)
                    {
                        hv_SelectOut = "first";
                    }
                    else
                    {
                        if ((int)(new HTuple(hv_SelectOut.TupleEqual("last"))) != 0)
                        {

                            hv_SelectOut = "last";
                        }
                        else
                        {
                            hv_SelectOut = "all";
                        }
                    }
                    //检测边缘
                    HOperatorSet.MeasurePos(ho_Image, hv_MsrHandle_Measure, hv_Sigma, hv_Threshold,
                        hv_TransitionOut, hv_SelectOut, out hv_RowEdge, out hv_ColEdge, out hv_Amplitude,
                        out hv_Distance);
                    //清除测量对象句柄
                    HOperatorSet.CloseMeasure(hv_MsrHandle_Measure);
                    //临时变量初始化
                    //tRow，tCol保存找到指定边缘的坐标
                    hv_tRow = 0;
                    hv_tCol = 0;
                    //t保存边缘的幅度绝对值
                    hv_t = 0;
                    HOperatorSet.TupleLength(hv_RowEdge, out hv_Number);
                    //找到的边缘必须至少为1个
                    if ((int)(new HTuple(hv_Number.TupleLess(1))) != 0)
                    {
                        continue;
                    }
                    //有多个边缘时，选择幅度绝对值最大的边缘
                    HTuple end_val110 = hv_Number - 1;
                    HTuple step_val110 = 1;
                    for (hv_k = 0; hv_k.Continue(end_val110, step_val110); hv_k = hv_k.TupleAdd(step_val110))
                    {
                        if ((int)(new HTuple(((((hv_Amplitude.TupleSelect(hv_k))).TupleAbs())).TupleGreater(
                            hv_t))) != 0)
                        {

                            hv_tRow = hv_RowEdge.TupleSelect(hv_k);
                            hv_tCol = hv_ColEdge.TupleSelect(hv_k);
                            hv_t = ((hv_Amplitude.TupleSelect(hv_k))).TupleAbs();
                        }
                    }
                    //把找到的边缘保存在输出数组
                    if ((int)(new HTuple(hv_t.TupleGreater(0))) != 0)
                    {

                        hv_ResultRow = hv_ResultRow.TupleConcat(hv_tRow);
                        hv_ResultColumn = hv_ResultColumn.TupleConcat(hv_tCol);
                    }

                }

                //gen_cross_contour_xld (Cross, ResultRow, ResultColumn, 6, 0.785398)
                ho_ContCircle.Dispose();
                ho_Rectangle1.Dispose();
                ho_Arrow1.Dispose();

                return;
            }
            catch (HalconException HDevExpDefaultException)
            {
                ho_ContCircle.Dispose();
                ho_Rectangle1.Dispose();
                ho_Arrow1.Dispose();

                throw HDevExpDefaultException;
            }
        }
        #endregion

        #region    拟合圆
        /// <summary>
        /// 拟合圆
        /// </summary>
        /// <param name="ho_Circle">输出拟合圆的xld</param>
        /// <param name="hv_Rows">拟合圆的边缘y数组</param>
        /// <param name="hv_Cols">拟合圆的边缘x数组</param>
        /// <param name="hv_ActiveNum">最小有效点数</param>
        /// <param name="hv_ArcType">拟合圆弧类型：'arc'圆弧；'circle'圆</param>
        /// <param name="hv_RowCenter">拟合的圆中心y</param>
        /// <param name="hv_ColCenter">拟合的圆中心x</param>
        /// <param name="hv_Radius">拟合的圆半径</param>
        /// <param name="hv_StartPhi">圆弧起点角度(单位：弧度)</param>
        /// <param name="hv_EndPhi">圆弧终点角度(单位：弧度)</param>
        /// <param name="hv_PointOrder">轮廓点方向</param>
        /// <param name="hv_ArcAngle"></param>
        void pts_to_best_circle(out HObject ho_Circle, HTuple hv_Rows, HTuple hv_Cols,
      HTuple hv_ActiveNum, HTuple hv_ArcType, out HTuple hv_RowCenter, out HTuple hv_ColCenter,
      out HTuple hv_Radius, out HTuple hv_StartPhi, out HTuple hv_EndPhi, out HTuple hv_PointOrder,
      out HTuple hv_ArcAngle)
        {
            // Local iconic variables 
            HObject ho_Contour = null;
            // Local control variables 
            HTuple hv_Length = null, hv_Length1 = new HTuple();
            HTuple hv_CircleLength = new HTuple();
            // Initialize local and output iconic variables 
            HOperatorSet.GenEmptyObj(out ho_Circle);
            HOperatorSet.GenEmptyObj(out ho_Contour);
            hv_StartPhi = new HTuple();
            hv_EndPhi = new HTuple();
            hv_PointOrder = new HTuple();
            hv_ArcAngle = new HTuple();
            //try
            //{
            //    //初始化
            hv_RowCenter = 0;
            hv_ColCenter = 0;
            hv_Radius = 0;
            //产生一个空的直线对象，用于保存拟合后的圆
            ho_Circle.Dispose();
            HOperatorSet.GenEmptyObj(out ho_Circle);
            //计算边缘数量
            HOperatorSet.TupleLength(hv_Cols, out hv_Length);
            //当边缘数量不小于有效点数时进行拟合
            if ((int)((new HTuple(hv_Length.TupleGreaterEqual(hv_ActiveNum))).TupleAnd(
                new HTuple(hv_ActiveNum.TupleGreater(2)))) != 0)
            {
                //halcon的拟合是基于xld的，需要把边缘连接成xld
                if ((int)(new HTuple(hv_ArcType.TupleEqual("circle"))) != 0)
                {
                    //如果是闭合的圆，轮廓需要首尾相连
                    ho_Contour.Dispose();
                    HOperatorSet.GenContourPolygonXld(out ho_Contour, hv_Rows.TupleConcat(hv_Rows.TupleSelect(
                        0)), hv_Cols.TupleConcat(hv_Cols.TupleSelect(0)));
                }
                else
                {
                    ho_Contour.Dispose();
                    HOperatorSet.GenContourPolygonXld(out ho_Contour, hv_Rows, hv_Cols);
                }
                //拟合圆。使用的算法是''geotukey''，其他算法请参考fit_circle_contour_xld的描述部分。
                HOperatorSet.FitCircleContourXld(ho_Contour, "geotukey", -1, 0, 0, 3, 2,
                    out hv_RowCenter, out hv_ColCenter, out hv_Radius, out hv_StartPhi, out hv_EndPhi,
                    out hv_PointOrder);
                //判断拟合结果是否有效：如果拟合成功，数组中元素的数量大于0
                HOperatorSet.TupleLength(hv_StartPhi, out hv_Length1);
                if ((int)(new HTuple(hv_Length1.TupleLess(1))) != 0)
                {
                    ho_Contour.Dispose();
                    return;
                }
                //根据拟合结果，产生直线xld
                if ((int)(new HTuple(hv_ArcType.TupleEqual("arc"))) != 0)
                {
                    #region  无用代码
                    //判断圆弧的方向：顺时针还是逆时针
                    //halcon求圆弧会出现方向混乱的问题
                    //tuple_mean (Rows, RowsMean)
                    //tuple_mean (Cols, ColsMean)
                    //gen_cross_contour_xld (Cross, RowsMean, ColsMean, 6, 0.785398)
                    //gen_circle_contour_xld (Circle1, RowCenter, ColCenter, Radius, StartPhi, EndPhi, 'positive', 1)
                    //求轮廓1中心
                    //area_center_points_xld (Circle1, Area, Row1, Column1)
                    //gen_circle_contour_xld (Circle2, RowCenter, ColCenter, Radius, StartPhi, EndPhi, 'negative', 1)
                    //求轮廓2中心
                    //area_center_points_xld (Circle2, Area, Row2, Column2)
                    //distance_pp (RowsMean, ColsMean, Row1, Column1, Distance1)
                    //distance_pp (RowsMean, ColsMean, Row2, Column2, Distance2)
                    //ArcAngle := EndPhi-StartPhi
                    //if (Distance1<Distance2)

                    //PointOrder := 'positive'
                    //copy_obj (Circle1, Circle, 1, 1)
                    //else

                    //PointOrder := 'negative'
                    //if (abs(ArcAngle)>3.1415926)
                    //ArcAngle := ArcAngle-2.0*3.1415926
                    //endif
                    //copy_obj (Circle2, Circle, 1, 1)
                    //endif
                    #endregion
                    ho_Circle.Dispose();
                    HOperatorSet.GenCircleContourXld(out ho_Circle, hv_RowCenter, hv_ColCenter,
                        hv_Radius, hv_StartPhi, hv_EndPhi, hv_PointOrder, 1);

                    HOperatorSet.LengthXld(ho_Circle, out hv_CircleLength);
                    hv_ArcAngle = hv_EndPhi - hv_StartPhi;
                    if ((int)(new HTuple(hv_CircleLength.TupleGreater(((new HTuple(180)).TupleRad()
                        ) * hv_Radius))) != 0)
                    {
                        if ((int)(new HTuple(((hv_ArcAngle.TupleAbs())).TupleLess((new HTuple(180)).TupleRad()
                            ))) != 0)
                        {
                            if ((int)(new HTuple(hv_ArcAngle.TupleGreater(0))) != 0)
                            {
                                hv_ArcAngle = ((new HTuple(360)).TupleRad()) - hv_ArcAngle;
                            }
                            else
                            {

                                hv_ArcAngle = ((new HTuple(360)).TupleRad()) + hv_ArcAngle;
                            }
                        }
                    }
                    else
                    {
                        if ((int)(new HTuple(hv_CircleLength.TupleLess(((new HTuple(180)).TupleRad()
                            ) * hv_Radius))) != 0)
                        {
                            if ((int)(new HTuple(((hv_ArcAngle.TupleAbs())).TupleGreater((new HTuple(180)).TupleRad()
                                ))) != 0)
                            {
                                if ((int)(new HTuple(hv_ArcAngle.TupleGreater(0))) != 0)
                                {
                                    hv_ArcAngle = hv_ArcAngle - ((new HTuple(360)).TupleRad());

                                }
                                else
                                {
                                    hv_ArcAngle = ((new HTuple(360)).TupleRad()) + hv_ArcAngle;
                                }
                            }
                        }
                    }
                }
                else
                {
                    hv_StartPhi = 0;
                    hv_EndPhi = (new HTuple(360)).TupleRad();
                    hv_ArcAngle = (new HTuple(360)).TupleRad();
                    ho_Circle.Dispose();
                    HOperatorSet.GenCircleContourXld(out ho_Circle, hv_RowCenter, hv_ColCenter,
                        hv_Radius, hv_StartPhi, hv_EndPhi, hv_PointOrder, 1);
                }
            }
            ho_Contour.Dispose();
            return;
            //}
            //catch ()
            //{
            //    ho_Contour.Dispose();

            //   //throw HDevExpDefaultException;
            //}
        }
        #endregion

        #region   得到xld
        /// <summary>
        /// 得到xld
        /// </summary>
        /// <param name="ho_Arrow"></param>
        /// <param name="hv_Row1"></param>
        /// <param name="hv_Column1"></param>
        /// <param name="hv_Row2"></param>
        /// <param name="hv_Column2"></param>
        /// <param name="hv_HeadLength"></param>
        /// <param name="hv_HeadWidth"></param>
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

    #region  拟合圆的数据接口
    /// <summary>
    /// 拟合圆的数据接口
    /// </summary>
    public interface ICircleShuJu : IOutsideCricle, MultTree.IToolDateFather
    {
        #region  图片数据
        /// <summary>
        /// 查找到的点
        /// </summary>
        HObject Ho_Regions
        {
            get;
            set;

        }

        /// <summary>
        ///输出边缘点检测区域及方向 
        /// </summary>
        HObject Ho_Regions_0
        {
            get;
            set;
        }

        /// <summary>
        /// 拟合出来的圆
        /// </summary>
        HObject Ho_Circle { get; set; }
        #endregion

        //#region  防射变换
        /////// <summary>
        /////// 防射变换
        /////// </summary>
        ////HTuple Hv_HomMat2D
        ////{
        ////    get;
        ////    set;
        ////}
        //#endregion

        #region    卡尺的数据
        /// <summary>
        /// 卡尺的个数
        /// </summary>
        HTuple Hv_Elements { get; set; }

        /// <summary>
        /// 卡尺的高
        /// </summary>
        HTuple Hv_DetectHeight { get; set; }

        /// <summary>
        /// 卡尺的宽
        /// </summary>
        HTuple Hv_DetectWidth { get; set; }

        /// <summary>
        /// spoke工具ROI的y数组   检测区域起点的y值
        /// </summary>
        HTuple Hv_ROIRows { get; set; }

        /// <summary>
        /// spoke工具ROI的x数组    检测区域起点的x值
        /// </summary>
        HTuple Hv_ROICols { get; set; }

        /// <summary>
        /// 'inner'表示检测方向由边缘点指向圆心；'outer'表示检测方向由圆心指向边缘点
        /// </summary>
        HTuple Hv_Direct { get; set; }

        /// <summary>
        /// 高斯滤波因子
        /// </summary>
        HTuple Hv_Sigma { get; set; }

        /// <summary>
        /// 边缘幅度阈值
        /// </summary>
        HTuple Hv_Threshold { get; set; }

        /// <summary>
        /// 极性：  positive表示由黑到白   negative表示由白到黑   all表示以上两种方向
        /// </summary>
        HTuple Hv_Transition { get; set; }

        /// <summary>
        /// >first表示选择第一点    last表示选择最后一点   max表示选择边缘强度最强点
        /// </summary>
        HTuple Hv_Select { set; get; }

        /// <summary>
        /// 检测到的边缘点的y坐标数组    拟合圆的边缘y数组
        /// </summary>
        HTuple Hv_ResultRow { set; get; }

        /// <summary>
        /// 检测到的边缘点的x坐标数组   拟合圆的边缘x数组
        /// </summary>
        HTuple Hv_ResultColumn { get; set; }

        /// <summary>
        /// 拟合圆弧类型：'arc'圆弧；'circle'圆
        /// </summary>
        HTuple Hv_ArcType { get; set; }

        /// <summary>
        /// 最小有效点数
        /// </summary>
        HTuple Hv_ActiveNum { get; set; }

        #endregion

        #region  输出的数据
        ///// <summary>
        ///// 拟合的圆中心y
        ///// </summary>
        //HTuple Hv_RowCenter { get; set; }

        ///// <summary>
        ///// 拟合的圆中心x
        ///// </summary>
        //HTuple Hv_ColCenter { get; set; }

        /// <summary>
        /// 拟合的圆半径
        /// </summary>
        HTuple Hv_Radius { get; set; }

        /// <summary>
        /// 圆弧起点角度(单位：弧度)
        /// </summary>
        HTuple Hv_StartPhi { get; set; }

        /// <summary>
        /// 圆弧终点角度(单位：弧度)
        /// </summary>
        HTuple Hv_EndPh { get; set; }

        /// <summary>
        /// 轮廓点方向
        /// </summary>
        HTuple Hv_PointOrder { get; set; }

        ///// <summary>
        ///// 
        ///// </summary>
        //HTuple Hv_ArcAngle { get; set; }
        #endregion

    }
    #endregion

    #region 拟合圆数据设置器
    /// <summary>
    /// 设置拟合圆工具的数据
    /// </summary>
    public class SetCirleShuJu:MultTree.SetFather
    {
        #region  无用代码
        #region  无用代码
        //#region 设置卡尺参数
        ///// <summary>
        ///// 设置卡尺的数据
        ///// </summary>
        ///// <param name="ICircle">传入数据的接口</param>
        ///// <param name="number">卡尺的个数，null时不设置</param>
        ///// <param name="height">卡尺的高，null时不设置</param>
        ///// <param name="width">卡尺的宽，null时不设置</param>
        ///// <returns>返回真代表设置成功</returns>
        //public bool Set_CalliPers(ICircleShuJu ICircle, string number, string height, string width)
        //{
        //    bool ok = false;

        //    if (number != null)
        //    {
        //        int nu = int.Parse(number);
        //        ICircle.Hv_Elements = nu;
        //    }

        //    if (height != null)
        //    {
        //        double he = double.Parse(height);
        //        ICircle.Hv_DetectHeight = he;
        //    }

        //    if (width != null)
        //    {
        //        double wi = double.Parse(width);
        //        ICircle.Hv_DetectWidth = wi;
        //    }

        //    ok = true;
        //    return ok;
        //}
        //#endregion
        #endregion

        #region  无用代码
        #region 设置spoke参数
        ///// <summary>
        ///// 设置spoke参数
        ///// </summary>
        ///// <param name="ICircle">传入的数据接口</param>
        ///// <param name="Ho_Regions">传入spoke的region ，null时不设置</param>
        ///// <param name="Hv_ROIRows">传入spoke的y点的数据</param>
        ///// <param name="Hv_ROICols">传入spoke的x点的数据</param>
        ///// <param name="Hv_Direct">传入spoke的检测方向，inner：从外指向圆心，outer：从圆心指向外</param>
        ///// <returns></returns>
        //public bool Set_Spoke(ICircleShuJu ICircle, HObject Ho_Regions, HTuple Hv_ROIRows, HTuple Hv_ROICols, HTuple Hv_Direct)
        //{
        //    bool ok = false;

        //    if (Ho_Regions != null)
        //    {
        //        ICircle.Ho_Regions = Ho_Regions;
        //    }

        //    if (Hv_ROIRows != null)
        //    {
        //        ICircle.Hv_ROIRows = Hv_ROIRows;
        //    }

        //    if (Hv_ROICols != null)
        //    {
        //        ICircle.Hv_ROICols = Hv_ROICols;
        //    }

        //    if (Hv_Direct != null)
        //    {
        //        ICircle.Hv_Direct = Hv_Direct;
        //    }


        //    ok = true;
        //    return ok;


        //}

        #endregion
        #endregion

        #region  无用代码
        //    #region  显示拟合圆
        //    /// <summary>
        //    /// 显示拟合圆
        //    /// </summary>
        //    /// <param name="ICircleShuJu_"></param>
        //    /// <param name="hv_WindowHandle"></param>
        //    /// <returns></returns>
        //    public bool Set_show_Circle(ICircleShuJu ICircleShuJu_, HWindow hv_WindowHandle)
        //    {
        //        bool ok = false;

        //        if (ICircleShuJu_.Ho_Circle.IsInitialized())
        //        {
        //            hv_WindowHandle.DispObj(ICircleShuJu_.Ho_Circle);
        //        }

        //        ok = true;
        //        return ok;
        //    }

        //    #endregion

        //#region  显示找到的点
        ///// <summary>
        ///// 显示找到的点
        ///// </summary>
        ///// <param name="ICircleShuJu_"></param>
        ///// <param name="hv_WindowHandle"></param>
        ///// <returns></returns>
        //public bool Set_show_point(ICircleShuJu ICircleShuJu_, HWindow hv_WindowHandle)
        //{
        //    bool ok = false;
        //    if (ICircleShuJu_.Hv_ResultColumn == null)
        //    {
        //        return false;
        //    }
        //    int num = ICircleShuJu_.Hv_ResultColumn.Length;
        //    HObject cross;
        //    HOperatorSet.GenEmptyObj(out cross);

        //    for (int i = 0; i < num; i++)
        //    {
        //        HOperatorSet.GenCrossContourXld(out cross, ICircleShuJu_.Hv_ResultRow[i], ICircleShuJu_.Hv_ResultColumn[i], 10, 60);

        //        hv_WindowHandle.DispObj(cross);
        //    }

        //    ok = true;
        //    return ok;
        //}

        //#endregion
        #endregion
        #endregion

        #region   设置测量参数，传入的参数为null时不设置
        /// <summary>
        /// 设置测量参数，传入的参数为null时不设置
        /// </summary>
        /// <param name="ICircle">传入数据的接口</param>
        /// <param name="Hv_ActiveNum">最小有效点</param>
        /// <param name="Hv_Sigma">高斯滤波因子</param>
        /// <param name="Hv_Threshold">梯度阈值</param>
        /// <param name="Hv_Transition">查找的极性</param>
        /// <param name="Hv_Select">选择查找点的位置</param>
        /// <returns></returns>
        public bool Set_Measure(ICircleShuJu ICircle, string number, string height, string width, string Hv_Dirct, string startAngle, string endAngel, string Hv_ActiveNum, string Hv_Sigma
            , string Hv_Threshold, string Hv_Transition, string Hv_Select)
        {
            bool ok = false;

            if (number != null)
            {
                int nu = int.Parse(number);
                ICircle.Hv_Elements = nu;
            }

            if (height != null)
            {
                double he = double.Parse(height);
                ICircle.Hv_DetectHeight = he;
            }

            if (width != null)
            {
                double wi = double.Parse(width);
                ICircle.Hv_DetectWidth = wi;
            }

            if (Hv_Dirct != null)
            {
                ICircle.Hv_Direct = Hv_Dirct;
            }

            if (startAngle != null)
            {
                double num = double.Parse(startAngle);

                num = (Math.PI / 180) * num;

                ICircle.Hv_StartPhi = num;
            }

            if (endAngel != null)
            {
                double num = double.Parse(endAngel);

                num = (Math.PI / 180) * num;

                ICircle.Hv_EndPh = num;
            }

            if (Hv_ActiveNum != null)
            {
                double num = Convert.ToDouble(Hv_ActiveNum);
                ICircle.Hv_ActiveNum = num;
            }

            if (Hv_Sigma != null)
            {
                double num = Convert.ToDouble(Hv_Sigma);
                ICircle.Hv_Sigma = num;
            }

            if (Hv_Threshold != null)
            {
                double num = Convert.ToDouble(Hv_Threshold);
                ICircle.Hv_Threshold = num;
            }

            if (Hv_Transition != null)
            {
                ICircle.Hv_Transition = Hv_Transition;
            }

            if (Hv_Select != null)
            {
                ICircle.Hv_Select = Hv_Select;
            }
            ok = true;
            return ok;

        }
        #endregion

        #region  输出参数
        /// <summary>
        /// 输出参数
        /// </summary>
        /// <param name="ICircleShuJu_"></param>
        /// <param name="control"></param>
        /// <param name="halconWinControl_"></param>
        /// <returns></returns>
        public bool Set_ShowParameterHalconWinControl(ICircleShuJu ICircleShuJu_, Control.ControlCollection control, HalControl.HalconWinControl_ROI halconWinControl_, HalControl.HalconWinControl_ROI.repaint roi_)
        {
            bool ok = false;

            this.ShuaXinDingWeiDian((MultTree.IToolDateFather)ICircleShuJu_,ICircleShuJu_.IOutSide);
            
            if (halconWinControl_ != null)
            {
                halconWinControl_.DrawCircle(ICircleShuJu_.IOutSide.Center_column_x, ICircleShuJu_.IOutSide.Center_row_y, ICircleShuJu_.IOutSide.Radius, ICircleShuJu_.IOutSide);
            }

            if (roi_ != null)
            {
                halconWinControl_.Repaint += roi_;
            }

            Set_ShowParameter(ICircleShuJu_, control);
            ok = true;
            return ok;
        }

        /// <summary>
        /// 输出参数
        /// </summary>
        /// <param name="ICircleShuJu_"></param>
        /// <param name="control"></param>
        /// <returns></returns>
        bool Set_ShowParameter(ICircleShuJu ICircleShuJu_, Control.ControlCollection control)
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
                            con.Text = ICircleShuJu_.Hv_Elements.ToString().Replace("\"", "");
                            break;

                        case "numericUpDown_Hv_DetectHeight":
                            con.Text = ICircleShuJu_.Hv_DetectHeight.ToString().Replace("\"", "");
                            break;

                        case "numericUpDown_Hv_DetectWidth":
                            con.Text = ICircleShuJu_.Hv_DetectWidth.ToString().Replace("\"", "");
                            break;

                        case "numericUpDown_startAngle":
                            double num = ICircleShuJu_.Hv_StartPhi.D;
                            num = num * 180 / Math.PI;
                            con.Text = num.ToString();
                            break;

                        case "numericUpDown_endAngle":
                            double num1 = ICircleShuJu_.Hv_EndPh.D;
                            num1 = num1 * 180 / Math.PI;
                            con.Text = num1.ToString();
                            break;
                        #endregion

                        #region   测量数据
                        case "numericUpDown_Hv_Direct":
                            con.Text = ICircleShuJu_.Hv_Direct.ToString().Replace("\"", "");
                            break;

                        case "comboBox_Hv_Sigma":
                            con.Text = ICircleShuJu_.Hv_Sigma.ToString().Replace("\"", "");
                            break;

                        case "numericUpDown_Hv_Threshold":
                            con.Text = ICircleShuJu_.Hv_Threshold.ToString().Replace("\"", "");
                            break;

                        case "comboBox_Hv_Transition":
                            con.Text = ICircleShuJu_.Hv_Transition.ToString().Replace("\"", "");
                            break;

                        case "comboBox_Hv_ArcType":
                            con.Text = ICircleShuJu_.Hv_ArcType.ToString().Replace("\"", "");
                            break;

                        case "numericUpDown_Hv_ActiveNum":
                            con.Text = ICircleShuJu_.Hv_ActiveNum.ToString().Replace("\"", "");
                            break;

                        case "comboBox_Hv_Select":
                            con.Text = ICircleShuJu_.Hv_Select.ToString().Replace("\"", "");
                            break;

                        case "comboBox_Hv_Direct":
                            con.Text = ICircleShuJu_.Hv_Direct.ToString().Replace("\"", "");
                            break;

                        #endregion
                    }
                }
                if (con.Controls.Count > 0)
                {
                    Set_ShowParameter(ICircleShuJu_, con.Controls);
                }
            }
            ok = true;
            return ok;

        }
        #endregion

        #region   显示卡尺,获取卡尺测量的点

        #region  无用代码
        ///// <summary>
        ///// 画圆
        ///// </summary>
        ///// <param name="ICircleShuJu_"></param>
        ///// <param name="ho_Image"></param>
        ///// <param name="hv_WindowHandle"></param>
        ///// <returns></returns>
        //public bool Set_DrawSpoke(ICircleShuJu ICircleShuJu_, HObject ho_Image, HWindow hv_WindowHandle)
        //{

        //    bool ok = false;
        //    HObject ho_region;
        //    HOperatorSet.GenEmptyObj(out ho_region);
        //    HTuple Row, Column, Direct;

        //    base.draw_spoke(ho_Image, out ho_region, hv_WindowHandle, ICircleShuJu_.Hv_Elements, ICircleShuJu_.Hv_DetectHeight, ICircleShuJu_.Hv_DetectWidth, out Row, out Column, out Direct);

        //    ICircleShuJu_.Ho_Regions = ho_region;
        //    ICircleShuJu_.Hv_ROIRows = Row;
        //    ICircleShuJu_.Hv_ROICols = Column;
        //    ICircleShuJu_.Hv_Direct = Direct;
        //    hv_WindowHandle.DispObj(ho_region);

        //    ok = true;
        //    return ok;
        //}
        //#endregion

        //    #region   显示卡尺
        //    /// <summary>
        //    /// 显示卡尺
        //    /// </summary>
        //    /// <param name="ICircleShuJu_"></param>
        //    /// <param name="hv_WindowHandle"></param>
        //    /// <returns></returns>
        //    public bool Set_Show_DrawSpoke(ICircleShuJu ICircleShuJu_, HWindow hv_WindowHandle)
        //    {
        //        bool ok = false;
        //        hv_WindowHandle.DispObj(ICircleShuJu_.Ho_Regions);
        //        ok = true;
        //        return ok;
        //    }
        #endregion

        /// <summary>
        /// 显示卡尺,获取卡尺测量的点
        /// </summary>
        /// <param name="ICircleShuJu_"></param>
        /// <param name="hv_WindowHandle"></param>
        /// <returns></returns>
        public bool Set_ShowDrawSpoke2(HObject ho_Image_, ICircleShuJu ICircleShuJu_, HWindow hv_WindowHandle)
        {
            bool ok = false;
            HObject Ho_Region, ho_cross;
            HOperatorSet.GenEmptyObj(out Ho_Region);
            HOperatorSet.GenEmptyObj(out ho_cross);
            HTuple RowResult_, ColumnResult_, hv_Acty_;
            spoke2(ho_Image_, out Ho_Region, ICircleShuJu_.IOutSide.Center_row_y, ICircleShuJu_.IOutSide.Center_column_x, ICircleShuJu_.IOutSide.Radius, ICircleShuJu_.Hv_StartPhi, ICircleShuJu_.Hv_EndPh, ICircleShuJu_.Hv_Elements, ICircleShuJu_.Hv_Direct, ICircleShuJu_.Hv_DetectHeight, ICircleShuJu_.Hv_DetectWidth, ICircleShuJu_.Hv_Transition, ICircleShuJu_.Hv_Select, ICircleShuJu_.Hv_Sigma, ICircleShuJu_.Hv_Threshold, out RowResult_, out ColumnResult_, out hv_Acty_);

            ICircleShuJu_.Ho_Regions_0.Dispose();
            ICircleShuJu_.Ho_Regions_0 = Ho_Region;
            ICircleShuJu_.Hv_ResultRow = RowResult_;
            ICircleShuJu_.Hv_ResultColumn = ColumnResult_;
            ICircleShuJu_.Hv_ArcType = hv_Acty_;

            HOperatorSet.GenCrossContourXld(out ho_cross, ICircleShuJu_.Hv_ResultRow, ICircleShuJu_.Hv_ResultColumn, 30, 30);

            ICircleShuJu_.Ho_Regions.Dispose();
            ICircleShuJu_.Ho_Regions = ho_cross;

            hv_WindowHandle.DispObj(ICircleShuJu_.Ho_Regions_0);
            hv_WindowHandle.DispObj(ICircleShuJu_.Ho_Regions);

            ok = true;
            return ok;
        }

        void spoke2(HObject ho_Image, out HObject ho_Regions, HTuple hv_yuanDian_y,
    HTuple hv_yuanDian_x, HTuple hv_r, HTuple hv_startJiao, HTuple hv_endJiao, HTuple hv_Elements,
    HTuple hv_Direct, HTuple hv_DetectHeight, HTuple hv_DetectWidth, HTuple hv_Transition,
    HTuple hv_Select, HTuple hv_Sigma, HTuple hv_Threshold, out HTuple hv_ResultRow,
    out HTuple hv_ResultColumn, out HTuple hv_ArcType)
        {
            // Stack for temporary objects 
            HObject[] OTemp = new HObject[20];
            // Local iconic variables 
            HObject ho_ContCircle, ho_Rectangle1 = null;
            HObject ho_Arrow1 = null;
            // Local control variables

            HTuple hv_SelectOut = null, hv_TransitionOut = null;
            HTuple hv_Width = null, hv_Height = null, hv_RowXLD = null;
            HTuple hv_ColXLD = null, hv_Length2 = null, hv_i = null;
            HTuple hv_j = new HTuple(), hv_RowE = new HTuple(), hv_ColE = new HTuple();
            HTuple hv_ATan = new HTuple(), hv_RowL2 = new HTuple();
            HTuple hv_RowL1 = new HTuple(), hv_ColL2 = new HTuple();
            HTuple hv_ColL1 = new HTuple(), hv_MsrHandle_Measure = new HTuple();
            HTuple hv_RowEdge = new HTuple(), hv_ColEdge = new HTuple();
            HTuple hv_Amplitude = new HTuple(), hv_Distance = new HTuple();
            HTuple hv_tRow = new HTuple(), hv_tCol = new HTuple();
            HTuple hv_t = new HTuple(), hv_Number = new HTuple(), hv_k = new HTuple();
            // Initialize local and output iconic variables 
            HOperatorSet.GenEmptyObj(out ho_Regions);
            HOperatorSet.GenEmptyObj(out ho_ContCircle);
            HOperatorSet.GenEmptyObj(out ho_Rectangle1);
            HOperatorSet.GenEmptyObj(out ho_Arrow1);
            hv_ArcType = new HTuple();
            try
            {
                hv_SelectOut = hv_Select.Clone();
                hv_TransitionOut = hv_Transition.Clone();
                //获取图像尺寸
                HOperatorSet.GetImageSize(ho_Image, out hv_Width, out hv_Height);

                //产生一个空显示对象，用于显示
                ho_Regions.Dispose();
                HOperatorSet.GenEmptyObj(out ho_Regions);

                //初始化边缘坐标数组
                hv_ResultRow = new HTuple();
                hv_ResultColumn = new HTuple();

                ho_ContCircle.Dispose();
                HOperatorSet.GenCircleContourXld(out ho_ContCircle, hv_yuanDian_y, hv_yuanDian_x,
                    hv_r, hv_startJiao, hv_endJiao, "positive", 1);

                //获取圆或圆弧xld上的点坐标
                HOperatorSet.GetContourXld(ho_ContCircle, out hv_RowXLD, out hv_ColXLD);

                //求圆或圆弧xld上的点的数量
                HOperatorSet.TupleLength(hv_ColXLD, out hv_Length2);

                HTuple end_val20 = hv_Elements - 1;
                HTuple step_val20 = 1;
                for (hv_i = 0; hv_i.Continue(end_val20, step_val20); hv_i = hv_i.TupleAdd(step_val20))
                {
                    //xld的起点和终点坐标相对，为圆
                    HOperatorSet.TupleInt(((1.0 * hv_Length2) / hv_Elements) * hv_i, out hv_j);
                    hv_ArcType = "circle";

                    //索引越界，强制赋值为最后一个索引
                    if ((int)(new HTuple(hv_j.TupleGreaterEqual(hv_Length2))) != 0)
                    {
                        hv_j = hv_Length2 - 1;
                        //continue
                    }

                    //获取卡尺工具中心
                    hv_RowE = hv_RowXLD.TupleSelect(hv_j);
                    hv_ColE = hv_ColXLD.TupleSelect(hv_j);

                    //超出图像区域，不检测，否则容易报异常
                    if ((int)((new HTuple((new HTuple((new HTuple(hv_RowE.TupleGreater(hv_Height - 1))).TupleOr(
                        new HTuple(hv_RowE.TupleLess(0))))).TupleOr(new HTuple(hv_ColE.TupleGreater(
                        hv_Width - 1))))).TupleOr(new HTuple(hv_ColE.TupleLess(0)))) != 0)
                    {
                        continue;
                    }

                    //边缘搜索方向类型：'inner'搜索方向由圆外指向圆心；'outer'搜索方向由圆心指向圆外
                    if ((int)(new HTuple(hv_Direct.TupleEqual("inner"))) != 0)
                    {
                        //求卡尺工具的边缘搜索方向
                        //求圆心指向边缘的矢量的角度
                        HOperatorSet.TupleAtan2((-hv_RowE) + hv_yuanDian_y, hv_ColE - hv_yuanDian_x,
                            out hv_ATan);
                        //角度反向
                        hv_ATan = ((new HTuple(180)).TupleRad()) + hv_ATan;
                    }
                    else
                    {
                        //求卡尺工具的边缘搜索方向
                        //求圆心指向边缘的矢量的角度
                        HOperatorSet.TupleAtan2((-hv_RowE) + hv_yuanDian_y, hv_ColE - hv_yuanDian_x,
                            out hv_ATan);
                    }


                    //产生卡尺xld，并保持到显示对象
                    ho_Rectangle1.Dispose();
                    HOperatorSet.GenRectangle2ContourXld(out ho_Rectangle1, hv_RowE, hv_ColE,
                        hv_ATan, hv_DetectHeight / 2, hv_DetectWidth / 2);
                    {
                        HObject ExpTmpOutVar_0;
                        HOperatorSet.ConcatObj(ho_Regions, ho_Rectangle1, out ExpTmpOutVar_0);
                        ho_Regions.Dispose();
                        ho_Regions = ExpTmpOutVar_0;
                    }
                    //用箭头xld指示边缘搜索方向，并保持到显示对象
                    if ((int)(new HTuple(hv_i.TupleEqual(0))) != 0)
                    {
                        hv_RowL2 = hv_RowE + ((hv_DetectHeight / 2) * (((-hv_ATan)).TupleSin()));
                        hv_RowL1 = hv_RowE - ((hv_DetectHeight / 2) * (((-hv_ATan)).TupleSin()));
                        hv_ColL2 = hv_ColE + ((hv_DetectHeight / 2) * (((-hv_ATan)).TupleCos()));
                        hv_ColL1 = hv_ColE - ((hv_DetectHeight / 2) * (((-hv_ATan)).TupleCos()));
                        ho_Arrow1.Dispose();

                        gen_arrow_contour_xld(out ho_Arrow1, hv_RowL1, hv_ColL1, hv_RowL2, hv_ColL2,
                            25, 25);
                        {
                            HObject ExpTmpOutVar_0;
                            HOperatorSet.ConcatObj(ho_Regions, ho_Arrow1, out ExpTmpOutVar_0);
                            ho_Regions.Dispose();
                            ho_Regions = ExpTmpOutVar_0;
                        }
                    }

                    //产生测量对象句柄
                    HOperatorSet.GenMeasureRectangle2(hv_RowE, hv_ColE, hv_ATan, hv_DetectHeight / 2,
                        hv_DetectWidth / 2, hv_Width, hv_Height, "nearest_neighbor", out hv_MsrHandle_Measure);


                    //设置极性
                    if ((int)(new HTuple(hv_TransitionOut.TupleEqual("negative"))) != 0)
                    {
                        hv_TransitionOut = "negative";
                    }
                    else
                    {
                        if ((int)(new HTuple(hv_TransitionOut.TupleEqual("positive"))) != 0)
                        {

                            hv_TransitionOut = "positive";
                        }
                        else
                        {
                            hv_TransitionOut = "all";
                        }
                    }
                    //设置边缘位置。最强点是从所有边缘中选择幅度绝对值最大点，需要设置为'all'
                    if ((int)(new HTuple(hv_SelectOut.TupleEqual("first"))) != 0)
                    {
                        hv_SelectOut = "first";
                    }
                    else
                    {
                        if ((int)(new HTuple(hv_SelectOut.TupleEqual("last"))) != 0)
                        {

                            hv_SelectOut = "last";
                        }
                        else
                        {
                            hv_SelectOut = "all";
                        }
                    }
                    //检测边缘
                    HOperatorSet.MeasurePos(ho_Image, hv_MsrHandle_Measure, hv_Sigma, hv_Threshold,
                        hv_TransitionOut, hv_SelectOut, out hv_RowEdge, out hv_ColEdge, out hv_Amplitude,
                        out hv_Distance);
                    //清除测量对象句柄
                    HOperatorSet.CloseMeasure(hv_MsrHandle_Measure);
                    //临时变量初始化
                    //tRow，tCol保存找到指定边缘的坐标
                    hv_tRow = 0;
                    hv_tCol = 0;
                    //t保存边缘的幅度绝对值
                    hv_t = 0;
                    HOperatorSet.TupleLength(hv_RowEdge, out hv_Number);
                    //找到的边缘必须至少为1个
                    if ((int)(new HTuple(hv_Number.TupleLess(1))) != 0)
                    {
                        continue;
                    }
                    //有多个边缘时，选择幅度绝对值最大的边缘
                    HTuple end_val110 = hv_Number - 1;
                    HTuple step_val110 = 1;
                    for (hv_k = 0; hv_k.Continue(end_val110, step_val110); hv_k = hv_k.TupleAdd(step_val110))
                    {
                        if ((int)(new HTuple(((((hv_Amplitude.TupleSelect(hv_k))).TupleAbs())).TupleGreater(
                            hv_t))) != 0)
                        {

                            hv_tRow = hv_RowEdge.TupleSelect(hv_k);
                            hv_tCol = hv_ColEdge.TupleSelect(hv_k);
                            hv_t = ((hv_Amplitude.TupleSelect(hv_k))).TupleAbs();
                        }
                    }
                    //把找到的边缘保存在输出数组
                    if ((int)(new HTuple(hv_t.TupleGreater(0))) != 0)
                    {

                        hv_ResultRow = hv_ResultRow.TupleConcat(hv_tRow);
                        hv_ResultColumn = hv_ResultColumn.TupleConcat(hv_tCol);
                    }

                }

                //gen_cross_contour_xld (Cross, ResultRow, ResultColumn, 6, 0.785398)
                ho_ContCircle.Dispose();
                ho_Rectangle1.Dispose();
                ho_Arrow1.Dispose();

                return;
            }
            catch (HalconException HDevExpDefaultException)
            {
                ho_ContCircle.Dispose();
                ho_Rectangle1.Dispose();
                ho_Arrow1.Dispose();

                throw HDevExpDefaultException;
            }
        }

        public void gen_arrow_contour_xld(out HObject ho_Arrow, HTuple hv_Row1, HTuple hv_Column1,
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
        #endregion

        #region  无用代码
        //#region  刷新标定
        ///// <summary>
        ///// 刷新标定点
        ///// </summary>
        ///// <param name="ICircleShuJu_"></param>
        ///// <returns></returns>
        //public bool ShuaXinBiaoDing(ICircleShuJu ICircleShuJu_)
        //{
        //    bool ok = false;

        //    if (ICircleShuJu_.IrectShuJuPianYi != null)
        //    {
        //        ICircleShuJu_.GenSuiDian_Y_Row = ICircleShuJu_.IrectShuJuPianYi.Row;
        //        ICircleShuJu_.GeuSuiDian_X_Col = ICircleShuJu_.IrectShuJuPianYi.Column;
        //        ICircleShuJu_.GenSuiDian_A = ICircleShuJu_.IrectShuJuPianYi.Angle;
        //    }
        //    ok = true;
        //    return ok;

        //}
        //#endregion
        #endregion

    }
    #endregion

    #region  无用代码
    //#region  数据获取器
    ///// <summary>
    ///// 画圆
    ///// </summary>
    //public class DrawSpoke
    //{
    //    #region    画圆
    //    /// <summary>
    //    /// 画圆
    //    /// </summary>
    //    /// <param name="ho_Image">输入的图片</param>
    //    /// <param name="ho_Regions">输出的region</param>
    //    /// <param name="hv_WindowHandle">窗口句柄</param>
    //    /// <param name="hv_Elements">卡尺的个数</param>
    //    /// <param name="hv_DetectHeight">卡尺的高</param>
    //    /// <param name="hv_DetectWidth">卡尺的宽</param>
    //    /// <param name="hv_ROIRows">spoke工具ROI的y数组</param>
    //    /// <param name="hv_ROICols">spoke工具ROI的x数组</param>
    //    /// <param name="hv_Direct">'inner'表示检测方向由边缘点指向圆心；'outer'表示检测方向由圆心指向边缘点</param>
    //    public void draw_spoke(HObject ho_Image, out HObject ho_Regions, HWindow hv_WindowHandle,
    //  HTuple hv_Elements, HTuple hv_DetectHeight, HTuple hv_DetectWidth, out HTuple hv_ROIRows,
    //  out HTuple hv_ROICols, out HTuple hv_Direct)
    //    {
    //        // Stack for temporary objects 
    //        HObject[] OTemp = new HObject[20];

    //        // Local iconic variables 

    //        HObject ho_ContOut1, ho_Contour, ho_ContCircle;
    //        HObject ho_Cross, ho_Rectangle1 = null, ho_Arrow1 = null;

    //        // Local control variables 

    //        HTuple hv_Rows = null, hv_Cols = null, hv_Weights = null;
    //        HTuple hv_Length1 = null, hv_RowC = null, hv_ColumnC = null;
    //        HTuple hv_Radius = null, hv_StartPhi = null, hv_EndPhi = null;
    //        HTuple hv_PointOrder = null, hv_RowXLD = null, hv_ColXLD = null;
    //        HTuple hv_Row1 = null, hv_Column1 = null, hv_Row2 = null;
    //        HTuple hv_Column2 = null, hv_DistanceStart = null, hv_DistanceEnd = null;
    //        HTuple hv_Length2 = null, hv_i = null, hv_j = new HTuple();
    //        HTuple hv_RowE = new HTuple(), hv_ColE = new HTuple();
    //        HTuple hv_ATan = new HTuple(), hv_RowL2 = new HTuple();
    //        HTuple hv_RowL1 = new HTuple(), hv_ColL2 = new HTuple();
    //        HTuple hv_ColL1 = new HTuple();
    //        // Initialize local and output iconic variables 
    //        HOperatorSet.GenEmptyObj(out ho_Regions);
    //        HOperatorSet.GenEmptyObj(out ho_ContOut1);
    //        HOperatorSet.GenEmptyObj(out ho_Contour);
    //        HOperatorSet.GenEmptyObj(out ho_ContCircle);
    //        HOperatorSet.GenEmptyObj(out ho_Cross);
    //        HOperatorSet.GenEmptyObj(out ho_Rectangle1);
    //        HOperatorSet.GenEmptyObj(out ho_Arrow1);
    //        hv_ROIRows = new HTuple();
    //        hv_ROICols = new HTuple();
    //        hv_Direct = new HTuple();
    //        try
    //        {
    //            //提示
    //            disp_message(hv_WindowHandle, "1、画4个以上点确定一个圆弧,点击右键确认", "window",
    //                12, 12, "red", "false");
    //            //产生一个空显示对象，用于显示
    //            ho_Regions.Dispose();
    //            HOperatorSet.GenEmptyObj(out ho_Regions);
    //            //沿着圆弧或圆的边缘画点
    //            ho_ContOut1.Dispose();
    //            HOperatorSet.DrawNurbs(out ho_ContOut1, hv_WindowHandle, "true", "true", "true",
    //                "true", 3, out hv_Rows, out hv_Cols, out hv_Weights);
    //            //至少要4个点
    //            HOperatorSet.TupleLength(hv_Weights, out hv_Length1);
    //            if ((int)(new HTuple(hv_Length1.TupleLess(4))) != 0)
    //            {
    //                disp_message(hv_WindowHandle, "提示：点数太少，请重画", "window", 32, 12,
    //                    "red", "false");
    //                hv_ROIRows = new HTuple();
    //                hv_ROICols = new HTuple();
    //                ho_ContOut1.Dispose();
    //                ho_Contour.Dispose();
    //                ho_ContCircle.Dispose();
    //                ho_Cross.Dispose();
    //                ho_Rectangle1.Dispose();
    //                ho_Arrow1.Dispose();

    //                return;
    //            }
    //            //获取点
    //            hv_ROIRows = hv_Rows.Clone();
    //            hv_ROICols = hv_Cols.Clone();
    //            //产生xld
    //            ho_Contour.Dispose();
    //            HOperatorSet.GenContourPolygonXld(out ho_Contour, hv_ROIRows, hv_ROICols);
    //            //用回归线法（不抛出异常点，所有点权重一样）拟合圆
    //            HOperatorSet.FitCircleContourXld(ho_Contour, "algebraic", -1, 0, 0, 3, 2, out hv_RowC,
    //                out hv_ColumnC, out hv_Radius, out hv_StartPhi, out hv_EndPhi, out hv_PointOrder);
    //            //根据拟合结果产生xld，并保持到显示对象
    //            ho_ContCircle.Dispose();
    //            HOperatorSet.GenCircleContourXld(out ho_ContCircle, hv_RowC, hv_ColumnC, hv_Radius,
    //                hv_StartPhi, hv_EndPhi, hv_PointOrder, 3);
    //            {
    //                HObject ExpTmpOutVar_0;
    //                HOperatorSet.ConcatObj(ho_Regions, ho_ContCircle, out ExpTmpOutVar_0);
    //                ho_Regions.Dispose();
    //                ho_Regions = ExpTmpOutVar_0;
    //            }

    //            //获取圆或圆弧xld上的点坐标
    //            HOperatorSet.GetContourXld(ho_ContCircle, out hv_RowXLD, out hv_ColXLD);
    //            //显示图像和圆弧
    //            //if (HDevWindowStack.IsOpen())
    //            //{
    //            //HOperatorSet.DispObj(ho_Image, HDevWindowStack.GetActive());
    //            hv_WindowHandle.DispObj(ho_Image);

    //            //}
    //            //if (HDevWindowStack.IsOpen())
    //            //{
    //            //HOperatorSet.DispObj(ho_ContCircle, HDevWindowStack.GetActive());
    //            hv_WindowHandle.DispObj(ho_ContCircle);

    //            //}
    //            //产生并显示圆心
    //            ho_Cross.Dispose();
    //            HOperatorSet.GenCrossContourXld(out ho_Cross, hv_RowC, hv_ColumnC, 60, 0.785398);
    //            //if (HDevWindowStack.IsOpen())
    //            //{
    //            //HOperatorSet.DispObj(ho_Cross, HDevWindowStack.GetActive());
    //            hv_WindowHandle.DispObj(ho_Cross);

    //            //}
    //            //提示
    //            disp_message(hv_WindowHandle, "2、远离圆心，画箭头确定边缘检测方向，点击右键确认",
    //                "window", 12, 12, "red", "false");
    //            //画线，确定检测方向
    //            HOperatorSet.DrawLine(hv_WindowHandle, out hv_Row1, out hv_Column1, out hv_Row2,
    //                out hv_Column2);
    //            //求圆心到检测方向直线起点的距离
    //            HOperatorSet.DistancePp(hv_RowC, hv_ColumnC, hv_Row1, hv_Column1, out hv_DistanceStart);
    //            //求圆心到检测方向直线终点的距离
    //            HOperatorSet.DistancePp(hv_RowC, hv_ColumnC, hv_Row2, hv_Column2, out hv_DistanceEnd);

    //            //求圆或圆弧xld上的点的数量
    //            HOperatorSet.TupleLength(hv_ColXLD, out hv_Length2);
    //            //判断检测的边缘数量是否过少
    //            if ((int)(new HTuple(hv_Elements.TupleLess(3))) != 0)
    //            {
    //                hv_ROIRows = new HTuple();
    //                hv_ROICols = new HTuple();
    //                disp_message(hv_WindowHandle, "检测的边缘数量太少，请重新设置!", "window",
    //                    52, 12, "red", "false");
    //                ho_ContOut1.Dispose();
    //                ho_Contour.Dispose();
    //                ho_ContCircle.Dispose();
    //                ho_Cross.Dispose();
    //                ho_Rectangle1.Dispose();
    //                ho_Arrow1.Dispose();

    //                return;
    //            }
    //            //如果xld是圆弧，有Length2个点，从起点开始，等间距（间距为Length2/(Elements-1)）取Elements个点，作为卡尺工具的中点
    //            //如果xld是圆，有Length2个点，以0°为起点，从起点开始，等间距（间距为Length2/(Elements)）取Elements个点，作为卡尺工具的中点
    //            HTuple end_val53 = hv_Elements - 1;
    //            HTuple step_val53 = 1;
    //            for (hv_i = 0; hv_i.Continue(end_val53, step_val53); hv_i = hv_i.TupleAdd(step_val53))
    //            {

    //                if ((int)(new HTuple(((hv_RowXLD.TupleSelect(0))).TupleEqual(hv_RowXLD.TupleSelect(
    //                    hv_Length2 - 1)))) != 0)
    //                {
    //                    //xld的起点和终点坐标相对，为圆
    //                    HOperatorSet.TupleInt(((1.0 * hv_Length2) / hv_Elements) * hv_i, out hv_j);

    //                }
    //                else
    //                {
    //                    //否则为圆弧
    //                    HOperatorSet.TupleInt(((1.0 * hv_Length2) / (hv_Elements - 1)) * hv_i, out hv_j);
    //                }
    //                //索引越界，强制赋值为最后一个索引
    //                if ((int)(new HTuple(hv_j.TupleGreaterEqual(hv_Length2))) != 0)
    //                {
    //                    hv_j = hv_Length2 - 1;
    //                    //continue
    //                }
    //                //获取卡尺工具中心
    //                hv_RowE = hv_RowXLD.TupleSelect(hv_j);
    //                hv_ColE = hv_ColXLD.TupleSelect(hv_j);

    //                //如果圆心到检测方向直线的起点的距离大于圆心到检测方向直线的终点的距离，搜索方向由圆外指向圆心
    //                //如果圆心到检测方向直线的起点的距离不大于圆心到检测方向直线的终点的距离，搜索方向由圆心指向圆外
    //                if ((int)(new HTuple(hv_DistanceStart.TupleGreater(hv_DistanceEnd))) != 0)
    //                {
    //                    //求卡尺工具的边缘搜索方向
    //                    //求圆心指向边缘的矢量的角度
    //                    HOperatorSet.TupleAtan2((-hv_RowE) + hv_RowC, hv_ColE - hv_ColumnC, out hv_ATan);
    //                    //角度反向
    //                    hv_ATan = ((new HTuple(180)).TupleRad()) + hv_ATan;
    //                    //边缘搜索方向类型：'inner'搜索方向由圆外指向圆心；'outer'搜索方向由圆心指向圆外
    //                    hv_Direct = "inner";
    //                }
    //                else
    //                {
    //                    //求卡尺工具的边缘搜索方向
    //                    //求圆心指向边缘的矢量的角度
    //                    HOperatorSet.TupleAtan2((-hv_RowE) + hv_RowC, hv_ColE - hv_ColumnC, out hv_ATan);
    //                    //边缘搜索方向类型：'inner'搜索方向由圆外指向圆心；'outer'搜索方向由圆心指向圆外
    //                    hv_Direct = "outer";
    //                }

    //                //产生卡尺xld，并保持到显示对象
    //                ho_Rectangle1.Dispose();
    //                HOperatorSet.GenRectangle2ContourXld(out ho_Rectangle1, hv_RowE, hv_ColE,
    //                    hv_ATan, hv_DetectHeight / 2, hv_DetectWidth / 2);
    //                {
    //                    HObject ExpTmpOutVar_0;
    //                    HOperatorSet.ConcatObj(ho_Regions, ho_Rectangle1, out ExpTmpOutVar_0);
    //                    ho_Regions.Dispose();
    //                    ho_Regions = ExpTmpOutVar_0;
    //                }

    //                //用箭头xld指示边缘搜索方向，并保持到显示对象
    //                if ((int)(new HTuple(hv_i.TupleEqual(0))) != 0)
    //                {
    //                    hv_RowL2 = hv_RowE + ((hv_DetectHeight / 2) * (((-hv_ATan)).TupleSin()));
    //                    hv_RowL1 = hv_RowE - ((hv_DetectHeight / 2) * (((-hv_ATan)).TupleSin()));
    //                    hv_ColL2 = hv_ColE + ((hv_DetectHeight / 2) * (((-hv_ATan)).TupleCos()));
    //                    hv_ColL1 = hv_ColE - ((hv_DetectHeight / 2) * (((-hv_ATan)).TupleCos()));
    //                    ho_Arrow1.Dispose();
    //                    gen_arrow_contour_xld(out ho_Arrow1, hv_RowL1, hv_ColL1, hv_RowL2, hv_ColL2,
    //                        25, 25);
    //                    {
    //                        HObject ExpTmpOutVar_0;
    //                        HOperatorSet.ConcatObj(ho_Regions, ho_Arrow1, out ExpTmpOutVar_0);
    //                        ho_Regions.Dispose();
    //                        ho_Regions = ExpTmpOutVar_0;
    //                    }
    //                }
    //            }

    //            ho_ContOut1.Dispose();
    //            ho_Contour.Dispose();
    //            ho_ContCircle.Dispose();
    //            ho_Cross.Dispose();
    //            ho_Rectangle1.Dispose();
    //            ho_Arrow1.Dispose();

    //            return;
    //        }
    //        catch (HalconException HDevExpDefaultException)
    //        {
    //            ho_ContOut1.Dispose();
    //            ho_Contour.Dispose();
    //            ho_ContCircle.Dispose();
    //            ho_Cross.Dispose();
    //            ho_Rectangle1.Dispose();
    //            ho_Arrow1.Dispose();

    //            throw HDevExpDefaultException;
    //        }
    //    }
    //    #endregion

    //    #region   显示信息
    //    void disp_message(HTuple hv_WindowHandle, HTuple hv_String, HTuple hv_CoordSystem,
    //HTuple hv_Row, HTuple hv_Column, HTuple hv_Color, HTuple hv_Box)
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

    //    #region   得到xld
    //    void gen_arrow_contour_xld(out HObject ho_Arrow, HTuple hv_Row1, HTuple hv_Column1,
    //       HTuple hv_Row2, HTuple hv_Column2, HTuple hv_HeadLength, HTuple hv_HeadWidth)
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
    //    #endregion
    //}
    //#endregion


    //   #region  数据分析器
    //   /// <summary>
    //   /// 拟合圆工具
    //   /// </summary>
    //   public class Circle : MultTree.ToolFather
    //   {
    //       //#region 标定
    //       ///// <summary>
    //       ///// 标定
    //       ///// </summary>
    //       //Calibration _Cal = new Calibration();
    //       //#endregion

    //       #region   卡尺圆工具
    //       /// <summary>
    //       /// 卡尺圆工具
    //       /// </summary>
    //       /// <param name="ICircle_"></param>
    //       /// <param name="ho_Image"></param>
    //       /// <returns></returns>
    //       public bool Spoke(ICircleShuJu ICircle_, HObject ho_Image)
    //       {
    //           bool ok = false;

    //           HTuple hv_modMat2D;
    //           HTuple hv_Center_X, hv_Center_Y;
    //           if (ICircle_.IrectShuJuPianYi != null)
    //           {
    //               HObject hv_Cirle;
    //               HTuple Area_, Column_, Row_;
    //               HOperatorSet.GenEmptyObj(out hv_Cirle);
    //               HOperatorSet.VectorAngleToRigid(ICircle_.GenSuiDian_Y_Row, ICircle_.GeuSuiDian_X_Col, ICircle_.GenSuiDian_A, ICircle_.IrectShuJuPianYi.Row, ICircle_.IrectShuJuPianYi.Column, ICircle_.IrectShuJuPianYi.Angle, out hv_modMat2D);
    //               HOperatorSet.GenCircle(out hv_Cirle, ICircle_.IOutSide.Center_row_y, ICircle_.IOutSide.Center_column_x, ICircle_.IOutSide.Radius);
    //               HOperatorSet.AffineTransRegion(hv_Cirle, out hv_Cirle, hv_modMat2D, "nearest_neighbor");
    //               HOperatorSet.AreaCenter(hv_Cirle, out Area_, out Row_, out Column_);
    //               hv_Cirle.Dispose();
    //               hv_Center_X = Column_;
    //               hv_Center_Y = Row_;
    //           }
    //           else
    //           {
    //               hv_Center_X = ICircle_.IOutSide.Center_column_x;
    //               hv_Center_Y = ICircle_.IOutSide.Center_row_y;
    //           }

    //           HObject ho_Regions, ho_cross;
    //           HOperatorSet.GenEmptyObj(out ho_Regions);
    //           HOperatorSet.GenEmptyObj(out ho_cross);
    //           HTuple Resultrow, Resultcolumn, ResultArcType;
    //           spoke2(ho_Image, out ho_Regions, hv_Center_Y, hv_Center_X, ICircle_.IOutSide.Radius, ICircle_.Hv_StartPhi, ICircle_.Hv_EndPh, ICircle_.Hv_Elements, ICircle_.Hv_Direct, ICircle_.Hv_DetectHeight, ICircle_.Hv_DetectWidth, ICircle_.Hv_Transition, ICircle_.Hv_Select, ICircle_.Hv_Sigma, ICircle_.Hv_Threshold, out Resultrow, out Resultcolumn, out ResultArcType);

    //           HOperatorSet.GenCrossContourXld(out ho_cross, Resultrow, Resultcolumn, 6, 0.785398);

    //           ICircle_.Ho_Regions.Dispose();
    //           ICircle_.Ho_Regions = ho_cross;

    //           ICircle_.Hv_ResultColumn = Resultcolumn;
    //           ICircle_.Hv_ResultRow = Resultrow;
    //           ICircle_.Hv_ArcType = ResultArcType;
    //           ICircle_.Ho_Regions_0.Dispose();
    //           ICircle_.Ho_Regions_0 = ho_Regions;

    //           HObject ho_Circle;
    //           HOperatorSet.GenEmptyObj(out ho_Circle);
    //           ho_Circle.Dispose();

    //           HTuple hv_RowCenter, hv_ColCenter, hv_Radius, hv_StartPhi, hv_EndPhi, hv_PointOrder, hv_ArcAngle;
    //           pts_to_best_circle(out ho_Circle, ICircle_.Hv_ResultRow, ICircle_.Hv_ResultColumn, ICircle_.Hv_ActiveNum, ICircle_.Hv_ArcType, out hv_RowCenter, out hv_ColCenter, out hv_Radius, out hv_StartPhi, out hv_EndPhi, out hv_PointOrder, out hv_ArcAngle);

    //           ICircle_.Ho_Circle.Dispose();
    //           ICircle_.Ho_Circle = ho_Circle;
    //           ICircle_.Row = hv_RowCenter;
    //           ICircle_.Column = hv_ColCenter;
    //           ICircle_.Hv_PointOrder = hv_PointOrder;
    //           ICircle_.Angle = hv_ArcAngle;

    //           ok = true;
    //           return ok;
    //       }

    //       #region  圆的卡尺工具
    //       #region   无用代码
    //       //     /// <summary>
    //       //     /// 圆的卡尺工具
    //       //     /// </summary>
    //       //     /// <param name="ho_Image">输入图像</param>
    //       //     /// <param name="ho_Regions">输出边缘点检测区域及方向</param>
    //       //     /// <param name="hv_Elements">检测边缘点数</param>
    //       //     /// <param name="hv_DetectHeight">卡尺工具的高度</param>
    //       //     /// <param name="hv_DetectWidth">卡尺工具的宽度</param>
    //       //     /// <param name="hv_Sigma">高斯滤波因子</param>
    //       //     /// <param name="hv_Threshold">边缘幅度阈值</param>
    //       //     /// <param name="hv_Transition">极性：  positive表示由黑到白   negative表示由白到黑   all表示以上两种方向</param>
    //       //     /// <param name="hv_Select">first表示选择第一点    last表示选择最后一点   max表示选择边缘强度最强点</param>
    //       //     /// <param name="hv_ROIRows">检测区域起点的y值</param>
    //       //     /// <param name="hv_ROICols">检测区域起点的x值</param>
    //       //     /// <param name="hv_Direct">'inner'表示检测方向由边缘点指向圆心;'outer'表示检测方向由圆心指向边缘点</param>
    //       //     /// <param name="hv_ResultRow">检测到的边缘点的y坐标数组</param>
    //       //     /// <param name="hv_ResultColumn">检测到的边缘点的x坐标数组</param>
    //       //     /// <param name="hv_ArcType">拟合圆弧类型：'arc'圆弧；'circle'圆</param>
    //       //     void spoke(HObject ho_Image, out HObject ho_Regions, HTuple hv_Elements,
    //       //HTuple hv_DetectHeight, HTuple hv_DetectWidth, HTuple hv_Sigma, HTuple hv_Threshold,
    //       //HTuple hv_Transition, HTuple hv_Select, HTuple hv_ROIRows, HTuple hv_ROICols,
    //       //HTuple hv_Direct, out HTuple hv_ResultRow, out HTuple hv_ResultColumn, out HTuple hv_ArcType)
    //       //     {
    //       //         // Stack for temporary objects 
    //       //         HObject[] OTemp = new HObject[20];
    //       //         // Local iconic variables
    //       //         HObject ho_Contour, ho_ContCircle, ho_Rectangle1 = null;
    //       //         HObject ho_Arrow1 = null;
    //       //         // Local control variables 
    //       //         HTuple hv_Width = null, hv_Height = null, hv_RowC = null;
    //       //         HTuple hv_ColumnC = null, hv_Radius = null, hv_StartPhi = null;
    //       //         HTuple hv_EndPhi = null, hv_PointOrder = null, hv_RowXLD = null;
    //       //         HTuple hv_ColXLD = null, hv_Length2 = null, hv_i = null;
    //       //         HTuple hv_j = new HTuple(), hv_RowE = new HTuple(), hv_ColE = new HTuple();
    //       //         HTuple hv_ATan = new HTuple(), hv_RowL2 = new HTuple();
    //       //         HTuple hv_RowL1 = new HTuple(), hv_ColL2 = new HTuple();
    //       //         HTuple hv_ColL1 = new HTuple(), hv_MsrHandle_Measure = new HTuple();
    //       //         HTuple hv_RowEdge = new HTuple(), hv_ColEdge = new HTuple();
    //       //         HTuple hv_Amplitude = new HTuple(), hv_Distance = new HTuple();
    //       //         HTuple hv_tRow = new HTuple(), hv_tCol = new HTuple();
    //       //         HTuple hv_t = new HTuple(), hv_Number = new HTuple(), hv_k = new HTuple();
    //       //         HTuple hv_Select_COPY_INP_TMP = hv_Select.Clone();
    //       //         HTuple hv_Transition_COPY_INP_TMP = hv_Transition.Clone();
    //       //         // Initialize local and output iconic variables 
    //       //         HOperatorSet.GenEmptyObj(out ho_Regions);
    //       //         HOperatorSet.GenEmptyObj(out ho_Contour);
    //       //         HOperatorSet.GenEmptyObj(out ho_ContCircle);
    //       //         HOperatorSet.GenEmptyObj(out ho_Rectangle1);
    //       //         HOperatorSet.GenEmptyObj(out ho_Arrow1);
    //       //         hv_ArcType = new HTuple();
    //       //         try
    //       //         {
    //       //             //获取图像尺寸
    //       //             HOperatorSet.GetImageSize(ho_Image, out hv_Width, out hv_Height);
    //       //             //产生一个空显示对象，用于显示
    //       //             ho_Regions.Dispose();
    //       //             HOperatorSet.GenEmptyObj(out ho_Regions);
    //       //             //初始化边缘坐标数组
    //       //             hv_ResultRow = new HTuple();
    //       //             hv_ResultColumn = new HTuple();

    //       //             //产生xld
    //       //             ho_Contour.Dispose();
    //       //             HOperatorSet.GenContourPolygonXld(out ho_Contour, hv_ROIRows, hv_ROICols);
    //       //             //用回归线法（不抛出异常点，所有点权重一样）拟合圆
    //       //             HOperatorSet.FitCircleContourXld(ho_Contour, "algebraic", -1, 0, 0, 1, 2, out hv_RowC,
    //       //                 out hv_ColumnC, out hv_Radius, out hv_StartPhi, out hv_EndPhi, out hv_PointOrder);
    //       //             //根据拟合结果产生xld，并保持到显示对象
    //       //             ho_ContCircle.Dispose();
    //       //             HOperatorSet.GenCircleContourXld(out ho_ContCircle, hv_RowC, hv_ColumnC, hv_Radius,
    //       //                 hv_StartPhi, hv_EndPhi, hv_PointOrder, 3);
    //       //             {
    //       //                 HObject ExpTmpOutVar_0;
    //       //                 HOperatorSet.ConcatObj(ho_Regions, ho_ContCircle, out ExpTmpOutVar_0);
    //       //                 ho_Regions.Dispose();
    //       //                 ho_Regions = ExpTmpOutVar_0;
    //       //             }
    //       //             //获取圆或圆弧xld上的点坐标
    //       //             HOperatorSet.GetContourXld(ho_ContCircle, out hv_RowXLD, out hv_ColXLD);

    //       //             //求圆或圆弧xld上的点的数量
    //       //             HOperatorSet.TupleLength(hv_ColXLD, out hv_Length2);
    //       //             if ((int)(new HTuple(hv_Elements.TupleLess(3))) != 0)
    //       //             {
    //       //                 //    disp_message (WindowHandle, '检测的边缘数量太少，请重新设置!', 'window', 52, 12, 'red', 'false')
    //       //                 ho_Contour.Dispose();
    //       //                 ho_ContCircle.Dispose();
    //       //                 ho_Rectangle1.Dispose();
    //       //                 ho_Arrow1.Dispose();

    //       //                 return;
    //       //             }
    //       //             //如果xld是圆弧，有Length2个点，从起点开始，等间距（间距为Length2/(Elements-1)）取Elements个点，作为卡尺工具的中点
    //       //             //如果xld是圆，有Length2个点，以0°为起点，从起点开始，等间距（间距为Length2/(Elements)）取Elements个点，作为卡尺工具的中点
    //       //             HTuple end_val27 = hv_Elements - 1;
    //       //             HTuple step_val27 = 1;
    //       //             for (hv_i = 0; hv_i.Continue(end_val27, step_val27); hv_i = hv_i.TupleAdd(step_val27))
    //       //             {

    //       //                 if ((int)(new HTuple(((hv_RowXLD.TupleSelect(0))).TupleEqual(hv_RowXLD.TupleSelect(
    //       //                     hv_Length2 - 1)))) != 0)
    //       //                 {
    //       //                     //xld的起点和终点坐标相对，为圆
    //       //                     HOperatorSet.TupleInt(((1.0 * hv_Length2) / hv_Elements) * hv_i, out hv_j);
    //       //                     hv_ArcType = "circle";
    //       //                 }
    //       //                 else
    //       //                 {
    //       //                     //否则为圆弧
    //       //                     HOperatorSet.TupleInt(((1.0 * hv_Length2) / (hv_Elements - 1)) * hv_i, out hv_j);
    //       //                     hv_ArcType = "arc";
    //       //                 }
    //       //                 //索引越界，强制赋值为最后一个索引
    //       //                 if ((int)(new HTuple(hv_j.TupleGreaterEqual(hv_Length2))) != 0)
    //       //                 {
    //       //                     hv_j = hv_Length2 - 1;
    //       //                     //continue
    //       //                 }
    //       //                 //获取卡尺工具中心
    //       //                 hv_RowE = hv_RowXLD.TupleSelect(hv_j);
    //       //                 hv_ColE = hv_ColXLD.TupleSelect(hv_j);

    //       //                 //超出图像区域，不检测，否则容易报异常
    //       //                 if ((int)((new HTuple((new HTuple((new HTuple(hv_RowE.TupleGreater(hv_Height - 1))).TupleOr(
    //       //                     new HTuple(hv_RowE.TupleLess(0))))).TupleOr(new HTuple(hv_ColE.TupleGreater(
    //       //                     hv_Width - 1))))).TupleOr(new HTuple(hv_ColE.TupleLess(0)))) != 0)
    //       //                 {
    //       //                     continue;
    //       //                 }
    //       //                 //边缘搜索方向类型：'inner'搜索方向由圆外指向圆心；'outer'搜索方向由圆心指向圆外
    //       //                 if ((int)(new HTuple(hv_Direct.TupleEqual("inner"))) != 0)
    //       //                 {
    //       //                     //求卡尺工具的边缘搜索方向
    //       //                     //求圆心指向边缘的矢量的角度
    //       //                     HOperatorSet.TupleAtan2((-hv_RowE) + hv_RowC, hv_ColE - hv_ColumnC, out hv_ATan);
    //       //                     //角度反向
    //       //                     hv_ATan = ((new HTuple(180)).TupleRad()) + hv_ATan;
    //       //                 }
    //       //                 else
    //       //                 {
    //       //                     //求卡尺工具的边缘搜索方向
    //       //                     //求圆心指向边缘的矢量的角度
    //       //                     HOperatorSet.TupleAtan2((-hv_RowE) + hv_RowC, hv_ColE - hv_ColumnC, out hv_ATan);
    //       //                 }


    //       //                 //产生卡尺xld，并保持到显示对象
    //       //                 ho_Rectangle1.Dispose();
    //       //                 HOperatorSet.GenRectangle2ContourXld(out ho_Rectangle1, hv_RowE, hv_ColE,
    //       //                     hv_ATan, hv_DetectHeight / 2, hv_DetectWidth / 2);
    //       //                 {
    //       //                     HObject ExpTmpOutVar_0;
    //       //                     HOperatorSet.ConcatObj(ho_Regions, ho_Rectangle1, out ExpTmpOutVar_0);
    //       //                     ho_Regions.Dispose();
    //       //                     ho_Regions = ExpTmpOutVar_0;
    //       //                 }
    //       //                 //用箭头xld指示边缘搜索方向，并保持到显示对象
    //       //                 if ((int)(new HTuple(hv_i.TupleEqual(0))) != 0)
    //       //                 {
    //       //                     hv_RowL2 = hv_RowE + ((hv_DetectHeight / 2) * (((-hv_ATan)).TupleSin()));
    //       //                     hv_RowL1 = hv_RowE - ((hv_DetectHeight / 2) * (((-hv_ATan)).TupleSin()));
    //       //                     hv_ColL2 = hv_ColE + ((hv_DetectHeight / 2) * (((-hv_ATan)).TupleCos()));
    //       //                     hv_ColL1 = hv_ColE - ((hv_DetectHeight / 2) * (((-hv_ATan)).TupleCos()));
    //       //                     ho_Arrow1.Dispose();
    //       //                     gen_arrow_contour_xld(out ho_Arrow1, hv_RowL1, hv_ColL1, hv_RowL2, hv_ColL2,
    //       //                         25, 25);
    //       //                     {
    //       //                         HObject ExpTmpOutVar_0;
    //       //                         HOperatorSet.ConcatObj(ho_Regions, ho_Arrow1, out ExpTmpOutVar_0);
    //       //                         ho_Regions.Dispose();
    //       //                         ho_Regions = ExpTmpOutVar_0;
    //       //                     }
    //       //                 }


    //       //                 //产生测量对象句柄
    //       //                 HOperatorSet.GenMeasureRectangle2(hv_RowE, hv_ColE, hv_ATan, hv_DetectHeight / 2,
    //       //                     hv_DetectWidth / 2, hv_Width, hv_Height, "nearest_neighbor", out hv_MsrHandle_Measure);

    //       //                 //设置极性
    //       //                 if ((int)(new HTuple(hv_Transition_COPY_INP_TMP.TupleEqual("negative"))) != 0)
    //       //                 {
    //       //                     hv_Transition_COPY_INP_TMP = "negative";
    //       //                 }
    //       //                 else
    //       //                 {
    //       //                     if ((int)(new HTuple(hv_Transition_COPY_INP_TMP.TupleEqual("positive"))) != 0)
    //       //                     {

    //       //                         hv_Transition_COPY_INP_TMP = "positive";
    //       //                     }
    //       //                     else
    //       //                     {
    //       //                         hv_Transition_COPY_INP_TMP = "all";
    //       //                     }
    //       //                 }
    //       //                 //设置边缘位置。最强点是从所有边缘中选择幅度绝对值最大点，需要设置为'all'
    //       //                 if ((int)(new HTuple(hv_Select_COPY_INP_TMP.TupleEqual("first"))) != 0)
    //       //                 {
    //       //                     hv_Select_COPY_INP_TMP = "first";
    //       //                 }
    //       //                 else
    //       //                 {
    //       //                     if ((int)(new HTuple(hv_Select_COPY_INP_TMP.TupleEqual("last"))) != 0)
    //       //                     {

    //       //                         hv_Select_COPY_INP_TMP = "last";
    //       //                     }
    //       //                     else
    //       //                     {
    //       //                         hv_Select_COPY_INP_TMP = "all";
    //       //                     }
    //       //                 }
    //       //                 //检测边缘
    //       //                 HOperatorSet.MeasurePos(ho_Image, hv_MsrHandle_Measure, hv_Sigma, hv_Threshold,
    //       //                     hv_Transition_COPY_INP_TMP, hv_Select_COPY_INP_TMP, out hv_RowEdge, out hv_ColEdge,
    //       //                     out hv_Amplitude, out hv_Distance);
    //       //                 //清除测量对象句柄
    //       //                 HOperatorSet.CloseMeasure(hv_MsrHandle_Measure);
    //       //                 //临时变量初始化
    //       //                 //tRow，tCol保存找到指定边缘的坐标
    //       //                 hv_tRow = 0;
    //       //                 hv_tCol = 0;
    //       //                 //t保存边缘的幅度绝对值
    //       //                 hv_t = 0;
    //       //                 HOperatorSet.TupleLength(hv_RowEdge, out hv_Number);
    //       //                 //找到的边缘必须至少为1个
    //       //                 if ((int)(new HTuple(hv_Number.TupleLess(1))) != 0)
    //       //                 {
    //       //                     continue;
    //       //                 }
    //       //                 //有多个边缘时，选择幅度绝对值最大的边缘
    //       //                 HTuple end_val120 = hv_Number - 1;
    //       //                 HTuple step_val120 = 1;
    //       //                 for (hv_k = 0; hv_k.Continue(end_val120, step_val120); hv_k = hv_k.TupleAdd(step_val120))
    //       //                 {
    //       //                     if ((int)(new HTuple(((((hv_Amplitude.TupleSelect(hv_k))).TupleAbs())).TupleGreater(
    //       //                         hv_t))) != 0)
    //       //                     {

    //       //                         hv_tRow = hv_RowEdge.TupleSelect(hv_k);
    //       //                         hv_tCol = hv_ColEdge.TupleSelect(hv_k);
    //       //                         hv_t = ((hv_Amplitude.TupleSelect(hv_k))).TupleAbs();
    //       //                     }
    //       //                 }
    //       //                 //把找到的边缘保存在输出数组
    //       //                 if ((int)(new HTuple(hv_t.TupleGreater(0))) != 0)
    //       //                 {

    //       //                     hv_ResultRow = hv_ResultRow.TupleConcat(hv_tRow);
    //       //                     hv_ResultColumn = hv_ResultColumn.TupleConcat(hv_tCol);
    //       //                 }
    //       //             }


    //       //             ho_Contour.Dispose();
    //       //             ho_ContCircle.Dispose();
    //       //             ho_Rectangle1.Dispose();
    //       //             ho_Arrow1.Dispose();

    //       //             return;
    //       //         }
    //       //         catch (HalconException HDevExpDefaultException)
    //       //         {
    //       //             ho_Contour.Dispose();
    //       //             ho_ContCircle.Dispose();
    //       //             ho_Rectangle1.Dispose();
    //       //             ho_Arrow1.Dispose();

    //       //             throw HDevExpDefaultException;
    //       //         }
    //       //     }
    //       //    void spoke(HObject ho_Image, out HObject ho_Regions, HTuple hv_yuanDian_y,
    //       //HTuple hv_yuanDian_x, HTuple hv_r, HTuple hv_Elements, HTuple hv_Direct, HTuple hv_DetectHeight,
    //       //HTuple hv_DetectWidth, HTuple hv_Transition, HTuple hv_Select, HTuple hv_Sigma,
    //       //HTuple hv_Threshold, out HTuple hv_ResultRow, out HTuple hv_ResultColumn, out HTuple hv_ArcType)
    //       //    {
    //       //        // Stack for temporary objects 
    //       //        HObject[] OTemp = new HObject[20];

    //       //        // Local iconic variables 

    //       //        HObject ho_ContCircle, ho_Rectangle1 = null;
    //       //        HObject ho_Arrow1 = null, ho_Cross;

    //       //        // Local control variables 

    //       //        HTuple hv_SelectOut = null, hv_TransitionOut = null;
    //       //        HTuple hv_Width = null, hv_Height = null, hv_RowXLD = null;
    //       //        HTuple hv_ColXLD = null, hv_Length2 = null, hv_i = null;
    //       //        HTuple hv_j = new HTuple(), hv_RowE = new HTuple(), hv_ColE = new HTuple();
    //       //        HTuple hv_ATan = new HTuple(), hv_RowL2 = new HTuple();
    //       //        HTuple hv_RowL1 = new HTuple(), hv_ColL2 = new HTuple();
    //       //        HTuple hv_ColL1 = new HTuple(), hv_MsrHandle_Measure = new HTuple();
    //       //        HTuple hv_RowEdge = new HTuple(), hv_ColEdge = new HTuple();
    //       //        HTuple hv_Amplitude = new HTuple(), hv_Distance = new HTuple();
    //       //        HTuple hv_tRow = new HTuple(), hv_tCol = new HTuple();
    //       //        HTuple hv_t = new HTuple(), hv_Number = new HTuple(), hv_k = new HTuple();
    //       //        // Initialize local and output iconic variables 
    //       //        HOperatorSet.GenEmptyObj(out ho_Regions);
    //       //        HOperatorSet.GenEmptyObj(out ho_ContCircle);
    //       //        HOperatorSet.GenEmptyObj(out ho_Rectangle1);
    //       //        HOperatorSet.GenEmptyObj(out ho_Arrow1);
    //       //        HOperatorSet.GenEmptyObj(out ho_Cross);
    //       //        hv_ArcType = new HTuple();
    //       //        try
    //       //        {
    //       //            hv_SelectOut = hv_Select.Clone();
    //       //            hv_TransitionOut = hv_Transition.Clone();
    //       //            //获取图像尺寸
    //       //            HOperatorSet.GetImageSize(ho_Image, out hv_Width, out hv_Height);

    //       //            //产生一个空显示对象，用于显示
    //       //            ho_Regions.Dispose();
    //       //            HOperatorSet.GenEmptyObj(out ho_Regions);

    //       //            //初始化边缘坐标数组
    //       //            hv_ResultRow = new HTuple();
    //       //            hv_ResultColumn = new HTuple();

    //       //            ho_ContCircle.Dispose();
    //       //            HOperatorSet.GenCircleContourXld(out ho_ContCircle, hv_yuanDian_y, hv_yuanDian_x,
    //       //                hv_r, 0, (new HTuple(360)).TupleRad(), "positive", 1);

    //       //            //获取圆或圆弧xld上的点坐标
    //       //            HOperatorSet.GetContourXld(ho_ContCircle, out hv_RowXLD, out hv_ColXLD);

    //       //            //求圆或圆弧xld上的点的数量
    //       //            HOperatorSet.TupleLength(hv_ColXLD, out hv_Length2);

    //       //            HTuple end_val20 = hv_Elements - 1;
    //       //            HTuple step_val20 = 1;
    //       //            for (hv_i = 0; hv_i.Continue(end_val20, step_val20); hv_i = hv_i.TupleAdd(step_val20))
    //       //            {

    //       //                //xld的起点和终点坐标相对，为圆
    //       //                HOperatorSet.TupleInt(((1.0 * hv_Length2) / hv_Elements) * hv_i, out hv_j);
    //       //                hv_ArcType = "circle";

    //       //                //索引越界，强制赋值为最后一个索引
    //       //                if ((int)(new HTuple(hv_j.TupleGreaterEqual(hv_Length2))) != 0)
    //       //                {
    //       //                    hv_j = hv_Length2 - 1;
    //       //                    //continue
    //       //                }

    //       //                //获取卡尺工具中心
    //       //                hv_RowE = hv_RowXLD.TupleSelect(hv_j);
    //       //                hv_ColE = hv_ColXLD.TupleSelect(hv_j);

    //       //                //超出图像区域，不检测，否则容易报异常
    //       //                if ((int)((new HTuple((new HTuple((new HTuple(hv_RowE.TupleGreater(hv_Height - 1))).TupleOr(
    //       //                    new HTuple(hv_RowE.TupleLess(0))))).TupleOr(new HTuple(hv_ColE.TupleGreater(
    //       //                    hv_Width - 1))))).TupleOr(new HTuple(hv_ColE.TupleLess(0)))) != 0)
    //       //                {
    //       //                    continue;
    //       //                }

    //       //                //边缘搜索方向类型：'inner'搜索方向由圆外指向圆心；'outer'搜索方向由圆心指向圆外
    //       //                if ((int)(new HTuple(hv_Direct.TupleEqual("inner"))) != 0)
    //       //                {
    //       //                    //求卡尺工具的边缘搜索方向
    //       //                    //求圆心指向边缘的矢量的角度
    //       //                    HOperatorSet.TupleAtan2((-hv_RowE) + hv_yuanDian_y, hv_ColE - hv_yuanDian_x,
    //       //                        out hv_ATan);
    //       //                    //角度反向
    //       //                    hv_ATan = ((new HTuple(180)).TupleRad()) + hv_ATan;
    //       //                }
    //       //                else
    //       //                {
    //       //                    //求卡尺工具的边缘搜索方向
    //       //                    //求圆心指向边缘的矢量的角度
    //       //                    HOperatorSet.TupleAtan2((-hv_RowE) + hv_yuanDian_y, hv_ColE - hv_yuanDian_x,
    //       //                        out hv_ATan);
    //       //                }


    //       //                //产生卡尺xld，并保持到显示对象
    //       //                ho_Rectangle1.Dispose();
    //       //                HOperatorSet.GenRectangle2ContourXld(out ho_Rectangle1, hv_RowE, hv_ColE,
    //       //                    hv_ATan, hv_DetectHeight / 2, hv_DetectWidth / 2);
    //       //                {
    //       //                    HObject ExpTmpOutVar_0;
    //       //                    HOperatorSet.ConcatObj(ho_Regions, ho_Rectangle1, out ExpTmpOutVar_0);
    //       //                    ho_Regions.Dispose();
    //       //                    ho_Regions = ExpTmpOutVar_0;
    //       //                }
    //       //                //用箭头xld指示边缘搜索方向，并保持到显示对象
    //       //                if ((int)(new HTuple(hv_i.TupleEqual(0))) != 0)
    //       //                {
    //       //                    hv_RowL2 = hv_RowE + ((hv_DetectHeight / 2) * (((-hv_ATan)).TupleSin()));
    //       //                    hv_RowL1 = hv_RowE - ((hv_DetectHeight / 2) * (((-hv_ATan)).TupleSin()));
    //       //                    hv_ColL2 = hv_ColE + ((hv_DetectHeight / 2) * (((-hv_ATan)).TupleCos()));
    //       //                    hv_ColL1 = hv_ColE - ((hv_DetectHeight / 2) * (((-hv_ATan)).TupleCos()));
    //       //                    ho_Arrow1.Dispose();
    //       //                    gen_arrow_contour_xld(out ho_Arrow1, hv_RowL1, hv_ColL1, hv_RowL2, hv_ColL2,
    //       //                        25, 25);
    //       //                    {
    //       //                        HObject ExpTmpOutVar_0;
    //       //                        HOperatorSet.ConcatObj(ho_Regions, ho_Arrow1, out ExpTmpOutVar_0);
    //       //                        ho_Regions.Dispose();
    //       //                        ho_Regions = ExpTmpOutVar_0;
    //       //                    }
    //       //                }

    //       //                //产生测量对象句柄
    //       //                HOperatorSet.GenMeasureRectangle2(hv_RowE, hv_ColE, hv_ATan, hv_DetectHeight / 2,
    //       //                    hv_DetectWidth / 2, hv_Width, hv_Height, "nearest_neighbor", out hv_MsrHandle_Measure);


    //       //                //设置极性
    //       //                if ((int)(new HTuple(hv_TransitionOut.TupleEqual("negative"))) != 0)
    //       //                {
    //       //                    hv_TransitionOut = "negative";
    //       //                }
    //       //                else
    //       //                {
    //       //                    if ((int)(new HTuple(hv_TransitionOut.TupleEqual("positive"))) != 0)
    //       //                    {

    //       //                        hv_TransitionOut = "positive";
    //       //                    }
    //       //                    else
    //       //                    {
    //       //                        hv_TransitionOut = "all";
    //       //                    }
    //       //                }
    //       //                //设置边缘位置。最强点是从所有边缘中选择幅度绝对值最大点，需要设置为'all'
    //       //                if ((int)(new HTuple(hv_SelectOut.TupleEqual("first"))) != 0)
    //       //                {
    //       //                    hv_SelectOut = "first";
    //       //                }
    //       //                else
    //       //                {
    //       //                    if ((int)(new HTuple(hv_SelectOut.TupleEqual("last"))) != 0)
    //       //                    {

    //       //                        hv_SelectOut = "last";
    //       //                    }
    //       //                    else
    //       //                    {
    //       //                        hv_SelectOut = "all";
    //       //                    }
    //       //                }
    //       //                //检测边缘
    //       //                HOperatorSet.MeasurePos(ho_Image, hv_MsrHandle_Measure, hv_Sigma, hv_Threshold,
    //       //                    hv_TransitionOut, hv_SelectOut, out hv_RowEdge, out hv_ColEdge, out hv_Amplitude,
    //       //                    out hv_Distance);
    //       //                //清除测量对象句柄
    //       //                HOperatorSet.CloseMeasure(hv_MsrHandle_Measure);
    //       //                //临时变量初始化
    //       //                //tRow，tCol保存找到指定边缘的坐标
    //       //                hv_tRow = 0;
    //       //                hv_tCol = 0;
    //       //                //t保存边缘的幅度绝对值
    //       //                hv_t = 0;
    //       //                HOperatorSet.TupleLength(hv_RowEdge, out hv_Number);
    //       //                //找到的边缘必须至少为1个
    //       //                if ((int)(new HTuple(hv_Number.TupleLess(1))) != 0)
    //       //                {
    //       //                    continue;
    //       //                }
    //       //                //有多个边缘时，选择幅度绝对值最大的边缘
    //       //                HTuple end_val110 = hv_Number - 1;
    //       //                HTuple step_val110 = 1;
    //       //                for (hv_k = 0; hv_k.Continue(end_val110, step_val110); hv_k = hv_k.TupleAdd(step_val110))
    //       //                {
    //       //                    if ((int)(new HTuple(((((hv_Amplitude.TupleSelect(hv_k))).TupleAbs())).TupleGreater(
    //       //                        hv_t))) != 0)
    //       //                    {

    //       //                        hv_tRow = hv_RowEdge.TupleSelect(hv_k);
    //       //                        hv_tCol = hv_ColEdge.TupleSelect(hv_k);
    //       //                        hv_t = ((hv_Amplitude.TupleSelect(hv_k))).TupleAbs();
    //       //                    }
    //       //                }
    //       //                //把找到的边缘保存在输出数组
    //       //                if ((int)(new HTuple(hv_t.TupleGreater(0))) != 0)
    //       //                {

    //       //                    hv_ResultRow = hv_ResultRow.TupleConcat(hv_tRow);
    //       //                    hv_ResultColumn = hv_ResultColumn.TupleConcat(hv_tCol);
    //       //                }

    //       //            }

    //       //            ho_Cross.Dispose();
    //       //            HOperatorSet.GenCrossContourXld(out ho_Cross, hv_ResultRow, hv_ResultColumn,
    //       //                6, 0.785398);
    //       //            ho_ContCircle.Dispose();
    //       //            ho_Rectangle1.Dispose();
    //       //            ho_Arrow1.Dispose();
    //       //            ho_Cross.Dispose();

    //       //            return;
    //       //        }
    //       //        catch (HalconException HDevExpDefaultException)
    //       //        {
    //       //            ho_ContCircle.Dispose();
    //       //            ho_Rectangle1.Dispose();
    //       //            ho_Arrow1.Dispose();
    //       //            ho_Cross.Dispose();

    //       //            throw HDevExpDefaultException;
    //       //        }
    //       //    }
    //       #endregion

    //       void spoke2(HObject ho_Image, out HObject ho_Regions, HTuple hv_yuanDian_y,
    //HTuple hv_yuanDian_x, HTuple hv_r, HTuple hv_startJiao, HTuple hv_endJiao, HTuple hv_Elements,
    //HTuple hv_Direct, HTuple hv_DetectHeight, HTuple hv_DetectWidth, HTuple hv_Transition,
    //HTuple hv_Select, HTuple hv_Sigma, HTuple hv_Threshold, out HTuple hv_ResultRow,
    //out HTuple hv_ResultColumn, out HTuple hv_ArcType)
    //       {
    //           // Stack for temporary objects 
    //           HObject[] OTemp = new HObject[20];

    //           // Local iconic variables 

    //           HObject ho_ContCircle, ho_Rectangle1 = null;
    //           HObject ho_Arrow1 = null;

    //           // Local control variables 

    //           HTuple hv_SelectOut = null, hv_TransitionOut = null;
    //           HTuple hv_Width = null, hv_Height = null, hv_RowXLD = null;
    //           HTuple hv_ColXLD = null, hv_Length2 = null, hv_i = null;
    //           HTuple hv_j = new HTuple(), hv_RowE = new HTuple(), hv_ColE = new HTuple();
    //           HTuple hv_ATan = new HTuple(), hv_RowL2 = new HTuple();
    //           HTuple hv_RowL1 = new HTuple(), hv_ColL2 = new HTuple();
    //           HTuple hv_ColL1 = new HTuple(), hv_MsrHandle_Measure = new HTuple();
    //           HTuple hv_RowEdge = new HTuple(), hv_ColEdge = new HTuple();
    //           HTuple hv_Amplitude = new HTuple(), hv_Distance = new HTuple();
    //           HTuple hv_tRow = new HTuple(), hv_tCol = new HTuple();
    //           HTuple hv_t = new HTuple(), hv_Number = new HTuple(), hv_k = new HTuple();
    //           // Initialize local and output iconic variables 
    //           HOperatorSet.GenEmptyObj(out ho_Regions);
    //           HOperatorSet.GenEmptyObj(out ho_ContCircle);
    //           HOperatorSet.GenEmptyObj(out ho_Rectangle1);
    //           HOperatorSet.GenEmptyObj(out ho_Arrow1);
    //           hv_ArcType = new HTuple();
    //           try
    //           {
    //               hv_SelectOut = hv_Select.Clone();
    //               hv_TransitionOut = hv_Transition.Clone();
    //               //获取图像尺寸
    //               HOperatorSet.GetImageSize(ho_Image, out hv_Width, out hv_Height);

    //               //产生一个空显示对象，用于显示
    //               ho_Regions.Dispose();
    //               HOperatorSet.GenEmptyObj(out ho_Regions);

    //               //初始化边缘坐标数组
    //               hv_ResultRow = new HTuple();
    //               hv_ResultColumn = new HTuple();

    //               ho_ContCircle.Dispose();
    //               HOperatorSet.GenCircleContourXld(out ho_ContCircle, hv_yuanDian_y, hv_yuanDian_x,
    //                   hv_r, hv_startJiao, hv_endJiao, "positive", 1);

    //               //获取圆或圆弧xld上的点坐标
    //               HOperatorSet.GetContourXld(ho_ContCircle, out hv_RowXLD, out hv_ColXLD);

    //               //求圆或圆弧xld上的点的数量
    //               HOperatorSet.TupleLength(hv_ColXLD, out hv_Length2);

    //               HTuple end_val20 = hv_Elements - 1;
    //               HTuple step_val20 = 1;
    //               for (hv_i = 0; hv_i.Continue(end_val20, step_val20); hv_i = hv_i.TupleAdd(step_val20))
    //               {

    //                   //xld的起点和终点坐标相对，为圆
    //                   HOperatorSet.TupleInt(((1.0 * hv_Length2) / hv_Elements) * hv_i, out hv_j);
    //                   hv_ArcType = "circle";

    //                   //索引越界，强制赋值为最后一个索引
    //                   if ((int)(new HTuple(hv_j.TupleGreaterEqual(hv_Length2))) != 0)
    //                   {
    //                       hv_j = hv_Length2 - 1;
    //                       //continue
    //                   }

    //                   //获取卡尺工具中心
    //                   hv_RowE = hv_RowXLD.TupleSelect(hv_j);
    //                   hv_ColE = hv_ColXLD.TupleSelect(hv_j);

    //                   //超出图像区域，不检测，否则容易报异常
    //                   if ((int)((new HTuple((new HTuple((new HTuple(hv_RowE.TupleGreater(hv_Height - 1))).TupleOr(
    //                       new HTuple(hv_RowE.TupleLess(0))))).TupleOr(new HTuple(hv_ColE.TupleGreater(
    //                       hv_Width - 1))))).TupleOr(new HTuple(hv_ColE.TupleLess(0)))) != 0)
    //                   {
    //                       continue;
    //                   }

    //                   //边缘搜索方向类型：'inner'搜索方向由圆外指向圆心；'outer'搜索方向由圆心指向圆外
    //                   if ((int)(new HTuple(hv_Direct.TupleEqual("inner"))) != 0)
    //                   {
    //                       //求卡尺工具的边缘搜索方向
    //                       //求圆心指向边缘的矢量的角度
    //                       HOperatorSet.TupleAtan2((-hv_RowE) + hv_yuanDian_y, hv_ColE - hv_yuanDian_x,
    //                           out hv_ATan);
    //                       //角度反向
    //                       hv_ATan = ((new HTuple(180)).TupleRad()) + hv_ATan;
    //                   }
    //                   else
    //                   {
    //                       //求卡尺工具的边缘搜索方向
    //                       //求圆心指向边缘的矢量的角度
    //                       HOperatorSet.TupleAtan2((-hv_RowE) + hv_yuanDian_y, hv_ColE - hv_yuanDian_x,
    //                           out hv_ATan);
    //                   }


    //                   //产生卡尺xld，并保持到显示对象
    //                   ho_Rectangle1.Dispose();
    //                   HOperatorSet.GenRectangle2ContourXld(out ho_Rectangle1, hv_RowE, hv_ColE,
    //                       hv_ATan, hv_DetectHeight / 2, hv_DetectWidth / 2);
    //                   {
    //                       HObject ExpTmpOutVar_0;
    //                       HOperatorSet.ConcatObj(ho_Regions, ho_Rectangle1, out ExpTmpOutVar_0);
    //                       ho_Regions.Dispose();
    //                       ho_Regions = ExpTmpOutVar_0;
    //                   }
    //                   //用箭头xld指示边缘搜索方向，并保持到显示对象
    //                   if ((int)(new HTuple(hv_i.TupleEqual(0))) != 0)
    //                   {
    //                       hv_RowL2 = hv_RowE + ((hv_DetectHeight / 2) * (((-hv_ATan)).TupleSin()));
    //                       hv_RowL1 = hv_RowE - ((hv_DetectHeight / 2) * (((-hv_ATan)).TupleSin()));
    //                       hv_ColL2 = hv_ColE + ((hv_DetectHeight / 2) * (((-hv_ATan)).TupleCos()));
    //                       hv_ColL1 = hv_ColE - ((hv_DetectHeight / 2) * (((-hv_ATan)).TupleCos()));
    //                       ho_Arrow1.Dispose();

    //                       gen_arrow_contour_xld(out ho_Arrow1, hv_RowL1, hv_ColL1, hv_RowL2, hv_ColL2,
    //                           25, 25);
    //                       {
    //                           HObject ExpTmpOutVar_0;
    //                           HOperatorSet.ConcatObj(ho_Regions, ho_Arrow1, out ExpTmpOutVar_0);
    //                           ho_Regions.Dispose();
    //                           ho_Regions = ExpTmpOutVar_0;
    //                       }
    //                   }

    //                   //产生测量对象句柄
    //                   HOperatorSet.GenMeasureRectangle2(hv_RowE, hv_ColE, hv_ATan, hv_DetectHeight / 2,
    //                       hv_DetectWidth / 2, hv_Width, hv_Height, "nearest_neighbor", out hv_MsrHandle_Measure);


    //                   //设置极性
    //                   if ((int)(new HTuple(hv_TransitionOut.TupleEqual("negative"))) != 0)
    //                   {
    //                       hv_TransitionOut = "negative";
    //                   }
    //                   else
    //                   {
    //                       if ((int)(new HTuple(hv_TransitionOut.TupleEqual("positive"))) != 0)
    //                       {

    //                           hv_TransitionOut = "positive";
    //                       }
    //                       else
    //                       {
    //                           hv_TransitionOut = "all";
    //                       }
    //                   }
    //                   //设置边缘位置。最强点是从所有边缘中选择幅度绝对值最大点，需要设置为'all'
    //                   if ((int)(new HTuple(hv_SelectOut.TupleEqual("first"))) != 0)
    //                   {
    //                       hv_SelectOut = "first";
    //                   }
    //                   else
    //                   {
    //                       if ((int)(new HTuple(hv_SelectOut.TupleEqual("last"))) != 0)
    //                       {

    //                           hv_SelectOut = "last";
    //                       }
    //                       else
    //                       {
    //                           hv_SelectOut = "all";
    //                       }
    //                   }
    //                   //检测边缘
    //                   HOperatorSet.MeasurePos(ho_Image, hv_MsrHandle_Measure, hv_Sigma, hv_Threshold,
    //                       hv_TransitionOut, hv_SelectOut, out hv_RowEdge, out hv_ColEdge, out hv_Amplitude,
    //                       out hv_Distance);
    //                   //清除测量对象句柄
    //                   HOperatorSet.CloseMeasure(hv_MsrHandle_Measure);
    //                   //临时变量初始化
    //                   //tRow，tCol保存找到指定边缘的坐标
    //                   hv_tRow = 0;
    //                   hv_tCol = 0;
    //                   //t保存边缘的幅度绝对值
    //                   hv_t = 0;
    //                   HOperatorSet.TupleLength(hv_RowEdge, out hv_Number);
    //                   //找到的边缘必须至少为1个
    //                   if ((int)(new HTuple(hv_Number.TupleLess(1))) != 0)
    //                   {
    //                       continue;
    //                   }
    //                   //有多个边缘时，选择幅度绝对值最大的边缘
    //                   HTuple end_val110 = hv_Number - 1;
    //                   HTuple step_val110 = 1;
    //                   for (hv_k = 0; hv_k.Continue(end_val110, step_val110); hv_k = hv_k.TupleAdd(step_val110))
    //                   {
    //                       if ((int)(new HTuple(((((hv_Amplitude.TupleSelect(hv_k))).TupleAbs())).TupleGreater(
    //                           hv_t))) != 0)
    //                       {

    //                           hv_tRow = hv_RowEdge.TupleSelect(hv_k);
    //                           hv_tCol = hv_ColEdge.TupleSelect(hv_k);
    //                           hv_t = ((hv_Amplitude.TupleSelect(hv_k))).TupleAbs();
    //                       }
    //                   }
    //                   //把找到的边缘保存在输出数组
    //                   if ((int)(new HTuple(hv_t.TupleGreater(0))) != 0)
    //                   {

    //                       hv_ResultRow = hv_ResultRow.TupleConcat(hv_tRow);
    //                       hv_ResultColumn = hv_ResultColumn.TupleConcat(hv_tCol);
    //                   }

    //               }

    //               //gen_cross_contour_xld (Cross, ResultRow, ResultColumn, 6, 0.785398)
    //               ho_ContCircle.Dispose();
    //               ho_Rectangle1.Dispose();
    //               ho_Arrow1.Dispose();

    //               return;
    //           }
    //           catch (HalconException HDevExpDefaultException)
    //           {
    //               ho_ContCircle.Dispose();
    //               ho_Rectangle1.Dispose();
    //               ho_Arrow1.Dispose();

    //               throw HDevExpDefaultException;
    //           }
    //       }

    //       #endregion

    //       #region    拟合圆
    //       /// <summary>
    //       /// 拟合圆
    //       /// </summary>
    //       /// <param name="ho_Circle">输出拟合圆的xld</param>
    //       /// <param name="hv_Rows">拟合圆的边缘y数组</param>
    //       /// <param name="hv_Cols">拟合圆的边缘x数组</param>
    //       /// <param name="hv_ActiveNum">最小有效点数</param>
    //       /// <param name="hv_ArcType">拟合圆弧类型：'arc'圆弧；'circle'圆</param>
    //       /// <param name="hv_RowCenter">拟合的圆中心y</param>
    //       /// <param name="hv_ColCenter">拟合的圆中心x</param>
    //       /// <param name="hv_Radius">拟合的圆半径</param>
    //       /// <param name="hv_StartPhi">圆弧起点角度(单位：弧度)</param>
    //       /// <param name="hv_EndPhi">圆弧终点角度(单位：弧度)</param>
    //       /// <param name="hv_PointOrder">轮廓点方向</param>
    //       /// <param name="hv_ArcAngle"></param>
    //       void pts_to_best_circle(out HObject ho_Circle, HTuple hv_Rows, HTuple hv_Cols,
    //     HTuple hv_ActiveNum, HTuple hv_ArcType, out HTuple hv_RowCenter, out HTuple hv_ColCenter,
    //     out HTuple hv_Radius, out HTuple hv_StartPhi, out HTuple hv_EndPhi, out HTuple hv_PointOrder,
    //     out HTuple hv_ArcAngle)
    //       {
    //           // Local iconic variables 
    //           HObject ho_Contour = null;
    //           // Local control variables 
    //           HTuple hv_Length = null, hv_Length1 = new HTuple();
    //           HTuple hv_CircleLength = new HTuple();
    //           // Initialize local and output iconic variables 
    //           HOperatorSet.GenEmptyObj(out ho_Circle);
    //           HOperatorSet.GenEmptyObj(out ho_Contour);
    //           hv_StartPhi = new HTuple();
    //           hv_EndPhi = new HTuple();
    //           hv_PointOrder = new HTuple();
    //           hv_ArcAngle = new HTuple();
    //           //try
    //           //{
    //           //    //初始化
    //           hv_RowCenter = 0;
    //           hv_ColCenter = 0;
    //           hv_Radius = 0;
    //           //产生一个空的直线对象，用于保存拟合后的圆
    //           ho_Circle.Dispose();
    //           HOperatorSet.GenEmptyObj(out ho_Circle);
    //           //计算边缘数量
    //           HOperatorSet.TupleLength(hv_Cols, out hv_Length);
    //           //当边缘数量不小于有效点数时进行拟合
    //           if ((int)((new HTuple(hv_Length.TupleGreaterEqual(hv_ActiveNum))).TupleAnd(
    //               new HTuple(hv_ActiveNum.TupleGreater(2)))) != 0)
    //           {
    //               //halcon的拟合是基于xld的，需要把边缘连接成xld
    //               if ((int)(new HTuple(hv_ArcType.TupleEqual("circle"))) != 0)
    //               {
    //                   //如果是闭合的圆，轮廓需要首尾相连
    //                   ho_Contour.Dispose();
    //                   HOperatorSet.GenContourPolygonXld(out ho_Contour, hv_Rows.TupleConcat(hv_Rows.TupleSelect(
    //                       0)), hv_Cols.TupleConcat(hv_Cols.TupleSelect(0)));
    //               }
    //               else
    //               {
    //                   ho_Contour.Dispose();
    //                   HOperatorSet.GenContourPolygonXld(out ho_Contour, hv_Rows, hv_Cols);
    //               }
    //               //拟合圆。使用的算法是''geotukey''，其他算法请参考fit_circle_contour_xld的描述部分。
    //               HOperatorSet.FitCircleContourXld(ho_Contour, "geotukey", -1, 0, 0, 3, 2,
    //                   out hv_RowCenter, out hv_ColCenter, out hv_Radius, out hv_StartPhi, out hv_EndPhi,
    //                   out hv_PointOrder);
    //               //判断拟合结果是否有效：如果拟合成功，数组中元素的数量大于0
    //               HOperatorSet.TupleLength(hv_StartPhi, out hv_Length1);
    //               if ((int)(new HTuple(hv_Length1.TupleLess(1))) != 0)
    //               {
    //                   ho_Contour.Dispose();
    //                   return;
    //               }
    //               //根据拟合结果，产生直线xld
    //               if ((int)(new HTuple(hv_ArcType.TupleEqual("arc"))) != 0)
    //               {
    //                   #region  无用代码
    //                   //判断圆弧的方向：顺时针还是逆时针
    //                   //halcon求圆弧会出现方向混乱的问题
    //                   //tuple_mean (Rows, RowsMean)
    //                   //tuple_mean (Cols, ColsMean)
    //                   //gen_cross_contour_xld (Cross, RowsMean, ColsMean, 6, 0.785398)
    //                   //gen_circle_contour_xld (Circle1, RowCenter, ColCenter, Radius, StartPhi, EndPhi, 'positive', 1)
    //                   //求轮廓1中心
    //                   //area_center_points_xld (Circle1, Area, Row1, Column1)
    //                   //gen_circle_contour_xld (Circle2, RowCenter, ColCenter, Radius, StartPhi, EndPhi, 'negative', 1)
    //                   //求轮廓2中心
    //                   //area_center_points_xld (Circle2, Area, Row2, Column2)
    //                   //distance_pp (RowsMean, ColsMean, Row1, Column1, Distance1)
    //                   //distance_pp (RowsMean, ColsMean, Row2, Column2, Distance2)
    //                   //ArcAngle := EndPhi-StartPhi
    //                   //if (Distance1<Distance2)

    //                   //PointOrder := 'positive'
    //                   //copy_obj (Circle1, Circle, 1, 1)
    //                   //else

    //                   //PointOrder := 'negative'
    //                   //if (abs(ArcAngle)>3.1415926)
    //                   //ArcAngle := ArcAngle-2.0*3.1415926
    //                   //endif
    //                   //copy_obj (Circle2, Circle, 1, 1)
    //                   //endif
    //                   #endregion
    //                   ho_Circle.Dispose();
    //                   HOperatorSet.GenCircleContourXld(out ho_Circle, hv_RowCenter, hv_ColCenter,
    //                       hv_Radius, hv_StartPhi, hv_EndPhi, hv_PointOrder, 1);

    //                   HOperatorSet.LengthXld(ho_Circle, out hv_CircleLength);
    //                   hv_ArcAngle = hv_EndPhi - hv_StartPhi;
    //                   if ((int)(new HTuple(hv_CircleLength.TupleGreater(((new HTuple(180)).TupleRad()
    //                       ) * hv_Radius))) != 0)
    //                   {
    //                       if ((int)(new HTuple(((hv_ArcAngle.TupleAbs())).TupleLess((new HTuple(180)).TupleRad()
    //                           ))) != 0)
    //                       {
    //                           if ((int)(new HTuple(hv_ArcAngle.TupleGreater(0))) != 0)
    //                           {
    //                               hv_ArcAngle = ((new HTuple(360)).TupleRad()) - hv_ArcAngle;
    //                           }
    //                           else
    //                           {

    //                               hv_ArcAngle = ((new HTuple(360)).TupleRad()) + hv_ArcAngle;
    //                           }
    //                       }
    //                   }
    //                   else
    //                   {
    //                       if ((int)(new HTuple(hv_CircleLength.TupleLess(((new HTuple(180)).TupleRad()
    //                           ) * hv_Radius))) != 0)
    //                       {
    //                           if ((int)(new HTuple(((hv_ArcAngle.TupleAbs())).TupleGreater((new HTuple(180)).TupleRad()
    //                               ))) != 0)
    //                           {
    //                               if ((int)(new HTuple(hv_ArcAngle.TupleGreater(0))) != 0)
    //                               {
    //                                   hv_ArcAngle = hv_ArcAngle - ((new HTuple(360)).TupleRad());

    //                               }
    //                               else
    //                               {
    //                                   hv_ArcAngle = ((new HTuple(360)).TupleRad()) + hv_ArcAngle;
    //                               }
    //                           }
    //                       }
    //                   }
    //               }
    //               else
    //               {
    //                   hv_StartPhi = 0;
    //                   hv_EndPhi = (new HTuple(360)).TupleRad();
    //                   hv_ArcAngle = (new HTuple(360)).TupleRad();
    //                   ho_Circle.Dispose();
    //                   HOperatorSet.GenCircleContourXld(out ho_Circle, hv_RowCenter, hv_ColCenter,
    //                       hv_Radius, hv_StartPhi, hv_EndPhi, hv_PointOrder, 1);
    //               }
    //           }
    //           ho_Contour.Dispose();
    //           return;
    //           //}
    //           //catch ()
    //           //{
    //           //    ho_Contour.Dispose();

    //           //   //throw HDevExpDefaultException;
    //           //}
    //       }
    //       #endregion

    //       #region   得到xld
    //       /// <summary>
    //       /// 得到xld
    //       /// </summary>
    //       /// <param name="ho_Arrow"></param>
    //       /// <param name="hv_Row1"></param>
    //       /// <param name="hv_Column1"></param>
    //       /// <param name="hv_Row2"></param>
    //       /// <param name="hv_Column2"></param>
    //       /// <param name="hv_HeadLength"></param>
    //       /// <param name="hv_HeadWidth"></param>
    //       void gen_arrow_contour_xld(out HObject ho_Arrow, HTuple hv_Row1, HTuple hv_Column1,
    //           HTuple hv_Row2, HTuple hv_Column2, HTuple hv_HeadLength, HTuple hv_HeadWidth)
    //       {
    //           // Stack for temporary objects 
    //           HObject[] OTemp = new HObject[20];
    //           // Local iconic variables 
    //           HObject ho_TempArrow = null;
    //           // Local control variables 
    //           HTuple hv_Length = null, hv_ZeroLengthIndices = null;
    //           HTuple hv_DR = null, hv_DC = null, hv_HalfHeadWidth = null;
    //           HTuple hv_RowP1 = null, hv_ColP1 = null, hv_RowP2 = null;
    //           HTuple hv_ColP2 = null, hv_Index = null;
    //           // Initialize local and output iconic variables 
    //           HOperatorSet.GenEmptyObj(out ho_Arrow);
    //           HOperatorSet.GenEmptyObj(out ho_TempArrow);
    //           try
    //           {
    //               //This procedure generates arrow shaped XLD contours,
    //               //pointing from (Row1, Column1) to (Row2, Column2).
    //               //If starting and end point are identical, a contour consisting
    //               //of a single point is returned.
    //               //
    //               //input parameteres:
    //               //Row1, Column1: Coordinates of the arrows' starting points
    //               //Row2, Column2: Coordinates of the arrows' end points
    //               //HeadLength, HeadWidth: Size of the arrow heads in pixels
    //               //
    //               //output parameter:
    //               //Arrow: The resulting XLD contour
    //               //
    //               //The input tuples Row1, Column1, Row2, and Column2 have to be of
    //               //the same length.
    //               //HeadLength and HeadWidth either have to be of the same length as
    //               //Row1, Column1, Row2, and Column2 or have to be a single element.
    //               //If one of the above restrictions is violated, an error will occur.
    //               //
    //               //
    //               //Init
    //               ho_Arrow.Dispose();
    //               HOperatorSet.GenEmptyObj(out ho_Arrow);
    //               //
    //               //Calculate the arrow length
    //               HOperatorSet.DistancePp(hv_Row1, hv_Column1, hv_Row2, hv_Column2, out hv_Length);
    //               //
    //               //Mark arrows with identical start and end point
    //               //(set Length to -1 to avoid division-by-zero exception)
    //               hv_ZeroLengthIndices = hv_Length.TupleFind(0);
    //               if ((int)(new HTuple(hv_ZeroLengthIndices.TupleNotEqual(-1))) != 0)
    //               {
    //                   if (hv_Length == null)
    //                       hv_Length = new HTuple();
    //                   hv_Length[hv_ZeroLengthIndices] = -1;
    //               }
    //               //
    //               //Calculate auxiliary variables.
    //               hv_DR = (1.0 * (hv_Row2 - hv_Row1)) / hv_Length;
    //               hv_DC = (1.0 * (hv_Column2 - hv_Column1)) / hv_Length;
    //               hv_HalfHeadWidth = hv_HeadWidth / 2.0;
    //               //
    //               //Calculate end points of the arrow head.
    //               hv_RowP1 = (hv_Row1 + ((hv_Length - hv_HeadLength) * hv_DR)) + (hv_HalfHeadWidth * hv_DC);
    //               hv_ColP1 = (hv_Column1 + ((hv_Length - hv_HeadLength) * hv_DC)) - (hv_HalfHeadWidth * hv_DR);
    //               hv_RowP2 = (hv_Row1 + ((hv_Length - hv_HeadLength) * hv_DR)) - (hv_HalfHeadWidth * hv_DC);
    //               hv_ColP2 = (hv_Column1 + ((hv_Length - hv_HeadLength) * hv_DC)) + (hv_HalfHeadWidth * hv_DR);
    //               //
    //               //Finally create output XLD contour for each input point pair
    //               for (hv_Index = 0; (int)hv_Index <= (int)((new HTuple(hv_Length.TupleLength())) - 1); hv_Index = (int)hv_Index + 1)
    //               {
    //                   if ((int)(new HTuple(((hv_Length.TupleSelect(hv_Index))).TupleEqual(-1))) != 0)
    //                   {
    //                       //Create_ single points for arrows with identical start and end point
    //                       ho_TempArrow.Dispose();
    //                       HOperatorSet.GenContourPolygonXld(out ho_TempArrow, hv_Row1.TupleSelect(
    //                           hv_Index), hv_Column1.TupleSelect(hv_Index));
    //                   }
    //                   else
    //                   {
    //                       //Create arrow contour
    //                       ho_TempArrow.Dispose();
    //                       HOperatorSet.GenContourPolygonXld(out ho_TempArrow, ((((((((((hv_Row1.TupleSelect(
    //                           hv_Index))).TupleConcat(hv_Row2.TupleSelect(hv_Index)))).TupleConcat(
    //                           hv_RowP1.TupleSelect(hv_Index)))).TupleConcat(hv_Row2.TupleSelect(hv_Index)))).TupleConcat(
    //                           hv_RowP2.TupleSelect(hv_Index)))).TupleConcat(hv_Row2.TupleSelect(hv_Index)),
    //                           ((((((((((hv_Column1.TupleSelect(hv_Index))).TupleConcat(hv_Column2.TupleSelect(
    //                           hv_Index)))).TupleConcat(hv_ColP1.TupleSelect(hv_Index)))).TupleConcat(
    //                           hv_Column2.TupleSelect(hv_Index)))).TupleConcat(hv_ColP2.TupleSelect(
    //                           hv_Index)))).TupleConcat(hv_Column2.TupleSelect(hv_Index)));
    //                   }
    //                   {
    //                       HObject ExpTmpOutVar_0;
    //                       HOperatorSet.ConcatObj(ho_Arrow, ho_TempArrow, out ExpTmpOutVar_0);
    //                       ho_Arrow.Dispose();
    //                       ho_Arrow = ExpTmpOutVar_0;
    //                   }
    //               }
    //               ho_TempArrow.Dispose();

    //               return;
    //           }
    //           catch (HalconException HDevExpDefaultException)
    //           {
    //               ho_TempArrow.Dispose();

    //               throw HDevExpDefaultException;
    //           }
    //       }
    //       #endregion
    //       #endregion

    //       #region   显示结果
    //       /// <summary>
    //       /// 显示结果
    //       /// </summary>
    //       /// <param name="ICircle_"></param>
    //       /// <param name="hwin"></param>
    //       /// <returns></returns>
    //       public bool Circle_Show(ICircleShuJu ICircle_, HWindow hwin)
    //       {
    //           bool ok = false;

    //           /****显示圆的圆心***/
    //           if (ICircle_.Column > 0)
    //           {
    //               HObject hv_cross;
    //               HOperatorSet.GenEmptyObj(out hv_cross);
    //               HOperatorSet.GenCrossContourXld(out hv_cross, ICircle_.Row, ICircle_.Column, 60, ICircle_.Angle);

    //               hwin.DispObj(hv_cross);

    //               /***********显示找到的点************/
    //               hwin.DispObj(ICircle_.Ho_Regions);
    //               /***显示卡尺工具****/
    //               hwin.DispObj(ICircle_.Ho_Regions_0);
    //               /***显示拟合的圆****/
    //               hwin.DispObj(ICircle_.Ho_Circle);

    //           }
    //           else
    //           {
    //               hwin.SetColor("red");
    //               /***显示卡尺工具****/
    //               hwin.DispObj(ICircle_.Ho_Regions_0);
    //               hwin.SetColor("green");
    //           }
    //           ok = true;
    //           return ok;
    //       }
    //       #endregion

    //       #region  检测，显示，保存
    //       /// <summary>
    //       /// 检测，显示，保存
    //       /// </summary>
    //       /// <param name="ho_Image"></param>
    //       /// <param name="ICircle_"></param>
    //       /// <param name="hwin"></param>
    //       /// <param name="Key"></param>
    //       /// <param name="_dictionary_resulte"></param>
    //       /// <returns></returns>
    //       public bool Spoke_Show_Out(HObject ho_Image, ICircleShuJu ICircle_, HWindow hwin, string Key, ref Dictionary<string, Object> _dictionary_resulte)
    //       {
    //           bool ok = false;
    //           /*******************************************处理***********************************************/
    //           HTuple hv_modMat2D;
    //           HTuple hv_Center_X, hv_Center_Y;
    //           if (ICircle_.IrectShuJuPianYi != null)
    //           {
    //               HObject hv_Cirle;
    //               HTuple Area_, Column_, Row_;
    //               HOperatorSet.GenEmptyObj(out hv_Cirle);
    //               HOperatorSet.VectorAngleToRigid(ICircle_.GenSuiDian_Y_Row, ICircle_.GeuSuiDian_X_Col, ICircle_.GenSuiDian_A, ICircle_.IrectShuJuPianYi.Row, ICircle_.IrectShuJuPianYi.Column, ICircle_.IrectShuJuPianYi.Angle, out hv_modMat2D);
    //               HOperatorSet.GenCircle(out hv_Cirle, ICircle_.IOutSide.Center_row_y, ICircle_.IOutSide.Center_column_x, ICircle_.IOutSide.Radius);
    //               HOperatorSet.AffineTransRegion(hv_Cirle, out hv_Cirle, hv_modMat2D, "nearest_neighbor");
    //               HOperatorSet.AreaCenter(hv_Cirle, out Area_, out Row_, out Column_);
    //               hv_Cirle.Dispose();
    //               hv_Center_X = Column_;
    //               hv_Center_Y = Row_;
    //           }
    //           else
    //           {
    //               hv_Center_X = ICircle_.IOutSide.Center_column_x;
    //               hv_Center_Y = ICircle_.IOutSide.Center_row_y;
    //           }

    //           HObject ho_Regions;
    //           HOperatorSet.GenEmptyObj(out ho_Regions);
    //           HTuple Resultrow, Resultcolumn, ResultArcType;
    //           //spoke(ho_Image, out ho_Regions, hv_Center_Y, hv_Center_X, ICircle_.IOutSide.Radius, ICircle_.Hv_Elements, ICircle_.Hv_Direct, ICircle_.Hv_DetectHeight, ICircle_.Hv_DetectWidth, ICircle_.Hv_Transition, ICircle_.Hv_Select, ICircle_.Hv_Sigma, ICircle_.Hv_Threshold, out Resultrow, out Resultcolumn, out ResultArcType);
    //           spoke2(ho_Image, out ho_Regions, hv_Center_Y, hv_Center_X, ICircle_.IOutSide.Radius, ICircle_.Hv_StartPhi, ICircle_.Hv_EndPh, ICircle_.Hv_Elements, ICircle_.Hv_Direct, ICircle_.Hv_DetectHeight, ICircle_.Hv_DetectWidth, ICircle_.Hv_Transition, ICircle_.Hv_Select, ICircle_.Hv_Sigma, ICircle_.Hv_Threshold, out Resultrow, out Resultcolumn, out ResultArcType);

    //           HObject hv_cross1;
    //           HOperatorSet.GenEmptyObj(out hv_cross1);

    //           HOperatorSet.GenCrossContourXld(out hv_cross1, Resultrow, Resultcolumn, 6, 0.78639);
    //           ICircle_.Ho_Regions.Dispose();
    //           ICircle_.Ho_Regions = hv_cross1;

    //           ICircle_.Hv_ResultColumn = Resultcolumn;
    //           ICircle_.Hv_ResultRow = Resultrow;
    //           ICircle_.Hv_ArcType = ResultArcType;
    //           ICircle_.Ho_Regions_0 = ho_Regions;

    //           HObject ho_Circle;
    //           HOperatorSet.GenEmptyObj(out ho_Circle);
    //           ho_Circle.Dispose();

    //           HTuple hv_RowCenter, hv_ColCenter, hv_Radius, hv_StartPhi, hv_EndPhi, hv_PointOrder, hv_ArcAngle;
    //           pts_to_best_circle(out ho_Circle, ICircle_.Hv_ResultRow, ICircle_.Hv_ResultColumn, ICircle_.Hv_ActiveNum, ICircle_.Hv_ArcType, out hv_RowCenter, out hv_ColCenter, out hv_Radius, out hv_StartPhi, out hv_EndPhi, out hv_PointOrder, out hv_ArcAngle);

    //           ICircle_.Ho_Circle.Dispose();
    //           ICircle_.Ho_Circle = ho_Circle;
    //           ICircle_.Row = hv_RowCenter;
    //           ICircle_.Column = hv_ColCenter;
    //           ICircle_.Hv_PointOrder = hv_PointOrder;
    //           ICircle_.Angle = hv_ArcAngle;

    //           /****************************************保存数据************************************/
    //           Key = "Circle_" + Key;
    //           Cricle_Result cricleResult = new Cricle_Result();
    //           cricleResult._tolatName = Key;
    //           Result_Analyisis(ICircle_, ref cricleResult);

    //           _dictionary_resulte.Add(Key, cricleResult);
    //           #region  无用代码
    //           //if (ICircle_.Ho_Circle.IsInitialized())
    //           //{
    //           //    Cricle_Result _result = new Cricle_Result();
    //           //    ICircle_.Row = hv_RowCenter;
    //           //    ICircle_.Column = hv_ColCenter;
    //           //    //ICircle_.Hv_StartPhi = hv_StartPhi;
    //           //    //ICircle_.Hv_EndPh = hv_EndPhi;
    //           //    ICircle_.Hv_PointOrder = hv_PointOrder;
    //           //    ICircle_.Angle = hv_ArcAngle;

    //           //    _result.Row = hv_RowCenter;
    //           //    _result.Column = hv_ColCenter;
    //           //    _result.Hv_StartPhi = hv_StartPhi;
    //           //    _result.Hv_EndPh = hv_EndPhi;
    //           //    _result.Hv_PointOrder = hv_PointOrder;
    //           //    _result.Angle = hv_ArcAngle;
    //           //    _dictionary_resulte.Add(Key, _result);
    //           //}
    //           //else
    //           //{
    //           //    _dictionary_resulte.Add(Key, null);
    //           //}
    //           #endregion

    //           if (cricleResult._tolatResult)
    //           {
    //               ok = true;
    //           }
    //           /********************************显示**********************************************/

    //           /***显示卡尺工具****/
    //           if (!cricleResult._tolatResult)//提示对错
    //           {
    //               hwin.SetColor("red");
    //               hwin.DispObj(ICircle_.Ho_Regions_0);
    //               hwin.SetColor("green");
    //           }
    //           else
    //           {
    //               hwin.DispObj(ICircle_.Ho_Regions_0);
    //               /*****显示查找的点***********/
    //               hwin.DispObj(ICircle_.Ho_Regions);

    //               /***显示拟合的圆****/
    //               hwin.DispObj(ICircle_.Ho_Circle);

    //               /****显示圆的圆心***/
    //               if (ICircle_.Column > 0)
    //               {
    //                   HObject hv_cross;
    //                   HOperatorSet.GenEmptyObj(out hv_cross);
    //                   hv_cross.Dispose();
    //                   HOperatorSet.GenCrossContourXld(out hv_cross, ICircle_.Row, ICircle_.Column, 60, ICircle_.Angle);
    //                   hwin.DispObj(hv_cross);
    //               }

    //           }


    //           return ok;
    //       }
    //       #endregion

    //       #region   数据分析
    //       /// <summary>
    //       /// 数据分析
    //       /// </summary>
    //       /// <param name="ICircle_"></param>
    //       /// <param name="cricleResult_"></param>
    //       /// <returns></returns>
    //       bool Result_Analyisis(ICircleShuJu ICircle_, ref Cricle_Result cricleResult_)
    //       {
    //           bool ok = false;

    //           if (ICircle_.Row > 0)
    //           {
    //               cricleResult_._tolatResult = true;
    //           }
    //           else
    //           {
    //               cricleResult_._tolatResult = false;
    //           }

    //           if (ICircle_._ICalibration != null)//确定是否有标定
    //           {
    //               HTuple row_, col_;

    //               row_ = ICircle_.Row;
    //               col_ = ICircle_.Column;

    //               this.Cal(ICircle_._ICalibration.HomMat2D, ref row_, ref col_);
    //               ICircle_.Row = row_;
    //               ICircle_.Column = col_;
    //               cricleResult_.Row = row_;
    //               cricleResult_.Column = col_;
    //           }
    //           else
    //           {
    //               cricleResult_.Row = ICircle_.Row;
    //               cricleResult_.Column = ICircle_.Column;
    //           }

    //           cricleResult_.Hv_StartPhi = ICircle_.Hv_StartPhi;
    //           cricleResult_.Hv_EndPh = ICircle_.Hv_EndPh;
    //           cricleResult_.Hv_PointOrder = ICircle_.Hv_PointOrder;
    //           cricleResult_.Angle = ICircle_.Angle;

    //           ok = true;
    //           return ok;
    //       }
    //       #endregion
    //   }
    //   #endregion
    #endregion

    #region  结果
    /// <summary>
    /// 结果
    /// </summary>
    public class Cricle_Result : MultTree.ClassResultFather
    {

        /// <summary>
        /// 
        /// </summary>
        public HTuple Row = new HTuple();
        /// <summary>
        /// 
        /// </summary>
        public HTuple Column = new HTuple();
        /// <summary>
        /// 
        /// </summary>
        public HTuple Hv_StartPhi = new HTuple();
        /// <summary>
        /// 
        /// </summary>
        public HTuple Hv_EndPh = new HTuple();
        /// <summary>
        /// 
        /// </summary>
        public HTuple Hv_PointOrder = new HTuple();
        /// <summary>
        /// 
        /// </summary>
        public HTuple Angle = new HTuple();

        /// <summary>
        /// 输出显示数据
        /// </summary>
        /// <param name="str_array"></param>
        /// <returns></returns>
        public override bool showResult(out string[] str_array)
        {
            bool ok = false;
            str_array = new string[5];
            if (this._tolatResult)
            {
                str_array[0] = this._tolatName;
                str_array[1] = this._tolatResult.ToString();
                str_array[2] = "x:" + Row.D.ToString();
                str_array[3] = "y:" + Column.D.ToString();
                str_array[4] = "a:" + Angle.D.ToString();
            }
            else
            {
                str_array[0] = this._tolatName;
                str_array[1] = this._tolatResult.ToString();
                str_array[2] = "x:";
                str_array[3] = "y:";
                str_array[4] = "a:";
            }
            ok = true;
            return ok;
        }

    }
    #endregion
}
