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
    public class QuestionDAO
    {
        public int Insert(Question question)
        {
            string DBConnect = ConfigurationManager.ConnectionStrings["ConnStr"].ConnectionString;
            SqlConnection myConn = new SqlConnection(DBConnect);
            string sqlStmt = "INSERT INTO Question (question, number, option1, option2, option3, option4, answer, quizId)" +
                             "VALUES (@paraQuestion, @paraNumber, @paraOption1, @paraOption2, @paraOption3, @paraOption4, @paraAnswer, @paraQuizID)";

            int result = 0;    // Execute NonQuery return an integer value
            SqlCommand sqlCmd = new SqlCommand(sqlStmt, myConn);

            sqlCmd.Parameters.AddWithValue("@paraQuestion", question.question);
            sqlCmd.Parameters.AddWithValue("@paraNumber", question.number);
            sqlCmd.Parameters.AddWithValue("@paraOption1", question.option1);
            sqlCmd.Parameters.AddWithValue("@paraOption2", question.option2);
            sqlCmd.Parameters.AddWithValue("@paraOption3", question.option3);
            sqlCmd.Parameters.AddWithValue("@paraOption4", question.option4);
            sqlCmd.Parameters.AddWithValue("@paraAnswer", question.answer);
            sqlCmd.Parameters.AddWithValue("@paraQuizID", question.quizId);

            myConn.Open();
            result = sqlCmd.ExecuteNonQuery();

            myConn.Close();

            return result;
        }

        public List<Question> SelectByQuiz(string quizId)
        {
            string DBConnect = ConfigurationManager.ConnectionStrings["ConnStr"].ConnectionString;
            SqlConnection myConn = new SqlConnection(DBConnect);

            string sqlstmt = "Select * From Question Where quizId = @paraQuizID";
            SqlDataAdapter da = new SqlDataAdapter(sqlstmt, myConn);
            da.SelectCommand.Parameters.AddWithValue("@paraQuizID", quizId);

            DataSet ds = new DataSet();
            da.Fill(ds);
            int rec_cnt = ds.Tables[0].Rows.Count;

            Question obj = null;
            List<Question> questionlist = new List<Question>();
            if (rec_cnt > 0)
            {
                for (int i = 0; i < rec_cnt; i++)
                {
                    DataRow row = ds.Tables[0].Rows[i];
                    string question = row["question"].ToString();
                    string questionNo = row["number"].ToString();
                    string option1 = row["option1"].ToString();
                    string option2 = row["option2"].ToString();
                    string option3 = row["option3"].ToString();
                    string option4 = row["option4"].ToString();
                    string answer = row["answer"].ToString();
                    string quizID = row["quizId"].ToString();

                    obj = new Question(question, questionNo, option1, option2, option3, option4, answer, quizID);
                    questionlist.Add(obj);
                }
            }

            return questionlist;
        }

        public int GetQuestionCount(string quizId)
        {
            string DBConnect = ConfigurationManager.ConnectionStrings["ConnStr"].ConnectionString;
            SqlConnection myConn = new SqlConnection(DBConnect);

            string sqlstmt = "Select * From Question Where quizId = @paraQuizID";
            SqlDataAdapter da = new SqlDataAdapter(sqlstmt, myConn);
            da.SelectCommand.Parameters.AddWithValue("@paraQuizID", quizId);

            DataSet ds = new DataSet();
            da.Fill(ds);
            int rec_cnt = ds.Tables[0].Rows.Count;
            return rec_cnt;
        }
    }
}