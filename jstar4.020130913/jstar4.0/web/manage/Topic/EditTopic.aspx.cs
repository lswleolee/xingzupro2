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

public partial class manage_Topic_EditTopic : System.Web.UI.Page
{

    public Model.dsTopic.tb_TopicDataTable TopicList
    {
        set
        {
            ViewState["EditTopictb_TopicDataTable"] = value;
        }
        get
        {
            if (ViewState["EditTopictb_TopicDataTable"] == null)
                ViewState["EditTopictb_TopicDataTable"] = new Model.dsTopic.tb_TopicDataTable();
            return (Model.dsTopic.tb_TopicDataTable)ViewState["EditTopictb_TopicDataTable"];
        }
    }
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            ReBindPageList();
        }
    }
    protected void lvTopicList_PagePropertiesChanged(object sender, EventArgs e)
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

        lvTopicList.DataSource = TopicList;
        lvTopicList.DataBind();
    }
    public void ReBindPageList()
    {
        DBLL.DBcommon dbcom = new DBLL.DBcommon();
        DataTable dt = new DataTable();
        dt = dbcom.selectNormalTableofAll(false, "tb_Topic");
        if (dt != null)
        {
            TopicList.Merge(dt);
            lvTopicList.DataSource = TopicList;
            lvTopicList.DataBind();
        }
    }
    protected bool ValiEdit()
    {
        bool bcheck = true;
        return bcheck;
    }
    protected void BtnUpdate_Click(object sender, EventArgs e)
    {
        //判断session
        if (Session["User"] == null || Session["User"].ToString().Length < 1) Response.Redirect(Request.RawUrl);
        try
        {
            if (ValiEdit())
            {
                DBLL.clsTopic Topic = new DBLL.clsTopic();
                bool _Result = Topic.update_tb_TopicBynTopicID(int.Parse(hfTopicUpdateID.Value), txtsTopicNameCN.Text, txtsTopicNameEN.Text, Session["user"].ToString(), DateTime.Now, true, int.Parse(ddlnSorting.SelectedValue));
                if (_Result == true)
                {
                    //ShowMsg1.InnerContent = option.GetOptionValue("FormatSetting", "CommandControl", "UpdateSuccess");
                    //ShowMsg1.Show();
                }
                else
                {
                    //失败就一条
                    //ShowMsg1.InnerContent = option.GetOptionValue("FormatSetting", "CommandControl", "UpdateFail");
                    //ShowMsg1.Show();
                }
            }
        }
        catch (Exception)
        {

            throw;
        }
    }
    protected void btnBackToList_Click(object sender, EventArgs e)
    {
        MultiView1.ActiveViewIndex = 0;
        ReBindPageList();
    }
    protected void lvTopicList_ItemDeleting(object sender, ListViewDeleteEventArgs e)
    {
        DBLL.DBcommon dbcom = new DBLL.DBcommon();
        Label lblnID = (Label)lvTopicList.Items[e.ItemIndex].FindControl("lblnTopicID");
        int _nID = 0;
        if (int.TryParse(lblnID.Text.Trim(), out _nID) && _nID > 0)
        {
            hfTopicUpdateID.Value = _nID.ToString();
        }
        dbcom.sp_DeleteNormalTableByID(int.Parse(hfTopicUpdateID.Value), "tb_Topic");
    }
    protected void lvTopicList_ItemDataBound(object sender, ListViewItemEventArgs e)
    {
        try
        {
            DBLL.OptionSysDBLL option = new DBLL.OptionSysDBLL();
            Button btnDelete = (Button)e.Item.FindControl("btnDelete");
            btnDelete.OnClientClick = "javascript:if (confirm('" + option.GetOptionValue("FormatSetting", "CommandControl", "bIsDelete") + "')){$('#EntryForm').block({ message: null });}else{return false;}";

        }
        catch (Exception)
        {
        }
    }
    protected void lvTopicList_SelectedIndexChanging(object sender, ListViewSelectEventArgs e)
    {
        Label lblnID = (Label)lvTopicList.Items[e.NewSelectedIndex].FindControl("lblnTopicID");
        int _nID = 0;
        DBLL.clsTopic Topic = new DBLL.clsTopic();
        if (int.TryParse(lblnID.Text.Trim(), out _nID) && _nID > 0)
        {
            MultiView1.ActiveViewIndex = 1;
            DataTable dt = Topic.Select_tb_TopicBynTopicID(_nID);
            txtsTopicNameCN.Text = dt.Rows[0]["sTopicNameCN"].ToString();
            txtsTopicNameEN.Text = dt.Rows[0]["sTopicNameEN"].ToString();
            ddlnSorting.SelectedValue = dt.Rows[0]["nSorting"].ToString();
            hfTopicUpdateID.Value = _nID.ToString();
        }
    }
}