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

        protected void btncomment_Click(object sender, EventArgs e)
        {

        }
    }
}