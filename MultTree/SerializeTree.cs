using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Windows.Forms;
using System.Runtime.Serialization.Formatters.Binary;
using MultTree.MultTreeNodeStruct;/*********必须包含这个空间**********/





namespace MultTree.SerializeTree
{
    /// <summary>
    /// TreeView串行化类
    /// </summary>
    public class TreeViewDataAccess
    {
        /// <summary>
        /// 要处理的节点接口
        /// </summary>
        IMultTreeNode _IMult = null;

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="Mult">传入要处理的节点</param>
        public TreeViewDataAccess(IMultTreeNode Mult)
        {
            _IMult = Mult;
        }

        /// <summary>
        /// TreeViewData 树的数据
        /// </summary>
        [Serializable()]
        public struct TreeViewData
        {
            public TreeNodeData[] Nodes;

            /// <summary>
            /// 递归初始化TreeView数据
            /// </summary>
            /// <param name="Mtr"></param>
            public TreeViewData(IMultTreeNode Mtr)
            {
                Nodes = new TreeNodeData[Mtr.getChildNodeCount()];//获取树节点数 创建对应个数的TreeNodeData数组
                if (Mtr.getChildNodeCount() == 0)
                {
                    return;//等于O就返回
                }

                for (int i = 0; i <= Mtr.getChildNodeCount() - 1; i++)
                {
                    // Nodes[i] = new TreeNodeData(treeview.Nodes[i]);//把节点对应添加到数组中
                    Nodes[i] = new TreeNodeData(Mtr.getChildList()[i]);
                }
            }

            /// <summary>
            /// 通过TreeViewData弹出TreeView
            /// </summary>
            /// <param name="IMult"></param>
            public void PopulateTree(IMultTreeNode IMult)
            {
                if (this.Nodes == null || this.Nodes.Length == 0)
                {
                    return;//判断节点数组是否为空或没有节点
                }
                #region 无用代码
                //  treeview.BeginUpdate();//禁止树视图重绘
                #endregion
                for (int i = 0; i <= this.Nodes.Length - 1; i++)
                {
                    #region 无用代码
                    #region  无用代码
                    // treeview.Nodes.Add(this.Nodes[i].ToTreeNode());//把节点添加到树中
                    //MultTreeNode tr = new MultTreeNode();
                    //tr.setSelfId(this.Nodes[i].ToTreeNode().getSelfId());
                    //tr.setNodeName( this.Nodes[i].ToTreeNode().getNodeName());
                    //tr.setParent(this.Nodes[i].ToTreeNode().getParentId());
                    //tr.setParentNode(this.Nodes[i].ToTreeNode().getParentNode());
                    //tr.setChildList(this.Nodes[i].ToTreeNode().getChildList());
                    //    treeview.Nodes.Add(tr);
                    //MachineVision.ShuJuJieGou.TreeStatic.get_Root().getChildList().Add(this.Nodes[i].ToTreeNode());
                    #endregion
                    // IMult.getChildList().Add(this.Nodes[i].ToTreeNode());
                    #endregion
                    IMult.InsertChildNode(this.Nodes[i].ToTreeNode());
                }
                #region  无用代码
                // treeview.EndUpdate();//启动树视图重绘
                #endregion
            }
        }

        /// <summary>
        /// TreeNodeData 节点的数据
        /// </summary>
        [Serializable()]
        public struct TreeNodeData
        {
            #region  无用代码
            // public MultTreeNode parentNodes;
            //  public string Parent;
            #endregion
            public string Text;
            public string Name;
            #region  无用代码
            // public int ImageIndex;
            // public int SelectedImageIndex;
            // public bool Checked;
            // public bool Expanded;
            #endregion
            public object Tag;
            public TreeNodeData[] Nodes;
            /// <summary>
            /// TreeNode构造函数
            /// </summary>
            /// <param name="node"></param>
            public TreeNodeData(MultTreeNode node)
            {

                //this.Text = node.getNodeName();
                //this.Name = node.getSelfId();
                this.Text = node.NodeName;
                this.Name = node.SelfId;
                #region 无用代码
                // this.Parent = node.getParentId();
                //  this.ImageIndex = node.ImageIndex;
                //this.SelectedImageIndex = node.SelectedImageIndex;
                //  this.Checked = node.Checked;
                // this.Expanded = node.IsExpanded;
                #endregion

                this.Nodes = new TreeNodeData[node.getChildNodeCount()];
                if ((!(node.Obj == null)) && node.Obj.GetType().IsSerializable)
                {
                    this.Tag = node.Obj;
                }
                else
                {
                    this.Tag = null;
                }

                #region  无用代码
                //if (node.getParentNode() != null)
                //{
                //    this.parentNodes = node.getParentNode();
                //}
                //else
                //{
                //    this.parentNodes = null;
                //}
                #endregion

                if (node.getChildNodeCount() == 0)
                {
                    return;
                }
                for (int i = 0; i <= node.getChildNodeCount() - 1; i++)
                {
                    Nodes[i] = new TreeNodeData(node.getChildList()[i]);
                }
            }

            /// <summary>
            /// TreeNodeData返回TreeNode
            /// </summary>
            /// <returns></returns>
            public MultTreeNode ToTreeNode()
            {
                #region  无用代码
                //TreeNode ToTreeNode = new TreeNode(this.Text, this.ImageIndex, this.SelectedImageIndex);
                #endregion

                MultTreeNode ToTreeNode = new MultTreeNode();
                #region  无用代码
                //  ToTreeNode.Checked = this.Checked;
                #endregion
                ToTreeNode.Obj = this.Tag;
                ToTreeNode.SelfId = this.Name;
                ToTreeNode.NodeName = this.Text;
                //ToTreeNode.setNodeName(this.Text);
                // ToTreeNode.setSelfId(this.Name);
                #region  无用代码
                #region  无用代码
                //ToTreeNode.setParent(this.Parent);
                //ToTreeNode.setParentNode(this.parentNodes);
                #endregion

                #region 无用代码
                //if (this.Expanded)
                //{
                //    ToTreeNode.Expand();
                //}
                #endregion
                #endregion

                if (this.Nodes == null && this.Nodes.Length == 0)
                {
                    return null;
                }
                if (ToTreeNode != null && this.Nodes.Length == 0)
                {
                    return ToTreeNode;
                }
                for (int i = 0; i <= this.Nodes.Length - 1; i++)
                {
                    #region 无用代码
                    // ToTreeNode.Nodes.Add(this.Nodes[i].ToTreeNode());
                    // ToTreeNode.getChildList().Add(this.Nodes[i].ToTreeNode());
                    #endregion
                    ToTreeNode.InsertChildNode(this.Nodes[i].ToTreeNode());
                }
                return ToTreeNode;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="path"></param>
        public void LoadTreeViewData(string path)
        {
            LoadTreeViewData(path, _IMult);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="path"></param>
        /// <param name="_IMult"></param>
        static void LoadTreeViewData(string path, IMultTreeNode _IMult)
        {
            #region  无用代码
            // TreeStatic.get_Root().getChildList().Clear();//加载时先清空跟节点的子节点
            #endregion
            _IMult.getChildList().Clear();//加载时先清空跟节点的子节点
            BinaryFormatter ser = new BinaryFormatter();
            Stream file = new FileStream(path, FileMode.Open, FileAccess.Read, FileShare.Read);
            TreeViewData treeData = ((TreeViewData)(ser.Deserialize(file)));
            treeData.PopulateTree(_IMult);
            file.Close();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="path"></param>
        public void SaveTreeViewData(string path)
        {
            SaveTreeViewData(path, _IMult);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="path"></param>
        /// <param name="_IMult"></param>
        static void SaveTreeViewData(string path, IMultTreeNode _IMult)
        {
            BinaryFormatter ser = new BinaryFormatter();
            Stream file = new FileStream(path, FileMode.Create);
            #region  无用代码
            //  ser.Serialize(file, new TreeViewData(TreeStatic.get_Root()));
            #endregion
            ser.Serialize(file, new TreeViewData(_IMult));
            file.Close();
        }
    }

    /// <summary>
    ///MultTreeNode 串行化类
    /// </summary>
    public class MultTreeNodeDataAccess
    {
        public MultTreeNodeDataAccess() { }
        /// <summary>
        /// TreeNodeData 节点的数据
        /// </summary>
        [Serializable()]
        public struct MultTreeNodeData
        {
            /// <summary>
            /// 文本名
            /// </summary>
            public string Text;
            /// <summary>
            /// 节点名
            /// </summary>
            public string Name;
            //   public int ImageIndex;
            //  public int SelectedImageIndex;
            //    public bool Checked;
            //  public bool Expanded;
            /// <summary>
            /// 数据
            /// </summary>
            public object Tag;
            /// <summary>
            /// 子节点
            /// </summary>
            public MultTreeNodeData[] Nodes;
            /// <summary>
            /// TreeNode构造函数
            /// </summary>
            /// <param name="node"></param>
            public MultTreeNodeData(MultTreeNode node)
            {
                //this.Text = node.getNodeName();
                //this.Name = node.getSelfId();
                this.Text = node.NodeName;
                this.Name = node.SelfId;
                //  this.ImageIndex = node.ImageIndex;
                //  this.SelectedImageIndex = node.SelectedImageIndex;
                // this.Checked = node.Checked;
                // this.Expanded = node.IsExpanded;
                this.Nodes = new MultTreeNodeData[node.getChildList().Count];
                if ((!(node.Obj == null)) && node.Obj.GetType().IsSerializable)
                {
                    this.Tag = node.Obj;
                }
                else
                {
                    this.Tag = null;
                }
                if (node.getChildList().Count == 0)
                {
                    return;
                }
                for (int i = 0; i <= node.getChildList().Count - 1; i++)
                {
                    Nodes[i] = new MultTreeNodeData(node.getChildList()[i]);
                }
            }


            /// <summary>
            /// TreeNodeData返回TreeNode
            /// </summary>
            /// <returns></returns>
            public MultTreeNode ToTreeNode()
            {

                MultTreeNode ToTreeNode = new MultTreeNode();
                //    ToTreeNode.Checked = this.Checked;
                //  ToTreeNode.setObj(this.Tag);
                ToTreeNode.Obj = this.Tag;
                ToTreeNode.NodeName = this.Text;
                ToTreeNode.SelfId = this.Name;
                // ToTreeNode.setNodeName(this.Name);
                //if (this.Expanded)
                //{
                //    ToTreeNode.Expand();
                //}
                if (this.Nodes == null && this.Nodes.Length == 0)
                {
                    return null;
                }
                if (ToTreeNode != null && this.Nodes.Length == 0)
                {
                    return ToTreeNode;
                }
                for (int i = 0; i <= this.Nodes.Length - 1; i++)
                {
                    ToTreeNode.getChildList().Add(this.Nodes[i].ToTreeNode());
                }
                return ToTreeNode;
            }
        }
    }
}
