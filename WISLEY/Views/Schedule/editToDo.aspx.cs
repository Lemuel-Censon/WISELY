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
                    Planner planner = new Planner().SelectByID(todoID.Value);

                    LblSelectedDate.Text = planner.todoDate.ToShortDateString();
                    if (!Page.IsPostBack)
                    {
                        tbEditTitle.Text = planner.todoTitle;
                        tbEditDesc.Text = planner.todoDescription;
                    }
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

        public void toast(Page page, string message, string title, string type)
        {
            page.ClientScript.RegisterStartupScript(page.GetType(), "toastmsg", "toastnotif('" + message + "','" + title + "','" + type.ToLower() + "');", true);
        }

        protected void btnBack_Click(object sender, EventArgs e)
        {
            Response.Redirect("schedule.aspx");
        }

        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            if (validateInput())
            {
                string ID = todoID.Value;
                string title = tbEditTitle.Text;
                string description = tbEditDesc.Text;

                Planner todolist = new Planner();

                int result = todolist.UpdateToDo(ID, title, description);

                if (result == 1)
                {
                    Session["success"] = "Your plan has been updated successfully!";
                    Response.Redirect("schedule.aspx");
                }

                else
                {
                    Session["error"] = "Changes were unable to be saved, please inform system administrator!";
                    Response.Redirect("schedule.aspx");
                }
            }
        }

        public bool validateInput()
        {
            bool isValid = false;

            if (String.IsNullOrEmpty(tbEditTitle.Text))
            {
                toast(this, "Please enter your title!", "Error", "error");
            }

            else if (String.IsNullOrEmpty(tbEditDesc.Text))
            {
                toast(this, "Please enter your description!", "Error", "error");
            }

            else
            {
                isValid = true;
            }

            return isValid;
        }
    }
}