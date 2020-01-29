using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using WISLEY.BLL.Quiz;

namespace WISLEY.DAL.Quiztool
{
    public class QuizDAO
    {
        public int Insert(Quiz quiz)
        {
            string DBConnect = ConfigurationManager.ConnectionStrings["ConnStr"].ConnectionString;
            SqlConnection myConn = new SqlConnection(DBConnect);
            string sqlStmt = "INSERT INTO Quiz (title, description, datecreated, userId, quizId)" +
                             "VALUES (@paraTitle, @paraDescription, @paraDatecreate, @paraUserID, @paraQuizID)";

            int result = 0;    // Execute NonQuery return an integer value
            SqlCommand sqlCmd = new SqlCommand(sqlStmt, myConn);

            sqlCmd.Parameters.AddWithValue("@paraTitle", quiz.title);
            sqlCmd.Parameters.AddWithValue("@paraDescription", quiz.description);
            sqlCmd.Parameters.AddWithValue("@paraDatecreate", quiz.datecreated);
            sqlCmd.Parameters.AddWithValue("@paraUserID", quiz.userId);
            sqlCmd.Parameters.AddWithValue("@paraQuizID", quiz.quizId);

            myConn.Open();
            result = sqlCmd.ExecuteNonQuery();

            myConn.Close();

            return result;
        }

        public int SelectCountById(string userId)
        {
            string DBConnect = ConfigurationManager.ConnectionStrings["ConnStr"].ConnectionString;
            SqlConnection myConn = new SqlConnection(DBConnect);

            string sqlstmt = "Select * from Quiz where userId = @paraUid";
            SqlDataAdapter da = new SqlDataAdapter(sqlstmt, myConn);
            da.SelectCommand.Parameters.AddWithValue("@paraUid", userId);

            DataSet ds = new DataSet();
            da.Fill(ds);
            int rec_cnt = ds.Tables[0].Rows.Count;
            return rec_cnt;
        }

        public Quiz SelectById(string quizId)
        {
            string DBConnect = ConfigurationManager.ConnectionStrings["ConnStr"].ConnectionString;
            SqlConnection myConn = new SqlConnection(DBConnect);

            string sqlstmt = "Select * from Quiz where quizId = @paraQuizID";
            SqlDataAdapter da = new SqlDataAdapter(sqlstmt, myConn);
            da.SelectCommand.Parameters.AddWithValue("@paraQuizID", quizId);

            DataSet ds = new DataSet();
            da.Fill(ds);
            int rec_cnt = ds.Tables[0].Rows.Count;

            Quiz obj = null;
            if (rec_cnt > 0)
            {
                DataRow row = ds.Tables[0].Rows[0];
                string title = row["title"].ToString();
                string description = row["description"].ToString();
                string datecreated = row["datecreated"].ToString();
                string userId = row["userId"].ToString();
                string quizID = row["quizId"].ToString();

                obj = new Quiz(title, description, datecreated, userId, quizID);
            }

            return obj;
        }
    }
}