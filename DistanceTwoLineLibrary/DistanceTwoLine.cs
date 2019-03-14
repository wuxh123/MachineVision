using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HalconDotNet;
using MultTree;
using RectLibrary;
using CalibrationLibrary;
using System.Windows.Forms;


namespace DistanceTwoLineLibrary
{
    #region  两条直线的交点数据
    /// <summary>
    /// 两条直线的交点数据
    /// </summary>
    [Serializable]
    public class DistanceTwoLineShuJu : MultTree.ToolDateFather, IDistanceTwoLineShuJu
    {
        #region    全局变量

        #region  第一条直线的路径
        /// <summary>
        /// 第一条直线的路径
        /// </summary>
        string _diYiTiaoZhiXianLuJing = "";
        #endregion

        #region   第二条直线的路径
        /// <summary>
        /// 第二条直线的路径
        /// </summary>
        string _diErTiaoZhiXianLuJing = "";
        #endregion

        #region   第一条直线
        /// <summary>
        /// 第一条直线
        /// </summary>
        ILineStruct _diYiTiaoZhiXian = new LineStruct();

        #endregion

        #region   第二条直线
        /// <summary>
        /// 第二条直线
        /// </summary>
        ILineStruct _diErTiaoZhiXian = new LineStruct();
        #endregion

        #region 交点region
        /// <summary>
        /// 交点region
        /// </summary>
        HObject _jiaoDianXLD = null;
        #endregion

        #region   结果
        /// <summary>
        /// 结果
        /// </summary>
        [NonSerialized]
        DistanceTwoLine_Result _result = new DistanceTwoLine_Result();
        #endregion

        #endregion

        #region  属性

        #region  第一条直线
        /// <summary>
        /// 第一条直线
        /// </summary>
        public ILineStruct DiYiTiaoZhiXian
        {
            get { return _diYiTiaoZhiXian; }
            set { _diYiTiaoZhiXian = value; }
        }
        #endregion

        #region  第二条直线
        /// <summary>
        /// 第二条直线
        /// </summary>
        public ILineStruct DiErTiaoZhiXian
        {
            get { return _diErTiaoZhiXian; }
            set { _diErTiaoZhiXian = value; }
        }


        #endregion

        #region  交点region
        /// <summary>
        /// 交点region
        /// </summary>
        public HObject JiaoDianXLD
        {
            get
            {
                if (_jiaoDianXLD == null)
                {
                    HOperatorSet.GenEmptyObj(out _jiaoDianXLD);
                    _jiaoDianXLD.Dispose();
                }
                return _jiaoDianXLD;
            }
            set { _jiaoDianXLD = value; }
        }
        #endregion

        #region   第一条值线的路径
        /// <summary>
        /// 第一条直线的路径
        /// </summary>
        public string DiYiTiaoZhiXianLuJing
        {
            get { return _diYiTiaoZhiXianLuJing; }
            set { _diYiTiaoZhiXianLuJing = value; }
        }
        #endregion

        #region  第二条直线的路径
        /// <summary>
        /// 第二条直线的路径
        /// </summary>
        public string DiErTiaoZhiXianLuJing
        {
            get { return _diErTiaoZhiXianLuJing; }
            set { _diErTiaoZhiXianLuJing = value; }
        }
        #endregion

        #endregion

        #region  序列化

        #endregion

        #region  保存
        /// <summary>
        /// 保存
        /// </summary>
        public override void save()
        {
            base.save();
        }
        #endregion

        #region  初始化
        /// <summary>
        /// 初始化
        /// </summary>
        public override void init()
        {
            base.init();
            _result = new DistanceTwoLine_Result();
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

            if ((this._diErTiaoZhiXian != null) && (this._diYiTiaoZhiXian != null))
            {
                if ((this._diErTiaoZhiXian.IrectShuJuPianYiOne != null) && (this._diYiTiaoZhiXian.IrectShuJuPianYiTwo != null) && (this._diErTiaoZhiXian.IrectShuJuPianYiOne.Column != null) && (this._diYiTiaoZhiXian.IrectShuJuPianYiTwo.Column != null))
                {
                    HTuple IsOverlapping;
                    HOperatorSet.IntersectionLines(this._diYiTiaoZhiXian.IrectShuJuPianYiOne.Row, this._diYiTiaoZhiXian.IrectShuJuPianYiOne.Column, this._diYiTiaoZhiXian.IrectShuJuPianYiTwo.Row, this._diYiTiaoZhiXian.IrectShuJuPianYiTwo.Column, this._diErTiaoZhiXian.IrectShuJuPianYiOne.Row, this._diErTiaoZhiXian.IrectShuJuPianYiOne.Column, this._diErTiaoZhiXian.IrectShuJuPianYiTwo.Row, this._diErTiaoZhiXian.IrectShuJuPianYiTwo.Column, out this.row, out this.column, out IsOverlapping);
                    HOperatorSet.AngleLl(this._diYiTiaoZhiXian.IrectShuJuPianYiOne.Row, this._diYiTiaoZhiXian.IrectShuJuPianYiOne.Column, this._diYiTiaoZhiXian.IrectShuJuPianYiTwo.Row, this._diYiTiaoZhiXian.IrectShuJuPianYiTwo.Column, this._diErTiaoZhiXian.IrectShuJuPianYiOne.Row, this._diErTiaoZhiXian.IrectShuJuPianYiOne.Column, this._diErTiaoZhiXian.IrectShuJuPianYiTwo.Row, this._diErTiaoZhiXian.IrectShuJuPianYiTwo.Column, out angle);

                    this.JiaoDianXLD.Dispose();
                    HOperatorSet.GenCrossContourXld(out this._jiaoDianXLD, this.Row, this.Column, 6, this.Angle);

                    /*************数据分析********************/
                    Key = "DistanceTwoLine_" + Key;
                    _result._tolatName = Key;
                    _result._tolatResult = true;
                    _result.Angle = this.Angle;
                    _result.Column = this.Column;
                    _result.Row = this.Row;

                    if (this._ICalibration != null)
                    {
                        this.Cal(this._ICalibration.HomMat2D, ref _result.Row, ref _result.Column);
                    }
                    _dictionary_resulte.Add(Key, this._result);

                    show(hwin);
                    ok = true;
                }
            }
            return ok;
        }
        #endregion

        #region   显示
        /// <summary>
        /// 显示
        /// </summary>
        /// <param name="hwin"></param>
        /// <returns></returns>
        public override bool show(HWindow hwin)
        {
            bool ok = false;
            if (this.JiaoDianXLD.IsInitialized())
            {
                hwin.DispObj(this.JiaoDianXLD);
            }
            return ok;
        }

        #endregion

        #region  显示结果
        /// <summary>
        /// 输出结果
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

    #region   接口数据
    /// <summary>
    /// 接口数据
    /// </summary>
    public interface IDistanceTwoLineShuJu : MultTree.IToolDateFather
    {
        #region  属性

        #region  第一条直线
        /// <summary>
        /// 第一条直线
        /// </summary>
        ILineStruct DiYiTiaoZhiXian { get; set; }
        #endregion

        #region  第二条直线
        /// <summary>
        /// 第二条直线
        /// </summary>
        ILineStruct DiErTiaoZhiXian { get; set; }
        #endregion

        #region  交点region
        /// <summary>
        /// 交点region
        /// </summary>
        HObject JiaoDianXLD
        {
            get;
            set;
        }
        #endregion

        #region   第一条值线的路径
        /// <summary>
        /// 第一条直线的路径
        /// </summary>
        string DiYiTiaoZhiXianLuJing
        {
            get;
            set;
        }
        #endregion

        #region  第二条直线的路径
        /// <summary>
        /// 第二条直线的路径
        /// </summary>
        string DiErTiaoZhiXianLuJing
        {
            get;
            set;
        }
        #endregion

        #endregion
    }
    #endregion

    #region   数据设置器
    /// <summary>
    /// 数据设置器
    /// </summary>
    public class Set_DistanceTwoLine:MultTree.SetFather
    {

        #region 确定第一条线
        /// <summary>
        /// 确定第一条线
        /// </summary>
        /// <param name="id_"></param>
        /// <returns></returns>
        public bool Set_QueDingDiYiTiaoZhiXian(IDistanceTwoLineShuJu id_, Object obj_)
        {
            bool ok = false;
            var il_ = obj_ as ILineStruct;
            if (il_ is ILineStruct)
            {
                id_.DiYiTiaoZhiXian = il_;
                ok = true;
            }
            return ok;
        }
        #endregion

        #region   确定第二条直线
        /// <summary>
        /// 确定第二条直线
        /// </summary>
        /// <param name="id_"></param>
        /// <param name="obj_"></param>
        /// <returns></returns>
        public bool Set_QueDingDiErTiaoZhiXian(IDistanceTwoLineShuJu id_, Object obj_)
        {
            bool ok = false;
            var il_ = obj_ as ILineStruct;
            if (il_ is ILineStruct)
            {
                id_.DiErTiaoZhiXian = il_;
                ok = true;
            }
            return ok;
        }
        #endregion

        #region   显示数据
        /// <summary>
        /// 显示数据
        /// </summary>
        /// <param name="id_"></param>
        public void Set_showParameter(IDistanceTwoLineShuJu id_,ListBox list_One,ListBox list_Two)
        {
            id_.DiYiTiaoZhiXianLuJing = this.panDuanToolShiFouCunZai(id_.DiYiTiaoZhiXianLuJing);
            
            if (id_.DiYiTiaoZhiXianLuJing == "")
            {
                id_.DiYiTiaoZhiXian = null;
            }
            else
            {
                list_One.Items.Add(id_.DiYiTiaoZhiXianLuJing);
            }

            id_.DiErTiaoZhiXianLuJing = this.panDuanToolShiFouCunZai(id_.DiErTiaoZhiXianLuJing);
            if (id_.DiErTiaoZhiXianLuJing == "")
            {
                id_.DiYiTiaoZhiXian = null;
            }
            else
            {
                list_Two.Items.Add(id_.DiErTiaoZhiXianLuJing);
            }
        }
        #endregion

    }
    #endregion

    #region  结果数据
    /// <summary>
    /// 结果数据
    /// </summary>
    public class DistanceTwoLine_Result : MultTree.ClassResultFather
    {

        /// <summary>
        /// 
        /// </summary>
        public HTuple Row = 0;
        /// <summary>
        /// 
        /// </summary>
        public HTuple Column = 0;
        /// <summary>
        /// 
        /// </summary>
        public HTuple Angle = 0;

        /// <summary>
        /// 
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
                str_array[2] = "x坐标:" + this.Column.D.ToString();
                str_array[3] = "y坐标:" + this.Row.D.ToString();
                str_array[4] = "a角度:" + this.Angle.D.ToString();
            }
            else
            {
                str_array[0] = this._tolatName;
                str_array[1] = this._tolatResult.ToString();
                str_array[2] = "x坐标:0";
                str_array[3] = "y坐标:0";
                str_array[4] = "a角度:0";
            }
            return ok;
        }

    }
    #endregion
}
