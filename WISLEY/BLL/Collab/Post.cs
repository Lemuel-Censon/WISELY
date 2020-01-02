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
        public string datecreated { get; set; }
        public string userId { get; set; }
        public string groupId { get; set; }

        public Post()
        {

        }

        public Post(string title, string content, string userId, string groupId, string datecreated)
        {
            this.title = title;
            this.content = content;
            this.datecreated = datecreated;
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

        public Post SelectByID(string postId)
        {
            PostDAO postdao = new PostDAO();
            return postdao.SelectByID(postId);
        }


        public List<Post> SelectByGrp(string grpId)
        {
            PostDAO postdao = new PostDAO();
            return postdao.SelectByGroup(grpId);
        }

        public List<Post> SelectByUser(string userId)
        {
            PostDAO postdao = new PostDAO();
            return postdao.SelectByUser(userId);
        }

        public int UpdatePost(string postId, string title, string content, string datecreate)
        {
            PostDAO postdao = new PostDAO();
            return postdao.UpdatePost(postId, title, content, datecreate);
        }
    }
}