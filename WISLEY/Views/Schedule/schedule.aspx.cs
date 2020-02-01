using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WISLEY.BLL.Profile;
using WISLEY.BLL.Schedule;

namespace WISLEY.Views.Schedule
{
    public partial class schedules : System.Web.UI.Page
    {
        Hashtable HolidayList;

        protected void Page_Load(object sender, EventArgs e)
        {
            HolidayList = GetHoliday();

            if (Request.QueryString["Id"] != null)
            {
                if (!Page.IsPostBack)
                {
                    List<Planner> todoList = new Planner().getToDoByUserEmail(Request.QueryString["userId"]);
                    todolistRepeater.DataSource = todoList;
                    todolistRepeater.DataBind();
                }
            }
        }

        private Hashtable GetHoliday()
        {
            Hashtable publicHol = new Hashtable();
            publicHol["1/1/" + DateTime.Today.Year] = "New Year Day";
            publicHol["25/1/" + DateTime.Today.Year] = "Chinese New Year";
            publicHol["26/1/" + DateTime.Today.Year] = "Chinese New Year";
            publicHol["10/4/" + DateTime.Today.Year] = "Good Friday";
            publicHol["1/5/" + DateTime.Today.Year] = "Labour Day";
            publicHol["7/5/" + DateTime.Today.Year] = "Vesak Day";
            publicHol["24/5/" + DateTime.Today.Year] = "Hari Raya Puasa";
            publicHol["31/7/" + DateTime.Today.Year] = "Hari Raya Haji";
            publicHol["9/8/" + DateTime.Today.Year] = "National Day";
            publicHol["14/11/" + DateTime.Today.Year] = "Deepavali";
            publicHol["25/12/" + DateTime.Today.Year] = "Christmas Day";
            return publicHol;
        }

        protected void calendarPlan_SelectionChanged(object sender, EventArgs e)
        {
            Session["selectDate"] = calendarPlan.SelectedDate.ToShortDateString();
            Response.Redirect("todoplan.aspx");
        }

        protected void calendarPlan_DayRender(object sender, DayRenderEventArgs e)
        {
            if (HolidayList[e.Day.Date.ToShortDateString()] != null)
            {
                e.Cell.BackColor = Color.Red;
                e.Cell.ForeColor = Color.White;
                Label pulHoliday = new Label();
                pulHoliday.Text = HolidayList[e.Day.Date.ToShortDateString()].ToString();
                e.Cell.ToolTip = pulHoliday.Text;
            }
        }

        public User currUser()
        {
            User user = new User().SelectByEmail(Session["email"].ToString());
            return user;
        }

        protected int ToDoListcount()
        {
            List<Planner> allToDoList = new Planner().getToDoByUserEmail(currUser().email.ToString());
            return allToDoList.Count();
        }

        protected void todolist_ItemCommand(object source, RepeaterCommandEventArgs e)
        {

        }
    }
}