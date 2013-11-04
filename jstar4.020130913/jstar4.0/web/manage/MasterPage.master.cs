using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class managepage_MasterPage : System.Web.UI.MasterPage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (Session["UserID"] != null  && Session["User"] != null)
            {
                lblusername.Text = Session["User"].ToString();
                
            }
            else
            {
                Response.Redirect("~/manage/Login.aspx");
                //lblusername.Text = "admin";
                //Session["User"] = "admin";
            }
        }
    }
    protected void TreeView1_SelectedNodeChanged(object sender, EventArgs e)
    {
        for (int i = 0; i < this.TreeView1.Nodes.Count; i++)
        {//跌迭根节点
            if (this.TreeView1.SelectedNode.Parent == null)
            {
                if (this.TreeView1.SelectedValue == this.TreeView1.Nodes[i].Value)
                {//如果选中的是根节点,就展开

                    this.TreeView1.SelectedNode.Expanded = true;
                }
                else
                {//如果选中的不是根节点

                    
                    this.TreeView1.Nodes[i].Expanded = false;

                }
            }
        }

        //if (TreeView1.SelectedNode.Expanded == true)
        //{
        //    TreeView1.SelectedNode.Expanded = false;
        //}
        //else TreeView1.SelectedNode.Expanded = true;
    }
    protected void lbtnLogOut_Click(object sender, EventArgs e)
    {
        Session.Clear();
        Response.Redirect("Login.aspx");
    }
}
