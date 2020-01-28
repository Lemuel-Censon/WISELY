using System;
using System.Collections.Generic;
using System.Configuration;
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
            string sqlStmt = "INSERT INTO Question (question, option1, option2, option3, option4, option5, answer, quizId)" +
                             "VALUES (@paraQuestion, @paraOption1, @paraOption2, @paraOption3, @paraOption4, @paraOption5, @paraAnswer, @paraQuizID)";

            int result = 0;    // Execute NonQuery return an integer value
            SqlCommand sqlCmd = new SqlCommand(sqlStmt, myConn);

            sqlCmd.Parameters.AddWithValue("@paraQuestion", question.question);
            sqlCmd.Parameters.AddWithValue("@paraOption1", question.option1);
            sqlCmd.Parameters.AddWithValue("@paraOption2", question.option2);
            sqlCmd.Parameters.AddWithValue("@paraOption3", question.option3);
            sqlCmd.Parameters.AddWithValue("@paraOption4", question.option4);
            sqlCmd.Parameters.AddWithValue("@paraOption5", question.option5);
            sqlCmd.Parameters.AddWithValue("@paraAnswer", question.answer);
            sqlCmd.Parameters.AddWithValue("@paraQuizID", question.quizId);

            myConn.Open();
            result = sqlCmd.ExecuteNonQuery();

            myConn.Close();

            return result;
        }
    }
}