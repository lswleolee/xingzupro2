using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;
public partial class usercontrol_leftFAQsControl : System.Web.UI.UserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            OnSetLanguage();
            DBLL.clsFAQs clsfaqs = new DBLL.clsFAQs();
            DBLL.DBcommon dbcom = new DBLL.DBcommon();
            DataTable dt = dbcom.GetDataTable("select top 1 * from tb_FAQs  order by nSorting desc,dCreatedTime desc");
            gvFAQS.DataSource = dt;
            gvFAQS.DataBind();
        }
    }
    protected void gvFAQS_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            LinkButton lblFAQSCN = (LinkButton)e.Row.FindControl("lblFAQSCN");
            LinkButton lblFAQSEN = (LinkButton)e.Row.FindControl("lblFAQSEN");
            Label lblAnswerCN = (Label)e.Row.FindControl("lblAnswerCN");
            Label lblAnswerEN = (Label)e.Row.FindControl("lblAnswerEN");
            string contentEN = common.StripHTML(lblAnswerEN.Text);
            string contentCN = common.StripHTML(lblAnswerCN.Text);

            if (lblAnswerCN.Text.Length > 100)
                lblAnswerCN.Text = contentCN.Substring(0, 100) + "...";
            if (lblAnswerEN.Text.Length > 50)
                lblAnswerEN.Text = contentEN.Substring(0, 100) + "...";
            if (Session["languageGlobal"] == "en")
            {
                lblFAQSEN.Visible = true;
                lblFAQSCN.Visible = false;
                lblAnswerCN.Visible = false;
                lblAnswerEN.Visible = true;
            }
            else
            {
                lblFAQSEN.Visible = false;
                lblFAQSCN.Visible = true;
                lblAnswerCN.Visible = true;
                lblAnswerEN.Visible = false;
            }

        }
    }
    protected void gvFAQS_SelectedIndexChanging(object sender, GridViewSelectEventArgs e)
    {
        try
        {
            Label lblnID = (Label)gvFAQS.Rows[e.NewSelectedIndex].FindControl("lblnID");
            Session["nFAQsRidectSet"] = lblnID.Text.Trim();

            Response.Redirect("Service.aspx?nTCategoryID=18");
        }
        catch (Exception)
        {

            throw;
        }
    }

    protected void btnMoreFaqs_Click(object sender, EventArgs e)
    {
        Response.Redirect("Service.aspx?nTCategoryID=18");
    }

    public void OnSetLanguage()
    {
        string xmlfilepath = ConfigurationManager.AppSettings["xmlfilepath"].ToString();
        if (Session["languageGlobal"] != null)
        {
            xmlfilepath = xmlfilepath.Replace("[filename]", Session["languageGlobal"].ToString());

        }
        else
        {
            xmlfilepath = xmlfilepath.Replace("[filename]", "en");


        }
        clslang langxml = new clslang(xmlfilepath);
        langxml.XmlLoad();

        //Label
        // lblAdd_Education_News.Text = langxml.getString("AddNews", "Label", "lblAdd_Education_News");
        //button
        lblFAQSleft.Text = langxml.getString("leftFAQsControl", "Label", "lblFAQSleft");
        btnMoreFaqs.Text = langxml.getString("leftFAQsControl", "Button", "btnMoreFaqs");
        //btnSearch.Text = langxml.getString("MasterPage", "Button", "btnSearch");
    }
}
