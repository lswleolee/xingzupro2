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

public partial class manage_Link_AddLink : System.Web.UI.Page
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
            DBLL.clsLink Link = new DBLL.clsLink();
            DBLL.OptionSysDBLL option = new DBLL.OptionSysDBLL();
            string sThumbPath = "";
            if (int.Parse(ddlnType.SelectedValue) == 1)
                sThumbPath = "~/style/images/thumb/Msn.png";
            else if (int.Parse(ddlnType.SelectedValue) == 2)
                sThumbPath = "~/style/images/thumb/Email.png";
            else if (int.Parse(ddlnType.SelectedValue) == 3)
                sThumbPath = "~/style/images/thumb/Skype.png";
            else if (int.Parse(ddlnType.SelectedValue) == 4)
                sThumbPath = "~/style/images/thumb/QQ.png";

            int _Result = Link.insert_tb_Link(ddlnType.Text, sThumbPath, txtsLink.Text, Session["User"].ToString(), DateTime.Now, Session["User"].ToString(), DateTime.Now, true, int.Parse(ddlnSorting.SelectedValue));
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
    protected bool ValiAdd()
    {
        bool bcheck = true;
        ShowMsg1.InnerContent = "";
        if (string.IsNullOrEmpty(txtsLink.Text))
        {
            ShowMsg1.InnerContent += "联系不能为空<br/>";
            bcheck = false;
        }
        return bcheck;
    }
    public void Clear()
    {
        txtsLink.Text = "";
        ddlnType.SelectedIndex = 1;
        ddlnSorting.SelectedIndex = 1;
    }
}