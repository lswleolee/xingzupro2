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

public partial class manage_Album_AddAlbum : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            DBLL.DBcommon dbcom = new DBLL.DBcommon();
            DBLL.clsTopicCategory TopicCategory = new DBLL.clsTopicCategory();
            DataTable TopicCategorydt = TopicCategory.sp_selectNormalTableOfAllByTopicCategoryAndnType(false, 2);
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
            MutileUploaderUserControl21.SavePath(ddlnTCategoryID.SelectedItem.Text);

            for (int i = 0; i < MutileUploaderUserControl21.ImageDT.Rows.Count; i++)
            {
                Response.Write(MutileUploaderUserControl21.ImageDT.Rows[i]["sFilename"].ToString());
                DBLL.clsAlbum Album = new DBLL.clsAlbum();
                DBLL.OptionSysDBLL option = new DBLL.OptionSysDBLL();
                int _Result = 0;
                _Result = Album.insert_tb_Album(int.Parse(ddlnTCategoryID.SelectedValue), MutileUploaderUserControl21.ImageDT.Rows[i]["sImageNameCN"].ToString(), MutileUploaderUserControl21.ImageDT.Rows[i]["sImageNameEN"].ToString(), MutileUploaderUserControl21.filepathlist[i].ToString(), Session["User"].ToString(), DateTime.Now, Session["User"].ToString(), DateTime.Now, true, int.Parse(ddlnSorting.SelectedValue));

                if (_Result > 0)
                {
                    ShowMsg1.InnerContent = option.GetOptionValue("FormatSetting", "CommandControl", "InsertSuccess");
                    ShowMsg1.Show();
                }
                else
                {
                    ShowMsg1.InnerContent = option.GetOptionValue("FormatSetting", "CommandControl", "InsertFail");
                    ShowMsg1.Show();
                }
            }
            Response.Redirect("~/manage/Album/AddAlbum.aspx");
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
        //txtsImageNameCN.Text = "";
        //txtsImageNameEN.Text = "";
        ddlnTCategoryID.SelectedIndex = 0;
        ddlnSorting.SelectedIndex = 0;
    }
    protected bool ValiAdd()
    {
        bool bcheck = true;
        ShowMsg1.InnerContent = "";
        //if (string.IsNullOrEmpty(txtsImageNameCN.Text))
        //{
        //    ShowMsg1.InnerContent += "图片中文名字不能为空<br/>";
        //    bcheck = false;
        //}
        //if (string.IsNullOrEmpty(txtsImageNameEN.Text))
        //{
        //    ShowMsg1.InnerContent += "图片英文名字不能为空<br/>";
        //    bcheck = false;
        //}
        return bcheck;
    }
}