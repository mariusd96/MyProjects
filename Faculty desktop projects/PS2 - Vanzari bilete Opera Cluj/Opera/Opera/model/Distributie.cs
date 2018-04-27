using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Opera.model
{
    public class Distributie
    {
        private int idSpectacol;
        private string numeActor;

        public Distributie(int idSpectacol, string numeActor)
        {
            this.idSpectacol = idSpectacol;
            this.numeActor = numeActor;
        }

        public Distributie()
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

        public virtual string NumeActor
        {
            get
            {
                return numeActor;
            }

            set
            {
                numeActor = value;
            }
        }

        public override string ToString()
        {
            return "idSpectacol = " + idSpectacol + ", nume actor = " + numeActor;
        }
    }
}
