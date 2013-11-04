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

public partial class manage_OptionSys_CustomInformation1 : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            DBLL.OptionSysDBLL option = new DBLL.OptionSysDBLL();
            CKEditorControl1.Text = option.GetOptionValue("cn", "SystemSetting", "CustomInformation1").ToString();
            CKEditorControl2.Text = option.GetOptionValue("en", "SystemSetting", "CustomInformation1").ToString();
        }
    }
    protected void BtnAdd_Click(object sender, EventArgs e)
    {
        //判断session
        if (Session["User"] == null || Session["User"].ToString().Length < 1) Response.Redirect(Request.RawUrl);
        try
        {
            DBLL.OptionSysDBLL option = new DBLL.OptionSysDBLL();
            option.UpdateOptionValue("cn", "SystemSetting", "CustomInformation1", CKEditorControl1.Text);
            option.UpdateOptionValue("en", "SystemSetting", "CustomInformation1", CKEditorControl2.Text);
            ShowMsg1.InnerContent = "更新成功!";
            ShowMsg1.Show();
        }
        catch
        {
            throw;
        }
    }
}