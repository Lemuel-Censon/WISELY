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

            string sqlStatement = "INSERT INTO Planner (dateSelected, title, description) " +
                                  "VALUES (@paraDateSelected, @paraTitle, @paraDescription)";

            int result = 0;
            SqlCommand sqlcmd = new SqlCommand(sqlStatement, myConn);

            sqlcmd.Parameters.AddWithValue("@paraDateSelected", todolist.todoDate);
            sqlcmd.Parameters.AddWithValue("@paraTitle", todolist.todoTitle);
            sqlcmd.Parameters.AddWithValue("@paraDescription", todolist.todoDescription);

            myConn.Open();

            result = sqlcmd.ExecuteNonQuery();
            myConn.Close();

            return result;
        }

        public List<Planner> SelectAllToDo()
        {
            string DBConnect = ConfigurationManager.ConnectionStrings["ConnStr"].ConnectionString;
            SqlConnection myConnection = new SqlConnection(DBConnect);

            string sqlStmt = "SELECT * FROM Planner ORDER BY dateSelected ASC";
            SqlDataAdapter da = new SqlDataAdapter(sqlStmt, myConnection);

            DataSet ds = new DataSet();
            da.Fill(ds);

            int count = ds.Tables[0].Rows.Count;

            Planner obj = null;
            List<Planner> plannerList = new List<Planner>();

            if (count > 0)
            {
                for (int i=0; i<count; i++)
                {
                    DataRow row = ds.Tables[0].Rows[i];
                    DateTime todoDate = Convert.ToDateTime(row["dateSelected"].ToString());
                    string todoTitle = row["title"].ToString();
                    string todoDesc = row["description"].ToString();
                    obj = new Planner(todoDate, todoTitle, todoDesc);

                    plannerList.Add(obj);
                }
            }

            return plannerList;
        }
    }
}