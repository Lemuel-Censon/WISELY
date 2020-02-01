using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WISLEY.DAL.Collab;

namespace WISLEY.BLL.Collab
{
    public class PostLikes
    {
        public int userId { get; set; }
        public string postId { get; set; }

        public PostLikes()
        {

        }

        public PostLikes(int userId, string postId)
        {
            this.userId = userId;
            this.postId = postId;
        }

        public int AddLike()
        {
            PostLikesDAO likesdao = new PostLikesDAO();
            return likesdao.Insert(this);
        }

        public int Unlike(int userId, string postId)
        {
            PostLikesDAO likesdao = new PostLikesDAO();
            return likesdao.Remove(userId, postId);
        }

        public List<string> SelectLikesByUser(int userId)
        {
            PostLikesDAO likesdao = new PostLikesDAO();
            return likesdao.SelectLikesByUser(userId);
        }
    }
}