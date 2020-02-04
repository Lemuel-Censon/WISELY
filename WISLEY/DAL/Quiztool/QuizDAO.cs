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
            string sqlStmt = "INSERT INTO Quiz (title, description, datecreated, totalquestions, status, userId)" +
                             "VALUES (@paraTitle, @paraDescription, @paraDatecreate, @paraTotalquestions, @paraStatus, @paraUserID)";

            int result = 0;    // Execute NonQuery return an integer value
            SqlCommand sqlCmd = new SqlCommand(sqlStmt, myConn);

            sqlCmd.Parameters.AddWithValue("@paraTitle", quiz.title);
            sqlCmd.Parameters.AddWithValue("@paraDescription", quiz.description);
            sqlCmd.Parameters.AddWithValue("@paraDatecreate", quiz.datecreated);
            sqlCmd.Parameters.AddWithValue("@paraTotalquestions", quiz.totalquestions);
            sqlCmd.Parameters.AddWithValue("@paraStatus", quiz.status);
            sqlCmd.Parameters.AddWithValue("@paraUserID", quiz.userId);

            myConn.Open();
            result = sqlCmd.ExecuteNonQuery();

            myConn.Close();

            return result;
        }

        public List<Quiz> SelectAll()
        {
            string DBConnect = ConfigurationManager.ConnectionStrings["ConnStr"].ConnectionString;
            SqlConnection myConn = new SqlConnection(DBConnect);

            string sqlstmt = "Select quiz.*, [User].name, [User].profilesrc from Quiz where status = '' " +
                "INNER JOIN [User] ON quiz.userId = [User].Id ";
            SqlDataAdapter da = new SqlDataAdapter(sqlstmt, myConn);

            DataSet ds = new DataSet();
            da.Fill(ds);
            int rec_cnt = ds.Tables[0].Rows.Count;

            Quiz obj = null;
            List<Quiz> quizlist = new List<Quiz>();
            if (rec_cnt > 0)
            {
                for (int i = 0; i < rec_cnt; i++)
                {
                    DataRow row = ds.Tables[0].Rows[i];
                    string title = row["title"].ToString();
                    string description = row["description"].ToString();
                    string datecreated = row["datecreated"].ToString();
                    int totalquestions = int.Parse(row["totalquestions"].ToString());
                    string status = row["status"].ToString();
                    string userID = row["userId"].ToString();
                    string username = row["name"].ToString();
                    string profilesrc = row["profilesrc"].ToString();
                    int quizID = int.Parse(row["Id"].ToString());

                    obj = new Quiz(title, description, datecreated, userID, quizID, totalquestions, status, username, profilesrc);
                    quizlist.Add(obj);
                }
            }

            return quizlist;
        }

        public List<Quiz> SelectByUserId(string userId)
        {
            string DBConnect = ConfigurationManager.ConnectionStrings["ConnStr"].ConnectionString;
            SqlConnection myConn = new SqlConnection(DBConnect);

            string sqlstmt = "Select * from Quiz where userId = @paraUid and status = ''";
            SqlDataAdapter da = new SqlDataAdapter(sqlstmt, myConn);
            da.SelectCommand.Parameters.AddWithValue("@paraUid", userId);

            DataSet ds = new DataSet();
            da.Fill(ds);
            int rec_cnt = ds.Tables[0].Rows.Count;

            Quiz obj = null;
            List<Quiz> userquizlist = new List<Quiz>();
            if (rec_cnt > 0)
            {
                for (int i = 0; i < rec_cnt; i++)
                {
                    DataRow row = ds.Tables[0].Rows[i];
                    string title = row["title"].ToString();
                    string description = row["description"].ToString();
                    string datecreated = row["datecreated"].ToString();
                    int totalquestions = int.Parse(row["totalquestions"].ToString());
                    string status = row["status"].ToString();
                    string userID = row["userId"].ToString();
                    int quizID = int.Parse(row["Id"].ToString());

                    obj = new Quiz(title, description, datecreated, userID, quizID, totalquestions, status);
                    userquizlist.Add(obj);
                }
            }

            return userquizlist;
        }

        public Quiz SelectById(string quizId)
        {
            string DBConnect = ConfigurationManager.ConnectionStrings["ConnStr"].ConnectionString;
            SqlConnection myConn = new SqlConnection(DBConnect);

            string sqlstmt = "Select * from Quiz where Id = @paraQuizID";
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
                int totalquestions = int.Parse(row["totalquestions"].ToString());
                string userId = row["userId"].ToString();
                int quizID = int.Parse(row["Id"].ToString());

                obj = new Quiz(title, description, datecreated, userId, quizID, totalquestions);
            }

            return obj;
        }

        public int GetLastID()
        {
            string DBConnect = ConfigurationManager.ConnectionStrings["ConnStr"].ConnectionString;
            SqlConnection myConn = new SqlConnection(DBConnect);

            string sqlstmt = "Select MAX(Id) as LastID from Quiz";
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

        public int DeleteById(string quizId)
        {
            string DBConnect = ConfigurationManager.ConnectionStrings["ConnStr"].ConnectionString;
            SqlConnection myConn = new SqlConnection(DBConnect);
            string sqlstmt = "Update Quiz Set status = 'deleted' where Id = @paraQuizID";

            int result = 0;    // Execute NonQuery return an integer value
            SqlCommand sqlCmd = new SqlCommand(sqlstmt, myConn);

            sqlCmd.Parameters.AddWithValue("@paraQuizID", quizId);

            myConn.Open();
            result = sqlCmd.ExecuteNonQuery();

            myConn.Close();

            return result;
        }

        public int UpdateQuiz(string title, string desc, string quizId)
        {
            string DBConnect = ConfigurationManager.ConnectionStrings["ConnStr"].ConnectionString;
            SqlConnection myConn = new SqlConnection(DBConnect);
            string sqlstmt = "Update Quiz Set title = @paraTitle, description = @paraDesc where Id = @paraQuizID";

            int result = 0;    // Execute NonQuery return an integer value
            SqlCommand sqlCmd = new SqlCommand(sqlstmt, myConn);

            sqlCmd.Parameters.AddWithValue("@paraTitle", title);
            sqlCmd.Parameters.AddWithValue("@paraDesc", desc);
            sqlCmd.Parameters.AddWithValue("@paraQuizID", quizId);

            myConn.Open();
            result = sqlCmd.ExecuteNonQuery();

            myConn.Close();

            return result;
        }

        public int UpdateTotalQuestions(int totalquestions, string quizId)
        {
            string DBConnect = ConfigurationManager.ConnectionStrings["ConnStr"].ConnectionString;
            SqlConnection myConn = new SqlConnection(DBConnect);
            string sqlstmt = "Update Quiz Set totalquestions = @paraTotalquestions where Id = @paraQuizID";

            int result = 0;    // Execute NonQuery return an integer value
            SqlCommand sqlCmd = new SqlCommand(sqlstmt, myConn);

            sqlCmd.Parameters.AddWithValue("@paraTotalQuestions", totalquestions);
            sqlCmd.Parameters.AddWithValue("@paraQuizID", quizId);

            myConn.Open();
            result = sqlCmd.ExecuteNonQuery();

            myConn.Close();

            return result;
        }
    }
}