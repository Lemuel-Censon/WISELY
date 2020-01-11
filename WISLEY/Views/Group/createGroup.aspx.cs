using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WISLEY.Views.Group
{
    public partial class createGroup : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        public void CreateGroup(object sender, EventArgs e)
        {
            bool noError = true;
            string grpName = groupNameTB.Text.ToString().Trim();
            string grpDescription = groupNameTB.Text.ToString().Trim();

            System.Diagnostics.Debug.WriteLine(grpName);
            System.Diagnostics.Debug.WriteLine(grpDescription);

            if (string.IsNullOrEmpty(grpName))
            {
                noError = false;
            }
            if (string.IsNullOrEmpty(grpDescription))
            {
                noError = false;
            }
        }
    }
}