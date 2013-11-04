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
using ASPNETAJAXWeb.AjaxEBusiness;
using System.IO;
public partial class manage_Product_AddProduct : System.Web.UI.Page
{
    private string url = "";
    private string fullPath = "";
    private string fileName = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            DBLL.DBcommon dbcom = new DBLL.DBcommon();
            Model.dsProduct.tb_ProductCategoryDataTable ProductList = new Model.dsProduct.tb_ProductCategoryDataTable();
            ProductList.Merge(dbcom.selectNormalTableofAll(false, "tb_ProductCategory"));

            ddlProductCateTreelist2.ProductList = ProductList;
        }
    }
    protected void BtnAdd_Click(object sender, EventArgs e)
    {
        //判断session
        if (Session["User"] == null || Session["User"].ToString().Length < 1) Response.Redirect(Request.RawUrl);
        if (ValiAdd())
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


            int _Result = Product.insert_tb_Product(ddlProductCateTreelist2.nSelectProductCategoryID, cbbHot.Checked, sSavepath, txtsProductNameCN.Text, txtsProductNameEN.Text, txtsSummaryCN.Text, txtsSummaryEN.Text, txtsPlaceoforiginCN.Text, txtsPlaceoforiginEN.Text, txtsModelNoCN.Text, txtsModelNoEN.Text, txtsPriceTermsCN.Text, txtsPriceTermsEN.Text, txtsPaymentTermsCN.Text, txtsPaymentTermsEN.Text, txtsPackageCN.Text, txtsPackageEN.Text, txtsMinimumOrderCN.Text, txtsMinimumOrderEN.Text, txtsDeliveryTimeCN.Text, txtsDeliveryTimeEN.Text, txtsBrandNameCN.Text, txtsBrandNameEN.Text, CKEditorControl1.Text, CKEditorControl2.Text, Session["User"].ToString(), DateTime.Now, Session["User"].ToString(), DateTime.Now, true, int.Parse(ddlnSorting.SelectedValue));
            if (_Result > 0)
            {
                int _ImageResult = 0;
                MutileUploaderUserControl1.sNewName = txtsProductNameCN.Text;
                MutileUploaderUserControl1.SavePath();
                for (int i = 0; i < MutileUploaderUserControl1.filepathlist.Count; i++)
                {
                    //Response.Write(MutileUploaderUserControl1.filepathlist[i]);
                    DBLL.clsProductImage ProductImage = new DBLL.clsProductImage();
                    _ImageResult = ProductImage.insert_tb_ProductImage(_Result, MutileUploaderUserControl1.filenamelist[i].ToString(), txtsProductNameEN.Text, MutileUploaderUserControl1.filepathlist[i].ToString(), Session["User"].ToString(), DateTime.Now, Session["User"].ToString(), DateTime.Now, true, 1);
                }
                if (_ImageResult > 0)
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
        cbbHot.Checked = false;
        txtsProductNameCN.Text = "";
        txtsProductNameEN.Text = "";
        txtsSummaryCN.Text = "";
        txtsSummaryEN.Text = "";
        txtsPlaceoforiginCN.Text = "";
        txtsPlaceoforiginEN.Text = "";
        txtsModelNoCN.Text = "";
        txtsModelNoEN.Text = "";
        txtsPriceTermsCN.Text = "";
        txtsPriceTermsEN.Text = "";
        txtsPaymentTermsCN.Text = "";
        txtsPaymentTermsEN.Text = "";
        txtsPackageCN.Text = "";
        txtsPackageEN.Text = "";
        txtsMinimumOrderCN.Text = "";
        txtsMinimumOrderEN.Text = "";
        txtsDeliveryTimeCN.Text = "";
        txtsDeliveryTimeEN.Text = "";
        txtsBrandNameCN.Text = "";
        txtsBrandNameEN.Text = "";
        CKEditorControl1.Text = "";
        CKEditorControl2.Text = "";
        ddlnSorting.SelectedIndex = 0;
        DBLL.DBcommon dbcom = new DBLL.DBcommon();
        Model.dsProduct.tb_ProductCategoryDataTable ProductList = new Model.dsProduct.tb_ProductCategoryDataTable();
        ProductList.Merge(dbcom.selectNormalTableofAll(false, "tb_ProductCategory"));

        ddlProductCateTreelist2.ProductList = ProductList;
        ddlProductCateTreelist2.Fresh();
    }
    protected bool ValiAdd()
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
}