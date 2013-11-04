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
public partial class usercontrol_MutileUploaderUserControl2 : System.Web.UI.UserControl
{
    public string sSaveFolderPath
    {
        get
        {
            if (ViewState["SaveFolderPathUploaderUserControl2"] == null)
            {
                ViewState["SaveFolderPathUploaderUserControl2"] = "";
            }
            return ViewState["SaveFolderPathUploaderUserControl2"].ToString();
        }
        set
        {
            ViewState["SaveFolderPathUploaderUserControl2"] = value;
        }
    }
    public ArrayList filepathlist
    {
        get
        {
            if (ViewState["SavePathUploaderUserControl2"] == null)
            {
                ViewState["SavePathUploaderUserControl2"] = new ArrayList();
            }
            return (ArrayList)ViewState["SavePathUploaderUserControl2"];
        }
        set
        {
            ViewState["SavePathUploaderUserControl2"] = value;
        }
        
    }
    public string sNewName
    {
        get
        {
            if (ViewState["sNewNameUploaderUserControl2"] == null)
            {
                ViewState["sNewNameUploaderUserControl2"] = "";
            }
            return ViewState["sNewNameUploaderUserControl2"].ToString();
        }
        set
        {
            ViewState["sNewNameUploaderUserControl2"] = value;
        }
    }
    public DataTable ImageDT
    {
        get
        {
            if (ViewState["ImageDTUploaderUserControl2"] == null)
            {
                ViewState["ImageDTUploaderUserControl2"] = new DataTable();
            }
            return (DataTable)ViewState["ImageDTUploaderUserControl2"];
        }
        set
        {
            ViewState["ImageDTUploaderUserControl2"] = value;
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


    public void SavePath(string Topic)
    {
        ArrayList filelist = new ArrayList();

        DataTable dtFileList = new DataTable();
        DataColumn col = new DataColumn("sImageNameCN");
        dtFileList.Columns.Add(col);
        DataColumn col1 = new DataColumn("sImageNameEN");
        dtFileList.Columns.Add(col1);
        DataColumn col2 = new DataColumn("sFilename");
        dtFileList.Columns.Add(col2);
        DataColumn col3 = new DataColumn("nID");
        dtFileList.Columns.Add(col3);

        HttpFileCollection postedFiles = Request.Files;
        //string txtCNlist = ((TextBox)this.Controls.Find("txtsImageNameCN", true)[0]).Text;
        //string txtCNlist = ((TextBox)this.FindControl("txtsImageNameCN")).Text;
        string[] txtCNlist = new string[50];
        string[] txtENlist = new string[50];
        if (Request.Form["txtCN"] != null)
        {
            txtCNlist = Request.Form["txtCN"].Split(',');
            txtENlist = Request.Form["txtEN"].Split(',');
        }
        for (int i = 0; i < postedFiles.Count; i++)
        {
            if (postedFiles[i].ContentLength > 0)
            {
                DataRow newrow = dtFileList.NewRow();
                if (i > 0)
                {
                    newrow["sImageNameCN"] = txtCNlist[i - 1];
                    newrow["sImageNameEN"] = txtENlist[i - 1];
                }
                else
                {
                    newrow["sImageNameCN"] = txtsImageNameCN.Text;
                    newrow["sImageNameEN"] = txtsImageNameEN.Text;
                }
                newrow["sFilename"] = postedFiles[i].FileName;
                newrow["nID"] = i.ToString();
                dtFileList.Rows.Add(newrow);
                string basepath = "";
                string PsFiles = DateTime.Now.Year.ToString() + DateTime.Now.Month.ToString() +
                        DateTime.Now.Day.ToString() + DateTime.Now.Hour.ToString() + DateTime.Now.Minute.ToString() +
                        DateTime.Now.Second.ToString();

                if (sSaveFolderPath != "")
                    basepath = sSaveFolderPath + "/" + PsFiles + "/";
                else
                    basepath = "~/Upload" + "/" + Topic + "/" + PsFiles + "/";



                string filename = postedFiles[i].FileName.Substring(postedFiles[i].FileName.LastIndexOf("\\") + 1);
                if (i > 0)
                {
                    if (txtCNlist[i - 1].ToString() != "" && txtCNlist[i - 1].Length > 0)
                    {
                        filename = txtCNlist[i - 1].ToString() + filename.Substring(filename.LastIndexOf("."));
                    }
                }
                else
                {
                    if (txtsImageNameCN.Text != "" && txtsImageNameCN.Text.Length > 0)
                    {
                        filename = txtsImageNameCN.Text + filename.Substring(filename.LastIndexOf("."));
                    }
                }


                string sSaveFolderFullPath = Server.MapPath(basepath);

                if (!System.IO.Directory.Exists(sSaveFolderFullPath))
                {
                    Directory.CreateDirectory(sSaveFolderFullPath);
                }
                string filefullpath = sSaveFolderFullPath + filename;
                string sSavepath = basepath + filename;
                postedFiles[i].SaveAs(filefullpath);

                filelist.Add(sSavepath);
            }
        }
        filepathlist = filelist;
        ImageDT = dtFileList;
        gvFileList.DataSource = dtFileList;
        gvFileList.DataBind();
    }
    
}