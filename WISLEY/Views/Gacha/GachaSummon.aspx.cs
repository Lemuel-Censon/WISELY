using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
//using System.Timers;
using System.Threading;
using WISLEY.BLL.Gacha;


namespace WISLEY.Views.Gacha
{
    public partial class GachaSummons : System.Web.UI.Page
    {
        

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["SSResults"] != null && Session["SSRarity"] != null)
            {
                BLL.Gacha.Gacha gacha = new BLL.Gacha.Gacha();
                List<BLL.Gacha.Gacha> results = new List<BLL.Gacha.Gacha>();
                List<string> resultrarity = (List<string>)Session["SSRarity"];

                foreach (var result in (List<int>)Session["SSResults"])
                {
                    results.Add(gacha.SelectByID(result));
                }
                gacharesults.DataSource = results;
                gacharesults.DataBind();

                if (resultrarity.Contains("Super_Rare"))
                {
                    gachavideo.Src = Page.ResolveUrl("~/Public/videos/gacha_super.mp4");
                }
                else if (resultrarity.Contains("Rare"))
                {
                    gachavideo.Src = Page.ResolveUrl("~/Public/videos/gacha_rare.mp4");
                }
                else
                {
                    gachavideo.Src = Page.ResolveUrl("~/Public/videos/gacha_common.mp4");
                }
            }
            else
            {
                Response.Redirect("Gacha.aspx");
            }
        }

        
        
        protected void ButtonBack_Click(object sender, EventArgs e)
        {
            Response.Redirect("Gacha.aspx");
        }

        protected void ButtonResults_Click(object sender, EventArgs e)
        {
            gacharesults.Visible = true;
        }

        protected void gacharesults_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            HiddenField rarity = (HiddenField)e.Item.FindControl("rarity");
            Image avatar = (Image)e.Item.FindControl("avatarimg");
            if (rarity.Value == "Common")
            {
                avatar.CssClass += " border border-success";
            }
            else if (rarity.Value == "Rare")
            {
                avatar.CssClass += " border border-primary";
            }
            else if (rarity.Value == "Super_Rare")
            {
                avatar.CssClass += " border border-secondary";
            }
        }
    }


}