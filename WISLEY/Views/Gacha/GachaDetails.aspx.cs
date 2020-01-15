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
            LabelSummon.Text = Session["SSSummon"].ToString();
            if (LabelSummon.Text == "Regular Summon")
            {
                gachadetailsbanner.Attributes.Add("src", "//cdn.bannersnack.com/banners/bxh82nnjd/embed/index.html?userId=40214613&t=1575958709");
            }
            else
            {
                gachadetailsbanner.Attributes.Add("src", "//cdn.bannersnack.com/banners/bdpl499mz/embed/index.html?userId=40214613&t=1575957949");
            }
        }

        protected void ButtonBack_Click(object sender, EventArgs e)
        {
            Response.Redirect("Gacha.aspx");
        }

        protected void GridViewSummon_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}