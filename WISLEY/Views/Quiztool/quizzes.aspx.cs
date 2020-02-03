using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WISLEY.BLL.Quiz;

namespace WISLEY.Views.Quiztool
{
    public partial class quizzes : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            List<Quiz> quizzes = new Quiz().SelectAll();
            quizinfo.DataSource = quizzes;
            quizinfo.DataBind();
        }

        protected void quizinfo_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Footer && quizinfo.Items.Count < 1)
            {
                e.Item.FindControl("LbErr").Visible = true;
            }
        }

        protected void btnCreate_Click(object sender, EventArgs e)
        {
            Response.Redirect(Page.ResolveUrl("~/Views/Quiztool/quizcreator.aspx"));
        }

        protected void quizinfo_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            if (e.CommandName == "viewprofile")
            {
                Response.Redirect(Page.ResolveUrl("~/Views/Profile/profile.aspx?id=" + e.CommandArgument.ToString()));
            }
        }
    }
}