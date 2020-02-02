using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WISLEY.BLL.Collab;
using WISLEY.BLL.Group;
using WISLEY.BLL.Profile;

namespace WISLEY
{
    public partial class collab : System.Web.UI.Page
    {

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["email"] != null)
            {
                LbEmail.Text = Session["email"].ToString();
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
                if (Request.QueryString["groupId"] != null)
                {
                    if (!Page.IsPostBack)
                    {
                        List<Post> posts = new Post().SelectByGrp(Request.QueryString["groupId"]);
                        postinfo.DataSource = posts;
                        postinfo.DataBind();
                    }
                }
                else
                {
                    List<Group> groups = new Group().getGroupsJoined(LbEmail.Text);
                    if (!Page.IsPostBack)
                    {
                        ddlgrp.Items.Insert(0, "Select Group");
                        for (int i = 0; i < groups.Count; i++)
                        {
                            try
                            {
                                ListItem item = new ListItem(groups[i].name, groups[i].id.ToString());
                                ddlgrp.Items.Insert(i + 1, item);
                            }
                            catch { }
                            
                        }
                        List<Post> posts = new Post().SelectByEmail(LbEmail.Text);
                        postinfo.DataSource = posts;
                        postinfo.DataBind();
                    }
                    ddlgrp.Visible = true; 
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

        public bool ValidateInput(string title, string content)
        {
            bool valid = false;
            if (String.IsNullOrEmpty(title))
            {
                toast(this, "Please enter a title!", "Error", "error");
            }
            else if (String.IsNullOrEmpty(content))
            {
                toast(this, "Please enter some content!", "Error", "error");
            }
            else if (ddlgrp.SelectedIndex == 0 && Request.QueryString["groupId"] == null)
            {
                toast(this, "Please select a group to post in!", "Error", "error");
            }
            else
            {
                valid = true;
            }
            return valid;
        }

        public bool EditValidateInput(string title, string content)
        {
            bool valid = false;
            if (String.IsNullOrEmpty(title))
            {
                toast(this, "Please enter a title!", "Error", "error");
            }
            else if (String.IsNullOrEmpty(content))
            {
                toast(this, "Please enter some content!", "Error", "error");
            }
            else
            {
                valid = true;
            }
            return valid;
        }

        public bool storeFile()
        {
            bool save = false;

            if (fileUpload.HasFile)
            {
                try
                {
                    if (fileUpload.PostedFile.ContentLength < 3000000)
                    {
                        string filename = Path.GetFileName(fileUpload.FileName);
                        fileUpload.SaveAs(Server.MapPath("~/Public/uploads/") + filename);
                        toast(this, "File uploaded!", "Success", "success");
                        save = true;
                    }
                    else
                    {
                        toast(this, "The file has to be less than 3MB!", "Error", "error");
                    }
                }
                catch (Exception)
                {
                    toast(this, "The file could not be uploaded.", "Error", "error");
                }
            }
            else
            {
                save = true;
            }

            return save;
        }

        protected void btnpost_Click(object sender, EventArgs e)
        {
            if (ValidateInput(tbtitle.Text, tbcontent.Text) && storeFile())
            {
                string title = tbtitle.Text;
                string content = tbcontent.Text;
                string date = DateTime.Now.ToString("dd/MM/yyyy");
                string userId = user().id.ToString();
                string grpId;
                if (Request.QueryString["groupId"] != null)
                {
                    grpId = Request.QueryString["groupId"];
                }
                else
                {
                    grpId = ddlgrp.SelectedValue;
                }

                Post post = new Post(title, content, userId, grpId, date);
                int result = post.AddPost();

                if (result == 1)
                {
                    Session["success"] = "Post Added!";
                    Response.Redirect("collab.aspx");
                }
                else
                {
                    toast(this, "Unable to add post, please inform system administrator!", "Error", "error");
                }
            }
        }

        protected void postinfo_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            if (e.CommandName == "viewpost")
            {
                string postId = e.CommandArgument.ToString();
                Session["postId"] = postId;
                List<Post> currpost = new Post().SelectByID(postId);
                Post post = new Post();
                post.UpdateView(postId, currpost[0].views + 1);
                Response.Redirect("viewpost.aspx");
            }

            if (e.CommandName == "viewprofile")
            {
                Response.Redirect(Page.ResolveUrl("~/Views/Profile/profile.aspx?id="+ e.CommandArgument.ToString()));
            }

            if (e.CommandName == "like")
            {
                string postId = e.CommandArgument.ToString();
                int userId = user().id;
                int likeresult = 0;
                int updateresult = 0;
                List<Post> currpost = new Post().SelectByID(postId);
                Post post = new Post();

                List<string> userfavs = new PostLikes().SelectLikesByUser(userId);
                if (!userfavs.Contains(postId))
                {
                    PostLikes like = new PostLikes(userId, postId);
                    likeresult = like.AddLike();
                    updateresult = post.UpdateLikes(postId, currpost[0].likes + 1);

                    if (likeresult == 1 && updateresult == 1)
                    {
                        toast(this, "Post liked!", "Success", "success");
                    }
                    else
                    {
                        toast(this, "There was an error while liking post, please try again later!", "Error", "error");
                    }
                }

                else
                {
                    PostLikes like = new PostLikes();
                    likeresult = like.Unlike(userId, postId);
                    updateresult = post.UpdateLikes(postId, currpost[0].likes - 1);

                    if (likeresult == 1 && updateresult == 1)
                    {
                        toast(this, "Post unliked!", "Success", "success");
                    }
                    else
                    {
                        toast(this, "There was an error while unliking post, please try again later!", "Error", "error");
                    }
                }

                if (Request.QueryString["groupId"] != null)
                {
                    List<Post> posts = new Post().SelectByGrp(Request.QueryString["groupId"]);
                    postinfo.DataSource = posts;
                    postinfo.DataBind();
                }
                else
                {
                    List<Post> posts = new Post().SelectByEmail(LbEmail.Text);
                    postinfo.DataSource = posts;
                    postinfo.DataBind();
                }

            }

            if (e.CommandName == "editpost")
            {
                e.Item.FindControl("posttitle").Visible = false;
                e.Item.FindControl("postcontent").Visible = false;
                e.Item.FindControl("btnView").Visible = false;
                e.Item.FindControl("tbUptitle").Visible = true;
                e.Item.FindControl("tbUpcontent").Visible = true;
                e.Item.FindControl("btncancel").Visible = true;
                e.Item.FindControl("btnsave").Visible = true;
            }

            if (e.CommandName == "cancel")
            {
                e.Item.FindControl("posttitle").Visible = true;
                e.Item.FindControl("postcontent").Visible = true;
                e.Item.FindControl("btnView").Visible = true;
                e.Item.FindControl("tbUptitle").Visible = false;
                e.Item.FindControl("tbUpcontent").Visible = false;
                e.Item.FindControl("btncancel").Visible = false;
                e.Item.FindControl("btnsave").Visible = false;
            }

            if (e.CommandName == "save")
            {
                string postId = e.CommandArgument.ToString();
                TextBox title = e.Item.FindControl("tbUptitle") as TextBox;
                TextBox content = e.Item.FindControl("tbUpcontent") as TextBox;
                string dateedit = DateTime.Now.ToString("dd/MM/yyyy");
                if (EditValidateInput(title.Text, content.Text)){
                    Post post = new Post();
                    int result = post.UpdatePost(postId, title.Text, content.Text, dateedit);
                    if (result == 1)
                    {
                        toast(this, "Changes saved!", "Success", "success");
                        e.Item.FindControl("posttitle").Visible = true;
                        e.Item.FindControl("postcontent").Visible = true;
                        e.Item.FindControl("btnView").Visible = true;
                        e.Item.FindControl("tbUptitle").Visible = false;
                        e.Item.FindControl("tbUpcontent").Visible = false;
                        e.Item.FindControl("btncancel").Visible = false;
                        e.Item.FindControl("btnsave").Visible = false;
                        if (Request.QueryString["groupId"] != null)
                        {
                            List<Post> posts = new Post().SelectByGrp(Request.QueryString["groupId"]);
                            postinfo.DataSource = posts;
                            postinfo.DataBind();
                        }
                        else
                        {
                            List<Post> posts = new Post().SelectByEmail(LbEmail.Text);
                            postinfo.DataSource = posts;
                            postinfo.DataBind();
                        }
                    }
                    else
                    {
                        toast(this, "Changes were unable to be saved, please inform system administrator!", "Error", "error");
                        e.Item.FindControl("posttitle").Visible = true;
                        e.Item.FindControl("postcontent").Visible = true;
                        e.Item.FindControl("btnView").Visible = true;
                        e.Item.FindControl("tbUptitle").Visible = false;
                        e.Item.FindControl("tbUpcontent").Visible = false;
                        e.Item.FindControl("btncancel").Visible = false;
                        e.Item.FindControl("btnsave").Visible = false;
                    }
                }
            }

            if (e.CommandName == "delpost")
            {
                string postId = e.CommandArgument.ToString();
                Post post = new Post();
                int result = post.DelPostUpdate(postId, "deleted");
                if (result == 1)
                {
                    Session["success"] = "Post deleted successfully!";
                    Response.Redirect("collab.aspx");
                }
                else
                {
                    Session["error"] = "Post was unable to be deleted, please inform system administrator!";
                    Response.Redirect("collab.aspx");
                }
            }
        }

        protected void postinfo_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                HiddenField postuser = (HiddenField)e.Item.FindControl("postuserID");
                if (int.Parse(postuser.Value) != user().id)
                {
                    e.Item.FindControl("btnEdit").Visible = false;
                    e.Item.FindControl("delete").Visible = false;
                    e.Item.FindControl("btnLike").Visible = true;
                }
            }

            if (e.Item.ItemType == ListItemType.Footer && postinfo.Items.Count < 1)
            {
                e.Item.FindControl("LbErr").Visible = true;
            }

        }

    }
}