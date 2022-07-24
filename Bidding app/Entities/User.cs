using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bidding_app.Entities
{
    internal abstract class User : ICloneable
    {
        private string _username;
        private string _password;
        private string _email;
        private string _phone;

        public User(string username, string password, string email, string phone)
        {
            _username = username;
            _password = password;
            _email = email;
            _phone = phone;
        }
        public string Username { get { return _username; } set { _username = value; } }
        public string Password { set { _password = value; } }
        public string Email { get { return _email; } set { _email = value; } }
        public string Phone { get { return _phone; } set { _phone = value; } }
        public void ChangePassword(string new_password)
        {
            _password = new_password;
        }
        public bool Login(string username, string password)
        {
            if (username.Equals(_username) && password.Equals(_password))
            {
                return true;
            }
            else return false;
        }

        public object Clone()
        {
            return this.MemberwiseClone();
        }
    }
}
