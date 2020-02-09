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
    public partial class viewResourceDetails : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["email"] != null)
            {
                if (Request.QueryString["groupId"] != null && !isGroupMember(user().email))
                {
                    Session["error"] = "You are not a member of this group.";
                    Response.Redirect(Page.ResolveUrl("~/Views/Board/collab.aspx"));
                }
                else
                {
                    FileInfo fi = getFileInfo();
                    string fileExtension = fi.Extension;

                    if (fileExtension == ".pdf")
                    {
                        PDFiframe.Attributes.Add("src", Page.ResolveUrl(getFilePath()));
                    }
                    else if (getFileInfo().Extension == ".png" || getFileInfo().Extension == ".gif" || getFileInfo().Extension == ".jpg" || getFileInfo().Extension == ".jpeg")
                    {
                        imgHolder.Attributes.Add("src", Page.ResolveUrl(getFilePath()));

                    }
                    else
                    {
                        fileImg.Attributes.Add("src", Page.ResolveUrl("~/Public/img/fileIcon.png"));
                    }
                }
            }
            else
            {
                Session["error"] = "Please log in.";
                Response.Redirect(Page.ResolveUrl("~/Views/index.aspx"));
            }




        }

        public void toast(Page page, string message, string title, string type)
        {
            ScriptManager.RegisterClientScriptBlock(page, page.GetType(), "toastmsg", "toastnotif('" + message + "','" + title + "','" + type.ToLower() + "');", true);
        }

        public FileInfo getFileInfo()
        {

            FileInfo fi = new FileInfo(getFilePath());

            return fi;
        }

        public string getFilePath()
        {
            string grpId = Request.QueryString["groupId"];
            string resourceType = Request.QueryString["resourceType"];
            string fileName = Request.QueryString["fileName"];

            string filePath = $"~/Public/uploads/groupResources/{grpId}/{resourceType}/{fileName}";
            return filePath;
        }

        public void backToResource(object sender, EventArgs e)
        {
            string grpId = Request.QueryString["groupId"];
            Response.Redirect("~/Views/Resources/viewResources.aspx?groupId=" + grpId);
        }

        public void downloadResource(object sender, EventArgs e)
        {
            string grpId = Request.QueryString["groupId"];
            string resourceType = Request.QueryString["resourceType"];
            string fileName = Request.QueryString["fileName"];

            string folderPath = Server.MapPath("~/Public/uploads/groupResources/") + grpId;


            Response.Clear();
            Response.ContentType = "application/octet-stream";
            Response.AppendHeader("content-disposition", $"filename={fileName}");
            Response.TransmitFile(folderPath + "/" + resourceType + "/" + fileName);
        }

        public void deleteResource(object sender, EventArgs e)
        {
            string grpId = Request.QueryString["groupId"];
            string resourceType = Request.QueryString["resourceType"];
            string fileName = Request.QueryString["fileName"];

            string folderPath = Server.MapPath($"~/Public/uploads/groupResources/{grpId}/{resourceType}/{fileName}");

            if (File.Exists(folderPath))
            {
                File.Delete(folderPath);
                grpResource grpRes = new grpResource();
                int result = grpRes.deleteResource(grpId, resourceType, fileName);
                if(result == 1)
                {
                    Session["success"] = "File Successfully deleted!";
                    Response.Redirect("~/Views/Resources/viewResources.aspx?groupId=" + grpId);
                }
                else
                {
                    toast(this, "File deletion error!", "Error", "error");
                    Response.Redirect("~/Views/Resources/viewResources.aspx?groupId=" + grpId);

                }
            }
            else
            {
                toast(this, "File does not exist!", "Error", "error");
                System.Diagnostics.Debug.WriteLine("File already exists!");
            }
        }




        public BLL.Group.Group getGroupDetails()
        {
            string grpId = Request.QueryString["groupId"];

            BLL.Group.Group grp = new BLL.Group.Group().getGroupByID(grpId);
            return grp;
        }

        public bool isGroupMember(string email)
        {
            BLL.Group.Group grp = new BLL.Group.Group();
            List<BLL.Group.Group> grpList = grp.getGroupsJoined(email);
            bool isMember = false;
            for (int i = 0; i < grpList.Count; i++)
            {
                if (grpList[i].id == int.Parse(Request.QueryString["groupId"]))
                {
                    isMember = true;
                }
            }
            return isMember;
        }

        public User user()
        {
            User user = new User().SelectByEmail(Session["email"].ToString());
            return user;
        }
    }
}