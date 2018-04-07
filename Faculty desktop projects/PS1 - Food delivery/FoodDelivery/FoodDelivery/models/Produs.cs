using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodDelivery.models
{
    public class Produs
    {
        private int idProdus;
        private string categorie;
        private string nume;
        private string descriere;
        private int gramaj;
        private double pret;

        public Produs(int idProdus, string categorie, string nume, string descriere, int gramaj, double pret)
        {
            IdProdus = idProdus;
            Categorie = categorie;
            Nume = nume;
            Descriere = descriere;
            Gramaj = gramaj;
            Pret = pret;
        }

        public int IdProdus
        {
            get
            {
                return idProdus;
            }

            set
            {
                idProdus = value;
            }
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

        public string Nume
        {
            get
            {
                return nume;
            }

            set
            {
                nume = value;
            }
        }

        public string Descriere
        {
            get
            {
                return descriere;
            }

            set
            {
                descriere = value;
            }
        }

        public int Gramaj
        {
            get
            {
                return gramaj;
            }

            set
            {
                gramaj = value;
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

        public override string ToString()
        {
            return "Produs : " + idProdus + ", categorie : " + categorie + ", nume : " + nume + ", descriere : " + descriere + ", gramaj : " + gramaj + ", pret : " + pret;
        }
    }
}
