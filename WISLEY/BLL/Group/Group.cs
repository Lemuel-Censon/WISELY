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
        public int id { get; set; }
        public string joinCode { get; set; }

        public Group()
        {

        }

        public Group(string Name, string Description, int Weightage, int id = -1, string joinCode = "")
        {
            name = Name;
            description = Description;
            weightage = Weightage;
            this.id = id;
            this.joinCode = joinCode;
        }

        public int addGroup(string email)
        {
            GroupDAO groupDAO = new GroupDAO();

            return groupDAO.Insert(this, email);
        }

        public Group getGroupByID(string GroupId)
        {
            GroupDAO groupDAO = new GroupDAO();
            return groupDAO.SelectGroupByAttribute("Id", GroupId);
        }

        public Group getGroupByAttribute(string attribute, string data)
        {
            GroupDAO groupDAO = new GroupDAO();
            return groupDAO.SelectGroupByAttribute(attribute, data);

        }

        public int updateGroup(int id, string desc, int weightage)
        {
            GroupDAO groupDAO = new GroupDAO();
            return groupDAO.Update(id, desc, weightage);

        }

        public int joinGroup(string email, string code)
        {
            GroupDAO groupDAO = new GroupDAO();
            return groupDAO.joinGroup(email, code);
        }
    }
}