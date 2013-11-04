using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
namespace DBLL
{
    public class DBcommon
    {
        public DataTable GetDataTable(string cmd)
        {
            try
            {
                DataTable dt = sqlhelper.SqlHelper.ExecuteDataset(dbstring.dbconnectionstring, CommandType.Text, cmd).Tables[0];
                return dt;
            }
            catch (Exception)
            {

                return null;
            }
        }
        public int Excute(string cmd)
        {
            try
            {
                int count = sqlhelper.SqlHelper.ExecuteNonQuery(dbstring.dbconnectionstring, CommandType.Text, cmd);
                return count;
            }
            catch (Exception)
            {

                return 0;
            }
        }

        public DataTable selectNormalTableofAll(bool bIncludeUnable, string sTableName)
        {
            try
            {
                try
                {
                    string connectionString = dbstring.dbconnectionstring.ToString();  // get your connection string here

                    SqlParameter[] sqlParameters = new SqlParameter[2];
                    sqlParameters[0] = new SqlParameter("@bIncludeUnable", SqlDbType.Bit);
                    sqlParameters[0].Value = bIncludeUnable;
                    sqlParameters[1] = new SqlParameter("@sTableName", SqlDbType.NVarChar);
                    sqlParameters[1].Value = sTableName;
                    DataSet ds = sqlhelper.SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "sp_selectNormalTableOfAll", sqlParameters);
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
        public void sp_DeleteNormalTableByID(int pnKeyID, string psTableName)
        {


            string connectionString = dbstring.dbconnectionstring.ToString();  // get your connection string here

            SqlParameter[] sqlParameters = new SqlParameter[2];
            sqlParameters[0] = new SqlParameter("@nKeyID", SqlDbType.Int);
            sqlParameters[0].Value = pnKeyID;

            sqlParameters[1] = new SqlParameter("@sTableName", SqlDbType.NVarChar);
            sqlParameters[1].Value = psTableName;
            try
            {
                DataSet ds = sqlhelper.SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "sp_DeleteNormalTableByID", sqlParameters);

            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public DataTable sp_selectNormalTableBynKeyID(bool pbIncludeUnable, string psTableName, int nKeyID)
        {
            try
            {
                try
                {
                    string connectionString = dbstring.dbconnectionstring.ToString();  // get your connection string here

                    SqlParameter[] sqlParameters = new SqlParameter[3];
                    sqlParameters[0] = new SqlParameter("@bIncludeUnable", SqlDbType.Bit);
                    sqlParameters[0].Value = pbIncludeUnable;

                    sqlParameters[1] = new SqlParameter("@sTableName", SqlDbType.NVarChar);
                    sqlParameters[1].Value = psTableName;

                    sqlParameters[2] = new SqlParameter("@nKeyID", SqlDbType.NVarChar);
                    sqlParameters[2].Value = psTableName;

                    DataSet ds = sqlhelper.SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "sp_selectNormalTableBynKeyID", sqlParameters);
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
    }
}
