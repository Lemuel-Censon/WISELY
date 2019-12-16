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
    public partial class comment : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        public bool ValidateInput()
        {
            LbMsg.Text = String.Empty;
            bool valid = false;

            if (String.IsNullOrEmpty(tbComment.Text))
            {
                LbMsg.Text += "Please enter some content!";
                LbMsg.ForeColor = Color.Red;
            }
            if (String.IsNullOrEmpty(LbMsg.Text))
            {
                valid = true;
            }

            return valid;
        }

        protected void btnComment_Click(object sender, EventArgs e)
        {
            if (ValidateInput())
            {
                LbMsg.Text = String.Empty;
                string content = tbComment.Text;

                Comment comment = new Comment("100", "100", content);
                int result = comment.AddComment();

                if (result == 1)
                {
                    LbMsg.Text = "Comment Posted!";
                    LbMsg.ForeColor = Color.Green;
                }
                else
                {
                    LbMsg.Text = "Unable to post comment, please inform system administrator!";
                    LbMsg.ForeColor = Color.Red;
                }
            }
        }
    }
}