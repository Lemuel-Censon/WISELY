using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WISLEY.BLL.Profile;
using WISLEY.BLL.Resources;

namespace WISLEY.Views.Resources
{
    public partial class viewResources : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            resTypeData.SelectCommand = $"SELECT * FROM [grpResourceType] " +
                $"where [grpResourceType].grpId = {Request.QueryString["groupId"]} " +
                $"ORDER BY [grpResourceType].customOrder ASC";

        }

        public BLL.Group.Group getGroupDetails()
        {
            string grpId = Request.QueryString["groupId"];

            BLL.Group.Group grp = new BLL.Group.Group().getGroupByID(grpId);
            return grp;
        }

        //public List<grpResourceType> getDirectories()
        //{

        //    //Get all directories
        //    string folderPath = Server.MapPath("~/Public/uploads/groupResources/") + Request.QueryString["groupId"];
        //    Directory.CreateDirectory(folderPath + "/");


        //    int grpId = int.Parse(Request.QueryString["groupId"]);
        //    List<grpResourceType> grpRsTypes = new BLL.Group.Group().getGroupResourceTypes(grpId);

        //    return grpRsTypes;

        //    //for (int i = 0; i < grpRsTypes.Count; i++)
        //    //{

        //    //}


        //    //    foreach (var d in Directory.GetDirectories(folderPath))
        //    //{
        //    //    //var dir = new DirectoryInfo(d); // Gets directory object 
        //    //    //var dirName = dir.Name; // Gets directory name

        //    //    //List<string> fileNames = new List<string>();



        //    //    //grpResourceType Resource = new grpResourceType(dirName, fileNames);
        //    //    //folderList.Add(Resource);
        //    //}

        //    //return folderList;

        //}

        protected void downloadCommand(object source, RepeaterCommandEventArgs e)
        {
            if (e.CommandName == "Download")
            {
                string[] commandArgs = e.CommandArgument.ToString().Split(new char[] { ',' });
                string folderPath = Server.MapPath("~/Public/uploads/groupResources/") + Request.QueryString["groupId"];

                Response.Clear();
                Response.ContentType = "application/octet-stream";
                Response.AppendHeader("content-disposition", $"filename={commandArgs[1]}");
                Response.TransmitFile(folderPath + "/" + commandArgs[0] + "/" + commandArgs[1]);
            }
        }

        public List<string> getFileNames(string resType)
        {
            List<string> fileNames = new List<string>();
            string folderPath = Server.MapPath("~/Public/uploads/groupResources/") + Request.QueryString["groupId"];

            foreach (string strFile in Directory.GetFiles($"{folderPath}/{resType}"))
            {
                FileInfo fi = new FileInfo(strFile);
                fileNames.Add(fi.Name);

            }

            return fileNames;
        }

        public string getQuery(object cat)
        {
            return "SELECT * FROM [grpResource] WHERE resourceType ='" + cat.ToString() + "'";
        }

        public User user()
        {
            User user = new User().SelectByEmail(Session["email"].ToString());
            return user;
        }
    }


}