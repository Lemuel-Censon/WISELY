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

        public Avatar()
        {

        }

        public Avatar(int AvatarID, string Acquired, string Src)
        {
            avatarID = AvatarID;
            acquired = Acquired;
            src = Src;
        }

        public Avatar(int avatarId)
        {
            avatarID = avatarId;
        }

        public Avatar getAvatarByID(string avatarID)
        {
            AvatarDAO AvatarDAO = new AvatarDAO();
            return AvatarDAO.SelectAvatarByID(avatarID);
        }

        public int UpdateAcquired(string acquired, int id)
        {
            AvatarDAO Avatardao = new AvatarDAO();
            return Avatardao.UpdateAcquired(acquired, id);
        }

    }
}