using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Opera.model
{
    public class Bilet
    {
        private int idBilet;
        private int idSpectacol;
        private int rand;
        private int coloana;

        public Bilet(int idSpectacol, int rand, int coloana)
        {
            this.idSpectacol = idSpectacol;
            this.rand = rand;
            this.coloana = coloana;
        }

        public Bilet() { }

        public virtual int IdBilet
        {
            get
            {
                return idBilet;
            }

            set
            {
                idBilet = value;
            }
        }

        public virtual int IdSpectacol
        {
            get
            {
                return idSpectacol;
            }

            set
            {
                idSpectacol = value;
            }
        }

        public virtual int Rand
        {
            get
            {
                return rand;
            }

            set
            {
                rand = value;
            }
        }

        public virtual int Coloana
        {
            get
            {
                return coloana;
            }

            set
            {
                coloana = value;
            }
        }

        public override string ToString()
        {
            return "idBilet = " + idBilet + ", idSpectacol = " + IdSpectacol + ", rand = " + Rand + ", coloana = " + Coloana;
        }

        public virtual string csvString()
        {
            return IdBilet + ";" + IdSpectacol + ";" + Rand + ";" + Coloana;
        }
    }
}