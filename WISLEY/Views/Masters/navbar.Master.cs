using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WISLEY.BLL.Notification;
using WISLEY.BLL.Profile;
using WISLEY.BLL.User;

namespace WISLEY
{
    public partial class navbar : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["email"] != null)
            {
                Lbemail.Text = Session["email"].ToString();
                user();
                int currentpoints = user().points;
                Badge badge = new Badge().SelectByBadgeId(user().id.ToString(), 6);
                Badge badge2 = new Badge().SelectByBadgeId(user().id.ToString(), 7);
                Badge badge3 = new Badge().SelectByBadgeId(user().id.ToString(), 8);
                Badge badge4 = new Badge().SelectByBadgeId(user().id.ToString(), 12);
                Notify notify = new Notify(user().email, user().email, DateTime.Now.ToString(), "badge", -1, -1, 6);
                Notify notify2 = new Notify(user().email, user().email, DateTime.Now.ToString(), "badge", -1, -1, 7);
                Notify notify3 = new Notify(user().email, user().email, DateTime.Now.ToString(), "badge", -1, -1, 8);
                Notify notify4 = new Notify(user().email, user().email, DateTime.Now.ToString(), "badge", -1, -1, 12);
                if (user().points >= 1000 && badge.status == "Locked")
                {
                    currentpoints += 50;
                    user().UpdateWISPoints(user().id, currentpoints);
                    badge.UpdateBadge(user().id.ToString(), 6, DateTime.Now.ToString("dd/MM/yyyy"), "Unlocked");
                    notify.AddBadgeNotif();
                }
                if (user().points >= 10000 && badge2.status == "Locked")
                {
                    currentpoints += 200;
                    user().UpdateWISPoints(user().id, currentpoints);
                    badge2.UpdateBadge(user().id.ToString(), 7, DateTime.Now.ToString("dd/MM/yyyy"), "Unlocked");
                    notify2.AddBadgeNotif();
                }
                if (user().points >= 100000 && badge3.status == "Locked")
                {
                    currentpoints += 1000;
                    user().UpdateWISPoints(user().id, currentpoints);
                    badge3.UpdateBadge(user().id.ToString(), 8, DateTime.Now.ToString("dd/MM/yyyy"), "Unlocked");
                    notify3.AddBadgeNotif();
                }
                if (new Badge().GetBadgeCount(user().id.ToString(), "Locked") == 1)
                {
                    currentpoints += 1000;
                    user().UpdateWISPoints(user().id, currentpoints);
                    badge4.UpdateBadge(user().id.ToString(), 12, DateTime.Now.ToString("dd/MM/yyyy"), "Unlocked");
                    notify4.AddBadgeNotif();
                }
            }
            //System.Diagnostics.Debug.WriteLine("Nav Loaded");
            //showAllSession();
        }

        public User user()
        {
            User user = new User().SelectByEmail(Lbemail.Text);
            return user;
        }

        public void showAllSession()
        {
            foreach (var crntSession in Session.Contents)
            {
                System.Diagnostics.Debug.WriteLine(string.Concat(crntSession, "=", Session[crntSession.ToString()]));
            }
        }

        public int notifnum()
        {
            int notifcount = new Notify().UserNotifCount(user().email);
            return notifcount;
        }

        public string getPageName()
        {
            string pageName = Path.GetFileNameWithoutExtension(Page.AppRelativeVirtualPath);
            System.Diagnostics.Debug.WriteLine(pageName);
            return pageName;
        }

    }
}