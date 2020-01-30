using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WISLEY.DAL.Gacha;

namespace WISLEY.BLL.Gacha
{
    public class Gacha
    {
        public int Id { get; set; }
        public string src { get; set; }
        public string rarity { get; set; }

        public Gacha()
        {

        }

        public Gacha(string src, string rarity, int Id = -1)
        {
            this.src = src;
            this.rarity = rarity;
            this.Id = Id;
        }

        public List<Gacha> SelectAll()
        {
            GachaDAO gachaDAO = new GachaDAO();
            return gachaDAO.SelectAll();
        }

        public Gacha SelectByID(int id)
        {
            GachaDAO gachaDAO = new GachaDAO();
            return gachaDAO.SelectByID(id);
        }
    }
}