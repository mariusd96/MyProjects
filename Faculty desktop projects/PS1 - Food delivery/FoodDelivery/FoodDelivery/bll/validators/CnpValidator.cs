using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using FoodDelivery.models;

namespace FoodDelivery.bll.validators
{
    class CnpValidator : IValidator<Client>
    {
        public void validate(Client t)
        {
            string codCorector = "279146358279";
            bool ok = true;
            int suma = 0, cifraControl = 0;

            if (t.Cnp.Length == 13)
            {
                for (int i = 0; i < 12; i++) suma += (t.Cnp[i] - '0') * (codCorector[i] - '0');
                cifraControl = suma % 11;
                cifraControl = cifraControl == 10 ? 1 : cifraControl;

                if (cifraControl != (t.Cnp[12] - '0')) ok = false;
            }
            else ok = false;

            if(ok == false) throw new Exception("CNP invalid !");
        }
    }
}
