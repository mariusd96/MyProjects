using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Opera.model
{
    public class Casier : User
    {
        private string nume;

        public Casier(string nume, string user, string pass) : base(user, pass)
        {
            this.nume = nume;
        }

        public Casier() : base() { }

        public virtual string Nume
        {
            get
            {
                return nume;
            }

            set
            {
                nume = value;
            }
        }

        public override string ToString()
        {
            return "Nume = " + Nume + ", Username = " + Username + ", Password = " + Password;
        }
    }
}
