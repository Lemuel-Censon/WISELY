using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using WISLEY.BLL.Notification;

namespace WISLEY.DAL.Notification
{
    public class NotifyDAO
    {
        public int InsertPost(Notify postnotif)
        {
            string DBConnect = ConfigurationManager.ConnectionStrings["ConnStr"].ConnectionString;
            SqlConnection myConn = new SqlConnection(DBConnect);

            string sqlStmt = "INSERT INTO Notification (senderId, receiverId, groupId, postId, datecreated, type, status)" +
                             "VALUES (@paraSenderID, @paraReceiverID, @paraGroupID, @paraPostID, @paraDatecreate, @paraType, @paraStatus)";

            int result = 0;    // Execute NonQuery return an integer value
            SqlCommand sqlCmd = new SqlCommand(sqlStmt, myConn);

            sqlCmd.Parameters.AddWithValue("@paraSenderID", postnotif.senderEmail);
            sqlCmd.Parameters.AddWithValue("@paraReceiverID", postnotif.receiverEmail);
            sqlCmd.Parameters.AddWithValue("@paraGroupID", postnotif.groupId);
            sqlCmd.Parameters.AddWithValue("@paraPostID", postnotif.postId);
            sqlCmd.Parameters.AddWithValue("@paraDatecreate", postnotif.datecreated);
            sqlCmd.Parameters.AddWithValue("@paraType", postnotif.type);
            sqlCmd.Parameters.AddWithValue("@paraStatus", postnotif.status);

            myConn.Open();
            result = sqlCmd.ExecuteNonQuery();

            myConn.Close();

            return result;
        }

        public List<Notify> SelectPostNotif(string userEmail)
        {
            string DBConnect = ConfigurationManager.ConnectionStrings["ConnStr"].ConnectionString;
            SqlConnection myConn = new SqlConnection(DBConnect);

            string sqlstmt = "SELECT Notification.*, [User].name as sendername, [Group].name, [Post].title FROM (((NOTIFICATION " +
                    "INNER JOIN [User] ON Notification.senderId = [User].Email) " +
                    "INNER JOIN [Group] ON Notification.groupId = [Group].Id) " +
                    "INNER JOIN [Post] ON Notification.postId = [Post].Id) " +
                    "WHERE Notification.receiverId = @paraUserId AND Notification.type = 'post' AND Notification.status = ''";
            SqlDataAdapter da = new SqlDataAdapter(sqlstmt, myConn);
            da.SelectCommand.Parameters.AddWithValue("@paraUserId", userEmail);

            DataSet ds = new DataSet();
            da.Fill(ds);
            int rec_cnt = ds.Tables[0].Rows.Count;

            Notify obj = null;
            List<Notify> postnotif = new List<Notify>();
            if (rec_cnt > 0)
            {
                for (int i = 0; i < rec_cnt; i++)
                {
                    DataRow row = ds.Tables[0].Rows[i];
                    string senderId = row["senderId"].ToString();
                    string receiverId = row["receiverId"].ToString();
                    string datecreated = row["datecreated"].ToString();
                    string type = row["type"].ToString();
                    int Id = int.Parse(row["Id"].ToString());
                    int groupId = int.Parse(row["groupId"].ToString());
                    int postId = int.Parse(row["postId"].ToString());
                    string senderName = row["sendername"].ToString();
                    string groupName = row["name"].ToString();
                    string postName = row["title"].ToString();
                    obj = new Notify(senderId, receiverId, datecreated, type, groupId, postId, Id, senderName, groupName, postName);
                    postnotif.Add(obj);
                }

            }

            return postnotif;
        }

        public int InsertInvite(Notify invnotif)
        {
            string DBConnect = ConfigurationManager.ConnectionStrings["ConnStr"].ConnectionString;
            SqlConnection myConn = new SqlConnection(DBConnect);

            string sqlStmt = "INSERT INTO Notification (senderId, receiverId, groupId, datecreated, type, status)" +
                             "VALUES (@paraSenderID, @paraReceiverID, @paraGroupID, @paraDatecreate, @paraType, @paraStatus)";

            int result = 0;    // Execute NonQuery return an integer value
            SqlCommand sqlCmd = new SqlCommand(sqlStmt, myConn);

            sqlCmd.Parameters.AddWithValue("@paraSenderID", invnotif.senderEmail);
            sqlCmd.Parameters.AddWithValue("@paraReceiverID", invnotif.receiverEmail);
            sqlCmd.Parameters.AddWithValue("@paraGroupID", invnotif.groupId);
            sqlCmd.Parameters.AddWithValue("@paraDatecreate", invnotif.datecreated);
            sqlCmd.Parameters.AddWithValue("@paraType", invnotif.type);
            sqlCmd.Parameters.AddWithValue("@paraStatus", invnotif.status);

            myConn.Open();
            result = sqlCmd.ExecuteNonQuery();

            myConn.Close();

            return result;
        }

        public List<Notify> SelectInvNotif(string userEmail)
        {
            string DBConnect = ConfigurationManager.ConnectionStrings["ConnStr"].ConnectionString;
            SqlConnection myConn = new SqlConnection(DBConnect);

            string sqlstmt = "SELECT Notification.*, [User].name as sendername, [Group].name FROM ((NOTIFICATION " +
                    "INNER JOIN [User] ON Notification.senderId = [User].Email) " +
                    "INNER JOIN [Group] ON Notification.groupId = [Group].Id) " +
                    "WHERE Notification.receiverId = @paraUserId AND Notification.type = 'invite' AND Notification.status = ''";
            SqlDataAdapter da = new SqlDataAdapter(sqlstmt, myConn);
            da.SelectCommand.Parameters.AddWithValue("@paraUserId", userEmail);

            DataSet ds = new DataSet();
            da.Fill(ds);
            int rec_cnt = ds.Tables[0].Rows.Count;

            Notify obj = null;
            List<Notify> invnotif = new List<Notify>();
            if (rec_cnt > 0)
            {
                for (int i = 0; i < rec_cnt; i++)
                {
                    DataRow row = ds.Tables[0].Rows[i];
                    string senderId = row["senderId"].ToString();
                    string receiverId = row["receiverId"].ToString();
                    string datecreated = row["datecreated"].ToString();
                    string type = row["type"].ToString();
                    int Id = int.Parse(row["Id"].ToString());
                    int groupId = int.Parse(row["groupId"].ToString());
                    string senderName = row["sendername"].ToString();
                    string groupName = row["name"].ToString();
                    obj = new Notify(senderId, receiverId, datecreated, type, groupId, -1, Id, senderName, groupName);
                    invnotif.Add(obj);
                }

            }

            return invnotif;
        }

        public List<Notify> SelectCommNotif(string userEmail)
        {
            string DBConnect = ConfigurationManager.ConnectionStrings["ConnStr"].ConnectionString;
            SqlConnection myConn = new SqlConnection(DBConnect);

            string sqlstmt = "SELECT Notification.*, [User].name as sendername, [Group].name, [Post].title FROM (((NOTIFICATION " +
                    "INNER JOIN [User] ON Notification.senderId = [User].Email) " +
                    "INNER JOIN [Group] ON Notification.groupId = [Group].Id) " +
                    "INNER JOIN [Post] ON Notification.postId = [Post].Id) " +
                    "WHERE Notification.receiverId = @paraUserId AND Notification.type = 'comment' AND Notification.status = ''";
            SqlDataAdapter da = new SqlDataAdapter(sqlstmt, myConn);
            da.SelectCommand.Parameters.AddWithValue("@paraUserId", userEmail);

            DataSet ds = new DataSet();
            da.Fill(ds);
            int rec_cnt = ds.Tables[0].Rows.Count;

            Notify obj = null;
            List<Notify> commnotif = new List<Notify>();
            if (rec_cnt > 0)
            {
                for (int i = 0; i < rec_cnt; i++)
                {
                    DataRow row = ds.Tables[0].Rows[i];
                    string senderId = row["senderId"].ToString();
                    string receiverId = row["receiverId"].ToString();
                    string datecreated = row["datecreated"].ToString();
                    string type = row["type"].ToString();
                    int Id = int.Parse(row["Id"].ToString());
                    int groupId = int.Parse(row["groupId"].ToString());
                    int postId = int.Parse(row["postId"].ToString());
                    string senderName = row["sendername"].ToString();
                    string groupName = row["name"].ToString();
                    string postName = row["title"].ToString();
                    obj = new Notify(senderId, receiverId, datecreated, type, groupId, postId, Id, senderName, groupName, postName);
                    commnotif.Add(obj);
                }

            }

            return commnotif;
        }

        public int ClearNotifs(string notifId)
        {
            string DBConnect = ConfigurationManager.ConnectionStrings["ConnStr"].ConnectionString;
            SqlConnection myConn = new SqlConnection(DBConnect);

            string sqlStmt = "UPDATE Notification " +
                "SET status = 'cleared' " +
                "WHERE Id = @paraNotifID";

            int result = 0;    // Execute NonQuery return an integer value
            SqlCommand sqlCmd = new SqlCommand(sqlStmt, myConn);

            sqlCmd.Parameters.AddWithValue("@paraNotifID", notifId);

            myConn.Open();
            result = sqlCmd.ExecuteNonQuery();

            myConn.Close();

            return result;
        }

        public int ClearDeletedPostNotifs(string postId)
        {
            string DBConnect = ConfigurationManager.ConnectionStrings["ConnStr"].ConnectionString;
            SqlConnection myConn = new SqlConnection(DBConnect);

            string sqlStmt = "UPDATE Notification " +
                "SET status = 'cleared' " +
                "WHERE postId = @paraPostID";

            int result = 0;    // Execute NonQuery return an integer value
            SqlCommand sqlCmd = new SqlCommand(sqlStmt, myConn);

            sqlCmd.Parameters.AddWithValue("@paraPostID", postId);

            myConn.Open();
            result = sqlCmd.ExecuteNonQuery();

            myConn.Close();

            return result;
        }

        public int UserNotifCount(string userEmail)
        {
            string DBConnect = ConfigurationManager.ConnectionStrings["ConnStr"].ConnectionString;
            SqlConnection myConn = new SqlConnection(DBConnect);

            string sqlstmt = "Select * from Notification where receiverId = @paraReceiverID AND status = ''";
            SqlDataAdapter da = new SqlDataAdapter(sqlstmt, myConn);
            da.SelectCommand.Parameters.AddWithValue("@paraReceiverID", userEmail);

            DataSet ds = new DataSet();
            da.Fill(ds);
            int rec_cnt = ds.Tables[0].Rows.Count;
            int notifcount = 0;

            if (rec_cnt > 0)
            {
                for (int i = 0; i < rec_cnt; i++)
                {
                    notifcount++;
                }
            }

            return notifcount;
        }
    }
}