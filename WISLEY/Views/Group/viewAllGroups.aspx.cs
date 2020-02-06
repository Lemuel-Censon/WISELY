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
                User current_user = new User().SelectByEmail(Session["email"].ToString());

                //ContentPlaceHolder cp = (ContentPlaceHolder)this.Master.Master.FindControl("contentHolder1");
                //SqlDataSource das = (SqlDataSource)cp.FindControl("groupData");
                //das.SelectCommand = "SELECT * FROM [Group] " +
                //"WHERE Id IN (SELECT groupID FROM [GroupUserRelations] WHERE userEmail = '" + current_user.email + "') and active = 1 " +
                //"ORDER BY Id ASC";




                SQLgroupData.SelectCommand = "SELECT * FROM [Group] " +
                    "INNER JOIN [GroupUserRelations] " +
                    "ON [Group].Id = [GroupUserRelations].groupID " +
                    "WHERE userEmail = '" + current_user.email + "' and active = 1 and show = 1 " +
                    "ORDER BY customOrder ASC";

                SQLhiddenGroupData.SelectCommand = "SELECT * FROM [Group] " +
                    "INNER JOIN [GroupUserRelations] " +
                    "ON [Group].Id = [GroupUserRelations].groupID " +
                    "WHERE userEmail = '" + current_user.email + "' and active = 1 and show = 0 " +
                    "ORDER BY customOrder ASC";

                //SQLgroupData.SelectCommand = "SELECT * FROM [GroupUserRelations] " +
                //"WHERE userEmail = '" + current_user.email + "' and show = 1 " +
                //"ORDER BY customOrder ASC";





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
                if(result == 1)
                {
                    Response.Redirect(Request.RawUrl);

                }


            }
        }

        protected void hiddenGroupsBtns_groupOrderCommand(object source, RepeaterCommandEventArgs e)
        {
            if(e.CommandName == "showGroup")
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


        public void test()
        {
            System.Diagnostics.Debug.WriteLine("zzzzzzzzzz");

        }

    }
}