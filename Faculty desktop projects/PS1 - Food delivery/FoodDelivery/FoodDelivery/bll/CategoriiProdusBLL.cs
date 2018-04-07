using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using FoodDelivery.models;
using FoodDelivery.dao;

namespace FoodDelivery.bll
{
    class CategoriiProdusBLL
    {
        public static void insertCategorie(CategoriiProdus obj)
        {
            ReflectionDAO.insert(obj, "CategoriiProdus");
        }

        public static CategoriiProdus findCategorie(CategoriiProdus obj)
        {
            return (CategoriiProdus)(ReflectionDAO.select(obj, "CategoriiProdus"));
        }
    }
}
