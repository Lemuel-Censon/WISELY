using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

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
            datecreated = DateTime.Now;
            this.userId = userId;
        }
    }
}