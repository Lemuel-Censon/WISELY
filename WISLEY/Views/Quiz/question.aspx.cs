using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WISLEY.Views.Quiz
{
    public partial class question : System.Web.UI.Page
    {

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["next"] != null)
            {
                LbQuestionNo.Text = Session["next"].ToString();
            }
            else
            {
                if (Session["previous"] != null)
                {
                    LbQuestionNo.Text = Session["previous"].ToString();
                }
            }
            if (LbQuestionNo.Text == "1")
            {
                btnPrevious.Visible = false;
            }
            if (DdlOptions.SelectedItem.Value == "2")
            {
                TbOption3.Visible = false;
                LbOption3.Visible = false;
                TbOption4.Visible = false;
                LbOption4.Visible = false;
                TbOption5.Visible = false;
                LbOption5.Visible = false;
            }
            else if (DdlOptions.SelectedItem.Value == "3")
            {
                TbOption3.Visible = true;
                LbOption3.Visible = true;
                TbOption4.Visible = false;
                LbOption4.Visible = false;
                TbOption5.Visible = false;
                LbOption5.Visible = false;
            }
            else if (DdlOptions.SelectedItem.Value == "4")
            {
                TbOption3.Visible = true;
                LbOption3.Visible = true;
                TbOption4.Visible = true;
                LbOption4.Visible = true;
                TbOption5.Visible = false;
                LbOption5.Visible = false;
            }
            else if (DdlOptions.SelectedItem.Value == "5")
            {
                TbOption3.Visible = true;
                LbOption3.Visible = true;
                TbOption4.Visible = true;
                LbOption4.Visible = true;
                TbOption5.Visible = true;
                LbOption5.Visible = true;
            }
        }

        protected void DdlOptions_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (DdlOptions.SelectedItem.Value == "2")
            {
                TbOption3.Visible = false;
                LbOption3.Visible = false;
                TbOption4.Visible = false;
                LbOption4.Visible = false;
                TbOption5.Visible = false;
                LbOption5.Visible = false;
            }
            else if (DdlOptions.SelectedItem.Value == "3")
            {
                TbOption3.Visible = true;
                LbOption3.Visible = true;
                TbOption4.Visible = false;
                LbOption4.Visible = false;
                TbOption5.Visible = false;
                LbOption5.Visible = false;
            }
            else if (DdlOptions.SelectedItem.Value == "4")
            {
                TbOption3.Visible = true;
                LbOption3.Visible = true;
                TbOption4.Visible = true;
                LbOption4.Visible = true;
                TbOption5.Visible = false;
                LbOption5.Visible = false;
            }
            else if (DdlOptions.SelectedItem.Value == "5")
            {
                TbOption3.Visible = true;
                LbOption3.Visible = true;
                TbOption4.Visible = true;
                LbOption4.Visible = true;
                TbOption5.Visible = true;
                LbOption5.Visible = true;
            }
        }
        int questionNo = 0;
        protected void btnNext_Click(object sender, EventArgs e)
        {
            questionNo = int.Parse(LbQuestionNo.Text);
            questionNo += 1;
            Session["next"] = questionNo.ToString();
            Session["previous"] = null;
            Response.Redirect("question.aspx");
        }

        protected void btnPrevious_Click(object sender, EventArgs e)
        {
            questionNo = int.Parse(LbQuestionNo.Text);
            questionNo -= 1;
            Session["next"] = null;
            Session["previous"] = questionNo.ToString();
            Response.Redirect("question.aspx");
        }

        protected void btnExit_Click(object sender, EventArgs e)
        {
            Response.Redirect("quizcreator.aspx");
        }
    }
}