using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WISLEY.BLL.Profile;
using WISLEY.BLL.Quiz;

namespace WISLEY.Views.Quiztool
{
    public partial class quizcreator1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["email"] != null)
            {
                if (!Page.IsPostBack)
                {
                    User user = new User().SelectByEmail(Session["email"].ToString());
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

        //Generate RandomNo
        public int GenerateRandomNo()
        {
            int _min = 1000;
            int _max = 9999;
            Random _rdm = new Random();
            return _rdm.Next(_min, _max);
        }

        protected void btnCreateQuestions_Click(object sender, EventArgs e)
        {
            if (ValidateInput())
            {
                User user = new User().SelectByEmail(Session["email"].ToString());
                string title = TbTitle.Text;
                string description = TbDesc.Text;
                string date = DateTime.Now.ToString("dd/MM/yyyy");
                string userId = user.id.ToString();
                string quizId = GenerateRandomNo().ToString();
                Quiz quiz = new Quiz(title, description, date, userId, quizId);
                int result = quiz.AddQuiz();
                if (result == 1)
                {
                    Session["quizId"] = quizId;
                    Session["email"] = user.email;
                    Response.Redirect("question.aspx");
                }
                else
                {
                    toast(this, "Unable to create quiz, please contact system administrator!", "Error", "error");
                }
            }
        }
    }
}