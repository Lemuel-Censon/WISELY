using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WISLEY.BLL.Profile;

namespace WISLEY.Views.Group
{
    public partial class createGroup : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            foreach(var crntSession in Session.Contents)
            {
              System.Diagnostics.Debug.WriteLine(string.Concat(crntSession, "=", Session[crntSession.ToString()]) + "<br />");
            }

            if (Session["email"] != null)
            {
           
                User user = new User().SelectByEmail(Session["email"].ToString());

                if(user.userType != "Teacher")
                {
                    Session["error"] = "You must be a teacher to create a group!";
                    Response.Redirect(Page.ResolveUrl("~/Views/Profile/profile.aspx"));
                }


            }
            else
            {
                Session["error"] = "You must be logged in to create a group!";
                Response.Redirect(Page.ResolveUrl("~/Views/Profile/login.aspx"));
            }

        }

        public void toast(Page page, string message, string title, string type)
        {
            ScriptManager.RegisterClientScriptBlock(page, page.GetType(), "toastmsg", "toastnotif('" + message + "','" + title + "','" + type.ToLower() + "');", true);
        }

        public bool ValidateInput(string name, string description, string weightage)
        {
            bool valid = false;
            if (String.IsNullOrEmpty(name))
            {
                toast(this, "Please enter the group name!", "Error", "error");
            }
            else if (String.IsNullOrEmpty(description))
            {
                toast(this, "Please enter the group description!", "Error", "error");
            }
            else if (String.IsNullOrEmpty(weightage))
            {
                toast(this, "Please enter the weightage!", "Error", "error");

            }
            else
            {
                valid = true;
            }
            return valid;
        }

        public void CreateGroup(object sender, EventArgs e)
        {
    
            string grpName = groupNameTB.Text.Trim();
            string grpDescription = groupNameTB.Text.Trim();
            string grpWeightage = groupWeightageTB.Text.Trim();

            if (ValidateInput(grpName, grpDescription, grpWeightage))
            {
                int intGrpWeightage = int.Parse(grpWeightage);
                BLL.Group.Group newGoup = new BLL.Group.Group(grpName, grpDescription, intGrpWeightage);
                int result = newGoup.addGroup(Session["email"].ToString());
                if (result == 1)
                {
                    Session["success"] = "toast";
                    Response.Redirect("~/Views/Board/collab.aspx");
                }
                else
                {
                    toast(this, "Unable to add post, please inform system administrator!", "Error", "error");
                }
            }
        }
    }
}