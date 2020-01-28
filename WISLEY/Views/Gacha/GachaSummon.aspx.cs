using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
//using System.Timers;
using System.Threading;


namespace WISLEY.Views.Gacha
{
    public partial class GachaSummons : System.Web.UI.Page
    {
        

        protected void Page_Load(object sender, EventArgs e)
        {
            LabelTitle.Text = Session["SSTitle"].ToString();

            

        }

        
        
        protected void ButtonBack_Click(object sender, EventArgs e)
        {
            Response.Redirect("Gacha.aspx");
        }

        protected void ButtonResults_Click(object sender, EventArgs e)
        {
            Thread.Sleep(5000);
            hider.Style.Add("visibility", "true");
        }
    }


}