using AbcTutorial_SMS.DAO;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace AbcTutorial_SMS.DAL
{
    public class UserDAL
    {

        SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["MyConStr"].ConnectionString);

        public DataTable LoadAllDataDAL(UserDAO dao)
        {
            SqlCommand com = new SqlCommand("sp_LoginInfo", conn);
            com.CommandType = CommandType.StoredProcedure;
            com.Parameters.AddWithValue("@LoginName", dao.LoginName);
            com.Parameters.AddWithValue("@Password", dao.Password);
            SqlDataAdapter da = new SqlDataAdapter(com);
            DataTable dss = new DataTable();
            da.Fill(dss);
            return dss;
        }


    }
}