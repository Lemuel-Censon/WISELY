using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WISLEY.Views.Gacha
{
    public partial class GachaDetail : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            GvSummon.Visible = true;
        }

        protected void ButtonBack_Click(object sender, EventArgs e)
        {

        }

        protected void GridViewSummon_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}