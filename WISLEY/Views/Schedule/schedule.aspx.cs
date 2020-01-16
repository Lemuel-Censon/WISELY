using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WISLEY.Views.Schedule
{
    public partial class schedules : System.Web.UI.Page
    {
        Hashtable HolidayList;

        protected void Page_Load(object sender, EventArgs e)
        {
            HolidayList = GetHoliday();
        }

        private Hashtable GetHoliday()
        {
            Hashtable publicHol = new Hashtable();
            publicHol["1/1/" + DateTime.Today.Year] = "New Year Day";
            publicHol["25/1/" + DateTime.Today.Year] = "Chinese New Year";
            publicHol["26/1/" + DateTime.Today.Year] = "Chinese New Year";
            publicHol["25/12/" + DateTime.Today.Year] = "Christmas Day";
            return publicHol;
        }

        protected void calendarPlan_SelectionChanged(object sender, EventArgs e)
        {
            Session["selectDate"] = calendarPlan.SelectedDate.ToShortDateString();
            Response.Redirect("todoplan.aspx");
        }

        protected void btnEditToDo_Click(object sender, EventArgs e)
        {
            Response.Redirect("editToDo.aspx");
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
    }
}