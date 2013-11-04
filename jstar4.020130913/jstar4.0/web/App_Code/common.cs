using System;
using System.Data;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using System.Data.SqlClient;
using System.Web.SessionState;
using System.IO;
using System.Net;
using System.Collections;
using System.Text.RegularExpressions;
using System.Xml;
using System.IO.IsolatedStorage;
using System.Text;

/// <summary>
///common 的摘要说明
/// </summary>
public class common : System.Web.UI.Page       
{
    static string strconn = System.Configuration.ConfigurationManager.ConnectionStrings["dbcon"].ToString();


	public common()
	{
        
	}
    public static int GetGridViewPageCount()
    {
        return 6;
    }
    public static object setValue(object obj, string value)
    {
        if (obj.GetType().Name == "DropDownList")
        {
            DropDownList ddl = (DropDownList)obj;
            for (int i = 0; i < ddl.Items.Count; i++)
            {
                if (ddl.Items[i].Value.ToString() == value)
                {
                    ddl.SelectedIndex = i;
                    return ddl;
                }

            }
            ListItem item = new ListItem();
            item.Text = value;
            item.Value = value;
            ddl.Items.Insert(0, item);
            ddl.SelectedIndex = 0;
            return ddl;
        }
    
        else if (obj.GetType().Name == "RadioButtonList")
        {
            RadioButtonList rbl = (RadioButtonList)obj;
            for (int i = 0; i < rbl.Items.Count; i++)
            {
                if (rbl.Items[i].Value == value)
                {
                    rbl.Items[i].Selected = true;
                    break;
                }
            }
            return rbl;
        }

        else
        {
            return obj;
        }
    }
    public  static string GetValue(object obj)
    {
        if (obj.GetType().Name == "CheckBox")
        {
            CheckBox cb = (CheckBox)obj;
            if (cb.Checked == true)
            {
                return "1";
            }
            else
            {
                return "";
            }
        }
        else if (obj.GetType().Name == "DropDownList")
        {
            DropDownList ddl = (DropDownList)obj;

            if (ddl.Items.Count >= 1)
                return ddl.SelectedValue;
            else return "0";
        }
        else if (obj.GetType().Name == "Label")
        {
            Label lbl = (Label)obj;
            return lbl.Text;
        }
        else if (obj.GetType().Name == "RadioButton")
        {
            RadioButton rb = (RadioButton)obj;
            //return zzrb.Checked.ToString();
            return (rb.Checked ? "1" : "");
        }
        else if (obj.GetType().Name == "RadioButtonList")
        {
            RadioButtonList rbl = (RadioButtonList)obj;
            return rbl.SelectedValue;
        }
        else if (obj.GetType().Name == "TextBox")
        {
            TextBox txt = (TextBox)obj;
         
            return txt.Text;
        }


      
        else if (obj.GetType().Name == "HiddenField")
        {
            HiddenField hf = (HiddenField)obj;
            return hf.Value;
        }
        else
        {
            return "";
        }

    }
    //public DateTime GetValeTime(string time)
    //{



    //    DateTime dTime = DateTime.Now;
    //    bool bCheck = true;
    //    System.Globalization.CultureInfo cu = new System.Globalization.CultureInfo("en-us");
    //    bCheck = DateTime.TryParse(GetDataBaseDateTime(time), cu, System.Globalization.DateTimeStyles.None, out dTime);
    //    if (bCheck == true)
    //    {
    //        if (dTime >= Convert.ToDateTime("1/1/1799"))
    //        {
    //            return dTime;
    //        }
    //        else
    //        {
    //            return Convert.ToDateTime("1/1/1799");
    //        }
    //    }
    //    else
    //    {
    //        return Convert.ToDateTime("1/1/1799");
    //    }

    //}
    //public string GetDataBaseDateTime(string sDateTime)
    //{
    //    try
    //    {
    //        return sDateTime.Substring(sDateTime.IndexOf("/") + 1, sDateTime.LastIndexOf("/") - sDateTime.IndexOf("/")) + sDateTime.Substring(0, sDateTime.IndexOf("/") + 1) + sDateTime.Substring(sDateTime.LastIndexOf("/") + 1);
    //    }
    //    catch
    //    {
    //        return "1/1/1799";
    //    }
    //}
    public  bool SessionCheck(string sSessionName)
    {
        if (Session[sSessionName] == null || string.IsNullOrEmpty(Session[sSessionName].ToString()))
        {
            return false;
        }
        else
        {
            return true;
        }
    }


    #region/// 过滤html,js,css代码
    /// <summary>
    /// 过滤html,js,css代码
    /// </summary>
    /// <param name="html">参数传入</param>
    /// <returns></returns>
    public static string CheckStr(string html)
    {
        System.Text.RegularExpressions.Regex regex1 = new System.Text.RegularExpressions.Regex(@"<script[\s\S]+</script *>", System.Text.RegularExpressions.RegexOptions.IgnoreCase);
        System.Text.RegularExpressions.Regex regex2 = new System.Text.RegularExpressions.Regex(@" href *= *[\s\S]*script *:", System.Text.RegularExpressions.RegexOptions.IgnoreCase);
        System.Text.RegularExpressions.Regex regex3 = new System.Text.RegularExpressions.Regex(@" no[\s\S]*=", System.Text.RegularExpressions.RegexOptions.IgnoreCase);
        System.Text.RegularExpressions.Regex regex4 = new System.Text.RegularExpressions.Regex(@"<iframe[\s\S]+</iframe *>", System.Text.RegularExpressions.RegexOptions.IgnoreCase);
        System.Text.RegularExpressions.Regex regex5 = new System.Text.RegularExpressions.Regex(@"<frameset[\s\S]+</frameset *>", System.Text.RegularExpressions.RegexOptions.IgnoreCase);
        System.Text.RegularExpressions.Regex regex6 = new System.Text.RegularExpressions.Regex(@"\<img[^\>]+\>", System.Text.RegularExpressions.RegexOptions.IgnoreCase);
        System.Text.RegularExpressions.Regex regex7 = new System.Text.RegularExpressions.Regex(@"</p>", System.Text.RegularExpressions.RegexOptions.IgnoreCase);
        System.Text.RegularExpressions.Regex regex8 = new System.Text.RegularExpressions.Regex(@"<p>", System.Text.RegularExpressions.RegexOptions.IgnoreCase);
        System.Text.RegularExpressions.Regex regex9 = new System.Text.RegularExpressions.Regex(@"<[^>]*>", System.Text.RegularExpressions.RegexOptions.IgnoreCase);
        html = regex1.Replace(html, ""); //过滤<script></script>标记
        html = regex2.Replace(html, ""); //过滤href=javascript: (<A>) 属性
        html = regex3.Replace(html, " _disibledevent="); //过滤其它控件的on...事件
        html = regex4.Replace(html, ""); //过滤iframe
        html = regex5.Replace(html, ""); //过滤frameset
        html = regex6.Replace(html, ""); //过滤frameset
        html = regex7.Replace(html, ""); //过滤frameset
        html = regex8.Replace(html, ""); //过滤frameset
        //html = regex9.Replace(html, "");
        //html = html.Replace(" ", "");
        html = html.Replace("</strong>", "");
        html = html.Replace("<strong>", "");
        return html;
    }
    #endregion
    public static string StripHTML(string HTML) //google "StripHTML" 得到
{ string[] Regexs =
                                {
                                    @"<script[^>]*?>.*?</script>",
                                    @"<(\/\s*)?!?((\w+:)?\w+)(\w+(\s*=?\s*(([""'])(\\[""'tbnr]|[^\7])*?\7|\w+)|.{0})|\s)*?(\/\s*)?>",
                                    @"([\r\n])[\s]+",
                                    @"&(quot|#34);",
                                    @"&(amp|#38);",
                                    @"&(lt|#60);",
                                    @"&(gt|#62);",
                                    @"&(nbsp|#160);",
                                    @"&(iexcl|#161);",
                                    @"&(cent|#162);",
                                    @"&(pound|#163);",
                                    @"&(copy|#169);",
                                    @"&#(\d+);",
                                    @"-->",
                                    @"<!--.*\n"
                                };

            string[] Replaces =
                                {
                                    "",
                                    "",
                                    "",
                                    "\"",
                                    "&",
                                    "<",
                                    ">",
                                    " ",
                                    "\xa1", //chr(161),
                                    "\xa2", //chr(162),
                                    "\xa3", //chr(163),
                                    "\xa9", //chr(169),
                                    "",
                                    "\r\n",
                                    ""
                                };

            string s = HTML;
            for (int i = 0; i < Regexs.Length; i++)
            {
                s = new Regex(Regexs[i], RegexOptions.Multiline | RegexOptions.IgnoreCase).Replace(s, Replaces[i]);
            }
            s.Replace("<", "");
            s.Replace(">", "");
            s.Replace("\r\n", "");
            return s;
        }
    public string RequestQueryString(string QueryString)
    {
        string value = "";

        if (Request.QueryString[QueryString] != null && !string.IsNullOrEmpty(Request.QueryString[QueryString].ToString()))
        {
            value = Request.QueryString[QueryString].ToString();

        }

        return value;
    }
    public string GetSessionValue(string SessionString)
    {
        string value = "";

        if (Session[SessionString] != null && !string.IsNullOrEmpty(Session[SessionString].ToString()))
        {
            value = Session[SessionString].ToString();

        }

        return value;
    }
    public bool Pre_GetSessionValue(string SessionString)
    {
        bool check = false;

        if (Session[SessionString] != null && !string.IsNullOrEmpty(Session[SessionString].ToString()))
        {
            check = true;

        }

        return check;
    }
    public void showMsgJavascript(string msg)
    {


        string scriptString = "<script language='JavaScript'>alert('" + msg + "'); </script>";
        if (!Page.ClientScript.IsClientScriptBlockRegistered(scriptString))
        {

            Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "script", scriptString);

        }

    }
    public void showMsgscriptAndRedirect(string msg, string path)
    {



        string scriptString = "<script language='JavaScript'>";
        if (!string.IsNullOrEmpty(msg))
            scriptString += "alert('" + msg + "');";
        if (!string.IsNullOrEmpty(msg))
            scriptString += "window.location.href='" + path + "';";
        scriptString += " </script>";
        if (!Page.ClientScript.IsClientScriptBlockRegistered(scriptString))
        {

            Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "script", scriptString);

        }



    }

    //时间处理
    public DateTime GetStratTime(DateTime dtime)
    {
        DateTime stime = new DateTime(dtime.Year, dtime.Month, 1);

        return stime;
    }
    public DateTime GetEndTime(DateTime dtime)
    {
        DateTime etime = DateTime.Now;
        if (dtime.Month == 12)
        {
            etime = new DateTime(dtime.Year, dtime.Month, 31, 23, 59, 59);

        }
        else
        {
            etime = new DateTime(dtime.Year, dtime.Month + 1, 1, 0, 0, 0);
            etime = etime.AddSeconds(-1);

        }
        return etime;
    }
    
}
