using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace DBLL
{
    public class clsProductImage
    {


        public int insert_tb_ProductImage(int pnProductID, string psPImageNameCN, string psPImageNameEN, string psPImagePath, string psCreatedBy, System.DateTime pdCreatedTime, string psUpdatedBy, System.DateTime pdUpdatedTime, bool pbEnable, int pnSorting)
        {
            int _nID = 0;
            string connectionString = dbstring.dbconnectionstring.ToString();  // get your connection string here

            SqlParameter[] sqlParameters = new SqlParameter[10];
            sqlParameters[0] = new SqlParameter("@nProductID", SqlDbType.Int);
            sqlParameters[0].Value = pnProductID;

            sqlParameters[1] = new SqlParameter("@sPImageNameCN", SqlDbType.NVarChar);
            sqlParameters[1].Value = psPImageNameCN;

            sqlParameters[2] = new SqlParameter("@sPImageNameEN", SqlDbType.NVarChar);
            sqlParameters[2].Value = psPImageNameEN;

            sqlParameters[3] = new SqlParameter("@sPImagePath", SqlDbType.NVarChar);
            sqlParameters[3].Value = psPImagePath;

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

            try
            {

                DataSet ds = sqlhelper.SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "sp_insert_tb_ProductImage", sqlParameters);
                  if (ds != null && ds.Tables[0] != null && ds.Tables[0].Rows.Count > 0)
                {
                    _nID = int.Parse(ds.Tables[0].Rows[0][0].ToString());
                    return _nID;
                }
                else return _nID;
            
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        public DataTable Select_tb_ProductImageBynPImageID(int pnPImageID)
        {
            try
            {
                try
                {
                    string connectionString = dbstring.dbconnectionstring.ToString();  // get your connection string here

                    SqlParameter[] sqlParameters = new SqlParameter[1];
                    sqlParameters[0] = new SqlParameter("@nPImageID", SqlDbType.Int);
                    sqlParameters[0].Value = pnPImageID;



                    DataSet ds = sqlhelper.SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "sp_Select_tb_ProductImageBynPImageID", sqlParameters);
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
        public bool sp_DeleteNormalTableByIDProductImage(int pnKeyID, string psTableName)
        {
            string connectionString = dbstring.dbconnectionstring.ToString();  // get your connection string here

            SqlParameter[] sqlParameters = new SqlParameter[2];
            sqlParameters[0] = new SqlParameter("@nKeyID", SqlDbType.Int);
            sqlParameters[0].Value = pnKeyID;

            sqlParameters[1] = new SqlParameter("@sTableName", SqlDbType.NVarChar);
            sqlParameters[1].Value = psTableName;
            try
            {
                DataSet ds = sqlhelper.SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "sp_DeleteNormalTableByIDProductImage", sqlParameters);
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
        public DataTable Select_tb_ProductImageBynProductID(int pnProductID)
        {
            try
            {
                try
                {
                    string connectionString = dbstring.dbconnectionstring.ToString();  // get your connection string here

                    SqlParameter[] sqlParameters = new SqlParameter[1];
                    sqlParameters[0] = new SqlParameter("@nProductID", SqlDbType.Int);
                    sqlParameters[0].Value = pnProductID;



                    DataSet ds = sqlhelper.SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "sp_Select_tb_ProductImageBynProductID", sqlParameters);
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

        public bool update_tb_ProductImageBynPImageID(int nPImageID, int nProductID, string sPImageNameCN, string sPImageNameEN, string sPImagePath, string psUpdatedBy, System.DateTime pdUpdatedTime, bool pbEnable, int pnSorting)
        {
            try
            {
                string connectionString = dbstring.dbconnectionstring.ToString();  // get your connection string here
                SqlParameter[] sqlParameters = new SqlParameter[9];
                sqlParameters[0] = new SqlParameter("@nPImageID", SqlDbType.Int);
                sqlParameters[0].Value = nPImageID;

                sqlParameters[1] = new SqlParameter("@nProductID", SqlDbType.Int);
                sqlParameters[1].Value = nProductID;

                sqlParameters[2] = new SqlParameter("@sPImageNameCN", SqlDbType.NVarChar);
                sqlParameters[2].Value = sPImageNameCN;

                sqlParameters[3] = new SqlParameter("@sPImageNameEN", SqlDbType.NVarChar);
                sqlParameters[3].Value = sPImageNameEN;

                sqlParameters[4] = new SqlParameter("@sPImagePath", SqlDbType.NVarChar);
                sqlParameters[4].Value = sPImagePath;

                sqlParameters[5] = new SqlParameter("@sUpdatedBy", SqlDbType.NVarChar);
                sqlParameters[5].Value = psUpdatedBy;

                sqlParameters[6] = new SqlParameter("@dUpdatedTime", SqlDbType.DateTime);
                sqlParameters[6].Value = pdUpdatedTime;

                sqlParameters[7] = new SqlParameter("@bEnable", SqlDbType.Bit);
                sqlParameters[7].Value = pbEnable;

                sqlParameters[8] = new SqlParameter("@nSorting", SqlDbType.Int);
                sqlParameters[8].Value = pnSorting;

                DataSet ds = sqlhelper.SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "sp_update_tb_ProductImageBynPImageID", sqlParameters);
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
