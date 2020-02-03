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
            if (Session["email"] != null)
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
                List<Avatar> useravatars = new Avatar().SelectByUser(user().id);
                avatars.DataSource = useravatars;
                avatars.DataBind();
            }
            else
            {
                Session["error"] = "You must be logged in to change avatar!";
                Response.Redirect(Page.ResolveUrl("~/Views/index.aspx"));
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
           
            Response.Redirect(Page.ResolveUrl("~/Views/Profile/profile.aspx"));
        }

        protected void DropDownListSort_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void avatars_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (avatars.Items.Count < 1)
            {
                if (e.Item.ItemType == ListItemType.Footer)
                {
                    e.Item.FindControl("LbErr").Visible = true;
                }
            }
            else
            {
                if (e.Item.ItemType == ListItemType.Item)
                {
                    HiddenField rarity = (HiddenField)e.Item.FindControl("avatarrarity");
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

        protected void avatars_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            if (e.CommandName == "upAvatar")
            {
                User curruser = new User();
                int result = curruser.UpdateProfilePic(user().id, e.CommandArgument.ToString());
                if (result == 1)
                {
                    Session["success"] = "Avatar updated successfully!";
                    Response.Redirect("Avatar.aspx");
                }
                else
                {
                    Session["error"] = "Avatar was unable to be updated, please inform system administrator!";
                    Response.Redirect("Avatar.aspx");
                }
            }
        }
    }
}