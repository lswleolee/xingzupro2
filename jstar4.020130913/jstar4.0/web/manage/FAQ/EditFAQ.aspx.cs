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

public partial class manage_FAQ_EditFAQ : System.Web.UI.Page
{

    public Model.dsTopic.tb_FAQsDataTable FAQList
    {
        set
        {
            ViewState["EditFAQtb_FAQDataTable"] = value;
        }
        get
        {
            if (ViewState["EditFAQtb_FAQDataTable"] == null)
                ViewState["EditFAQtb_FAQDataTable"] = new Model.dsTopic.tb_FAQsDataTable();
            return (Model.dsTopic.tb_FAQsDataTable)ViewState["EditFAQtb_FAQDataTable"];
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
        DBLL.clsFAQs FAQs = new DBLL.clsFAQs();
        DataTable dt = new DataTable();
        dt = FAQs.sp_selectNormalTableOfAllByFAQs(false);
        if (dt != null)
        {
            FAQList.Merge(dt);
            lvFAQList.DataSource = FAQList;
            lvFAQList.DataBind();
        }
        else
        {
            lvFAQList.DataSource = null;
            lvFAQList.DataBind();
        }
    }
    protected bool ValiEdit()
    {
        bool bcheck = true;
        return bcheck;
    }
    protected void lvFAQList_PagePropertiesChanged(object sender, EventArgs e)
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

        lvFAQList.DataSource = FAQList;
        lvFAQList.DataBind();
    }
    protected void btnBackToList_Click(object sender, EventArgs e)
    {
        MultiView1.ActiveViewIndex = 0;
        ReBindPageList();
    }
    protected void BtnUpdate_Click(object sender, EventArgs e)
    {
        //判断session
        if (Session["User"] == null || Session["User"].ToString().Length < 1) Response.Redirect(Request.RawUrl);
        try
        {
            if (ValiEdit())
            {
                DBLL.clsFAQs FAQ = new DBLL.clsFAQs();
                DBLL.OptionSysDBLL option = new DBLL.OptionSysDBLL();
                bool _Result = FAQ.update_tb_FAQsBynFAQID(int.Parse(hfFAQUpdateID.Value), txtsQuestionCN.Text, txtsQuestionEN.Text,txtsAnswerCN.Text,txtsAnswerEN.Text, Session["user"].ToString(), DateTime.Now, true, int.Parse(ddlnSorting.SelectedValue));
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
    protected void lvFAQList_ItemDataBound(object sender, ListViewItemEventArgs e)
    {
        try
        {
            DBLL.OptionSysDBLL option = new DBLL.OptionSysDBLL();

            Label lblsQuestionEN = (Label)e.Item.FindControl("lblsQuestionEN");
            if (lblsQuestionEN.Text.Length > 4)
            {
                lblsQuestionEN.Text = lblsQuestionEN.Text.Substring(0, 4).ToString() + "....";
            }
            Label lblsQuestionCN = (Label)e.Item.FindControl("lblsQuestionCN");
            if (lblsQuestionCN.Text.Length > 4)
            {
                lblsQuestionCN.Text = lblsQuestionCN.Text.Substring(0, 4).ToString() + "....";
            }

            Label lblsAnswerCN = (Label)e.Item.FindControl("lblsAnswerCN");
            if (lblsAnswerCN.Text.Length > 4)
            {
                lblsAnswerCN.Text = lblsAnswerCN.Text.Substring(0, 4).ToString() + "....";
            }
            Label lblsAnswerEN = (Label)e.Item.FindControl("lblsAnswerEN");
            if (lblsAnswerEN.Text.Length > 4)
            {
                lblsAnswerEN.Text = lblsAnswerEN.Text.Substring(0, 4).ToString() + "....";
            }

            ImageButton imgDelete = (ImageButton)e.Item.FindControl("imgDelete");
            imgDelete.OnClientClick = "javascript:if (confirm('" + option.GetOptionValue("FormatSetting", "CommandControl", "bIsDelete") + "')){$('#EntryForm').block({ message: null });}else{return false;}";

        }
        catch (Exception)
        {
        }
    }
    protected void lvFAQList_ItemDeleting(object sender, ListViewDeleteEventArgs e)
    {
        DBLL.DBcommon dbcom = new DBLL.DBcommon();
        Label lblnID = (Label)lvFAQList.Items[e.ItemIndex].FindControl("lblnFAQID");
        int _nID = 0;
        if (int.TryParse(lblnID.Text.Trim(), out _nID) && _nID > 0)
        {
            hfFAQUpdateID.Value = _nID.ToString();
        }
        dbcom.sp_DeleteNormalTableByID(int.Parse(hfFAQUpdateID.Value), "tb_FAQs");
        ReBindPageList();
    }
    protected void lvFAQList_SelectedIndexChanging(object sender, ListViewSelectEventArgs e)
    {
        Label lblnID = (Label)lvFAQList.Items[e.NewSelectedIndex].FindControl("lblnFAQID");
        int _nID = 0;
        DBLL.clsFAQs FAQ = new DBLL.clsFAQs();
        if (int.TryParse(lblnID.Text.Trim(), out _nID) && _nID > 0)
        {
            MultiView1.ActiveViewIndex = 1;
            DataTable dt = FAQ.Select_tb_FAQsBynFAQID(_nID);
            txtsQuestionCN.Text = dt.Rows[0]["sQuestionCN"].ToString();
            txtsQuestionEN.Text = dt.Rows[0]["sQuestionEN"].ToString();
            txtsAnswerCN.Text = dt.Rows[0]["sAnswerCN"].ToString();
            txtsAnswerEN.Text = dt.Rows[0]["sAnswerEN"].ToString();
            ddlnSorting.SelectedValue = dt.Rows[0]["nSorting"].ToString();
            hfFAQUpdateID.Value = _nID.ToString();
        }
    }
}