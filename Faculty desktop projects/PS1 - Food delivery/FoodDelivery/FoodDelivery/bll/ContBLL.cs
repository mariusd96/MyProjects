using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using FoodDelivery.models;
using FoodDelivery.dao;

namespace FoodDelivery.bll
{
    public class ContBLL
    {
        public static Cont findUser(Cont obj)
        {
            Cont c = null;
            c = (Cont)ReflectionDAO.select(obj, "Cont");
            return c;
        }

        public static void insertUser(Cont obj)
        {
            //System.Windows.MessageBox.Show("Cont");
            ReflectionDAO.insert(obj, "Cont");
        }

        public static void updateClient(Cont contModificat, Cont contOriginal)
        {
            ReflectionDAO.update(contModificat, contOriginal, "Cont");
        }

        public static void deleteClient(Cont cont)
        {
            ReflectionDAO.delete(cont, "Cont");
        }
    }
}
