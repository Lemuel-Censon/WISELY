using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;


namespace WISLEY.DAL.Group
{
    public class GroupDAO
    {
        public int Insert(BLL.Group.Group group)
        {
           
            string DBConnect = ConfigurationManager.ConnectionStrings["ConnStr"].ConnectionString;
            SqlConnection myConn = new SqlConnection(DBConnect);

            string sqlStmt = "INSERT INTO [Group] (name, description, weightage)" +
                 "VALUES (@paraName, @paraDescription, @paraWeightage)";

            int result = 0;    // Execute NonQuery return an integer value
            SqlCommand sqlCmd = new SqlCommand(sqlStmt, myConn);

            sqlCmd.Parameters.AddWithValue("@paraName", group.name);
            sqlCmd.Parameters.AddWithValue("@paraDescription", group.description);
            sqlCmd.Parameters.AddWithValue("@paraWeightage", group.weightage);

            myConn.Open();
            result = sqlCmd.ExecuteNonQuery();

            myConn.Close();

            return result;
        }

        public BLL.Group.Group SelectByID(string id)
        {
            string DBConnect = ConfigurationManager.ConnectionStrings["ConnStr"].ConnectionString;
            SqlConnection myConn = new SqlConnection(DBConnect);

            string sqlstmt = "Select * from [Group] where Id = @paraId";
            SqlDataAdapter da = new SqlDataAdapter(sqlstmt, myConn);
            da.SelectCommand.Parameters.AddWithValue("@paraId", id);

            DataSet ds = new DataSet();
            da.Fill(ds);
            int rec_cnt = ds.Tables[0].Rows.Count;

            BLL.Group.Group obj = null;
            if (rec_cnt > 0)
            {
                DataRow row = ds.Tables[0].Rows[0];
                string name = row["name"].ToString();
                string description = row["description"].ToString();
                int weightage = int.Parse(row["weightage"].ToString());

                obj = new BLL.Group.Group(name, description, weightage);
            }

            return obj;
        }

    }
}