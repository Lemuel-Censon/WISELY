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

        protected void btnCreateQuestions_Click(object sender, EventArgs e)
        {
            if (ValidateInput())
            {
                User user = new User().SelectByEmail(Session["email"].ToString());
                string title = TbTitle.Text;
                string description;
                if (!String.IsNullOrEmpty(TbDesc.Text))
                {
                    description = TbDesc.Text;
                }
                else
                {
                    description = "No Description";
                }
                string date = DateTime.Now.ToString("dd/MM/yyyy");
                int totalquestions = 0;
                string userId = user.id.ToString();
                Quiz quiz = new Quiz(title, description, date, totalquestions, userId);
                int result = quiz.AddQuiz();
                if (result == 1)
                {
                    Session["quizId"] = quiz.Id;
                    Session["email"] = user.email;
                    Response.Redirect("editquiz.aspx");
                }
                else
                {
                    toast(this, "Unable to create quiz, please contact system administrator!", "Error", "error");
                }
            }
        }
    }
}