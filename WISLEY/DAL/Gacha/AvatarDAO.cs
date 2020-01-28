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
        public int Update(int avatarID, string acquired, string src)
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

        public Avatar SelectAvatarByID(string id)
        {
            string DBConnect = ConfigurationManager.ConnectionStrings["ConnStr"].ConnectionString;
            SqlConnection myConn = new SqlConnection(DBConnect);

            string sqlstmt = "Select * from [Avatar] where Id = @paraAvatarID";
            SqlDataAdapter da = new SqlDataAdapter(sqlstmt, myConn);
            da.SelectCommand.Parameters.AddWithValue("@paraAvatarID", id);

            DataSet ds = new DataSet();
            da.Fill(ds);
            int rec_cnt = ds.Tables[0].Rows.Count;

            Avatar obj = null;
            if (rec_cnt > 0)
            {
                DataRow row = ds.Tables[0].Rows[0];
                int avatarId = int.Parse(row["avatarId"].ToString());
                string acquired = row["acquired"].ToString();
                string src = row["src"].ToString();

                obj = new Avatar(avatarId);
            }

            return obj;
        }

        public int UpdateAcquired(string acquired, int id)
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