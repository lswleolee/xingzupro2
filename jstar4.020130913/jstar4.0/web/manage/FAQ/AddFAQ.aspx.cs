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

public partial class manage_FAQ_AddFAQ : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void BtnAdd_Click(object sender, EventArgs e)
    {
        //判断session
        if (Session["User"] == null || Session["User"].ToString().Length < 1) Response.Redirect(Request.RawUrl);
        if (ValiAdd())
        {
            DBLL.clsFAQs FAQ = new DBLL.clsFAQs();
            DBLL.OptionSysDBLL option = new DBLL.OptionSysDBLL();
            int _Result = FAQ.insert_tb_FAQs(txtsQuestionCN.Text, txtsQuestionEN.Text, txtsAnswerCN.Text, txtsAnswerEN.Text, Session["User"].ToString(), DateTime.Now, Session["User"].ToString(), DateTime.Now, true, int.Parse(ddlnSorting.SelectedValue));
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
        txtsQuestionCN.Text = "";
        txtsQuestionEN.Text = "";
        txtsAnswerCN.Text = "";
        txtsAnswerEN.Text = "";
        ddlnSorting.SelectedIndex = 0;
    }
    protected bool ValiAdd()
    {
        bool bcheck = true;
        return bcheck;
    }
}