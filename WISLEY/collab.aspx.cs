using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WISLEY.BLL.Collab;

namespace WISLEY
{
    public partial class collab : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            RefreshGridView();
        }

        public void RefreshGridView()
        {
            Post post = new Post();
            List<Post> postlist = post.SelectAll();
            GvPosts.Visible = true;
            GvPosts.DataSource = postlist;
            GvPosts.DataBind();
        }

        protected void btnpost_Click(object sender, EventArgs e)
        {
            string title = tbtitle.Text;
            string content = tbcontent.Text;

            Post post = new Post("Test", "How to do", "1", "1");
            int result = post.AddPost();

            if (result == 1)
            {
                LblMsg.Text = "Post Added!";
                LblMsg.ForeColor = Color.Green;
            }
            else
            {
                LblMsg.Text = "Unable to Add Post. Please inform system administrator!";
                LblMsg.ForeColor = Color.Red;
            }
        }
    }
}