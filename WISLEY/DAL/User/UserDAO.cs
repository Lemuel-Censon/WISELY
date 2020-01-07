using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using WISLEY.BLL.Profile;

namespace WISLEY.DAL.Profile
{
    public class UserDAO
    {
        public int Insert(User user)
        {
            string DBConnect = ConfigurationManager.ConnectionStrings["ConnStr"].ConnectionString;
            SqlConnection myConn = new SqlConnection(DBConnect);

            string sqlStmt = "INSERT INTO User (userId, email, password, userType, fName, lName, dob, contactNo, location)" +
                             "VALUES (@paraUserID, @paraEmail, @paraPassword, @paraUserType, @paraFName, @paraLName, @paraDob, @paraContactNo, @paraLocation)";

            int result = 0;    // Execute NonQuery return an integer value
            SqlCommand sqlCmd = new SqlCommand(sqlStmt, myConn);

            sqlCmd.Parameters.AddWithValue("@paraUserID", user.userId);
            sqlCmd.Parameters.AddWithValue("@paraEmail", user.email);
            sqlCmd.Parameters.AddWithValue("@paraPassword", user.password);
            sqlCmd.Parameters.AddWithValue("@paraUserType", user.userType);
            sqlCmd.Parameters.AddWithValue("@paraFName", user.fName);
            sqlCmd.Parameters.AddWithValue("@paraLName", user.lName);
            sqlCmd.Parameters.AddWithValue("@paraDob", user.dob);
            sqlCmd.Parameters.AddWithValue("@paraContactNo", user.contactNo);
            sqlCmd.Parameters.AddWithValue("@paraLocation", user.location);

            myConn.Open();
            result = sqlCmd.ExecuteNonQuery();

            myConn.Close();

            return result;
        }
    }
}