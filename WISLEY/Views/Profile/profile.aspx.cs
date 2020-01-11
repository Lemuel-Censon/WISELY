using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WISLEY.BLL.Collab;
using WISLEY.BLL.Profile;

namespace WISLEY
{
    public partial class profile : System.Web.UI.Page
    {
        public int postcount()
        {
            Post post = new Post();
            return post.SelectByUser(LbEmail.Text).Count;
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["email"] != null)
            {
                LbEmail.Text = Session["email"].ToString();
                User user = new User().SelectByEmail(LbEmail.Text);
                LbName.Text = user.name;
                LbType.Text = user.userType;
                hidotheremail.Value = Session["email"].ToString();
                if (Session["success"] != null)
                {
                    toast(this, Session["success"].ToString(), "Success", "success");
                    Session["success"] = null;
                }
                if (Request.QueryString["email"] != null)
                {
                    LbEmail.Text = Request.QueryString["email"];
                }
                postcount();
                userpostdata.SelectCommand = "SELECT * FROM POST WHERE userId = '" + LbEmail.Text + "' ORDER BY Id DESC";
            }
            else
            {
                Session["error"] = "You must be logged in to view profile!";
                Response.Redirect(Page.ResolveUrl("~/Views/index.aspx"));
            }
        }

        public void toast(Page page, string message, string title, string type)
        {
            page.ClientScript.RegisterStartupScript(page.GetType(), "toastmsg", "toastnotif('" + message + "','" + title + "','" + type.ToLower() + "');", true);
        }

        protected void btneditProfile_Click(object sender, EventArgs e)
        {
            Session["email"] = LbEmail.Text;
            Response.Redirect("editprofile.aspx");
        }


        protected void btnchangeAvatar_Click(object sender, EventArgs e)
        {

        }

        protected void btnEditBio_Click(object sender, EventArgs e)
        {

        }

        protected void btnEditCaption_Click(object sender, EventArgs e)
        {

        }
    }
}