using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class usercontrol_DataList_TreeListBar : System.Web.UI.UserControl
{
    public Model.dsTopic.tb_TopicCategoryDataTable TopicCateDataTable 
    {
        set { ViewState["TopicCateTreeListBar"] = value; }
        get
        {
            if (ViewState["TopicCateTreeListBar"] == null)
                ViewState["TopicCateTreeListBar"] = new Model.dsTopic.tb_TopicCategoryDataTable();
            return (Model.dsTopic.tb_TopicCategoryDataTable)ViewState["TopicCateTreeListBar"];
        }
    }
    public string RedirectUrl
    {
        set { ViewState["RidectUrlTreeListBar"] = value; }
        get
        {
            if (ViewState["RidectUrlTreeListBar"] == null)
                ViewState["RidectUrlTreeListBar"] = "";
            return (string)ViewState["RidectUrlTreeListBar"];
        }
    }
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            DBLL.clsProductCategory clspdc = new DBLL.clsProductCategory();
            lvProCate.DataSource = TopicCateDataTable;
            lvProCate.DataBind();
        }
    }
    protected void lvProCate_ItemDataBound(object sender, ListViewItemEventArgs e)
    {
        Label lblnID = (Label)e.Item.FindControl("lblnTCategoryID");
        System.Web.UI.HtmlControls.HtmlGenericControl div = (System.Web.UI.HtmlControls.HtmlGenericControl)e.Item.FindControl("TreeListBardivItem");
        LinkButton lbtnsTCategoryNameEN = (LinkButton)e.Item.FindControl("lbtnsTCategoryNameEN");
        LinkButton lbtsTCategoryNameCN = (LinkButton)e.Item.FindControl("lbtsTCategoryNameCN");
        if (Session["languageGlobal"] == "en")
        {
            lbtnsTCategoryNameEN.Visible = true;
            lbtsTCategoryNameCN.Visible = false;
        }
        else
        {
            lbtnsTCategoryNameEN.Visible = false;
            lbtsTCategoryNameCN.Visible = true;
        }

        if (Request["nTCategoryID"] != null && Request["nTCategoryID"].ToString().Length > 0)
        {
            if (lblnID.Text.Trim() == Request["nTCategoryID"].ToString())
            {
                div.Attributes["class"] = "TreeListBardivItemhover";
            }
        }
    }
    protected void lvProCate_SelectedIndexChanging(object sender, ListViewSelectEventArgs e)
    {
        try
        {
          Label lblnTCategoryID=(Label)  lvProCate.Items[e.NewSelectedIndex].FindControl("lblnTCategoryID");
          Response.Redirect(RedirectUrl + "?nTCategoryID="+lblnTCategoryID.Text);
        }
        catch (Exception)
        {
            
            throw;
        }
    }
}