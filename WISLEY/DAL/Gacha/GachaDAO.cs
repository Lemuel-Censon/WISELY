using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using WISLEY.BLL.Gacha;

namespace WISLEY.DAL.Gacha
{
    public class GachaDAO
    {

        public List<BLL.Gacha.Gacha> SelectAll()
        {
            string DBConnect = ConfigurationManager.ConnectionStrings["ConnStr"].ConnectionString;
            SqlConnection myConn = new SqlConnection(DBConnect);

            string sqlstmt = "Select * from [Gacha]";
            SqlDataAdapter da = new SqlDataAdapter(sqlstmt, myConn);

            DataSet ds = new DataSet();
            da.Fill(ds);
            int rec_cnt = ds.Tables[0].Rows.Count;

            BLL.Gacha.Gacha obj = null;
            List<BLL.Gacha.Gacha> allgachas = new List<BLL.Gacha.Gacha>();
            if (rec_cnt > 0)
            {
                DataRow row = ds.Tables[0].Rows[0];
                int id = int.Parse(row["Id"].ToString());
                string src = row["src"].ToString();
                string rarity = row["rarity"].ToString();

                obj = new BLL.Gacha.Gacha(src, rarity, id);
                allgachas.Add(obj);
            }

            return allgachas;
        }

        public BLL.Gacha.Gacha SelectByID(int id)
        {
            string DBConnect = ConfigurationManager.ConnectionStrings["ConnStr"].ConnectionString;
            SqlConnection myConn = new SqlConnection(DBConnect);

            string sqlstmt = "Select * from [Gacha] where Id = @paraGachaID";
            SqlDataAdapter da = new SqlDataAdapter(sqlstmt, myConn);
            da.SelectCommand.Parameters.AddWithValue("@paraGachaID", id);

            DataSet ds = new DataSet();
            da.Fill(ds);
            int rec_cnt = ds.Tables[0].Rows.Count;

            BLL.Gacha.Gacha obj = null;
            if (rec_cnt > 0)
            {
                DataRow row = ds.Tables[0].Rows[0];
                string src = row["src"].ToString();
                string rarity = row["rarity"].ToString();

                obj = new BLL.Gacha.Gacha(src, rarity, id);
            }

            return obj;
        }
    }
}