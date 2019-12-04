﻿using System;
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

        public Post()
        {

        }

        public Post(string title, string content, string userId)
        {
            this.title = title;
            this.content = content;
            datecreated = DateTime.Today;
            this.userId = userId;
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

        public int UpdatePost(string userId, string title, string content, DateTime datecreate)
        {
            PostDAO postdao = new PostDAO();
            return postdao.UpdatePost(userId, title, content, datecreate);
        }
    }
}