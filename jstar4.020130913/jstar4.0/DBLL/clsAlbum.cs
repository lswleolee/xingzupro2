using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace DBLL
{
    public class clsAlbum
    {


        public int insert_tb_Album(int pnTCategoryID, string psImageNameCN, string psImageNameEN, string psImagePath, string psCreatedBy, System.DateTime pdCreatedTime, string psUpdatedBy, System.DateTime pdUpdatedTime, bool pbEnable, int pnSorting)
        {
            int _nID = 0;
            try
            {
                string connectionString = dbstring.dbconnectionstring.ToString();  // get your connection string here

                SqlParameter[] sqlParameters = new SqlParameter[11];
                sqlParameters[0] = new SqlParameter("@nTCategoryID", SqlDbType.Int);
                sqlParameters[0].Value = pnTCategoryID;

                sqlParameters[1] = new SqlParameter("@sImageNameCN", SqlDbType.NVarChar);
                sqlParameters[1].Value = psImageNameCN;

                sqlParameters[2] = new SqlParameter("@sImageNameEN", SqlDbType.NVarChar);
                sqlParameters[2].Value = psImageNameEN;

                sqlParameters[3] = new SqlParameter("@sImagePath", SqlDbType.NVarChar);
                sqlParameters[3].Value = psImagePath;

                sqlParameters[4] = new SqlParameter("@sCreatedBy", SqlDbType.NVarChar);
                sqlParameters[4].Value = psCreatedBy;

                sqlParameters[5] = new SqlParameter("@dCreatedTime", SqlDbType.DateTime);
                sqlParameters[5].Value = pdCreatedTime;

                sqlParameters[6] = new SqlParameter("@sUpdatedBy", SqlDbType.NVarChar);
                sqlParameters[6].Value = psUpdatedBy;

                sqlParameters[7] = new SqlParameter("@dUpdatedTime", SqlDbType.DateTime);
                sqlParameters[7].Value = pdUpdatedTime;

                sqlParameters[8] = new SqlParameter("@bEnable", SqlDbType.Bit);
                sqlParameters[8].Value = pbEnable;

                sqlParameters[9] = new SqlParameter("@nSorting", SqlDbType.Int);
                sqlParameters[9].Value = pnSorting;

                DataSet ds = sqlhelper.SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "sp_insert_tb_Album", sqlParameters);
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


        public DataTable Select_tb_AlbumBynAlbumID(int pnAlbumID)
        {
            try
            {
                try
                {
                    string connectionString = dbstring.dbconnectionstring.ToString();  // get your connection string here

                    SqlParameter[] sqlParameters = new SqlParameter[1];
                    sqlParameters[0] = new SqlParameter("@nAlbumID", SqlDbType.Int);
                    sqlParameters[0].Value = pnAlbumID;



                    DataSet ds = sqlhelper.SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "sp_Select_tb_AlbumBynAlbumID", sqlParameters);
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
        public DataTable Select_tb_AlbumBynTCategoryID(int pnTCategoryID)
        {
            try
            {
                try
                {
                    string connectionString = dbstring.dbconnectionstring.ToString();  // get your connection string here

                    SqlParameter[] sqlParameters = new SqlParameter[1];
                    sqlParameters[0] = new SqlParameter("@nTCategoryID", SqlDbType.Int);
                    sqlParameters[0].Value = pnTCategoryID;



                    DataSet ds = sqlhelper.SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "sp_Select_tb_AlbumBynTCategoryID", sqlParameters);
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
        public bool update_tb_AlbumBynAlbumID(int nAlbumID, int nTCategoryID, string sImageNameCN, string sImageNameEN,string sImagePath, string psUpdatedBy, System.DateTime pdUpdatedTime, bool pbEnable, int pnSorting)
        {
            try
            {
                string connectionString = dbstring.dbconnectionstring.ToString();  // get your connection string here
                SqlParameter[] sqlParameters = new SqlParameter[9];
                sqlParameters[0] = new SqlParameter("@nAlbumID", SqlDbType.Int);
                sqlParameters[0].Value = nAlbumID;

                sqlParameters[1] = new SqlParameter("@nArticleID", SqlDbType.Int);
                sqlParameters[1].Value = nTCategoryID;

                sqlParameters[2] = new SqlParameter("@sImageNameCN", SqlDbType.NVarChar);
                sqlParameters[2].Value = sImageNameCN;

                sqlParameters[3] = new SqlParameter("@sImageNameEN", SqlDbType.NVarChar);
                sqlParameters[3].Value = sImageNameEN;

                sqlParameters[4] = new SqlParameter("@sImagePath", SqlDbType.NVarChar);
                sqlParameters[4].Value = sImagePath;

                sqlParameters[5] = new SqlParameter("@sUpdatedBy", SqlDbType.NVarChar);
                sqlParameters[5].Value = psUpdatedBy;

                sqlParameters[6] = new SqlParameter("@dUpdatedTime", SqlDbType.DateTime);
                sqlParameters[6].Value = pdUpdatedTime;

                sqlParameters[7] = new SqlParameter("@bEnable", SqlDbType.Bit);
                sqlParameters[7].Value = pbEnable;

                sqlParameters[8] = new SqlParameter("@nSorting", SqlDbType.Int);
                sqlParameters[8].Value = pnSorting;

                DataSet ds = sqlhelper.SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "sp_update_tb_AlbumBynAlbumID", sqlParameters);
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
        public DataTable sp_selectNormalTableOfAllByAlbum(bool bIncludeUnable, int pnTCategoryID)
        {
            try
            {
                try
                {
                    string connectionString = dbstring.dbconnectionstring.ToString();  // get your connection string here

                    SqlParameter[] sqlParameters = new SqlParameter[2];
                    sqlParameters[0] = new SqlParameter("@bIncludeUnable", SqlDbType.Bit);
                    sqlParameters[0].Value = bIncludeUnable;
                    sqlParameters[1] = new SqlParameter("@nTCategoryID", SqlDbType.Int);
                    sqlParameters[1].Value = pnTCategoryID;
                    DataSet ds = sqlhelper.SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "sp_selectNormalTableOfAllByAlbum", sqlParameters);
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
        public bool sp_DeleteNormalTableByIDAlbum(int pnKeyID, string psTableName)
        {
            string connectionString = dbstring.dbconnectionstring.ToString();  // get your connection string here

            SqlParameter[] sqlParameters = new SqlParameter[2];
            sqlParameters[0] = new SqlParameter("@nKeyID", SqlDbType.Int);
            sqlParameters[0].Value = pnKeyID;

            sqlParameters[1] = new SqlParameter("@sTableName", SqlDbType.NVarChar);
            sqlParameters[1].Value = psTableName;
            try
            {
                DataSet ds = sqlhelper.SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "sp_DeleteNormalTableByIDAlbum", sqlParameters);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    return false;
                }
                else return true;
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
