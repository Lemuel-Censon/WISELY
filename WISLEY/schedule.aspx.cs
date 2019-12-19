using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WISLEY
{
	public partial class schedule : System.Web.UI.Page
	{
		protected void Page_Load(object sender, EventArgs e)
		{

		}

        protected void calendarPlan_SelectionChanged(object sender, EventArgs e)
        {
            Session["selectDate"] = calendarPlan.SelectedDate.ToShortDateString();
            Response.Redirect("todoplan.aspx");
        }

        protected void calendarPlan_DayRender(object sender, DayRenderEventArgs e)
        {
            CalendarDay day = (CalendarDay)e.Day;
            TableCell cell = (TableCell)e.Cell;

            if (!day.IsOtherMonth)
            {
                String holidayStr = pulHolDay[day.Date.Month, day.Date.Day];

                if (holidayStr != null)
                {
                    cell.BackColor = System.Drawing.Color.HotPink;
                    cell.Controls.Add(new LiteralControl(holidayStr));
                }
            }
        }
    }
}