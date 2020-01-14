using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WISLEY.BLL.Profile;

namespace WISLEY.Views.Group
{
    public partial class joinGroup : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["email"] == null)
            {
                Session["error"] = "You must be logged in to create a group!";
                Response.Redirect(Page.ResolveUrl("~/Views/Auth/login.aspx"));
            }

        }

        //public void joinGroup()
        //{
        //    return;
        //}

        public User user()
        {
            User user = new User().SelectByEmail(Session["email"].ToString());
            return user;
        }


    }
}