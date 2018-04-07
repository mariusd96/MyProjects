using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodDelivery.models
{
    public class DetaliiComanda
    {
        private int idComanda;
        private string numeProdus;
        private double pret;
        private int cantitate;

        public DetaliiComanda(int idComanda, string numeProdus, double pret, int cantitate)
        {
            IdComanda = idComanda;
            NumeProdus = numeProdus;
            Pret = pret;
            Cantitate = cantitate;
        }

        public int IdComanda
        {
            get
            {
                return idComanda;
            }

            set
            {
                idComanda = value;
            }
        }

        public string NumeProdus
        {
            get
            {
                return numeProdus;
            }

            set
            {
                numeProdus = value;
            }
        }

        public double Pret
        {
            get
            {
                return pret;
            }

            set
            {
                pret = value;
            }
        }

        public int Cantitate
        {
            get
            {
                return cantitate;
            }

            set
            {
                cantitate = value;
            }
        }

        public override string ToString()
        {
            return "Detalii comanda -> idComanda : " + idComanda + ", numeProdus : " + numeProdus + ", pret : " + pret + ", cantitate : " + cantitate;
        }
    }
}
