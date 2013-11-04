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

public partial class manage_Inquiry_Inquiry : System.Web.UI.Page
{

    public Model.dsProduct.tb_InquiryDataTable InquiryList
    {
        set
        {
            ViewState["Inquirytb_InquiryDataTable"] = value;
        }
        get
        {
            if (ViewState["Inquirytb_InquiryDataTable"] == null)
                ViewState["Inquirytb_InquiryDataTable"] = new Model.dsProduct.tb_InquiryDataTable();
            return (Model.dsProduct.tb_InquiryDataTable)ViewState["Inquirytb_InquiryDataTable"];
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
    protected void lvInquiryList_PagePropertiesChanged(object sender, EventArgs e)
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

        lvInquiryList.DataSource = InquiryList;
        lvInquiryList.DataBind();
    }
    public void ReBindPageList()
    {
        DBLL.clsInquiry Inquiry = new DBLL.clsInquiry();
        DataTable dt = new DataTable();
        dt = Inquiry.sp_selectNormalTableOfAllByInquiry(false);
        if (dt != null)
        {
            InquiryList.Merge(dt);
            lvInquiryList.DataSource = InquiryList;
            lvInquiryList.DataBind();
        }
        else
        {
            lvInquiryList.DataSource = null;
            lvInquiryList.DataBind();
        }
    }
    protected void btnBackToList_Click(object sender, EventArgs e)
    {
        MultiView1.ActiveViewIndex = 0;
        ReBindPageList();
    }
    protected void BtnUpdate_Click(object sender, EventArgs e)
    {
        //判断session
        if (Session["User"] == null || Session["User"].ToString().Length < 1) Response.Redirect(Request.RawUrl);
        try
        {
            //if (ValiEdit())
            //{
            DBLL.clsInquiry Inquiry = new DBLL.clsInquiry();
                DBLL.OptionSysDBLL option = new DBLL.OptionSysDBLL();
                bool _Result = Inquiry.update_tb_InquiryBynInquiryIDAndbCheck(int.Parse(hfInquiryUpdateID.Value), true);
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
            //}
        }
        catch (Exception)
        {

            throw;
        }
    }
    //protected bool ValiEdit()
    //{
    //    bool bcheck = true;
    //    ShowMsg1.InnerContent = "";
    //    if (string.IsNullOrEmpty(txtsLink.Text))
    //    {
    //        ShowMsg1.InnerContent += "联系不能为空<br/>";
    //        bcheck = false;
    //    }
    //    return bcheck;
    //}
    protected void lvInquiryList_ItemDataBound(object sender, ListViewItemEventArgs e)
    {
        try
        {
            //if (e.Item.ItemType == ListViewItemType.DataItem)
            //{
            //    Label lblsTitle = (Label)e.Item.FindControl("lblsTitle");
            //    lblsTitle.Text = lblsTitle.Text.Substring(0, 8).ToString() + "....";
            //    Label lblsContents = (Label)e.Item.FindControl("lblsContents");
            //    lblsContents.Text = lblsContents.Text.Substring(0, 16).ToString() + "....";
            //}
            //DBLL.OptionSysDBLL option = new DBLL.OptionSysDBLL();
            //ImageButton imgDelete = (ImageButton)e.Item.FindControl("imgDelete");
            //imgDelete.OnClientClick = "javascript:if (confirm('" + option.GetOptionValue("FormatSetting", "CommandControl", "bIsDelete") + "')){$('#EntryForm').block({ message: null });}else{return false;}";

        }
        catch (Exception)
        {
        }
    }
    //protected void lvContactList_ItemDeleting(object sender, ListViewDeleteEventArgs e)
    //{
    //    DBLL.DBcommon dbcom = new DBLL.DBcommon();
    //    Label lblnID = (Label)lvContactList.Items[e.ItemIndex].FindControl("lblnLinkID");
    //    int _nID = 0;
    //    if (int.TryParse(lblnID.Text.Trim(), out _nID) && _nID > 0)
    //    {
    //        hfContactUpdateID.Value = _nID.ToString();
    //    }
    //    dbcom.sp_DeleteNormalTableByID(int.Parse(hfContactUpdateID.Value), "tb_Link");
    //    ReBindPageList();
    //}
    protected void lvInquiryList_SelectedIndexChanging(object sender, ListViewSelectEventArgs e)
    {
        Label lblnID = (Label)lvInquiryList.Items[e.NewSelectedIndex].FindControl("lblnInquiryID");
        int _nID = 0;
        DBLL.clsInquiry Inquiry = new DBLL.clsInquiry();
        DBLL.clsProduct Product = new DBLL.clsProduct();
        //ArrayList ProductList = new ArrayList();
        if (int.TryParse(lblnID.Text.Trim(), out _nID) && _nID > 0)
        {
            MultiView1.ActiveViewIndex = 1;
            DataTable dt = Inquiry.Select_tb_InquiryBynInquiryID(_nID);
            txtsFirstName.Text = dt.Rows[0]["sFirstName"].ToString();
            if (dt.Rows[0]["nSex"].ToString() == "1")
                txtnSex.Text = "男";
            else
                txtnSex.Text = "女";
            txtsSubject.Text = dt.Rows[0]["sSubject"].ToString();
            txtsEmail.Text = dt.Rows[0]["sEmail"].ToString();
            txtsCountry.Text = dt.Rows[0]["sCountry"].ToString();
            if (dt.Rows[0]["sProductIDList"].ToString() != "")
            {
                string ProductL = "";
                string[] ProductList = dt.Rows[0]["sProductIDList"].ToString().Split(',');
                for (int i = 0; i < ProductList.Length; i++)
                {
                    DataTable Productdt = Product.Select_tb_ProductBynProductID(int.Parse(ProductList[i].ToString()));
                    if (Productdt.Rows.Count > 0)
                    {
                        ProductL = ProductL + Productdt.Rows[0]["sProductNameCN"].ToString()+",";
                    }
                }
                txtsProductIDList.Text = ProductL.Substring(0, ProductL.Length - 1);
            }
            hfInquiryUpdateID.Value = _nID.ToString();
        }
    }
}