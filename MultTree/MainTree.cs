using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using MultTree.MultTreeNodeStruct;
using RectLibrary;
using CalibrationLibrary;
using ReadImageHalconLibrary;
using HalControl.ROI.Line;
using HalControl.ROI.Cricle;
using HalControl.ROI.Rectangle1;
using HalControl.ROI.Rectangle2;
using HalControl;

using HalconDotNet;



namespace MultTree
{
    #region  静态树
    /// <summary>
    /// 静态的树，存贮工具对应的数据
    /// </summary>
    [Serializable]
    public static class TreeStatic
    {
        #region 第一个根节点：驱动
        /// <summary>
        /// 根节点
        /// </summary>
        private static IMultTreeNode _Root = null;
        #endregion

        #region  当前节点数据
        /// <summary>
        /// 当前工具节点
        /// </summary>
        public static IMultTreeNode Mult_Tree_Node;
        #endregion

        #region  图片的节点
        /// <summary>
        /// 图片的节点
        /// </summary>
        public static IMultTreeNode Mult_Tree_Node_Picture;
        #endregion

        #region  属性
        /// <summary>
        /// 根节点
        /// </summary>
        public static IMultTreeNode Root
        {
            get
            {
                if (_Root == null)
                {
                    _Root = new MultTreeNode();
                    //_Root.setSelfId("System_1");
                    //_Root.setNodeName("驱动1");
                    _Root.SelfId = "System_1";
                    _Root.NodeName = "驱动1";
                }
                return _Root;
            }
            set { _Root = value; }
        }
        #endregion

        #region   把所有节点添加到treeview节点
        /// <summary>
        /// 把MultTreeNode节点的子节点添加到treeview节点
        /// </summary>
        /// <param name="tr">传入</param>
        /// <param name="mtr">传入</param>
        /// <returns></returns>
        public static bool load_MultTreeNode_To_TreeNode(TreeNode tr, IMultTreeNode mtr)
        {
            bool ok = false;
            foreach (MultTreeNode mtr_ in mtr.getChildList())
            {
                TreeNode tr_1 = new TreeNode();

                #region  无用代码
                //tr_1.Text = mtr_.getNodeName();
                //tr_1.Name = mtr_.getSelfId();
                #endregion

                tr_1.Text = mtr_.NodeName;
                tr_1.Name = mtr_.SelfId;
                tr.Nodes.Add(tr_1);
                if (!mtr_.isLeaf())
                {
                    load_MultTreeNode_To_TreeNode(tr_1, mtr_);
                }
            }
            ok = true;
            return ok;
        }

        /// <summary>
        /// 把MultTreeNode节点添加到treeview节点，包含他自己，跟子节点
        /// </summary>
        /// <param name="tr"></param>
        /// <param name="mtr"></param>
        /// <returns></returns>
        public static bool load_MultTreeNode_To_TreeNode_ContainsSelf(TreeNode tr, IMultTreeNode mtr)
        {
            bool ok = false;

            TreeNode tr_1 = new TreeNode();
            //tr_1.Text = mtr.getNodeName();
            //tr_1.Name = mtr.getSelfId();
            tr_1.Text = mtr.NodeName;
            tr_1.Name = mtr.SelfId;
            tr.Nodes.Add(tr_1);

            if (!mtr.isLeaf())
            {
                load_MultTreeNode_To_TreeNode(tr_1, mtr);
            }

            ok = true;
            return ok;
        }
        
        #endregion

        #region 加载MultTreeNode
        /// <summary>
        /// 加载MultTreeNode
        /// </summary>
        public static bool load_MultTreeNode(string path)
        {
            bool ok = false;
            /*******建立一个序列化工具*****/
            MultTree.SerializeTree.TreeViewDataAccess tr = new SerializeTree.TreeViewDataAccess(_Root);
            tr.LoadTreeViewData(path);

            ok = true;
            return ok;
        }
        #endregion

        #region 保存MultTreeNode
        /// <summary>
        /// 保存MultTreeNode
        /// </summary>
        /// <param name="path"></param>
        public static void save_MultTreeNode(string path)
        {
            MultTree.SerializeTree.TreeViewDataAccess tr = new SerializeTree.TreeViewDataAccess(_Root);
            tr.SaveTreeViewData(path);
        }
        #endregion

        #region  获取当前根节点中的其中一个子节点
        /// <summary>
        ///  获取当前根节点中的其中一个子节点
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        public static MultTree.MultTreeNodeStruct.MultTreeNode get_root_childern(int index)
        {
            int num = _Root.ChildList.Count;

            if (index < 0 && index > num - 1)
            {
                return null;
            }
            return _Root.ChildList[index];
        }
        #endregion

        #region   清空根节点所有子节点
        /// <summary>
        /// 清空根节点所有子节点
        /// </summary>
        public static void clear_childern()
        {
            _Root.ChildList.Clear();
        }
        #endregion
    }
    #endregion

    #region  所有工具运行后结果的父类
    /// <summary>
    /// 所有工具运行后结果的父类 
    /// </summary>
    public class ClassResultFather : IClassResultFather
    {
        #region  全局变量
        /// <summary>
        /// 所有工具运行后结果的父类
        /// </summary>
        public bool _tolatResult = false;

        /// <summary>
        /// 当前工具的名称
        /// </summary>
        public string _tolatName = "";

        #region  无用代码
        ///// <summary>
        ///// 工具的路径
        ///// </summary>
        //public string _pathTool = "";
        #endregion
        #endregion

        #region  属性
        /// <summary>
        /// 所有工具运行后结果的父类
        /// </summary>
        public bool TolatResult
        {
            get { return _tolatResult; }
            set { _tolatResult = value; }
        }

        /// <summary>
        /// 当前工具的名称
        /// </summary>
        public string TolatName
        {
            get { return _tolatName; }
            set { _tolatName = value; }
        }

        #region  无用代码
        ///// <summary>
        ///// 工具的路径
        ///// </summary>
        //public string PathTool
        //{
        //    get { return _pathTool; }
        //    set { _pathTool = value; }
        //}
        #endregion

        #endregion

        #region  显示数据
        /// <summary>
        /// 显示结果
        /// </summary>
        /// <returns></returns>
        public virtual bool showResult(out string str)
        {
            bool ok = false;
            str = "显示失败";

            return ok;

        }

        /// <summary>
        /// 显示数据
        /// </summary>
        /// <param name="str_array"></param>
        /// <returns></returns>
        public virtual bool showResult(out string[] str_array)
        {
            bool ok = false;
            str_array = new string[2];
            str_array[0] = "没有名称";
            str_array[1] = "数据为空";
            ok = true;
            return ok;
        }
        #endregion
    }
    #endregion

    #region 所有工具运行后结果的父类 接口
    /// <summary>
    /// 所有工具运行后结果的父类 接口
    /// </summary>
    public interface IClassResultFather
    {
        #region  属性
        /// <summary>
        /// 所有工具运行后结果的父类
        /// </summary>
        bool TolatResult
        {
            get;
            set;
        }

        /// <summary>
        /// 当前工具的名称
        /// </summary>
        string TolatName
        {
            get;
            set;
        }
        #endregion

        #region   显示数据
        /// <summary>
        /// 显示数据
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        bool showResult(out string str);

        /// <summary>
        /// 显示数据
        /// </summary>
        /// <param name="str_array"></param>
        /// <returns></returns>
        bool showResult(out string[] str_array);
        #endregion
    }

    /// <summary>
    /// 所有工具运行后结果的父类 接口的接口
    /// </summary>
    public interface IResultFather
    {
        /// <summary>
        /// 所有工具运行后结果的父类 接口
        /// </summary>
        IClassResultFather _IClass { get; set; }
    }
    #endregion

    #region  工具数据的父类
    /// <summary>
    /// 工具的父类
    /// </summary>
    [Serializable]
    public class ToolDateFather : IToolDateFather,IDisposable
    {
        #region    全局变量

        #region  图片的接口
        /// <summary>
        /// 图片的接口
        /// </summary>
        ReadImageHalconLibrary.IImageFather imageFather = null;
        #endregion

        #region   跟随定位的数据

        #region   跟随点
        /// <summary>
        /// 跟随点x
        /// </summary>
        [NonSerialized]
        public HTuple geuSuiDian_X_Col = 0;

        /// <summary>
        /// 跟随点y
        /// </summary>
        [NonSerialized]
        public HTuple genSuiDian_Y_Row = 0;


        /// <summary>
        /// 跟随点角度a
        /// </summary>
        [NonSerialized]
        public HTuple genSuiDian_A = 0;
        #endregion

        #region   放射变换矩阵
        /// <summary>
        /// 跟随点的放射变换矩阵
        /// </summary>
        [NonSerialized]
        public HTuple genSuiDianWei_Hv_HomMat2D = 0;
        #endregion

        #region 防射变换偏移的数据接口
        /// <summary>
        /// 防射变换偏移的数据接口
        /// </summary>
        IRectShuJuPianYi irectShuJuPianYi = null;
        #endregion

        #region  跟随点与定位点的变换region
        /// <summary>
        /// 跟随点与定位点的变换region
        /// </summary>
        [NonSerialized]
        HObject genSuiDianYuDingWeiDianDeBianHuanRegion = null;
        #endregion

        #endregion

        #region   标定数据
        /// <summary>
        /// 标定数据
        /// </summary>    
        IHomMat2D _iCalibration = null;
        #endregion

        #region   跟随定位点
        /// <summary>
        /// 跟随定位点的中心点,y
        /// </summary>
        [NonSerialized]
        public HTuple row = null;

        /// <summary>
        /// 跟随定位点的中心点,x
        /// </summary>
        [NonSerialized]
        public HTuple column = null;

        /// <summary>
        /// 跟随定位点的角度
        /// </summary>
        [NonSerialized]
        public HTuple angle = null;
        #endregion

        #endregion

        #region   属性

        #region  图片的接口
        /// <summary>
        /// 图片的接口
        /// </summary>
        public ReadImageHalconLibrary.IImageFather ImageFather
        {
            get { return imageFather; }
            set { imageFather = value; }
        }
        #endregion

        #region   跟随定位的数据

        #region  跟随点
        /// <summary>
        /// 跟随点x
        /// </summary>
        public HTuple GeuSuiDian_X_Col
        {
            get { return geuSuiDian_X_Col; }
            set { geuSuiDian_X_Col = value; }
        }

        /// <summary>
        /// 跟随点y
        /// </summary>
        public HTuple GenSuiDian_Y_Row
        {
            get { return genSuiDian_Y_Row; }
            set { genSuiDian_Y_Row = value; }
        }

        /// <summary>
        /// 跟随点角度a
        /// </summary>
        public HTuple GenSuiDian_A
        {
            get { return genSuiDian_A; }
            set { genSuiDian_A = value; }
        }

        #endregion

        #region  跟随点的放射变换矩阵
        /// <summary>
        /// 跟随点的放射变换矩阵
        /// </summary>
        public HTuple GenSuiDianWei_Hv_HomMat2D
        {
            get { return genSuiDianWei_Hv_HomMat2D; }
            set
            {
                genSuiDianWei_Hv_HomMat2D = value;
            }
        }
        #endregion

        #region  防射变换偏移的数据接口
        /// <summary>
        /// 防射变换偏移的数据接口
        /// </summary>
        public IRectShuJuPianYi IrectShuJuPianYi
        {
            get { return irectShuJuPianYi; }
            set
            {
                irectShuJuPianYi = value;
                #region  无用代码
                //if (value != null)//判断是不是跟随定位
                //{
                //    //if (this.GenSuiDianYuDingWeiDianDeBianHuanRegion != null)
                //    //{
                //    HTuple y_row_, x_col_, area_, phi_, hv_homMat2D_;
                //    HObject hv_rengect_;
                //    HOperatorSet.GenEmptyObj(out hv_rengect_);
                //    hv_rengect_.Dispose();
                //    HOperatorSet.VectorAngleToRigid(this.GenSuiDian_Y_Row, this.GeuSuiDian_X_Col, this.GenSuiDian_A, this.IrectShuJuPianYi.Row, this.IrectShuJuPianYi.Column, this.IrectShuJuPianYi.Angle, out hv_homMat2D_);

                //    HOperatorSet.GenRectangle2(out hv_rengect_, this.IOutSide.Mid_row_y, this.IOutSide.Mid_col_x, this.IOutSide.Phi, this.IOutSide.Len1, this.IOutSide.Len2);
                //    HOperatorSet.AffineTransRegion(hv_rengect_, out hv_rengect_, hv_homMat2D_, "nearest_neighbor");

                //    HOperatorSet.AreaCenter(hv_rengect_, out area_, out y_row_, out x_col_);
                //    HOperatorSet.OrientationRegion(hv_rengect_, out phi_);
                //    this._iOutSide.Mid_col_x = x_col_;
                //    this._iOutSide.Mid_row_y = y_row_;
                //    this._iOutSide.Phi = phi_;

                //    hv_rengect_.Dispose();//清空局部创建的变量

                //    //if (this.GenSuiDianWei_Hv_HomMat2D != null)
                //    //{
                //    HObject modelImage_;
                //    HOperatorSet.GenEmptyObj(out modelImage_);
                //    modelImage_.Dispose();
                //    HOperatorSet.AffineTransImage(this.ModelImage, out modelImage_, hv_homMat2D_, "constant", "false");
                //    this.ModelImage.Dispose();
                //    this.ModelImage = modelImage_;
                //    HObject CoverUpRegin_;
                //    HOperatorSet.GenEmptyObj(out CoverUpRegin_);
                //    HOperatorSet.AffineTransRegion(this.CoverUpRegion, out CoverUpRegin_, hv_homMat2D_, "nearest_neighbor");
                //    this.CoverUpRegion.Dispose();
                //    this.CoverUpRegion = CoverUpRegin_;

                //    //}
                //    //}
                //}
                #endregion
            }
        }
        #endregion

        #region  跟随点与定位点的变换region
        /// <summary>
        /// 跟随点与定位点的变换region
        /// </summary>
        public HObject GenSuiDianYuDingWeiDianDeBianHuanRegion
        {
            get
            {
                if (genSuiDianYuDingWeiDianDeBianHuanRegion == null)
                {
                    HOperatorSet.GenEmptyObj(out genSuiDianYuDingWeiDianDeBianHuanRegion);
                    genSuiDianYuDingWeiDianDeBianHuanRegion.Dispose();
                }
                return genSuiDianYuDingWeiDianDeBianHuanRegion;
            }
            set
            {
                genSuiDianYuDingWeiDianDeBianHuanRegion = value;
            }
        }
        #endregion

        #endregion

        #region  标定数据
        /// <summary>
        /// 标定数据
        /// </summary>
        public IHomMat2D _ICalibration
        {
            get { return _iCalibration; }
            set { _iCalibration = value; }
        }
        #endregion

        #region   跟随定位点
        /// <summary>
        /// 跟随定位点的中心点,y
        /// </summary>
        public HTuple Row
        {
            get { return row; }
            set { row = value; }
        }

        /// <summary>
        /// 跟随定位点的中心点,x
        /// </summary>
        public HTuple Column
        {
            get { return column; }
            set { column = value; }
        }

        /// <summary>
        /// 跟随定位点的角度
        /// </summary>
        public HTuple Angle
        {
            get { return angle; }
            set { angle = value; }
        }

        #endregion

        #endregion

        #region   序列化数据

        #region   跟随定位的数据

        #region   跟随点
        /// <summary>
        /// 跟随点x
        /// </summary>
        Object geuSuiDian_X_Col_1;

        /// <summary>
        /// 跟随点y
        /// </summary>
        Object genSuiDian_Y_Row_1;


        /// <summary>
        /// 跟随点角度a
        /// </summary>
        Object genSuiDian_A_1;
        #endregion

        #region   放射变换矩阵
        /// <summary>
        /// 跟随点的放射变换矩阵
        /// </summary>
        Object genSuiDianWei_Hv_HomMat2D_1;
        #endregion

        #region  跟随点与定位点的变换region
        /// <summary>
        /// 跟随点与定位点的变换region
        /// </summary>
        Object genSuiDianYuDingWeiDianDeBianHuanRegion_1;
        #endregion

        #endregion

        #region   跟随定位点
        /// <summary>
        /// 跟随定位点的中心点,y
        /// </summary>
        Object row_1;

        /// <summary>
        /// 跟随定位点的中心点,x
        /// </summary>
        Object column_1;

        /// <summary>
        /// 跟随定位点的角度
        /// </summary>
        Object angle_1;
        #endregion

        #endregion

        #region  显示
        /// <summary>
        /// 显示
        /// </summary>
        /// <returns></returns>
        public virtual bool show(HWindow hwin)
        {
            bool ok = false;

            ok = true;
            return ok;
        }
        #endregion

        #region  显示 分析
        /// <summary>
        /// 显示  分析
        /// </summary>
        /// <param name="data"></param>
        /// <param name="ho_Image"></param>
        /// <param name="hwin"></param>
        /// <param name="Key"></param>
        /// <param name="_dictionary_resulte"></param>
        /// <returns></returns>
        public virtual bool analyze_show(HWindow hwin, string Key, ref Dictionary<string, Object> _dictionary_resulte)
        {
            bool ok = false;



            ok = true;
            return ok;
        }
        #endregion

        #region   输出工具的结果
        /// <summary>
        /// 输出工具的结果
        /// </summary>
        /// <returns></returns>
        public virtual bool outResult(out string[] toolResult_)
        {
            bool ok = false;
            toolResult_ = new string[2];
            toolResult_[0] = "没有名称";
            toolResult_[1] = "数据为空";
            ok = true;
            return ok;
        }

        #endregion

        #region   保存
        /// <summary>
        /// 保存
        /// </summary>
        public virtual void save()
        {
            #region   跟随定位的数据

            geuSuiDian_X_Col_1 = GeuSuiDian_X_Col;

            genSuiDian_Y_Row_1 = GenSuiDian_Y_Row;

            genSuiDian_A_1 = GenSuiDian_A;
            #endregion

            #region   放射变换矩阵
            genSuiDianWei_Hv_HomMat2D_1 = GenSuiDianWei_Hv_HomMat2D;
            #endregion

            #region  跟随点与定位点的变换region
            if (GenSuiDianYuDingWeiDianDeBianHuanRegion.IsInitialized())
            {
                genSuiDianYuDingWeiDianDeBianHuanRegion_1 = GenSuiDianYuDingWeiDianDeBianHuanRegion;
            }
            #endregion

            #region   跟随定位点
            row_1 = Row;

            column_1 = Column;

            angle_1 = Angle;
            #endregion
        }
        #endregion

        #region   初始化
        /// <summary>
        /// 初始化
        /// </summary>
        public virtual void init()
        {
            #region   跟随定位的数据

            GeuSuiDian_X_Col = (HTuple)geuSuiDian_X_Col_1;

            GenSuiDian_Y_Row = (HTuple)genSuiDian_Y_Row_1;

            GenSuiDian_A = (HTuple)genSuiDian_A_1;
            #endregion

            #region   放射变换矩阵
            GenSuiDianWei_Hv_HomMat2D = (HTuple)genSuiDianWei_Hv_HomMat2D_1;
            #endregion

            #region  跟随点与定位点的变换region
            GenSuiDianYuDingWeiDianDeBianHuanRegion = (HObject)genSuiDianYuDingWeiDianDeBianHuanRegion_1;
            #endregion

            #region   跟随定位点
            Row = (HTuple)row_1;

            Column = (HTuple)column_1;

            Angle = (HTuple)angle_1;
            #endregion
        }
        #endregion

        #region 算出标定数据
        /// <summary>
        /// 算出标定数据
        /// </summary>
        /// <param name="homMat2D"></param>
        /// <param name="pixel_row_y"></param>
        /// <param name="pixel_column_x"></param>
        /// <param name="world_row_y"></param>
        /// <param name="world_column_x"></param>
        /// <returns></returns>
        public bool Cal(HTuple homMat2D, ref HTuple pixel_row_y, ref HTuple pixel_column_x/*, out HTuple world_row_y, out HTuple world_column_x*/)
        {
            bool ok = false;
            HTuple world_row_y, world_column_x;
            HOperatorSet.AffineTransPoint2d(homMat2D, pixel_column_x, pixel_row_y, out world_column_x, out world_row_y);
            // HOperatorSet.AffineTransPixel(homMat2D, pixel_row_y, pixel_row_y, out world_row_y, out world_column_x);
            pixel_column_x = world_column_x;
            pixel_row_y = world_row_y;
            ok = true;
            return ok;
        }
        #endregion

        #region   释放资源
        /// <summary>
        /// 释放资源
        /// </summary>
        public virtual void Dispose()
        {
            this.ImageFather = null;
            irectShuJuPianYi = null;
            _iCalibration = null;
        }
        #endregion

    }

    #region   工具数据的父类  接口
    /// <summary>
    /// 工具数据的父类  接口
    /// </summary>
    public interface IToolDateFather : RectLibrary.IRectShuJuPianYi, RectLibrary.IGenSuiDianWeiDeJieKouMuKuai, ReadImageHalconLibrary.IImageFatherOutSide,IDisposable
    {
        #region   属性
        #region   跟随定位的数据

        #region  跟随点
        /// <summary>
        /// 跟随点x
        /// </summary>
        HTuple GeuSuiDian_X_Col
        {
            get;
            set;
        }

        /// <summary>
        /// 跟随点y
        /// </summary>
        HTuple GenSuiDian_Y_Row
        {
            get;
            set;
        }

        /// <summary>
        /// 跟随点角度a
        /// </summary>
        HTuple GenSuiDian_A
        {
            get;
            set;
        }

        #endregion

        #region  跟随点的放射变换矩阵
        /// <summary>
        /// 跟随点的放射变换矩阵
        /// </summary>
        HTuple GenSuiDianWei_Hv_HomMat2D
        {
            get;
            set;
        }
        #endregion

        #region  防射变换偏移的数据接口
        /// <summary>
        /// 防射变换偏移的数据接口
        /// </summary>
        IRectShuJuPianYi IrectShuJuPianYi
        {
            get;
            set;
        }
        #endregion

        #region  跟随点与定位点的变换region
        /// <summary>
        /// 跟随点与定位点的变换region
        /// </summary>
        HObject GenSuiDianYuDingWeiDianDeBianHuanRegion
        {
            get;
            set;
        }
        #endregion

        #endregion

        #region  标定数据
        /// <summary>
        /// 标定数据
        /// </summary>
        IHomMat2D _ICalibration
        {
            get;
            set;
        }
        #endregion

        //#region   跟随定位点
        ///// <summary>
        ///// 跟随定位点的中心点,y
        ///// </summary>
        //HTuple Row
        //{
        //    get;
        //    set;
        //}
        ///// <summary>
        ///// 跟随定位点的中心点,x
        ///// </summary>
        //HTuple Column
        //{
        //    get;
        //    set;
        //}
        ///// <summary>
        ///// 跟随定位点的角度
        ///// </summary>
        //HTuple Angle
        //{
        //    get;
        //    set;
        //}
        //#endregion
        #endregion
        
        #region  显示
        /// <summary>
        /// 显示
        /// </summary>
        /// <param name="data"></param>
        /// <param name="hwin"></param>
        /// <returns></returns>
        bool show(HWindow hwin);
        #endregion

        #region  显示 分析
        /// <summary>
        /// 显示  分析
        /// </summary>
        /// <param name="data"></param>
        /// <param name="ho_Image"></param>
        /// <param name="hwin"></param>
        /// <param name="Key"></param>
        /// <param name="_dictionary_resulte"></param>
        /// <returns></returns>
        bool analyze_show( HWindow hwin, string Key, ref Dictionary<string, Object> _dictionary_resulte);
        #endregion

        #region   保存
        /// <summary>
        /// 保存
        /// </summary>
        void save();
        #endregion

        #region   初始化
        /// <summary>
        /// 初始化
        /// </summary>
        void init();
        #endregion

        #region  显示结果
        /// <summary>
        /// 显示结果
        /// </summary>
        /// <param name="toolResult_"></param>
        /// <returns></returns>
        bool outResult(out string[] toolResult_);
        #endregion

    }
    #endregion

    #endregion

    #region   工具的父类
    /// <summary>
    /// 工具的父类
    /// </summary>
    public class ToolFather
    {
        #region 算出标定数据
        /// <summary>
        /// 算出标定数据
        /// </summary>
        /// <param name="homMat2D"></param>
        /// <param name="pixel_row_y"></param>
        /// <param name="pixel_column_x"></param>
        /// <param name="world_row_y"></param>
        /// <param name="world_column_x"></param>
        /// <returns></returns>
        public bool Cal(HTuple homMat2D, ref HTuple pixel_row_y, ref HTuple pixel_column_x/*, out HTuple world_row_y, out HTuple world_column_x*/)
        {
            bool ok = false;
            HTuple world_row_y, world_column_x;
            HOperatorSet.AffineTransPoint2d(homMat2D, pixel_column_x, pixel_row_y, out world_column_x, out world_row_y);
            // HOperatorSet.AffineTransPixel(homMat2D, pixel_row_y, pixel_row_y, out world_row_y, out world_column_x);
            pixel_column_x = world_column_x;
            pixel_row_y = world_row_y;
            ok = true;
            return ok;
        }
        #endregion

        #region  显示
        /// <summary>
        /// 显示
        /// </summary>
        /// <returns></returns>
        public virtual bool show(ref Object data, HWindow hwin)
        {
            bool ok = false;

            ok = true;
            return ok;
        }
        #endregion

        #region  显示 分析
        /// <summary>
        /// 显示  分析
        /// </summary>
        /// <param name="data"></param>
        /// <param name="ho_Image"></param>
        /// <param name="hwin"></param>
        /// <param name="Key"></param>
        /// <param name="_dictionary_resulte"></param>
        /// <returns></returns>
        public virtual bool analyze_show(ref Object data, HObject ho_Image, HWindow hwin, string Key, ref Dictionary<string, Object> _dictionary_resulte)
        {
            bool ok = false;

            ok = true;
            return ok;
        }

        #endregion
    }
    #endregion
    
    #region   设置器的父类
    /// <summary>
    /// 设置器的父类
    /// </summary>
    public class SetFather
    {
        #region  刷新工具集合
        /// <summary>
        /// 刷新工具集合
        /// </summary>
        public List<string> ShuaXinToolJiHe(List<string> toolPath_)
        {
            List<string> removeStr=new List<string>();
            
            foreach (string str in toolPath_)
            {
                if (!MultTree.CalculateMultTreeNodeName.CalculateMultTreeNodeName.PanDuanFuJieDianShiFoCunZai(str))
                {
                    removeStr.Add(str);
                }
            }

            foreach (string str in removeStr)
            {
                toolPath_.Remove(str);
            }
                
            return toolPath_;
        }

        /// <summary>
        /// 刷新工具集合
        /// </summary>
        /// <param name="toolPath_"></param>
        /// <param name="lis_"></param>
        public List<string> ShuaXinToolJiHe(List<string> toolPath_, ListBox lis_)
        {
            ShuaXinToolJiHe(toolPath_);
            foreach (string file_name in toolPath_)
            {
                lis_.Items.Add(file_name); //加载所有文件
            }
            return toolPath_;
        }
        
        #endregion

        #region  刷新定位点
        /// <summary>
        /// 涮新定位点
        /// </summary>
        /// <param name="itoolDateFather_"></param>
        public void ShuaXinDingWeiDian(IToolDateFather itoolDateFather_,Object ioutSide_)
        {
            if (itoolDateFather_.IrectShuJuPianYi != null)//更新定位点
            {
              
                #region  判断是不是直线
                if (ioutSide_ is IOutsideLineROI)//判断是不是直线
                {
                    IOutsideLineROI IOutSide_ = (IOutsideLineROI)ioutSide_;

                    HTuple oneRow_, oneCol_, twoRow_, twoCol_;
                  
                    HTuple hv_modMat2D, crossRow_ = new HTuple(), crossCol_ = new HTuple(), Nr, Nc, Dist;
                    HObject contour_;
                    HOperatorSet.VectorAngleToRigid(itoolDateFather_.GenSuiDian_Y_Row, itoolDateFather_.GeuSuiDian_X_Col, itoolDateFather_.GenSuiDian_A, itoolDateFather_.IrectShuJuPianYi.Row, itoolDateFather_.IrectShuJuPianYi.Column, itoolDateFather_.IrectShuJuPianYi.Angle, out hv_modMat2D);

                    crossRow_[0] = IOutSide_.Row1.D;
                    crossRow_[1] = IOutSide_.Row2.D;
                    crossCol_[0] = IOutSide_.Cols1.D;
                    crossCol_[1] = IOutSide_.Cols2.D;
                    HOperatorSet.GenContourPolygonXld(out contour_, crossRow_, crossCol_);

                    HOperatorSet.AffineTransContourXld(contour_, out contour_, hv_modMat2D);

                    HOperatorSet.FitLineContourXld(contour_, "tukey", -1, 0, 5, 2, out oneRow_, out oneCol_, out twoRow_, out twoCol_, out Nr, out Nc, out Dist);

                    IOutSide_.Row1 = oneRow_;
                    IOutSide_.Row2 = twoRow_;
                    IOutSide_.Cols1 = oneCol_;
                    IOutSide_.Cols2 = twoCol_;
                    contour_.Dispose();
                }
                #endregion

                #region  判断是不是矩形1
                if (ioutSide_ is IOutsideRectangle1ROI)//判断是不是矩形1
                {

                }
                #endregion

                #region  判断是不是圆
                if (ioutSide_ is IOutsideCricleROI)//判断是不是圆
                {
                    IOutsideCricleROI IOutSide_ = (IOutsideCricleROI)ioutSide_;
                    HTuple hv_modMat2D;
                    HObject hv_Cirle;
                    HTuple Area_, Column_, Row_;
                    
                    HOperatorSet.VectorAngleToRigid(itoolDateFather_.GenSuiDian_Y_Row, itoolDateFather_.GeuSuiDian_X_Col, itoolDateFather_.GenSuiDian_A, itoolDateFather_.IrectShuJuPianYi.Row, itoolDateFather_.IrectShuJuPianYi.Column, itoolDateFather_.IrectShuJuPianYi.Angle, out hv_modMat2D);

                    //HOperatorSet.GenCircle(out hv_Cirle, IOutSide_.Center_row_y, IOutSide_.Center_column_x, IOutSide_.Radius);
                    //HOperatorSet.AffineTransRegion(hv_Cirle, out hv_Cirle, hv_modMat2D, "nearest_neighbor");
                    //HOperatorSet.AreaCenter(hv_Cirle, out Area_, out Row_, out Column_);
                    
                    HOperatorSet.GenCircleContourXld(out hv_Cirle, IOutSide_.Center_row_y, IOutSide_.Center_column_x, IOutSide_.Radius, 0, 6.28318, "positive", 1);
                    HOperatorSet.AffineTransContourXld(hv_Cirle, out hv_Cirle, hv_modMat2D);
                    HTuple pointOrder;
                    HOperatorSet.AreaCenterXld(hv_Cirle, out Area_, out Row_, out Column_, out pointOrder);

                    hv_Cirle.Dispose();
                    IOutSide_.Center_column_x = Column_;
                    IOutSide_.Center_row_y = Row_;

                }
                #endregion

                #region  判断是不是矩形2
                if (ioutSide_ is IOutsideRectangle2ROI)//判断是不是矩形2
                {
                    HTuple hv_modMat2D,mid_row_,mid_col_,phi_,area_;
                    HObject ho_ROI_0;
                    IOutsideRectangle2ROI IOutSide_ = (IOutsideRectangle2ROI)ioutSide_;
                    HOperatorSet.GenRectangle2(out ho_ROI_0, IOutSide_.Mid_row_y, IOutSide_.Mid_col_x, -IOutSide_.Phi, IOutSide_.Len1, IOutSide_.Len2);        
                    HOperatorSet.VectorAngleToRigid(itoolDateFather_.GenSuiDian_Y_Row, itoolDateFather_.GeuSuiDian_X_Col, itoolDateFather_.GenSuiDian_A, itoolDateFather_.IrectShuJuPianYi.Row, itoolDateFather_.IrectShuJuPianYi.Column, itoolDateFather_.IrectShuJuPianYi.Angle, out hv_modMat2D);

                    HOperatorSet.AffineTransRegion(ho_ROI_0, out ho_ROI_0, hv_modMat2D, "nearest_neighbor");

                    HOperatorSet.AreaCenter(ho_ROI_0, out area_, out mid_row_, out mid_col_);

                    HOperatorSet.OrientationRegion(ho_ROI_0, out phi_);
                    IOutSide_.Mid_col_x = mid_col_;
                    IOutSide_.Mid_row_y = mid_row_;
                    IOutSide_.Phi = -phi_;
                    
                    ho_ROI_0.Dispose();

                }
                #endregion

                #region  刷新定位点
                itoolDateFather_.GenSuiDian_A = itoolDateFather_.IrectShuJuPianYi.Angle;
                itoolDateFather_.GenSuiDian_Y_Row = itoolDateFather_.IrectShuJuPianYi.Row;
                itoolDateFather_.GeuSuiDian_X_Col = itoolDateFather_.IrectShuJuPianYi.Column;
                #endregion
                
            }
        }

        #region  无用代码
        //public void ShuaXinDingWeiDian2(IToolDateFather itoolDateFather_, IOutsideCricleROI ioutSide_)
        //{
        //    if (itoolDateFather_.IrectShuJuPianYi != null)//更新定位点
        //    {
        //        //#region  判断是不是圆
        //        //if (ioutSide_ != null)//判断是不是圆
        //        //{
        //        //    //IOutsideCricle IOutSide_ = (IOutsideCricle)ioutSide_;
        //        //    HTuple hv_modMat2D;
        //        //    HObject hv_Cirle;
        //        //    HTuple Area_, Column_, Row_;

        //        //    HOperatorSet.VectorAngleToRigid(itoolDateFather_.GenSuiDian_Y_Row, itoolDateFather_.GeuSuiDian_X_Col, itoolDateFather_.GenSuiDian_A, itoolDateFather_.IrectShuJuPianYi.Row, itoolDateFather_.IrectShuJuPianYi.Column, itoolDateFather_.IrectShuJuPianYi.Angle, out hv_modMat2D);

        //        //    HOperatorSet.GenCircle(out hv_Cirle, ioutSide_.Center_row_y, ioutSide_.Center_column_x, ioutSide_.Radius);
        //        //    HOperatorSet.AffineTransRegion(hv_Cirle, out hv_Cirle, hv_modMat2D, "nearest_neighbor");
        //        //    HOperatorSet.AreaCenter(hv_Cirle, out Area_, out Row_, out Column_);

        //        //    hv_Cirle.Dispose();
        //        //    ioutSide_.Center_column_x = Column_;
        //        //    ioutSide_.Center_row_y = Row_;

        //        //}
        //        //#endregion
                            
        //        //#region  刷新定位点
        //        //itoolDateFather_.GenSuiDian_A = itoolDateFather_.IrectShuJuPianYi.Angle;
        //        //itoolDateFather_.GenSuiDian_Y_Row = itoolDateFather_.IrectShuJuPianYi.Row;
        //        //itoolDateFather_.GeuSuiDian_X_Col = itoolDateFather_.IrectShuJuPianYi.Column;
        //        //#endregion
        //    }
        //}
        #endregion
       
        
        #endregion
        
        #region  判断工具路径是否存在
        /// <summary>
        /// 判断工具路径是否存在
        /// </summary>
        public string  panDuanToolShiFouCunZai(string toolPath_)
        {
            if (!MultTree.CalculateMultTreeNodeName.CalculateMultTreeNodeName.PanDuanFuJieDianShiFoCunZai(toolPath_))
            {
                toolPath_ = "";
            }
            return toolPath_;
        }

        #endregion

        #region  无用代码
        //#region  显示参数
        ///// <summary>
        ///// 显示参数
        ///// </summary>
        ///// <returns></returns>
        //public virtual bool show_Paramters(string strOne_,string strTwo_, ListBox lisOne_, ListBox lisTwo_)
        //{
        //    bool ok = false;
        //    this.panDuanToolShiFouCunZai(strOne_);
        //    this.panDuanToolShiFouCunZai(strTwo_);

        //    if (strOne_ != "")
        //    {
        //        lisOne_.Items.Add(strOne_);
        //    }

        //    if (strTwo_ != "")
        //    {
        //        lisTwo_.Items.Add(strTwo_);
        //    }
        //    ok = true;
        //    return ok;
        //}        
        //#endregion
        #endregion
    }
    #endregion

    #region   操作树工具
    /// <summary>
    /// 操作树工具
    /// </summary>
    public static class operationTreeViewTool
    {
        #region  初始化树
        /// <summary>
        /// 初始化树
        /// </summary>
        public static void initTreeView(TreeView treeView_, IMultTreeNode root_)
        {
            TreeNode tr_0 = new TreeNode();
            tr_0.Text = "驱动1";
            tr_0.Name = "System_1"; //新建一个驱动

            if (treeView_.Nodes != null)
            {
                treeView_.Nodes.Clear();
            }//清空树

            TreeStatic.load_MultTreeNode_To_TreeNode_ContainsSelf(tr_0, root_);
            treeView_.Nodes.Add(tr_0);//添加一个检测
            treeView_.ExpandAll();
        }
        #endregion

        #region  获取父节点路径
        /// <summary>
        /// 获取父节点路径
        /// </summary>
        /// <param name="current_treenode"></param>
        /// <param name="_tool_treeview_struct"></param>
       public static void get_parent_node_path(ref  TreeNode current_treenode, ref  MultTreeControlLibrary.tool_treeview_struct _tool_treeview_struct)
        {
            #region  获取父节点名称
            string parentnodepath = "";
            //_tool_treeview_struct.current_nodes_parent.Clear();
            for (bool parent = true; parent == true; )//获取当前节点的所有父节点的名称
            {
                if (current_treenode.Parent != null)
                {
                    //_tool_treeview_struct.current_nodes_parent.Insert(0, current_treenode.Parent.Name);
                    parentnodepath = current_treenode.Parent.Name + '>' + parentnodepath;
                    current_treenode = current_treenode.Parent;
                }
                else
                {
                    parent = false;
                }
            }
            _tool_treeview_struct.Current_Node_lujing = parentnodepath + _tool_treeview_struct.Current_Nodes_Name;
            #endregion

            string[] node_name = _tool_treeview_struct.Current_Node_lujing.Split('>');
            // MultTreeNode_Interface mu;
            IMultTreeNode mu;
            mu = TreeStatic.Root.findNodeById(node_name[1]);
            int node_name_number = node_name.Length;
            for (int i = 2; i < node_name_number; i++)
            {
                mu = mu.findNodeById(node_name[i]);
            }
            //TreeStatic.Mult_Tree_Node = mu;
            _tool_treeview_struct.Current_MultTreeNode = mu;
        }
        #endregion
    }
    #endregion

}
