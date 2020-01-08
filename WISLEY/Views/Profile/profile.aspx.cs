using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WISLEY
{
    public partial class profile : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["email"] != null)
            {
                LbEmail.Text = Session["email"].ToString();
                if (Session["otheremail"] != null)
                {
                    hidotheremail.Value = Session["email"].ToString();
                    LbEmail.Text = Session["otheremail"].ToString();
                }
            }
            else
            {
                Response.Redirect(Page.ResolveUrl("~/Views/index.aspx"));
            }
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