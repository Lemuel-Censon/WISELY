using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WISLEY.BLL.Profile;

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
            }
            //System.Diagnostics.Debug.WriteLine("Nav Loaded");
            showAllSession();
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



    }
}