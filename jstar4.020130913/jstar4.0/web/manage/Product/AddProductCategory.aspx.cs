using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class manage_Product_AddProductCategory : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            DBLL.DBcommon dbcom = new DBLL.DBcommon();
            Model.dsProduct.tb_ProductCategoryDataTable ProductList = new Model.dsProduct.tb_ProductCategoryDataTable();
            ProductList.Merge(dbcom.selectNormalTableofAll(false, "tb_ProductCategory"));

            ddlProductCateTreelist1.ProductList = ProductList;
        }
    }
    protected void BtnAdd_Click(object sender, EventArgs e)
    {
        //判断session
        if (Session["User"] == null || Session["User"].ToString().Length < 1) Response.Redirect(Request.RawUrl);
        if (ValiAdd())
        {
            DBLL.clsProductCategory ProductCategory = new DBLL.clsProductCategory();
            DBLL.OptionSysDBLL option = new DBLL.OptionSysDBLL();
            int _Result = ProductCategory.insert_tb_ProductCategory(ddlProductCateTreelist1.nSelectProductCategoryID, txtsProductCategoryNameCN.Text, txtsProductCategoryNameEN.Text, CKEditorControl1.Text, CKEditorControl2.Text, Session["User"].ToString(), DateTime.Now, Session["User"].ToString(), DateTime.Now, true, int.Parse(ddlnSorting.SelectedValue));
            if (_Result > 0)
            {
                ShowMsg1.InnerContent = option.GetOptionValue("FormatSetting", "CommandControl", "InsertSuccess");
                ShowMsg1.Show();
                Clear();
            }
            else
            {
                ShowMsg1.InnerContent = option.GetOptionValue("FormatSetting", "CommandControl", "InsertFail");
                ShowMsg1.Show();
            }
        }
        else
        {
            ShowMsg1.Show();
        }
    }
    protected void BtnClear_Click(object sender, EventArgs e)
    {
        Clear();
    }
    public void Clear()
    {
        txtsProductCategoryNameCN.Text = "";
        txtsProductCategoryNameEN.Text = "";
        CKEditorControl1.Text = "";
        CKEditorControl2.Text = "";
    }
    protected bool ValiAdd()
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
}