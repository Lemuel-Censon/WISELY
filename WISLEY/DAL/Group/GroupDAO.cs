using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;


namespace WISLEY.DAL.Group
{
    public class GroupDAO
    {
        public int Insert(BLL.Group.Group group)
        {
           
            string DBConnect = ConfigurationManager.ConnectionStrings["ConnStr"].ConnectionString;
            SqlConnection myConn = new SqlConnection(DBConnect);

            string sqlStmt = "INSERT INTO [Group] (name, description, weightage)" +
                 "VALUES (@paraName, @paraDescription, @paraWeightage)";

            int result = 0;    // Execute NonQuery return an integer value
            SqlCommand sqlCmd = new SqlCommand(sqlStmt, myConn);

            sqlCmd.Parameters.AddWithValue("@paraName", group.name);
            sqlCmd.Parameters.AddWithValue("@paraDescription", group.description);
            sqlCmd.Parameters.AddWithValue("@paraWeightage", group.weightage);

            myConn.Open();
            result = sqlCmd.ExecuteNonQuery();

            myConn.Close();

            return result;
        }

    }
}