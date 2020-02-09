using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WISLEY.BLL.Notification;
using WISLEY.BLL.Profile;
using WISLEY.BLL.User;

namespace WISLEY
{
    public partial class login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["email"] != null)
            {
                Session["error"] = "You are already logged in!";
                Response.Redirect(Page.ResolveUrl("~/Views/Board/collab.aspx"));
            }
            if (Session["success"] != null)
            {
                toast(this, Session["success"].ToString(), "Success", "success");
                Session["success"] = null;
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

        static string GenerateSaltedHash(byte[] plainText, byte[] salt)
        {
            HashAlgorithm algorithm = new SHA256Managed();

            byte[] plainTextWithSaltBytes = new byte[plainText.Length + salt.Length];

            for (int i = 0; i < plainText.Length; i++)
            {
                plainTextWithSaltBytes[i] = plainText[i];
            }
            for (int i = 0; i < salt.Length; i++)
            {
                plainTextWithSaltBytes[plainText.Length + i] = salt[i];
            }

            return Convert.ToBase64String(algorithm.ComputeHash(plainTextWithSaltBytes));
        }

        public bool CompareHash()
        {
            User user = new User().SelectByEmail(TbEmail.Text);
            string compare = GenerateSaltedHash(System.Text.Encoding.Unicode.GetBytes(TbPassword.Text), System.Text.Encoding.Unicode.GetBytes(user.salt));
            if (compare == user.password)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool ValidateInput()
        {
            bool valid = false;
            User user = new User().SelectByEmail(TbEmail.Text);

            if (String.IsNullOrEmpty(TbEmail.Text))
            {
                toast(this, "Please enter your email!", "Error", "error");
            }

            //else if (!TbEmail.Text.Contains("@"))
            //{
            //    toast(this, "Please enter a valid email!", "Error", "error");
            //}

            else if (String.IsNullOrEmpty(TbPassword.Text))
            {
                toast(this, "Please enter your password!", "Error", "error");
            }

            else if (user == null)
            {
                toast(this, "Account does not exist!", "Error", "error");
            }

            else if (!CompareHash())
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
                Session["email"] = TbEmail.Text;
                int uid = user().id;
                int currentpoints = user().points;
                Badge badge = new Badge().SelectByBadgeId(user().id.ToString(), 1);
                Notify notify = new Notify(user().email, user().email, DateTime.Now.ToString(), "badge", -1, -1, 1);
                if (badge.status == "Locked")
                {
                    badge.UpdateBadge(user().id.ToString(), 1, DateTime.Now.ToString("dd/MM/yyyy"), "Unlocked");
                    notify.AddBadgeNotif();
                }
                Session["uid"] = uid;
                Session["success"] = "Logged in successfully!";
                Response.Redirect("~/Views/Board/collab.aspx");
            }
        }
    }
}