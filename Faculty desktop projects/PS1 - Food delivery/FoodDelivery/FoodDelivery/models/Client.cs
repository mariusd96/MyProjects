using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodDelivery.models
{
    public class Client
    {
        private int idClient;
        private string username;
        private string nume;
        private string prenume;
        private string cnp;
        private string adresaLivrare;
        private string nrTelefon;
        private string email;
        private char eClientLoial;

        public Client(string username, string nume, string prenume, string cnp, string adresaLivrare, string nrTelefon, string email, char eClientLoial)
        {
            Username = username;
            Nume = nume;
            Prenume = prenume;
            Cnp = cnp;
            AdresaLivrare = adresaLivrare;
            NrTelefon = nrTelefon;
            Email = email;
            EClientLoial = eClientLoial;
        }

        public Client(int idClient, string username, string nume, string prenume, string cnp, string adresaLivrare, string nrTelefon, string email, char eClientLoial)
        {
            IdClient = idClient;
            Username = username;
            Nume = nume;
            Prenume = prenume;
            Cnp = cnp;
            AdresaLivrare = adresaLivrare;
            NrTelefon = nrTelefon;
            Email = email;
            EClientLoial = eClientLoial;
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

        public string Username
        {
            get
            {
                return username;
            }

            set
            {
                username = value;
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

        public string Prenume
        {
            get
            {
                return prenume;
            }

            set
            {
                prenume = value;
            }
        }

        public string Cnp
        {
            get
            {
                return cnp;
            }

            set
            {
                cnp = value;
            }
        }

        public string AdresaLivrare
        {
            get
            {
                return adresaLivrare;
            }

            set
            {
                adresaLivrare = value;
            }
        }

        public string NrTelefon
        {
            get
            {
                return nrTelefon;
            }

            set
            {
                nrTelefon = value;
            }
        }

        public string Email
        {
            get
            {
                return email;
            }

            set
            {
                email = value;
            }
        }

        public char EClientLoial
        {
            get
            {
                return eClientLoial;
            }

            set
            {
                eClientLoial = value;
            }
        }

        public override string ToString()
        {
            return "Client : " + idClient + ", username : " + username + ", nume : " + nume + ", prenume : " + prenume + ", cnp : " + cnp + ", adresa de livrare : " + adresaLivrare + ", nr telefon : " + nrTelefon + ", email : " + email + ", e client loial :" + eClientLoial;
        }
    }
}
