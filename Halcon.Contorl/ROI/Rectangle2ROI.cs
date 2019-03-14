using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HalconDotNet;


namespace HalControl.ROI.Rectangle2
{
    internal class Rectangle2ROI : ROI
    {
        #region  全局变量

        #region  矩形的端点
        /// <summary>
        /// 
        /// </summary>
        double _mid_row_y;

        /// <summary>
        /// 
        /// </summary>
        double _mid_col_x;

        /// <summary>
        /// 
        /// </summary>
        double _len1;

        /// <summary>
        /// 
        /// </summary>
        double _len2;

        /// <summary>
        /// 
        /// </summary>
        double _phi;

        #endregion

        #region  角度操作点  无用代码
        ///// <summary>
        ///// 角度操作点
        ///// </summary>
        //double _phi_row_y;

        ///// <summary>
        ///// 角度操作点
        ///// </summary>
        //double _phi_col_x;

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

        #region  操作点
        /// <summary>
        /// 初始操作点
        /// </summary>
        HTuple _rowsInit_y;
        /// <summary>
        /// 初始操作点
        /// </summary>
        HTuple _colsInit_x;
        /// <summary>
        /// 转换后的操作点
        /// </summary>
        HTuple _rows_y;
        /// <summary>
        /// 转换后的操作点
        /// </summary>
        HTuple _cols_x;
        #endregion

        #region  放射变换矩形
        /// <summary>
        /// 放射变换矩形
        /// </summary>
        HHomMat2D _hom2D;

        /// <summary>
        /// 放射变换矩形
        /// </summary>
        HHomMat2D _tmp;
        #endregion

        #region  对接外部数据
        /// <summary>
        /// 对接外部数据
        /// </summary>
        IOutsideRectangle2ROI _iOutSide = null;
        #endregion

        #endregion

        #region  属性

        #region  矩形端点
        /// <summary>
        /// 
        /// </summary>
        public double Mid_row_y
        {
            get { return _mid_row_y; }
            set { _mid_row_y = value; }
        }

        /// <summary>
        /// 
        /// </summary>
        public double Mid_col_x
        {
            get { return _mid_col_x; }
            set { _mid_col_x = value; }
        }

        /// <summary>
        /// 
        /// </summary>
        public double Len1
        {
            get { return _len1; }
            set { _len1 = value; }
        }

        /// <summary>
        /// 
        /// </summary>
        public double Len2
        {
            get { return _len2; }
            set { _len2 = value; }
        }

        /// <summary>
        /// 
        /// </summary>
        public double Phi
        {
            get { return _phi; }
            set { _phi = value; }
        }
        #endregion

        #region  角度操作点 无用代码

        ///// <summary>
        ///// 角度操作点
        ///// </summary>
        //public double Phi_row_y
        //{
        //    get { return _phi_row_y; }
        //    set { _phi_row_y = value; }
        //}

        ///// <summary>
        ///// 角度操作点
        ///// </summary>
        //public double Phi_col_x
        //{
        //    get { return _phi_col_x; }
        //    set { _phi_col_x = value; }
        //}

        #endregion

        #region  对接外部数据
        /// <summary>
        /// 对接外部数据
        /// </summary>
        public IOutsideRectangle2ROI IOutSide
        {
            get { return _iOutSide; }
            set { _iOutSide = value; }
        }
        #endregion

        #endregion

        #region  初始化
        /// <summary>
        /// 初始化
        /// </summary>
        internal Rectangle2ROI()
        {
            _operationing = -1;
            _operation_piont_number = 6;
        }
        #endregion

        #region  显示ROI
        /// <summary>
        /// 显示ROI
        /// </summary>
        /// <param name="hwin"></param>
        public override void displayROI(HalconDotNet.HWindow hwin)
        {
            hwin.DispRectangle2(this._mid_row_y, this._mid_col_x, -this._phi, this._len1, this._len2);
            hwin.DispLine(this._mid_row_y, this._mid_col_x, this._rows_y[5], this._cols_x[5]);
            if (this._operationing == -1)
            {
                //hwin.DispRectangle2(this.in
                for (int i = 0; i < this._operation_piont_number; i++)
                {
                    hwin.DispRectangle2(this._rows_y[i].D, this._cols_x[i].D, -this._phi, 5, 5);
                }
            }
            else
            {
                for (int i = 0; i < this._operation_piont_number; i++)
                {
                    if (i == this._operationing)
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

        #region  显示操作点
        /// <summary>
        /// 显示操作点
        /// </summary>
        /// <param name="number"></param>
        /// <param name="hwin"></param>
        public override void displayOperation(int number, HalconDotNet.HWindow hwin)
        {
            hwin.SetColor("red");
            hwin.DispRectangle2(this._rows_y[number].D, this._cols_x[number].D, -this._phi, 5, 5);
            hwin.SetColor("green");
            #region  无用代码
            //switch (number)
            //{
            //    case 0:
            //        hwin.SetColor("red");
            //        hwin.DispRectangle2(this.rows[0].D, this.cols[0].D, this._phi, 25, 25);
            //        hwin.SetColor("green");
            //        break;
            //    case 1:
            //        hwin.SetColor("red");
            //        hwin.DispRectangle2(this.rows[1].D, this.cols[1].D, this._phi, 25, 25);
            //        hwin.SetColor("green");
            //        break;
            //    case 2:
            //        hwin.SetColor("red");
            //        hwin.DispRectangle2(this.rows[0].D, this.cols[0].D, this._phi, 25, 25);
            //        hwin.SetColor("green");
            //        break;
            //    case 3:

            //        break;
            //    case 4:

            //        break;
            //    case 5:

            //        break;
            //    default:
            //        break;
            //}
            #endregion
        }
        #endregion

        #region   显示没有选中的操作点
        /// <summary>
        ///  显示没有选中的操作点
        /// </summary>
        /// <param name="number"></param>
        /// <param name="hwin"></param>
        void no_chice_point(int number, HalconDotNet.HWindow hwin)
        {
            hwin.DispRectangle2(this._rows_y[number].D, this._cols_x[number].D, -this._phi, 5, 5);
            #region  无用代码
            //switch (number)
            //{
            //    case 0:
            //        hwin.DispRectangle2(this._row_y1, this._col_x1, 0, 25, 25);
            //        break;

            //    case 1:
            //        hwin.DispRectangle2(this._row_y1, this._col_x2, 0, 25, 25);
            //        break;

            //    case 2:
            //        hwin.DispRectangle2(this._row_y2, this._col_x1, 0, 25, 25);
            //        break;

            //    case 3:
            //        hwin.DispRectangle2(this._row_y2, this._col_x2, 0, 25, 25);
            //        break;

            //    case 4:
            //        hwin.DispRectangle2(this._mid_row_y, this._mid_col_x, 0, 25, 25);
            //        break;
            //}
            #endregion
        }
        #endregion

        #region 是否选中
        /// <summary>
        /// 是否选中
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <returns></returns>
        public override int isSelected(double x, double y)
        {
            //return base.isSelected(x, y);
            this._operationing = -1;
            double max = 35;
            double[] val = new double[this._operation_piont_number];

            for (int i = 0; i < this._operation_piont_number; i++)
            {
                val[i] = HMisc.DistancePp(y, x, _rows_y[i].D, _cols_x[i].D);
            }

            for (int i = 0; i < this._operation_piont_number; i++)
            {
                if (val[i] < max)
                {
                    this._operationing = i;
                    break;
                }
            }
            return this._operationing;
        }
        #endregion

        #region  设置点位
        /// <summary>
        /// 设置点位
        /// </summary>
        /// <param name="col_x"></param>
        /// <param name="row_y"></param>
        public override void setOpoint(double col_x, double row_y)
        {
            double vX, vY, x = 0, y = 0;
            switch (this._operationing)
            {
                case 0:
                #region  无用代码
                //_tmp = _hom2D.HomMat2dInvert();
                //x = _tmp.AffineTransPoint2d(col_x, row_y, out y);

                //this._len2 = Math.Abs(y);
                //this._len1 = Math.Abs(x);
                #region  无用代码
                //col_x = col_x - this._mid_col_x;
                //row_y = row_y - this._mid_row_y;
                //checkForRange(col_x, row_y);
                #endregion
                //break;
                #endregion

                case 1:
                #region  无用代码
                //_tmp = _hom2D.HomMat2dInvert();
                //x = _tmp.AffineTransPoint2d(col_x, row_y, out y);

                //this._len2 = Math.Abs(y);
                //this._len1 = Math.Abs(x);
                #region  无用代码
                //col_x = col_x - this._mid_col_x;
                //row_y = row_y - this._mid_row_y;

                //checkForRange(col_x, row_y);
                #endregion

                //break;
                #endregion
                case 2:
                #region  无用代码
                //_tmp = _hom2D.HomMat2dInvert();
                //x = _tmp.AffineTransPoint2d(col_x, row_y, out y);
                //this._len2 = Math.Abs(y);
                //this._len1 = Math.Abs(x);
                #region  无用代码
                //col_x = col_x - this._mid_col_x;
                //row_y = row_y - this._mid_row_y;

                //checkForRange(col_x, row_y);
                #endregion
                //break;
                #endregion
                case 3:
                    _tmp = _hom2D.HomMat2dInvert();
                    x = _tmp.AffineTransPoint2d(col_x, row_y, out y);

                    this._len2 = Math.Abs(y);
                    this._len1 = Math.Abs(x);

                    //checkForRange(x,y);
                    #region  无用代码
                    //col_x = col_x - this._mid_col_x;
                    //row_y = row_y - this._mid_row_y;

                    //checkForRange(col_x, row_y);
                    #endregion
                    break;
                case 4:
                    this._mid_col_x = col_x;
                    this._mid_row_y = row_y;
                    break;
                case 5:
                    vY = row_y - _rows_y[4].D;
                    vX = col_x - _cols_x[4].D;
                    this._phi = Math.Atan2(vY, vX);
                    break;
                default:

                    break;
            }
            updateHandlePos();
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

        #region   检测region是否超出范围  无用代码
        /// <summary>
        /// 检测region是否超出范围
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        //private void checkForRange(double x, double y)
        //{
        //    switch (this._operationing)
        //    {
        //        case 0:
        //            if ((x < this._mid_col_x) && (y < this._mid_row_y))
        //                return;
        //            if (x >= this._mid_col_x) this._len1 = 0.01;
        //            if (y >= this._mid_row_y) this._len2 = 0.01;
        //            break;
        //        case 1:
        //            if ((x > this._mid_col_x) && (y < this._mid_row_y))
        //                return;
        //            if (x <= this._mid_col_x) this._len1 = 0.01;
        //            if (y >= this._mid_row_y) this._len2 = 0.01;
        //            break;
        //        case 2:
        //            if ((x > this._mid_col_x) && (y > this._mid_row_y))
        //                return;
        //            if (x <= this._mid_col_x) this._len1 = 0.01;
        //            if (y <= this._mid_row_y) this._len2 = 0.01;
        //            break;
        //        case 3:
        //            if ((x < this._mid_col_x) && (y > this._mid_row_y))
        //                return;
        //            if (x >= this._mid_col_x) this._len1 = 0.01;
        //            if (y <= this._mid_row_y) this._len2 = 0.01;
        //            break;
        //        default:
        //            break;
        //    }
        //}
        #endregion

        #region   创建矩形2
        /// <summary>
        ///  创建矩形2
        /// </summary>
        /// <param name="mid_row_y"></param>
        /// <param name="mid_col_x"></param>
        /// <param name="phi"></param>
        /// <param name="len1"></param>
        /// <param name="len2"></param>
        internal void create(double mid_row_y, double mid_col_x, double phi, double len1, double len2)
        {
            this._mid_row_y = mid_row_y;
            this._mid_col_x = mid_col_x;
            this._len1 = len1;
            this._len2 = len2;
            this._phi = phi;
            _rowsInit_y = new HTuple(new double[] {-1.0, -1.0, 1.0, 
												   1.0,  0.0, 0.0 });
            _colsInit_x = new HTuple(new double[] {-1.0, 1.0,  1.0, 
												  -1.0, 0.0, 0.6 });
            _hom2D = new HHomMat2D();
            _tmp = new HHomMat2D();
            updateHandlePos();

            updateInterface();
        }
        #endregion

        #region  更新操作点
        /// <summary>
        ///更新操作点
        /// </summary>
        private void updateHandlePos()
        {
            _hom2D.HomMat2dIdentity();
            _hom2D = _hom2D.HomMat2dTranslate(this._mid_col_x, this._mid_row_y);
            _hom2D = _hom2D.HomMat2dRotateLocal(this._phi);
            _tmp = _hom2D.HomMat2dScaleLocal(this._len1, this._len2);
            _cols_x = _tmp.AffineTransPoint2d(_colsInit_x, _rowsInit_y, out _rows_y);

            updateInterface();
        }
        #endregion

        #region  更新接口数据
        /// <summary>
        /// 更新接口数据
        /// </summary>
        void updateInterface()
        {
            if (_iOutSide != null)
            {
                _iOutSide.Len1 = _len1;
                _iOutSide.Len2 = _len2;
                _iOutSide.Phi = _phi;
                _iOutSide.Mid_col_x = _mid_col_x;
                _iOutSide.Mid_row_y = _mid_row_y;
            }

        }
        #endregion
    }

    #region   Rectangle2ROI对接外部的接口
    /// <summary>
    /// Rectangle2ROI对接外部的数据
    /// </summary>
    [Serializable]
    public class OutsideRectangle2ROI : IOutsideRectangle2ROI
    {
        #region   Rectangle2ROI对接外部的接口
        /// <summary>
        /// 
        /// </summary>
        [NonSerialized]
        HTuple _mid_row_y;

        /// <summary>
        /// 
        /// </summary>
        [NonSerialized]
        HTuple _mid_col_x;

        /// <summary>
        /// 
        /// </summary>
        [NonSerialized]
        HTuple _len1;

        /// <summary>
        /// 
        /// </summary>
        [NonSerialized]
        HTuple _len2;

        /// <summary>
        /// 
        /// </summary>
        [NonSerialized]
        HTuple _phi;

        #endregion

        #region   属性
        /// <summary>
        /// 
        /// </summary>
        public HTuple Mid_row_y
        {
            get { return _mid_row_y; }
            set { _mid_row_y = value; }
        }

        /// <summary>
        /// 
        /// </summary>
        public HTuple Mid_col_x
        {
            get { return _mid_col_x; }
            set { _mid_col_x = value; }
        }

        /// <summary>
        /// 
        /// </summary>
        public HTuple Len1
        {
            get { return _len1; }
            set { _len1 = value; }
        }

        /// <summary>
        /// 
        /// </summary>
        public HTuple Len2
        {
            get { return _len2; }
            set { _len2 = value; }
        }

        /// <summary>
        /// 
        /// </summary>
        public HTuple Phi
        {
            get { return _phi; }
            set { _phi = value; }
        }
        #endregion
    }

    /// <summary>
    /// Rectangle2ROI对接外部的接口
    /// </summary>
    public interface IOutsideRectangle2ROI
    {
        #region  矩形端点
        /// <summary>
        /// 
        /// </summary>
        HTuple Mid_row_y
        {
            get;
            set;
        }

        /// <summary>
        /// 
        /// </summary>
        HTuple Mid_col_x
        {
            get;
            set;
        }

        /// <summary>
        /// 
        /// </summary>
        HTuple Len1
        {
            get;
            set;
        }

        /// <summary>
        /// 
        /// </summary>
        HTuple Len2
        {
            get;
            set;
        }

        /// <summary>
        /// 
        /// </summary>
        HTuple Phi
        {
            get;
            set;
        }
        #endregion
    }
    #endregion

    #region   对外接口
    /// <summary>
    /// 对外接口
    /// </summary>
    public interface IOutsideRectangle2
    {
        /// <summary>
        /// 对外接口
        /// </summary>
        IOutsideRectangle2ROI IOutSide { get; set; }
    }
    #endregion

}
