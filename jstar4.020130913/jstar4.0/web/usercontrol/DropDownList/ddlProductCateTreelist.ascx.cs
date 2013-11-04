using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class usercontrol_DropDownList_ddlProductCateTreelist : System.Web.UI.UserControl
{
    public Model.dsProduct.tb_ProductCategoryDataTable ProductList
    {
        set
        {
            ViewState["ddlProductCateTreelistCategoryDataTable"] = value;
        }
        get
        {
            if (ViewState["ddlProductCateTreelistCategoryDataTable"] == null)
                ViewState["ddlProductCateTreelistCategoryDataTable"] = new Model.dsProduct.tb_ProductCategoryDataTable();
            return (Model.dsProduct.tb_ProductCategoryDataTable)ViewState["ddlProductCateTreelistCategoryDataTable"];
        }
    }
    public int bHaveRoot
    {
        set
        {
            ViewState["ddlProductCateTreelistbHaveRoot"] = value;
        }
        get
        {
            if (ViewState["ddlProductCateTreelistbHaveRoot"] == null)
                ViewState["ddlProductCateTreelistbHaveRoot"] = 1;
            return (int)ViewState["ddlProductCateTreelistbHaveRoot"];
        }
    }
    public int nSelectProductCategoryID
    {
        set
        {
            ViewState["ddlProductCateTreelistnSelectProductCategoryID"] = value;
        }
        get
        {
            if (ViewState["ddlProductCateTreelistnSelectProductCategoryID"] == null)
                ViewState["ddlProductCateTreelistnSelectProductCategoryID"] = 0;
            return (int)ViewState["ddlProductCateTreelistnSelectProductCategoryID"];
        }
    }
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            Fresh();
        }
    }
    protected void TreeView1_SelectedNodeChanged(object sender, EventArgs e)
    {
        try
        {
            int _nTempID = 0;
            if (int.TryParse(TreeView1.SelectedValue, out _nTempID))
            {
                nSelectProductCategoryID = _nTempID;
                txtProducCateID.Text = TreeView1.SelectedNode.Text;
            }
            PnlTreeList.Attributes["display"] = "none";

        }
        catch (Exception)
        {
            
            throw;
        }
    }
    public void Fresh()
    {
        PnlTreeList.Attributes["display"] = "none";
        txtProducCateID.Text = nSelectProductCategoryID.ToString();
        if (ProductList != null && ProductList.Rows.Count > 0)
        {
            if (Session["languageGlobal"] != null && Session["languageGlobal"] == "en")
            {
                BLL.TreeViewFromTableBLL tvftbll = new BLL.TreeViewFromTableBLL();

                tvftbll.nRootParentID = 0;
                tvftbll.NodeValueColumnName = ProductList.nProductCategoryIDColumn.ColumnName;
                tvftbll.NodeTextColumnName = ProductList.sProductCategoryNameENColumn.ColumnName;
                tvftbll.FatherIDColumnName = ProductList.nParentCategoryIDColumn.ColumnName;
                TreeNode[] nodes = tvftbll.GetTreeNodes(ProductList);
                TreeView1.Nodes.Clear();
                if (bHaveRoot == 1)
                {
                    TreeNode noderoot = new TreeNode();
                    noderoot.Text = "All Product";
                    noderoot.Value = "0";
                    for (int i = 0; i < nodes.Length; i++)
                    {

                        noderoot.ChildNodes.Add(nodes[i]);
                    }
                    TreeView1.Nodes.Add(noderoot);
                }
                else
                {
                    for (int i = 0; i < nodes.Length; i++)
                    {

                        TreeView1.Nodes.Add(nodes[i]);
                    }
                }
            }
            else
            {
                BLL.TreeViewFromTableBLL tvftbll = new BLL.TreeViewFromTableBLL();

                tvftbll.nRootParentID = 0;
                tvftbll.NodeValueColumnName = ProductList.nProductCategoryIDColumn.ColumnName;
                tvftbll.NodeTextColumnName = ProductList.sProductCategoryNameCNColumn.ColumnName;
                tvftbll.FatherIDColumnName = ProductList.nParentCategoryIDColumn.ColumnName;
                TreeNode[] nodes = tvftbll.GetTreeNodes(ProductList);
                TreeView1.Nodes.Clear();
                if (bHaveRoot == 1)
                {
                    TreeNode noderoot = new TreeNode();
                    noderoot.Text = "所有产品";
                    noderoot.Value = "0";
                    for (int i = 0; i < nodes.Length; i++)
                    {

                        noderoot.ChildNodes.Add(nodes[i]);
                    }
                    TreeView1.Nodes.Add(noderoot);
                }
                else
                {
                    for (int i = 0; i < nodes.Length; i++)
                    {

                        TreeView1.Nodes.Add(nodes[i]);
                    }
                }
            }
            TreeView1.ExpandAll();
        }
    }
    public void setnSelectID(int nSelectPCID)
    {
        nSelectProductCategoryID = nSelectPCID;
        DBLL.clsProductCategory clspc = new DBLL.clsProductCategory();
        Model.dsProduct.tb_ProductCategoryDataTable pcdt = new Model.dsProduct.tb_ProductCategoryDataTable();
        if (pcdt != null && pcdt.Rows.Count > 0)
        {
            pcdt.Merge(clspc.Select_tb_ProductCategoryBynProductCategoryID(nSelectPCID));
            txtProducCateID.Text = pcdt.Rows[0]["sProductCategoryNameCN"].ToString();
        }
        else
        {
            txtProducCateID.Text = "没有上级产品类";
        }
    }
}