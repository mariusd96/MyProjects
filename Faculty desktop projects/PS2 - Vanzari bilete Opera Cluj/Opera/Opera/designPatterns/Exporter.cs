using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Opera.model;

namespace Opera.designPatterns
{
    public interface Exporter
    {
        void export(string numeSpectacol, List<Bilet> bilete);
    }
}
