using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodDelivery.models
{
    class CategoriiProdus
    {
        string categorie;

        public CategoriiProdus(string categorie)
        {
            Categorie = categorie;
        }

        public string Categorie
        {
            get
            {
                return categorie;
            }

            set
            {
                categorie = value;
            }
        }
    }
}
