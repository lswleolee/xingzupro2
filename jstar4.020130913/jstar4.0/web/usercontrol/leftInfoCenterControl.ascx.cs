using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;
public partial class usercontrol_leftInfoCenterControl : System.Web.UI.UserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            OnSetLanguage();
            DBLL.DBcommon com = new DBLL.DBcommon();
            DataTable dt = new DataTable();
            if (Session["languageGlobal"] == "en")
            {
                dt = com.GetDataTable(" select top 1 * from tb_News where nLangType=2 order by nSorting desc,dUpdatedTime desc");
           
            }
            else
            {
                dt = com.GetDataTable(" select top 1 * from tb_News where nLangType=1 order by nSorting desc,dUpdatedTime desc");
            }
            if (dt != null && dt.Rows.Count > 0)
            {
                lbltitle.Text = dt.Rows[0]["sTitle"].ToString();
                lbltime.Text = dt.Rows[0]["dUpdatedTime"].ToString();
              string content=  common.StripHTML(dt.Rows[0]["sContent"].ToString());
              if (content.Length > 100)
              {
                  lblContent.Text = content.Substring(0, 100) + "...";
              }
              else lblContent.Text = content;
            }
        }
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
        lbltitleleft.Text = langxml.getString("leftInfoCenterControl", "Label", "lbltitleleft");
        btnMoreFaqs.Text = langxml.getString("leftInfoCenterControl", "Button", "btnMoreFaqs");
        //btnSearch.Text = langxml.getString("MasterPage", "Button", "btnSearch");
    }
    protected void lbltitle_Click(object sender, EventArgs e)
    {
        Response.Redirect("InfoCenter.aspx");

    }
    protected void btnMoreFaqs_Click(object sender, EventArgs e)
    {
        Response.Redirect("InfoCenter.aspx");
    }
}