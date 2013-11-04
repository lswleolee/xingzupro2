using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace DBLL
{
    public class clsTopic
    {

        public DataTable sp_selectNormalTableOfAllByTopic(bool bIncludeUnable)
        {
            try
            {
                try
                {
                    string connectionString = dbstring.dbconnectionstring.ToString();  // get your connection string here

                    SqlParameter[] sqlParameters = new SqlParameter[1];
                    sqlParameters[0] = new SqlParameter("@bIncludeUnable", SqlDbType.Bit);
                    sqlParameters[0].Value = bIncludeUnable;
                    DataSet ds = sqlhelper.SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "sp_selectNormalTableOfAllByTopic", sqlParameters);
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
        public int insert_tb_Topic(string psTopicNameCN, string psTopicNameEN, string psCreatedBy, System.DateTime pdCreatedTime, string psUpdatedBy, System.DateTime pdUpdatedTime, bool pbEnable, int pnSorting)
        {
            int _nID = 0;
            try
            {
                string connectionString = dbstring.dbconnectionstring.ToString();  // get your connection string here

                SqlParameter[] sqlParameters = new SqlParameter[8];
                sqlParameters[0] = new SqlParameter("@sTopicNameCN", SqlDbType.NVarChar);
                sqlParameters[0].Value = psTopicNameCN;

                sqlParameters[1] = new SqlParameter("@sTopicNameEN", psTopicNameEN);

                sqlParameters[2] = new SqlParameter("@sCreatedBy", SqlDbType.NVarChar);
                sqlParameters[2].Value = psCreatedBy;

                sqlParameters[3] = new SqlParameter("@dCreatedTime", SqlDbType.DateTime);
                sqlParameters[3].Value = pdCreatedTime;

                sqlParameters[4] = new SqlParameter("@sUpdatedBy", SqlDbType.NVarChar);
                sqlParameters[4].Value = psUpdatedBy;

                sqlParameters[5] = new SqlParameter("@dUpdatedTime", SqlDbType.DateTime);
                sqlParameters[5].Value = pdUpdatedTime;

                sqlParameters[6] = new SqlParameter("@bEnable", SqlDbType.Bit);
                sqlParameters[6].Value = pbEnable;

                sqlParameters[7] = new SqlParameter("@nSorting", SqlDbType.Int);
                sqlParameters[7].Value = pnSorting;

                DataSet ds = sqlhelper.SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "sp_insert_tb_Topic", sqlParameters);
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
        public DataTable Select_tb_TopicBynTopicID(int pnTopicID)
        {
           
                try
                {
                    string connectionString = dbstring.dbconnectionstring.ToString();  // get your connection string here

                    SqlParameter[] sqlParameters = new SqlParameter[1];
                    sqlParameters[0] = new SqlParameter("@nTopicID", SqlDbType.Int);
                    sqlParameters[0].Value = pnTopicID;

                    DataSet ds = sqlhelper.SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "sp_Select_tb_TopicBynTopicID", sqlParameters);
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
        public bool update_tb_TopicBynTopicID(int nTopicID, string sTopicNameCN, string sTopicNameEN, string psUpdatedBy, System.DateTime pdUpdatedTime, bool pbEnable, int pnSorting)
        {
            try
            {
                string connectionString = dbstring.dbconnectionstring.ToString();  // get your connection string here
                SqlParameter[] sqlParameters = new SqlParameter[7];
                sqlParameters[0] = new SqlParameter("@nTopicID", SqlDbType.Int);
                sqlParameters[0].Value = nTopicID;

                sqlParameters[1] = new SqlParameter("@sTopicNameCN", SqlDbType.NVarChar);
                sqlParameters[1].Value = sTopicNameCN;

                sqlParameters[2] = new SqlParameter("@sTopicNameEN", SqlDbType.NVarChar);
                sqlParameters[2].Value = sTopicNameEN;

                sqlParameters[3] = new SqlParameter("@sUpdatedBy", SqlDbType.NVarChar);
                sqlParameters[3].Value = psUpdatedBy;

                sqlParameters[4] = new SqlParameter("@dUpdatedTime", SqlDbType.DateTime);
                sqlParameters[4].Value = pdUpdatedTime;

                sqlParameters[5] = new SqlParameter("@bEnable", SqlDbType.Bit);
                sqlParameters[5].Value = pbEnable;

                sqlParameters[6] = new SqlParameter("@nSorting", SqlDbType.Int);
                sqlParameters[6].Value = pnSorting;

                DataSet ds = sqlhelper.SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "sp_update_tb_TopicBynTopicID", sqlParameters);
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
