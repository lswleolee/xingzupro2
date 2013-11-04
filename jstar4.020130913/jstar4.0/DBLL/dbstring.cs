using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Configuration;

using System.Data;
using System.Data.SqlClient;
/// <summary>
///dbstring 的摘要说明
/// </summary>
public class dbstring
{
   
        public static string dbconnectionstring = ConfigurationManager.ConnectionStrings["dbcon"].ToString();
    
}