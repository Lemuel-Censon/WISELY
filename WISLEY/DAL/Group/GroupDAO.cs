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
            if (SelectGroupByAttribute("name", group.name) == null)
            {
                string generatedCode = generateInviteCode();
                string DBConnect = ConfigurationManager.ConnectionStrings["ConnStr"].ConnectionString;
                SqlConnection myConn = new SqlConnection(DBConnect);

                //Creating Group
                string sqlStmt = "INSERT INTO [Group] (name, description, weightage, joinCode)" +
                     "VALUES (@paraName, @paraDescription, @paraWeightage, @paraJoinCode)";

                // Execute NonQuery return an integer value
                SqlCommand sqlCmd = new SqlCommand(sqlStmt, myConn);

                sqlCmd.Parameters.AddWithValue("@paraName", group.name);
                sqlCmd.Parameters.AddWithValue("@paraDescription", group.description);
                sqlCmd.Parameters.AddWithValue("@paraWeightage", group.weightage);
                sqlCmd.Parameters.AddWithValue("@paraJoinCode", generatedCode);


                myConn.Open();
                result = sqlCmd.ExecuteNonQuery(); //Result 
                myConn.Close();


                //Getting Created Group ID by inviteCode
                //int groupId = int.Parse(getGroupID(group.name, group.description, group.weightage).ToString());
                int groupId = int.Parse(SelectGroupByAttribute("joinCode", generatedCode).id.ToString());
                System.Diagnostics.Debug.WriteLine("Group ID:" + groupId);


                string insertGroupUserRelations = "INSERT INTO [GroupUserRelations] (userEmail, groupID, customOrder) " +
                    "VALUES (@paraUserEmail, @paraGroupId, @paraOrder)";

                SqlCommand executeInsert = new SqlCommand(insertGroupUserRelations, myConn);
                executeInsert.Parameters.AddWithValue("@paraUserEmail", email);
                executeInsert.Parameters.AddWithValue("@paraGroupId", groupId);
                executeInsert.Parameters.AddWithValue("@paraOrder", higherJoinedGroupOrder(email) + 1);

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

        public string generateInviteCode()
        {
            var chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
            var stringChars = new char[8];
            var random = new Random();

            for (int i = 0; i < stringChars.Length; i++)
            {
                stringChars[i] = chars[random.Next(chars.Length)];
            }

            var inviteCode = new String(stringChars);

            string DBConnect = ConfigurationManager.ConnectionStrings["ConnStr"].ConnectionString;
            SqlConnection myConn = new SqlConnection(DBConnect);

            string getCode = "Select joinCode from [Group] where joinCode = @paraCode";
            SqlDataAdapter groupIdAdapter = new SqlDataAdapter(getCode, myConn);
            groupIdAdapter.SelectCommand.Parameters.AddWithValue("@paraCode", inviteCode);

            DataSet codeDS = new DataSet();
            groupIdAdapter.Fill(codeDS);
            int group_count = codeDS.Tables[0].Rows.Count;

            if (group_count > 0)
            {
                inviteCode = generateInviteCode();
            }

            return inviteCode;


        }

        public int ResetGroupJoinCode(int id)
        {
            string generatedCode = generateInviteCode();
            System.Diagnostics.Debug.WriteLine(generatedCode);
            string DBConnect = ConfigurationManager.ConnectionStrings["ConnStr"].ConnectionString;
            SqlConnection myConn = new SqlConnection(DBConnect);

            string sqlStmt = "UPDATE [Group] " +
                "SET joinCode = @paraCode " +
                "WHERE Id = @paraId";

            int result = 0;    // Execute NonQuery return an integer value
            SqlCommand sqlCmd = new SqlCommand(sqlStmt, myConn);

            sqlCmd.Parameters.AddWithValue("@paraCode", generatedCode);
            sqlCmd.Parameters.AddWithValue("@paraId", id);

            myConn.Open();
            result = sqlCmd.ExecuteNonQuery();

            myConn.Close();

            return result;
        }

        public int Update(int id, string desc, int weightage)
        {
            string DBConnect = ConfigurationManager.ConnectionStrings["ConnStr"].ConnectionString;
            SqlConnection myConn = new SqlConnection(DBConnect);

            string sqlStmt = "UPDATE [Group] " +
                "SET description = @paraDesc, weightage = @paraWeight " +
                "WHERE Id = @paraId";

            int result = 0;    // Execute NonQuery return an integer value
            SqlCommand sqlCmd = new SqlCommand(sqlStmt, myConn);

            sqlCmd.Parameters.AddWithValue("@paraDesc", desc);
            sqlCmd.Parameters.AddWithValue("@paraWeight", weightage);
            sqlCmd.Parameters.AddWithValue("@paraId", id);

            myConn.Open();
            result = sqlCmd.ExecuteNonQuery();

            myConn.Close();

            return result;
        }

        public BLL.Group.Group SelectGroupByAttribute(string attribute, string data)
        {
            string DBConnect = ConfigurationManager.ConnectionStrings["ConnStr"].ConnectionString;
            SqlConnection myConn = new SqlConnection(DBConnect);

            string sqlstmt = "Select * from [Group] where " + attribute + " = @paraData";
            SqlDataAdapter da = new SqlDataAdapter(sqlstmt, myConn);
            da.SelectCommand.Parameters.AddWithValue("@paraData", data);

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
                string joinCode = row["joinCode"].ToString();
                int status = int.Parse(row["active"].ToString());

                obj = new BLL.Group.Group(name, description, weightage, grpId, joinCode, status);
            }
            return obj;
        }

        public List<int> SelectUserGroupsJoined(string email)
        {
            string DBConnect = ConfigurationManager.ConnectionStrings["ConnStr"].ConnectionString;
            SqlConnection myConn = new SqlConnection(DBConnect);

            string sqlstmt = "Select groupID from [GroupUserRelations] where userEmail = @paraUserEmail";
            SqlDataAdapter sqlCmd = new SqlDataAdapter(sqlstmt, myConn);
            sqlCmd.SelectCommand.Parameters.AddWithValue("@paraUserEmail", email);

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

        public int higherJoinedGroupOrder(string email)
        {
            int order = 0; 
            string DBConnect = ConfigurationManager.ConnectionStrings["ConnStr"].ConnectionString;
            SqlConnection myConn = new SqlConnection(DBConnect);

            string sqlstmt = "Select customOrder from [GroupUserRelations] where userEmail = @paraUserEmail order by customOrder desc";
            SqlDataAdapter sqlCmd = new SqlDataAdapter(sqlstmt, myConn);
            sqlCmd.SelectCommand.Parameters.AddWithValue("@paraUserEmail", email);

            DataSet ds = new DataSet();
            sqlCmd.Fill(ds);
            int rec_cnt = ds.Tables[0].Rows.Count;

            if (rec_cnt > 0)
            {
                DataRow row = ds.Tables[0].Rows[0];
                order = int.Parse(row["customOrder"].ToString());
            }
            else
            {
                order = 1;
            }

            return order;
        }

        public List<string> SelectGroupMembers(string groupId)
        {
            string DBConnect = ConfigurationManager.ConnectionStrings["ConnStr"].ConnectionString;
            SqlConnection myConn = new SqlConnection(DBConnect);

            string sqlstmt = "Select userEmail from [GroupUserRelations] where groupId = @paraGroupID";
            SqlDataAdapter sqlCmd = new SqlDataAdapter(sqlstmt, myConn);
            sqlCmd.SelectCommand.Parameters.AddWithValue("@paraGroupID", groupId);

            DataSet ds = new DataSet();
            sqlCmd.Fill(ds);
            int rec_cnt = ds.Tables[0].Rows.Count;

            List<string> userIDList = new List<string>();
            if (rec_cnt > 0)
            {
                for (int i = 0; i < rec_cnt; i++)
                {
                    DataRow row = ds.Tables[0].Rows[i];
                    string userId = row["userEmail"].ToString();
                    userIDList.Add(userId);
                }
            }

            return userIDList;
        }

        public int joinGroup(string email, string code)
        {
            int result = 0;
            int groupId = int.Parse(SelectGroupByAttribute("joinCode", code).id.ToString());
            bool isInList = SelectUserGroupsJoined(email).IndexOf(groupId) != -1;
            if (!isInList)
            {
                string DBConnect = ConfigurationManager.ConnectionStrings["ConnStr"].ConnectionString;
                SqlConnection myConn = new SqlConnection(DBConnect);

                //Creating Group
                string sqlStmt = "INSERT INTO [GroupUserRelations] (userEmail, groupID, customOrder)" +
                     "VALUES (@paraEmail, @paraGroupID)";


                // Execute NonQuery return an integer value
                SqlCommand sqlCmd = new SqlCommand(sqlStmt, myConn);

                sqlCmd.Parameters.AddWithValue("@paraEmail", email);
                sqlCmd.Parameters.AddWithValue("@paraGroupID", groupId);
                sqlCmd.Parameters.AddWithValue("@paraOrder", higherJoinedGroupOrder(email) + 1);

                myConn.Open();
                result = sqlCmd.ExecuteNonQuery(); //Result 
                myConn.Close();
            }
            else
            {
                result = -1;
            }
            return result;
        }

        public int hideJoinedGroup(string email, string groupId)
        {
            string DBConnect = ConfigurationManager.ConnectionStrings["ConnStr"].ConnectionString;
            SqlConnection myConn = new SqlConnection(DBConnect);

            string sqlStmt = "UPDATE [GroupUserRelations] " +
                "SET show = @paraStatus, customOrder = @paraOrder " +
                "WHERE groupID = @paraId and userEmail = @paraEmail";

            int result = 0;    // Execute NonQuery return an integer value
            SqlCommand sqlCmd = new SqlCommand(sqlStmt, myConn);

            sqlCmd.Parameters.AddWithValue("@paraStatus", 0);
            sqlCmd.Parameters.AddWithValue("@paraOrder", -1);
            sqlCmd.Parameters.AddWithValue("@paraId", groupId);
            sqlCmd.Parameters.AddWithValue("@paraEmail", email);


            myConn.Open();
            result = sqlCmd.ExecuteNonQuery();

            myConn.Close();

            return result;
        }

        public int showJoinedGroup(string email, string groupId)
        {
            string DBConnect = ConfigurationManager.ConnectionStrings["ConnStr"].ConnectionString;
            SqlConnection myConn = new SqlConnection(DBConnect);

            string sqlStmt = "UPDATE [GroupUserRelations] " +
                "SET show = @paraStatus, customOrder = @paraOrder " +
                "WHERE groupID = @paraId and userEmail = @paraEmail";

            int result = 0;    // Execute NonQuery return an integer value
            SqlCommand sqlCmd = new SqlCommand(sqlStmt, myConn);

            sqlCmd.Parameters.AddWithValue("@paraStatus", 1);
            sqlCmd.Parameters.AddWithValue("@paraOrder", higherJoinedGroupOrder(email) + 1);
            sqlCmd.Parameters.AddWithValue("@paraId", groupId);
            sqlCmd.Parameters.AddWithValue("@paraEmail", email);


            myConn.Open();
            result = sqlCmd.ExecuteNonQuery();

            myConn.Close();

            return result;
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
