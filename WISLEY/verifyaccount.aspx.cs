using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WISLEY
{
    public partial class verifyaccount : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnVerifyAccount_Click(object sender, EventArgs e)
        {
            Response.Redirect("changepassword.aspx");
        }

        protected void btnBack_Click(object sender, EventArgs e)
        {
            Response.Redirect("recoveraccount.aspx");
        }
    }
}