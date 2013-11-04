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

public partial class manage_OptionSys_ContactInformation : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            DBLL.OptionSysDBLL option = new DBLL.OptionSysDBLL();
            CKEditorControl1.Text = option.GetOptionValue("cn", "SystemSetting", "ContactInformation").ToString();
            CKEditorControl2.Text = option.GetOptionValue("en", "SystemSetting", "ContactInformation").ToString();
        }
    }
    protected void BtnAdd_Click(object sender, EventArgs e)
    {
        //判断session
        if (Session["User"] == null || Session["User"].ToString().Length < 1) Response.Redirect(Request.RawUrl);
        try
        {
            DBLL.OptionSysDBLL option = new DBLL.OptionSysDBLL();
            option.UpdateOptionValue("cn", "SystemSetting", "ContactInformation", CKEditorControl1.Text);
            option.UpdateOptionValue("en", "SystemSetting", "ContactInformation", CKEditorControl2.Text);
            ShowMsg1.InnerContent = "更新成功!";
            ShowMsg1.Show();
        }
        catch
        {
            throw;
        }
    }
}