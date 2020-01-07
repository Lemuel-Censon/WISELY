using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WISLEY.DAL.Profile;

namespace WISLEY.BLL.Profile
{
    public class User
    {
        public string userId { get; set; }
        public string groupId { get; set; }
        public string email { get; set; }
        public string name { get; set; }
        public string password { get; set; }
        public string gender { get; set; }
        public string dob { get; set; }
        public string department { get; set; }
        public string experience { get; set; }
        public string wisPoints { get; set; }
        public string accType { get; set; }

        public User()
        {

        }

        public User(string userId, string groupId, string email, string name, string password, string gender, string dob, string department, string experience, string wisPoints, string accType)
        {
            this.userId = userId;
            this.groupId = groupId;
            this.email = email;
            this.name = name;
            this.password = password;
            this.gender = gender;
            this.dob = dob;
            this.department = department;
            this.experience = experience;
            this.wisPoints = wisPoints;
            this.accType = accType;
        }

        public int AddUser()
        {
            UserDAO userdao = new UserDAO();
            return userdao.Insert(this);
        }

        public User SelectByID(string userId)
        {
            UserDAO userdao = new UserDAO();
            return userdao.SelectByID(userId);
        }
    }
}