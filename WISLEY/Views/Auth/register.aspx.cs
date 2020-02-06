using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WISLEY.BLL.Profile;
using WISLEY.BLL.User;

namespace WISLEY
{
    public partial class register : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        public void toast(Page page, string message, string title, string type)
        {
            page.ClientScript.RegisterStartupScript(page.GetType(), "toastmsg", "toastnotif('" + message + "','" + title + "','" + type.ToLower() + "');", true);
        }

        public bool ValidateInput()
        {
            bool valid = false;
            User compare = new User().SelectByEmail(TbEmail.Text);

            if (String.IsNullOrEmpty(TbEmail.Text))
            {
                toast(this, "Please enter your email!", "Error", "error");
            }

            else if (!TbEmail.Text.Contains("@"))
            {
                toast(this, "Please enter a valid email!", "Error", "error");
            }

            else if (String.IsNullOrEmpty(TbName.Text))
            {
                toast(this, "Please enter your full name!", "Error", "error");
            }

            else if (String.IsNullOrEmpty(TbPassword.Text))
            {
                toast(this, "Please enter a password!", "Error", "error");
            }

            else if (TbPassword.Text.Length < 8)
            {
                toast(this, "Your password must be at least 8 characters long!", "Error", "error");
            }

            else if (TbPassword.Text != TbConfirmPassword.Text)
            {
                toast(this, "Both passwords must match!", "Error", "error");
            }

            else if (compare != null)
            {
                toast(this, "Account already exists!", "Error", "error");
            }

            else {
                valid = true;
            }

            return valid;
        }

        protected void btnRegister_Click(object sender, EventArgs e)
        {
            if (ValidateInput())
            {
                string email = TbEmail.Text;
                string name = TbName.Text;
                string password = TbPassword.Text;

                User user = new User(email, password, "Student", name, "", "", "", 0, 0, "F", "F", "");
                int result = user.AddUser();
                Badge badge1 = new Badge(user.GetLastID().ToString(), "../../Public/img/Badges/Badge_Beginner.png", "Badge_Beginner.png", "Become a WISELY member", 50, DateTime.Now.ToString("dd/MM/yyyy"), "Unlocked");
                Badge badge2 = new Badge(user.GetLastID().ToString(), "../../Public/img/Badges/Badge_Group.png", "Badge_Group.png", "Join a group.", 50, "", "Locked");
                Badge badge3 = new Badge(user.GetLastID().ToString(), "../../Public/img/Badges/Badge_Post.png", "Badge_Post.png", "Create a post.", 50, "", "Locked");
                if (result == 1)
                {
                    badge1.AddBadge();
                    badge2.AddBadge();
                    badge3.AddBadge();
                    Session["registered"] = "register";
                    Response.Redirect(Page.ResolveUrl("~/Views/Auth/login.aspx"));
                }

                else
                {
                    toast(this, "There was a error while registering, please contact system administrator!", "Error", "error");
                }
                
            }
        }
    }
}