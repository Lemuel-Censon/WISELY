using AjaxControlToolkit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WISLEY.BLL.Profile;

namespace WISLEY.Views.Group
{
    public partial class viewAllGroups : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["email"] != null)
            {
                SQLgroupData.SelectCommand = "SELECT * FROM [Group] " +
                    "INNER JOIN [GroupUserRelations] " +
                    "ON [Group].Id = [GroupUserRelations].groupID " +
                    "WHERE userEmail = '" + user().email + "' and active = 1 and show = 1 " +
                    "ORDER BY customOrder ASC";

                SQLhiddenGroupData.SelectCommand = "SELECT * FROM [Group] " +
                    "INNER JOIN [GroupUserRelations] " +
                    "ON [Group].Id = [GroupUserRelations].groupID " +
                    "WHERE userEmail = '" + user().email + "' and active = 1 and show = 0 " +
                    "ORDER BY customOrder ASC";

                SQLinactiveGroupData.SelectCommand = "SELECT * FROM [Group] " +
                    "INNER JOIN [GroupUserRelations] " +
                    "ON [Group].Id = [GroupUserRelations].groupID " +
                    "WHERE userEmail = '" + user().email + "' and active = 0" +
                    "ORDER BY customOrder ASC";
            }
        }

        public string Truncate(string value, int maxLength)
        {

            if (string.IsNullOrEmpty(value) || value.Length <= maxLength)
            {
                return value;
            }
            else
            {
                value = value.Substring(0, maxLength) + "..";
                return value;
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

        protected void AllGroupReorderList_groupOrderCommand(object source, ReorderListCommandEventArgs e)
        {
            System.Diagnostics.Debug.WriteLine("groupOrderCommand executed");

            if (e.CommandName == "hideGroup")
            {
                System.Diagnostics.Debug.WriteLine("Hide Group Clicked");
                User current_user = new User().SelectByEmail(Session["email"].ToString());
                BLL.Group.Group grp = new BLL.Group.Group();

                int result = grp.hideJoinedGroup(current_user.email, e.CommandArgument.ToString());
                if (result == 1)
                {
                    Response.Redirect(Request.RawUrl);

                }


            }
        }

        public void AllGroupReorderList_onItemDataBound(object source, ReorderListItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                HiddenField grpName = (HiddenField)e.Item.FindControl("grpName");

                Label grpNameLabel = (Label)e.Item.FindControl("grpNameLabel");
                if (user().userType == "Teacher")
                {
                    grpNameLabel.Text = Truncate(grpName.Value, 20);
                }
                else
                {
                    grpNameLabel.Text = Truncate(grpName.Value, 40);
                }

            }
        }

        protected void hiddenGroupsBtns_groupOrderCommand(object source, RepeaterCommandEventArgs e)
        {
            if (e.CommandName == "showGroup")
            {
                User current_user = new User().SelectByEmail(Session["email"].ToString());
                BLL.Group.Group grp = new BLL.Group.Group();

                int result = grp.showJoinedGroup(current_user.email, e.CommandArgument.ToString());
                if (result == 1)
                {
                    Response.Redirect(Request.RawUrl);

                }
            }

        }

        protected void inactiveGroupsBtns_groupOrderCommand(object source, RepeaterCommandEventArgs e)
        {
            if (e.CommandName == "activateGroup")
            {
                User current_user = new User().SelectByEmail(Session["email"].ToString());
                BLL.Group.Group grp = new BLL.Group.Group();

                int result = grp.enableGroup(e.CommandArgument.ToString());
                if (result == 1)
                {
                    Response.Redirect(Request.RawUrl);

                }
            }

        }

        public void test()
        {
            System.Diagnostics.Debug.WriteLine("zzzzzzzzzz");

        }

    }
}