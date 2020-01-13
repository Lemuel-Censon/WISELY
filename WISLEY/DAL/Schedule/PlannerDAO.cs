using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using WISLEY.BLL.Schedule;

namespace WISLEY.DAL.Schedule
{
    public class PlannerDAO
    {
        public int Insert(Planner todolist)
        {
            string DBConnect = ConfigurationManager.ConnectionStrings["ConnStr"].ConnectionString;
            SqlConnection myConn = new SqlConnection(DBConnect);

            string sqlStatement = "INSERT INTO Planner (ID, dateSelected, title, description)" +
                                  "VALUES (@paraId, @paraDateSelected, @paraTitle, @paraDescription)";

            int result = 0;
            SqlCommand sqlcmd = new SqlCommand(sqlStatement, myConn);

            sqlcmd.Parameters.AddWithValue("@paraId", todolist.todoId);
            sqlcmd.Parameters.AddWithValue("@paraDateSelected", todolist.todoDate);
            sqlcmd.Parameters.AddWithValue("@paraTitle", todolist.todoTitle);
            sqlcmd.Parameters.AddWithValue("@paraDescription", todolist.todoDescription);

            myConn.Open();

            result = sqlcmd.ExecuteNonQuery();
            myConn.Close();

            return result;
        }
    }
}