using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
namespace BLL
{
    public class TreeViewFromTableBLL
    {
        public DataTable dtSource = new DataTable();
        public string FatherIDColumnName = "";
        public string NodeTextColumnName = "";
        public string NodeValueColumnName = "";
        public string NodebIsClickColumnName = "";
        public string NavigateUrlColumnName = "";
        public bool bIsClick = false;
        public string RootNodeText = "";
        public int nRootParentID = 0;

        public TreeViewFromTableBLL()
        {
            dtSource = new DataTable();
            FatherIDColumnName = "";
            NodeTextColumnName = "";
            NodeValueColumnName = "";
            NodebIsClickColumnName = "";
            NavigateUrlColumnName = "";
            bIsClick = false;
        }
        public TreeNode[] GetTreeNodes(DataTable dt)
        {
            try
            {
                dtSource = dt;
               

                return BindMenuItems(nRootParentID);
            }


            catch (Exception)
            {

                throw;
            }
        }

        public TreeNode GetRootTreeNode(DataTable dt)
        {
            try
            {
                dtSource = dt;
                TreeNode noderoot = new TreeNode();
                noderoot.Value = nRootParentID.ToString();
                noderoot.Text = RootNodeText;

                return BindMenuItems(noderoot, nRootParentID);
            }


            catch (Exception)
            {

                throw;
            }
        }
        //************************
        private TreeNode[] BindMenuItems( int nParentID)
        {
            //************************

            int _nMenuValue = 0;


            bool _bIsClick = false;
            bool _bIsPopup = false;
         
            DataRow[] _drs;
           
            //************************
            try
            {
                _drs = dtSource.Select(FatherIDColumnName + " = " + nParentID);
                TreeNode[] nodes = new TreeNode[_drs.Length];
                for (int i = 0; i < _drs.Length; i++) 
                {
                    DataRow dr = _drs[i];
                    nodes[i] = new TreeNode();

                    if (dtSource.Columns.IndexOf(NodeTextColumnName) >= 0)
                    {
                              nodes[i].Text = dr[NodeTextColumnName].ToString();
                    }
                    else nodes[i].Text = "null";


                    if (dtSource.Columns.IndexOf(NodeValueColumnName) >= 0)
                    {
                        int.TryParse(dr[NodeValueColumnName].ToString(), out _nMenuValue);
                        nodes[i].Value = _nMenuValue.ToString();
                    }

                    if (dtSource.Columns.IndexOf(NodebIsClickColumnName) >= 0)
                    {
                        bool.TryParse(dr[NodebIsClickColumnName].ToString(), out _bIsClick);

                    }

                    if (bIsClick == true)
                    {

                        nodes[i].NavigateUrl = "ProductList.aspx?nSelelctProductCateID=" + dr[NodeValueColumnName].ToString();
                    }


                    if (_bIsPopup)
                    {
                        nodes[i].Target = "_blank";
                    }
                    AddChildMenu(nodes[i], _nMenuValue);
                }

                return nodes;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        //************************
        private TreeNode BindMenuItems(TreeNode noderoot, int nParentID)
        {
            //************************

            int _nMenuValue = 0;


            bool _bIsClick = false;
            bool _bIsPopup = false;

            DataRow[] _drs;
            TreeNode _miNode;
            //************************
            try
            {
                _drs = dtSource.Select(FatherIDColumnName + " = " + nParentID);

                foreach (DataRow dr in _drs)
                {
                    _miNode = new TreeNode();

                    if (dtSource.Columns.IndexOf(NodeTextColumnName) >= 0)
                    {
                        _miNode.Text = dr[NodeTextColumnName].ToString();
                    }
                    else _miNode.Text = "null";


                    if (dtSource.Columns.IndexOf(NodeValueColumnName) >= 0)
                    {
                        int.TryParse(dr[NodeValueColumnName].ToString(), out _nMenuValue);
                        _miNode.Value = _nMenuValue.ToString();
                    }

                    if (dtSource.Columns.IndexOf(NodebIsClickColumnName) >= 0)
                    {
                        bool.TryParse(dr[NodebIsClickColumnName].ToString(), out _bIsClick);

                    }

                    if (bIsClick == true )
                    {

                        _miNode.NavigateUrl = "ProductList.aspx?nSelelctProductCateID=" + dr[NodeValueColumnName].ToString();
                    }


                    if (_bIsPopup)
                    {
                        _miNode.Target = "_blank";
                    }
                    //TreeView2.Nodes.AddAt(0,_miNode);
                    noderoot.ChildNodes.Add(_miNode);
                    //Menu1.Items.Add(_miNode);
                    AddChildMenu(_miNode, _nMenuValue);
                }

                return noderoot;
            }
            catch (Exception ex)
            {
                return noderoot;
            }
        }
        //************************
        private void AddChildMenu(TreeNode miNode, int nParentID)
        {
            //************************

            int _nMenuValue = 0;


            bool _bIsClick = false;
            bool _bIsPopup = false;

            DataRow[] _drs;
            TreeNode _miNode;
            //************************
            try
            {
                _drs = dtSource.Select(FatherIDColumnName + " = " + nParentID);

                foreach (DataRow dr in _drs)
                {
                    _miNode = new TreeNode();

                    if (dtSource.Columns.IndexOf(NodeTextColumnName) >= 0)
                    {
                        _miNode.Text = dr[NodeTextColumnName].ToString();
                    }
                    else _miNode.Text = "null";


                    if (dtSource.Columns.IndexOf(NodeValueColumnName) >= 0)
                    {
                        int.TryParse(dr[NodeValueColumnName].ToString(), out _nMenuValue);
                        _miNode.Value = _nMenuValue.ToString();
                    }

                    if (dtSource.Columns.IndexOf(NodebIsClickColumnName) >= 0)
                    {
                        bool.TryParse(dr[NodebIsClickColumnName].ToString(), out _bIsClick);

                    }

                    if (bIsClick == true)
                    {

                        _miNode.NavigateUrl = "ProductList.aspx?nSelelctProductCateID=" + dr[NodeValueColumnName].ToString();
                    }


                    if (_bIsPopup)
                    {
                        _miNode.Target = "_blank";
                    }
                    //TreeView2.Nodes.Add(_miNode);
                    miNode.ChildNodes.Add(_miNode);
                    //Menu1.Items.Add(_miNode);
                    AddChildMenu(_miNode, _nMenuValue);
                }
            }
            catch (Exception ex)
            {

            }
        }
    }
}
