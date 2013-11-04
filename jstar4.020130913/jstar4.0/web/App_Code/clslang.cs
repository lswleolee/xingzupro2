using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Xml;
/// <summary>
/// Summary description for clslangXml
/// </summary>
public class clslang
{
    XmlDocument xmlDoc = new XmlDocument();
    string path = "";
    string mainnode="language";
   public string _path
    {
        get { return path; }
        set { path = value; } 
   }
    public clslang()
    {
        //
        // TODO: Add constructor logic here
        //
    }
    public clslang(string _path)
    {
        path = _path;
    }
    public void XmlLoad()
    {
        xmlDoc.Load(System.Web.HttpContext.Current.Request.PhysicalApplicationPath + path);
    }
    public string getString(string group,string type,string name)
    {
        try
        {
            XmlNode groupnode = xmlDoc.SelectSingleNode("language").SelectSingleNode(group);
            XmlNode typenode = groupnode.SelectSingleNode(type);

        XmlNode stringnode= typenode.SelectSingleNode(name);
        string strvalue = stringnode.InnerText;
        return strvalue;
        }
        catch (Exception ee)
        {

            return "";
        }
        
      

    }
    public string getHTML(string group, string type, string name)
    {
        try
        {
            XmlNode groupnode = xmlDoc.SelectSingleNode("language").SelectSingleNode(group);
            XmlNode typenode = groupnode.SelectSingleNode(type);

            XmlNode stringnode = typenode.SelectSingleNode(name);
            string strvalue = stringnode.Value;
            return strvalue;
        }
        catch (Exception ee)
        {

            return "";
        }



    }
    
}
