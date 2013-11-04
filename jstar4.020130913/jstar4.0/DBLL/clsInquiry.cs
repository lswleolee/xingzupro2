using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace DBLL
{
    public class clsInquiry
    {

        public DataTable sp_selectNormalTableOfAllByInquiry(bool bIncludeUnable)
        {
            try
            {
                try
                {
                    string connectionString = dbstring.dbconnectionstring.ToString();  // get your connection string here

                    SqlParameter[] sqlParameters = new SqlParameter[1];
                    sqlParameters[0] = new SqlParameter("@bIncludeUnable", SqlDbType.Bit);
                    sqlParameters[0].Value = bIncludeUnable;
                    DataSet ds = sqlhelper.SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "sp_selectNormalTableOfAllByInquiry", sqlParameters);
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
        public int insert_tb_Inquiry(string psFirstName, string psLastName, int pnSex, string psEmail, string psSubject, string psMessage,
            string psCountry, string sProductIDList, string psCreatedBy, System.DateTime pdCreatedTime, string psUpdatedBy, System.DateTime pdUpdatedTime, bool pbEnable, int pnSorting, bool bCheck)
        {
            int _nID = 0;
            try
            {
                string connectionString = dbstring.dbconnectionstring.ToString();  // get your connection string here

                SqlParameter[] sqlParameters = new SqlParameter[15];
                sqlParameters[0] = new SqlParameter("@sFirstName", SqlDbType.NVarChar);
                sqlParameters[0].Value = psFirstName;

                sqlParameters[1] = new SqlParameter("@sLastName", SqlDbType.NVarChar);
                sqlParameters[1].Value = psLastName;

                sqlParameters[2] = new SqlParameter("@nSex", SqlDbType.Int);
                sqlParameters[2].Value = pnSex;

                sqlParameters[3] = new SqlParameter("@sEmail", SqlDbType.NVarChar);
                sqlParameters[3].Value = psEmail;

                sqlParameters[4] = new SqlParameter("@sSubject", SqlDbType.NVarChar);
                sqlParameters[4].Value = psSubject;

                sqlParameters[5] = new SqlParameter("@sMessage", SqlDbType.NVarChar);
                sqlParameters[5].Value = psMessage;

                sqlParameters[6] = new SqlParameter("@sCountry", SqlDbType.NVarChar);
                sqlParameters[6].Value = psCountry;

                

                sqlParameters[7] = new SqlParameter("@sCreatedBy", SqlDbType.NVarChar);
                sqlParameters[7].Value = psCreatedBy;

                sqlParameters[8] = new SqlParameter("@dCreatedTime", SqlDbType.DateTime);
                sqlParameters[8].Value = pdCreatedTime;

                sqlParameters[9] = new SqlParameter("@sUpdatedBy", SqlDbType.NVarChar);
                sqlParameters[9].Value = psUpdatedBy;

                sqlParameters[10] = new SqlParameter("@dUpdatedTime", SqlDbType.DateTime);
                sqlParameters[10].Value = pdUpdatedTime;

                sqlParameters[11] = new SqlParameter("@bEnable", SqlDbType.Bit);
                sqlParameters[11].Value = pbEnable;

                sqlParameters[12] = new SqlParameter("@nSorting", SqlDbType.Int);
                sqlParameters[12].Value = pnSorting;

                sqlParameters[13] = new SqlParameter("@sProductIDList", SqlDbType.NVarChar);
                sqlParameters[13].Value = sProductIDList;

                sqlParameters[14] = new SqlParameter("@bCheck", SqlDbType.Bit);
                sqlParameters[14].Value = bCheck;

                DataSet ds = sqlhelper.SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "sp_insert_tb_Inquiry", sqlParameters);
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
        public DataTable Select_tb_InquiryBynInquiryID(int pnInquiryID)
        {
            try
            {
                try
                {
                    string connectionString = dbstring.dbconnectionstring.ToString();  // get your connection string here

                    SqlParameter[] sqlParameters = new SqlParameter[1];
                    sqlParameters[0] = new SqlParameter("@nInquiryID", SqlDbType.Int);
                    sqlParameters[0].Value = pnInquiryID;



                    DataSet ds = sqlhelper.SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "sp_Select_tb_InquiryBynInquiryID", sqlParameters);
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
        public bool update_tb_InquiryBynInquiryID(int nInquiryID, string sFirstName, string sLastName, int nSex, string sEmail, string sSubject,
            string sMessage, string sCountry, string sProductIDList, string psUpdatedBy, System.DateTime pdUpdatedTime, bool pbEnable, int pnSorting, bool bCheck)
        {
            try
            {
                string connectionString = dbstring.dbconnectionstring.ToString();  // get your connection string here
                SqlParameter[] sqlParameters = new SqlParameter[13];
                sqlParameters[0] = new SqlParameter("@nInquiryID", SqlDbType.Int);
                sqlParameters[0].Value = nInquiryID;

                sqlParameters[1] = new SqlParameter("@sFirstName", SqlDbType.NVarChar);
                sqlParameters[1].Value = sFirstName;

                sqlParameters[2] = new SqlParameter("@sLastName", SqlDbType.NVarChar);
                sqlParameters[2].Value = sLastName;

                sqlParameters[3] = new SqlParameter("@nSex", SqlDbType.Int);
                sqlParameters[3].Value = nSex;

                sqlParameters[4] = new SqlParameter("@sEmail", SqlDbType.NVarChar);
                sqlParameters[4].Value = sEmail;

                sqlParameters[5] = new SqlParameter("@sSubject", SqlDbType.NVarChar);
                sqlParameters[5].Value = sSubject;

                sqlParameters[6] = new SqlParameter("@sMessage", SqlDbType.NVarChar);
                sqlParameters[6].Value = sMessage;

                sqlParameters[7] = new SqlParameter("@sCountry", SqlDbType.NVarChar);
                sqlParameters[7].Value = sCountry;

                sqlParameters[8] = new SqlParameter("@sUpdatedBy", SqlDbType.NVarChar);
                sqlParameters[8].Value = psUpdatedBy;

                sqlParameters[9] = new SqlParameter("@dUpdatedTime", SqlDbType.DateTime);
                sqlParameters[9].Value = pdUpdatedTime;

                sqlParameters[10] = new SqlParameter("@bEnable", SqlDbType.Bit);
                sqlParameters[10].Value = pbEnable;

                sqlParameters[11] = new SqlParameter("@nSorting", SqlDbType.Int);
                sqlParameters[11].Value = pnSorting;
                sqlParameters[12] = new SqlParameter("@sProductIDList", SqlDbType.NVarChar);
                sqlParameters[12].Value = sProductIDList;
                sqlParameters[13] = new SqlParameter("@bCheck", SqlDbType.Bit);
                sqlParameters[13].Value = bCheck;
                DataSet ds = sqlhelper.SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "sp_update_tb_InquiryBynInquiryID", sqlParameters);
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


        public bool update_tb_InquiryBynInquiryIDAndbCheck(int nInquiryID, bool bCheck)
        {
            try
            {
                string connectionString = dbstring.dbconnectionstring.ToString();  // get your connection string here
                SqlParameter[] sqlParameters = new SqlParameter[2];
                sqlParameters[0] = new SqlParameter("@nInquiryID", SqlDbType.Int);
                sqlParameters[0].Value = nInquiryID;
                sqlParameters[1] = new SqlParameter("@bCheck", SqlDbType.Bit);
                sqlParameters[1].Value = bCheck;
                DataSet ds = sqlhelper.SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "sp_update_tb_InquiryBynInquiryIDAndbCheck", sqlParameters);
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
