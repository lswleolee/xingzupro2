using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
namespace DBLL
{
   public class OptionSysDBLL
    {
        /// <summary>
        /// 查询数据字段对应值
        /// </summary>
        public string GetOptionValue(string sLangType, string sGroup, string sKey)
        {
            try
            {
                string commandstr = "select sValue from tb_OptionSys where sLangType=@sLangType and sGroup=@sGroup and sKey=@sKey";
                SqlParameter[] param = new SqlParameter[3];
                param[0] = new SqlParameter("@sLangType", sLangType);
                param[1] = new SqlParameter("@sGroup", sGroup);
                param[2] = new SqlParameter("@sKey", sKey);

                DataSet ds = sqlhelper.SqlHelper.ExecuteDataset(dbstring.dbconnectionstring, CommandType.Text, commandstr, param);
                if (ds != null && ds.Tables[0] != null && ds.Tables[0].Rows.Count > 0)
                {
                    return ds.Tables[0].Rows[0][0].ToString();
                }
                else return "";
            }
            catch (Exception)
            {

                return "";
            }
        }



        /// <summary>
        /// 查询数据字段对应关键字和值记录返回表
        /// </summary>

        public DataTable GetOptionKeyAndValue(string sLangType, string sGroup)
        {

            try
            {
                string commandstr = "select * from tb_OptionSys where sLangType=@sLangType and sGroup=@sGroup order by nSorting desc";
                SqlParameter[] param = new SqlParameter[2];
                param[0] = new SqlParameter("@sLangType", sLangType);
                param[1] = new SqlParameter("@sGroup", sGroup);
                DataSet ds = sqlhelper.SqlHelper.ExecuteDataset(dbstring.dbconnectionstring, CommandType.Text, commandstr, param);
                if (ds != null && ds.Tables[0] != null && ds.Tables[0].Rows.Count > 0)
                {
                    return ds.Tables[0];
                }
                else return null;
            }
            catch (Exception)
            {
                return null;
            }

        }


        /// <summary>
        /// 查询数据字段对应关键字和值记录返回表
        /// </summary>
        public DataTable GetOptionValueTable(string sLangType, string sGroup, string sKey)
        {

            try
            {
                string commandstr = "select * from tb_OptionSys where sLangType=@sLangType and sGroup=@sGroup and sKey=@sKey  order by nSorting desc";
                SqlParameter[] param = new SqlParameter[3];
                param[0] = new SqlParameter("@sLangType", sLangType);
                param[1] = new SqlParameter("@sGroup", sGroup);
                param[1] = new SqlParameter("@sKey", sKey);
                DataSet ds = sqlhelper.SqlHelper.ExecuteDataset(dbstring.dbconnectionstring, CommandType.Text, commandstr, param);
                if (ds != null && ds.Tables[0] != null && ds.Tables[0].Rows.Count > 0)
                {
                    return ds.Tables[0];
                }
                else return null;
            }
            catch (Exception)
            {
                throw;
            }


        }

        /// <summary>
        /// 更新配置表的值
        /// </summary>

        public bool UpdateOptionValue(string sLangType, string sGroup, string sKey, string sValue)
        {
            try
            {
                string commandstr = "sp_Updatetb_OptionSysValue";
                SqlParameter[] param = new SqlParameter[4];
                param[0] = new SqlParameter("@sLangType", sLangType);
                param[1] = new SqlParameter("@sGroup", sGroup);
                param[2] = new SqlParameter("@sKey", sKey);
                param[3] = new SqlParameter("@sValue", sValue);
                DataSet ds = sqlhelper.SqlHelper.ExecuteDataset(dbstring.dbconnectionstring, CommandType.StoredProcedure, commandstr, param);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    return true;
                }
                else return false;
            }
            catch (Exception)
            {
                return false;
            }
        }

      

    }
}
