using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WISLEY.BLL.Notification;
using WISLEY.BLL.Profile;

namespace WISLEY.Views.Group
{
    public partial class inviteStudent : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            List<User> addableUsers = new BLL.Group.Group().getAddableUsers(getGroupDetails().id.ToString());
            userListBtns.DataSource = addableUsers;
            userListBtns.DataBind();
        }

        protected void addMemberCommand(object source, RepeaterCommandEventArgs e)
        {
            if (e.CommandName == "addToGroup")
            {
                string invitedMemberEmail = e.CommandArgument.ToString();
                BLL.Group.Group grp = new BLL.Group.Group();
                int result = grp.addMemberToGroup(invitedMemberEmail, Request.QueryString["groupId"]);
                if(result != 1)
                {
                    toast(this, "Adding member failed. Please try again.", "Error", "error");

                }
                else
                {
                    Notify notif = new Notify(user().email, invitedMemberEmail, DateTime.Now.ToShortTimeString(), "invite", getGroupDetails().id);
                    notif.AddInvNotif();
                    toast(this, "Member Added!", "Success", "success");
                }
                Response.Redirect(Request.RawUrl);
            }
        }

        public void toast(Page page, string message, string title, string type)
        {
            ScriptManager.RegisterClientScriptBlock(page, page.GetType(), "toastmsg", "toastnotif('" + message + "','" + title + "','" + type.ToLower() + "');", true);
        }

        public BLL.Group.Group getGroupDetails()
        {
            string grpId = Request.QueryString["groupId"];

            BLL.Group.Group grp = new BLL.Group.Group().getGroupByID(grpId);
            return grp;
        }

        public User user()
        {
            User user = new User().SelectByEmail(Session["email"].ToString());
            return user;
        }

    }
}