using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WISLEY.DAL.Schedule;

namespace WISLEY.BLL.Schedule
{
    public class Planner
    {
        public string userId { get; set; }
        public DateTime todoDate { get; set; }
        public string todoTitle { get; set; }
        public string todoDescription { get; set; }

        public Planner()
        {

        }

        public Planner(string userID, DateTime tododate, string todotitle, string tododescription)
        {
            this.userId = userID;
            this.todoDate = tododate;
            this.todoTitle = todotitle;
            this.todoDescription = tododescription;
        }

        public int AddToDoList()
        {
            PlannerDAO plannerdao = new PlannerDAO();
            return plannerdao.Insert(this);
        }
    }
}