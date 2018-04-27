using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Opera.model;
using System.IO;
using System.Xml.Serialization;

namespace Opera.designPatterns
{
    public class XmlExporter : Exporter
    {
        public void export(string numeSpectacol, List<Bilet> bilete)
        {
            string data = DateTime.Today.ToString("dd_MM_yyyy");
            string filename = "raport_" + numeSpectacol + ".xml";

            if (!Directory.Exists(@"../Export/xml/" + data)) Directory.CreateDirectory(@"../Export/xml/" + data);
            StreamWriter swBilet = File.CreateText(@"../Export/xml/" + data + "/" + filename);

            var serializer = new XmlSerializer(typeof(List<Bilet>));
            serializer.Serialize(swBilet, bilete);
        }
    }
}
