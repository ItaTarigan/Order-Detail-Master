﻿using BalitTanahPelayanan.Helpers;
using BalitTanahPelayanan.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BalitTanahPelayanan.Usercontrols
{
    public partial class OrderNavigation : System.Web.UI.UserControl
    {
        static List<ordernavigationtbl> CacheData;
        public enum NavigationMode { TreeNav, ButtonNav };
        public NavigationMode Mode { get; set; }
        public delegate void ExitNavigation();
        public event ExitNavigation exitNavigation;

        public delegate void ComoditySelected(int commodityNo, string commodityName);
        public event ComoditySelected comoditySelected;
        public int CurrentParentId
        {
            get
            {
                if (ViewState["CurParent"] == null)
                {
                    ViewState["CurParent"] = -1;
                }
                return (int)ViewState["CurParent"];
            }
            set
            {
                ViewState["CurParent"] = value;
            }
        }
        public void Reset()
        {
            if (Mode == NavigationMode.TreeNav)
            {
               
            }
            else
            {
                CurrentParentId = -1;
                LoadButton();
            }
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (CacheData == null)
            {
                using (var db = new smlpobDB())
                {
                    CacheData = (from x in db.ordernavigationtbls
                                 select x).ToList();
                }
            }
            LitCommodity.Text = LanguageHelper.GetTranslation("choose_a_comodity");
            BtnExit.Text = LanguageHelper.GetTranslation("back");
            RptButton.ItemCommand += RptButton_ItemCommand;
            BtnExit.Click += BtnExit_Click;
            TreeNav.SelectedNodeChanged += TreeNav_SelectedNodeChanged;
            if (!IsPostBack)
            {
                if (Mode == NavigationMode.TreeNav)
                {
                    TreePanel.Visible = true;
                    ButtonPanel.Visible = false;
                    LoadTree();
                }
                else
                {
                    TreePanel.Visible = false;
                    ButtonPanel.Visible = true;
                    CurrentParentId = -1;
                    LoadButton();
                }
            }
        }

        private void RptButton_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            if (e.CommandName == "Select")
            {
                var btn = source as Button;
                int.TryParse(e.CommandArgument.ToString(), out var nodeId);
                using(var db = new smlpobDB())
                {
                    var selNode = CacheData.Where(x => x.id == nodeId).FirstOrDefault();
                    if (selNode != null)
                    {
                        if (selNode.commodityNo == 0 && selNode.isLeaf!="1")
                        {
                            CurrentParentId = selNode.id;
                            LoadButton();
                        }
                        else
                        {
                            comoditySelected?.Invoke(selNode.commodityNo, selNode.name);
                        }
                    }
                }
                
            }
        }

        void LoadButton()
        {
            //using (smlpobDB db = new smlpobDB())
            {
                var childs = from x in CacheData
                             where x.parentId == CurrentParentId
                             select new { Id = x.id, CommodityName = x.name };
                RptButton.DataSource = childs.ToList();
                RptButton.DataBind();
            }
        }
        private void BtnExit_Click(object sender, EventArgs e)
        {
            exitNavigation?.Invoke();
        }

        private void TreeNav_SelectedNodeChanged(object sender, EventArgs e)
        {
            var tree1 = sender as TreeView;
            var node = tree1.SelectedNode;
            if (node != null)
            {
                int.TryParse(node.Value, out var valNode);
                if (valNode == 0) return;
                comoditySelected?.Invoke(int.Parse(node.Value), node.Text);
            }
        }

        void LoadTree()
        {
            TreeNode root = new TreeNode("Pelayanan","0");
            TraverseTree(root, -1);
            TreeNav.Nodes.Clear();
            TreeNav.Nodes.Add(root);
        }

        void TraverseTree(TreeNode ParentNode, int ParentId)
        {
            //using(smlpobDB db = new smlpobDB())
            {
                var childs = from x in CacheData
                             where x.parentId == ParentId
                             select x;
                foreach(var item in childs)
                {
                    var childNode = new TreeNode(item.name, item.commodityNo.ToString());
                    ParentNode.ChildNodes.Add(childNode);
                    TraverseTree(childNode, item.id);
                }
            }
        }
    }
}