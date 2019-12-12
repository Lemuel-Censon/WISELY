using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WISLEY.DAL.Collab;

namespace WISLEY.BLL.Collab
{
    public class Comment
    {
        public string postid { get; set; }
        public string userid { get; set; }
        public string content { get; set; }
        public DateTime datecreate { get; set; }

        public Comment()
        {

        }

        public Comment(string postid, string userid, string content)
        {
            this.postid = postid;
            this.userid = userid;
            this.content = content;
            datecreate = DateTime.Today;
        }

        public int Insert()
        {
            CommentDAO commdao = new CommentDAO();
            return commdao.Insert(this);
        }

        public List<Comment> SelectAll()
        {
            CommentDAO commdao = new CommentDAO();
            return commdao.SelectAll();
        }

        public int UpdateComment(string postId, string content, DateTime datecreate)
        {
            CommentDAO commdao = new CommentDAO();
            return commdao.UpdateComment(postId, content, datecreate);
        }
    }
}