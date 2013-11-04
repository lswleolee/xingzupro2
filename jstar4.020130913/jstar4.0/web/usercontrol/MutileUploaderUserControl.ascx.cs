using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Collections;
using System.IO;
using System.Configuration;
public partial class usercontrol_MutileUploaderUserControl : System.Web.UI.UserControl
{
    public string sSaveFolderPath
    {
        get
        {
            if (ViewState["SaveFolderPathUploaderUserControl"] == null)
            {
                ViewState["SaveFolderPathUploaderUserControl"] = "";
            }
            return ViewState["SaveFolderPathUploaderUserControl"].ToString();
        }
        set
        {
            ViewState["SaveFolderPathUploaderUserControl"] = value;
        }
    }
    public ArrayList filepathlist
    {
        get
        {
            if (ViewState["SavePathUploaderUserControl"] == null)
            {
                ViewState["SavePathUploaderUserControl"] = new ArrayList();
            }
            return (ArrayList)ViewState["SavePathUploaderUserControl"];
        }
        set
        {
            ViewState["SavePathUploaderUserControl"] = value;
        }

    }
    public ArrayList filenamelist
    {
        get
        {
            if (ViewState["SavenameUploaderUserControl"] == null)
            {
                ViewState["SavenameUploaderUserControl"] = new ArrayList();
            }
            return (ArrayList)ViewState["SavenameUploaderUserControl"];
        }
        set
        {
            ViewState["SavenameUploaderUserControl"] = value;
        }

    }
    public string sNewName
    {
        get
        {
            if (ViewState["sNewNameUploaderUserControl"] == null)
            {
                ViewState["sNewNameUploaderUserControl"] = "";
            }
            return ViewState["sNewNameUploaderUserControl"].ToString();
        }
        set
        {
            ViewState["sNewNameUploaderUserControl"] = value;
        }
    }





    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            //ViewState["dtFileList"] = null;
            //DataTable dtFileList = new DataTable();
            //DataColumn col = new DataColumn("sFilename");
            //dtFileList.Columns.Add(col);
            //DataColumn col1 = new DataColumn("nID");
            //dtFileList.Columns.Add(col1);
            //ViewState["dtFileList"] = dtFileList;
            //gvFileList.DataSource = dtFileList;
            //gvFileList.DataBind();
        }

    }

    public void Refresh()
    {
        gvFileList.DataSource = null;
        gvFileList.DataBind();
    }
    public void SavePath()
    {
        ArrayList filelist = new ArrayList();
        ArrayList namelist = new ArrayList();
        DataTable dtFileList = new DataTable();
        DataColumn col = new DataColumn("sFilename");
        dtFileList.Columns.Add(col);
        DataColumn col1 = new DataColumn("nID");
        dtFileList.Columns.Add(col1);

        HttpFileCollection postedFiles = Request.Files;
        for (int i = 0; i < postedFiles.Count; i++)
        {
            if (postedFiles[i].ContentLength > 0)
            {
                DataRow newrow = dtFileList.NewRow();
                newrow["sFilename"] = postedFiles[i].FileName;
                newrow["nID"] = i.ToString();
                dtFileList.Rows.Add(newrow);
                string basepath = "";


                if (sSaveFolderPath != "")
                    basepath = sSaveFolderPath + "/" + DateTime.Now.Year.ToString() + DateTime.Now.Month.ToString() +
                        DateTime.Now.Day.ToString() + DateTime.Now.Hour.ToString() + DateTime.Now.Minute.ToString() +
                        DateTime.Now.Second.ToString() + "/";

                else

                    basepath = "~/ProductsUpload" + "/" + DateTime.Now.Year.ToString() + DateTime.Now.Month.ToString() +
                        DateTime.Now.Day.ToString() + DateTime.Now.Hour.ToString() + DateTime.Now.Minute.ToString() +
                        DateTime.Now.Second.ToString() + "/";



                string filename = postedFiles[i].FileName.Substring(postedFiles[i].FileName.LastIndexOf("\\") + 1);
                if (sNewName != "" && sNewName.Length > 0)
                {
                    filename = sNewName + i + filename.Substring(filename.LastIndexOf("."));
                    string type = postedFiles[i].FileName.Substring(postedFiles[i].FileName.LastIndexOf(".") + 1);//获取文件类型
                    if (type == "jpg")
                    {
                        string sSaveFolderFullPath = Server.MapPath(basepath);

                        if (!System.IO.Directory.Exists(sSaveFolderFullPath))
                        {
                            Directory.CreateDirectory(sSaveFolderFullPath);
                        }
                        string filefullpath = sSaveFolderFullPath + filename;
                        string sSavepath = basepath + filename;
                        postedFiles[i].SaveAs(filefullpath);
                        namelist.Add(filename);
                        filelist.Add(sSavepath);
                        #region----第一幅图片做缩略图
                        //if (i == 0)
                        //{
                        //    System.Drawing.Image image, newimage; //定义image类的对象
                        //    string imagePath; 　 //图片路径
                        //    string imageType; 　 //图片类型
                        //    string imageName; 　 //图片名称
                        //    //提供一个回调方法,用于确定Image对象在执行生成缩略图操作时何时提前取消执行
                        //    //如果此方法确定 GetThumbnailImage 方法应提前停止执行，则返回 true；否则返回 false
                        //    System.Drawing.Image.GetThumbnailImageAbort callb = null;


                        //    string tebasepath = "~/ProductsUpload" + "/temp/" + DateTime.Now.Year.ToString() + DateTime.Now.Month.ToString() +
                        //                             DateTime.Now.Day.ToString() + DateTime.Now.Hour.ToString() + DateTime.Now.Minute.ToString() +
                        //                             DateTime.Now.Second.ToString() + "/";

                        //    string steSaveFolderFullPath = Server.MapPath(tebasepath);

                        //    if (!System.IO.Directory.Exists(steSaveFolderFullPath))
                        //    {
                        //        Directory.CreateDirectory(steSaveFolderFullPath);
                        //    }


                        //    string thbasepath = "~/ProductsUpload" + "/thumb/" + DateTime.Now.Year.ToString() + DateTime.Now.Month.ToString() +
                        //        DateTime.Now.Day.ToString() + DateTime.Now.Hour.ToString() + DateTime.Now.Minute.ToString() +
                        //        DateTime.Now.Second.ToString() + "/";

                        //    string thsSaveFolderFullPath = Server.MapPath(thbasepath);

                        //    if (!System.IO.Directory.Exists(thsSaveFolderFullPath))
                        //    {
                        //        Directory.CreateDirectory(thsSaveFolderFullPath);
                        //    }


                        //    imagePath = postedFiles[0].FileName;
                        //    //取得图片类型
                        //    imageType = imagePath.Substring(imagePath.LastIndexOf(".") + 1);
                        //    //取得图片名称
                        //    imageName = imagePath.Substring(imagePath.LastIndexOf("\\") + 1);
                        //    Stream imgStream = postedFiles[0].InputStream;//流文件，准备读取上载文件的内容
                        //    int imgLen = postedFiles[0].ContentLength;    //上载文件大小
                        //    //string imgName = txtImageName.Text;                   //图片名称


                        //    //string imgnm = txtImageName.Text;
                        //    byte[] imgBinaryData = new byte[imgLen];//


                        //    int n = imgStream.Read(imgBinaryData, 0, imgLen);



                        //    //保存到虚拟路径
                        //    postedFiles[0].SaveAs(steSaveFolderFullPath + "\\" + imageName);
                        //    ////显示原图
                        //    //imageSource.ImageUrl = "upFile/" + imageName;
                        //    //为上传的图片建立引用
                        //    image = System.Drawing.Image.FromFile(steSaveFolderFullPath + "\\" + imageName);

                        //    //int smallW = 100;//小图片宽
                        //    //int smallH = smallW * image.Height / image.Width;//小图片高

                        //    int smallH = 100;
                        //    int smallW = smallH * image.Width / image.Height;
                        //    //生成缩略图
                        //    newimage = image.GetThumbnailImage(smallW, smallH, callb, new System.IntPtr());
                        //    //把缩略图保存到指定的虚拟路径
                        //    newimage.Save(thsSaveFolderFullPath + "\\" + imageName);
                        //    //释放image对象占用的资源
                        //    image.Dispose();
                        //    //释放newimage对象的资源
                        //    newimage.Dispose();
                        //}
                        #endregion
                    }
                    else
                    {
                        Response.Write("<script type=text/javascript>alert('你的图片格式不正确')</script>");
                    }
                }
            }
        }
        filenamelist = namelist;
        filepathlist = filelist;
        gvFileList.DataSource = dtFileList;
        gvFileList.DataBind();
    }

}