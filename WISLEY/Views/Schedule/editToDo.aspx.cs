using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WISLEY.BLL.Schedule;

namespace WISLEY.Views.Schedule
{
    public partial class editToDo : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["email"] != null)
            {
                if (Session["todoID"] != null)
                {
                    todoID.Value = Session["todoID"].ToString();
                }
                else
                {
                    Session["error"] = "Please select a plan to edit!";
                    Response.Redirect(Page.ResolveUrl("~/Views/Schedule/schedule.aspx"));
                }
            }
            else
            {
                Session["error"] = "You need to be logged in to edit your schedule!";
                Response.Redirect(Page.ResolveUrl("~/Views/index.aspx"));
            }
        }
    }
}