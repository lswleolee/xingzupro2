using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class manage_User_AddUser : System.Web.UI.Page
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
            DBLL.clsUser user = new DBLL.clsUser();
            DBLL.OptionSysDBLL option = new DBLL.OptionSysDBLL();
            int _Result = user.insert_tb_User(txtsUsername.Text, txtsPassword2.Text, txtsRealName.Text, int.Parse(rblnUserSex.SelectedValue), txtsUserQQ.Text, txtsUserMSN.Text, txtsUserPhone.Text, txtsUserEmail.Text, int.Parse(rblnUserType.SelectedValue), Session["User"].ToString(), DateTime.Now, Session["User"].ToString(), DateTime.Now, true, 1, cbIsContact.Checked, cbIsInquiry.Checked);
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
        txtsUsername.Text = "";
        txtsPassword.Text = "";
        txtsPassword2.Text = "";
        txtsRealName.Text = "";
        rblnUserSex.SelectedIndex = 0;
        txtsUserQQ.Text = "";
        txtsUserMSN.Text = "";
        txtsUserPhone.Text = "";
        txtsUserEmail.Text = "";
        rblnUserType.SelectedIndex = 0;
    }
    protected bool ValiAdd()
    {
        bool bcheck = true;
        ShowMsg1.InnerContent = "";
        if (string.IsNullOrEmpty(txtsUsername.Text))
        {
            ShowMsg1.InnerContent += "用户登录名称不能为空<br/>";
            bcheck = false;
        }
        if (string.IsNullOrEmpty(txtsPassword.Text))
        {
            ShowMsg1.InnerContent += "为了安全,密码不能为空<br/>";
            bcheck = false;
        }
        if (txtsPassword.Text != txtsPassword2.Text)
        {
            ShowMsg1.InnerContent += "密码确认不正确<br/>";
            bcheck = false;
        }
        return bcheck;
    }
}