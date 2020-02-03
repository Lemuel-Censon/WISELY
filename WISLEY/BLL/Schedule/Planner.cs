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
        public DateTime todoDate { get; set; }
        public string todoTitle { get; set; }
        public string todoDescription { get; set; }

        public Planner()
        {

        }

        public Planner(int userID, DateTime tododate, string todotitle, string tododescription, int Id = -1)
        {
            this.userId = userID;
            this.todoDate = tododate;
            this.todoTitle = todotitle;
            this.todoDescription = tododescription;
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
    }
}