using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;
using HalconDotNet;

namespace HalControl.ROI
{

    /// <summary>
    /// roi控制器
    /// </summary>
    public class ROIControl
    {
        #region  全局变量

        #region  ROI的集合
        /// <summary>
        /// ROI集合
        /// </summary>
        ArrayList _array_ROI;
        #endregion

        #region  当前ROI的接口
        /// <summary>
        /// 当前ROI的接口
        /// </summary>
        IROI _iROI;
        #endregion

        #region  当前被算中的roi
        /// <summary>
        /// 当前被算中的roi
        /// </summary>
        IDiJiGeROIBeiXuanZhong _iDiJiGeRoi = null;
        #endregion

        #endregion

        #region  初始化
        /// <summary>
        /// 初始化
        /// </summary>
        internal ROIControl()
        {
            _array_ROI = new ArrayList();
            _iROI = null;
        }
        #endregion

        #region  判断roi的有无
        /// <summary>
        ///  判断roi的有无
        /// </summary>
        /// <returns></returns>
        internal bool isArrayROIExit()
        {
            bool ok = false;
            int num = 0;
            num = _array_ROI.Count;
            if (num > 0)
            {
                ok = true;
            }
            return ok;
        }
        #endregion

        #region  确定ROI是否被选中
        /// <summary>
        /// 确定ROI是否被选中
        /// </summary>
        /// <param name="col_x"></param>
        /// <param name="row_y"></param>
        /// <returns></returns>
        internal int selectedROI(double col_x, double row_y)
        {

            int ok = -1;
            int num = _array_ROI.Count;
            for (int i = 0; i < num; i++)
            {
                ROI roi_ = (ROI)_array_ROI[i];
                if (roi_.isSelected(col_x, row_y) != -1)
                {
                    ok = i;
                    this._iROI = roi_;
                }
            }

            if (ok != -1)
            {
                if (this._iDiJiGeRoi != null)
                {
                    this._iDiJiGeRoi.IXuanZhongRoiDeIndex = ok;
                }
            }

            return ok;
        }
        #endregion

        #region  设置当前ROI的选中点的位置
        /// <summary>
        /// 设置当前ROI的选中点的位置
        /// </summary>
        internal void setROISelectedPoint(double col_x, double row_y)
        {
            _iROI.setOpoint(col_x, row_y);
        }
        #endregion

        #region   画圆
        /// <summary>
        /// 画圆
        /// </summary>
        /// <param name="cols_x"></param>
        /// <param name="row_y"></param>
        /// <param name="radius"></param>
        internal void drawCircle(double cols_x, double row_y, double radius, Cricle.IOutsideCricleROI iOutSide_)
        {
            Cricle.CricleROI circle_ = new Cricle.CricleROI();
            circle_.create(row_y, cols_x, radius);
            if (iOutSide_ != null)
            {
                circle_.IOutSide = iOutSide_;
            }
            _array_ROI.Add(circle_);

        }
        #endregion

        #region   画矩形1
        /// <summary>
        /// 画矩形
        /// </summary>
        /// <param name="cols_x1"></param>
        /// <param name="row_y1"></param>
        /// <param name="cols_x2"></param>
        /// <param name="row_y2"></param>
        internal void drawRectangle1(double cols_x1, double row_y1, double cols_x2, double row_y2, Rectangle1.IOutsideRectangle1ROI iOutSide_)
        {
            Rectangle1.Rectangle1ROI rectangle1_ = new Rectangle1.Rectangle1ROI();
            if (iOutSide_ != null)
            {
                rectangle1_.IOutside = iOutSide_;
            }
            rectangle1_.create(row_y1, cols_x1, row_y2, cols_x2);
            _array_ROI.Add(rectangle1_);
        }
        #endregion

        #region 画矩形2
        /// <summary>
        /// 画矩形2
        /// </summary>
        /// <param name="mid_row_y"></param>
        /// <param name="mid_col_x"></param>
        /// <param name="phi"></param>
        /// <param name="len1"></param>
        /// <param name="len2"></param>
        internal void drawRectangle2(double mid_row_y, double mid_col_x, double phi, double len1, double len2, Rectangle2.IOutsideRectangle2ROI iOutSide_)
        {
            Rectangle2.Rectangle2ROI rectangle2 = new Rectangle2.Rectangle2ROI();
            rectangle2.create(mid_row_y, mid_col_x, phi, len1, len2);
            if (iOutSide_ != null)
            {
                rectangle2.IOutSide = iOutSide_;
            }
            _array_ROI.Add(rectangle2);
        }
        #endregion

        #region 画直线
        /// <summary>
        /// 画直线
        /// </summary>
        /// <param name="cols_x1"></param>
        /// <param name="row_y1"></param>
        /// <param name="cols_x2"></param>
        /// <param name="row_y2"></param>
        internal void drawLine(double cols_x1, double row_y1, double cols_x2, double row_y2, Line.IOutsideLineROI iOutSide_)
        {
            Line.LineROI lineROI_ = new Line.LineROI();
            lineROI_.create(row_y1, cols_x1, row_y2, cols_x2);
            if (iOutSide_ != null)
            {
                lineROI_.IOutSide = iOutSide_;
            }
            _array_ROI.Add(lineROI_);
        }
        #endregion

        #region  绑定第几个roi被选中
        /// <summary>
        /// 绑定第几个roi被选中
        /// </summary>
        internal void bangDingDiJiGeRoiDeJieKou(IDiJiGeROIBeiXuanZhong iDiJiGeRoi_)
        {
            this._iDiJiGeRoi = iDiJiGeRoi_;
        }
        #endregion

        #region   显示所有ROI
        /// <summary>
        ///  显示所有ROI
        /// </summary>
        /// <param name="hwin"></param>
        internal void displayROI(HWindow hwin)
        {
            foreach (object ob in this._array_ROI)
            {
                ROI roi_ = (ROI)ob;
                roi_.displayROI(hwin);
            }
        }
        #endregion

        #region  删除当前所有的ROI
        /// <summary>
        /// 删除当前所有的ROI
        /// </summary>
        /// <returns></returns>
        internal bool deleteAllRoi()
        {
            bool ok = false;
            this._array_ROI.Clear();
            this._iDiJiGeRoi.IXuanZhongRoiDeIndex = -1;

            ok = true;
            return ok;
        }
        #endregion

        #region  删除当前的roi
        /// <summary>
        /// 删除当前的roi
        /// </summary>
        /// <returns></returns>
        internal bool deleteDangQianRoi()
        {
            bool ok = false;

            if (this._iDiJiGeRoi.IXuanZhongRoiDeIndex != -1)
            {
                this._array_ROI.RemoveAt(this._iDiJiGeRoi.IXuanZhongRoiDeIndex);
                if (this._array_ROI.Count > 0)
                {
                    this._iDiJiGeRoi.IXuanZhongRoiDeIndex = 0;
                }
                else
                {
                    this._iDiJiGeRoi.IXuanZhongRoiDeIndex = -1;
                }
            }
            ok = true;
            return ok;

        }
        #endregion
    }

    #region  ROI的状态
    /// <summary>
    /// ROI状态枚举
    /// </summary>
    internal enum ROIStatus
    {
        /// <summary>
        /// 选中ROI
        /// </summary>
        ChioceROI,
        /// <summary>
        /// 没有选中ROI
        /// </summary>
        NoChioceROI
    }
    #endregion

    #region  第几个roi被选中
    /// <summary>
    /// 第几个roi被选中
    /// </summary>
    [Serializable]
    public class DiJiGeROIBeiXuanZhong : IDiJiGeROIBeiXuanZhong
    {
        #region  全局变量
        /// <summary>
        /// 被选中roi的引索
        /// </summary>
        int iXuanZhongRoiDeIndex = 0;
        #endregion


        #region  被选中roi的引索
        /// <summary>
        /// 被选中roi的引索
        /// </summary>
        public int IXuanZhongRoiDeIndex
        {
            get { return iXuanZhongRoiDeIndex; }
            set { iXuanZhongRoiDeIndex = value; }
        }
        #endregion
    }


    /// <summary>
    /// 第几个roi被选中
    /// </summary>
    public interface IDiJiGeROIBeiXuanZhong
    {
        /// <summary>
        /// 被选中roi的引索
        /// </summary>
        int IXuanZhongRoiDeIndex { set; get; }
    }

    /// <summary>
    /// 第几个roi被选中 接口
    /// </summary>
    public interface IRoiIndex
    {
        /// <summary>
        /// 被选中roi的引索
        /// </summary>
        IDiJiGeROIBeiXuanZhong IXuanZhongDeRoi { set; get; }
    }




    #endregion
}
