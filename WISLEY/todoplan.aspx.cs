using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WISLEY
{
    public partial class todoplan : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            tbDateSelected.Text = Session["selectDate"].ToString();
        }

        protected void btnBack_Click(object sender, EventArgs e)
        {
            Response.Redirect("schedule.aspx");
        }
    }
}