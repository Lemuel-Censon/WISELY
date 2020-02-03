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
                if (Session["success"] != null)
                {
                    toast(this, Session["success"].ToString(), "Success", "success");
                    Session["success"] = null;
                }
                if (Session["quizId"] != null)
                {
                    if (!Page.IsPostBack)
                    {
                        Quiz quiz = new Quiz().SelectById(Session["quizId"].ToString());
                        TbTitle.Text = quiz.title;
                        TbDesc.Text = quiz.description;
                        LbQuestionCount.Text = quiz.totalquestions.ToString();
                    }
                    LbQuizId.Text = Session["quizId"].ToString();
                    List<Question> questions = new Question().SelectQuestion(Session["quizId"].ToString());
                    question.DataSource = questions;
                    question.DataBind();
                }
            }
            else
            {
                Session["error"] = "You must be logged in to have access to the quiz creator!";
                Response.Redirect(Page.ResolveUrl("~/Views/index.aspx"));
            }
        }

        public void toast(Page page, string message, string title, string type)
        {
            page.ClientScript.RegisterStartupScript(page.GetType(), "toastmsg", "toastnotif('" + message + "','" + title + "','" + type.ToLower() + "');", true);
        }


        protected void btnSaveQuiz_Click(object sender, EventArgs e)
        {
            Session["success"] = "Your quiz has been saved! You may view it in your profile.";
            Response.Redirect(Page.ResolveUrl("~/Views/Profile/profile.aspx"));
        }

        protected void btnaddQuestion_Click(object sender, EventArgs e)
        {
            int questionNo = int.Parse(LbQuestionCount.Text) + 1;
            Question question = new Question("", questionNo.ToString(), "", "", "", "", "", LbQuizId.Text);
            Quiz quiz = new Quiz();
            int result = question.AddQuestion();
            if (result == 1)
            {
                quiz.UpdateTotalQuestions(questionNo, LbQuizId.Text);
                Session["success"] = "Question added!";
                Response.Redirect("editquiz.aspx");
            }
            else
            {
                toast(this, "Question cannot be added, please contact system administrator!", "Error", "error");
            }
        }

        protected void question_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (question.Items.Count < 1)
            {
                if (e.Item.ItemType == ListItemType.Footer)
                {
                    e.Item.FindControl("LbErr").Visible = true;
                }
            }
        }

        protected void question_ItemCommand(object source, RepeaterCommandEventArgs e)
        {

        }

        protected void DdlCorrect_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}