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
            LabelTitle.Text = Session["SSTitle"].ToString();

            LabelRNG.Text = Session["SSResults"].ToString();

            

            //RNG GAME
            if (Session["SSTitle"].ToString() == "Featured units 11x Summon" || Session["SSTitle"].ToString() == "Beginner special 11x Summon")
                for (int i = 0; i < 21; i += 2)
                    {
                        if (LabelRNG.Text[i] == 1) {
                            new Avatar().getAvatarByID(1);
                        }

                        else if (LabelRNG.Text[i] == 2) {
                            new Avatar().getAvatarByID(2);
                        }

                        else if (LabelRNG.Text[i] == 3) {
                            new Avatar().getAvatarByID(3);
                        }

                        else if (LabelRNG.Text[i] == 4) {
                            new Avatar().getAvatarByID(4);
                        }

                        else if (LabelRNG.Text[i] == 5) {
                            new Avatar().getAvatarByID(5);
                        }

                        else if (LabelRNG.Text[i] == 6) {
                            new Avatar().getAvatarByID(6);
                        }

                        else if (LabelRNG.Text[i] == 7) {
                            new Avatar().getAvatarByID(7);
                        }

                        else if (LabelRNG.Text[i] == 8) {
                            new Avatar().getAvatarByID(8);
                        }
                    }
            else
            {
                //1x
                if (LabelRNG.Text[0] == 1)
                {
                    Avatar avatar = new Avatar().getAvatarByID(1);
                }

                else if (LabelRNG.Text[0] == 2)
                {
                    Avatar avatar = new Avatar().getAvatarByID(2);
                }

                else if (LabelRNG.Text[0] == 3)
                {
                    Avatar avatar = new Avatar().getAvatarByID(3);
                }

                else if (LabelRNG.Text[0] == 4)
                {
                    Avatar avatar = new Avatar().getAvatarByID(4);
                }

                else if (LabelRNG.Text[0] == 5)
                {
                    Avatar avatar = new Avatar().getAvatarByID(5);
                }

                else if (LabelRNG.Text[0] == 6)
                {
                    Avatar avatar = new Avatar().getAvatarByID(6);
                }

                else if (LabelRNG.Text[0] == 7)
                {
                    Avatar avatar = new Avatar().getAvatarByID(7);
                }

                else if (LabelRNG.Text[0] == 8)
                {
                    Avatar avatar = new Avatar().getAvatarByID(8);
                }
            }

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