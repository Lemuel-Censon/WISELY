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
            
            LabelSummon.Text = Session["SSSummon"].ToString();
            if (LabelSummon.Text == "Regular Summon")
            {
                gachadetailsbanner.Attributes.Add("src", "//cdn.bannersnack.com/banners/bxh82nnjd/embed/index.html?userId=40214613&t=1575958709");
                GvSummon.Visible = false;
                //GvSummon is the one with featured table

            }
            else
            {
                gachadetailsbanner.Attributes.Add("src", "//cdn.bannersnack.com/banners/bdpl499mz/embed/index.html?userId=40214613&t=1575957949");

                GvSummon2.Visible = false;
                // GvSummon2 is the one with regular table
            }



        }

        protected void ButtonBack_Click(object sender, EventArgs e)
        {
            Response.Redirect("Gacha.aspx");
        }
        
    }
}