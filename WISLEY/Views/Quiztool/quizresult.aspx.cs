using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WISLEY.BLL.Profile;

namespace WISLEY.Views.Quiztool
{
    public partial class quizresult : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["email"] != null)
            {
                if (Session["result"] != null || !Page.IsPostBack)
                {
                    decimal result = decimal.Parse(Session["result"].ToString());
                    LbScore.Text = Math.Round(result, 2).ToString() + "%";
                    LbWISPoints.Text = Session["points"].ToString();
                    if (result == 100)
                    {
                        LbScore.ForeColor = Color.Gold;
                        LbWISPoints.Text = "50";
                    }
                    else if (result >= 75)
                    {
                        LbScore.ForeColor = Color.Green;
                        LbWISPoints.Text = "30";
                    }
                    else if (result >= 50)
                    {
                        LbScore.ForeColor = Color.Green;
                        LbWISPoints.Text = "20";
                    }
                    else
                    {
                        LbScore.ForeColor = Color.Red;
                        LbWISPoints.Text = "10";
                    }
                }
            }
            else
            {
                Session["error"] = "You need to be logged in to view a quiz!";
                Response.Redirect(Page.ResolveUrl("~/Views/index.aspx"));
            }
        }

        protected void btnBack_Click(object sender, EventArgs e)
        {
            Response.Redirect("quizzes.aspx");
        }

        protected void btnRetake_Click(object sender, EventArgs e)
        {
            Response.Redirect(Page.ResolveUrl("~/Views/Quiztool/viewquiz.aspx?id=" + Session["Id"].ToString()));
        }
    }
}