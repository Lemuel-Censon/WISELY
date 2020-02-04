using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WISLEY.BLL.Quiz;

namespace WISLEY.Views.Quiztool
{
    public partial class viewquiz : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["email"] != null)
            {
                if (Request.QueryString["id"] != null)
                {
                    LbQuizID.Value = Request.QueryString["id"];
                    List <Question> questions = new Question().SelectByQuiz(LbQuizID.Value);
                    questionitems.DataSource = questions;
                    questionitems.DataBind();
                }
                else
                {
                    Session["error"] = "Please choose a quiz to view!";
                    Response.Redirect("quizzes.aspx");
                }
            }
            else
            {
                Session["error"] = "You need to be logged in to view a quiz!";
                Response.Redirect(Page.ResolveUrl("~/Views/index.aspx"));
            }
        }

        public Quiz quiz()
        {
            return new Quiz().SelectById(Request.QueryString["id"]);
        }
    }
}