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

            string sqlStmt = "INSERT INTO Notification (senderId, receiverId, groupId, postId, datecreated, type)" +
                             "VALUES (@paraSenderID, @paraReceiverID, @paraGroupID, @paraPostID, @paraDatecreate, @paraType)";

            int result = 0;    // Execute NonQuery return an integer value
            SqlCommand sqlCmd = new SqlCommand(sqlStmt, myConn);

            sqlCmd.Parameters.AddWithValue("@paraSenderID", postnotif.senderId);
            sqlCmd.Parameters.AddWithValue("@paraReceiverID", postnotif.receiverId);
            sqlCmd.Parameters.AddWithValue("@paraGroupID", postnotif.groupId);
            sqlCmd.Parameters.AddWithValue("@paraPostID", postnotif.postId);
            sqlCmd.Parameters.AddWithValue("@paraDatecreate", postnotif.datecreated);
            sqlCmd.Parameters.AddWithValue("@paraType", postnotif.type);

            myConn.Open();
            result = sqlCmd.ExecuteNonQuery();

            myConn.Close();

            return result;
        }

        public List<Notify> SelectPostNotif(string userId)
        {
            string DBConnect = ConfigurationManager.ConnectionStrings["ConnStr"].ConnectionString;
            SqlConnection myConn = new SqlConnection(DBConnect);

            string sqlstmt = "SELECT Notification.*, [User].name as sendername, [Group].name, [Post].title FROM (((NOTIFICATION " +
                    "INNER JOIN [User] ON Notification.senderId = [User].Id) " +
                    "INNER JOIN [Group] ON Notification.groupId = [Group].Id) " +
                    "INNER JOIN [Post] ON Notification.postId = [Post].Id) " +
                    "WHERE Notification.receiverId = @paraUserId AND Notification.type = 'post'";
            SqlDataAdapter da = new SqlDataAdapter(sqlstmt, myConn);
            da.SelectCommand.Parameters.AddWithValue("@paraUserId", userId);

            DataSet ds = new DataSet();
            da.Fill(ds);
            int rec_cnt = ds.Tables[0].Rows.Count;

            Notify obj = null;
            List<Notify> notif = new List<Notify>();
            if (rec_cnt > 0)
            {
                for (int i = 0; i < rec_cnt; i++)
                {
                    DataRow row = ds.Tables[0].Rows[i];
                    int senderId = int.Parse(row["senderId"].ToString());
                    int receiverId = int.Parse(row["receiverId"].ToString());
                    string datecreated = row["datecreated"].ToString();
                    string type = row["type"].ToString();
                    int groupId = int.Parse(row["groupId"].ToString());
                    int postId = int.Parse(row["postId"].ToString());
                    string senderName = row["sendername"].ToString();
                    string groupName = row["name"].ToString();
                    string postName = row["title"].ToString();
                    obj = new Notify(senderId, receiverId, datecreated, type, groupId, postId, senderName, groupName, postName);
                    notif.Add(obj);
                }

            }

            return notif;
        }
    }
}