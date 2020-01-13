﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WISLEY.BLL.Schedule;

namespace WISLEY
{
    public partial class todoplan : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            tbDateSelected.Text = Session["selectDate"].ToString();
        }

        public void toast(Page page, string message, string title, string type)
        {
            page.ClientScript.RegisterStartupScript(page.GetType(), "toastmsg", "toastnotif('" + message + "','" + title + "','" + type.ToLower() + "');", true);
        }

        protected void btnBack_Click(object sender, EventArgs e)
        {
            Response.Redirect("schedule.aspx");
        }

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            if (validateInput())
            {
                DateTime selectedToDoDate = Convert.ToDateTime(tbDateSelected.Text);
                string todoTitle = tbTitle.Text.ToString();
                string todoDesc = tbDesc.Text.ToString();
            }
        }

        public bool validateInput()
        {
            bool isValid = false;

            if (String.IsNullOrEmpty(tbTitle.Text))
            {
                toast(this, "Please enter your title", "Error", "error");
            }

            else if (String.IsNullOrEmpty(tbDesc.Text))
            {
                toast(this, "Please enter your description", "Error", "error");
            }

            else
            {
                isValid = true;
            }

            return isValid;
        }
    }
}