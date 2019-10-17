using MODEL.EasyUIModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MODEL
{
    public partial class Ou_Permission
    {
        #region 1.0 生成 很纯洁的 实体对象 +Ou_Permission ToPOCO()
        /// <summary>
        /// 生成 很纯洁的 实体对象
        /// </summary>
        /// <returns></returns>
        public Ou_Permission ToPOCO()
        {
            Ou_Permission poco = new Ou_Permission()
            {
                pid = this.pid,
                pParent = this.pParent,
                pName = this.pName,
                pAreaName = this.pAreaName,
                pControllerName = this.pControllerName,
                pActionName = this.pActionName,
                pFormMethod = this.pFormMethod,
                pOperationType = this.pOperationType,
                pIco = this.pIco,
                pOrder = this.pOrder,
                pIsLink = this.pIsLink,
                pLinkUrl = this.pLinkUrl,
                pIsShow = this.pIsShow,
                pRemark = this.pRemark,
                pIsDel = this.pIsDel,
                pAddTime = this.pAddTime
            };
            return poco;
        }
        #endregion

        public TreeNode ToNode()
        {
            TreeNode node = new TreeNode()
            {
                id = this.pid,
                text = this.pName,
                state = "open",
                Checked = false,
                attributes = null,
                children = new List<TreeNode>()
            };
            return node;
        }

        #region 2.0 将 权限集合 转成 树节点集合 +List<MODEL.EasyUIModel.TreeNode> ToTreeNodes(List<Ou_Permission> listPer)
        /// <summary>
        /// 将 权限集合 转成 树节点集合
        /// </summary>
        /// <param name="listPer"></param>
        /// <returns></returns>
        public static List<MODEL.EasyUIModel.TreeNode> ToTreeNodes(List<Ou_Permission> listPer)
        {
            List<MODEL.EasyUIModel.TreeNode> listNodes = new List<EasyUIModel.TreeNode>();
            //生成 树节点时，根据 pid=0的根节点 来生成
            LoadTreeNode(listPer, listNodes, 0);
            return listNodes;
        }
        #endregion

        public static void LoadTreeNode(List<Ou_Permission> listPer,List<TreeNode> listNodes,int pid)
        {
            foreach (var permission in listPer)
            {
                if (permission.pParent == pid)
                {
                    //将 权限转成 树节点
                    TreeNode node = permission.ToNode();
                    listNodes.Add(node);
                    LoadTreeNode(listPer, node.children, node.id);
                }
            }
        }
    }
}
