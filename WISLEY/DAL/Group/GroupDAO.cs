using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using WISLEY.BLL.Profile;
using WISLEY.DAL.Profile;

namespace WISLEY.DAL.Group
{
    public class GroupDAO
    {
        public int Insert(BLL.Group.Group group, string email)
        {
            int result = 0;
            if (SelectGroupByName(group.name) == null)
            {
                string DBConnect = ConfigurationManager.ConnectionStrings["ConnStr"].ConnectionString;
                SqlConnection myConn = new SqlConnection(DBConnect);

                //Creating Group
                string sqlStmt = "INSERT INTO [Group] (name, description, weightage)" +
                     "VALUES (@paraName, @paraDescription, @paraWeightage)";

                // Execute NonQuery return an integer value
                SqlCommand sqlCmd = new SqlCommand(sqlStmt, myConn);

                sqlCmd.Parameters.AddWithValue("@paraName", group.name);
                sqlCmd.Parameters.AddWithValue("@paraDescription", group.description);
                sqlCmd.Parameters.AddWithValue("@paraWeightage", group.weightage);

                myConn.Open();
                result = sqlCmd.ExecuteNonQuery(); //Result 
                myConn.Close();


                //Getting Created Group ID
                int groupId = int.Parse(getGroupID(group.name, group.description, group.weightage).ToString());
                System.Diagnostics.Debug.WriteLine("Group ID:" + groupId);

                string insertGroupUserRelations = "INSERT INTO [GroupUserRelations] (userEmail, groupID) " +
                    "VALUES (@paraUserEmail, @paraGroupId)";

                SqlCommand executeInsert = new SqlCommand(insertGroupUserRelations, myConn);
                executeInsert.Parameters.AddWithValue("@paraUserEmail", email);
                executeInsert.Parameters.AddWithValue("@paraGroupId", groupId);

                myConn.Open();
                int insertResult = executeInsert.ExecuteNonQuery();
                myConn.Close();
            }
            else
            {
                return -1; // Returns -1 when group already exists
            }

            return result;
        }


        //Update User

        public int getGroupID(string name, string description, int weightage)
        {
            string DBConnect = ConfigurationManager.ConnectionStrings["ConnStr"].ConnectionString;
            SqlConnection myConn = new SqlConnection(DBConnect);

            string getGroupId = "Select Id from [Group] where name = @paraName and description = @paraDescription and weightage = @paraWeightage";
            SqlDataAdapter groupIdAdapter = new SqlDataAdapter(getGroupId, myConn);
            groupIdAdapter.SelectCommand.Parameters.AddWithValue("@paraName", name);
            groupIdAdapter.SelectCommand.Parameters.AddWithValue("@paraDescription", description);
            groupIdAdapter.SelectCommand.Parameters.AddWithValue("@paraWeightage", weightage);

            DataSet grpID_ds = new DataSet();
            groupIdAdapter.Fill(grpID_ds);
            int group_count = grpID_ds.Tables[0].Rows.Count;

            if (group_count > 0)
            {
                DataRow row = grpID_ds.Tables[0].Rows[0];
                int groupId = int.Parse(row["Id"].ToString());
                return groupId;
            }
            else
            {
                return -1;
            }
        }

        public BLL.Group.Group SelectGroupByName(string name)
        {
            string DBConnect = ConfigurationManager.ConnectionStrings["ConnStr"].ConnectionString;
            SqlConnection myConn = new SqlConnection(DBConnect);

            string sqlstmt = "Select * from [Group] where name = @paraName";
            SqlDataAdapter da = new SqlDataAdapter(sqlstmt, myConn);
            da.SelectCommand.Parameters.AddWithValue("@paraName", name);

            DataSet ds = new DataSet();
            da.Fill(ds);
            int rec_cnt = ds.Tables[0].Rows.Count;

            BLL.Group.Group obj = null;
            if (rec_cnt > 0)
            {
                DataRow row = ds.Tables[0].Rows[0];
                string description = row["description"].ToString();
                int weightage = int.Parse(row["weightage"].ToString());
                int grpId = int.Parse(row["Id"].ToString());

                obj = new BLL.Group.Group(name, description, weightage, grpId);
            }
            return obj;
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
                int grpId = int.Parse(row["Id"].ToString());

                obj = new BLL.Group.Group(name, description, weightage, grpId);
            }
            return obj;
        }

        public List<int> SelectUserGroupsJoined(string email)
        {
            string DBConnect = ConfigurationManager.ConnectionStrings["ConnStr"].ConnectionString;
            SqlConnection myConn = new SqlConnection(DBConnect);

            string sqlstmt = "Select groupID from [GroupUserRelations] where userID = @paraUserID";
            SqlDataAdapter sqlCmd = new SqlDataAdapter(sqlstmt, myConn);
            sqlCmd.SelectCommand.Parameters.AddWithValue("@paraUserID", email);

            DataSet ds = new DataSet();
            sqlCmd.Fill(ds);
            int rec_cnt = ds.Tables[0].Rows.Count;

            List<int> groupIDList = new List<int>();
            if (rec_cnt > 0)
            {
                for (int i = 0; i < rec_cnt; i++)
                {
                    DataRow row = ds.Tables[0].Rows[i];
                    int grpId = int.Parse(row["groupID"].ToString());
                    groupIDList.Add(grpId);
                }
            }

            return groupIDList;
        }


        public bool joinGroup()
        {
            return false;
        }

    }
}

//string getGroupList = "Select inGroupsId from [User] where email = @paraEmail";
//SqlDataAdapter da = new SqlDataAdapter(getGroupList, myConn);
//da.SelectCommand.Parameters.AddWithValue("@paraEmail", email);

//DataSet ds = new DataSet();
//da.Fill(ds);

//string groupList = "";
//int rec_cnt = ds.Tables[0].Rows.Count;
//if (rec_cnt > 0)
//{
//    DataRow row = ds.Tables[0].Rows[0];
//    string groupsString = row["inGroupsId"].ToString();

//    if (!String.IsNullOrEmpty(groupsString))
//    {
//        List<string> groupListStrings = groupsString.Split(',').ToList();
//        groupListStrings.Add(groupIdString);
//        groupList = string.Join(",", groupListStrings);
//    }
//    else
//    {
//        groupList = groupIdString;
//    }
//}

//System.Diagnostics.Debug.WriteLine(groupList);

// =====================================   Getting group ID old   ===================================
//string getGroupId = "Select Id from [Group] where name = @paraName and description = @paraDescription and weightage = @paraWeightage";
//SqlDataAdapter groupId = new SqlDataAdapter(getGroupId, myConn);
//groupId.SelectCommand.Parameters.AddWithValue("@paraName", group.name);
//groupId.SelectCommand.Parameters.AddWithValue("@paraDescription", group.description);
//groupId.SelectCommand.Parameters.AddWithValue("@paraWeightage", group.weightage);

//DataSet grpID_ds = new DataSet();
//groupId.Fill(grpID_ds);
//string groupIdString = "";
//int group_count = grpID_ds.Tables[0].Rows.Count;

//if (group_count > 0)
//{
//    DataRow row = grpID_ds.Tables[0].Rows[0];
//    groupIdString = row["Id"].ToString();
//}

/// ======================================== Old Insert User relation ==========================================

////Getting user from Email
//UserDAO currentUserDAO = new UserDAO();
//User currentUser = currentUserDAO.SelectByEmail(email);


////Getting Group List from current user through attribute
//List<string> groupListStrings = currentUser.inGroupsId.Split(',').ToList();
//groupListStrings.RemoveAll(s => string.IsNullOrEmpty(s));
//groupListStrings.Add(groupId.ToString());
//string groupList = string.Join(",", groupListStrings);


////Update user inGroupsId
//string updateUser = "UPDATE [User] " +
//    "SET inGroupsId = @paraGroupId " +
//    "WHERE email = @paraEmail";

//SqlCommand executeUpdate = new SqlCommand(updateUser, myConn);
//executeUpdate.Parameters.AddWithValue("@paraEmail", email);
//executeUpdate.Parameters.AddWithValue("@paraGroupId", groupList);

//myConn.Open();
//int Updateresult = executeUpdate.ExecuteNonQuery();
//myConn.Close();
