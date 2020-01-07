using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WISLEY
{
    public partial class editprofile : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["email"] != null)
            {
                tbEmail.Text = Session["email"].ToString();
            } else
            {
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

        protected void btnSave_Click(object sender, EventArgs e)
        {
            if (tbEmail.Text == string.Empty)
            {
                toast(this, "Please enter your email!", "Error", "error");
            }
            if (tbFname.Text == string.Empty)
            {
                toast(this, "Please enter your first name!", "Error", "error");
            }
            if (tbLname.Text == string.Empty)
            {
                toast(this, "Please enter your last name!", "Error", "error");
            }
            else
            {
                toast(this, "Your profile has been saved!", "Success", "success");
            }
        }
    }
}