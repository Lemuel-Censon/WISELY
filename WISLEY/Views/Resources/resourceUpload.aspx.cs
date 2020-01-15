using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WISLEY.Views.Resources
{
    public partial class resourceUpload : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["email"] != null)
            {
                User user = new User().SelectByEmail(Session["email"].ToString());

                if (user.userType != "Teacher")
                {
                    Session["error"] = "You must be a teacher to edit a group!";
                    Response.Redirect(Page.ResolveUrl("~/Views/Profile/profile.aspx"));
                }
            }
            else
            {
                Session["error"] = "You must be logged in to edit a group!";
                Response.Redirect(Page.ResolveUrl("~/Views/Auth/login.aspx"));
            }
        }

        public void toast(Page page, string message, string title, string type)
        {
            ScriptManager.RegisterClientScriptBlock(page, page.GetType(), "toastmsg", "toastnotif('" + message + "','" + title + "','" + type.ToLower() + "');", true);
        }

        protected void uploadResource(object sender, EventArgs e)
        {
            if (resourceUploadControl.HasFile)
            {
                try
                {
                    string filename = Path.GetFileName(resourceUploadControl.FileName);
                    resourceUploadControl.SaveAs(Server.MapPath("~/") + filename);
                    Session["success"] = "Resources uploaded successfully!";

                }
                catch (Exception ex)
                {
                    toast(this, ("Upload status: The file could not be uploaded. The following error occured: " + ex.Message), "Error", "error");

                }
            }
        }


    }
}