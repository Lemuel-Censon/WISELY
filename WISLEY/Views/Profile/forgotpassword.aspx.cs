using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WISLEY.BLL.Profile;

namespace WISLEY
{
    public partial class recoveraccount : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["error"] != null)
            {
                toast(this, Session["error"].ToString(), "Error", "error");
                Session["error"] = null;
            }
        }

        public void toast(Page page, string message, string title, string type)
        {
            page.ClientScript.RegisterStartupScript(page.GetType(), "toastmsg", "toastnotif('" + message + "','" + title + "','" + type.ToLower() + "');", true);
        }


        protected void btnRecoverAccount_Click(object sender, EventArgs e)
        {
            User validate = new User().SelectByEmail(TbEmail.Text);
            if (String.IsNullOrEmpty(TbEmail.Text))
            {
                toast(this, "Please enter an email address!", "Error", "error");
            }
            if (validate == null)
            {
                toast(this, "Email address does not exist. Did you enter the correct email address?", "Error", "error");
            } else
            {
                Session["email"] = TbEmail.Text;
                Session["success"] = "Your email address has been verified!"; 
                Response.Redirect("changepassword.aspx");
            }
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("login.aspx");
        }
    }
}