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
    public class grpResourceDAO
    {
        public int Insert(grpResource resource)
        {
            int result = 0;

            string DBConnect = ConfigurationManager.ConnectionStrings["ConnStr"].ConnectionString;
            SqlConnection myConn = new SqlConnection(DBConnect);

            //Creating Group
            string sqlStmt = "INSERT INTO [grpResource] (fileName, resourceType, grpId, customOrder, dateUploaded)" +
                 "VALUES (@paraFileName, @parResourceType, @paraGrpId, @paraCustomOrder, @paraDateUploaded)";

            // Execute NonQuery return an integer value
            SqlCommand sqlCmd = new SqlCommand(sqlStmt, myConn);

            sqlCmd.Parameters.AddWithValue("@paraFileName", resource.fileName);
            sqlCmd.Parameters.AddWithValue("@parResourceType", resource.resourceType);
            sqlCmd.Parameters.AddWithValue("@paraGrpId", resource.grpId);
            sqlCmd.Parameters.AddWithValue("@paraCustomOrder", resource.customOrder);
            sqlCmd.Parameters.AddWithValue("@paraDateUploaded", resource.dateUploaded);


            myConn.Open();
            result = sqlCmd.ExecuteNonQuery(); //Result 
            myConn.Close();

            return result;
        }

        public int deleteResource(string grpId, string resourceType, string fileName)
        {
            int result = 0;
            string DBConnect = ConfigurationManager.ConnectionStrings["ConnStr"].ConnectionString;
            SqlConnection myConn = new SqlConnection(DBConnect);

            string checkFileStmt = "Select * from [grpResource] " +
            "where grpId = @paraGroupId and resourceType = @paraType and fileName = @paraName";

            SqlDataAdapter sqlCheckCmd = new SqlDataAdapter(checkFileStmt, myConn);

            sqlCheckCmd.SelectCommand.Parameters.AddWithValue("@paraGroupId", grpId);
            sqlCheckCmd.SelectCommand.Parameters.AddWithValue("@paraType", resourceType);
            sqlCheckCmd.SelectCommand.Parameters.AddWithValue("@paraName", fileName);


            DataSet ds = new DataSet();
            sqlCheckCmd.Fill(ds);
            int rec_cnt = ds.Tables[0].Rows.Count;

            if (rec_cnt > 0)
            {
                //Adding To Group
                string sqlStmt = "Delete from [grpResource] " +
                     "where grpId = @paraGroupId and resourceType = @paraType and fileName = @paraName";

                // Execute NonQuery return an integer value
                SqlCommand sqlCmd = new SqlCommand(sqlStmt, myConn);

                sqlCmd.Parameters.AddWithValue("@paraGroupId", grpId);
                sqlCmd.Parameters.AddWithValue("@paraType", resourceType);
                sqlCmd.Parameters.AddWithValue("@paraName", fileName);


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

        public int getLatestOrder(int grpId, string resourceType)
        {
            string DBConnect = ConfigurationManager.ConnectionStrings["ConnStr"].ConnectionString;
            SqlConnection myConn = new SqlConnection(DBConnect);

            string sqlstmt = "Select customOrder from [grpResource] where grpId = @paraGrpId and resourceType = @paraResourceType ORDER BY customOrder DESC";
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