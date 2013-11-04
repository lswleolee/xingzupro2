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

public partial class manage_Product_EditProduct : System.Web.UI.Page
{
    public int nPageRowCount
    {
        set
        {
            ViewState["nPageRowCounmanage_Product_EditProduct"] = value;
        }
        get
        {
            if (ViewState["nPageRowCounmanage_Product_EditProduct"] == null)
                ViewState["nPageRowCounmanage_Product_EditProduct"] = 10;
            return (int)ViewState["nPageRowCounmanage_Product_EditProduct"];
        }
    }
    public Model.dsProduct.tb_ProductDataTable ProductList
    {
        set {
            Cache.Remove("EditProducttb_ProductDataTable");
            Cache.Insert("EditProducttb_ProductDataTable", value, null, System.Web.Caching.Cache.NoAbsoluteExpiration, new TimeSpan(2, 0, 0));
             }
        get
        {
            if (Cache["EditProducttb_ProductDataTable"] == null)
            {
                Cache.Insert("EditProducttb_ProductDataTable", new Model.dsProduct.tb_ProductDataTable(), null, System.Web.Caching.Cache.NoAbsoluteExpiration, new TimeSpan(2, 0, 0));
            }
               
            return (Model.dsProduct.tb_ProductDataTable)Cache["EditProducttb_ProductDataTable"];
        }
        //set
        //{
        //    ViewState["EditProducttb_ProductDataTable"] = value;
        //}
        //get
        //{
        //    if (ViewState["EditProducttb_ProductDataTable"] == null)
        //        ViewState["EditProducttb_ProductDataTable"] = new Model.dsProduct.tb_ProductDataTable();
        //    return (Model.dsProduct.tb_ProductDataTable)ViewState["EditProducttb_ProductDataTable"];
        //}
    }
    public Model.dsProduct.tb_ProductImageDataTable ProductImageList
    {
        set
        {
            ViewState["EditProductImagetb_ProductImageDataTable"] = value;
        }
        get
        {
            if (ViewState["EditProductImagetb_ProductImageDataTable"] == null)
                ViewState["EditProductImagetb_ProductImageDataTable"] = new Model.dsProduct.tb_ProductImageDataTable();
            return (Model.dsProduct.tb_ProductImageDataTable)ViewState["EditProductImagetb_ProductImageDataTable"];
        }
    }
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            DBLL.OptionSysDBLL option = new DBLL.OptionSysDBLL();
            int nPageSize = 0;
            if (nPageRowCount <= 0)
            {
                if (int.TryParse(option.GetOptionValue("FormatSetting", "GridViewFormat", "RowsCountDefault"), out nPageSize))
                {
                    nPageRowCount = nPageSize;

                }
                else
                {
                    nPageRowCount = common.GetGridViewPageCount();
                }
                
            }
            DataPager1.PageSize = nPageRowCount;
            ReBindPageList();
           
        }
    }
    public void ReBindPageList()
    {
        DBLL.clsProduct Product = new DBLL.clsProduct();
        DataTable dt = new DataTable();
        dt = Product.sp_selectNormalTableOfAllByProduct(false);
        if (dt != null)
        {
            ProductList.Merge(dt);
            lvProductList.DataSource = ProductList;
            lvProductList.DataBind();
        }
        else
        {
            lvProductList.DataSource = null;
            lvProductList.DataBind();
        }
        DBLL.DBcommon dbcom = new DBLL.DBcommon();
        Model.dsProduct.tb_ProductCategoryDataTable ProductCategoryList = new Model.dsProduct.tb_ProductCategoryDataTable();
        ProductCategoryList.Merge(dbcom.selectNormalTableofAll(false, "tb_ProductCategory"));

        ddlProductCateTreelist1.ProductList = ProductCategoryList;
    }
    protected void lvProductList_PagePropertiesChanged(object sender, EventArgs e)
    {

       
        DataPager1.SetPageProperties(DataPager1.StartRowIndex, nPageRowCount, true); 
        lvProductList.DataSource = ProductList;
        lvProductList.DataBind();
    }
    protected void BtnUpdate_Click(object sender, EventArgs e)
    {
        //判断session
        if (Session["User"] == null || Session["User"].ToString().Length < 1) Response.Redirect(Request.RawUrl);
        try
        {
            if (ValiEdit())
            {
                DBLL.clsProduct Product = new DBLL.clsProduct();
                DBLL.OptionSysDBLL option = new DBLL.OptionSysDBLL();


                string sSavepath = "";
                //生成缩略图 
                HttpFileCollection postedFiles = Request.Files;
                if (postedFiles.Count > 0)
                {
                    if (postedFiles[0].ContentLength > 0)
                    {
                        System.Drawing.Image image, newimage; //定义image类的对象
                        string imagePath; 　 //图片路径
                        string imageType; 　 //图片类型
                        string imageName; 　 //图片名称
                        //提供一个回调方法,用于确定Image对象在执行生成缩略图操作时何时提前取消执行
                        //如果此方法确定 GetThumbnailImage 方法应提前停止执行，则返回 true；否则返回 false
                        System.Drawing.Image.GetThumbnailImageAbort callb = null;


                        string basepath = "~/ProductsUpload" + "/temp/" + DateTime.Now.Year.ToString() + DateTime.Now.Month.ToString() +
                            DateTime.Now.Day.ToString() + DateTime.Now.Hour.ToString() + DateTime.Now.Minute.ToString() +
                            DateTime.Now.Second.ToString() + "/";

                        string sSaveFolderFullPath = Server.MapPath(basepath);

                        if (!System.IO.Directory.Exists(sSaveFolderFullPath))
                        {
                            Directory.CreateDirectory(sSaveFolderFullPath);
                        }


                        string thbasepath = "~/ProductsUpload" + "/thumb/" + DateTime.Now.Year.ToString() + DateTime.Now.Month.ToString() +
                            DateTime.Now.Day.ToString() + DateTime.Now.Hour.ToString() + DateTime.Now.Minute.ToString() +
                            DateTime.Now.Second.ToString() + "/";

                        string thsSaveFolderFullPath = Server.MapPath(thbasepath);

                        if (!System.IO.Directory.Exists(thsSaveFolderFullPath))
                        {
                            Directory.CreateDirectory(thsSaveFolderFullPath);
                        }


                        imagePath = postedFiles[0].FileName;
                        //取得图片类型
                        imageType = imagePath.Substring(imagePath.LastIndexOf(".") + 1);
                        //取得图片名称
                        imageName = imagePath.Substring(imagePath.LastIndexOf("\\") + 1);
                        Stream imgStream = postedFiles[0].InputStream;//流文件，准备读取上载文件的内容
                        int imgLen = postedFiles[0].ContentLength;    //上载文件大小
                        //string imgName = txtImageName.Text;                   //图片名称


                        //string imgnm = txtImageName.Text;
                        byte[] imgBinaryData = new byte[imgLen];//


                        int n = imgStream.Read(imgBinaryData, 0, imgLen);



                        //保存到虚拟路径
                        postedFiles[0].SaveAs(sSaveFolderFullPath + "\\" + imageName);
                        ////显示原图
                        //imageSource.ImageUrl = "upFile/" + imageName;
                        //为上传的图片建立引用
                        image = System.Drawing.Image.FromFile(sSaveFolderFullPath + "\\" + imageName);

                        //int smallW = 100;//小图片宽
                        //int smallH = smallW * image.Height / image.Width;//小图片高

                        int smallH = 100;
                        int smallW = smallH * image.Width / image.Height;
                        //生成缩略图
                        newimage = image.GetThumbnailImage(smallW, smallH, callb, new System.IntPtr());
                        //把缩略图保存到指定的虚拟路径
                        newimage.Save(thsSaveFolderFullPath + "\\" + imageName);
                        //释放image对象占用的资源
                        image.Dispose();
                        //释放newimage对象的资源
                        newimage.Dispose();

                        sSavepath = thbasepath + imageName;
                    }
                }


                bool _Result = Product.update_tb_ProductBynProductID(int.Parse(hfProductUpdateID.Value), ddlProductCateTreelist2.nSelectProductCategoryID, cbbHot.Checked, sSavepath, txtsProductNameCN.Text, txtsProductNameEN.Text, txtsSummaryCN.Text, txtsSummaryEN.Text, txtsPlaceoforiginCN.Text, txtsPlaceoforiginEN.Text, txtsModelNoCN.Text, txtsModelNoEN.Text, txtsPriceTermsCN.Text, txtsPriceTermsEN.Text, txtsPaymentTermsCN.Text, txtsPaymentTermsEN.Text, txtsPackageCN.Text, txtsPackageEN.Text, txtsMinimumOrderCN.Text, txtsMinimumOrderEN.Text, txtsDeliveryTimeCN.Text, txtsDeliveryTimeEN.Text, txtsBrandNameCN.Text, txtsBrandNameEN.Text, CKEditorControl1.Text, CKEditorControl2.Text, Session["User"].ToString(), DateTime.Now, true, int.Parse(ddlnSorting.SelectedValue));
                if (_Result == true)
                {
                    int _ImageResult = 0;
                    MutileUploaderUserControl1.sNewName = txtsProductNameCN.Text;
                    MutileUploaderUserControl1.SavePath();
                    if (MutileUploaderUserControl1.filepathlist.Count > 0)
                    {
                        for (int i = 0; i < MutileUploaderUserControl1.filepathlist.Count; i++)
                        {
                            //Response.Write(MutileUploaderUserControl1.filepathlist[i]);
                            DBLL.clsProductImage ProductImage = new DBLL.clsProductImage();
                            _ImageResult = ProductImage.insert_tb_ProductImage(int.Parse(hfProductUpdateID.Value), MutileUploaderUserControl1.filenamelist[i].ToString(), txtsProductNameEN.Text, MutileUploaderUserControl1.filepathlist[i].ToString(), Session["User"].ToString(), DateTime.Now, Session["User"].ToString(), DateTime.Now, true, 1);
                        }
                    }
                    else
                    {
                        _ImageResult = 1;
                    }
                    if (_ImageResult > 0)
                    {
                        ShowMsg1.InnerContent = option.GetOptionValue("FormatSetting", "CommandControl", "InsertSuccess");
                        ShowMsg1.Show();
                        MultiView1.ActiveViewIndex = 0;
                        ReBindPageList();
                    }
                    else
                    {
                        ShowMsg1.InnerContent = option.GetOptionValue("FormatSetting", "CommandControl", "InsertFail");
                        ShowMsg1.Show();
                    }
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
        }
        catch (Exception)
        {

            throw;
        }
    }
    protected void lvProductList_SelectedIndexChanging(object sender, ListViewSelectEventArgs e)
    {
        Label lblnID = (Label)lvProductList.Items[e.NewSelectedIndex].FindControl("lblnProductID");
        int _nID = 0;
        DBLL.clsProduct Product = new DBLL.clsProduct();
        if (int.TryParse(lblnID.Text.Trim(), out _nID) && _nID > 0)
        {
            DBLL.DBcommon dbcom = new DBLL.DBcommon();
            Model.dsProduct.tb_ProductCategoryDataTable ProductList = new Model.dsProduct.tb_ProductCategoryDataTable();
            ProductList.Merge(dbcom.selectNormalTableofAll(false, "tb_ProductCategory"));
            ddlProductCateTreelist2.ProductList = ProductList;
            ddlProductCateTreelist2.Fresh();

            MultiView1.ActiveViewIndex = 1;
            DataTable dt = Product.Select_tb_ProductBynProductID(_nID);
            cbbHot.Checked = bool.Parse(dt.Rows[0]["bHot"].ToString());
            txtsProductNameCN.Text = dt.Rows[0]["sProductNameCN"].ToString();
            txtsProductNameEN.Text = dt.Rows[0]["sProductNameEN"].ToString();
            txtsSummaryCN.Text = dt.Rows[0]["sSummaryCN"].ToString();
            txtsSummaryEN.Text = dt.Rows[0]["sSummaryEN"].ToString();
            txtsPlaceoforiginCN.Text = dt.Rows[0]["sPlaceoforiginCN"].ToString();
            txtsPlaceoforiginEN.Text = dt.Rows[0]["sPlaceoforiginEN"].ToString();
            txtsModelNoCN.Text = dt.Rows[0]["sModelNoCN"].ToString();
            txtsModelNoEN.Text = dt.Rows[0]["sModelNoEN"].ToString();
            txtsPriceTermsCN.Text = dt.Rows[0]["sPriceTermsCN"].ToString();
            txtsPriceTermsEN.Text = dt.Rows[0]["sPriceTermsEN"].ToString();
            txtsPaymentTermsCN.Text = dt.Rows[0]["sPaymentTermsCN"].ToString();
            txtsPaymentTermsEN.Text = dt.Rows[0]["sPaymentTermsEN"].ToString();
            txtsPackageCN.Text = dt.Rows[0]["sPackageCN"].ToString();
            txtsPackageEN.Text = dt.Rows[0]["sPackageEN"].ToString();
            txtsMinimumOrderCN.Text = dt.Rows[0]["sMinimumOrderCN"].ToString();
            txtsMinimumOrderEN.Text = dt.Rows[0]["sMinimumOrderEN"].ToString();
            txtsDeliveryTimeCN.Text = dt.Rows[0]["sDeliveryTimeCN"].ToString();
            txtsDeliveryTimeEN.Text = dt.Rows[0]["sDeliveryTimeEN"].ToString();
            txtsBrandNameCN.Text = dt.Rows[0]["sBrandNameCN"].ToString();
            txtsBrandNameEN.Text = dt.Rows[0]["sBrandNameEN"].ToString();
            CKEditorControl1.Text = dt.Rows[0]["sIntroCN"].ToString();
            CKEditorControl2.Text = dt.Rows[0]["sIntroEN"].ToString();
            ddlnSorting.SelectedValue = dt.Rows[0]["nSorting"].ToString();
            //ddlProductCateTreelist2.nSelectProductCategoryID = int.Parse(dt.Rows[0]["nProductCategoryID"].ToString());
            ddlProductCateTreelist2.setnSelectID(int.Parse(dt.Rows[0]["nProductCategoryID"].ToString()));
            MutileUploaderUserControl1.Refresh();
            DBLL.clsProductImage ProductImage = new DBLL.clsProductImage();
            DataTable Imagedt = new DataTable();
            Imagedt = ProductImage.Select_tb_ProductImageBynProductID(_nID);
            if (Imagedt != null)
            {
                ProductImageList.Clear();
                ProductImageList.Merge(Imagedt);
                lvProductImageList.DataSource = ProductImageList;
                lvProductImageList.DataBind();
            }
            else
            {
                ProductImageList.Clear();
                lvProductImageList.DataSource = ProductImageList;
                lvProductImageList.DataBind();
            }
            Button1.Text = "显示图片";
            lvProductImageList.Visible = false;
            hfProductUpdateID.Value = _nID.ToString();
        }
    }
    protected void lvProductList_ItemDataBound(object sender, ListViewItemEventArgs e)
    {
        try
        {

            DBLL.OptionSysDBLL option = new DBLL.OptionSysDBLL();
            DBLL.clsProductCategory ProductCategory = new DBLL.clsProductCategory();
            if (e.Item.ItemType == ListViewItemType.DataItem)
            {
                int nType = 0;
                Label lblnProductCategoryID = (Label)e.Item.FindControl("lblnProductCategoryID");
                if (int.TryParse(lblnProductCategoryID.Text, out nType))
                {
                    nType = int.Parse(lblnProductCategoryID.Text);
                    string sTopicName = ProductCategory.Select_tb_ProductCategoryBynProductCategoryID(nType).Rows[0]["sProductCategoryNameCN"].ToString();
                    lblnProductCategoryID.Text = sTopicName;
                }
            }
            ImageButton imgDelete = (ImageButton)e.Item.FindControl("imgDelete");
            imgDelete.OnClientClick = "javascript:if (confirm('" + option.GetOptionValue("FormatSetting", "CommandControl", "bIsDelete") + "')){$('#EntryForm').block({ message: null });}else{return false;}";

        }
        catch (Exception)
        {

        }
    }
    protected void lvProductList_ItemDeleting(object sender, ListViewDeleteEventArgs e)
    {
        DBLL.DBcommon dbcom = new DBLL.DBcommon();
        Label lblnID = (Label)lvProductList.Items[e.ItemIndex].FindControl("lblnProductID");
        int _nID = 0;
        if (int.TryParse(lblnID.Text.Trim(), out _nID) && _nID > 0)
        {
            hfProductUpdateID.Value = _nID.ToString();
        }
        dbcom.sp_DeleteNormalTableByID(int.Parse(hfProductUpdateID.Value), "tb_Product");
        ProductList.Rows.RemoveAt(e.ItemIndex);
        ReBindPageList();
    }
    protected bool ValiEdit()
    {
        bool bcheck = true;
        ShowMsg1.InnerContent = "";
        DBLL.clsProductCategory ProductCategory = new DBLL.clsProductCategory();
        DataTable dt = new DataTable();
        dt = ProductCategory.Select_tb_ProductCategoryBynParentCategoryID(ddlProductCateTreelist2.nSelectProductCategoryID);
        if (dt != null)
        {
            ShowMsg1.InnerContent += "你选择的产品类型不是最尾级,请确认<br/>";
            bcheck = false;
        }
        if (string.IsNullOrEmpty(txtsProductNameCN.Text))
        {
            ShowMsg1.InnerContent += "产品名称(中文)不能为空<br/>";
            bcheck = false;
        }
        if (string.IsNullOrEmpty(txtsProductNameEN.Text))
        {
            ShowMsg1.InnerContent += "产品名称(英文)不能为空<br/>";
            bcheck = false;
        }
        return bcheck;
    }
    protected void btnBackToList_Click(object sender, EventArgs e)
    {
        MultiView1.ActiveViewIndex = 0;
        ReBindPageList();
    }
    protected void lvProductImageList_ItemDataBound(object sender, ListViewItemEventArgs e)
    {
        try
        {
            DBLL.OptionSysDBLL option = new DBLL.OptionSysDBLL();
            ImageButton imgDelete1 = (ImageButton)e.Item.FindControl("imgDelete1");
            imgDelete1.OnClientClick = "javascript:if (confirm('" + option.GetOptionValue("FormatSetting", "CommandControl", "bIsDelete") + "')){$('#EntryForm').block({ message: null });}else{return false;}";

        }
        catch (Exception)
        {
        }
    }
    protected void lvProductImageList_ItemDeleting(object sender, ListViewDeleteEventArgs e)
    {
        DBLL.clsProductImage ProductImage = new DBLL.clsProductImage();
        Label lblnID = (Label)lvProductImageList.Items[e.ItemIndex].FindControl("lblnPImageID");
        int _nID = 0;
        if (int.TryParse(lblnID.Text.Trim(), out _nID) && _nID > 0)
        {
            bool Result = ProductImage.sp_DeleteNormalTableByIDProductImage(int.Parse(_nID.ToString()), "tb_ProductImage");
            if (Result)
            {
                //判断文件是不是存在
                Image ImsPImagePath = (Image)lvProductImageList.Items[e.ItemIndex].FindControl("ImsPImagePath");
                string sSaveFolderFullPath = Server.MapPath(ImsPImagePath.ImageUrl);
                if (File.Exists(sSaveFolderFullPath))
                {
                    //如果存在则删除
                    File.Delete(sSaveFolderFullPath);

                    System.IO.DirectoryInfo dir = new System.IO.DirectoryInfo(sSaveFolderFullPath.Substring(0, sSaveFolderFullPath.LastIndexOf("\\")).ToString());
                    System.IO.FileInfo[] dirs = dir.GetFiles();
                    if (dirs.Length > 0)
                    {
                        //有子文件夹
                    }
                    else
                    {
                        Directory.Delete(sSaveFolderFullPath.Substring(0, sSaveFolderFullPath.LastIndexOf("\\")).ToString());
                    }

                    DataTable Imagedt = new DataTable();
                    Imagedt = ProductImage.Select_tb_ProductImageBynProductID(int.Parse(hfProductUpdateID.Value));
                    if (Imagedt != null)
                    {
                        ProductImageList.Clear();
                        ProductImageList.Merge(Imagedt);
                        lvProductImageList.DataSource = ProductImageList;
                        lvProductImageList.DataBind();
                    }
                    else
                    {
                        ProductImageList.Clear();
                        lvProductImageList.DataSource = ProductImageList;
                        lvProductImageList.DataBind();
                    }
                }
            }
        }
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        if (Button1.Text == "显示图片")
        {
            Button1.Text = "隐藏图片";
            lvProductImageList.Visible = true;
        }
        else if (Button1.Text == "隐藏图片")
        {
            Button1.Text = "显示图片";
            lvProductImageList.Visible = false;
        }
    }
    protected void btnSearch_Click(object sender, EventArgs e)
    {
        string sSearch = txtSearch.Text;
        DBLL.clsProduct clspdc = new DBLL.clsProduct();
        DataTable dtpdc = new DataTable();
        if (ddlProductCateTreelist1.nSelectProductCategoryID > 0)
        {
            dtpdc = clspdc.Select_tb_ProductBynParentCategoryID(ddlProductCateTreelist1.nSelectProductCategoryID);
        }
        else dtpdc = clspdc.sp_selectNormalTableOfAllByProduct(false);
        if (dtpdc != null && dtpdc.Rows.Count > 0)
        {
            Model.dsProduct.tb_ProductDataTable dtSearchpdc = new Model.dsProduct.tb_ProductDataTable();
            string cmd = "sProductNameCN like '%" + sSearch + "%' ";
            cmd += " or ";
            cmd += "sProductNameEN like '%" + sSearch + "%' ";
            cmd += " or ";
            cmd += "sSummaryCN like '%" + sSearch + "%' ";
            cmd += " or ";
            cmd += "sSummaryEN like '%" + sSearch + "%' ";
            DataRow[] rows = dtpdc.Select(cmd);
            foreach (DataRow row in rows)
            {
                Model.dsProduct.tb_ProductRow Searchrow = dtSearchpdc.Newtb_ProductRow();
                foreach (DataColumn col in dtpdc.Columns)
                {
                    Searchrow[col.ColumnName] = row[col.ColumnName];
                }
                dtSearchpdc.Rows.Add(Searchrow);
            }
            ProductList = new Model.dsProduct.tb_ProductDataTable();
            ProductList.Merge(dtSearchpdc);
            lvProductList.DataSource = dtSearchpdc;
            lvProductList.DataBind();

       
        }
        //////old
        //DBLL.clsProduct clspdc = new DBLL.clsProduct();
        //DataTable dtpdc = new DataTable();
        //if (ddlProductCateTreelist1.nSelectProductCategoryID > 0)
        //{
        //    dtpdc = clspdc.Select_tb_ProductBynProductCategoryID(ddlProductCateTreelist1.nSelectProductCategoryID);
        //    if (dtpdc != null)
        //    {
        //        ProductList.Clear();
        //        ProductList.Merge(dtpdc);
        //        lvProductList.DataSource = ProductList;
        //        lvProductList.DataBind();
        //    }
        //    else
        //    {
        //        lvProductList.DataSource = null;
        //        lvProductList.DataBind();
        //    }
        //}
    }
}