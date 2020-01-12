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
        public int Insert(BLL.Group.Group group, string email)
        {
           
            string DBConnect = ConfigurationManager.ConnectionStrings["ConnStr"].ConnectionString;
            SqlConnection myConn = new SqlConnection(DBConnect);

            //Creating Group
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


            //Getting Created Group ID
            string getGroupId = "Select Id from [Group] where name = @paraName and description = @paraDescription and weightage = @paraWeightage";
            SqlDataAdapter groupId = new SqlDataAdapter(getGroupId, myConn);
            groupId.SelectCommand.Parameters.AddWithValue("@paraName", group.name);
            groupId.SelectCommand.Parameters.AddWithValue("@paraDescription", group.description);
            groupId.SelectCommand.Parameters.AddWithValue("@paraWeightage", group.weightage);

            DataSet grpID_ds = new DataSet();
            groupId.Fill(grpID_ds);
            string groupIdString = "";
            int group_count = grpID_ds.Tables[0].Rows.Count;

            if (group_count > 0)
            {
                DataRow row = grpID_ds.Tables[0].Rows[0];
                groupIdString = row["Id"].ToString();
            }

            //Getting Group List from current user
            string getGroupList = "Select inGroupsId from [User] where email = @paraEmail";
            SqlDataAdapter da = new SqlDataAdapter(getGroupList, myConn);
            da.SelectCommand.Parameters.AddWithValue("@paraEmail", email);

            DataSet ds = new DataSet();
            da.Fill(ds);

            string groupList = "";
            int rec_cnt = ds.Tables[0].Rows.Count;
            if (rec_cnt > 0)
            {
                DataRow row = ds.Tables[0].Rows[0];
                string groupsString = row["inGroupsId"].ToString();

                if (!String.IsNullOrEmpty(groupsString))
                {
                    List<string> groupListStrings = groupsString.Split(',').ToList();
                    groupListStrings.Add(groupIdString);
                    groupList = string.Join(",", groupListStrings);
                }
                else
                {
                    groupList = groupIdString;
                }
            }

            System.Diagnostics.Debug.WriteLine(groupList);

            //Update User
            string updateUser = "UPDATE [User] " +
                "SET inGroupsId = @paraGroupId" +
                "WHERE email = @paraEmail";

      
            SqlCommand executeUpdate = new SqlCommand(updateUser, myConn);
        
            sqlCmd.Parameters.AddWithValue("@paraEmail", email);
            sqlCmd.Parameters.AddWithValue("@paraGroupId", groupList);

            myConn.Open();
            int Updateresult = sqlCmd.ExecuteNonQuery();
            System.Diagnostics.Debug.WriteLine(Updateresult);

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