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

public partial class manage_Album_EditAlbum : System.Web.UI.Page
{
    public Model.dsTopic.tb_AlbumDataTable AlbumList
    {
        set
        {
            ViewState["EditAlbumtb_AlbumDataTable"] = value;
        }
        get
        {
            if (ViewState["EditAlbumtb_AlbumDataTable"] == null)
                ViewState["EditAlbumtb_AlbumDataTable"] = new Model.dsTopic.tb_AlbumDataTable();
            return (Model.dsTopic.tb_AlbumDataTable)ViewState["EditAlbumtb_AlbumDataTable"];
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
        DBLL.DBcommon dbcom = new DBLL.DBcommon();
        DBLL.clsTopicCategory TopicCategory = new DBLL.clsTopicCategory();
        DataTable TopicCategorydt = TopicCategory.sp_selectNormalTableOfAllByTopicCategoryAndnType(false, 2);
        ddlnTCategoryID.DataSource = TopicCategorydt;
        ddlnTCategoryID.DataValueField = "nTCategoryID";
        ddlnTCategoryID.DataTextField = "sTCategoryNameCN";
        ddlnTCategoryID.DataBind();
        AlbumList.Clear();
        DBLL.clsAlbum Album = new DBLL.clsAlbum();
        DataTable dt = new DataTable();
        dt = Album.sp_selectNormalTableOfAllByAlbum(false, int.Parse(ddlnTCategoryID.SelectedValue));
        if (dt != null)
        {
            AlbumList.Merge(dt);
            lvAlbumList.DataSource = AlbumList;
            lvAlbumList.DataBind();
        }
        else
        {
            lvAlbumList.DataSource = null;
            lvAlbumList.DataBind();
        }
    }
    protected void lvAlbumList_PagePropertiesChanged(object sender, EventArgs e)
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

        lvAlbumList.DataSource = AlbumList;
        lvAlbumList.DataBind();
    }
    //protected void lvTopicCategoryList_SelectedIndexChanging(object sender, ListViewSelectEventArgs e)
    //{
    //    Label lblnID = (Label)lvTopicCategoryList.Items[e.NewSelectedIndex].FindControl("lblnTCategoryID");
    //    int _nID = 0;
    //    DBLL.clsTopicCategory TopicCategory = new DBLL.clsTopicCategory();
    //    if (int.TryParse(lblnID.Text.Trim(), out _nID) && _nID > 0)
    //    {
    //        MultiView1.ActiveViewIndex = 1;
    //        DBLL.DBcommon dbcom = new DBLL.DBcommon();
    //        DataTable Topicdt = dbcom.selectNormalTableofAll(false, "tb_Topic");
    //        ddlnTopicID.DataSource = Topicdt;
    //        ddlnTopicID.DataValueField = "nTopicID";
    //        ddlnTopicID.DataTextField = "sTopicNameCN";
    //        ddlnTopicID.DataBind();
    //        DataTable dt = TopicCategory.Select_tb_TopicCategoryBynTCategoryID(_nID);

    //        ddlnTopicID.SelectedValue = dt.Rows[0]["nTopicID"].ToString();
    //        txtsTCategoryNameCN.Text = dt.Rows[0]["sTCategoryNameCN"].ToString();
    //        txtsTCategoryNameEN.Text = dt.Rows[0]["sTCategoryNameEN"].ToString();
    //        rblnType.SelectedValue = dt.Rows[0]["nType"].ToString();
    //        if (rblnType.SelectedValue == "1")
    //        {
    //            CKEditorControl1.Enabled = true;
    //            CKEditorControl2.Enabled = true;
    //        }
    //        else
    //        {
    //            CKEditorControl1.Enabled = false;
    //            CKEditorControl2.Enabled = false;
    //        }
    //        CKEditorControl1.Text = dt.Rows[0]["sContentCN"].ToString();
    //        CKEditorControl2.Text = dt.Rows[0]["sContentEN"].ToString();
    //        ddlnSorting.SelectedValue = dt.Rows[0]["nSorting"].ToString();
    //        hfTopicCategoryUpdateID.Value = _nID.ToString();
    //    }
    //}
    protected void lvAlbumList_ItemDeleting(object sender, ListViewDeleteEventArgs e)
    {
        DBLL.clsAlbum Album = new DBLL.clsAlbum();
        Label lblnID = (Label)lvAlbumList.Items[e.ItemIndex].FindControl("lblnAlbumID");
        int _nID = 0;
        if (int.TryParse(lblnID.Text.Trim(), out _nID) && _nID > 0)
        {
            bool Result = Album.sp_DeleteNormalTableByIDAlbum(int.Parse(_nID.ToString()), "tb_Album");
            if (Result)
            {
                //判断文件是不是存在
                Image ImsImagePath = (Image)lvAlbumList.Items[e.ItemIndex].FindControl("ImsImagePath");
                string sSaveFolderFullPath = Server.MapPath(ImsImagePath.ImageUrl);
                if (File.Exists(sSaveFolderFullPath))
                {
                    //如果存在则删除
                    File.Delete(sSaveFolderFullPath);
                }
            }
        }
        ReBindPageList();
    }
    protected void lvAlbumList_ItemDataBound(object sender, ListViewItemEventArgs e)
    {
        try
        {
            DBLL.OptionSysDBLL option = new DBLL.OptionSysDBLL();
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
        return bcheck;
    }
    protected void ddlnTCategoryID_SelectedIndexChanged(object sender, EventArgs e)
    {
        AlbumList.Clear();
        DBLL.clsAlbum Album = new DBLL.clsAlbum();
        DataTable dt = new DataTable();
        dt = Album.sp_selectNormalTableOfAllByAlbum(false, int.Parse(ddlnTCategoryID.SelectedValue));
        if (dt != null)
        {
            AlbumList.Merge(dt);
            lvAlbumList.DataSource = AlbumList;
            lvAlbumList.DataBind();
        }
        else
        {
            lvAlbumList.DataSource = null;
            lvAlbumList.DataBind();
        }
    }
}