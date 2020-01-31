using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WISLEY.BLL.Gacha;
using WISLEY.BLL.Profile;

namespace WISLEY.Views.Gacha
{
    public partial class Gachas : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["email"] == null)
            {
                Session["error"] = "You must be logged in to summon!";
                Response.Redirect(Page.ResolveUrl("~/Views/index.aspx"));
            }
            else
            {
                if (Session["success"] != null)
                {
                    toast(this, Session["success"].ToString(), "Success", "success");
                    Session["success"] = null;
                }
                if (Session["error"] != null)
                {
                    toast(this, Session["error"].ToString(), "Error", "error");
                    Session["error"] = null;
                }
            }
        }

        public User user()
        {
            User user = new User().SelectByEmail(Session["email"].ToString());
            return user;
        }

        public void toast(Page page, string message, string title, string type)
        {
            page.ClientScript.RegisterStartupScript(page.GetType(), "toastmsg", "toastnotif('" + message + "','" + title + "','" + type.ToLower() + "');", true);
        }

        protected void ButtonBack_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Views/Profile/profile.aspx");
        }

        protected void Button1x_R_Click(object sender, EventArgs e)
        {
            //RNG
            BLL.Gacha.Gacha gacha = new BLL.Gacha.Gacha();
            BLL.Gacha.Gacha addedavatar = new BLL.Gacha.Gacha();
            List<int> results = new List<int>();
            List<string> rarity = new List<string>();

            Random randNum = new Random();
            results.Add(randNum.Next(0, gacha.SelectAll().Count));

            addedavatar = gacha.SelectByID(results[0]);
            rarity.Add(addedavatar.rarity);

            Avatar avatar = new Avatar("true", addedavatar.src, addedavatar.rarity, user().id.ToString());
            int addresult = avatar.AddAvatar();

            if (addresult == 1)
            {
                Session["SSResults"] = results;
                Session["SSRarity"] = rarity;

                Response.Redirect("GachaSummon.aspx");
            }
            else
            {
                Session["error"] = "There was an error while summoning, please inform system administrator!";
                Response.Redirect("Gacha.aspx");
            }

        }

        protected void Button11x_R_Click(object sender, EventArgs e)
        {


            //RNG
            BLL.Gacha.Gacha gacha = new BLL.Gacha.Gacha();
            BLL.Gacha.Gacha addedavatar = new BLL.Gacha.Gacha();
            List<int> results = new List<int>();
            List<int> addresults = new List<int>();
            List<string> rarity = new List<string>();

            Random randNum = new Random();
            for (int i = 0; i < 11; i++)
            {
                results.Add(randNum.Next(0, gacha.SelectAll().Count));
            }
            foreach(var result in results)
            {
                addedavatar = gacha.SelectByID(result);
                rarity.Add(addedavatar.rarity);

                Avatar avatar = new Avatar("true", addedavatar.src, addedavatar.rarity, user().id.ToString());
                addresults.Add(avatar.AddAvatar());
            }

            if (addresults.Contains(1))
            {
                Session["SSResults"] = results;
                Session["SSRarity"] = rarity;

                Response.Redirect("GachaSummon.aspx");
            }
            else
            {
                Session["error"] = "There was an error while summoning, please inform system administrator!";
                Response.Redirect("Gacha.aspx");
            }
        }

        protected void ButtonI_R(object sender, EventArgs e)
        {
            Session["SSSummon"] = "Regular Summon";
            Response.Redirect("GachaDetails.aspx");
        }
    }
}