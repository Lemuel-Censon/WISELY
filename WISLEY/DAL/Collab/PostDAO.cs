using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using WISLEY.BLL.Collab;

namespace WISLEY.DAL.Collab
{
    public class PostDAO
    {
        public int Insert(Post post)
        {
            string DBConnect = ConfigurationManager.ConnectionStrings["ConnStr"].ConnectionString;
            SqlConnection myConn = new SqlConnection(DBConnect);

            string sqlStmt = "INSERT INTO Post (userId, groupId, title, content, datecreated, status)" +
                             "VALUES (@paraUserID, @paraGroupID, @paraTitle, @paraContent, @paraDatecreate, @paraStatus)";

            int result = 0;    // Execute NonQuery return an integer value
            SqlCommand sqlCmd = new SqlCommand(sqlStmt, myConn);

            sqlCmd.Parameters.AddWithValue("@paraUserID", post.userId);
            sqlCmd.Parameters.AddWithValue("@paraGroupID", post.groupId);
            sqlCmd.Parameters.AddWithValue("@paraTitle", post.title);
            sqlCmd.Parameters.AddWithValue("@paraContent", post.content);
            sqlCmd.Parameters.AddWithValue("@paraDatecreate", post.datecreated);
            sqlCmd.Parameters.AddWithValue("@paraStatus", post.status);

            myConn.Open();
            result = sqlCmd.ExecuteNonQuery();

            myConn.Close();

            return result;
        }

        public List<Post> SelectByID(string postId)
        {
            string DBConnect = ConfigurationManager.ConnectionStrings["ConnStr"].ConnectionString;
            SqlConnection myConn = new SqlConnection(DBConnect);

            string sqlstmt = "SELECT post.*, [User].name FROM POST " +
                    "INNER JOIN [User] ON post.userId = [User].Id " +
                    "WHERE post.Id = @parapostId";
            SqlDataAdapter da = new SqlDataAdapter(sqlstmt, myConn);
            da.SelectCommand.Parameters.AddWithValue("@parapostId", postId);

            DataSet ds = new DataSet();
            da.Fill(ds);
            int rec_cnt = ds.Tables[0].Rows.Count;

            Post obj = null;
            List<Post> post = new List<Post>();
            if (rec_cnt > 0)
            {
                DataRow row = ds.Tables[0].Rows[0];
                string userId = row["userId"].ToString();
                string title = row["title"].ToString();
                string content = row["content"].ToString();
                string group = row["groupId"].ToString();
                string datecreated = row["datecreated"].ToString();
                string username = row["name"].ToString();
                int Id = int.Parse(row["Id"].ToString());
                obj = new Post(title, content, userId, group, datecreated, Id, username);
                post.Add(obj);
            }

            return post;
        }

        public List<Post> SelectByGroup(string groupId)
        {
            string DBConnect = ConfigurationManager.ConnectionStrings["ConnStr"].ConnectionString;
            SqlConnection myConn = new SqlConnection(DBConnect);

            string sqlstmt = "SELECT post.*, [User].name as username, [Group].name as grpname FROM ((post " +
                        "INNER JOIN [User] ON post.userId = [User].Id) " +
                        "INNER JOIN [Group] ON post.groupId = [Group].Id) " +
                        "WHERE post.groupId = @paraGrpId " +
                        "AND post.status = '' ORDER BY Id DESC";
            SqlDataAdapter da = new SqlDataAdapter(sqlstmt, myConn);
            da.SelectCommand.Parameters.AddWithValue("@paraGrpId", groupId);

            DataSet ds = new DataSet();
            da.Fill(ds);
            int rec_cnt = ds.Tables[0].Rows.Count;

            Post obj = null;
            List<Post> grppostlist = new List<Post>();
            if (rec_cnt > 0)
            {
                for (int i = 0; i < rec_cnt; i++)
                {
                    DataRow row = ds.Tables[0].Rows[i];
                    string userId = row["userId"].ToString();
                    string title = row["title"].ToString();
                    string content = row["content"].ToString();
                    string datecreated = row["datecreated"].ToString();
                    string username = row["username"].ToString();
                    int Id = int.Parse(row["Id"].ToString());
                    obj = new Post(title, content, userId, groupId, datecreated, Id, username);
                    grppostlist.Add(obj);
                }
            }

            return grppostlist;
        }

        public List<Post> SelectByUser(string userId)
        {
            string DBConnect = ConfigurationManager.ConnectionStrings["ConnStr"].ConnectionString;
            SqlConnection myConn = new SqlConnection(DBConnect);

            string sqlstmt = "Select * from Post where userId = @paraUserId ORDER BY Id DESC";
            SqlDataAdapter da = new SqlDataAdapter(sqlstmt, myConn);
            da.SelectCommand.Parameters.AddWithValue("@paraUserId", userId);

            DataSet ds = new DataSet();
            da.Fill(ds);
            int rec_cnt = ds.Tables[0].Rows.Count;

            Post obj = null;
            List<Post> userpostlist = new List<Post>();
            if (rec_cnt > 0)
            {
                for (int i = 0; i < rec_cnt; i++)
                {
                    DataRow row = ds.Tables[0].Rows[i];
                    string title = row["title"].ToString();
                    string content = row["content"].ToString();
                    string group = row["groupId"].ToString();
                    string datecreated = row["datecreated"].ToString();
                    obj = new Post(title, content, userId, group, datecreated);
                    userpostlist.Add(obj);
                }
            }

            return userpostlist;
        }

        public List<Post> SelectByEmail(string email)
        {
            string DBConnect = ConfigurationManager.ConnectionStrings["ConnStr"].ConnectionString;
            SqlConnection myConn = new SqlConnection(DBConnect);

            string sqlstmt = "SELECT post.*, [User].name as username, [Group].name as grpname FROM ((POST " +
                        "INNER JOIN [User] ON post.userId = [User].Id) " +
                        "INNER JOIN [Group] ON post.groupId = [Group].Id) " +
                        "WHERE userId in " +
                        "(Select Id from [User] where email = @paraEmail) " +
                        "AND post.status = '' ORDER BY Id DESC";
            SqlDataAdapter da = new SqlDataAdapter(sqlstmt, myConn);
            da.SelectCommand.Parameters.AddWithValue("@paraEmail", email);

            DataSet ds = new DataSet();
            da.Fill(ds);
            int rec_cnt = ds.Tables[0].Rows.Count;

            Post obj = null;
            List<Post> userpostlist = new List<Post>();
            if (rec_cnt > 0)
            {
                for (int i = 0; i < rec_cnt; i++)
                {
                    DataRow row = ds.Tables[0].Rows[i];
                    string userId = row["userId"].ToString();
                    string title = row["title"].ToString();
                    string content = row["content"].ToString();
                    string group = row["groupId"].ToString();
                    string datecreated = row["datecreated"].ToString();
                    string username = row["username"].ToString();
                    int Id = int.Parse(row["Id"].ToString());
                    obj = new Post(title, content, userId, group, datecreated, Id, username);
                    userpostlist.Add(obj);
                }
            }

            return userpostlist;
        }

        public int UpdatePost(string postId, string title, string content, string datecreate)
        {
            string DBConnect = ConfigurationManager.ConnectionStrings["ConnStr"].ConnectionString;
            SqlConnection myConn = new SqlConnection(DBConnect);

            string sqlStmt = "UPDATE Post " +
                "SET title = @paraTitle, content = @paraContent, datecreated = @paraDatecreate " +
                "WHERE Id = @paraPostID";

            int result = 0;    // Execute NonQuery return an integer value
            SqlCommand sqlCmd = new SqlCommand(sqlStmt, myConn);

            sqlCmd.Parameters.AddWithValue("@paraPostID", postId);
            sqlCmd.Parameters.AddWithValue("@paraTitle", title);
            sqlCmd.Parameters.AddWithValue("@paraContent", content);
            sqlCmd.Parameters.AddWithValue("@paraDatecreate", datecreate);

            myConn.Open();
            result = sqlCmd.ExecuteNonQuery();

            myConn.Close();

            return result;

        }

        public int DelPostUpdate(string postId, string status)
        {
            string DBConnect = ConfigurationManager.ConnectionStrings["ConnStr"].ConnectionString;
            SqlConnection myConn = new SqlConnection(DBConnect);

            string sqlStmt = "UPDATE Post " +
                "SET status = @paraStats " +
                "WHERE Id = @paraPostID";

            int result = 0;    // Execute NonQuery return an integer value
            SqlCommand sqlCmd = new SqlCommand(sqlStmt, myConn);

            sqlCmd.Parameters.AddWithValue("@paraStats", status);
            sqlCmd.Parameters.AddWithValue("@paraPostID", postId);

            myConn.Open();
            result = sqlCmd.ExecuteNonQuery();

            myConn.Close();

            return result;
        }
    }
}