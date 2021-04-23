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
    public class SectionDAL
    {

        SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["MyConStr"].ConnectionString);


        public DataSet BatchDDLLoadDAL()
        {
            SqlCommand com = new SqlCommand("sp_BatchDDLLoad", conn);
            com.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter da = new SqlDataAdapter(com);
            DataSet dss = new DataSet();
            da.Fill(dss);
            return dss;
        }



        public void AddNewInfoDAL(SectionDAO aDao)
        {
            SqlCommand com = new SqlCommand("sp_Insert_Section", conn);
            com.CommandType = CommandType.StoredProcedure;
            com.Parameters.AddWithValue("@SectionName", aDao.SectionName);
            com.Parameters.AddWithValue("@BatchId", aDao.BatchId);
            conn.Open();
            com.ExecuteNonQuery();
            conn.Close();
        }


        public DataSet LoadAllDataDAL()
        {
            SqlCommand com = new SqlCommand("sp_LoadAllData_Section", conn);
            com.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter da = new SqlDataAdapter(com);
            DataSet dss = new DataSet();
            da.Fill(dss);
            return dss;
        }


        public DataSet LoadDataByMasterIDDAL(int MasterId)
        {
            SqlCommand com = new SqlCommand("Get_SectionMaterDataById", conn);
            com.CommandType = CommandType.StoredProcedure;
            com.Parameters.AddWithValue("@MasterId", MasterId);
            SqlDataAdapter da = new SqlDataAdapter(com);
            DataSet dss = new DataSet();
            da.Fill(dss);
            return dss;
        }

        public void UpdateInfoDAL(SectionDAO aDao)
        {
            SqlCommand com = new SqlCommand("Update_SectionByMasterId", conn);
            com.CommandType = CommandType.StoredProcedure;
            com.Parameters.AddWithValue("@SectionId", aDao.SectionId);
            com.Parameters.AddWithValue("@SectionName", aDao.SectionName);
            com.Parameters.AddWithValue("@BatchId", aDao.BatchId);
            conn.Open();
            com.ExecuteNonQuery();
            conn.Close();
        }

        public void DeleteInfoDAL(int SectionId)
        {
            SqlCommand com = new SqlCommand("Delete_SectionByMasterId", conn);
            com.CommandType = CommandType.StoredProcedure;
            com.Parameters.AddWithValue("@SectionId", SectionId);

            conn.Open();
            com.ExecuteNonQuery();
            conn.Close();
        }
    }
}