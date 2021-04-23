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
    public class CourseDAL
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


        public DataSet SectionByBathIdDDLLoadDAL(int BatchId)
        {
            SqlCommand com = new SqlCommand("sp_SectionByBatchIdDDLLoad", conn);


            com.CommandType = CommandType.StoredProcedure;
            com.Parameters.AddWithValue("@BatchId", BatchId);
            SqlDataAdapter da = new SqlDataAdapter(com);
            DataSet dss = new DataSet();
            da.Fill(dss);
            return dss;
        }


        public void AddNewInfoDAL(CourseDAO aDao)
        {
            SqlCommand com = new SqlCommand("sp_Insert_Course", conn);
            com.CommandType = CommandType.StoredProcedure;
            com.Parameters.AddWithValue("@CourseName", aDao.CourseName);
            com.Parameters.AddWithValue("@BatchId", aDao.BatchId);
            com.Parameters.AddWithValue("@SectionId", aDao.SectionId);
            conn.Open();
            com.ExecuteNonQuery();
            conn.Close();
        }


        public DataSet LoadAllDataDAL()
        {
            SqlCommand com = new SqlCommand("sp_LoadAllData_Course", conn);
            com.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter da = new SqlDataAdapter(com);
            DataSet dss = new DataSet();
            da.Fill(dss);
            return dss;
        }


        public void DeleteInfoDAL(int CourseId)
        {
            SqlCommand com = new SqlCommand("Delete_CourseByMasterId", conn);
            com.CommandType = CommandType.StoredProcedure;
            com.Parameters.AddWithValue("@CourseId", CourseId);

            conn.Open();
            com.ExecuteNonQuery();
            conn.Close();
        }


        public DataSet LoadDataByMasterIDDAL(int CourseId)
        {
            SqlCommand com = new SqlCommand("Get_CourseMaterDataById", conn);
            com.CommandType = CommandType.StoredProcedure;
            com.Parameters.AddWithValue("@CourseId", CourseId);
            SqlDataAdapter da = new SqlDataAdapter(com);
            DataSet dss = new DataSet();
            da.Fill(dss);
            return dss;
        }


        public void UpdateInfoDAL(CourseDAO aDao)
        {
            SqlCommand com = new SqlCommand("Update_CourseByMasterId", conn);
            com.CommandType = CommandType.StoredProcedure;
            com.Parameters.AddWithValue("@CourseId", aDao.CourseId);
            com.Parameters.AddWithValue("@CourseName", aDao.CourseName);
            com.Parameters.AddWithValue("@BatchId", aDao.BatchId);
            com.Parameters.AddWithValue("@SectionId", aDao.SectionId);
            conn.Open();
            com.ExecuteNonQuery();
            conn.Close();
        }


    }
}