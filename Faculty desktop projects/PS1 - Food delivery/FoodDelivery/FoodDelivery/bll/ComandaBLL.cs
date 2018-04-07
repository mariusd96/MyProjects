using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using FoodDelivery.models;
using FoodDelivery.dao;

namespace FoodDelivery.bll
{
    class ComandaBLL
    {
        public static void insertComanda(Comanda c)
        {
            ComandaDAO.insertComanda(c);
        }

        public static Comanda selectComanda(Comanda a)
        {
            return ComandaDAO.getComanda(a);
        }
    }
}
