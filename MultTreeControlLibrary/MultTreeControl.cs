using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading;
using System.Collections;
using HalControl;
using CheckStreamLibrary;
using MultTree;
using MultTree.MultTreeNodeStruct;
using ReadImageHalconLibrary;
using System.Windows.Forms;
using MultTree.CalculateMultTreeNodeName;
using LogClassLibrary;
using BarCodeHalconLibrary;
using TemplateHalconLibrary;
using RectLibrary;
using CircleLibrary;
using CalibrationLibrary;
using DistancePointToLineLibrary;
using DistanceTwoLineLibrary;
using ZhuCeRuanJianLibrary;



namespace MultTreeControlLibrary
{
    /// <summary>
    /// 
    /// </summary>
    public partial class MultTreeControl : UserControl
    {
        #region 全局变量

        #region 树节点的数据
        /// <summary>
        /// 当前选择节点的信息
        /// </summary>
        MultTreeControlLibrary.tool_treeview_struct _tool_treeview_struct;
        #endregion

        #region 检测逻辑的参数
        /// <summary>
        /// 检测逻辑的路径
        /// </summary>
        string _Detection_path = null;
        #endregion

        #region  运行的check
        /// <summary>
        /// 检测流
        /// </summary>
        CheckStreamLibrary.ICheckStream _ICheckStr;

        /// <summary>
        /// 检测流
        /// </summary>
        public CheckStreamLibrary.ICheckStream ICheckStr1
        {
            get { return _ICheckStr; }
            set { _ICheckStr = value; }
        }
        #endregion

        #region  当前状态
        /// <summary>
        /// 当前状态
        /// </summary>
        public run_way _RunWay;
        #endregion

        #region  无用代码
        #region  取图工具
        /// <summary>
        /// 取图工具
        /// </summary>
        //IReadImage _IRead = new ReadImageHalconLibrary.ReadImage();
        #endregion
        #endregion

        #endregion

        #region  构造函数
        public MultTreeControl()
        {
            InitializeComponent();
        }
        #endregion

        #region   初始化
        /**全局变量数据初始值一定要写在初始化函数里面，不然在使用控件时，会报错，主要是在初始化时，系统先编译，编译不成功导致出错**/
        /// <summary>
        /// 初始化
        /// </summary>
        /// <returns></returns>
        public bool init(HalControl.HalconWinControl_1 Hwin)
        {

            bool ok = false;
            _RunWay = run_way.stop;
            _tool_treeview_struct = new MultTreeControlLibrary.tool_treeview_struct();
            _ICheckStr = new CheckStreamLibrary.CheckStream();

            _ICheckStr.CheckStream_Init(Hwin);/*初始化流*/
            _ICheckStr._Resulte1 += CheckStream_CallBack;
            but_add_detection_Click(null, null);

            if (ZhuCeRuanJianLibrary.CheckRuanJianShiBuShiZhuCe.CheckShiFoZhuCe())
            {
                ok = true;
            }            
          
            return ok;
        }
        #endregion

        #region 新建初始化一个检测
        /// <summary>
        /// 新建一个检测
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void but_add_detection_Click(object sender, EventArgs e)
        {
            if (tool_treeView.Nodes != null)
            {
                tool_treeView.Nodes.Clear();
            }/*清空树*/

            create_delection();

            TreeNode tr_0;
            tr_0 = new TreeNode();
            tr_0.Text = "驱动1";
            tr_0.Name = "System_1"; //新建一个驱动

            #region   无用的代码
            #region   无用代码
            //TreeNode tr_1 = new TreeNode();
            //tr_1.Text = "图像检测";
            //tr_1.Name = "detection_1";//新建一个检测
            #endregion

            //MultTreeNode m_tr_1 = new MultTreeNode();
            //m_tr_1.setNodeName("图像检测");
            //m_tr_1.setSelfId("detection_1");

            #region   无用代码
            //TreeNode tr_2 = new TreeNode();        
            //tr_2.Text = "取图";
            //tr_2.Name = "acquire_1";//新建一个取图
            //ShuJu.ReadShuJu reshuju = new ShuJu.ReadShuJu();
            //tr_2.Tag = reshuju;//写入数据结构
            #endregion

            //ShuJu.ReadShuJu reshuju = new ShuJu.ReadShuJu();
            //MultTreeNode m_tr_2 = new MultTreeNode();
            //m_tr_2.setNodeName("取图");
            //m_tr_2.setSelfId("acquire_1");
            //m_tr_2.setObj(reshuju);

            #region  无用代码
            //tr_1.Nodes.Add(tr_2);//添加一个取图
            //tr_0.Nodes.Add(tr_1);//添加一个检测
            #endregion

            //  m_tr_1.InsertChildNode(m_tr_2);

            //if (TreeStatic.get_Root().getChildNodeCount() != 0)
            //{
            //    TreeStatic.get_Root().deleteClearAll();
            //}//清空树
            //  TreeStatic.get_Root().InsertChildNode(m_tr_1);
            #region 无用代码
            //  checkTreeNode(tr_0, TreeStatic.get_Root());
            #endregion


            #endregion

            _ICheckStr.Check_Root = MultTreeControlLibrary.Select_MultTreeCheckStream.Select_CheckFristNodeStream();

            //TreeStatic.load_MultTreeNode_To_TreeNode(tr_0, _ICheckStr.Check_Root);

            TreeStatic.load_MultTreeNode_To_TreeNode_ContainsSelf(tr_0, _ICheckStr.Check_Root);

            tool_treeView.Nodes.Add(tr_0);//添加一个检测
            tool_treeView.ExpandAll();

            Refresh_Delection();
        }

        #region  清空所有节点，新建一个检测，跟取图工具
        /// <summary>
        ///  清空所有节点，新建一个检测，跟取图工具
        /// </summary>
        /// <returns></returns>
        public static bool create_delection()
        {
            bool ok = false;

            MultTreeNode m_tr_1 = new MultTreeNode();
            //m_tr_1.setNodeName("图像检测");
            //m_tr_1.setSelfId("detection_1");
            m_tr_1.NodeName = "图像检测";
            m_tr_1.SelfId = "detection_1";

            ReadShuJu reshuju = new ReadShuJu();
            MultTreeNode m_tr_2 = new MultTreeNode();
            //m_tr_2.setNodeName("取图");
            //m_tr_2.setSelfId("acquire_1");
            //m_tr_2.setObj(reshuju);

            m_tr_2.NodeName = "取图";
            m_tr_2.SelfId = "acquire_1";
            m_tr_2.Obj = reshuju;

            m_tr_1.InsertChildNode(m_tr_2);

            if (TreeStatic.Root.getChildNodeCount() != 0)
            {
                TreeStatic.Root.deleteClearAll();
            }//清空树

            TreeStatic.Root.InsertChildNode(m_tr_1);


            ok = true;
            return ok;
        }
        #endregion

        #endregion

        #region 加载一个检测
        private void but_load_detection_Click(object sender, EventArgs e)
        {
            OpenFileDialog open_file = new OpenFileDialog();
            open_file.Filter = "det files (*.det)|*det";
            open_file.FilterIndex = 1;
            open_file.RestoreDirectory = true;
            open_file.Multiselect = true;
            //open_file.ShowDialog();//打开对话框 

            if (open_file.ShowDialog() == DialogResult.OK)
            {
                if (tool_treeView.Nodes != null)
                {
                    tool_treeView.Nodes.Clear();
                }
                string path = open_file.FileName;

                TreeNode tr_0;

                load_detection(path, out tr_0);

                _Detection_path = path;

                tool_treeView.Nodes.Add(tr_0);//添加一个检测
                tool_treeView.ExpandAll();

                Refresh_Delection();

            }
        }

        #region  加载一个detection
        /// <summary>
        /// 加载一个detection
        /// </summary>
        /// <param name="path"></param>
        /// <param name="tr_0"></param>
        /// <returns></returns>
        bool load_detection(string path, out  TreeNode tr_0)
        {
            bool ok = false;
            tr_0 = new TreeNode();
            tr_0.Text = "驱动1";
            tr_0.Name = "System_1"; //新建一个驱动

            //  TreeStatic.load_MultTreeNode(path);
            CheckStreamLibrary.MultTreeStaticSave.LoadTreeStatic(ref path);

            _ICheckStr.Check_Root = MultTreeControlLibrary.Select_MultTreeCheckStream.Select_CheckFristNodeStream();

            TreeStatic.load_MultTreeNode_To_TreeNode_ContainsSelf(tr_0, _ICheckStr.Check_Root);

            //TreeStatic.load_MultTreeNode_To_TreeNode(tr_0, TreeStatic.Root);

            ok = true;
            return ok;
        }
        #endregion

        #endregion

        #region 另保存检测逻辑
        private void bnt_anthor_save_detection_Click(object sender, EventArgs e)
        {
            SaveFileDialog savfile = new SaveFileDialog();
            savfile.Filter = "det files(*.det)|*.det";
            savfile.FilterIndex = 1;
            if (savfile.ShowDialog() == DialogResult.OK)
            {
                _Detection_path = savfile.FileName;

                #region 无用代码
                // di_gui_save();//递归保存数据
                //SerializeTree.TreeViewDataAccess.SaveTreeViewData(_Detection_path);
                //TreeStatic.save_MultTreeNode(_Detection_path);
                #endregion

                //  CheckStreamLibrary.MultTreeStaticSave.LoadTreeStatic(ref _Detection_path);
                CheckStreamLibrary.MultTreeStaticSave.SaveTreeStatic(ref _Detection_path);
            }
        }
        #endregion

        #region 保存检测逻辑
        private void bnt_save_detection_Click(object sender, EventArgs e)
        {
            #region   序列化数据
            if (_Detection_path == null)
            {
                bnt_anthor_save_detection_Click(null, null);//路径为空触发另保存事件
                return;
            }
            if (System.IO.File.Exists(_Detection_path))
            {
                //TreeStatic.save_MultTreeNode(_Detection_path);
                CheckStreamLibrary.MultTreeStaticSave.SaveTreeStatic(ref _Detection_path);
            }
            else
            {
                bnt_anthor_save_detection_Click(null, null);//路径为空触发另保存事件
            }
            #endregion
        }
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
            if(e.Node.Text == "驱动1")
            {
                return;
            }//预防卡死
            tool_treeView.Enabled = false;//预防频率过高，卡死
            #region  取出节点数据
            _tool_treeview_struct.Current_Nodes_Name = e.Node.Name;//记录当前选择节点的名称
            _tool_treeview_struct.Current_Nodes_Text = e.Node.Text;
            get_parent_node_path(ref current_treenode, ref _tool_treeview_struct);
            #endregion

            #region   显示单个工具的结果

            IToolDateFather iToolDate_ = _tool_treeview_struct.Current_MultTreeNode.Obj as ToolDateFather;

            if (iToolDate_ != null)
            {
                string[] result_;
                iToolDate_.outResult(out result_);
                this.listBox2.Items.Clear();
                foreach (string str in result_)
                {
                    this.listBox2.Items.Add(str);
                }
            }
            #endregion

            tool_treeView.Enabled = true;//预防频率过高，卡死
        }

        #region  获取父节点路径
        /// <summary>
        /// 获取父节点路径
        /// </summary>
        /// <param name="current_treenode"></param>
        /// <param name="_tool_treeview_struct"></param>
        static void get_parent_node_path(ref  TreeNode current_treenode, ref  MultTreeControlLibrary.tool_treeview_struct _tool_treeview_struct)
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
            TreeStatic.Mult_Tree_Node = mu;
            _tool_treeview_struct.Current_MultTreeNode = mu;

            #region 判断是不是取图节点
            if (mu.SelfId.Contains("acquire"))
            {
                //  MachineVision.ShuJuJieGou.TreeStatic.Mult_Tree_Node_Picture = mu;
                TreeStatic.Mult_Tree_Node_Picture = mu;
            }
            #endregion
        }
        #endregion

        #endregion

        #region   显示调试界面
        private void tool_treeView_DoubleClick(object sender, EventArgs e)
        {
            show_dubug();
        }

        /// <summary>
        /// 显示界面
        /// </summary>
        void show_dubug()
        {
            string str_name = _tool_treeview_struct.Current_Nodes_Name;

            if (str_name == null)//防止卡死
            {
                return;
            }

            str_name = str_name.Substring(0, str_name.IndexOf("_"));//当前节点的名称    
            switch (str_name)
            {
                #region  取图工具
                case "acquire":

                    ReadImageHalconLibrary.UI.AcqurieFrm acq = new ReadImageHalconLibrary.UI.AcqurieFrm();
                    // acq._re =(ShuJu.ReadShuJu) tool_treeView.SelectedNode.Tag;
                    acq.ShowDialog();
                    //  tool_treeView.SelectedNode.Tag = acq._re;
                    acq.Close();
                    break;

                #endregion

                #region  模板匹配
                case "Template":

                    TemplateHalconLibrary.UI.TemplateFrm te = new TemplateHalconLibrary.UI.TemplateFrm();
                    te.ShowDialog();
                    te.Close();
                    break;

                #endregion

                #region 拟合圆
                case "Circle":

                    CircleLibrary.UI.CircleFrm ci = new CircleLibrary.UI.CircleFrm();
                    // ci._circleshuju = (MachineVision.Interface.ICircleShuJu)tool_treeView.SelectedNode.Tag;
                    ci.ShowDialog();
                    // tool_treeView.SelectedNode.Tag = ci._circleshuju;
                    ci.Close();
                    break;

                #endregion

                #region  拟合直线
                case "Line":


                    LineLibrary.UI.LineFrm Li = new LineLibrary.UI.LineFrm();
                    Li.ShowDialog();
                    Li.Close();

                    break;

                #endregion

                #region  防射变化
                case "Rect":
                    RectLibrary.UI.RectFrm rect = new RectLibrary.UI.RectFrm(ICheckStr1);
                    //  rect._shuju = (RectHalcon.ShuJu.ShuJuRect)tool_treeView.SelectedNode.Tag;
                    //rect._tr = new TreeView.TreeView();
                    //rect._tr._TreeNode = tool_treeView.Nodes[0];
                    // rect.tianjiashu();
                    rect.ShowDialog();
                    rect.Close();
                    break;

                #endregion

                #region  标定
                case "Calibration":

                    CalibrationLibrary.UI.CalibrationFrm Calfrm = new CalibrationLibrary.UI.CalibrationFrm(ICheckStr1);
                    Calfrm.ShowDialog();
                    Calfrm.Close();
                    break;
                #endregion

                #region  一维码
                case "BarCode":

                    BarCodeHalconLibrary.UI.CodeBarFrm co = new BarCodeHalconLibrary.UI.CodeBarFrm();
                    // ci._circleshuju = (MachineVision.Interface.ICircleShuJu)tool_treeView.SelectedNode.Tag;
                    co.ShowDialog();
                    // tool_treeView.SelectedNode.Tag = ci._circleshuju;
                    co.Close();
                    break;

                #endregion

                #region  二维码
                case "DataCode":

                    DataCodeLibrary.UI.DataCodeFrm da = new DataCodeLibrary.UI.DataCodeFrm();
                    da.ShowDialog();
                    da.Close();
                    break;
                #endregion

                #region ocr
                case "OCR":

                    OCRLibrary.UI.OCRFrm ocr = new OCRLibrary.UI.OCRFrm();
                    ocr.ShowDialog();
                    ocr.Close();
                    break;
                #endregion

                #region   ocv
                case "OCV":

                    OCVLibrary.UI.OCVFrm ocv = new OCVLibrary.UI.OCVFrm();
                    ocv.ShowDialog();
                    ocv.Close();
                    break;
                #endregion

                #region     背景检测
                case "BackGround":

                    BackGroundCheckHalconLibrary.UI.BackGroundFrm backGround_ = new BackGroundCheckHalconLibrary.UI.BackGroundFrm();
                    backGround_.ShowDialog();
                    backGround_.Close();
                    break;
                #endregion

                #region  两点的距离
                case "DistanceTwoPoint":

                    DistanceTwoPointLibrary.UI.DistanceTwoPointFrm distanceTwo_ = new DistanceTwoPointLibrary.UI.DistanceTwoPointFrm(ICheckStr1);
                    distanceTwo_.ShowDialog();
                    distanceTwo_.Close();
                    break;
                #endregion

                #region   点到线的距离
                case "DistancePointToLine":

                    DistancePointToLineLibrary.UI.DistancePointToLineFrm distanceToPointLine_ = new DistancePointToLineLibrary.UI.DistancePointToLineFrm(ICheckStr1);
                    distanceToPointLine_.ShowDialog();
                    distanceToPointLine_.Close();
                    break;
                #endregion

                #region   两线的交点
                case "DistanceTwoLine":
                    DistanceTwoLineLibrary.UI.DistanceTwoLineFrm distanceTwoLine = new DistanceTwoLineLibrary.UI.DistanceTwoLineFrm(ICheckStr1);
                    distanceTwoLine.ShowDialog();
                    distanceTwoLine.Close();
                    break;
                #endregion

                #region   斑点
                case"Blob":
                    BlobLibrary.UI.BlobFrm blob_ = new BlobLibrary.UI.BlobFrm();
                    blob_.ShowDialog();
                    blob_.Close();
                    break;
                #endregion

                #region ocr文本   
                case  "OCRWenBen":
                    OCRTextLibrary.UI.OCRTextFrm OCRText = new OCRTextLibrary.UI.OCRTextFrm();
                    OCRText.ShowDialog();
                    OCRText.Close();
                    break;
                #endregion

            }
        }
        #endregion

        #region  单步运行
        private void tSB_run_again_check_stream_Click(object sender, EventArgs e)
        {
            string str = tSB_run_again_check_stream.Text;
            if (str == "单步运行")
            {
                tSB_run_again_check_stream.Text = "检测。。";
                _RunWay = run_way.check_stream_again_run;
                DanBuYunXingPingKongJian();

                Thread thr = new Thread(new ThreadStart(() =>
                {
                    _ICheckStr.trigger_check();
                }));
                thr.Start();
            }
            else
            {
                tSB_run_again_check_stream.Text = "单步运行";
                _RunWay = run_way.stop;
                DanBuYunXingKaiFangKongJian();
            }
        }
        #endregion

        #region  循环运行
        private void tSB_run_circulation_check_stream_Click(object sender, EventArgs e)
        {
            string str = tSB_run_circulation_check_stream.Text;
            if (str == "循环运行")
            {
                tSB_run_circulation_check_stream.Text = "循环。。";
                _RunWay = run_way.check_stream_circulation;

                XunHuanYunXingPingBiKongJian();

                Thread thr = new Thread(new ThreadStart(() =>
                {
                    _ICheckStr.trigger_check();
                }));
                thr.Start();
            }
            else
            {
                tSB_run_circulation_check_stream.Text = "循环运行";
                _RunWay = run_way.stop;
                XunHuanYunXingPingKongJian();
            }

        }
        #endregion

        #region  取一张图片
        private void tSB_read_one_image_Click(object sender, EventArgs e)
        {
            if (TreeStatic.Mult_Tree_Node_Picture == null)
            {
                MessageBox.Show("没有选择哪个取图工具，请选择一下");
                return;
            }

            IReadShuJu IREADSHUJU = (IReadShuJu)TreeStatic.Mult_Tree_Node_Picture.Obj;

            //_ICheckStr.IRead.read_Image(IREADSHUJU);
            Dictionary<string, Object> dis_ = new Dictionary<string, object>();
            IREADSHUJU.analyze_show(_ICheckStr.HalconWinControl_11.HalconWindow1, "1", ref dis_);
            _ICheckStr.HalconWinControl_11.Ho_Image = IREADSHUJU.Ho_image;
        }
        #endregion

        #region 跟前添加工具
        private void 跟前添加工具_Click(object sender, EventArgs e)
        {
            #region  无用代码
            //try
            //{
            //    AddToolFrm addtoolfrm = new AddToolFrm(_tool_treeview_struct);
            //    addtoolfrm._insert_direction = "跟前添加工具";
            //    addtoolfrm._hwin = halconWinControl_11.HalconWindow1;
            //    if (addtoolfrm.ShowDialog() == DialogResult.OK)
            //    {
            //        string name = addtoolfrm._insert_tool, text = addtoolfrm._tool_text;
            //      //  int i = tool_treeView.SelectedNode.Index;

            //        name = SerializeTree.CalculateTreeNode.NodeAdd.CalculateNodeName(name, tool_treeView.SelectedNode.Parent);

            //        MultTreeNode mu = new MultTreeNode();
            //        mu.SelfId = name;
            //        mu.NodeName = text;



            //        mu.Obj= addtoolfrm._tag;


            //        TreeStatic.Mult_Tree_Node.InsertNodeBefore(mu);

            //        //TreeNode tmp = new TreeNode(text);
            //        //tmp.Name = name;
            //        //tmp.Tag = addtoolfrm._tag;
            //        //tool_treeView.SelectedNode.Nodes.Add(tmp);

            //        TreeNode tr_0 = new TreeNode();
            //        tr_0.Text = "驱动1";
            //        tr_0.Name = "System_1"; //新建一个驱动

            //        if (tool_treeView.Nodes != null)
            //        {
            //            tool_treeView.Nodes.Clear();
            //        }//清空树

            //       // checkTreeNode(tr_0, TreeStatic.get_Root());

            //        TreeStatic.load_MultTreeNode_To_TreeNode(tr_0, TreeStatic.get_Root());
            //        tool_treeView.Nodes.Add(tr_0);
            //        tool_treeView.ExpandAll();

            //        addtoolfrm.Close();

            //        //TreeNode tree = new TreeNode(text);
            //        //tree.Name = name;
            //        //tree.Tag = addtoolfrm._tag;
            //        //tool_treeView.SelectedNode.Parent.Nodes.Insert(i, tree);

            //    }
            //}
            //catch
            //{
            //    SerializeTree.Log.LogManager.WriteLog(SerializeTree.Log.LogFile.Error, "跟前节点添加出错");
            //    throw new Exception("跟前节点添加出错");
            //}
            #endregion
            add_tool("跟前添加工具");
        }
        #endregion

        #region 跟后添加工具
        private void 跟后添加工具_Click(object sender, EventArgs e)
        {
            #region   无用代码
            //try
            //{
            //    AddToolFrm addtoolfrm = new AddToolFrm(_tool_treeview_struct);
            //    addtoolfrm._insert_direction = "跟后添加工具";
            //    addtoolfrm._hwin = halconWinControl_11.HalconWindow1;
            //    if (addtoolfrm.ShowDialog() == DialogResult.OK)
            //    {
            //        string name = addtoolfrm._insert_tool, text = addtoolfrm._tool_text;
            //        int i = tool_treeView.SelectedNode.Index;

            //        name = SerializeTree.CalculateTreeNode.NodeAdd.CalculateNodeName(name, tool_treeView.SelectedNode.Parent);

            //        MultTreeNode mu = new MultTreeNode();
            //        mu.SelfId = name;
            //        mu.NodeName = text;
            //        mu.Obj = addtoolfrm._tag;


            //        TreeStatic.Mult_Tree_Node.InsertNodeAfter(mu);


            //        TreeNode tr_0 = new TreeNode();
            //        tr_0.Text = "驱动1";
            //        tr_0.Name = "System_1"; //新建一个驱动

            //        if (tool_treeView.Nodes != null)
            //        {
            //            tool_treeView.Nodes.Clear();
            //        }//清空树

            //        // checkTreeNode(tr_0, TreeStatic.get_Root());
            //        TreeStatic.load_MultTreeNode_To_TreeNode(tr_0, TreeStatic.get_Root());

            //        tool_treeView.Nodes.Add(tr_0);
            //        tool_treeView.ExpandAll();

            //        addtoolfrm.Close();


            //    }
            //}
            //catch
            //{
            //    SerializeTree.Log.LogManager.WriteLog(SerializeTree.Log.LogFile.Error, "跟后节点添加出错");
            //    throw new Exception("跟后节点添加出错");
            //}
            #endregion
            add_tool("跟后添加工具");
        }
        #endregion

        #region 插入工具
        private void 插入工具_Click(object sender, EventArgs e)
        {
            #region  无用代码
            //try
            //{
            //    AddToolFrm addtoolfrm = new AddToolFrm(_tool_treeview_struct);
            //    addtoolfrm._insert_direction = "插入工具";
            //    addtoolfrm._hwin = halconWinControl_11.HalconWindow1;
            //    if (addtoolfrm.ShowDialog() == DialogResult.OK)
            //    {
            //        string name = addtoolfrm._insert_tool, text = addtoolfrm._tool_text;
            //        MultTreeNode mu = new MultTreeNode();
            //        mu.setNodeName(text);

            //        switch (name)
            //        {
            //            case "BarCode":
            //                name = SerializeTree.CalculateTreeNode.NodeAdd.CalculateNodeName(name, tool_treeView.SelectedNode);
            //                BarCodeHalcon.BarCodeShuJu.BarCodeShuJu ba = (BarCodeHalcon.BarCodeShuJu.BarCodeShuJu)addtoolfrm._tag;
            //                ba.Bar_code_name = name;
            //                mu.setSelfId(name);
            //                mu.setObj(ba);
            //                break;

            //                default :
            //                name = SerializeTree.CalculateTreeNode.NodeAdd.CalculateNodeName(name, tool_treeView.SelectedNode);
            //                mu.setSelfId(name);
            //                mu.setObj(addtoolfrm._tag);

            //                break;                                
            //        }


            //        TreeStatic.Mult_Tree_Node.InsertChildNode(mu);

            //        //TreeNode tmp = new TreeNode(text);
            //        //tmp.Name = name;
            //        //tmp.Tag = addtoolfrm._tag;
            //        //tool_treeView.SelectedNode.Nodes.Add(tmp);

            //        TreeNode tr_0 = new TreeNode();
            //        tr_0.Text = "驱动1";
            //        tr_0.Name = "System_1"; //新建一个驱动

            //        if (tool_treeView.Nodes != null)
            //        {
            //            tool_treeView.Nodes.Clear();
            //        }//清空树
            //         //  checkTreeNode(tr_0, TreeStatic.get_Root());

            //        TreeStatic.load_MultTreeNode_To_TreeNode(tr_0, TreeStatic.get_Root());

            //        tool_treeView.Nodes.Add(tr_0);
            //        tool_treeView.ExpandAll();

            //        addtoolfrm.Close();
            //    }
            //}
            //catch
            //{
            //    SerializeTree.Log.LogManager.WriteLog(SerializeTree.Log.LogFile.Error, "插入工具出错");
            //    throw new Exception("插入工具出错");
            //}
            #endregion
            add_tool("插入工具");
        }
        #endregion

        #region 添加工具
        /// <summary>
        /// 添加工具
        /// </summary>
        /// <param name="add_way">传入添加工具的格式</param>
        /// <returns></returns>
        public bool add_tool(string add_way)
        {
            bool ok = false;

            if (MultTree.TreeStatic.Mult_Tree_Node_Picture == null)
            {
                return ok;
            }

            switch (add_way)
            {
                #region 插入工具
                case "插入工具":

                    try
                    {
                        AddToolFrm addtoolfrm = new AddToolFrm(_tool_treeview_struct);
                        addtoolfrm._insert_direction = "插入工具";
                        // addtoolfrm._hwin = halconWinControl_11.HalconWindow1;
                        if (addtoolfrm.ShowDialog() == DialogResult.OK)
                        {
                            string name = addtoolfrm._insert_tool, toolName = addtoolfrm._insert_tool, text = addtoolfrm._tool_text;
                            name = MultTree.CalculateMultTreeNodeName.CalculateMultTreeNodeName.CalculateNodeName(name, _tool_treeview_struct.Current_MultTreeNode);
                            MultTreeNode mu = new MultTreeNode();

                            mu.NodeName = text;
                            Add_tool_set_name(toolName, name, ref mu, addtoolfrm._tag);

                            TreeStatic.Mult_Tree_Node.InsertChildNode(mu);
                            addtoolfrm.Close();
                        }
                    }
                    catch
                    {
                        // SerializeTree.Log.LogManager.WriteLog(SerializeTree.Log.LogFile.Error, "插入工具出错");
                        LogManager.WriteLog(LogFile.Error, "插入工具出错");
                        throw new Exception("插入工具出错");
                    }


                    break;
                #endregion

                #region   跟前添加工具
                case "跟前添加工具":

                    try
                    {
                        AddToolFrm addtoolfrm = new AddToolFrm(_tool_treeview_struct);
                        addtoolfrm._insert_direction = "跟前添加工具";
                        //  addtoolfrm._hwin = halconWinControl_11.HalconWindow1;
                        if (addtoolfrm.ShowDialog() == DialogResult.OK)
                        {
                            string name = addtoolfrm._insert_tool, toolName = addtoolfrm._insert_tool, text = addtoolfrm._tool_text;

                            name = MultTree.CalculateMultTreeNodeName.CalculateMultTreeNodeName.CalculateNodeName(name, _tool_treeview_struct.Current_MultTreeNode.ParentNode);

                            MultTreeNode mu = new MultTreeNode();
                            mu.NodeName = text;
                            Add_tool_set_name(toolName, name, ref mu, addtoolfrm._tag);
                            TreeStatic.Mult_Tree_Node.InsertNodeBefore(mu);
                            addtoolfrm.Close();
                        }
                    }
                    catch
                    {
                        LogManager.WriteLog(LogFile.Error, "跟前节点添加出错");
                        throw new Exception("跟前节点添加出错");
                    }

                    break;
                #endregion

                #region   跟后添加工具
                case "跟后添加工具":
                    try
                    {
                        AddToolFrm addtoolfrm = new AddToolFrm(_tool_treeview_struct);
                        addtoolfrm._insert_direction = "跟后添加工具";
                        // addtoolfrm._hwin = halconWinControl_11.HalconWindow1;
                        if (addtoolfrm.ShowDialog() == DialogResult.OK)
                        {
                            string name = addtoolfrm._insert_tool, toolName = addtoolfrm._insert_tool, text = addtoolfrm._tool_text;

                            //  int i = tool_treeView.SelectedNode.Index;

                            //name = SerializeTree.CalculateTreeNode.NodeAdd.CalculateNodeName(name, tool_treeView.SelectedNode.Parent);

                            name = MultTree.CalculateMultTreeNodeName.CalculateMultTreeNodeName.CalculateNodeName(name, _tool_treeview_struct.Current_MultTreeNode.ParentNode);
                            MultTreeNode mu = new MultTreeNode();
                            mu.NodeName = text;

                            Add_tool_set_name(toolName, name, ref mu, addtoolfrm._tag);
                            //mu.SelfId = name;
                            //mu.Obj = addtoolfrm._tag;
                            TreeStatic.Mult_Tree_Node.InsertNodeAfter(mu);

                            #region   无用代码
                            //TreeNode tr_0 = new TreeNode();
                            //tr_0.Text = "驱动1";
                            //tr_0.Name = "System_1"; //新建一个驱动

                            //if (tool_treeView.Nodes != null)
                            //{
                            //    tool_treeView.Nodes.Clear();
                            //}//清空树

                            //// checkTreeNode(tr_0, TreeStatic.get_Root());
                            //TreeStatic.load_MultTreeNode_To_TreeNode(tr_0, TreeStatic.get_Root());

                            //tool_treeView.Nodes.Add(tr_0);
                            //tool_treeView.ExpandAll();

                            #endregion

                            addtoolfrm.Close();
                        }
                    }
                    catch
                    {
                        LogManager.WriteLog(LogFile.Error, "跟后节点添加出错");
                        throw new Exception("跟后节点添加出错");
                    }

                    break;
                #endregion

                #region 默认处理
                default:


                    break;
                #endregion
            }

            #region  无用代码
            #region   刷新treeview
            //TreeNode tr_0 = new TreeNode();
            //tr_0.Text = "驱动1";
            //tr_0.Name = "System_1"; //新建一个驱动

            //if (tool_treeView.Nodes != null)
            //{
            //    tool_treeView.Nodes.Clear();
            //}//清空树

            ////  TreeStatic.load_MultTreeNode_To_TreeNode(tr_0, TreeStatic.Root);

            //TreeStatic.load_MultTreeNode_To_TreeNode_ContainsSelf(tr_0, _ICheckStr.Check_Root);

            //tool_treeView.Nodes.Add(tr_0);
            //tool_treeView.ExpandAll();
            #endregion
            #endregion

            Refresh_TreeViewAndMultTree();

            ok = true;
            return ok;
        }
        #endregion

        #region   添加工具需要检测工具是否要设置名称
        /// <summary>
        /// 添加工具需要检测工具是否要设置名称
        /// </summary>
        /// <param name="toolName">添加那种工具</param>
        /// <param name="name">工具的名称</param>
        /// <param name="mu"></param>
        /// <param name="tag">数据</param>
        /// <returns></returns>
        bool Add_tool_set_name(string toolName, string name, ref MultTreeNode mu, Object tag)
        {
            bool ok = false;
            #region  无用代码
            //switch (toolName)
            //{
            //    #region   BarCode工具需要设置名称
            //    case "BarCode":
            //        // toolName = SerializeTree.CalculateTreeNode.NodeAdd.CalculateNodeName(toolName, tool_treeView.SelectedNode);
            //      //  BarCodeHalcon.BarCodeShuJu.BarCodeShuJu ba = (BarCodeHalcon.BarCodeShuJu.BarCodeShuJu)tag;
            //        // ba.Bar_code_name = name;
            //        mu.setSelfId(name);
            //        mu.setObj(ba);
            //        break;
            //    #endregion

            //    #region   OCR工具
            //    //OCRHalcon.OCRShuJu.OCRShuJu ocr=()

            //    #endregion

            //    #region  默认添加工具
            //    default:
            //        //  toolName = SerializeTree.CalculateTreeNode.NodeAdd.CalculateNodeName(toolName, tool_treeView.SelectedNode);
            #endregion
            //mu.setSelfId(name);
            //mu.setObj(tag);

            mu.SelfId = name;
            mu.Obj = tag;

            #region  无用代码
            //        break;
            //    #endregion
            //}
            #endregion
            ok = true;
            return ok;
        }
        #endregion

        #region  删除工具
        private void 删除工具_Click(object sender, EventArgs e)
        {
            #region  无用代码
            //IMultTreeNode parent = TreeStatic.Mult_Tree_Node.getParentNode();
            //string id = TreeStatic.Mult_Tree_Node.SelfId;
            //int childnum = parent.ChildList.Count;
            //bool go = true;
            //for (int i = 0; (i < (childnum)) && (go == true); i++)
            //{
            //    string child = parent.ChildList[i].SelfId;
            //    if (child == id)
            //    {
            //        TreeStatic.Mult_Tree_Node = null;
            //        parent.ChildList.RemoveAt(i);
            //        go = false;
            //    }
            //}
            #endregion

            if ((_tool_treeview_struct.Current_Nodes_Text != "驱动1") && (_tool_treeview_struct.Current_Nodes_Text != "图像检测") && (_tool_treeview_struct.Current_Nodes_Text != "取图"))
            {
                MultTree.IToolDateFather itoolDate = (MultTree.IToolDateFather)_tool_treeview_struct.Current_MultTreeNode.Obj;
                itoolDate.Dispose();
               
                _tool_treeview_struct.Current_MultTreeNode.deleteNode();
                TreeNode node = tool_treeView.SelectedNode;
                tool_treeView.Nodes.Remove(node);

                Refresh_TreeViewAndMultTree();
            }
        }
        #endregion

        #region   检测完后回调
        /// <summary>
        /// 检测流回调
        /// </summary>
        /// <param name="result">回调的结果</param>
        void CheckStream_CallBack(object sender, CheckStreamEventArgs e)
        {
            Invoke(new Action(delegate
           {
               #region 显示处理时间

               tSB_time.Text = _ICheckStr.Milliseconds.ToString();

               #endregion

               #region   显示工具的对错
               //Invoke(new Action(delegate
               //{
               if (e.AllResult)
               {
                   tool_treeView.Nodes["System_1"].ImageIndex = 1;
                   //tool_treeView.Nodes["System_1"].Nodes["detection_1"].ImageIndex = 1;
                   tool_treeView.Nodes["System_1"].Nodes[0].ImageIndex = 1;
               }
               else
               {
                   tool_treeView.Nodes["System_1"].ImageIndex = 2;
                   //tool_treeView.Nodes["System_1"].Nodes["detection_1"].ImageIndex = 2;
                   tool_treeView.Nodes["System_1"].Nodes[0].ImageIndex = 2;
               }

               TreeNode tnCurrent, tnCurrentPar;

               tnCurrentPar = tool_treeView.Nodes["System_1"].Nodes[0];
               tnCurrent = tnCurrentPar.FirstNode;

               int num = e._dictionary_resulte.Count;
               int i = 0;

               ArrayList ar_list = new ArrayList();
               Dictionary<string, object>.KeyCollection keyCol = e._dictionary_resulte.Keys;

               foreach (string str1 in keyCol)
               {
                   ar_list.Add(str1);
               }

               while (num > 0)
               {
                   var n = e._dictionary_resulte[ar_list[i].ToString()];
                   MultTree.ClassResultFather resultFat = (MultTree.ClassResultFather)n;
                   if (resultFat._tolatResult)//显示对错
                   {
                       tnCurrent.ImageIndex = 1;
                   }
                   else
                   {
                       tnCurrent.ImageIndex = 2;
                   }

                   i++;
                   num--;

                   if (num > 0)
                   {
                       if (tnCurrent.Index + 2 > tnCurrentPar.Nodes.Count)//确定下一个节点
                       {
                           tnCurrentPar = tnCurrent;
                           tnCurrent = tnCurrentPar.FirstNode;
                       }
                       else
                       {
                           tnCurrent = tnCurrent.NextNode;
                       }
                   }
               }
               #endregion

               #region  显示数据
               CheckShuJuResultTool Ch = new CheckShuJuResultTool();
               this.listBox1.Items.Clear();
               Ch.ShowOnListBox1(this.listBox1, e);
               #endregion

               #region  运行状态的处理
               switch (_RunWay)
               {
                   #region  单步触发
                   case run_way.check_stream_again_run:

                       //Invoke(new Action(delegate
                       //{
                       tSB_run_again_check_stream.Text = "单步运行";
                       _RunWay = run_way.stop;
                       DanBuYunXingKaiFangKongJian();
                       //}));

                       break;
                   #endregion

                   #region  循环触发
                   case run_way.check_stream_circulation:
                       Thread thr = new Thread(new ThreadStart(() => { _ICheckStr.trigger_check(); }));
                       thr.Start();
                       break;
                   #endregion

                   #region 链接相机运行
                   case run_way.link_camer_run:

                       break;
                   #endregion

                   #region   停止运行
                   case run_way.stop:
                       XunHuanYunXingPingKongJian();
                       break;
                   #endregion

                   #region  默认处理
                   default:
                       _RunWay = run_way.stop;
                       break;
                   #endregion
               }
               #endregion

           }));
        }
        #endregion

        #region    刷新检测节点
        /// <summary>
        /// 刷新检测节点
        /// </summary>
        void Refresh_Delection()
        {
            Invoke(new Action(delegate
            {
                #region  无用代码
                //List<string> delection;
                //MultTreeControlLibrary.Select_MultTreeCheckStream.Out_CheckMultNode(out delection);
                //tSB_delection_box.Items.Clear();
                //foreach (string n in delection)
                //{
                //    tSB_delection_box.Items.Add(n);
                //}
                #endregion

                if (tSB_delection_box.Items.Count > 0)
                {
                    tSB_delection_box.Items.Clear();
                }
                int num = TreeStatic.Root.ChildList.Count;
                for (int i = 0; i < num; i++)
                {
                    tSB_delection_box.Items.Add(i.ToString());
                }
            }));
        }
        #endregion

        #region   支持外部使用控件单步触发检测
        /// <summary>
        ///  支持外部使用控件单步触发当前检测流
        /// </summary>
        /// <returns></returns>
        public bool External_Trigger()
        {
            bool ok = false;
            _ICheckStr.trigger_check();
            ok = true;
            return ok;
        }
        #endregion

        #region   刷新当前树节点
        /// <summary>
        /// 刷新当前树节点
        /// </summary>
        void Refresh_TreeViewAndMultTree()
        {
            TreeNode tr_0 = new TreeNode();
            tr_0.Text = "驱动1";
            tr_0.Name = "System_1"; //新建一个驱动

            if (tool_treeView.Nodes != null)
            {
                tool_treeView.Nodes.Clear();
            }//清空树

            //  TreeStatic.load_MultTreeNode_To_TreeNode(tr_0, TreeStatic.Root);

            TreeStatic.load_MultTreeNode_To_TreeNode_ContainsSelf(tr_0, _ICheckStr.Check_Root);

            tool_treeView.Nodes.Add(tr_0);
            tool_treeView.ExpandAll();
        }
        #endregion

        #region   单步运行屏蔽控件
        /// <summary>
        /// 单步运行屏蔽控件
        /// </summary>
        void DanBuYunXingPingKongJian()
        {
            but_add_detection.Enabled = false;
            but_load_detection.Enabled = false;
            tSB_run_circulation_check_stream.Enabled = false;
            bnt_save_detection.Enabled = false;
            bnt_anthor_save.Enabled = false;
            tSB_read_one_image.Enabled = false;
            listBox1.Enabled = false;
            listBox2.Enabled = false;
            tool_treeView.Enabled = false;
            toolStrip_third.Enabled = false;
        }
        #endregion

        #region   单步运行开放控件
        /// <summary>
        /// 单步运行开放控件
        /// </summary>
        void DanBuYunXingKaiFangKongJian()
        {
            but_add_detection.Enabled = true;
            but_load_detection.Enabled = true;
            tSB_run_circulation_check_stream.Enabled = true;
            bnt_save_detection.Enabled = true;
            bnt_anthor_save.Enabled = true;
            tSB_read_one_image.Enabled = true;
            listBox1.Enabled = true;
            listBox2.Enabled = true;
            tool_treeView.Enabled = true;
            toolStrip_third.Enabled = true;
        }
        #endregion

        #region   循环运行屏蔽控件
        /// <summary>
        /// 循环运行屏蔽控件
        /// </summary>
        void XunHuanYunXingPingBiKongJian()
        {
            but_add_detection.Enabled = false;
            but_load_detection.Enabled = false;
            tSB_run_again_check_stream.Enabled = false;
            bnt_save_detection.Enabled = false;
            bnt_anthor_save.Enabled = false;
            tSB_read_one_image.Enabled = false;
            listBox1.Enabled = false;
            listBox2.Enabled = false;
            toolStrip_third.Enabled = false;
            tool_treeView.Enabled = false;
        }

        #endregion

        #region   循环运行开始控件
        /// <summary>
        /// 循环运行开始控件
        /// </summary>
        void XunHuanYunXingPingKongJian()
        {
            but_add_detection.Enabled = true;
            but_load_detection.Enabled = true;
            tSB_run_again_check_stream.Enabled = true;
            bnt_save_detection.Enabled = true;
            bnt_anthor_save.Enabled = true;
            tSB_read_one_image.Enabled = true;
            listBox1.Enabled = true;
            listBox2.Enabled = true;
            tool_treeView.Enabled = true;
            toolStrip_third.Enabled = true;
        }
        #endregion

        #region     更改检测树
        private void tSB_delection_box_SelectedIndexChanged(object sender, EventArgs e)
        {
            ChangeCheckTree();
        }

        /// <summary>
        /// 更改检测树
        /// </summary>
        void ChangeCheckTree()
        {
            string num = tSB_delection_box.Text;

            if (num != "")
            {
                int i = int.Parse(num);
                this._ICheckStr.Check_Root = TreeStatic.Root.ChildList[i];
                TreeNode tr_0;
                tr_0 = new TreeNode();
                tr_0.Text = "驱动1";
                tr_0.Name = "System_1"; //新建一个驱动

                if (tool_treeView.Nodes != null)
                {
                    tool_treeView.Nodes.Clear();
                }

                TreeStatic.load_MultTreeNode_To_TreeNode_ContainsSelf(tr_0, _ICheckStr.Check_Root);
                tool_treeView.Nodes.Add(tr_0);//添加一个检测
                tool_treeView.ExpandAll();

                // Refresh_Delection();
            }
        }

        #endregion

        #region  添加一个检测
        private void toolStripButton_Add_Detection_Click(object sender, EventArgs e)
        {
            Add_Detection();
        }

        /// <summary>
        /// 添加一个检测
        /// </summary>
        void Add_Detection()
        {
            MultTreeNode m_tr_1 = new MultTreeNode();
            //m_tr_1.setNodeName("图像检测");
            //m_tr_1.setSelfId("detection_1");
            m_tr_1.NodeName = "图像检测";
            //m_tr_1.SelfId = "detection_1";

            string name = MultTree.CalculateMultTreeNodeName.CalculateMultTreeNodeName.CalculateNodeName("detection", TreeStatic.Root);
            m_tr_1.SelfId = name;

            ReadShuJu reshuju = new ReadShuJu();
            MultTreeNode m_tr_2 = new MultTreeNode();

            m_tr_2.NodeName = "取图";
            m_tr_2.SelfId = "acquire_1";
            m_tr_2.Obj = reshuju;

            m_tr_1.InsertChildNode(m_tr_2);

            TreeStatic.Root.InsertChildNode(m_tr_1);
            Refresh_Delection();
        }
        #endregion

        #region  删除一个检测
        private void toolStripButton_delete_detection_Click(object sender, EventArgs e)
        {
            Delete_Detection();
        }

        /// <summary>
        /// 删除当前检测
        /// </summary>
        void Delete_Detection()
        {
            string num = tSB_delection_box.Text;
            if (num != "")
            {
                int n = TreeStatic.Root.getChildNodeCount();

                if (n == 1)
                {
                    return;
                }
                int i = int.Parse(num);
                TreeStatic.Root.ChildList.RemoveAt(i);
                this._ICheckStr.Check_Root = TreeStatic.Root.ChildList[0];
                TreeNode tr_0;
                tr_0 = new TreeNode();
                tr_0.Text = "驱动1";
                tr_0.Name = "System_1"; //新建一个驱动

                if (tool_treeView.Nodes != null)
                {
                    tool_treeView.Nodes.Clear();
                }

                TreeStatic.load_MultTreeNode_To_TreeNode_ContainsSelf(tr_0, _ICheckStr.Check_Root);
                tool_treeView.Nodes.Add(tr_0);//添加一个检测
                tool_treeView.ExpandAll();

                Refresh_Delection();

            }
        }


        #endregion
    }

    #region 枚举运行方式
    /// <summary>
    /// 运行方式
    /// </summary>
    public enum run_way
    {
        /// <summary>
        /// 链接相机运行
        /// </summary>
        link_camer_run,
        /// <summary>
        /// 单步运行检测流
        /// </summary>
        check_stream_again_run,
        /// <summary>
        /// 循环运行检测流
        /// </summary>
        check_stream_circulation,
        /// <summary>
        /// 停止运行
        /// </summary>
        stop
    }
    #endregion
}
