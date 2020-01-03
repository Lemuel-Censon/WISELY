using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WISLEY.Views.Resources
{
    public partial class fileUploadTest : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            if (FileUpload1.HasFile)
            {
                string Path = Server.MapPath("~/Public/uploads//");
                FileUpload1.SaveAs(Path + FileUpload1.FileName);
                Label1.Text = "File Uploaded";
            }
            else
            {
                Label1.Text = "No file chosen";
            }
        }
    }
}