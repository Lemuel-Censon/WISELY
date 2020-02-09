using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WISLEY.BLL.Profile;

namespace WISLEY
{
    public partial class changepassword : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["success"] != null)
            {
                toast(this, Session["success"].ToString(), "Success", "success");
                Session["success"] = null;
            }
            if (Session["email"] != null)
            {
                if (!Page.IsPostBack)
                {
                    User user = new User().SelectByEmail(Session["email"].ToString());
                }
            }
            else
            {
                Session["error"] = "You must verify your email address before further recovering your account!";
                Response.Redirect("recoveraccount.aspx");
            }
        }

        public void toast(Page page, string message, string title, string type)
        {
            page.ClientScript.RegisterStartupScript(page.GetType(), "toastmsg", "toastnotif('" + message + "','" + title + "','" + type.ToLower() + "');", true);
        }

        protected void btnChangePassword_Click(object sender, EventArgs e)
        {
            User user = new User().SelectByEmail(Session["email"].ToString());
            if (String.IsNullOrEmpty(TbNewPassword.Text))
            {
                toast(this, "Please enter a new password!", "Error", "error");
            }
            else if (String.IsNullOrEmpty(TbConfirmPassword.Text))
            {
                toast(this, "Please confirm your new password!", "Error", "error");
            }
            else if (TbNewPassword.Text == user.password)
            {
                toast(this, "You cannot use the same password!", "Error", "error");
            }
            else if (TbNewPassword.Text != TbConfirmPassword.Text)
            {
                toast(this, "Both new passwords must match!", "Error", "error");
            }
            else
            {
                string email = Session["email"].ToString();
                string password = TbConfirmPassword.Text;
                user = new User();
                int result = user.UpdatePassword(email, password);
                if (result == 1)
                {
                    Session["password"] = "Your password has been changed successfully!";
                    Response.Redirect(Page.ResolveUrl("~/Views/Auth/login.aspx"));
                }
                else
                {
                    toast(this, "Password was unable to be changed, please inform system administrator!", "Error", "error");
                }
            }
        }

        protected void btnBack_Click(object sender, EventArgs e)
        {
            Response.Redirect("forgotpassword.aspx");
        }
    }
}