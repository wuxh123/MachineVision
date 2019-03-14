using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using HalconDotNet;
using System.IO;
using System.Threading;
using MultTree;
using MultTree.MultTreeNodeStruct;
using BarCodeHalconLibrary;
using TemplateHalconLibrary;
using OCRLibrary;
using OCVLibrary;
using CircleLibrary;
using BackGroundCheckHalconLibrary;
using DataCodeLibrary;




namespace RectLibrary.UI
{
    public partial class RectFrm : Form
    {
        #region    全局变量

        #region 当前选择定位树节点的信息
        /// <summary>
        /// 当前选择定位树节点的信息
        /// </summary>
        MultTreeControlLibrary.tool_treeview_struct _tool_treeview_struct;
        #endregion

        #region   当前选择 工具跟随树节点的信息
        /// <summary>
        ///  当前选择 工具跟随树节点的信息
        /// </summary>
        MultTreeControlLibrary.tool_treeview_struct _tool_treeview_struct2;
        #endregion

        #region  当前节点数据
        /// <summary>
        /// 当前节点数据
        /// </summary>
        IRectShuJu _IRect;
        #endregion

        #region  当前的检测流
        /// <summary>
        /// 检测流
        /// </summary>
        CheckStreamLibrary.ICheckStream _ICheckStr;
        #endregion

        #region 防射变化设置器
        /// <summary>
        /// 防射变化设置器
        /// </summary>
        RectLibrary.SetRectShuJu _SerRectShuJu = new SetRectShuJu();
        #endregion

        #endregion

        #region   构造函数
        public RectFrm(CheckStreamLibrary.ICheckStream ICheckStr_)
        {
            InitializeComponent();
            _ICheckStr = ICheckStr_;
        }
        #endregion

        #region  初始化
        private void ParentFrm_Load(object sender, EventArgs e)
        {
            #region  初始化树 定位树
            
            #region  无用代码
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
            #endregion

            MultTree.operationTreeViewTool.initTreeView(treeView1, _ICheckStr.Check_Root);
            
            #endregion

            #region   初始化 工具跟随定位树
            
            #region  无用代码
            //TreeNode tr_1 = new TreeNode();
            //tr_1.Text = "驱动1";
            //tr_1.Name = "System_1"; //新建一个驱动

            //if (treeView2.Nodes != null)
            //{
            //    treeView2.Nodes.Clear();
            //}//清空树

            //TreeStatic.load_MultTreeNode_To_TreeNode_ContainsSelf(tr_1, _ICheckStr.Check_Root);

            //treeView2.Nodes.Add(tr_1);//添加一个检测
            //treeView2.ExpandAll();
            #endregion

            MultTree.operationTreeViewTool.initTreeView(treeView2, _ICheckStr.Check_Root);

            #endregion

#if DEBUG ==true
            if (TreeStatic.Mult_Tree_Node.Obj == null)
            {
                _IRect = new RectLibrary.RectShuJu();
            }
            else
            {
                _IRect = (RectShuJu)TreeStatic.Mult_Tree_Node.Obj;
            }
#else
            _IRect = (RectShuJu)TreeStatic.Mult_Tree_Node.Obj;
#endif

            #region    显示路径
          this._IRect.Tool_Path= this._SerRectShuJu.ShuaXinToolJiHe(this._IRect.Tool_Path, listBox_GenSuiGongJu);

           this._IRect.BeiGenSuiDingWeiGongJu= this._SerRectShuJu.panDuanToolShiFouCunZai(this._IRect.BeiGenSuiDingWeiGongJu);
                      
            #endregion

            #region  显示原点   及定位工具
           if (this._IRect.BeiGenSuiDingWeiGongJu == "")
           {
               _IRect.Yuan_dian_row_y = null;
           }
           else
            {
                message.Text = "原点x:" + _IRect.Yuan_dian_col_x.ToString() + "__y:" + _IRect.Yuan_dian_row_y.ToString() + "__angle:" + _IRect.Yuan_dian_angle_a.ToString();

                listBox_DingWeiGongJu.Items.Clear();

                listBox_DingWeiGongJu.Items.Add(this._IRect.BeiGenSuiDingWeiGongJu);
            }
            #endregion

        }
        #endregion

        #region   查找所有节点
        /// <summary>
        /// 查找所有节点
        /// </summary>
        //void checkTreeNode(TreeNode tr, MultTreeNode mtr)
        //{
        //    foreach (MultTreeNode mtr_ in mtr.getChildList())
        //    {
        //        TreeNode tr_1 = new TreeNode();
        //        tr_1.Text = mtr_.getNodeName();
        //        tr_1.Name = mtr_.getSelfId();

        //        tr.Nodes.Add(tr_1);
        //        if (!mtr_.isLeaf())
        //        {
        //            checkTreeNode(tr_1, mtr_);
        //        }
        //    }
        //}
        #endregion

        #region  无用代码
        #region  无用代码
        #region  适应窗口
        //private void fit_window_strip_Click(object sender, EventArgs e)
        //{
        //   // DispImageFit();
        //}
        #endregion
        #endregion

        #region  无用代码
        #region  保存图片
        //private void save_Image_strip_Click(object sender, EventArgs e)
        //{

        //    HOperatorSet.GenEmptyObj(out _ho_Image);
        //        _ho_Image.Dispose();

        //    SaveWindowDumpDialog();
        //}

        ///// <summary>
        ///// 保存图片
        ///// </summary>
        //private void SaveWindowDumpDialog()
        //{
        //    try
        //    {
        //        SaveFileDialog sfd = new SaveFileDialog();
        //        //string imgFileName;

        //        sfd.Filter = "PNG图像|*.png|BMP图像|*.bmp|JPEG图像|*.jpg|所有文件|*.*";

        //        if (sfd.ShowDialog() == DialogResult.OK)
        //        {
        //            if (String.IsNullOrEmpty(sfd.FileName))
        //                return;
        //            HOperatorSet.WriteImage(_ho_Image, Path.GetExtension(sfd.FileName).Substring(1), 0, sfd.FileName);

        //            //  hv_image.WriteImage(Path.GetExtension(sfd.FileName).Substring(1), 0, sfd.FileName);
        //            //imgFileName = sfd.FileName;
        //            //SaveWindowDump(imgFileName, new Size(1280, 1024));
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        message.Text = ex.Message;
        //    }

        //}

        #endregion
        #endregion

        #region   无用代码
        #region  无用代码
        #region  循环运行
        //private void tSB_circulation_run_Click(object sender, EventArgs e)
        //{
        //    string str = tSB_circulation_run.Text;
        //    if (str == "循环运行")
        //    {
        //        _xun_huan_yun_xing_biao_zhi = true;
        //        tSB_circulation_run.Text = "停止循环";
        //        //timer_run.Enabled = true;
        //    }
        //    else
        //    {
        //        _xun_huan_yun_xing_biao_zhi = false;
        //       // timer_run.Enabled = false;
        //        tSB_circulation_run.Text = "循环运行";
        //    }
        //}
        #endregion
        #endregion

        #region  无用代码
        #region     运行
        //private void tSB_run_one_Click(object sender, EventArgs e)
        //{
        //    if (_run != null)
        //    {
        //        _run();

        //    }//_run_event.Set();
        //}

        ///// <summary>
        ///// 运行成功后回调
        ///// </summary>
        //void run_callBack(IAsyncResult re)
        //{
        //    if (_xun_huan_yun_xing_biao_zhi)
        //    {
        //        Invoke(new Action(delegate {
        //            _read();
        //        }));
        //       // timer_run.Enabled = true;
        //    }
        //}
        #endregion
        #endregion

        #region  无用代码
        #region   读取一张图片  线程

        #region  无用代码
        /// <summary>
        /// 读取一张图片   线程
        /// </summary>
        /// <returns></returns>
        //public void read_one_image()
        //{
        //    while (_start_stop)
        //    {
        //        _read_event.WaitOne();
        //        this.BeginInvoke(new Action(delegate
        //        {
        //            try
        //            {
        //                int i = listBox_acquire_picture.Items.Count;
        //                if (i > 0)
        //                {
        //                    if (_number_Image >= i)
        //                    {
        //                        _number_Image = 0;
        //                    }

        //                    Mai.Tool.readImage read = new Mai.Tool.readImage();
        //                    listBox_acquire_picture.SelectedIndex = _number_Image;

        //                    string path = listBox_acquire_picture.SelectedItem.ToString();
        //                    _number_Image++;

        //                    read.read_Image(path, hWindowControl1.HalconWindow);
        //                    _ho_Image = read.ho_Image;

        //                    if (_xun_huan_yun_xing_biao_zhi)
        //                    {
        //                        _run(); 
        //                     //   _run_event.Set();
        //                    }
        //                }
        //            }
        //            catch (Exception ex)
        //            {
        //                Mai.Log.LogManager.WriteLog(Mai.Log.LogFile.Error, "取图片一张出错");
        //                MessageBox.Show(ex.Message + " " + "取图片一张出错");
        //            }
        //        }));
        //    }
        //}
        #endregion

        #region 无用代码
        //public virtual bool read_one_image()
        //{
        //    bool ok = false;
        //    try
        //    {
        //        int i = listBox_acquire_picture.Items.Count;
        //        if (i > 0)
        //        {
        //            if (_number_Image >= i)
        //            {
        //                _number_Image = 0;
        //            }

        //            ReadImageHalcon.Tool.readImage read = new ReadImageHalcon.Tool.readImage();
        //            listBox_acquire_picture.SelectedIndex = _number_Image;

        //            string path = listBox_acquire_picture.SelectedItem.ToString();
        //            _number_Image++;

        //            read.read_Image(path, hWindowControl1.HalconWindow);
        //            _ho_Image = read.ho_Image;

        //            ok = true;
        //            if (_xun_huan_yun_xing_biao_zhi)
        //            {
        //                if (_run != null)
        //                {
        //                    _run.BeginInvoke(run_callBack, null);
        //                }
        //                else
        //                {
        //                    //timer_run.Enabled = true;
        //                }

        //                ok = true;
        //                //   _run_event.Set();
        //            }
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        SerializeTree.Log.LogManager.WriteLog(SerializeTree.Log.LogFile.Error, "取图片一张出错");
        //        MessageBox.Show(ex.Message + " " + "取图片一张出错");
        //        ok = false;
        //    }
        //    return ok;
        //}        
        #endregion

        #endregion
        #endregion

        #region 无用代码
        #region  取一张图片
        //private void tSB_read_image_Click(object sender, EventArgs e)
        //{
        //    //this.BeginInvoke(new Action(delegate {
        //    //    try
        //    //    {
        //    //        int i = listBox_acquire_picture.Items.Count;
        //    //        if (i > 0)
        //    //        {
        //    //            if (_number_Image >= i)
        //    //            {
        //    //                _number_Image = 0;
        //    //            }

        //    //            ReadImageHalcon.Tool.readImage read = new ReadImageHalcon.Tool.readImage();
        //    //            listBox_acquire_picture.SelectedIndex = _number_Image;

        //    //            string path = listBox_acquire_picture.SelectedItem.ToString();
        //    //            _number_Image++;

        //    //            read.read_Image(path, hWindowControl1.HalconWindow);
        //    //            _ho_Image = read.ho_Image;

        //    //        }
        //    //    }
        //    //    catch (Exception ex)
        //    //    {
        //    //        SerializeTree.Log.LogManager.WriteLog(SerializeTree.Log.LogFile.Error, "取图片一张出错");
        //    //        MessageBox.Show(ex.Message + " " + "取图片一张出错");
        //    //    }
        //    //}));
        //}
        #endregion
        #endregion
        #endregion



        #region   无用代码
        #region    添加图片
        //private void bnt_add_picture_Click(object sender, EventArgs e)
        //{
        //    OpenFileDialog open_file = new OpenFileDialog();
        //    open_file.Filter = "All files (*.*)|*.*|TIFF files (*.tif)|*tif";
        //    open_file.FilterIndex = 2;
        //    open_file.RestoreDirectory = true;
        //    open_file.Multiselect = true;
        //    open_file.ShowDialog();//打开对话框           

        //    if (listBox_acquire_picture.Items.Count != 0)//判断有无图片
        //    {
        //        listBox_acquire_picture.Items.Clear();//清空图片
        //    }

        //    if (_re.Path_Picture.Count!=0)
        //    {
        //        _re.Path_Picture.Clear();
        //    }


        //    foreach (string file_name in open_file.FileNames)
        //    {
        //        listBox_acquire_picture.Items.Add(file_name); //加载所有文件

        //        _re.Path_Picture.Add(file_name);

        //    }
        //}
        #endregion
        #endregion

        #region   无用代码
        #region     删除图片
        //private void btn_delete_picture_Click(object sender, EventArgs e)
        //{
        //    listBox_acquire_picture.Items.Clear();
        //}
        #endregion
        #endregion

        #region 无用代码
        #region     循环触发检测图片
        //private void timer_run_Tick(object sender, EventArgs e)
        //{
        //    //timer_run.Enabled = false;
        //    _read.Invoke();
        //   // _read_event.Set();
        //}
        #endregion
        #endregion
        #endregion

        #region  取出定位点
        private void btn_acqurie_lotation_Click(object sender, EventArgs e)
        {
            #region  无用代码
            //string str1 = _tool_treeview_struct.Current_Nodes_Name;
            //switch (str1.Substring(0, str1.IndexOf("_")))
            //{
            //    #region   定位工具
            //    case "Template":                    
            //        #region   取出节点数据
            //        ITemplateShuJu ITemplate_ = (TemplateShuJu)_tool_treeview_struct.Current_MultTreeNode.Obj;
            //        IRectShuJu IRect_ = (RectShuJu)TreeStatic.Mult_Tree_Node.Obj;
            //        #endregion
            //        #region   写入原点
            //        if (ITemplate_.Column != null)
            //        {
            //            IRectShuJuPianYi Irectshujupianyi_=(IRectShuJuPianYi)ITemplate_;
            //            //_SerRectShuJu.Set_Orgin(IRect_, (double)ITemplate_.Column, (double)ITemplate_.Row, (double)ITemplate_.Angle);
            //            _SerRectShuJu.Set_Orgin(IRect_, Irectshujupianyi_);
            //            Invoke(new Action(delegate {
            //                message.Text = "原点x:" + Irectshujupianyi_.Column.ToString() + "__y:" + Irectshujupianyi_.Row.ToString() + "__angle:" + Irectshujupianyi_.Angle.ToString();                        
            //            }));
            //        }
            //        else
            //        {
            //            MessageBox.Show("数据定位出错");
            //        }
            //        #endregion
            //        break;
            //    #endregion
            //    #region  默认
            //    default :
            //        MessageBox.Show("当前控件不能用于定位");
            //        break;
            //    #endregion
            //}
            #endregion
            get_lotation();
        }

        #region  取出定位点
        /// <summary>
        /// 取出定位点
        /// </summary>
        void get_lotation()
        {
            #region  判断是否已经有定位
            if (listBox_DingWeiGongJu.Items.Count > 0)
            {
                MessageBox.Show("已经存在定位，请先移除");
            }
            #endregion

            #region   取出节点数据
            var Irect = _tool_treeview_struct.Current_MultTreeNode.Obj as ToolDateFather;
            #endregion

            #region   算法
            if (Irect != null)
            {
                IRectShuJuPianYi Irectshujupianyi_ = (IRectShuJuPianYi)Irect;
                //_SerRectShuJu.Set_Orgin(IRect_, (double)ITemplate_.Column, (double)ITemplate_.Row, (double)ITemplate_.Angle);
                _SerRectShuJu.Set_Orgin(_IRect, Irectshujupianyi_);
                Invoke(new Action(delegate
                {
                    message.Text = "原点x:" + Irectshujupianyi_.Column.ToString() + "  y:" + Irectshujupianyi_.Row.ToString() + "  angle:" + Irectshujupianyi_.Angle.ToString();
                }));
            }
            #endregion

            #region   保存,把被跟随定位的工具同步到listBox_DingWeiGongJu中

            this._IRect.BeiGenSuiDingWeiGongJu = _tool_treeview_struct.Current_Node_lujing;
            listBox_DingWeiGongJu.Items.Clear();
            listBox_DingWeiGongJu.Items.Add(_tool_treeview_struct.Current_Node_lujing);
            listBox_DingWeiGongJu.SelectedIndex = listBox_DingWeiGongJu.Items.IndexOf(_tool_treeview_struct.Current_Node_lujing);

            #endregion

            #region  无用代码
            //string str1 = _tool_treeview_struct.Current_Nodes_Name;
            //switch (str1.Substring(0, str1.IndexOf("_")))
            //{
            //    #region   定位工具
            //    case "Template":

            //        #region   取出节点数据
            //        var ITemplate_ = _tool_treeview_struct.Current_MultTreeNode.Obj as ToolDateFather;
            //        #endregion

            //        #region   写入原点
            //        if (ITemplate_.Column != null)
            //        {
            //            IRectShuJuPianYi Irectshujupianyi_ = (IRectShuJuPianYi)ITemplate_;
            //            //_SerRectShuJu.Set_Orgin(IRect_, (double)ITemplate_.Column, (double)ITemplate_.Row, (double)ITemplate_.Angle);
            //            _SerRectShuJu.Set_Orgin(_IRect, Irectshujupianyi_);
            //            Invoke(new Action(delegate
            //            {
            //                message.Text = "原点x:" + Irectshujupianyi_.Column.ToString() + "__y:" + Irectshujupianyi_.Row.ToString() + "__angle:" + Irectshujupianyi_.Angle.ToString();
            //            }));
            //        }
            //        else
            //        {
            //            MessageBox.Show("数据定位出错");
            //        }
            //        #endregion

            //        #region   保存,把被跟随定位的工具同步到listBox_DingWeiGongJu中

            //        this._IRect.BeiGenSuiDingWeiGongJu = _tool_treeview_struct.Current_Node_lujing;
            //        listBox_DingWeiGongJu.Items.Clear();
            //        listBox_DingWeiGongJu.Items.Add(_tool_treeview_struct.Current_Node_lujing);
            //        listBox_DingWeiGongJu.SelectedIndex = listBox_DingWeiGongJu.Items.IndexOf(_tool_treeview_struct.Current_Node_lujing);

            //        #endregion

            //        break;
            //    #endregion

            //    #region  默认
            //    default:
            //        MessageBox.Show("当前控件不能用于定位");
            //        break;
            //    #endregion
            //}
            #endregion
        }
        #endregion

        #endregion

        #region treeview  选择工具
        /// <summary>
        /// 选择工具
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tool_treeView_AfterSelect(object sender, TreeViewEventArgs e)
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
            #region  无用代码
            //#region  取出节点数据 
            //_tool_treeview_struct.Current_Nodes_Name = e.Node.Name;//记录当前选择节点的名称
            //_tool_treeview_struct.Current_Nodes_Text = e.Node.Text;

            //#region  获取父节点名称
            //string parentnodepath = "";

            ////_tool_treeview_struct.current_nodes_parent.Clear();

            //for (bool parent = true; parent == true;)//获取当前节点的所有父节点的名称
            //{
            //    if (current_treenode.Parent != null)
            //    {
            //        //_tool_treeview_struct.current_nodes_parent.Insert(0, current_treenode.Parent.Name);
            //        parentnodepath = current_treenode.Parent.Name + '>' + parentnodepath;
            //        current_treenode = current_treenode.Parent;

            //    }
            //    else
            //    {
            //        parent = false;
            //    }
            //}

            //_tool_treeview_struct.Current_Node_lujing = parentnodepath + _tool_treeview_struct.Current_Nodes_Name;
            //#endregion

            //string[] node_name = _tool_treeview_struct.Current_Node_lujing.Split('>');

            //MultTreeNode_Interface mu;

            //mu = TreeStatic.get_Root().findNodeById(node_name[1]);

            //int node_name_number = node_name.Length;
            //for (int i = 2; i < node_name_number; i++)
            //{
            //    mu = mu.findNodeById(node_name[i]);
            //}
            //_rect_Mu = mu;
            //#endregion
            #endregion

            synchroinization_listBox_DingWeiGongJu();
        }
        #endregion

        #region   同步被跟随工具的列表
        /// <summary>
        /// 同步被跟随工具的列表
        /// </summary>
        void synchroinization_listBox_DingWeiGongJu()
        {
            if (this.listBox_DingWeiGongJu.Items.Contains(_tool_treeview_struct.Current_Node_lujing))
            {
                this.listBox_DingWeiGongJu.SelectedIndex = this.listBox_DingWeiGongJu.Items.IndexOf(_tool_treeview_struct.Current_Node_lujing);
            }
            else
            {
                this.listBox_DingWeiGongJu.ClearSelected();
            }
        }
        #endregion

        #region  无用代码
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

        //    #region  无用代码
        //    //#region 判断是不是取图节点
        //    //if (mu.SelfId.Contains("acquire"))
        //    //{
        //    //    //  MachineVision.ShuJuJieGou.TreeStatic.Mult_Tree_Node_Picture = mu;
        //    //    TreeStatic.Mult_Tree_Node_Picture = mu;
        //    //}
        //    //#endregion
        //    #endregion
        //}
        //#endregion
        #endregion

        #region    确定跟随的定位工具
        private void bnt_sure_fallow_tool_Click(object sender, EventArgs e)
        {
            sure_fallow_tool();
        }

        #region    确定跟随的定位工具
        /// <summary>
        /// 确定跟随的定位工具
        /// </summary>
        void sure_fallow_tool()
        {
            #region   判断工具是否已经添加过
            if (this.listBox_GenSuiGongJu.Items.Contains(_tool_treeview_struct2.Current_Node_lujing))
            {
                MessageBox.Show("工具以添加过定位，请先移除");
                return;
            }
            #endregion

            #region  取出数据
            var toolDate_ = _tool_treeview_struct2.Current_MultTreeNode.Obj as ToolDateFather;
            #endregion

            if (toolDate_ != null)
            {
                #region 算法
                toolDate_.GeuSuiDian_X_Col = _IRect.IRect_shuju_pianyi.Column;
                toolDate_.GenSuiDian_Y_Row = _IRect.IRect_shuju_pianyi.Row;
                toolDate_.GenSuiDian_A = _IRect.IRect_shuju_pianyi.Angle;

                //toolDate_.IrectShuJuPianYi = _IRect.IRect_shuju_pianyi;  
                
                toolDate_.IrectShuJuPianYi = _IRect.IDuiJieGenSuiDingWeiGongJu;
                
                #endregion

                #region  存储跟随定位的工具及同步显示
                _IRect.Tool_Path.Add(_tool_treeview_struct2.Current_Node_lujing);
                listBox_GenSuiGongJu.Items.Add(_tool_treeview_struct2.Current_Node_lujing);
                #endregion

                this.synchroinization_GenSuiDingWeiLieBian();
            }
            else
            {
                MessageBox.Show("添加工具出错");
            }

            #region  无用代码

            //string str1 = _tool_treeview_struct2.Current_Nodes_Name;
            ////IRectShuJu IRect_ = (RectShuJu)TreeStatic.Mult_Tree_Node.Obj;
            //switch (str1.Substring(0, str1.IndexOf("_")))
            //{
            //    #region  无用代码
            //    //#region  拟合圆
            //    //case "Circle":
            //    //    #region  取出数据
            //    //    ICircleShuJu ICircle_ = (CircleShuJu)_tool_treeview_struct2.Current_MultTreeNode.Obj;
            //    //    #endregion

            //    //    #region 算法
            //    //    ICircle_.Ihv_HomMat2D = _IRect;
            //    //    _IRect.Tool_Path.Add(_tool_treeview_struct2.Current_Node_lujing);
            //    //    listBox1.Items.Add(_tool_treeview_struct2.Current_Node_lujing);
            //    //    #endregion
            //    //    break;
            //    //#endregion

            //    //#region  拟合边
            //    //case "Line":
            //    //    #region  取出数据
            //    //    ILineShuJu ILine_ = (LineShuJu)_tool_treeview_struct2.Current_MultTreeNode.Obj;
            //    //    #endregion

            //    //    #region  算法
            //    //    ILine_.Ihv_HomMat2D = _IRect;
            //    //    _IRect.Tool_Path.Add(_tool_treeview_struct2.Current_Node_lujing);
            //    //    listBox1.Items.Add(_tool_treeview_struct2.Current_Node_lujing);
            //    //    #endregion
            //    //    break;
            //    //#endregion


            //    //#region   OCV
            //    //case "OCV":
            //    //    #region  取出数据
            //    //    IOCVShuJu IOCV_ = (OCVShuJu)_tool_treeview_struct2.Current_MultTreeNode.Obj;
            //    //    #endregion

            //    //    #region  算法
            //    //    IOCV_.Ihv_HomMat2D = _IRect;
            //    //    _IRect.Tool_Path.Add(_tool_treeview_struct2.Current_Node_lujing);
            //    //    listBox1.Items.Add(_tool_treeview_struct2.Current_Node_lujing);
            //    //    #endregion
            //    //    break;
            //    //#endregion
            //    #endregion

            //    #region  OCR
            //    case "OCR":
            //        #region  取出数据
            //        IOCRShuJu IOCR_ = (OCRShuJu)_tool_treeview_struct2.Current_MultTreeNode.Obj;
            //        #endregion

            //        #region  算法
            //        IOCR_.GenSuiDian_A = _IRect.IRect_shuju_pianyi.Angle;
            //        IOCR_.GeuSuiDian_X_Col = _IRect.IRect_shuju_pianyi.Column;
            //        IOCR_.GenSuiDian_Y_Row = _IRect.IRect_shuju_pianyi.Row;

            //        IOCR_.IrectShuJuPianYi = _IRect.IRect_shuju_pianyi;
            //        #endregion

            //        #region  存储跟随定位的工具及同步显示
            //        _IRect.Tool_Path.Add(_tool_treeview_struct2.Current_Node_lujing);

            //        listBox_GenSuiGongJu.Items.Add(_tool_treeview_struct2.Current_Node_lujing);

            //        #endregion


            //        break;
            //    #endregion

            //    #region   一维码
            //    case "BarCode":

            //        //#region   取出数据
            //        //IBarCodeShuJu IBar_ = (BarCodeShuJu)_tool_treeview_struct2.Current_MultTreeNode.Obj;
            //        //#endregion

            //        #region   取出数据
            //        var IBar_ = _tool_treeview_struct2.Current_MultTreeNode.Obj as ToolDateFather;
            //        #endregion

            //        #region   算法
            //        IBar_.GeuSuiDian_X_Col = _IRect.IRect_shuju_pianyi.Column;
            //        IBar_.GenSuiDian_Y_Row = _IRect.IRect_shuju_pianyi.Row;
            //        IBar_.GenSuiDian_A = _IRect.IRect_shuju_pianyi.Angle;
            //        IBar_.IrectShuJuPianYi = _IRect.IRect_shuju_pianyi;
            //        #endregion

            //        #region  存储跟随定位的工具及同步显示
            //        _IRect.Tool_Path.Add(_tool_treeview_struct2.Current_Node_lujing);
            //        listBox_GenSuiGongJu.Items.Add(_tool_treeview_struct2.Current_Node_lujing);
            //        #endregion

            //        break;
            //    #endregion

            //    #region   背景检测
            //    case "BackGround":

            //        #region   取出数据
            //        IBackGroundShuJu IBack_ = (BackGroundShuJu)_tool_treeview_struct2.Current_MultTreeNode.Obj;
            //        #endregion

            //        #region    算法

            //        IBack_.GeuSuiDian_X_Col = this._IRect.IRect_shuju_pianyi.Column;
            //        IBack_.GenSuiDian_Y_Row = this._IRect.IRect_shuju_pianyi.Row;
            //        IBack_.GenSuiDian_A = this._IRect.IRect_shuju_pianyi.Angle;

            //        IBack_.IrectShuJuPianYi = this._IRect.IRect_shuju_pianyi;

            //        #endregion

            //        #region  存储跟随定位的工具及同步显示
            //        _IRect.Tool_Path.Add(_tool_treeview_struct2.Current_Node_lujing);
            //        listBox_GenSuiGongJu.Items.Add(_tool_treeview_struct2.Current_Node_lujing);
            //        #endregion
            //        break;
            //    #endregion

            //    #region   二维码
            //    case "DataCode":

            //        #region   取出数据
            //        IDataCodeShuJu IDataCode = (DataCodeShuJu)_tool_treeview_struct2.Current_MultTreeNode.Obj;
            //        #endregion

            //        #region  算法
            //        IDataCode.GeuSuiDian_X_Col = _IRect.IRect_shuju_pianyi.Column;
            //        IDataCode.GenSuiDian_Y_Row = _IRect.IRect_shuju_pianyi.Row;
            //        IDataCode.GenSuiDian_A = _IRect.IRect_shuju_pianyi.Angle;

            //        IDataCode.IrectShuJuPianYi = _IRect.IRect_shuju_pianyi;
            //        #endregion

            //        #region   存储跟随定位的工具及同步显示
            //        _IRect.Tool_Path.Add(_tool_treeview_struct2.Current_Node_lujing);
            //        listBox_GenSuiGongJu.Items.Add(_tool_treeview_struct2.Current_Node_lujing);
            //        #endregion

            //        break;
            //    #endregion

            //    #region   ocv
            //    case "OCV":

            //        #region  取出数据
            //        IOCVShuJu IOCV_ = (OCVShuJu)_tool_treeview_struct2.Current_MultTreeNode.Obj;
            //        #endregion

            //        #region  算法
            //        IOCV_.GeuSuiDian_X_Col = _IRect.IRect_shuju_pianyi.Column;
            //        IOCV_.GenSuiDian_Y_Row = _IRect.IRect_shuju_pianyi.Row;
            //        IOCV_.GenSuiDian_A = _IRect.IRect_shuju_pianyi.Angle;

            //        IOCV_.IrectShuJuPianYi = _IRect.IRect_shuju_pianyi;
            //        #endregion

            //        #region   存储跟随定位的工具及同步显示
            //        _IRect.Tool_Path.Add(_tool_treeview_struct2.Current_Node_lujing);
            //        listBox_GenSuiGongJu.Items.Add(_tool_treeview_struct2.Current_Node_lujing);
            //        #endregion

            //        break;
            //    #endregion

            //    #region  默认
            //    default:
            //        MessageBox.Show("当前控件不能用于跟随定位");
            //        break;
            //    #endregion
            //}
            #endregion

        }
        #endregion

        #endregion

        #region    选择跟随定位的工具
        /// <summary>
        /// 选择跟随定位的工具
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void treeView2_AfterSelect(object sender, TreeViewEventArgs e)
        {
            TreeNode current_treenode = e.Node;
            if (e.Node.Text == "驱动1")
            {
                return;
            }//预防卡死

            treeView2.Enabled = false;//预防频率过高，卡死

            #region  取出节点数据
            _tool_treeview_struct2.Current_Nodes_Name = e.Node.Name;//记录当前选择节点的名称
            _tool_treeview_struct2.Current_Nodes_Text = e.Node.Text;

            MultTree.operationTreeViewTool.get_parent_node_path(ref current_treenode, ref _tool_treeview_struct2);
            //get_parent_node_path(ref current_treenode, ref _tool_treeview_struct2);
            #endregion

            treeView2.Enabled = true;//预防频率过高，卡死

            synchroinization_GenSuiDingWeiLieBian();
        }
        #endregion

        #region 同步跟随工具列表
        /// <summary>
        /// 同步跟随工具列表
        /// </summary>
        void synchroinization_GenSuiDingWeiLieBian()
        {
            if (this.listBox_GenSuiGongJu.Items.Contains(_tool_treeview_struct2.Current_Node_lujing))
            {
                this.listBox_GenSuiGongJu.SelectedIndex = this.listBox_GenSuiGongJu.Items.IndexOf(_tool_treeview_struct2.Current_Node_lujing);
            }
            else
            {
                this.listBox_GenSuiGongJu.ClearSelected();
            }
        }
        #endregion

        #region 移除跟随的工具
        private void bnt_delete_fallow_tool_Click(object sender, EventArgs e)
        {
            delete_fallow_tool();
        }

        #region  移除跟随定位的工具
        /// <summary>
        /// 移除跟随定位的工具
        /// </summary>
        void delete_fallow_tool()
        {
            #region   判断工具是否已经添加过
            if (!this.listBox_GenSuiGongJu.Items.Contains(_tool_treeview_struct2.Current_Node_lujing))
            {
                MessageBox.Show("工具没有添加跟随定位，移除不了请先添加");
                return;
            }
            #endregion

            #region    取出数据
            var toolDate_ = _tool_treeview_struct2.Current_MultTreeNode.Obj as ToolDateFather;
            #endregion

            if (toolDate_ != null)
            {
                #region   算法
                toolDate_.GeuSuiDian_X_Col = null;
                toolDate_.GenSuiDian_Y_Row = null;
                toolDate_.GenSuiDian_A = null;
                toolDate_.IrectShuJuPianYi = null;
                #endregion

                #region   移除存储的定位数据
                this.listBox_GenSuiGongJu.Items.Remove(_tool_treeview_struct2.Current_Node_lujing);
                this._IRect.Tool_Path.Remove(_tool_treeview_struct2.Current_Node_lujing);
                #endregion
            }

            #region  无用代码
            //string str1 = _tool_treeview_struct2.Current_Nodes_Name;
            ////IRectShuJu IRect_ = (RectShuJu)TreeStatic.Mult_Tree_Node.Obj;

            //switch (str1.Substring(0, str1.IndexOf("_")))
            //{
            //    #region  无用代码
            //    //#region  拟合圆
            //    //case "Circle":
            //    //    #region  取出数据
            //    //    ICircleShuJu ICircle_ = (CircleShuJu)_tool_treeview_struct2.Current_MultTreeNode.Obj;
            //    //    #endregion

            //    //    #region 算法
            //    //    ICircle_.Ihv_HomMat2D = _IRect;
            //    //    _IRect.Tool_Path.Add(_tool_treeview_struct2.Current_Node_lujing);
            //    //    listBox1.Items.Add(_tool_treeview_struct2.Current_Node_lujing);
            //    //    #endregion
            //    //    break;
            //    //#endregion

            //    //#region  拟合边
            //    //case "Line":
            //    //    #region  取出数据
            //    //    ILineShuJu ILine_ = (LineShuJu)_tool_treeview_struct2.Current_MultTreeNode.Obj;
            //    //    #endregion

            //    //    #region  算法
            //    //    ILine_.Ihv_HomMat2D = _IRect;
            //    //    _IRect.Tool_Path.Add(_tool_treeview_struct2.Current_Node_lujing);
            //    //    listBox1.Items.Add(_tool_treeview_struct2.Current_Node_lujing);
            //    //    #endregion
            //    //    break;
            //    //#endregion

            //    //#region  OCR
            //    //case "OCR":
            //    //    #region  取出数据
            //    //    IOCRShuJu IOCR_ = (OCRShuJu)_tool_treeview_struct2.Current_MultTreeNode.Obj;
            //    //    #endregion

            //    //    #region  算法
            //    //    IOCR_.Ihv_HomMat2D = _IRect;
            //    //    _IRect.Tool_Path.Add(_tool_treeview_struct2.Current_Node_lujing);
            //    //    listBox1.Items.Add(_tool_treeview_struct2.Current_Node_lujing);
            //    //    #endregion
            //    //    break;
            //    //#endregion

            //    //#region   OCV
            //    //case "OCV":
            //    //    #region  取出数据
            //    //    IOCVShuJu IOCV_ = (OCVShuJu)_tool_treeview_struct2.Current_MultTreeNode.Obj;
            //    //    #endregion

            //    //    #region  算法
            //    //    IOCV_.Ihv_HomMat2D = _IRect;
            //    //    _IRect.Tool_Path.Add(_tool_treeview_struct2.Current_Node_lujing);
            //    //    listBox1.Items.Add(_tool_treeview_struct2.Current_Node_lujing);
            //    //    #endregion
            //    //    break;
            //    //#endregion
            //    #endregion

            //    #region 背景检测
            //    case "BackGround":

            //        #region  取出数据
            //        IBackGroundShuJu IBack_ = (BackGroundShuJu)_tool_treeview_struct2.Current_MultTreeNode.Obj;
            //        #endregion

            //        #region   算法

            //        IBack_.GenSuiDian_A = null;
            //        IBack_.GeuSuiDian_X_Col = null;
            //        IBack_.GenSuiDian_Y_Row = null;

            //        IBack_.IrectShuJuPianYi = null;

            //        #endregion

            //        #region   移除存储的定位数据
            //        this.listBox_GenSuiGongJu.Items.Remove(_tool_treeview_struct2.Current_Node_lujing);
            //        this._IRect.Tool_Path.Remove(_tool_treeview_struct2.Current_Node_lujing);
            //        #endregion

            //        break;
            //    #endregion

            //    #region   一维码
            //    case "BarCode":

            //        #region   取出数据
            //        IBarCodeShuJu IBar_ = (BarCodeShuJu)_tool_treeview_struct2.Current_MultTreeNode.Obj;
            //        #endregion

            //        #region   算法

            //        IBar_.GenSuiDian_A = null;
            //        IBar_.GenSuiDian_Y_Row = null;
            //        IBar_.GeuSuiDian_X_Col = null;

            //        IBar_.IrectShuJuPianYi = null;

            //        #endregion

            //        #region   移除存储的定位数据
            //        this.listBox_GenSuiGongJu.Items.Remove(_tool_treeview_struct2.Current_Node_lujing);
            //        this._IRect.Tool_Path.Remove(_tool_treeview_struct2.Current_Node_lujing);
            //        #endregion

            //        break;
            //    #endregion

            //    #region  默认
            //    default:
            //        MessageBox.Show("当前控件不能用于跟随定位");
            //        break;
            //    #endregion
            //}
            #endregion

        }
        #endregion

        #endregion

        #region    移除跟被随定位的工具
        private void btn_delete_lotation_Click(object sender, EventArgs e)
        {
            yiChuBeiDingWeiDeGongJu();
        }

        #region  移除跟被随定位的工具
        /// <summary>
        /// 移除跟被随定位的工具
        /// </summary>
        void yiChuBeiDingWeiDeGongJu()
        {

            /**************清空数据*********************/
            this._IRect.BeiGenSuiDingWeiGongJu = null;
            this._IRect.IRect_shuju_pianyi = null;
            this._IRect.Yuan_dian_angle_a = null;
            this._IRect.Yuan_dian_col_x = null;
            this._IRect.Yuan_dian_row_y = null;

            /**************删除列表中的数据********************/
            this.listBox_DingWeiGongJu.Items.Clear();

        }
        #endregion

        #endregion
    }
}
