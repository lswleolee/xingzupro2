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

public partial class manage_Link_EditLink : System.Web.UI.Page
{

    public Model.dsLink.tb_LinkDataTable LinkList
    {
        set
        {
            ViewState["EditLinktb_LinkDataTable"] = value;
        }
        get
        {
            if (ViewState["EditLinktb_LinkDataTable"] == null)
                ViewState["EditLinktb_LinkDataTable"] = new Model.dsLink.tb_LinkDataTable();
            return (Model.dsLink.tb_LinkDataTable)ViewState["EditLinktb_LinkDataTable"];
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
    protected void lvLinkList_PagePropertiesChanged(object sender, EventArgs e)
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

        lvLinkList.DataSource = LinkList;
        lvLinkList.DataBind();
    }
    public void ReBindPageList()
    {
        DBLL.clsLink Link = new DBLL.clsLink();
        DataTable dt = new DataTable();
        dt = Link.sp_selectNormalTableOfAllByLink(false);
        if (dt != null)
        {
            LinkList.Merge(dt);
            lvLinkList.DataSource = LinkList;
            lvLinkList.DataBind();
        }
        else
        {
            lvLinkList.DataSource = null;
            lvLinkList.DataBind();
        }
    }
    protected void btnBackToList_Click(object sender, EventArgs e)
    {
        MultiView1.ActiveViewIndex = 0;
        ReBindPageList();
    }
    protected void BtnUpdate_Click(object sender, EventArgs e)
    {
        //判断session
        if (Session["User"] == null || Session["User"].ToString().Length < 1) Response.Redirect(Request.RawUrl);
        try
        {
            if (ValiEdit())
            {
                DBLL.clsLink Link = new DBLL.clsLink();
                DBLL.OptionSysDBLL option = new DBLL.OptionSysDBLL();
                
                string sThumbPath = "";
                if (int.Parse(ddlnType.SelectedValue) == 1)
                    sThumbPath = "~/style/images/thumb/Msn.png";
                else if (int.Parse(ddlnType.SelectedValue) == 2)
                    sThumbPath = "~/style/images/thumb/Email.png";
                else if (int.Parse(ddlnType.SelectedValue) == 3)
                    sThumbPath = "~/style/images/thumb/Skype.png";
                else if (int.Parse(ddlnType.SelectedValue) == 4)
                    sThumbPath = "~/style/images/thumb/QQ.png";

                bool _Result = Link.update_tb_LinkBynLinkID(int.Parse(hfLinkUpdateID.Value), ddlnType.Text, sThumbPath, txtsLink.Text, Session["user"].ToString(), DateTime.Now, true, int.Parse(ddlnSorting.SelectedValue));
                if (_Result == true)
                {
                    ShowMsg1.InnerContent = option.GetOptionValue("FormatSetting", "CommandControl", "UpdateSuccess");
                    ShowMsg1.Show();
                    MultiView1.ActiveViewIndex = 0;
                    ReBindPageList();
                }
                else
                {
                    //失败就一条
                    ShowMsg1.InnerContent = option.GetOptionValue("FormatSetting", "CommandControl", "UpdateFail");
                    ShowMsg1.Show();
                }
            }
        }
        catch (Exception)
        {

            throw;
        }
    }
    protected bool ValiEdit()
    {
        bool bcheck = true;
        ShowMsg1.InnerContent = "";
        if (string.IsNullOrEmpty(txtsLink.Text))
        {
            ShowMsg1.InnerContent += "联系不能为空<br/>";
            bcheck = false;
        }
        return bcheck;
    }
    protected void lvLinkList_ItemDataBound(object sender, ListViewItemEventArgs e)
    {
        try
        {
            if (e.Item.ItemType == ListViewItemType.DataItem)
            {
                Label lblnType = (Label)e.Item.FindControl("lblnType");
                if (int.Parse(lblnType.Text) == 1)
                    lblnType.Text = "MSN";
                else if (int.Parse(lblnType.Text) == 2)
                    lblnType.Text = "EMAIL";
                else if (int.Parse(lblnType.Text) == 3)
                    lblnType.Text = "Skype";
                else if (int.Parse(lblnType.Text) == 4)
                    lblnType.Text = "QQ";
            }
            DBLL.OptionSysDBLL option = new DBLL.OptionSysDBLL();
            ImageButton imgDelete = (ImageButton)e.Item.FindControl("imgDelete");
            imgDelete.OnClientClick = "javascript:if (confirm('" + option.GetOptionValue("FormatSetting", "CommandControl", "bIsDelete") + "')){$('#EntryForm').block({ message: null });}else{return false;}";

        }
        catch (Exception)
        {
        }
    }
    protected void lvLinkList_ItemDeleting(object sender, ListViewDeleteEventArgs e)
    {
        DBLL.DBcommon dbcom = new DBLL.DBcommon();
        Label lblnID = (Label)lvLinkList.Items[e.ItemIndex].FindControl("lblnLinkID");
        int _nID = 0;
        if (int.TryParse(lblnID.Text.Trim(), out _nID) && _nID > 0)
        {
            hfLinkUpdateID.Value = _nID.ToString();
        }
        dbcom.sp_DeleteNormalTableByID(int.Parse(hfLinkUpdateID.Value), "tb_Link");
        ReBindPageList();
    }
    protected void lvLinkList_SelectedIndexChanging(object sender, ListViewSelectEventArgs e)
    {
        Label lblnID = (Label)lvLinkList.Items[e.NewSelectedIndex].FindControl("lblnLinkID");
        int _nID = 0;
        DBLL.clsLink Link = new DBLL.clsLink();
        if (int.TryParse(lblnID.Text.Trim(), out _nID) && _nID > 0)
        {
            MultiView1.ActiveViewIndex = 1;
            DataTable dt = Link.Select_tb_LinkBynLinkID(_nID);
            ddlnType.Text = dt.Rows[0]["nType"].ToString();
            txtsLink.Text = dt.Rows[0]["sLink"].ToString();
            ddlnSorting.SelectedValue = dt.Rows[0]["nSorting"].ToString();
            hfLinkUpdateID.Value = _nID.ToString();
        }
    }
}