using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HalconDotNet;

namespace HalControl.ROI.Cricle
{

    internal class CricleROI : ROI
    {
        #region 全局变量

        #region  半径
        /// <summary>
        /// 圆的半径
        /// </summary>
        double _radius;
        #endregion

        #region  用于设置半径的点
        /// <summary>
        /// 用于设置半径的点
        /// </summary>
        double _row_r_y;

        /// <summary>
        /// 用于设置半斤的点
        /// </summary>
        double _col_r_x;
        #endregion

        #region  圆心
        /// <summary>
        /// 圆心
        /// </summary>
        double _center_row_y;

        /// <summary>
        /// 圆心
        /// </summary>
        double _center_column_x;
        #endregion

        #region  对外开放的操作点位数
        /// <summary>
        /// 对外开放的操作点位数
        /// </summary>
        int _operation_piont_number;
        #endregion

        #region  操作第几个点
        /// <summary>
        /// 操作第几个点
        /// </summary>
        int _operationing;
        #endregion

        #region  对接外部数据
        /// <summary>
        /// 对接外部数据
        /// </summary>
        IOutsideCricleROI _iOutSide = null;
        #endregion

        #endregion

        #region   属性

        #region  半径
        /// <summary>
        /// 圆的半径
        /// </summary>
        public double Radius
        {
            get { return _radius; }
            set { _radius = value; }
        }
        #endregion

        #region 用于设置半径的点
        /// <summary>
        /// 用于设置半径的点
        /// </summary>
        public double Row_r_y
        {
            get { return _row_r_y; }
            set { _row_r_y = value; }
        }

        /// <summary>
        /// 用于设置半斤的点
        /// </summary>
        public double Col_r_x
        {
            get { return _col_r_x; }
            set { _col_r_x = value; }
        }
        #endregion

        #region  圆心
        /// <summary>
        /// 圆心
        /// </summary>
        public double Center_row_y
        {
            get { return _center_row_y; }
            set { _center_row_y = value; }
        }

        /// <summary>
        /// 圆心
        /// </summary>
        public double Center_column_x
        {
            get { return _center_column_x; }
            set { _center_column_x = value; }
        }
        #endregion

        #region  对接外部数据
        /// <summary>
        /// 对接外部数据
        /// </summary>
        public IOutsideCricleROI IOutSide
        {
            get { return _iOutSide; }
            set { _iOutSide = value; }
        }
        #endregion

        #endregion

        #region  构造函数
        /// <summary>
        /// 构造函数
        /// </summary>
        public CricleROI()
        {
            _operation_piont_number = 2;
            _operationing = -1;
        }
        #endregion

        #region  显示圆
        /// <summary>
        /// 显示圆
        /// </summary>
        public override void displayROI(HWindow hwin)
        {
            hwin.DispCircle(Center_row_y, Center_column_x, Radius);

            if (_operationing == -1)
            {
                hwin.DispRectangle2(Center_row_y, Center_column_x, 0, 5, 5);
                hwin.DispRectangle2(_row_r_y, _col_r_x, 0, 5, 5);
            }
            else
            {
                for (int i = 0; i < _operation_piont_number; i++)
                {
                    if (i == _operationing)
                    {
                        displayOperation(i, hwin);
                    }
                    else
                    {
                        no_chice_point(i, hwin);
                    }
                }
            }
        }
        #endregion

        #region  是否选中圆
        /// <summary>
        /// 是否选中圆
        /// </summary>
        /// <returns></returns>
        public override int isSelected(double x, double y)
        {
            _operationing = -1;

            double max = 35;
            double[] value = new double[_operation_piont_number];
            value[0] = HMisc.DistancePp(y, x, _row_r_y, _col_r_x);
            value[1] = HMisc.DistancePp(y, x, _center_row_y, _center_column_x);
            for (int i = 0; i < _operation_piont_number; i++)
            {
                if (value[i] < max)
                {
                    max = value[i];
                    _operationing = i;
                }
            }
            return _operationing;
        }
        #endregion

        #region  创建圆
        /// <summary>
        /// 创建圆
        /// </summary>
        /// <param name="center_row_y_"></param>
        /// <param name="center_column_x_"></param>
        /// <param name="radius_"></param>
        public bool create(double center_row_y_, double center_column_x_, double radius_)
        {
            bool ok = true;
            _center_column_x = center_column_x_;
            _center_row_y = center_row_y_;

            _radius = radius_;

            _col_r_x = radius_ + center_column_x_;
            _row_r_y = center_row_y_;

            updateInterface();

            ok = false;
            return ok;
        }
        #endregion

        #region  显示选中的操作点
        /// <summary>
        /// 显示选中的操作点
        /// </summary>
        /// <param name="number"></param>
        public override void displayOperation(int number, HWindow hwin)
        {
            switch (number)
            {
                case 0:
                    hwin.SetColor("red");
                    hwin.DispRectangle2(_row_r_y, _col_r_x, 0, 5, 5);
                    hwin.SetColor("green");
                    break;
                case 1:
                    hwin.SetColor("red");
                    hwin.DispRectangle2(Center_row_y, Center_column_x, 0, 5, 5);
                    hwin.SetColor("green");
                    break;
            }
        }
        #endregion

        #region   显示没有选中的操作点
        /// <summary>
        /// 显示没有选中的操作点
        /// </summary>
        /// <param name="col_x"></param>
        /// <param name="row_y"></param>
        void no_chice_point(int number, HWindow hwin)
        {
            switch (number)
            {
                case 0:
                    hwin.DispRectangle2(_row_r_y, _col_r_x, 0, 5, 5);
                    break;
                case 1:
                    hwin.DispRectangle2(Center_row_y, Center_column_x, 0, 5, 5);
                    break;
            }
        }
        #endregion

        #region  设置操作点
        /// <summary>
        /// 设置操作点
        /// </summary>
        /// <param name="col_x"></param>
        /// <param name="row_y"></param>
        /// <param name="number"></param>
        public override void setOpoint(double col_x, double row_y)
        {
            switch (_operationing)
            {
                case 0:
                    _row_r_y = row_y;
                    _col_r_x = col_x;

                    sheild_R();
                    break;

                case 1:
                    Center_row_y = row_y;
                    Center_column_x = col_x;

                    sheild_col_row();
                    break;
            }

            updateInterface();
        }
        #endregion

        #region  刷新下半径
        /// <summary>
        /// 刷新下半径
        /// </summary>
        void sheild_R()
        {
            _radius = HMisc.DistancePp(Center_row_y, Center_column_x, _row_r_y, _col_r_x);
        }
        #endregion

        #region  刷新半径操作点
        /// <summary>
        /// 刷新半径操作点
        /// </summary>
        void sheild_col_row()
        {
            _col_r_x = _radius + Center_column_x;
            _row_r_y = Center_row_y;
        }
        #endregion

        #region  更新接口数据
        /// <summary>
        /// 更新接口数据
        /// </summary>
        void updateInterface()
        {
            if (this._iOutSide != null)
            {
                this._iOutSide.Radius = this._radius;
                this._iOutSide.Center_column_x = this._center_column_x;
                this._iOutSide.Center_row_y = this._center_row_y;
            }
        }

        #endregion

        #region  无用代码
        //#region  对接外部数据
        ///// <summary>
        ///// 对接外部数据
        ///// </summary>
        ///// <returns></returns>
        //public override HalControl.ROI.IOutside iOutSide()
        //{
        //    return (IOutside)_iOutSide;
        //}
        //#endregion
        #endregion
    }

    #region  数据对外数据接口
    /// <summary>
    /// 数据对外数据接口
    /// </summary>
    [Serializable]
    public class OutsideCricleROI : IOutsideCricleROI
    {
        #region  半径
        /// <summary>
        /// 半径
        /// </summary>
        [NonSerialized]
        private HTuple _radius;
        #endregion

        #region   圆心
        /// <summary>
        /// 圆心
        /// </summary>
        [NonSerialized]
        private HTuple _center_row_y;

        /// <summary>
        /// 圆心
        /// </summary>
        [NonSerialized]
        private HTuple _center_column_x;

        #endregion

        #region  属性

        #region  半径
        /// <summary>
        /// 半径
        /// </summary>
        public HTuple Radius
        {
            get { return _radius; }
            set { _radius = value; }
        }
        #endregion

        #region  圆心
        /// <summary>
        /// 圆心
        /// </summary>
        public HTuple Center_row_y
        {
            get { return _center_row_y; }
            set { _center_row_y = value; }
        }

        /// <summary>
        /// 圆心
        /// </summary>
        public HTuple Center_column_x
        {
            get { return _center_column_x; }
            set { _center_column_x = value; }
        }
        #endregion

        #endregion
    }

    /// <summary>
    /// 数据对外数据接口
    /// </summary>
    public interface IOutsideCricleROI
    {
        #region   属性

        #region  半径
        /// <summary>
        /// 圆的半径
        /// </summary>
        HTuple Radius
        {
            get;
            set;
        }
        #endregion

        #region  圆心
        /// <summary>
        /// 圆心
        /// </summary>
        HTuple Center_row_y
        {
            get;
            set;
        }

        /// <summary>
        /// 圆心
        /// </summary>
        HTuple Center_column_x
        {
            get;
            set;
        }
        #endregion

        #endregion
    }
    #endregion

    #region   对外接口
    /// <summary>
    /// 对外接口
    /// </summary>
    public interface IOutsideCricle
    {
        /// <summary>
        /// 对外接口
        /// </summary>
        IOutsideCricleROI IOutSide { get; set; }
    }
    #endregion

}
