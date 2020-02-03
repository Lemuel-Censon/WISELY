using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WISLEY.DAL.Collab;

namespace WISLEY.BLL.Collab
{
    public class Post
    {
        public int Id { get; set; }
        public string title { get; set; }
        public string content { get; set; }
        public string datecreated { get; set; }
        public string fileName { get; set; }
        public string userId { get; set; }
        public string username { get; set; }
        public string profilesrc { get; set; }
        public int views { get; set; }
        public int likes { get; set; }
        public string groupId { get; set; }
        public string status { get; set; }

        public Post()
        {

        }

        public Post(string title, string content, string userId, string groupId, string datecreated, string fileName, int Id = -1, string username = "", string profilesrc = "", int views = 0, int likes = 0, string status = "")
        {
            this.title = title;
            this.content = content;
            this.datecreated = datecreated;
            this.fileName = fileName;
            this.userId = userId;
            this.groupId = groupId;
            this.username = username;
            this.profilesrc = profilesrc;
            this.views = views;
            this.likes = likes;
            this.status = status;
            this.Id = Id;
        }

        public int AddPost()
        {
            PostDAO postdao = new PostDAO();
            return postdao.Insert(this);
        }

        public List<Post> SelectByID(string postId)
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

        public List<Post> SelectByEmail(string email)
        {
            PostDAO postdao = new PostDAO();
            return postdao.SelectByEmail(email);
        }

        public int UpdatePost(string postId, string title, string content, string datecreate)
        {
            PostDAO postdao = new PostDAO();
            return postdao.UpdatePost(postId, title, content, datecreate);
        }

        public int UpdateView(string postId, int view)
        {
            PostDAO postdao = new PostDAO();
            return postdao.UpdateView(postId, view);
        }

        public int UpdateLikes(string postId, int likes)
        {
            PostDAO postdao = new PostDAO();
            return postdao.UpdateLikes(postId, likes);
        }

        public int DelPostUpdate(string postId, string status)
        {
            PostDAO postdao = new PostDAO();
            return postdao.DelPostUpdate(postId, status);
        }

    }
}