using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WISLEY.BLL.Notification;
using WISLEY.BLL.Profile;
using WISLEY.BLL.User;

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
                int currentpoints = user().points;
                Badge badge = new Badge().SelectByBadgeId(user().id.ToString(), 2);
                Notify notify = new Notify(user().email, user().email, DateTime.Now.ToString(), "badge", -1, -1, 2);
                if (result == 1)
                {
                    if (badge.status == "Locked")
                    {
                        currentpoints += 50;
                        user().UpdateWISPoints(user().id, currentpoints);
                        badge.UpdateBadge(user().id.ToString(), 2, DateTime.Now.ToString("dd/MM/yyyy"), "Unlocked");
                        notify.AddBadgeNotif();
                    }
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