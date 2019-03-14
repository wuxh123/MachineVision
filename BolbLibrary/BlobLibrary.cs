using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using HalconDotNet;

using MultTree;


namespace BlobLibrary
{
    #region  blob数据
    /// <summary>
    /// blob数据
    /// </summary>
    [Serializable]
    public class BlobShuJu : MultTree.ToolDateFather, IBlobShuJu
    {
        #region  全局变量

        #region   检测的region
        /// <summary>
        /// 外部接口
        /// </summary>
        [NonSerialized]
        HalControl.ROI.Rectangle2.IOutsideRectangle2ROI _iOutSide = null;
        #endregion

        #region   分割的区域范围
        /// <summary>
        /// 最小灰度值
        /// </summary>
        [NonSerialized]
        HTuple _minGray = 120;

        /// <summary>
        /// 最大灰度值
        /// </summary>
        [NonSerialized]
        HTuple _maxGray = 255;
        #endregion

        #region   筛选的特征
        /// <summary>
        /// 筛选的特征
        /// </summary>
        [NonSerialized]
        HTuple _features = "area";

        /// <summary>
        /// 筛选特征的大小
        /// </summary>
        [NonSerialized]
        HTuple _operation = "and";

        /// <summary>
        /// 特征最小值
        /// </summary>
        [NonSerialized]
        HTuple _min = 150;

        /// <summary>
        /// 特征最大值
        /// </summary>
        [NonSerialized]
        HTuple _max = 99999;

        /// <summary>
        /// 选择得到的区域
        /// </summary>
        [NonSerialized]
        HObject _selectRegion = null;
        #endregion

        #region   结果
        /// <summary>
        /// 结果类
        /// </summary>
        [NonSerialized]
        Blob_Result _result = new Blob_Result();
        #endregion
        #endregion

        #region  序列化

        #region  提取ocv检测的region 点位
        /// </summary>
        Object mid_row_y_1;
        /// <summary>
        /// 
        /// </summary>
        Object mid_col_x_1;
        /// <summary>
        /// 
        /// </summary>
        Object len1_1;
        /// <summary>
        /// 
        /// </summary>
        Object len2_1;
        /// <summary>
        /// 
        /// </summary>
        Object angle_1;
        #endregion

        #region   分割的区域范围
        /// <summary>
        /// 最小灰度值
        /// </summary>
        Object _minGray_1;

        /// <summary>
        /// 最大灰度值
        /// </summary>
        Object _maxGray_1;
        #endregion

        #region   筛选的特征
        /// <summary>
        /// 筛选的特征
        /// </summary>
        Object _features_1;

        /// <summary>
        /// 筛选特征的大小
        /// </summary>
        Object _operation_1;

        /// <summary>
        /// 特征最小值
        /// </summary>
        Object _min_1;

        /// <summary>
        /// 特征最大值
        /// </summary>
        Object _max_1;
        #endregion

        #endregion

        #region   属性

        #region  外部接口
        /// <summary>
        /// 外部接口
        /// </summary>
        public HalControl.ROI.Rectangle2.IOutsideRectangle2ROI IOutSide
        {
            get
            {
                if (_iOutSide == null)
                {
                    this._iOutSide = new HalControl.ROI.Rectangle2.OutsideRectangle2ROI();
                    this._iOutSide.Len1 = 100;
                    this._iOutSide.Len2 = 100;
                    this._iOutSide.Phi = 0;
                    this._iOutSide.Mid_col_x = 100;
                    this._iOutSide.Mid_row_y = 100;
                }
                return _iOutSide;
            }
            set
            {
                if (_iOutSide == null)
                {
                    this._iOutSide = new HalControl.ROI.Rectangle2.OutsideRectangle2ROI();
                }

                _iOutSide = value;
            }
        }
        #endregion

        #region   分割的区域范围
        /// <summary>
        /// 最小灰度值
        /// </summary>
        public HTuple MinGray
        {
            get { return _minGray; }
            set { _minGray = value; }
        }

        /// <summary>
        /// 最大灰度值
        /// </summary>
        public HTuple MaxGray
        {
            get { return _maxGray; }
            set { _maxGray = value; }
        }

        #endregion

        #region  筛选的特征
        /// <summary>
        /// 筛选的特征
        /// </summary>
        public HTuple Features
        {
            get { return _features; }
            set { _features = value; }
        }

        /// <summary>
        /// 筛选特征的大小
        /// </summary>
        public HTuple Operation
        {
            get { return _operation; }
            set { _operation = value; }
        }

        /// <summary>
        /// 特征最小值
        /// </summary>
        public HTuple Min
        {
            get { return _min; }
            set { _min = value; }
        }

        /// <summary>
        /// 特征最大值
        /// </summary>
        public HTuple Max
        {
            get { return _max; }
            set { _max = value; }
        }

        /// <summary>
        /// 选择得到的区域
        /// </summary>
        public HObject SelectRegion
        {
            get
            {
                if (_selectRegion == null)
                {
                    HOperatorSet.GenEmptyObj(out _selectRegion);
                    _selectRegion.Dispose();
                }
                return _selectRegion;
            }
            set { _selectRegion = value; }
        }
        #endregion

        #endregion

        #region  检测
        public override bool analyze_show(HWindow hwin, string Key, ref Dictionary<string, object> _dictionary_resulte)
        {
            bool ok = false;

            /***********************处理***************************************/
            HObject ho_ImageReduced_;
            HOperatorSet.GenEmptyObj(out ho_ImageReduced_);

            HTuple hv_ModMat2D_;

            HObject ho_Rectangle_;
            HOperatorSet.GenEmptyObj(out ho_Rectangle_);
            ho_Rectangle_.Dispose();

            HOperatorSet.GenRectangle2(out ho_Rectangle_, IOutSide.Mid_row_y, IOutSide.Mid_col_x, -IOutSide.Phi, IOutSide.Len1, IOutSide.Len2);
            if (IrectShuJuPianYi != null)//判断有无定位
            {
                HOperatorSet.VectorAngleToRigid(GenSuiDian_Y_Row, GeuSuiDian_X_Col, GenSuiDian_A, IrectShuJuPianYi.Row, IrectShuJuPianYi.Column, IrectShuJuPianYi.Angle, out hv_ModMat2D_);
                HOperatorSet.AffineTransRegion(ho_Rectangle_, out ho_Rectangle_, hv_ModMat2D_, "nearest_neighbor");
            }
            HOperatorSet.ReduceDomain(this.ImageFather.Ho_image, ho_Rectangle_, out ho_ImageReduced_);

            this.GenSuiDianYuDingWeiDianDeBianHuanRegion.Dispose();
            this.GenSuiDianYuDingWeiDianDeBianHuanRegion = ho_Rectangle_;

            HOperatorSet.Threshold(ho_ImageReduced_, out ho_ImageReduced_, this.MinGray, this.MaxGray);
            HOperatorSet.Connection(ho_ImageReduced_, out ho_ImageReduced_);
            HOperatorSet.SelectShape(ho_ImageReduced_, out ho_ImageReduced_, this.Features, this.Operation, this.Min, this.Max);

            this.SelectRegion.Dispose();
            this.SelectRegion = ho_ImageReduced_;

            HOperatorSet.AreaCenter(ho_ImageReduced_, out this._result._area, out this._result._row_y, out this._result._col_x);

            /**********************************数据分析***************************/
            Key = "blob_" + Key;
            this._result._tolatName = Key;

            if (this._result._area.Length > 0)
            {
                this._result._tolatResult = true;
            }
            else
            {
                this._result._tolatResult = false;
            }
            _dictionary_resulte.Add(Key, this._result);

            /**********显示******************/
            this.show(hwin);

            ok = this._result._tolatResult;

            return ok;
        }
        #endregion

        #region   显示
        public override bool show(HWindow hwin)
        {
            bool ok = false;

            if (this._result._tolatResult)
            {
                hwin.DispObj(this.SelectRegion);
            }
            else
            {
                hwin.SetColor("red");
                hwin.DispObj(this.GenSuiDianYuDingWeiDianDeBianHuanRegion);
                hwin.SetColor("green");
            }
            return ok;
        }
        #endregion

        #region   初始化
        public override void init()
        {
            base.init();

            this._result = new Blob_Result();

            #region  提取ocv检测的region 点位
            //this.IOutSide.Row_y1 = (HTuple)hv_Row1_1;
            //this.IOutSide.Col_x1 = (HTuple)hv_Column1_1;
            //this.IOutSide.Row_y2 = (HTuple)hv_Row2_1;
            //this.IOutSide.Col_x2 = (HTuple)hv_Column2_1;

            this.IOutSide.Mid_col_x = (HTuple)this.mid_col_x_1;
            this.IOutSide.Mid_row_y = (HTuple)this.mid_row_y_1;
            this.IOutSide.Len1 = (HTuple)this.len1_1;
            this.IOutSide.Len2 = (HTuple)this.len2_1;
            this.IOutSide.Phi = (HTuple)this.angle_1;
            #endregion

            #region   分割的区域范围
            this._minGray = (HTuple)_minGray_1;

            this._maxGray = (HTuple)_maxGray_1;
            #endregion

            #region   筛选的特征
            this.Features = (HTuple)_features_1;

            this._operation = (HTuple)_operation_1;

            this.Min = (HTuple)_min_1;

            this.Max = (HTuple)_max_1;
            #endregion

        }
        #endregion

        #region   保存
        public override void save()
        {
            base.save();

            #region  提取ocv检测的region 点位
            this.mid_col_x_1 = this.IOutSide.Mid_col_x;
            this.mid_row_y_1 = this.IOutSide.Mid_row_y;
            this.len1_1 = this.IOutSide.Len1;
            this.len2_1 = this.IOutSide.Len2;
            this.angle_1 = this.IOutSide.Phi;
            #endregion

            #region   分割的区域范围
            _minGray_1 = this._minGray;

            _maxGray_1 = this._maxGray;
            #endregion

            #region   筛选的特征
            _features_1 = this.Features;

            _operation_1 = this._operation;

            _min_1 = this.Min;

            _max_1 = this.Max;
            #endregion

        }
        #endregion

        #region 显示结果
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
    public interface IBlobShuJu : MultTree.IToolDateFather, HalControl.ROI.Rectangle2.IOutsideRectangle2
    {
        #region   属性

        #region  外部接口
        /// <summary>
        /// 外部接口
        /// </summary>
        HalControl.ROI.Rectangle2.IOutsideRectangle2ROI IOutSide
        {
            get
         ;
            set
           ;
        }
        #endregion

        #region   分割的区域范围
        /// <summary>
        /// 最小灰度值
        /// </summary>
        HTuple MinGray
        {
            get;
            set;
        }

        /// <summary>
        /// 最大灰度值
        /// </summary>
        HTuple MaxGray
        {
            get;
            set;
        }

        #endregion

        #region  筛选的特征
        /// <summary>
        /// 筛选的特征
        /// </summary>
        HTuple Features
        {
            get;
            set;
        }

        /// <summary>
        /// 筛选特征的大小
        /// </summary>
        HTuple Operation
        {
            get;
            set;
        }

        /// <summary>
        /// 特征最小值
        /// </summary>
        HTuple Min
        {
            get;
            set;
        }

        /// <summary>
        /// 特征最大值
        /// </summary>
        HTuple Max
        {
            get;
            set;
        }

        /// <summary>
        /// 选择得到的区域
        /// </summary>
        HObject SelectRegion
        {
            get;
            set;
        }
        #endregion

        #endregion
    }
    #endregion

    #region   设置器
    /// <summary>
    /// 设置器
    /// </summary>
    public class Set_BlobShuJu:MultTree.SetFather
    {
        #region  刷新定位点
        /// <summary>
        /// 刷新定位点
        /// </summary>
        /// <param name="IBolb_"></param>
        /// <returns></returns>
        public bool Set_ShuaXinDingWeiDian(IBlobShuJu IBolb_)
        {
            bool ok = false;
            if (IBolb_.IrectShuJuPianYi != null)
            {
                IBolb_.GenSuiDian_A = IBolb_.IrectShuJuPianYi.Angle;
                IBolb_.GenSuiDian_Y_Row = IBolb_.IrectShuJuPianYi.Row;
                IBolb_.GeuSuiDian_X_Col = IBolb_.IrectShuJuPianYi.Column;
                ok = true;
            }
            return ok;
        }
        #endregion

        #region   设置参数
        /// <summary>
        /// 设置参数
        /// </summary>
        /// <param name="IBolb_"></param>
        /// <param name="MinGray_"></param>
        /// <param name="MaxGray_"></param>
        /// <param name="features"></param>
        /// <param name="Min"></param>
        /// <param name="Max"></param>
        /// <returns></returns>
        public bool Set_SheZhiCanShu(IBlobShuJu IBolb_, string MinGray_, string MaxGray_, string features_, string Min, string Max)
        {
            bool ok = false;
            if (MinGray_ != null)
            {
                double num = double.Parse(MinGray_);
                IBolb_.MinGray = num;

            }

            if (MaxGray_ != null)
            {
                double num = double.Parse(MaxGray_);
                IBolb_.MaxGray = num;
            }

            if (features_ != null)
            {
                IBolb_.Features = features_;
            }

            if (Min != null)
            {
                double num = double.Parse(Min);
                IBolb_.Min = num;
            }

            if (Max != null)
            {
                double num = double.Parse(Max);
                IBolb_.Max = num;
            }
            ok = true;
            return ok;
        }

        #endregion

        #region  显示参数
        /// <summary>
        /// 显示参数
        /// </summary>
        /// <param name="IBlob_"></param>
        /// <param name="control_"></param>
        /// <param name="halconWinControl_"></param>
        /// <returns></returns>
        public bool Set_ShowParameterHalconWinControl(IBlobShuJu IBlob_, Control.ControlCollection control_, HalControl.HalconWinControl_ROI halconWinControl_)
        {
            bool ok = false;

            this.ShuaXinDingWeiDian((IToolDateFather)IBlob_, IBlob_.IOutSide);

            if (halconWinControl_ != null)
            {
                halconWinControl_.DrawRectangle2(IBlob_.IOutSide.Mid_col_x, IBlob_.IOutSide.Mid_row_y, IBlob_.IOutSide.Phi, IBlob_.IOutSide.Len1, IBlob_.IOutSide.Len2, IBlob_.IOutSide);
            }

            Set_ShowParameter(IBlob_, control_);

            return ok;
        }

        /// <summary>
        /// 显示
        /// </summary>
        /// <param name="IBlob_"></param>
        /// <param name="control"></param>
        bool Set_ShowParameter(IBlobShuJu IBlob_, Control.ControlCollection control)
        {
            bool ok = false;
            foreach (Control con in control)
            {
                string name = con.Name;
                if ((con is ComboBox) || (con is TextBox) || (con is RichTextBox) || (con is Label) || (con is NumericUpDown))
                {
                    switch (name)
                    {
                        #region    分割的区域范围
                        case "numericUpDown_MinGray":
                            con.Text = IBlob_.MinGray.D.ToString().Replace("\"", "");
                            break;

                        case "numericUpDown_MaxGray":
                            con.Text = IBlob_.MaxGray.D.ToString().Replace("\"", "");
                            break;

                        #endregion

                        #region  筛选的特征
                        case "comboBox_Features":
                            con.Text = IBlob_.Features.ToString().Replace("\"", "");
                            break;

                        case "numericUpDown_Min":
                            con.Text = IBlob_.Min.D.ToString().Replace("\"", "");
                            break;

                        case "numericUpDown_Max":
                            con.Text = IBlob_.Max.D.ToString().Replace("\"", "");
                            break;
                        #endregion

                        #region 默认处理
                        default:

                            break;
                        #endregion
                    }
                }
                if (con.Controls.Count > 0)
                {
                    Set_ShowParameter(IBlob_, con.Controls);
                }
            }

            ok = true;
            return ok;


        }
        #endregion
    }
    #endregion

    #region   blob结果类
    /// <summary>
    /// blob结果类
    /// </summary>
    public class Blob_Result : MultTree.ClassResultFather
    {
        /// <summary>
        /// blob的面积
        /// </summary>
        public HTuple _area = null;

        /// <summary>
        /// blob的y
        /// </summary>
        public HTuple _row_y = null;

        /// <summary>
        /// blob的x
        /// </summary>
        public HTuple _col_x = null;

        /// <summary>
        /// 输出数据
        /// </summary>
        /// <param name="str_array"></param>
        /// <returns></returns>
        public override bool showResult(out string[] str_array)
        {
            bool ok = false;

            List<string> li = new List<string>();
            li.Add(this._tolatName);
            li.Add(this._tolatResult.ToString());
            if (this._tolatResult)
            {
                int al = _area.Length;
                for (int i = 0; i < al; i++)
                {
                    string s="面积" + i.ToString() + ":" + _area[i].D.ToString();
                    li.Add(s);
                    string n = "x:" + this._col_x[i].D.ToString();
                    li.Add(n);
                    string m = "y:" + this._row_y[i].D.ToString();
                    li.Add(m);
                }
            }

            int num = li.Count;
            str_array = new string[num];
            for (int i = 0; i < num; i++)
            {
                str_array[i] = li[i];
            }
            return ok;
        }

    }
    #endregion
}
