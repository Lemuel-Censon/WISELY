using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WISLEY.DAL.Schedule;

namespace WISLEY.BLL.Schedule
{
    public class Planner
    {
        public int Id { get; set; }
        public int userId { get; set; }
        public string todoDate { get; set; }
        public string todoTitle { get; set; }
        public string todoDescription { get; set; }
        public string todoStatus { get; set; }

        public Planner()
        {

        }

        public Planner(int userID, string tododate, string todotitle, string tododescription, string todoStatus="", int Id = -1)
        {
            this.userId = userID;
            this.todoDate = tododate;
            this.todoTitle = todotitle;
            this.todoDescription = tododescription;
            this.todoStatus = todoStatus;
            this.Id = Id;
        }


        public int AddToDoList()
        {
            PlannerDAO plannerdao = new PlannerDAO();
            return plannerdao.Insert(this);
        }

        public List<Planner> SelectByUser(int userId)
        {
            PlannerDAO plannerdao = new PlannerDAO();
            return plannerdao.SelectbyUser(userId);
        }

        public Planner SelectByID(string id)
        {
            PlannerDAO plannerDAO = new PlannerDAO();
            return plannerDAO.SelectByID(id);
        }

        public int UpdateToDo(string todoID, string title, string description)
        {
            PlannerDAO plannerDAO = new PlannerDAO();
            return plannerDAO.UpdateToDoList(todoID, title, description);
        }

        public int DeleteToDo(string todoId, string status)
        {
            PlannerDAO plannerDAO = new PlannerDAO();
            return plannerDAO.DeleteToDoList(todoId, status);
        }

        public string SelectByDate(string selectedDate)
        {
            PlannerDAO plannerDAO = new PlannerDAO();
            return plannerDAO.SelectByDate(selectedDate);
        }
    }
}