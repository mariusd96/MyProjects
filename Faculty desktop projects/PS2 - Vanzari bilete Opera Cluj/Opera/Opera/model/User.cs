using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Opera.model
{
    public class User
    {
        private string username;
        private string password;

        public User(string username, string password)
        {
            this.username = username;
            this.password = password;
        }

        public User()
        {

        }

        public virtual string Username
        {
            get
            {
                return username;
            }

            set
            {
                username = value;
            }
        }

        public virtual string Password
        {
            get
            {
                return password;
            }

            set
            {
                password = value;
            }
        }

        public override string ToString()
        {
            return "Username = " + Username + ", Password = " + Password;
        }
    }
}
