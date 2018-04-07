using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Text.RegularExpressions;
using FoodDelivery.models;

namespace FoodDelivery.bll.validators
{
    class EmailValidator : IValidator<Client>
    {
        public void validate(Client t)
        {
            string pattern = @"^([a-zA-Z0-9_\-\.]+)@((\[[0-9]{1,3}" + @"\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([a-zA-Z0-9\-]+\" + @".)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$";

            if (!Regex.IsMatch(t.Email, pattern)) throw new Exception("Email invalid!");
        }
    }
}
