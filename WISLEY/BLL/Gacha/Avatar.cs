using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WISLEY.DAL.Gacha;

namespace WISLEY.BLL.Gacha
{
    public class Avatar
    {
        public int avatarID { get; set; }
        public string acquired { get; set; }
        public string src { get; set; }
        public string rarity { get; set; }
        public string userId { get; set; }

        public Avatar()
        {

        }

        public Avatar(string acquired, string src, string rarity, string userId, int avatarID = -1)
        {
            this.acquired = acquired;
            this.src = src;
            this.rarity = rarity;
            this.userId = userId;
            this.avatarID = avatarID;
        }

        public Avatar getAvatarByID(int avatarID)
        {
            AvatarDAO avatarDAO = new AvatarDAO();
            return avatarDAO.SelectAvatarByID(avatarID);
        }

        public List<Avatar> SelectByUser(int userId)
        {
            AvatarDAO avatarDAO = new AvatarDAO();
            return avatarDAO.SelectByUser(userId);
        }

        public int UpdateAcquired(string acquired, string id)
        {
            AvatarDAO avatardao = new AvatarDAO();
            return avatardao.UpdateAcquired(acquired, id);
        }

    }
}