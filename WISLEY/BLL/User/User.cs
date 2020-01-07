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
        public string email { get; set; }
        public string password { get; set; }
        public string userType { get; set; }
        public string fName { get; set; }
        public string lName { get; set; }
        public DateTime dob { get; set; }
        public string contactNo { get; set; }
        public string location { get; set; }

        public User()
        {

        }

        public User(string userId, string email, string password, string userType, string fName, string lName, DateTime dob, string contactNo, string location)
        {
            this.userId = userId;
            this.email = email;
            this.password = password;
            this.userType = userType;
            this.fName = fName;
            this.lName = lName;
            this.dob = dob;
            this.contactNo = contactNo;
            this.location = location;
        }

        public int AddUser()
        {
            UserDAO userdao = new UserDAO();
            return userdao.Insert(this);
        }
    }
}