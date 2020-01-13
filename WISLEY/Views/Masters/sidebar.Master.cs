using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WISLEY.BLL.Profile;

namespace WISLEY
{
    public partial class NestedMasterPage1 : System.Web.UI.MasterPage
    {

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["email"] != null)
            {
                User current_user = new User().SelectByEmail(Session["email"].ToString());
                //LbUsername.Text = current_user.name;
               
                string pageName = Path.GetFileNameWithoutExtension(Page.AppRelativeVirtualPath);
                //System.Diagnostics.Debug.WriteLine(Page.Master.FindControl("LbUsername"));
                //System.Diagnostics.Debug.WriteLine(this.Page.Master.Master.Controls);
                //System.Diagnostics.Debug.WriteLine(Page.Master.Master.Controls[0].ID);

                //Content ct = this.Master.Master.FindControl("contentHolder1") as Content;
                //foreach (Control ctrl in ct.Controls)
                //{
                //    System.Diagnostics.Debug.WriteLine(ctrl.ID);

                //}
            }

        }

        public bool TeacherCheck()
        {
            bool isTeacher = false;
            if (Session["email"] != null)
            {

                User user = new User().SelectByEmail(Session["email"].ToString());

                if (user.userType == "Teacher")
                {
                    isTeacher = true;
                }

            }
            return isTeacher;
        }

        public User user()
        {
            User user = new User().SelectByEmail(Session["email"].ToString());
            return user;
        }

        public string getUsername()
        {
            return user().name;
        }
    }
}