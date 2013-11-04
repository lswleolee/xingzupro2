using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class usercontrol_DataList_Treebar : System.Web.UI.UserControl
{
    
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            try
            {

                TreeView1.ExpandDepth = 0;

            }
            catch (Exception)
            {
                
                throw;
            }
           
        }
    }
    public void SetNode(TreeNode[] nodepages)
    {
        TreeView1.Nodes.Clear();
        if (nodepages != null && nodepages.Length > 0)
        {
            for (int i = 0; i < nodepages.Length; i++)
            {

                TreeView1.Nodes.Add(nodepages[i]);
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
    protected void TreeView1_SelectedNodeChanged1(object sender, EventArgs e)
    {

    }
}