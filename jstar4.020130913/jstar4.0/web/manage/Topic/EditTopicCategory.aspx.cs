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

public partial class manage_Topic_EditTopicCategory : System.Web.UI.Page
{
    public Model.dsTopic.tb_TopicCategoryDataTable TopicCategoryList
    {
        set
        {
            ViewState["EditTopicCategorytb_TopicCategoryDataTable"] = value;
        }
        get
        {
            if (ViewState["EditTopicCategorytb_TopicCategoryDataTable"] == null)
                ViewState["EditTopicCategorytb_TopicCategoryDataTable"] = new Model.dsTopic.tb_TopicCategoryDataTable();
            return (Model.dsTopic.tb_TopicCategoryDataTable)ViewState["EditTopicCategorytb_TopicCategoryDataTable"];
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
        DBLL.clsTopicCategory TopicCategory = new DBLL.clsTopicCategory();
        DataTable dt = new DataTable();
        dt = TopicCategory.sp_selectNormalTableOfAllByTopicCategory(false);
        if (dt != null)
        {
            TopicCategoryList.Merge(dt);
            lvTopicCategoryList.DataSource = TopicCategoryList;
            lvTopicCategoryList.DataBind();
        }
        else
        {
            lvTopicCategoryList.DataSource = null;
            lvTopicCategoryList.DataBind();
        }
    }
    protected void lvTopicCategoryList_PagePropertiesChanged(object sender, EventArgs e)
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

        lvTopicCategoryList.DataSource = TopicCategoryList;
        lvTopicCategoryList.DataBind();
    }
    protected void BtnUpdate_Click(object sender, EventArgs e)
    {
        //判断session
        if (Session["User"] == null || Session["User"].ToString().Length < 1) Response.Redirect(Request.RawUrl);
        try
        {
            if (ValiEdit())
            {
                DBLL.clsTopicCategory TopicCategory = new DBLL.clsTopicCategory();
                DBLL.OptionSysDBLL option = new DBLL.OptionSysDBLL();
                bool _Result = TopicCategory.update_tb_TopicCategoryBynTCategoryID(int.Parse(hfTopicCategoryUpdateID.Value), int.Parse(ddlnTopicID.SelectedValue), txtsTCategoryNameCN.Text, txtsTCategoryNameEN.Text, int.Parse(rblnType.SelectedValue), CKEditorControl1.Text, CKEditorControl2.Text, Session["user"].ToString(), DateTime.Now, true, int.Parse(ddlnSorting.SelectedValue));
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
    protected void lvTopicCategoryList_SelectedIndexChanging(object sender, ListViewSelectEventArgs e)
    {
        Label lblnID = (Label)lvTopicCategoryList.Items[e.NewSelectedIndex].FindControl("lblnTCategoryID");
        int _nID = 0;
        DBLL.clsTopicCategory TopicCategory = new DBLL.clsTopicCategory();
        if (int.TryParse(lblnID.Text.Trim(), out _nID) && _nID > 0)
        {
            MultiView1.ActiveViewIndex = 1;
            DBLL.DBcommon dbcom = new DBLL.DBcommon();
            DataTable Topicdt = dbcom.selectNormalTableofAll(false, "tb_Topic");
            ddlnTopicID.DataSource = Topicdt;
            ddlnTopicID.DataValueField = "nTopicID";
            ddlnTopicID.DataTextField = "sTopicNameCN";
            ddlnTopicID.DataBind();
            DataTable dt = TopicCategory.Select_tb_TopicCategoryBynTCategoryID(_nID);

            ddlnTopicID.SelectedValue = dt.Rows[0]["nTopicID"].ToString();
            txtsTCategoryNameCN.Text = dt.Rows[0]["sTCategoryNameCN"].ToString();
            txtsTCategoryNameEN.Text = dt.Rows[0]["sTCategoryNameEN"].ToString();
            rblnType.SelectedValue = dt.Rows[0]["nType"].ToString();
            if (rblnType.SelectedValue == "1")
            {
                CKEditorControl1.Enabled = true;
                CKEditorControl2.Enabled = true;
            }
            else
            {
                CKEditorControl1.Enabled = false;
                CKEditorControl2.Enabled = false;
            }
            CKEditorControl1.Text = dt.Rows[0]["sContentCN"].ToString();
            CKEditorControl2.Text = dt.Rows[0]["sContentEN"].ToString();
            ddlnSorting.SelectedValue = dt.Rows[0]["nSorting"].ToString();
            hfTopicCategoryUpdateID.Value = _nID.ToString();
        }
    }
    protected void lvTopicCategoryList_ItemDeleting(object sender, ListViewDeleteEventArgs e)
    {
        DBLL.DBcommon dbcom = new DBLL.DBcommon();
        Label lblnID = (Label)lvTopicCategoryList.Items[e.ItemIndex].FindControl("lblnTCategoryID");
        int _nID = 0;
        if (int.TryParse(lblnID.Text.Trim(), out _nID) && _nID > 0)
        {
            hfTopicCategoryUpdateID.Value = _nID.ToString();
        }
        if (hfTopicCategoryUpdateID.Value == "18" || hfTopicCategoryUpdateID.Value == "19" || hfTopicCategoryUpdateID.Value == "20")
        {
            ShowMsg1.InnerContent = "此栏目不能删除!";
            ShowMsg1.Show();
            ReBindPageList();
        }
        else
        {
            dbcom.sp_DeleteNormalTableByID(int.Parse(hfTopicCategoryUpdateID.Value), "tb_TopicCategory");
            TopicCategoryList.Rows.RemoveAt(e.ItemIndex);
            ReBindPageList();
        }
    }
    protected void lvTopicCategoryList_ItemDataBound(object sender, ListViewItemEventArgs e)
    {
        try
        {
            DBLL.OptionSysDBLL option = new DBLL.OptionSysDBLL();
            if (e.Item.ItemType == ListViewItemType.DataItem)
            {
                DBLL.clsTopic Topic = new DBLL.clsTopic();
                int nType = 0;
                Label lblnTopicID = (Label)e.Item.FindControl("lblnTopicID");
                if (int.TryParse(lblnTopicID.Text, out nType))
                {
                    nType = int.Parse(lblnTopicID.Text);
                    string sTopicName = Topic.Select_tb_TopicBynTopicID(nType).Rows[0]["sTopicNameCN"].ToString();
                    lblnTopicID.Text = sTopicName;
                }
                Label lblsTCategoryNameCN = (Label)e.Item.FindControl("lblsTCategoryNameCN");
                if (lblsTCategoryNameCN.Text.Length > 5)
                {
                    lblsTCategoryNameCN.Text = lblsTCategoryNameCN.Text.Substring(0, 5).ToString() + "....";
                }
                Label lblsTCategoryNameEN = (Label)e.Item.FindControl("lblsTCategoryNameEN");
                if (lblsTCategoryNameEN.Text.Length > 6)
                {
                    lblsTCategoryNameEN.Text = lblsTCategoryNameEN.Text.Substring(0, 6).ToString() + "....";
                }
            }
            ImageButton imgDelete = (ImageButton)e.Item.FindControl("imgDelete");
            imgDelete.OnClientClick = "javascript:if (confirm('" + option.GetOptionValue("FormatSetting", "CommandControl", "bIsDelete") + "')){$('#EntryForm').block({ message: null });}else{return false;}";

        }
        catch (Exception)
        {
        }
    }
    protected void btnBackToList_Click(object sender, EventArgs e)
    {
        MultiView1.ActiveViewIndex = 0;
        ReBindPageList();
    }
    protected bool ValiEdit()
    {
        bool bcheck = true;
        ShowMsg1.InnerContent = "";
        if (string.IsNullOrEmpty(txtsTCategoryNameCN.Text))
        {
            ShowMsg1.InnerContent += "栏目(中文)名称不能为空<br/>";
            bcheck = false;
        }
        if (string.IsNullOrEmpty(txtsTCategoryNameEN.Text))
        {
            ShowMsg1.InnerContent += "栏目(英文)名称不能为空<br/>";
            bcheck = false;
        }
        return bcheck;
    }
    protected void rblnType_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (rblnType.SelectedValue == "1")
        {
            CKEditorControl1.Enabled = true;
            CKEditorControl2.Enabled = true;
        }
        else
        {
            CKEditorControl1.Enabled = false;
            CKEditorControl2.Enabled = false;
        }
    }
}