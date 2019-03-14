using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using HalconDotNet;
using CalibrationLibrary;
using MultTree.MultTreeNodeStruct;
using CheckStreamLibrary;
using MultTree;
using TemplateHalconLibrary;
using CircleLibrary;
using LineLibrary;






namespace CalibrationLibrary.UI
{
    public partial class CalibrationFrm : Form
    {
        #region  全局变量

        #region   标定数据
        /// <summary>
        /// 标定数据
        /// </summary>
        ICalibrationShuJu _ICal;
        #endregion

        #region 当前选择树节点的信息
        /// <summary>
        /// 当前选择定位树节点的信息
        /// </summary>
        MultTreeControlLibrary.tool_treeview_struct _tool_treeview_struct;
        #endregion

        #region  无用代码
        //#region 标定工具
        ///// <summary>
        ///// 标定工具
        ///// </summary>
        //Calibration _Cal;
        //#endregion
        #endregion

        #region  设置标定数据
        /// <summary>
        /// 设置标定数据
        /// </summary>
        SetCalibrationShuJu _Set_Cal;
        #endregion

        #region  当前的检测流
        /// <summary>
        /// 检测流
        /// </summary>
        CheckStreamLibrary.ICheckStream _ICheckStr;
        #endregion

        #endregion

        #region  构造函数
        public CalibrationFrm(ICheckStream ICheck_)
        {
            InitializeComponent();
            _ICheckStr = ICheck_;
        }
        #endregion

        #region  初始化
        private void CalibrationFrm_Load(object sender, EventArgs e)
        {
            #region 初始化树
            //TreeNode tr_0 = new TreeNode();
            //tr_0.Text = "驱动1";
            //tr_0.Name = "System_1"; //新建一个驱动

            //if (treeView1.Nodes != null)
            //{
            //    treeView1.Nodes.Clear();
            //}//清空树

            //TreeStatic.load_MultTreeNode_To_TreeNode_ContainsSelf(tr_0, _ICheckStr.Check_Root);
            //treeView1.Nodes.Add(tr_0);//添加一个检测
            //treeView1.ExpandAll();

            MultTree.operationTreeViewTool.initTreeView(treeView1, _ICheckStr.Check_Root);

            #endregion

            _Set_Cal = new SetCalibrationShuJu();

#if DEBUG == true
            if (TreeStatic.Mult_Tree_Node.Obj == null)
            {
                _ICal = new CalibrationShuJu();
            }
            else
            {
                _ICal = (CalibrationShuJu)TreeStatic.Mult_Tree_Node.Obj; ;
            }
#else
          _ICircleShuJu = new CircleShuJu();
#endif

            _Set_Cal.Set_show_row_col(_ICal, this.Controls);

            #region   显示标定的工具
            this._Set_Cal.Set_showTool(this._ICal, listBox_cal_tool);

            //foreach (string tool in _ICal._Cal_tool_path)
            //{
            //    listBox_cal_tool.Items.Add(tool);
            //}
            #endregion
        }
        #endregion

        #region  无用代码
        //#region 确定像素坐标
        //private void bnt_sure_pixel_Click(object sender, EventArgs e)
        //{
        //    List<double> pixel_col_x_ = new List<double>();
        //    List<double> pixel_row_y_ = new List<double>();

        //    /*** x1  **/
        //    pixel_col_x_.Add(Convert.ToDouble(pixel_col_x1.Text));
        //    pixel_row_y_.Add(Convert.ToDouble(pixel_row_y1.Text));

        //    /*** x2  **/
        //    pixel_col_x_.Add(Convert.ToDouble(pixel_col_x2.Text));
        //    pixel_row_y_.Add(Convert.ToDouble(pixel_row_y2.Text));

        //    /*** x3  **/
        //    pixel_col_x_.Add(Convert.ToDouble(pixel_col_x3.Text));
        //    pixel_row_y_.Add(Convert.ToDouble(pixel_row_y3.Text));

        //    /*** x4  **/
        //    pixel_col_x_.Add(Convert.ToDouble(pixel_col_x4.Text));
        //    pixel_row_y_.Add(Convert.ToDouble(pixel_row_y4.Text));

        //    /*** x5  **/
        //    pixel_col_x_.Add(Convert.ToDouble(pixel_col_x5.Text));
        //    pixel_row_y_.Add(Convert.ToDouble(pixel_row_y5.Text));

        //    /*** x6  **/
        //    pixel_col_x_.Add(Convert.ToDouble(pixel_col_x6.Text));
        //    pixel_row_y_.Add(Convert.ToDouble(pixel_row_y6.Text));

        //    /*** x7  **/
        //    pixel_col_x_.Add(Convert.ToDouble(pixel_col_x7.Text));
        //    pixel_row_y_.Add(Convert.ToDouble(pixel_row_y7.Text));

        //    /*** x8  **/
        //    pixel_col_x_.Add(Convert.ToDouble(pixel_col_x8.Text));
        //    pixel_row_y_.Add(Convert.ToDouble(pixel_row_y8.Text));

        //    /*** x9  **/
        //    pixel_col_x_.Add(Convert.ToDouble(pixel_col_x9.Text));
        //    pixel_row_y_.Add(Convert.ToDouble(pixel_row_y9.Text));

        //    _Set_Cal.Set_Cal_pixel(_ICal, ref pixel_row_y_, ref pixel_col_x_);

        //}
        //#endregion

        //#region  确定世界坐标
        //private void bnt_sure_world_Click(object sender, EventArgs e)
        //{
        //    List<double> world_row_y_ = new List<double>();
        //    List<double> world_col_x_ = new List<double>();

        //    /*** x1 ***/
        //    world_col_x_.Add(Convert.ToDouble(world_col_x1.Text));
        //    world_row_y_.Add(Convert.ToDouble(world_row_y1.Text));

        //    /*** x2 ***/
        //    world_col_x_.Add(Convert.ToDouble(world_col_x2.Text));
        //    world_row_y_.Add(Convert.ToDouble(world_row_y2.Text));

        //    /*** x3 ***/
        //    world_col_x_.Add(Convert.ToDouble(world_col_x3.Text));
        //    world_row_y_.Add(Convert.ToDouble(world_row_y3.Text));

        //    /*** x4 ***/
        //    world_col_x_.Add(Convert.ToDouble(world_col_x4.Text));
        //    world_row_y_.Add(Convert.ToDouble(world_row_y4.Text));

        //    /*** x5 ***/
        //    world_col_x_.Add(Convert.ToDouble(world_col_x5.Text));
        //    world_row_y_.Add(Convert.ToDouble(world_row_y5.Text));

        //    /*** x6 ***/
        //    world_col_x_.Add(Convert.ToDouble(world_col_x6.Text));
        //    world_row_y_.Add(Convert.ToDouble(world_row_y6.Text));

        //    /*** x7 ***/
        //    world_col_x_.Add(Convert.ToDouble(world_col_x7.Text));
        //    world_row_y_.Add(Convert.ToDouble(world_row_y7.Text));

        //    /*** x8 ***/
        //    world_col_x_.Add(Convert.ToDouble(world_col_x8.Text));
        //    world_row_y_.Add(Convert.ToDouble(world_row_y8.Text));

        //    /*** x9 ***/
        //    world_col_x_.Add(Convert.ToDouble(world_col_x9.Text));
        //    world_row_y_.Add(Convert.ToDouble(world_row_y9.Text));

        //    _Set_Cal.Set_Cal_world(_ICal, ref world_col_x_, ref world_row_y_);

        //}
        //#endregion
        #endregion

        #region  标定数据
        private void bnt_biaoding_Click(object sender, EventArgs e)
        {
            bnt_biaoding.Text = "正在标定";

            double[] pixel_x_col = new double[9];
            double[] pixel_y_row = new double[9];
            double[] world_x_col = new double[9];
            double[] world_y_row = new double[9];

            #region 像素x
            pixel_x_col[0] = Convert.ToDouble(txt_pixel_col_x1.Text);
            pixel_x_col[1] = Convert.ToDouble(txt_pixel_col_x2.Text);
            pixel_x_col[2] = Convert.ToDouble(txt_pixel_col_x3.Text);
            pixel_x_col[3] = Convert.ToDouble(txt_pixel_col_x4.Text);
            pixel_x_col[4] = Convert.ToDouble(txt_pixel_col_x5.Text);
            pixel_x_col[5] = Convert.ToDouble(txt_pixel_col_x6.Text);
            pixel_x_col[6] = Convert.ToDouble(txt_pixel_col_x7.Text);
            pixel_x_col[7] = Convert.ToDouble(txt_pixel_col_x8.Text);
            pixel_x_col[8] = Convert.ToDouble(txt_pixel_col_x9.Text);
            #endregion

            #region  像素y
            pixel_y_row[0] = Convert.ToDouble(txt_pixel_row_y1.Text);
            pixel_y_row[1] = Convert.ToDouble(txt_pixel_row_y2.Text);
            pixel_y_row[2] = Convert.ToDouble(txt_pixel_row_y3.Text);
            pixel_y_row[3] = Convert.ToDouble(txt_pixel_row_y4.Text);
            pixel_y_row[4] = Convert.ToDouble(txt_pixel_row_y5.Text);
            pixel_y_row[5] = Convert.ToDouble(txt_pixel_row_y6.Text);
            pixel_y_row[6] = Convert.ToDouble(txt_pixel_row_y7.Text);
            pixel_y_row[7] = Convert.ToDouble(txt_pixel_row_y8.Text);
            pixel_y_row[8] = Convert.ToDouble(txt_pixel_row_y9.Text);
            #endregion

            #region  世界x
            world_x_col[0] = Convert.ToDouble(txt_world_col_x1.Text);
            world_x_col[1] = Convert.ToDouble(txt_world_col_x2.Text);
            world_x_col[2] = Convert.ToDouble(txt_world_col_x3.Text);
            world_x_col[3] = Convert.ToDouble(txt_world_col_x4.Text);
            world_x_col[4] = Convert.ToDouble(txt_world_col_x5.Text);
            world_x_col[5] = Convert.ToDouble(txt_world_col_x6.Text);
            world_x_col[6] = Convert.ToDouble(txt_world_col_x7.Text);
            world_x_col[7] = Convert.ToDouble(txt_world_col_x8.Text);
            world_x_col[8] = Convert.ToDouble(txt_world_col_x9.Text);
            #endregion

            #region   世界y
            world_y_row[0] = Convert.ToDouble(txt_world_row_y1.Text);
            world_y_row[1] = Convert.ToDouble(txt_world_row_y2.Text);
            world_y_row[2] = Convert.ToDouble(txt_world_row_y3.Text);
            world_y_row[3] = Convert.ToDouble(txt_world_row_y4.Text);
            world_y_row[4] = Convert.ToDouble(txt_world_row_y5.Text);
            world_y_row[5] = Convert.ToDouble(txt_world_row_y6.Text);
            world_y_row[6] = Convert.ToDouble(txt_world_row_y7.Text);
            world_y_row[7] = Convert.ToDouble(txt_world_row_y8.Text);
            world_y_row[8] = Convert.ToDouble(txt_world_row_y9.Text);
            #endregion

            if (this._Set_Cal.Set_Cal_pixel_world_9Calibration(this._ICal, ref pixel_x_col, ref pixel_y_row, ref world_x_col, ref  world_y_row))
            {
                string biaoDingWuCha = "";
                this._Set_Cal.Set_YanZhengJingDu(this._ICal, ref biaoDingWuCha);
                bnt_biaoding.Text = "标定成功_____误差是：" + biaoDingWuCha;
            }
        }
        #endregion

        #region   选择定位的工具
        private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {
            TreeNode current_treenode = e.Node;
            if (e.Node.Text == "驱动1")
            {
                return;
            }//预防卡死
            treeView1.Enabled = false;//预防频率过高，卡死

            #region  取出节点数据
            _tool_treeview_struct.Current_Nodes_Name = e.Node.Name;//记录当前选择节点的名称
            _tool_treeview_struct.Current_Nodes_Text = e.Node.Text;

            MultTree.operationTreeViewTool.get_parent_node_path(ref current_treenode, ref _tool_treeview_struct);

            //get_parent_node_path(ref current_treenode, ref _tool_treeview_struct);
            #endregion

            treeView1.Enabled = true;//预防频率过高，卡死

            synchroinization_GenSuiDingWeiLieBian();

        }

        #region 同步跟随工具列表
        /// <summary>
        /// 同步跟随工具列表
        /// </summary>
        void synchroinization_GenSuiDingWeiLieBian()
        {
            if (this.listBox_cal_tool.Items.Contains(_tool_treeview_struct.Current_Node_lujing))
            {
                this.listBox_cal_tool.SelectedIndex = this.listBox_cal_tool.Items.IndexOf(_tool_treeview_struct.Current_Node_lujing);
            }
            else
            {
                this.listBox_cal_tool.ClearSelected();
            }
        }
        #endregion

        #region 无用代码
        //#region  获取父节点路径
        ///// <summary>
        ///// 获取父节点路径
        ///// </summary>
        ///// <param name="current_treenode"></param>
        ///// <param name="_tool_treeview_struct"></param>
        //static void get_parent_node_path(ref  TreeNode current_treenode, ref  MultTreeControlLibrary.tool_treeview_struct _tool_treeview_struct)
        //{
        //    #region  获取父节点名称
        //    string parentnodepath = "";
        //    //_tool_treeview_struct.current_nodes_parent.Clear();
        //    for (bool parent = true; parent == true; )//获取当前节点的所有父节点的名称
        //    {
        //        if (current_treenode.Parent != null)
        //        {
        //            //_tool_treeview_struct.current_nodes_parent.Insert(0, current_treenode.Parent.Name);
        //            parentnodepath = current_treenode.Parent.Name + '>' + parentnodepath;
        //            current_treenode = current_treenode.Parent;
        //        }
        //        else
        //        {
        //            parent = false;
        //        }
        //    }
        //    _tool_treeview_struct.Current_Node_lujing = parentnodepath + _tool_treeview_struct.Current_Nodes_Name;
        //    #endregion

        //    string[] node_name = _tool_treeview_struct.Current_Node_lujing.Split('>');
        //    // MultTreeNode_Interface mu;
        //    IMultTreeNode mu;
        //    mu = TreeStatic.Root.findNodeById(node_name[1]);
        //    int node_name_number = node_name.Length;
        //    for (int i = 2; i < node_name_number; i++)
        //    {
        //        mu = mu.findNodeById(node_name[i]);
        //    }
        //    //TreeStatic.Mult_Tree_Node = mu;
        //    _tool_treeview_struct.Current_MultTreeNode = mu;
        //}
        //#endregion
        #endregion

        #endregion

        #region  无用代码
        //#region 选择标定的工具
        //private void bnt_sure_fallow_tool_Click(object sender, EventArgs e)
        //{
        //    sure_fallow_tool();
        //}

        //#region   选择标定的工具
        ///// <summary>
        ///// 选择标定的工具
        ///// </summary>
        //void sure_fallow_tool()
        //{
        //    string str1 = _tool_treeview_struct.Current_Nodes_Name;

        //    switch (str1.Substring(0, str1.IndexOf("_")))
        //    {
        //        #region  模板工具
        //        case "Template":
        //            #region  取出数据
        //            ITemplateShuJu ITemplate_ = (TemplateShuJu)_tool_treeview_struct.Current_MultTreeNode.Obj;
        //            #endregion

        //            #region  算法
        //            ITemplate_._ICalibration = _ICal;
        //            _ICal._Cal_tool_path.Add(_tool_treeview_struct.Current_Node_lujing);
        //            listBox_cal_tool.Items.Add(_tool_treeview_struct.Current_Node_lujing);
        //            #endregion
        //            break;

        //        #endregion

        //        #region  拟合圆
        //        case "Circle":
        //            #region  取出数据
        //            ICircleShuJu ICircle_ = (CircleShuJu)_tool_treeview_struct.Current_MultTreeNode.Obj;
        //            #endregion

        //            #region 算法
        //            ICircle_._ICalibration = _ICal;
        //            _ICal._Cal_tool_path.Add(_tool_treeview_struct.Current_Node_lujing);
        //            listBox_cal_tool.Items.Add(_tool_treeview_struct.Current_Node_lujing);
        //            #endregion
        //            break;
        //        #endregion

        //        #region  拟合边
        //        case "Line":
        //            #region  取出数据
        //            ILineShuJu ILine_ = (LineShuJu)_tool_treeview_struct.Current_MultTreeNode.Obj;
        //            #endregion

        //            #region  算法
        //            ILine_._ICalibration = _ICal;
        //            _ICal._Cal_tool_path.Add(_tool_treeview_struct.Current_Node_lujing);
        //            listBox_cal_tool.Items.Add(_tool_treeview_struct.Current_Node_lujing);
        //            #endregion                    
        //            break;
        //        #endregion

        //        #region  默认
        //        default:
        //            MessageBox.Show("当前控件不能用于标定");
        //            break;
        //        #endregion
        //    }
        //}
        //#endregion

        //#endregion
        #endregion

        #region   添加标定的工具
        private void bnt_sure_biao_ding_tool_Click(object sender, EventArgs e)
        {
            tian_jia_biao_ding_de_gong_ju();
        }

        #region   添加标定工具
        /// <summary>
        /// 确定标定的工具
        /// </summary>
        /// <returns></returns>
        void tian_jia_biao_ding_de_gong_ju()
        {

            #region  确定放射变换
            if (this._ICal.HomMat2D == null)
            {
                MessageBox.Show("还没有标定");
                return;
            }
            #endregion

            #region  确定工具是否没有添加
            if (listBox_cal_tool.Items.Contains(_tool_treeview_struct.Current_Node_lujing))
            {
                MessageBox.Show("数据已经添加，请先删除");
                return;
            }
            #endregion

            #region  取出数据
            var CalDate_ = _tool_treeview_struct.Current_MultTreeNode.Obj as MultTree.ToolDateFather;
            if (CalDate_ != null)
            {
                CalDate_._ICalibration = _ICal;
            }
            else
            {
                MessageBox.Show("移除标定工具出错");
            }
            #endregion

            #region  同步数据

            _ICal._Cal_tool_path.Add(_tool_treeview_struct.Current_Node_lujing);
            listBox_cal_tool.Items.Add(_tool_treeview_struct.Current_Node_lujing);

            #endregion


            #region  无用代码
            //string str1 = _tool_treeview_struct.Current_Nodes_Name;
            //switch (str1.Substring(0, str1.IndexOf("_")))
            //{
            //    #region  模板工具
            //    case "Template":
            //        #region  无用代码
            //        //#region  取出数据
            //        //ITemplateShuJu ITemplate_ = (TemplateShuJu)_tool_treeview_struct.Current_MultTreeNode.Obj;
            //        //#endregion

            //        //#region  算法
            //        //ITemplate_._ICalibration = _ICal;
            //        //_ICal._Cal_tool_path.Add(_tool_treeview_struct.Current_Node_lujing);
            //        //listBox_cal_tool.Items.Add(_tool_treeview_struct.Current_Node_lujing);
            //        //#endregion
            //        #endregion

            //        #region   取出数据
            //        var ITemplate_ = _tool_treeview_struct.Current_MultTreeNode.Obj as MultTree.ToolDateFather;
            //        #endregion

            //        #region  算法
            //        if (ITemplate_ != null)
            //        {
            //            ITemplate_._ICalibration = _ICal;
            //            _ICal._Cal_tool_path.Add(_tool_treeview_struct.Current_Node_lujing);
            //            listBox_cal_tool.Items.Add(_tool_treeview_struct.Current_Node_lujing);//同步数据
            //        }
            //        #endregion
            //        break;

            //    #endregion

            //    #region  拟合圆
            //    //case "Circle":
            //    //    #region  取出数据
            //    //    ICircleShuJu ICircle_ = (CircleShuJu)_tool_treeview_struct.Current_MultTreeNode.Obj;
            //    //    #endregion

            //    //    #region 算法
            //    //    ICircle_._ICalibration = _ICal;
            //    //    _ICal._Cal_tool_path.Add(_tool_treeview_struct.Current_Node_lujing);
            //    //    listBox_cal_tool.Items.Add(_tool_treeview_struct.Current_Node_lujing);
            //    //    #endregion
            //    //    break;
            //    #endregion

            //    #region  拟合边
            //    case "Line":
            //        #region  取出数据
            //        ILineShuJu ILine_ = (LineShuJu)_tool_treeview_struct.Current_MultTreeNode.Obj;
            //        #endregion

            //        #region  算法
            //        ILine_._ICalibration = _ICal;
            //        _ICal._Cal_tool_path.Add(_tool_treeview_struct.Current_Node_lujing);
            //        listBox_cal_tool.Items.Add(_tool_treeview_struct.Current_Node_lujing);
            //        #endregion
            //        break;
            //    #endregion

            //    #region  默认
            //    default:
            //        MessageBox.Show("当前控件不能用于标定");
            //        break;
            //    #endregion
            //}
            #endregion
        }
        #endregion
        #endregion

        #region  移除标定的工具
        private void bnt_delect_biao_ding_tool_Click(object sender, EventArgs e)
        {
            yi_chu_biao_ding_de_gong_ju();
        }

        #region  移除标定的工具
        /// <summary>
        /// 移除标定的工具
        /// </summary>
        /// <returns></returns>
        void yi_chu_biao_ding_de_gong_ju()
        {
            #region   判断工具是否已经添加过
            if (!this.listBox_cal_tool.Items.Contains(_tool_treeview_struct.Current_Node_lujing))
            {
                MessageBox.Show("工具没有添加跟随定位，移除不了请先添加");
                return;
            }
            #endregion

            #region   取出数据
            var CalDate_ = _tool_treeview_struct.Current_MultTreeNode.Obj as MultTree.ToolDateFather;
            if (CalDate_ != null)
            {
                CalDate_._ICalibration = null;
            }
            else
            {
                MessageBox.Show("移除标定工具出错");
            }
            #endregion

            #region  同步数据
            _ICal._Cal_tool_path.Remove(_tool_treeview_struct.Current_Node_lujing);
            this.listBox_cal_tool.Items.Remove(_tool_treeview_struct.Current_Node_lujing);
            #endregion


            #region  无用代码
            //string str1 = _tool_treeview_struct.Current_Nodes_Name;

            //switch (str1.Substring(0, str1.IndexOf("_")))
            //{
            //    #region  模板工具
            //    case "Template":
            //        #region  无用代码
            //        //#region  取出数据
            //        //ITemplateShuJu ITemplate_ = (TemplateShuJu)_tool_treeview_struct.Current_MultTreeNode.Obj;
            //        //#endregion

            //        //#region  算法
            //        //ITemplate_._ICalibration = null;
            //        //_ICal._Cal_tool_path.Remove(_tool_treeview_struct.Current_Node_lujing);
            //        //listBox_cal_tool.Items.Remove(_tool_treeview_struct.Current_Node_lujing);
            //        //#endregion
            //        #endregion

            //        #region   取出数据
            //        var ITemplate_ = _tool_treeview_struct.Current_MultTreeNode.Obj as MultTree.ToolDateFather;
            //        #endregion

            //        #region    算法
            //        if (ITemplate_ != null)
            //        {
            //            ITemplate_._ICalibration = null;
            //            _ICal._Cal_tool_path.Remove(_tool_treeview_struct.Current_Node_lujing);
            //            listBox_cal_tool.Items.Remove(_tool_treeview_struct.Current_Node_lujing);
            //        }
            //        #endregion
            //        break;

            //    #endregion

            //    #region  拟合圆
            //    //case "Circle":

            //    //    #region  取出数据
            //    //    ICircleShuJu ICircle_ = (CircleShuJu)_tool_treeview_struct.Current_MultTreeNode.Obj;
            //    //    #endregion

            //    //    #region 算法
            //    //    ICircle_._ICalibration = null;
            //    //    _ICal._Cal_tool_path.Remove(_tool_treeview_struct.Current_Node_lujing);
            //    //    #endregion

            //    //    #region   同步数据
            //    //    listBox_cal_tool.Items.Remove(_tool_treeview_struct.Current_Node_lujing);
            //    //    #endregion

            //    //    break;
            //    #endregion

            //    #region  拟合边
            //    case "Line":

            //        #region  取出数据
            //        ILineShuJu ILine_ = (LineShuJu)_tool_treeview_struct.Current_MultTreeNode.Obj;
            //        #endregion

            //        #region  算法
            //        ILine_._ICalibration = null;
            //        _ICal._Cal_tool_path.Remove(_tool_treeview_struct.Current_Node_lujing);

            //        #endregion

            //        #region    同步数据

            //        listBox_cal_tool.Items.Remove(_tool_treeview_struct.Current_Node_lujing);
            //        #endregion

            //        break;
            //    #endregion

            //    #region  默认
            //    default:
            //        MessageBox.Show("当前控件不能用于标定");
            //        break;
            //    #endregion
            //}
            #endregion
        }
        #endregion
        #endregion

        #region  测试标定
        private void bnt_ceShiBiaoDing_Click(object sender, EventArgs e)
        {
            string x = txt_XiangSuX.Text;
            string y = txt_XiangSuY.Text;

            this._Set_Cal.ceShiBiaoDing(this._ICal, ref x, ref y);

            txt_ShiJieZuoBiaoX.Text = x;
            txt_ShiJieZuoBiaoY.Text = y;
            #region  无用代码
            //像素坐标
            //  HTuple hv_xiangsu_x = new HTuple();
            //   hv_xiangsu_x[0] = 1117.8735;
            //   hv_xiangsu_x[1] = 1121.0515;
            //   hv_xiangsu_x[2] = 1120.2373;
            //   hv_xiangsu_x[3] = 1027.886;
            //   hv_xiangsu_x[4] = 1029.6871;
            //   hv_xiangsu_x[5] = 1035.337;
            //   hv_xiangsu_x[6] = 941.963;
            //   hv_xiangsu_x[7] = 941.729;
            //   hv_xiangsu_x[8] = 945.122;
            //HTuple  hv_xiangsu_y = new HTuple();
            //   hv_xiangsu_y[0] = 1067.1712;
            //   hv_xiangsu_y[1] = 981.6710;
            //   hv_xiangsu_y[2] = 893.158;
            //   hv_xiangsu_y[3] = 1062.052;
            //   hv_xiangsu_y[4] = 979.107;
            //   hv_xiangsu_y[5] = 889.405;
            //   hv_xiangsu_y[6] = 1057.785;
            //   hv_xiangsu_y[7] = 973.204;
            //   hv_xiangsu_y[8] = 887.8228;
            //   //世界坐标
            // HTuple  hv_calcol_world_x = new HTuple();
            //   hv_calcol_world_x[0] = -5;
            //   hv_calcol_world_x[1] = 0;
            //   hv_calcol_world_x[2] = 5;
            //   hv_calcol_world_x[3] = -5;
            //   hv_calcol_world_x[4] = 0;
            //   hv_calcol_world_x[5] = 5;
            //   hv_calcol_world_x[6] = -5;
            //   hv_calcol_world_x[7] = 0;
            //   hv_calcol_world_x[8] = 5;
            // HTuple  hv_calrow_world_y = new HTuple();
            //   hv_calrow_world_y[0] = -5;
            //   hv_calrow_world_y[1] = -5;
            //   hv_calrow_world_y[2] = -5;
            //   hv_calrow_world_y[3] = 0;
            //   hv_calrow_world_y[4] = 0;
            //   hv_calrow_world_y[5] = 0;
            //   hv_calrow_world_y[6] = 5;
            //   hv_calrow_world_y[7] = 5;
            //   hv_calrow_world_y[8] = 5;

            //   HTuple hv_HomMat2D2, hv_Qx1, hv_Qy1, hv_RowTrans, hv_ColTrans;

            //   HOperatorSet.VectorToHomMat2d(hv_xiangsu_x, hv_xiangsu_y, hv_calcol_world_x,
            //       hv_calrow_world_y, out hv_HomMat2D2);

            //   HOperatorSet.AffineTransPoint2d(hv_HomMat2D2, 1117.8735, 1067.1712, out hv_Qx1,
            //       out hv_Qy1);
            //   HOperatorSet.AffineTransPixel(hv_HomMat2D2, 1117.8735, 1067.1712, out hv_RowTrans,
            //       out hv_ColTrans);
            #endregion
        }
        #endregion
    }
}
