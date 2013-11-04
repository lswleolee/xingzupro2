using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;
public partial class usercontrol_TopicDetailShowControl : System.Web.UI.UserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if(!IsPostBack)
        {
            OnSetLanguage();
            MultiView1.ActiveViewIndex = 0;
            DBLL.clsTopicCategory clsTopicCate = new DBLL.clsTopicCategory();
            int _nTCategoryID = 0;

            if (Request.QueryString["nTCategoryID"] != null && int.TryParse(Request.QueryString["nTCategoryID"], out _nTCategoryID))
            {
                DataTable dttc = clsTopicCate.Select_tb_TopicCategoryBynTCategoryID(_nTCategoryID);
                if (dttc != null && dttc.Rows.Count > 0)
                {
                    int nType = int.Parse(dttc.Rows[0]["nType"].ToString());

                    switch (nType)
                    {
                        case 1:
                            {
                                if (Session["languageGlobal"] == "en")
                                {
                                    SetType1DivContent(dttc.Rows[0]["sTCategoryNameEN"].ToString(), dttc.Rows[0]["sContentEN"].ToString());
                                }
                                else
                                {
                                    SetType1DivContent(dttc.Rows[0]["sTCategoryNameCN"].ToString(), dttc.Rows[0]["sContentCN"].ToString());
                                }

                                break;
                            }
                        case 2:
                            {
                                if (Session["languageGlobal"] == "en")
                                {
                                    SetTyp2Ablum(dttc.Rows[0]["sTCategoryNameEN"].ToString(), _nTCategoryID);
                                }
                                else
                                {
                                    SetTyp2Ablum(dttc.Rows[0]["sTCategoryNameCN"].ToString(), _nTCategoryID);
                                }

                                break;
                            }
                        case 3:
                            {
                                if (Session["languageGlobal"] == "en")
                                {
                                    SetTyp3News(dttc.Rows[0]["sTCategoryNameEN"].ToString(), _nTCategoryID, 2);
                                }
                                else
                                {
                                    SetTyp3News(dttc.Rows[0]["sTCategoryNameCN"].ToString(), _nTCategoryID, 1);
                                }

                                break;
                            }
                        case 4:
                            {
                                if (Session["languageGlobal"] == "en")
                                {
                                    SetTyp4FAQs(dttc.Rows[0]["sTCategoryNameEN"].ToString(), _nTCategoryID);
                                }
                                else
                                {
                                    SetTyp4FAQs(dttc.Rows[0]["sTCategoryNameCN"].ToString(), _nTCategoryID);
                                }

                                break;
                            }
                        default:
                            break;
                    }

                    int nFAQsID = 0;
                    if (Session["nFAQsRidectSet"] != null && int.TryParse(Session["nFAQsRidectSet"].ToString(), out nFAQsID) && nFAQsID > 0)
                    {
                        Session["nFAQsRidectSet"] = "";
                        DBLL.clsFAQs clsnews = new DBLL.clsFAQs();
                        DataTable dtnews = clsnews.Select_tb_FAQsBynFAQID(nFAQsID);
                        if (dtnews != null && dtnews.Rows.Count > 0)
                        {
                            if (Session["languageGlobal"] == "en")
                            {

                                lblFAQsDetailtitle.Text = dtnews.Rows[0]["sQuestionEN"].ToString();
                                lblFAQsDetailTime.Text = dtnews.Rows[0]["dCreatedTime"].ToString();
                                divFAQsDetail.InnerHtml = dtnews.Rows[0]["sAnswerEN"].ToString();
                            }
                            else
                            {
                                lblFAQsDetailtitle.Text = dtnews.Rows[0]["sQuestionCN"].ToString();
                                lblFAQsDetailTime.Text = dtnews.Rows[0]["dCreatedTime"].ToString();
                                divFAQsDetail.InnerHtml = dtnews.Rows[0]["sAnswerCN"].ToString();
                            }
                            PnlFAQsDetail.Visible = true;
                            lvFAQs.Visible = false;
                        }
                    }






                }
            }
           
        }
    }
    public void SetType1DivContent(string sName,string sContent)
    {
        MultiView1.ActiveViewIndex = 0;
        lblBigTitle.Text = sName;
        divsContent.InnerHtml = sContent;


    }
    public void SetTyp2Ablum(string sName, int nTCID)
    {
        MultiView1.ActiveViewIndex = 1;
        lblBigTitle.Text = sName;
        DBLL.clsTopicCategory clstc = new DBLL.clsTopicCategory();
        DBLL.clsAlbum clsa = new DBLL.clsAlbum();
        dlAlbum.DataSource = clsa.Select_tb_AlbumBynTCategoryID(nTCID);
        dlAlbum.DataBind();
    }
    public void SetTyp3News(string sName, int nTCID, int nLangType)
    {
        MultiView1.ActiveViewIndex = 2;
        lblBigTitle.Text = sName;
        DBLL.clsNews clsnew = new DBLL.clsNews();

        lvNews.DataSource = clsnew.Select_tb_NewsBynTCategoryIDAndnLangType(nTCID, nLangType);
        lvNews.DataBind();

    }
    public void SetTyp4FAQs(string sName, int nTCID)
    {
        MultiView1.ActiveViewIndex = 3;
        lblBigTitle.Text = sName;
        DBLL.clsFAQs clsFAQs = new DBLL.clsFAQs();

        lvFAQs.DataSource = clsFAQs.sp_selectNormalTableOfAllByFAQs(false);
        lvFAQs.DataBind();

    }
    protected void dlAlbum_ItemDataBound(object sender, DataListItemEventArgs e)
    {
        try
        {
            
                Label lblImgNameEN = (Label)e.Item.FindControl("lblImgNameEN");
                Label lblImgNameCN = (Label)e.Item.FindControl("lblImgNameCN");
                if (Session["languageGlobal"] == "en")
                {
                    lblImgNameEN.Visible = true;
                    lblImgNameCN.Visible = false;
                }
                else
                {
                    lblImgNameCN.Visible = true;
                    lblImgNameEN.Visible = false;
                }

            
        }
        catch (Exception)
        {
            
            throw;
        }
    }
    protected void lvFAQs_ItemDataBound(object sender, ListViewItemEventArgs e)
    {
        try
        {
            LinkButton lbtnFAQsTitleEN = (LinkButton)e.Item.FindControl("lbtnFAQsTitleEN");
            LinkButton lbtnFAQsTitleCN = (LinkButton)e.Item.FindControl("lbtnFAQsTitleCN");
          Label lblFAQsAnswerEN = (Label)e.Item.FindControl("lblFAQsAnswerEN");
          Label lblFAQsAnswerCN = (Label)e.Item.FindControl("lblFAQsAnswerCN");

          string contentEN = common.StripHTML(lblFAQsAnswerEN.Text);
          string contentCN = common.StripHTML(lblFAQsAnswerCN.Text);
          if (lblFAQsAnswerEN.Text.Length > 200)
              lblFAQsAnswerEN.Text = contentEN.Substring(0, 200) + "...";
          if (lblFAQsAnswerCN.Text.Length > 200)
              lblFAQsAnswerCN.Text = contentCN.Substring(0, 200) + "...";
          if (Session["languageGlobal"] == "en")
          {
              lbtnFAQsTitleEN.Visible = true;
              lbtnFAQsTitleCN.Visible = false;
              lblFAQsAnswerEN.Visible = true;
              lblFAQsAnswerCN.Visible = false;

          }
          else
          {
              lbtnFAQsTitleEN.Visible = false;
              lbtnFAQsTitleCN.Visible = true;
              lblFAQsAnswerEN.Visible = false;
              lblFAQsAnswerCN.Visible = true;
          }
        }
        catch (Exception)
        {
            
            throw;
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
        lblBigTitle.Text = langxml.getString("TopicDetailShowControl", "Label", "lblBigTitle");
        //btnSearch.Text = langxml.getString("MasterPage", "Button", "btnSearch");
    }
    protected void lvNews_SelectedIndexChanging(object sender, ListViewSelectEventArgs e)
    {
        try
        {
            Label lblnID=(Label) lvNews.Items[e.NewSelectedIndex].FindControl("lblnID");
            int nID = 0;
            if (int.TryParse(lblnID.Text.Trim(), out nID) && nID > 0)
            {
                DBLL.clsNews clsnews = new DBLL.clsNews();
                DataTable dtnews = clsnews.Select_tb_NewsBynNewsID(nID);
                if (dtnews != null && dtnews.Rows.Count > 0)
                {
                   lblNewsDetailtitle.Text=  dtnews.Rows[0]["sTitle"].ToString();
                   lblNewsDetailTime.Text = dtnews.Rows[0]["dCreatedTime"].ToString();
                   divNewsDetail.InnerHtml = dtnews.Rows[0]["sContent"].ToString();
                   PnlNewsDetail.Visible = true;
                   lvNews.Visible = false;
                }
            }
        }
        catch (Exception)
        {
            
            throw;
        }
    }
    protected void lvNews_ItemDataBound(object sender, ListViewItemEventArgs e)
    {
        try
        {
           Label lblContent=(Label) e.Item.FindControl("lblContent");
           string content = common.StripHTML(lblContent.Text);
           if (content.Length > 200)
               lblContent.Text = content.Substring(0, 200) + "...";
           
        }
        catch (Exception)
        {
            
            throw;
        }
    }
    protected void lvFAQs_SelectedIndexChanging(object sender, ListViewSelectEventArgs e)
    {
        try
        {
            Label lblnID = (Label)lvFAQs.Items[e.NewSelectedIndex].FindControl("lblnID");
            int nID = 0;
            if (int.TryParse(lblnID.Text.Trim(), out nID) && nID > 0)
            {
                DBLL.clsFAQs clsnews = new DBLL.clsFAQs();
                DataTable dtnews = clsnews.Select_tb_FAQsBynFAQID(nID);
                if (dtnews != null && dtnews.Rows.Count > 0)
                {
                    if (Session["languageGlobal"] == "en")
                    {

                        lblFAQsDetailtitle.Text = dtnews.Rows[0]["sQuestionEN"].ToString();
                        lblFAQsDetailTime.Text = dtnews.Rows[0]["dCreatedTime"].ToString();
                        divFAQsDetail.InnerHtml = dtnews.Rows[0]["sAnswerEN"].ToString();
                    }
                    else
                    {
                        lblFAQsDetailtitle.Text = dtnews.Rows[0]["sQuestionCN"].ToString();
                        lblFAQsDetailTime.Text = dtnews.Rows[0]["dCreatedTime"].ToString();
                        divFAQsDetail.InnerHtml = dtnews.Rows[0]["sAnswerCN"].ToString();
                    }
                    PnlFAQsDetail.Visible = true;
                    lvFAQs.Visible = false;
                }
            }
        }
        catch (Exception)
        {

            throw;
        }
    }
}