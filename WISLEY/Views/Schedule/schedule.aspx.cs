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

                List<Planner> todoList = new Planner().SelectByUser(currUser().id);
                todolistRepeater.DataSource = todoList;
                todolistRepeater.DataBind();
            }

            else
            {
                Session["error"] = "You must be logged in to see your schedule!";
                Response.Redirect(Page.ResolveUrl("~/Views/index.aspx"));
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

        public bool validateSelectedDate()
        {
            bool isValid = false;

            var dateSelecteed = new DateTime(calendarPlan.SelectedDate.Year, calendarPlan.SelectedDate.Month, calendarPlan.SelectedDate.Day);

            if (dateSelecteed < DateTime.Today)
            {
                toast(this, "Selected date must be after today!", "Error", "error");
            }

            else
            {
                isValid = true;
            }

            return isValid;
        }

        protected void calendarPlan_SelectionChanged(object sender, EventArgs e)
        {
            if (validateSelectedDate())
            {
                Session["selectDate"] = calendarPlan.SelectedDate.ToString("dddd, dd MMMMM yyyy");
                Response.Redirect("todoplan.aspx");
            }
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

        public void toast(Page page, string message, string title, string type)
        {
            page.ClientScript.RegisterStartupScript(page.GetType(), "toastmsg", "toastnotif('" + message + "','" + title + "','" + type.ToLower() + "');", true);
        }

        protected int ToDoListcount()
        {
            List<Planner> allToDoList = new Planner().SelectByUser(currUser().id);
            return allToDoList.Count();
        }

        protected void todolist_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            if (e.CommandName == "edit")
            {
                Session["todoID"] = e.CommandArgument.ToString();
                Response.Redirect(Page.ResolveUrl("~/Views/Schedule/editToDo.aspx"));
            }

            if (e.CommandName == "delToDo")
            {
                string todoID = e.CommandArgument.ToString();
                Planner todolist = new Planner();
                int result = todolist.DeleteToDo(todoID, "deleted");
                
                if (result == 1)
                {
                    Session["success"] = "To-do-list has been deleted successfully!";
                    Response.Redirect("schedule.aspx");
                }

                else
                {
                    Session["error"] = "To-do-list cannot be deleted, please inform system administrator!";
                    Response.Redirect("schedule.aspx");
                }
            }
        }

        protected void todolistRepeater_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (todolistRepeater.Items.Count < 1)
            {
                if (e.Item.ItemType == ListItemType.Footer)
                {
                    e.Item.FindControl("LbErr").Visible = true;
                }
            }
        }
    }
}