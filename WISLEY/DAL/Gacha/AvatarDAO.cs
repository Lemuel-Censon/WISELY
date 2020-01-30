using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using WISLEY.BLL.Profile;
using WISLEY.BLL.Gacha;
using WISLEY.DAL.Profile;

namespace WISLEY.DAL.Gacha
{
    public class AvatarDAO
    {
        public int Update(string avatarID, string acquired, string src)
        {
            string DBConnect = ConfigurationManager.ConnectionStrings["ConnStr"].ConnectionString;
            SqlConnection myConn = new SqlConnection(DBConnect);

            string sqlStmt = "UPDATE [Avatar] " +
                "SET acquired = @paraAcquired " +
                "WHERE Id = @paraAvatarID";

            int result = 0;    // Execute NonQuery return an integer value
            SqlCommand sqlCmd = new SqlCommand(sqlStmt, myConn);

            sqlCmd.Parameters.AddWithValue("@paraAcquired", acquired);
            sqlCmd.Parameters.AddWithValue("@paraAvatarID", avatarID);
            sqlCmd.Parameters.AddWithValue("@paraSrc", src);

            myConn.Open();
            result = sqlCmd.ExecuteNonQuery();

            myConn.Close();

            return result;
        }

        public Avatar SelectAvatarByID(int id)
        {
            string DBConnect = ConfigurationManager.ConnectionStrings["ConnStr"].ConnectionString;
            SqlConnection myConn = new SqlConnection(DBConnect);

            string sqlstmt = "Select * from [Avatar] where avatarID = @paraAvatarID";
            SqlDataAdapter da = new SqlDataAdapter(sqlstmt, myConn);
            da.SelectCommand.Parameters.AddWithValue("@paraAvatarID", id);

            DataSet ds = new DataSet();
            da.Fill(ds);
            int rec_cnt = ds.Tables[0].Rows.Count;

            Avatar obj = null;
            if (rec_cnt > 0)
            {
                DataRow row = ds.Tables[0].Rows[0];
                int avatarId = int.Parse(row["avatarID"].ToString());
                string acquired = row["acquired"].ToString();
                string src = row["src"].ToString();
                string rarity = row["rarity"].ToString();
                string userId = row["userId"].ToString();

                obj = new Avatar(acquired, src, rarity, userId, avatarId);
            }

            return obj;
        }

        public List<Avatar> SelectByUser(int userId)
        {
            string DBConnect = ConfigurationManager.ConnectionStrings["ConnStr"].ConnectionString;
            SqlConnection myConn = new SqlConnection(DBConnect);

            string sqlstmt = "Select * from [Avatar] where userId = @paraUserID";
            SqlDataAdapter da = new SqlDataAdapter(sqlstmt, myConn);
            da.SelectCommand.Parameters.AddWithValue("@paraUserID", userId);

            DataSet ds = new DataSet();
            da.Fill(ds);
            int rec_cnt = ds.Tables[0].Rows.Count;

            Avatar obj = null;
            List<Avatar> useravatar = new List<Avatar>();
            if (rec_cnt > 0)
            {
                DataRow row = ds.Tables[0].Rows[0];
                int avatarId = int.Parse(row["avatarID"].ToString());
                string acquired = row["acquired"].ToString();
                string src = row["src"].ToString();
                string rarity = row["rarity"].ToString();

                obj = new Avatar(acquired, src, rarity, userId.ToString(), avatarId);
                useravatar.Add(obj);
            }

            return useravatar;
        }

        public int UpdateAcquired(string acquired, string id)
        {
            string DBConnect = ConfigurationManager.ConnectionStrings["ConnStr"].ConnectionString;
            SqlConnection myConn = new SqlConnection(DBConnect);

            string sqlStmt = "UPDATE [Avatar] " +
                "SET acquired = @paraAcquired " +
                "WHERE id = @paraAvatarId";

            int result = 0;    // Execute NonQuery return an integer value
            SqlCommand sqlCmd = new SqlCommand(sqlStmt, myConn);

            sqlCmd.Parameters.AddWithValue("@paraAcquired", acquired);
            sqlCmd.Parameters.AddWithValue("@paraAvatarId", id);

            myConn.Open();
            result = sqlCmd.ExecuteNonQuery();

            myConn.Close();

            return result;
        }

    }
}