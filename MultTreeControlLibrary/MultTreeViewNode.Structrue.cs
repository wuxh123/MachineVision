using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MultTree.MultTreeNodeStruct;
using MultTree;



namespace MultTreeControlLibrary
{
    #region 树节点的结构体
    /// <summary>
    /// 工具树的节点的结构体，包含当前节点的名字，有多小个父节点
    /// </summary>
    public struct tool_treeview_struct
    {
        #region  全局变量
        /// <summary>
        /// 当前节点名称
        /// </summary>
        private string current_nodes_name;
        /// <summary>
        /// 当前节点的文本名
        /// </summary>
        private string current_nodes_text;
        /// <summary>
        /// 节点路径
        /// </summary>
        private string current_node_lujing;
        /// <summary>
        /// 当前节点
        /// </summary>
        private IMultTreeNode current_multtreenode;
        /// <summary>
        /// 当前节点有多小个父节点
        /// </summary>
        /// public ArrayList current_nodes_parent;

        /// <summary>
        /// 所有父节点的名称
        /// </summary>
        private List<string> parent_node_name;
        #endregion

        #region 初始化
        /// <summary>
        /// 初始化结构体,默认current_nodes=null
        /// </summary>
        public void init()
        {
            current_nodes_name = null;
            current_nodes_text = null;
            current_node_lujing = null;
            current_multtreenode = null;
        }
        #endregion

        #region 属性

        /// <summary>
        /// 当前节点名称
        /// </summary>
        public string Current_Nodes_Name
        {
            get { return current_nodes_name; }
            set { current_nodes_name = value; }
        }

        /// <summary>
        /// 当前节点的文本名
        /// </summary>
        public string Current_Nodes_Text
        {
            get { return current_nodes_text; }

            set { current_nodes_text = value; }
        }

        /// <summary>
        /// 节点路径
        /// </summary>
        public string Current_Node_lujing
        {
            get { return current_node_lujing; }

            set { current_node_lujing = value; }
        }

        /// <summary>
        /// 当前节点
        /// </summary>
        public IMultTreeNode Current_MultTreeNode
        {
            get { return current_multtreenode; }

            set { current_multtreenode = value; }
        }

        /// <summary>
        /// 父节点的名称
        /// </summary>
        public List<string> Parent_Node_Name
        {
            get { return parent_node_name; }

            set { parent_node_name = value; }
        }

        #endregion
    }
    #endregion

    #region   分割检测树的检测流(静态)
    /// <summary>
    ///  分割检测树的检测流(静态)
    /// </summary>
    public static class Select_MultTreeCheckStream
    {
        #region    分割检测树的检测流
        /// <summary>
        /// 分割检测树的检测节点
        /// </summary>
        /// <param name="IMult"></param>
        /// <param name="Index"></param>
        /// <returns></returns>
        public static IMultTreeNode Select_CheckNodeStream(ref int Index)
        {
            IMultTreeNode IMult;

            int num = TreeStatic.Root.ChildList.Count;

            if (num == 0)
            {
                return null;
            }

            IMult = TreeStatic.Root.ChildList[Index];

            return IMult;
        }

        /// <summary>
        /// 选择第一个检测树的检测节点
        /// </summary>
        /// <param name="IMult"></param>
        /// <returns></returns>
        public static IMultTreeNode Select_CheckFristNodeStream()
        {
            IMultTreeNode IMult;
            int num = TreeStatic.Root.ChildList.Count;
            if (num == 0)
            {
                return null;
            }
            IMult = TreeStatic.Root.ChildList[0];
            return IMult;
        }
        #endregion

        #region   输出根节点的所有检测节点
        /// <summary>
        /// 输出根节点的所有检测节点的名称
        /// </summary>
        /// <param name="CheckMultNode"></param>
        /// <returns></returns>
        public static bool Out_CheckMultNode(out List<string> CheckMultNode)
        {
            bool ok = false;
            CheckMultNode = new List<string>();

            int num = TreeStatic.Root.ChildList.Count;

            if (num == 0)
            {
                return ok;
            }
            for (int i = 0; i < num; i++)
            {
                CheckMultNode.Add(TreeStatic.Root.ChildList[i].SelfId);
            }
            ok = true;
            return ok;
        }
        #endregion
    }
    #endregion

}
