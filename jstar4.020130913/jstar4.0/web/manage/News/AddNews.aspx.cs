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

public partial class manage_News_AddNews : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            DBLL.DBcommon dbcom = new DBLL.DBcommon();
            DBLL.clsTopicCategory TopicCategory = new DBLL.clsTopicCategory();
            DataTable TopicCategorydt = TopicCategory.sp_selectNormalTableOfAllByTopicCategoryAndnType(false, 3);
            ddlnTCategoryID.DataSource = TopicCategorydt;
            ddlnTCategoryID.DataValueField = "nTCategoryID";
            ddlnTCategoryID.DataTextField = "sTCategoryNameCN";
            ddlnTCategoryID.DataBind();
        }
    }
    protected void BtnAdd_Click(object sender, EventArgs e)
    {
        //判断session
        if (Session["User"] == null || Session["User"].ToString().Length < 1) Response.Redirect(Request.RawUrl);
        if (ValiAdd())
        {
            DBLL.clsNews News = new DBLL.clsNews();
            DBLL.OptionSysDBLL option = new DBLL.OptionSysDBLL();
            int _Result = 0;
            MutileUploaderUserControl3.sNewName = txtsTitle.Text;
            MutileUploaderUserControl3.SavePath();
            if (MutileUploaderUserControl3.filepathlist.Count > 0)
            {
                for (int i = 0; i < MutileUploaderUserControl3.filepathlist.Count; i++)
                {
                    _Result = News.insert_tb_News(int.Parse(ddlnTCategoryID.SelectedValue), int.Parse(rblnLangType.SelectedValue), txtsTitle.Text, txtsAuthor.Text, MutileUploaderUserControl3.filepathlist[i].ToString(), CKEditorControl1.Text, Session["User"].ToString(), DateTime.Now, Session["User"].ToString(), DateTime.Now, true, int.Parse(ddlnSorting.SelectedValue));
                }
            }
            else
            {
                _Result = News.insert_tb_News(int.Parse(ddlnTCategoryID.SelectedValue), int.Parse(rblnLangType.SelectedValue), txtsTitle.Text, txtsAuthor.Text, "", CKEditorControl1.Text, Session["User"].ToString(), DateTime.Now, Session["User"].ToString(), DateTime.Now, true, int.Parse(ddlnSorting.SelectedValue));
            }
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
        txtsTitle.Text = "";
        txtsAuthor.Text = "";
        CKEditorControl1.Text = "";
        rblnLangType.SelectedIndex = 0;
        ddlnTCategoryID.SelectedIndex = 0;
        ddlnSorting.SelectedIndex = 0;
    }
    protected bool ValiAdd()
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
}