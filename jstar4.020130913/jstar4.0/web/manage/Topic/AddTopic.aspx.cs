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

public partial class manage_Topic_AddTopic : System.Web.UI.Page
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
            DBLL.clsTopic Topic = new DBLL.clsTopic();
            int _Result = Topic.insert_tb_Topic(txtsTopicNameCN.Text, txtsTopicNameEN.Text, Session["User"].ToString(), DateTime.Now, Session["User"].ToString(), DateTime.Now, true, int.Parse(ddlnSorting.SelectedValue));
            if (_Result > 0)
            {
                Clear();
            }
            else
            {
            }
        }
        else
        {

        }
    }
    protected void BtnClear_Click(object sender, EventArgs e)
    {
        Clear();
    }
    public void Clear()
    {
        txtsTopicNameCN.Text = "";
        txtsTopicNameEN.Text = "";
        ddlnSorting.SelectedIndex = 1;
    }
    protected bool ValiAdd()
    {
        bool bcheck = true;
        return bcheck;
    }
}