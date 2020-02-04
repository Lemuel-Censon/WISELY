using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WISLEY.BLL.Profile;

namespace WISLEY.Views.Group
{
    public partial class joinGroup : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["email"] == null)
            {
                Session["error"] = "You must be logged in to create a group!";
                Response.Redirect(Page.ResolveUrl("~/Views/Auth/login.aspx"));
            }

        }

        public void toast(Page page, string message, string title, string type)
        {
            ScriptManager.RegisterClientScriptBlock(page, page.GetType(), "toastmsg", "toastnotif('" + message + "','" + title + "','" + type.ToLower() + "');", true);
        }

        public void join(object sender, EventArgs e)
        {
            string grpCode = groupCodeTB.Text.ToString();


            if (!string.IsNullOrEmpty(grpCode))
            {
                BLL.Group.Group grp = new BLL.Group.Group().getGroupByAttribute("joinCode", grpCode);
                int result = grp.joinGroup(user().email, grpCode);
                if (result == 1)
                {
                    Session["success"] = "Group joined successfully!";
                    Response.Redirect("~/Views/Board/collab.aspx?groupId="+grp.id);
                }
                else if (result == -1)
                {
                    toast(this, "Group already joined.", "Error", "error");

                }
                else
                {
                    toast(this, "Unable to join group, please inform system administrator!", "Error", "error");
                }
            }
            else
            {
                toast(this, "Please enter the the group code!", "Error", "error");
            }
        }

        public User user()
        {
            User user = new User().SelectByEmail(Session["email"].ToString());
            return user;
        }

        public void back(object sender, EventArgs e)
        {
            Response.Redirect("~/Views/Board/collab.aspx");
        }

    }
}