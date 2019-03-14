using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using HalconDotNet;
using RectLibrary;
using MultTree;


namespace DistancePointToLineLibrary
{

    #region  点到线的距离数据
    /// <summary>
    /// 点到线的距离数据
    /// </summary>
    [Serializable]
    public class DistancePointToLineShuJu : ToolDateFather, IDistancePointToLineShuJu
    {
        #region  全局变量

        #region  投影到直线的点  投影线的第二个点
        /// <summary>
        /// 投影到直线的点  投影线的第二个点
        /// </summary>
        RectLibrary.IRectShuJuPianYi _irectShuJuPianYiTwo = new RectShuJuPianYi();
        #endregion

        #region  投影到直线的点  投影线的第一个点
        /// <summary>
        ///   投影线的第一个点
        /// </summary>
        RectLibrary.IRectShuJuPianYi _irectShuJuPianYiOne = new RectShuJuPianYi();
        #endregion

        #region  点到直线的投影线
        /// <summary>
        /// 点到直线的投影线
        /// </summary>
        [NonSerialized]
        HObject ho_cross = null;
        #endregion

        #region   点到直线的距离
        /// <summary>
        /// 点到直线的距离
        /// </summary>
        [NonSerialized]
        HTuple _distance = 0;
        #endregion

        #region  直线的地址
        /// <summary>
        /// 直线的地址
        /// </summary>
        string _pathLine = "";
        #endregion

        #region  点的地址
        /// <summary>
        /// 点的地址
        /// </summary>
        string _pathPoint = "";
        #endregion

        #region  直线
        /// <summary>
        /// 直线
        /// </summary>
        ILineStruct _iLine;
        #endregion

        #region  直线的端点  跟  中点
        /// <summary>
        /// 直线的端电脑  跟  中点
        /// </summary>
        [NonSerialized]
        HObject _zhiXianDeDuanDianGenZhongDian;
        #endregion

        #region   结果
        /// <summary>
        /// 结果
        /// </summary>
        [NonSerialized]
        DistancePointToLine_Result _result = new DistancePointToLine_Result();
        #endregion

        #endregion

        #region  属性

        #region  点到直线的投影线
        /// <summary>
        /// 点到直线的投影线
        /// </summary>
        public HObject Ho_cross
        {
            get
            {
                if (ho_cross == null)
                {
                    HOperatorSet.GenEmptyObj(out ho_cross);

                }
                return ho_cross;
            }
            set { ho_cross = value; }
        }
        #endregion

        #region  投影到直线的点
        /// <summary>
        /// 投影到直线的点
        /// </summary>
        public RectLibrary.IRectShuJuPianYi IrectShuJuPianYiTwo
        {
            get { return _irectShuJuPianYiTwo; }
            set { _irectShuJuPianYiTwo = value; }
        }
        #endregion

        #region 投影线的第一个点
        /// <summary>
        ///   投影线的第一个点
        /// </summary>
        public RectLibrary.IRectShuJuPianYi IrectShuJuPianYiOne
        {
            get { return _irectShuJuPianYiOne; }
            set { _irectShuJuPianYiOne = value; }
        }
        #endregion

        #region 直线的距离
        /// <summary>
        /// 点到直线的距离
        /// </summary>
        public HTuple Distance
        {
            get { return _distance; }
            set { _distance = value; }
        }
        #endregion

        #region   直线的地址
        /// <summary>
        /// 直线的地址
        /// </summary>
        public string PathLine
        {
            get { return _pathLine; }
            set { _pathLine = value; }
        }
        #endregion

        #region 点的地址
        /// <summary>
        /// 点的地址
        /// </summary>
        public string PathPoint
        {
            get { return _pathPoint; }
            set { _pathPoint = value; }
        }
        #endregion

        #region  直线
        /// <summary>
        /// 直线
        /// </summary>
        public ILineStruct ILine
        {
            get { return _iLine; }
            set { _iLine = value; }
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
            _result = new DistancePointToLine_Result();
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

        #region   处理函数
        /// <summary>
        /// 处理函数
        /// </summary>
        /// <param name="ho_Image"></param>
        /// <param name="hwin"></param>
        /// <param name="Key"></param>
        /// <param name="_dictionary_resulte"></param>
        /// <returns></returns>
        public override bool analyze_show( HWindow hwin, string Key, ref Dictionary<string, object> _dictionary_resulte)
        {
            bool ok = false;
            if ((IrectShuJuPianYi != null) && (ILine.IrectShuJuPianYiOne != null) && (ILine.IrectShuJuPianYiTwo != null))
            {
                if ((IrectShuJuPianYi.Row != null) && (ILine.IrectShuJuPianYiOne.Row != null) && (ILine.IrectShuJuPianYiTwo.Row != null))
                {
                    HOperatorSet.DistancePl(this.IrectShuJuPianYi.Row, this.IrectShuJuPianYi.Column, this.ILine.IrectShuJuPianYiOne.Row, this.ILine.IrectShuJuPianYiOne.Column, this.ILine.IrectShuJuPianYiTwo.Row, this.ILine.IrectShuJuPianYiTwo.Column, out this._distance);

                    HTuple row1_ = new HTuple(), col1_ = new HTuple();
                    HOperatorSet.ProjectionPl(this.IrectShuJuPianYi.Row, this.IrectShuJuPianYi.Column, this.ILine.IrectShuJuPianYiOne.Row, this.ILine.IrectShuJuPianYiOne.Column, this.ILine.IrectShuJuPianYiTwo.Row, this.ILine.IrectShuJuPianYiTwo.Column, out row1_, out col1_);

                    this._irectShuJuPianYiTwo.Column = col1_;
                    this._irectShuJuPianYiTwo.Row = row1_;

                    HTuple row_ = new HTuple(), col_ = new HTuple();
                    row_[0] = this.IrectShuJuPianYi.Row;
                    row_[1] = this._irectShuJuPianYiTwo.Row;

                    col_[0] = this.IrectShuJuPianYi.Column;
                    col_[1] = this._irectShuJuPianYiTwo.Column;

                    row_[2] = (row_[0] + row_[1]) / 2;
                    col_[2] = (col_[0] + col_[1]) / 2;

                    this.Ho_cross.Dispose();
                    HOperatorSet.GenContourPolygonXld(out this.ho_cross, row_, col_);
                    HOperatorSet.LineOrientation(this.IrectShuJuPianYi.Row, this.IrectShuJuPianYi.Column, this._irectShuJuPianYiTwo.Row, this._irectShuJuPianYiTwo.Column, out this.angle);
                    HOperatorSet.GenCrossContourXld(out _zhiXianDeDuanDianGenZhongDian, row_, col_, 6, 0.78);

                    this.row = (row_[0] + row_[1]) / 2;
                    this.column = (col_[0] + col_[1]) / 2;

                    /********数据分析**************/
                    Key = "DistancePointToLine_" + Key;
                    _result._tolatName = Key;
                    _result._tolatResult = true;
                    _result._angle = this.Angle;
                    _result._col = this.Column;
                    _result._row = this.Row;
                    _result._distance = this.Distance;

                    if (this._ICalibration != null)
                    {
                        HTuple diYiGeDianRow_ = this.IrectShuJuPianYiOne.Row;
                        HTuple diYiGeDianCol_ = this.IrectShuJuPianYiOne.Column;
                        HTuple diErGeDianRow_ = this.IrectShuJuPianYiTwo.Row;
                        HTuple deErGeDianCol_ = this.IrectShuJuPianYiTwo.Column;
                        this.Cal(this._ICalibration.HomMat2D, ref diYiGeDianRow_, ref diYiGeDianCol_);
                        this.Cal(this._ICalibration.HomMat2D, ref diErGeDianRow_, ref deErGeDianCol_);
                        HOperatorSet.DistancePp(diYiGeDianRow_, diYiGeDianCol_, diErGeDianRow_, deErGeDianCol_, out  _result._distance);
                        this.Cal(this._ICalibration.HomMat2D, ref _result._row, ref _result._col);
                    }
                    _dictionary_resulte.Add(Key, this._result);

                    if (_result._tolatResult)
                    {
                        ok = true;
                    }
                    show(hwin);
                }
            }
            return ok;
        }
        #endregion

        #region  显示函数
        /// <summary>
        /// 显示函数
        /// </summary>
        /// <param name="data"></param>
        /// <param name="hwin"></param>
        /// <returns></returns>
        public override bool show(HWindow hwin)
        {
            bool ok = false;
            if (_result._tolatResult)
            {
                if (Ho_cross.IsInitialized() && _zhiXianDeDuanDianGenZhongDian.IsInitialized())
                {
                    hwin.DispObj(this.ho_cross);
                    hwin.DispObj(this._zhiXianDeDuanDianGenZhongDian);
                    ok = true;
                }
            }
            return ok;
        }
        #endregion

        #region   显示结果
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

    #region  点到线的距离数据接口
    /// <summary>
    /// 点到线的距离数据接口
    /// </summary>
    public interface IDistancePointToLineShuJu : MultTree.IToolDateFather, ILineStruct
    {
        #region  属性

        #region  点到直线的投影线
        /// <summary>
        /// 点到直线的投影线
        /// </summary>
        HObject Ho_cross
        {
            get;
            set;
        }
        #endregion

        //#region  投影到直线的点
        ///// <summary>
        ///// 投影到直线的点
        ///// </summary>
        //RectLibrary.RectShuJuPianYi IrectShuJuPianYiTwo
        //{
        //    get;
        //    set;
        //}
        //#endregion

        #region 直线的距离
        /// <summary>
        /// 点到直线的距离
        /// </summary>
        HTuple Distance
        {
            get;
            set;
        }
        #endregion

        #region  直线
        /// <summary>
        /// 直线
        /// </summary>
        ILineStruct ILine
        {
            get;
            set;
        }
        #endregion

        #region   直线的地址
        /// <summary>
        /// 直线的地址
        /// </summary>
        string PathLine
        {
            get;
            set;
        }
        #endregion

        #region 点的地址
        /// <summary>
        /// 点的地址
        /// </summary>
        string PathPoint
        {
            get;
            set;
        }
        #endregion

        #endregion
    }
    #endregion

    #region  设置数据
    /// <summary>
    /// 设置数据
    /// </summary>
    public class Set_DistancePointToLine:MultTree.SetFather
    {
        #region  确定第一条直线
        /// <summary>
        /// 确定一条直线
        /// </summary>
        /// <param name="IDis_"></param>
        /// <param name="ob_"></param>
        /// <returns></returns>
        public bool Set_QueDingDiYiTiaoZhiXian(IDistancePointToLineShuJu IDis_, Object ob_)
        {
            bool ok = false;
            ILineStruct il_ = ob_ as ILineStruct;
            if (il_ != null)
            {
                IDis_.ILine = il_;
                ok = true;
            }
            else
            {
                MessageBox.Show("没有直线");
            }
            return ok;
        }
        #endregion

        #region   确定点
        /// <summary>
        /// 确定点
        /// </summary>
        /// <param name="IDis_"></param>
        /// <param name="iRect_"></param>
        /// <returns></returns>
        public bool Set_QueDingDian(IDistancePointToLineShuJu IDis_, Object iRect_)
        {
            bool ok = false;
            var ir_ = iRect_ as IRectShuJuPianYi;
            if (ir_ != null)
            {
                IDis_.IrectShuJuPianYi = ir_;
                IDis_.IrectShuJuPianYiOne = ir_;
                ok = true;
            }
            return ok;
        }
        #endregion

        #region  显示数据
        /// <summary>
        /// 显示数据
        /// </summary>
        public void Set_showParamter(IDistancePointToLineShuJu IDis_,ListBox list_One,ListBox list_Two)
        {
            #region  确定路径是否存在
            IDis_.PathLine = this.panDuanToolShiFouCunZai(IDis_.PathLine);

            if (IDis_.PathLine == "")
            {
                IDis_.ILine = null;
            }
            else
            {
                list_One.Items.Add(IDis_.PathLine);
            }

            IDis_.PathPoint = this.panDuanToolShiFouCunZai(IDis_.PathPoint);

            if (IDis_.PathPoint == "")
            {
                IDis_.IrectShuJuPianYi = null;
                IDis_.IrectShuJuPianYiOne = null;
            }
            else
            {
                list_Two.Items.Add(IDis_.PathPoint);
            }            
            #endregion
        }
        #endregion

        #region  无用代码
        /// <summary>
        /// 显示参数
        /// </summary>
        /// <returns></returns>
        //public bool show_Paramters(IDistancePointToLineShuJu iDistancePoint_, ListBox linePath_, ListBox pointPath_)
        //{
        //    bool ok = false;
        //    this.panDuanToolShiFouCunZai(iDistancePoint_.PathLine);
        //    this.panDuanToolShiFouCunZai(iDistancePoint_.PathPoint);

        //    if (iDistancePoint_.PathLine != "")
        //    {
        //        linePath_.Items.Add(iDistancePoint_.PathLine);
        //    }

        //    if (iDistancePoint_.PathPoint != "")
        //    {
        //        pointPath_.Items.Add(iDistancePoint_.PathPoint);
        //    }
            
        //    ok = true;
        //    return ok;
        //}

        #endregion

    }
    #endregion

    #region 数据结果
    /// <summary>
    ///数据结果 
    /// </summary>
    public class DistancePointToLine_Result : MultTree.ClassResultFather
    {
        /// <summary>
        /// 
        /// </summary>
        public HTuple _row=0;
        /// <summary>
        /// 
        /// </summary>
        public HTuple _col=0;
        /// <summary>
        /// 
        /// </summary>
        public HTuple _angle=0;

        /// <summary>
        /// 
        /// </summary>
        public HTuple _distance=0;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="str_array"></param>
        /// <returns></returns>
        public override bool showResult(out string[] str_array)
        {
            bool ok = false;

            str_array = new string[6];

            str_array[0] = this._tolatName;

            str_array[1] = this._tolatResult.ToString();

            str_array[2] = _row.D.ToString();

            str_array[3] = _col.D.ToString();

            str_array[4] = _angle.D.ToString();

            str_array[5] = _distance.D.ToString();

            ok = true;
            return ok;
        }

    }
    #endregion
}