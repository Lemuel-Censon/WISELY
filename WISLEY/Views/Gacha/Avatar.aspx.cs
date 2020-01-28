using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WISLEY.BLL.Profile;
using WISLEY.BLL.Gacha;

namespace WISLEY.Views.Gacha
{
    public partial class Avatars : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            User user = new User();
            
        }

        protected void ButtonBack_Click(object sender, EventArgs e)
        {
            Response.Redirect(Page.ResolveUrl("~/Views/Profile/profile.aspx"));
        }

        protected void DropDownListSort_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void ButtonSelect_Click(object sender, EventArgs e)
        {

            Response.Redirect(Page.ResolveUrl("~/Views/Profile/profile.aspx"));
        }

        protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
        {
            //pikachu
            Avatar avatar = new Avatar().getAvatarByID("01");

            Session["SSImage"] = avatar.src;
        }

        protected void ImageButton2_Click(object sender, ImageClickEventArgs e)
        {
            //baymax
            Avatar avatar = new Avatar().getAvatarByID("02");

            Session["SSImage"] = avatar.src;
        }

        protected void ImageButton3_Click(object sender, ImageClickEventArgs e)
        {
            //pubg
            Avatar avatar = new Avatar().getAvatarByID("03");

            Session["SSImage"] = avatar.src;
        }

        protected void ImageButton4_Click(object sender, ImageClickEventArgs e)
        {
            //monk
            Avatar avatar = new Avatar().getAvatarByID("04");

            Session["SSImage"] = avatar.src;
        }

        protected void ImageButton5_Click(object sender, ImageClickEventArgs e)
        {
            //skull
            Avatar avatar = new Avatar().getAvatarByID("05");

            Session["SSImage"] = avatar.src;
        }

        protected void ImageButton6_Click(object sender, ImageClickEventArgs e)
        {
            //ninja
            Avatar avatar = new Avatar().getAvatarByID("08");

            Session["SSImage"] = avatar.src;
        }

        protected void ImageButton7_Click(object sender, ImageClickEventArgs e)
        {
            //angry monk
            Avatar avatar = new Avatar().getAvatarByID("06");

            Session["SSImage"] = avatar.src;
        }

        protected void ImageButton8_Click(object sender, ImageClickEventArgs e)
        {
            //villager
            Avatar avatar = new Avatar().getAvatarByID("07");

            Session["SSImage"] = avatar.src;
        }
    }
}