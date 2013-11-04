using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace DBLL
{
    public class clsProduct
    {

        public DataTable sp_selectNormalTableOfAllByProduct(bool bIncludeUnable)
        {
            try
            {
                try
                {
                    string connectionString = dbstring.dbconnectionstring.ToString();  // get your connection string here

                    SqlParameter[] sqlParameters = new SqlParameter[1];
                    sqlParameters[0] = new SqlParameter("@bIncludeUnable", SqlDbType.Bit);
                    sqlParameters[0].Value = bIncludeUnable;
                    DataSet ds = sqlhelper.SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "sp_selectNormalTableOfAllByProduct", sqlParameters);
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
        public int insert_tb_Product(int pnProductCategoryID, bool pbHot, string sThumbPath, string psProductNameCN, string psProductNameEN, string psSummaryCN, string psSummaryEN, string psPlaceoforiginCN, 
            string psPlaceoforiginEN, string psModelNoCN, string psModelNoEN, string psPriceTermsCN, string psPriceTermsEN, string psPaymentTermsCN, string psPaymentTermsEN, string psPackageCN,
            string psPackageEN, string psMinimumOrderCN, string psMinimumOrderEN, string psDeliveryTimeCN, string psDeliveryTimeEN, string psBrandNameCN, string psBrandNameEN, string psIntroCN, 
            string psIntroEN, string psCreatedBy, System.DateTime pdCreatedTime, string psUpdatedBy, System.DateTime pdUpdatedTime, bool pbEnable, int pnSorting)
        {
            int _nID = 0;
            try
            {
                string connectionString = dbstring.dbconnectionstring.ToString();  // get your connection string here

                SqlParameter[] sqlParameters = new SqlParameter[31];
                sqlParameters[0] = new SqlParameter("@nProductCategoryID", SqlDbType.Int);
                sqlParameters[0].Value = pnProductCategoryID;

                sqlParameters[1] = new SqlParameter("@bHot", SqlDbType.Bit);
                sqlParameters[1].Value = pbHot;

                sqlParameters[2] = new SqlParameter("@sProductNameCN", SqlDbType.NVarChar);
                sqlParameters[2].Value = psProductNameCN;

                sqlParameters[3] = new SqlParameter("@sProductNameEN", SqlDbType.NVarChar);
                sqlParameters[3].Value = psProductNameEN;

                sqlParameters[4] = new SqlParameter("@sSummaryCN", SqlDbType.NVarChar);
                sqlParameters[4].Value = psSummaryCN;

                sqlParameters[5] = new SqlParameter("@sSummaryEN", SqlDbType.NVarChar);
                sqlParameters[5].Value = psSummaryEN;

                sqlParameters[6] = new SqlParameter("@sPlaceoforiginCN", SqlDbType.NVarChar);
                sqlParameters[6].Value = psPlaceoforiginCN;

                sqlParameters[7] = new SqlParameter("@sPlaceoforiginEN", SqlDbType.NVarChar);
                sqlParameters[7].Value = psPlaceoforiginEN;

                sqlParameters[8] = new SqlParameter("@sModelNoCN", SqlDbType.NVarChar);
                sqlParameters[8].Value = psModelNoCN;

                sqlParameters[9] = new SqlParameter("@sModelNoEN", SqlDbType.NVarChar);
                sqlParameters[9].Value = psModelNoEN;

                sqlParameters[10] = new SqlParameter("@sPriceTermsCN", SqlDbType.NVarChar);
                sqlParameters[10].Value = psPriceTermsCN;

                sqlParameters[11] = new SqlParameter("@sPriceTermsEN", SqlDbType.NVarChar);
                sqlParameters[11].Value = psPriceTermsEN;

                sqlParameters[12] = new SqlParameter("@sPaymentTermsCN", SqlDbType.NVarChar);
                sqlParameters[12].Value = psPaymentTermsCN;

                sqlParameters[13] = new SqlParameter("@sPaymentTermsEN", SqlDbType.NVarChar);
                sqlParameters[13].Value = psPaymentTermsEN;

                sqlParameters[14] = new SqlParameter("@sPackageCN", SqlDbType.NVarChar);
                sqlParameters[14].Value = psPackageCN;

                sqlParameters[15] = new SqlParameter("@sPackageEN", SqlDbType.NVarChar);
                sqlParameters[15].Value = psPackageEN;

                sqlParameters[16] = new SqlParameter("@sMinimumOrderCN", SqlDbType.NVarChar);
                sqlParameters[16].Value = psMinimumOrderCN;

                sqlParameters[17] = new SqlParameter("@sMinimumOrderEN", SqlDbType.NVarChar);
                sqlParameters[17].Value = psMinimumOrderEN;

                sqlParameters[18] = new SqlParameter("@sDeliveryTimeCN", SqlDbType.NVarChar);
                sqlParameters[18].Value = psDeliveryTimeCN;

                sqlParameters[19] = new SqlParameter("@sDeliveryTimeEN", SqlDbType.NVarChar);
                sqlParameters[19].Value = psDeliveryTimeEN;

                sqlParameters[20] = new SqlParameter("@sBrandNameCN", SqlDbType.NVarChar);
                sqlParameters[20].Value = psBrandNameCN;

                sqlParameters[21] = new SqlParameter("@sBrandNameEN", SqlDbType.NVarChar);
                sqlParameters[21].Value = psBrandNameEN;

                sqlParameters[22] = new SqlParameter("@sIntroCN", psIntroCN);

                sqlParameters[23] = new SqlParameter("@sIntroEN", psIntroEN);

                sqlParameters[24] = new SqlParameter("@sCreatedBy", SqlDbType.NVarChar);
                sqlParameters[24].Value = psCreatedBy;

                sqlParameters[25] = new SqlParameter("@dCreatedTime", SqlDbType.DateTime);
                sqlParameters[25].Value = pdCreatedTime;

                sqlParameters[26] = new SqlParameter("@sUpdatedBy", SqlDbType.NVarChar);
                sqlParameters[26].Value = psUpdatedBy;

                sqlParameters[27] = new SqlParameter("@dUpdatedTime", SqlDbType.DateTime);
                sqlParameters[27].Value = pdUpdatedTime;

                sqlParameters[28] = new SqlParameter("@bEnable", SqlDbType.Bit);
                sqlParameters[28].Value = pbEnable;

                sqlParameters[29] = new SqlParameter("@nSorting", SqlDbType.Int);
                sqlParameters[29].Value = pnSorting;

                sqlParameters[30] = new SqlParameter("@sThumbPath", SqlDbType.NVarChar);
                sqlParameters[30].Value = sThumbPath;
                DataSet ds = sqlhelper.SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "sp_insert_tb_Product", sqlParameters);
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
        public DataTable Select_tb_ProductBybHot(bool pbHot)
        {
            try
            {
                try
                {
                    string connectionString = dbstring.dbconnectionstring.ToString();  // get your connection string here

                    SqlParameter[] sqlParameters = new SqlParameter[1];
                    sqlParameters[0] = new SqlParameter("@bHot", pbHot);

                    DataSet ds = sqlhelper.SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "sp_Select_tb_ProductBybHot", sqlParameters);
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
        public DataTable Select_tb_ProductBynProductCategoryID(int pnProductCategoryID)
        {
            try
            {
                try
                {
                    string connectionString = dbstring.dbconnectionstring.ToString();  // get your connection string here

                    SqlParameter[] sqlParameters = new SqlParameter[1];
                    sqlParameters[0] = new SqlParameter("@nProductCategoryID", SqlDbType.Int);
                    sqlParameters[0].Value = pnProductCategoryID;



                    DataSet ds = sqlhelper.SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "sp_Select_tb_ProductBynProductCategoryID", sqlParameters);
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
        public DataTable Select_tb_ProductBynProductID(int pnProductID)
        {
            try
            {
                try
                {
                    string connectionString = dbstring.dbconnectionstring.ToString();  // get your connection string here

                    SqlParameter[] sqlParameters = new SqlParameter[1];
                    sqlParameters[0] = new SqlParameter("@nProductID", SqlDbType.Int);
                    sqlParameters[0].Value = pnProductID;



                    DataSet ds = sqlhelper.SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "sp_Select_tb_ProductBynProductID", sqlParameters);
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
        public DataTable Select_tb_ProductBynParentCategoryID(int nParentCategoryID)
        {
            try
            {
                try
                {
                    string connectionString = dbstring.dbconnectionstring.ToString();  // get your connection string here

                    SqlParameter[] sqlParameters = new SqlParameter[1];
                    sqlParameters[0] = new SqlParameter("@nParentCategoryID", SqlDbType.Int);
                    sqlParameters[0].Value = nParentCategoryID;



                    DataSet ds = sqlhelper.SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "sp_Select_tb_ProductBynParentCategoryID", sqlParameters);
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
        public bool update_tb_ProductBynProductID(int nProductID ,int nProductCategoryID, bool bHot,string sThumbPath, string sProductNameCN, string sProductNameEN, string psSummaryCN, string psSummaryEN, string sPlaceoforiginCN,
            string sPlaceoforiginEN, string sModelNoCN, string sModelNoEN, string sPriceTermsCN, string sPriceTermsEN, string sPaymentTermsCN, string sPaymentTermsEN, string sPackageCN, string sPackageEN, 
            string sMinimumOrderCN, string sMinimumOrderEN, string sDeliveryTimeCN, string sDeliveryTimeEN, string sBrandNameCN, string sBrandNameEN, string sIntroCN, string sIntroEN, string psUpdatedBy, 
            System.DateTime pdUpdatedTime, bool pbEnable, int pnSorting)
        {
            try
            {
                string connectionString = dbstring.dbconnectionstring.ToString();  // get your connection string here
                SqlParameter[] sqlParameters = new SqlParameter[30];
                sqlParameters[0] = new SqlParameter("@nProductID", SqlDbType.Int);
                sqlParameters[0].Value = nProductID;

                sqlParameters[1] = new SqlParameter("@nProductCategoryID", SqlDbType.Int);
                sqlParameters[1].Value = nProductCategoryID;

                sqlParameters[2] = new SqlParameter("@bHot", SqlDbType.Bit);
                sqlParameters[2].Value = bHot;

                sqlParameters[3] = new SqlParameter("@sProductNameCN", SqlDbType.NVarChar);
                sqlParameters[3].Value = sProductNameCN;

                sqlParameters[4] = new SqlParameter("@sProductNameEN", SqlDbType.NVarChar);
                sqlParameters[4].Value = sProductNameEN;

                sqlParameters[5] = new SqlParameter("@sSummaryCN", SqlDbType.NVarChar);
                sqlParameters[5].Value = psSummaryCN;

                sqlParameters[6] = new SqlParameter("@sSummaryEN", SqlDbType.NVarChar);
                sqlParameters[6].Value = psSummaryEN;

                sqlParameters[7] = new SqlParameter("@sPlaceoforiginCN", SqlDbType.NVarChar);
                sqlParameters[7].Value = sPlaceoforiginCN;

                sqlParameters[8] = new SqlParameter("@sPlaceoforiginEN", SqlDbType.NVarChar);
                sqlParameters[8].Value = sPlaceoforiginEN;

                sqlParameters[9] = new SqlParameter("@sModelNoCN", SqlDbType.NVarChar);
                sqlParameters[9].Value = sModelNoCN;

                sqlParameters[10] = new SqlParameter("@sModelNoEN", SqlDbType.NVarChar);
                sqlParameters[10].Value = sModelNoEN;

                sqlParameters[11] = new SqlParameter("@sPriceTermsCN", SqlDbType.NVarChar);
                sqlParameters[11].Value = sPriceTermsCN;

                sqlParameters[12] = new SqlParameter("@sPriceTermsEN", SqlDbType.NVarChar);
                sqlParameters[12].Value = sPriceTermsEN;

                sqlParameters[13] = new SqlParameter("@sPaymentTermsCN", SqlDbType.NVarChar);
                sqlParameters[13].Value = sPaymentTermsCN;

                sqlParameters[14] = new SqlParameter("@sPaymentTermsEN", SqlDbType.NVarChar);
                sqlParameters[14].Value = sPaymentTermsEN;

                sqlParameters[15] = new SqlParameter("@sPackageCN", SqlDbType.NVarChar);
                sqlParameters[15].Value = sPackageCN;

                sqlParameters[16] = new SqlParameter("@sPackageEN", SqlDbType.NVarChar);
                sqlParameters[16].Value = sPackageEN;

                sqlParameters[17] = new SqlParameter("@sMinimumOrderCN", SqlDbType.NVarChar);
                sqlParameters[17].Value = sMinimumOrderCN;

                sqlParameters[18] = new SqlParameter("@sMinimumOrderEN", SqlDbType.NVarChar);
                sqlParameters[18].Value = sMinimumOrderEN;

                sqlParameters[19] = new SqlParameter("@sDeliveryTimeCN", SqlDbType.NVarChar);
                sqlParameters[19].Value = sDeliveryTimeCN;

                sqlParameters[20] = new SqlParameter("@sDeliveryTimeEN", SqlDbType.NVarChar);
                sqlParameters[20].Value = sDeliveryTimeEN;

                sqlParameters[21] = new SqlParameter("@sBrandNameCN", SqlDbType.NVarChar);
                sqlParameters[21].Value = sBrandNameCN;

                sqlParameters[22] = new SqlParameter("@sBrandNameEN", SqlDbType.NVarChar);
                sqlParameters[22].Value = sBrandNameEN;

                sqlParameters[23] = new SqlParameter("@sIntroCN", SqlDbType.NVarChar);
                sqlParameters[23].Value = sIntroCN;

                sqlParameters[24] = new SqlParameter("@sIntroEN", SqlDbType.NVarChar);
                sqlParameters[24].Value = sIntroEN;

                sqlParameters[25] = new SqlParameter("@sUpdatedBy", SqlDbType.NVarChar);
                sqlParameters[25].Value = psUpdatedBy;

                sqlParameters[26] = new SqlParameter("@dUpdatedTime", SqlDbType.DateTime);
                sqlParameters[26].Value = pdUpdatedTime;

                sqlParameters[27] = new SqlParameter("@bEnable", SqlDbType.Bit);
                sqlParameters[27].Value = pbEnable;

                sqlParameters[28] = new SqlParameter("@nSorting", SqlDbType.Int);
                sqlParameters[28].Value = pnSorting;

                sqlParameters[29] = new SqlParameter("@sThumbPath", SqlDbType.NVarChar);
                sqlParameters[29].Value = sThumbPath;
                DataSet ds = sqlhelper.SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "sp_update_tb_ProductBynProductID", sqlParameters);
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
