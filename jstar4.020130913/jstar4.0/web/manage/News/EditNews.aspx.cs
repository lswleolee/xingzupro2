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

public partial class manage_News_EditNews : System.Web.UI.Page
{
    public Model.dsTopic.tb_NewsDataTable NewsList
    {
        set
        {
            ViewState["EditNewstb_NewsDataTable"] = value;
        }
        get
        {
            if (ViewState["EditNewstb_NewsDataTable"] == null)
                ViewState["EditNewstb_NewsDataTable"] = new Model.dsTopic.tb_NewsDataTable();
            return (Model.dsTopic.tb_NewsDataTable)ViewState["EditNewstb_NewsDataTable"];
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
        DBLL.clsNews News = new DBLL.clsNews();
        DataTable dt = new DataTable();
        dt = News.sp_selectNormalTableOfAllByNews(false);
        if (dt != null)
        {
            NewsList.Merge(dt);
            lvNewsList.DataSource = NewsList;
            lvNewsList.DataBind();
        }
        else
        {
            lvNewsList.DataSource = null;
            lvNewsList.DataBind();
        }
    }
    protected void lvNewsList_PagePropertiesChanged(object sender, EventArgs e)
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

        lvNewsList.DataSource = NewsList;
        lvNewsList.DataBind();
    }
    protected void BtnUpdate_Click(object sender, EventArgs e)
    {
        //判断session
        if (Session["User"] == null || Session["User"].ToString().Length < 1) Response.Redirect(Request.RawUrl);
        try
        {
            if (ValiEdit())
            {
                DBLL.clsNews News = new DBLL.clsNews();
                DBLL.OptionSysDBLL option = new DBLL.OptionSysDBLL();
                bool _Result = false;
                MutileUploaderUserControl3.sNewName = txtsTitle.Text;
                MutileUploaderUserControl3.SavePath();
                if (MutileUploaderUserControl3.filepathlist.Count > 0)
                {
                    for (int i = 0; i < MutileUploaderUserControl3.filepathlist.Count; i++)
                    {
                        _Result = News.update_tb_NewsBynNewsID(int.Parse(hfNewsUpdateID.Value), int.Parse(ddlnTCategoryID.SelectedValue), int.Parse(rblnLangType.SelectedValue), txtsTitle.Text, txtsAuthor.Text, MutileUploaderUserControl3.filepathlist[i].ToString(), CKEditorControl1.Text, Session["user"].ToString(), DateTime.Now, true, int.Parse(ddlnSorting.SelectedValue));
                    }
                }
                else
                {
                    if (Image3.ImageUrl != "")
                    {
                        _Result = News.update_tb_NewsBynNewsID(int.Parse(hfNewsUpdateID.Value), int.Parse(ddlnTCategoryID.SelectedValue), int.Parse(rblnLangType.SelectedValue), txtsTitle.Text, txtsAuthor.Text, Image3.ImageUrl.ToString(), CKEditorControl1.Text, Session["user"].ToString(), DateTime.Now, true, int.Parse(ddlnSorting.SelectedValue));
                    }
                    else
                    {
                        _Result = News.update_tb_NewsBynNewsID(int.Parse(hfNewsUpdateID.Value), int.Parse(ddlnTCategoryID.SelectedValue), int.Parse(rblnLangType.SelectedValue), txtsTitle.Text, txtsAuthor.Text, "", CKEditorControl1.Text, Session["user"].ToString(), DateTime.Now, true, int.Parse(ddlnSorting.SelectedValue));
                    }
                }
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
    protected void lvNewsList_SelectedIndexChanging(object sender, ListViewSelectEventArgs e)
    {
        Label lblnID = (Label)lvNewsList.Items[e.NewSelectedIndex].FindControl("lblnNewsID");
        int _nID = 0;
        DBLL.clsNews News = new DBLL.clsNews();
        if (int.TryParse(lblnID.Text.Trim(), out _nID) && _nID > 0)
        {
            MultiView1.ActiveViewIndex = 1;
            DBLL.DBcommon dbcom = new DBLL.DBcommon();
            DataTable TopicCategorydt = dbcom.selectNormalTableofAll(false, "tb_TopicCategory");
            ddlnTCategoryID.DataSource = TopicCategorydt;
            ddlnTCategoryID.DataValueField = "nTCategoryID";
            ddlnTCategoryID.DataTextField = "sTCategoryNameCN";
            ddlnTCategoryID.DataBind();
            DataTable dt = News.Select_tb_NewsBynNewsID(_nID);

            ddlnTCategoryID.SelectedValue = dt.Rows[0]["nTCategoryID"].ToString();
            txtsTitle.Text = dt.Rows[0]["sTitle"].ToString();
            txtsAuthor.Text = dt.Rows[0]["sAuthor"].ToString();
            rblnLangType.SelectedValue = dt.Rows[0]["nLangType"].ToString();
            Image3.ImageUrl = dt.Rows[0]["sImagePath"].ToString();
            if (Image3.ImageUrl != "")
            {
                lblsImagePath.Visible = false;
                MutileUploaderUserControl3.Visible = false;
                Label2.Visible = true;
                Button1.Visible = true;
                Image3.Visible = true;
            }
            else
            {
                lblsImagePath.Visible = true;
                MutileUploaderUserControl3.Visible = true;
                Label2.Visible = false;
                Button1.Visible = false;
                Image3.Visible = false;
            }
            CKEditorControl1.Text = dt.Rows[0]["sContent"].ToString();
            ddlnSorting.SelectedValue = dt.Rows[0]["nSorting"].ToString();
            MutileUploaderUserControl3.Refresh();
            hfNewsUpdateID.Value = _nID.ToString();
        }
    }
    protected void lvNewsList_ItemDeleting(object sender, ListViewDeleteEventArgs e)
    {
        DBLL.DBcommon dbcom = new DBLL.DBcommon();
        Label lblnID = (Label)lvNewsList.Items[e.ItemIndex].FindControl("lblnNewsID");
        int _nID = 0;
        if (int.TryParse(lblnID.Text.Trim(), out _nID) && _nID > 0)
        {
            hfNewsUpdateID.Value = _nID.ToString();
        }
        dbcom.sp_DeleteNormalTableByID(int.Parse(hfNewsUpdateID.Value), "tb_News");
        ReBindPageList();
    }
    protected void lvNewsList_ItemDataBound(object sender, ListViewItemEventArgs e)
    {
        try
        {
            DBLL.OptionSysDBLL option = new DBLL.OptionSysDBLL();
            if (e.Item.ItemType == ListViewItemType.DataItem)
            {
                Label lblnLangType = (Label)e.Item.FindControl("lblnLangType");
                if (int.Parse(lblnLangType.Text) == 1)
                    lblnLangType.Text = "中文";
                else if (int.Parse(lblnLangType.Text) == 2)
                    lblnLangType.Text = "英文";

                DBLL.clsTopicCategory TopicCategory = new DBLL.clsTopicCategory();
                int nType = 0;
                Label lblnTCategoryID = (Label)e.Item.FindControl("lblnTCategoryID");
                if (int.TryParse(lblnTCategoryID.Text, out nType))
                {
                    nType = int.Parse(lblnTCategoryID.Text);
                    string sTCategoryNameCN = TopicCategory.Select_tb_TopicCategoryBynTCategoryID(nType).Rows[0]["sTCategoryNameCN"].ToString();
                    lblnTCategoryID.Text = sTCategoryNameCN;
                }
                Label lblsTitle = (Label)e.Item.FindControl("lblsTitle");
                if (lblsTitle.Text.Length > 5)
                {
                    lblsTitle.Text = lblsTitle.Text.Substring(0, 6).ToString() + "....";
                }
                Label lblsAuthor = (Label)e.Item.FindControl("lblsAuthor");
                if (lblsAuthor.Text.Length > 5)
                {
                    lblsAuthor.Text = lblsAuthor.Text.Substring(0, 6).ToString() + "....";
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
        if (string.IsNullOrEmpty(txtsTitle.Text))
        {
            ShowMsg1.InnerContent += "标题不能为空<br/>";
            bcheck = false;
        }
        //if (string.IsNullOrEmpty(CKEditorControl1.Text))
        //{
        //    ShowMsg1.InnerContent += "内容不能为空<br/>";
        //    bcheck = false;
        //}
        return bcheck;
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        DBLL.clsNews News = new DBLL.clsNews();
        DBLL.OptionSysDBLL option = new DBLL.OptionSysDBLL();
        bool _Result = News.update_tb_NewsBynNewsID(int.Parse(hfNewsUpdateID.Value), int.Parse(ddlnTCategoryID.SelectedValue), int.Parse(rblnLangType.SelectedValue), txtsTitle.Text, txtsAuthor.Text, "", CKEditorControl1.Text, Session["user"].ToString(), DateTime.Now, true, int.Parse(ddlnSorting.SelectedValue));
        if (_Result)
        {
            string sSaveFolderFullPath = Server.MapPath(Image3.ImageUrl);
            if (File.Exists(sSaveFolderFullPath))
            {
                //如果存在则删除
                File.Delete(sSaveFolderFullPath);

                System.IO.DirectoryInfo dir = new System.IO.DirectoryInfo(sSaveFolderFullPath.Substring(0, sSaveFolderFullPath.LastIndexOf("\\")).ToString());
                System.IO.FileInfo[] dirs = dir.GetFiles();
                if (dirs.Length > 0)
                {
                    //有子文件夹
                }
                else
                {
                    Directory.Delete(sSaveFolderFullPath.Substring(0, sSaveFolderFullPath.LastIndexOf("\\")).ToString());
                }
            }
            lblsImagePath.Visible = true;
            MutileUploaderUserControl3.Visible = true;
            Label2.Visible = false;
            Button1.Visible = false;
            Image3.Visible = false;
        }
    }
}