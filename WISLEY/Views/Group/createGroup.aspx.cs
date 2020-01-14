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
                Response.Redirect(Page.ResolveUrl("~/Views/Auth/login.aspx"));
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
            string grpDescription = groupDescriptionTB.Text.Trim();
            string grpWeightage = groupWeightageTB.Text.Trim();

            if (ValidateInput(grpName, grpDescription, grpWeightage))
            {
                int intGrpWeightage = 0;

                if (int.TryParse(grpWeightage, out intGrpWeightage))
                {
                    BLL.Group.Group newGoup = new BLL.Group.Group(grpName, grpDescription, intGrpWeightage);
                    int result = newGoup.addGroup(Session["email"].ToString());
                    if (result == 1)
                    {
                        Session["success"] = "Group created successfully!";
                        Response.Redirect("~/Views/Board/collab.aspx");
                    }
                    else if(result == -1)
                    {
                        toast(this, "Group name already taken.", "Error", "error");

                    }
                    else
                    {
                        toast(this, "Unable to add post, please inform system administrator!", "Error", "error");
                    }
                }
                else
                {
                    toast(this, "Please enter a numerical weightage.", "Error", "error");

                }


            }
        }
    }
}