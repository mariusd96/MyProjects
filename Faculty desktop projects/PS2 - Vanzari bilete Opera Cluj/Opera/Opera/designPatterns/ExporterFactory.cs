using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Opera.designPatterns
{
    public class ExporterFactory
    {
        public ExporterFactory() { }

        public Exporter getExporter(String str)
        {
            if (str == null) return null;

            if (str.ToLower() == "csv") return new CsvExporter();
            else if (str.ToLower() == "json") return new JsonExporter();
            else if (str.ToLower() == "xml") return new XmlExporter();

            return null;
        }
    }
}
