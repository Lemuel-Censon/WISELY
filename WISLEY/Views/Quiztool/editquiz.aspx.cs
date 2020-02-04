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

        public bool ValidateQuestion()
        {
            bool valid = false;
            if (String.IsNullOrEmpty(TbQuestion.Text))
            {
                toast(this, "Please enter question title!", "Error", "error");
            }
            else if (String.IsNullOrEmpty(TbOption1.Text) || String.IsNullOrEmpty(TbOption2.Text) || String.IsNullOrEmpty(TbOption3.Text) || String.IsNullOrEmpty(TbOption4.Text))
            {
                toast(this, "Please fill in all options!", "Error", "error");
            }
            else if (DdlCorrect.SelectedIndex == -1)
            {
                toast(this, "Please select correct answer!", "Error", "error");
            }
            else
            {
                valid = true;
            }

            return valid;
        }

        public string CorrectAnswer()
        {
            string correct = "";
            if (DdlCorrect.SelectedItem.Text == "1")
            {
                correct = TbOption1.Text;
            }
            else if (DdlCorrect.SelectedItem.Text == "2")
            {
                correct = TbOption2.Text;
            }
            else if (DdlCorrect.SelectedItem.Text == "3")
            {
                correct = TbOption3.Text;
            }
            else if (DdlCorrect.SelectedItem.Text == "4")
            {
                correct = TbOption4.Text;
            }
            return correct;
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

        protected void btnSaveQn_Click(object sender, EventArgs e)
        {
            if (ValidateQuestion())
            {
                string questionname = TbQuestion.Text;
                string option1 = TbOption1.Text;
                string option2 = TbOption2.Text;
                string option3 = TbOption3.Text;
                string option4 = TbOption4.Text;
                string correct = CorrectAnswer();
                int questionNo = int.Parse(LbQuestionCount.Text) + 1;

                Question newquestion = new Question(questionname, questionNo.ToString(), option1, option2, option3, option4, correct, LbQuizID.Value);
                Quiz quiz = new Quiz();
                int result = newquestion.AddQuestion();
                if (result == 1)
                {
                    quiz.UpdateTotalQuestions(questionNo, LbQuizID.Value);
                    toast(this, "Question added!", "Success", "success");
                    TbQuestion.Text = "";
                    TbOption1.Text = "";
                    TbOption2.Text = "";
                    TbOption3.Text = "";
                    TbOption4.Text = "";
                    DdlCorrect.SelectedIndex = -1;
                    List<Question> questions = new Question().SelectByQuiz(LbQuizID.Value);
                    question.DataSource = questions;
                    question.DataBind();
                }
                else
                {
                    toast(this, "Question could not be added, please contact system administrator!", "Error", "error");
                }
            }
        }
    }
}