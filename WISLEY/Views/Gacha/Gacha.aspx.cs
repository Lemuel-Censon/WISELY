using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WISLEY.BLL.Gacha;
using WISLEY.BLL.Notification;
using WISLEY.BLL.Profile;
using WISLEY.BLL.User;

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
            int rn = randNum.Next(1, gacha.SelectAll().Count + 1);
            results.Add(rn);

            addedavatar = gacha.SelectByID(rn);
            rarity.Add(addedavatar.rarity);

            Avatar avatar = new Avatar(addedavatar.src, addedavatar.rarity, user().id.ToString());
            int addresult = avatar.AddAvatar();
            int currentpoints = user().points;
            Badge badge = new Badge().SelectByBadgeId(user().id.ToString(), 9);
            Notify notify = new Notify(user().email, user().email, DateTime.Now.ToString(), "badge", -1, -1, 9);
            if (currentpoints < 1000)
            {
                toast(this, "Not enough WIS Points!", "Error", "error");
            }
            else
            {
                if (addresult == 1)
                {
                    if (badge.status == "Locked")
                    {
                        currentpoints += 50;
                        user().UpdateWISPoints(user().id, currentpoints);
                        badge.UpdateBadge(user().id.ToString(), 9, DateTime.Now.ToString("dd/MM/yyyy"), "Unlocked");
                        notify.AddBadgeNotif();
                    }
                    Session["SSResults"] = results;
                    Session["SSRarity"] = rarity;
                    currentpoints -= 1000;
                    user().UpdateWISPoints(user().id, currentpoints);

                    Response.Redirect("GachaSummon.aspx");
                }
                else
                {
                    Session["error"] = "There was an error while summoning, please inform system administrator!";
                    Response.Redirect("Gacha.aspx");
                }
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
                results.Add(randNum.Next(1, gacha.SelectAll().Count + 1));
            }
            foreach(var result in results)
            {
                addedavatar = gacha.SelectByID(result);
                rarity.Add(addedavatar.rarity);

                Avatar avatar = new Avatar(addedavatar.src, addedavatar.rarity, user().id.ToString());
                addresults.Add(avatar.AddAvatar());
            }

            int currentpoints = user().points;
            Badge badge = new Badge().SelectByBadgeId(user().id.ToString(), 10);
            Notify notify = new Notify(user().email, user().email, DateTime.Now.ToString(), "badge", -1, -1, 10);
            if (currentpoints < 10000)
            {
                toast(this, "Not enough WIS Points!", "Error", "error");
            }
            else
            {
                if (addresults.Contains(1))
                {
                    if (badge.status == "Locked")
                    {
                        currentpoints += 200;
                        user().UpdateWISPoints(user().id, currentpoints);
                        badge.UpdateBadge(user().id.ToString(), 10, DateTime.Now.ToString("dd/MM/yyyy"), "Unlocked");
                        notify.AddBadgeNotif();
                    }
                    Session["SSResults"] = results;
                    Session["SSRarity"] = rarity;
                    currentpoints -= 10000;
                    user().UpdateWISPoints(user().id, currentpoints);

                    Response.Redirect("GachaSummon.aspx");
                }
                else
                {
                    Session["error"] = "There was an error while summoning, please inform system administrator!";
                    Response.Redirect("Gacha.aspx");
                }
            }
        }

        protected void ButtonI_R(object sender, EventArgs e)
        {
            Session["SSSummon"] = "Featured Summon";
            Response.Redirect("GachaDetails.aspx");
        }
    }
}