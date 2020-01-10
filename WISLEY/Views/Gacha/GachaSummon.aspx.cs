using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WISLEY.Views.Gacha
{
    public partial class GachaSummons : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            LabelTitle.Text = Session["SSTitle"].ToString();
        }

        protected void ButtonBack_Click(object sender, EventArgs e)
        {

        }
    }
}