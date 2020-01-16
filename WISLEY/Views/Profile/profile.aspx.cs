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
            if (Session["email"] != null && Session["uid"] != null)
            {
                LbEmail.Text = Session["email"].ToString();
                hidotheremail.Value = Session["uid"].ToString();
                userid.Value = Session["uid"].ToString();
                
                if (Session["success"] != null)
                {
                    toast(this, Session["success"].ToString(), "Success", "success");
                    Session["success"] = null;
                }
                if (Request.QueryString["id"] != null)
                {
                    userid.Value = Request.QueryString["id"];
                }

                User user = new User().SelectById(userid.Value);
                LbName.Text = user.name;
                LbType.Text = user.userType;
                LbWISPoints.Text = user.points.ToString();
                if (user.dob != string.Empty)
                {
                    LbDob.Visible = true;
                    LbDob.Text = "Born in " + user.dob;
                }
                else
                {
                    LbDob.Visible = false;
                }
                if (user.contactNo != string.Empty)
                {
                    LbContact.Visible = true;
                    LbContact.Text = "Contact No: " + user.contactNo;
                }
                else
                {
                    LbContact.Visible = false;
                }
                if (user.privacy == "T")
                {
                    LbPrivacy.Text = "Privacy is On";
                }
                else
                {
                    LbPrivacy.Text = "Privacy is Off";
                }
                postcount();
                userpostdata.SelectCommand = "SELECT * FROM POST WHERE userId = '" + userid.Value + "' ORDER BY Id DESC";
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
            Response.Redirect(Page.ResolveUrl("~/Views/Gacha/gacha.aspx"));
        }

        protected void btnEditBio_Click(object sender, EventArgs e)
        {

        }

        protected void btnEditCaption_Click(object sender, EventArgs e)
        {

        }
    }
}