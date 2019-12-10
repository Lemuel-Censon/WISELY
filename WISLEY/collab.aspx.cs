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
        public List<Post> allPosts = new Post().SelectAll();

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        public bool ValidateInput()
        {
            LblMsg.Text = String.Empty;
            bool valid = true;
            if (String.IsNullOrEmpty(tbtitle.Text))
            {
                LblMsg.Text += "Please enter a title!<br/>";
                LblMsg.ForeColor = Color.Red;
                valid = false;
            }
            if (String.IsNullOrEmpty(tbcontent.Text))
            {
                LblMsg.Text += "Please enter some content!<br/>";
                LblMsg.ForeColor = Color.Red;
                valid = false;
            }
            return valid;
        }

        protected void btnpost_Click(object sender, EventArgs e)
        {
            if (ValidateInput())
            {
                LblMsg.Text = "";
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
}