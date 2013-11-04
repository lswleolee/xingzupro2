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

public partial class manage_Topic_AddTopicCategory : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            DBLL.DBcommon dbcom = new DBLL.DBcommon();
            DataTable Topicdt = dbcom.selectNormalTableofAll(false, "tb_Topic");
            ddlnTopicID.DataSource = Topicdt;
            ddlnTopicID.DataValueField = "nTopicID";
            ddlnTopicID.DataTextField = "sTopicNameCN";
            ddlnTopicID.DataBind();
        }
    }
    protected void BtnAdd_Click(object sender, EventArgs e)
    {
        //判断session
        if (Session["User"] == null || Session["User"].ToString().Length < 1) Response.Redirect(Request.RawUrl);
        if (ValiAdd())
        {
            DBLL.clsTopicCategory TopicCategory = new DBLL.clsTopicCategory();
            DBLL.OptionSysDBLL option = new DBLL.OptionSysDBLL();
            int _Result = 0;
            if (rblnType.SelectedValue == "1")
            {
                _Result = TopicCategory.insert_tb_TopicCategory(int.Parse(ddlnTopicID.SelectedValue), txtsTCategoryNameCN.Text, txtsTCategoryNameEN.Text, int.Parse(ddlnTopicID.SelectedValue), CKEditorControl1.Text, CKEditorControl2.Text, Session["User"].ToString(), DateTime.Now, Session["User"].ToString(), DateTime.Now, true, int.Parse(ddlnSorting.SelectedValue));
            }
            else
            {
                _Result = TopicCategory.insert_tb_TopicCategory(int.Parse(ddlnTopicID.SelectedValue), txtsTCategoryNameCN.Text, txtsTCategoryNameEN.Text, int.Parse(ddlnTopicID.SelectedValue), "", "", Session["User"].ToString(), DateTime.Now, Session["User"].ToString(), DateTime.Now, true, int.Parse(ddlnSorting.SelectedValue));
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
        txtsTCategoryNameCN.Text = "";
        txtsTCategoryNameEN.Text = "";
        CKEditorControl1.Text = "";
        CKEditorControl2.Text = "";
        rblnType.SelectedIndex = 1;
        ddlnTopicID.SelectedIndex = 1;
        ddlnSorting.SelectedIndex = 1;
    }
    protected bool ValiAdd()
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