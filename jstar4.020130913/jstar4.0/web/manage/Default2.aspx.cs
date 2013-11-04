using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.IO;
public partial class manage_Default2 : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            DBLL.clsProduct productdt=new DBLL.clsProduct();
            DBLL.clsProductImage proimage=new DBLL.clsProductImage();
            DBLL.DBcommon DBcommon=new DBLL.DBcommon();
            DataTable dtp = productdt.sp_selectNormalTableOfAllByProduct(false);
            DataTable dtpi = DBcommon.GetDataTable("select * from tb_ProductImage where bEnable=1 order by dCreatedTime desc");
            for (int i = 0; i < dtp.Rows.Count; i++)
            {
                try
                {
                    DataRow[] pirow = dtpi.Select("nProductID=" + dtp.Rows[i]["nProductID"].ToString());
                    string sSavepath = "";
                    if (pirow.Length > 0)
                    {

                        string yuanpath = pirow[0]["sPImagePath"].ToString();

                        System.Drawing.Image image, newimage; //定义image类的对象
                        string imagePath; 　 //图片路径
                        string imageType; 　 //图片类型
                        string imageName; 　 //图片名称
                        //提供一个回调方法,用于确定Image对象在执行生成缩略图操作时何时提前取消执行
                        //如果此方法确定 GetThumbnailImage 方法应提前停止执行，则返回 true；否则返回 false
                        System.Drawing.Image.GetThumbnailImageAbort callb = null;




                        string thbasepath = "~/ProductsUpload" + "/thumb/" + DateTime.Now.Year.ToString() + DateTime.Now.Month.ToString() +
                            DateTime.Now.Day.ToString() + DateTime.Now.Hour.ToString() + DateTime.Now.Minute.ToString() +
                            DateTime.Now.Second.ToString() + dtp.Rows[i]["nProductID"].ToString() + "/";

                        string thsSaveFolderFullPath = Server.MapPath(thbasepath);

                        if (!System.IO.Directory.Exists(thsSaveFolderFullPath))
                        {
                            Directory.CreateDirectory(thsSaveFolderFullPath);
                        }

                        StreamReader re = new StreamReader(Server.MapPath(yuanpath));
                        image = System.Drawing.Image.FromFile(Server.MapPath(yuanpath));
                        imagePath = yuanpath;
                        //取得图片类型
                        imageType = imagePath.Substring(imagePath.LastIndexOf(".") + 1);
                        //取得图片名称
                        imageName = imagePath.Substring(imagePath.LastIndexOf("/") + 1);




                        ////显示原图
                        //imageSource.ImageUrl = "upFile/" + imageName;
                        //为上传的图片建立引用


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
                    DBcommon.Excute("update tb_Product set sThumbPath='" + sSavepath + "' where nProductID=" + dtp.Rows[i]["nProductID"].ToString());
              
                }
                catch (Exception)
                {
                    
                    
                }
              

             
            }
        }
    }
}