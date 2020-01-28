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

        

        protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
        {
            //pikachu
            Avatar avatar = new Avatar().getAvatarByID(1);

            Session["SSImage"] = "https://www.clipartwiki.com/clipimg/detail/315-3158759_clipart-dressed.png" ;
            
        }

        protected void ImageButton2_Click(object sender, ImageClickEventArgs e)
        {
            //baymax
            Avatar avatar = new Avatar().getAvatarByID(2);

            Session["SSImage"] = "https://i.ya-webdesign.com/images/baymax-transparent-head-2.png";
        }

        protected void ImageButton3_Click(object sender, ImageClickEventArgs e)
        {
            //pubg
            Avatar avatar = new Avatar().getAvatarByID(3);

            Session["SSImage"] = "https://i.pinimg.com/736x/ec/67/45/ec6745ffe17cffb0e23b2f16c64100b1.jpg";
        }

        protected void ImageButton4_Click(object sender, ImageClickEventArgs e)
        {
            //monk
            Avatar avatar = new Avatar().getAvatarByID(4);

            Session["SSImage"] = "https://steemitimages.com/640x0/https://chibigame.io/chibis/generated/0/3/9170981d59d0f8d3f003ef0f289394ded6a00696.png";
        }

        protected void ImageButton5_Click(object sender, ImageClickEventArgs e)
        {
            //skull
            Avatar avatar = new Avatar().getAvatarByID(5);

            Session["SSImage"] = "https://steemitimages.com/0x0/https://chibigame.io/chibis/generated/0/3/cea6475abf50000b50fe25c592e079363689f59e.png";
        }

        protected void ImageButton6_Click(object sender, ImageClickEventArgs e)
        {
            //ninja
            Avatar avatar = new Avatar().getAvatarByID(8);

            Session["SSImage"] = "https://storage.opensea.io/0x71c118b00759b0851785642541ceb0f4ceea0bd5-preview/2354-1553846801.png";
        }

        protected void ImageButton7_Click(object sender, ImageClickEventArgs e)
        {
            //angry monk
            Avatar avatar = new Avatar().getAvatarByID(6);

            Session["SSImage"] = "https://storage.opensea.io/0x71c118b00759b0851785642541ceb0f4ceea0bd5/920-1550012771.png";
        }

        protected void ImageButton8_Click(object sender, ImageClickEventArgs e)
        {
            //villager
            Avatar avatar = new Avatar().getAvatarByID(7);

            Session["SSImage"] = "https://storage.opensea.io/0x71c118b00759b0851785642541ceb0f4ceea0bd5/3538-1556546438.png";
        }
    }
}