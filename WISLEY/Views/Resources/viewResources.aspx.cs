using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WISLEY.Views.Resources
{
    public partial class viewResources : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            getDirectories();
        }

        public BLL.Group.Group getGroupDetails()
        {
            string grpId = Request.QueryString["groupId"];

            BLL.Group.Group grp = new BLL.Group.Group().getGroupByID(grpId);
            return grp;
        }

        public void getDirectories()
        {
            System.Diagnostics.Debug.WriteLine("in GetDirectories");

            string folderPath = Server.MapPath("~/Public/uploads/groupResources/") + Request.QueryString["groupId"];
            Directory.CreateDirectory(folderPath + "/");

            foreach (var d in Directory.GetDirectories(folderPath))
            {
                var dir = new DirectoryInfo(d);
                var dirName = dir.Name;

                System.Diagnostics.Debug.WriteLine("dir: " + dirName);
            }


        }
    }


}