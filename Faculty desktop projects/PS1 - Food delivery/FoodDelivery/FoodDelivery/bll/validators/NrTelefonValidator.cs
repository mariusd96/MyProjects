using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using FoodDelivery.models;

namespace FoodDelivery.bll.validators
{
    class NrTelefonValidator : IValidator<Client>
    {
        public void validate(Client t)
        {
            bool ok = true;

            if (t.NrTelefon.Length == 10)
            {
                for (int i = 0; i < 10 && ok == true; i++)
                {
                    char cifra = Convert.ToChar(t.NrTelefon[i]);
                    if (!(cifra >= '0' && cifra <= '9')) ok = false;
                }
            }
            else ok = false;

            if(ok == false) throw new Exception("Numar de telefon invalid!");
        }
    }
}
