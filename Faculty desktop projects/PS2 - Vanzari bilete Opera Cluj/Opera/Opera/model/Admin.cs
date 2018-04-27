using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Opera.model
{
    public class Admin : User
    {
        public Admin(string user, string pass) : base(user, pass) { }

        public Admin() : base() { }
    }
}
