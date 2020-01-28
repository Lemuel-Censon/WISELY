using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WISLEY.BLL.Profile;

namespace WISLEY.Views.Profile
{
    public partial class settings : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["email"] != null)
            {
                if (!Page.IsPostBack)
                {
                    User user = new User().SelectByEmail(Session["email"].ToString());
                    if (user.privacy == "T")
                    {
                        chkBoxPrivacy.Checked = true;
                    }
                    else
                    {
                        chkBoxPrivacy.Checked = false;
                    }
                    if (user.notification == "T")
                    {
                        chkBoxNotification.Checked = true;
                    }
                    else
                    {
                        chkBoxNotification.Checked = false;
                    }
                }
            }
            else
            {
                Session["error"] = "You must be logged in to view settings!";
                Response.Redirect(Page.ResolveUrl("~/Views/index.aspx"));
            }
        }

        public void toast(Page page, string message, string title, string type)
        {
            page.ClientScript.RegisterStartupScript(page.GetType(), "toastmsg", "toastnotif('" + message + "','" + title + "','" + type.ToLower() + "');", true);
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            string email;
            string privacy;
            string notification;
            if (chkBoxPrivacy.Checked == true)
            {
                email = Session["email"].ToString();
                privacy = "T";
                User user = new User();
                int result = user.UpdatePrivacy(email, privacy);
                if (result == 1)
                {
                    Session["success"] = "Your changes have been saved!";
                    Response.Redirect(Page.ResolveUrl("~/Views/Profile/profile.aspx"));
                }
            }
            if (chkBoxPrivacy.Checked == false)
            {
                email = Session["email"].ToString();
                privacy = "F";
                User user = new User();
                int result = user.UpdatePrivacy(email, privacy);
                if (result == 1)
                {
                    Session["success"] = "Your changes have been saved!";
                    Response.Redirect(Page.ResolveUrl("~/Views/Profile/profile.aspx"));
                }
            }
            if (chkBoxNotification.Checked == true)
            {
                email = Session["email"].ToString();
                notification = "T";
                User user = new User();
                int result = user.UpdateNotification(email, notification);
                if (result == 1)
                {
                    Session["success"] = "Your changes have been saved!";
                    Response.Redirect(Page.ResolveUrl("~/Views/Profile/profile.aspx"));
                }
            }
            if (chkBoxNotification.Checked == false)
            {
                email = Session["email"].ToString();
                notification = "F";
                User user = new User();
                int result = user.UpdateNotification(email, notification);
                if (result == 1)
                {
                    Session["success"] = "Your changes have been saved!";
                    Response.Redirect(Page.ResolveUrl("~/Views/Profile/profile.aspx"));
                }
            }
        }
    }
}