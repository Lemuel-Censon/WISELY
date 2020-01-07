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

            string sqlStmt = "INSERT INTO User (userId, groupId, email, name, password, gender, dob, department, experience, wisPoints, accType)" +
                             "VALUES (@paraUserID, @paraGroupID, @paraEmail, @paraName, @paraPassword, @paraGender, @paraDob, @paraDepartment, @paraExperience, @paraWisPoints, @paraAccType)";

            int result = 0;    // Execute NonQuery return an integer value
            SqlCommand sqlCmd = new SqlCommand(sqlStmt, myConn);

            sqlCmd.Parameters.AddWithValue("@paraUserID", user.userId);
            sqlCmd.Parameters.AddWithValue("@paraGroupID", user.groupId);
            sqlCmd.Parameters.AddWithValue("@paraEmail", user.email);
            sqlCmd.Parameters.AddWithValue("@paraName", user.name);
            sqlCmd.Parameters.AddWithValue("@paraPassword", user.password);
            sqlCmd.Parameters.AddWithValue("@paraGender", user.gender);
            sqlCmd.Parameters.AddWithValue("@paraDob", user.dob);
            sqlCmd.Parameters.AddWithValue("@paraDepartment", user.department);
            sqlCmd.Parameters.AddWithValue("@paraExperience", user.experience);
            sqlCmd.Parameters.AddWithValue("@paraWisPoints", user.wisPoints);
            sqlCmd.Parameters.AddWithValue("@paraAccType", user.accType);

            myConn.Open();
            result = sqlCmd.ExecuteNonQuery();

            myConn.Close();

            return result;
        }

        public User SelectByID(string userID)
        {
            string DBConnect = ConfigurationManager.ConnectionStrings["ConnStr"].ConnectionString;
            SqlConnection myConn = new SqlConnection(DBConnect);

            string sqlstmt = "Select * from User where Id = @parauserId";
            SqlDataAdapter da = new SqlDataAdapter(sqlstmt, myConn);
            da.SelectCommand.Parameters.AddWithValue("@parauserId", userID);

            DataSet ds = new DataSet();
            da.Fill(ds);
            int rec_cnt = ds.Tables[0].Rows.Count;

            User obj = null;
            if (rec_cnt > 0)
            {
                DataRow row = ds.Tables[0].Rows[0];
                string userId = row["userId"].ToString();
                string groupId = row["groupId"].ToString();
                string email = row["email"].ToString();
                string name = row["name"].ToString();
                string password = row["password"].ToString();
                string gender = row["gender"].ToString();
                string dob = row["dob"].ToString();
                string department = row["department"].ToString();
                string experience = row["experience"].ToString();
                string wisPoints = row["wisPoints"].ToString();
                string accType = row["accType"].ToString();
                obj = new User(userId, groupId, email, name, password, gender, dob, department, experience, wisPoints, accType);
            }

            return obj;
        }

    }
}