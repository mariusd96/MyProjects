using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using FoodDelivery.models;
using FoodDelivery.dao;

namespace FoodDelivery.bll
{
    class ProdusBLL
    {
        public ProdusBLL()
        {

        }

        public int validareProdus(Produs p)
        {
            if (p.Categorie.ToString().Length < 1) return 0;
            if (p.Nume.ToString().Length < 1) return 0;
            if (p.Descriere.ToString().Length < 1) return 0;
            if (p.Gramaj <= 0) return 0;
            if (p.Pret < 0.01) return 0; 

            return 1;
        }

        public static void insertProdus(Produs p)
        {
            ReflectionDAO.insert(p, "Produs");
        }

        public static Produs selectProdus(Produs a)
        {
            return (Produs)ReflectionDAO.select(a, "Produs");
        }

        public static void updateProdus(Produs produsModificat, Produs produsOriginal)
        {
            ReflectionDAO.update(produsModificat, produsOriginal, "Produs");
        }

        public static void deleteProdus(Produs produs)
        {
            ReflectionDAO.delete(produs, "Produs");
        }
    }
}
