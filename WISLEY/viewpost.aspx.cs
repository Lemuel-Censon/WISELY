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
        public Post post = new Post();
        public List<Comment> allComments()
        {
            List<Comment> allComments = new Comment().SelectAll();
            return allComments;
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            allComments();
        }

        public void toast(Page page, string message, string title, string type)
        {
            page.ClientScript.RegisterStartupScript(page.GetType(), "toastmsg", "toastnotif('" + message + "','" + title + "','" + type.ToLower() + "');", true);
        }

        public bool ValidateInput()
        {
            bool valid = true;
            if (String.IsNullOrEmpty(tbcomment.Text))
            {
                toast(this.Page, "Please enter some content!", "Error", "error");
                valid = false;
            }
            return valid;
        }

        protected void btncomment_Click(object sender, EventArgs e)
        {
            if (ValidateInput())
            {
                string content = tbcomment.Text;

                Comment comment = new Comment("100", "100", content);
                int result = comment.AddComment();

                if (result == 1)
                {
                    toast(this.Page, "Comment posted!", "Success", "success");
                }
                else
                {
                    toast(this.Page, "Unable to post comment, please inform system administrator!", "Error", "error");
                }
            }
        }
    }
}