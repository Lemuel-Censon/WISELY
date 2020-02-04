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
                        LbQuestionCount.Text = new Question().GetQuestionCount(LbQuizID.Value);
                        List<Question> questions = new Question().SelectByQuiz(LbQuizID.Value);
                        question.DataSource = questions;
                        question.DataBind();
                    }
                }
                else
                {
                    Session["error"] = "Please select a quiz to edit";
                    Response.Redirect(Page.ResolveUrl("~/Views/Profile/profile.aspx"));
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

        public bool ValidateQuestion(string question, string option1, string option2, string option3, string option4, DropDownList correct)
        {
            bool valid = false;
            if (String.IsNullOrEmpty(question))
            {
                toast(this, "Please enter question title!", "Error", "error");
            }
            else if (String.IsNullOrEmpty(option1) || String.IsNullOrEmpty(option2) || String.IsNullOrEmpty(option3) || String.IsNullOrEmpty(option4))
            {
                toast(this, "Please fill in all options!", "Error", "error");
            }
            else if (correct.SelectedIndex == -1)
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
            if (question.Items.Count < 1 && e.Item.ItemType == ListItemType.Footer)
            {
                e.Item.FindControl("LbErr").Visible = true;
            }
        }

        protected void btnSaveQn_Click(object sender, EventArgs e)
        {
            if (ValidateQuestion(TbQuestion.Text, TbOption1.Text, TbOption2.Text, TbOption3.Text, TbOption4.Text, DdlCorrect))
            {
                string questionname = TbQuestion.Text;
                string option1 = TbOption1.Text;
                string option2 = TbOption2.Text;
                string option3 = TbOption3.Text;
                string option4 = TbOption4.Text;
                string correct = CorrectAnswer();
                int questionNo = int.Parse(new Question().GetQuestionCount(LbQuizID.Value)) + 1;

                Question newquestion = new Question(questionname, questionNo.ToString(), option1, option2, option3, option4, correct, LbQuizID.Value);
                Quiz quiz = new Quiz().SelectById(LbQuizID.Value);
                int result = newquestion.AddQuestion();
                if (result == 1)
                {
                    quiz.UpdateTotalQuestions(quiz.totalquestions + 1, LbQuizID.Value);
                    toast(this, "Question added!", "Success", "success");
                    TbQuestion.Text = "";
                    TbOption1.Text = "";
                    TbOption2.Text = "";
                    TbOption3.Text = "";
                    TbOption4.Text = "";
                    DdlCorrect.SelectedIndex = -1;
                    LbQuestionCount.Text = new Question().GetQuestionCount(LbQuizID.Value);
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

        protected void question_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            if (e.CommandName == "edit")
            {
                e.Item.FindControl("qnName").Visible = false;
                e.Item.FindControl("qnOp1").Visible = false;
                e.Item.FindControl("qnOp2").Visible = false;
                e.Item.FindControl("qnOp3").Visible = false;
                e.Item.FindControl("qnOp4").Visible = false;
                e.Item.FindControl("editbtns").Visible = true;
                e.Item.FindControl("tbUpName").Visible = true;
                e.Item.FindControl("tbOp1").Visible = true;
                e.Item.FindControl("tbOp2").Visible = true;
                e.Item.FindControl("tbOp3").Visible = true;
                e.Item.FindControl("tbOp4").Visible = true;
                e.Item.FindControl("DdlAns").Visible = true;
            }
            if (e.CommandName == "cancel")
            {
                e.Item.FindControl("qnName").Visible = true;
                e.Item.FindControl("qnOp1").Visible = true;
                e.Item.FindControl("qnOp2").Visible = true;
                e.Item.FindControl("qnOp3").Visible = true;
                e.Item.FindControl("qnOp4").Visible = true;
                e.Item.FindControl("editbtns").Visible = false;
                e.Item.FindControl("tbUpName").Visible = false;
                e.Item.FindControl("tbOp1").Visible = false;
                e.Item.FindControl("tbOp2").Visible = false;
                e.Item.FindControl("tbOp3").Visible = false;
                e.Item.FindControl("tbOp4").Visible = false;
                e.Item.FindControl("DdlAns").Visible = false;
            }
            if (e.CommandName == "save")
            {
                TextBox name = (TextBox)e.Item.FindControl("tbUpName");
                TextBox op1 = (TextBox)e.Item.FindControl("tbOp1");
                TextBox op2 = (TextBox)e.Item.FindControl("tbOp2");
                TextBox op3 = (TextBox)e.Item.FindControl("tbOp3");
                TextBox op4 = (TextBox)e.Item.FindControl("tbOp4");
                DropDownList ans = (DropDownList)e.Item.FindControl("DdlAns");
                Question edited = new Question();
                string questionid = e.CommandArgument.ToString();

                if (ValidateQuestion(name.Text, op1.Text, op2.Text, op3.Text, op4.Text, ans))
                {
                    string corr = "";
                    if (ans.SelectedItem.Text == "1")
                    {
                        corr = op1.Text;
                    }
                    else if (ans.SelectedItem.Text == "2")
                    {
                        corr = op2.Text;
                    }
                    else if (ans.SelectedItem.Text == "3")
                    {
                        corr = op3.Text;
                    }
                    else if (ans.SelectedItem.Text == "4")
                    {
                        corr = op4.Text;
                    }
                    int result = edited.UpdateQuestion(questionid, name.Text, op1.Text, op2.Text, op3.Text, op4.Text, corr);
                    if (result == 1)
                    {
                        toast(this, "Question saved successfully!", "Success", "success");
                        e.Item.FindControl("qnName").Visible = true;
                        e.Item.FindControl("qnOp1").Visible = true;
                        e.Item.FindControl("qnOp2").Visible = true;
                        e.Item.FindControl("qnOp3").Visible = true;
                        e.Item.FindControl("qnOp4").Visible = true;
                        e.Item.FindControl("editbtns").Visible = false;
                        e.Item.FindControl("tbUpName").Visible = false;
                        e.Item.FindControl("tbOp1").Visible = false;
                        e.Item.FindControl("tbOp2").Visible = false;
                        e.Item.FindControl("tbOp3").Visible = false;
                        e.Item.FindControl("tbOp4").Visible = false;
                        e.Item.FindControl("DdlAns").Visible = false;
                        List<Question> questions = new Question().SelectByQuiz(LbQuizID.Value);
                        question.DataSource = questions;
                        question.DataBind();
                    }
                    else
                    {
                        toast(this, "There was an error while saving question, please contact system administrator!", "Error", "error");
                        e.Item.FindControl("qnName").Visible = true;
                        e.Item.FindControl("qnOp1").Visible = true;
                        e.Item.FindControl("qnOp2").Visible = true;
                        e.Item.FindControl("qnOp3").Visible = true;
                        e.Item.FindControl("qnOp4").Visible = true;
                        e.Item.FindControl("editbtns").Visible = false;
                        e.Item.FindControl("tbUpName").Visible = false;
                        e.Item.FindControl("tbOp1").Visible = false;
                        e.Item.FindControl("tbOp2").Visible = false;
                        e.Item.FindControl("tbOp3").Visible = false;
                        e.Item.FindControl("tbOp4").Visible = false;
                        e.Item.FindControl("DdlAns").Visible = false;
                    }
                }
            }
        }
    }
}