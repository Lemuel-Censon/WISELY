using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WISLEY.DAL.Collab;

namespace WISLEY.BLL.Collab
{
    public class Comment
    {
        public int Id { get; set; }
        public string postid { get; set; }
        public string userid { get; set; }
        public string content { get; set; }
        public string datecreated { get; set; }
        public string username { get; set; }
        public string profilesrc { get; set; }
        public string status { get; set; }

        public Comment()
        {

        }

        public Comment(string postid, string userid, string content, string datecreated, int Id = -1, string username = "", string profilesrc = "", string status = "")
        {
            this.postid = postid;
            this.userid = userid;
            this.content = content;
            this.datecreated = datecreated;
            this.username = username;
            this.profilesrc = profilesrc;
            this.status = status;
            this.Id = Id;
        }

        public int AddComment()
        {
            CommentDAO commdao = new CommentDAO();
            return commdao.Insert(this);
        }

        public List<Comment> SelectByPost(string postId)
        {
            CommentDAO commdao = new CommentDAO();
            return commdao.SelectByPost(postId);
        }

        public int UpdateComment(string commId, string content, string datecreate)
        {
            CommentDAO commdao = new CommentDAO();
            return commdao.UpdateComment(commId, content, datecreate);
        }

        public int DelCommUpdate(string commId, string status)
        {
            CommentDAO commdao = new CommentDAO();
            return commdao.DelCommUpdate(commId, status);
        }
    }
}