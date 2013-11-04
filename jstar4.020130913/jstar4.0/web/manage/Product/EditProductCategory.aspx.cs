using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Collections;

public partial class manage_Product_EditProductCategory : System.Web.UI.Page
{

    public Model.dsProduct.tb_ProductCategoryDataTable ProductList
    {
        set
        {
            ViewState["EditProductCategorytb_ProductCategoryDataTable"] = value;
        }
        get
        {
            if (ViewState["EditProductCategorytb_ProductCategoryDataTable"] == null)
                ViewState["EditProductCategorytb_ProductCategoryDataTable"] = new Model.dsProduct.tb_ProductCategoryDataTable();
            return (Model.dsProduct.tb_ProductCategoryDataTable)ViewState["EditProductCategorytb_ProductCategoryDataTable"];
        }
    }
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            ReBindPageList();
            DataPager1.PageSize = common.GetGridViewPageCount();
        }
    }
    public void ReBindPageList()
    {
        DBLL.clsProductCategory ProductCategory = new DBLL.clsProductCategory();
        DataTable dt = new DataTable();
        dt = ProductCategory.sp_selectNormalTableOfAllByProductCategory(false);
        if (dt != null)
        {
            ProductList.Merge(dt);
            lvProductCategoryList.DataSource = ProductList;
            lvProductCategoryList.DataBind();
        }
        else
        {
            lvProductCategoryList.DataSource = null;
            lvProductCategoryList.DataBind();
        }
    }
    protected void lvProductCategoryList_PagePropertiesChanged(object sender, EventArgs e)
    {

        DBLL.OptionSysDBLL option = new DBLL.OptionSysDBLL();
        int nPageSize = 0;

        if (int.TryParse(option.GetOptionValue("FormatSetting", "GridViewFormat", "RowsCountDefault"), out nPageSize))
        {
            DataPager1.PageSize = nPageSize;
            DataPager1.SetPageProperties(DataPager1.StartRowIndex, nPageSize, true);
        }
        else
        {
            DataPager1.SetPageProperties(common.GetGridViewPageCount(), nPageSize, true);
        }

        lvProductCategoryList.DataSource = ProductList;
        lvProductCategoryList.DataBind();
    }
    protected void BtnUpdate_Click(object sender, EventArgs e)
    {
        //判断session
        if (Session["User"] == null || Session["User"].ToString().Length < 1) Response.Redirect(Request.RawUrl);
        try
        {
            if (ValiEdit())
            {
                DBLL.clsProductCategory ProductCategory = new DBLL.clsProductCategory();
                DBLL.OptionSysDBLL option = new DBLL.OptionSysDBLL();
                bool _Result = ProductCategory.update_tb_ProductCategoryBynProductCategoryID(int.Parse(hfProductCategoryUpdateID.Value), ddlProductCateTreelist1.nSelectProductCategoryID, txtsProductCategoryNameCN.Text, txtsProductCategoryNameEN.Text, CKEditorControl1.Text, CKEditorControl2.Text, Session["User"].ToString(), DateTime.Now, true, int.Parse(ddlnSorting.SelectedValue));

                if (_Result == true)
                {
                    ShowMsg1.InnerContent = option.GetOptionValue("FormatSetting", "CommandControl", "InsertSuccess");
                    ShowMsg1.Show();
                    MultiView1.ActiveViewIndex = 0;
                    ReBindPageList();
                }
                else
                {
                    ShowMsg1.InnerContent = option.GetOptionValue("FormatSetting", "CommandControl", "InsertFail");
                    ShowMsg1.Show();
                }
            }
        }
        catch (Exception)
        {

            throw;
        }

    }
    protected void lvProductCategoryList_SelectedIndexChanging(object sender, ListViewSelectEventArgs e)
    {
        Label lblnID = (Label)lvProductCategoryList.Items[e.NewSelectedIndex].FindControl("lblnProductCategoryID");
        int _nID = 0;
        DBLL.clsProductCategory ProductCategory = new DBLL.clsProductCategory();
        if (int.TryParse(lblnID.Text.Trim(), out _nID) && _nID > 0)
        {
            DBLL.DBcommon dbcom = new DBLL.DBcommon();
            Model.dsProduct.tb_ProductCategoryDataTable ProductList = new Model.dsProduct.tb_ProductCategoryDataTable();
            ProductList.Merge(dbcom.selectNormalTableofAll(false, "tb_ProductCategory"));
            ddlProductCateTreelist1.ProductList = ProductList;
            ddlProductCateTreelist1.Fresh();

            MultiView1.ActiveViewIndex = 1;
            DataTable dt = ProductCategory.Select_tb_ProductCategoryBynProductCategoryID(_nID);
            txtsProductCategoryNameCN.Text = dt.Rows[0]["sProductCategoryNameCN"].ToString();
            txtsProductCategoryNameEN.Text = dt.Rows[0]["sProductCategoryNameEN"].ToString();
            CKEditorControl1.Text = dt.Rows[0]["sContentCN"].ToString();
            CKEditorControl2.Text = dt.Rows[0]["sContentEN"].ToString();
            lblPCID.Text = dt.Rows[0]["nParentCategoryID"].ToString();
            //ddlProductCateTreelist1.nSelectProductCategoryID = int.Parse(dt.Rows[0]["nParentCategoryID"].ToString());
            ddlProductCateTreelist1.setnSelectID(int.Parse(dt.Rows[0]["nParentCategoryID"].ToString()));
            ddlnSorting.SelectedValue = dt.Rows[0]["nSorting"].ToString();
            hfProductCategoryUpdateID.Value = _nID.ToString();
        }
    }
    protected void lvProductCategoryList_ItemDataBound(object sender, ListViewItemEventArgs e)
    {
        try
        {
            DBLL.OptionSysDBLL option = new DBLL.OptionSysDBLL();
            DBLL.clsProductCategory ProductCategory = new DBLL.clsProductCategory();
            if (e.Item.ItemType == ListViewItemType.DataItem)
            {
                int nType = 0;
                Label lblnParentCategoryID = (Label)e.Item.FindControl("lblnParentCategoryID");
                if (int.TryParse(lblnParentCategoryID.Text, out nType))
                {
                    nType = int.Parse(lblnParentCategoryID.Text);
                    string sTopicName = ProductCategory.Select_tb_ProductCategoryBynProductCategoryID(nType).Rows[0]["sProductCategoryNameCN"].ToString();
                    lblnParentCategoryID.Text = sTopicName;
                }
            }
            ImageButton imgDelete = (ImageButton)e.Item.FindControl("imgDelete");
            imgDelete.OnClientClick = "javascript:if (confirm('" + option.GetOptionValue("FormatSetting", "CommandControl", "bIsDelete") + "')){$('#EntryForm').block({ message: null });}else{return false;}";

        }
        catch (Exception)
        {

        }
    }
    protected void lvProductCategoryList_ItemDeleting(object sender, ListViewDeleteEventArgs e)
    {
        DBLL.DBcommon dbcom = new DBLL.DBcommon();
        Label lblnID = (Label)lvProductCategoryList.Items[e.ItemIndex].FindControl("lblnProductCategoryID");
        int _nID = 0;
        if (int.TryParse(lblnID.Text.Trim(), out _nID) && _nID > 0)
        {
            hfProductCategoryUpdateID.Value = _nID.ToString();
        }
        dbcom.sp_DeleteNormalTableByID(int.Parse(hfProductCategoryUpdateID.Value), "tb_ProductCategory");
        ReBindPageList();
    }
    protected bool ValiEdit()
    {
        bool bcheck = true;
        ShowMsg1.InnerContent = "";
        if (string.IsNullOrEmpty(txtsProductCategoryNameCN.Text))
        {
            ShowMsg1.InnerContent += "类别中文名不能为空<br/>";
            bcheck = false;
        }
        if (string.IsNullOrEmpty(txtsProductCategoryNameEN.Text))
        {
            ShowMsg1.InnerContent += "类别英文名不能为空<br/>";
            bcheck = false;
        }
        return bcheck;
    }
    protected void btnBackToList_Click(object sender, EventArgs e)
    {
        MultiView1.ActiveViewIndex = 0;
        ReBindPageList();
    }
}