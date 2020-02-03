using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WISLEY.DAL.Quiztool;

namespace WISLEY.BLL.Quiz
{
    public class Question
    {
        public string question { get; set; }
        public string number { get; set; }
        public string option1 { get; set; }
        public string option2 { get; set; }
        public string option3 { get; set; }
        public string option4 { get; set; }
        public string answer { get; set; }
        public string quizId { get; set; }

        public Question()
        {

        }

        public Question(string question, string number, string option1, string option2, string option3, string option4, string answer, string quizId)
        {
            this.question = question;
            this.number = number;
            this.option1 = option1;
            this.option2 = option2;
            this.option3 = option3;
            this.option4 = option4;
            this.answer = answer;
            this.quizId = quizId;
        }

        public int AddQuestion()
        {
            QuestionDAO questiondao = new QuestionDAO();
            return questiondao.Insert(this);
        }

        public List<Question> SelectQuestion(string quizId)
        {
            QuestionDAO questiondao = new QuestionDAO();
            return questiondao.SelectQuestion(quizId);
        }

        public string GetQuestionCount(string quizId)
        {
            QuestionDAO questiondao = new QuestionDAO();
            return questiondao.GetQuestionCount(quizId).ToString();
        }
    }
}