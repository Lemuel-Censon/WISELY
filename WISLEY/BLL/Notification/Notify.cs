using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WISLEY.DAL.Notification;

namespace WISLEY.BLL.Notification
{
    public class Notify
    {
        public int senderId { get; set; }
        public int receiverId { get; set; }
        public string datecreated { get; set; }
        public string type { get; set; }
        public int groupId { get; set; }
        public int postId { get; set; }
        public string senderName { get; set; }
        public string groupName { get; set; }
        public string postName { get; set; }

        public Notify()
        {

        }

        public Notify(int senderId, int receiverId, string datecreated, string type, int groupId = -1, int postId = -1, string senderName = "", string groupName = "", string postName = "")
        {
            this.senderId = senderId;
            this.receiverId = receiverId;
            this.datecreated = datecreated;
            this.type = type;
            this.groupId = groupId;
            this.postId = postId;
            this.senderName = senderName;
            this.groupName = groupName;
            this.postName = postName;
        }

        public int AddPostNotif()
        {
            NotifyDAO notifydao = new NotifyDAO();
            return notifydao.InsertPost(this);
        }

        public List<Notify> SelectPostNotif(string userId)
        {
            NotifyDAO notifydao = new NotifyDAO();
            return notifydao.SelectPostNotif(userId);
        }
    }
}