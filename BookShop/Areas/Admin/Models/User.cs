using System;

namespace BookShop.Areas.Admin.Models
{
    public class User
    {
        private string User_ID;
        private string FullName;
        private string UserName;
        private string Password;
        private string Email;
        private string Address;
        private string Phone;
        private string Role;

        public string user_ID
        {
            get { return User_ID; }
            set { User_ID = value; }
        }
        public string fullname
        {
            get { return FullName; }
            set { FullName = value; }
        }
        public string username
        {
            get { return UserName; }
            set { UserName = value; }
        }
        public string password
        {
            get { return Password; }
            set { Password = value; }
        }

        public string email
        {
            get { return Email; }
            set { Email = value; }
        }
        public string address
        {
            get { return Address; }
            set { Address = value; }
        }

        public string phone
        {
            get { return Phone; }
            set { Phone = value; }
        }
        public string role
        {
            get { return Role; }
            set { Role = value; }
        }
        public User()
        {
        }

        public User(string usname, string pass, string mail)
        {
            this.UserName = usname;
            this.Password = pass;
            this.Email = mail;
        }

       
    }
}
