using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MultTree.MultTreeNodeStruct;


namespace MultTree.CalculateMultTreeNodeName
{
    #region  计算节点系统名
    /// <summary>
    /// 计算MultTree的节点名
    /// </summary>
   public static class CalculateMultTreeNodeName
    {
        #region 计算节点系统名称
        /// <summary>
        /// 计算节点的系统名称
        /// </summary>
        /// <param name="str_1">节点系统名的前缀</param>
        /// <param name="trn_Parent">传入父节点</param>
        /// <returns>返回节点的系统名</returns>
       public static string CalculateNodeName(string str_1, MultTree.MultTreeNodeStruct.IMultTreeNode trn_Parent)
        {
            List<MultTreeNode> PARENT;
            //TreeNode trn_Parent;
            int n, max;
            string name, nameold;

            // namenew = null;//先赋值
            name = str_1;//节点系统名
            //text = str;//节点的text

            //dianqian = trn.Name;//当前节点名称
            PARENT = trn_Parent.ChildList;//父节点的集合
            // trn_Parent = trn.Parent;//获取父节点

            //  fulv = trn.Name;
            n = PARENT.Count;//父节点包含多小个节点

            max = 0;

            for (int z = 1; z < n + 1; z++)//确定要添加工具的最大个数
            {
                name = str_1 + "_" + z.ToString();
                for (int zz = 0; zz < n; zz++)
                {
                    nameold = trn_Parent.ChildList[zz].SelfId;
                    if (name == nameold)
                    {
                        max = z;
                        // namenew = nameold;
                    }
                }
            }

            if (max == 0)//确定要添加step对应节点的名字
            {
                name = str_1 + "_" + '1';
            }
            else
            {
                //zuihou = namenew.Substring(namenew.Length - 1, 1);
                //int.TryParse(zuihou, out n);
                //n++;
                max += 1;
                name = str_1 + "_" + max.ToString();
            }
            return name;
        }
        #endregion

        #region  判断节点路径是否存在
       /// <summary>
       /// 判断节点路径是否存在
       /// </summary>
       /// <param name="jieDianLuJing"></param>
       /// <returns></returns>
       public static bool PanDuanFuJieDianShiFoCunZai(string jieDianLuJing)
       {
           bool ok = false;

           string[] str_Jie = jieDianLuJing.Split('>');

           IMultTreeNode mu_ = MultTree.TreeStatic.Root;
          
           bool run = true;
           
           for (int i = 0; i < str_Jie.Length && run == true; i++)
           {              
                   mu_ = mu_.findNodeById(str_Jie[i]);
                   if (mu_ == null)
                   {
                       run = false;
                   }             
           }
           if (run == true)
           {
               ok = true;
           }
               return ok;
       }

        #endregion
    }
    #endregion
}
