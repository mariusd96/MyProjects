using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Opera.model
{
    public class DistributieBalet : Distributie
    {
        private int idActorBalet;

        public DistributieBalet(int idSpectacol, string numeActor) : base(idSpectacol, numeActor) { }

        public DistributieBalet() : base() { }

        public virtual int IdActorBalet
        {
            get
            {
                return idActorBalet;
            }

            set
            {
                idActorBalet = value;
            }
        }
    }
}
