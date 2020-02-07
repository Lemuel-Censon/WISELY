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

                User user = new User(email, password, "Student", name, "", "", "", 0, "");
                int result = user.AddUser();
                Badge badge1 = new Badge(1, user.GetLastID().ToString(), "../../Public/img/Badges/Badge_Beginner.png", "Beginner", "Become a WISELY member", 0, DateTime.Now.ToString("dd/MM/yyyy"), "Unlocked");
                Badge badge2 = new Badge(2, user.GetLastID().ToString(), "../../Public/img/Badges/Badge_Group.png", "Join a Group", "Join a group.", 50, "", "Locked");
                Badge badge3 = new Badge(3, user.GetLastID().ToString(), "../../Public/img/Badges/Badge_Post.png", "Create a post", "Create a post.", 50, "", "Locked");
                Badge badge4 = new Badge(4, user.GetLastID().ToString(), "../../Public/img/Badges/Badge_Quiz.png", "Create a quiz", "Create a quiz.", 50, "", "Locked");
                Badge badge5 = new Badge(5, user.GetLastID().ToString(), "../../Public/img/Badges/Badge_Quiz_10.png", "Create 10 quizzes.", "Create 10 quizzes.", 200, "", "Locked");
                Badge badge6 = new Badge(6, user.GetLastID().ToString(), "../../Public/img/Badges/Badge_1000WIS.png", "Earn 1000 WIS points", "Earn 1000 WIS points.", 50, "", "Locked");
                Badge badge7 = new Badge(7, user.GetLastID().ToString(), "../../Public/img/Badges/Badge_10000WIS.png", "Earn 10000 WIS points", "Earn 10000 WIS points.", 200, "", "Locked");
                Badge badge8 = new Badge(8, user.GetLastID().ToString(), "../../Public/img/Badges/Badge_100000WIS.png", "Earn 100000 WIS points", "Earn 100000 WIS points.", 1000, "", "Locked");
                Badge badge9 = new Badge(9, user.GetLastID().ToString(), "../../Public/img/Badges/Badge_Gacha.png", "Summon a 1x gacha", "Summon a x1 gacha.", 50, "", "Locked");
                Badge badge10 = new Badge(10, user.GetLastID().ToString(), "../../Public/img/Badges/Badge_Gacha_11.png", "Summon a 11x gacha", "Summon a x11 gacha.", 200, "", "Locked");
                Badge badge11 = new Badge(11, user.GetLastID().ToString(), "../../Public/img/Badges/Badge_ToDoList.png", "Create a to-do-list", "Create a to-do-list.", 50, "", "Locked");
                Badge badge12 = new Badge(12, user.GetLastID().ToString(), "../../Public/img/Badges/Badge_Thuglife.png", "You have become WISE", "Earn all badges to become truly WISELY.", 1000, "", "Locked");
                if (result == 1)
                {
                    badge1.AddBadge();
                    badge2.AddBadge();
                    badge3.AddBadge();
                    badge4.AddBadge();
                    badge5.AddBadge();
                    badge6.AddBadge();
                    badge7.AddBadge();
                    badge8.AddBadge();
                    badge9.AddBadge();
                    badge10.AddBadge();
                    badge11.AddBadge();
                    badge12.AddBadge();
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