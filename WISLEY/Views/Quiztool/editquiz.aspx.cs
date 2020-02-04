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

                if (Session["error"] != null)
                {
                    toast(this, Session["error"].ToString(), "Error", "error");
                    Session["error"] = null;
                }

                if (Session["quizId"] != null)
                {
                    LbQuizID.Value = Session["quizId"].ToString();

                    if (!Page.IsPostBack)
                    {
                        Quiz quiz = new Quiz().SelectById(LbQuizID.Value);
                        TbTitle.Text = quiz.title;
                        TbDesc.Text = quiz.description;
                        LbQuestionCount.Text = quiz.totalquestions.ToString();
                        List<Question> questions = new Question().SelectByQuiz(LbQuizID.Value);
                        question.DataSource = questions;
                        question.DataBind();
                    }
                }
            }
            else
            {
                Session["error"] = "You must be logged in to edit a quiz!";
                Response.Redirect(Page.ResolveUrl("~/Views/index.aspx"));
            }
        }

        public void toast(Page page, string message, string title, string type)
        {
            ScriptManager.RegisterClientScriptBlock(page, page.GetType(), "toastmsg", "toastnotif('" + message + "','" + title + "','" + type.ToLower() + "');", true);
        }

        public bool ValidateInput()
        {
            bool valid = true;
            if (String.IsNullOrEmpty(TbTitle.Text))
            {
                toast(this, "Please enter a title!", "Error", "error");
                valid = false;
            }

            return valid;
        }


        protected void btnSaveQuiz_Click(object sender, EventArgs e)
        {
            if (ValidateInput())
            {
                string desc = "No Description";

                if (!String.IsNullOrEmpty(TbDesc.Text))
                {
                    desc = TbDesc.Text;
                }
                int result = new Quiz().UpdateQuiz(TbTitle.Text, desc, LbQuizID.Value);

                if (result == 1)
                {
                    Session["success"] = "Quiz saved successfully! You may view it in your profile.";
                    Response.Redirect(Page.ResolveUrl("~/Views/Profile/profile.aspx"));
                }
                else
                {
                    toast(this, "Quiz could not be saved, please contact system administrator!", "Error", "error");
                }
            }
        }

        protected void btnaddQuestion_Click(object sender, EventArgs e)
        {
            int questionNo = int.Parse(LbQuestionCount.Text) + 1;
            Question newquestion = new Question("", questionNo.ToString(), "", "", "", "", "", LbQuizID.Value);
            Quiz quiz = new Quiz();
            int result = newquestion.AddQuestion();
            if (result == 1)
            {
                quiz.UpdateTotalQuestions(questionNo, LbQuizID.Value);
                toast(this, "Question added!", "Success", "success");
                List<Question> questions = new Question().SelectByQuiz(LbQuizID.Value);
                question.DataSource = questions;
                question.DataBind();
            }
            else
            {
                toast(this, "Question could not be added, please contact system administrator!", "Error", "error");
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
            if (e.CommandName == "saveqn")
            {
                string ddlselect = ((DropDownList)e.Item.FindControl("DdlCorrect")).SelectedItem.Text;
                if (ddlselect == "-- Select --")
                {
                    toast(this, "Select a correct answer!", "Error", "error");
                }
                else
                {
                    string number = e.CommandArgument.ToString();
                    string quizId = Session["quizId"].ToString();
                    string questionTitle = (e.Item.FindControl("TbQuestion") as TextBox).Text;
                    string option1 = (e.Item.FindControl("TbOption1") as TextBox).Text;
                    string option2 = (e.Item.FindControl("TbOption2") as TextBox).Text;
                    string option3 = (e.Item.FindControl("TbOption3") as TextBox).Text;
                    string option4 = (e.Item.FindControl("TbOption4") as TextBox).Text;
                    string answer = "";
                    if (ddlselect == "1")
                    {
                        answer = option1;
                    }
                    else if (ddlselect == "2")
                    {
                        answer = option2;
                    }
                    else if (ddlselect == "3")
                    {
                        answer = option3;
                    }
                    else if (ddlselect == "4")
                    {
                        answer = option4;
                    }
                    Question newquestion = new Question();
                    int result = newquestion.UpdateQuestion(number, quizId, questionTitle, option1, option2, option3, option4, answer);
                    if (result == 1)
                    {
                        toast(this, "Question saved!", "Success", "success");
                        List<Question> questions = new Question().SelectByQuiz(LbQuizID.Value);
                        question.DataSource = questions;
                        question.DataBind();
                    }
                    else
                    {
                        toast(this, "Question could be saved, please contact system administrator!", "Error", "error");
                    }
                }
            }
        }
    }
}