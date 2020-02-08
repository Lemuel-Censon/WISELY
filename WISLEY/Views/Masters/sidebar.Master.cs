using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WISLEY.BLL.Group;
using WISLEY.BLL.Notification;
using WISLEY.BLL.Profile;
using WISLEY.BLL.Schedule;
using WISLEY.BLL.User;

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


                Repeater grpRep = (Repeater)cp.FindControl("groupBtns");

                List<Group> groups = new Group().getGroupsJoined(current_user.email);
                grpRep.DataSource = groups;
                grpRep.DataBind();



                List<Planner> todolist = new Planner().SelectByUser(user().id);

                Repeater schedule = (Repeater)cp.FindControl("scheduleitems");
                schedule.DataSource = todolist;
                schedule.DataBind();
            }
            else
            {

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
                    Response.Redirect("~/Views/Board/collab.aspx?groupId=" + grp.id);
                }
                else if (result == -1)
                {
                    toast(this.Page, "Group already joined.", "Error", "error");

                }
                else
                {
                    toast(this.Page, "Unable to join group, please inform system administrator!", "Error", "error");
                }
            }
            else
            {
                toast(this.Page, "Please enter the the group code!", "Error", "error");
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

        public void resetGroupCode(object sender, EventArgs e)
        {
            var grp = getGroupDetails();
            int result = grp.resetGroupJoinCode(grp.id);
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


        //============================================// Redirects //============================================//

        public void redirectToAddMember(object sender, EventArgs e)
        {
            Response.Redirect("~/Views/Group/addMember.aspx?groupId=" + Request.QueryString["groupId"].ToString());

        }

        public void redirectToJoinGroup(object sender, EventArgs e)
        {
            Response.Redirect("~/Views/Group/joinGroup.aspx");
        }

        public void redirectToCreateGroup(object sender, EventArgs e)
        {
            Response.Redirect("~/Views/Group/createGroup.aspx");
        }

        public void toMembers()
        {
            string grpId = Request.QueryString["groupId"];
            Response.Redirect("~/Views/Group/members.aspx?groupId=" + grpId);
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

        //============================================// Repeater Codes //============================================//

        protected void groupItemCommand(object source, RepeaterCommandEventArgs e)
        {
            if (e.CommandName == "redirectToGroup")
            {
                Response.Redirect("~/Views/Board/collab.aspx?groupId=" + e.CommandArgument.ToString());
            }
        }

        protected void groupItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                HiddenField grpBtnName = (HiddenField)e.Item.FindControl("grpBtnName");

                LinkButton linkBtn = (LinkButton)e.Item.FindControl("groupRedirect");
                linkBtn.Text = Truncate(grpBtnName.Value, 30);

            }

        }

        protected void scheduleRepeater_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            if (e.CommandName == "edit")
            {
                Session["todoID"] = e.CommandArgument.ToString();
                Response.Redirect(Page.ResolveUrl("~/Views/Schedule/editToDo.aspx"));
            }
        }

        protected void scheduleRepeater_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (scheduleitems.Items.Count < 1)
            {
                if (e.Item.ItemType == ListItemType.Footer)
                {
                    e.Item.FindControl("LblMsg").Visible = true;
                }
            }
        }
    }
}