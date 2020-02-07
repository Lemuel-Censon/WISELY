using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WISLEY.BLL.Notification;
using WISLEY.BLL.Profile;
using WISLEY.BLL.Quiz;
using WISLEY.BLL.User;

namespace WISLEY.Views.Quiztool
{
    public partial class quizcreator : System.Web.UI.Page
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
                Session["error"] = "You must be logged in to create quiz!";
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
                string userId = user.id.ToString();
                Quiz quiz = new Quiz(title, description, date, userId);
                int result = quiz.AddQuiz();
                int currentpoints = user.points;
                Badge badge = new Badge().SelectByBadgeId(user.id.ToString(), 4);
                Badge badge2 = new Badge().SelectByBadgeId(user.id.ToString(), 5);
                Notify notify = new Notify(user.email, user.email, DateTime.Now.ToString(), "badge", -1, -1, 4);
                Notify notify2 = new Notify(user.email, user.email, DateTime.Now.ToString(), "badge", -1, -1, 5);
                if (result == 1)
                {
                    if (badge.status == "Locked")
                    {
                        currentpoints += 50;
                        user.UpdateWISPoints(user.id, currentpoints);
                        badge.UpdateBadge(user.id.ToString(), 4, DateTime.Now.ToString("dd/MM/yyyy"), "Unlocked");
                        notify.AddBadgeNotif();
                    }
                    if (badge2.status == "Locked" && quiz.GetQuizCount(user.id.ToString()) > 9)
                    {
                        currentpoints += 200;
                        user.UpdateWISPoints(user.id, currentpoints);
                        badge2.UpdateBadge(user.id.ToString(), 5, DateTime.Now.ToString("dd/MM/yyyy"), "Unlocked");
                        notify2.AddBadgeNotif();
                    }
                    Session["quizId"] = quiz.GetLastID();
                    Session["success"] = "Quiz created!";
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