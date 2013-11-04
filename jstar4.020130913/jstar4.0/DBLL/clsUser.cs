using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace DBLL
{
    public class clsUser
    {

        public DataTable sp_selectNormalTableOfAllByUser(bool bIncludeUnable)
        {
            try
            {
                try
                {
                    string connectionString = dbstring.dbconnectionstring.ToString();  // get your connection string here

                    SqlParameter[] sqlParameters = new SqlParameter[1];
                    sqlParameters[0] = new SqlParameter("@bIncludeUnable", SqlDbType.Bit);
                    sqlParameters[0].Value = bIncludeUnable;
                    DataSet ds = sqlhelper.SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "sp_selectNormalTableOfAllByUser", sqlParameters);
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
        public int insert_tb_User(string psUsername, string psPassword, string psRealName, int pnUserSex, string psUserQQ, string psUserMSN, string psUserPhone, string psUserEmail, int pnUserType, string psCreatedBy, System.DateTime pdCreatedTime, string psUpdatedBy, System.DateTime pdUpdatedTime, bool pbEnable, int pnSorting, bool pIsContact, bool pIsInquiry)
        {
            int _nID = 0;
            try
            {
                string connectionString = dbstring.dbconnectionstring.ToString();  // get your connection string here

                SqlParameter[] sqlParameters = new SqlParameter[17];
                sqlParameters[0] = new SqlParameter("@sUsername", SqlDbType.NVarChar);
                sqlParameters[0].Value = psUsername;

                sqlParameters[1] = new SqlParameter("@sPassword", SqlDbType.NVarChar);
                sqlParameters[1].Value = psPassword;

                sqlParameters[2] = new SqlParameter("@sRealName", SqlDbType.NVarChar);
                sqlParameters[2].Value = psRealName;

                sqlParameters[3] = new SqlParameter("@nUserSex", SqlDbType.Int);
                sqlParameters[3].Value = pnUserSex;

                sqlParameters[4] = new SqlParameter("@sUserQQ", SqlDbType.NVarChar);
                sqlParameters[4].Value = psUserQQ;

                sqlParameters[5] = new SqlParameter("@sUserMSN", psUserMSN);

                sqlParameters[6] = new SqlParameter("@sUserPhone", SqlDbType.NVarChar);
                sqlParameters[6].Value = psUserPhone;

                sqlParameters[7] = new SqlParameter("@sUserEmail", SqlDbType.NVarChar);
                sqlParameters[7].Value = psUserEmail;

                sqlParameters[8] = new SqlParameter("@nUserType", SqlDbType.Int);
                sqlParameters[8].Value = pnUserType;

                sqlParameters[9] = new SqlParameter("@sCreatedBy", SqlDbType.NVarChar);
                sqlParameters[9].Value = psCreatedBy;

                sqlParameters[10] = new SqlParameter("@dCreatedTime", SqlDbType.DateTime);
                sqlParameters[10].Value = pdCreatedTime;

                sqlParameters[11] = new SqlParameter("@sUpdatedBy", SqlDbType.NVarChar);
                sqlParameters[11].Value = psUpdatedBy;

                sqlParameters[12] = new SqlParameter("@dUpdatedTime", SqlDbType.DateTime);
                sqlParameters[12].Value = pdUpdatedTime;

                sqlParameters[13] = new SqlParameter("@bEnable", SqlDbType.Bit);
                sqlParameters[13].Value = pbEnable;

                sqlParameters[14] = new SqlParameter("@nSorting", SqlDbType.Int);
                sqlParameters[14].Value = pnSorting;

                sqlParameters[15] = new SqlParameter("@IsContact", SqlDbType.Bit);
                sqlParameters[15].Value = pIsContact;

                sqlParameters[16] = new SqlParameter("@IsInquiry", SqlDbType.Bit);
                sqlParameters[16].Value = pIsInquiry;

                DataSet ds = sqlhelper.SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "sp_insert_tb_User", sqlParameters);
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
        public DataTable Select_tb_UserBynUserID(int pnUserID)
        {
            try
            {
                try
                {
                    string connectionString = dbstring.dbconnectionstring.ToString();  // get your connection string here

                    SqlParameter[] sqlParameters = new SqlParameter[1];
                    sqlParameters[0] = new SqlParameter("@nUserID", SqlDbType.Int);
                    sqlParameters[0].Value = pnUserID;

                    DataSet ds = sqlhelper.SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "sp_Select_tb_UserBynUserID", sqlParameters);
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
        public DataTable Select_tb_UserBysUsernameandsPassword(string psUsername, string psPassword)
        {
            try
            {
                try
                {
                    string connectionString = dbstring.dbconnectionstring.ToString();  // get your connection string here

                    SqlParameter[] sqlParameters = new SqlParameter[2];
                    sqlParameters[0] = new SqlParameter("@sUsername", psUsername);
                    sqlParameters[1] = new SqlParameter("@sPassword", psPassword);

                    DataSet ds = sqlhelper.SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "sp_Select_tb_UserBysUsernameandsPassword", sqlParameters);
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

        public bool update_tb_UserBynUserID(int nUserID, string sUsername, string sPassword, string sRealName, int nUserSex, string sUserQQ, string sUserMSN, string sUserPhone, string sUserEmail, int nUserType, string psUpdatedBy, System.DateTime pdUpdatedTime, bool pbEnable, int pnSorting, bool pIsContact, bool pIsInquiry)
        {
            try
            {
                string connectionString = dbstring.dbconnectionstring.ToString();  // get your connection string here
                SqlParameter[] sqlParameters = new SqlParameter[16];
                sqlParameters[0] = new SqlParameter("@nUserID", SqlDbType.Int);
                sqlParameters[0].Value = nUserID;

                sqlParameters[1] = new SqlParameter("@sUsername", SqlDbType.NVarChar);
                sqlParameters[1].Value = sUsername;

                sqlParameters[2] = new SqlParameter("@sPassword", SqlDbType.NVarChar);
                sqlParameters[2].Value = sPassword;

                sqlParameters[3] = new SqlParameter("@sRealName", SqlDbType.NVarChar);
                sqlParameters[3].Value = sRealName;

                sqlParameters[4] = new SqlParameter("@nUserSex", SqlDbType.Int);
                sqlParameters[4].Value = nUserSex;

                sqlParameters[5] = new SqlParameter("@sUserQQ", SqlDbType.NVarChar);
                sqlParameters[5].Value = sUserQQ;

                sqlParameters[6] = new SqlParameter("@sUserMSN", SqlDbType.NVarChar);
                sqlParameters[6].Value = sUserMSN;

                sqlParameters[7] = new SqlParameter("@sUserPhone", SqlDbType.NVarChar);
                sqlParameters[7].Value = sUserPhone;

                sqlParameters[8] = new SqlParameter("@sUserEmail", SqlDbType.NVarChar);
                sqlParameters[8].Value = sUserEmail;

                sqlParameters[9] = new SqlParameter("@nUserType", SqlDbType.Int);
                sqlParameters[9].Value = nUserType;

                sqlParameters[10] = new SqlParameter("@sUpdatedBy", SqlDbType.NVarChar);
                sqlParameters[10].Value = psUpdatedBy;

                sqlParameters[11] = new SqlParameter("@dUpdatedTime", SqlDbType.DateTime);
                sqlParameters[11].Value = pdUpdatedTime;

                sqlParameters[12] = new SqlParameter("@bEnable", SqlDbType.Bit);
                sqlParameters[12].Value = pbEnable;

                sqlParameters[13] = new SqlParameter("@nSorting", SqlDbType.Int);
                sqlParameters[13].Value = pnSorting;

                sqlParameters[14] = new SqlParameter("@IsContact", SqlDbType.Bit);
                sqlParameters[14].Value = pIsContact;

                sqlParameters[15] = new SqlParameter("@IsInquiry", SqlDbType.Bit);
                sqlParameters[15].Value = pIsInquiry;
                DataSet ds = sqlhelper.SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "sp_update_tb_UserBynUserID", sqlParameters);
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
