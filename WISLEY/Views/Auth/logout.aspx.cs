using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WISLEY.Views.Auth
{
    public partial class logout : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["email"] != null)
            {
                Session["email"] = null;
                Session["success"] = "Logged out successfully!";
                Response.Redirect(Page.ResolveUrl("~/Views/index.aspx"));
            }
            else
            {
                Session["error"] = "You are not logged in!";
                Response.Redirect(Page.ResolveUrl("~/Views/index.aspx"));
            }
        }
    }
}