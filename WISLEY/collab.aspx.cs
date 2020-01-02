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
        public Comment postComments = new Comment();

        public List<Post> allPosts()
        {
            List<Post> allPosts = new Post().SelectAll();
            return allPosts;
        }

        public void displaybtns()
        {
            foreach (var id in new Post().SelectIDs())
            {
                Button btn = new Button();
                btn.ID = id;
                btn.Text = new Post().SelectByID(id).title;
                btn.CssClass = "btn btn-sm btn-success";
                btn.Click += new EventHandler(btnView_Click);
                btncontainer.Controls.Add(btn);
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            allPosts();
            displaybtns();
        }

        public void toast(Page page, string message, string title, string type)
        {
            page.ClientScript.RegisterStartupScript(page.GetType(), "toastmsg", "toastnotif('" + message + "','" + title + "','" + type.ToLower() + "');", true);
        }

        public bool ValidateInput()
        {
            bool valid = false;
            if (String.IsNullOrEmpty(tbtitle.Text))
            {
                toast(this.Page, "Please enter a title!", "Error", "error");
            }
            if (String.IsNullOrEmpty(tbcontent.Text))
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
                    fileUpload.SaveAs(Server.MapPath("/Uploads/") + filename);
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
            if (ValidateInput() && storeFile())
            {
                string title = tbtitle.Text;
                string content = tbcontent.Text;

                Post post = new Post(title, content, "100", "100", DateTime.Today);
                int result = post.AddPost();

                if (result == 1)
                {
                    toast(this.Page, "Post Added!", "Success", "success");
                    tbtitle.Text = "";
                    tbcontent.Text = "";
                }
                else
                {
                    toast(this.Page, "Unable to add post, please inform system administrator!", "Error", "error");
                }
            }
        }

        protected void btnView_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            Session["postId"] = btn.ID;
            Response.Redirect("viewpost.aspx");
        }
    }
}