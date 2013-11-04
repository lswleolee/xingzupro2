using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace DBLL
{
    public class clsFAQs
    {

        public DataTable sp_selectNormalTableOfAllByFAQs(bool bIncludeUnable)
        {
            try
            {
                try
                {
                    string connectionString = dbstring.dbconnectionstring.ToString();  // get your connection string here

                    SqlParameter[] sqlParameters = new SqlParameter[1];
                    sqlParameters[0] = new SqlParameter("@bIncludeUnable", SqlDbType.Bit);
                    sqlParameters[0].Value = bIncludeUnable;
                    DataSet ds = sqlhelper.SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "sp_selectNormalTableOfAllByFAQs", sqlParameters);
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
        public int insert_tb_FAQs(string psQuestionCN, string psQuestionEN, string psAnswerCN, string psAnswerEN, string psCreatedBy, System.DateTime pdCreatedTime, string psUpdatedBy, System.DateTime pdUpdatedTime, bool pbEnable, int pnSorting)
        {
            int _nID = 0;
            try
            {
                string connectionString = dbstring.dbconnectionstring.ToString();  // get your connection string here

                SqlParameter[] sqlParameters = new SqlParameter[10];
                sqlParameters[0] = new SqlParameter("@sQuestionCN", SqlDbType.NVarChar);
                sqlParameters[0].Value = psQuestionCN;

                sqlParameters[1] = new SqlParameter("@sQuestionEN", SqlDbType.NVarChar);
                sqlParameters[1].Value = psQuestionEN;

                sqlParameters[2] = new SqlParameter("@sAnswerCN", SqlDbType.NVarChar);
                sqlParameters[2].Value = psAnswerCN;

                sqlParameters[3] = new SqlParameter("@sAnswerEN", SqlDbType.NVarChar);
                sqlParameters[3].Value = psAnswerEN;

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

                DataSet ds = sqlhelper.SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "sp_insert_tb_FAQs", sqlParameters);
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
        public DataTable Select_tb_FAQsBynFAQID(int pnFAQID)
        {
            try
            {
                try
                {
                    string connectionString = dbstring.dbconnectionstring.ToString();  // get your connection string here

                    SqlParameter[] sqlParameters = new SqlParameter[1];
                    sqlParameters[0] = new SqlParameter("@nFAQID", SqlDbType.Int);
                    sqlParameters[0].Value = pnFAQID;



                    DataSet ds = sqlhelper.SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "sp_Select_tb_FAQsBynFAQID", sqlParameters);
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

        public bool update_tb_FAQsBynFAQID(int nFAQID, string sQuestionCN, string sQuestionEN, string sAnswerCN, string sAnswerEN, string psUpdatedBy, System.DateTime pdUpdatedTime, bool pbEnable, int pnSorting)
        {
            try
            {
                string connectionString = dbstring.dbconnectionstring.ToString();  // get your connection string here
                SqlParameter[] sqlParameters = new SqlParameter[9];
                sqlParameters[0] = new SqlParameter("@nFAQID", SqlDbType.Int);
                sqlParameters[0].Value = nFAQID;

                sqlParameters[1] = new SqlParameter("@sQuestionCN", SqlDbType.NVarChar);
                sqlParameters[1].Value = sQuestionCN;

                sqlParameters[2] = new SqlParameter("@sQuestionEN", SqlDbType.NVarChar);
                sqlParameters[2].Value = sQuestionEN;

                sqlParameters[3] = new SqlParameter("@sAnswerCN", SqlDbType.NVarChar);
                sqlParameters[3].Value = sAnswerCN;

                sqlParameters[4] = new SqlParameter("@sAnswerEN", SqlDbType.NVarChar);
                sqlParameters[4].Value = sAnswerEN;

                sqlParameters[5] = new SqlParameter("@sUpdatedBy", SqlDbType.NVarChar);
                sqlParameters[5].Value = psUpdatedBy;

                sqlParameters[6] = new SqlParameter("@dUpdatedTime", SqlDbType.DateTime);
                sqlParameters[6].Value = pdUpdatedTime;

                sqlParameters[7] = new SqlParameter("@bEnable", SqlDbType.Bit);
                sqlParameters[7].Value = pbEnable;

                sqlParameters[8] = new SqlParameter("@nSorting", SqlDbType.Int);
                sqlParameters[8].Value = pnSorting;

                DataSet ds = sqlhelper.SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "sp_update_tb_FAQsBynFAQID", sqlParameters);
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
