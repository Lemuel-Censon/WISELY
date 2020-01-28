using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WISLEY.Views.Gacha
{
    public partial class Gachas : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void ButtonBack_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Views/Profile/profile.aspx");
        }

        protected void Button1x_F_Click(object sender, EventArgs e)
        {
            Session["SSTitle"] = "Featured units 1x Summon";
            Response.Redirect("GachaSummon.aspx");
        }

        protected void Button11x_F_Click(object sender, EventArgs e)
        {
            Session["SSTitle"] = "Featured units 11x Summon";
            Response.Redirect("GachaSummon.aspx");
        }

        protected void Button1x_R_Click(object sender, EventArgs e)
        {
            Session["SSTitle"] = "Beginner special 1x Summon";
            Response.Redirect("GachaSummon.aspx");
        }

        protected void Button11x_R_Click(object sender, EventArgs e)
        {
            Session["SSTitle"] = "Beginner special 11x Summon";
            Response.Redirect("GachaSummon.aspx");
        }

        protected void ButtonI_F(object sender, EventArgs e)
        {
            Session["SSSummon"] = "Featured Summon";
            Response.Redirect("GachaDetails.aspx");
        }

        protected void ButtonI_R(object sender, EventArgs e)
        {
            Session["SSSummon"] = "Regular Summon";
            Response.Redirect("GachaDetails.aspx");
        }
    }
}