using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Opera.model
{
    public class DistributieOp : Distributie
    {
        private int idActorOp;
        private string rolActor;

        public DistributieOp(int idSpectacol, string numeActor, string rolActor) : base(idSpectacol, numeActor)
        {
            this.rolActor = rolActor;
        }

        public DistributieOp() : base() { }

        public virtual int IdActorOp
        {
            get
            {
                return idActorOp;
            }

            set
            {
                idActorOp = value;
            }
        }

        public virtual string RolActor
        {
            get
            {
                return rolActor;
            }

            set
            {
                rolActor = value;
            }
        }
    }
}
