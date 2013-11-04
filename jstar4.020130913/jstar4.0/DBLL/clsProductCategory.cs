using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace DBLL
{
    public class clsProductCategory
    {

        public DataTable sp_selectNormalTableOfAllByProductCategory(bool bIncludeUnable)
        {
            try
            {
                try
                {
                    string connectionString = dbstring.dbconnectionstring.ToString();  // get your connection string here

                    SqlParameter[] sqlParameters = new SqlParameter[1];
                    sqlParameters[0] = new SqlParameter("@bIncludeUnable", SqlDbType.Bit);
                    sqlParameters[0].Value = bIncludeUnable;
                    DataSet ds = sqlhelper.SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "sp_selectNormalTableOfAllByProductCategory", sqlParameters);
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
        public int insert_tb_ProductCategory(int pnParentCategoryID, string psProductCategoryNameCN, string psProductCategoryNameEN, string psContentCN, string psContentEN, string psCreatedBy, System.DateTime pdCreatedTime, string psUpdatedBy, System.DateTime pdUpdatedTime, bool pbEnable, int pnSorting)
        {
            int _nID = 0;
            try
            {
                string connectionString = dbstring.dbconnectionstring.ToString();  // get your connection string here

                SqlParameter[] sqlParameters = new SqlParameter[11];
                sqlParameters[0] = new SqlParameter("@nParentCategoryID", SqlDbType.Int);
                sqlParameters[0].Value = pnParentCategoryID;

                sqlParameters[1] = new SqlParameter("@sProductCategoryNameCN", SqlDbType.NVarChar);
                sqlParameters[1].Value = psProductCategoryNameCN;

                sqlParameters[2] = new SqlParameter("@sProductCategoryNameEN", SqlDbType.NVarChar);
                sqlParameters[2].Value = psProductCategoryNameEN;

                sqlParameters[3] = new SqlParameter("@sContentCN", SqlDbType.NVarChar);
                sqlParameters[3].Value = psContentCN;

                sqlParameters[4] = new SqlParameter("@sContentEN", SqlDbType.NVarChar);
                sqlParameters[4].Value = psContentEN;

                sqlParameters[5] = new SqlParameter("@sCreatedBy", SqlDbType.NVarChar);
                sqlParameters[5].Value = psCreatedBy;

                sqlParameters[6] = new SqlParameter("@dCreatedTime", SqlDbType.DateTime);
                sqlParameters[6].Value = pdCreatedTime;

                sqlParameters[7] = new SqlParameter("@sUpdatedBy", SqlDbType.NVarChar);
                sqlParameters[7].Value = psUpdatedBy;

                sqlParameters[8] = new SqlParameter("@dUpdatedTime", SqlDbType.DateTime);
                sqlParameters[8].Value = pdUpdatedTime;

                sqlParameters[9] = new SqlParameter("@bEnable", SqlDbType.Bit);
                sqlParameters[9].Value = pbEnable;

                sqlParameters[10] = new SqlParameter("@nSorting", SqlDbType.Int);
                sqlParameters[10].Value = pnSorting;

                DataSet ds = sqlhelper.SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "sp_insert_tb_ProductCategory", sqlParameters);
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
        public DataTable Select_tb_ProductCategoryBynProductCategoryID(int pnProductCategoryID)
        {
            try
            {
                try
                {
                    string connectionString = dbstring.dbconnectionstring.ToString();  // get your connection string here

                    SqlParameter[] sqlParameters = new SqlParameter[1];
                    sqlParameters[0] = new SqlParameter("@nProductCategoryID", SqlDbType.Int);
                    sqlParameters[0].Value = pnProductCategoryID;



                    DataSet ds = sqlhelper.SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "sp_Select_tb_ProductCategoryBynProductCategoryID", sqlParameters);
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
        public DataTable Select_tb_ProductCategoryBynParentCategoryID(int pnParentCategoryID)
        {
            try
            {
                try
                {
                    string connectionString = dbstring.dbconnectionstring.ToString();  // get your connection string here

                    SqlParameter[] sqlParameters = new SqlParameter[1];
                    sqlParameters[0] = new SqlParameter("@nParentCategoryID", SqlDbType.Int);
                    sqlParameters[0].Value = pnParentCategoryID;



                    DataSet ds = sqlhelper.SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "sp_Select_tb_ProductCategoryBynParentCategoryID", sqlParameters);
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
        public bool update_tb_ProductCategoryBynProductCategoryID(int nProductCategoryID, int nParentCategoryID, string sProductCategoryNameCN, string sProductCategoryNameEN, string sContentCN, string sContentEN, string psUpdatedBy, System.DateTime pdUpdatedTime, bool pbEnable, int pnSorting)
        {
            try
            {
                string connectionString = dbstring.dbconnectionstring.ToString();  // get your connection string here
                SqlParameter[] sqlParameters = new SqlParameter[10];
                sqlParameters[0] = new SqlParameter("@nProductCategoryID", SqlDbType.Int);
                sqlParameters[0].Value = nProductCategoryID;

                sqlParameters[1] = new SqlParameter("@nParentCategoryID", SqlDbType.Int);
                sqlParameters[1].Value = nParentCategoryID;

                sqlParameters[2] = new SqlParameter("@sProductCategoryNameCN", SqlDbType.NVarChar);
                sqlParameters[2].Value = sProductCategoryNameCN;

                sqlParameters[3] = new SqlParameter("@sProductCategoryNameEN", SqlDbType.NVarChar);
                sqlParameters[3].Value = sProductCategoryNameEN;

                sqlParameters[4] = new SqlParameter("@sContentCN", SqlDbType.NVarChar);
                sqlParameters[4].Value = sContentCN;

                sqlParameters[5] = new SqlParameter("@sContentEN", SqlDbType.NVarChar);
                sqlParameters[5].Value = sContentEN;

                sqlParameters[6] = new SqlParameter("@sUpdatedBy", SqlDbType.NVarChar);
                sqlParameters[6].Value = psUpdatedBy;

                sqlParameters[7] = new SqlParameter("@dUpdatedTime", SqlDbType.DateTime);
                sqlParameters[7].Value = pdUpdatedTime;

                sqlParameters[8] = new SqlParameter("@bEnable", SqlDbType.Bit);
                sqlParameters[8].Value = pbEnable;

                sqlParameters[9] = new SqlParameter("@nSorting", SqlDbType.Int);
                sqlParameters[9].Value = pnSorting;

                DataSet ds = sqlhelper.SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "sp_update_tb_ProductCategoryBynProductCategoryID", sqlParameters);
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
