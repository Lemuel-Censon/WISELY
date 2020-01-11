using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WISLEY.BLL.Profile;

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

            else if (TbPassword.Text != TbConfirmPassword.Text)
            {
                toast(this, "Both passwords must match!", "Error", "error");
            }

            else if (typelist.SelectedIndex == -1)
            {
                toast(this, "Please indicate whether you are a student or teacher!", "Error", "error");
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
                string type = typelist.SelectedItem.Text;
                string email = TbEmail.Text;
                string name = TbName.Text;
                string password = TbPassword.Text;

                User user = new User(email, password, type, name, "", "", "", 0, 0);
                int result = user.AddUser();
                if (result == 1)
                {
                    Session["registered"] = "register";
                    Response.Redirect("login.aspx");
                }

                else
                {
                    toast(this, "There was a error while registering, please contact system administrator!", "Error", "error");
                }
                
            }
        }
    }
}