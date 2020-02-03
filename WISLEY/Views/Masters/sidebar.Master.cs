using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WISLEY.BLL.Group;
using WISLEY.BLL.Profile;

namespace WISLEY
{
    public partial class NestedMasterPage1 : System.Web.UI.MasterPage
    {

        protected void Page_Load(object sender, EventArgs e)
        {
            string pageName = Path.GetFileNameWithoutExtension(Page.AppRelativeVirtualPath);
            System.Diagnostics.Debug.WriteLine(pageName);
            if (Session["email"] != null)
            {
                User current_user = new User().SelectByEmail(Session["email"].ToString());

                ContentPlaceHolder cp = (ContentPlaceHolder)this.Master.Master.FindControl("contentHolder1");
                SqlDataSource das = (SqlDataSource)cp.FindControl("groupData");
                //das.SelectCommand = "SELECT * FROM [Group] " +
                //"WHERE Id IN (SELECT groupID FROM [GroupUserRelations] WHERE userEmail = '" + current_user.email + "') and active = 1 " +
                //"ORDER BY Id ASC";

                das.SelectCommand = "SELECT * FROM [Group] " +
                    "INNER JOIN [GroupUserRelations] " +
                    "ON [Group].Id = [GroupUserRelations].groupID " +
                    "WHERE userEmail = '" + current_user.email + "' and active = 1 and show = 1 " +
                    "ORDER BY customOrder ASC";



            }

        }

        public bool TeacherCheck() //Checks whether user is a teacher and returns a bool
        {
            bool isTeacher = false;
            if (Session["email"] != null)
            {
                User user = new User().SelectByEmail(Session["email"].ToString());

                if (user.userType == "Teacher")
                {
                    isTeacher = true;
                }
            }
            return isTeacher;
        }

        public void toMembers()
        {
            string grpId = Request.QueryString["groupId"];
            Response.Redirect("~/Views/Group/members.aspx?groupId=" + grpId);
        }

        public void redirectToGroup(object sender, EventArgs e)
        {
            System.Diagnostics.Debug.WriteLine("Group List Strings:");
        }

        protected void groupItemCommand(object source, RepeaterCommandEventArgs e)
        {
            if (e.CommandName == "redirectToGroup")
            {
                Response.Redirect("~/Views/Board/collab.aspx?groupId=" + e.CommandArgument.ToString());
            }
        }

        public void resetGroupCode(object sender, EventArgs e)
        {
            var grp = getGroupDetails();
            int result = grp.resetGroupJoinCode(grp.id);
        }



        //============================================// Getting Details from DB //============================================//

        public Group getGroupDetails()
        {
            string grpId = Request.QueryString["groupId"];

            Group grp = new Group().getGroupByID(grpId);
            return grp;
        }

        public string getPageName()
        {
            string pageName = Path.GetFileNameWithoutExtension(Page.AppRelativeVirtualPath);
            System.Diagnostics.Debug.WriteLine(pageName);
            return pageName;
        }

        public User user()
        {
            User user = new User().SelectByEmail(Session["email"].ToString());
            return user;
        }


    }
}