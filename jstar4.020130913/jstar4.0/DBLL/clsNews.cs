using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace DBLL
{
    public class clsNews
    {

        public DataTable sp_selectNormalTableOfAllByNews(bool bIncludeUnable)
        {
            try
            {
                try
                {
                    string connectionString = dbstring.dbconnectionstring.ToString();  // get your connection string here

                    SqlParameter[] sqlParameters = new SqlParameter[1];
                    sqlParameters[0] = new SqlParameter("@bIncludeUnable", SqlDbType.Bit);
                    sqlParameters[0].Value = bIncludeUnable;
                    DataSet ds = sqlhelper.SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "sp_selectNormalTableOfAllByNews", sqlParameters);
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
        public int insert_tb_News(int pnTCategoryID, int pnLangType, string psTitle, string psAuthor, string psImagePath, string psContent, string psCreatedBy, System.DateTime pdCreatedTime, string psUpdatedBy, System.DateTime pdUpdatedTime, bool pbEnable, int pnSorting)
        {
            int _nID = 0;
            try
            {
                string connectionString = dbstring.dbconnectionstring.ToString();  // get your connection string here

                SqlParameter[] sqlParameters = new SqlParameter[12];
                sqlParameters[0] = new SqlParameter("@nTCategoryID", SqlDbType.Int);
                sqlParameters[0].Value = pnTCategoryID;

                sqlParameters[1] = new SqlParameter("@nLangType", SqlDbType.Int);
                sqlParameters[1].Value = pnLangType;

                sqlParameters[2] = new SqlParameter("@sTitle", SqlDbType.NVarChar);
                sqlParameters[2].Value = psTitle;

                sqlParameters[3] = new SqlParameter("@sAuthor", SqlDbType.NVarChar);
                sqlParameters[3].Value = psAuthor;

                sqlParameters[4] = new SqlParameter("@sImagePath", SqlDbType.NVarChar);
                sqlParameters[4].Value = psImagePath;

                sqlParameters[5] = new SqlParameter("@sContent", psContent);

                sqlParameters[6] = new SqlParameter("@sCreatedBy", SqlDbType.NVarChar);
                sqlParameters[6].Value = psCreatedBy;

                sqlParameters[7] = new SqlParameter("@dCreatedTime", SqlDbType.DateTime);
                sqlParameters[7].Value = pdCreatedTime;

                sqlParameters[8] = new SqlParameter("@sUpdatedBy", SqlDbType.NVarChar);
                sqlParameters[8].Value = psUpdatedBy;

                sqlParameters[9] = new SqlParameter("@dUpdatedTime", SqlDbType.DateTime);
                sqlParameters[9].Value = pdUpdatedTime;

                sqlParameters[10] = new SqlParameter("@bEnable", SqlDbType.Bit);
                sqlParameters[10].Value = pbEnable;

                sqlParameters[11] = new SqlParameter("@nSorting", SqlDbType.Int);
                sqlParameters[11].Value = pnSorting;

                DataSet ds = sqlhelper.SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "sp_insert_tb_News", sqlParameters);
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
        public DataTable Select_tb_NewsBynNewsID(int pnNewsID)
        {
            try
            {
                try
                {
                    string connectionString = dbstring.dbconnectionstring.ToString();  // get your connection string here

                    SqlParameter[] sqlParameters = new SqlParameter[1];
                    sqlParameters[0] = new SqlParameter("@nNewsID", SqlDbType.Int);
                    sqlParameters[0].Value = pnNewsID;



                    DataSet ds = sqlhelper.SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "sp_Select_tb_NewsBynNewsID", sqlParameters);
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
        public DataTable Select_tb_NewsBynTCategoryID(int pnTCategoryID)
        {
            try
            {
                try
                {
                    string connectionString = dbstring.dbconnectionstring.ToString();  // get your connection string here

                    SqlParameter[] sqlParameters = new SqlParameter[1];
                    sqlParameters[0] = new SqlParameter("@nTCategoryID", SqlDbType.Int);
                    sqlParameters[0].Value = pnTCategoryID;



                    DataSet ds = sqlhelper.SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "sp_Select_tb_NewsBynTCategoryID", sqlParameters);
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
        public DataTable Select_tb_NewsBynTCategoryIDAndnLangType(int pnTCategoryID,int nLangType)
        {
            try
            {
                try
                {
                    string connectionString = dbstring.dbconnectionstring.ToString();  // get your connection string here

                    SqlParameter[] sqlParameters = new SqlParameter[2];
                    sqlParameters[0] = new SqlParameter("@nTCategoryID", SqlDbType.Int);
                    sqlParameters[0].Value = pnTCategoryID;
                    sqlParameters[1] = new SqlParameter("@nLangType", SqlDbType.Int);
                    sqlParameters[1].Value = nLangType;


                    DataSet ds = sqlhelper.SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "sp_Select_tb_NewsBynTCategoryIDAndnLangType", sqlParameters);
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
        public bool update_tb_NewsBynNewsID(int nNewsID, int nTCategoryID, int nLangType, string sTitle, string sAuthor, string psImagePath, string sContent, string psUpdatedBy, System.DateTime pdUpdatedTime, bool pbEnable, int pnSorting)
        {
            try
            {
                string connectionString = dbstring.dbconnectionstring.ToString();  // get your connection string here
                SqlParameter[] sqlParameters = new SqlParameter[11];
                sqlParameters[0] = new SqlParameter("@nNewsID", SqlDbType.Int);
                sqlParameters[0].Value = nNewsID;

                sqlParameters[1] = new SqlParameter("@nTCategoryID", SqlDbType.Int);
                sqlParameters[1].Value = nTCategoryID;

                sqlParameters[2] = new SqlParameter("@nLangType", SqlDbType.Int);
                sqlParameters[2].Value = nLangType;

                sqlParameters[3] = new SqlParameter("@sTitle", SqlDbType.NVarChar);
                sqlParameters[3].Value = sTitle;

                sqlParameters[4] = new SqlParameter("@sAuthor", SqlDbType.NVarChar);
                sqlParameters[4].Value = sAuthor;

                sqlParameters[5] = new SqlParameter("@sImagePath", SqlDbType.NVarChar);
                sqlParameters[5].Value = psImagePath;

                sqlParameters[6] = new SqlParameter("@sContent", SqlDbType.NVarChar);
                sqlParameters[6].Value = sContent;

                sqlParameters[7] = new SqlParameter("@sUpdatedBy", SqlDbType.NVarChar);
                sqlParameters[7].Value = psUpdatedBy;

                sqlParameters[8] = new SqlParameter("@dUpdatedTime", SqlDbType.DateTime);
                sqlParameters[8].Value = pdUpdatedTime;

                sqlParameters[9] = new SqlParameter("@bEnable", SqlDbType.Bit);
                sqlParameters[9].Value = pbEnable;

                sqlParameters[10] = new SqlParameter("@nSorting", SqlDbType.Int);
                sqlParameters[10].Value = pnSorting;

                DataSet ds = sqlhelper.SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "sp_update_tb_NewsBynNewsID", sqlParameters);
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
