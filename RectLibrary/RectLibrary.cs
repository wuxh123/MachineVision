using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using HalconDotNet;





namespace RectLibrary
{
    #region 仿射变换
    /// <summary>
    /// 放射变换
    /// </summary>
    [Serializable]
    public class RectShuJu : MultTree.ToolDateFather, IRectShuJu/*, IRectShuJuHv_HomMat2D*/
    {

        #region   原点
        /// <summary>
        /// 原点x
        /// </summary>
        [NonSerialized]
        public HTuple yuan_dian_col_x;

        /// <summary>
        ///原点y 
        /// </summary>
        [NonSerialized]
        public HTuple yuan_dian_row_y;

        /// <summary>
        /// 原点角度
        /// </summary>
        [NonSerialized]
        public HTuple yuan_dian_angle_a;

        #endregion

        #region  防射变换偏移的数据接口
        /// <summary>
        /// 防射变换偏移的数据接口
        /// </summary>
        IRectShuJuPianYi _iRect_shuju_pianyi;
        #endregion
            
        #region  对接跟随定位工具的点的接口
        /// <summary>
        /// 对接跟随定位工具的点的接口
        /// </summary>
        IRectShuJuPianYi _iDuiJieGenSuiDingWeiGongJu;
      
        #endregion

        #region  工具的路径
        /// <summary>
        /// 工具的路径
        /// </summary>
        List<string> _tool_Path = null;
        #endregion

        #region  被跟随的定位工具
        /// <summary>
        /// 被跟随的定位工具
        /// </summary>
        string _beiGenSuiDingWeiGongJu = null;
        #endregion

        #region  无用代码
        //#region  偏移点
        ///// <summary>
        ///// 偏移后的x
        ///// </summary>
        //[NonSerialized]
        //public HTuple col_x;

        ///// <summary>
        /////偏移后的y 
        ///// </summary>
        //[NonSerialized]
        //public HTuple row_y;

        ///// <summary>
        ///// 偏移后角度
        ///// </summary>
        //[NonSerialized]
        //public HTuple angle_a;
        //#endregion
        #endregion

        #region  放射变换的矩阵
        /// <summary>
        /// 放射变换的矩阵
        /// </summary>
        [NonSerialized]
        HTuple hv_HomMat2D;
        #endregion

        #region   属性

        #region   原点
        /// <summary>
        /// 原点x
        /// </summary>
        public HTuple Yuan_dian_col_x
        {
            get { return yuan_dian_col_x; }
            set { yuan_dian_col_x = value; }
        }
        /// <summary>
        ///原点y 
        /// </summary>
        public HTuple Yuan_dian_row_y
        {
            get { return yuan_dian_row_y; }
            set { yuan_dian_row_y = value; }
        }
        /// <summary>
        /// 原点角度
        /// </summary>
        public HTuple Yuan_dian_angle_a
        {
            get { return yuan_dian_angle_a; }
            set { yuan_dian_angle_a = value; }
        }

        #endregion

        #region 无用代码
        //#region  偏移点
        ///// <summary>
        ///// 偏移后的x
        ///// </summary>
        //public HTuple Col_x
        //{
        //    get { return col_x; }
        //    set { col_x = value; }
        //}

        ///// <summary>
        /////偏移后的y 
        ///// </summary>
        //public HTuple Row_y
        //{
        //    get { return row_y; }
        //    set { row_y = value; }
        //}

        ///// <summary>
        ///// 偏移后角度
        ///// </summary>
        //public HTuple Angle_a
        //{
        //    get { return angle_a; }
        //    set { angle_a = value; }
        //}
        //#endregion
        #endregion

        #region  防射变换偏移的数据接口
        /// <summary>
        /// 防射变换偏移的数据接口
        /// </summary>
        public IRectShuJuPianYi IRect_shuju_pianyi
        {
            get { return _iRect_shuju_pianyi; }
            set { _iRect_shuju_pianyi = value; }
        }
        #endregion

        #region  放射变换的矩阵
        /// <summary>
        /// 放射变换的矩阵
        /// </summary>
        public HTuple Hv_HomMat2D
        {
            get { return hv_HomMat2D; }
            set { hv_HomMat2D = value; }
        }
        #endregion

        #region   工具的路径
        /// <summary>
        /// 工具的路径
        /// </summary>
        public List<string> Tool_Path
        {
            get
            {
                if (_tool_Path == null)
                {
                    _tool_Path = new List<string>();
                }
                return _tool_Path;
            }
            set { _tool_Path = value; }
        }
        #endregion

        #region   被跟随的定位工具
        /// <summary>
        /// 被跟随的定位工具
        /// </summary>
        public string BeiGenSuiDingWeiGongJu
        {
            get
            {
                if (_beiGenSuiDingWeiGongJu == null)
                {
                    _beiGenSuiDingWeiGongJu = "";
                }
                return _beiGenSuiDingWeiGongJu;
            }
            set { _beiGenSuiDingWeiGongJu = value; }
        }
        #endregion

        //#region   对接跟随定位工具的点
        ///// <summary>
        ///// 对接跟随定位工具的点
        ///// </summary>
        //public RectShuJuPianYi DuiJieGenSuiDingWeiGongJu
        //{
        //    get { return _duiJieGenSuiDingWeiGongJu; }
        //    set { _duiJieGenSuiDingWeiGongJu = value; }
        //}
        //#endregion

        #region  对接跟随定位工具的点的接口
        /// <summary>
        /// 对接跟随定位工具的点的接口
        /// </summary>
        public IRectShuJuPianYi IDuiJieGenSuiDingWeiGongJu
        {
            get { return _iDuiJieGenSuiDingWeiGongJu; }
            set { _iDuiJieGenSuiDingWeiGongJu = value; }
        }
        #endregion

        #endregion

        #region     构造函数
        /// <summary>
        /// 构造函数
        /// </summary>
        public RectShuJu()
        {
            //this._duiJieGenSuiDingWeiGongJu=new RectShuJuPianYi();
            this.IDuiJieGenSuiDingWeiGongJu = new RectShuJuPianYi();
            _tool_Path = new List<string>();
        }
        #endregion

        #region   序列化保存的数据
        #region 图片
        /// <summary>
        /// 图片
        /// </summary>
        //   Object ho_image_;
        #endregion

        #region   原点
        /// <summary>
        /// 原点x
        /// </summary>
        Object yuan_dian_col_x_;

        /// <summary>
        ///原点y 
        /// </summary>
        Object yuan_dian_row_y_;

        /// <summary>
        /// 原点角度
        /// </summary>
        Object yuan_dian_angle_a_;

        #endregion

        #region  偏移点
        /// <summary>
        /// 偏移后的x
        /// </summary>
        //  Object col_x_;

        /// <summary>
        ///偏移后的y 
        /// </summary>
        //  Object row_y_;

        /// <summary>
        /// 偏移后角度
        /// </summary>
        //  Object angle_a_;
        #endregion

        #region  放射变换的矩阵
        /// <summary>
        /// 放射变换的矩阵
        /// </summary>
        // Object hv_HomMat2D_;
        #endregion
        #endregion

        #region  保存数据
        /// <summary>
        /// 保存数据
        /// </summary>
        public override void save()
        {
            #region 图片

            //   ho_image_=ho_image;
            #endregion

            #region   原点
            yuan_dian_col_x_ = yuan_dian_col_x;

            yuan_dian_row_y_ = yuan_dian_row_y;

            yuan_dian_angle_a_ = yuan_dian_angle_a;

            #endregion

            #region  偏移点
            //col_x_=col_x;

            //row_y_=row_y;

            // angle_a_=angle_a;
            #endregion

            #region  放射变换的矩阵
            //      hv_HomMat2D_=hv_HomMat2D;
            #endregion
        }
        #endregion

        #region   初始化数据
        /// <summary>
        /// 初始化数据
        /// </summary>
        public override void init()
        {
            #region 图片

            //   ho_image=(HObject)ho_image_;
            #endregion

            #region   原点

            yuan_dian_col_x = (HTuple)yuan_dian_col_x_;

            yuan_dian_row_y = (HTuple)yuan_dian_row_y_;

            yuan_dian_angle_a = (HTuple)yuan_dian_angle_a_;

            #endregion

            #region  偏移点
            //col_x=(HTuple)col_x_;

            // row_y=(HTuple)row_y_;

            // angle_a=(HTuple)angle_a_;
            #endregion

            #region  放射变换的矩阵
            // hv_HomMat2D=(HTuple)hv_HomMat2D_;
            #endregion

            #region   对接定位工具的点
            //this._duiJieGenSuiDingWeiGongJu = new RectShuJuPianYi();
            //this._duiJieGenSuiDingWeiGongJu.Angle = yuan_dian_angle_a;
            //this._duiJieGenSuiDingWeiGongJu.Column = yuan_dian_col_x;
            //this._duiJieGenSuiDingWeiGongJu.Row = yuan_dian_row_y;
            //this.IDuiJieGenSuiDingWeiGongJu = this._duiJieGenSuiDingWeiGongJu;

            this.IDuiJieGenSuiDingWeiGongJu.Angle = Yuan_dian_angle_a;
            this.IDuiJieGenSuiDingWeiGongJu.Row = Yuan_dian_row_y;
            this.IDuiJieGenSuiDingWeiGongJu.Column = Yuan_dian_col_x;
            #endregion
        
        }
        #endregion

        #region   检测
        public override bool analyze_show(HWindow hwin, string Key, ref Dictionary<string, object> _dictionary_resulte)
        {
            bool ok = false;

            Key = "Rect_" + Key;
            RectShuJu_Result _result = new RectShuJu_Result();

            if(this.IRect_shuju_pianyi!=null)
            {
                //this.DuiJieGenSuiDingWeiGongJu.Angle = this.IRect_shuju_pianyi.Angle;
                //this.DuiJieGenSuiDingWeiGongJu.Column = this.IRect_shuju_pianyi.Column;
                //this.DuiJieGenSuiDingWeiGongJu.Row = this.IRect_shuju_pianyi.Row;         
                this.IDuiJieGenSuiDingWeiGongJu.Angle = this.IRect_shuju_pianyi.Angle;
                this.IDuiJieGenSuiDingWeiGongJu.Column = this.IRect_shuju_pianyi.Column;
                this.IDuiJieGenSuiDingWeiGongJu.Row = this.IRect_shuju_pianyi.Row;     
            }
               
            _result._tolatResult = true;
            _result._tolatName = Key;
            _dictionary_resulte.Add(Key, _result);
            ok = true;

            return ok;
        }
        #endregion

        #region   释放资源
        /// <summary>
        /// 释放资源
        /// </summary>
        public override void Dispose()
        {
            base.Dispose();
            this.IDuiJieGenSuiDingWeiGongJu = null;
        }
        #endregion

    }
    #endregion

    #region   放射变化的数据接口
    /// <summary>
    /// 放射变化的数据接口
    /// </summary>
    public interface IRectShuJu : IRectShuJuHv_HomMat2D, MultTree.IToolDateFather
    {
        #region   无用代码
        #region 图片
        /// <summary>
        /// 图片
        /// </summary>
        //HObject Ho_image
        //{
        //    get;
        //    set;
        //}
        #endregion
        #endregion

        #region   原点
        /// <summary>
        /// 原点x
        /// </summary>
        HTuple Yuan_dian_col_x
        {
            get;
            set;
        }
        /// <summary>
        ///原点y 
        /// </summary>
        HTuple Yuan_dian_row_y
        {
            get;
            set;
        }
        /// <summary>
        /// 原点角度
        /// </summary>
        HTuple Yuan_dian_angle_a
        {
            get;
            set;
        }

        #endregion

        #region  防射变换偏移的数据接口
        /// <summary>
        /// 防射变换偏移的数据接口
        /// </summary>
        IRectShuJuPianYi IRect_shuju_pianyi
        {
            get;
            set;
        }
        #endregion

        #region  无用代码
        //#region  偏移点
        ///// <summary>
        ///// 偏移后的x
        ///// </summary>
        //HTuple Col_x
        //{
        //    get;
        //    set;
        //}

        ///// <summary>
        /////偏移后的y 
        ///// </summary>
        //HTuple Row_y
        //{
        //    get;
        //    set;
        //}

        ///// <summary>
        ///// 偏移后角度
        ///// </summary>
        //HTuple Angle_a
        //{
        //    get;
        //    set;
        //}
        //#endregion
        #endregion

        #region  放射变换的矩阵   后续这个可以删除
        /// <summary>
        /// 放射变换的矩阵
        /// </summary>
        HTuple Hv_HomMat2D
        {
            get;
            set;
        }
        #endregion

        #region   工具的路径
        /// <summary>
        /// 工具的路径
        /// </summary>
        List<string> Tool_Path
        {
            get;
            set;
        }
        #endregion

        #region   被跟随的定位工具
        /// <summary>
        /// 被跟随的定位工具
        /// </summary>
        string BeiGenSuiDingWeiGongJu
        {
            get;
            set;
        }
        #endregion

        #region   保存数据
        /// <summary>
        /// 保存数据
        /// </summary>
        void save();
        #endregion

        #region   初始化数据
        /// <summary>
        /// 初始化数据
        /// </summary>
        void init();
        #endregion

        //#region  对接跟随定位工具的点
        ///// <summary>
        ///// 对接跟随定位工具的点
        ///// </summary>
        //RectShuJuPianYi DuiJieGenSuiDingWeiGongJu
        //{
        //    get;
        //    set;
        //}
        //#endregion

        #region  对接跟随定位工具的点的接口
        /// <summary>
        /// 对接跟随定位工具的点的接口
        /// </summary>
        IRectShuJuPianYi IDuiJieGenSuiDingWeiGongJu
        {
            get;
            set;
        }
        #endregion
    }
    #endregion

    #region   放射变化的数据设置器
    /// <summary>
    /// 放射变化的数据设置器
    /// </summary>
    public class SetRectShuJu:MultTree.SetFather
    {
        #region  设置原点
        #region   无用代码
        ///// <summary>
        ///// 设置原点
        ///// </summary>
        ///// <param name="IRect"></param>
        ///// <param name="Yuan_dian_col_x"></param>
        ///// <param name="Yuan_dian_row_y"></param>
        ///// <param name="Yuan_dian_angle_a"></param>
        ///// <returns></returns>
        //public bool Set_Orgin(IRectShuJu IRect, double Yuan_dian_col_x, double Yuan_dian_row_y, double Yuan_dian_angle_a)
        //{
        //    bool ok = false;
        //    IRect.Yuan_dian_col_x = Yuan_dian_col_x;
        //    IRect.Yuan_dian_row_y = Yuan_dian_row_y;
        //    IRect.Yuan_dian_angle_a = Yuan_dian_angle_a;
        //    ok = true;
        //    return ok;
        //}
        #endregion

        /// <summary>
        /// 设置原点
        /// </summary>
        /// <param name="IRect_"></param>
        /// <param name="IRectShuJuPianYi_"></param>
        /// <returns></returns>
        public bool Set_Orgin(IRectShuJu IRect_, IRectShuJuPianYi IRectShuJuPianYi_)
        {
            bool ok = false;

            IRect_.Yuan_dian_col_x = IRectShuJuPianYi_.Column;
            IRect_.Yuan_dian_row_y = IRectShuJuPianYi_.Row;
            IRect_.Yuan_dian_angle_a = IRectShuJuPianYi_.Angle;
            IRect_.IRect_shuju_pianyi = IRectShuJuPianYi_;

            ok = true;
            return ok;

        }
        #endregion

        #region  设置偏移点
        /// <summary>
        /// 设置偏移点
        /// </summary>
        /// <param name="IRect"></param>
        /// <param name="Col_x"></param>
        /// <param name="Row_y"></param>
        /// <param name="Angle_a"></param>
        /// <returns></returns>
        public bool Set_PianYiDian(IRectShuJu IRect, double Col_x, double Row_y, double Angle_a)
        {
            bool ok = false;

            //IRect.Col_x = Col_x;
            //IRect.Row_y = Row_y;
            //IRect.Angle_a = Angle_a;

            ok = true;
            return ok;
        }
        #endregion

        //#region   显示参数
        ///// <summary>
        ///// 显示参数
        ///// </summary>
        ///// <param name="IRect"></param>
        ///// <param name="control"></param>
        //public bool Set_ShowParamter(IRectShuJu IRect, Control.ControlCollection control)
        //{
        //    bool ok = false;
        //    foreach (Control con in control)
        //    {
        //        string name = con.Name;
        //        if ((con is ComboBox) || (con is TextBox) || (con is RichTextBox) || (con is Label))
        //        {
        //            switch (name)
        //            {
        //                #region   
        //                #endregion
        //            }
        //        }

        //        if (con.Controls.Count > 0)
        //        {
        //            Set_ShowParamter(IRect, con.Controls);
        //        }
        //    }
        //    ok = true;
        //    return ok;
        //}
        //#endregion
    }
    #endregion

    //#region   防射变化数据分析器
    ///// <summary>
    ///// 防射变化数据分析器
    ///// </summary>
    //public class Rect_FangSheBianHuan
    //{
    //    #region   无用代码
    //    ///// <summary>
    //    ///// 输入防射变化矩阵
    //    ///// </summary>
    //    ///// <param name="IRect"></param>
    //    //public void fang_bian_huan_ju_zhen(IRectShuJu IRect)
    //    //{
    //    //    HTuple hv_HomMat2D = null;

    //    //    HOperatorSet.VectorAngleToRigid(IRect.Yuan_dian_row_y, IRect.Yuan_dian_col_x, IRect.Yuan_dian_angle_a, IRect.IRect_shuju_pianyi.Row, IRect.IRect_shuju_pianyi.Column, IRect.IRect_shuju_pianyi.Angle, out hv_HomMat2D);

    //    //    IRect.Hv_HomMat2D = hv_HomMat2D;
    //    //}
    //    #endregion

    //    #region  放射变换
    //    /// <summary>
    //    /// 放射变换
    //    /// </summary>
    //    /// <param name="IRect"></param>
    //    /// <param name="Key"></param>
    //    /// <param name="_dictionary_resulte"></param>
    //    public bool fang_bian_huan_ju_zhen(IRectShuJu IRect, string Key, ref Dictionary<string, Object> _dictionary_resulte)
    //    {
    //        bool ok = false;

    //        Key = "Rect_" + Key;
    //        RectShuJu_Result _result = new RectShuJu_Result();
    //        _result._tolatResult = true;
    //        _result._tolatName = Key;
    //        _dictionary_resulte.Add(Key, _result);

    //        ok = true;
    //        return ok;
    //    }
    //    #endregion

    //    #region  无用代码
    //    #region 防射变换XLD
    //    /// <summary>
    //    /// 防射变换XLD
    //    /// </summary>
    //    /// <param name="hv_HomMat2D">防射变换矩阵</param>
    //    /// <param name="coutour">要变换的xld轮廓</param>
    //    /// <param name="coutouraffinetrans">变换后的轮廓</param>
    //    /// <param name="Row"></param>
    //    ///<param name="Col">变换后的轮廓</param>
    //    //public void AffineTransContourXld(HTuple hv_HomMat2D, HObject coutour,out HObject coutouraffinetrans
    //    //    ,out HTuple Row,out HTuple Col)
    //    //{
    //    //    HOperatorSet.AffineTransContourXld(coutour, out coutouraffinetrans, hv_HomMat2D);
    //    //    HOperatorSet.GetContourXld(coutouraffinetrans, out Row, out Col);
    //    //}
    //    #endregion

    //    #region   防射变化region
    //    /// <summary>
    //    /// 防射变化region
    //    /// </summary>
    //    /// <param name="hv_HomMat2D">防射变换矩阵</param>
    //    /// <param name="region">要变化的region</param>
    //    /// <param name="regionaffinetrans">输出的region</param>
    //    //public void AffineTransContourRegion(HTuple hv_HomMat2D, HObject region, out HObject regionaffinetrans)
    //    //{

    //    //    HOperatorSet.AffineTransRegion(region, out regionaffinetrans, hv_HomMat2D, "nearest_neighbor");

    //    //}
    //    #endregion
    //    #endregion
    //}
    //#endregion

    #region 防射变换偏移的数据接口
    /// <summary>
    /// 防射变换偏移的数据
    /// </summary>
    public interface IRectShuJuPianYi
    {
        #region 定位工具的输出偏移点
        /// <summary>
        /// 定位工具的输出偏移点,y
        /// </summary>
        HTuple Row
        {
            get;
            set;
        }

        /// <summary>
        /// 定位工具的输出偏移点,x
        /// </summary>
        HTuple Column
        {
            get;
            set;
        }

        /// <summary>
        /// 定位工具的输出偏移点，angle
        /// </summary>
        HTuple Angle
        {
            get;
            set;
        }
        #endregion
    }
    #endregion

    #region  点
    /// <summary>
    /// 点
    /// </summary>
    [Serializable]
    public class RectShuJuPianYi : IRectShuJuPianYi
    {
        #region  全局
        /// <summary>
        /// 角度
        /// </summary>
        [NonSerialized]
        public HTuple angle = 0;
        /// <summary>
        /// x
        /// </summary>
        [NonSerialized]
        public HTuple column = 0;
        /// <summary>
        /// y
        /// </summary>
        [NonSerialized]
        public HTuple row = 0;
        #endregion

        #region  属性
        /// <summary>
        /// a
        /// </summary>
        public HTuple Angle
        {
            get { return angle; }
            set { angle = value; }
        }

        /// <summary>
        /// x
        /// </summary>
        public HTuple Column
        {
            get { return column; }
            set { column = value; }
        }

        /// <summary>
        /// y
        /// </summary>
        public HTuple Row
        {
            get { return row; }
            set { row = value; }
        }
        #endregion
    }

    #endregion

    #region  直线
    /// <summary>
    /// 直线接口
    /// </summary>
    public interface ILineStruct
    {
        #region 直线的第一个点
        /// <summary>
        /// 直线的第一个点
        /// </summary>
        IRectShuJuPianYi IrectShuJuPianYiOne { get; set; }
        #endregion

        #region  直线的第二个点
        /// <summary>
        /// 直线的第二个点
        /// </summary>
        IRectShuJuPianYi IrectShuJuPianYiTwo { get; set; }
        #endregion
    }

    /// <summary>
    /// 直线
    /// </summary>
    [Serializable]
    public class LineStruct : ILineStruct
    {
        #region 直线的第一个点
        /// <summary>
        /// 直线的第一个点
        /// </summary>
        IRectShuJuPianYi _irectShuJuPianYiOne = null;
        /// <summary>
        /// 直线的第一个点
        /// </summary>
        public IRectShuJuPianYi IrectShuJuPianYiOne
        {
            get { return _irectShuJuPianYiOne; }
            set { _irectShuJuPianYiOne = value; }
        }
        #endregion

        #region  直线的第二个点
        /// <summary>
        /// 直线的第二个点
        /// </summary>
        IRectShuJuPianYi _irectShuJuPianYiTwo = null;
        /// <summary>
        /// 直线的第二个点
        /// </summary>
        public IRectShuJuPianYi IrectShuJuPianYiTwo
        {
            get { return _irectShuJuPianYiTwo; }
            set { _irectShuJuPianYiTwo = value; }
        }
        #endregion
    }

    #endregion

    #region   防射变换矩阵接口
    /// <summary>
    /// 防射变换矩阵接口
    /// </summary>
    public interface IRectShuJuHv_HomMat2D
    {
        #region  放射变换的矩阵
        /// <summary>
        /// 放射变换的矩阵
        /// </summary>
        HTuple Hv_HomMat2D
        {
            get;
            set;
        }
        #endregion
    }

    /// <summary>
    /// 防射变换矩阵接口
    /// </summary>
    public interface IHv_HomMat2D
    {
        /// <summary>
        /// 需要防射变化
        /// </summary>
        IRectShuJuHv_HomMat2D Ihv_HomMat2D
        {
            get;
            set;
        }
    }
    #endregion

    #region  跟随定位的接口模块
    /// <summary>
    /// 跟随定位的接口模块
    /// </summary>
    public interface IGenSuiDianWeiDeJieKouMuKuai
    {
        #region   跟随点
        /// <summary>
        /// 跟随点x
        /// </summary>
        HTuple GeuSuiDian_X_Col { get; set; }

        /// <summary>
        /// 跟随点y
        /// </summary>
        HTuple GenSuiDian_Y_Row { get; set; }

        /// <summary>
        /// 跟随点角度a
        /// </summary>
        HTuple GenSuiDian_A { get; set; }
        #endregion

        #region   放射变换矩阵
        /// <summary>
        /// 跟随点的放射变换矩阵
        /// </summary>
        HTuple GenSuiDianWei_Hv_HomMat2D { get; set; }
        #endregion

        #region 防射变换偏移的数据接口
        /// <summary>
        /// 防射变换偏移的数据接口
        /// </summary>
        IRectShuJuPianYi IrectShuJuPianYi { get; set; }
        #endregion

        #region  跟随点与定位点的变换region
        /// <summary>
        /// 跟随点与定位点的变换region
        /// </summary>
        HObject GenSuiDianYuDingWeiDianDeBianHuanRegion { get; set; }
        #endregion
    }
    #endregion

    #region 放射变换的结果

    /// <summary>
    /// 放射变换的结果
    /// </summary>
    public class RectShuJu_Result : MultTree.ClassResultFather
    {
        /// <summary>
        /// 显示
        /// </summary>
        /// <param name="str_array"></param>
        /// <returns></returns>
        public override bool showResult(out string[] str_array)
        {
            bool ok = false;
            str_array = new string[2];
            str_array[0] = this._tolatName;
            str_array[1] = this._tolatResult.ToString();
            ok = true;
            return ok;
        }
    }
    #endregion

}
