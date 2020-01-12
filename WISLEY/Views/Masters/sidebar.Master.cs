using System;
using System.Collections.Generic;
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

        }

        public bool TeacherCheck()
        {
            if (Session["email"] != null)
            {

                User user = new User().SelectByEmail(Session["email"].ToString());

                if (user.userType == "Teacher")
                {
                    return true;
                }

            }
            return false;
        }
    }
}