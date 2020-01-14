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
            if (Session["email"] != null)
            {
                User current_user = new User().SelectByEmail(Session["email"].ToString());
           
                ContentPlaceHolder cp = (ContentPlaceHolder)this.Master.Master.FindControl("contentHolder1");
                SqlDataSource das = (SqlDataSource)cp.FindControl("groupData");
                //if (getGroupIds().Count > 1)
                //{
                //    das.SelectCommand = "SELECT * FROM [Group] WHERE Id in (" + current_user.inGroupsId + ") ORDER BY Id ASC";

                //}

                if (getGroupIds().Count > 1)
                {
                    das.SelectCommand = "SELECT * FROM [Group] WHERE Id in (" + current_user.inGroupsId + ") ORDER BY Id ASC";

                }
                //das.SelectCommand = "SELECT * FROM [Group] WHERE Id in (" + current_user.inGroupsId + ") ORDER BY Id ASC";

                //if(Session["group"] != null)
                //{

                //}

            }

        }

        public List<string> getGroupIds()
        {
            List<Group> groupList = new List<Group>();
            List<string> groupListStrings = user().inGroupsId.Split(',').ToList();
            return groupListStrings;
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
                Session["group"] = e.CommandArgument.ToString();
                Response.Redirect("collab.aspx");
            }
        }

        public Group getGroupDetails()
        {
            Group grp = new Group().getGroupByID(Session["group"].ToString());
            return grp;
        }
    }
}