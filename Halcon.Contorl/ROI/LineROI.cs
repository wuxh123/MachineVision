using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HalconDotNet;


namespace HalControl.ROI.Line
{
    /// <summary>
    /// 
    /// </summary>
    internal class LineROI : ROI
    {
        #region  全局变量

        #region  直线的开端点
        /// <summary>
        /// 线的开头点
        /// </summary>
        double _row_y1;

        /// <summary>
        /// 线的开头点
        /// </summary>
        double _cols_x1;

        /// <summary>
        /// 线的结束点
        /// </summary>
        double _row_y2;

        /// <summary>
        /// 线的结束点
        /// </summary>
        double _cols_x2;
        #endregion

        #region  中心点

        /// <summary>
        /// 直线的中心点x
        /// </summary>
        double _mid_row_y;

        /// <summary>
        /// 直线的中心点y
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

        #region   外部数据
        /// <summary>
        /// 外部数据
        /// </summary>
        IOutsideLineROI _iOutSide = null;

        #endregion

        #endregion

        #region  初始化
        /// <summary>
        /// 初始化
        /// </summary>
        internal LineROI()
        {
            _operationing = -1;
            _operation_piont_number = 3;
        }
        #endregion

        #region  属性

        /// <summary>
        /// 线的开头点
        /// </summary>
        public double Row1
        {
            get { return _row_y1; }
            set { _row_y1 = value; }
        }

        /// <summary>
        /// 线的开头点
        /// </summary>
        public double Cols1
        {
            get { return _cols_x1; }
            set { _cols_x1 = value; }
        }

        /// <summary>
        /// 线的结束点
        /// </summary>
        public double Row2
        {
            get { return _row_y2; }
            set { _row_y2 = value; }
        }

        /// <summary>
        /// 线的结束点
        /// </summary>
        public double Cols2
        {
            get { return _cols_x2; }
            set { _cols_x2 = value; }
        }


        /// <summary>
        /// 外部数据
        /// </summary>
        public IOutsideLineROI IOutSide
        {
            get { return _iOutSide; }
            set { _iOutSide = value; }
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
                    hwin.DispRectangle2(this._row_y1, this._cols_x1, 0, 5, 5);
                    hwin.SetColor("green");
                    break;
                case 1:
                    hwin.SetColor("red");
                    hwin.DispRectangle2(this._row_y2, this._cols_x2, 0, 5, 5);
                    hwin.SetColor("green");
                    break;
                case 2:
                    hwin.SetColor("red");
                    hwin.DispRectangle2(this._mid_row_y, this._mid_col_x, 0, 5, 5);
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
        void no_chice_point(int number, HalconDotNet.HWindow hwin)
        {
            switch (number)
            {
                case 0:
                    hwin.DispRectangle2(this._row_y1, this._cols_x1, 0, 5, 5);
                    break;

                case 1:
                    hwin.DispRectangle2(this._row_y2, this._cols_x2, 0, 5, 5);
                    break;

                case 2:
                    hwin.DispRectangle2(this._mid_row_y, this._mid_col_x, 0, 5, 5);
                    break;
            }
        }
        #endregion

        #region  ROI是否被选中
        /// <summary>
        /// ROI是否被选中 
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <returns></returns>
        public override int isSelected(double x, double y)
        {
            _operationing = -1;

            double max = 35;
            double[] value = new double[_operation_piont_number];

            value[0] = HMisc.DistancePp(y, x, this._row_y1, this._cols_x1);
            value[1] = HMisc.DistancePp(y, x, this._row_y2, this._cols_x2);
            value[2] = HMisc.DistancePp(y, x, this._mid_row_y, this._mid_col_x);

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

        #region  显示ROI
        /// <summary>
        /// 显示ROI
        /// </summary>
        /// <param name="hwin"></param>
        public override void displayROI(HalconDotNet.HWindow hwin)
        {

            hwin.DispLine(this._row_y1, this._cols_x1, this._row_y2, this._cols_x2);

            if (this._operationing == -1)
            {
                hwin.DispRectangle2(_row_y1, _cols_x1, 0, 5, 5);
                hwin.DispRectangle2(_row_y2, _cols_x2, 0, 5, 5);
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

        #region  设置选中点的位置
        /// <summary>
        /// 设置选中点的位置
        /// </summary>
        /// <param name="col_x"></param>
        /// <param name="row_y"></param>
        public override void setOpoint(double col_x, double row_y)
        {
            switch (_operationing)
            {
                case 0://开头点
                    this._cols_x1 = col_x;
                    this._row_y1 = row_y;

                    /*******刷新中点********/
                    _mid_row_y = (this._row_y1 + this._row_y2) / 2.0;
                    _mid_col_x = (this._cols_x1 + this._cols_x2) / 2.0;
                    break;

                case 1://结束点
                    this._cols_x2 = col_x;
                    this._row_y2 = row_y;

                    /********刷新中点**********/
                    _mid_row_y = (this._row_y1 + this._row_y2) / 2.0;
                    _mid_col_x = (this._cols_x1 + this._cols_x2) / 2.0;
                    break;

                case 2://中点
                    double len_row_y, len_col_x;

                    len_row_y = this._row_y1 - _mid_row_y;
                    len_col_x = this._cols_x1 - _mid_col_x;

                    _mid_row_y = row_y;
                    _mid_col_x = col_x;

                    /*******刷新端点*********/
                    this._row_y1 = _mid_row_y + len_row_y;
                    this._cols_x1 = _mid_col_x + len_col_x;
                    this._row_y2 = _mid_row_y - len_row_y;
                    this._cols_x2 = _mid_col_x - len_col_x;

                    break;
            }

            updateInterface();

        }
        #endregion

        #region   创建一条直线
        /// <summary>
        /// 创建一条直线
        /// </summary>
        /// <param name="row_y1"></param>
        /// <param name="col_x1"></param>
        /// <param name="row_y2"></param>
        /// <param name="col_x2"></param>
        internal void create(double row_y1, double col_x1, double row_y2, double col_x2)
        {
            this._cols_x1 = col_x1;
            this._row_y1 = row_y1;
            this._cols_x2 = col_x2;
            this._row_y2 = row_y2;
            _mid_row_y = (this._row_y1 + this._row_y2) / 2.0;
            _mid_col_x = (this._cols_x1 + this._cols_x2) / 2.0;

            updateInterface();
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
                this._iOutSide.Row1 = this._row_y1;
                this._iOutSide.Cols1 = this._cols_x1;
                this._iOutSide.Row2 = this._row_y2;
                this._iOutSide.Cols2 = this._cols_x2;
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

    #region  对接外部数据
    /// <summary>
    /// 对接外部数据
    /// </summary>
    [Serializable]
    public class OutsideLineROI : IOutsideLineROI
    {
        #region  直线端点
        /// <summary>
        /// 直线端点
        /// </summary>
        [NonSerialized]
        private HTuple _row1;

        /// <summary>
        /// 直线端点
        /// </summary>
       [NonSerialized]
        private HTuple _cols1;

        /// <summary>
        /// 直线端点
        /// </summary>
       [NonSerialized]
        private HTuple _row2;

        /// <summary>
        /// 直线端点
        /// </summary>
        [NonSerialized]
        private HTuple _cols2;

        #endregion

        #region  属性

        #region  直线端点
        /// <summary>
        /// 直线端点
        /// </summary>
        public HTuple Row1
        {
            get { return _row1; }
            set { _row1 = value; }
        }

        /// <summary>
        /// 直线端点
        /// </summary>
        public HTuple Cols1
        {
            get { return _cols1; }
            set { _cols1 = value; }
        }

        /// <summary>
        /// 直线端点
        /// </summary>
        public HTuple Row2
        {
            get { return _row2; }
            set { _row2 = value; }
        }

        /// <summary>
        /// 直线端点
        /// </summary>
        public HTuple Cols2
        {
            get { return _cols2; }
            set { _cols2 = value; }
        }
        #endregion

        #endregion
    }

    /// <summary>
    /// 数据对外数据接口
    /// </summary>
    public interface IOutsideLineROI
    {
        #region  属性
        /// <summary>
        /// 线的开头点
        /// </summary>
        HTuple Row1
        {
            get;
            set;
        }

        /// <summary>
        /// 线的开头点
        /// </summary>
        HTuple Cols1
        {
            get;
            set;
        }

        /// <summary>
        /// 线的结束点
        /// </summary>
        HTuple Row2
        {
            get;
            set;
        }

        /// <summary>
        /// 线的结束点
        /// </summary>
        HTuple Cols2
        {
            get;
            set;
        }
        #endregion
    }
    #endregion

    #region     对外接口
    /// <summary>
    /// 对外接口
    /// </summary>
    public interface IOutsideLine
    {
        /// <summary>
        /// 对外接口
        /// </summary>
        IOutsideLineROI IOutSide { get; set; }
    }
    #endregion
}
