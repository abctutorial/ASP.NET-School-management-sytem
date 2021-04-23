using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using AbcTutorial_SMS.DAO;

namespace AbcTutorial_SMS.DAL
{
    public class BatchDAL
    {
        SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["MyConStr"].ConnectionString);

        public void AddNewInfoDAL(BatchDAO aDao)
        {
            SqlCommand com = new SqlCommand("sp_Insert_Batch",conn);
            com.CommandType = CommandType.StoredProcedure;
            com.Parameters.AddWithValue("@BatchName", aDao.BatchName);
            conn.Open();
            com.ExecuteNonQuery();
            conn.Close();
        }


          public void UpdateInfoDAL(BatchDAO aDao)
        {
            SqlCommand com = new SqlCommand("Update_BatchByMasterId", conn);
            com.CommandType = CommandType.StoredProcedure;
            com.Parameters.AddWithValue("@BatchId", aDao.BatchId);
            com.Parameters.AddWithValue("@BatchName", aDao.BatchName);
            conn.Open();
            com.ExecuteNonQuery();
            conn.Close();
        }
        public DataSet get_recordbyid(int id)
        {
            SqlCommand com = new SqlCommand("Sp_register_byid", conn);
            com.CommandType = CommandType.StoredProcedure;
            com.Parameters.AddWithValue("@Sr_no", id);
            SqlDataAdapter da = new SqlDataAdapter(com);
            DataSet ds = new DataSet();
            da.Fill(ds);
            return ds;
        }

        public DataSet LoadAllDataDAL()
        {
            SqlCommand com = new SqlCommand("sp_LoadAllData_Batch", conn);
            com.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter da = new SqlDataAdapter(com);
            DataSet dss= new DataSet();
            da.Fill(dss);
            return dss;
        }


        public DataSet LoadDataByMasterIDDAL(int MasterId)
        {
            SqlCommand com = new SqlCommand("Get_BatchMaterDataById", conn);
            com.CommandType = CommandType.StoredProcedure;
            com.Parameters.AddWithValue("@MasterId", MasterId);
            SqlDataAdapter da = new SqlDataAdapter(com);
            DataSet dss = new DataSet();
            da.Fill(dss);
            return dss;
        }


        public void DeleteInfoDAL(int BatchId)
        {
            SqlCommand com = new SqlCommand("Delete_BatchByMasterId", conn);
            com.CommandType = CommandType.StoredProcedure;
            com.Parameters.AddWithValue("@BatchId", BatchId);
          
            conn.Open();
            com.ExecuteNonQuery();
            conn.Close();
        }
      
    }
}