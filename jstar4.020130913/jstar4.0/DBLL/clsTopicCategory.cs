using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace DBLL
{
    public class clsTopicCategory
    {

        public DataTable sp_selectNormalTableOfAllByTopicCategory(bool bIncludeUnable)
        {
            try
            {
                try
                {
                    string connectionString = dbstring.dbconnectionstring.ToString();  // get your connection string here

                    SqlParameter[] sqlParameters = new SqlParameter[1];
                    sqlParameters[0] = new SqlParameter("@bIncludeUnable", SqlDbType.Bit);
                    sqlParameters[0].Value = bIncludeUnable;
                    DataSet ds = sqlhelper.SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "sp_selectNormalTableOfAllByTopicCategory", sqlParameters);
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
        public int insert_tb_TopicCategory(int pnTopicID, string psTCategoryNameCN, string psTCategoryNameEN, int pnType, string psContentCN, string psContentEN, string psCreatedBy, System.DateTime pdCreatedTime, string psUpdatedBy, System.DateTime pdUpdatedTime, bool pbEnable, int pnSorting)
        {
            int _nID = 0;
            try
            {
            string connectionString = dbstring.dbconnectionstring.ToString();  // get your connection string here

            SqlParameter[] sqlParameters = new SqlParameter[12];
            sqlParameters[0] = new SqlParameter("@nTopicID", SqlDbType.Int);
            sqlParameters[0].Value = pnTopicID;

            sqlParameters[1] = new SqlParameter("@sTCategoryNameCN", SqlDbType.NVarChar);
            sqlParameters[1].Value = psTCategoryNameCN;

            sqlParameters[2] = new SqlParameter("@sTCategoryNameEN", SqlDbType.NVarChar);
            sqlParameters[2].Value = psTCategoryNameEN;

            sqlParameters[3] = new SqlParameter("@nType", SqlDbType.Int);
            sqlParameters[3].Value = pnType;

            sqlParameters[4] = new SqlParameter("@sContentCN", psContentCN);

            sqlParameters[5] = new SqlParameter("@sContentEN", psContentEN);

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

            DataSet ds = sqlhelper.SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "sp_insert_tb_TopicCategory", sqlParameters);
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
        public DataTable Select_tb_TopicCategoryBynTCategoryID(int pnTCategoryID)
        {
            try
            {
                try
                {
                    string connectionString = dbstring.dbconnectionstring.ToString();  // get your connection string here

                    SqlParameter[] sqlParameters = new SqlParameter[1];
                    sqlParameters[0] = new SqlParameter("@nTCategoryID", SqlDbType.Int);
                    sqlParameters[0].Value = pnTCategoryID;

                    DataSet ds = sqlhelper.SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "sp_Select_tb_TopicCategoryBynTCategoryID", sqlParameters);
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
        public DataTable Select_tb_TopicCategoryBynTopicID(int pnTopicID)
        {
            try
            {
                try
                {
                    string connectionString = dbstring.dbconnectionstring.ToString();  // get your connection string here

                    SqlParameter[] sqlParameters = new SqlParameter[1];
                    sqlParameters[0] = new SqlParameter("@nTopicID", SqlDbType.Int);
                    sqlParameters[0].Value = pnTopicID;

                    DataSet ds = sqlhelper.SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "sp_Select_tb_TopicCategoryBynTopicID", sqlParameters);
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
        public DataTable sp_selectNormalTableOfAllByTopicCategoryAndnType(bool bIncludeUnable, int nType)
        {
            try
            {
                try
                {
                    string connectionString = dbstring.dbconnectionstring.ToString();  // get your connection string here

                    SqlParameter[] sqlParameters = new SqlParameter[2];
                    sqlParameters[0] = new SqlParameter("@bIncludeUnable", SqlDbType.Bit);
                    sqlParameters[0].Value = bIncludeUnable;
                    sqlParameters[1] = new SqlParameter("@nType", SqlDbType.Int);
                    sqlParameters[1].Value = nType;
                    DataSet ds = sqlhelper.SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "sp_selectNormalTableOfAllByTopicCategoryAndnType", sqlParameters);
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
        public bool update_tb_TopicCategoryBynTCategoryID(int nTCategoryID, int nTopicID, string sTCategoryNameCN, string sTCategoryNameEN, int nType, string sContentCN, string sContentEN, string psUpdatedBy, System.DateTime pdUpdatedTime, bool pbEnable, int pnSorting)
        {
            try
            {
                string connectionString = dbstring.dbconnectionstring.ToString();  // get your connection string here
                SqlParameter[] sqlParameters = new SqlParameter[11];
                sqlParameters[0] = new SqlParameter("@nTCategoryID", SqlDbType.Int);
                sqlParameters[0].Value = nTCategoryID;

                sqlParameters[1] = new SqlParameter("@nTopicID", SqlDbType.Int);
                sqlParameters[1].Value = nTopicID;

                sqlParameters[2] = new SqlParameter("@sTCategoryNameCN", SqlDbType.NVarChar);
                sqlParameters[2].Value = sTCategoryNameCN;

                sqlParameters[3] = new SqlParameter("@sTCategoryNameEN", SqlDbType.NVarChar);
                sqlParameters[3].Value = sTCategoryNameEN;

                sqlParameters[4] = new SqlParameter("@nType", SqlDbType.Int);
                sqlParameters[4].Value = nType;

                sqlParameters[5] = new SqlParameter("@sContentCN", SqlDbType.NVarChar);
                sqlParameters[5].Value = sContentCN;

                sqlParameters[6] = new SqlParameter("@sContentEN", SqlDbType.NVarChar);
                sqlParameters[6].Value = sContentEN;

                sqlParameters[7] = new SqlParameter("@sUpdatedBy", SqlDbType.NVarChar);
                sqlParameters[7].Value = psUpdatedBy;

                sqlParameters[8] = new SqlParameter("@dUpdatedTime", SqlDbType.DateTime);
                sqlParameters[8].Value = pdUpdatedTime;

                sqlParameters[9] = new SqlParameter("@bEnable", SqlDbType.Bit);
                sqlParameters[9].Value = pbEnable;

                sqlParameters[10] = new SqlParameter("@nSorting", SqlDbType.Int);
                sqlParameters[10].Value = pnSorting;

                DataSet ds = sqlhelper.SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "sp_update_tb_TopicCategoryBynTCategoryID", sqlParameters);
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
