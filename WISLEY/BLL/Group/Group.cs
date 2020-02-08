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

        public string userEmail { get; set; }
        public int customOrder { get; set; }
        public int show { get; set; }

        public Group()
        {

        }

        public Group(string Name, string Description, int Weightage = -1, 
            int id = -1, string joinCode = "", int status = 1,
            string userEmail = "", int customOrder = -1, int show = 1)
        {
            name = Name;
            description = Description;
            weightage = Weightage;
            this.id = id;
            this.joinCode = joinCode;
            this.status = status;

            this.userEmail = userEmail;
            this.customOrder = customOrder;
            this.show = show;
        }

        public int addGroup(string email)
        {
            GroupDAO groupDAO = new GroupDAO();

            return groupDAO.Insert(this, email);
        }

        public int updateGroup(int id, string name,string desc, int weightage)
        {
            GroupDAO groupDAO = new GroupDAO();
            return groupDAO.Update(id, name, desc, weightage);

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

        public List<Group> getGroupsJoined(string email)
        {

            GroupDAO groupDAO = new GroupDAO();
            List<Group> grpIdList = groupDAO.SelectUserGroupsJoined(email);

            return grpIdList;
        }

        public List<string> getGroupMembers(string groupId)
        {
            GroupDAO groupdao = new GroupDAO();
            return groupdao.SelectGroupMembers(groupId);
        }

        public List<grpResourceType> getGroupResourceTypes(int grpId)
        {
            grpResourceTypeDAO RsTypeDAO = new grpResourceTypeDAO();
            return RsTypeDAO.GetGrpResourceTypes(grpId);
        }

        public List<BLL.Profile.User> getAddableUsers(string groupId)
        {
            GroupDAO groupDAO = new GroupDAO();
            List<BLL.Profile.User> addableUserList = groupDAO.SelectNonMembers(groupId);
            System.Diagnostics.Debug.WriteLine(addableUserList.Count);

            return addableUserList;

        }



        public int hideJoinedGroup(string email, string groupId)
        {
            GroupDAO groupDAO = new GroupDAO();
            return groupDAO.hideJoinedGroup(email, groupId);
        }

        public int showJoinedGroup(string email, string groupId)
        {
            GroupDAO groupDAO = new GroupDAO();
            return groupDAO.showJoinedGroup(email, groupId);
        }

        public int disableGroup(string groupId)
        {
            GroupDAO groupDAO = new GroupDAO();
            return groupDAO.disableGroup(groupId);
        }

        public int enableGroup(string groupId)
        {
            GroupDAO groupDAO = new GroupDAO();
            return groupDAO.enableGroup(groupId);
        }


        public int addMemberToGroup(string email, string groupId)
        {
            GroupDAO groupDAO = new GroupDAO();
            return groupDAO.addMemberToGroup(email, groupId);
        }

        public int removeMemberFromGroup(string email, string groupId)
        {
            GroupDAO groupDAO = new GroupDAO();
            return groupDAO.removeMemberFromGroup(email, groupId);
        }
    }
}