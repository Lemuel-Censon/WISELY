using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
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

            string sqlStmt = "INSERT INTO User (email, name, password, contactNo, dob, gender, experience, wisPoints, accType)" +
                             "VALUES (@paraEmail, @paraName, @paraPassword, @paraContactNo, @paraDob, @paragender, @paraexp, @parapoints, @paraUserType)";

            int result = 0;    // Execute NonQuery return an integer value
            SqlCommand sqlCmd = new SqlCommand(sqlStmt, myConn);

            sqlCmd.Parameters.AddWithValue("@paraEmail", user.email);
            sqlCmd.Parameters.AddWithValue("@paraPassword", user.password);
            sqlCmd.Parameters.AddWithValue("@paraUserType", user.userType);
            sqlCmd.Parameters.AddWithValue("@paraName", user.name);
            sqlCmd.Parameters.AddWithValue("@paraDob", user.dob);
            sqlCmd.Parameters.AddWithValue("@paragender", user.gender);
            sqlCmd.Parameters.AddWithValue("@paraexp", user.experience);
            sqlCmd.Parameters.AddWithValue("@parapoints", user.points);
            sqlCmd.Parameters.AddWithValue("@paraContactNo", user.contactNo);

            myConn.Open();
            result = sqlCmd.ExecuteNonQuery();

            myConn.Close();

            return result;
        }

        public User SelectByEmail(string email)
        {
            string DBConnect = ConfigurationManager.ConnectionStrings["ConnStr"].ConnectionString;
            SqlConnection myConn = new SqlConnection(DBConnect);

            string sqlstmt = "Select * from User where email = @paraEmail";
            SqlDataAdapter da = new SqlDataAdapter(sqlstmt, myConn);
            da.SelectCommand.Parameters.AddWithValue("@paraEmail", email);

            DataSet ds = new DataSet();
            da.Fill(ds);
            int rec_cnt = ds.Tables[0].Rows.Count;

            User obj = null;
            if (rec_cnt > 0)
            {
                DataRow row = ds.Tables[0].Rows[0];
                string password = row["password"].ToString();
                string type = row["accType"].ToString();
                string name = row["name"].ToString();
                string dob = row["dob"].ToString();
                string contactNo = row["contactNo"].ToString();
                string gender = row["gender"].ToString();
                int exp = int.Parse(row["experience"].ToString());
                int points = int.Parse(row["wisPoints"].ToString());
                obj = new User(email, password, type, name, dob, contactNo, gender, exp, points);
            }

            return obj;
        }
    }
}