using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WISLEY.DAL.Quiztool;

namespace WISLEY.BLL.Quiz
{
    public class Quiz
    {
        public int Id { get; set; }
        public string title { get; set; }
        public string description { get; set; }
        public string datecreated { get; set; }
        public int totalquestions { get; set; }
        public string userId { get; set; }
        public string username { get; set; }
        public string profilesrc { get; set; }

        public Quiz()
        {

        }

        public Quiz(string title, string description, string datecreated, int totalquestions, string userId, int Id = -1, string username = "", string profilesrc = "")
        {
            this.title = title;
            this.description = description;
            this.datecreated = datecreated;
            this.totalquestions = totalquestions;
            this.userId = userId;
            this.username = username;
            this.profilesrc = profilesrc;
            this.Id = Id;
        }

        public int AddQuiz()
        {
            QuizDAO quizdao = new QuizDAO();
            return quizdao.Insert(this);
        }

        public List<Quiz> SelectAll()
        {
            QuizDAO quizdao = new QuizDAO();
            return quizdao.SelectAll();
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

        public int GetLastID()
        {
            QuizDAO quizdao = new QuizDAO();
            return quizdao.GetLastID();
        }

        public int DeleteById(string quizId)
        {
            QuizDAO quizdao = new QuizDAO();
            return quizdao.DeleteById(quizId);
        }

        public int UpdateQuiz(string title, string desc, string quizId)
        {
            QuizDAO quizdao = new QuizDAO();
            return quizdao.UpdateQuiz(title, desc, quizId);
        }

        public int UpdateTotalQuestions(int totalquestions, string quizId)
        {
            QuizDAO quizdao = new QuizDAO();
            return quizdao.UpdateTotalQuestions(totalquestions, quizId);
        }
    }
}