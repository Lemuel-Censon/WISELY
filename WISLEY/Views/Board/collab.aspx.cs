﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WISLEY.BLL.Collab;

namespace WISLEY
{
    public partial class collab : System.Web.UI.Page
    {
        public List<Post> allPosts()
        {
            List<Post> allPosts = new Post().SelectAll();
            return allPosts;
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            allPosts();
        }

        public void toast(Page page, string message, string title, string type)
        {
            page.ClientScript.RegisterStartupScript(page.GetType(), "toastmsg", "toastnotif('" + message + "','" + title + "','" + type.ToLower() + "');", true);
        }

        public bool ValidateInput(string title, string content)
        {
            bool valid = false;
            if (String.IsNullOrEmpty(title))
            {
                toast(this.Page, "Please enter a title!", "Error", "error");
            }
            if (String.IsNullOrEmpty(content))
            {
                toast(this.Page, "Please enter some content!", "Error", "error");
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
                    string filename = Path.GetFileName(fileUpload.FileName);
                    fileUpload.SaveAs(Server.MapPath("~/Public/uploads/") + filename);
                    toast(this.Page, "File uploaded!", "Success", "success");
                    save = true;
                }
                catch (Exception)
                {
                    toast(this.Page, "The file could not be uploaded.", "Error", "error");
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

                Post post = new Post(title, content, "100", "100", date);
                int result = post.AddPost();

                if (result == 1)
                {
                    toast(this.Page, "Post Added!", "Success", "success");
                    tbtitle.Text = "";
                    tbcontent.Text = "";
                    postinfo.DataSourceID = "postdata";
                }
                else
                {
                    toast(this.Page, "Unable to add post, please inform system administrator!", "Error", "error");
                    tbtitle.Text = "";
                    tbcontent.Text = "";
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

            if (e.CommandName == "editpost")
            {
                e.Item.FindControl("posttitle").Visible = false;
                e.Item.FindControl("postcontent").Visible = false;
                e.Item.FindControl("btnView").Visible = false;
                e.Item.FindControl("Uptitle").Visible = true;
                e.Item.FindControl("Upcontent").Visible = true;
                e.Item.FindControl("btncancel").Visible = true;
                e.Item.FindControl("btnsave").Visible = true;
            }

            if (e.CommandName == "cancel")
            {
                e.Item.FindControl("posttitle").Visible = true;
                e.Item.FindControl("postcontent").Visible = true;
                e.Item.FindControl("btnView").Visible = true;
                e.Item.FindControl("Uptitle").Visible = false;
                e.Item.FindControl("Upcontent").Visible = false;
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
                        toast(this.Page, "Changes saved!", "Sucess", "success");
                        e.Item.FindControl("posttitle").Visible = true;
                        e.Item.FindControl("postcontent").Visible = true;
                        e.Item.FindControl("btnView").Visible = true;
                        e.Item.FindControl("Uptitle").Visible = false;
                        e.Item.FindControl("Upcontent").Visible = false;
                        e.Item.FindControl("btncancel").Visible = false;
                        e.Item.FindControl("btnsave").Visible = false;
                        postinfo.DataSourceID = "postdata";
                    }
                    else
                    {
                        toast(this.Page, "Changes were unable to be saved, please inform system administrator!", "Error", "error");
                        e.Item.FindControl("posttitle").Visible = true;
                        e.Item.FindControl("postcontent").Visible = true;
                        e.Item.FindControl("btnView").Visible = true;
                        e.Item.FindControl("Uptitle").Visible = false;
                        e.Item.FindControl("Upcontent").Visible = false;
                        e.Item.FindControl("btncancel").Visible = false;
                        e.Item.FindControl("btnsave").Visible = false;
                    }
                }
            }
        }

    }
}