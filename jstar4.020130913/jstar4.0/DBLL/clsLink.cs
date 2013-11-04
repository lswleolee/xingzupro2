using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace DBLL
{
    public class clsLink
    {

        public DataTable sp_selectNormalTableOfAllByLink(bool bIncludeUnable)
        {
            try
            {
                try
                {
                    string connectionString = dbstring.dbconnectionstring.ToString();  // get your connection string here

                    SqlParameter[] sqlParameters = new SqlParameter[1];
                    sqlParameters[0] = new SqlParameter("@bIncludeUnable", SqlDbType.Bit);
                    sqlParameters[0].Value = bIncludeUnable;
                    DataSet ds = sqlhelper.SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "sp_selectNormalTableOfAllByLink", sqlParameters);
                    if (ds != null && ds.Tables[0] != null && ds.Tables[0].Rows.Count > 0)
                    {
                        return ds.Tables[0];
                    }
                    else return null;
                }
                catch (Exception ex)
                {
                    throw;
                }
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        public int insert_tb_Link(string pnType, string psThumbPath, string psLink, string psCreatedBy, System.DateTime pdCreatedTime, string psUpdatedBy, System.DateTime pdUpdatedTime, bool pbEnable, int pnSorting)
        {
            int _nID = 0;
            try
            {
                string connectionString = dbstring.dbconnectionstring.ToString();  // get your connection string here
                SqlParameter[] sqlParameters = new SqlParameter[9];
                sqlParameters[0] = new SqlParameter("@nType", SqlDbType.NVarChar);
                sqlParameters[0].Value = pnType;

                sqlParameters[1] = new SqlParameter("@sThumbPath", SqlDbType.NVarChar);
                sqlParameters[1].Value = psThumbPath;

                sqlParameters[2] = new SqlParameter("@sLink", SqlDbType.NVarChar);
                sqlParameters[2].Value = psLink;

                sqlParameters[3] = new SqlParameter("@sCreatedBy", SqlDbType.NVarChar);
                sqlParameters[3].Value = psCreatedBy;

                sqlParameters[4] = new SqlParameter("@dCreatedTime", SqlDbType.DateTime);
                sqlParameters[4].Value = pdCreatedTime;

                sqlParameters[5] = new SqlParameter("@sUpdatedBy", SqlDbType.NVarChar);
                sqlParameters[5].Value = psUpdatedBy;

                sqlParameters[6] = new SqlParameter("@dUpdatedTime", SqlDbType.DateTime);
                sqlParameters[6].Value = pdUpdatedTime;

                sqlParameters[7] = new SqlParameter("@bEnable", SqlDbType.Bit);
                sqlParameters[7].Value = pbEnable;

                sqlParameters[8] = new SqlParameter("@nSorting", SqlDbType.Int);
                sqlParameters[8].Value = pnSorting;

                DataSet ds = sqlhelper.SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "sp_insert_tb_Link", sqlParameters);
                if (ds != null && ds.Tables[0] != null && ds.Tables[0].Rows.Count > 0)
                {
                    _nID = int.Parse(ds.Tables[0].Rows[0][0].ToString());
                }
                else return _nID;
            }
            catch (Exception ex)
            {
                throw;
            }
            return _nID;
        }
        public DataTable Select_tb_LinkBynLinkID(int pnLinkID)
        {
            try
            {
                try
                {
                    string connectionString = dbstring.dbconnectionstring.ToString();  // get your connection string here

                    SqlParameter[] sqlParameters = new SqlParameter[1];
                    sqlParameters[0] = new SqlParameter("@nLinkID", SqlDbType.Int);
                    sqlParameters[0].Value = pnLinkID;



                    DataSet ds = sqlhelper.SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "sp_Select_tb_LinkBynLinkID", sqlParameters);
                    if (ds != null && ds.Tables[0] != null && ds.Tables[0].Rows.Count > 0)
                    {
                        return ds.Tables[0];
                    }
                    else return null;
                }
                catch (Exception ex)
                {
                    throw;
                }
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        public bool update_tb_LinkBynLinkID(int nLinkID, string nType, string sThumbPath, string sLink, string psUpdatedBy, System.DateTime pdUpdatedTime, bool pbEnable, int pnSorting)
        {
            try
            {
                string connectionString = dbstring.dbconnectionstring.ToString();  // get your connection string here
                SqlParameter[] sqlParameters = new SqlParameter[8];
                sqlParameters[0] = new SqlParameter("@nLinkID", SqlDbType.Int);
                sqlParameters[0].Value = nLinkID;

                sqlParameters[1] = new SqlParameter("@nType", SqlDbType.NVarChar);
                sqlParameters[1].Value = nType;

                sqlParameters[2] = new SqlParameter("@sThumbPath", SqlDbType.NVarChar);
                sqlParameters[2].Value = sThumbPath;

                sqlParameters[3] = new SqlParameter("@sLink", SqlDbType.NVarChar);
                sqlParameters[3].Value = sLink;

                sqlParameters[4] = new SqlParameter("@sUpdatedBy", SqlDbType.NVarChar);
                sqlParameters[4].Value = psUpdatedBy;

                sqlParameters[5] = new SqlParameter("@dUpdatedTime", SqlDbType.DateTime);
                sqlParameters[5].Value = pdUpdatedTime;

                sqlParameters[6] = new SqlParameter("@bEnable", SqlDbType.Bit);
                sqlParameters[6].Value = pbEnable;

                sqlParameters[7] = new SqlParameter("@nSorting", SqlDbType.Int);
                sqlParameters[7].Value = pnSorting;

                DataSet ds = sqlhelper.SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "sp_update_tb_LinkBynLinkID", sqlParameters);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    return true;
                }
                else return false;
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
