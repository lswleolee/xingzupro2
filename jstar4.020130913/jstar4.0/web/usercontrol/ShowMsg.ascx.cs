using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
public partial class usercontrol_ShowMsg : System.Web.UI.UserControl
{
    public event EventHandler RenderOk;
    public bool bPostBack
    {
        get
        {
            if (ViewState["bPostBackShowMsgUserControl"] == null)
            {
                ViewState["bPostBackShowMsgUserControl"] = true;
            }
            return (bool)ViewState["bPostBackShowMsgUserControl"];
        }
        set
        {
            ViewState["bPostBackShowMsgUserControl"] = value;
        }
    }

    public string TitleName
    {
        get
        {
            if (ViewState["TitleNameShowMsgUserControl"] == null)
            {
                ViewState["TitleNameShowMsgUserControl"] = "系统提示";
            }
            return ViewState["TitleNameShowMsgUserControl"].ToString();
        }
        set
        {
            ViewState["TitleNameShowMsgUserControl"] = value;
        }
    }
    public string InnerContent
    {
        get
        {
            if (ViewState["InnerContentShowMsgUserControl"] == null)
            {
                ViewState["InnerContentShowMsgUserControl"] = "";
            }
            return ViewState["InnerContentShowMsgUserControl"].ToString();
        }
        set
        {
            ViewState["InnerContentShowMsgUserControl"] = value;
        }
    }
    protected void Page_Load(object sender, EventArgs e)
    {
        
        if (!IsPostBack)
        {
            PanelModal.Attributes["display"] = "none";
            //PanelModal.Visible = false;
            divInnerContent.InnerHtml = InnerContent;
            lblTitle.Text = TitleName;
        }
    }
    public void Show()
    {
        PanelModal.Attributes["display"] = "";
        divInnerContent.InnerHtml = InnerContent;
        lblTitle.Text = TitleName;
        ModalPopupExtender1.Show();
    }
    protected void btnModalOK_Click(object sender, EventArgs e)
    {
        PanelModal.Attributes["display"] = "none";
        //PanelModal.Visible = false;
        if (RenderOk != null )
        {
            RenderOk(this, new EventArgs());
            ModalPopupExtender1.Hide();
        }
        else ModalPopupExtender1.Hide();
        
    }
}