using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using WISLEY.BLL.Profile;
using WISLEY.BLL.User;

namespace WISLEY.DAL.Profile
{
    public class UserDAO
    {
        public int Insert(User user)
        {
            string DBConnect = ConfigurationManager.ConnectionStrings["ConnStr"].ConnectionString;
            SqlConnection myConn = new SqlConnection(DBConnect);
            string sqlStmt = "INSERT INTO [User] (email, name, password, salt, contactNo, gender, dob, wisPoints, accType, bio)" +
                             "VALUES (@paraEmail, @paraName, @paraPassword, @paraSalt, @paraContactNo, @paragender, @paraDob, @parapoints, @paraUserType, @paraBio)";

            int result = 0;    // Execute NonQuery return an integer value
            SqlCommand sqlCmd = new SqlCommand(sqlStmt, myConn);

            sqlCmd.Parameters.AddWithValue("@paraEmail", user.email);
            sqlCmd.Parameters.AddWithValue("@paraName", user.name);
            sqlCmd.Parameters.AddWithValue("@paraPassword", user.password);
            sqlCmd.Parameters.AddWithValue("@paraSalt", user.salt);
            sqlCmd.Parameters.AddWithValue("@paraContactNo", user.contactNo);
            sqlCmd.Parameters.AddWithValue("@paragender", user.gender);
            sqlCmd.Parameters.AddWithValue("@paraDob", user.dob);
            sqlCmd.Parameters.AddWithValue("@parapoints", user.points);
            sqlCmd.Parameters.AddWithValue("@paraUserType", user.userType);
            sqlCmd.Parameters.AddWithValue("@paraBio", user.bio);

            myConn.Open();
            result = sqlCmd.ExecuteNonQuery();

            myConn.Close();

            return result;
        }

        public User SelectByEmail(string email)
        {
            string DBConnect = ConfigurationManager.ConnectionStrings["ConnStr"].ConnectionString;
            SqlConnection myConn = new SqlConnection(DBConnect);

            string sqlstmt = "Select * from [User] where email = @paraEmail";
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
                string salt = row["salt"].ToString();
                string type = row["accType"].ToString();
                string name = row["name"].ToString();
                string dob = row["dob"].ToString();
                string contactNo = row["contactNo"].ToString();
                string gender = row["gender"].ToString();
                int points = int.Parse(row["wisPoints"].ToString());
                string bio = row["bio"].ToString();
                string src = row["profilesrc"].ToString();
                int id = int.Parse(row["Id"].ToString());


                obj = new User(email, password, salt, type, name, dob, contactNo, gender, points, bio, src, id);
            }

            return obj;
        }

        public User SelectById(string uid)
        {
            string DBConnect = ConfigurationManager.ConnectionStrings["ConnStr"].ConnectionString;
            SqlConnection myConn = new SqlConnection(DBConnect);

            string sqlstmt = "Select * from [User] where Id = @paraUid";
            SqlDataAdapter da = new SqlDataAdapter(sqlstmt, myConn);
            da.SelectCommand.Parameters.AddWithValue("@paraUid", uid);

            DataSet ds = new DataSet();
            da.Fill(ds);
            int rec_cnt = ds.Tables[0].Rows.Count;

            User obj = null;
            if (rec_cnt > 0)
            {
                DataRow row = ds.Tables[0].Rows[0];
                string email = row["email"].ToString();
                string password = row["password"].ToString();
                string salt = row["salt"].ToString();
                string type = row["accType"].ToString();
                string name = row["name"].ToString();
                string dob = row["dob"].ToString();
                string contactNo = row["contactNo"].ToString();
                string gender = row["gender"].ToString();
                int points = int.Parse(row["wisPoints"].ToString());
                string bio = row["bio"].ToString();
                string src = row["profilesrc"].ToString();
                int id = int.Parse(row["Id"].ToString());


                obj = new User(email, password, salt, type, name, dob, contactNo, gender, points, bio, src, id);
            }

            return obj;
        }

        public int UpdateUser(string email, string name, string dob, string contactNo)
        {
            string DBConnect = ConfigurationManager.ConnectionStrings["ConnStr"].ConnectionString;
            SqlConnection myConn = new SqlConnection(DBConnect);

            string sqlStmt = "UPDATE [User] " +
                "SET name = @paraName, dob = @paraDob, contactNo = @paraContactNo " +
                "WHERE email = @paraEmail";

            int result = 0;    // Execute NonQuery return an integer value
            SqlCommand sqlCmd = new SqlCommand(sqlStmt, myConn);

            sqlCmd.Parameters.AddWithValue("@paraName", name);
            sqlCmd.Parameters.AddWithValue("@paraDob", dob);
            sqlCmd.Parameters.AddWithValue("@paraContactNo", contactNo);
            sqlCmd.Parameters.AddWithValue("@paraEmail", email);

            myConn.Open();
            result = sqlCmd.ExecuteNonQuery();

            myConn.Close();

            return result;
        }

        public int UpdatePassword(string email, string password)
        {
            string DBConnect = ConfigurationManager.ConnectionStrings["ConnStr"].ConnectionString;
            SqlConnection myConn = new SqlConnection(DBConnect);

            string sqlStmt = "UPDATE [User] " +
                "SET password = @paraPassword " +
                "WHERE email = @paraEmail";

            int result = 0;    // Execute NonQuery return an integer value
            SqlCommand sqlCmd = new SqlCommand(sqlStmt, myConn);

            sqlCmd.Parameters.AddWithValue("@paraEmail", email);
            sqlCmd.Parameters.AddWithValue("@paraPassword", password);

            myConn.Open();
            result = sqlCmd.ExecuteNonQuery();

            myConn.Close();

            return result;
        }

        public int UpdateBio(string email, string bio)
        {
            string DBConnect = ConfigurationManager.ConnectionStrings["ConnStr"].ConnectionString;
            SqlConnection myConn = new SqlConnection(DBConnect);

            string sqlStmt = "UPDATE [User] " +
                "SET bio = @paraBio " +
                "WHERE email = @paraEmail";

            int result = 0;    // Execute NonQuery return an integer value
            SqlCommand sqlCmd = new SqlCommand(sqlStmt, myConn);

            sqlCmd.Parameters.AddWithValue("@paraEmail", email);
            sqlCmd.Parameters.AddWithValue("@paraBio", bio);

            myConn.Open();
            result = sqlCmd.ExecuteNonQuery();

            myConn.Close();

            return result;
        }

        public int UpdateProfilePic(int id, string src)
        {
            string DBConnect = ConfigurationManager.ConnectionStrings["ConnStr"].ConnectionString;
            SqlConnection myConn = new SqlConnection(DBConnect);

            string sqlStmt = "UPDATE [User] " +
                "SET profilesrc = @paraSrc " +
                "WHERE Id = @paraId";

            int result = 0;    // Execute NonQuery return an integer value
            SqlCommand sqlCmd = new SqlCommand(sqlStmt, myConn);

            sqlCmd.Parameters.AddWithValue("@paraSrc", src);
            sqlCmd.Parameters.AddWithValue("@paraId", id);

            myConn.Open();
            result = sqlCmd.ExecuteNonQuery();

            myConn.Close();

            return result;
        }

        public int UpdateWISPoints(int id, int points)
        {
            string DBConnect = ConfigurationManager.ConnectionStrings["ConnStr"].ConnectionString;
            SqlConnection myConn = new SqlConnection(DBConnect);

            string sqlStmt = "UPDATE [User] " +
                "SET wisPoints = @paraPoints " +
                "WHERE Id = @paraId";

            int result = 0;    // Execute NonQuery return an integer value
            SqlCommand sqlCmd = new SqlCommand(sqlStmt, myConn);

            sqlCmd.Parameters.AddWithValue("@paraPoints", points);
            sqlCmd.Parameters.AddWithValue("@paraId", id);

            myConn.Open();
            result = sqlCmd.ExecuteNonQuery();

            myConn.Close();

            return result;
        }

        public int GetLastID()
        {
            string DBConnect = ConfigurationManager.ConnectionStrings["ConnStr"].ConnectionString;
            SqlConnection myConn = new SqlConnection(DBConnect);

            string sqlstmt = "Select MAX(Id) as LastID from [User]";
            SqlDataAdapter da = new SqlDataAdapter(sqlstmt, myConn);

            DataSet ds = new DataSet();
            da.Fill(ds);
            int rec_cnt = ds.Tables[0].Rows.Count;
            int lastID = 1;

            if (rec_cnt > 0)
            {
                DataRow row = ds.Tables[0].Rows[0];

                lastID = int.Parse(row["LastID"].ToString());

            }

            return lastID;
        }
    }
}