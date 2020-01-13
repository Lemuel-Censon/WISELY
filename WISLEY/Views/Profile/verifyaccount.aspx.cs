using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WISLEY
{
    public partial class verifyaccount : System.Web.UI.Page
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
                LbEmail.Text = Session["email"].ToString();
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

        protected void btnVerifyAccount_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(TbCode.Text))
            {
                toast(this, "Please enter validation code!", "Error", "error");
            }
            else
            {
                Session["success"] = "Verification successful!";
                Session["email"] = LbEmail.Text;
                Response.Redirect("changepassword.aspx");
            }
        }

        protected void btnBack_Click(object sender, EventArgs e)
        {
            Response.Redirect("recoveraccount.aspx");
        }
    }
}