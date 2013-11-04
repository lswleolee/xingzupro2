using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
public partial class manage_Login : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void btnLogin_Click(object sender, EventArgs e)
    {
        try
        {
            DBLL.clsUser user = new DBLL.clsUser();
         DataTable dt=   user.Select_tb_UserBysUsernameandsPassword(txtUsername.Text,txtPassword.Text);
         if (dt != null && dt.Rows.Count > 0)
         {
             Session["UserID"] = dt.Rows[0]["nUserID"].ToString();
             Session["User"] = dt.Rows[0]["sUsername"].ToString();
             Response.Redirect("Default.aspx");
         }
         else
         {
             ShowMsg1.InnerContent = "<p>用户名或密码错误！</p>";
             ShowMsg1.Show();
         }
        }
        catch (Exception)
        {
            
            throw;
        }
    }
    protected void btnBack_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/Default.aspx");
    }
}