using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WISLEY.BLL.Profile;

namespace WISLEY.Views.Quiz
{
    public partial class quizcreator1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["email"] != null)
            {
                if (!Page.IsPostBack)
                {
                    User user = new User().SelectByEmail(Session["email"].ToString());
                }
            }
            else
            {
                Session["error"] = "You must be logged in to have access to the quiz creator!";
                Response.Redirect(Page.ResolveUrl("~/Views/index.aspx"));
            }
        }
    }
}