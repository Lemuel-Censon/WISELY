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

            string sqlStatement = "INSERT INTO Planner (userId, dateSelected, ToDotitle, description) " +
                                  "VALUES (@paraUserId, @paraDateSelected, @paraTitle, @paraDescription)";

            int result = 0;
            SqlCommand sqlcmd = new SqlCommand(sqlStatement, myConn);

            sqlcmd.Parameters.AddWithValue("@paraUserId", todolist.userId);
            sqlcmd.Parameters.AddWithValue("@paraDateSelected", todolist.todoDate);
            sqlcmd.Parameters.AddWithValue("@paraTitle", todolist.todoTitle);
            sqlcmd.Parameters.AddWithValue("@paraDescription", todolist.todoDescription);

            myConn.Open();

            result = sqlcmd.ExecuteNonQuery();
            myConn.Close();

            return result;
        }

        public List<Planner> SelectbyUser(int userId)
        {
            string DBConnect = ConfigurationManager.ConnectionStrings["ConnStr"].ConnectionString;
            SqlConnection myConnection = new SqlConnection(DBConnect);

            string sqlStmt = "SELECT * FROM Planner WHERE userId = @paraUserId ORDER BY dateSelected ASC";
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
                    DateTime dateSelected = DateTime.Parse(row["dateSelected"].ToString());
                    string title = row["ToDotitle"].ToString();
                    string description = row["description"].ToString();
                    int id = int.Parse(row["Id"].ToString());

                    plannerObj = new Planner(userId, dateSelected, title, description, id);
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
                DateTime dateSelected = DateTime.Parse(row["dateSelected"].ToString());
                string title = row["ToDotitle"].ToString();
                string description = row["description"].ToString();

                plannerObj = new Planner(userId, dateSelected, title, description, int.Parse(id));
            }

            return plannerObj;
        }
    }
}