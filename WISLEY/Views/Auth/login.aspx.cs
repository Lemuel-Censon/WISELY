using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WISLEY.BLL.Profile;

namespace WISLEY
{
    public partial class login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["password"] != null)
            {
                toast(this, Session["password"].ToString(), "Success", "success");
                Session["password"] = null;
            }
            if (Session["registered"] != null)
            {
                toast(this, "You have been registered successfully! Please log in.", "Success", "success");
                Session["registered"] = null;
            }
        }

        public void toast(Page page, string message, string title, string type)
        {
            page.ClientScript.RegisterStartupScript(page.GetType(), "toastmsg", "toastnotif('" + message + "','" + title + "','" + type.ToLower() + "');", true);
        }

        public User user()
        {
            User user = new User().SelectByEmail(Session["email"].ToString());
            return user;
        }

        public bool ValidateInput()
        {
            bool valid = false;
            User user = new User().SelectByEmail(TbEmail.Text);

            if (String.IsNullOrEmpty(TbEmail.Text))
            {
                toast(this, "Please enter your email!", "Error", "error");
            }

            else if (String.IsNullOrEmpty(TbPassword.Text))
            {
                toast(this, "Please enter your password!", "Error", "error");
            }

            else if (user == null)
            {
                toast(this, "Account does not exist!", "Error", "error");
            }

            else if (user.password != TbPassword.Text)
            {
                toast(this, "Password is incorrect!", "Error", "error");
            }

            else
            {
                valid = true;
            }

            return valid;
        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            if (ValidateInput())
            {
                if (Session["email"] == null)
                {
                    Session["email"] = TbEmail.Text;
                    int uid = user().id;
                    Session["uid"] = uid;
                    Session["success"] = "Logged in successfully!";
                    Response.Redirect("~/Views/Board/collab.aspx");
                }
                else
                {
                    Session["error"] = "You are already logged in!";
                    Response.Redirect("~/Views/Board/collab.aspx");
                }
            }
        }
    }
}