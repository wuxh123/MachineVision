using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Common;
using System.Collections;
using System.IO;
using System.Text.RegularExpressions;




namespace MultTree.MultTreeNodeStruct
{
    #region   树节点的数据结构
    /// <summary>
    /// 树节点的数据结构
    /// </summary>
    [Serializable]
    public class MultTreeNode : IMultTreeNode
    {
        #region members  变量
      
        #region  无用代码
        #region  无用代码
        /// <summary>
        /// 工具个数
        /// </summary>
        //public static int toolNumber = 0;

        /// <summary>
        /// 父节点的id
        /// </summary>
        // private string parentId;
        #endregion
        #region   无用代码
        ///// <summary>
        ///// 节点的文本
        ///// </summary>
        ///// protected string nodeText;   
        #endregion
        #endregion

        #region  节点id
        /// <summary>
        /// 节点自己的id,对应treeview的name
        /// </summary>
        protected string selfId;
        #endregion

        #region  节点的文本名
        /// <summary>
        /// 节点的文本名称，对应treeview的text
        /// </summary>
        protected string nodeName;
        #endregion

        #region  节点绑定的数据
        /// <summary>
        /// 节点绑定的数据
        /// </summary>
        protected Object obj;
        #endregion

        #region  当前节点的父节点
        /// <summary>
        /// 节点的父节点
        /// </summary>
        protected MultTreeNode parentNode;
        #endregion
     
        #region  当前节点的子节点
        /// <summary>
        /// 节点的子节点
        /// </summary>
        protected List<MultTreeNode> childList;
        #endregion 

        #endregion members

        #region contrustion   创建

        #region 创建默认节点
        /// <summary>
        /// 初始化,默认selfid为"0",nodeName为"0",obj为null
        /// </summary>
        public MultTreeNode()
        {
            init();
        }
        #endregion

        #region  传入一个节点，创建这个节点
        /// <summary>
        /// 初始化
        /// </summary>
        /// <param name="pNode">传入节点</param>
        public MultTreeNode(MultTreeNode pNode)
        {
            init(pNode);
        }
        #endregion

        #region   初始化这个节点
        /// <summary>
        /// 初始化
        /// </summary>
        /// <param name="pNode">传入节点</param>
        public void init(MultTreeNode pNode = null)
        {
            if (childList == null)
            {
                childList = new List<MultTreeNode>();
            }
            //   parentId = "0";
            selfId = "0";
            nodeName = "0";
            obj = null;

            if (pNode != null)
            {
                nodeName = pNode.NodeName;
                selfId = pNode.SelfId;

                if (pNode.Obj != null)
                {
                    //obj = new Hashtable((Hashtable)pNode.getObj());
                    obj = pNode.Obj;
                }

                if (pNode.getChildList() != null)
                {
                    childList = new List<MultTreeNode>(pNode.getChildList());
                }

                if (pNode.ParentNode != null)
                {
                    parentNode = pNode.ParentNode;
                    pNode.parentNode.childList.Add(this);
                }

            }
        }
        #endregion

        #endregion contrustion

        #region check node   检测节点

        #region  检测是否存在子节点
        /// <summary>
        /// 获取是否不存在子节点
        /// </summary>
        /// <returns>返回真代表没有子节点</returns>
        public bool isLeaf()
        {
            return childList == null || childList.Count == 0;
        }
        #endregion

        #region  判断是否有父节点,没有父节点的是根节点
        /// <summary>
        /// 判断是否有父节点
        /// </summary>
        /// <returns>返回真代表没有父节点，没有父节点表示为根节点</returns>
        public bool isRoot()
        {
            return parentNode == null;
        }
        #endregion

        #region 检测当前节点是否存在每个节点
        /// <summary>
        /// check exist of child node.检测子节点是否存在
        /// </summary>
        /// <param name="name">查看的节点名称</param>
        /// <returns>返回真代表有</returns>
        public bool ExistChildNode(string name)//,bool IgnoreCase = false
        {
            bool bRet = false;
            foreach (MultTreeNode node in childList)
            {
                if (node.SelfId == name)
                {
                    bRet = true;
                    break;
                }
            }
            return bRet;
        }
        #endregion

        #endregion check node

        #region insert  添加节点
        #region 无用代码
        /// <summary>
        /// insert child node to one node(this).
        /// </summary>
        /// <param name="name">new child node name.</param>
        /// <param name="path"></param>
        /// <param name="newnode">can be null. no use I think.</param>
        /// <returns></returns>
        //virtual public MultTreeNode InsertNode(string name, string path = "", MultTreeNode newnode = null)
        //{
        //    MultTreeNode pntnode = this;
        //    if (newnode == null) newnode = new MultTreeNode();
        //    if (path.Length > 0)
        //    {
        //        pntnode = findNodeByPath(path);
        //    }
        //    if (pntnode == null) return null;
        //    // check if has same node with same name.
        //    // can not insert two same name node under one parent node.
        //    // 2016-03-04 09:38:33
        //    if (pntnode.ExistChildNode(name))
        //        return pntnode;
        //    newnode.setNodeName(name);
        //    newnode.parentNode = pntnode;
        //    pntnode.InsertChildNode(newnode);
        //    return newnode;
        //}

        #endregion

        #region  在当前节点前面加入一个节点
        /// <summary>
        /// 在当前的节点前面插入节点
        /// </summary>
        public void InsertNodeBefore(MultTreeNode treeNode)
        {
            int i = this.parentNode.childList.IndexOf(this);
            treeNode.ParentNode = this.ParentNode;
            this.parentNode.childList.Insert(i, treeNode);
        }
        #endregion

        #region  在当前节点后面加入一个节点
        /// <summary>
        /// 在当前的节点后面插入节点
        /// </summary>
        public void InsertNodeAfter(MultTreeNode treeNode)
        {
            int i = this.parentNode.childList.IndexOf(this);
            treeNode.ParentNode = this.ParentNode;
            this.parentNode.childList.Insert(i + 1, treeNode);
        }
        #endregion

        #region  在当前节点的子节点加入一个节点
        /// <summary>
        /// 在当前节点出入子节点
        /// </summary>
        public void InsertChildNode(MultTreeNode treeNode)
        {
            if (childList == null)
            {
                childList = new List<MultTreeNode>();
            }
            treeNode.ParentNode = this;
            childList.Add(treeNode);
        }
        #endregion
        #endregion insert

        #region get  

        #region 获取当前节点的子节点个数
        /// <summary>
        /// 获取子节点个数
        /// </summary>
        /// <returns></returns>
        public int getChildNodeCount()
        {
            return childList == null ? 0 : childList.Count;
        }
        #endregion

        #region 无用代码
        /// <summary>
        /// 获取兄弟节点
        /// </summary>
        /// <returns>current node 's brother node count</returns>
        //public int getBrotherNodeCount()
        //{
        //    if (parentNode != null)
        //    {
        //        return parentNode.getChildList() != null ? parentNode.getChildList().Count : 1;
        //    }
        //    else
        //    {
        //        return 1;
        //    }
        //}

        /// <summary>
        /// 获取obj
        /// </summary>
        /// <returns></returns>
        //public Object getObj()
        //{
        //    return obj;
        //}

        /// <summary>
        /// 获取父节点
        /// </summary>
        /// <returns></returns>
        //public MultTreeNode getParentNode()
        //{
        //    return parentNode;
        //}

        /// <summary>
        /// 获取节点的id
        /// </summary>
        /// <returns></returns>
        //public string getSelfId()
        //{
        //    return selfId;
        //}
        /// <summary>
        /// 获取父节点的id
        /// </summary>
        /// <returns></returns>
        //public string getParentId()
        //{
        //    return parentId;
        //}

        /// <summary>
        /// 获取节点的名称
        /// </summary>
        /// <returns></returns>
        //public string getNodeName()
        //{
        //    return nodeName;
        //}

        #region  无用代码
        /// <summary>
        /// find one note in tree.
        /// 2016-03-04 16:21:34
        /// modify when empty path .return this instead of null.
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        //public MultTreeNode findNodeByPath(string path)
        //{
        //    if (string.IsNullOrEmpty(path)) return this;

        //    path = StrUtils.FormatPath(path);
        //    path = StrUtils.GetSDirString(path);

        //    string[] pathArr = StrUtils.Split(path, "\\");//path.Split('\\');
        //    if (pathArr[0] == null) pathArr[0] = path;

        //    // make sure this is root path.
        //    if (nodeName != pathArr[0]) return null;

        //    MultTreeNode node = this;
        //    for (int i = 0; i < pathArr.Count(); i++)
        //    {
        //        // 说明：注释。不知道为什么要加这句 可能会影响代码生成。需要注意
        //        // 修改为 break; => continue; \ 查找具有 相同节点名称的 子节点 逻辑
        //        // 短暂测试是正常的。
        //        // 修改日期：2014-8-5 14:20:28
        //        if (string.IsNullOrEmpty(pathArr[i]))
        //        {
        //            List<MultTreeNode> list = node.getChildList();
        //            if (i < pathArr.Count() - 1)
        //                for (int j = 0; j < list.Count; j++)
        //                {
        //                    if (list[j].getNodeName() == pathArr[i + 1])
        //                    {
        //                        node = list[j];
        //                    }
        //                }
        //            continue;
        //        }
        //        // use path to avoid error like 0\0\0
        //        // 2016-07-11 21:34:54
        //        string nodePath = node.getPath();
        //        string testPath = StrUtils.FromArr(ArrayUtils.SplitArray<string>(pathArr, 0, i - 1), "\\");

        //        if (node.getNodeName() == pathArr[i] && nodePath == testPath)
        //        {
        //            List<MultTreeNode> list = node.getChildList();
        //            for (int j = 0; j < list.Count; j++)
        //            {
        //                if (i + 1 < pathArr.Length && list[j].getNodeName() == pathArr[i + 1])
        //                {
        //                    node = list[j];
        //                }
        //            }
        //        }
        //        else
        //        {
        //            node = null;
        //            break;
        //        }
        //    }
        //    return node;
        //}

        /// <summary>
        /// build one path by node name
        /// </summary>
        /// <returns>path like directory</returns>
        //public string getPath()
        //{
        //    List<MultTreeNode> list = getElders();
        //    string path = "";
        //    for (int i = 0; i < list.Count; i++)
        //    {
        //        if (list[i] != null)
        //        {
        //            if (path.Length > 0) path += "\\";
        //            path += list[i].getNodeName();
        //        }
        //    }
        //    return path;
        //}

        /** 返回当前节点的父辈节点集合 形成路径使用 */
        //public List<MultTreeNode> getElders()
        //{
        //    ListExtA<MultTreeNode> elderList = new ListExtA<MultTreeNode>();
        //    MultTreeNode parentNode = this.getParentNode();
        //    if (parentNode == null)
        //    {
        //        return elderList;
        //    }
        //    else
        //    {
        //        elderList.AddAll(parentNode.getElders());
        //        elderList.Add(parentNode);
        //        return elderList;
        //    }
        //}


        /** 返回当前节点的晚辈集合 */
        //public List<MultTreeNode> getJuniors()
        //{
        //    ListExtA<MultTreeNode> juniorList = new ListExtA<MultTreeNode>();
        //    List<MultTreeNode> childList = this.getChildList();
        //    if (childList == null)
        //    {
        //        return juniorList;
        //    }
        //    else
        //    {
        //        int childNumber = childList.Count;
        //        for (int i = 0; i < childNumber; i++)
        //        {
        //            MultTreeNode junior = childList.ElementAt(i);
        //            juniorList.Add(junior);
        //            juniorList.AddAll(junior.getJuniors());
        //        }
        //        return juniorList;
        //    }
        //}
        #endregion
        #endregion

        #region  获取子节点
        /// <summary>
        /// 获取子节点
        /// </summary>
        /// <returns></returns>
        public List<MultTreeNode> getChildList()
        {
            return childList;
        }
        #endregion

        #endregion get

        #region delete 删除

        #region  删除当前节点和他的晚辈
        /// <summary>
        /// 删除当前节点和他的晚辈
        /// </summary>
        public void deleteNode()
        {
            IMultTreeNode parentNode = this.ParentNode;
            string id = this.SelfId;
            if (parentNode != null)
            {
                parentNode.deleteChildNode(id);
            }
        }
        #endregion

        #region   删除当前节点的某个子节点
        /// <summary>
        ///  删除当前节点的某个子节点,当传入childId=""时删除，所有子节点
        /// </summary>
        /// <param name="childId"></param>
        public void deleteChildNode(string childId = "")
        {
            //  List<MultTreeNode> childList = this.getChildList();
            int childNumber = childList.Count;
            for (int i = 0; i < childNumber; i++)
            {
                MultTreeNode child = childList.ElementAt(i);
                if (child.SelfId == childId || childId == "")
                {
                    childList.RemoveAt(i);
                    return;
                }
            }
        }
        #endregion

        #region 清空当前节点的子节点
        /// <summary>
        /// 清空子节点
        /// </summary>
        public void deleteClearAll()
        {
            childList.Clear();
        }
        #endregion

        #endregion delete

        #region  无用代码
        #region  无用代码
        #region loop  无用代码
        //public delegate int OneStepTravers(MultTreeNode node);

        ///** 遍历一棵树，深度遍历 */
        //public void depthtraverse(OneStepTravers stepbef, OneStepTravers stepafter)
        //{
        //    if (stepbef != null)
        //        stepbef(this);

        //    if (childList != null)
        //    {
        //        int childNumber = childList.Count;
        //        for (int i = 0; i < childNumber; i++)
        //        {
        //            MultTreeNode child = childList.ElementAt(i);
        //            child.depthtraverse(stepbef, stepafter);
        //        }
        //    }
        //    if (stepafter != null)
        //        stepafter(this);
        //}
        #endregion loop

        #region node test  无用代码
        //public void print(String content)
        //{
        //    System.Diagnostics.Debug.WriteLine(content);
        //}

        //public void print(int content)
        //{
        //    System.Diagnostics.Debug.WriteLine(content.ToString());
        //}
        #endregion node test
        #endregion

        #region  无用代码
        #region set
        ///// <summary>
        ///// 
        ///// </summary>
        ///// <param name="childList"></param>
        //public void setChildList(List<MultTreeNode> childList)
        //{
        //    this.childList = childList;
        //}

        /// <summary>
        /// 设置父节点的id
        /// </summary>
        /// <param name="Parent"></param>
        //public void setParent(string Parent)
        //{
        //    this.parentId = Parent;
        //}


        #region  无用代码
        //public void setParentId(int parentId)
        //{
        //    this.parentId = parentId;
        //}

        #endregion

        /// <summary>
        /// 设置节点的id
        /// </summary>
        /// <param name="selfId"></param>
        //public void setSelfId(string selfId)
        //{
        //    this.selfId = selfId;
        //}

        /// <summary>
        /// 设置当前节点的父节点
        /// </summary>
        /// <param name="parentNode"></param>
        //public void setParentNode(MultTreeNode parentNode)
        //{
        //    this.parentNode = parentNode;
        //}

        /// <summary>
        /// 
        /// </summary>
        /// <param name="nodeName"></param>
        //public void setNodeName(string nodeName)
        //{
        //    this.nodeName = nodeName;
        //}

        //public void setObj(Object obj)
        //{
        //    this.obj = obj;
        //}
        #endregion set
        #endregion
        #endregion

        #region find  查找节点

        #region  查找节点
        /// <summary>
        /// 通过id找到节点
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public MultTreeNode findNodeById(string id)
        {
            if (this.selfId == id)
                return this;
            if (isLeaf())
            {
                return null;
            }
            else
            {
                int childNumber = childList.Count;
                for (int i = 0; i < childNumber; i++)
                {
                    MultTreeNode child = childList.ElementAt(i);
                    MultTreeNode resultNode = child.findNodeById(id);
                    if (resultNode != null)
                    {
                        return resultNode;
                    }
                }
                return null;
            }
        }
        #endregion

        #region  无用代码
        ///// <summary>
        ///// 查找节点在父节点的位置
        ///// </summary>
        ///// <param name="id"></param>
        ///// <returns></returns>
        //public int findNodeInderById()
        //{                      
        //    if (this.isRoot())
        //    {
        //        return 0;
        //    }
        //    else
        //    {
        //        int childNumber =this.parentNode.childList.Count;
        //        for (int i = 0; i < childNumber; i++)
        //        {
        //            MultTreeNode child =this.parentNode.childList.ElementAt(i);
        //            //MultTreeNode resultNode = this.parentNode.findNodeById(id);
        //            if (child.SelfId == this.selfId)
        //            {
        //                return i;
        //            }
        //        }
        //        return -2;
        //    }
        //}
        #endregion

        #endregion

        #region  变量的属性
      
        #region  无用代码
        /// <summary>
        /// 父节点的id
        /// </summary>
        //public string ParentId
        //{
        //    get { return parentId; }
        //    set { parentId = value; }
        //}
        #endregion

        #region 节点的id
        /// <summary>
        ///节点的id
        /// </summary>
        public string SelfId
        {
            get { return selfId; }

            set { selfId = value; }
        }
        #endregion

        #region  当前节点的文本名
        /// <summary>
        /// 当前节点的文本名称
        /// </summary>
        public string NodeName
        {
            set { nodeName = value; }

            get { return nodeName; }
        }
        #endregion 

        #region   节点的父节点
        /// <summary>
        ///节点的父节点 
        /// </summary>
        public MultTreeNode ParentNode
        {
            get { return parentNode; }

            set { parentNode = value; }
        }
        #endregion 

        #region  节点的子节点
        /// <summary>
        /// 节点的子节点
        /// </summary>
        public List<MultTreeNode> ChildList
        {
            set { childList = value; }

            get { return childList; }
        }
        #endregion

        #region  绑定节点的数据
        /// <summary>
        /// 绑定节点的数据属性
        /// </summary>
        public Object Obj
        {
            set { obj = value; }

            get { return obj; }
        }
        #endregion
        
        #endregion
    }
    #endregion

    #region  树节点的数据结构接口
    /// <summary>
    ///  树节点的数据结构接口
    /// </summary>
    public interface IMultTreeNode
    {
        #region check node
        /// <summary>
        /// 获取是否不存在子节点
        /// </summary>
        /// <returns>返回真代表没有子节点</returns>
        bool isLeaf();

        /// <summary>
        /// 判断是否有父节点
        /// </summary>
        /// <returns>返回真代表没有父节点，没有父节点表示为根节点</returns>
        bool isRoot();

        /// <summary>
        /// check exist of child node.检测子节点是否存在
        /// </summary>
        /// <param name="name">查看的节点名称</param>
        /// <returns>返回真代表有</returns>
        bool ExistChildNode(string name);
        #endregion check node

        #region insert
        #region 无用代码
        /// <summary>
        /// insert child node to one node(this).
        /// </summary>
        /// <param name="name">new child node name.</param>
        /// <param name="path"></param>
        /// <param name="newnode">can be null. no use I think.</param>
        /// <returns></returns>
        //virtual public MultTreeNode InsertNode(string name, string path = "", MultTreeNode newnode = null)
        //{
        //    MultTreeNode pntnode = this;
        //    if (newnode == null) newnode = new MultTreeNode();
        //    if (path.Length > 0)
        //    {
        //        pntnode = findNodeByPath(path);
        //    }
        //    if (pntnode == null) return null;
        //    // check if has same node with same name.
        //    // can not insert two same name node under one parent node.
        //    // 2016-03-04 09:38:33
        //    if (pntnode.ExistChildNode(name))
        //        return pntnode;
        //    newnode.setNodeName(name);
        //    newnode.parentNode = pntnode;
        //    pntnode.InsertChildNode(newnode);
        //    return newnode;
        //}

        #endregion


        /// <summary>
        /// 在当前节点插入子节点
        /// </summary>
        void InsertChildNode(MultTreeNode treeNode);

        /// <summary>
        /// 在当前的节点后面插入节点
        /// </summary>
        void InsertNodeAfter(MultTreeNode treeNode);

        /// <summary>
        /// 在当前节点前面插入子节点
        /// </summary>
        void InsertNodeBefore(MultTreeNode treeNode);

        #endregion insert

        #region get
        /// <summary>
        /// 获取子节点个数
        /// </summary>
        /// <returns></returns>
        int getChildNodeCount();

        #region 无用代码
        /// <summary>
        /// 获取obj
        /// </summary>
        /// <returns></returns>
        //Object getObj();

        /// <summary>
        /// 获取父节点
        /// </summary>
        /// <returns></returns>
        //MultTreeNode getParentNode();

        /// <summary>
        /// 获取节点的id
        /// </summary>
        /// <returns></returns>
        // string getSelfId();

        /// <summary>
        /// 获取父节点的id
        /// </summary>
        /// <returns></returns>
        //  string getParentId();


        /// <summary>
        /// 获取节点的名称
        /// </summary>
        /// <returns></returns>
        // string getNodeName();
        /// <summary>
        /// 获取兄弟节点
        /// </summary>
        /// <returns>current node 's brother node count</returns>
        //int getBrotherNodeCount();


        #region  无用代码
        /// <summary>
        /// find one note in tree.
        /// 2016-03-04 16:21:34
        /// modify when empty path .return this instead of null.
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        //public MultTreeNode findNodeByPath(string path)
        //{
        //    if (string.IsNullOrEmpty(path)) return this;

        //    path = StrUtils.FormatPath(path);
        //    path = StrUtils.GetSDirString(path);

        //    string[] pathArr = StrUtils.Split(path, "\\");//path.Split('\\');
        //    if (pathArr[0] == null) pathArr[0] = path;

        //    // make sure this is root path.
        //    if (nodeName != pathArr[0]) return null;

        //    MultTreeNode node = this;
        //    for (int i = 0; i < pathArr.Count(); i++)
        //    {
        //        // 说明：注释。不知道为什么要加这句 可能会影响代码生成。需要注意
        //        // 修改为 break; => continue; \ 查找具有 相同节点名称的 子节点 逻辑
        //        // 短暂测试是正常的。
        //        // 修改日期：2014-8-5 14:20:28
        //        if (string.IsNullOrEmpty(pathArr[i]))
        //        {
        //            List<MultTreeNode> list = node.getChildList();
        //            if (i < pathArr.Count() - 1)
        //                for (int j = 0; j < list.Count; j++)
        //                {
        //                    if (list[j].getNodeName() == pathArr[i + 1])
        //                    {
        //                        node = list[j];
        //                    }
        //                }
        //            continue;
        //        }
        //        // use path to avoid error like 0\0\0
        //        // 2016-07-11 21:34:54
        //        string nodePath = node.getPath();
        //        string testPath = StrUtils.FromArr(ArrayUtils.SplitArray<string>(pathArr, 0, i - 1), "\\");

        //        if (node.getNodeName() == pathArr[i] && nodePath == testPath)
        //        {
        //            List<MultTreeNode> list = node.getChildList();
        //            for (int j = 0; j < list.Count; j++)
        //            {
        //                if (i + 1 < pathArr.Length && list[j].getNodeName() == pathArr[i + 1])
        //                {
        //                    node = list[j];
        //                }
        //            }
        //        }
        //        else
        //        {
        //            node = null;
        //            break;
        //        }
        //    }
        //    return node;
        //}

        /// <summary>
        /// build one path by node name
        /// </summary>
        /// <returns>path like directory</returns>
        //public string getPath()
        //{
        //    List<MultTreeNode> list = getElders();
        //    string path = "";
        //    for (int i = 0; i < list.Count; i++)
        //    {
        //        if (list[i] != null)
        //        {
        //            if (path.Length > 0) path += "\\";
        //            path += list[i].getNodeName();
        //        }
        //    }
        //    return path;
        //}

        /** 返回当前节点的父辈节点集合 形成路径使用 */
        //public List<MultTreeNode> getElders()
        //{
        //    ListExtA<MultTreeNode> elderList = new ListExtA<MultTreeNode>();
        //    MultTreeNode parentNode = this.getParentNode();
        //    if (parentNode == null)
        //    {
        //        return elderList;
        //    }
        //    else
        //    {
        //        elderList.AddAll(parentNode.getElders());
        //        elderList.Add(parentNode);
        //        return elderList;
        //    }
        //}


        /** 返回当前节点的晚辈集合 */
        //public List<MultTreeNode> getJuniors()
        //{
        //    ListExtA<MultTreeNode> juniorList = new ListExtA<MultTreeNode>();
        //    List<MultTreeNode> childList = this.getChildList();
        //    if (childList == null)
        //    {
        //        return juniorList;
        //    }
        //    else
        //    {
        //        int childNumber = childList.Count;
        //        for (int i = 0; i < childNumber; i++)
        //        {
        //            MultTreeNode junior = childList.ElementAt(i);
        //            juniorList.Add(junior);
        //            juniorList.AddAll(junior.getJuniors());
        //        }
        //        return juniorList;
        //    }
        //}
        #endregion
        #endregion

        /// <summary>
        /// 获取子节点
        /// </summary>
        /// <returns></returns>
        List<MultTreeNode> getChildList();

        #endregion get

        #region delete

        /// <summary>
        /// 删除当前节点和他的晚辈
        /// </summary>
        void deleteNode();


        /// <summary>
        ///  删除当前节点的某个子节点,当传入childId=""时删除，所有子节点
        /// </summary>
        /// <param name="childId"></param>
        void deleteChildNode(string childId = "");


        /// <summary>
        /// 清空子节点
        /// </summary>
        void deleteClearAll();

        #endregion delete

        #region  无用代码
        #region set
        //void setChildList(List<MultTreeNode> childList);


        /// <summary>
        /// 设置父节点的id
        /// </summary>
        /// <param name="Parent"></param>
        // void setParent(string Parent);



        #region  无用代码
        //public void setParentId(int parentId)
        //{
        //    this.parentId = parentId;
        //}

        #endregion

        /// <summary>
        /// 设置节点的id
        /// </summary>
        /// <param name="selfId"></param>
        // void setSelfId(string selfId);


        //void setParentNode(MultTreeNode parentNode);


        // void setNodeName(string nodeName);


        //  void setObj(Object obj);

        #endregion set
        #endregion

        #region find

        /// <summary>
        /// 通过id找到节点
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        MultTreeNode findNodeById(string id);
        #endregion

        #region  变量的属性

        #region  无用代码
        /// <summary>
        /// 父节点的id
        /// </summary>
        // string ParentId
        //{
        //    get;
        //    set;
        //}
        #endregion

        /// <summary>
        ///节点的id
        /// </summary>
        string SelfId
        {
            get;

            set;
        }

        /// <summary>
        /// 当前节点的文本名称
        /// </summary>
        string NodeName
        {
            set;

            get;
        }

        /// <summary>
        ///节点的父节点 
        /// </summary>
        MultTreeNode ParentNode
        {
            get;

            set;
        }

        /// <summary>
        /// 节点的子节点
        /// </summary>
        List<MultTreeNode> ChildList
        {
            set;

            get;
        }

        /// <summary>
        /// 绑定节点的数据属性
        /// </summary>
        Object Obj
        {
            set;

            get;
        }
        #endregion

    }
    #endregion

    #region   数组工具
    /// <summary>
    /// 数组工具
    /// </summary>
    partial class ArrayUtils
    {
        static public T Get<T>(T[] arr, int n, T Default)
        {
            if (arr == null) return Default;
            if (n < 0) return Default;
            T value = Default;
            if (arr.Count() > n)
                try
                {
                    value = arr[n];
                    if (value == null) value = Default;
                }
                catch
                {
                }
            return value;
        }
        /// <summary>
        /// 从数组中截取一部分成新的数组
        /// </summary>
        /// <param name="Source">原数组</param>
        /// <param name="StartIndex">原数组的起始位置</param>
        /// <param name="EndIndex">原数组的截止位置</param>
        /// <returns></returns>
        public static T[] SplitArray<T>(T[] Source, int StartIndex, int EndIndex)
        {
            if (Source.Length <= StartIndex)
            {
                return new T[0];
            }
            if (StartIndex < 0) StartIndex = 0;
            if (EndIndex > Source.Length - 1) EndIndex = Source.Length - 1;
            try
            {

                T[] result = new T[EndIndex - StartIndex + 1];
                for (int i = 0; i <= EndIndex - StartIndex; i++) result[i] = Get<T>(Source, i + StartIndex, default(T));
                return result;
            }
            catch (IndexOutOfRangeException ex)
            {
                //  Common.WriteException(ex);
                return new T[0];
            }
            catch (Exception ex)
            {
                //   Common.WriteException(ex);

                return new T[0];
            }
        }
        /// <summary>
        /// check string is null or empty.
        /// </summary>
        /// <param name="Arr"></param>
        /// <returns></returns>
        public static bool IsNullOrEmpty<T>(T[] Arr)
        {
            return Arr == null || Arr.Length == 0;
        }

        /// <summary>
        /// check if arr index is in arr
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="Arr"></param>
        /// <param name="n"></param>
        /// <returns></returns>
        public static bool IsValidIndex<T>(T[] Arr, int n)
        {
            if (IsNullOrEmpty(Arr)) return false;
            return n >= 0 && n < Arr.Length - 1;
        }
        public static bool IsBetweenIndex<T>(T[] Arr, int n, int nStartIndex, int nEndIndex)
        {
            if ((IsValidIndex<T>(Arr, nStartIndex) && n < nStartIndex) ||
                    (IsValidIndex<T>(Arr, nEndIndex) && n > nEndIndex))
            {
                return false;
            }
            return true;
        }
    }
    #endregion

    #region   HashTableUtils
    partial class HashTableUtils
    {
        static public bool IsNullOrEmpty(Hashtable ht)
        {
            if (ht == null) return true;
            if (ht.Count == 0) return true;
            return false;
        }
        static public bool Equal(Hashtable ht1, Hashtable ht2)
        {
            if (ht1 == null || ht2 == null) return false;
            if (ht1.Count != ht2.Count) return false;
            foreach (DictionaryEntry item in ht1)
            {
                object obj = GetValue<object>(ht2, item.Key.ToString(), null);
                if (!obj.Equals(item.Value))
                    return false;
            }
            return true;
        }
        static public int Add(ref Hashtable ht, object key, object value)
        {
            if (ht == null) ht = new Hashtable();
            if (key != null && value != null)
            {
                if (!ht.ContainsKey(key)) ht.Add(key, value);
            }
            return 0;
        }
        static public string GetString(Hashtable ht, string key, string Default = "")
        {
            object obj = GetValue(ht, key, Default);
            return obj == null && Default == null ? null : obj.ToString();
        }

        static public T GetValue<T>(Hashtable ht, string key, T Default)
        {
            T value = Default;
            if (ht == null || ht.Count == 0) return value;
            try
            {
                value = (T)ht[key];
                if (value == null) value = Default;
            }
            catch
            {
            }
            return value;
        }
        static public int SetValue(ref Hashtable ht, object key, object value)
        {
            int nRet = 0;
            if (ht == null) ht = new Hashtable();
            if (key != null)
            {
                if (!ht.ContainsKey(key))
                {
                    ht.Add(key, value);
                }
                else
                {
                    ht[key] = value;
                    nRet = -1;
                }
            }
            return nRet;
        }
    }
    #endregion

    #region   字符串工具
    partial class StrUtils
    {
        public static bool Exist(string str, string tar, bool IgnoreCase = false)
        {
            if (string.IsNullOrEmpty(str) || string.IsNullOrEmpty(tar)) return false;
            if (IgnoreCase)
            {
                if (str.ToUpper().Length > 0 && tar.ToUpper().Length > 0)
                {
                    str = str.ToUpper();
                    tar = tar.ToUpper();
                }
            }
            int pos = str.IndexOf(tar, 0);
            if (pos >= 0) return true;
            return false;
        }
        static public string ConDirs(string root, string dir)
        {
            if (!IsExistVisibleChar(root))
            {
                // 说明：not need to connect. if no root
                // 修改日期：2015-3-5 12:28:39
                root = "";
                return dir;
            }
            if (!IsExistVisibleChar(dir)) dir = "";
            bool IsRootDir = IsDirString(root);
            bool IsDirBgn = IsDirStringBgn(dir);
            if (!IsRootDir && !IsDirBgn) return root.Trim() + "\\" + dir.Trim();
            else if (IsRootDir && IsDirBgn) return Left(root, root.Length - 1).Trim() + "\\" + Mid(dir, 1, dir.Length - 1).Trim();
            else return root + dir;
        }
        public static string Mid(string str, int nStartIndex, int nlength)
        {
            if (str == null || nlength < 0) return "";
            nStartIndex = nStartIndex < 0 ? 0 : nStartIndex;
            if (str.Length <= Math.Abs(nStartIndex + nlength))
            {
                nlength = str.Length - nStartIndex;
            }
            if (nlength <= 0) return "";
            return Substring(str, nStartIndex, nlength);
        }
        static public bool IsDirStringBgn(string text)
        {
            if (text.Length < 1) return false;
            string lst = Substring(text, 0, 1);
            return lst == "\\" || lst == "/";
        }
        public static bool IsExistVisibleChar(string str)
        {
            if (string.IsNullOrEmpty(str)) return false;
            Regex VisibleChar = new Regex(@"[^\r\n\t\s\v]+");
            return VisibleChar.IsMatch(str);
        }
        static public string GetDirPart(string text)
        {
            if (!IsExistVisibleChar(text)) text = "";
            text = GetSDirString(text);
            int lstInt = text.LastIndexOf("\\");
            int lstInt2 = text.LastIndexOf("/");
            if (lstInt < 0 && lstInt2 < 0)
            {
                // 说明：error logic return text.now return empty string.

                // 修改日期：2015-9-1 21:56:05
                //Logs.WriteError("path error: "+text);
                return "";
            }
            lstInt = lstInt > lstInt2 ? lstInt : lstInt2;
            return Substring(text, 0, lstInt + 1);
        }
        static public string GetFilePart(string text)
        {
            if (!IsExistVisibleChar(text)) text = "";
            text = text.Trim();
            int lstInt1 = text.LastIndexOf("\\");
            int lstInt2 = text.LastIndexOf("/");
            int lstInt = lstInt1 > lstInt2 ? lstInt1 : lstInt2;
            if (lstInt < 0) return text;
            return Substring(text, lstInt + 1, text.Length - lstInt - 1);
        }
        /// <summary>
        /// string array trans to string split with flg.
        /// 2016-02-18 13:24:47
        /// add startindex and endindex.
        /// </summary>
        /// <param name="arr"></param>
        /// <param name="split"></param>
        /// <param name="surround1"></param>
        /// <param name="surround2"></param>
        /// <param name="nStartIndex"></param>
        /// <param name="nEndIndex"></param>
        /// <returns></returns>
        public static string FromArr(string[] arr, string split = ";", string surround1 = "", string surround2 = "", int nStartIndex = -1, int nEndIndex = -1)
        {
            string str = "";
            if (arr == null) return str;
            int nIndex = -1;
            foreach (string item in arr)
            {
                nIndex++;
                if (!ArrayUtils.IsBetweenIndex<string>(arr, nIndex, nStartIndex, nEndIndex))
                {
                    continue;
                }
                if (str.Length > 0) str += split;
                str += surround1 + item + surround2;
            }
            return str;
        }
        public static string[] Split(string str, string splitflg)
        {
            if (string.IsNullOrEmpty(str)) return new string[] { };

            if (string.IsNullOrEmpty(splitflg))
            {
                return new string[] { str };
            }
            string[] strArr = null;

            RegexOptions ro = RegexOptions.Multiline | RegexOptions.ExplicitCapture;
            strArr = Regex.Split(str, splitflg, ro);
            //char[] splitflgArr = splitflg.ToArray();
            //strArr = str.Split(splitflgArr);

            return strArr;
        }
        public static string FormatPath(string srcFilePath, bool IsWindows = true)
        {
            string splitflg1 = "/", splitflg2 = "\\";
            if (string.IsNullOrEmpty(srcFilePath)) return "";
            srcFilePath = srcFilePath.Trim();
            if (!IsWindows)
            {
                splitflg1 = "\\";
                splitflg2 = "/";
            }
            srcFilePath.Replace(splitflg1, splitflg2);
            return srcFilePath;
        }
        static public string GetSDirString(string text)
        {
            if (text.Length < 1) return text;
            if (IsDirString(text))
                text = Left(text, text.Length - 1);
            return text;
        }
        static public bool IsDirString(string text)
        {
            if (text.Length < 1) return false;
            string lst = Substring(text, text.Length - 1, 1);
            return lst == "\\" || lst == "/";
        }
        public static string Substring(string str, int nPos, int nlength = -1)
        {
            if (string.IsNullOrEmpty(str)) return "";
            if (nlength == -1) nlength = str.Length - nPos;
            char[] ch = new char[nlength];
            for (int i = 0; i < nlength; i++)
            {
                ch[i] = str[nPos + i];
            }
            return new string(ch);
        }
        public static string Left(string str, int nlength)
        {
            if (str == null || nlength < 0) return "";
            if (str.Length <= Math.Abs(nlength)) return str;
            return Substring(str, 0, nlength);
        }
    }
    #endregion

    #region  list工具
    partial class ListUtils
    {
        static public bool IsNullOrEmpty<T>(List<T> list)
        {
            if (list == null) return true;
            if (list.Count == 0) return true;
            return false;
        }
        static public T Get<T>(List<T> list, int n, T Default)
        {
            T value = Default;
            if (IsNullOrEmpty<T>(list)) return value;
            if (list.Count > n && n >= 0)
                try
                {
                    value = list[n];
                    if (value == null) value = Default;
                }
                catch
                {
                }
            return value;
        }
        static public T Pop<T>(ref List<T> list, T Default = default(T))
        {
            T res = Get<T>(list, 0, Default);
            Remove<T>(ref list, 0);
            return res;
        }
        public static int Remove<T>(ref List<T> list, int n)
        {
            if (IsNullOrEmpty(list))
                return -1;
            if (n < 0 || n > list.Count - 1)
                return -1;
            list.RemoveAt(n);
            return 0;
        }
    }
    #endregion

    # region  ListExtA
    partial class ListExtA<T> : System.Collections.Generic.List<T>
    {
        public void AddAll(List<T> addlist)
        {
            for (int i = 0; i < addlist.Count; i++)
                Add(addlist.ElementAt(i));
        }

        public static T Get(List<T> list, int nIndex = 0)
        {
            if (nIndex >= list.Count || nIndex < 0) return default(T);
            return list.ElementAt(nIndex);
        }
    }
    #endregion
}
