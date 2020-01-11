using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WISLEY.BLL.Profile;

namespace WISLEY
{
    public partial class editprofile : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["email"] != null)
            {
                tbEmail.Text = Session["email"].ToString();
                User user = new User().SelectByEmail(tbEmail.Text);
            }
            else
            {
                Session["error"] = "You must be logged in to edit your profile!";
                Response.Redirect("profile.aspx");
            }
        }

        public void toast(Page page, string message, string title, string type)
        {
            ScriptManager.RegisterClientScriptBlock(page, page.GetType(), "toastmsg", "toastnotif('" + message + "','" + title + "','" + type.ToLower() + "');", true);
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("profile.aspx");
        }

        public bool ValidateInput(string email, string name)
        {
            bool valid = false;
            if (String.IsNullOrEmpty(email))
            {
                toast(this, "Please enter your email!", "Error", "error");
            }
            if (String.IsNullOrEmpty(name))
            {
                toast(this, "Please enter your full name!", "Error", "error");
            }
            else
            {
                valid = true;
            }
            return valid;
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            if (ValidateInput(tbEmail.Text, tbName.Text))
            {
                User user = new User();
                string email = tbEmail.Text;
                string name = tbName.Text;
                string dob = tbDOB.Text;
                string contactNo = tbContact.Text;
                int result = user.UpdateUser(email, name, dob, contactNo);
                if (result == 1)
                {
                    toast(this, "Your profile has been saved!", "Success", "success");
                }
                else
                {
                    toast(this, "Changes were unable to be saved, please inform system administrator!", "Error", "error");
                }
            }
        }
    }
}