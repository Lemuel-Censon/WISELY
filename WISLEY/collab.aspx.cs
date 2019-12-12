using System;
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
        public List<Post> allPosts = new Post().SelectAll();

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        public bool ValidateInput()
        {
            LblMsg.Text = String.Empty;
            bool valid = false;
            if (String.IsNullOrEmpty(tbtitle.Text))
            {
                LblMsg.Text += "Please enter a title!<br/>";
                LblMsg.ForeColor = Color.Red;
            }
            if (String.IsNullOrEmpty(tbcontent.Text))
            {
                LblMsg.Text += "Please enter some content!<br/>";
                LblMsg.ForeColor = Color.Red;
            }
            if (String.IsNullOrEmpty(LblMsg.Text))
            {
                valid = true;
            }
            return valid;
        }

        protected void btnpost_Click(object sender, EventArgs e)
        {
            if (ValidateInput())
            {
                LblMsg.Text = String.Empty;
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
                    LblMsg.Text = "Unable to add post. Please inform system administrator!";
                    LblMsg.ForeColor = Color.Red;
                }
            }
        }

        protected void btnUpload_Click(object sender, EventArgs e)
        {
            if (fileUpload.HasFile)
            {
                try
                {
                    string filename = Path.GetFileName(fileUpload.FileName);
                    fileUpload.SaveAs(Server.MapPath("/Uploads/") + filename);
                    LbStatus.Text = "File uploaded!";
                    LbStatus.ForeColor = Color.Green;
                }
                catch (Exception ex)
                {
                    LbStatus.Text = "The file could not be uploaded. The following error occured: " + ex.Message;
                    LbStatus.ForeColor = Color.Red;
                }
            }
        }
    }
}