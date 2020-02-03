using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WISLEY.BLL.Resources;
using WISLEY.DAL.Group;
using WISLEY.DAL.Resources;

namespace WISLEY.BLL.Group
{
    public class Group
    {
        public string name { get; set; }
        public string description { get; set; }
        public int weightage { get; set; }
        public int id { get; set; }
        public string joinCode { get; set; }
        public int status { get; set; }

        public Group()
        {

        }

        public Group(string Name, string Description, int Weightage, int id = -1, string joinCode = "", int status = 1)
        {
            name = Name;
            description = Description;
            weightage = Weightage;
            this.id = id;
            this.joinCode = joinCode;
            this.status = status;
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

        public int resetGroupJoinCode(int id)
        {
            GroupDAO groupDAO = new GroupDAO();
            return groupDAO.ResetGroupJoinCode(id);
        }

        public int joinGroup(string email, string code)
        {
            GroupDAO groupDAO = new GroupDAO();
            return groupDAO.joinGroup(email, code);
        }

        public List<Group> getGroupsJoined(string email)
        {
            List<Group> grpList = new List<Group>(); 
            GroupDAO groupDAO = new GroupDAO();
            List<int> grpIdList = groupDAO.SelectUserGroupsJoined(email);

            if (grpIdList.Count > 0){
                for (int j = 0; j < grpIdList.Count; j++)
                {
                    Group grp = groupDAO.SelectGroupByAttribute("Id", grpIdList[j].ToString());
                    grpList.Add(grp);
                }
            }

            return grpList;
        }

        public List<grpResourceType> getGroupResourceTypes(int grpId)
        {
            //List<grpResourceType> typeList = new List<grpResourceType>();
            grpResourceTypeDAO RsTypeDAO = new grpResourceTypeDAO();
            return RsTypeDAO.GetGrpResourceTypes(grpId);
        }


    }
}