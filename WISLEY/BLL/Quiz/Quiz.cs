using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WISLEY.DAL.Quiztool;

namespace WISLEY.BLL.Quiz
{
    public class Quiz
    {
        public string title { get; set; }
        public string description { get; set; }
        public string datecreated { get; set; }
        public string userId { get; set; }
        public string quizId { get; set; }

        public Quiz()
        {

        }

        public Quiz(string title, string description, string datecreated, string userId, string quizId)
        {
            this.title = title;
            this.description = description;
            this.datecreated = datecreated;
            this.userId = userId;
            this.quizId = quizId;
        }

        public int AddQuiz()
        {
            QuizDAO quizdao = new QuizDAO();
            return quizdao.Insert(this);
        }

        public List<Quiz> SelectByUserId(string userId) {
            QuizDAO quizdao = new QuizDAO();
            return quizdao.SelectByUserId(userId);
        }

        public Quiz SelectById(string quizId)
        {
            QuizDAO quizdao = new QuizDAO();
            return quizdao.SelectById(quizId);
        }

        public int DeleteById(string quizId)
        {
            QuizDAO quizdao = new QuizDAO();
            return quizdao.DeleteById(quizId);
        }
    }
}