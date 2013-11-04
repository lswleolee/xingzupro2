using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DBLL;
public partial class managepage_Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            OptionSysDBLL option = new OptionSysDBLL();
            DBcommon dbcom = new DBcommon();
            lvSystemLog.DataSource = dbcom.GetDataTable("select * from tb_System_Log where bEnable=1");
            lvSystemLog.DataBind();
        }
    }
}