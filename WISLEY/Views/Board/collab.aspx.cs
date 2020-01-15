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
        public int postcount()
        {
            List<Post> allPosts = new Post().SelectAll();
            return allPosts.Count;
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["email"] != null)
            {
                postcount();
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
                if (Session["postadd"] != null)
                {
                    toast(this, Session["postadd"].ToString(), "Success", "success");
                    Session["postadd"] = null;
                }
                if (Request.QueryString["groupId"] != null)
                {
                    postdata.SelectCommand = "SELECT * FROM POST WHERE groupId = " + Request.QueryString["groupId"] + " ORDER BY Id DESC";
                }
                else
                {
                    List<Group> groups = new Group().getGroupsJoined(LbEmail.Text);
                    if (!Page.IsPostBack)
                    {
                        ddlgrp.Items.Insert(0, "Select Group");
                        for (int i = 0; i < groups.Count; i++)
                        {
                            ListItem item = new ListItem(groups[i].name, groups[i].id.ToString());
                            ddlgrp.Items.Insert(i + 1, item);
                        }
                    }
                    ddlgrp.Visible = true;
                    postdata.SelectCommand = "SELECT * FROM POST WHERE userId in (Select Id from [User] where email = '" + LbEmail.Text + "') ORDER BY Id DESC";
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
            else if (ddlgrp.SelectedValue == "-1" && Request.QueryString["groupId"] != null)
            {
                toast(this, "Please select a group to post in!", "Error", "error");
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
                    Session["postadd"] = "Post Added!";
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
                Session["postId"] = e.CommandArgument.ToString();
                Response.Redirect("viewpost.aspx");
            }

            if (e.CommandName == "viewprofile")
            {
                Response.Redirect(Page.ResolveUrl("~/Views/Profile/profile.aspx?email="+ e.CommandArgument.ToString()));
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
                if (ValidateInput(title.Text, content.Text)){
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
                        postinfo.DataSourceID = "postdata";
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
        }

        protected void postinfo_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            LinkButton userId = (LinkButton)e.Item.FindControl("viewprofile");
            if (userId.Text != LbEmail.Text)
            {
                e.Item.FindControl("btnEdit").Visible = false;
            }
        }
    }
}