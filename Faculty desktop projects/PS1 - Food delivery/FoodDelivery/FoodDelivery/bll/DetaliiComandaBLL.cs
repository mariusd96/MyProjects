using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using FoodDelivery.models;
using FoodDelivery.bll.validators;
using FoodDelivery.dao;

namespace FoodDelivery.bll
{
    class DetaliiComandaBLL
    {
        public DetaliiComandaBLL()
        {

        }

        public void insertDetaliiComanda(DetaliiComanda dc)
        {
            DetaliiComandaDAO.insertDetaliuComanda(dc);
        }

        public void selectDetaliiComanda(DetaliiComanda dc)
        {
            ReflectionDAO.select(dc, "DetaliiComanda");
        }
    }
}
