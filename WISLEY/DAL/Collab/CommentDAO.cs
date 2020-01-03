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
    public class CommentDAO
    {
        public int Insert(Comment comment)
        {
            string DBConnect = ConfigurationManager.ConnectionStrings["ConnStr"].ConnectionString;
            SqlConnection myConn = new SqlConnection(DBConnect);

            string sqlStmt = "INSERT INTO Comment (postId, userId, content, datecreated)" +
                             "VALUES (@paraPostID, @paraUserID, @paraContent, @paraDatecreate)";

            int result = 0;    // Execute NonQuery return an integer value
            SqlCommand sqlCmd = new SqlCommand(sqlStmt, myConn);

            sqlCmd.Parameters.AddWithValue("@paraPostID", comment.postid);
            sqlCmd.Parameters.AddWithValue("@paraUserID", comment.userid);
            sqlCmd.Parameters.AddWithValue("@paraContent", comment.content);
            sqlCmd.Parameters.AddWithValue("@paraDatecreate", comment.datecreated);

            myConn.Open();
            result = sqlCmd.ExecuteNonQuery();

            myConn.Close();

            return result;
        }

        public List<Comment> SelectAll()
        {
            string DBConnect = ConfigurationManager.ConnectionStrings["ConnStr"].ConnectionString;
            SqlConnection myConn = new SqlConnection(DBConnect);

            string sqlstmt = "Select * from Comment ORDER BY datecreated DESC";
            SqlDataAdapter da = new SqlDataAdapter(sqlstmt, myConn);

            DataSet ds = new DataSet();
            da.Fill(ds);
            int rec_cnt = ds.Tables[0].Rows.Count;

            Comment obj = null;
            List<Comment> commlist = new List<Comment>();
            if (rec_cnt > 0)
            {
                for (int i = 0; i < rec_cnt; i++)
                {
                    DataRow row = ds.Tables[0].Rows[i];
                    string postId = row["postId"].ToString();
                    string userId = row["userId"].ToString();
                    string content = row["content"].ToString();
                    string datecreated = row["datecreated"].ToString();
                    obj = new Comment(postId, userId, content, datecreated);
                    commlist.Add(obj);
                }
            }
            return commlist;
        }

        public List<Comment> SelectByPost(string postId)
        {
            string DBConnect = ConfigurationManager.ConnectionStrings["ConnStr"].ConnectionString;
            SqlConnection myConn = new SqlConnection(DBConnect);

            string sqlstmt = "Select * from Comment where postId = @paraPostId ORDER BY datecreated DESC";
            SqlDataAdapter da = new SqlDataAdapter(sqlstmt, myConn);
            da.SelectCommand.Parameters.AddWithValue("@paraPostId", postId);

            DataSet ds = new DataSet();
            da.Fill(ds);
            int rec_cnt = ds.Tables[0].Rows.Count;

            Comment obj = null;
            List<Comment> commpostlist = new List<Comment>();
            if (rec_cnt > 0)
            {
                for (int i = 0; i < rec_cnt; i++)
                {
                    DataRow row = ds.Tables[0].Rows[i];
                    string userId = row["userId"].ToString();
                    string content = row["content"].ToString();
                    string datecreated = row["datecreated"].ToString();
                    obj = new Comment(postId, userId, content, datecreated);
                    commpostlist.Add(obj);
                }
            }

            return commpostlist;
        }

        public int UpdateComment(string commId, string content, string datecreate)
        {
            string DBConnect = ConfigurationManager.ConnectionStrings["ConnStr"].ConnectionString;
            SqlConnection myConn = new SqlConnection(DBConnect);

            string sqlStmt = "UPDATE Comment " +
                "SET content = @paraContent, datecreated = @paraDatecreate " +
                "WHERE Id = @paracommID";

            int result = 0;    // Execute NonQuery return an integer value
            SqlCommand sqlCmd = new SqlCommand(sqlStmt, myConn);

            sqlCmd.Parameters.AddWithValue("@paracommID", commId);
            sqlCmd.Parameters.AddWithValue("@paraContent", content);
            sqlCmd.Parameters.AddWithValue("@paraDatecreate", datecreate);

            myConn.Open();
            result = sqlCmd.ExecuteNonQuery();

            myConn.Close();

            return result;

        }
    }
}