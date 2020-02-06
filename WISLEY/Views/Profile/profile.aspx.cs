using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WISLEY.BLL.Collab;
using WISLEY.BLL.Profile;
using WISLEY.BLL.Quiz;

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

                if (!Page.IsPostBack)
                {
                    User user = new User().SelectById(userid.Value);
                    LbEmail.Text = user.email;
                    LbName.Text = user.name;
                    LbType.Text = user.userType;
                    LbWISPoints.Text = user.points.ToString();
                    LbBio.Text = user.bio;
                    TbBio.Text = user.bio;
                    LbDob.Text = "Date of Birth: ";
                    LbContact.Text = "Contact Number: ";
                    if (!String.IsNullOrEmpty(user.dob))
                    {
                        LbDob.Text += user.dob;
                    }
                    else
                    {
                        LbDob.Text += "Not set";
                    }
                    if (!String.IsNullOrEmpty(user.contactNo))
                    {
                        LbContact.Text += user.contactNo;
                    }
                    else
                    {
                        LbContact.Text += "Not set";
                    }
                    if (user.privacy == "T")
                    {
                        LbPrivacy.Text = "Privacy is On";
                    }
                    else
                    {
                        LbPrivacy.Text = "Privacy is Off";
                    }
                    if (String.IsNullOrEmpty(user.bio))
                    {
                        LbBio.Text = "Currently Empty";
                    }
                    else
                    {
                        LbBio.Text = user.bio;
                    }
                    postcount();
                    List <Post> userposts = new Post().SelectByUser(userid.Value);
                    List <Quiz> quizposts = new Quiz().SelectByUserId(userid.Value);
                    userpost.DataSource = userposts;
                    userpost.DataBind();
                    userquiz.DataSource = quizposts;
                    userquiz.DataBind();
                }
            }
            else
            {
                Session["error"] = "You must be logged in to view profile!";
                Response.Redirect(Page.ResolveUrl("~/Views/index.aspx"));
            }

        }

        public User user()
        {
            User user = new User().SelectByEmail(Session["email"].ToString());
            return user;
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
            Response.Redirect(Page.ResolveUrl("~/Views/Gacha/Avatar.aspx"));
        }

        protected void btnEditBio_Click(object sender, EventArgs e)
        {
            TbBio.Visible = true;
            btnCancelChanges.Visible = true;
            btnSaveChanges.Visible = true;
            btnEditBio.Visible = false;
            LbBioDesc.Visible = true;
        }

        protected void btnCancelChanges_Click(object sender, EventArgs e)
        {
            TbBio.Visible = false;
            btnCancelChanges.Visible = false;
            btnSaveChanges.Visible = false;
            btnEditBio.Visible = true;
            LbBioDesc.Visible = false;
        }

        protected void btnSaveChanges_Click(object sender, EventArgs e)
        {
            string email = LbEmail.Text.ToString();
            string bio = TbBio.Text;

            User user = new User();
            int result = user.UpdateBio(email, bio);
            if (result == 1)
            {
                TbBio.Visible = false;
                btnCancelChanges.Visible = false;
                btnSaveChanges.Visible = false;
                btnEditBio.Visible = true;
                LbBioDesc.Visible = false;
                Session["success"] = "Your changes have been saved!";
                Response.Redirect("profile.aspx");
            }
            else
            {
                toast(this, "Changes were unable to be saved, please inform system administrator!", "Error", "error");
            }
        }

        protected void userpost_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (userpost.Items.Count < 1)
            {
                if (e.Item.ItemType == ListItemType.Footer)
                {
                    e.Item.FindControl("LbErr").Visible = true;
                }
            }
        }

        protected void userpost_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            if (e.CommandName == "viewpost")
            {
                Session["postId"] = e.CommandArgument.ToString();
                Response.Redirect(Page.ResolveUrl("~/Views/Board/viewpost.aspx"));
            }
        }

        protected void userquiz_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (userquiz.Items.Count < 1)
            {
                if (e.Item.ItemType == ListItemType.Footer)
                {
                    e.Item.FindControl("LbErr").Visible = true;
                }
            }
        }

        protected void userquiz_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            if (e.CommandName == "viewquiz")
            {
                Response.Redirect(Page.ResolveUrl("~/Views/Quiztool/viewquiz.aspx?id=" + e.CommandArgument.ToString()));
            }

            if (e.CommandName == "deletequiz")
            {
                int result = new Quiz().DeleteById(e.CommandArgument.ToString());
                if (result == 1)
                {
                    Session["success"] = "Quiz deleted!";
                    Response.Redirect("profile.aspx");
                }
                else
                {
                    toast(this, "Quiz could not be deleted, please inform system administrator!", "Error", "error");
                }
            }

            if (e.CommandName == "editquiz")
            {
                Session["quizId"] = e.CommandArgument.ToString();
                Response.Redirect(Page.ResolveUrl("~/Views/Quiztool/editquiz.aspx"));
            }
        }
    }
}