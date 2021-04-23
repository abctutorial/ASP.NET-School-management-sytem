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
    public class StudentDAL
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


        public DataSet GetStudentIdNODAL()
        {
            SqlCommand com = new SqlCommand("sp_GetStudentIDNo", conn);
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


        public void AddNewInfoDAL(StudentDAO aDao)
        {
            SqlCommand com = new SqlCommand("sp_Insert_Student", conn);
            com.CommandType = CommandType.StoredProcedure;

            com.Parameters.AddWithValue("@StudentName", aDao.StudentName);
            com.Parameters.AddWithValue("@BatchId", aDao.BatchId);
            com.Parameters.AddWithValue("@SectionId", aDao.SectionId);
            com.Parameters.AddWithValue("@DOB", aDao.DOB);
            com.Parameters.AddWithValue("@Gender", aDao.Gender);
            com.Parameters.AddWithValue("@Religion", aDao.Religion);
            com.Parameters.AddWithValue("@FatherName", aDao.FatherName);
            com.Parameters.AddWithValue("@MotherName", aDao.MotherName);
            com.Parameters.AddWithValue("@PresentAddrees", aDao.PresentAddrees);



            com.Parameters.AddWithValue("@PermanentAddress", aDao.PermanentAddress);
            com.Parameters.AddWithValue("@AddmittedDate", aDao.AddmittedDate);
            com.Parameters.AddWithValue("@Status", aDao.Status);
             

            conn.Open();
            com.ExecuteNonQuery();
            conn.Close();
        }


        public DataSet LoadAllDataDAL(int BatchId)
        {
            SqlCommand com = new SqlCommand("sp_LoadAllData_Student", conn);
            com.CommandType = CommandType.StoredProcedure;

            com.Parameters.AddWithValue("@BatchId", BatchId);
            SqlDataAdapter da = new SqlDataAdapter(com);
            DataSet dss = new DataSet();
            da.Fill(dss);
            return dss;
        }


        public void DeleteInfoDAL(int StudentId)
        {
            SqlCommand com = new SqlCommand("Inactive_Student_ByMasterId", conn);
            com.CommandType = CommandType.StoredProcedure;
            com.Parameters.AddWithValue("@StudentId", StudentId);

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