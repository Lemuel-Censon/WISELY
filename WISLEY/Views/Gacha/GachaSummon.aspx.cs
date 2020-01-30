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
            if (Session["SSResults"] != null)
            {
                BLL.Gacha.Gacha gacha = new BLL.Gacha.Gacha();
                List<BLL.Gacha.Gacha> results = new List<BLL.Gacha.Gacha>();
                foreach (var result in (List<int>)Session["SSResults"])
                {
                    results.Add(gacha.SelectByID(result));
                }
                gacharesults.DataSource = results;
                gacharesults.DataBind();
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
    }


}