using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WISLEY.BLL.Collab;
using WISLEY.BLL.Notification;
using WISLEY.BLL.Profile;

namespace WISLEY
{
    public partial class viewpost : System.Web.UI.Page
    {
        public int commcount()
        {
            List<Comment> allComments = new Comment().SelectByPost(LbPostID.Text);
            return allComments.Count;
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["postId"] != null && Session["uid"] != null)
            {
                LbUserID.Value = Session["uid"].ToString();
                LbPostID.Text = Session["postId"].ToString();
                if (Session["success"] != null)
                {
                    toast(this, Session["success"].ToString(), "Success", "success");
                    Session["success"] = null;
                }
                if (Session["error"] != null)
                {
                    toast(this, Session["error"].ToString(), "Error", "error");
                    Session["error"] = null;
                }
                if (!Page.IsPostBack)
                {
                    List<Post> postinfo = new Post().SelectByID(Session["postId"].ToString());
                    post.DataSource = postinfo;
                    post.DataBind();
                    List<Comment> comments = new Comment().SelectByPost(Session["postId"].ToString());
                    commentinfo.DataSource = comments;
                    commentinfo.DataBind();
                }
            }
            else
            {
                Session["error"] = "You must be logged in to view posts!";
                Response.Redirect(Page.ResolveUrl("~/Views/index.aspx"));
            }
        }

        public void toast(Page page, string message, string title, string type)
        {
            ScriptManager.RegisterClientScriptBlock(page, page.GetType(), "toastmsg", "toastnotif('" + message + "','" + title + "','" + type.ToLower() + "');", true);
        }

        public User user()
        {
            User user = new User().SelectByEmail(Session["email"].ToString());
            return user;
        }

        public bool ValidateInput(string content)
        {
            bool valid = true;
            if (String.IsNullOrEmpty(content))
            {
                toast(this, "Please enter some content!", "Error", "error");
                valid = false;
            }
            return valid;
        }

        protected void btncomment_Click(object sender, EventArgs e)
        {
            if (ValidateInput(tbcomment.Text))
            {
                string postId = LbPostID.Text;
                string content = tbcomment.Text;
                string date = DateTime.Now.ToString("dd/MM/yyyy");

                Comment comment = new Comment(postId, LbUserID.Value, content, date);
                int result = comment.AddComment();
                Post postcreator = new Post().SelectByID(postId)[0];
                int creatorId = int.Parse(postcreator.userId);

                if (result == 1)
                {
                    if (user().id != creatorId)
                    {
                        string creatorEmail = new User().SelectById(creatorId.ToString()).email;
                        Notify notif = new Notify(user().email, creatorEmail, date, "comment");
                        notif.AddPostNotif();
                    }
                    Session["success"] = "Comment posted!";
                    Response.Redirect("viewpost.aspx");
                }
                else
                {
                    toast(this, "Unable to post comment, please inform system administrator!", "Error", "error");
                }
            }
        }

        protected void commentinfo_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            if (e.CommandName == "viewprofile")
            {
                Response.Redirect(Page.ResolveUrl("~/Views/Profile/profile.aspx?id="+ e.CommandArgument.ToString()));
            }

            if (e.CommandName == "editcomm")
            {
                e.Item.FindControl("commcontent").Visible = false;
                e.Item.FindControl("tbUpcomm").Visible = true;
                e.Item.FindControl("editbtns").Visible = true;
            }

            if (e.CommandName == "cancel")
            {
                e.Item.FindControl("commcontent").Visible = true;
                e.Item.FindControl("tbUpcomm").Visible = false;
                e.Item.FindControl("editbtns").Visible = false;
            }

            if (e.CommandName == "save")
            {
                string commId = e.CommandArgument.ToString();
                TextBox content = e.Item.FindControl("tbUpcomm") as TextBox;
                string dateedit = DateTime.Now.ToString("dd/MM/yyyy");
                if (ValidateInput(content.Text))
                {
                    Comment comment = new Comment();
                    int result = comment.UpdateComment(commId, content.Text, dateedit);
                    if (result == 1)
                    {
                        toast(this, "Changes saved!", "Success", "success");
                        e.Item.FindControl("commcontent").Visible = true;
                        e.Item.FindControl("tbUpcomm").Visible = false;
                        e.Item.FindControl("editbtns").Visible = false;
                        List<Comment> comments = new Comment().SelectByPost(LbPostID.Text);
                        commentinfo.DataSource = comments;
                        commentinfo.DataBind();
                    }
                    else
                    {
                        toast(this, "Changes were unable to be saved, please inform system administrator!", "Error", "error");
                        e.Item.FindControl("commcontent").Visible = true;
                        e.Item.FindControl("tbUpcomm").Visible = false;
                        e.Item.FindControl("editbtns").Visible = false;
                    }
                }
            }

            if (e.CommandName == "delcomm")
            {
                string commId = e.CommandArgument.ToString();
                Comment comment = new Comment();
                int result = comment.DelCommUpdate(commId, "deleted");
                if (result == 1)
                {
                    Session["success"] = "Post deleted successfully!";
                    Response.Redirect("viewpost.aspx");
                }
                else
                {
                    Session["error"] = "Post was unable to be deleted, please inform system administrator!";
                    Response.Redirect("viewpost.aspx");
                }
            }
        }

        protected void btnback_Click(object sender, EventArgs e)
        {
            Response.Redirect("collab.aspx");
        }

        protected void post_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            if (e.CommandName == "viewpost")
            {
                Response.Redirect(Page.ResolveUrl("~/Views/Profile/profile.aspx?id="+ e.CommandArgument.ToString()));
            }

            if (e.CommandName == "download")
            {
                string[] commandArgs = e.CommandArgument.ToString().Split(new char[] { ',' });
                string grpId = commandArgs[0];
                string fileName = commandArgs[1];
                string folderPath = Server.MapPath("~/Public/uploads/posts/") + grpId + "/" + user().id;

                Response.Clear();
                Response.ContentType = "application/octet-stream";
                Response.AppendHeader("content-disposition", $"filename={fileName}");
                Response.TransmitFile(folderPath + "/" + fileName);
            }
        }

        protected void commentinfo_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (commentinfo.Items.Count < 1)
            {
                if (e.Item.ItemType == ListItemType.Footer)
                {
                    e.Item.FindControl("LbErr").Visible = true;
                }
            }
            else
            {
                if (e.Item.ItemType == ListItemType.Item)
                {
                    HiddenField userId = (HiddenField)e.Item.FindControl("commuserID");
                    if (userId.Value != LbUserID.Value)
                    {
                        e.Item.FindControl("btnEdit").Visible = false;
                        e.Item.FindControl("delconfirm").Visible = false;
                    }
                }

            }

        }
    }
}