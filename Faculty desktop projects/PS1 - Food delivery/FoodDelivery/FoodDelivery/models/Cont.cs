using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodDelivery.models
{
    public class Cont
    {
        private string username;
        private string pass;
        private char rol;

        public Cont(string username, string pass, char rol)
        {
            this.Username = username;
            this.Pass = pass;
            this.Rol = rol;
        }

        public string Username
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

        public string Pass
        {
            get
            {
                return pass;
            }

            set
            {
                pass = value;
            }
        }

        public char Rol
        {
            get
            {
                return rol;
            }

            set
            {
                rol = value;
            }
        }

        public override string ToString()
        {
            return "Cont : " + username + ", parola : " + pass + ", rol : " + rol;
        }
    }
}
