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
        public int badgeId { get; set; }
        public string senderName { get; set; }
        public string groupName { get; set; }
        public string postName { get; set; }
        public string badgeName { get; set; }
        public string status { get; set; }

        public Notify()
        {

        }

        public Notify(string senderEmail, string receiverEmail, string datecreated, string type, int groupId = -1, int postId = -1, int badgeId = -1, int Id = -1, string senderName = "", string groupName = "", string postName = "", string badgeName = "", string status = "")
        {
            this.senderEmail = senderEmail;
            this.receiverEmail = receiverEmail;
            this.datecreated = datecreated;
            this.type = type;
            this.Id = Id;
            this.groupId = groupId;
            this.postId = postId;
            this.badgeId = badgeId;
            this.senderName = senderName;
            this.groupName = groupName;
            this.postName = postName;
            this.badgeName = badgeName;
            this.status = status;
        }

        public int AddPostNotif()
        {
            NotifyDAO notifydao = new NotifyDAO();
            return notifydao.InsertPost(this);
        }

        public List<Notify> SelectPostNotif(string userEmail)
        {
            NotifyDAO notifydao = new NotifyDAO();
            return notifydao.SelectPostNotif(userEmail);
        }

        public int AddInvNotif()
        {
            NotifyDAO notifydao = new NotifyDAO();
            return notifydao.InsertInvite(this);
        }

        public List<Notify> SelectInvNotif(string userEmail)
        {
            NotifyDAO notifydao = new NotifyDAO();
            return notifydao.SelectInvNotif(userEmail);
        }

        public List<Notify> SelectCommNotif(string userEmail)
        {
            NotifyDAO notifydao = new NotifyDAO();
            return notifydao.SelectCommNotif(userEmail);
        }

        public int AddBadgeNotif()
        {
            NotifyDAO notifydao = new NotifyDAO();
            return notifydao.InsertBadgeNotif(this);
        }

        public List<Notify> SelectBadgeNotif(string userEmail)
        {
            NotifyDAO notifydao = new NotifyDAO();
            return notifydao.SelectBadgeNotifs(userEmail);
        }

        public int ClearNotifs(string notifId)
        {
            NotifyDAO notifydao = new NotifyDAO();
            return notifydao.ClearNotifs(notifId);
        }

        public int ClearDelPostNotifs(string postId)
        {
            NotifyDAO notifydao = new NotifyDAO();
            return notifydao.ClearDeletedPostNotifs(postId);
        }

        public int UserNotifCount(string userEmail)
        {
            NotifyDAO notifydao = new NotifyDAO();
            return notifydao.UserNotifCount(userEmail);
        }
    }
}