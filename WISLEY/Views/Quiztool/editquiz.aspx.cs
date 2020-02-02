using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WISLEY.BLL.Quiz;

namespace WISLEY.Views.Quiztool
{
    public partial class editquiz : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["email"] != null)
            {
                if (Session["quizId"] != null)
                {
                    if (!Page.IsPostBack)
                    {
                        Quiz quiz = new Quiz().SelectById(Session["quizId"].ToString());
                        TbTitle.Text = quiz.title;
                        TbDesc.Text = quiz.description;
                    }
                    LbQuizId.Text = Session["quizId"].ToString();
                }
            }
            else
            {
                Session["error"] = "You must be logged in to have access to the quiz creator!";
                Response.Redirect(Page.ResolveUrl("~/Views/index.aspx"));
            }
        }

        protected void btnSaveQuiz_Click(object sender, EventArgs e)
        {
            Response.Redirect(Page.ResolveUrl("~/Views/Profile/profile.aspx"));
        }
    }
}