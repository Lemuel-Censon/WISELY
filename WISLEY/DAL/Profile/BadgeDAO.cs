using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using WISLEY.BLL.User;

namespace WISLEY.DAL.Profile
{
    public class BadgeDAO
    {
        public int Insert(Badge badge)
        {
            string DBConnect = ConfigurationManager.ConnectionStrings["ConnStr"].ConnectionString;
            SqlConnection myConn = new SqlConnection(DBConnect);
            string sqlStmt = "INSERT INTO Badge (badgeId, userId, src, alt, requirement, points, dateachieved, status)" +
                             "VALUES (@paraBadgeID, @paraUserID, @paraSrc, @paraAlt, @paraRequirement, @paraPoints, @paraDateachieved, @paraStatus)";

            int result = 0;    // Execute NonQuery return an integer value
            SqlCommand sqlCmd = new SqlCommand(sqlStmt, myConn);

            sqlCmd.Parameters.AddWithValue("@paraBadgeID", badge.badgeId);
            sqlCmd.Parameters.AddWithValue("@paraUserID", badge.userId);
            sqlCmd.Parameters.AddWithValue("@paraSrc", badge.src);
            sqlCmd.Parameters.AddWithValue("@paraAlt", badge.alt);
            sqlCmd.Parameters.AddWithValue("@paraRequirement", badge.requirement);
            sqlCmd.Parameters.AddWithValue("@paraPoints", badge.points);
            sqlCmd.Parameters.AddWithValue("@paraDateachieved", badge.dateachieved);
            sqlCmd.Parameters.AddWithValue("@paraStatus", badge.status);

            myConn.Open();
            result = sqlCmd.ExecuteNonQuery();

            myConn.Close();

            return result;
        }

        public Badge SelectByBadgeId(string userId, int badgeId)
        {
            string DBConnect = ConfigurationManager.ConnectionStrings["ConnStr"].ConnectionString;
            SqlConnection myConn = new SqlConnection(DBConnect);

            string sqlstmt = "Select * from Badge where userId = @paraUserID and badgeId = @paraBadgeID";
            SqlDataAdapter da = new SqlDataAdapter(sqlstmt, myConn);
            da.SelectCommand.Parameters.AddWithValue("@paraUserID", userId);
            da.SelectCommand.Parameters.AddWithValue("@paraBadgeID", badgeId);

            DataSet ds = new DataSet();
            da.Fill(ds);
            int rec_cnt = ds.Tables[0].Rows.Count;

            Badge obj = null;
            if (rec_cnt > 0)
            {
                DataRow row = ds.Tables[0].Rows[0];
                int badgeID = int.Parse(row["badgeId"].ToString());
                string userID = row["userId"].ToString();
                string src = row["src"].ToString();
                string alt = row["alt"].ToString();
                string requirement = row["requirement"].ToString();
                int points = int.Parse(row["points"].ToString());
                string dateachieved = row["dateachieved"].ToString();
                string badge_status = row["status"].ToString();

                obj = new Badge(badgeID, userID, src, alt, requirement, points, dateachieved, badge_status);
            }

            return obj;
        }

        public List<Badge> SelectByUserId(string userId, string status)
        {
            string DBConnect = ConfigurationManager.ConnectionStrings["ConnStr"].ConnectionString;
            SqlConnection myConn = new SqlConnection(DBConnect);

            string sqlstmt = "Select * from Badge where userId = @paraUserID and status = @paraStatus";
            SqlDataAdapter da = new SqlDataAdapter(sqlstmt, myConn);
            da.SelectCommand.Parameters.AddWithValue("@paraUserID", userId);
            da.SelectCommand.Parameters.AddWithValue("@paraStatus", status);

            DataSet ds = new DataSet();
            da.Fill(ds);
            int rec_cnt = ds.Tables[0].Rows.Count;

            Badge obj = null;
            List<Badge> userbadgelist = new List<Badge>();
            if (rec_cnt > 0)
            {
                for (int i = 0; i < rec_cnt; i++)
                {
                    DataRow row = ds.Tables[0].Rows[i];
                    int badgeID = int.Parse(row["badgeId"].ToString());
                    string userID = row["userId"].ToString();
                    string src = row["src"].ToString();
                    string alt = row["alt"].ToString();
                    string requirement = row["requirement"].ToString();
                    int points = int.Parse(row["points"].ToString());
                    string dateachieved = row["dateachieved"].ToString();
                    string badge_status = row["status"].ToString();

                    obj = new Badge(badgeID, userID, src, alt, requirement, points, dateachieved, badge_status);
                    userbadgelist.Add(obj);
                }
            }

            return userbadgelist;
        }

        public int GetBadgeCount(string userId, string status)
        {
            string DBConnect = ConfigurationManager.ConnectionStrings["ConnStr"].ConnectionString;
            SqlConnection myConn = new SqlConnection(DBConnect);

            string sqlstmt = "Select * from Badge where userId = @paraUserID and status = @paraStatus";
            SqlDataAdapter da = new SqlDataAdapter(sqlstmt, myConn);
            da.SelectCommand.Parameters.AddWithValue("@paraUserID", userId);
            da.SelectCommand.Parameters.AddWithValue("@paraStatus", status);

            DataSet ds = new DataSet();
            da.Fill(ds);
            int rec_cnt = ds.Tables[0].Rows.Count;
            return rec_cnt;
        }

        public int UpdateBadge(string userId, int badgeId, string dateachieved, string status)
        {
            string DBConnect = ConfigurationManager.ConnectionStrings["ConnStr"].ConnectionString;
            SqlConnection myConn = new SqlConnection(DBConnect);
            string sqlstmt = "Update Badge Set dateachieved = @paraDateachieved, status = @paraStatus where userId = @paraUserID and badgeId = @paraBadgeID";

            int result = 0;    // Execute NonQuery return an integer value
            SqlCommand sqlCmd = new SqlCommand(sqlstmt, myConn);

            sqlCmd.Parameters.AddWithValue("@paraDateachieved", dateachieved);
            sqlCmd.Parameters.AddWithValue("@paraStatus", status);
            sqlCmd.Parameters.AddWithValue("@paraUserID", userId);
            sqlCmd.Parameters.AddWithValue("@paraBadgeID", badgeId);

            myConn.Open();
            result = sqlCmd.ExecuteNonQuery();

            myConn.Close();

            return result;
        }

        public int GetLastID()
        {
            string DBConnect = ConfigurationManager.ConnectionStrings["ConnStr"].ConnectionString;
            SqlConnection myConn = new SqlConnection(DBConnect);

            string sqlstmt = "Select MAX(Id) as LastID from Badge";
            SqlDataAdapter da = new SqlDataAdapter(sqlstmt, myConn);

            DataSet ds = new DataSet();
            da.Fill(ds);
            int rec_cnt = ds.Tables[0].Rows.Count;
            int lastID = 1;

            if (rec_cnt > 0)
            {
                DataRow row = ds.Tables[0].Rows[0];

                lastID = int.Parse(row["LastID"].ToString());

            }

            return lastID;
        }
    }
}