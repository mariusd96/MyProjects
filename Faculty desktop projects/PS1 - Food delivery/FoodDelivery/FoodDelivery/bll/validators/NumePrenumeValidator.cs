using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using FoodDelivery.models;

namespace FoodDelivery.bll.validators
{
    class NumePrenumeValidator : IValidator<Client>
    {
        public void validate(Client t)
        {
            bool ok = true;

            if(t.Nume.Length > 0)
            {
                for (int i = 0; i < t.Nume.Length && ok == true; i++)
                {
                    char litera = Convert.ToChar(t.Nume[i]);
                    if (!((litera >= 'a' && litera <= 'z') || (litera >= 'A' && litera <= 'Z'))) ok = false;
                }
            }

            if(ok == true)
            {
                if (t.Prenume.Length > 0)
                {
                    for (int i = 0; i < t.Prenume.Length && ok == true; i++)
                    {
                        char litera = Convert.ToChar(t.Prenume[i]);
                        if (!((litera >= 'a' && litera <= 'z') || (litera >= 'A' && litera <= 'Z'))) ok = false;
                    }
                }
            }

            if(ok == false) throw new Exception("Nume/Prenume invalid");
        }
    }
}
