using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WISLEY.BLL.Notification;
using WISLEY.BLL.Profile;

namespace WISLEY.Views.Notification
{
    public partial class viewnotif : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["email"] != null)
            {
                List<Notify> postnotifications = new Notify().SelectPostNotif(user().email);
                postnotifs.DataSource = postnotifications;
                postnotifs.DataBind();
                List<Notify> invnotifications = new Notify().SelectInvNotif(user().email);
                invitenotifs.DataSource = invnotifications;
                invitenotifs.DataBind();
                List<Notify> commnotifications = new Notify().SelectCommNotif(user().email);
                commentnotifs.DataSource = commnotifications;
                commentnotifs.DataBind();
            }
            else
            {
                Session["error"] = "You need to be logged in to view notifications!";
                Response.Redirect(Page.ResolveUrl("~/Views/index.aspx"));
            }
        }

        public List<int> notifcount()
        {
            List<int> notifscount = new List<int>();
            List<Notify> postnotifications = new Notify().SelectPostNotif(user().email);
            List<Notify> invnotifications = new Notify().SelectInvNotif(user().email);
            List<Notify> commnotifications = new Notify().SelectCommNotif(user().email);
            notifscount.Add(postnotifications.Count);
            notifscount.Add(invnotifications.Count);
            notifscount.Add(commnotifications.Count);
            return notifscount;
        }

        public User user()
        {
            User user = new User().SelectByEmail(Session["email"].ToString());
            return user;
        }

        protected void postnotifs_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Footer && postnotifs.Items.Count < 1)
            {
                e.Item.FindControl("LbErr").Visible = true;
            }
        }

        protected void postnotifs_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            if (e.CommandName == "viewprofile")
            {
                int target = new User().SelectByEmail(e.CommandArgument.ToString()).id;
                Response.Redirect(Page.ResolveUrl("~/Views/Profile/profile.aspx?id=" + target));
            }
            if (e.CommandName == "viewpost")
            {
                Session["postId"] = e.CommandArgument.ToString();
                Response.Redirect(Page.ResolveUrl("~/Views/Board/viewpost.aspx"));
            }
            if (e.CommandName == "viewgroup")
            {
                string groupId = e.CommandArgument.ToString();
                Response.Redirect(Page.ResolveUrl("~/Views/Board/collab.aspx?groupId=" + groupId));
            }
            if (e.CommandName == "clearnotif")
            {
                string notifId = e.CommandArgument.ToString();
                Notify notif = new Notify();
                notif.ClearNotifs(notifId);
                Response.Redirect("viewnotif.aspx");
            }
        }

        protected void invitenotifs_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            if (e.CommandName == "viewprofile")
            {
                int target = new User().SelectByEmail(e.CommandArgument.ToString()).id;
                Response.Redirect(Page.ResolveUrl("~/Views/Profile/profile.aspx?id=" + target));
            }
            if (e.CommandName == "viewgroup")
            {
                string groupId = e.CommandArgument.ToString();
                Response.Redirect(Page.ResolveUrl("~/Views/Board/collab.aspx?groupId=" + groupId));
            }
            if (e.CommandName == "clearnotif")
            {
                string notifId = e.CommandArgument.ToString();
                Notify notif = new Notify();
                notif.ClearNotifs(notifId);
                Response.Redirect("viewnotif.aspx");
            }
        }

        protected void invitenotifs_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Footer && invitenotifs.Items.Count < 1)
            {
                e.Item.FindControl("LbErr").Visible = true;
            }
        }

        protected void commentnotifs_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            if (e.CommandName == "viewprofile")
            {
                int target = new User().SelectByEmail(e.CommandArgument.ToString()).id;
                Response.Redirect(Page.ResolveUrl("~/Views/Profile/profile.aspx?id=" + target));
            }
            if (e.CommandName == "viewpost")
            {
                Session["postId"] = e.CommandArgument.ToString();
                Response.Redirect(Page.ResolveUrl("~/Views/Board/viewpost.aspx"));
            }
            if (e.CommandName == "viewgroup")
            {
                string groupId = e.CommandArgument.ToString();
                Response.Redirect(Page.ResolveUrl("~/Views/Board/collab.aspx?groupId=" + groupId));
            }
            if (e.CommandName == "clearnotif")
            {
                string notifId = e.CommandArgument.ToString();
                Notify notif = new Notify();
                notif.ClearNotifs(notifId);
                Response.Redirect("viewnotif.aspx");
            }
        }

        protected void commentnotifs_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Footer && commentnotifs.Items.Count < 1)
            {
                e.Item.FindControl("LbErr").Visible = true;
            }
        }
    }
}