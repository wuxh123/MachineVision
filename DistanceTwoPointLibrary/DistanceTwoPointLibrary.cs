using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using HalconDotNet;

using MultTree;
using RectLibrary;
using CalibrationLibrary;


namespace DistanceTwoPointLibrary
{
    #region  两点间距离的数据
    /// <summary>
    /// 两点间距离的数据
    /// </summary>
    [Serializable]
    public class DistanceTwoPointShuJu : MultTree.ToolDateFather, IDistanceTwoPointShuJu
    {
        #region  全局变量

        #region  第一点
        /// <summary>
        /// 第二点    
        /// </summary>
        IRectShuJuPianYi _irectShuJuPianYiOne = null;
        #endregion

        #region  第二点
        /// <summary>
        /// 第二点    
        /// </summary>
        IRectShuJuPianYi _irectShuJuPianYiTwo = null;
        #endregion

        #region   两点的距离
        /// <summary>
        /// 两点的距离
        /// </summary>
        [NonSerialized]
        HTuple _distanceTwoPoint;

        #endregion

        #region   两点的直线
        /// <summary>
        /// 两点的直线
        /// </summary>
        [NonSerialized]
        HObject _ho_crossLine = null;
        #endregion

        #region   端点的region
        /// <summary>
        ///端点的region 
        /// </summary>
        [NonSerialized]
        HObject _ho_Point;
        #endregion

        #region  第一个点的路径
        /// <summary>
        /// 第一个点的路径
        /// </summary>
        string _pathOne = null;
        #endregion

        #region   第二个点的路径
        /// <summary>
        /// 第二个点的路径
        /// </summary>
        string _pathTwo = null;
        #endregion

        #region   结果
        /// <summary>
        /// 结果
        /// </summary>
        [NonSerialized]
        Result_DistanceTwoPoint _result = new Result_DistanceTwoPoint();
        #endregion

        #endregion

        #region   属性

        #region  第一点
        /// <summary>
        /// 第一点    
        /// </summary>
        public IRectShuJuPianYi IrectShuJuPianYiOne
        {
            get { return _irectShuJuPianYiOne; }
            set { _irectShuJuPianYiOne = value; }
        }
        #endregion

        #region  第二点
        /// <summary>
        /// 第二点    
        /// </summary>
        public IRectShuJuPianYi IrectShuJuPianYiTwo
        {
            get { return _irectShuJuPianYiTwo; }
            set { _irectShuJuPianYiTwo = value; }
        }
        #endregion

        #region  两点的直线
        /// <summary>
        /// 两点的直线
        /// </summary>
        public HObject Ho_crossLine
        {
            get
            {
                if (_ho_crossLine == null)
                {
                    HOperatorSet.GenEmptyObj(out _ho_crossLine);
                    _ho_crossLine.Dispose();
                }
                return _ho_crossLine;
            }
            set { _ho_crossLine = value; }
        }
        #endregion

        #region 第一个点的路径
        /// <summary>
        /// 第一个点的路径
        /// </summary>
        public string PathOne
        {
            get
            {
                if (_pathOne == null)
                {
                    _pathOne = "";
                }
                return _pathOne;
            }
            set { _pathOne = value; }
        }
        #endregion

        #region  第二个点的路径
        /// <summary>
        /// 第二个点的路径
        /// </summary>
        public string PathTwo
        {
            get
            {
                if (_pathTwo == null)
                {
                    _pathTwo = "";
                }
                return _pathTwo;
            }
            set { _pathTwo = value; }
        }
        #endregion

        #region  端点的region
        /// <summary>
        ///端点的region 
        /// </summary>
        public HObject Ho_Point
        {
            get
            {
                if (_ho_Point == null)
                {
                    HOperatorSet.GenEmptyObj(out _ho_Point);
                    _ho_Point.Dispose();
                }
                return _ho_Point;
            }
            set { _ho_Point = value; }
        }
        #endregion

        #region  两点的距离
        /// <summary>
        /// 两点的距离
        /// </summary>
        public HTuple DistanceTwoPoint
        {
            get { return _distanceTwoPoint; }
            set { _distanceTwoPoint = value; }
        }
        #endregion

        #endregion

        #region   序列化数据



        #endregion

        #region   初始化
        /// <summary>
        /// 初始化
        /// </summary>
        public override void init()
        {
            base.init();
            this._result = new Result_DistanceTwoPoint();
        }
        #endregion

        #region  保存数据
        /// <summary>
        /// 保存数据
        /// </summary>
        public override void save()
        {
            base.save();
        }
        #endregion

        #region  检测
        /// <summary>
        /// 检测
        /// </summary>
        /// <param name="ho_Image"></param>
        /// <param name="hwin"></param>
        /// <param name="Key"></param>
        /// <param name="_dictionary_resulte"></param>
        /// <returns></returns>
        public override bool analyze_show(HWindow hwin, string Key, ref Dictionary<string, object> _dictionary_resulte)
        {
            bool ok = false;

            if ((IrectShuJuPianYiOne != null) && (IrectShuJuPianYiTwo != null))
            {
                HTuple distance_;

                HOperatorSet.DistancePp(IrectShuJuPianYiOne.Row, IrectShuJuPianYiOne.Column, IrectShuJuPianYiTwo.Row, IrectShuJuPianYiTwo.Column, out distance_);
                HOperatorSet.LineOrientation(IrectShuJuPianYiOne.Row, IrectShuJuPianYiOne.Column, IrectShuJuPianYiTwo.Row, IrectShuJuPianYiTwo.Column, out this.angle);

                HTuple row_ = new HTuple(), col_ = new HTuple();
                HObject ho_cross;
                HOperatorSet.GenEmptyObj(out ho_cross);
                row_[0] = IrectShuJuPianYiOne.Row;
                row_[1] = IrectShuJuPianYiTwo.Row;
                row_[2] = (row_[0].D + row_[1].D) / 2;

                col_[0] = IrectShuJuPianYiOne.Column;
                col_[1] = IrectShuJuPianYiTwo.Column;
                col_[2] = (col_[0].D + col_[1].D) / 2;

                HOperatorSet.GenContourPolygonXld(out ho_cross, row_, col_);
                Ho_crossLine.Dispose();
                Ho_crossLine = ho_cross;

                HObject ho_xld;
                HOperatorSet.GenEmptyObj(out ho_xld);
                HOperatorSet.GenCrossContourXld(out ho_xld, row_, col_, 60, 0.78);
                Ho_Point.Dispose();
                Ho_Point = ho_xld;

                Column = col_[2];
                Row = row_[2];

                DistanceTwoPoint = distance_;


                /*********数据分析***********/
                //Result_DistanceTwoPoint result_ = new Result_DistanceTwoPoint();
                Key = "DistanceTwoPoint_" + Key;
                _result._tolatName = Key;
                if ((IrectShuJuPianYiOne.Row.Length > 0) && (IrectShuJuPianYiTwo.Column.Length > 0))
                {
                    _result._distance = DistanceTwoPoint;
                    _result._centerCol = Column;
                    _result._centerRow = Row;
                    _result._angle = Angle;
                    _result._tolatResult = true;

                    if (this._ICalibration != null)
                    {
                        HTuple row1_ = row_[0];
                        HTuple col1_ = col_[0];
                        HTuple row2_ = row_[1];
                        HTuple col2_ = col_[1];
                        this.Cal(this._ICalibration.HomMat2D, ref row1_, ref col1_);
                        this.Cal(this._ICalibration.HomMat2D, ref row2_, ref col2_);
                        HOperatorSet.DistancePp(row1_, col1_, row2_, col2_, out  _result._distance);
                        this.Cal(this._ICalibration.HomMat2D, ref _result._centerRow, ref _result._centerCol);
                    }

                    ok = true;
                }
                else
                {
                    _result._distance = 0;
                    _result._centerCol = 0;
                    _result._centerRow = 0;
                    _result._tolatResult = false;
                }
                _dictionary_resulte.Add(Key, _result);

                /**********显示**************/
                show(hwin);
            }
            return ok;
        }
        #endregion

        #region  显示
        /// <summary>
        /// 显示
        /// </summary>
        /// <param name="hwin"></param>
        /// <returns></returns>
        public override bool show(HWindow hwin)
        {
            bool ok = false;

            if (Ho_crossLine.IsInitialized() && Ho_Point.IsInitialized())
            {
                hwin.DispObj(Ho_crossLine);
                hwin.DispObj(Ho_Point);
                ok = true;
            }
            return ok;
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

    #region   数据接口
    /// <summary>
    /// 数据接口
    /// </summary>
    public interface IDistanceTwoPointShuJu : MultTree.IToolDateFather, ILineStruct
    {
        #region   属性

        #region  第一点
        /// <summary>
        /// 第一点    
        /// </summary>
        IRectShuJuPianYi IrectShuJuPianYiOne
        {
            get;
            set;
        }
        #endregion

        #region  第二点
        /// <summary>
        /// 第二点    
        /// </summary>
        IRectShuJuPianYi IrectShuJuPianYiTwo
        {
            get;
            set;
        }
        #endregion

        #region  两点的直线
        /// <summary>
        /// 两点的直线
        /// </summary>
        HObject Ho_crossLine
        {
            get;
            set;
        }
        #endregion

        #region 第一个点的路径
        /// <summary>
        /// 第一个点的路径
        /// </summary>
        string PathOne
        {
            get;
            set;
        }
        #endregion

        #region  第二个点的路径
        /// <summary>
        /// 第二个点的路径
        /// </summary>
        string PathTwo
        {
            get;
            set;
        }
        #endregion

        #region  端点的region
        /// <summary>
        ///端点的region 
        /// </summary>
        HObject Ho_Point
        {
            get;
            set;
        }
        #endregion

        #region  两点的距离
        /// <summary>
        /// 两点的距离
        /// </summary>
        HTuple DistanceTwoPoint
        {
            get;
            set;
        }
        #endregion

        #endregion
    }
    #endregion

    #region 数据设置器
    /// <summary>
    /// 数据设置器
    /// </summary>
    public class Set_DistanceTwoPiont:MultTree.SetFather
    {

        #region  确定第一个点
        /// <summary>
        /// 确定第一个点
        /// </summary>
        /// <param name="iDstanceTwo_"></param>
        /// <param name="iRect_"></param>
        /// <returns></returns>
        public bool Set_QueDingDiYiGeDian(IDistanceTwoPointShuJu iDstanceTwo_, Object diYiGeDian_)
        {
            bool ok = false;
            var ir_ = diYiGeDian_ as IRectShuJuPianYi;
            if ((ir_ is IRectShuJuPianYi))
            {
                if (ir_.Column != null)
                {
                    iDstanceTwo_.IrectShuJuPianYiOne = ir_;
                    ok = true;
                }
            }
            return ok;
        }
        #endregion

        #region  确定第二个点
        /// <summary>
        /// 确定第二个点
        /// </summary>
        /// <param name="iDstanceTwo_"></param>
        /// <param name="diYiGeDian_"></param>
        /// <returns></returns>
        public bool Set_QueDingDiErGeDian(IDistanceTwoPointShuJu iDstanceTwo_, Object diErGeDian_)
        {
            bool ok = false;

            var ir_ = diErGeDian_ as IRectShuJuPianYi;

            if ((ir_ is IRectShuJuPianYi))
            {
                if (ir_.Column != null)
                {
                    iDstanceTwo_.IrectShuJuPianYiTwo = ir_;
                    ok = true;
                }
            }
            return ok;
        }
        #endregion

        #region   显示数据
        /// <summary>
        /// 显示数据
        /// </summary>
        /// <param name="iDstanceTwo_"></param>
        /// <param name="list_One"></param>
        /// <param name="list_Two"></param>
        public void Set_showParameter(IDistanceTwoPointShuJu iDstanceTwo_,ListBox list_One,ListBox list_Two)
        {

            iDstanceTwo_.PathOne = this.panDuanToolShiFouCunZai(iDstanceTwo_.PathOne);
            if (iDstanceTwo_.PathOne == "")
            {
                iDstanceTwo_.IrectShuJuPianYiOne = null;
            }
            else
            {
                list_One.Items.Add(iDstanceTwo_.PathOne);
            }

            iDstanceTwo_.PathTwo = this.panDuanToolShiFouCunZai(iDstanceTwo_.PathTwo);
            if (iDstanceTwo_.PathTwo == "")
            {
                iDstanceTwo_.IrectShuJuPianYiTwo = null;
            }
            else
            {
                list_Two.Items.Add(iDstanceTwo_.PathTwo);
            }
        }
        #endregion

    }
    #endregion

    //#region   数据分析器
    ///// <summary>
    ///// 数据分析器
    ///// </summary>
    //public class DistanceTwoPiont
    //{
    //    #region  显示
    //    /// <summary>
    //    /// 显示
    //    /// </summary>
    //    /// <param name="iDistance_"></param>
    //    /// <returns></returns>
    //    public bool show(IDistanceTwoPointShuJu iDistance_, HWindow hwin)
    //    {
    //        bool ok = false;
    //        if (iDistance_.Row.Length > 0)
    //        {
    //            hwin.DispObj(iDistance_.Ho_crossLine);
    //            hwin.DispObj(iDistance_.Ho_Point);
    //        }
    //        ok = true;
    //        return ok;
    //    }
    //    #endregion

    //    #region   分析
    //    /// <summary>
    //    /// 分析
    //    /// </summary>
    //    /// <param name="iDistance_"></param>
    //    /// <returns></returns>
    //    public bool Analyze(IDistanceTwoPointShuJu iDistance_, HObject ho_Image)
    //    {
    //        bool ok = false;
    //        if ((iDistance_.IrectShuJuPianYi.Row.Length > 0) && (iDistance_.IrectShuJuPianYiTwo.Column.Length > 0))
    //        {
    //            HTuple distance_;

    //            HOperatorSet.DistancePp(iDistance_.IrectShuJuPianYi.Row, iDistance_.IrectShuJuPianYi.Column, iDistance_.IrectShuJuPianYiTwo.Row, iDistance_.IrectShuJuPianYiTwo.Column, out distance_);

    //            HTuple row_ = new HTuple(), col_ = new HTuple();
    //            HObject ho_cross;
    //            HOperatorSet.GenEmptyObj(out ho_cross);
    //            row_[0] = iDistance_.IrectShuJuPianYi.Row;
    //            row_[1] = iDistance_.IrectShuJuPianYiTwo.Row;
    //            row_[2] = (row_[0].D + row_[1].D) / 2;

    //            col_[0] = iDistance_.IrectShuJuPianYi.Column;
    //            col_[1] = iDistance_.IrectShuJuPianYiTwo.Column;
    //            col_[2] = (col_[0].D + col_[1].D) / 2;

    //            HOperatorSet.GenContourPolygonXld(out ho_cross, row_, col_);
    //            iDistance_.Ho_crossLine.Dispose();
    //            iDistance_.Ho_crossLine = ho_cross;

    //            HObject ho_xld;
    //            HOperatorSet.GenEmptyObj(out ho_xld);
    //            HOperatorSet.GenCrossContourXld(out ho_xld, row_, col_, 60, 0.78);
    //            iDistance_.Ho_Point = ho_xld;

    //            iDistance_.Column = col_[2];
    //            iDistance_.Row = row_[2];




    //            ok = true;
    //        }
    //        return ok;
    //    }

    //    #endregion

    //    #region   显示  分析  保存
    //    /// <summary>
    //    /// 显示  分析  保存
    //    /// </summary>
    //    /// <param name="ho_Image"></param>
    //    /// <param name="iDistance_"></param>
    //    /// <param name="hwin"></param>
    //    /// <param name="Key"></param>
    //    /// <param name="_dictionary_resulte"></param>
    //    /// <returns></returns>
    //    public bool show_analyze_save(HObject ho_Image, IDistanceTwoPointShuJu iDistance_, HWindow hwin, string Key, ref Dictionary<string, Object> _dictionary_resulte)
    //    {
    //        bool ok = false;
    //        if ((iDistance_.IrectShuJuPianYi.Row.Length > 0) && (iDistance_.IrectShuJuPianYiTwo.Column.Length > 0))
    //        {
    //            HTuple distance_;
    //            HOperatorSet.DistancePp(iDistance_.IrectShuJuPianYi.Row, iDistance_.IrectShuJuPianYi.Column, iDistance_.IrectShuJuPianYiTwo.Row, iDistance_.IrectShuJuPianYiTwo.Column, out distance_);

    //            HTuple row_ = new HTuple(), col_ = new HTuple();
    //            HObject ho_cross;
    //            HOperatorSet.GenEmptyObj(out ho_cross);
    //            row_[0] = iDistance_.IrectShuJuPianYi.Row;
    //            row_[1] = iDistance_.IrectShuJuPianYiTwo.Row;
    //            row_[2] = (row_[0].D + row_[1].D) / 2;

    //            col_[0] = iDistance_.IrectShuJuPianYi.Column;
    //            col_[1] = iDistance_.IrectShuJuPianYiTwo.Column;
    //            col_[2] = (col_[0].D + col_[1].D) / 2;

    //            iDistance_.Row = row_[2].D;
    //            iDistance_.Column = col_[2].D;
    //            iDistance_.Angle = 0;

    //            HOperatorSet.GenContourPolygonXld(out ho_cross, row_, col_);
    //            iDistance_.Ho_crossLine.Dispose();
    //            iDistance_.Ho_crossLine = ho_cross;

    //            HObject ho_xld;
    //            HOperatorSet.GenEmptyObj(out ho_xld);
    //            HOperatorSet.GenCrossContourXld(out ho_xld, row_, col_, 60, 0.78);
    //            iDistance_.Ho_Point.Dispose();
    //            iDistance_.Ho_Point = ho_xld;

    //            /*********数据分析***********/
    //            Result_DistanceTwoPoint result_ = new Result_DistanceTwoPoint();
    //            Key = "DistanceTwoPoint_" + Key;
    //            result_._tolatName = Key;
    //            result_analyze(iDistance_, ref result_);
    //            _dictionary_resulte.Add(Key, result_);

    //            if (result_._tolatResult)
    //            {
    //                hwin.DispObj(iDistance_.Ho_crossLine);
    //                hwin.DispObj(iDistance_.Ho_Point);
    //                ok = true;
    //            }
    //        }
    //        return ok;
    //    }

    //    #endregion

    //    #region   结果分析
    //    /// <summary>
    //    /// 结果分析
    //    /// </summary>
    //    /// <param name="iDistance_"></param>
    //    /// <param name="_result"></param>
    //    /// <returns></returns>
    //    public bool result_analyze(IDistanceTwoPointShuJu iDistance_, ref  Result_DistanceTwoPoint _result)
    //    {
    //        bool ok = false;

    //        if ((iDistance_.IrectShuJuPianYi.Row.Length > 0) && (iDistance_.IrectShuJuPianYiTwo.Column.Length > 0))
    //        {
    //            _result._distance = iDistance_.DistanceTwoPoint;
    //            _result._centerCol = iDistance_.Column;
    //            _result._centerRow = iDistance_.Row;
    //            _result._tolatResult = true;
    //            ok = true;
    //        }
    //        else
    //        {
    //            _result._distance = 0;
    //            _result._centerCol = 0;
    //            _result._centerRow = 0;
    //            _result._tolatResult = false;
    //        }

    //        return ok;
    //    }

    //    #endregion
    //}
    //#endregion

    #region  结果类
    /// <summary>
    /// 结果类
    /// </summary>
    public class Result_DistanceTwoPoint : MultTree.ClassResultFather
    {

        /// <summary>
        /// 距离
        /// </summary>
        public HTuple _distance=0;
        /// <summary>
        /// y
        /// </summary>
        public HTuple _centerRow=0;
        /// <summary>
        /// x
        /// </summary>
        public HTuple _centerCol=0;
        /// <summary>
        /// a
        /// </summary>
        public HTuple _angle=0;

        /// <summary>
        /// 显示
        /// </summary>
        /// <param name="str_array"></param>
        /// <returns></returns>
        public override bool showResult(out string[] str_array)
        {
            bool ok = false;
            str_array = new string[6];

            str_array[0] = this._tolatName;
            str_array[1] = this._tolatResult.ToString();
            if (this._tolatResult)
            {
                str_array[2] = "x坐标:" + this._centerCol.D.ToString();
                str_array[3] = "y坐标:" + this._centerRow.D.ToString();
                str_array[4] = "a角度:" + this._angle.D.ToString();
                str_array[5] = "l距离:" + this._distance.D.ToString();
            }
            else
            {
                str_array[2] = "x坐标:0";
                str_array[3] = "y坐标:0";
                str_array[4] = "a角度:0";
                str_array[5] = "l距离:0";
            }
            return ok;
        }

    }
    #endregion
}
