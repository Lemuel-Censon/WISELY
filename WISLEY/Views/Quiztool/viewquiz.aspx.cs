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
    public partial class viewquiz : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["email"] != null)
            {
                if (Request.QueryString["id"] != null)
                {
                    if (!Page.IsPostBack)
                    {
                        LbQuizID.Value = Request.QueryString["id"];
                        List<Question> questions = new Question().SelectByQuiz(LbQuizID.Value);
                        questionitems.DataSource = questions;
                        questionitems.DataBind();
                    }
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

        protected void questionitems_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {

        }

        protected void questionitems_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            if (e.CommandName == "submit")
            {
                int score = 0;
                foreach (RepeaterItem rt in questionitems.Items)
                {
                    string selection = "";
                    string answer = ((Label)rt.FindControl("Label1")).Text;
                    if (((RadioButton)rt.FindControl("rbtnOption1")).Checked)
                    {
                        selection = ((RadioButton)rt.FindControl("rbtnOption1")).Text;
                    }
                    else if (((RadioButton)rt.FindControl("rbtnOption2")).Checked)
                    {
                        selection = ((RadioButton)rt.FindControl("rbtnOption2")).Text;
                    }
                    else if (((RadioButton)rt.FindControl("rbtnOption3")).Checked)
                    {
                        selection = ((RadioButton)rt.FindControl("rbtnOption3")).Text;
                    }
                    else if (((RadioButton)rt.FindControl("rbtnOption4")).Checked)
                    {
                        selection = ((RadioButton)rt.FindControl("rbtnOption4")).Text;
                    }
                    if (selection == answer)
                    {
                        score += 1;
                    }
                }
                User user = new User().SelectByEmail(Session["email"].ToString());
                int result = (score / quiz().totalquestions) * 100;
                int points = 0;
                int currentWISPoints = user.points;
                if (result == 100)
                {
                    points = 50;
                }
                else if (result >= 75)
                {
                    points = 30;
                }
                else if (result >= 50)
                {
                    points = 20;
                }
                else
                {
                    points = 10;
                }
                currentWISPoints += points;
                user.UpdateWISPoints(user.id, currentWISPoints);
                Session["result"] = result;
                Session["points"] = points;
                Session["Id"] = quiz().Id;
                Response.Redirect("quizresult.aspx");
            }
        }
    }
}