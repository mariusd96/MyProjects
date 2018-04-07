using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodDelivery.models
{
    public class Comanda
    {
        private int idComanda;
        private int idClient;
        private string dataComanda;
        private double pretTotal;
        private string modalitatePlata;

        public Comanda(int idClient, string dataComanda, double pretTotal, string modalitatePlata)
        {
            IdClient = idClient;
            DataComanda = dataComanda;
            PretTotal = pretTotal;
            ModalitatePlata = modalitatePlata;
        }

        public Comanda(int idComanda, int idClient, string dataComanda, double pretTotal, string modalitatePlata)
        {
            IdComanda = idComanda;
            IdClient = idClient;
            DataComanda = dataComanda;
            PretTotal = pretTotal;
            ModalitatePlata = modalitatePlata;
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

        public int IdClient
        {
            get
            {
                return idClient;
            }

            set
            {
                idClient = value;
            }
        }

        public string DataComanda
        {
            get
            {
                return dataComanda;
            }

            set
            {
                dataComanda = value;
            }
        }

        public double PretTotal
        {
            get
            {
                return pretTotal;
            }

            set
            {
                pretTotal = value;
            }
        }

        public string ModalitatePlata
        {
            get
            {
                return modalitatePlata;
            }

            set
            {
                modalitatePlata = value;
            }
        }

        public override string ToString()
        {
            return "Comanda : " + IdComanda + ", client : " + idClient + " data efectuarii comenzii : " + dataComanda + ", pret total : " + pretTotal + ", modalitate plate : " + modalitatePlata;
        }
    }
}
