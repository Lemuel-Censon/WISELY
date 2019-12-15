using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WISLEY.DAL.Collab;

namespace WISLEY.BLL.Collab
{
    public class Post
    {
        public string title { get; set; }
        public string content { get; set; }
        public DateTime datecreated { get; set; }
        public string userId { get; set; }
        public string groupId { get; set; }

        public Post()
        {

        }

        public Post(string title, string content, string userId, string groupId)
        {
            this.title = title;
            this.content = content;
            datecreated = DateTime.Today;
            this.userId = userId;
            this.groupId = groupId;
        }

        public int AddPost()
        {
            PostDAO postdao = new PostDAO();
            return postdao.Insert(this);
        }

        public List<Post> SelectAll()
        {
            PostDAO postdao = new PostDAO();
            return postdao.SelectAll();
        }

        public List<string> SelectIDs()
        {
            PostDAO postdao = new PostDAO();
            return postdao.SelectIDs();
        }

        public int UpdatePost(string userId, string title, string content, DateTime datecreate)
        {
            PostDAO postdao = new PostDAO();
            return postdao.UpdatePost(userId, title, content, datecreate);
        }
    }
}