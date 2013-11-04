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

public partial class manage_User_EditUser : System.Web.UI.Page
{

    public Model.dsUser.tb_UserDataTable UserList
    {
        set
        {
            ViewState["EditUsertb_UserDataTable"] = value;
        }
        get
        {
            if (ViewState["EditUsertb_UserDataTable"] == null)
                ViewState["EditUsertb_UserDataTable"] = new Model.dsUser.tb_UserDataTable();
            return (Model.dsUser.tb_UserDataTable)ViewState["EditUsertb_UserDataTable"];
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
    protected void lvUserList_PagePropertiesChanged(object sender, EventArgs e)
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

        lvUserList.DataSource = UserList;
        lvUserList.DataBind();
    }
    protected void lvUserList_SelectedIndexChanging(object sender, ListViewSelectEventArgs e)
    {
        Label lblnID = (Label)lvUserList.Items[e.NewSelectedIndex].FindControl("lblnUserID");
        int _nID = 0;
        DBLL.clsUser user = new DBLL.clsUser();
        if (int.TryParse(lblnID.Text.Trim(), out _nID) && _nID > 0)
        {
            MultiView1.ActiveViewIndex = 1;
            DataTable dt = user.Select_tb_UserBynUserID(_nID);
            txtsUsername.Text = dt.Rows[0]["sUsername"].ToString();
            txtsPassword.Text = dt.Rows[0]["sPassword"].ToString();
            txtsPassword.Attributes.Add("Value", txtsPassword.Text);
            txtsPassword2.Text = dt.Rows[0]["sPassword"].ToString();
            txtsPassword2.Attributes.Add("Value", txtsPassword2.Text);
            txtsRealName.Text = dt.Rows[0]["sRealName"].ToString();
            rblnUserSex.SelectedValue = dt.Rows[0]["nUserSex"].ToString();
            txtsUserQQ.Text = dt.Rows[0]["sUserQQ"].ToString();
            txtsUserMSN.Text = dt.Rows[0]["sUserMSN"].ToString();
            txtsUserPhone.Text = dt.Rows[0]["sUserPhone"].ToString();
            txtsUserEmail.Text = dt.Rows[0]["sUserEmail"].ToString();
            cbIsContact.Checked = bool.Parse(dt.Rows[0]["IsContact"].ToString());
            cbIsInquiry.Checked = bool.Parse(dt.Rows[0]["IsInquiry"].ToString());
            rblnUserType.SelectedValue = dt.Rows[0]["nUserType"].ToString();
            hfUserUpdateID.Value = _nID.ToString();
        }
    }
    protected void btnBackToList_Click(object sender, EventArgs e)
    {
        MultiView1.ActiveViewIndex = 0;
        ReBindPageList();
    }
    public void ReBindPageList()
    {
        DBLL.clsUser User = new DBLL.clsUser();
        DataTable dt = new DataTable();
        dt = User.sp_selectNormalTableOfAllByUser(false);
        if (dt != null)
        {
            UserList.Merge(dt);
            lvUserList.DataSource = UserList;
            lvUserList.DataBind();
        }
        else
        {
            lvUserList.DataSource = null;
            lvUserList.DataBind();
        }
    }
    protected bool ValiEdit()
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
    protected void BtnUpdate_Click(object sender, EventArgs e)
    {
        //判断session
        if (Session["User"] == null || Session["User"].ToString().Length < 1) Response.Redirect(Request.RawUrl);
        try
        {
            if (ValiEdit())
            {
                DBLL.clsUser user = new DBLL.clsUser();
                DBLL.OptionSysDBLL option = new DBLL.OptionSysDBLL();
                bool _Result = user.update_tb_UserBynUserID(int.Parse(hfUserUpdateID.Value), txtsUsername.Text, txtsPassword2.Text, txtsRealName.Text, int.Parse(rblnUserSex.SelectedValue), txtsUserQQ.Text, txtsUserMSN.Text, txtsUserPhone.Text, txtsUserEmail.Text, int.Parse(rblnUserType.SelectedValue), Session["user"].ToString(), DateTime.Now, true, 1, cbIsContact.Checked, cbIsInquiry.Checked);
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
            else
            {
                ShowMsg1.Show();
            }
        }
        catch (Exception)
        {

            throw;
        }
    }
    protected void lvUserList_ItemDataBound(object sender, ListViewItemEventArgs e)
    {
        try
        {
            if (e.Item.ItemType == ListViewItemType.DataItem)
            {
                Label lblnUserType = (Label)e.Item.FindControl("lblnUserType");
                if (int.Parse(lblnUserType.Text) == 2)
                    lblnUserType.Text = "超级用户";
                else if (int.Parse(lblnUserType.Text) == 1)
                    lblnUserType.Text = "普通用户";
            }
            DBLL.OptionSysDBLL option = new DBLL.OptionSysDBLL();
            ImageButton imgDelete = (ImageButton)e.Item.FindControl("imgDelete");
            imgDelete.OnClientClick = "javascript:if (confirm('" + option.GetOptionValue("FormatSetting", "CommandControl", "bIsDelete") + "')){$('#EntryForm').block({ message: null });}else{return false;}";

        }
        catch (Exception)
        {

        }
    }
    protected void lvUserList_ItemDeleting(object sender, ListViewDeleteEventArgs e)
    {
        DBLL.DBcommon dbcom = new DBLL.DBcommon();
        Label lblnID = (Label)lvUserList.Items[e.ItemIndex].FindControl("lblnUserID");
        int _nID = 0;
        if (int.TryParse(lblnID.Text.Trim(), out _nID) && _nID > 0)
        {
            hfUserUpdateID.Value = _nID.ToString();
        }
        dbcom.sp_DeleteNormalTableByID(int.Parse(hfUserUpdateID.Value), "tb_User");
        ReBindPageList();
    }
}