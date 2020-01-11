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
                LbEmail.Text = Session["email"].ToString();
                User user = new User().SelectByEmail(LbEmail.Text);
                tbName.Text = user.name;
                tbDOB.Text = user.dob;
                tbContact.Text = user.contactNo;
            }
            else
            {
                Session["error"] = "You must be logged in to edit your profile!";
                Response.Redirect("profile.aspx");
            }
        }

        public void toast(Page page, string message, string title, string type)
        {
            page.ClientScript.RegisterStartupScript(page.GetType(), "toastmsg", "toastnotif('" + message + "','" + title + "','" + type.ToLower() + "');", true);
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("profile.aspx");
        }

        public bool ValidateInput(string name, string dob, string contact)
        {
            bool valid = false;
            DateTime date;
            if (String.IsNullOrEmpty(name))
            {
                toast(this, "Please enter your full name!", "Error", "error");
            }
            else if (!String.IsNullOrEmpty(dob) && !DateTime.TryParse(dob, out date)){
                toast(this, "Please enter a valid date!", "Error", "error");
            }
            else if (!String.IsNullOrEmpty(contact) && contact.Length < 8)
            {
                toast(this, "Please enter a valid contact number!", "Error", "error");
            }
            else
            {
                valid = true;
            }
            return valid;
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            if (ValidateInput(tbName.Text, tbDOB.Text, tbContact.Text))
            {
                User user = new User();
                string email = LbEmail.Text;
                string name = tbName.Text;
                string dob = tbDOB.Text;
                string contactNo = tbContact.Text;
                int result = user.UpdateUser(email, name, dob, contactNo);
                if (result == 1)
                {
                    Session["success"] = "Your profile has been saved!";
                    Response.Redirect(Page.ResolveUrl("~/Views/Profile/profile.aspx"));
                }
                else
                {
                    toast(this, "Changes were unable to be saved, please inform system administrator!", "Error", "error");
                }
            }
        }
    }
}