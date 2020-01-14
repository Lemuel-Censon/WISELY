using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WISLEY.BLL.Profile;

namespace WISLEY.Views.Group
{
    public partial class members : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["email"] != null)
            {
                memberData.SelectCommand = "Select * from [User] " +
                    "where email in (Select userEmail from [GroupUserRelations] where groupID = '" + getGroupDetails().id + "')";
                
            }
            else
            {
                Session["error"] = "You must be logged in to view members!";
                Response.Redirect(Page.ResolveUrl("~/Views/index.aspx"));
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