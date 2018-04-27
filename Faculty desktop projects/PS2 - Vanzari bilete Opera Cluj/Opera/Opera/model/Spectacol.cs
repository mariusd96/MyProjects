using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Opera.model
{
    public class Spectacol
    {
        private int idSpectacol;
        private string gen;
        private string titlu;
        private string regia;
        private string dataPremiere;
        private int numarBilete;

        public Spectacol(int idSpectacol, string gen, string titlu, string regia, string dataPremiere, int numarBilete)
        {
            this.idSpectacol = idSpectacol;
            this.gen = gen;
            this.titlu = titlu;
            this.regia = regia;
            this.dataPremiere = dataPremiere;
            this.numarBilete = numarBilete;
        }

        public Spectacol()
        {

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

        public virtual string Gen
        {
            get
            {
                return gen;
            }

            set
            {
                gen = value;
            }
        }

        public virtual string Titlu
        {
            get
            {
                return titlu;
            }

            set
            {
                titlu = value;
            }
        }

        public virtual string Regia
        {
            get
            {
                return regia;
            }

            set
            {
                regia = value;
            }
        }

        public virtual string DataPremiere
        {
            get
            {
                return dataPremiere;
            }

            set
            {
                dataPremiere = value;
            }
        }

        public virtual int NumarBilete
        {
            get
            {
                return numarBilete;
            }

            set
            {
                numarBilete = value;
            }
        }

        public override string ToString()
        {
            return "idSpectacol = " + idSpectacol + ", gen = " + gen + "\n titlu = " + titlu + "\n regia = " + regia + "\n data premiere = " + dataPremiere + "\n numar bilete = " + numarBilete + "\n";
        }
    }
}
