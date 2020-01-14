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
                das.SelectCommand = "SELECT * FROM [Group] " +
                "WHERE Id IN (SELECT groupID FROM [GroupUserRelations] WHERE userEmail = '" + current_user.email + "') " +
                "ORDER BY Id ASC";


                

            }

        }


        public List<Group> getGroups()
        {
            List<Group> groupList = new List<Group>();
            List<string> groupListStrings = user().inGroupsId.Split(',').ToList();

            for (int i = 0; i < 5; i++)
            {
                try
                {
                    Group grp = new Group().getGroupByID(groupListStrings[i]);
                    groupList.Add(grp);
                }
                catch
                {
                    break;
                }

            }

            return groupList;

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

        public bool TeacherCheck()
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

        public User user()
        {
            User user = new User().SelectByEmail(Session["email"].ToString());
            return user;
        }

        protected void groupItemCommand(object source, RepeaterCommandEventArgs e)
        {
            if (e.CommandName == "redirectToGroup")
            {
                Response.Redirect("~/Views/Board/collab.aspx?groupId=" + e.CommandArgument.ToString());
            }
        }

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
    }
}