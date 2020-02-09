using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
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

            string sqlStatement = "INSERT INTO Planner (userId, dateSelected, ToDotitle, description, status) " +
                                  "VALUES (@paraUserId, @paraDateSelected, @paraTitle, @paraDescription, @paraStatus)";

            int result = 0;
            SqlCommand sqlcmd = new SqlCommand(sqlStatement, myConn);

            sqlcmd.Parameters.AddWithValue("@paraUserId", todolist.userId);
            sqlcmd.Parameters.AddWithValue("@paraDateSelected", todolist.todoDate);
            sqlcmd.Parameters.AddWithValue("@paraTitle", todolist.todoTitle);
            sqlcmd.Parameters.AddWithValue("@paraDescription", todolist.todoDescription);
            sqlcmd.Parameters.AddWithValue("@paraStatus", todolist.todoStatus);

            myConn.Open();

            result = sqlcmd.ExecuteNonQuery();
            myConn.Close();

            return result;
        }

        public List<Planner> SelectbyUser(int userId)
        {
            string DBConnect = ConfigurationManager.ConnectionStrings["ConnStr"].ConnectionString;
            SqlConnection myConnection = new SqlConnection(DBConnect);

            string sqlStmt = "SELECT * FROM Planner WHERE userId = @paraUserId AND status = '' ORDER BY dateSelected ASC";
            SqlDataAdapter da = new SqlDataAdapter(sqlStmt, myConnection);

            da.SelectCommand.Parameters.AddWithValue("@paraUserId", userId);

            DataSet ds = new DataSet();

            da.Fill(ds);

            Planner plannerObj = null;
            List<Planner> userToDo = new List<Planner>();

            int count = ds.Tables[0].Rows.Count;
            if (count > 0)
            {
                for (int i = 0; i < count; i++)
                {
                    DataRow row = ds.Tables[0].Rows[i];
                    string dateSelected = row["dateSelected"].ToString();
                    string title = row["ToDotitle"].ToString();
                    string description = row["description"].ToString();
                    string status = row["status"].ToString();
                    int id = int.Parse(row["Id"].ToString());

                    plannerObj = new Planner(userId, dateSelected, title, description, status, id);
                    userToDo.Add(plannerObj);
                }
            }
            return userToDo;
        }

        public Planner SelectByID(string id)
        {
            string DBConnect = ConfigurationManager.ConnectionStrings["ConnStr"].ConnectionString;
            SqlConnection myConnection = new SqlConnection(DBConnect);

            string sqlStmt = "SELECT * FROM Planner WHERE Id = @paraPlanId ORDER BY dateSelected ASC";
            SqlDataAdapter da = new SqlDataAdapter(sqlStmt, myConnection);

            da.SelectCommand.Parameters.AddWithValue("@paraPlanId", id);

            DataSet ds = new DataSet();

            da.Fill(ds);

            Planner plannerObj = null;

            int count = ds.Tables[0].Rows.Count;
            if (count > 0)
            {
                DataRow row = ds.Tables[0].Rows[0];

                int userId = int.Parse(row["userId"].ToString());
                string dateSelected = row["dateSelected"].ToString();
                string title = row["ToDotitle"].ToString();
                string description = row["description"].ToString();
                string status = row["status"].ToString();

                plannerObj = new Planner(userId, dateSelected, title, description, status, int.Parse(id));
            }

            return plannerObj;
        }

        public int UpdateToDoList(string todoID, string title, string description)
        {
            string DBConnect = ConfigurationManager.ConnectionStrings["connStr"].ConnectionString;
            SqlConnection myConnection = new SqlConnection(DBConnect);

            string sqlStmt = "UPDATE Planner " +
                "SET ToDotitle = @paraTitle, description = @paraDescription " +
                "WHERE Id = @paraToDoID";

            int result = 0;    // Execute NonQuery return an integer value
            SqlCommand sqlCmd = new SqlCommand(sqlStmt, myConnection);

            sqlCmd.Parameters.AddWithValue("@paraToDoID", todoID);
            sqlCmd.Parameters.AddWithValue("@paraTitle", title);
            sqlCmd.Parameters.AddWithValue("@paraDescription", description);

            myConnection.Open();
            result = sqlCmd.ExecuteNonQuery();

            myConnection.Close();

            return result;
        }

        public int DeleteToDoList(string todoID, string status)
        {
            string DBConnect = ConfigurationManager.ConnectionStrings["connStr"].ConnectionString;
            SqlConnection myConnection = new SqlConnection(DBConnect);

            string sqlStmt = "UPDATE Planner " +
                "SET status = @paraStatus " +
                "WHERE Id = @paraToDoID";

            int result = 0;    // Execute NonQuery return an integer value
            SqlCommand sqlCmd = new SqlCommand(sqlStmt, myConnection);

            sqlCmd.Parameters.AddWithValue("@paraStatus", status);
            sqlCmd.Parameters.AddWithValue("@paraToDoID", todoID);

            myConnection.Open();
            result = sqlCmd.ExecuteNonQuery();

            myConnection.Close();

            return result;
        }

        public string SelectByDate(string todoDate)
        {
            string DBConnect = ConfigurationManager.ConnectionStrings["connStr"].ConnectionString;
            SqlConnection myConnection = new SqlConnection(DBConnect);

            string sqlStmt = "SELECT * FROM Planner " +
                "WHERE dateSelected = @paraToDoDate " +
                "AND status = ''";

            SqlDataAdapter da = new SqlDataAdapter(sqlStmt, myConnection);

            da.SelectCommand.Parameters.AddWithValue("@paraToDoDate", todoDate);

            DataSet ds = new DataSet();

            da.Fill(ds);

            int count = ds.Tables[0].Rows.Count;
            string dateofToDo = "";

            if (count > 0)
            {
                DataRow row = ds.Tables[0].Rows[0];
                dateofToDo = row["dateSelected"].ToString();
            }

            return dateofToDo;
        }
    }
}