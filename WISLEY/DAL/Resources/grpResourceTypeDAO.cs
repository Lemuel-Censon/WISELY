using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using WISLEY.BLL.Resources;

namespace WISLEY.DAL.Resources
{
    public class grpResourceTypeDAO
    {
        public int Insert(grpResourceType resourceType)
        {
            int result = 0;

            if (SelectGroupResTypeByAttribute("resourceType", resourceType.resourceType, resourceType.grpId) == null)
            {
                string DBConnect = ConfigurationManager.ConnectionStrings["ConnStr"].ConnectionString;
                SqlConnection myConn = new SqlConnection(DBConnect);

                //Creating Group
                string sqlStmt = "INSERT INTO [grpResourceType] (resourceType, grpId, customOrder, dateUploaded, visibility)" +
                     "VALUES (@parResourceType, @paraGrpId, @paraCustomOrder, @paraDateUploaded, @paraVisibility)";

                // Execute NonQuery return an integer value
                SqlCommand sqlCmd = new SqlCommand(sqlStmt, myConn);

                sqlCmd.Parameters.AddWithValue("@parResourceType", resourceType.resourceType);
                sqlCmd.Parameters.AddWithValue("@paraGrpId", resourceType.grpId);
                sqlCmd.Parameters.AddWithValue("@paraCustomOrder", resourceType.customOrder);
                sqlCmd.Parameters.AddWithValue("@paraDateUploaded", resourceType.dateCreated);
                sqlCmd.Parameters.AddWithValue("@paraVisibility", resourceType.visibility);


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

        public grpResourceType SelectGroupResTypeByAttribute(string attribute, string data, int grpId)
        {
            string DBConnect = ConfigurationManager.ConnectionStrings["ConnStr"].ConnectionString;
            SqlConnection myConn = new SqlConnection(DBConnect);

            string sqlstmt = "Select * from [grpResourceType] where " + attribute + " = @paraData and grpId = @paraGrpId";
            SqlDataAdapter da = new SqlDataAdapter(sqlstmt, myConn);
            da.SelectCommand.Parameters.AddWithValue("@paraData", data);
            da.SelectCommand.Parameters.AddWithValue("@paraGrpId", grpId);


            DataSet ds = new DataSet();
            da.Fill(ds);
            int rec_cnt = ds.Tables[0].Rows.Count;

            grpResourceType obj = null;

            if (rec_cnt > 0)
            {
                DataRow row = ds.Tables[0].Rows[0];
                string resourceType = row["resourceType"].ToString();
                //int grpId = int.Parse(row["grpId"].ToString());
                int customOrder = int.Parse(row["customOrder"].ToString());
                DateTime dateUploaded = DateTime.Parse(row["dateUploaded"].ToString());
                int visibility = int.Parse(row["visibility"].ToString());
                int id = int.Parse(row["Id"].ToString());
                obj = new grpResourceType(resourceType, grpId, customOrder, dateUploaded, visibility, id);

            }
            return obj;
        }


        public List<grpResourceType> GetGrpResourceTypes(int grpId)
        {
            string DBConnect = ConfigurationManager.ConnectionStrings["ConnStr"].ConnectionString;
            SqlConnection myConn = new SqlConnection(DBConnect);

            string sqlstmt = "Select * from [grpResourceType] where grpId = @paraGrpId";
            SqlDataAdapter da = new SqlDataAdapter(sqlstmt, myConn);

            da.SelectCommand.Parameters.AddWithValue("@paraGrpId", grpId);

            DataSet ds = new DataSet();
            da.Fill(ds);
            int rec_cnt = ds.Tables[0].Rows.Count;

            List<grpResourceType> RsTypeList = new List<grpResourceType>();

            if (rec_cnt > 0)
            {
                for (int i = 0; i < rec_cnt; i++)
                {

                    grpResourceType obj = null;

                    DataRow row = ds.Tables[0].Rows[i];
                    string resourceType = row["resourceType"].ToString();
                    //int grpId = int.Parse(row["grpId"].ToString());
                    int customOrder = int.Parse(row["customOrder"].ToString());
                    DateTime dateUploaded = DateTime.Parse(row["dateUploaded"].ToString());
                    int visibility = int.Parse(row["visibility"].ToString());
                    int id = int.Parse(row["Id"].ToString());
                    obj = new grpResourceType(resourceType, grpId, customOrder, dateUploaded, visibility, id);

                    RsTypeList.Add(obj);
                }

            }
            return RsTypeList;
        }



        public int getLatestOrder(int grpId, string resourceType)
        {
            string DBConnect = ConfigurationManager.ConnectionStrings["ConnStr"].ConnectionString;
            SqlConnection myConn = new SqlConnection(DBConnect);

            string sqlstmt = "Select customOrder from [grpResourceType] where grpId = @paraGrpId and resourceType = @paraResourceType ORDER BY customOrder DESC";
            SqlDataAdapter da = new SqlDataAdapter(sqlstmt, myConn);

            da.SelectCommand.Parameters.AddWithValue("@paraGrpId", grpId);
            da.SelectCommand.Parameters.AddWithValue("@paraResourceType", resourceType);

            DataSet ds = new DataSet();
            da.Fill(ds);

            int rec_cnt = ds.Tables[0].Rows.Count;

            int latestOrder = 0;
            if (rec_cnt > 0)
            {
                DataRow row = ds.Tables[0].Rows[0];
                latestOrder = int.Parse(row["customOrder"].ToString());
            }

            return latestOrder;
        }
    }

}