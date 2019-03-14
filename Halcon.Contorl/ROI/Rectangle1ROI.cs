using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HalconDotNet;


namespace HalControl.ROI.Rectangle1
{
    /// <summary>
    /// 
    /// </summary>
    internal class Rectangle1ROI : ROI
    {
        #region  全局变量

        #region  矩形端点
        /// <summary>
        /// 
        /// </summary>
        double _row_y1;

        /// <summary>
        /// 
        /// </summary>
        double _col_x1;

        /// <summary>
        /// 
        /// </summary>
        double _row_y2;

        /// <summary>
        /// 
        /// </summary>
        double _col_x2;

        #endregion

        #region  中点

        /// <summary>
        /// 
        /// </summary>
        double _mid_row_y;

        /// <summary>
        /// 
        /// </summary>
        double _mid_col_x;

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

        #region  外部接口数据
        /// <summary>
        /// 外部接口数据
        /// </summary>
        IOutsideRectangle1ROI _iOutside = null;
        #endregion

        #endregion

        #region  属性

        #region  矩形端点
        /// <summary>
        /// 
        /// </summary>
        public double Row_y1
        {
            get { return _row_y1; }
            set { _row_y1 = value; }
        }

        /// <summary>
        /// 
        /// </summary>
        public double Col_x1
        {
            get { return _col_x1; }
            set { _col_x1 = value; }
        }

        /// <summary>
        /// 
        /// </summary>
        public double Row_y2
        {
            get { return _row_y2; }
            set { _row_y2 = value; }
        }

        /// <summary>
        /// 
        /// </summary>
        public double Col_x2
        {
            get { return _col_x2; }
            set { _col_x2 = value; }
        }
        #endregion

        #region  端点

        /// <summary>
        /// 
        /// </summary>
        public double Min_row_y
        {
            get { return _mid_row_y; }
            set { _mid_row_y = value; }
        }

        /// <summary>
        /// 
        /// </summary>
        public double Min_col_x
        {
            get { return _mid_col_x; }
            set { _mid_col_x = value; }
        }
        #endregion

        #region  外部接口数据
        /// <summary>
        /// 外部接口数据
        /// </summary>
        internal IOutsideRectangle1ROI IOutside
        {
            get { return _iOutside; }
            set { _iOutside = value; }
        }
        #endregion
        #endregion

        #region  初始化
        /// <summary>
        /// 初始化
        /// </summary>
        internal Rectangle1ROI()
        {
            _operationing = -1;
            _operation_piont_number = 5;
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
            switch (number)
            {
                case 0:

                    hwin.SetColor("red");
                    hwin.DispRectangle2(this._row_y1, this._col_x1, 0, 5, 5);
                    hwin.SetColor("green");

                    break;
                case 1:
                    hwin.SetColor("red");
                    hwin.DispRectangle2(this._row_y1, this._col_x2, 0, 5, 5);
                    hwin.SetColor("green");
                    break;
                case 2:
                    hwin.SetColor("red");
                    hwin.DispRectangle2(this._row_y2, this._col_x1, 0, 5, 5);
                    hwin.SetColor("green");
                    break;
                case 3:
                    hwin.SetColor("red");
                    hwin.DispRectangle2(this._row_y2, this._col_x2, 0, 5, 5);
                    hwin.SetColor("green");
                    break;
                case 4:
                    hwin.SetColor("red");
                    hwin.DispRectangle2(this._mid_row_y, this._mid_col_x, 0, 5, 5);
                    hwin.SetColor("green");
                    break;
                default:
                    break;
            }
        }
        #endregion

        #region  显示ROI
        /// <summary>
        /// 显示ROI
        /// </summary>
        /// <param name="hwin"></param>
        public override void displayROI(HalconDotNet.HWindow hwin)
        {
            hwin.DispRectangle1(this._row_y1, this._col_x1, this._row_y2, this._col_x2);

            if (this._operationing == -1)
            {
                hwin.DispRectangle2(this._row_y1, this._col_x1, 0, 5, 5);
                hwin.DispRectangle2(this._row_y1, this._col_x2, 0, 5, 5);
                hwin.DispRectangle2(this._row_y2, this._col_x1, 0, 5, 5);
                hwin.DispRectangle2(this._row_y2, this._col_x2, 0, 5, 5);
                hwin.DispRectangle2(this._mid_row_y, this._mid_col_x, 0, 5, 5);
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

        #region   显示没有选中的操作点
        /// <summary>
        ///  显示没有选中的操作点
        /// </summary>
        /// <param name="number"></param>
        /// <param name="hwin"></param>
        void no_chice_point(int number, HalconDotNet.HWindow hwin)
        {
            switch (number)
            {
                case 0:
                    hwin.DispRectangle2(this._row_y1, this._col_x1, 0, 5, 5);
                    break;

                case 1:
                    hwin.DispRectangle2(this._row_y1, this._col_x2, 0, 5, 5);
                    break;

                case 2:
                    hwin.DispRectangle2(this._row_y2, this._col_x1, 0, 5, 5);
                    break;

                case 3:
                    hwin.DispRectangle2(this._row_y2, this._col_x2, 0, 5, 5);
                    break;

                case 4:
                    hwin.DispRectangle2(this._mid_row_y, this._mid_col_x, 0, 5, 5);
                    break;
            }
        }
        #endregion

        #region  确定点是否被选中
        /// <summary>
        /// 确定点是否被选中
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <returns>返回-1表示没有被选中</returns>
        public override int isSelected(double x, double y)
        {
            _operationing = -1;
            double max = 35;
            double[] value = new double[_operation_piont_number];

            value[0] = HMisc.DistancePp(y, x, this._row_y1, this._col_x1);
            value[1] = HMisc.DistancePp(y, x, this._row_y1, this._col_x2);
            value[2] = HMisc.DistancePp(y, x, this._row_y2, this._col_x1);
            value[3] = HMisc.DistancePp(y, x, this._row_y2, this._col_x2);
            value[4] = HMisc.DistancePp(y, x, this._mid_row_y, this._mid_col_x);

            for (int i = 0; i < _operation_piont_number; i++)
            {
                if (value[i] < max)
                {
                    max = value[i];
                    _operationing = i;
                    break;
                }
            }

            return _operationing;
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
            switch (this._operationing)
            {
                case 0:
                    this._col_x1 = col_x;
                    this._row_y1 = row_y;
                    break;
                case 1:
                    this._row_y1 = row_y;
                    this._col_x2 = col_x;
                    break;
                case 2:
                    this._col_x1 = col_x;
                    this._row_y2 = row_y;
                    break;
                case 3:
                    this._col_x2 = col_x;
                    this._row_y2 = row_y;
                    break;
                case 4:
                    double len_row_y, len_col_x;
                    len_row_y = ((this._row_y2 - this._row_y1) / 2);
                    len_col_x = ((this._col_x2 - this._col_x1) / 2);

                    this._row_y1 = row_y - len_row_y;
                    this._row_y2 = row_y + len_row_y;

                    this._col_x1 = col_x - len_col_x;
                    this._col_x2 = col_x + len_col_x;

                    #region  无用代码
                    //len_col_x = this._col_x1 - this._mid_col_x;
                    //len_row_y = this._row_y1 - this._mid_row_y;

                    //this._mid_col_x = col_x;
                    //this._mid_row_y = row_y;

                    //this._col_x1 = len_col_x + this._mid_col_x;
                    //this._row_y1 = len_row_y + this._mid_row_y;

                    //this._col_x2 = this._mid_col_x - len_col_x;
                    //this._row_y2 = this._mid_row_y - len_row_y;
                    #endregion
                    break;
            }
            /*********************防止端点1大于端点2*********************************/
            if (this._row_y2 <= this._row_y1)
            {
                double temp = this._row_y1;
                this._row_y1 = this._row_y2;
                this._row_y2 = temp;
            }

            if (this._col_x2 <= this._col_x1)
            {
                double temp = this._col_x1;
                this._col_x1 = this._col_x2;
                this._col_x2 = temp;
            }
            /*********************更新中点*******************************/
            this._mid_col_x = (this._col_x1 + this._col_x2) / 2.0;
            this._mid_row_y = (this._row_y1 + this._row_y2) / 2.0;

            updateInterface();


        }
        #endregion

        #region  创建矩形
        /// <summary>
        /// 创建矩形
        /// </summary>
        /// <param name="row_y1"></param>
        /// <param name="col_x1"></param>
        /// <param name="row_y2"></param>
        /// <param name="col_x2"></param>
        internal void create(double row_y1, double col_x1, double row_y2, double col_x2)
        {
            this._row_y1 = row_y1;
            this._col_x1 = col_x1;
            this._row_y2 = row_y2;
            this._col_x2 = col_x2;
            this._mid_col_x = (this._col_x1 + this._col_x2) / 2.0;
            this._mid_row_y = (this._row_y1 + this._row_y2) / 2.0;
            updateInterface();
        }
        #endregion

        #region  更新接口数据
        /// <summary>
        /// 更新接口数据
        /// </summary>
        void updateInterface()
        {
            if (this._iOutside != null)
            {
                this._iOutside.Row_y1 = this._row_y1;
                this._iOutside.Col_x1 = this._col_x1;

                this._iOutside.Row_y2 = this._row_y2;
                this._iOutside.Col_x2 = this._col_x2;
            }

        }

        #endregion

        #region  无用代码
        //#region 对接外部数据
        ///// <summary>
        ///// 对接外部数据
        ///// </summary>
        ///// <returns></returns>
        //public override IOutside iOutSide()
        //{
        //    return (IOutside)_iOutside;
        //}
        //#endregion
        #endregion
    }

    #region  矩形接口
    /// <summary>
    /// 外部接口数据
    /// </summary>
    public class OutSideRectangle1ROI : IOutsideRectangle1ROI
    {
        #region  矩形端点
        /// <summary>
        /// 矩形端点
        /// </summary>
        private HTuple _row_y1;
        /// <summary>
        /// 矩形端点
        /// </summary>
        private HTuple _col_x1;
        /// <summary>
        /// 矩形端点
        /// </summary>
        private HTuple _row_y2;
        /// <summary>
        /// 矩形端点
        /// </summary>
        private HTuple _col_x2;
        #endregion

        #region   矩形端点属性
        /// <summary>
        /// 矩形端点1
        /// </summary>
        public HTuple Row_y1
        {
            get
            {
                return _row_y1;
            }
            set
            {
                _row_y1 = value;
            }
        }

        /// <summary>
        /// 矩形端点2
        /// </summary>
        public HTuple Col_x1
        {
            get { return _col_x1; }
            set { _col_x1 = value; }
        }

        /// <summary>
        /// 矩形端点2
        /// </summary>
        public HTuple Row_y2
        {
            get { return _row_y2; }
            set { _row_y2 = value; }
        }

        /// <summary>
        /// 矩形端点2
        /// </summary>
        public HTuple Col_x2
        {
            get { return _col_x2; }
            set { _col_x2 = value; }
        }

        #endregion
    }

    /// <summary>
    /// 矩形接口
    /// </summary>
    public interface IOutsideRectangle1ROI
    {
        #region  矩形端点
        /// <summary>
        /// 矩形端点1
        /// </summary>
        HTuple Row_y1
        {
            get;
            set;
        }

        /// <summary>
        /// 矩形端点1
        /// </summary>
        HTuple Col_x1
        {
            get;
            set;
        }

        /// <summary>
        /// 矩形端点2
        /// </summary>
        HTuple Row_y2
        {
            get;
            set;
        }

        /// <summary>
        /// 矩形端点2
        /// </summary>
        HTuple Col_x2
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
    public interface IOutsideRectangle1
    {
        /// <summary>
        /// 对外接口
        /// </summary>
        IOutsideRectangle1ROI IOutSide { get; set; }
    }
    #endregion
}
