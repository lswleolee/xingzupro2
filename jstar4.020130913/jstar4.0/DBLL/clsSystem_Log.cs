using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace DBLL
{
    public class clsSystem_Log
    {


        public int insert_tb_System_Log(string psTypeCN, string psTypeEN, string psRemarkCN, string psRemarkEN, string psCreatedBy, System.DateTime pdCreatedTime, string psUpdatedBy, System.DateTime pdUpdatedTime, bool pbEnable, int pnSorting)
        {
            int _nID = 0;
            try
            {
                string connectionString = dbstring.dbconnectionstring.ToString();  // get your connection string here

            SqlParameter[] sqlParameters = new SqlParameter[10];
            sqlParameters[0] = new SqlParameter("@sTypeCN", SqlDbType.NVarChar);
            sqlParameters[0].Value = psTypeCN;

            sqlParameters[1] = new SqlParameter("@sTypeEN", SqlDbType.NVarChar);
            sqlParameters[1].Value = psTypeEN;

            sqlParameters[2] = new SqlParameter("@sRemarkCN", SqlDbType.NVarChar);
            sqlParameters[2].Value = psRemarkCN;

            sqlParameters[3] = new SqlParameter("@sRemarkEN", SqlDbType.NVarChar);
            sqlParameters[3].Value = psRemarkEN;

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

            DataSet ds = sqlhelper.SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "sp_insert_tb_System_Log", sqlParameters);
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
    }
}
