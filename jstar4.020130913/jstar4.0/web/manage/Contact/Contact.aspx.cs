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

public partial class manage_Contact_Contact : System.Web.UI.Page
{

    public Model.dsTopic.tb_ContactDataTable ContactList
    {
        set
        {
            ViewState["Contacttb_ContactDataTable"] = value;
        }
        get
        {
            if (ViewState["Contacttb_ContactDataTable"] == null)
                ViewState["Contacttb_ContactDataTable"] = new Model.dsTopic.tb_ContactDataTable();
            return (Model.dsTopic.tb_ContactDataTable)ViewState["Contacttb_ContactDataTable"];
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
    protected void lvContactList_PagePropertiesChanged(object sender, EventArgs e)
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

        lvContactList.DataSource = ContactList;
        lvContactList.DataBind();
    }
    public void ReBindPageList()
    {
        DBLL.clsContact Contact = new DBLL.clsContact();
        DataTable dt = new DataTable();
        dt = Contact.sp_selectNormalTableOfAllByContact(false);
        if (dt != null)
        {
            ContactList.Merge(dt);
            lvContactList.DataSource = ContactList;
            lvContactList.DataBind();
        }
        else
        {
            lvContactList.DataSource = null;
            lvContactList.DataBind();
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
            //if (ValiEdit())
            //{
                DBLL.clsContact Contact = new DBLL.clsContact();
                DBLL.OptionSysDBLL option = new DBLL.OptionSysDBLL();
                bool _Result = Contact.update_tb_ContactBynContactID(int.Parse(hfContactListUpdateID.Value), txtsTitle.Text,txtsName.Text,txtsCompanyName.Text,txtsAddress.Text,txtsEmail.Text,txtsFax.Text,txtsPhone.Text,txtsContents.Text, Session["user"].ToString(), DateTime.Now, true, 0,true);
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
            //}
        }
        catch (Exception)
        {

            throw;
        }
    }
    //protected bool ValiEdit()
    //{
    //    bool bcheck = true;
    //    ShowMsg1.InnerContent = "";
    //    if (string.IsNullOrEmpty(txtsLink.Text))
    //    {
    //        ShowMsg1.InnerContent += "联系不能为空<br/>";
    //        bcheck = false;
    //    }
    //    return bcheck;
    //}
    protected void lvContactList_ItemDataBound(object sender, ListViewItemEventArgs e)
    {
        try
        {
            if (e.Item.ItemType == ListViewItemType.DataItem)
            {
                Label lblsTitle = (Label)e.Item.FindControl("lblsTitle");
                if (lblsTitle.Text.Length > 8)
                {
                    lblsTitle.Text = lblsTitle.Text.Substring(0, 8).ToString() + "....";
                }
                Label lblsContents = (Label)e.Item.FindControl("lblsContents");
                if (lblsContents.Text.Length > 8)
                {
                    lblsContents.Text = lblsContents.Text.Substring(0, 16).ToString() + "....";
                }
            }
            //DBLL.OptionSysDBLL option = new DBLL.OptionSysDBLL();
            //ImageButton imgDelete = (ImageButton)e.Item.FindControl("imgDelete");
            //imgDelete.OnClientClick = "javascript:if (confirm('" + option.GetOptionValue("FormatSetting", "CommandControl", "bIsDelete") + "')){$('#EntryForm').block({ message: null });}else{return false;}";

        }
        catch (Exception)
        {
        }
    }
    //protected void lvContactList_ItemDeleting(object sender, ListViewDeleteEventArgs e)
    //{
    //    DBLL.DBcommon dbcom = new DBLL.DBcommon();
    //    Label lblnID = (Label)lvContactList.Items[e.ItemIndex].FindControl("lblnLinkID");
    //    int _nID = 0;
    //    if (int.TryParse(lblnID.Text.Trim(), out _nID) && _nID > 0)
    //    {
    //        hfContactUpdateID.Value = _nID.ToString();
    //    }
    //    dbcom.sp_DeleteNormalTableByID(int.Parse(hfContactUpdateID.Value), "tb_Link");
    //    ReBindPageList();
    //}
    protected void lvContactListt_SelectedIndexChanging(object sender, ListViewSelectEventArgs e)
    {
        Label lblnID = (Label)lvContactList.Items[e.NewSelectedIndex].FindControl("lblnContactID");
        int _nID = 0;
        DBLL.clsContact Contact = new DBLL.clsContact();
        if (int.TryParse(lblnID.Text.Trim(), out _nID) && _nID > 0)
        {
            MultiView1.ActiveViewIndex = 1;
            DataTable dt = Contact.Select_tb_ContactBynContactID(_nID);
            txtsTitle.Text = dt.Rows[0]["sTitle"].ToString();
            txtsName.Text = dt.Rows[0]["sName"].ToString();
            txtsCompanyName.Text = dt.Rows[0]["sCompanyName"].ToString();
            txtsAddress.Text = dt.Rows[0]["sAddress"].ToString();
            txtsEmail.Text = dt.Rows[0]["sEmail"].ToString();
            txtsFax.Text = dt.Rows[0]["sFax"].ToString();
            txtsPhone.Text = dt.Rows[0]["sPhone"].ToString();
            txtsContents.Text = dt.Rows[0]["sContents"].ToString(); 
            hfContactListUpdateID.Value = _nID.ToString();
        }
    }
}