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
                }
            }
        }

        protected void postinfo_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            Session["postId"] = ((HiddenField)e.Item.FindControl("LbID")).Value;
            Response.Redirect("viewpost.aspx");
        }
    }
}