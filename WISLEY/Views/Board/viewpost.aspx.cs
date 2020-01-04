using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WISLEY.BLL.Collab;

namespace WISLEY
{
    public partial class viewpost : System.Web.UI.Page
    {
        public Post post()
        {
            Post post = new Post().SelectByID(LbPostID.Text);
            return post;
        }

        public int commcount()
        {
            List<Comment> allComments = new Comment().SelectByPost(LbPostID.Text);
            return allComments.Count;
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["postId"] != null)
            {
                LbPostID.Text = Session["postId"].ToString();
                post();
                commcount();
                commentdata.SelectCommand = "SELECT * FROM COMMENT WHERE postId = " + LbPostID.Text + "ORDER BY datecreated DESC";
            }
            else
            {
                Response.Redirect("index.aspx");
            }
        }

        public void toast(Page page, string message, string title, string type)
        {
            ScriptManager.RegisterClientScriptBlock(page, page.GetType(), "toastmsg", "toastnotif('" + message + "','" + title + "','" + type.ToLower() + "');", true);
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

                Comment comment = new Comment(postId, "100", content, date);
                int result = comment.AddComment();

                if (result == 1)
                {
                    toast(this, "Comment posted!", "Success", "success");
                    tbcomment.Text = "";
                }
                else
                {
                    toast(this, "Unable to post comment, please inform system administrator!", "Error", "error");
                }
            }
        }

        protected void commentinfo_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
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
                        commentinfo.DataSourceID = "commentdata";
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
        }
    }
}