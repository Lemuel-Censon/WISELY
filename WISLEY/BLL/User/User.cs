using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WISLEY.DAL.Profile;

namespace WISLEY.BLL.Profile
{
    public class User
    {
        public string email { get; set; }
        public string name { get; set; }
        public string password { get; set; }
        public string contactNo { get; set; }
        public string userType { get; set; }
        public string dob { get; set; }
        public string gender { get; set; }
        public int experience { get; set; }
        public int points { get; set; }
        public string inGroupsId { get; set; }

        public User()
        {

        }

        public User(string email, string password, string userType, string name, string dob, string contactNo, string gender, int experience, int points, string inGroupsId = "")
        {
            this.inGroupsId = inGroupsId;
            this.email = email;
            this.password = password;
            this.userType = userType;
            this.name = name;
            this.dob = dob;
            this.contactNo = contactNo;
            this.gender = gender;
            this.experience = experience;
            this.points = points;
        }

        public int AddUser()
        {
            UserDAO userdao = new UserDAO();
            return userdao.Insert(this);
        }

        public User SelectByEmail(string email)
        {
            UserDAO userdao = new UserDAO();
            return userdao.SelectByEmail(email);
        }

        public int UpdateUser(string email, string name, string dob, string contactNo)
        {
            UserDAO userdao = new UserDAO();
            return userdao.UpdateUser(email, name, dob, contactNo);
        }

        public int UpdatePassword(string email, string password)
        {
            UserDAO userdao = new UserDAO();
            return userdao.UpdatePassword(email, password);
        }
    }
}