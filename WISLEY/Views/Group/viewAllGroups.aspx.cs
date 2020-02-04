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

    }
}