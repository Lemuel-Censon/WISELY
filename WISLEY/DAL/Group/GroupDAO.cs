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

        public int Update(int id, string name, string desc, int weightage)
        {
            string DBConnect = ConfigurationManager.ConnectionStrings["ConnStr"].ConnectionString;
            SqlConnection myConn = new SqlConnection(DBConnect);

            string sqlStmt = "UPDATE [Group] " +
                "SET name = @paraName, description = @paraDesc, weightage = @paraWeight " +
                "WHERE Id = @paraId";

            int result = 0;    // Execute NonQuery return an integer value
            SqlCommand sqlCmd = new SqlCommand(sqlStmt, myConn);

            sqlCmd.Parameters.AddWithValue("@paraName", name);
            sqlCmd.Parameters.AddWithValue("@paraDesc", desc);
            sqlCmd.Parameters.AddWithValue("@paraWeight", weightage);
            sqlCmd.Parameters.AddWithValue("@paraId", id);

            myConn.Open();
            result = sqlCmd.ExecuteNonQuery();

            myConn.Close();

            return result;
        }


        //Select Functions

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

        public List<BLL.Group.Group> SelectUserGroupsJoined(string email)
        {
            string DBConnect = ConfigurationManager.ConnectionStrings["ConnStr"].ConnectionString;
            SqlConnection myConn = new SqlConnection(DBConnect);

            string sqlstmt = "SELECT * FROM [Group] " +
                    "INNER JOIN [GroupUserRelations] " +
                    "ON [Group].Id = [GroupUserRelations].groupID " +
                    "WHERE userEmail = @paraUserEmail " +
                    "ORDER BY customOrder ASC";

            SqlDataAdapter sqlCmd = new SqlDataAdapter(sqlstmt, myConn);
            sqlCmd.SelectCommand.Parameters.AddWithValue("@paraUserEmail", email);

            DataSet ds = new DataSet();
            sqlCmd.Fill(ds);
            int rec_cnt = ds.Tables[0].Rows.Count;
            System.Diagnostics.Debug.WriteLine(rec_cnt);

            List<BLL.Group.Group> groupObjList = new List<BLL.Group.Group>();

            if (rec_cnt > 0)
            {
                for (int i = 0; i < rec_cnt; i++)
                {
                    DataRow row = ds.Tables[0].Rows[i];
                    string groupName = row["name"].ToString();
                    string description = row["description"].ToString();
                    string joinCode = row["joinCode"].ToString();
                    int status = int.Parse(row["active"].ToString());

                    int grpId = int.Parse(row["groupID"].ToString());
                    int customOrder = int.Parse(row["customOrder"].ToString());
                    int show = int.Parse(row["show"].ToString());

                    BLL.Group.Group obj = new BLL.Group.Group(
                        Name: groupName,
                        Description: description,
                        joinCode: description,
                        status: status,
                        id: grpId,
                        customOrder: customOrder,
                        show: show
                        );
                    System.Diagnostics.Debug.WriteLine(obj);

                    groupObjList.Add(obj);

                }
            }

            return groupObjList;
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

        public List<User> SelectNonMembers(string groupId)
        {
            string DBConnect = ConfigurationManager.ConnectionStrings["ConnStr"].ConnectionString;
            SqlConnection myConn = new SqlConnection(DBConnect);

            string sqlstmt = "Select * from [User] " +
                "where email not in (Select userEmail from [GroupUserRelations] where groupID = @paraGroupID)";
            SqlDataAdapter sqlCmd = new SqlDataAdapter(sqlstmt, myConn);
            sqlCmd.SelectCommand.Parameters.AddWithValue("@paraGroupID", groupId);

            DataSet ds = new DataSet();
            sqlCmd.Fill(ds);
            int rec_cnt = ds.Tables[0].Rows.Count;

            List<User> userIDList = new List<User>();
            if (rec_cnt > 0)
            {
                for (int i = 0; i < rec_cnt; i++)
                {
                    DataRow row = ds.Tables[0].Rows[i];
                    int Id = int.Parse(row["Id"].ToString());
                    string profilesrc = row["profilesrc"].ToString();
                    string userEmail = row["email"].ToString();
                    string name = row["name"].ToString();
                    string password = row["password"].ToString();
                    string salt = row["salt"].ToString();
                    string contactNo = row["contactNo"].ToString();
                    string gender = row["gender"].ToString();
                    string dob = row["dob"].ToString();
                    string accType = row["accType"].ToString();
                    string bio = row["bio"].ToString();
                    int points = int.Parse(row["wisPoints"].ToString());

                    User obj = new User(
                        id: Id,
                        email: userEmail,
                        userType: accType,
                        name: name,
                        password: password,
                        salt: salt,
                        dob: dob,
                        contactNo: contactNo,
                        gender: gender,
                        bio: bio,
                        points: points);

                    userIDList.Add(obj);
                }
            }
            System.Diagnostics.Debug.WriteLine(userIDList.Count);
            return userIDList;
        }


        //Changing Group Status

        public int disableGroup(string groupId)
        {
            string DBConnect = ConfigurationManager.ConnectionStrings["ConnStr"].ConnectionString;
            SqlConnection myConn = new SqlConnection(DBConnect);

            string grpUserRltnSqlStmt = "UPDATE [GroupUserRelations] " +
                "SET show = @paraStatus, customOrder = @paraOrder " +
                "WHERE groupID = @paraId";

            int grpUserResult = 0;    
            SqlCommand grpUserRltnsqlCmd = new SqlCommand(grpUserRltnSqlStmt, myConn);

            grpUserRltnsqlCmd.Parameters.AddWithValue("@paraStatus", 1);
            grpUserRltnsqlCmd.Parameters.AddWithValue("@paraOrder", -1);
            grpUserRltnsqlCmd.Parameters.AddWithValue("@paraId", groupId);

            string grpDisableSqlStmt = "UPDATE [Group] " +
                "SET active = @paraStatus " +
                "WHERE Id = @paraId";

            int grpResult = 0;

            SqlCommand grpDisableSqlCmd = new SqlCommand(grpDisableSqlStmt, myConn);
            grpDisableSqlCmd.Parameters.AddWithValue("@paraStatus", 0);
            grpDisableSqlCmd.Parameters.AddWithValue("@paraId", groupId);


            myConn.Open();
            grpUserResult = grpUserRltnsqlCmd.ExecuteNonQuery();
            grpResult = grpDisableSqlCmd.ExecuteNonQuery();
            myConn.Close();

            System.Diagnostics.Debug.WriteLine(grpUserResult);
            System.Diagnostics.Debug.WriteLine(grpResult);
            int result = 0;
            if(grpUserResult == 1 && grpResult == 1)
            {
                result = 1;
            }

            return result;
        }

        public int enableGroup(string groupId)
        {
            string DBConnect = ConfigurationManager.ConnectionStrings["ConnStr"].ConnectionString;
            SqlConnection myConn = new SqlConnection(DBConnect);

            string grpUserRltnSqlStmt = "UPDATE [GroupUserRelations] " +
                "SET show = @paraStatus, customOrder = @paraOrder " +
                "WHERE groupID = @paraId";

            int grpUserResult = 0;
            SqlCommand grpUserRltnsqlCmd = new SqlCommand(grpUserRltnSqlStmt, myConn);

            grpUserRltnsqlCmd.Parameters.AddWithValue("@paraStatus", 1);
            grpUserRltnsqlCmd.Parameters.AddWithValue("@paraOrder", -1);
            grpUserRltnsqlCmd.Parameters.AddWithValue("@paraId", groupId);

            string grpDisableSqlStmt = "UPDATE [Group] " +
                "SET active = @paraStatus " +
                "WHERE Id = @paraId";

            int grpResult = 0;

            SqlCommand grpDisableSqlCmd = new SqlCommand(grpDisableSqlStmt, myConn);
            grpDisableSqlCmd.Parameters.AddWithValue("@paraStatus", 1);
            grpDisableSqlCmd.Parameters.AddWithValue("@paraId", groupId);


            myConn.Open();
            grpUserResult = grpUserRltnsqlCmd.ExecuteNonQuery();
            grpResult = grpDisableSqlCmd.ExecuteNonQuery();
            myConn.Close();

            int result = 0;
            if (grpUserResult == 1 && grpResult == 1)
            {
                result = 1;
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


        //Joining/Quitting group functions

        public int joinGroup(string email, string code)
        {
            string DBConnect = ConfigurationManager.ConnectionStrings["ConnStr"].ConnectionString;
            SqlConnection myConn = new SqlConnection(DBConnect);

            int result = 0;
            string checkGroupStmt = "Select * from [GroupUserRelations] " +
                "where userEmail = @paraUserEmail and groupID = (Select Id from [Group] where joinCode = @paraCode)";
            SqlDataAdapter sqlCheckCmd = new SqlDataAdapter(checkGroupStmt, myConn);

            sqlCheckCmd.SelectCommand.Parameters.AddWithValue("@paraUserEmail", email);
            sqlCheckCmd.SelectCommand.Parameters.AddWithValue("@paraCode", code);

            DataSet ds = new DataSet();
            sqlCheckCmd.Fill(ds);
            int rec_cnt = ds.Tables[0].Rows.Count;

            //If user has not joined the group
            if (rec_cnt < 1)
            {

                //Joining Group
                string sqlStmt = "INSERT INTO [GroupUserRelations] (userEmail, groupID, customOrder) " +
                     "VALUES (@paraEmail, @paraGroupID, @paraOrder)";

                int groupId = int.Parse(SelectGroupByAttribute("joinCode", code).id.ToString());

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

        public int addMemberToGroup(string email, string groupId)
        {
            string DBConnect = ConfigurationManager.ConnectionStrings["ConnStr"].ConnectionString;
            SqlConnection myConn = new SqlConnection(DBConnect);
            int result = 0;

            string checkGroupStmt = "Select * from [GroupUserRelations] " +
                "where userEmail = @paraUserEmail and groupID = @paraGroupId";

            SqlDataAdapter sqlCheckCmd = new SqlDataAdapter(checkGroupStmt, myConn);

            sqlCheckCmd.SelectCommand.Parameters.AddWithValue("@paraUserEmail", email);
            sqlCheckCmd.SelectCommand.Parameters.AddWithValue("@paraGroupId", groupId);

            DataSet ds = new DataSet();
            sqlCheckCmd.Fill(ds);
            int rec_cnt = ds.Tables[0].Rows.Count;

            if (rec_cnt < 1)
            {
                //Adding To Group
                string sqlStmt = "INSERT INTO [GroupUserRelations] (userEmail, groupID, customOrder) " +
                     "VALUES (@paraEmail, @paraGroupID, @paraOrder)";

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

        public int removeMemberFromGroup(string email, string groupId)
        {
            string DBConnect = ConfigurationManager.ConnectionStrings["ConnStr"].ConnectionString;
            SqlConnection myConn = new SqlConnection(DBConnect);
            int result = 0;

            string checkGroupStmt = "Select * from [GroupUserRelations] " +
                "where userEmail = @paraUserEmail and groupID = @paraGroupId";

            SqlDataAdapter sqlCheckCmd = new SqlDataAdapter(checkGroupStmt, myConn);

            sqlCheckCmd.SelectCommand.Parameters.AddWithValue("@paraUserEmail", email);
            sqlCheckCmd.SelectCommand.Parameters.AddWithValue("@paraGroupId", groupId);

            DataSet ds = new DataSet();
            sqlCheckCmd.Fill(ds);
            int rec_cnt = ds.Tables[0].Rows.Count;

            if (rec_cnt > 0)
            {
              
                string sqlStmt = "Delete from [GroupUserRelations] " +
                     "Where userEmail = @paraEmail and groupID = @paraGroupID";

                // Execute NonQuery return an integer value
                SqlCommand sqlCmd = new SqlCommand(sqlStmt, myConn);

                sqlCmd.Parameters.AddWithValue("@paraEmail", email);
                sqlCmd.Parameters.AddWithValue("@paraGroupID", groupId);


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

        //Miscelaneous Functions

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




    }
}
