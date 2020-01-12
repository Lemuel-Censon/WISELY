using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WISLEY.DAL.Group;

namespace WISLEY.BLL.Group
{
    public class Group
    {
        public string name { get; set; }
        public string description { get; set; }
        public int weightage { get; set; }

        public Group()
        {

        }

        public Group(string Name, string Description, int Weightage)
        {
            name = Name;
            description = Description;
            weightage = Weightage;
        }

        public int addGroup(string email)
        {
            GroupDAO groupDAO = new GroupDAO();

            return groupDAO.Insert(this, email);
        }

        public Group getGroupByID(string GroupId)
        {
            GroupDAO groupDAO = new GroupDAO();
            return groupDAO.SelectByID(GroupId);
        }
    }
}