using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WISLEY.DAL.Notification;

namespace WISLEY.BLL.Notification
{
    public class Notify
    {
        public int Id { get; set; }
        public string senderEmail { get; set; }
        public string receiverEmail { get; set; }
        public string datecreated { get; set; }
        public string type { get; set; }
        public int groupId { get; set; }
        public int postId { get; set; }
        public string senderName { get; set; }
        public string groupName { get; set; }
        public string postName { get; set; }
        public string status { get; set; }

        public Notify()
        {

        }

        public Notify(string senderEmail, string receiverEmail, string datecreated, string type, int groupId = -1, int postId = -1, int Id = -1, string senderName = "", string groupName = "", string postName = "", string status = "")
        {
            this.senderEmail = senderEmail;
            this.receiverEmail = receiverEmail;
            this.datecreated = datecreated;
            this.type = type;
            this.Id = Id;
            this.groupId = groupId;
            this.postId = postId;
            this.senderName = senderName;
            this.groupName = groupName;
            this.postName = postName;
            this.status = status;
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

        public int ClearNotifs(string notifId)
        {
            NotifyDAO notifydao = new NotifyDAO();
            return notifydao.ClearNotifs(notifId);
        }
    }
}